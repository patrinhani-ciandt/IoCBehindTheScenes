using System;
using System.Collections.Generic;
using System.Linq;
using StructureMap;

namespace IoCBehindTheScenes.MyIoC
{
    public static class MyIoCService
    {
        private static IMyIoCContainer myIoCDefaultContainer = new MyIoCContainer("Default");

        public static void AddConfigType<TSource, TTarget>()
        {
            myIoCDefaultContainer.AddConfigType<TSource, TTarget>();
        }

        public static TInstance GetInstance<TInstance>()
        {
            return myIoCDefaultContainer.GetInstance<TInstance>();
        }

        public static IMyIoCContainer CreateContainer(string name)
        {
            return new MyIoCContainer(name);
        }
    }
}