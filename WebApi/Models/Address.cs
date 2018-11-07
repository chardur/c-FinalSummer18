namespace WebApi.Models
{
    public class Address
    {
        private string _City;
        private string _State;
        private string _Street;
        private string _Zip;
        private int _Id;
        private int _PostInfo;

        public Address(string street = "none", string city = "none", string state = "none", string zip = "00000")
        {
            _Street = street;
            _City = city;
            _State = state;
            _Zip = zip;
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public int PostInfo
        {
            get { return _PostInfo; }
            set { _PostInfo = value; }
        }

        public string Street
        {
            get { return _Street; }
            set { _Street = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        public string Zip
        {
            get { return _Zip; }
            set { _Zip = value; }
        }

        //public string addressString => $"Street: {Street} | City: {City} | State: {State} | Zip: {Zip}";
    }
}