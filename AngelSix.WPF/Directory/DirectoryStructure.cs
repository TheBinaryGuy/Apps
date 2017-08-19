using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AngelSix.WPF
{
    /// <summary>
    /// Helper class to query information about directories
    /// </summary>
    public static class DirectoryStructure
    {
        /// <summary>
        /// Gets all Logical Drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            // Get Logical Drives
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }

        /// <summary>
        /// Gets the directory's top level content
        /// </summary>
        /// <param name="fullPath">Full path to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContent(string fullPath)
        {
            // Create Empty List
            var items = new List<DirectoryItem>();

            #region Get Folders

            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
            }
            catch { }

            #endregion

            #region Get Files

            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
            }
            catch { }

            #endregion

            return items;
        }

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
