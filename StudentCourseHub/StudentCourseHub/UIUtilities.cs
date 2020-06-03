using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 
* Kyra Bolster
*  Database Programming - Final Project
*  June 7, 2020
*/

namespace StudentCourseHub
{
    internal static class UIUtilities
    {
        public static void BindComboBox(ComboBox cmb, DataTable dt, string displayMember, string valueMember)
        {
            //Adding an empty DataRow in the DataTable at first index
            DataRow row = dt.NewRow();
            row[valueMember] = DBNull.Value;
            row[displayMember] = "";
            dt.Rows.InsertAt(row, 0);

            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
            cmb.DataSource = dt;
        }

        public static void ClearControls(Control.ControlCollection controls)
        {
            foreach (Control ctl in controls)
            {
                switch (ctl)
                {
                    case TextBox txt:
                        txt.Clear();
                        break;
                    case ComboBox cmb:
                        cmb.SelectedIndex = -1;
                        break;
                    case GroupBox gB:
                        ClearControls(gB.Controls);
                        break;
                }
            }
        }
    }
}
