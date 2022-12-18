using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TPQR_Session1_01082022_BlazorWeb
{
    public partial class User
    {
        
        [Required]
        [MinLength(8)]
        public string UserId { get; set; }
        
        [Required]
        
        public string UserName { get; set; }
        
        [Required]
        public string UserPw { get; set; }
        
       
        public int UserTypeIdFk { get; set; }

        public virtual UserType UserTypeIdFkNavigation { get; set; }

        public override string ToString()
        {
            return $"{UserId}, {UserName}, {UserPw}, {UserTypeIdFk}";
        }
    }
}
