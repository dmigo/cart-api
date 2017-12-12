using System;
using Xunit;
using Moq;
using Client;
using System.Collections.Generic;

namespace Client.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Add_NewArticle_QuantityMatches()
        {
            var client = new Mock<IShopClient>();
            var target = new Cart(client.Object);
            var article = new Article { Id = 10 };

            target.Add(article, 11);

            Assert.True(target.Items.ContainsKey(article));
            Assert.Equal(11, target.Items[article]);
        }

        [Fact]
        public void Add_ExistingArticle_QuantityAdds()
        {
            var client = new Mock<IShopClient>();
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
            var client = new Mock<IShopClient>();
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
            var client = new Mock<IShopClient>();
            var target = new Cart(client.Object);
            var article = new Article { Id = 10 };

            target.Add(article, 11);

            Assert.Throws<NegativeQuantityException>(() => target.Add(article, -55));
        }

        [Fact]
        public void Add_ArticleIsNull_ThrowsException()
        {
            var client = new Mock<IShopClient>();
            var target = new Cart(client.Object);

            Assert.Throws<ArgumentNullException>(() => target.Add(null, 10));
        }

        [Fact]
        public void Add_SeveralItems_CountMatches()
        {
            var client = new Mock<IShopClient>();
            var target = new Cart(client.Object);

            target.Add(new Article { Id = 10 }, 11);
            target.Add(new Article { Id = 11 }, 2);
            target.Add(new Article { Id = 12 }, 33);

            Assert.Equal(3, target.Items.Count);
        }

        [Fact]
        public void Clear_HasSeveralItems_ItemsReturnsEmpty()
        {
            var client = new Mock<IShopClient>();
            var target = new Cart(client.Object);

            target.Add(new Article { Id = 10 }, 11);
            target.Add(new Article { Id = 11 }, 11);
            target.Add(new Article { Id = 12 }, 11);
            target.Clear();

            Assert.Equal(0, target.Items.Count);
        }

        [Fact]
        public void Load_ThrowsException_ShopClientExceptionRethrown()
        {
            var client = new Mock<IShopClient>();
            client
                .Setup(x => x.FetchCart())
                .Throws(new Exception());
            var target = new Cart(client.Object);

            Assert.Throws<ShopClientException>(() => target.Load());
        }

        [Fact]
        public void Submit_ThrowsException_ShopClientExceptionRethrown()
        {
            var client = new Mock<IShopClient>();
            client
                .Setup(x => x.SubmitCart(It.IsAny<IDictionary<Article, int>>()))
                .Throws(new Exception());
            var target = new Cart(client.Object);

            Assert.Throws<ShopClientException>(() => target.Submit());
        }
    }
}
