using Blazor_MestreDetalhes.Pages;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blazor_MestreDetalhes.Data
{
    public class Refeicao2
    {
        public int RefeicaoId { get; set; }
        public string NomeRefeicao { get; set; }
        public TimeSpan Horario { get; set; }

        

        // Dieta a qual a refeição pertence
        //public int DietId { get; set; }
        //public virtual Diet Diet { get; set; }
        public virtual List<Diet2> Diet { get; set; }

        // Lista de alimentos que compõem a refeição
        public virtual List<Alimentos2> Alimentos { get; set; }


    }
}
