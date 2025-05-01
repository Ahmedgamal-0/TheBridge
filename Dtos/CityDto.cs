namespace TheBridge.Dtos
{
    public class CityDto
    {
        public string Name { get; set; }
    }
    public class UpdateCityDto:CityDto
    {
       public Guid Id { get; set; }
    }
}
