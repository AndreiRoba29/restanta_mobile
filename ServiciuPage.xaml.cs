using ProgramareRevizie.Models;

namespace ProgramareRevizie;

public partial class ServiciuPage : ContentPage
{
    Programare sl;
    public ServiciuPage(Programare slist)
    {
        InitializeComponent();
        sl = slist;

    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var Serviciu = (Serviciu)BindingContext;
        await App.Database.SaveServiciuAsync(Serviciu);
        listView.ItemsSource = await App.Database.GetServiciusAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var Serviciu = (Serviciu)BindingContext;
        await App.Database.DeleteServiciuAsync(Serviciu);
        listView.ItemsSource = await App.Database.GetServiciusAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetServiciusAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Serviciu p;
        if (listView.SelectedItem != null)
        {
            p = listView.SelectedItem as Serviciu;
            var lp = new ListaServicii()
            {
                ProgramareID = sl.ID,
                ServiciuID = p.ID
            };
            await App.Database.SaveListaServiciiAsync(lp);
            p.ListaServiciis = new List<ListaServicii> { lp };
            await Navigation.PopAsync();
        }
    }


       
}
