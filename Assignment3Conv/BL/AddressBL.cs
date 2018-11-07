using System;
using System.Collections.ObjectModel;
using Assignment3Conv.Models;
using Newtonsoft.Json;

namespace Assignment3Conv.BL
{
    public class AddressBL : BaseBL
    {
        public static string AddressApiUrl => Settings.WebApiUrl + "Address/";

        public static Address GetAddress(int id)
        {
            var response = ApiCall(AddressApiUrl + id, "Get");
            var Address = JsonConvert.DeserializeObject<Address>(response);
            return Address;
        }

        public static ObservableCollection<Address> GetAddressList(int clientId)
        {
            var response = ApiCall(AddressApiUrl + clientId, "Get");
            if (response != null)
            {
                var AddressList = JsonConvert.DeserializeObject<ObservableCollection<Address>>(response);
                return AddressList;
            }
            return new ObservableCollection<Address>();
        }

        public static void PostAddress(Address address)
        {
            var AddressJson = JsonConvert.SerializeObject(address);
            var response = ApiCall(AddressApiUrl, "Post", AddressJson);
        }
    }
}