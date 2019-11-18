
using MyNotes.Models;
using MyNotes.ViewModels;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyNotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewNote : ContentPage
    {
        public NewNote()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Override base OnAppearing()
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var viewModel = new NewNoteViewModel();
            viewModel.Navigation = Navigation;
            viewModel.CategoryList = DataService.Instance.NoteCategories;
            BindingContext = viewModel;
            viewModel.NoteTitle = "My";
        }

        /// <summary>
        /// If editing existing note set the values to existing note's properties
        /// </summary>
        /// <param name="selectedNote">Note to be edited</param>
        public void SetNote(Note selectedNote)
        {
            var context = BindingContext as NewNoteViewModel;
            context.NoteId = selectedNote.Id; 
            context.NoteTitle = selectedNote.Title;
            context.NoteBody = selectedNote.Content;
            context.SelectedCategory = selectedNote.Category;
        }
    }
}