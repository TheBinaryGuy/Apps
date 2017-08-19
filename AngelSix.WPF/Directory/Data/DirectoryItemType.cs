using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngelSix.WPF
{
    /// <summary>
    /// Type of directory item
    /// </summary>
    public enum DirectoryItemType
    {
        /// <summary>
        /// A Logical Drive
        /// </summary>
        Drive,
        /// <summary>
        /// A Physical File
        /// </summary>
        File,
        /// <summary>
        /// A Folder
        /// </summary>
        Folder
    }
}
