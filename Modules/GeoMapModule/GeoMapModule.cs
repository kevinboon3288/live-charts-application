namespace Modules.GeoMapModule
{
    public class GeoMapModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public GeoMapModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("GeoMapContentRegion", typeof(GeoMapView));

            LiveCharts.Configure(config =>
            {
                config.AddDarkTheme();
                config.HasMap<City>((city, index) => new(index, city.Population));
            });
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<GeoMapView>();

            ViewModelLocationProvider.Register<GeoMapView, GeoMapViewModel>();
        }

        public record City(string Name, double Population);
    }
}
