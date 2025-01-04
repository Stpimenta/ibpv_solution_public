using System.ComponentModel.DataAnnotations;

namespace IbpvFrontend.Components.Pages.Gasto.form.models;

public class modelFormGasto
{
        public int Id { get; set; }
        [Required(ErrorMessage = "Insira um valor")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Valor deve ser positivo")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        public string? Descricao { get; set; } 

        [Required(ErrorMessage = "Data é obrigatória")]
        public DateTime Data { get; set; }

        public string? UrlComprovante { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo de caracteres atingido")]
        public string? NumeroFiscal { get; set; }

        [Required(ErrorMessage = "É necessário vínculo com um caixa")]
        public int IdCaixa { get; set; }
    
}