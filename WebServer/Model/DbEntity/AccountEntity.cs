using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServer.Model.DbEntity
{
    [Table("account")]
    public class AccountEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Column("account_id")]
        public long AccountId { get; set; }

        [Column("account_character")]
        public int AccountCharacter { get; set; }
    }

    [Table("account_currency")]
    public class AccountCurrencyEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Column("account_id")]
        public long AccountId { get; set; }

        [Column("gold")]
        public long Gold { get; set; }
    }

    [Table("account_nickname")]
    public class AccountNickNameEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Column("account_id")]
        public long AccountId { get; set; }

        [Column("account_nickName")]
        public string AccountNickName { get; set; }
    }
}
