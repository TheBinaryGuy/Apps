using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace AngelSix.WPF
{
    /// <summary>
    /// ViewModel for each directory item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Type of the item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// Full Path to the item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// Name of the directory item
        /// </summary>
        public string Name { get => this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(FullPath); }

        /// <summary>
        /// List of all children inside the item
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        /// <summary>
        /// Checks if the item can be expanded
        /// </summary>
        public bool CanExpand { get => this.Type != DirectoryItemType.File; }

        /// <summary>
        /// Checks if the current directory is expanded and also expands it if necessary
        /// </summary>
        public bool IsExpanded
        {
            get => Children?.Count(f => f != null) > 0;
            set
            {
                // If UI tells us to expand
                if (value == true)
                    // Find all Children
                    Expand();
                // If UI tells us to close
                else
                    // Clears all Children
                    ClearChildren();

            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="fullPath">Full path to the item</param>
        /// <param name="type">Type of the item (Drive, Folder or File)</param>
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            // Create Command
            ExpandCommand = new RelayCommand(Expand);

            // Set path and type
            FullPath = fullPath;
            Type = type;

            // Setup the Children as needed
            ClearChildren();
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// Command to expand the item
        /// </summary>
        public ICommand ExpandCommand { get; set; }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Clears all the Children of the item and adds the dummy item to show the expand icon if required
        /// </summary>
        private void ClearChildren()
        {
            // Clear items
            Children = new ObservableCollection<DirectoryItemViewModel>();

            // Show the expand arrow if we are not a file
            if (Type != DirectoryItemType.File)
                Children.Add(null);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Expands the directory and finds all the children
        /// </summary>
        private void Expand()
        {
            // We can not expand a file
            if (Type == DirectoryItemType.File)
                return;

            // Find all Children
            Children = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetDirectoryContents(FullPath)
                .Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }

        #endregion
    }
}
