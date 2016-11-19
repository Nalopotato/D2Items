namespace D2Items.Model
{
    public class ItemModsModel : BaseModel
    {
        public string Name { get; set; }

        public int ModID { get; set; }
        public float ModValue1 { get; set; }
        public float ModValue2 { get; set; }

        public override string Label
        {
            get
            {
                return (this.Name);
            }
        }    
    }
}