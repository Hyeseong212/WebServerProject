using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServer.Model.DbEntity
{
    [Table("account")]
    public class AccountEntity
    {
        [Key]
        [Column("account_id")]
        public long AccountId { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        [Column("user_password")]
        public string UserPassword { get; set; }
    }

    [Table("account_character")]
    public class AccountCharacterEntity
    {
        [Column("account_id")]
        public long AccountId { get; set; }

        [Column("account_character")]
        public int AccountCharacter { get; set; }
    }

    [Table("account_currency")]
    public class AccountCurrencyEntity
    {
        [Column("account_id")]
        public long AccountId { get; set; }

        [Column("gold")]
        public long Gold { get; set; }
    }
}
