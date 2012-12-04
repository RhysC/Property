namespace Property.Web.Services
{
    public interface IQueueWriter
    {
        void Enqueue<T>(T command);
    }
}
