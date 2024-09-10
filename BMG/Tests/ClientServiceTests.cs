using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using BMG.Data;
using BMG.Models;
using BMG.Services;
using System.Collections.Generic;
using System.Linq;

namespace BMG.Tests
{
    public class ClientServiceTests
    {
        private ClientService GetClientService()
        {
            var options = new DbContextOptionsBuilder<ClientContext>()
                .UseInMemoryDatabase(databaseName: "BMGTest")
                .Options;

            var context = new ClientContext(options);
            return new ClientService(context);
        }

        [Fact]
        public void AddClient_ShouldAddClient()
        {
            var service = GetClientService();
            var client = new Client { Name = "Test Client", Email = "test@example.com", Phone = "123456789" };

            service.AddClient(client);

            Assert.Equal(1, service.GetAllClients(null).Count());
        }

        [Fact]
        public void GetAllClients_ShouldReturnAllClients()
        {
            var service = GetClientService();
            service.AddClient(new Client { Name = "Client 1", Email = "client1@example.com", Phone = "123456789" });
            service.AddClient(new Client { Name = "Client 2", Email = "client2@example.com", Phone = "987654321" });

            var clients = service.GetAllClients(null);

            Assert.Equal(2, clients.Count());
        }

        [Fact]
        public void GetClientById_ShouldReturnClient()
        {
            var service = GetClientService();
            var client = new Client { Name = "Test Client", Email = "test@example.com", Phone = "123456789" };
            service.AddClient(client);

            var retrievedClient = service.GetClientById(client.Id);

            Assert.Equal(client.Name, retrievedClient.Name);
        }

        [Fact]
        public void DeleteClient_ShouldRemoveClient()
        {
            var service = GetClientService();
            var client = new Client { Name = "Test Client", Email = "test@example.com", Phone = "123456789" };
            service.AddClient(client);

            service.DeleteClient(client.Id);

            Assert.Null(service.GetClientById(client.Id));
        }
    }
}