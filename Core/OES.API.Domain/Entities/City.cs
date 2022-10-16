using Newtonsoft.Json;
using OES.API.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace OES.API.Domain.Entities
{
    public class City : BaseEntity
    {
        public string CityName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Event>? Events { get; set; }
        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
        [NotMapped]
        public override DateTime CreatedDate { get => base.CreatedDate; set => base.CreatedDate = value; }
    }
}
