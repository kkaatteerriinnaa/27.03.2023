using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp41
{
    public interface IClone { Transport DeepCopy(); }

    public class Engine
    {
        public double EnginePower { get; set; }
        public Engine(double idNumber) => EnginePower = idNumber;
        public Engine() => EnginePower = 0;
        public Engine DeepCopy() { return new Engine(EnginePower); }
    }

    public abstract class Transport : IClone
    {
        public string Name { get; set; }
        public double Range { get; set; }
        public Engine engine { get; set; }

        public Transport(string name, double range, Engine engine)
        {
            Name = name;
            Range = range;
            this.engine = engine;
        }
        public abstract Transport DeepCopy();
    }
    public class Ship : Transport
    {
        public int MaxDisplacement { get; set; }
        public int MaxSpeed { get; set; }

        public Ship(string name, double range, Engine engine, int maxDisplacement, int maxSpeed)
            : base(name, range, engine)
        {
            MaxDisplacement = maxDisplacement;
            MaxSpeed = maxSpeed;
        }

        public override string ToString()
        {
            return $"{Name}:\nMax Displacement: {MaxDisplacement} t\nMax Speed: {MaxSpeed} knots\nRange: {Range} km";
        }
        public override Transport DeepCopy()
        {
            Ship copy = new Ship(Name, Range, engine.DeepCopy(), MaxDisplacement, MaxSpeed);
            return copy;
        }
    }
    public class Car : Transport
    {
        public int MaxPassengers { get; set; }
        public int MaxSpeed { get; set; }
        public Car(string name, double range, Engine engine, int maxPassengers, int maxSpeed) : base(name, range, engine)
        {
            MaxPassengers = maxPassengers;
            MaxSpeed = maxSpeed;
        }

        public override string ToString()
        {
            return $"{Name}: \nMax Passengers: {MaxPassengers}\nMax Speed: {MaxSpeed} kmph\nRange: {Range} km";
        }
        public override Transport DeepCopy()
        {
            Car copy = new Car(Name, Range, engine.DeepCopy(), MaxPassengers, MaxSpeed);
            return copy;
        }
    }
    public class Airplane : Transport
    {
        public int MaxAltitude { get; set; }
        public int MaxSpeed { get; set; }

        public Airplane(string name, double range, Engine engine, int maxAltitude, int maxSpeed) : base(name, range, engine)
        {
            MaxAltitude = maxAltitude;
            MaxSpeed = maxSpeed;
        }

        public override string ToString()
        {
            return $"{Name}:\nMax Altitude: {MaxAltitude} ft\nMax Speed: {MaxSpeed} kmph\nRange: {Range} km";
        }
        public override Transport DeepCopy()
        {
            Airplane copy = new Airplane(Name, Range, engine.DeepCopy(), MaxAltitude, MaxSpeed);
            return copy;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(500);
            Ship ship = new Ship("Ship", 2000, engine, 40000, 20);
            Car car = new Car("Car", 500, engine, 4, 280);
            Airplane airplane = new Airplane("Plane", 8000, engine, 45000, 570);
            Car copy = (Car)car.DeepCopy();
            Console.WriteLine(copy);
        }
    }
}