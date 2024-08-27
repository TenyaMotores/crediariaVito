using filmesApp1A.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filmesApp1A
{
    public partial class frmAtores : Form
    {
        Contexto db;
        Form anterior;
        Ator selecionado;

        public frmAtores(Form anterior)
        {
            InitializeComponent();

            this.anterior = anterior;
        }

        public void Recarregar(string busca)
        {
            List<Ator> atores =
                this.db.Ator.Where(
                    a => a.Nome.ToUpper().Contains(busca.ToUpper())
                ).ToList();

            dgvAtores.DataSource = atores;
        }

        private void frmAtores_Load(object sender, EventArgs e)
        {
            this.db = new Contexto();
            this.db.Database.EnsureCreated(); // só pra garantir
            Recarregar("");
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            frmNovoAtor f = new frmNovoAtor();
            f.ShowDialog();
            Recarregar(txtBusca.Text);
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            Recarregar(txtBusca.Text);
        }

        private void dgvAtores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linha = dgvAtores.SelectedCells[0].RowIndex;
            int id = (int)dgvAtores.Rows[linha].Cells[0].Value;

            selecionado = this.db.Ator.Where(a => a.Id == id).First();

            btEditar.Enabled = true;
            btRemover.Enabled = true;
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show(
                "Deseja mesmo excluir o ator " + selecionado.Nome + "?",
                "Confirmação",
                MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                this.db.Ator.Remove(selecionado);
                this.db.SaveChanges();
                MessageBox.Show("Sucesso");
                Recarregar("");
                btEditar.Enabled = false;
                btRemover.Enabled = false;
            }
        }

        private void frmAtores_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.db.Dispose();
            this.anterior.Show();
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            frmEditarAtor f = new frmEditarAtor(selecionado);
            f.ShowDialog();
            Recarregar(txtBusca.Text);
        }
    }
}
