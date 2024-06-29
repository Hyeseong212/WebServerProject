using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebServer.Model.DbEntity
{
    [Table("inventory")]
    public class InventoryEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Column("account_id")]
        public long AccountId { get; set; }

        [Column("item_id")]
        public int ItemId { get; set; }
        [Column("count")]
        public long count { get; set; }
    }
}
