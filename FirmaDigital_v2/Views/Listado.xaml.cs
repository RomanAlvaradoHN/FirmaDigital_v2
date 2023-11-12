using FirmaDigital_v2.Models;
namespace FirmaDigital_v2.Views;

public partial class Listado : ContentPage
{
	public Listado(){
		InitializeComponent();
	}



    protected override async void OnAppearing() {
        base.OnAppearing();
        viewListado.ItemsSource = await App.db.SelectAll();
    }





    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args) {
        await Navigation.PushAsync(new FirmaView(args.SelectedItem as Firmas));
    }



}