using System.Collections.ObjectModel;
using System.Linq;

namespace AngelSix.WPF
{
    /// <summary>
    /// ViewModel for the Application's Main Directory View
    /// </summary>
    public class DirectoryStructureViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// A list of all directories on the machine
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DirectoryStructureViewModel()
        {
            Items = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetLogicalDrives().Select(drive => new DirectoryItemViewModel(drive.FullPath, drive.Type)));
        }

        #endregion
    }
}
