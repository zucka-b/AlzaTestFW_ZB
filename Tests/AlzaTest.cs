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
            AlzaKosikPage alzaKosikPage = new AlzaBasePage(driver)
                .OpenUrl()
                .ClickOnChosenCategory("Notebooky a tablety")
                .ClickOnOdNejlevnejsihoTabButton()
                .ClickOnKoupitFirstProductButton()
                .ClickOnKosikButton()
                .ClickOnPokracovatButton()
                .ClickOnAlzaShowRoomCheckBox()
                .ClickOnStandardniVydejRadioButton()
                .ClickOnHotoveKartouPriVyzvednutiCheckBox()
                .ClickOnPokracovatButton()
                .InputEmail("random.email@gmail.com")
                .InputTelefon("606000666")
                .ClickOnChciDoplnitFakturacniUdajeCheckBox()
                .InputFakturacniUdaje("Random Name", "Random Street 42", "Random City", "66600");
            Assert.That(alzaKosikPage.CheckInputDataAreValid, "Input data are not valid, your order cannot be completed!");
        }

    }
}
