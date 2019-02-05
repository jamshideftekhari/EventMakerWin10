using System;
using System.Reflection;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using EventMakerWin10;
using EventMakerWin10.Annotations;
using EventMakerWin10.View;
using EventMakerWin10.ViewModel;

namespace EventMakerUnitTest
{
    [TestClass]
    public class EventHandlerTest
    {
        //public EventHandler TestHandler { get; set; }
        public EventViewModel TestViewModel { get; set; }
        [TestMethod]
        public void TestCreatEvent()
        {
            // Arrange
            TestViewModel = new EventViewModel();
            TestViewModel.Name = "1";


            // Act

            TestViewModel.EventHandler.CreateEvent();

            //Assert
            int eventCount = TestViewModel.EventCatalogSingletone.Events.Count;
            Assert.AreNotEqual(1,eventCount);
        }
        [TestMethod]
        public void TestCreatEvent1()
        {
            // Arrange
            TestViewModel = new EventViewModel();
            
            // Act
            try
            {
                TestViewModel.EventHandler.CreateEvent();
            }
            catch (ArgumentNullException e)
            {
               return;
            }
           
            //Assert
            Assert.Fail();
        }
    }
}
