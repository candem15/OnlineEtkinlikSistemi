namespace OES.API.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        virtual public DateTime CreatedDate { get; set; }
        virtual public DateTime UpdatedDate { get; set; }
    }
}
