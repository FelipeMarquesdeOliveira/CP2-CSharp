namespace CP2_CSharp.UI;

/// <summary>
/// Designer da tela principal - RM556319 Felipe Marques de Oliveira | RM556309 Gabriel Barros Cisoto
/// </summary>
public partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private DataGridView dgvProdutos = null!;
    private TextBox txtId = null!;
    private TextBox txtNome = null!;
    private TextBox txtPreco = null!;
    private TextBox txtQuantidade = null!;
    private TextBox txtBusca = null!;
    private Button btnSalvar = null!;
    private Button btnAtualizar = null!;
    private Button btnExcluir = null!;
    private Button btnEntrada = null!;
    private Button btnSaida = null!;
    private Button btnBuscar = null!;
    private Button btnListarTodos = null!;
    private Button btnLimpar = null!;
    private Label lblTitulo = null!;
    private Label lblId = null!;
    private Label lblNome = null!;
    private Label lblPreco = null!;
    private Label lblQuantidade = null!;
    private Label lblBusca = null!;
    private Label lblIntegrantes = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.dgvProdutos = new DataGridView();
        this.txtId = new TextBox();
        this.txtNome = new TextBox();
        this.txtPreco = new TextBox();
        this.txtQuantidade = new TextBox();
        this.txtBusca = new TextBox();
        this.btnSalvar = new Button();
        this.btnAtualizar = new Button();
        this.btnExcluir = new Button();
        this.btnEntrada = new Button();
        this.btnSaida = new Button();
        this.btnBuscar = new Button();
        this.btnListarTodos = new Button();
        this.btnLimpar = new Button();
        this.lblTitulo = new Label();
        this.lblId = new Label();
        this.lblNome = new Label();
        this.lblPreco = new Label();
        this.lblQuantidade = new Label();
        this.lblBusca = new Label();
        this.lblIntegrantes = new Label();

        ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
        this.SuspendLayout();

        // lblTitulo
        this.lblTitulo.AutoSize = true;
        this.lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        this.lblTitulo.ForeColor = Color.FromArgb(0, 120, 215);
        this.lblTitulo.Location = new Point(20, 20);
        this.lblTitulo.Name = "lblTitulo";
        this.lblTitulo.Size = new Size(320, 32);
        this.lblTitulo.Text = "Sistema de Estoque";

        // lblIntegrantes
        this.lblIntegrantes.AutoSize = true;
        this.lblIntegrantes.Font = new Font("Segoe UI", 9F);
        this.lblIntegrantes.ForeColor = Color.Gray;
        this.lblIntegrantes.Location = new Point(20, 58);
        this.lblIntegrantes.Name = "lblIntegrantes";
        this.lblIntegrantes.Size = new Size(400, 15);
        this.lblIntegrantes.Text = "RM556319 Felipe Marques de Oliveira | RM556309 Gabriel Barros Cisoto";

        // lblId
        this.lblId.AutoSize = true;
        this.lblId.Location = new Point(20, 100);
        this.lblId.Name = "lblId";
        this.lblId.Size = new Size(21, 15);
        this.lblId.Text = "ID:";

        // txtId
        this.txtId.Location = new Point(90, 97);
        this.txtId.Name = "txtId";
        this.txtId.ReadOnly = true;
        this.txtId.Size = new Size(80, 23);

        // lblNome
        this.lblNome.AutoSize = true;
        this.lblNome.Location = new Point(20, 130);
        this.lblNome.Name = "lblNome";
        this.lblNome.Size = new Size(45, 15);
        this.lblNome.Text = "Nome:*";

        // txtNome
        this.txtNome.Location = new Point(90, 127);
        this.txtNome.Name = "txtNome";
        this.txtNome.Size = new Size(250, 23);

        // lblPreco
        this.lblPreco.AutoSize = true;
        this.lblPreco.Location = new Point(360, 130);
        this.lblPreco.Name = "lblPreco";
        this.lblPreco.Size = new Size(44, 15);
        this.lblPreco.Text = "Preço:*";

        // txtPreco
        this.txtPreco.Location = new Point(410, 127);
        this.txtPreco.Name = "txtPreco";
        this.txtPreco.Size = new Size(100, 23);

        // lblQuantidade
        this.lblQuantidade.AutoSize = true;
        this.lblQuantidade.Location = new Point(530, 130);
        this.lblQuantidade.Name = "lblQuantidade";
        this.lblQuantidade.Size = new Size(74, 15);
        this.lblQuantidade.Text = "Quantidade:*";

        // txtQuantidade
        this.txtQuantidade.Location = new Point(610, 127);
        this.txtQuantidade.Name = "txtQuantidade";
        this.txtQuantidade.Size = new Size(80, 23);

        // btnSalvar
        this.btnSalvar.BackColor = Color.FromArgb(0, 120, 215);
        this.btnSalvar.FlatStyle = FlatStyle.Flat;
        this.btnSalvar.ForeColor = Color.White;
        this.btnSalvar.Location = new Point(20, 165);
        this.btnSalvar.Name = "btnSalvar";
        this.btnSalvar.Size = new Size(110, 35);
        this.btnSalvar.Text = "Cadastrar";
        this.btnSalvar.UseVisualStyleBackColor = false;
        this.btnSalvar.Click += new EventHandler(this.btnSalvar_Click);

        // btnAtualizar
        this.btnAtualizar.BackColor = Color.FromArgb(0, 150, 136);
        this.btnAtualizar.FlatStyle = FlatStyle.Flat;
        this.btnAtualizar.ForeColor = Color.White;
        this.btnAtualizar.Location = new Point(140, 165);
        this.btnAtualizar.Name = "btnAtualizar";
        this.btnAtualizar.Size = new Size(110, 35);
        this.btnAtualizar.Text = "Atualizar";
        this.btnAtualizar.UseVisualStyleBackColor = false;
        this.btnAtualizar.Click += new EventHandler(this.btnAtualizar_Click);

        // btnExcluir
        this.btnExcluir.BackColor = Color.FromArgb(220, 53, 69);
        this.btnExcluir.FlatStyle = FlatStyle.Flat;
        this.btnExcluir.ForeColor = Color.White;
        this.btnExcluir.Location = new Point(260, 165);
        this.btnExcluir.Name = "btnExcluir";
        this.btnExcluir.Size = new Size(110, 35);
        this.btnExcluir.Text = "Excluir";
        this.btnExcluir.UseVisualStyleBackColor = false;
        this.btnExcluir.Click += new EventHandler(this.btnExcluir_Click);

        // btnEntrada
        this.btnEntrada.BackColor = Color.FromArgb(40, 167, 69);
        this.btnEntrada.FlatStyle = FlatStyle.Flat;
        this.btnEntrada.ForeColor = Color.White;
        this.btnEntrada.Location = new Point(380, 165);
        this.btnEntrada.Name = "btnEntrada";
        this.btnEntrada.Size = new Size(110, 35);
        this.btnEntrada.Text = "Entrada (+)";
        this.btnEntrada.UseVisualStyleBackColor = false;
        this.btnEntrada.Click += new EventHandler(this.btnEntrada_Click);

        // btnSaida
        this.btnSaida.BackColor = Color.FromArgb(255, 152, 0);
        this.btnSaida.FlatStyle = FlatStyle.Flat;
        this.btnSaida.ForeColor = Color.White;
        this.btnSaida.Location = new Point(500, 165);
        this.btnSaida.Name = "btnSaida";
        this.btnSaida.Size = new Size(110, 35);
        this.btnSaida.Text = "Saída (-)";
        this.btnSaida.UseVisualStyleBackColor = false;
        this.btnSaida.Click += new EventHandler(this.btnSaida_Click);

        // btnLimpar
        this.btnLimpar.BackColor = Color.Gray;
        this.btnLimpar.FlatStyle = FlatStyle.Flat;
        this.btnLimpar.ForeColor = Color.White;
        this.btnLimpar.Location = new Point(620, 165);
        this.btnLimpar.Name = "btnLimpar";
        this.btnLimpar.Size = new Size(70, 35);
        this.btnLimpar.Text = "Limpar";
        this.btnLimpar.UseVisualStyleBackColor = false;
        this.btnLimpar.Click += new EventHandler(this.btnLimpar_Click);

        // lblBusca
        this.lblBusca.AutoSize = true;
        this.lblBusca.Location = new Point(20, 220);
        this.lblBusca.Name = "lblBusca";
        this.lblBusca.Size = new Size(93, 15);
        this.lblBusca.Text = "Buscar por nome:";

        // txtBusca
        this.txtBusca.Location = new Point(120, 217);
        this.txtBusca.Name = "txtBusca";
        this.txtBusca.Size = new Size(250, 23);

        // btnBuscar
        this.btnBuscar.BackColor = Color.FromArgb(0, 120, 215);
        this.btnBuscar.FlatStyle = FlatStyle.Flat;
        this.btnBuscar.ForeColor = Color.White;
        this.btnBuscar.Location = new Point(380, 215);
        this.btnBuscar.Name = "btnBuscar";
        this.btnBuscar.Size = new Size(80, 28);
        this.btnBuscar.Text = "Buscar";
        this.btnBuscar.UseVisualStyleBackColor = false;
        this.btnBuscar.Click += new EventHandler(this.btnBuscar_Click);

        // btnListarTodos
        this.btnListarTodos.BackColor = Color.Gray;
        this.btnListarTodos.FlatStyle = FlatStyle.Flat;
        this.btnListarTodos.ForeColor = Color.White;
        this.btnListarTodos.Location = new Point(470, 215);
        this.btnListarTodos.Name = "btnListarTodos";
        this.btnListarTodos.Size = new Size(110, 28);
        this.btnListarTodos.Text = "Listar Todos";
        this.btnListarTodos.UseVisualStyleBackColor = false;
        this.btnListarTodos.Click += new EventHandler(this.btnListarTodos_Click);

        // dgvProdutos
        this.dgvProdutos.AllowUserToAddRows = false;
        this.dgvProdutos.AllowUserToDeleteRows = false;
        this.dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvProdutos.BackgroundColor = Color.White;
        this.dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvProdutos.Location = new Point(20, 255);
        this.dgvProdutos.Name = "dgvProdutos";
        this.dgvProdutos.ReadOnly = true;
        this.dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        this.dgvProdutos.Size = new Size(670, 280);
        this.dgvProdutos.TabIndex = 0;
        this.dgvProdutos.CellClick += new DataGridViewCellEventHandler(this.dgvProdutos_CellClick);

        // MainForm
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.BackColor = Color.White;
        this.ClientSize = new Size(710, 560);
        this.Controls.Add(this.dgvProdutos);
        this.Controls.Add(this.btnListarTodos);
        this.Controls.Add(this.btnBuscar);
        this.Controls.Add(this.txtBusca);
        this.Controls.Add(this.lblBusca);
        this.Controls.Add(this.btnLimpar);
        this.Controls.Add(this.btnSaida);
        this.Controls.Add(this.btnEntrada);
        this.Controls.Add(this.btnExcluir);
        this.Controls.Add(this.btnAtualizar);
        this.Controls.Add(this.btnSalvar);
        this.Controls.Add(this.txtQuantidade);
        this.Controls.Add(this.txtPreco);
        this.Controls.Add(this.txtNome);
        this.Controls.Add(this.txtId);
        this.Controls.Add(this.lblQuantidade);
        this.Controls.Add(this.lblPreco);
        this.Controls.Add(this.lblNome);
        this.Controls.Add(this.lblId);
        this.Controls.Add(this.lblIntegrantes);
        this.Controls.Add(this.lblTitulo);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "MainForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Sistema de Estoque - CP2 C#";
        this.Load += new EventHandler(this.MainForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
