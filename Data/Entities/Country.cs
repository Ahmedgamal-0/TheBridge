using TheBridge.Data.BaseEntities;

namespace TheBridge.Data.Entities
{
    public class Country:BaseEntity
    {
        public ICollection<City> Cities { get; set; }
    }
}
