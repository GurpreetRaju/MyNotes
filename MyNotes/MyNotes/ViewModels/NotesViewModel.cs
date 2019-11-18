
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using MyNotes.Models;
using MyNotes.Utilities;
using MyNotes.Views;

namespace MyNotes.ViewModels
{
    public class NotesViewModel : ViewModelBase
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public NotesViewModel()
        {
            AllNotes = new ObservableCollection<Note>(DataService.Instance.Notes);
            NewNoteCommand = new DelegateCommand(CreateNewNote, CanCreateNewNote);
            EditNoteCommand = new DelegateCommand(EditNote, CanEditNote);
            DataService.Instance.PropertyChanged += OnDataServiceChanged;
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
        public ObservableCollection<Note> AllNotes
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
        async private void CreateNewNote(object param)
        {
            var newNote = new NewNote();
            await Navigation.PushAsync(newNote);
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
        async private void EditNote(object param)
        {
            var editNote = new NewNote();
            editNote.SetNote(SelectedNote);
            await Navigation.PushAsync(editNote);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Update the notes when Notes event is triggered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDataServiceChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Notes")
            {
                AllNotes.Clear();
                foreach(Note n in DataService.Instance.Notes)
                {
                    AllNotes.Add(n);
                }
            }
        }
        #endregion
    }
}
