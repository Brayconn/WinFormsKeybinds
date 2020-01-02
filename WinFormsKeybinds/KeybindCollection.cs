using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace WinFormsKeybinds
{
    /// <summary>
    /// Collection of keybindings. Used purely for the .settings file
    /// </summary>
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class KeybindCollection
    {
        public List<Keybind> Keybinds { get; private set; }

        public KeybindCollection()
        {
            Keybinds = new List<Keybind>();
        }

        /// <summary>
        /// Adds a keybind to the list
        /// </summary>
        /// <param name="k">Input to recognise</param>
        /// <param name="s">Action to run</param>
        public void Add(KeyInput k, string s)
        {
            Keybinds.Add(new Keybind(k, s));
        }

        /// <summary>
        /// Adds a jeybind to the list
        /// </summary>
        /// <param name="k">Keybind to add</param>
        public void Add(Keybind k)
        {
            Keybinds.Add(k);
        }

        /// <summary>
        /// Converts this collection into a dictionary. Will throw an ArgumentException in the event of duplicate keys.
        /// </summary>
        /// <returns>The contents of this collection as a Dictionary</returns>
        public Dictionary<KeyInput,string> ToDictionary()
        {
            return (Dictionary<KeyInput, string>)this;
        }

        public override int GetHashCode()
        {
            return Keybinds.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is KeybindCollection kc && this.Keybinds.SequenceEqual(kc.Keybinds);
        }

        public static explicit operator Dictionary<KeyInput, string>(KeybindCollection kc)
        {
            var dict = new Dictionary<KeyInput, string>();
            for (int i = 0; i < kc.Keybinds.Count; i++)
                if (!dict.ContainsKey(kc.Keybinds[i].Input))
                    dict.Add(kc.Keybinds[i].Input, kc.Keybinds[i].Action);
                else
                    throw new System.ArgumentException("Input has already been mapped!",
                        $"Keybinds[{kc.Keybinds.IndexOf(kc.Keybinds[i])}], Keybinds[{i}]");
            return dict;
        }

        public static bool operator ==(KeybindCollection left, KeybindCollection right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(KeybindCollection left, KeybindCollection right)
        {
            return !(left == right);
        }
    }
}
