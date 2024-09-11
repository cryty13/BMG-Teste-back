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

        public Cliente AddClient(Cliente client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            _context.Client.Add(client);
            _context.SaveChanges();
            // SendEmail(client);
            return client;
        }

        public Cliente GetClientById(int id)
        {
            return _context.Client.Find(id);
        }

        public IEnumerable<Cliente> GetAllClients(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return _context.Client.ToList();
            }
            else
            {
                return _context.Client.Where(c => c.Nome.Contains(search)).ToList();
            }
        }

        public void DeleteClient(int id)
        {
            var client = _context.Client.Find(id);
            if (client != null)
            {
                client.Status = false;
                _context.SaveChanges();
            }
        }
        public void SendEmail(Cliente client)
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