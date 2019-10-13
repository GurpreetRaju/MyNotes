
namespace MyNotes.Utilities
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
        public string HeaderColorCode
        {
            get;
            set;
        }

        /// <summary>
        /// Color code for body
        /// </summary>
        public string BodyColorCode 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 
        /// </summary>
        public string FontColorCode 
        { 
            get; 
            set; 
        }
        #endregion
    }
}
