using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsKeybinds;
using System.Windows.Forms;
using static WinFormsKeybindsUnitTests.XMLSerialization;

namespace WinFormsKeybindsUnitTests
{
    [TestClass]
    public class KeybindTests
    {
        static readonly Keybind[] testData = new Keybind[]
        {
            new Keybind(new KeyInput(Keys.None),"Nothing")
        };

        [TestMethod]
        public void KeybindItegrity()
        {
            foreach (var val in testData)
            {
                Assert.AreEqual(val, Deserialize<Keybind>(Serialize(val)));
            }
        }
    }
}
