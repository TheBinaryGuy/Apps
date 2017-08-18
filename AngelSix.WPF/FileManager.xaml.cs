using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AngelSix.WPF
{
    /// <summary>
    /// Interaction logic for FileManager.xaml
    /// </summary>
    public partial class FileManager : Window
    {
        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public FileManager()
        {
            InitializeComponent();
        }
        #endregion

        #region On Loaded Event
        /// <summary>
        /// Fired Event when the application loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Get Logical Drives
            foreach (var drives in Directory.GetLogicalDrives())
            {
                // Create a new item
                var item = new TreeViewItem()
                {
                    // Set header and path
                    Header = drives,
                    Tag = drives
                };

                // Add a dummy item
                item.Items.Add(null);

                // Listen out for item being expanded
                item.Expanded += Folder_Expanded;

                // Add to the main TreeView
                folderView.Items.Add(item);
            }
        }
        #endregion

        #region Folder Expanded
        /// <summary>
        /// When a folder is expanded, find files/sub-folders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            #region Initial Checks

            var item = (TreeViewItem)sender;

            // If Item has dummy data
            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            // Clear dummy data
            item.Items.Clear();

            // Get Full Path
            var fullPath = (string)item.Tag;
            #endregion

            #region Get Folders

            var directories = new List<string>();

            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch { }

            directories.ForEach(directoryPath =>
            {
                // Create directory item
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(directoryPath),
                    Tag = directoryPath
                };

                // Add dummy item
                subItem.Items.Add(null);

                // Listen out for item being expanded
                subItem.Expanded += Folder_Expanded;

                // Add to the parent
                item.Items.Add(subItem);
            });
            #endregion

            #region Get Files

            var files = new List<string>();

            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    files.AddRange(fs);
            }
            catch { }

            files.ForEach(filePath =>
            {
                // Create file item
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(filePath),
                    Tag = filePath
                };

                // Add to the parent
                item.Items.Add(subItem);
            });
            #endregion
        }
        #endregion

        #region Helpers
        /// <summary>
        /// Find File or folder name
        /// </summary>
        /// <param name="path">The full directory path</param>
        /// <returns>Name of the File or Folder</returns>
        public static string GetFileFolderName(string path)
        {
            // If param is null, return empty string
            if (string.IsNullOrEmpty(path))
                return "";

            // Make all slashes back slashes
            var normalizedPath = path.Replace('/', '\\');

            // Find the last index of back slash
            var lastIndex = normalizedPath.LastIndexOf('\\');

            // If we don't find back slash
            if (lastIndex <= 0)
                return path;

            // Return name after last index (back slash)
            return path.Substring(lastIndex + 1);
        }
        #endregion
    }
}
