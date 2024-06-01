namespace Domain.Entities.Common
{
    public abstract class EntityBase
    {
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
