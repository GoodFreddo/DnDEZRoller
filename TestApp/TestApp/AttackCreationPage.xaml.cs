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
        private int? _diceSize;
        Dictionary<string, int> Dice = new Dictionary<string, int>() { { "D2", 2 }, { "D3", 3 }, { "D4", 4 }, { "D6", 6 }, { "D8", 8 }, { "D12", 12 } };
        CharacterPage _parentCharacter;

        public AttackCreationPage(CharacterPage parentCharcter)
        {
            InitializeComponent();

            ModifierPicker.ItemsSource = SetSortedpickerNumbers(-5, 10);

            ProficiencyPicker.ItemsSource = ConstructProficiencyList();
            ProficiencyPicker.SelectedItem = 0;
            DicePicker.ItemsSource = Dice.Keys.ToList();
            _parentCharacter = parentCharcter;
        }

        private IList ConstructProficiencyList()
        {
            var proficiencyList = SetSortedpickerNumbers(0, 6);
            proficiencyList.Remove(1);
            return proficiencyList;
        }

        private List<int> SetSortedpickerNumbers(int start, int end)
        {
            var numberList = Enumerable.Range(start, end + 1 - start).ToList();
            numberList.Reverse();
            return numberList;
        }

        void IsProficient_Clicked(object sender, EventArgs e)
        {
            ProficiencyStack.IsVisible = IsProficient.IsChecked;
            if (!IsProficient.IsChecked) { ProficiencyPicker.SelectedItem = 0; }
        }


        async void DoneAddAttackButton_Clicked(object sender, EventArgs e)
        {

            if (ModifierPicker.SelectedItem != null && DicePicker.SelectedItem != null)
            {
                int.TryParse(ProficiencyPicker.SelectedItem.ToString(), out int _proficiency);
                int.TryParse(ModifierPicker.SelectedItem.ToString(), out int _modifier);
                _diceSize = Dice[DicePicker.SelectedItem.ToString()];
                if (!string.IsNullOrEmpty(AttackNameEntry.Text) && _diceSize != null)
                {
                    
                    var newAttackPage = new AttackPage(AttackNameEntry.Text, new Attack(_diceSize ?? 0, _modifier, _proficiency),_parentCharacter);

                    _parentCharacter.attacks.Add(newAttackPage);
                    await Navigation.PopModalAsync();
                }
            }
            else return;

        }
    }
}