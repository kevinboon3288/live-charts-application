namespace Modules.GeoMapModule;

public class GeoMapModule : IModule
{
    private readonly IRegionManager _regionManager;
    private readonly IEventAggregator _eventAggregator;

    public GeoMapModule(IRegionManager regionManager, IEventAggregator eventAggregator)
    {
        _regionManager = regionManager;
        _eventAggregator = eventAggregator;
    }

    public void OnInitialized(IContainerProvider containerProvider)
    {
        _regionManager.RegisterViewWithRegion("GeoMapContentRegion", typeof(GeoMapView));

        LiveCharts.Configure(config =>
        {
            config.AddDarkTheme();
            config.HasMap<City>((city, index) => new(index, city.Population));
        });

        _eventAggregator.GetEvent<UIEvents>().Publish();
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<GeoMapView>();

        ViewModelLocationProvider.Register<GeoMapView, GeoMapViewModel>();

        ToolModuleManager.AddModule("Geo Map", nameof(GeoMapView));
    }

    public record City(string Name, double Population);
}
