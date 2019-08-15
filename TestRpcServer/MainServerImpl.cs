using Communication.RPC.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestRpcServer
{
    public class MainServerImpl : ServerService.Iface
    {
        private int _flag = 0;
        public ThriftResponse Invoke(ThriftRequest request)
        {
            Console.WriteLine($"Accept Data {request.Data}");

            return new ThriftResponse
            {
                Status = ResponseStatus.Success
            };
        }
    }
}
