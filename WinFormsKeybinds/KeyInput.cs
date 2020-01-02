using System.Windows.Forms;
using System.Configuration;

namespace WinFormsKeybinds
{
    /// <summary>
    /// Represents one input of buttons on the keyboard
    /// </summary>
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class KeyInput
    {
        public bool Shift { get; set; }        
        public bool Control { get; set; }
        public bool Alt { get; set; }
        public Keys KeyValue { get; set; }        
        public Keys KeyData
        {
            get
            {
                Keys value = KeyValue;
                if (Shift)
                    value |= Keys.Shift;
                if (Control)
                    value |= Keys.Control;
                if (Alt)
                    value |= Keys.Alt;
                return value;
            }
        }

        public KeyInput(Keys key)
        {
            //Each of these if statements sets a bool, then removes the bit from key if the bool is true
            if (Shift = (key & Keys.Shift) != 0)
                key &= ~Keys.Shift;
            if (Control = (key & Keys.Control) != 0)
                key &= ~Keys.Control;
            if (Alt = (key & Keys.Alt) != 0)
                key &= ~Keys.Alt;
            KeyValue = key;
        }

        public KeyInput() : this(Keys.None)
        {

        }

        public override bool Equals(object obj)
        {
            return obj switch
            {
                KeyInput kb => KeyData == kb.KeyData,
                KeyEventArgs kea => KeyData == kea.KeyData,
                _ => false
            };
        }
        public override int GetHashCode()
        {
            return KeyData.GetHashCode();
        }

        public static bool operator !=(KeyInput left, KeyInput right)
        {
            return !(left == right);
        }
        public static bool operator ==(KeyInput left, KeyInput right)
        {
            return left.Equals(right);
        }
    }
}
