namespace Domain.Entities.Common
{
    public abstract class Entity<TId> : EntityBase
        where TId : IEquatable<TId>
    {
        public TId Id { get; set; }
    }
}
