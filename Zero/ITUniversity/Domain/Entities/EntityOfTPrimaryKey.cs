namespace ITUniversity.Domain.Entities
{
    /// <summary>
    /// Сущность
    /// </summary>
    /// <typeparam name="TPrimaryKey">Тип первичного ключа</typeparam>
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        /// <inheritdoc/>
        public virtual TPrimaryKey Id { get; set; }
    }
}