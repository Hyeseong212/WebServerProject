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
        [Column("account_id")]
        public long AccountId { get; set; }
        [Key]
        [Column("account_character")]
        public int AccountCharacter { get; set; }
    }

    [Table("account_currency")]
    public class AccountCurrencyEntity
    {
        [Key]
        [Column("account_id")]
        public long AccountId { get; set; }
        [Key]
        [Column("gold")]
        public long Gold { get; set; }
    }

    [Table("account_nickname")]
    public class AccountNickNameEntity
    {
        [Key]
        [Column("account_id")]
        public long AccountId { get; set; }
        [Key]
        [Column("account_nickName")]
        public string AccountNickName { get; set; }
    }
    [Table("inventory")]
    public class InventoryEntity
    {
        [Key]
        [Column("ItemUID")]
        public string ItemUID { get; set; }
        [Column("account_id")]
        public long AccountId { get; set; }
        [Column("item_id")]
        public int ItemId { get; set; }
        [Column("count")]
        public long count { get; set; }
    }
}
