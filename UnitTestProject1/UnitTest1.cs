using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var server = new Thread(()=> RenCapGrpc.Server.Program.Main(new string[0]));
            server.Start();
            var client = new Thread(() => RenCapGrpc.Client.Program.Main(new string[0]));
            client.Start();
            Thread.Sleep(5000);
        }
    }
}
