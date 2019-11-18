using MyNotes.Utilities;

namespace MyNotes.Models
{
    public class NoteCategory : NotificationObject
    {
        #region Properties
        private int m_id;
        /// <summary>
        /// Category id
        /// </summary>
        public int Id
        {
            get 
            { 
                return m_id; 
            }
            set 
            { 
                m_id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        private string m_name;
        /// <summary>
        /// Name of category
        /// </summary>
        public string Name
        {
            get 
            { 
                return m_name; 
            }
            set 
            { 
                m_name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        private NoteTheme m_theme;

        public NoteTheme Theme
        {
            get 
            { 
                return m_theme; 
            }
            set 
            {
                m_theme = value;
                RaisePropertyChanged(nameof(Theme));
            }
        }

        /// <summary>
        /// Override object.ToString() method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}