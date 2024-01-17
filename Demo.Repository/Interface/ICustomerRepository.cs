using Demo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository.Interface
{
    public interface ICustomerRepository
    { 
        List<Customer> GetAll();
        Customer FindById(int id);
        void Create(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);


    }
}
