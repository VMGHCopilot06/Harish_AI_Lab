using Microsoft.AspNetCore.Mvc;

namespace APIMDemoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AzureServicesController : ControllerBase
    {
        private static List<AzureService> azureServices = new List<AzureService>();       
    
        private readonly ILogger<AzureServicesController> _logger;

        public AzureServicesController(ILogger<AzureServicesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllAzureServices")]
        public IEnumerable<AzureService> Get()
        {
            azureServices.Clear();
            AzureService azureService = new AzureService();
            azureService.ServiceName = "Azure Active Directory";
            azureService.Description = "Azure Active Directory (Azure AD) is a cloud-based identity and access management service";
            azureService.DocumentationLink = new Uri("https://learn.microsoft.com/en-us/azure/active-directory/fundamentals/active-directory-whatis");
            azureServices.Add(azureService);

            azureService = new AzureService();
            azureService.ServiceName = "Azure CDN";
            azureService.Description = "A content delivery network (CDN) is a distributed network of servers that can efficiently deliver web content to users";
            azureService.DocumentationLink = new Uri("https://learn.microsoft.com/en-us/azure/cdn/cdn-overview");
            azureServices.Add(azureService);

            azureService = new AzureService();
            azureService.ServiceName = "Azure Data Factory";
            azureService.Description = "Data Factory is a managed cloud service that's built for these complex hybrid extract-transform-load (ETL), extract-load-transform (ELT), and data integration projects.";
            azureService.DocumentationLink = new Uri("https://learn.microsoft.com/en-us/azure/data-factory/introduction");
            azureServices.Add(azureService);

            azureService = new AzureService();
            azureService.ServiceName = "Azure SQL";
            azureService.Description = "Migrate your SQL workloads to Azure with ease while maintaining complete SQL Server compatibility and operating system-level access.";
            azureService.DocumentationLink = new Uri("https://azure.microsoft.com/en-in/products/azure-sql/?ef_id=_k_8754db105df51ece3e75bf4e760f0b14_k_&OCID=AIDcmmf1elj9v5_SEM__k_8754db105df51ece3e75bf4e760f0b14_k_&msclkid=8754db105df51ece3e75bf4e760f0b14");
            azureServices.Add(azureService);

            azureService = new AzureService();
            azureService.ServiceName = "Azure Kubernetes Container";
            azureService.Description = "AKS allows you to quickly deploy a production ready Kubernetes cluster in Azure.";
            azureService.DocumentationLink = new Uri("https://learn.microsoft.com/en-us/azure/aks/");
            azureServices.Add(azureService);

            azureService = new AzureService();
            azureService.ServiceName = "CosmosDB";
            azureService.Description = "Azure Cosmos DB is a fully managed NoSQL and relational database for modern app development.";
            azureService.DocumentationLink = new Uri("https://learn.microsoft.com/en-us/azure/cosmos-db/introduction");
            azureServices.Add(azureService);

            azureService = new AzureService();
            azureService.ServiceName = "DevOps";
            azureService.Description = "Plan smarter, collaborate better, and ship faster with a set of modern dev services.";
            azureService.DocumentationLink = new Uri("https://azure.microsoft.com/en-in/products/devops/");
            azureServices.Add(azureService);

            azureService = new AzureService();
            azureService.ServiceName = "Azure Backup";
            azureService.Description = "The Azure Backup service provides simple, secure, and cost-effective solutions to back up your data and recover it from the Microsoft Azure cloud.";
            azureService.DocumentationLink = new Uri("https://learn.microsoft.com/en-us/azure/backup/backup-overview");
            azureServices.Add(azureService);

            azureService = new AzureService();
            azureService.ServiceName = "Logic Apps";
            azureService.Description = "Azure Logic Apps is a cloud platform where you can create and run automated workflows with little to no code. ";
            azureService.DocumentationLink = new Uri("https://learn.microsoft.com/en-us/azure/logic-apps/logic-apps-overview");
            azureServices.Add(azureService);

            azureService = new AzureService();
            azureService.ServiceName = "Virtual Machine";
            azureService.Description = "Create the right virtual machine for your Windows or Linux operating system-based workload.";
            azureService.DocumentationLink = new Uri("https://azure.microsoft.com/en-in/free/virtual-machines/search/?ef_id=_k_de8cd76e032219ca7be6b330318ec1f4_k_&OCID=AIDcmmf1elj9v5_SEM__k_de8cd76e032219ca7be6b330318ec1f4_k_&msclkid=de8cd76e032219ca7be6b330318ec1f4");
            azureServices.Add(azureService);

            return azureServices;
        }
    }
}
