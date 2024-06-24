using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebServer.Model.DbEntity
{
    [Table("account")]
    public class AccountEntity
    {
        // 그냥 해당 컬럼이 기본키라는 것을 알려줌
        //[Key]
        [Column("account_id")]
        public long AccountId { get; set; }

        [Column("user_id")]
        public string UserId { get; set; }

        [Column("user_password")]
        public string UserPassword { get; set; }
    }
}
