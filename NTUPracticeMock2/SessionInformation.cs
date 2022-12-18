using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTUPracticeMock2
{
    public class SessionInformation
    {
        public bool isHR;
        public bool isManager;
        public Employee currentUser;
        public int modifiedUserID;

        public SessionInformation(bool isHR, bool isManager, Employee currentUser, int modifiedUserID = 0)
        {
            this.isHR = isHR;
            this.isManager = isManager;
            this.currentUser = currentUser;
            this.modifiedUserID = modifiedUserID;
        }
    }
}
