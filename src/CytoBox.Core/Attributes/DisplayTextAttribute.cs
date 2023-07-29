namespace CytoBox.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Enum)]
    public class DisplayTextAttribute : Attribute
    {
        private readonly string _displayText;

        public string DisplayText => _displayText;

        public DisplayTextAttribute(string displayTest)
        {
            _displayText = displayTest;
        }
    }
}
