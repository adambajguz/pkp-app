namespace TrainsOnline.Api
{
    using System;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class SampleService : ISampleService
    {
        public SampleService()
        {

        }

        public string Ping(string s)
        {
            Console.WriteLine("Exec ping method");
            return s;
        }

        public void VoidMethod(string s)
        {

        }

        public Task<int> AsyncMethod()
        {
            return Task.Run(() => 42);
        }

        public int? NullableMethod(bool? arg)
        {
            return null;
        }

        public void XmlMethod(XElement xml)
        {
            Console.WriteLine(xml.ToString());
        }
    }
}
