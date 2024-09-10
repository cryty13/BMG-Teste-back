using BMG.Models;

namespace BMG.Services
{
    public interface IClientService
    {
        // Defina os métodos que o ClientService deve implementar
        Client AddClient(Client client);
        Client GetClientById(int id);
        IEnumerable<Client> GetAllClients(string search);
        void DeleteClient(int id);
        void SendEmail(Client client);
    }
}