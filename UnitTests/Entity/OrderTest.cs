using Application.Domain.Entity;

namespace UnitTests.Entity
{
    public class OrderTest
    {
        [Fact]
        public void ShouldThrowErrorWhenIdIsEmpty()
        {
            Exception actualException = Assert.Throws<Exception>(() => new Order("", "", new List<OrderItem>()));
            Assert.Equal("Id is required", actualException.Message);
        }

        [Fact]
        public void ShouldThrowErrorWhenCustomerIdIsEmpty()
        {
            Exception actualException = Assert.Throws<Exception>(() => new Order("1", "", new List<OrderItem>()));
            Assert.Equal("CostumerId is required", actualException.Message);
        }

        [Fact]
        public void ShouldThrowErrorOrderItemsIsEmpty()
        {
            Exception actualException = Assert.Throws<Exception>(() => new Order("1", "1", new List<OrderItem>()));
            Assert.Equal("Items is required", actualException.Message);
        }


        [Fact]
        public void ShouldCalculateTotal()
        {
            var order = new Order("1", "1", [new("1", "Item 1", 10, "1", 2), new("12", "Item 12", 10, "1", 1)]);
            Assert.Equal(30, order.GetTotal());
        }

        [Fact]
        public void ShouldThrowErrorIfQuantityIsZero()
        {
            Exception actualException = Assert.Throws<Exception>(() =>
                new Order("`ProductId", "ProductName", [new("1", "Item 1", 10, "1", 0)]));
            Assert.Equal("Quantity is required", actualException.Message);
        }
    }
}