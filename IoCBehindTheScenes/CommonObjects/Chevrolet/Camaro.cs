using IoCBehindTheScenes.CommonObjects.CarAccessories.Comfort;
using IoCBehindTheScenes.CommonObjects.CarAccessories.Security;
using IoCBehindTheScenes.MyIoC;

namespace IoCBehindTheScenes.CommonObjects.Chevrolet
{
    public class Camaro : Car, ICamaro
    {
        public Camaro(IMyIoCContainer myIoCContainer, IAlarm alarmSystem, IAirBag airBagSystem, IPowerSteering powerSteeringSystem) 
            : base(myIoCContainer, alarmSystem, airBagSystem, powerSteeringSystem)
        {
        }

        public override string Model
        {
            get { return "Camaro SS 2014"; }
        }
    }
}
