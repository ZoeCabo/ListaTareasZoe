using ListaTareasApp.MVVM.Models;
using ListaTareasApp.MVVM.ViewModels;

namespace ListaTareasApp.MVVM.Views;

public partial class Pagina2 : ContentPage
{
	public Pagina2( ModeloTarea tarea)
	{
		InitializeComponent();
        BindingContext = new VistaModeloPag2(tarea);
	}

    //evento para el boton guardar
    private async void Button_Clicked(object sender, EventArgs e)
    {    
        await Navigation.PopAsync();
    }
    

}