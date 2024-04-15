using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor_MestreDetalhes.Data
{
    public class Alimentos2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlimentosId { get; set; }
        public string? Alimento { get; set; }
        public double Carboidrato { get; set; }
        public double Lipidio { get; set; }
        public double Proteina { get; set; }
        public double Kcal { get; set; }
        public string? Preparo { get; set; }
        public double Fibra { get; set; }
        public double Quantidade {  get; set; }

        //public int RefeicaoId { get; set; }
        //public virtual Refeicao Refeicao { get; set; }
        public virtual List<Refeicao2> Refeicao { get; set; }

    }
}
