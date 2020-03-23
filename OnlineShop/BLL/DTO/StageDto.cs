using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using BLL.DTO.Abstract;

namespace BLL.DTO
{
    [DataContract]
    public class StageDto : BaseBllEntity
    {
        [DataMember]
        [Required, StringLength(20)]
        public string Caption { get; set; }
    }
}
