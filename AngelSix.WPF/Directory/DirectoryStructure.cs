using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
