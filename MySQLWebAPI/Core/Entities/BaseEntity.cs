using Core.Enums;
using System;

namespace Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreationDate{ get; set; }
        public DateTime? ModifiedDate { get; set; }
        public EnumStatus Status { get; set; }
    }
}
