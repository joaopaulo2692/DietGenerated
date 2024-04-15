namespace Blazor_MestreDetalhes.ViewObject
{
    public class AlimentoVO
    {
        public int AlimentosId { get; set; }
        public string? Alimento { get; set; }
        public double Carboidrato { get; set; }
        public double Lipidio { get; set; }
        public double Proteina { get; set; }
        public double Kcal { get; set; }
        public string? Preparo { get; set; }
        public double Fibra { get; set; }
        public double Quantidade { get; set; }
    }
}
