
using System.Collections.ObjectModel;
using System.Windows.Input;
using MyNotes.Models;
using MyNotes.Utilities;

namespace MyNotes.ViewModels
{
    public class NotesViewModel : NotificationObject
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public NotesViewModel()
        {
            AllNotes = new ObservableCollection<Note>();
            NewNoteCommand = new DelegateCommand(CreateNewNote, CanCreateNewNote);
            EditNoteCommand = new DelegateCommand(EditNote, CanEditNote);
        }
        #endregion

        #region Properties
        private Note m_selectedNote;
        /// <summary>
        /// Selected note
        /// </summary>
        public Note SelectedNote
        {
            get 
            { 
                return m_selectedNote; 
            }
            set 
            {
                if (m_selectedNote != value)
                {
                    m_selectedNote = value;
                    RaisePropertyChanged(nameof(SelectedNote));
                }
            }
        }


        /// <summary>
        /// All notes collection
        /// </summary>
        ObservableCollection<Note> AllNotes
        {
            get;
            set;
        }
        #endregion

        #region Commands and Command handlers
        /// <summary>
        /// New Note command
        /// </summary>
        public ICommand NewNoteCommand
        {
            get;
            set;
        }

        /// <summary>
        /// Edit note command
        /// </summary>
        public ICommand EditNoteCommand
        {
            get;
            set;
        }

        /// <summary>
        /// Can create new note
        /// </summary>
        /// <param name="param">parameters</param>
        /// <returns>True/False</returns>
        private bool CanCreateNewNote(object param)
        {
            return true;
        }

        /// <summary>
        /// Handle the logic to create a new note
        /// </summary>
        /// <param name="param"></param>
        private void CreateNewNote(object param)
        {

        }

        /// <summary>
        /// Can edit the selected note
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private bool CanEditNote(object param)
        {
            return true;
        }

        /// <summary>
        /// Handle the logic to edit note
        /// </summary>
        /// <param name="param"></param>
        private void EditNote(object param)
        {

        }
        #endregion
    }
}
