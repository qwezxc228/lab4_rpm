class Car
{
    private string _marka;
    private double _n;
    private double _r;
    public Car()
    {
        _marka = "пока нинаю";
        _n = 0;
        _r = 0;
    }
    public Car(string marka, double n, double r)
    {
        _marka = marka;
        _n = n;
        _r = r;
    }
    public string Marka
    {
        get { return _marka; }
        set { }
    }


    public double R
    {
        get { return _r; }
        set { if (value > 0) _r = value; }
    }
    public virtual double CalculateFuel()
    {
        return _n * _r / 100;
    }
    public virtual void Print()
    {
        System.Console.WriteLine($"че за авто: {_marka}");
        System.Console.WriteLine($"какой расход: {_n} литров за сотку");
        System.Console.WriteLine($"сколько проедет: {_r} км");
        System.Console.WriteLine($"сколько слил в канистру: {CalculateFuel()} литров");
    }
}

class Truck : Car
{
    private double _gruzopodjemnost;

    public Truck(string marka, double n, double r, double gruzopodjemnost)
        : base(marka, n, r)
    {
        _gruzopodjemnost = gruzopodjemnost;
    }

    public new double CalculateFuel()
    {
        return base.CalculateFuel() + _gruzopodjemnost * R;
    }

    public new void Print()
    {
        base.Print();
        System.Console.WriteLine($"Грузоподъёмность: {_gruzopodjemnost}");
        System.Console.WriteLine($"Общий расход: {CalculateFuel()}");
    }
}

class PassengerCar : Car
{
    private double _volume;
    public PassengerCar(string marka, double n, double r, double volume)
        : base(marka, n, r)
    {
        _volume = volume;
    }
    public new double CalculateFuel()
    {
        double baseFuel = base.CalculateFuel();
        if (_volume > 3)
        {
            return baseFuel + 0.005 * _volume * R;
        }
        return baseFuel;
    }
}

class Program
{
    static void Main()
    {
        Car car = new Car("семерочка", 8, 500);
        car.Print();
        Truck truck = new Truck("камазик", 20, 300, 1000);
        truck.Print();
        Car car1 = new Car("приора", 300,10);
    }
}