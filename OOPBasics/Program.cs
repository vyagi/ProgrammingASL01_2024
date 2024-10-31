var car = new Car("Opel", "Insignia", 60, 10);
car.Tank(10);
car.Tank(80);

Console.WriteLine($"Car {car.Brand} {car.Model} has {car.FuelLevel} of fuel and drove {car.Odometer}");
car.Drive(100);
Console.WriteLine($"Car {car.Brand} {car.Model} has {car.FuelLevel} of fuel and drove {car.Odometer}");
car.Drive(200);
Console.WriteLine($"Car {car.Brand} {car.Model} has {car.FuelLevel} of fuel and drove {car.Odometer}");
car.Drive(2000);
Console.WriteLine($"Car {car.Brand} {car.Model} has {car.FuelLevel} of fuel and drove {car.Odometer}");

public class Car
{
    private readonly string _brand;
    private readonly string _model;
    private readonly int _tankCapacity;
    private readonly double _fuelConsumption;

    private double _fuelLevel;
    private double _odometer;

    public Car(string brand, string model, int tankCapacity, double fuelConsumption)
    {
        if (string.IsNullOrWhiteSpace(brand))
            throw new ArgumentNullException(nameof(brand), "Brand can't be empty");

        if (string.IsNullOrWhiteSpace(model))
            throw new ArgumentNullException(nameof(model), "Model can't be empty");

        if (tankCapacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(tankCapacity), "Tank capacity must be positive");

        if (fuelConsumption <= 0)
            throw new ArgumentOutOfRangeException(nameof(fuelConsumption), "Fuel consumption must be positive");

        _brand = brand;
        _model = model;
        _tankCapacity = tankCapacity;
        _fuelConsumption = fuelConsumption;
    }

    public void Tank(double fuel)
    {
        if (fuel < 0)
            throw new ArgumentOutOfRangeException(nameof(fuel), "Amount of fuel must not be negative");

        _fuelLevel += fuel;

        if (_fuelLevel > _tankCapacity)
            _fuelLevel = _tankCapacity;
    }

    public void Drive(double distance)
    {
        if (distance < 0)
            throw new ArgumentOutOfRangeException(nameof(distance), "The distance can't be negative");

        var maximumDistance = _fuelLevel / _fuelConsumption * 100;

        if (distance <= maximumDistance)
        {
            _odometer += distance;
            _fuelLevel -= _fuelConsumption * distance / 100;
        }
        else 
        {
            _odometer += maximumDistance;
            _fuelLevel = 0;
        }
    }

    //public double GetFuelLevel()  
    //{
    //    return _fuelLevel;
    //}

    public string Brand => _brand;
    public string Model => _model;
    
    public int FuelLevel => (int)_fuelLevel;
    public int Odometer => (int)_odometer;
}