using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

// Toolkit namespace
using SimpleMvvmToolkit;
using System.Collections;
using Esri.ArcGISRuntime.Layers;
using System.Collections.Generic;
using Esri.ArcGISRuntime.Controls;
using GISRuntimeMvvm.Views;

namespace GISRuntimeMvvm
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class MainPageViewModel : ViewModelBase<MainPageViewModel>
    {
        //Fields
        private ObservableCollection<Layer> _legendLayers = new ObservableCollection<Layer>()
        {
            new ArcGISTiledMapServiceLayer(new Uri("http://services.arcgisonline.com/ArcGIS/rest/services/World_Street_Map/MapServer"))
        };
        // TODO: Add a member for IXxxServiceAgent

        // Default ctor
        public MainPageViewModel() { }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        // TODO: Add properties using the mvvmprop code snippet
        public ObservableCollection<Layer> LegendLayers
        {
            get
            {
                return this._legendLayers;
            }
            set
            {
                if (this._legendLayers != value)
                {
                    this._legendLayers = value;
                    NotifyPropertyChanged(p => p.LegendLayers);
                }
            }
        }

        //TODO:  Add Commands
        public DelegateCommand<MapView> LoadCommand
        {
            get
            {
                return new DelegateCommand<MapView>(mapView =>
                {
                    LegendLayers = mapView.Map.Layers;
                   // LegendLayers.Add(new ArcGISTiledMapServiceLayer(new Uri("http://services.arcgisonline.com/ArcGIS/rest/services/World_Street_Map/MapServer")));
                });
            }
        }

        // TODO: Add methods that will be called by the view
        public void AddData()
        {
            var addDataView = new AddDataView();
            var addDataViewModel = addDataView.DataContext as AddDataViewModel;
            addDataViewModel.LegendLayers = LegendLayers;
            addDataView.ShowDialog();
        }
        // TODO: Optionally add callback methods for async calls to the service agent

        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }
    }
}