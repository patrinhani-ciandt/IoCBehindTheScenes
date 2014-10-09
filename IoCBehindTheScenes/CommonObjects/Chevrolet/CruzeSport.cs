using IoCBehindTheScenes.CommonObjects.CarAccessories.Comfort;
using IoCBehindTheScenes.CommonObjects.CarAccessories.Security;
using IoCBehindTheScenes.MyIoC;

namespace IoCBehindTheScenes.CommonObjects.Chevrolet
{
    public class CruzeSport : Car, ICruzeSport
    {
        public CruzeSport(IMyIoCContainer myIoCContainer, IAlarm alarmSystem, IAirBag airBagSystem, IPowerSteering powerSteeringSystem)
            : base(myIoCContainer, alarmSystem, airBagSystem, powerSteeringSystem)
        {
        }

        public override string Model
        {
            get { return "Cruze Sport6 2014"; }
        }
    }
}
