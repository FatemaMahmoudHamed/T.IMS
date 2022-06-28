using IMS.UnitTests.Builders;
using Xunit;

namespace IMS.UnitTests
{
    public class CustomerUnitTest : BaseUnitTest
    {
        [Fact]
        public async void Create_New_Customer_Given_Valid_Information()
        {
            // Arrange
            var Customer = new CustomerBuilder().WithDefaultValues().Build();
            var CustomerService = ServiceHelper.CreateCustomerService();

            // Act
            var result = await CustomerService.AddAsync(Customer);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.True(result.Data.Id > 0);
        }

        
        [Fact]
        public async void Get_Customer_By_Id_Given_Valid_Information()
        {
            // Arrange
            var Customer = new CustomerBuilder().WithDefaultValues().Build();
            var CustomerService = ServiceHelper.CreateCustomerService();

            // Act
            var customer=await CustomerService.AddAsync(Customer);
            var result = await CustomerService.GetAsync(customer.Data.Id.Value);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(Customer.Id, result.Data.Id);
        }
    }

}
