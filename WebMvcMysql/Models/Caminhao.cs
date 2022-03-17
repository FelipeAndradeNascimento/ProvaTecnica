using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMvcMysql.Models
{
    [Table("Caminhao")]
    public class Caminhao
    {
        [Display(Name = "Codigo do Caminhao")]
        [Column("CaminhaoId")]
        public int CaminhaoId { get; set; }

        [Display(Name = "Modelo do Caminhao")]
        [Column("CaminhaoModelo")]
        public string CaminhaoModelo { get; set; }

        [Display(Name = "Ano de Fabricação do Caminhao")]
        [Column("CaminhaoAnoFabricacao")]
        public string CaminhaoAnoFabricacao { get; set; }

        [Display(Name = "Ano Modelo do Caminhao")]
        [Column("CaminhaoAnoModelo")]
        public string CaminhaoAnoModelo { get; set; }
    }
}
