using ListaTareasApp.MVVM.Models;
using ListaTareasApp.MVVM.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;


namespace ListaTareasApp.MVVM.ViewModels
{
    // vuelve a facer falta la INotifyPropertyChanged 
    public class VistaModeloTarea : INotifyPropertyChanged
    {
        #region variables, constantes objetos y demas

        //necesitamos una colecion pa mostar les tarees 
        public ObservableCollection<ModeloTarea> Tareas { get; set; } = new ObservableCollection<ModeloTarea>();

        // y una cte del tipo tarea 
        private ModeloTarea _tareaSeleccionada;

       
        #endregion

        #region PROPIEDADES DE VISTAMODELOTAREA

        //que son pa la tarea selecionada 
        //que devuelva el texto y lu pueda cmabiar 
        public ModeloTarea TareaSeleccionada
        {
            get => _tareaSeleccionada;
            set
            {
                if (_tareaSeleccionada != value)
                {
                    _tareaSeleccionada = value;
                    OnPropertyChanged(nameof(TareaSeleccionada));
                    OnPropertyChanged(nameof(EstaSeleccionada));
                }
            }
        }

       

        //propiedad pa que Estaselecionada devuelva true si esta seleccionada (no es null)

        public bool EstaSeleccionada
        {
            get
            {
                return TareaSeleccionada != null;
            }
        }

        #endregion


        #region COMANDOS
        public ICommand ComandoAniadirtarea { get; }
        public ICommand ComandoBorrartarea { get;}
        public ICommand ComandoCambiarPag { get; }

        #endregion

        #region metodos

        //constructor
        public VistaModeloTarea()
        {

            ComandoAniadirtarea = new Command(AniadirTarea);
            ComandoCambiarPag = new Command<ModeloTarea>(CambiarPag);
            ComandoBorrartarea = new Command<ModeloTarea>(BorrarTarea);
            PonerUnaAlPrincipioPaQueNoQuedeVacío();
        }

        

        // Método para agregar una nueva tarea 
        //bien yta xcon un textu predeterminau y sin completar 
        private void AniadirTarea()
        {
       Tareas.Add(new ModeloTarea {Nombre= "TAREA NUEVA", EstaCompletada = false });
        }

        // Método pa cambiar de vista 
        private async void CambiarPag(ModeloTarea tarea)
        {
            // si no ye nulo creamos una variable del tipo del modelo vista de la segunda vista con la tarea seleciona
            if (tarea != null)
            {

                var vistaModelo2 = new VistaModeloPag2(tarea);

                // y cambiamos a la otra pagina  que necesita que y pasemos el modelo de esa tarea  concreta

                var pagina2 = new Pagina2(tarea)
                {
                    BindingContext = vistaModelo2
                };

                await Application.Current.MainPage.Navigation.PushAsync(pagina2);
            }
        }

        private void BorrarTarea(ModeloTarea tareaBorrar)
        {
            if (tareaBorrar != null)
            {
                Tareas.Remove(tareaBorrar);
                if (TareaSeleccionada == tareaBorrar)
                {
                    TareaSeleccionada = null;
                    OnPropertyChanged(nameof(EstaSeleccionada));
                }
            }
        }


        //Método para añadir tareas de prueba 
        private void PonerUnaAlPrincipioPaQueNoQuedeVacío()
        {
            Tareas.Add(new ModeloTarea { Nombre = "Empezar a ponerme objetivos", EstaCompletada = false });
          

        }



        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
