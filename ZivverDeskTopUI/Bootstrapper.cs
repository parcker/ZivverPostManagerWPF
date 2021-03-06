using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ZivverDeskTopUI.ViewModels;
using ZivverServiceProvider.JsonPostService;

namespace ZivverDeskTopUI
{
    /// <summary>
    /// Start up Configurations 
    /// </summary>
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            _container.Instance(_container);
            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            _container.PerRequest<IJsonPlaceHolderService, JsonPlaceHolderService>();
                
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(viewModelType, viewModelType.ToString(), viewModelType));

        }
        protected async override void OnStartup(object sender, StartupEventArgs e)
        {
            await DisplayRootViewForAsync<PostViewModel>().ConfigureAwait(false); ;
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);  
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);   
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance); 
        }
    }
}
