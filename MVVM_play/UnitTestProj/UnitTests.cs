using Microsoft.UI.Xaml.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;

namespace UnitTestProj
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(0, 0);
        }

        // Use the UITestMethod attribute for tests that need to run on the UI thread.
        [UITestMethod]
        public void TestMethod2()
        {
            var grid = new Grid();
            Assert.AreEqual(0, grid.MinWidth);
        }

        [UITestMethod]
        public void TestUserControl1()
        {
            WinUIClassLibrary1.UserControl1 userControl1 = new();
            Assert.AreEqual(7, userControl1.GetSeven());
        }
    }
}
