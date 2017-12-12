using System;
using Xunit;
using Moq;
using Client;

namespace Client.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Add_NewArticle_QuantityMatches()
        {
            var client = new Mock<ShopClient>();
            var target = new Cart(client.Object);
            var article = new Article { Id = 10 };

            target.Add(article, 11);

            Assert.True(target.Items.ContainsKey(article));
            Assert.Equal(11, target.Items[article]);
        }

        [Fact]
        public void Add_ExistingArticle_QuantityAdds()
        {
            var client = new Mock<ShopClient>();
            var target = new Cart(client.Object);
            var article = new Article { Id = 10 };

            target.Add(article, 11);
            target.Add(article, 11);

            Assert.True(target.Items.ContainsKey(article));
            Assert.Equal(22, target.Items[article]);
        }

        [Fact]
        public void Add_NegativeQuantity_RemovesItems()
        {
            var client = new Mock<ShopClient>();
            var target = new Cart(client.Object);
            var article = new Article { Id = 10 };

            target.Add(article, 11);
            target.Add(article, -5);

            Assert.True(target.Items.ContainsKey(article));
            Assert.Equal(6, target.Items[article]);
        }

        [Fact]
        public void Add_NegativeQuantityMoreThanCurrent_ThrowsException()
        {
            var client = new Mock<ShopClient>();
            var target = new Cart(client.Object);
            var article = new Article { Id = 10 };

            target.Add(article, 11);

            Assert.Throws<NegativeQuantityException>(() => target.Add(article, -55));
        }

        [Fact]
        public void Add_ArticleIsNull_ThrowsException()
        {
            var client = new Mock<ShopClient>();
            var target = new Cart(client.Object);

            Assert.Throws<ArgumentNullException>(() => target.Add(null, 10));
        }
    }
}
