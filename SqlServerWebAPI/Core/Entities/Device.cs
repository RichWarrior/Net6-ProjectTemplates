using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public partial class Device
    {
        public Device()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? CreatorId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? StatusId { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
