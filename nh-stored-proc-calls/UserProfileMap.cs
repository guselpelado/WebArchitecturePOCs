using FluentNHibernate.Mapping;

namespace nh_stored_proc_calls
{
    public class UserProfileMap : ClassMap<UserProfile>
    {
        public UserProfileMap()
        {
            Id(x => x.Id);
            Map(x => x.UserName).Unique();
            Map(x => x.Name);
            Map(x => x.Apellido);
        }
    }
}
