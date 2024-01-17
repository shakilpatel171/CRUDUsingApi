using Demo.Data;
using Demo.Data.Models;
using Demo.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        DemoDbContext _db;
        public CustomerRepository(DemoDbContext db)
        {
            _db = db;       
        }
        public void Create(Customer customer)
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _db.Customers.Remove(customer);
            _db.SaveChanges();
        }

        public Customer FindById(int id)
        {
             return _db.Customers.Find(id);
        }

        public List<Customer> GetAll()
        {
            return _db.Customers.ToList();
        }

        public void Update(Customer customer)
        {
            _db.Customers.Update(customer);
            _db.SaveChanges(); 
        }
    }
}
