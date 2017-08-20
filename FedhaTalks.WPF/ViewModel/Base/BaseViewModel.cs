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

        /// <summary>
        /// Call this to fire <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name">Value to fire the event</param>
        public void OnPropertyChanged(string name) => PropertyChanged(this, new PropertyChangedEventArgs(name));
    }
}