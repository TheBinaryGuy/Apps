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

            this.DataContext = new DirectoryStructureViewModel();
        }

        #endregion        
    }
}
