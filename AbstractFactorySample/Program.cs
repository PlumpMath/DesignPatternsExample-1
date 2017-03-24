using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactorySample
{
    class Program
    {
        static void Main(string[] args)
        {
            BrandFactory renault = new RenaultFactory();
            BrandWorld cw = new BrandWorld(renault);
            cw.Run();


            BrandFactory volkswagen = new VolkswagenFactory();
            BrandWorld tw = new BrandWorld(volkswagen);
            tw.Run();

            Console.ReadKey();
        }
    }

    abstract class BrandFactory
    {
        public abstract Car CreateCar();
        public abstract Truck CreateTruck();
    }
    class RenaultFactory : BrandFactory
    {
        public override Car CreateCar()
        {
            return new Renault();
        }

        public override Truck CreateTruck()
        {
            return new Dodge();
        }
    }
    class VolkswagenFactory : BrandFactory
    {
        public override Car CreateCar()
        {
            return new Dacia();
        }

        public override Truck CreateTruck()
        {
            return new Man();
        }
    }
    abstract class Car
    {
    }
    class Renault : Car
    {

    }
    class Dacia : Car
    {

    }
    abstract class Truck
    {
        public abstract void Load(Car car);
    }

    class Man : Truck
    {
        public override void Load(Car car)
        {
            Console.WriteLine(this.GetType().Name + " Load " + car.GetType().Name);
        }
    }

    class Dodge : Truck
    {
        public override void Load(Car car)
        {
            Console.WriteLine(this.GetType().Name + " Load " + car.GetType().Name);
        }
    }

    class BrandWorld
    {
        private Car _car;
        private Truck _truck;

        public BrandWorld(BrandFactory factory)
        {
            _car = factory.CreateCar();
            _truck = factory.CreateTruck();
        }

        public void Run()
        {
            _truck.Load(_car);
        }
    }


}
