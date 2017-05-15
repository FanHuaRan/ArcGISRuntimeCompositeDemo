using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

// Toolkit namespace
using SimpleMvvmToolkit;
using Esri.ArcGISRuntime.Layers;
using Microsoft.Win32;
using Esri.ArcGISRuntime.LocalServices;
using Esri.ArcGISRuntime.Data;

namespace GISRuntimeMvvm
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class AddLocalNormalLayerViewModel : ViewModelBase<AddLocalNormalLayerViewModel>
    {

        private string _displayName;

        private string _filePath;
        public string DisplayName
        {
            get { return _displayName; }
            set
            {
                if (_displayName != value)
                {
                    _displayName = value;
                    NotifyPropertyChanged(p => p.DisplayName);
                }
            }
        }

        public string FilePath
        {
            get { return _filePath; }
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    NotifyPropertyChanged(p => p.FilePath);
                }
            }
        }

        /// <summary>
        /// 主地图图层集合
        /// </summary>
        public ObservableCollection<Layer> LegendLayers { get; set; } 

        /// <summary>
        /// 图层添加命令 
        /// </summary>
        public DelegateCommand<Window> AddLayerCommand
        {
            get
            {
                return new DelegateCommand<Window>(async window =>
                {
                    Layer layer = null;
                    var extension = System.IO.Path.GetExtension(_filePath);
                    if (extension == ".mpk")
                    {
                        LocalMapService localMapService = new LocalMapService(_filePath);
                        await localMapService.StartAsync();
                        layer = new ArcGISDynamicMapServiceLayer()
                        {
                            ID = System.IO.Path.GetFileNameWithoutExtension(_filePath),
                            DisplayName = _displayName,
                            ServiceUri = localMapService.UrlMapService,
                        };
                    }
                    else if (extension == ".tpk")
                    {
                        layer = new ArcGISLocalTiledLayer(_filePath)
                        {
                            DisplayName = _displayName
                        };
                    }
                    else
                    {
                        var shapefile = await ShapefileTable.OpenAsync(_filePath);
                        layer = new FeatureLayer(shapefile)
                        {
                            ID = shapefile.Name,
                            DisplayName = _displayName,
                        };
                    }
                    this.LegendLayers.Add(layer);
                });
            }
        }

        public DelegateCommand ChooseFileCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "*.mpk|*.mpk|*.tpk|*.tpk|*.shp|*.shp";
                    if (openFileDialog.ShowDialog() == true)
                    {
                        FilePath= openFileDialog.FileName;
                    }
                });
            }
        }

        /// <summary>
        /// 窗口关闭命令
        /// </summary>
        public DelegateCommand<Window> CloseCommand
        {
            get
            {
                return new DelegateCommand<Window>(window =>
                {
                    window.Close();
                });
            }
        }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }
    }
}