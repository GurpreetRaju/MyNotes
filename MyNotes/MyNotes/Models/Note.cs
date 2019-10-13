
using MyNotes.Utilities;

namespace MyNotes.Models
{
    public class Note : NotificationObject
    {
        #region Fields
        private int m_id;

        private string m_title;
        
        private string m_content;
        #endregion

        #region Properties
        /// <summary>
        /// unique Id of note
        /// </summary>
        public int Id
        {
            get 
            { 
                return m_id; 
            }
            set {
                m_id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }

        /// <summary>
        /// Title for note
        /// </summary>
        public string Title
        {
            get 
            { 
                return m_title; 
            }
            set 
            { 
                m_title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        private NoteCategory m_category;
        /// <summary>
        /// Note category
        /// </summary>
        public NoteCategory Category
        {
            get 
            { 
                return m_category; 
            }
            set 
            { 
                m_category = value;
                RaisePropertyChanged(nameof(Category));
            }
        }


        /// <summary>
        /// Content of the note
        /// </summary>
        public string Content
        {
            get 
            { 
                return m_content; 
            }
            set 
            { 
                m_content = value;
                RaisePropertyChanged(nameof(Content));
            }
        }
        #endregion


    }
}
