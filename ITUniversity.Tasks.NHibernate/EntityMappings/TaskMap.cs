using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Enums;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ITUniversity.Tasks.NHibernate.EntityMappings
{
    /// <summary>
    /// Описание структуры сущности <see cref="TaskMap"/>
    /// </summary>
    public class TaskMap : ClassMapping<TaskBase>
    {
        /// <summary>
        /// Инициализировать экземпляр <see cref="TaskMap"/>
        /// </summary>
        public TaskMap()
        {
            Id(x => x.Id, x =>
            {
                x.Generator(Generators.Increment);
                x.Type(NHibernateUtil.Int64);
                x.Column("Id");
            });

            Property(b => b.Subject, x =>
            {
                x.Type(NHibernateUtil.String);
            });

            Property(b => b.Description, x =>
            {
                x.Type(NHibernateUtil.String);
            });

            Property(b => b.CreationDate, x =>
            {
                x.Type(NHibernateUtil.DateTime);
                x.NotNullable(true);
            });

            Property(b => b.Status, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            Table(TaskBase.TableName);
        }
    }
}