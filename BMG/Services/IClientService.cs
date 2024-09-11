using BMG.Models;

namespace BMG.Services
{
    public interface IClientService
    {
        // Defina os métodos que o ClientService deve implementar
        Cliente AddClient(Cliente client);
        Cliente GetClientById(int id);
        IEnumerable<Cliente> GetAllClients(string search);
        void DeleteClient(int id);
        void SendEmail(Cliente client);
    }
}