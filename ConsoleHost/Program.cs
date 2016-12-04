using EvalServiceLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(EvalService));

            //// Code way to declare and expose endpoints (*.config file is not needed in this case)
            //host.AddServiceEndpoint(typeof(IEvalService),
            //    new BasicHttpBinding(),
            //    "http://localhost:8080/evals/basic/");

            //host.AddServiceEndpoint(typeof(IEvalService),
            //    new WSHttpBinding(),
            //    "http://localhost:8080/evals/ws/");

            //host.AddServiceEndpoint(typeof(IEvalService),
            //   new NetTcpBinding(),
            //   "net.tcp://localhost:8082/evals");


            //// Code way to declare Binding
            //BasicHttpBinding b = new BasicHttpBinding();
            //b.Security.Mode = BasicHttpSecurityMode.Transport;
            //b.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            //host.AddServiceEndpoint(typeof(IEvalService),
            //    b,
            //    "https://localhost:8081/evals/anotherbasic/");

            //// Code way to declare ehavior
            //ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            //smb.HttpGetEnabled = true;
            //smb.HttpGetUrl = new Uri("http://localhost:8080/evals/meta", UriKind.Absolute);
            //host.Description.Behaviors.Add(smb);



            try
            {
                host.Open();
                PrintServiceInfo(host);
                Console.ReadLine();
                host.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                host.Abort();
            }
        }

        static void PrintServiceInfo(ServiceHost host)
        {
            Console.WriteLine("{0} is up running with these endpoints", host.Description.ServiceType);

            foreach (ServiceEndpoint se in host.Description.Endpoints)
            {
                Console.WriteLine(se.Address);
            }
        }
    }
}
