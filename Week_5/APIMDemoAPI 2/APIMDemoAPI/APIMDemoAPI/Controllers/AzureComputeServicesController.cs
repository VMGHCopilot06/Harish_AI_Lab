using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIMDemoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AzureComputeServicesController : ControllerBase
    {
        private static readonly object lock1 = new object();
        private static readonly object lock2 = new object();

        public static List<AzureService> azureServices = new List<AzureService>();

        private readonly ILogger<AzureComputeServicesController> _logger;

        public AzureComputeServicesController(ILogger<AzureComputeServicesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAzureComputeServices")]
        public IEnumerable<AzureService> Get()
        {
            //azureServices.Clear();
            AzureService azureService = new AzureService();
            azureService.ServiceName = "App Service";
            azureService.Description = "Quickly build, deploy, and scale web apps and APIs on your terms.";
            azureService.DocumentationLink = new Uri("https://azure.microsoft.com/en-in/products/app-service/");
            azureServices.Add(azureService);

            azureService = new AzureService();
            azureService.ServiceName = "Azure Functions";
            azureService.Description = "Develop more efficiently with an event-driven, serverless compute platform that helps solve complex orchestration problems.";
            azureService.DocumentationLink = new Uri("https://azure.microsoft.com/en-in/products/functions/");
            azureServices.Add(azureService);

            azureService = new AzureService();
            azureService.ServiceName = "Virtual Machine";
            azureService.Description = "Create the right virtual machine for your Windows or Linux operating system-based workload.";
            azureService.DocumentationLink = new Uri("https://azure.microsoft.com/en-in/free/virtual-machines/search/?ef_id=_k_de8cd76e032219ca7be6b330318ec1f4_k_&OCID=AIDcmmf1elj9v5_SEM__k_de8cd76e032219ca7be6b330318ec1f4_k_&msclkid=de8cd76e032219ca7be6b330318ec1f4");
            azureServices.Add(azureService);

            azureService = new AzureService();
            azureService.ServiceName = "Azure Service Fabric";
            azureService.Description = "Service Fabric is an open source project and it powers core Azure infrastructure as well as other Microsoft services";
            azureService.DocumentationLink = new Uri("https://azure.microsoft.com/en-in/products/service-fabric/");
            azureServices.Add(azureService);

            azureService = new AzureService();
            azureService.ServiceName = "Azure Container Apps";
            azureService.Description = "Deploy containerized apps without managing complex infrastructure. Write code using your preferred programming language or framework, and build microservices ";
            azureService.DocumentationLink = new Uri("https://azure.microsoft.com/en-in/products/container-apps/");
            azureServices.Add(azureService);

            //azureServices[5].Description = "This is a test";

            foreach (AzureService  service in azureServices )
            {
                if (service.ServiceName == "Azure Container Apps")
                {
                    service.Description = "This is a test";
                }
            }

            //string sampleJson;
            //azureService = null;

            //if (azureService != null)
            //{
            //    sampleJson = JsonConvert.SerializeObject(azureService);
            //}
            //else
            //{
            //    sampleJson = null;
            //}

            //var sampleService = JsonConvert.DeserializeObject(sampleJson);


            //double premium = InsuranceCalculator.CalculatePremium(30, "female", 6, "sedan", 5, "urban", 1, 700, 12000, "comprehensive");


            //string sourceFilePath = @"C:\Demo\GitHubCopilot.png"; // Replace with your file path
            //FileUploader.UploadFile(sourceFilePath);

            //BlockThreads();

            //PremiumManager.CalculatePremium();

            return azureServices.ToArray();
        }


        private  void Thread1Method()
        {
            lock (lock1)
            {
                Console.WriteLine("Thread 1 acquired lock1");
                Thread.Sleep(100); // Simulate some work

                lock (lock2)
                {
                    Console.WriteLine("Thread 1 acquired lock2");
                }
            }
        }

        private  void Thread2Method()
        {
            lock (lock2)
            {
                Console.WriteLine("Thread 2 acquired lock2");
                Thread.Sleep(100); // Simulate some work

                lock (lock1)
                {
                    Console.WriteLine("Thread 2 acquired lock1");
                }
            }
        }

        private void BlockThreads()
        {
            Thread thread1 = new Thread(Thread1Method);
            Thread thread2 = new Thread(Thread2Method);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Threads completed execution.");
        }
    }
}