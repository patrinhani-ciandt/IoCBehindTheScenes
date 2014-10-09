using IoCBehindTheScenes.CommonObjects.CarAccessories.Comfort;
using IoCBehindTheScenes.CommonObjects.CarAccessories.Security;
using IoCBehindTheScenes.MyIoC;

namespace IoCBehindTheScenes.CommonObjects.Ford
{
    public class FordFiesta : Car, IFordFiesta
    {
        public FordFiesta(IMyIoCContainer myIoCContainer, IAlarm alarmSystem, IAirBag airBagSystem, IPowerSteering powerSteeringSystem) 
            : base(myIoCContainer, alarmSystem, airBagSystem, powerSteeringSystem)
        {
        }

        public override string Model
        {
            get { return "New Fiesta Hatch 2014"; }
        }
    }
}
