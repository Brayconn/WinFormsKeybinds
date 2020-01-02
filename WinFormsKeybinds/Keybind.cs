namespace WinFormsKeybinds
{
    /// <summary>
    /// Represents a keybinding
    /// </summary>
    public struct Keybind
    {
        public KeyInput Input { get; set; }
        public string Action { get; set; }

        public Keybind(KeyInput i, string a)
        {
            Input = i;
            Action = a;
        }

        public override bool Equals(object obj)
        {
            return obj is Keybind k && Input.Equals(k.Input) && Action == k.Action;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                //being really inventive with this hash code...
                int hash = 17;
                hash = hash * 23 + Input.GetHashCode();
                hash = hash * 23 + Action.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Keybind left, Keybind right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Keybind left, Keybind right)
        {
            return !(left == right);
        }
    }
}
