using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectPessoa.Models;

public class Pessoa
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string Name { get; set; }
    public DateTime DataNascimento { get; set; }
    [Column(TypeName = "varchar(11)")]
    public string Cpf { get; set; }
    public int EnderecoId { get; set; }
    public Endereco Endereco { get; set; }
}
