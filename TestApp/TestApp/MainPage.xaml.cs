using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //Test variables
        public static Attack testAttack = new Attack(6, 3);
        public static List<AttackPage> attacks = new List<AttackPage>() { new AttackPage("One", testAttack), new AttackPage("Two", testAttack), new AttackPage("3333", testAttack) };
        //todo remove above
        public MainPage()
        {
            InitializeComponent();
        }

        //put update on load stuff here later
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
            await Navigation.PushModalAsync( new AttackCreationPage());
            //list.ItemsSource = attacks.ToList();
        }
        async void ListOfAttacks_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(e.Item as AttackPage);
        }
    }
}
