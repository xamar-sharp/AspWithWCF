using CoreWCF;
namespace AspWithWCF.Services
{
    [ServiceContract]
    public interface IOSStatePresentor
    {
        [OperationContract]
        string GetState(bool detailed);
    }
}
