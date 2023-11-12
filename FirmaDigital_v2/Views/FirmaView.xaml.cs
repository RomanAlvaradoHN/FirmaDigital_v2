using FirmaDigital_v2.Models;

namespace FirmaDigital_v2.Views;

public partial class FirmaView : ContentPage
{
	Firmas firma;



	public FirmaView(Firmas firma)	{
		InitializeComponent();
		this.firma = firma;
	}


    protected override void OnAppearing() {
        base.OnAppearing();

        imgView.Source = ImageSource.FromFile(firma.FirmaFilePath);
    }
}