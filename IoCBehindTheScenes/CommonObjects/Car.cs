using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCBehindTheScenes.CommonObjects.CarAccessories;
using IoCBehindTheScenes.CommonObjects.CarAccessories.Comfort;
using IoCBehindTheScenes.CommonObjects.CarAccessories.Security;
using IoCBehindTheScenes.MyIoC;
using StructureMap;

namespace IoCBehindTheScenes.CommonObjects
{
    public abstract class Car : ICar
    {
        private readonly IMyIoCContainer _myIoCContainer;
        private IList<ICarAccessory> _accessories = new List<ICarAccessory>();

        public virtual string Model
        {
            get
            {
                return String.Empty;

            }
        }

        public IList<ICarAccessory> Accessories
        {
            get { return _accessories; }
            set { _accessories = value; }
        }

        public Car(IMyIoCContainer myIoCContainer, IAlarm alarmSystem, IAirBag airBagSystem, IPowerSteering powerSteeringSystem)
        {
            _myIoCContainer = myIoCContainer;
            AddAccessory(alarmSystem);
            AddAccessory(airBagSystem);
            AddAccessory(powerSteeringSystem);
        }

        public void AddAccessory(ICarAccessory accessory)
        {
            Accessories.Add(accessory);
        }

        public string GetInstalledAcessories()
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine("- Accessories:");
            foreach (var carAccessory in Accessories)
            {
                strBuilder.AppendLine(String.Format("\t - {0}", carAccessory.Name));
            }

            return strBuilder.ToString();
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();

            if (_myIoCContainer != null)
            {
                strBuilder.AppendLine(String.Format("# Using the IoC container: {0}", _myIoCContainer.Name));
            }

            strBuilder.AppendLine(Model);
            strBuilder.Append(GetInstalledAcessories());

            return strBuilder.ToString();
        }
    }
}
