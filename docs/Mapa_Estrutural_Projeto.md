# Mapa Estrutural do Projeto

# Domain - Entities

## Classe: Categoria

### Propriedades
- string Nome
- bool Ativo

### Construtores
- Categoria()
- Categoria(string nome)

### Métodos
- void ValidarNome()
- void AlterarNome()
- void Desativar()
- void Ativar()

---
## Classe: Compra

### Propriedades
- Guid IdUsuario
- Guid IdMercado
- DateTime DataCompra
- DateTime DataCriacao
- DateTime? DataFinalizacao
- bool Finalizada
- bool AtivaParaRelatorio
- Dinheiro ValorTotal
- IReadOnlyCollection<ItemCompra> Itens

### Construtores
- Compra()
- Compra(Guid idUsuario, Guid idMercado, DateTime dataCompra)

### Métodos
- void AdicionarItem()
- void RemoverItem()
- void RemoverDosRelatorios()
- void Finalizar()
- Dinheiro CalcularValorTotal()

---
## Classe: ConviteGrupo

### Propriedades
- Guid IdGrupo
- string Codigo
- Guid IdCriadoPorUsuario
- DateTime DataCriacao
- DateTime DataExpiracao
- bool Ativo

### Construtores
- ConviteGrupo()
- ConviteGrupo(Guid idGrupo, Guid idCriadoPorUsuario, int diasValidade)

### Métodos
- bool EstaExpirado()
- bool EstaValido()
- void Desativar()
- void Reativar()
- string GerarCodigoConvite()

---
## Classe: Entidade

### Propriedades
- Guid Id

### Construtores
- Entidade()
- Entidade(Guid id)

---
## Classe: Grupo

### Propriedades
- string Nome
- Guid IdCriadoPorUsuario
- DateTime DataCriacao
- bool Ativo
- IReadOnlyCollection<GrupoUsuario> Membros

### Construtores
- Grupo()
- Grupo(string nome, Guid idCriadoPorUsuario)

### Métodos
- void ValidarNome()
- void AlterarNome()
- void AdicionarMembro()
- void RemoverMembro()
- bool UsuarioPertenceAoGrupo()
- bool UsuarioIsAdministrador()
- void Desativar()

---
## Classe: GrupoUsuario

### Propriedades
- Guid IdGrupo
- Guid IdUsuario
- PapelGrupo Papel
- DateTime DataEntrada

### Construtores
- GrupoUsuario()
- GrupoUsuario(Guid idGrupo, Guid idUsuario, PapelGrupo papel)

### Métodos
- void TornarAdministrador()
- void TornarMembro()

---
## Classe: ItemCompra

### Propriedades
- Guid IdCompra
- Guid IdProduto
- string NomeProdutoSnapshot
- decimal Quantidade
- Dinheiro PrecoUnitario
- UnidadeMedida Unidade

### Construtores
- ItemCompra()
- ItemCompra(Guid idCompra, Guid idProduto, string nomeProduto, decimal quantidade, Dinheiro precoUnitario, UnidadeMedida unidade)

### Métodos
- void ValidarQuantidade()
- void AdicionarQuantidade()
- Dinheiro CalcularSubTotal()

---
## Classe: ItemLista

### Propriedades
- Guid IdListaDeCompras
- Guid IdProduto
- decimal QuantidadePlanejada
- UnidadeMedida Unidade
- bool Ativo

### Construtores
- ItemLista()
- ItemLista(Guid idListaDeCompras, Guid idProduto, decimal quantidadePlanejada, UnidadeMedida unidade)

### Métodos
- void ValidarQuantidadePlanejada()
- void AlterarQuantidadePlanejada()
- void AlterarUnidade()
- void Remover()

---
## Classe: ItemListaPadrao

### Propriedades
- Guid IdListaDeComprasPadrao
- Guid IdProduto
- decimal QuantidadePlanejada
- UnidadeMedida Unidade

### Construtores
- ItemListaPadrao()
- ItemListaPadrao(Guid idListaDeComprasPadrao, Guid idProduto, decimal quantidadePlanejada, UnidadeMedida unidade)

### Métodos
- void ValidarQuantidade()
- void AlterarQuantidadePlanejada()
- void AlterarUnidade()

---
## Classe: ListaDeCompras

### Propriedades
- string Nome
- Guid? IdUsuario
- Guid? IdGrupo
- DateTime DataCriacao
- StatusLista Status
- IReadOnlyCollection<ItemLista> Itens

### Construtores
- ListaDeCompras()
- ListaDeCompras(string nome, Guid idUsuario)
- ListaDeCompras(string nome, Guid idGrupo, bool isListaGrupo)

### Métodos
- void ValidarNome()
- void AlterarNome()
- void AdicionarItem()
- void RemoverItem()
- void ValidarProprietario()
- void Finalizar()
- void Reabrir()

---
## Classe: ListaDeComprasPadrao

### Propriedades
- Guid IdUsuario
- string Nome
- bool Ativo
- IReadOnlyCollection<ItemListaPadrao> Itens

### Construtores
- ListaDeComprasPadrao()
- ListaDeComprasPadrao(Guid idUsuario, string nome)

### Métodos
- void ValidarNome()
- void AlterarNome()
- void AdicionarItem()
- void RemoverItem()
- void Desativar()

---
## Classe: Marca

### Propriedades
- string Nome
- bool Ativo

### Construtores
- Marca()
- Marca(string nome)

### Métodos
- void ValidarNome()
- void AlterarNome()
- void Desativar()

---
## Classe: Mercado

### Propriedades
- string Nome
- bool Ativo

### Construtores
- Mercado()
- Mercado(string nome)

### Métodos
- void ValidarNome()
- void AlterarNome()
- void Desativar()

---
## Classe: Orcamento

### Propriedades
- Guid IdUsuario
- int Ano
- int Mes
- Dinheiro ValorPlanejado

### Construtores
- Orcamento()
- Orcamento(Guid idUsuario, int ano, int mes, Dinheiro valorPlanejado)

### Métodos
- void AlterarValor()

---
## Classe: Produto

### Propriedades
- string Nome
- Guid IdCategoria
- Guid? IdMarca
- UnidadeMedida UnidadeBase
- Guid? IdCriadoPorUsuario
- TipoProduto Tipo
- bool Ativo

### Construtores
- Produto()
- Produto(string nome, Guid idCategoria, UnidadeMedida unidadeBase, TipoProduto tipo, Guid? idMarca, Guid? idCriadoPorUsuario)

### Métodos
- void ValidarNome()
- void ValidarCategoria()
- void ValidarUnidadeBase()
- void AlterarMarca()
- void AlterarNome()
- void AlterarCategoria()
- void DesativarProduto()
- bool IsGlobal()
- bool IsPersonalizado()

---
## Classe: RegistroDePreco

### Propriedades
- Guid IdProduto
- Guid IdMercado
- Guid IdUsuario
- Dinheiro Preco
- decimal QuantidadeReferencia
- UnidadeMedida UnidadeReferencia
- DateTime DataRegistro

### Construtores
- RegistroDePreco()
- RegistroDePreco(Guid idProduto, Guid idMercado, Guid idUsuario, Dinheiro preco, decimal quantidadeReferencia, UnidadeMedida unidadeReferencia)

### Métodos
- void ValidarQuantidadeReferencia()
- void CorrigirPreco()

---
## Classe: Usuario

### Propriedades
- string Nome
- Email Email
- Senha Senha
- PlanoUsuario Plano
- DateTime DataCriacao
- bool Ativo
- TipoUsuario TipoUsuario

### Construtores
- Usuario()
- Usuario(string nome, Email email, Senha senha, TipoUsuario tipoUsuario)

### Métodos
- void ValidarNome()
- void AlterarNome()
- void AlterarEmail()
- void AlterarSenha()
- void DesativarConta()
- void ReativarConta()
- bool IsADM()
- void AlterarPlano()
- bool IsPremium()

---
# Domain - ValueObjects

## Classe: Dinheiro

### Propriedades
- decimal Valor
- Dinheiro Zero

### Construtores
- Dinheiro(decimal valor)

---
## Classe: Email

### Propriedades
- string Endereco

### Construtores
- Email()
- Email(string endereco)

### Métodos
- bool EmailValido()
- string ToString()

---
## Classe: Senha

### Propriedades
- string Hash

### Construtores
- Senha()
- Senha(string senhaTexto)

### Métodos
- bool SenhaForte()
- string GerarHash()
- bool VerificarSenha()

---
## Classe: UnidadeMedida

### Propriedades
- string Nome
- string Simbolo
- TipoUnidade Tipo
- decimal FatorBase

### Construtores
- UnidadeMedida(string nome, string simbolo, TipoUnidade tipo, decimal fatorBase)

### Métodos
- decimal Converter()

---
# Domain - Services

## Classe: CalculadoraOrcamentoAutomatico

### Métodos
- Dinheiro CalcularMediaMensal()

---
## Classe: EstatisticasCompraService

### Métodos
- Dictionary<Guid, Dinheiro> GastosPorCategoria()

---
# Application - DTOs

## Classe: CriarConviteGrupoDto

### Propriedades
- Guid IdGrupo
- Guid IdUsuarioCriador
- int DiasValidade

---
## Classe: EntrarGrupoPorCodigoDto

### Propriedades
- string Codigo
- Guid IdUsuario

---
## Classe: CriarGrupoDto

### Propriedades
- string Nome
- Guid IdUsuarioCriador

---
## Classe: RemoverMembroGrupoDto

### Propriedades
- Guid IdGrupo
- Guid IdUsuarioSolicitante
- Guid IdUsuarioRemover

---
## Classe: AtualizarMarcaDto

### Propriedades
- Guid Id
- string Nome

---
## Classe: CriarMarcaDto

### Propriedades
- string Nome

---
## Classe: MarcaDto

### Propriedades
- Guid Id
- string Nome
- bool Ativo

---
## Classe: AtualizarMercadoDto

### Propriedades
- Guid Id
- string Nome

---
## Classe: CriarMercadoDto

### Propriedades
- string Nome

---
## Classe: MercadoDto

### Propriedades
- Guid Id
- string Nome
- bool Ativo

---
## Classe: AtualizarProdutoDto

### Propriedades
- Guid Id
- string Nome
- Guid IdCategoria
- Guid? IdMarca

---
## Classe: CriarProdutoDto

### Propriedades
- string Nome
- Guid IdCategoria
- Guid? IdMarca
- string UnidadeBase

---
## Classe: ProdutoDto

### Propriedades
- Guid Id
- string Nome
- Guid IdCategoria
- Guid? IdMarca
- string UnidadeBase
- bool Ativo

---
## Classe: AlterarPerfilDto

### Propriedades
- Guid Id
- string NovoNome
- string NovoEmail

---
## Classe: CriarUsuarioDto

### Propriedades
- string Nome
- string Email
- string Senha

---
## Classe: LoginUsuarioDto

### Propriedades
- string Email
- string Senha

---
# Application - UseCases

## Classe: CriarConviteGrupoUseCase

### Construtores
- CriarConviteGrupoUseCase(IGrupoRepositorio grupoRepositorio, IConviteGrupoRepositorio conviteGrupoRepositorio)

### Métodos
- Task<string> ExecutarAsync()

---
## Classe: EntrarGrupoPorCodigoUseCase

### Construtores
- EntrarGrupoPorCodigoUseCase(IConviteGrupoRepositorio conviteGrupoRepositorio, IGrupoRepositorio grupoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: CriarGrupoUseCase

### Construtores
- CriarGrupoUseCase(IGrupoRepositorio grupoRepositorio)

### Métodos
- Task<Guid> ExecutarAsync()

---
## Classe: RemoverMembroGrupoUseCase

### Construtores
- RemoverMembroGrupoUseCase(IGrupoRepositorio grupoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AtualizarMarcaUseCase

### Construtores
- AtualizarMarcaUseCase(IMarcaRepositorio marcaRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: CriarMarcaUseCase

### Construtores
- CriarMarcaUseCase(IMarcaRepositorio marcaRepositorio)

### Métodos
- Task<Guid> ExecutarAsync()

---
## Classe: DesativarMarcaUseCase

### Construtores
- DesativarMarcaUseCase(IMarcaRepositorio marcaRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: ListarMarcasUseCase

### Construtores
- ListarMarcasUseCase(IMarcaRepositorio marcaRepositorio)

### Métodos
- Task<IEnumerable<MarcaDto>> ExecutarAsync()

---
## Classe: AtualizarMercadoUseCase

### Construtores
- AtualizarMercadoUseCase(IMercadoRepositorio mercadoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: CriarMercadoUseCase

### Construtores
- CriarMercadoUseCase(IMercadoRepositorio mercadoRepositorio)

### Métodos
- Task<Guid> ExecutarAsync()

---
## Classe: DesativarMercadoUseCase

### Construtores
- DesativarMercadoUseCase(IMercadoRepositorio mercadoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: ListarMercadosUseCase

### Construtores
- ListarMercadosUseCase(IMercadoRepositorio mercadoRepositorio)

### Métodos
- Task<IEnumerable<MercadoDto>> ExecutarAsync()

---
## Classe: AtualizarProdutoUseCase

### Construtores
- AtualizarProdutoUseCase(IProdutoRepositorio produtoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: CriarProdutoUseCase

### Construtores
- CriarProdutoUseCase(IProdutoRepositorio produtoRepositorio)

### Métodos
- Task<Guid> ExecutarAsync()
- UnidadeMedida ObterUnidade()

---
## Classe: DesativarProdutoUseCase

### Construtores
- DesativarProdutoUseCase(IProdutoRepositorio produtoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: ListarProdutosUseCase

### Construtores
- ListarProdutosUseCase(IProdutoRepositorio produtoRepositorio)

### Métodos
- Task<IEnumerable<ProdutoDto>> ExecutarAsync()

---
## Classe: AlterarPerfilUseCase

### Construtores
- AlterarPerfilUseCase(IUsuarioRepositorio usuarioRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: CriarUsuarioUseCase

### Construtores
- CriarUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)

### Métodos
- Task<Guid> ExecutarAsync()

---
## Classe: DesativarContaUseCase

### Construtores
- DesativarContaUseCase(IUsuarioRepositorio usuarioRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: LoginUsuarioUseCase

### Construtores
- LoginUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)

### Métodos
- Task<bool> ExecutarAsync()

---
# Infrastructure - Repositories

## Classe: ConviteGrupoRepositorio

### Construtores
- ConviteGrupoRepositorio(AppDbContext context)

### Métodos
- Task<ConviteGrupo?> ObterPorCodigoAsync()

---
## Classe: GrupoRepositorio

### Construtores
- GrupoRepositorio(AppDbContext context)

### Métodos
- Task<Grupo?> ObterPorIdAsync()
- Task<IEnumerable<Grupo>> ObterPorUsuarioAsync()

---
## Classe: MarcaRepositorio

### Construtores
- MarcaRepositorio(AppDbContext context)

### Métodos
- Task<IEnumerable<Marca>> ListarAtivosAsync()
- Task<IEnumerable<Marca>> BuscarPorNomeAsync()

---
## Classe: MercadoRepositorio

### Construtores
- MercadoRepositorio(AppDbContext context)

### Métodos
- Task<IEnumerable<Mercado>> ListarAtivosAsync()
- Task<IEnumerable<Mercado>> BuscarPorNomeAsync()

---
## Classe: ProdutoRepositorio

### Construtores
- ProdutoRepositorio(AppDbContext context)

### Métodos
- Task<IEnumerable<Produto>> ObterPorCategoriaAsync()
- Task<IEnumerable<Produto>> ListarAtivosAsync()
- Task<IEnumerable<Produto>> BuscarPorNomeAsync()

---
## Classe: RepositorioBase

### Construtores
- RepositorioBase(AppDbContext context)

### Métodos
- Task<T?> ObterPorIdAsync()
- Task<IEnumerable<T>> ObterTodosAsync()
- Task AdicionarAsync()
- Task AtualizarAsync()
- Task RemoverAsync()

---
## Classe: UsuarioRepositorio

### Construtores
- UsuarioRepositorio(AppDbContext context)

### Métodos
- Task<Usuario?> ObterPorEmailAsync()

---
# API - Controllers

## Classe: ConviteGrupoController

### Construtores
- ConviteGrupoController(CriarConviteGrupoUseCase criarConvite, EntrarGrupoPorCodigoUseCase entrarGrupo)

### Métodos
- Task<IActionResult> Criar()
- Task<IActionResult> Entrar()

---
## Classe: GrupoController

### Construtores
- GrupoController(CriarGrupoUseCase criarGrupoUseCase, RemoverMembroGrupoUseCase removerMembroGrupoUseCase)

### Métodos
- Task<IActionResult> Criar()
- Task<IActionResult> RemoverMembro()

---
## Classe: MarcaController

### Métodos
- Task<IActionResult> Criar()
- Task<IActionResult> Listar()
- Task<IActionResult> Dexativar()

---
## Classe: MercadoController

### Métodos
- Task<IActionResult> Criar()
- Task<IActionResult> Listar()
- Task<IActionResult> Atualizar()
- Task<IActionResult> Desativar()

---
## Classe: ProdutoController

### Construtores
- ProdutoController(CriarProdutoUseCase criarProduto, AtualizarProdutoUseCase atualizarProduto, DesativarProdutoUseCase desativarProduto, ListarProdutosUseCase listarProdutos)

### Métodos
- Task<IActionResult> Criar()
- Task<IActionResult> Atualizar()
- Task<IActionResult> Desativar()
- Task<IActionResult> ObterTodos()

---
## Classe: UsuarioController

### Construtores
- UsuarioController(CriarUsuarioUseCase criarUsuario, LoginUsuarioUseCase loginUsuario, AlterarPerfilUseCase alterarPerfil, DesativarContaUseCase desativarConta)

### Métodos
- Task<IActionResult> CriarUsuario()
- Task<IActionResult> Login()
- Task<IActionResult> AlterarPerfil()
- Task<IActionResult> DesativarConta()

---
# Interfaces

- ICompraRepositorio
- IConviteGrupoRepositorio
- IGrupoRepositorio
- IListaDeComprasPadraoRepositorio
- IListaDeComprasRepositorio
- IMarcaRepositorio
- IMercadoRepositorio
- IOrcamentoRepositorio
- IProdutoRepositorio
- IRegistroDePrecoRepositorio
- IRepositorioBase
- IUsuarioRepositorio

# Enums

## PapelGrupo
- Membro
- Administrador

## PlanoUsuario
- Gratuito
- Premium

## StatusLista
- Aberta
- Finalizada

## TipoProduto
- Global
- Personalizado

## TipoUnidade
- Massa
- Volume
- Contagem

## TipoUsuario
- Usuario
- Administrador

