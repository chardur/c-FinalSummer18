using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataLayer.Models

{
    public class Client
    {
        private string _Company;
        private string _Name;
        private string _Position;
        private int _Id;
        private ObservableCollection<Address> _addressList;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }

        public string Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        public ObservableCollection<Address> AddressList
        {
            get => _addressList;
            set => _addressList = value;
        }

        public void addAddress(Address address)
        {
            _addressList.Add(address);
        }

        //public string clientString => $"Name: {Name} | Company: {Company} | Position: {Position}";

    }
}