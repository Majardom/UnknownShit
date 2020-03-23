using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BLL.DTO.Abstract
{
    [DataContract]
    public abstract class BaseBllEntity
    {
        [DataMember]
        [Required]
        public int Id { get; set; }
    }
}
