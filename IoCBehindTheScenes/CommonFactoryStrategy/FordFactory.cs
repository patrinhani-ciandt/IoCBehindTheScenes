using IoCBehindTheScenes.CommonObjects;
using IoCBehindTheScenes.CommonObjects.CarAccessories.Comfort;
using IoCBehindTheScenes.CommonObjects.CarAccessories.Security;
using IoCBehindTheScenes.CommonObjects.Ford;

namespace IoCBehindTheScenes.CommonFactoryStrategy
{
    public class FordFactory
    {
        public static IFordFiesta CreateFordFiesta()
        {
            return new FordFiesta(null, new SimpleAlarmSystem(), new SimpleAirBagSystem(), new HydraulicPowerSteering());
        }

        public static IFordFocus CreateFordFocus()
        {
            return new FordFocus(null, new SimpleAlarmSystem(), new SimpleAirBagSystem(), new HydraulicPowerSteering());
        }
    }
}
