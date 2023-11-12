using FirmaDigital_v2.Controllers;
using FirmaDigital_v2.Views;


namespace FirmaDigital_v2 {
    public partial class App : Application {
        public static readonly DBController db = new DBController();
        public static readonly string firmasDirectory = Path.Combine(FileSystem.AppDataDirectory, "Firmas");


        public App() {
            InitializeComponent();

            //valida existencia del directorio de las firmas, si no existe, lo crea.
            if (!Directory.Exists(firmasDirectory)) {
                Directory.CreateDirectory(firmasDirectory);
            }

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new SignPad());
        }
    }
}