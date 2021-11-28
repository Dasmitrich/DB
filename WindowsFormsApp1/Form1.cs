using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dimcomission dc = new Dimcomission();
            dc.getStrings(new DBlink().open_connection());
            List<string> data = dc.editWindowRows();
            listBox1.Items.AddRange(data.ToArray());
        }
    }
}
