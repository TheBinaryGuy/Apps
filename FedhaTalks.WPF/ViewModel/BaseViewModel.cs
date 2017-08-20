using PropertyChanged;
using System.ComponentModel;

namespace FedhaTalks.WPF
{
    /// <summary>
    /// A base ViewModel that fires Property Changed Event as needed
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Event that gets fired if any property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}