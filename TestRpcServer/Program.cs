using Communication.RPC.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;

namespace TestRpcServer
{
    class Program
    {
        private static TServer _server = null;
        private static TMultiplexedProcessor _processor = null;
        private static TServerTransport _transport = null;

        private static readonly int _port = 15235;
        private static readonly string _serverName = "E85930D1-7415-472B-ACAB-2DB6D326FF69";

        private static void StartServerListener()
        {
            ////------------TSimpleServer —— 单线程服务器端使用标准的阻塞式 I/O
            //new TSimpleServer(
            //        new BasicDataService.Processor(new BasicDataServiceImp()),
            //        new TServerSocket(10091, 0, false))
            //        .Serve();

            {
                ////-------------TThreadPoolServer —— 多线程服务器端使用标准的阻塞式 I/O
                ////-------------线程池服务模型，使用标准的阻塞式IO，预先创建一组线程处理请求。
                //TServerTransport scoket = new TServerSocket(10091);
                ////-------------TNamedPipeServerTransport scoket2 = new TNamedPipeServerTransport();
                ////TTLSServerSocket scoket3 = new TTLSServerSocket(10091,new X509Certificate2());
                //SuperServiceForServer.Processor processor = new SuperServiceForServer.Processor(new SuperServiceForServerImp());
                //TThreadPoolServer server = new TThreadPoolServer(processor, scoket);
                //server.Serve();
            }

            //注册信息记录器
            //ServiceLocator.Instance.RegisterInstance<IInfoRecord>(new DebugRecord());

            {
                //对应客户端一    性能好方法
                _processor = new TMultiplexedProcessor();
                _transport = new TServerSocket(_port);
                _processor.RegisterProcessor
                        (
                                _serverName,
                                new ServerService.Processor
                                (
                                        new MainServerImpl()
                                )
                        );
                _server = new TThreadPoolServer
                        (
                                _processor,
                                _transport
                        );

                _server.Serve();

                ////对应客户端二
                ////-------------------TThreadPoolServer —— 多线程服务器端使用标准的阻塞式 I/O--------多服务注册
                ////-------------------线程池服务模型，使用标准的阻塞式IO，预先创建一组线程处理请求。
                //TProtocolFactory ProtocolFactory = new TBinaryProtocol.Factory(true, true);
                //TTransportFactory TransportFactory = new TFramedTransport.Factory();

                //TServerTransport scoket1 = new TServerSocket(10091, 0, false);
                //TMultiplexedProcessor multiplex = new TMultiplexedProcessor();
                //multiplex.RegisterProcessor("1", new BasicDataService.Processor(new BasicDataServiceImp()));
                //multiplex.RegisterProcessor("2", new BasicDataService.Processor(new BasicDataServiceImp()));
                //TThreadPoolServer server1 = new TThreadPoolServer(multiplex, scoket1, TransportFactory, ProtocolFactory);
                //server1.Serve();
            }

            {
                //////-------------TThreadedServer - 多线程服务模型，使用阻塞式IO，每个请求创建一个线程。
                //TServerTransport scoket = new TServerSocket(10091);
                ////-------------TNamedPipeServerTransport scoket2 = new TNamedPipeServerTransport();
                ////-------------TTLSServerSocket scoket3 = new TTLSServerSocket(10091,new X509Certificate2());
                //BasicDataService.Processor processor = new BasicDataService.Processor(new BasicDataServiceImp());
                //TThreadedServer server = new TThreadedServer(processor, scoket);
                //server.Serve();
            }

        }

        static void Main(string[] args)
        {
            Task.Factory.StartNew(() =>
            {
                StartServerListener();
            });

            Console.ReadKey();
        }
    }
}
