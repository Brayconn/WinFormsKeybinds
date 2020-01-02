using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsKeybinds;
using System.Windows.Forms;
using static WinFormsKeybindsUnitTests.XMLSerialization;

namespace WinFormsKeybindsUnitTests
{
    [TestClass]
    public class KeyInputTests
    {
        static readonly KeyInput[] testData = new KeyInput[]
        {
            new KeyInput(Keys.Control | Keys.Alt | Keys.Delete),
            new KeyInput(Keys.A | Keys.B | Keys.C),
            new KeyInput(Keys.Insert)
        };

        [TestMethod]
        public void KeyInputIntegrity()
        {
            foreach (var val in testData)
            {
                Assert.AreEqual(Deserialize<KeyInput>(Serialize(val)), val);
            }
        }
    }
}
