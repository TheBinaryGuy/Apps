using System.Windows;

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

            DataContext = new DirectoryStructureViewModel();
        }

        #endregion        
    }
}
