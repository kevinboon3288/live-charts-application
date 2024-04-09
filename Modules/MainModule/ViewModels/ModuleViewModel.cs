namespace MainModule.ViewModels;

public class ModuleViewModel : BindableBase, INavigationAware
{
    private readonly IRegionManager _regionManager;

    public ModuleViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
    }

    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return true;
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
        IRegion region = _regionManager.Regions["GeoMapContentRegion"];
        region.RequestNavigate("GeoMapView");
    }
}
