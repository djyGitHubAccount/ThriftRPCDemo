using Communication.RPC.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Protocol;
using Thrift.Transport;

namespace TestRpcClient
{
    class Program
    {
        static string _serverIP = "127.0.0.1";
        static int _port = 15235;
        private static readonly string _serverName = "E85930D1-7415-472B-ACAB-2DB6D326FF69";

        static void Main(string[] args)
        {

            int flag = 0;

            while (true)
            {
                for (int i = 0; i < 10; i++)
                {

                    ThriftRequest request = new ThriftRequest
                    {
                        RequestAddress = "APIName",
                        Data = $"Request {flag++}"
                    };

                    ThriftResponse response = null;
                    using (TTransport trans = new TSocket(_serverIP, _port))
                    {
                        trans.Open();
                        using (TProtocol Protocol = new TBinaryProtocol(trans))
                        {
                            //多服务
                            using (TMultiplexedProtocol muprotocol = new TMultiplexedProtocol(Protocol, _serverName))
                            {
                                using (var client = new ServerService.Client(muprotocol))
                                {
                                    response = client.Invoke(request);
                                }
                            }
                        }
                    }

                    Console.WriteLine($"Server Response: Status {response.Status}, Data {response.Data}, ErrMsg {response.ErrMsg}");
                }

                Console.ReadKey();
            }
        }
    }
}
