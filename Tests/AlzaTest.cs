using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using AlzaTestFW_ZB.Pages;
using AlzaTestFW_ZB.Tests;

namespace AlzaTestFW_ZB
{
    public class AlzaTest : BaseTest
    {
        
        [Test]
        public void testCheapestProductInCategory()
        {
            var driver = setDriver();
            AlzaKatalogPage alzaPage = new AlzaKatalogPage(driver);
            AlzaKosikPage alzaKosikPage = alzaPage
                .clickOnChosenCategory("Notebooky a tablety")
                .clickOnOdNejlevnejsihoTabButton()
                .clickOnKoupitFirstProductButton()
                .clickOnKosikButton()
                .clickOnPokracovatButton()
                .clickOnAlzaShowRoomCheckBox()
                .clickOnStandardniVydejRadioButton()
                .clickOnHotoveKartouPriVyzvednutiCheckBox()
                .clickOnPokracovatButton()
                .inputEmail("random.email@gmail.com")
                .inputTelefon("606000666")
                .clickOnChciDoplnitFakturacniUdajeCheckBox()
                .inputFakturacniUdaje("Random Name", "Random Street 42", "Random City", "66600");
            Assert.That(alzaKosikPage.checkInputDataAreValid, "Input data are not valid, your order cannot be completed!");

            removeDriver(driver);
        }

    }
}
