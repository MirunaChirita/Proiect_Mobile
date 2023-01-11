namespace Proiect_Mobile;
using Proiect_Mobile.Models;
using Proiect_Mobile.Data;
using SQLite;

public partial class RezervariPage : ContentPage
{
	public RezervariPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Rezervare)BindingContext;
        slist.DataProgramare = DateTime.UtcNow;
        await App.Database.SaveRezervareAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Rezervare)BindingContext;
        await App.Database.DeleteRezervareAsync(slist);
        await Navigation.PopAsync();
    }

}