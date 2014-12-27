using System.Collections.Generic;

namespace GenericRepository
{
    public class FooService
    {
        private readonly IGenericRepository<Customer> _customeRepository;

        public FooService()
        {
            //can be injected from construction
            IDataContext dataContext = new DataContext("test");
            _customeRepository = new GenericRepository<Customer>(dataContext);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customeRepository.GetAll();
        }

        public Customer Save(Customer customer)
        {
            using (_customeRepository)
            {
               return _customeRepository.Add(customer);
            }
        }
    }
}