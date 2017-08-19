using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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

        
    }
}
