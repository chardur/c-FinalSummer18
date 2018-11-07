using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Assignment3Conv.BL;
using Assignment3Conv.Models;

namespace Assignment3Conv.ViewModels
{
    public class CompanyVM : ObservableObject
    {
        private string _Street;
        private string _City;
        private string _State;
        private string _Zip;
        private Company _company;
        private string _Name;
        private Company _selectedCompany;

        public Company company
        {
            get => _company;
            set
            {
                _company = new Company { Name = _Name, Street = _Street, City = _City, State = _State, Zip = _Zip };
                RaisePropertyChangedEvent("address");
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

        public Company selectedCompany
        {
            get => _selectedCompany;
            set
            {
                _selectedCompany = value;
                if (_selectedCompany != null)
                {
                    Name = _selectedCompany.Name;
                    Street = _selectedCompany.Street;
                    City = _selectedCompany.City;
                    State = _selectedCompany.State;
                    Zip = _selectedCompany.Zip;
                }
                else
                {
                    Name = String.Empty;
                    Street = String.Empty;
                    City = String.Empty;
                    State = String.Empty;
                    Zip = String.Empty;
                }
            }
        }

        private ObservableCollection<Company> _CompanyList = new ObservableCollection<Company>();
        public ObservableCollection<Company> CompanyList
        {
            get
            {
                _CompanyList = CompanyBL.GetCompanies();
                return _CompanyList;
            }
        }

        public ICommand CompanySubmit => new DelegateCommand(AddCompany);

        private void AddCompany()
        {
            if (String.IsNullOrEmpty(_Name) || String.IsNullOrEmpty(_Street) || String.IsNullOrEmpty(_City) || String.IsNullOrEmpty(_State) ||
                String.IsNullOrEmpty(_Zip))
            {
                MessageBox.Show("Please Complete all fields");
                return;
            }
            else if (_selectedCompany != null)
            {
                _company = new Company { Name = _Name, Street = _Street, City = _City, State = _State, Zip = _Zip };
                _company.Id = _selectedCompany.Id;
                CompanyBL.PutCompany(_company);
                _CompanyList = CompanyBL.GetCompanies();
                RaisePropertyChangedEvent("CompanyList");

                Name = String.Empty;
                Street = String.Empty;
                City = String.Empty;
                State = String.Empty;
                Zip = String.Empty;
            }
            else
            {
                _company = new Company {Name = _Name, Street = _Street, City = _City, State = _State, Zip = _Zip};
                CompanyBL.PostCompany(_company);
                _CompanyList = CompanyBL.GetCompanies();
                RaisePropertyChangedEvent("CompanyList");

                Name = String.Empty;
                Street = String.Empty;
                City = String.Empty;
                State = String.Empty;
                Zip = String.Empty;
            }
        }


    }
}