using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;
using System.Linq;
// Toolkit namespace
using SimpleMvvmToolkit;
using System.Collections;
using Esri.ArcGISRuntime.Layers;
using System.Collections.Generic;
using Esri.ArcGISRuntime.Controls;
using GISRuntimeMvvm.Views;
using System.Reflection;

namespace GISRuntimeMvvm
{
    /// <summary>
    /// 主页面ViewModel
    /// 2017/05/14 fhr
    /// </summary>
    public class MainPageViewModel : ViewModelBase<MainPageViewModel>
    {
        private static Assembly arcGISAssembly = Assembly.Load("Esri.ArcGISRuntime");

        private ObservableCollection<Layer> _legendLayers = new ObservableCollection<Layer>()
        {
            new ArcGISTiledMapServiceLayer(new Uri("http://services.arcgisonline.com/ArcGIS/rest/services/World_Street_Map/MapServer"))
        };

        public MainPageViewModel() { }

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
                    new ArcGISDynamicMapServiceLayer();
                   // LegendLayers.Add(new ArcGISTiledMapServiceLayer(new Uri("http://services.arcgisonline.com/ArcGIS/rest/services/World_Street_Map/MapServer")));
                });
            }
        }

        public DelegateCommand<string> AddNormalServiceLayerCommand
        {
            get
            {
                return new DelegateCommand<string>((layerName) =>
                {
                    var addDataView = new AddServiceLayerView();
                    var addDataViewModel = addDataView.DataContext as AddServiceLayerViewModel;
                    addDataViewModel.LegendLayers = LegendLayers;
                    addDataViewModel.ServiceLayerType = arcGISAssembly.GetType(layerName);
                    addDataView.ShowDialog();
                });
            }
        }
        public DelegateCommand AddLocalNormalLayerCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var addNLView = new AddLocalNormalLayerView();
                    var addNLViewModel = addNLView.DataContext as AddLocalNormalLayerViewModel;
                    addNLViewModel.LegendLayers = LegendLayers;
                    addNLView.ShowDialog();
                });
            }
        }

        // TODO: Add methods that will be called by the view
        public void AddData()
        {
            
        }
        public void AddOpenStreet()
        {
            foreach (var layer in _legendLayers)
            {
                if (layer.GetType() == typeof(OpenStreetMapLayer))
                {
                    MessageBox.Show("已经存在OpenLayer图层，不必重新添加");
                }
            }
            _legendLayers.Add(new OpenStreetMapLayer());
        }
        // TODO: Optionally add callback methods for async calls to the service agent
        // ...

        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;
        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }
    }
}