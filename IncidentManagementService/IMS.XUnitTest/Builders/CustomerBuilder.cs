
using IMS.Core.Dtos;

namespace IMS.UnitTests.Builders
{
    public class CustomerBuilder
    {
        private CustomerDto _Customer = new CustomerDto();
        public CustomerBuilder Id(int Id)
        {
            _Customer.Id = Id;
            return this;
        }
        public CustomerBuilder Name(string name)
        {
            _Customer.Name = name;
            return this;
        }
        public CustomerBuilder Phone(string Phone)
        {
            _Customer.Phone = Phone;
            return this;
        }
        public CustomerBuilder Address(string Address)
        {
            _Customer.Address = Address;
            return this;
        }
        public CustomerBuilder Email(string Email)
        {
            _Customer.Email = Email;
            return this;
        }

        public CustomerBuilder WithDefaultValues()
        {
            _Customer = new CustomerDto
            {
                Id=0,
                Name = "aaaa",
                Address = "add",
                Email = "email@gmail.com",
                Phone = "01007983756"
            };

            return this;
        }

        public CustomerDto Build() => _Customer;
    }
}
