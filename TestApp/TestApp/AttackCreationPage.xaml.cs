using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class AttackCreationPage : ContentPage
    {
        readonly Dictionary<string, int> Dice = new Dictionary<string, int>() { { "D2", 2 }, { "D3", 3 }, { "D4", 4 }, { "D6", 6 }, { "D8", 8 }, { "D12", 12 } };

        CharacterPage _parentCharacterPage;

        public AttackCreationPage(CharacterPage parentCharcterPage)
        {
            InitializeComponent();

            ModifierPicker.ItemsSource = parentCharcterPage._character.modifiers.Keys.ToList();


            DicePicker.ItemsSource = Dice.Keys.ToList();
            _parentCharacterPage = parentCharcterPage;
        }

        async void DoneAddAttackButton_Clicked(object sender, EventArgs e)
        {



            if (ModifierPicker.SelectedItem != null && DicePicker.SelectedItem != null && !string.IsNullOrEmpty(AttackNameEntry.Text))
            {
                int _modifier = _parentCharacterPage._character.modifiers[(string)ModifierPicker.SelectedItem];
                int _proficiency = IsProficient.IsChecked ? _parentCharacterPage._character.proficiencyBonus : 0;
                int _diceSize = Dice[DicePicker.SelectedItem.ToString()];
                var newAttackPage = new AttackPage(AttackNameEntry.Text, new Attack(_diceSize, _modifier, _proficiency), _parentCharacterPage); ;
                _parentCharacterPage.attacks.Add(newAttackPage);
                await Navigation.PopModalAsync();
            }
            else return;

        }
    }
}