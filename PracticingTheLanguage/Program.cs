var ourBeautifulCup = new Cup(300);

ourBeautifulCup.Add(100);
ourBeautifulCup.Add(20);
ourBeautifulCup.Pour(50);
Console.WriteLine($"Inside we have {ourBeautifulCup.LiquidLevel}");

var coffeMaker = new CoffeeMachine("SIEMENS 1000", 1500, 1200);
coffeMaker.AddWater(1000);
coffeMaker.AddGrains(1000);

coffeMaker.MakeEspresso(ourBeautifulCup);

Console.WriteLine(ourBeautifulCup.LiquidLevel);


public class CoffeeMachine
{
    private readonly string _modelName;
    private readonly int _coffeeGrainsCapacity;
    private readonly int _waterCapacity;

    private int _currentCoffeeGrainsLevel;
    private int _currentWaterLevel;
    private int _numberOfEsspressosMade;

    public CoffeeMachine(string modelName, int coffeeGrainsCapacity, int waterCapacity)
    {//Checks are your homework
        _modelName = modelName;
        _coffeeGrainsCapacity = coffeeGrainsCapacity;
        _waterCapacity = waterCapacity;
    }

    public void AddGrains(int amount)
    {
        _currentCoffeeGrainsLevel += amount;

        if (_currentCoffeeGrainsLevel > _coffeeGrainsCapacity)
            _currentCoffeeGrainsLevel = _coffeeGrainsCapacity;
    }

    public void AddWater(int amount)
    {
        _currentWaterLevel += amount;

        if (_currentWaterLevel > _waterCapacity)
            _currentWaterLevel = _waterCapacity;
    }

    public void MakeEspresso(Cup cup)
    {
        if (_currentWaterLevel > 300 && _currentCoffeeGrainsLevel > 50)
        {
            _currentWaterLevel -= 36;
            _currentCoffeeGrainsLevel -= 18;
            _numberOfEsspressosMade++;
            cup.Add(36);
        }
    }
}

public class Cup
{
    private readonly int _capacity;

	private int _liquidLevel;

	public Cup(int capacity)
	{//Protect from negative value
		_capacity = capacity;
	}

	public void Add(int amount)
    {//Protect from negative value
        _liquidLevel += amount;

		if (_liquidLevel > _capacity)
			_liquidLevel = _capacity;
    }

    public void Pour(int amount)
    {//Protect from negative value
        _liquidLevel -= amount;

        if (_liquidLevel < 0)
            _liquidLevel = 0;
    }

    public int LiquidLevel => _liquidLevel;
}