using Microsoft.JSInterop.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor_MestreDetalhes.Data
{
    public class Diet2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DietId { get; set; }
        public string NomeDieta { get; set; }
        public string TipoDieta { get; set; }
        public virtual List<Refeicao2>? Refeicoes { get; set; }
 
        public List<Cliente2>? Cliente { get; set; }



    }
}
