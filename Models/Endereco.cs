using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectPessoa.Models;

public class Endereco
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column(TypeName = "varchar(10)")]
    public string CEP { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string Logradouro { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string Complemento { get; set; }    
    public int? Numero { get; set; }
    [Required]
    [Column(TypeName = "varchar(2)")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "A UF deve ter exatamente 2 caracteres.")]
    [RegularExpression("[A-Za-z]{2}$", ErrorMessage = "A UF deve conter apenas letras.")]
    public string UF { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string Cidade { get; set; }

}
