using IoCBehindTheScenes.CommonObjects.CarAccessories.Comfort;
using IoCBehindTheScenes.CommonObjects.CarAccessories.Security;
using IoCBehindTheScenes.MyIoC;

namespace IoCBehindTheScenes.CommonObjects.Ford
{
    public class FordFocus : Car, IFordFocus
    {
        public FordFocus(IMyIoCContainer myIoCContainer, IAlarm alarmSystem, IAirBag airBagSystem, IPowerSteering powerSteeringSystem)
            : base(myIoCContainer, alarmSystem, airBagSystem, powerSteeringSystem)
        {
        }

        public override string Model
        {
            get { return "New Focus Hatch 2014"; }
        }
    }
}
