using Microsoft.Maui.Controls;

using PasswordGenerator.Models;
using PasswordGenerator.Models.ViewModels;

namespace PasswordGenerator.Views
{
    public partial class AddAccount : ContentPage
    {
        private readonly AddAccountViewModel _viewModel;
        public AddAccount(AddAccountViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
        }
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await _viewModel.AddAccountAsync();

                if (!result.Success)
                {
                    await DisplayAlert("Error", result.Message, "OK");
                    return;
                }

                await DisplayAlert("Saved", "Changes have been saved.", "OK");

                Vault vaultPage = ((App)Application.Current).Services.GetService<Vault>();
                await Navigation.PushAsync(vaultPage);

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

        }
    }
}


