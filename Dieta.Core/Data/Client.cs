using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dieta.Core.Data
{
    public class Client : IdentityUser<string>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        //[Column("id")]
        //public override string Id { get; set; }
        //[Column("username")]
        //public override string UserName { get; set; }
        //[Column("normalized_username")]
        //public override string NormalizedUserName { get; set; }
        //[Column("email")]
        //public override string Email { get; set; }
        //[Column("normalized_email")]
        //public override string NormalizedEmail { get; set; }
        //[Column("email_confirmed")]
        //public override bool EmailConfirmed { get; set; }
        //[Column("password_hash")]
        //public override string PasswordHash { get; set; }
        //[Column("security_stamp")]
        //public override string SecurityStamp { get; set; }
        //[Column("concurrency_stamp")]
        //public override string ConcurrencyStamp { get; set; }
        //[Column("phone_number")]
        //public override string PhoneNumber { get; set; }
        //[Column("phone_number_confirmed")]
        //public override bool PhoneNumberConfirmed { get; set; }
        //[Column("two_factor_enabled")]
        //public override bool TwoFactorEnabled { get; set; }
        //[Column("lockout_end")]
        //public override DateTimeOffset? LockoutEnd { get; set; }
        //[Column("lockout_enabled")]
        //public override bool LockoutEnabled { get; set; }
        //[Column("access_failed_count")]
        //public override int AccessFailedCount { get; set; }
        public int ClientId {get; set;}
        public string? Name { get; set; }
        public int Age { get; set; }
        public float Heigth { get; set; }
        public float Weight { get; set; }
        public double BasalMeatabolicRate { get; set; }
        public int TrainingFreq { get; set; }

        public List<Diet>? Diets { get; set; } 
        public string? DietType { get; set; }
        public string? informationAdd { get; set; }

    }
}
