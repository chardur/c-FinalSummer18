using System.Collections.ObjectModel;
using Assignment3Conv.Models;
using Newtonsoft.Json;

namespace Assignment3Conv.BL
{
    public class CompanyBL : BaseBL
    {
        public static string CompanyApiUrl => Settings.WebApiUrl + "Company/";

        public static Company GetCompany(int id)
        {
            var response = ApiCall(CompanyApiUrl + id, "Get");
            var Company = JsonConvert.DeserializeObject<Company>(response);
            return Company;
        }

        public static ObservableCollection<Company> GetCompanies()
        {
            var response = ApiCall(CompanyApiUrl, "Get");
            var CompanyList = JsonConvert.DeserializeObject<ObservableCollection<Company>>(response);
            return CompanyList;
        }

        public static Company PostCompany(Company Company)
        {
            var CompanyJson = JsonConvert.SerializeObject(Company);
            var response = ApiCall(CompanyApiUrl, "Post", CompanyJson);
            var CompanyToAdd = JsonConvert.DeserializeObject<Company>(response);
            return CompanyToAdd;
        }

        public static void PutCompany(Company Company)
        {
            var CompanyJson = JsonConvert.SerializeObject(Company);
            var response = ApiCall(CompanyApiUrl + Company.Id, "Put", CompanyJson);
            //var CompanyToAdd = JsonConvert.DeserializeObject<Company>(response);
            //return CompanyToAdd;
        }
    }
}