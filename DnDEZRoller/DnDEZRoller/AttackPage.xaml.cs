using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDEZRoller
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AttackPage : ContentPage
    {
        public string AttackName { get; set; }
        private Attack _attack { get; set; }
        private CharacterPage _characterPageParent;


        public AttackPage(string attackName, Attack attack, CharacterPage characterPageParent)
        {
            InitializeComponent();
            AttackNameLabel.Text = attackName;
            AttackNameToolbarItem.Text = attackName;
            AttackName = attackName;
            _attack = attack;
            _characterPageParent = characterPageParent;
        }

        async void AttackDeleteToolbarItem_Clicked(object sender, EventArgs e)
        {
            _characterPageParent.attacks.Remove(this);
            await Navigation.PopAsync();
        }

        private void HitButton_Clicked(object sender, EventArgs e)
        {
            AttackHitScore.Text = "To Hit: " + _attack.rollforAttack().ToString();
            AttackDamageScore.Text = "Damage: " + _attack.RollforDamage().ToString();
        }
    }
}