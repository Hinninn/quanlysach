using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void trảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Return_Book rb = new Return_Book();
            rb.Show();
        }

        private void mượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Borrow_Book br = new Borrow_Book();
            br.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void thêmSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Book ab = new Add_Book();
            ab.Show();
        }

        private void thôngTinSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Book vb = new View_Book();
            vb.Show();
        }

        private void lịchSửMượnTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History_Book hb = new History_Book();
            hb.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void thêmĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Readers ar = new Add_Readers();
            ar.Show();
        }

        private void thôngTinĐộcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Readers vr = new View_Readers();
            vr.Show();
        }
    }
}
