using BooksCenterService.Interfaces;
using BooksCenterService.Models;

namespace BooksCenterService
{
    public interface ICustomerService
    {
        bool AddUser(Customer user);
        bool DeleteUser(string userName);
        Customer GetUser(string userName);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _userRepository;

        public CustomerService(ICustomerRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AddUser(Customer user)
        {
            return _userRepository.AddCustomer(user);
        }

        public bool DeleteUser(string userName)
        {
            return _userRepository.DeleteCustomer(userName);
        }

        public Customer GetUser(string userName)
        {
            return _userRepository.GetCustomer(userName);
        }
    }
}
