namespace WebApi.Models
{
    public class Company
    {
        private int _Id;
        private string _Name;
        private string _City;
        private string _State;
        private string _Street;
        private string _Zip;

        public Company(string name = "none", string street = "none", string city = "none", string state = "none", string zip = "00000")
        {
            _Name = name;
            _Street = street;
            _City = city;
            _State = state;
            _Zip = zip;
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
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

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        //public string companyString => $"Name:  {_Name} Street: {Street} | City: {City} | State: {State} | Zip: {Zip}";
    }
}