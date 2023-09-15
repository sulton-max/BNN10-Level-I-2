public class RentalService
{
    public void RentCar(Guid carId)
    {
        if(carId == default)
            throw new ArgumentOutOfRangeException(nameof(carId), "Car id cannot be empty");
    }
}