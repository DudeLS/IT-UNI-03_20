using ITUniversity.Tasks.Entities;

using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ITUniversity.Tasks.NHibernate.EntityMappings
{
    public class TaskMap : ClassMapping<TaskBase>
    {
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

            Table("Tasks");
        }
    }
}