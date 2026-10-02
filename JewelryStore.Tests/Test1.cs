using Microsoft.VisualStudio.TestTools.UnitTesting;
using JewelryStore.Models;
using JewelryStore.Services;
using JewelryStore.Exceptions;

namespace JewelryStore.Tests
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void Test_SuccessIntegration_AddAndSellItem()
        {
            // Внимание: Здесь должно быть имя вашего реального класса сервиса, например JewelryServices
            IJewelryServices service = new JewelryServices();
            var ring = new JewelryItem { Id = 1, Name = "Кольцо золотое", MetalType = "Золото", Price = 15999, Quantity = 5 };

            service.AddItem(ring);
            service.SellItem(1, 2);

            var updatedItem = service.GetItemById(1);
            Assert.IsNotNull(updatedItem);
            Assert.AreEqual(3, updatedItem.Quantity);
        }

        [TestMethod]
        public void Test_Exception_InvalidPrice()
        {
            IJewelryServices service = new JewelryServices();
            var brokenItem = new JewelryItem { Id = 2, Name = "Серебряный браслет", MetalType = "Серебро", Price = -1, Quantity = 1 };

            // По лабе метод AddItem должен выбрасывать исключение при отрицательной цене
            Assert.ThrowsException<JewelryException>(() => service.AddItem(brokenItem));
        }

        [TestMethod]
        public void Test_TryCatchFinally_Behavior()
        {
            IJewelryServices service = new JewelryServices();
            bool catchExecuted = false;
            bool finallyExecuted = false;

            try
            {
                // Пытаемся продать то, чего нет, чтобы вызвать ошибку
                service.SellItem(999, 1);
            }
            catch (JewelryException ex)
            {
                catchExecuted = true;
                System.Diagnostics.Debug.WriteLine($"Исключение {ex.Message} перехвачено");
            }
            finally
            {
                finallyExecuted = true;
            }

            Assert.IsTrue(catchExecuted, "catch не сработал");
            Assert.IsTrue(finallyExecuted, "finally не сработал");
        }
    } // Скобка класса теперь закрывается строго в конце всех методов!
}
