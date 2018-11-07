using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Assignment3Conv.BL;
using Assignment3Conv.Models;

namespace Assignment3Conv.ViewModels
{
    public class ClientVM : ObservableObject
    {
        private Client _client;
        private string _Company;
        private string _Name;
        private string _Position;
        private ObservableCollection<Client> _clientList;
        
        public Client client
        {
            get => _client;
            set
            {
                _client = new Client{Name = _Name, Company = _Company, Position = _Position };
                RaisePropertyChangedEvent("client");
            }
        }

        public string Name
        {
            get => _Name;
            set
            {
                _Name = value;
                RaisePropertyChangedEvent("Name");
            }
        }


        public string Company
        {
            get => _Company;
            set
            {
                _Company = value;
                RaisePropertyChangedEvent("Company");
            }
        }

        public string Position
        {
            get => _Position;
            set
            {
                _Position = value;
                RaisePropertyChangedEvent("Position");
            }
        }

        public ObservableCollection<Client> ClientList
        {
            get
            {
                _clientList = ClientBL.GetClients();
                return _clientList;
            }
        }

        public ICommand ClientSubmit => new DelegateCommand(AddClient);
        public void AddClient()
        {
            if (String.IsNullOrEmpty(_Name) || String.IsNullOrEmpty(_Company) || String.IsNullOrEmpty(_Position))
            {
                MessageBox.Show("Please Complete all fields");
                return;
            }
            else
            {
                _client = new Client {Name = _Name, Company = _Company, Position = _Position};

                ClientBL.PostClient(_client);
                _clientList = ClientBL.GetClients();
                RaisePropertyChangedEvent("ClientList");

                Name = String.Empty;
            }
        }
    }
}