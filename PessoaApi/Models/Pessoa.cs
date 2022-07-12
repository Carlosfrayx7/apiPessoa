using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PessoaApi.Models
{
    [Table("PessoaTeste")]
    public class Pessoa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Whatsapp { get; set; }

    }
}
