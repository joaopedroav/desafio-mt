using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend_mt.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Código é um campo obrigatório.")]
        [StringLength(4, ErrorMessage = "Código não pode ultrapassar 4 caracteres.")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Descrição é um campo obrigatório.")]
        [StringLength(50, ErrorMessage = "Descrição não pode ultrapassar 50 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Departamento é um campo obrigatório.")]
        [ForeignKey("Departamento")]
        public Guid DepartamentoId { get; set; }

        [Required(ErrorMessage = "Preço é um campo obrigatório.")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "Status é um campo obrigatório.")]
        public bool Status { get; set; }

        //[JsonIgnore]
        //public virtual Departamento Departamento { get; set; }
    }
}
