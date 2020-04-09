using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AttackPage : ContentPage
    {
        public string AttackName { get; set; }
        private Attack _attack { get; set; }
        public AttackPage(string attackName, Attack attack)
        {
            InitializeComponent();
            AttackNameLabel.Text = attackName;
            AttackNameToolbarItem.Text = attackName;
            AttackName = attackName;
            _attack = attack;
        }
        async void AttackDeleteToolbarItem_Clicked(object sender, EventArgs e)
        {
            MainPage.attacks.Remove(this);
            await Navigation.PopAsync();
        }

        private void HitButton_Clicked(object sender, EventArgs e)
        {
            AttackHitScore.Text = "To Hit: " + _attack.rollforAttack().ToString();
            AttackDamageScore.Text = "Damage: " + _attack.rollforDamage().ToString();
        }
    }
}