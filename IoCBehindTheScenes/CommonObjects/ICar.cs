using System.Collections.Generic;
using IoCBehindTheScenes.CommonObjects.CarAccessories;

namespace IoCBehindTheScenes.CommonObjects
{
    public interface ICar
    {
        string Model { get; }
        IList<ICarAccessory> Accessories { get; set; }

        void AddAccessory(ICarAccessory accessory);

        string GetInstalledAcessories();
    }
}
