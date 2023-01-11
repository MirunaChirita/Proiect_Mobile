namespace Proiect_Mobile;
using Proiect_Mobile.Models;

public partial class ScoalaEntryPage : ContentPage
{
	public ScoalaEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetScoalaAsync();
    }
    async void OnShopAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ScoalaPage
        {
            BindingContext = new Scoala()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ScoalaPage
            {
                BindingContext = e.SelectedItem as Scoala
            });
        }
    }

}