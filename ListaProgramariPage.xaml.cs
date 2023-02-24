using ProgramareRevizie.Models;
namespace ProgramareRevizie;

public partial class ListaProgramariPage : ContentPage
{
    public ListaProgramariPage()
	{
		InitializeComponent();
	}

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ServiciuPage((Programare)
       this.BindingContext)
        {
            BindingContext = new Serviciu()
        });

    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Programare)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveProgramareAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Programare)BindingContext;
        await App.Database.DeleteProgramareAsync(slist);
        await Navigation.PopAsync();
    }

    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        Serviciu Serviciu;
        var Programare = (Programare)BindingContext;
        if(listView.SelectedItem != null)
        {
            Serviciu = listView.SelectedItem as Serviciu;
            var ListaServiciiAll = await App.Database.GetListaServiciis();
            var ListaServicii = ListaServiciiAll.FindAll(x => x.ServiciuID == Serviciu.ID & x.ProgramareID == Programare.ID);
            await App.Database.DeleteListaServiciiAsync(ListaServicii.FirstOrDefault());
            await Navigation.PopAsync();
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (Programare)BindingContext;

        listView.ItemsSource = await App.Database.GetListaServiciisAsync(shopl.ID);
    }

}