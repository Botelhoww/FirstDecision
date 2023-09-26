using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstDecision.Model.Entities;

[Index("Email", Name = "UQ__Pessoa__A9D105345444188A", IsUnique = true)]
public partial class Pessoa
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Nome { get; set; }

    [StringLength(255)]
    public string? Sobrenome { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DataNascimento { get; set; }

    [Required]
    [StringLength(255)]
    public string Email { get; set; }

    [StringLength(20)]
    public string? Telefone { get; set; }

    [StringLength(255)]
    public string? Endereco { get; set; }

    [StringLength(100)]
    public string? Cidade { get; set; }

    [StringLength(50)]
    public string? Estado { get; set; }

    [Column("CEP")]
    [StringLength(10)]
    public string? Cep { get; set; }

    [Column("CPFCNPJ")]
    [StringLength(14)]
    public string CpfCnpj { get; set; }
}