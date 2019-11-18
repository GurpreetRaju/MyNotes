using MyNotes.Utilities;
using Xamarin.Forms;

namespace MyNotes.ViewModels
{
    public abstract class ViewModelBase : NotificationObject
    {
        #region Properties
        /// <summary>
        /// Navigation page reference
        /// </summary>
        public INavigation Navigation 
        { 
            get; 
            set; 
        }

        #endregion
    }
}
