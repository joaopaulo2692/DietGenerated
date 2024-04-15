using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor_MestreDetalhes.Data
{
    public class Cliente2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId {get; set;}
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public double GastoMetaBasal { get; set; }
        public int TreinoFreq { get; set; }

        public List<Diet2>? Dieta { get; set; } 
        public string? tipoDieta { get; set; }
        public string? informacaoAdd { get; set; }

    }
}
