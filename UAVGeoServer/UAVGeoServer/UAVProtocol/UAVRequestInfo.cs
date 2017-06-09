using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAVGeoServer.UAVProtocol
{
    //设备请求信息
     public class UAVRequestInfo:IRequestInfo
    {
         //key值
         public string Key { get; set; }
    }
}
