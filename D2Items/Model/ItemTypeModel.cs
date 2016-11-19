namespace D2Items.Model
{
    public class ItemTypeModel : BaseModel
    {
        public string Name { get; set; }
        public string BaseType { get; set; }
        public override string Label
        {
            get
            {
                return Name;
            }
        }
    }
}