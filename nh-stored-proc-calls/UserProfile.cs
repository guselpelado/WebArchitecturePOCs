using System;
using System.Collections.Generic;

using System.Linq;


namespace nh_stored_proc_calls
{

    public class UserProfile
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Apellido { get; set; }
    }
}