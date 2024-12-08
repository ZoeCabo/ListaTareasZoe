using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTareasApp.MVVM.Models
{
    //INotifyPropertyChanged  fae falta pa que notifique los cambios a tiempu real 
    public class ModeloTarea : INotifyPropertyChanged
    {

        #region variables, constantes objetos y demas
        //les tarees que son con lo que vamos a furrular trienen un nombre (que ye el texto que van a mostrar y un estado de completacaión)
        private string? _nombre;
        private bool _estaCompletada;
        #endregion

        #region PROPIEDADES DE MODELOTAREA

        //la del nombre 
        public string Nombre
        {
            //devuelve el texto 
            get => _nombre;

            //cuando se haz el set con el texto nuevu sobreeescribir y que al usar el metodo  OnPropertyChanged se muestre a utomatico el cambio
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    OnPropertyChanged(nameof(Nombre));
                }
            }
        }

        //la del booleanu del etao
        public bool EstaCompletada
        {
            //devuelve true si ta completa false si no
            get => _estaCompletada;
            set
            {
                if (_estaCompletada != value)
                {
                    _estaCompletada = value;
                    OnPropertyChanged(nameof(EstaCompletada));
                }
            }
        }
        #endregion


        #region METODOS AUTOGENERAOS POR Y PA LA INTERFACE 
        
        public event PropertyChangedEventHandler? PropertyChanged;

                
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
