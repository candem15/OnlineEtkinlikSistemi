﻿using Newtonsoft.Json;
using OES.API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Event>? Events { get; set; }
        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
        [NotMapped]
        public override DateTime CreatedDate { get => base.CreatedDate; set => base.CreatedDate = value; }
    }
}
