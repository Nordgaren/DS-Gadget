using System;

namespace DS_Gadget
{
    internal class ControlAttribute : Attribute
    {
        public string Name { get; set; }

        public ControlAttribute(string name)
        {
            Name = name;
        }
    }
}