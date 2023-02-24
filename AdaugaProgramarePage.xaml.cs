using ProgramareRevizie.Models;

namespace ProgramareRevizie;

public partial class AdaugaProgramarePage : ContentPage
{
	public AdaugaProgramarePage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetProgramaresAsync();
    }
    async void OnProgramareAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListaProgramariPage
        {
            BindingContext = new Programare()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ListaProgramariPage
            {
                BindingContext = e.SelectedItem as Programare
            });
        }
    }
}