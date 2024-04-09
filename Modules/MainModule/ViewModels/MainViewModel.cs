namespace MainModule.ViewModels;

public class MainViewModel : BindableBase, INavigationAware
{
    private readonly IRegionManager _regionManager;

    public MainViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;
    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
        IRegion region = _regionManager.Regions["ModuleContentRegion"];
        region.RequestNavigate("ModuleView");
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return true;
    }
}
