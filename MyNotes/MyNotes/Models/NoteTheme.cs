
using Xamarin.Forms;

namespace MyNotes.Models
{
    public class NoteTheme
    {
        #region Properties
        /// <summary>
        /// Name of color
        /// </summary>
        public string Name 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Color code for header
        /// </summary>
        public Color HeaderColor
        {
            get;
            set;
        }

        /// <summary>
        /// Color code for body
        /// </summary>
        public Color BodyColor
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 
        /// </summary>
        public Color FontColor 
        { 
            get; 
            set; 
        }
        #endregion
    }
}
