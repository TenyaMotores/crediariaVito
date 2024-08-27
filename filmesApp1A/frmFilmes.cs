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
    public partial class frmFilmes : Form
    {
        Contexto db;
        Form anterior;
        Filme selecionado;

        public frmFilmes(Form anterior)
        {
            InitializeComponent();

            this.anterior = anterior;
        }

        public void Recarregar(string busca)
        {
            List<Filme> filmes =
                this.db.Filme.Where(
                    a => a.Nome.ToUpper().Contains(busca.ToUpper())
                ).ToList();

            dgvFilmes.DataSource = filmes;
        }

        private void frmFilmes_Load(object sender, EventArgs e)
        {
            this.db = new Contexto();
            this.db.Database.EnsureCreated(); // só pra garantir
            Recarregar("");
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            frmNovoFilme f = new frmNovoFilme();
            f.ShowDialog();
            Recarregar(txtBusca.Text);
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            Recarregar(txtBusca.Text);
        }

        private void dgvFilmes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int linha = dgvFilmes.SelectedCells[0].RowIndex;
            int id = (int)dgvFilmes.Rows[linha].Cells[0].Value;

            selecionado = this.db.Filme.Where(a => a.Id == id).First();

            btEditar.Enabled = true;
            btRemover.Enabled = true;
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(
               "Deseja mesmo excluir o filme " + selecionado.Nome + "?",
               "Confirmação",
               MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                this.db.Filme.Remove(selecionado);
                this.db.SaveChanges();
                MessageBox.Show("Sucesso");
                Recarregar("");
                btEditar.Enabled = false;
                btRemover.Enabled = false;
            }
        }

        private void frmFilmes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.db.Dispose();
            this.anterior.Show();
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            frmEditarFilme f = new frmEditarFilme(selecionado);
            f.ShowDialog();
            Recarregar(txtBusca.Text);
        }
    }
}
