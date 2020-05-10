using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDEZRoller
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterPage : ContentPage
    {
        public Character _character;
        public string CharacterName { get; set; }
        public Attack testAttack = new Attack(6, 3, 2);
        public List<AttackPage> attacks = new List<AttackPage>();

        public CharacterPage(Character character)
        {
            InitializeComponent();
            CharacterName = character.characterName;
            CharcterNameToolbarItem.Text = character.characterName;
            _character = character;
            //test data
            AttackPage[] attackPages = { new AttackPage("One", testAttack, this), new AttackPage("Two", testAttack, this), new AttackPage("3333", testAttack, this) };
            attacks.AddRange(attackPages);
            //todo remove above
        }
        protected override void OnAppearing()
        {
            ListOfAttacks.ItemsSource = attacks.ToList();

        }


        void AddAttackButton_Clicked(object sender, EventArgs e)
        {
            AddAttackListItem(ListOfAttacks);
        }
        async void AddAttackListItem(ListView list)
        {
            await Navigation.PushModalAsync(new AttackCreationPage(this));
            list.ItemsSource = attacks.ToList();
        }
        public async void ListOfAttacks_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(e.Item as AttackPage);
        }
        public async void CharacterDeleteToolbarItem_Clicked(object sender, EventArgs e) { }
    }
}