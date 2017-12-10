using Xunit;
using Moq;
using Cart;
using Api.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Tests.Extensions;

namespace Api.Tests
{
    public class CartControllerTest
    {
        [Fact]
        public void Get__ReturnsOk()
        {
            var cartFacade = new Mock<ICartFacade>();
            cartFacade
                .Setup(facade => facade.GetCurrentCart())
                .Returns(new Cart.Cart
                {
                    Items = new[] {
                        new CartItem {
                            ArticleId = 10,
                            Quantity = 10
                        }
                    }
                });
            var target = new CartController(cartFacade.Object);

            var actual = target.Get();

            Assert.IsType<OkObjectResult>(actual);
        }

        [Fact]
        public void Get_TwoItems_ReturnsTwoItems()
        {
            var cartFacade = new Mock<ICartFacade>();
            cartFacade
                .Setup(facade => facade.GetCurrentCart())
                .Returns(new Cart.Cart
                {
                    Items = new[] {
                        new CartItem {
                            ArticleId = 10,
                            Quantity = 10
                        },
                        new CartItem {
                            ArticleId = 11,
                            Quantity = 10
                        }
                    },
                });
            var target = new CartController(cartFacade.Object);

            var actual = target.Get().As<CartModel>();

            Assert.Equal(2, actual.Items.Count());
        }

        [Fact]
        public void Get_TwoItems_ReturnsProperArticleId()
        {
            var cartFacade = new Mock<ICartFacade>();
            cartFacade
                .Setup(facade => facade.GetCurrentCart())
                .Returns(new Cart.Cart
                {
                    Items = new[] {
                        new CartItem {
                            ArticleId = 10,
                            Quantity = 22
                        },
                    },
                });
            var target = new CartController(cartFacade.Object);

            var actual = target.Get().As<CartModel>();

            Assert.Equal(10, actual.Items.Single().Article.Id);
        }

        [Fact]
        public void Get_TwoItems_ReturnsProperQuantity()
        {
            var cartFacade = new Mock<ICartFacade>();
            cartFacade
                .Setup(facade => facade.GetCurrentCart())
                .Returns(new Cart.Cart
                {
                    Items = new[] {
                        new CartItem {
                            ArticleId = 10,
                            Quantity = 22
                        }
                    },
                });
            var target = new CartController(cartFacade.Object);

            var actual = target.Get().As<CartModel>();

            Assert.Equal(22, actual.Items.Single().Quantity);
        }

        [Fact]
        public void Put_ModelStateIsInvalid_Returns400()
        {
            var cartFacade = new Mock<ICartFacade>();
            var target = new CartController(cartFacade.Object);

            target.ModelState.AddModelError("Model", "Invalid");
            var actual = target.Put(null);

            Assert.IsType<BadRequestObjectResult>(actual);
        }

        [Fact]
        public void Put_ValidInput_UpdatesValueInCartFacade()
        {
            var items = new[] {
                    new CartItemModel {
                        Article = new ArticleShortModel{
                            Id = 10
                        },
                            Quantity = 22
                        }
            };
            var cartFacade = new Mock<ICartFacade>();
            var target = new CartController(cartFacade.Object);

            var actual = target.Put(new CartModel
            {
                Items = items,
            });

            cartFacade.Verify(x=>x.UpdateCart(It.IsAny<Cart.Cart>()));
        }

        [Fact]
        public void Put_ValidInput_CountOfItemsIsTheSame()
        {
            var items = new[] {
                    new CartItemModel {
                        Article = new ArticleShortModel{
                            Id = 10
                        },
                            Quantity = 22
                    },
                    new CartItemModel
                    {
                        Article = new ArticleShortModel
                        {
                            Id = 11
                        },
                        Quantity = 2
                    }
            };
            var cartFacade = new Mock<ICartFacade>();
            var target = new CartController(cartFacade.Object);

            var actual = target.Put(new CartModel
            {
                Items = items
            });

            cartFacade.Verify(x => x.UpdateCart(
                It.Is<Cart.Cart>(cart=>cart.Items.Count() == 2)
            ));
        }

        [Fact]
        public void Put_ValidInput_PreservesOrderOfItems()
        {
            var items = new[] {
                    new CartItemModel {
                        Article = new ArticleShortModel{
                            Id = 10
                        },
                            Quantity = 22
                    },
                    new CartItemModel
                    {
                        Article = new ArticleShortModel
                        {
                            Id = 11
                        },
                        Quantity = 2
                    }
            };
            var cartFacade = new Mock<ICartFacade>();
            var target = new CartController(cartFacade.Object);

            var actual = target.Put(new CartModel
            {
                Items = items
            });

            cartFacade.Verify(x => x.UpdateCart(
                It.Is<Cart.Cart>(
                    cart => cart.Items.First().ArticleId == 10
                           && cart.Items.Skip(1).First().ArticleId == 11
                )
            ));
        }

        [Fact]
        public void Put_ValidInput_PreservesPropertiesOfAnItem()
        {
            var cartFacade = new Mock<ICartFacade>();
            var target = new CartController(cartFacade.Object);

            var actual = target.Put(new CartModel
            {
                Items = new[] {
                    new CartItemModel {
                        Article = new ArticleShortModel{
                            Id = 10
                        },
                            Quantity = 22
                        }
                    },
            });

            cartFacade.Verify(x => x.UpdateCart(It.Is<Cart.Cart>(
                cart => cart.Items.Single().ArticleId == 10
                && cart.Items.Single().Quantity == 22
            )));
        }
    }
}
