using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Sinh_Vien
{
    public static class Globals
    {
        public static int GlobalsUserId {get; private set;}
        public static void SetGlobalsUserId(int userId)
        {
            GlobalsUserId = userId;
        }
        public static int GlobalsContactId { get; private set; }
        public static void SetGlobalsContactId(int ContactID)
        {
            GlobalsContactId = ContactID;
        }

    }
}
