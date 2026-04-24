# Sistema de Estoque - Checkpoint 2 C#

## Identificação do Grupo

| Integrante | RM | Turma |
|------------|-----|-------|
| Felipe Marques de Oliveira | 556319 | 3ESPH |
| Gabriel Barros Cisoto | 556309 | 3ESPH |

**Disciplina:** C# Software Development
**Professor:** Angel Antonio Gonzalez Martinez
**Instituição:** FIAP - 2º Semestre de 2026

---

## Como Executar a Aplicação

### Pré-requisitos
- .NET SDK 8.0 ou superior
- SQL Server (Local ou Express)
- Visual Studio 2022 ou VS Code

### Passos para execução

1. **Executar o script do banco de dados:**
   ```sql
   -- Abra o SQL Server Management Studio
   -- Execute o arquivo: scripts/01_CreateDatabase.sql
   -- Isso criará o banco: DB_Felipe_RM556319
   ```

2. **Abrir a solução no Visual Studio:**
   ```
   - Abra o arquivo CP2_CSharp.sln
   - Configure o projeto CP2_CSharp.UI como projeto de inicialização
   - Restaure os pacotes NuGet se necessário
   ```

3. **Compilar e executar:**
   ```
   - Pressione F5 ou clique em "Iniciar"
   - A aplicação Windows Forms será aberta
   ```

4. **Connection String:**
   ```
   Server=localhost;Database=DB_Felipe_RM556319;Trusted_Connection=True;TrustServerCertificate=True;
   ```

---

## Funcionalidades Implementadas

### Obrigatórias ✅
- [x] **Cadastro de produtos** - Nome, preço e quantidade inicial
- [x] **Listagem de produtos** - Grid com todos os produtos ativos
- [x] **Busca por nome** - Filtro em tempo real
- [x] **Entrada de estoque** - Aumentar quantidade
- [x] **Saída de estoque** - Diminuir quantidade
- [x] **Impedimento de estoque negativo** - Validação implementada
- [x] **Atualização de produtos** - Editar dados existentes
- [x] **Exclusão lógica** - Soft delete (ativo = false)

### Validações ✅
- [x] Campos obrigatórios (nome)
- [x] Preço maior que zero
- [x] Quantidade não negativa
- [x] Validação de formato numérico
- [x] Mensagens de erro claras
- [x] Mensagens de sucesso

### Diferenciais Implementados ✅
- [x] Interface moderna com cores personalizadas
- [x] Auto-recarregamento do grid após operações
- [x] Identificação visual dos botões por cor
- [x] Nomes e RMs nos comentários do código
- [x] Arquitetura em camadas bem definida

---

## Arquitetura da Solução

```
CP2_CSharp/
├── CP2_CSharp.sln
├── scripts/
│   └── 01_CreateDatabase.sql
└── src/
    ├── CP2_CSharp.Config/         # Configurações (ConnectionFactory)
    ├── CP2_CSharp.Contracts/      # Interfaces (IProdutoRepository, IProdutoService)
    ├── CP2_CSharp.DAL/            # Acesso a dados (ADO.NET)
    ├── CP2_CSharp.BLL/            # Lógica de negócio (validações)
    ├── CP2_CSharp.Model/           # Entidades (Produto)
    └── CP2_CSharp.UI/             # Interface Windows Forms
```

### Camadas
1. **UI (Presentation)** - Windows Forms, interação com usuário
2. **BLL (Business)** - Validações e regras de negócio
3. **DAL (Data Access)** - Comunicação com banco via ADO.NET
4. **Model** - Entidades e objetos de domínio
5. **Contracts** - Interfaces para inversão de controle
6. **Config** - Configurações centralizadas

---

## Banco de Dados

- **Nome:** DB_Felipe_RM556319
- **Tabela:** Produto
- **Campos:** Id, Nome, Preco, Quantidade, Ativo, DataCadastro
- **Conexão:** Trusted Connection (autenticação Windows)

---

## Observações Adicionais

1. O projeto foi desenvolvido como evolução do miniCRUD trabalhado em laboratório
2. Utiliza ADO.NET puro com SqlClient para acesso aos dados
3. A separação em camadas permite fácil manutenção e evolução
4. O soft delete (campo Ativo) preserva o histórico de produtos

---

## Critérios de Avaliação Atendidos

| Critério | Pontos | Status |
|----------|--------|--------|
| Organização da solução e arquitetura | 2,0 | ✅ |
| Funcionalidades obrigatórias | 2,0 | ✅ |
| POO, interfaces e modularização | 1,5 | ✅ |
| Integração com banco e ADO.NET | 1,5 | ✅ |
| Validações e tratamento de erros | 1,5 | ✅ |
| Relatório, README e evidências | 1,0 | ✅ |
| Criatividade e refinamento | 0,5 | ✅ |

---

**Bom checkpoint!**
