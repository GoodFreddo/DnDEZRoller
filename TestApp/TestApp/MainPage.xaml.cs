using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace TestApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //Test variables
        
        public static List<CharacterPage> characters = new List<CharacterPage>() {new CharacterPage("Henry"), new CharacterPage("Bob"), new CharacterPage("Timmy") };
        //todo remove initialisation of above
        public MainPage()
        {
            InitializeComponent();
        }

        //put update on load stuff here later
        protected override void OnAppearing()
        {
            ListOfCharacters.ItemsSource = characters.ToList();

        }

        void AddCharacterButton_Clicked(object sender, EventArgs e)
        {
            AddCharacterListItem(ListOfCharacters);
        }
        async void AddCharacterListItem(ListView list)
        {
            await Navigation.PushModalAsync(new CharacterCreationPage());
            list.ItemsSource = characters.ToList();
        }
        async void ListOfCharacters_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(e.Item as CharacterPage);
        }
    }
}
