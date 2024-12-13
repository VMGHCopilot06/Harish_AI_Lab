using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIMDemoAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace APIMDemoAPI.Controllers.Tests
{
    [TestClass()]
    public class AzureComputeServicesControllerAzureComputeServicesControllerTests
    {
        private AzureComputeServicesController _controller;
        private ILogger<AzureComputeServicesController> _logger;

        [TestInitialize]
        public void Setup()
        {
            _logger = new LoggerFactory().CreateLogger<AzureComputeServicesController>();
            _controller = new AzureComputeServicesController(_logger);
        }

        [TestMethod]
        public void Get_ShouldReturnAllAzureServices()
        {
            // Act
            var result = _controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
        }

        [TestMethod]
        public void Get_ShouldReturnCorrectServiceNames()
        {
            // Act
            var result = _controller.Get().ToList();

            // Assert
            Assert.AreEqual("App Service", result[0].ServiceName);
            Assert.AreEqual("Azure Functions", result[1].ServiceName);
            Assert.AreEqual("Virtual Machine", result[2].ServiceName);
            Assert.AreEqual("Azure Service Fabric", result[3].ServiceName);
            Assert.AreEqual("Azure Container Apps", result[4].ServiceName);
        }

        [TestMethod]
        public void Get_ShouldReturnCorrectServiceDescriptions()
        {
            // Act
            var result = _controller.Get().ToList();

            // Assert
            Assert.AreEqual("Quickly build, deploy, and scale web apps and APIs on your terms.", result[0].Description);
            Assert.AreEqual("Develop more efficiently with an event-driven, serverless compute platform that helps solve complex orchestration problems.", result[1].Description);
            Assert.AreEqual("Create the right virtual machine for your Windows or Linux operating system-based workload.", result[2].Description);
            Assert.AreEqual("Service Fabric is an open source project and it powers core Azure infrastructure as well as other Microsoft services", result[3].Description);
            Assert.AreEqual("Deploy containerized apps without managing complex infrastructure. Write code using your preferred programming language or framework, and build microservices ", result[4].Description);
        }

        [TestMethod]
        public void Get_ShouldReturnCorrectDocumentationLinks()
        {
            // Act
            var result = _controller.Get().ToList();

            // Assert
            Assert.AreEqual("https://azure.microsoft.com/en-in/products/app-service/", result[0].DocumentationLink.ToString());
            Assert.AreEqual("https://azure.microsoft.com/en-in/products/functions/", result[1].DocumentationLink.ToString());
            Assert.AreEqual("https://azure.microsoft.com/en-in/free/virtual-machines/search/?ef_id=_k_de8cd76e032219ca7be6b330318ec1f4_k_&OCID=AIDcmmf1elj9v5_SEM__k_de8cd76e032219ca7be6b330318ec1f4_k_&msclkid=de8cd76e032219ca7be6b330318ec1f4", result[2].DocumentationLink.ToString());
            Assert.AreEqual("https://azure.microsoft.com/en-in/products/service-fabric/", result[3].DocumentationLink.ToString());
            Assert.AreEqual("https://azure.microsoft.com/en-in/products/container-apps/", result[4].DocumentationLink.ToString());
        }

        [TestMethod]
        public void Get_ShouldReturnEmptyList_WhenNoServicesAvailable()
        {
            // Arrange
            var emptyController = new AzureComputeServicesController(_logger);
            AzureComputeServicesController.azureServices.Clear();

            // Act
            var result = emptyController.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }
    }
}