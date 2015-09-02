using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeHZ.HeroLab2MapTool.Core {
    
    /// <summary>
    /// This class exposes all required functions to handle relevant files used to create a MapTool token.
    /// </summary>
    public class DirectoryWalker {


        /// <summary>
        /// Keeps a reference to valid file extesions to be processed.
        /// </summary>
        private readonly string[] validExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".por" };


        /// <summary>
        /// Keeps a reference to the source directory.
        /// </summary>
        private readonly string m_directory;
        

        /// <summary>
        /// Keeps a reference to all valid files found.
        /// </summary>
        private IList<FileEntryMetadata> m_files;


        /// <summary>
        /// Raised when a valid file is found in the source directory.
        /// </summary>
        public event EventHandler<FileEntryEventArgs> FileFound;
        

        /// <summary>
        /// Creates a new instance of DirectoryWalker class qualified with full directory path.
        /// </summary>
        /// <param name="source">The full qualified path of directory to be walked.</param>
        public DirectoryWalker(string source) {
            if (string.IsNullOrWhiteSpace(source)) {
                throw new ArgumentNullException("source");
            }

            m_directory = source;
            m_files = new List<FileEntryMetadata>();
        }


        /// <summary>
        /// Gets an IEnumerable instance of all valid files found in source directory.
        /// </summary>
        public IEnumerable<FileEntryMetadata> Files {
            get {
                return m_files;
            }
        }


        /// <summary>
        /// Process all relevant files in the configured source directory.
        /// </summary>
        public void Process() {
            ProcessDirectory(m_directory);
        }


        /// <summary>
        /// Recursively process the walking directory looking out for all valid files.
        /// </summary>
        /// <param name="source">The full qualified path of directory to be processed.</param>
        private void ProcessDirectory(string source) {
            // Process the list of files found in the 'source' directory. 
            var fileEntries = Directory.EnumerateFiles(source, "*.*").Where(f => validExtensions.Contains(Path.GetExtension(f))).ToList();

            foreach (var fileName in fileEntries) {
                ExecuteAndCatchException(fileName, () => ProcessFile(fileName));
                OnFileFound(new FileEntryEventArgs { FilePath = fileName });
            }

            // Recurse into subdirectories of this directory. 
            var subdirectoryEntries = Directory.EnumerateDirectories(source);
            foreach (var subdirectory in subdirectoryEntries) {
                ExecuteAndCatchException(subdirectory, () => ProcessDirectory(subdirectory));
            }
        }


        /// <summary>
        /// Processes files and adds it to valid files collection.
        /// </summary>
        /// <param name="filePath">The full qualified path of file to be processed.</param>
        private void ProcessFile(string filePath) {
            var args = new FileEntryEventArgs(filePath);
            OnFileFound(args);

            var metadata = new FileEntryMetadata {
                Directory = args.FilePath,
                Extension = args.FileExtension,
                FileName  = args.FileName,
                FileType  = args.FileType,
                MatchLength = 0
            };

            m_files.Add(metadata);
        }


        /// <summary>
        /// Helper methopd to easily handle possible excetions.
        /// </summary>
        private void ExecuteAndCatchException(string source, Action action) {
            try {
                action();
            }
            catch (UnauthorizedAccessException e) {
                Console.WriteLine("There was an error with UnauthorizedAccessException on reading '{0}'. {1}", source, e.Message);
            }
            catch (Exception e) {
                Console.WriteLine("There was an unexpected error reading '{0}'. {1}", source, e.Message);
            }
        }


        /// <summary>
        /// Trigger the FileFound event for each valid file found.
        /// </summary>
        /// <param name="e">Instance of FileEntryEventArgs containing all relevant file information.</param>
        private void OnFileFound(FileEntryEventArgs e) {
            if (FileFound != null)
                FileFound(this, e);
        }
    }
}



//public delegate void TreeEntryEventHandler(object sender, TreeEntryEventArgs e);
//public event TreeEntryEventHandler ValidFile;