using ListaTareasApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTareasApp.MVVM.ViewModels
{
    class VistaModeloPag2 : INotifyPropertyChanged
    {
        private ModeloTarea _TareaSeleccionada;

        

        public ModeloTarea TareaSeleccionada
        {
            get => _TareaSeleccionada;
            set
            {
                if (_TareaSeleccionada != value)
                {
                    _TareaSeleccionada = value;
                    OnPropertyChanged(nameof(TareaSeleccionada));
                }
            }
        }
        
        // Constructor para recibir la tarea
        public   VistaModeloPag2  (ModeloTarea tarea)
        {
            TareaSeleccionada = tarea;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}