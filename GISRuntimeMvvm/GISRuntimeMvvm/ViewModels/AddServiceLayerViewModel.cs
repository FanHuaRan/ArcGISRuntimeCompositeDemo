using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

// Toolkit namespace
using SimpleMvvmToolkit;
using Esri.ArcGISRuntime.Layers;
using Esri.ArcGISRuntime.Data;

namespace GISRuntimeMvvm
{
   /// <summary>
   /// 服务图层添加ViewModel
   /// 2017/05/14
   /// </summary>
    public class AddServiceLayerViewModel : ViewModelBase<AddServiceLayerViewModel>
    {
        //图层名称字段
        private String _displayName;
        //图层地址字段
        private string _serviceUrl;
        /// <summary>
        /// 添加图层类型
        /// </summary>
        public Type ServiceLayerType { get; set; }
        /// <summary>
        /// 图层名称属性
        /// </summary>
        public String DisplayName
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
        /// <summary>
        /// 图层地址属性
        /// </summary>
        public string ServiceUrl
        {
            get { return _serviceUrl; }
            set
            {
                if (_serviceUrl != value)
                {
                    _serviceUrl = value;
                    NotifyPropertyChanged(p => p.ServiceUrl);
                }
            }
        }
        /// <summary>
        /// 主地图图层集合
        /// </summary>
        public ObservableCollection<Layer> LegendLayers { get; set; }
        /// <summary>
        /// 图层添加命令 实例化图层应用了反射
        /// </summary>
        public DelegateCommand<Window> AddLayerCommand
        {
            get
            {
                return new DelegateCommand<Window>(window =>
                {
                    Layer layer = null;
                    try
                    {
                        if (ServiceLayerType != typeof(FeatureLayer))
                        {
                            layer = Activator.CreateInstance(ServiceLayerType, new Uri(ServiceUrl)) as Layer;
                            layer.DisplayName = DisplayName;
                        }
                        else
                        {
                            var table = new ServiceFeatureTable()
                            {
                                ServiceUri = ServiceUrl
                            };
                            var featureLayer = new FeatureLayer()
                            {
                                DisplayName = _displayName,
                                FeatureTable = table
                            };
                        }
                        this.LegendLayers.Add(layer);
                        window.Close();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("请检查图层地址是否正确");
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