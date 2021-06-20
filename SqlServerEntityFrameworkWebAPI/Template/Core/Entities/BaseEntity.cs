using $safeprojectname$.Enums;
using System;

namespace $safeprojectname$.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CreatorId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StatusId { get; set; }

        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            StatusId = (int)EnumStatus.Active;
        }
    }
}
