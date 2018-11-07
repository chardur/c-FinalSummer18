using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Assignment3Conv.Models;
using Newtonsoft.Json;

namespace Assignment3Conv.BL
{
    public class ClientBL : BaseBL
    {
        public static string ClientApiUrl => Settings.WebApiUrl + "Client/";

        public static Client GetClient(int id)
        {
            var response = ApiCall(ClientApiUrl + id, "Get");
            var client = JsonConvert.DeserializeObject<Client>(response);
            return client;
        }

        public static ObservableCollection<Client> GetClients()
        {
            var response = ApiCall(ClientApiUrl, "Get");
            var clientList = JsonConvert.DeserializeObject<ObservableCollection<Client>>(response);
            return clientList;
        }

        public static Client PostClient(Client client)
        {
            var clientJson = JsonConvert.SerializeObject(client);
            var response = ApiCall(ClientApiUrl, "Post", clientJson);
            var ClientToAdd = JsonConvert.DeserializeObject<Client>(response);
            return ClientToAdd;
        }

    }
}