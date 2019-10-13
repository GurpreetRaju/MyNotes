using MyNotes.Models;
using MyNotes.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MyNotes.ViewModels
{
    public class NewNoteViewModel : NotificationObject
    {
        #region Properties
        private string m_noteTitle;
        /// <summary>
        /// Title for note
        /// </summary>
        public string NoteTitle
        {
            get 
            { 
                return m_noteTitle; 
            }
            set 
            { 
                m_noteTitle = value;
                RaisePropertyChanged(nameof(NoteTitle));
            }
        }

        private string m_noteBody;
        /// <summary>
        /// Content of note
        /// </summary>
        public string NoteBody
        {
            get 
            {
                return m_noteBody; 
            }
            set 
            { 
                m_noteBody = value;
                RaisePropertyChanged(nameof(NoteBody));
            }
        }


        private NoteCategory m_selectedCategory;
        /// <summary>
        /// Notes category list
        /// </summary>
        public NoteCategory SelectedCategory
        {
            get 
            { 
                return m_selectedCategory; 
            }
            set 
            {
                if (m_selectedCategory != value)
                {
                    m_selectedCategory = value;
                    RaisePropertyChanged(nameof(SelectedCategory));
                }
            }
        }

        /// <summary>
        /// Collection of note categories
        /// </summary>
        public ObservableCollection<NoteCategory> CategoryList 
        { 
            get; 
            set; 
        }
        #endregion

        #region Constructor
        public NewNoteViewModel()
        {
            CategoryList = new ObservableCollection<NoteCategory>();
            SaveNoteCommand = new DelegateCommand(SaveNote, CanSaveNote);
        }
        #endregion

        #region Commands and Command handlers
        /// <summary>
        /// Save note command
        /// </summary>
        public ICommand SaveNoteCommand
        {
            get;
            set;
        }

        /// <summary>
        /// Can save note execute
        /// </summary>
        /// <returns></returns>
        private bool CanSaveNote(object param)
        {
            return true;
        }
        
        /// <summary>
        /// Save note handler
        /// </summary>
        private void SaveNote(object param)
        {

        }
        #endregion
    }
}
