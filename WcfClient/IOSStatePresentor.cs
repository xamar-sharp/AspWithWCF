using System.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfClient
{
    [ServiceContract]
    public interface IOSStatePresentor
    {
        [OperationContract]
        string GetState(bool detailed);
    }
}
