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
    public partial class frmEditarFilme : Form
    {
        Filme filme;
        Contexto db;
        public frmEditarFilme(Filme filme)
        {
            InitializeComponent();
            this.db = new Contexto();

            this.filme = filme;

            cbxNacionalidade.DataSource = this.db.Pais.ToList();

            txtNome.Text = filme.Nome;
            cbxNacionalidade.SelectedIndex = cbxNacionalidade.FindStringExact(filme.Nacionalidade.Nome);

            dgvAtores.DataSource = this.db.Ator
                                    .Where(f => f.Filmes.Contains(filme))
                                    .ToList();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (cbxNacionalidade.SelectedIndex > 0)
            {
                filme.Nome = txtNome.Text;
                filme.Nacionalidade = this.db.Pais.Where(
                        p => p.Nome == cbxNacionalidade.SelectedItem.ToString()
                    ).First();
                filme.AnoLancamento = (int)numAno.Value;
                this.db.Filme.Update(filme);
                this.db.SaveChanges();

                MessageBox.Show("Sucesso");
            }
        }

        private void frmEditarFilme_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.db.Dispose();
        }
    }
}
