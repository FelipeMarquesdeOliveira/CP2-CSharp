using CP2_CSharp.BLL;
using CP2_CSharp.Contracts;
using CP2_CSharp.DAL;
using CP2_CSharp.Model;

namespace CP2_CSharp.UI;

/// <summary>
/// Tela principal do sistema de estoque
/// RM556319 Felipe Marques de Oliveira | RM556309 Gabriel Barros Cisoto
/// </summary>
public partial class MainForm : Form
{
    private readonly IProdutoService _produtoService;

    public MainForm()
    {
        InitializeComponent();
        _produtoService = new ProdutoService(new ProdutoRepository());
        CarregarProdutos();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        ConfigurarGrid();
        lblQuantidade.BackColor = Color.Transparent;
        lblPreco.BackColor = Color.Transparent;
        lblNome.BackColor = Color.Transparent;
    }

    private void ConfigurarGrid()
    {
        dgvProdutos.ReadOnly = true;
        dgvProdutos.AllowUserToAddRows = false;
        dgvProdutos.AllowUserToDeleteRows = false;
        dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProdutos.MultiSelect = false;
        dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProdutos.RowHeadersVisible = false;
        dgvProdutos.ColumnHeadersVisible = true;
        dgvProdutos.BackgroundColor = Color.White;
    }

    private void btnSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            var produto = LerProdutoDoFormulario();

            if (produto == null) return;

            _produtoService.Cadastrar(produto);

            MessageBox.Show(
                "Produto cadastrado com sucesso!",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimparCampos();
            CarregarProdutos();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Validação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Erro ao cadastrar: " + ex.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnAtualizar_Click(object sender, EventArgs e)
    {
        try
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show(
                    "Selecione um produto na grade para atualizar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var produto = LerProdutoDoFormulario();
            if (produto == null) return;

            produto.Id = id;

            _produtoService.Atualizar(produto);

            MessageBox.Show(
                "Produto atualizado com sucesso!",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimparCampos();
            CarregarProdutos();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Validação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Erro ao atualizar: " + ex.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnExcluir_Click(object sender, EventArgs e)
    {
        try
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show(
                    "Selecione um produto na grade para excluir.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                "Deseja realmente excluir este produto?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes) return;

            var produto = _produtoService.BuscarPorId(id);
            if (produto != null)
            {
                produto.Ativo = false;
                _produtoService.Atualizar(produto);
            }

            MessageBox.Show(
                "Produto excluído com sucesso!",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimparCampos();
            CarregarProdutos();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Erro ao excluir: " + ex.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnEntrada_Click(object sender, EventArgs e)
    {
        try
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show(
                    "Selecione um produto na grade para entrada de estoque.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantidade.Text, out int quantidade))
            {
                MessageBox.Show(
                    "Informe uma quantidade válida.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _produtoService.EntradaEstoque(id, quantidade);

            MessageBox.Show(
                "Entrada de estoque registrada com sucesso!",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimparCampos();
            CarregarProdutos();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Validação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Erro na entrada: " + ex.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnSaida_Click(object sender, EventArgs e)
    {
        try
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show(
                    "Selecione um produto na grade para saída de estoque.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantidade.Text, out int quantidade))
            {
                MessageBox.Show(
                    "Informe uma quantidade válida.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _produtoService.SaidaEstoque(id, quantidade);

            MessageBox.Show(
                "Saída de estoque registrada com sucesso!",
                "Sucesso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimparCampos();
            CarregarProdutos();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Estoque Insuficiente",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Validação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Erro na saída: " + ex.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string filtro = txtBusca.Text.Trim();

            if (string.IsNullOrWhiteSpace(filtro))
            {
                CarregarProdutos();
                return;
            }

            var produtos = _produtoService.BuscarPorNome(filtro);
            dgvProdutos.DataSource = null;
            dgvProdutos.DataSource = produtos;

            if (produtos.Count == 0)
            {
                MessageBox.Show(
                    "Nenhum produto encontrado.",
                    "Busca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(
                ex.Message,
                "Validação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Erro na busca: " + ex.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnListarTodos_Click(object sender, EventArgs e)
    {
        txtBusca.Clear();
        CarregarProdutos();
    }

    private void btnLimpar_Click(object sender, EventArgs e)
    {
        LimparCampos();
    }

    private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var row = dgvProdutos.Rows[e.RowIndex];

        txtId.Text = row.Cells["Id"].Value?.ToString() ?? "";
        txtNome.Text = row.Cells["Nome"].Value?.ToString() ?? "";
        txtPreco.Text = row.Cells["Preco"].Value?.ToString() ?? "";
        txtQuantidade.Text = row.Cells["Quantidade"].Value?.ToString() ?? "";
    }

    private void CarregarProdutos()
    {
        try
        {
            var produtos = _produtoService.ListarTodos();
            dgvProdutos.DataSource = null;
            dgvProdutos.DataSource = produtos;

            if (dgvProdutos.Columns.Count > 0)
            {
                dgvProdutos.Columns["Id"].HeaderText = "ID";
                dgvProdutos.Columns["Nome"].HeaderText = "Nome do Produto";
                dgvProdutos.Columns["Preco"].HeaderText = "Preço";
                dgvProdutos.Columns["Quantidade"].HeaderText = "Estoque";
                dgvProdutos.Columns["Ativo"].HeaderText = "Ativo";
                dgvProdutos.Columns["DataCadastro"].HeaderText = "Data Cadastro";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Erro ao carregar produtos: " + ex.Message,
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void LimparCampos()
    {
        txtId.Clear();
        txtNome.Clear();
        txtPreco.Clear();
        txtQuantidade.Clear();
        txtNome.Focus();
    }

    private Produto? LerProdutoDoFormulario()
    {
        string nome = txtNome.Text.Trim();
        string precoTexto = txtPreco.Text.Trim();
        string quantidadeTexto = txtQuantidade.Text.Trim();

        if (string.IsNullOrWhiteSpace(nome))
        {
            MessageBox.Show(
                "Informe o nome do produto.",
                "Validação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return null;
        }

        if (!ProdutoService.ValidarPreco(precoTexto, out decimal preco))
        {
            MessageBox.Show(
                "Informe um preço válido.",
                "Validação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return null;
        }

        if (preco <= 0)
        {
            MessageBox.Show(
                "O preço deve ser maior que zero.",
                "Validação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return null;
        }

        if (!ProdutoService.ValidarQuantidadeTexto(quantidadeTexto, out int quantidade))
        {
            MessageBox.Show(
                "Informe uma quantidade válida.",
                "Validação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return null;
        }

        if (quantidade < 0)
        {
            MessageBox.Show(
                "A quantidade não pode ser negativa.",
                "Validação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return null;
        }

        return new Produto
        {
            Nome = nome,
            Preco = preco,
            Quantidade = quantidade
        };
    }
}
