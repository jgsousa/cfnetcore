using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace netcore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }

    [Route("")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            String res = "Hello SAP Cloud Platform!";
            return  res ;
        }
    }
    [Route("random")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            Random rnd = new Random();
            String res = "" + rnd.NextDouble();
            return res;
        }
    }
    [Route("fibonacci")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            String res = "";
			Fib fibo = new Fib();

			for (int i = 0; i < 75; i++) {
				res += (fibo.getNext());
				res += ('\n');
			}

            return res ;
        }
    }
    class Fib
    {
        private long x = 0L;
        private long y = 1L;

        public long getNext()
        {
            long temp = x;
            x = y;
            y = temp + y;
            return x;
        }
    }
}
