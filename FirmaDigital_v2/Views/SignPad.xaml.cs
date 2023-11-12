using FirmaDigital_v2.Models;


namespace FirmaDigital_v2.Views;

public partial class SignPad : ContentPage
{
    private byte[] firmaImageArray;
    private string firmaImagePath;



    public SignPad(){
		InitializeComponent();
	}




    public async void OnPadSignedEvent(object sender, EventArgs args) {
        //Guardar el byte[] de la imagen de la firma
        using (MemoryStream ms = new MemoryStream()) {
            Stream st = await signPad.GetImageStream(signPad.Width, signPad.Height);
            await st.CopyToAsync(ms);
            firmaImageArray = ms.ToArray();
        }
    }






    public async void OnBtnGuardarClicked(object sender, EventArgs args) {
        try {

            //Guardado del archivo de imagen en fisico.
            firmaImagePath = Path.Combine(App.firmasDirectory, txtNombre.Text);
            using (FileStream firmaFile = File.OpenWrite(firmaImagePath)) {
                Stream st = new MemoryStream(firmaImageArray);
                await st.CopyToAsync(firmaFile);
            }

            //Instanciamos un nuevo objeto firma con los datos necesarios
            Firmas firma = new Firmas(
                firmaImageArray,
                firmaImagePath,
                txtNombre.Text,
                txtDescripcion.Text
            );

            //Si el objeto firma devuelve datos invalidos, lanzamos un alert
            if (!firma.GetDatosInvalidos().Any()) {
                await App.db.Insert(firma);
                LimpiarCampos();
                await DisplayAlert("Success", "Datos guardados", "Aceptar");

            } else {
                string msj = string.Join("\n", firma.GetDatosInvalidos());
                await DisplayAlert("Datos Invalidos:", msj, "Acepar");
            }

        } catch (Exception ex) {
            await DisplayAlert("Error:", ex.Message, "Aceptar");
        }
    }







    public async void OnBtnListaClicked(object sender, EventArgs args) {
        await Navigation.PushAsync(new Listado());
    }








    public void OnBtnLimpiarClicked(object sender, EventArgs args) {
        LimpiarCampos();
    }


    private void LimpiarCampos() {
        firmaImageArray = new byte[0];
        signPad.Clear();
        txtNombre.Text = string.Empty;
        txtDescripcion.Text = string.Empty;
    }

}