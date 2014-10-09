using System;
using IoCBehindTheScenes.CommonFactoryStrategy;
using IoCBehindTheScenes.CommonObjects;
using IoCBehindTheScenes.CommonObjects.CarAccessories.Comfort;
using IoCBehindTheScenes.CommonObjects.CarAccessories.Security;
using IoCBehindTheScenes.CommonObjects.Chevrolet;
using IoCBehindTheScenes.CommonObjects.Ford;
using IoCBehindTheScenes.MyIoC;
using StructureMap;

namespace IoCBehindTheScenes
{
    public class Program
    {
        static void Main(string[] args)
        {
            //usingCommonFactoryStrategy();

            //usingMyIoC();

            //usingMyIoCWithContainers();

            Console.WriteLine("--- Pressione <ENTER> ---");
            Console.ReadLine();
        }

        private static void usingCommonFactoryStrategy()
        {
            Console.WriteLine("[Ford Factory] -------------------------------");
            Console.WriteLine();

            var fordFiesta = FordFactory.CreateFordFiesta();
            showCarCreated(fordFiesta);

            var fordFocus = FordFactory.CreateFordFocus();
            showCarCreated(fordFocus);

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("[Chevrolet Factory] --------------------------");
            Console.WriteLine();

            var camaro = ChevroletFactory.CreateCamaro();
            showCarCreated(camaro);

            var cruzeSport = ChevroletFactory.CreateCruzeSport();
            showCarCreated(cruzeSport);

            Console.WriteLine("----------------------------------------------");
        }

        private static void usingMyIoC()
        {
            MyIoCService.AddConfigType<IFordFiesta, FordFiesta>();
            MyIoCService.AddConfigType<IFordFocus, FordFocus>();

            MyIoCService.AddConfigType<ICamaro, Camaro>();
            MyIoCService.AddConfigType<ICruzeSport, CruzeSport>();

            MyIoCService.AddConfigType<IAlarm, SimpleAlarmSystem>();
            MyIoCService.AddConfigType<IAirBag, SimpleAirBagSystem>();
            MyIoCService.AddConfigType<IPowerSteering, HydraulicPowerSteering>();

            Console.WriteLine("[Ford Factory] -------------------------------");
            Console.WriteLine();

            var fordFiesta = MyIoCService.GetInstance<IFordFiesta>();
            showCarCreated(fordFiesta);

            var fordFocus = MyIoCService.GetInstance<IFordFocus>();
            showCarCreated(fordFocus);

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("[Chevrolet Factory] --------------------------");
            Console.WriteLine();

            MyIoCService.AddConfigType<IAlarm, SimpleAlarmSystem>();
            MyIoCService.AddConfigType<IAirBag, DoubleAirBagSystem>();
            MyIoCService.AddConfigType<IPowerSteering, HydraulicPowerSteering>();

            var camaro = MyIoCService.GetInstance<ICamaro>();
            showCarCreated(camaro);

            var cruzeSport = MyIoCService.GetInstance<ICruzeSport>();
            showCarCreated(cruzeSport);

            Console.WriteLine("----------------------------------------------");
        }

        private static void usingMyIoCWithContainers()
        {
            Console.WriteLine("[Ford Factory] -------------------------------");
            Console.WriteLine();

            var fordContainer = MyIoCService.CreateContainer("Ford Factory Container");

            fordContainer.AddConfigType<IFordFiesta, FordFiesta>();
            fordContainer.AddConfigType<IFordFocus, FordFocus>();

            fordContainer.AddConfigType<IAlarm, SimpleAlarmSystem>();
            fordContainer.AddConfigType<IAirBag, SimpleAirBagSystem>();
            fordContainer.AddConfigType<IPowerSteering, HydraulicPowerSteering>();

            var fordFiesta = fordContainer.GetInstance<IFordFiesta>();
            showCarCreated(fordFiesta);

            var fordFocus = fordContainer.GetInstance<IFordFocus>();
            showCarCreated(fordFocus);

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("[Chevrolet Factory] --------------------------");
            Console.WriteLine();

            var chevroletContainer = MyIoCService.CreateContainer("Chevrolet Factory Container");

            chevroletContainer.AddConfigType<ICamaro, Camaro>();
            chevroletContainer.AddConfigType<ICruzeSport, CruzeSport>();

            chevroletContainer.AddConfigType<IAlarm, SimpleAlarmSystem>();
            chevroletContainer.AddConfigType<IAirBag, DoubleAirBagSystem>();
            chevroletContainer.AddConfigType<IPowerSteering, HydraulicPowerSteering>();

            var camaro = chevroletContainer.GetInstance<ICamaro>();
            showCarCreated(camaro);

            var cruzeSport = chevroletContainer.GetInstance<ICruzeSport>();
            showCarCreated(cruzeSport);

            Console.WriteLine("----------------------------------------------");
        }

        private static void usingStructureMap()
        {
            ObjectFactory.Configure(cfg =>
            {
                cfg.For<IFordFiesta>().Use<FordFiesta>();
                cfg.For<IFordFocus>().Use<FordFocus>();

                cfg.For<ICamaro>().Use<Camaro>();
                cfg.For<ICruzeSport>().Use<CruzeSport>();

                cfg.For<IAlarm>().Use<SimpleAlarmSystem>();
                cfg.For<IAirBag>().Use<SimpleAirBagSystem>();
                cfg.For<IPowerSteering>().Use<HydraulicPowerSteering>();
            });

            Console.WriteLine("[Ford Factory] -------------------------------");
            Console.WriteLine();

            var fordFiesta = ObjectFactory.GetInstance<IFordFiesta>();
            showCarCreated(fordFiesta);

            var fordFocus = ObjectFactory.GetInstance<IFordFocus>();
            showCarCreated(fordFocus);

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("[Chevrolet Factory] --------------------------");
            Console.WriteLine();

            ObjectFactory.Configure(cfg =>
            {
                cfg.For<IAlarm>().Use<SimpleAlarmSystem>();
                cfg.For<IAirBag>().Use<DoubleAirBagSystem>();
                cfg.For<IPowerSteering>().Use<HydraulicPowerSteering>();
            });

            var camaro = ObjectFactory.GetInstance<ICamaro>();
            showCarCreated(camaro);

            var cruzeSport = ObjectFactory.GetInstance<ICruzeSport>();
            showCarCreated(cruzeSport);

            Console.WriteLine("----------------------------------------------");
        }

        private static void showCarCreated(ICar car)
        {
            Console.WriteLine("[New Car Created] ----------------------------");
            Console.WriteLine(car.ToString());
            Console.WriteLine("----------------------------------------------");
        }
    }
}