namespace DataLayer.Models
{
    public class Company
    {
        private int _Id;
        private string _Name;
        private string _City;
        private string _State;
        private string _Street;
        private string _Zip;

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

        //public string companyString => $"Name:  {_Name} Street: {Street} | City: {City} | State: {State} | Zip: {Zip}";
    }
}