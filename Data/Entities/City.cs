using TheBridge.Data.BaseEntities;

namespace TheBridge.Data.Entities
{
    public class City:BaseEntity
    {
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        
    }
}
