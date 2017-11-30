using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace ExemploSignalR {
    public class ServerHub : Hub {

        private static List<User> nomes = new List<User>();

        public override Task OnDisconnected(bool stopCalled) {
            try {
                nomes.RemoveAll(x => x.Id == Context.ConnectionId);

                Clients.All.broadcastLoad(nomes, false);

                return base.OnDisconnected(true);
            } catch (Exception ex) {
                throw new InvalidOperationException("Problem in disconnecting from chat server!");
            }
        }
                
        public void Enviar(string nome, string id, string de, string mensagem) {

            de = de.Replace("Usuario:", "");

            if (id == "todos") {
                Clients.All.broadcastMessage(de, mensagem);
            } 
            else {
                Clients.Client(id).broadcastMessage(de, mensagem);
            }
        }

        public void LoadDD(string nome) {

            bool existeUser = false;

            var result = nomes.Find(x => x.Nome == nome);


            if (result == null) {
                User user = new User();

                user.Id = Context.ConnectionId;
                user.Nome = nome;

                nomes.Add(user);
            } else {
                existeUser = true;
            }

            Clients.All.broadcastLoad(nomes, existeUser);
        }
    }
}