using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

// Toolkit namespace
using SimpleMvvmToolkit;
using Esri.ArcGISRuntime.Layers;

namespace GISRuntimeMvvm
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class AddDataViewModel : ViewModelBase<AddDataViewModel>
    {
        //Fields
        private ObservableCollection<Layer> _legendLayers = new ObservableCollection<Layer>();
        // Default ctor
        public AddDataViewModel() { }

        
        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        // TODO: Add properties using the mvvmprop code snippet
        public ObservableCollection<Layer> LegendLayers
        {
            get
            {
                return _legendLayers;
            }
            set
            {
                if (_legendLayers != value)
                {
                    this._legendLayers = value;
                    NotifyPropertyChanged(p => p.LegendLayers);
                }
            }
        }
        // TODO: Add methods that will be called by the view

        // TODO: Optionally add callback methods for async calls to the service agent
        
        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }
    }
}