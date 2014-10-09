namespace IoCBehindTheScenes.MyIoC
{
    public interface IMyIoCContainer
    {
        string Name { get; }

        void AddConfigType<TSource, TTarget>();

        TTarget GetInstance<TTarget>();
    }
}