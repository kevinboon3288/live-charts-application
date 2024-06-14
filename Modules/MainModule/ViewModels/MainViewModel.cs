namespace MainModule.ViewModels;

public class MainViewModel : BindableBase, INavigationAware
{
    private readonly IRegionManager _regionManager;
    private readonly IEventAggregator _eventAggregator;

    private List<string>? _examples = new();

    public List<string>? Examples
    {
        get { return _examples; }
        set { SetProperty(ref _examples, value); }
    }

    public MainViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
    {
        _regionManager = regionManager;
        _eventAggregator = eventAggregator;

        _eventAggregator.GetEvent<UIEvents>().Subscribe(OnRefresh);
    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
        IRegion region = _regionManager.Regions["ModuleContentRegion"];
        region.RequestNavigate("ModuleView");
    }

    private void OnRefresh() 
    {
        Dictionary<string, string>? modules = ToolModuleManager.GetModules();

        if (modules != null && Examples != null) 
        {
            foreach ((string title, string pageName) in modules)
            {
                Examples.Add(title);
            }
        }
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }

    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return true;
    }
}
