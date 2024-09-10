using BMG.Data;
using BMG.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace BMG.Services
{
    public class ClientService : IClientService
    {
        private readonly ClientContext _context;

        public ClientService(ClientContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Client AddClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            _context.Clients.Add(client);
            _context.SaveChanges();
            SendEmail(client);
            return client;
        }

        public Client GetClientById(int id)
        {
            return _context.Clients.Find(id);
        }

        public IEnumerable<Client> GetAllClients(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                throw new ArgumentNullException(nameof(search));
            }

            return _context.Clients.Where(c => c.Name.Contains(search)).ToList();
        }

        public void DeleteClient(int id)
        {
            var client = _context.Clients.Find(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }
        public void SendEmail(Client client)
        {
            // Configurações do SMTP
            SmtpClient _client = new SmtpClient("smtp.gmail.com", 587);
            _client.EnableSsl = true;
            _client.Credentials = new NetworkCredential("willian.bmg2024@gmail.com", "@BMG2024");

            // Criando a mensagem de email
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(client.Email);
            mail.To.Add("willian.bmg2024@gmail.com");
            mail.Subject = "Usuario Criado";
            mail.Body = "Este é o corpo do email.";

            try
            {
                _client.Send(mail);
                Console.WriteLine("Email enviado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao enviar email: " + ex.Message);
            }
        }
    }
}