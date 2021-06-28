using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayRoll
{
    public class Checking
    {
        public static bool CheckEmpty(String text1,String combo1)
        {

            if (text1== "" && combo1 == "")
            {
                
                return false;

            }
            else if (text1 == "")
            {
               
                return false;
            }
            else if (combo1== "")
            {
                return false;
            }

            return true;

        }

        public bool dateCheck(DateTime dateTimePicker1, DateTime dateTimePicker2)
        {
            DateTime date1 = dateTimePicker1;
            DateTime date2 = dateTimePicker2; ;
            if (date1.CompareTo(date2) < 0)
            {
                return true;
            }
            else if (date1.CompareTo(date2) == 0)
            {
                return true;
            }
            return false;
        }



    }
}
