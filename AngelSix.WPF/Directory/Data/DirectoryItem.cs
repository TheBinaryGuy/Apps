using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelSix.WPF
{
    /// <summary>
    /// Info about directory item such as drive, file, folder
    /// </summary>
    public class DirectoryItem
    {
        /// <summary>
        /// Type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The absolute path to the item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// Name of the directory item
        /// </summary>
        public string Name { get => this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(FullPath); }
    }
}
