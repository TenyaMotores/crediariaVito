using filmesApp1A.Models;

namespace filmesApp1A
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAtores act = new frmAtores(this);
            act.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmFilmes act = new frmFilmes(this);
            act.Show();
            this.Hide();   
        }
    }
}
