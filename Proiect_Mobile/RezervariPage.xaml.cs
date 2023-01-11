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
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((Rezervare)
       this.BindingContext)
        {
            BindingContext = new Product()
        });

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (Rezervare)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }
    async void OnDeleteItemButtonClicked(object sender, EventArgs e)
    {
        Product product;
        var shopList = (Rezervare)BindingContext;
        if (listView.SelectedItem != null)
        {
            product = listView.SelectedItem as Product;
            var listProductAll = await App.Database.GetListProducts();
            var listProduct = listProductAll.FindAll(x => x.ProductID == product.ID & x.RezervareID == shopList.ID);
            await App.Database.DeleteListProductAsync(listProduct.FirstOrDefault());
            await Navigation.PopAsync();
        }
    }
}