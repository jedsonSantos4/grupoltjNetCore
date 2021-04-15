namespace AppCore.Entities
{
    public class PictureEntity: BaseEntity
    {
        public string Name { get; set; }
        public decimal Size { get; set; }
        public string Url { get; set; }
        public string Key { get; set; }
    }
}
