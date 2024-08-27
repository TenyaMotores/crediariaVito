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
    public partial class frmEditarAtor : Form
    {
        Ator ator;
        Contexto db;
        public frmEditarAtor(Ator ator)
        {
            InitializeComponent();
            this.db = new Contexto();

            this.ator = ator;

            cbxNacionalidade.DataSource = this.db.Pais.ToList();

            txtNome.Text = ator.Nome;
            cbxNacionalidade.SelectedIndex = cbxNacionalidade.FindStringExact(ator.Nacionalidade.Nome);

            dgvFilmes.DataSource = this.db.Filme
                                    .Where(f => f.Atores.Contains(ator))
                                    .ToList();
        }

        private void frmEditarAtor_Load(object sender, EventArgs e)
        {

        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (cbxNacionalidade.SelectedIndex > 0)
            {
                ator.Nome = txtNome.Text;
                ator.Nacionalidade = this.db.Pais.Where(
                        p => p.Nome == cbxNacionalidade.SelectedItem.ToString()
                    ).First();

                this.db.Ator.Update(ator);
                this.db.SaveChanges();

                MessageBox.Show("Sucesso");
            }
        }

        private void frmEditarAtor_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.db.Dispose();
        }
    }
}
