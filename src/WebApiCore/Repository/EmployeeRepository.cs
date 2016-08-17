using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiCore.Repository
{
    public class EmployeeRepository : Interface.IBasicRepository<Models.Employee>
    {
        
        private string _dbConnection;

        public EmployeeRepository()
        {
           
        }
        public void Create(Employee obj)
        {
            
            using (var context = GetContext())
            {
                context.Employees.Add(obj);
                context.SaveChanges();
            }

        }

        private Context.CommonDbContext GetContext()
        {
           
            var optionsBuilder = new DbContextOptionsBuilder<Context.CommonDbContext>();
            //optionsBuilder.UseSqlServer("Server=NISHANTJ8440;Database=TestDbWebApi;user id=sa; pwd=orion123;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(Startup.ConnectionString);
            return new Context.CommonDbContext(optionsBuilder.Options);
        }

        public void Delete(string Id)
        {
            var cntx = GetContext();

            Employee ee= cntx.Employees.First(e => e.EmpId == new Guid(Id));
            //var  emp = from e in cntx.Employees
            //          where (e.EmpId.Equals(new Guid(Id)))
            //          select e ;

            //Employee empObj = (Employee)emp;

            cntx.Employees.Remove(ee);
            cntx.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            var cntx = GetContext();

            var allEmp = from e in cntx.Employees
                         select e;

          //  IEnumerable<Employee> emparr = allEmp.ToArray();

                //Configurations["data:DSN:ConnectionString"];
               // Models.Employee[] emp = { new Models.Employee() { FirstName = "Nishant", LastName = "Joshi" }, new Models.Employee() { FirstName = "NJ", LastName = "TT" } };
            return (IEnumerable<Employee>)allEmp;
        }

        public Employee Retrieve(string Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee obj)
        {
            var cntx = GetContext();
            cntx.Employees.Update(obj);
            cntx.SaveChanges();
        }
    }
}
