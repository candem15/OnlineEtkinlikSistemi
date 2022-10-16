using Newtonsoft.Json;
using OES.API.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace OES.API.Domain.Entities
{
    public class Quota : BaseEntity
    {
        public Guid EventId { get; set; }
        public int NumberOfParticipants { get; set; }
        public int MaxParticipantsNumber { get; set; }
        [JsonIgnore]
        public virtual Event Event { get; set; }
        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
        [NotMapped]
        public override DateTime CreatedDate { get => base.CreatedDate; set => base.CreatedDate = value; }
    }
}
