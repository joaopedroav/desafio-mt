using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend_mt.Models
{
    [Table("Departamento")]
    public class Departamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Código é um campo obrigatório.")]
        [StringLength(3, ErrorMessage = "Código não pode ultrapassar 3 caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Descrição é um campo obrigatório.")]
        [StringLength(50, ErrorMessage = "Descrição não pode ultrapassar 50 caracteres.")]
        public string Descricao { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Produto> Produtos { get; set; }
    }
}
