using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DnDEZRoller
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterCreationPage : ContentPage
    {
        public CharacterCreationPage()
        {

            InitializeComponent();
            var statPickerList = new List<Picker>() { StrengthValuePicker, ConstitutionValuePicker, DexterityValuePicker, WisdomValuePicker, CharismaValuePicker, IntelligenceValuePicker };
            foreach (var picker in statPickerList)
            {
                picker.ItemsSource = Enumerable.Range(6, 19).ToList();
                picker.SelectedIndex = 3;
            }
            CharacterLevelValuePicker.ItemsSource = Enumerable.Range(1, 20).ToList();
            CharacterLevelValuePicker.SelectedIndex = 0;
        }

        async void CharacterDoneButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CharacterNameEntry.Text))
            {
                var characterPage = new CharacterPage(new Character(CharacterNameEntry.Text
                                                                    , Strength: (int)StrengthValuePicker.SelectedItem
                                                                    , Constitution: (int)ConstitutionValuePicker.SelectedItem
                                                                    , Dexterity: (int)DexterityValuePicker.SelectedItem
                                                                    , Wisdom: (int)WisdomValuePicker.SelectedItem
                                                                    , Charisma: (int)CharismaValuePicker.SelectedItem
                                                                    , Intelligence: (int)IntelligenceValuePicker.SelectedItem
                                                                    , Level: (int)CharacterLevelValuePicker.SelectedItem
                                                                    ));
                MainPage.characters.Add(characterPage);
                await Navigation.PopModalAsync();
            }
        }
    }
}