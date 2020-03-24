namespace ITUniversity.Domain.Entities
{
    /// <summary>
    /// Сущность, с первичным ключем с типа <see cref="int"/>
    /// </summary>
    public abstract class Entity : Entity<int>, IEntity
    {

    }
}