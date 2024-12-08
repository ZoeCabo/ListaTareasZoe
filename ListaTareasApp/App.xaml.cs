using ListaTareasApp.MVVM.Views;

namespace ListaTareasApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //navigation page para facilitar el pasar a la otra 
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
