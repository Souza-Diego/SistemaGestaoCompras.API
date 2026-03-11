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
- void TornarAdministrador()
- void RemoverAdministrador()
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
- void AlterarQuantidade()
- void AlterarPreco()

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
- void AlterarQuantidade()
- void AlterarUnidade()

---
## Classe: ListaDeCompra

### Propriedades
- string Nome
- Guid? IdUsuario
- Guid? IdGrupo
- DateTime DataCriacao
- StatusLista Status
- IReadOnlyCollection<ItemLista> Itens

### Construtores
- ListaDeCompra()
- ListaDeCompra(string nome, Guid idUsuario)
- ListaDeCompra(string nome, Guid idGrupo, bool isListaGrupo)

### Métodos
- void ValidarNome()
- void AlterarNome()
- void AdicionarItem()
- void RemoverItem()
- void ValidarProprietario()
- void Finalizar()
- void Reabrir()

---
## Classe: ListaDeCompraPadrao

### Propriedades
- Guid IdUsuario
- string Nome
- bool Ativo
- IReadOnlyCollection<ItemListaPadrao> Itens

### Construtores
- ListaDeCompraPadrao()
- ListaDeCompraPadrao(Guid idUsuario, string nome)

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
- UnidadeMedida ObterPorSimbolo()
- string ToString()

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

## Classe: AlterarNomeCategoriaDto

### Propriedades
- Guid Id
- string Nome

---
## Classe: CategoriaDto

### Propriedades
- Guid Id
- string Nome
- bool Ativo

---
## Classe: CriarCategoriaDto

### Propriedades
- string Nome

---
## Classe: AdicionarItemCompraDto

### Propriedades
- Guid IdCompra
- Guid IdProduto
- string NomeProduto
- decimal Quantidade
- decimal PrecoUnitario
- UnidadeMedida Unidade

---
## Classe: AlterarPrecoItemCompraDto

### Propriedades
- Guid IdCompra
- Guid IdItem
- decimal PrecoUnitario

---
## Classe: AlterarQuantidadeItemCompraDto

### Propriedades
- Guid IdCompra
- Guid IdItem
- decimal Quantidade

---
## Classe: CriarCompraDto

### Propriedades
- Guid IdUsuario
- Guid IdMercado
- DateTime DataCompra

---
## Classe: ListarComprasPeriodoDto

### Propriedades
- Guid IdUsuario
- DateTime DataInicio
- DateTime DataFim

---
## Classe: RemoverItemCompraDto

### Propriedades
- Guid IdCompra
- Guid IdItem

---
## Classe: TotalGastoPeriodoDto

### Propriedades
- Guid IdUsuario
- DateTime Inicio
- DateTime Fim

---
## Classe: ConviteGrupoDto

### Propriedades
- Guid Id
- Guid GrupoId
- string Codigo
- Guid IdCriadoPorUsuario
- DateTime DataCriacao
- DateTime? DataExpiracao
- bool Ativo

---
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
## Classe: ValidarConviteGrupoDto

### Propriedades
- string Codigo

---
## Classe: AdicionarMembroGrupoDto

### Propriedades
- Guid GrupoId
- Guid UsuarioId
- Guid UsuarioConvidadoId

---
## Classe: AlterarNomeGrupoDto

### Propriedades
- Guid GrupoId
- Guid UsuarioId
- string NovoNome

---
## Classe: CriarGrupoDto

### Propriedades
- string Nome
- Guid IdUsuarioCriador

---
## Classe: DesativarGrupoDto

### Propriedades
- Guid IdGrupo
- Guid IdUsuarioSolicitante

---
## Classe: GrupoDto

### Propriedades
- Guid Id
- string Nome
- Guid CriadoPor
- DateTime DataCriacao
- bool Ativo

---
## Classe: RemoverAdministradorGrupoDto

### Propriedades
- Guid IdGrupo
- Guid IdUsuarioSolicitante
- Guid IdUsuario

---
## Classe: RemoverMembroGrupoDto

### Propriedades
- Guid IdGrupo
- Guid IdUsuarioSolicitante
- Guid IdUsuarioRemover

---
## Classe: SairDoGrupoDto

### Propriedades
- Guid IdGrupo
- Guid IdUsuario

---
## Classe: TornarUsuarioAdministradorGrupoDto

### Propriedades
- Guid IdGrupo
- Guid IdUsuarioSolicitante
- Guid IdUsuario

---
## Classe: AdicionarItemListaDto

### Propriedades
- Guid IdListaDeCompras
- Guid IdProduto
- decimal QuantidadePlanejada
- string Unidade

---
## Classe: AlterarNomeListaComprasDto

### Propriedades
- Guid Id
- string Nome

---
## Classe: AlterarQuantidadeItemListaDto

### Propriedades
- Guid IdListaDeCompras
- Guid IdItem
- decimal NovaQuantidade

---
## Classe: AlterarUnidadeItemListaDto

### Propriedades
- Guid IdListaDeCompras
- Guid IdItem
- string UnidadeSimbolo

---
## Classe: CriarListaAPartirDeTemplateDto

### Propriedades
- Guid IdListaPadrao
- string NomeNovaLista
- Guid? IdUsuario
- Guid? IdGrupo

---
## Classe: CriarListaComprasDto

### Propriedades
- string Nome
- Guid? IdUsuario
- Guid? IdGrupo

---
## Classe: RemoverItemListaDto

### Propriedades
- Guid IdListaDeCompras
- Guid IdItem

---
## Classe: AdicionarItemListaPadraoDto

### Propriedades
- Guid IdListaPadrao
- Guid IdProduto
- decimal QuantidadePlanejada
- string Unidade

---
## Classe: AlterarNomeListaPadraoDto

### Propriedades
- Guid Id
- string NovoNome

---
## Classe: AlterarQuantidadeItemListaPadraoDto

### Propriedades
- Guid IdListaPadrao
- Guid IdProduto
- decimal NovaQuantidade

---
## Classe: AlterarUnidadeItemListaPadraoDto

### Propriedades
- Guid IdListaPadrao
- Guid IdProduto
- string NovaUnidade

---
## Classe: CriarListaPadraoDto

### Propriedades
- Guid IdUsuario
- string Nome

---
## Classe: RemoverItemListaPadraoDto

### Propriedades
- Guid IdListaPadrao
- Guid IdProduto

---
## Classe: AlterarNomeMarcaDto

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
## Classe: AlterarNomeMercadoDto

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
## Classe: AlterarCategoriaProdutoDto

### Propriedades
- Guid Id
- Guid NovaCategoriaId

---
## Classe: AlterarMarcaProdutoDto

### Propriedades
- Guid Id
- Guid? NovaMarcaId

---
## Classe: AlterarNomeProdutoDto

### Propriedades
- Guid Id
- string NovoNome

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
- string Tipo
- bool Ativo

---
## Classe: AlterarEmailUsuarioDto

### Propriedades
- Guid Id
- string NovoEmail

---
## Classe: AlterarNomeUsuarioDto

### Propriedades
- Guid Id
- string NovoNome

---
## Classe: AlterarPlanoUsuarioDto

### Propriedades
- Guid Id
- PlanoUsuario NovoPlano

---
## Classe: AlterarSenhaUsuarioDto

### Propriedades
- Guid Id
- string SenhaAtual
- string NovaSenha

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
## Classe: RecuperarSenhaUsuarioDto

### Propriedades
- string Email
- string NovaSenha

---
## Classe: UsuarioDto

### Propriedades
- Guid Id
- string Nome
- string Email
- string Plano
- string TipoUsuario
- bool Ativo
- DateTime DataCriacao

---
# Application - UseCases

## Classe: AlterarNomeCategoriaUseCase

### Construtores
- AlterarNomeCategoriaUseCase(ICategoriaRepositorio categoriaRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: BuscarCategoriaPorIdUseCase

### Construtores
- BuscarCategoriaPorIdUseCase(ICategoriaRepositorio categoriaRepositorio)

### Métodos
- Task<CategoriaDto?> ExecutarAsync()

---
## Classe: CriarCategoriaUseCase

### Construtores
- CriarCategoriaUseCase(ICategoriaRepositorio categoriaRepository)

### Métodos
- Task<Guid> ExecutarAsync()

---
## Classe: DesativarCategoriaUseCase

### Construtores
- DesativarCategoriaUseCase(ICategoriaRepositorio categoriaRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: ListarCategoriasUseCase

### Construtores
- ListarCategoriasUseCase(ICategoriaRepositorio categoriaRepositorio)

### Métodos
- Task<IEnumerable<CategoriaDto>> ExecutarAsync()

---
## Classe: AdicionarItemCompraUseCase

### Construtores
- AdicionarItemCompraUseCase(ICompraRepositorio repositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AlterarPrecoItemCompraUseCase

### Construtores
- AlterarPrecoItemCompraUseCase(ICompraRepositorio repositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AlterarQuantidadeItemCompraUseCase

### Construtores
- AlterarQuantidadeItemCompraUseCase(ICompraRepositorio repositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: CriarCompraUseCase

### Construtores
- CriarCompraUseCase(ICompraRepositorio repositorio)

### Métodos
- Task<Guid> ExecutarAsync()

---
## Classe: FinalizarCompraUseCase

### Construtores
- FinalizarCompraUseCase(ICompraRepositorio repositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: ListarComprasDoUsuarioUseCase

### Construtores
- ListarComprasDoUsuarioUseCase(ICompraRepositorio repositorio)

### Métodos
- Task<IEnumerable<Compra>> ExecutarAsync()

---
## Classe: ListarComprasPorPeriodoUseCase

### Construtores
- ListarComprasPorPeriodoUseCase(ICompraRepositorio repositorio)

### Métodos
- Task<IEnumerable<Compra>> ExecutarAsync()

---
## Classe: ObterCompraPorIdUseCase

### Construtores
- ObterCompraPorIdUseCase(ICompraRepositorio repositorio)

### Métodos
- Task<Compra?> ExecutarAsync()

---
## Classe: ObterMercadosMaisUsadosUseCase

### Construtores
- ObterMercadosMaisUsadosUseCase(ICompraRepositorio repositorio)

### Métodos
- Task<IEnumerable<object>> ExecutarAsync()

---
## Classe: ObterProdutosMaisCompradosUseCase

### Construtores
- ObterProdutosMaisCompradosUseCase(ICompraRepositorio repositorio)

### Métodos
- Task<IEnumerable<object>> ExecutarAsync()

---
## Classe: ObterTotalGastoPorPeriodoUseCase

### Construtores
- ObterTotalGastoPorPeriodoUseCase(ICompraRepositorio repositorio)

### Métodos
- Task<decimal> ExecutarAsync()

---
## Classe: RemoverCompraDosRelatoriosUseCase

### Construtores
- RemoverCompraDosRelatoriosUseCase(ICompraRepositorio repositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: RemoverItemCompraUseCase

### Construtores
- RemoverItemCompraUseCase(ICompraRepositorio repositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: CancelarConviteGrupoUseCase

### Construtores
- CancelarConviteGrupoUseCase(IConviteGrupoRepositorio conviteRepositorio)

### Métodos
- Task ExecutarAsync()

---
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
## Classe: ListarConvitesGrupoUseCase

### Construtores
- ListarConvitesGrupoUseCase(IConviteGrupoRepositorio conviteRepositorio)

### Métodos
- Task<List<ConviteGrupoDto>> ExecutarAsync()

---
## Classe: ValidarConviteGrupoUseCase

### Construtores
- ValidarConviteGrupoUseCase(IConviteGrupoRepositorio conviteRepositorio)

### Métodos
- Task<bool> ExecutarAsync()

---
## Classe: AdicionarMembroGrupoUseCase

### Construtores
- AdicionarMembroGrupoUseCase(IGrupoRepositorio grupoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AlterarNomeGrupoUseCase

### Construtores
- AlterarNomeGrupoUseCase(IGrupoRepositorio grupoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: BuscarGrupoPorIdUseCase

### Construtores
- BuscarGrupoPorIdUseCase(IGrupoRepositorio grupoRepositorio)

### Métodos
- Task<GrupoDto?> ExecutarAsync()

---
## Classe: CriarGrupoUseCase

### Construtores
- CriarGrupoUseCase(IGrupoRepositorio grupoRepositorio)

### Métodos
- Task<Guid> ExecutarAsync()

---
## Classe: DesativarGrupoUseCase

### Construtores
- DesativarGrupoUseCase(IGrupoRepositorio grupoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: ListarGruposDoUsuarioUseCase

### Construtores
- ListarGruposDoUsuarioUseCase(IGrupoRepositorio grupoRepositorio)

### Métodos
- Task<IEnumerable<GrupoDto>> ExecutarAsync()

---
## Classe: RemoverAdministradorGrupoUseCase

### Construtores
- RemoverAdministradorGrupoUseCase(IGrupoRepositorio grupoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: RemoverMembroGrupoUseCase

### Construtores
- RemoverMembroGrupoUseCase(IGrupoRepositorio grupoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: SairDoGrupoUseCase

### Construtores
- SairDoGrupoUseCase(IGrupoRepositorio grupoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: TornarUsuarioAdministradorGrupoUseCase

### Construtores
- TornarUsuarioAdministradorGrupoUseCase(IGrupoRepositorio grupoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AdicionarItemListaUseCase

### Construtores
- AdicionarItemListaUseCase(IListaDeComprasRepositorio listaRepositorio)

### Métodos
- Task<Guid> ExecutarAsync()

---
## Classe: AlterarNomeListaDeComprasUseCase

### Construtores
- AlterarNomeListaDeComprasUseCase(IListaDeComprasRepositorio listaRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AlterarQuantidadeItemListaUseCase

### Construtores
- AlterarQuantidadeItemListaUseCase(IListaDeComprasRepositorio listaRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AlterarUnidadeItemListaUseCase

### Construtores
- AlterarUnidadeItemListaUseCase(IListaDeComprasRepositorio listaRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: BuscarListaDeComprasPorIdUseCase

### Construtores
- BuscarListaDeComprasPorIdUseCase(IListaDeComprasRepositorio listaRepositorio)

### Métodos
- Task<ListaDeCompra?> ExecutarAsync()

---
## Classe: CriarListaDeComprasAPartirDeTemplateUseCase

### Construtores
- CriarListaDeComprasAPartirDeTemplateUseCase(IListaDeComprasRepositorio listaRepositorio, IListaDeComprasPadraoRepositorio templateRepositorio)

### Métodos
- Task<Guid> ExecutarAsync()

---
## Classe: CriarListaDeComprasUseCase

### Construtores
- CriarListaDeComprasUseCase(IListaDeComprasRepositorio listaRepositorio)

### Métodos
- Task<Guid> ExecutarAsync()

---
## Classe: DesativarListaDeComprasUseCase

### Construtores
- DesativarListaDeComprasUseCase(IListaDeComprasRepositorio listaRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: FinalizarListaDeComprasUseCase

### Construtores
- FinalizarListaDeComprasUseCase(IListaDeComprasRepositorio listaRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: ListarListasDoGrupoUseCase

### Construtores
- ListarListasDoGrupoUseCase(IListaDeComprasRepositorio listaRepositorio)

### Métodos
- Task<IEnumerable<ListaDeCompra>> ExecutarAsync()

---
## Classe: ListarListasDoUsuarioUseCase

### Construtores
- ListarListasDoUsuarioUseCase(IListaDeComprasRepositorio listaRepositorio)

### Métodos
- Task<IEnumerable<ListaDeCompra>> ExecutarAsync()

---
## Classe: ReabrirListaDeComprasUseCase

### Construtores
- ReabrirListaDeComprasUseCase(IListaDeComprasRepositorio listaRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: RemoverItemListaUseCase

### Construtores
- RemoverItemListaUseCase(IListaDeComprasRepositorio listaRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AdicionarItemListaPadraoUseCase

### Construtores
- AdicionarItemListaPadraoUseCase(IListaDeComprasPadraoRepositorio repositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AlterarNomeListaPadraoUseCase

### Construtores
- AlterarNomeListaPadraoUseCase(IListaDeComprasPadraoRepositorio repositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AlterarQuantidadeItemListaPadraoUseCase

### Construtores
- AlterarQuantidadeItemListaPadraoUseCase(IListaDeComprasPadraoRepositorio repositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AlterarUnidadeItemListaPadraoUseCase

### Construtores
- AlterarUnidadeItemListaPadraoUseCase(IListaDeComprasPadraoRepositorio repositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: CriarListaPadraoUseCase

### Construtores
- CriarListaPadraoUseCase(IListaDeComprasPadraoRepositorio repositorio)

### Métodos
- Task<Guid> ExecutarAsync()

---
## Classe: DesativarListaPadraoUseCase

### Construtores
- DesativarListaPadraoUseCase(IListaDeComprasPadraoRepositorio repositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: ListarListasPadraoUsuarioUseCase

### Construtores
- ListarListasPadraoUsuarioUseCase(IListaDeComprasPadraoRepositorio repositorio)

### Métodos
- Task<IEnumerable<ListaDeCompraPadrao>> ExecutarAsync()

---
## Classe: ObterListaPadraoPorIdUseCase

### Construtores
- ObterListaPadraoPorIdUseCase(IListaDeComprasPadraoRepositorio repositorio)

### Métodos
- Task<ListaDeCompraPadrao?> ExecutarAsync()

---
## Classe: RemoverItemListaPadraoUseCase

### Construtores
- RemoverItemListaPadraoUseCase(IListaDeComprasPadraoRepositorio repositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AlterarNomeMarcaUseCase

### Construtores
- AlterarNomeMarcaUseCase(IMarcaRepositorio marcaRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: BuscarMarcaPorIdUseCase

### Construtores
- BuscarMarcaPorIdUseCase(IMarcaRepositorio marcaRepositorio)

### Métodos
- Task<MarcaDto?> ExecutarAsync()

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
## Classe: AlterarNomeMercadoUseCase

### Construtores
- AlterarNomeMercadoUseCase(IMercadoRepositorio mercadoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: BuscarMercadoPorIdUseCase

### Construtores
- BuscarMercadoPorIdUseCase(IMercadoRepositorio mercadoRepositorio)

### Métodos
- Task<MercadoDto?> ExecutarAsync()

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
## Classe: AlterarCategoriaProdutoUseCase

### Construtores
- AlterarCategoriaProdutoUseCase(IProdutoRepositorio produtoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AlterarMarcaProdutoUseCase

### Construtores
- AlterarMarcaProdutoUseCase(IProdutoRepositorio produtoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AlterarNomeProdutoUseCase

### Construtores
- AlterarNomeProdutoUseCase(IProdutoRepositorio produtoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: BuscarProdutoPorNomeUseCase

### Construtores
- BuscarProdutoPorNomeUseCase(IProdutoRepositorio produtoRepositorio)

### Métodos
- Task<IEnumerable<ProdutoDto>> ExecutarAsync()

---
## Classe: CriarProdutoUseCase

### Construtores
- CriarProdutoUseCase(IProdutoRepositorio produtoRepositorio)

### Métodos
- Task<Guid> ExecutarAsync()

---
## Classe: DesativarProdutoUseCase

### Construtores
- DesativarProdutoUseCase(IProdutoRepositorio produtoRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: ListarProdutosPorCategoriaUseCase

### Construtores
- ListarProdutosPorCategoriaUseCase(IProdutoRepositorio produtoRepositorio)

### Métodos
- Task<IEnumerable<ProdutoDto>> ExecutarAsync()

---
## Classe: ListarProdutosUseCase

### Construtores
- ListarProdutosUseCase(IProdutoRepositorio produtoRepositorio)

### Métodos
- Task<IEnumerable<ProdutoDto>> ExecutarAsync()

---
## Classe: ObterProdutoPorIdUseCase

### Construtores
- ObterProdutoPorIdUseCase(IProdutoRepositorio produtoRepositorio)

### Métodos
- Task<ProdutoDto?> ExecutarAsync()

---
## Classe: AlterarEmailUsuarioUseCase

### Construtores
- AlterarEmailUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AlterarNomeUsuarioUseCase

### Construtores
- AlterarNomeUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AlterarPlanoUsuarioUseCase

### Construtores
- AlterarPlanoUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: AlterarSenhaUsuarioUseCase

### Construtores
- AlterarSenhaUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: BuscarUsuarioPorEmailUseCase

### Construtores
- BuscarUsuarioPorEmailUseCase(IUsuarioRepositorio usuarioRepositorio)

### Métodos
- Task<UsuarioDto?> ExecutarAsync()

---
## Classe: BuscarUsuarioPorIdUseCase

### Construtores
- BuscarUsuarioPorIdUseCase(IUsuarioRepositorio usuarioRepositorio)

### Métodos
- Task<UsuarioDto?> ExecutarAsync()

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
## Classe: ListarUsuariosUseCase

### Construtores
- ListarUsuariosUseCase(IUsuarioRepositorio usuarioRepositorio)

### Métodos
- Task<IEnumerable<UsuarioDto>> ExecutarAsync()

---
## Classe: LoginUsuarioUseCase

### Construtores
- LoginUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)

### Métodos
- Task<bool> ExecutarAsync()

---
## Classe: ReativarContaUseCase

### Construtores
- ReativarContaUseCase(IUsuarioRepositorio usuarioRepositorio)

### Métodos
- Task ExecutarAsync()

---
## Classe: RecuperarSenhaUsuarioUseCase

### Construtores
- RecuperarSenhaUsuarioUseCase(IUsuarioRepositorio usuarioRepositorio)

### Métodos
- Task ExecutarAsync()

---
# Infrastructure - Repositories

## Classe: CategoriaRepositorio

### Construtores
- CategoriaRepositorio(AppDbContext context)

### Métodos
- Task<IEnumerable<Categoria>> ListarAtivosAsync()
- Task<IEnumerable<Categoria>> BuscarPorNomeAsync()

---
## Classe: CompraRepositorio

### Construtores
- CompraRepositorio(AppDbContext context)

### Métodos
- Task<IEnumerable<Compra>> ObterPorUsuarioAsync()
- Task<IEnumerable<Compra>> ObterPorPeriodoAsync()

---
## Classe: ConviteGrupoRepositorio

### Construtores
- ConviteGrupoRepositorio(AppDbContext context)

### Métodos
- Task<List<ConviteGrupo>> ListarPorGrupoIdAsync()
- Task<ConviteGrupo?> BuscarPorCodigoAsync()

---
## Classe: GrupoRepositorio

### Construtores
- GrupoRepositorio(AppDbContext context)

### Métodos
- Task<Grupo?> BuscarPorIdAsync()
- Task<IEnumerable<Grupo>> ObterPorUsuarioAsync()

---
## Classe: ListaDeComprasPadraoRepositorio

### Construtores
- ListaDeComprasPadraoRepositorio(AppDbContext context)

### Métodos
- Task<IEnumerable<ListaDeCompraPadrao>> ObterPorUsuarioAsync()

---
## Classe: ListaDeComprasRepositorio

### Construtores
- ListaDeComprasRepositorio(AppDbContext context)

### Métodos
- Task<IEnumerable<ListaDeCompra>> ListarPorUsuarioIdAsync()
- Task<IEnumerable<ListaDeCompra>> ListarPorGrupoIdAsync()

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
- Task<T?> BuscarPorIdAsync()
- Task<IEnumerable<T>> BuscarTodosAsync()
- Task AdicionarAsync()
- Task AtualizarAsync()
- Task RemoverAsync()

---
## Classe: UsuarioRepositorio

### Construtores
- UsuarioRepositorio(AppDbContext context)

### Métodos
- Task<Usuario?> BuscarPorEmailAsync()

---
# API - Controllers

## Classe: BaseController

### Métodos
- IActionResult OkResponse()
- IActionResult CreatedResponse()
- IActionResult NoContentResponse()
- IActionResult NotFoundResponse()

---
## Classe: CategoriaController

### Construtores
- CategoriaController(CriarCategoriaUseCase criarCategoria, ListarCategoriasUseCase listarCategorias, AlterarNomeCategoriaUseCase atualizarCategoria, DesativarCategoriaUseCase desativarCategoria, BuscarCategoriaPorIdUseCase buscarCategoriaPorId)

### Métodos
- Task<IActionResult> Criar()
- Task<IActionResult> Listar()
- Task<IActionResult> BuscarPorId()
- Task<IActionResult> Atualizar()
- Task<IActionResult> Desativar()

---
## Classe: CompraController

### Construtores
- CompraController(CriarCompraUseCase criar, AdicionarItemCompraUseCase adicionarItem, RemoverItemCompraUseCase removerItem, AlterarQuantidadeItemCompraUseCase alterarQuantidadeItem, AlterarPrecoItemCompraUseCase alterarPrecoItem, FinalizarCompraUseCase finalizar, RemoverCompraDosRelatoriosUseCase removerRelatorio, ObterCompraPorIdUseCase obter, ListarComprasDoUsuarioUseCase listarUsuario, ListarComprasPorPeriodoUseCase listarPeriodo, ObterTotalGastoPorPeriodoUseCase totalPeriodo, ObterProdutosMaisCompradosUseCase produtosMaisComprados, ObterMercadosMaisUsadosUseCase mercadosMaisUsados)

### Métodos
- Task<IActionResult> Criar()
- Task<IActionResult> Obter()
- Task<IActionResult> ListarPorUsuario()
- Task<IActionResult> ListarPorPeriodo()
- Task<IActionResult> Finalizar()
- Task<IActionResult> RemoverDosRelatorios()
- Task<IActionResult> AdicionarItem()
- Task<IActionResult> RemoverItem()
- Task<IActionResult> AlterarQuantidadeItem()
- Task<IActionResult> AlterarPrecoItem()
- Task<IActionResult> TotalGastoPeriodo()
- Task<IActionResult> ProdutosMaisComprados()
- Task<IActionResult> MercadosMaisUsados()

---
## Classe: ConviteGrupoController

### Construtores
- ConviteGrupoController(CriarConviteGrupoUseCase criarConvite, CancelarConviteGrupoUseCase cancelarConvite, EntrarGrupoPorCodigoUseCase entrarGrupoPorCodigo, ListarConvitesGrupoUseCase listarConvites, ValidarConviteGrupoUseCase validarConvite)

### Métodos
- Task<IActionResult> CriarConvite()
- Task<IActionResult> EntrarPorCodigo()
- Task<IActionResult> ValidarConvite()
- Task<IActionResult> ListarPorGrupo()
- Task<IActionResult> CancelarConvite()

---
## Classe: GrupoController

### Construtores
- GrupoController(CriarGrupoUseCase criarGrupo, BuscarGrupoPorIdUseCase buscarGrupoPorId, ListarGruposDoUsuarioUseCase listarGruposDoUsuario, AdicionarMembroGrupoUseCase adicionarMembro, RemoverMembroGrupoUseCase removerMembro, SairDoGrupoUseCase sairDoGrupo, AlterarNomeGrupoUseCase alterarNomeGrupo, DesativarGrupoUseCase desativarGrupo, TornarUsuarioAdministradorGrupoUseCase tornarAdministrador, RemoverAdministradorGrupoUseCase removerAdministrador)

### Métodos
- Task<IActionResult> CriarGrupo()
- Task<IActionResult> BuscarGrupoPorId()
- Task<IActionResult> ListarGruposDoUsuario()
- Task<IActionResult> AdicionarMembro()
- Task<IActionResult> RemoverMembro()
- Task<IActionResult> SairDoGrupo()
- Task<IActionResult> AlterarNomeGrupo()
- Task<IActionResult> TornarAdministrador()
- Task<IActionResult> RemoverAdministrador()
- Task<IActionResult> DesativarGrupo()

---
## Classe: ListaDeComprasController

### Construtores
- ListaDeComprasController(CriarListaDeComprasUseCase criarListaUseCase, BuscarListaDeComprasPorIdUseCase buscarListaUseCase, ListarListasDoUsuarioUseCase listarListasUsuarioUseCase, ListarListasDoGrupoUseCase listarListasGrupoUseCase, AlterarNomeListaDeComprasUseCase alterarNomeListaUseCase, DesativarListaDeComprasUseCase desativarListaUseCase, FinalizarListaDeComprasUseCase finalizarListaUseCase, ReabrirListaDeComprasUseCase reabrirListaUseCase, AdicionarItemListaUseCase adicionarItemUseCase, RemoverItemListaUseCase removerItemUseCase, AlterarQuantidadeItemListaUseCase alterarQuantidadeItemUseCase, AlterarUnidadeItemListaUseCase alterarUnidadeItemUseCase, CriarListaDeComprasAPartirDeTemplateUseCase criarListaAPartirTemplateUseCase)

### Métodos
- Task<IActionResult> CriarLista()
- Task<IActionResult> BuscarListaPorId()
- Task<IActionResult> ListarListasDoUsuario()
- Task<IActionResult> ListarListasDoGrupo()
- Task<IActionResult> AlterarNome()
- Task<IActionResult> DesativarLista()
- Task<IActionResult> FinalizarLista()
- Task<IActionResult> ReabrirLista()
- Task<IActionResult> AdicionarItem()
- Task<IActionResult> RemoverItem()
- Task<IActionResult> AlterarQuantidadeItem()
- Task<IActionResult> AlterarUnidadeItem()
- Task<IActionResult> CriarAPartirDeTemplate()

---
## Classe: ListaPadraoController

### Construtores
- ListaPadraoController(CriarListaPadraoUseCase criar, ListarListasPadraoUsuarioUseCase listar, ObterListaPadraoPorIdUseCase obter, AlterarNomeListaPadraoUseCase alterarNome, AdicionarItemListaPadraoUseCase adicionarItem, RemoverItemListaPadraoUseCase removerItem, AlterarQuantidadeItemListaPadraoUseCase alterarQuantidade, AlterarUnidadeItemListaPadraoUseCase alterarUnidade, DesativarListaPadraoUseCase desativar)

### Métodos
- Task<IActionResult> Criar()
- Task<IActionResult> ListarPorUsuario()
- Task<IActionResult> Obter()
- Task<IActionResult> AlterarNome()
- Task<IActionResult> AdicionarItem()
- Task<IActionResult> RemoverItem()
- Task<IActionResult> AlterarQuantidade()
- Task<IActionResult> AlterarUnidade()
- Task<IActionResult> Desativar()

---
## Classe: MarcaController

### Construtores
- MarcaController(CriarMarcaUseCase criarMarca, ListarMarcasUseCase listarMarcas, AlterarNomeMarcaUseCase atualizarMarca, DesativarMarcaUseCase desativarMarca, BuscarMarcaPorIdUseCase buscarMarcaPorId)

### Métodos
- Task<IActionResult> Criar()
- Task<IActionResult> Listar()
- Task<IActionResult> BuscarPorId()
- Task<IActionResult> Atualizar()
- Task<IActionResult> Desativar()

---
## Classe: MercadoController

### Construtores
- MercadoController(CriarMercadoUseCase criarMercado, ListarMercadosUseCase listarMercados, AlterarNomeMercadoUseCase atualizarMercado, DesativarMercadoUseCase desativarMarcado, BuscarMercadoPorIdUseCase buscarMercadoPorId)

### Métodos
- Task<IActionResult> Criar()
- Task<IActionResult> Listar()
- Task<IActionResult> BuscarPorId()
- Task<IActionResult> Atualizar()
- Task<IActionResult> Desativar()

---
## Classe: ProdutoController

### Construtores
- ProdutoController(CriarProdutoUseCase criarProduto, ListarProdutosUseCase listarProdutos, ObterProdutoPorIdUseCase obterProdutoPorId, ListarProdutosPorCategoriaUseCase listarProdutosPorCategoria, BuscarProdutoPorNomeUseCase buscarProdutoPorNome, AlterarNomeProdutoUseCase alterarNomeProduto, AlterarCategoriaProdutoUseCase alterarCategoriaProduto, AlterarMarcaProdutoUseCase alterarMarcaProduto, DesativarProdutoUseCase desativarProduto)

### Métodos
- Task<IActionResult> Criar()
- Task<IActionResult> Listar()
- Task<IActionResult> ObterPorId()
- Task<IActionResult> ListarPorCategoria()
- Task<IActionResult> BuscarPorNome()
- Task<IActionResult> AlterarNome()
- Task<IActionResult> AlterarCategoria()
- Task<IActionResult> AlterarMarca()
- Task<IActionResult> Desativar()

---
## Classe: UsuarioController

### Construtores
- UsuarioController(CriarUsuarioUseCase criarUsuario, LoginUsuarioUseCase loginUsuario, AlterarNomeUsuarioUseCase alterarNome, AlterarEmailUsuarioUseCase alterarEmail, AlterarSenhaUsuarioUseCase alterarSenha, AlterarPlanoUsuarioUseCase alterarPlano, DesativarContaUseCase desativarConta, ReativarContaUseCase reativarConta, BuscarUsuarioPorIdUseCase buscarUsuarioPorId, BuscarUsuarioPorEmailUseCase buscarUsuarioPorEmail, ListarUsuariosUseCase listarUsuarios, RecuperarSenhaUsuarioUseCase recuperarSenha)

### Métodos
- Task<IActionResult> CriarUsuario()
- Task<IActionResult> Login()
- Task<IActionResult> ListarUsuarios()
- Task<IActionResult> BuscarPorId()
- Task<IActionResult> BuscarPorEmail()
- Task<IActionResult> AlterarNome()
- Task<IActionResult> AlterarEmail()
- Task<IActionResult> AlterarSenha()
- Task<IActionResult> AlterarPlano()
- Task<IActionResult> DesativarConta()
- Task<IActionResult> ReativarConta()
- Task<IActionResult> RecuperarSenha()

---
# Interfaces

- ICategoriaRepositorio
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

