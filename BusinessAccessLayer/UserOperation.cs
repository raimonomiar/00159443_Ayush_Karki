using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntityLayer;

using DataAccessLayer;

namespace BusinessAccessLayer
{
    public class UserOperation
    {
        //User Login 
        public int Login(UserInfo ui)
        {
            var db = new DbConnection();
            int i = 0;
            int count = db.getUserAuthentication(ui);
            if (ui.username == "" || ui.password == "")
            {
                i = 0;

            }
            else
                if (count == 1)
                {
                    i = 1;

                }
                else
                {
                    i = 2;
                }
            return i;
        }
    }
}
