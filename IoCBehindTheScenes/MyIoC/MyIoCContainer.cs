using System;
using System.Collections.Generic;
using System.Linq;
using StructureMap;

namespace IoCBehindTheScenes.MyIoC
{
    public class MyIoCContainer : IMyIoCContainer
    {
        private readonly Dictionary<Type, Type> dicMapType = new Dictionary<Type, Type>();

        public string Name { get; private set; }

        public MyIoCContainer(string name)
        {
            Name = name;
        }

        public void AddConfigType<TSource, TTarget>()
        {
            dicMapType[typeof(TSource)] =  typeof(TTarget);
        }

        private Type findTarget<TSource>()
        {
            return findTarget(typeof (TSource));
        }

        private Type findTarget(Type sourceType)
        {
            Type typeTarget = null;

            if (sourceType == typeof (IMyIoCContainer))
                return typeof (IMyIoCContainer);

            if (dicMapType.ContainsKey(sourceType))
            {
                return dicMapType[sourceType];
            }
            else if ((!sourceType.IsAbstract) && (!sourceType.IsInterface))
            {
                typeTarget = sourceType;
            }

            return typeTarget;
        }

        private object getInstanceForType(Type type, object[] args = null)
        {
            if (type == typeof(IMyIoCContainer))
                return this;

            if (args == null)
            {
                return Activator.CreateInstance(type);
            }
            else
            {
                return Activator.CreateInstance(type, args);
            }
        }

        public TTarget GetInstance<TTarget>()
        {
            var targetType = findTarget<TTarget>();

            var constructors = targetType.GetConstructors();

            object[] ctorArgs = null;

            if (constructors.Any())
            {
                var especifConstructor = constructors.Last();

                if (especifConstructor.GetParameters().Count() > 0)
                {
                    var paramTypes = new List<Type>();
                    var listArgs = new List<object>();

                    foreach (var paramType in especifConstructor.GetParameters())
                    {
                        paramTypes.Add(paramType.ParameterType);

                        var paramTargetType = findTarget(paramType.ParameterType);

                        listArgs.Add(getInstanceForType(paramTargetType));
                    }

                    ctorArgs = listArgs.ToArray();
                }
            }

            var targetObj = (TTarget)getInstanceForType(targetType, ctorArgs);

            return targetObj;
        }
    }
}