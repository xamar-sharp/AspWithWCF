using System.ServiceModel;
namespace WcfClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var httpBinding = new System.ServiceModel.BasicHttpBinding();
            var endpoint = new System.ServiceModel.EndpointAddress("http://localhost:5000/EnvironmentOSStatePresentor/basichttp");
            var channelFactory = new ChannelFactory<IOSStatePresentor>(httpBinding, endpoint);
            var client = channelFactory.CreateChannel();
            Console.WriteLine(client.GetState(true));
        }
    }
}
