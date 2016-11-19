namespace D2Items.Model
{
    public class RuneModel : BaseModel
    {
        //public int ID { get; set; }
        public string Name { get; set; }
        public override string Label
        {
            get
            {
                return Name;
            }
        }
    }
}