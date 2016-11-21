namespace D2Items.Model
{
    public class ItemModsModel : BaseModel
    {
        public string Name { get; set; }
        public int ModID { get; set; }
        public int ItemID { get; set; }
        public double ModValue1 { get; set; }
        public double ModValue2 { get; set; }
        public string Skill { get; set; }

        public override string Label
        {
            get
            {
                return (Name);
            }
        }    
    }
}