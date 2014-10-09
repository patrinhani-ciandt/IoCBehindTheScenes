using IoCBehindTheScenes.CommonObjects.CarAccessories.Comfort;
using IoCBehindTheScenes.CommonObjects.CarAccessories.Security;
using IoCBehindTheScenes.CommonObjects.Chevrolet;

namespace IoCBehindTheScenes.CommonFactoryStrategy
{
    public class ChevroletFactory
    {
        public static ICamaro CreateCamaro()
        {
            return new Camaro(null, new SimpleAlarmSystem(), new DoubleAirBagSystem(), new HydraulicPowerSteering());
        }

        public static ICruzeSport CreateCruzeSport()
        {
            return new CruzeSport(null, new SimpleAlarmSystem(), new DoubleAirBagSystem(), new HydraulicPowerSteering());
        }
    }
}
