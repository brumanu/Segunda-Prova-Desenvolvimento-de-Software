using System;

namespace API.Models
{
    public class FormaPagamento
    {
        public FormaPagamento() => CriadoEm = DateTime.Now;
        public int FormaPagamentoId { get; set; }
        public string Nome { get; set; }
        public Boolean AVista { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}