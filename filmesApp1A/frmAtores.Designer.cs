namespace filmesApp1A
{
    partial class frmAtores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtBusca = new TextBox();
            btBuscar = new Button();
            dgvAtores = new DataGridView();
            btAdicionar = new Button();
            btEditar = new Button();
            btRemover = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAtores).BeginInit();
            SuspendLayout();
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(12, 12);
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(589, 23);
            txtBusca.TabIndex = 0;
            // 
            // btBuscar
            // 
            btBuscar.Location = new Point(607, 12);
            btBuscar.Name = "btBuscar";
            btBuscar.Size = new Size(75, 23);
            btBuscar.TabIndex = 1;
            btBuscar.Text = "Buscar";
            btBuscar.UseVisualStyleBackColor = true;
            btBuscar.Click += btBuscar_Click;
            // 
            // dgvAtores
            // 
            dgvAtores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAtores.Location = new Point(12, 51);
            dgvAtores.Name = "dgvAtores";
            dgvAtores.Size = new Size(667, 362);
            dgvAtores.TabIndex = 2;
            dgvAtores.CellClick += dgvAtores_CellClick;
            // 
            // btAdicionar
            // 
            btAdicionar.Location = new Point(12, 419);
            btAdicionar.Name = "btAdicionar";
            btAdicionar.Size = new Size(126, 23);
            btAdicionar.TabIndex = 3;
            btAdicionar.Text = "Adicionar Ator";
            btAdicionar.UseVisualStyleBackColor = true;
            btAdicionar.Click += btAdicionar_Click;
            // 
            // btEditar
            // 
            btEditar.Enabled = false;
            btEditar.Location = new Point(510, 419);
            btEditar.Name = "btEditar";
            btEditar.Size = new Size(75, 23);
            btEditar.TabIndex = 4;
            btEditar.Text = "Editar Ator";
            btEditar.UseVisualStyleBackColor = true;
            btEditar.Click += btEditar_Click;
            // 
            // btRemover
            // 
            btRemover.Enabled = false;
            btRemover.Location = new Point(591, 419);
            btRemover.Name = "btRemover";
            btRemover.Size = new Size(88, 23);
            btRemover.TabIndex = 5;
            btRemover.Text = "Excluir Ator";
            btRemover.UseVisualStyleBackColor = true;
            btRemover.Click += btRemover_Click;
            // 
            // frmAtores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(691, 450);
            Controls.Add(btRemover);
            Controls.Add(btEditar);
            Controls.Add(btAdicionar);
            Controls.Add(dgvAtores);
            Controls.Add(btBuscar);
            Controls.Add(txtBusca);
            MaximizeBox = false;
            Name = "frmAtores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Atores";
            FormClosing += frmAtores_FormClosing;
            Load += frmAtores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAtores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBusca;
        private Button btBuscar;
        private DataGridView dgvAtores;
        private Button btAdicionar;
        private Button btEditar;
        private Button btRemover;
    }
}