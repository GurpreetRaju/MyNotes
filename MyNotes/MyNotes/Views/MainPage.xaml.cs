﻿using MyNotes.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyNotes.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new NotesViewModel();
            (BindingContext as ViewModelBase).Navigation = Navigation;
        }
    }
}
