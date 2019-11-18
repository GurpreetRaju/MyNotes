using MyNotes.Models;
using MyNotes.Utilities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyNotes.ViewModels
{
    public class NewNoteViewModel : ViewModelBase
    {
        #region Properties
        /// <summary>
        /// Id of note, null if its a new note
        /// </summary>
        public int? NoteId
        {
            get; 
            set;
        }

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

        private List<NoteCategory> m_categoryList;
        /// <summary>
        /// Collection of note categories
        /// </summary>
        public List<NoteCategory> CategoryList 
        {
            get
            {
                return m_categoryList;
            }
            set
            {
                m_categoryList = value;
                RaisePropertyChanged(nameof(CategoryList));
            }
        }
        #endregion

        #region Constructor
        public NewNoteViewModel()
        { 
            //SelectedCategory = CategoryList?.First();
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
        async private void SaveNote(object param)
        {
            var note = new Note()
            {
                Title = NoteTitle,
                Content = NoteBody,
                Category = SelectedCategory
            };

            if (NoteId.HasValue)
            {
                note.Id = NoteId.Value;
                DataService.Instance.UpdateNote(note);
            }
            else
            {
                DataService.Instance.CreateNote(note);
            }

            await Navigation.PopAsync();
        }
        #endregion
    }
}
