namespace ShipManagementApi.Entities
{
    public class Ship
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public string Code { get; set; }
    }
}