using MyNotes.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MyNotes.Models
{
    public class DataService : NotificationObject
    {
        #region Fields
        /// <summary>
        /// singleton instance
        /// </summary>
        private static DataService m_instance;
        #endregion

        #region Constructor
        /// <summary>
        /// Private contructor
        /// </summary>
        private DataService()
        {

        }
        #endregion

        #region Properties
        private List<NoteCategory> m_noteCategories;
        /// <summary>
        /// List of all the notes
        /// </summary>
        public List<NoteCategory> NoteCategories
        {
            get 
            {
                if (m_noteCategories == null)
                {
                    m_noteCategories = new List<NoteCategory>();
                    m_noteCategories.AddRange(GetNoteCategories());
                }
                return m_noteCategories; 
            }
        }

        private List<Note> m_notes;
        /// <summary>
        /// List of all the notes
        /// </summary>
        public List<Note> Notes
        {
            get
            {
                if (m_notes == null)
                {
                    m_notes = new List<Note>();
                    m_notes.Add(new Note()
                    {
                        Id = 1,
                        Title = "Hello",
                        Content = "Body",
                        Category = NoteCategories.First()
                    });
                }
                return m_notes;
            }
        }

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static DataService Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new DataService();

                return m_instance;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get the note categies
        /// </summary>
        /// <returns>List of Note Categories</returns>
        private List<NoteCategory> GetNoteCategories()
        {
            var categories = new List<NoteCategory>();


            var themeBlue = new NoteTheme() 
            { 
                Name = "Blue",
                HeaderColor = Color.FromHex("#2874A6"),
                BodyColor = Color.FromHex("#3498DB"),
                FontColor = Color.FromHex("#AED6F1")
            };

            var themeOrange = new NoteTheme()
            {
                Name = "Orange",
                HeaderColor = Color.FromHex("#ff9659"),
                BodyColor = Color.FromHex("#ffae80"),
                FontColor = Color.FromHex("#471c04")
            };

            categories.Add(new NoteCategory() { Id = 1, Name = "Kitchen", Theme = themeBlue });
            categories.Add(new NoteCategory() { Id = 2, Name = "Dining", Theme = themeOrange });
            
            return categories;
        }

        /// <summary>
        /// Update an existing note
        /// </summary>
        /// <param name="note"></param>
        public void UpdateNote(Note note)
        {
            var oldNote = Notes.FirstOrDefault(n => n.Id == note.Id);
            if (oldNote != null)
                Notes.Remove(oldNote);
            Notes.Insert(0, note);
            RaisePropertyChanged(nameof(Notes));
        }

        /// <summary>
        /// Create a new note
        /// </summary>
        /// <param name="newNote"></param>
        public void CreateNote(Note newNote)
        {
            int id = 0;
            if (Notes.Count() > 0)
            {
                id = Notes.Max(n => n.Id);
            }
            newNote.Id = id + 1;
            Notes.Insert(0, newNote);
            RaisePropertyChanged(nameof(Notes));
        }
        #endregion
    }
}
