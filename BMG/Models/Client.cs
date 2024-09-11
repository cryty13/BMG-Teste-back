using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMG.Models
{
    [Table("tb_cliente")]
    public class Cliente
    {
        [Key]
        [Column("idCliente")]
        public int Id { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Column("email")]
        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Column("telefone")]
        [Required]
        [StringLength(20)]
        public string Telefone { get; set; }

        [Column("cep")]
        [StringLength(8)]
        public string? Cep { get; set; }

        [Column("logradouro")]
        [StringLength(100)]
        public string? Logradouro { get; set; }

        [Column("complemento")]
        [StringLength(100)]
        public string? Complemento { get; set; }

        [Column("bairro")]
        [StringLength(100)]
        public string? Bairro { get; set; }

        [Column("estado")]
        [StringLength(100)]
        public string? Estado { get; set; }

        [Column("cidade")]
        [StringLength(100)]
        public string? Cidade { get; set; }

        [Column("numero")]
        public int? Numero { get; set; }

        [Column("UF")]
        [StringLength(2)]
        public string? UF { get; set; }

        [Column("status")]
        public bool Status { get; set; } = true;

        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [Column("data_exclusao")]
        public DateTime? DataExclusao { get; set; }
    }
}