using Events;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Read.Tests
{
    public class CartEventProcessorsTests
    {
        private readonly ICarts _fakeCarts;
        private readonly CartEventProcessors _cartEventProcessors;
        private readonly Cart _testCart;

        public CartEventProcessorsTests()
        {
            _fakeCarts = A.Fake<ICarts>();
            _cartEventProcessors = new CartEventProcessors(_fakeCarts);

            // Initialize an empty cart as a baseline for all tests
            _testCart = new Cart
            {
                Id = Guid.NewGuid(),
                Lines = new List<CartLine>()
            };

            // Arrange so test cart is always returned from processor
            A.CallTo(() => _fakeCarts.GetById(A<Guid>._)).Returns(_testCart);
        }

        [Fact]
        public void Process_WhenCartExists_ShouldAddProductToCart()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new ItemAddedToCart
            {
                GrossItemPrice = 129,
                NetItemPrice = 99,
                Product = productId,
                Quantity = 1
            };

            // Act
            _cartEventProcessors.Process(product);

            // Assert
            Assert.Single(_testCart.Lines);
            Assert.Equal(1, _testCart.Lines.Single().Quantity);
            Assert.Equal(129, _testCart.Lines.Single().Price.Gross);
            Assert.Equal(99, _testCart.Lines.Single().Price.Net);
            Assert.Equal(productId, _testCart.Lines.Single().Product);

            A.CallTo(() => _fakeCarts.Save(A<Cart>._)).MustHaveHappened(Repeated.Exactly.Once);
        }

        [Fact]
        public void Process_WhenAddingSameProductThreeTimes_ShouldOnlyIncreaseQuantityInCart()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new ItemAddedToCart
            {
                GrossItemPrice = 129,
                NetItemPrice = 99,
                Product = productId,
                Quantity = 1
            };

            // Act
            _cartEventProcessors.Process(product);
            _cartEventProcessors.Process(product);
            _cartEventProcessors.Process(product);

            // Assert
            Assert.Single(_testCart.Lines);
            Assert.Equal(3, _testCart.Lines.Single().Quantity);
            Assert.Equal(129, _testCart.Lines.Single().Price.Gross);
            Assert.Equal(99, _testCart.Lines.Single().Price.Net);
            Assert.Equal(productId, _testCart.Lines.Single().Product);

            A.CallTo(() => _fakeCarts.Save(A<Cart>._)).MustHaveHappened(Repeated.Exactly.Times(3));
        }

        [Fact]
        public void Process_WhenAddingTwoDifferentProducts_ShouldAddBothToCart()
        {
            // Arrange
            var product1Id = Guid.NewGuid();
            var product1 = new ItemAddedToCart
            {
                GrossItemPrice = 129,
                NetItemPrice = 99,
                Product = product1Id,
                Quantity = 1
            };

            var product2Id = Guid.NewGuid();
            var product2 = new ItemAddedToCart
            {
                GrossItemPrice = 449,
                NetItemPrice = 399,
                Product = product2Id,
                Quantity = 1
            };

            // Act
            _cartEventProcessors.Process(product1);
            _cartEventProcessors.Process(product2);

            // Assert
            Assert.Equal(2, _testCart.Lines.Count());
            A.CallTo(() => _fakeCarts.Save(A<Cart>._)).MustHaveHappened(Repeated.Exactly.Twice);
        }
    }
}