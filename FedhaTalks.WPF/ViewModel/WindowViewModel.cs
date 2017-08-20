using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FedhaTalks.WPF
{
    /// <summary>
    /// ViewModel for the custom flat window
    /// </summary>
    class WindowViewModel : BaseViewModel
    {
        #region Private Properties

        /// <summary>
        /// The window this VM controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// Margin around the window for the drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;

        /// <summary>
        /// Radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 10;

        #endregion

        #region Public Properties

        /// <summary>
        /// The size of the resize border around window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;
        /// <summary>
        /// Size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get => new Thickness(ResizeBorder + OuterMarginSize); }

        /// <summary>
        /// Margin around the window for the drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get => mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            set => mOuterMarginSize = value;
        }
        public Thickness OuterMarginSizeThickness { get => new Thickness(OuterMarginSize); }

        /// <summary>
        /// Radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get => mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            set => mOuterMarginSize = value;
        }
        public CornerRadius WindowCornerRadius { get => new CornerRadius(WindowRadius); }

        /// <summary>
        /// The height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="window">Current window</param>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            // Listen out for the window resizing
            window.StateChanged += (sender, e) =>
            {
                // Fire off the event for all the properties that are resized by the resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };
        }

        #endregion
    }
}
