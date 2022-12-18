using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPage
{
    public class Session
    {
        public Employee currentUser { get; set; }
        public bool isManager { get; set; }
        public bool isHR { get; set; }
        public int modifiedCurrentUserID { get; set; }

        public Session(Employee currentUser, bool isManager, bool isHR, int modifiedCurrentUserID = 0)
        {
            this.currentUser = currentUser;
            this.isManager = isManager;
            this.isHR = isHR;
            this.modifiedCurrentUserID = modifiedCurrentUserID;
        }

        public Session()
        {
        }
    }
}
