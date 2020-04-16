namespace TrainsOnline.Api
{
    using System.ServiceModel;
    using System.Threading.Tasks;

    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract]
        string Ping(string s);

        [OperationContract]
        void VoidMethod(string s);

        [OperationContract]
        Task<int> AsyncMethod();

        [OperationContract]
        int? NullableMethod(bool? arg);

        [OperationContract]
        void XmlMethod(System.Xml.Linq.XElement xml);
    }
}
