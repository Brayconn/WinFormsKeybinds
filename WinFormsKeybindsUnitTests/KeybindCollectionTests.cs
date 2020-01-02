using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinFormsKeybinds;
using System.Windows.Forms;
using static WinFormsKeybindsUnitTests.XMLSerialization;

namespace WinFormsKeybindsUnitTests
{
    [TestClass]
    public class KeybindCollectionTests
    {
        static readonly Keybind[][] testData = new Keybind[][]
        {
            new Keybind[] { new Keybind(new KeyInput(Keys.None), "Nothing") }
        };

        [TestMethod]
        public void KeybindCollectionIntegrity()
        {
            foreach (var val in testData)
            {
                var kc = new KeybindCollection();
                for (int i = 0; i < val.Length; i++)
                    kc.Add(val[i]);
                Assert.AreEqual(kc, Deserialize<KeybindCollection>(Serialize(kc)));
            }
        }
    }
}
