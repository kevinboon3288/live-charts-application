using Prism.Commands;

namespace Modules.GeoMapModule.ViewModels;

public class GeoMapViewModel : BindableBase, INavigationAware
{
    private readonly IRegionManager _regionManager;

    public HeatLandSeries[] Series { get; set; } =
    [
        new HeatLandSeries
        {
            // every country has a unique identifier
            // check the "shortName" property in the following
            // json file to assign a value to a country in the heat map
            // https://github.com/beto-rodriguez/LiveCharts2/blob/master/docs/_assets/word-map-index.json
            Lands = new HeatLand[]
            {
                new HeatLand { Name = "bra", Value = 13 },
                new HeatLand { Name = "mex", Value = 10 },
                new HeatLand { Name = "usa", Value = 15 },
                new HeatLand { Name = "deu", Value = 13 },
                new HeatLand { Name = "fra", Value = 8 },
                new HeatLand { Name = "kor", Value = 10 },
                new HeatLand { Name = "zaf", Value = 12 },
                new HeatLand { Name = "are", Value = 13 }
            }
        }
    ];

    public SolidColorPaint Stroke { get; set; } = new(SKColors.Black) { StrokeThickness = 1 };
    public SolidColorPaint Fill { get; set; } = new(SKColors.LightSeaGreen);

    public DelegateCommand OnReturnCommand { get; private set; }

    public GeoMapViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;

        OnReturnCommand = new DelegateCommand(OnReturn);
    }

    private void OnReturn() 
    {
        IRegion region = _regionManager.Regions["ModuleContentRegion"];
        region.RequestNavigate("ModuleView");
    }

    public void OnNavigatedTo(NavigationContext navigationContext)
    {
        Console.WriteLine("Hi");
    }

    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return true;
    }

    public void OnNavigatedFrom(NavigationContext navigationContext)
    {
    }
}
