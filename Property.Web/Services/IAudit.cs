namespace Property.Web.Services
{
    public interface IAudit
    {
        void Audit<T>(T command);
    }
}
