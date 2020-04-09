using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class AttackCreationPage : ContentPage
    {
        private int? _modifier, _diceSize;
        Dictionary<string, int> Dice = new Dictionary<string, int>() { { "D2", 2 }, { "D3", 3 }, { "D4", 4 }, { "D6", 6 }, { "D8", 8 }, { "D12", 12 }, };

        public AttackCreationPage()
        {
            InitializeComponent();

            ModifierPicker.ItemsSource = SetSortedpickerNumbers(-5, 10);
            ProficiencyPicker.ItemsSource = SetSortedpickerNumbers(2, 5);
            DicePicker.ItemsSource = Dice.Keys.ToList();
        }
        private List<int> SetSortedpickerNumbers(int start, int end)
        {
            var numberList = Enumerable.Range(start, end - start).ToList();
            numberList.Reverse();
            return numberList;
        }

        void IsProficient_Clicked(object sender, EventArgs e) { ProficiencyPicker.IsVisible = IsProficient.IsChecked; }


        async void DoneAddAttackButton_Clicked(object sender, EventArgs e)
        {
            _modifier = int.Parse(ModifierPicker.SelectedItem.ToString());
            _diceSize = Dice[DicePicker.SelectedItem.ToString()];

            if (!string.IsNullOrEmpty(AttackNameEntry.Text) && _modifier != null && _diceSize != null)
            {                
                var newAttackPage = new AttackPage(AttackNameEntry.Text, new Attack(_diceSize ?? 0, _modifier ?? 0,int.Parse(ProficiencyPicker.SelectedItem.ToString())));
                MainPage.attacks.Add(newAttackPage);
                await Navigation.PopModalAsync();
            }
        }
    }
}