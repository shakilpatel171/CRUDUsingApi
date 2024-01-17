using Demo.Data.Models;
using Demo.Repository.Interface;
using Demo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Implementation
{

    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository) 
        {
            _customerRepository = customerRepository;
        }
        public void Create(Customer customer)
        {
            _customerRepository.Create(customer);
            
        }

        public void Delete(Customer customer)
        {
            _customerRepository.Delete(customer);
        }

        public Customer FindById(int id)
        {
           return _customerRepository.FindById(id);
        }

        public List<Customer> GetAll()
        {
           return _customerRepository.GetAll();
        }

        public void Update(Customer customer)
        {
            _customerRepository.Update(customer);
        }
    }
}
