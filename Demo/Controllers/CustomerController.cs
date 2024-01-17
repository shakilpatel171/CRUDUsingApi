using Demo.Data.Models;
using Demo.Repository.Interface;
using Demo.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _categoryService;
        public CustomerController(ICustomerService categoryService)
        {
            _categoryService = categoryService;
        }   
          
        [HttpGet]
        [ActionName("All Customer")]
        [Route("GetAll")]
        public IActionResult GetAllCustomer( )
        {
            var customers = _categoryService.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]   
        public IActionResult GetCustomerById(int id) 
        {
            var customer= _categoryService.FindById(id);
            return Ok(customer);
        }

        [HttpPost]
        [Route("Cretae")]
        public IActionResult Create(Customer customer)
        {
          if(ModelState.IsValid)
            {
                try
                {
                    Customer cust = new Customer()
                    {
                        Name = customer.Name,
                        City = customer.City,
                        Age = customer.Age
                    };
                    _categoryService.Create(cust);

                    return Created("Create", cust);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

          return BadRequest("Please check input");

            
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(int id, Customer customer) 
        { 
            if(id !=customer.CustomerId)
            {
                return BadRequest("Please check customer Id");
            }
            if(ModelState.IsValid)
            {
                try
                {
                    Customer cust = new Customer()
                    {
                        CustomerId = customer.CustomerId,
                        Name = customer.Name,
                        City = customer.City,
                        Age = customer.Age
                    };
                    _categoryService.Update(cust);
                    return Ok(cust);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
                
            }
            return BadRequest("Please check input data");

        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Please check Customer Id");

            Customer cust = _categoryService.FindById(id);

            if(cust != null)
            {
                try
                {
                    _categoryService.Delete(cust);
                    return Ok(cust);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            return NotFound($"Customer with id {id} Not Found");
        }
    }
}
