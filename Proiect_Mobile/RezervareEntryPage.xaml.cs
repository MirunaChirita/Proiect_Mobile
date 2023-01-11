using Proiect_Mobile.Models;

namespace Proiect_Mobile;

public partial class RezervareEntryPage : ContentPage
{
	public RezervareEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetRezervareAsync();
    }
    async void OnRezervareAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RezervariPage
        {
            BindingContext = new Rezervare()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new RezervariPage
            {
                BindingContext = e.SelectedItem as Rezervare
            });
        }
    }

}