using ITUniversity.Tasks.Entities;

using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ITUniversity.Tasks.NHibernate.EntityMappings
{
    /// <summary>
    /// Описание структуры сущности <see cref="User"/>
    /// </summary>
    public class UserMap : ClassMapping<User>
    {
        /// <summary>
        /// Инициализировать экземпляр <see cref="UserMap"/>
        /// </summary>
        public UserMap()
        {
            Id(property => property.Id, mapper =>
            {
                mapper.Generator(Generators.Increment);
                mapper.Type(NHibernateUtil.Int32);
                mapper.Column("Id");
            });

            Property(property => property.Login, mapping =>
            {
                mapping.Type(NHibernateUtil.String);
                mapping.NotNullable(true);
            });

            Property(property => property.Email, mapping =>
            {
                mapping.Type(NHibernateUtil.String);
                mapping.NotNullable(true);
            });

            Property(property => property.Password, mapping =>
            {
                mapping.Type(NHibernateUtil.String);
                mapping.NotNullable(true);
            });

            Property(property => property.IsBlocked, mapping =>
            {
                mapping.Type(NHibernateUtil.Boolean);
                mapping.NotNullable(true);
            });

            ManyToOne(property => property.Role, mapping =>
            {
                mapping.Column("RoleId");
                mapping.Cascade(Cascade.All);
            });

            Table(User.TableName);
        }
    }
}
