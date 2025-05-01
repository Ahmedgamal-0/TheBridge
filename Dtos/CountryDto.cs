namespace TheBridge.Dtos
{
    public class CountryDto
    {
        public string Name {  get; set; }
    }

    public class UpdateCountryDto : CountryDto
    {
        public Guid Id {  get; set; }
    }
}
