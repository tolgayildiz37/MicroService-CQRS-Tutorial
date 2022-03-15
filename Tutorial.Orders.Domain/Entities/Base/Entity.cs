using System.ComponentModel.DataAnnotations.Schema;

namespace Tutorial.Orders.Domain.Entities.Base
{
    public class Entity : IEntityBase
    {
        // Database üzerinden generate edilebilir olduğunu söylüyoruz
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; protected set; }

        public Entity Clone()
        {
            // Nesne klonluyoruz
            return (Entity)this.MemberwiseClone();
        }
    }
}
