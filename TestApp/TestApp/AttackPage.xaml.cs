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
        private CharacterPage _parent;
        

        public AttackPage(string attackName, Attack attack, CharacterPage parent)
        {
            InitializeComponent();
            AttackNameLabel.Text = attackName;
            AttackNameToolbarItem.Text = attackName;
            AttackName = attackName;
            _attack = attack;
            _parent = parent;
        }

        async void AttackDeleteToolbarItem_Clicked(object sender, EventArgs e)
        {
            _parent.attacks.Remove(this);
            await Navigation.PopAsync();
        }

        private void HitButton_Clicked(object sender, EventArgs e)
        {
            AttackHitScore.Text = "To Hit: " + _attack.rollforAttack().ToString();
            AttackDamageScore.Text = "Damage: " + _attack.rollforDamage().ToString();
        }
    }
}