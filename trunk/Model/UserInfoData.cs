

namespace psms.Model
{
    //登录用户信息�?
    public class UserInfoData
    {
        private int id;
        private string username;
        private string name;
        private string password;
        private string power;

        public UserInfoData(int id,string username,string name,string password,string power)
        {
            this.id = id;
            this.username = username;
            this.name = name;
            this.password = password;
            this.power = power;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                this.username = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        public string Power
        {
            get
            {
                return this.power;
            }
            set
            {
                this.power = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

    }
}
