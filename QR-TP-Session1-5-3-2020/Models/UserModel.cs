namespace QR_TP_Session1_5_3_2020
{
    public class UserModel
    {
        public UserModel(string userId, string userName, string userPw, int userTypeIdFK)
        {
            this.userId = userId;
            this.userName = userName;
            this.userPw = userPw;
            this.userTypeIdFK = userTypeIdFK;
        }

        public string userId { get; set; }
        public string userName { get; set; }
        public string userPw { get; set; }
        public int userTypeIdFK { get; set; }
    }
}