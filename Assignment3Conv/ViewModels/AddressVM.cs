using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Assignment3Conv.BL;
using Assignment3Conv.Models;

namespace Assignment3Conv.ViewModels
{
    public class AddressVM : ObservableObject
    {

        private string _Street;
        private string _City;
        private string _State;
        private string _Zip;
        private Client _selectedClient;
        private Address _address;
        private ObservableCollection<Address> _AddressList;
        private Address _selectedAddress;

        public Address address
        {
            get => _address;
            set
            {
                _address = new Address { Street = _Street, City = _City, State = _State, Zip = _Zip};
                RaisePropertyChangedEvent("address");
            }
        }

        public Client selectedClient
        {
            get => _selectedClient;
            set
            {
                    _selectedClient = value;
                if (_selectedClient != null)
                {
                    _AddressList = AddressBL.GetAddressList(_selectedClient.Id);
                }

                    RaisePropertyChangedEvent("AddressList");
                    RaisePropertyChangedEvent("selectedClient");
                
            }
        }
        
        public string Street
        {
            get => _Street;
            set
            {
                _Street = value;
                RaisePropertyChangedEvent("Street");
            }
        }

        public string City
        {
            get => _City;
            set
            {
                _City = value;
                RaisePropertyChangedEvent("City");
            }
        }

        public string State
        {
            get => _State;
            set
            {
                _State = value;
                RaisePropertyChangedEvent("State");
            }
        }

        public string Zip
        {
            get => _Zip;
            set
            {
                _Zip = value;
                RaisePropertyChangedEvent("Zip");
            }
        }

        public Address selectedAddress
        {
            get => _selectedAddress;
            set
            {
                _selectedAddress = value;
                if (_selectedAddress != null)
                {

                    Street = _selectedAddress.Street;
                    City = _selectedAddress.City;
                    State = _selectedAddress.State;
                    Zip = _selectedAddress.Zip;
                }
                else
                {
                    Street = String.Empty;
                    City = String.Empty;
                    State = String.Empty;
                    Zip = String.Empty;
                }
            }
        }

        private ObservableCollection<Client> _clientList;
        public ObservableCollection<Client> ClientList
        {
            get
            {
                _clientList = (ClientBL.GetClients());
                return _clientList;
            }
        }


        public string addressString
        {
            get { return $"Street: {Street} | City: {City} | State: {State} | Zip: {Zip}"; }
        }

        
        public ObservableCollection<Address> AddressList
        {
            get
            {
                if (_selectedClient != null)
                {
                    _AddressList = AddressBL.GetAddressList(_selectedClient.Id);
                }

                return _AddressList;
            }
        }
        
        public ICommand AddressSubmit => new DelegateCommand(AddAddress);

        private void AddAddress()
        {
            if (_selectedClient == null || String.IsNullOrEmpty(_Street) || String.IsNullOrEmpty(_City) || String.IsNullOrEmpty(_State) || 
                String.IsNullOrEmpty(_Zip))
            {
                MessageBox.Show("Please Complete all fields and ensure a client is selected");
                return;
            }
            else
            {
                _address = new Address {Street = _Street, City = _City, State = _State, Zip = _Zip};
                _address.PostInfo = _selectedClient.Id;
                AddressBL.PostAddress(_address);
                _AddressList = AddressBL.GetAddressList(_selectedClient.Id);
                RaisePropertyChangedEvent("AddressList");

                Street = String.Empty;
                City = String.Empty;
                State = String.Empty;
                Zip = String.Empty;
            }
        }
    }
}