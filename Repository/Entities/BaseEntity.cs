using System;

namespace Data.Entities
{

        public abstract class BaseEntity
        {

            public DateTime? CreatedDate { get; set; }
            public DateTime? UpdatedDate { get; set; }
            public DateTime? DeletedDate { get; set; }
            public string CreatedBy { get; set; }
            public bool? IsDeleted { get; set; }
            public string UpdatedBy { get; set; }
            public string DeletedBy { get; set; }

        }
}
