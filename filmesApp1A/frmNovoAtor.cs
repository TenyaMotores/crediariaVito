using filmesApp1A.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filmesApp1A
{
    public partial class frmNovoAtor : Form
    {
        Contexto db;
        public frmNovoAtor()
        {
            InitializeComponent();
        }

        private void frmNovoAtor_Load(object sender, EventArgs e)
        {
            this.db = new Contexto();
            List<Pais> paises = this.db.Pais.ToList();
            cbxNacionalidade.DataSource = paises;
        }

        private void frmNovoAtor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.db.Dispose();
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            if (cbxNacionalidade.SelectedIndex > -1)
            {
                Ator novo = new Ator();
                novo.Nome = txtNome.Text;
                novo.Nacionalidade = this.db.Pais.Where(
                        p => p.Nome == cbxNacionalidade.SelectedItem.ToString()
                    ).First();
                this.db.Ator.Add(novo);
                this.db.SaveChanges();
                MessageBox.Show("Sucesso");
                this.Close();
            }
        }
    }
}
