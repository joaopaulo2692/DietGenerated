using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dieta.Core.Data
{
    public class Diet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DietId { get; set; }
        public string DietName { get; set; }
        public string DietType { get; set; }
        public virtual List<Meal>? Meals { get; set; }
 
        public List<Client>? Client { get; set; }



    }
}
