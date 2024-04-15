
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Dieta.Core.Data
{
    public class Meal
    {
        public int RefeicaoId { get; set; }
        public string NomeRefeicao { get; set; }
        public TimeSpan Horario { get; set; }
        public int Ordenation { get; set; }
    
        public virtual List<Diet> Dieta { get; set; }


        //public virtual List<Alimentos> Alimentos { get; set; }

        //alt
        public virtual List<FoodsMeal> AlimentosRefeicoes { get; set; }
    }
}
