using System;
using System.Reflection;

namespace DS_Gadget
{
    class SavedStats
    {
        public string Name { get; set; }
        [Control("cmbSex")]
        public int? Sex { get; set; }
        [Control("cmbClass")]
        public int? Class { get; set; }
        [Control("cmbPhysique")]
        public int? Physique { get; set; }
        [Control("nudHumanity")]
        public int? Humanity { get; set; }
        [Control("nudSouls")]
        public int? Souls { get; set; }
        [Control("nudVit")]
        public int? Vit { get; set; }
        [Control("nudAtt")]
        public int? Att { get; set; }
        [Control("nudEnd")]
        public int? End { get; set; }
        [Control("nudStr")]
        public int? Str { get; set; }
        [Control("nudDex")]
        public int? Dex { get; set; }
        [Control("nudRes")]
        public int? Res { get; set; }
        [Control("nudInt")]
        public int? Int { get; set; }
        [Control("nudFth")]
        public int? Fth { get; set; }
        [Control("cmbCovenant")]
        public int? Covenant { get; set; }
        [Control("nudCovChaos")]
        public int? CovChaos { get; set; }
        [Control("nudCovDarkmoon")]
        public int? CovDarkmoon { get; set; }
        [Control("nudCovDarkwraith")]
        public int? CovDarkwraith { get; set; }
        [Control("nudCovForest")]
        public int? CovForest { get; set; }
        [Control("nudCovGravelord")]
        public int? CovGravelord { get; set; }
        [Control("nudCovDragon")]
        public int? CovDragon { get; set; }
        [Control("nudCovSunlight")]
        public int? CovSunlight { get; set; }

        //This indexer will take a name and match it to the Control Attribute name above each property
        public int? this[string attributeName]
        {
            get
            {
                //Get each property
                var props = typeof(SavedStats).GetProperties();
                foreach (var prop in props)
                {
                    //Check if it has a ControlAttribute with the same name
                    var Attr = prop.GetCustomAttribute<ControlAttribute>();
                    if (Attr != null && Attr.Name == attributeName)
                        return (int?)prop.GetValue(this, null); //Return matching Control Attribute as int?
                }
                return null;
            }
            set
            {
                //Get each property
                var props = typeof(SavedStats).GetProperties();
                foreach (var prop in props)
                {
                    //Check if it has a ControlAttribute with the same name
                    var Attr = prop.GetCustomAttribute<ControlAttribute>();
                    if (Attr != null && Attr.Name == attributeName)
                    {
                        prop.SetValue(this, value, null); //Set the properties value
                    }
                }
            }
        }
    }
}
