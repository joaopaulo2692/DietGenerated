using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.OpenXmlFormats.Dml.Diagram;


using System.Collections.Generic;
using Blazor_MestreDetalhes.Pages;
using System.Globalization;
using Blazor_MestreDetalhes.Data;
using Dieta.Core.Data;

namespace Blazor_MestreDetalhes.Service
{
    public class AlimentoService
    {
        private List<Pedido> pedidos = new List<Pedido>()
        {
            // ... (seu código existente)
        };

        private List<Food> cardapio = new List<Food>();

        //public List<Alimentos> Cardapio => cardapio;

        string filePath = @"C:\Users\joaop\Downloads\tab01.xls";

        public async Task<List<Food>> ObterAlimentos()
        {
            try
            {


                await using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = null;

                    if (filePath.EndsWith(".xls"))
                        workbook = new HSSFWorkbook(fs);

                    ISheet sheet = workbook?.GetSheetAt(0);

                    if (sheet != null)
                    {
                        int rowQtde = 1994;

                        for (int q = 5; q < rowQtde; q++)
                        {
                            IRow curRow = sheet.GetRow(q);

                            if (curRow != null && curRow.GetCell(1)?.StringCellValue != "")
                            {
                                string carbo = AlteraString(curRow.GetCell(7).ToString() ?? string.Empty);
                                string kcal = AlteraString(curRow.GetCell(4)?.ToString() ?? string.Empty);
                                string proteina = AlteraString(curRow.GetCell(5)?.ToString() ?? string.Empty);
                                string lipidio = AlteraString(curRow.GetCell(6)?.ToString() ?? string.Empty);
                                string fibra = AlteraString(curRow.GetCell(8)?.ToString() ?? string.Empty);

                                string preparo = curRow.GetCell(3)?.StringCellValue ?? string.Empty;
                                if (preparo == "Não se aplica")
                                {
                                    preparo = "";
                                }
                                Food alimento = new Food()
                                {

                                    //Alimento = curRow.GetCell(1)?.StringCellValue ?? string.Empty,                                   
                                    //Alimento = curRow.GetCell(1)?.StringCellValue + $"({q-4})",
                                    Prepare = curRow.GetCell(3)?.StringCellValue ?? string.Empty,
                                    FoodName = curRow.GetCell(1)?.StringCellValue + " " + preparo,
                                    //Carboidrato = curRow.GetCell(7)?.ToString() ?? string.Empty,
                                    Carb = double.Parse(carbo),

                                    Kcal = double.Parse(kcal),
                                    Protein = double.Parse(proteina),
                                    Fat = double.Parse(lipidio),
                                    Fiber = double.Parse(fibra)
                                };

                                cardapio.Add(alimento);


                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                // Registre ou lide com a exceção adequadamente
                throw ex;
            }
            var novoAlimentoLista = new List<Food>();
            foreach (var alimento in cardapio)
            {
                novoAlimentoLista.Add(alimento);
            }
            return novoAlimentoLista;
        }

        static double TentaConverterParaDouble(string texto, CultureInfo[] culturas)
        {
            foreach (var cultura in culturas)
            {
                if (double.TryParse(texto, NumberStyles.Any, cultura, out double resultado))
                {
                    return resultado;
                }
            }

            // Se não foi possível converter com nenhuma cultura, você pode lidar com isso de alguma forma
            throw new ArgumentException("Não foi possível converter a string para double.");
        }

        string AlteraString(string s)
        {
            if (s == "-")
            {
                s = "0";

                return s;
            }

            return s;
        }
    }

}
