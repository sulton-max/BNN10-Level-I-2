using N42_C.Models;

namespace N42_C.Services;

public class FuelStationService
{
    private readonly FuelFillerService _fuelFillerService;

    public FuelStationService(FuelFillerService fuelFillerService)
    {
        _fuelFillerService = fuelFillerService;
    }

    public async ValueTask<int> Start(List<Car> cars)
    {
        var fillTasks = cars.Select(car =>
        {
            return Task.Run(() =>
            {
                return _fuelFillerService.Fill(car);
            });
        });

        var balance = await Task.WhenAll(fillTasks);
        return balance.Sum();
    }
}