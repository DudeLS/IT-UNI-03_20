using ITUniversity.Tasks.Entities;

using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ITUniversity.Tasks.NHibernate.EntityMappings
{
    /// <summary>
    /// Описание структуры сущности <see cref="Role"/>
    /// </summary>
    public class RoleMap : ClassMapping<Role>
    {
        /// <summary>
        /// Инициализировать экземпляр <see cref="RoleMap"/>
        /// </summary>
        public RoleMap()
        {
            Id(property => property.Id, mapper =>
            {
                mapper.Generator(Generators.Increment);
                mapper.Type(NHibernateUtil.Int32);
                mapper.Column("Id");
            });

            Property(property => property.Name, mapping =>
            {
                mapping.Type(NHibernateUtil.String);
                mapping.NotNullable(true);
            });

            Set(property => property.Users,
                collectionMapping =>
                {
                    collectionMapping.Key(keyMapping =>
                    {
                        keyMapping.Column("RoleId");
                    });
                    collectionMapping.Cascade(Cascade.All);
                },
                mapping =>
                {
                    mapping.OneToMany();
                }
            );

            Table(Role.TableName);
        }
    }
}