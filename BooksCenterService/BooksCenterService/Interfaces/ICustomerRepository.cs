using BooksCenterService.Models;

namespace BooksCenterService.Interfaces
{
    public interface ICustomerRepository
    {
        bool AddCustomer(Customer user);
        bool DeleteCustomer(string userName);
        Customer GetCustomer(string username);
    }

}
