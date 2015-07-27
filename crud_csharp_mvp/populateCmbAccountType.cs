using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace crud_csharp_mvp
{
    public class populateCmbAccountType
    {
        public static void populateAccountType(ref ComboBox comboBox)
        {
            //usually i will retrieve distinct user-types from the database and loop it here, but 
            //you can do that. for simplicity's sake this will do for now. you'll learn and practice
            //this code project anyway when you "improve" or refactor this code.
            //don't forget to add me on fb (mag pm kayo ah kung saan nyo ako nakilala) abrenicamarkjoshua@gmail.com
            if (comboBox.Items.Count > 0)
            {
                comboBox.Items.Clear();
            }
            comboBox.Items.Add("user");
            comboBox.Items.Add("admin");

        }
    }
}
