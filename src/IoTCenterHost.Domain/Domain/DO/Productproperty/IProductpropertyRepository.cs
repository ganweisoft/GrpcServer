namespace IoTCenterHost.Domain.Domain.DO
{
    public interface IProductpropertyRepository
    {
        void SaveChanges();

        void AddRange(List<Productproperty> gWPluginInformation);

        bool Any();
    }
}
