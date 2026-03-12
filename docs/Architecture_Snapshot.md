# Architecture Snapshot

## Estrutura do Sistema

### Domain
- Entities: 17
- ValueObjects: 4
- Services: 3
- Enums: 6
- Repository Interfaces: 13

#### Entities
- Categoria
- Compra
- ConviteGrupo
- Entidade
- Grupo
- GrupoUsuario
- ItemCompra
- ItemLista
- ItemListaPadrao
- ListaDeCompra
- ListaDeCompraPadrao
- Marca
- Mercado
- Orcamento
- Produto
- RegistroDePreco
- Usuario

#### ValueObjects
- Dinheiro
- Email
- Senha
- UnidadeMedida

#### Domain Services
- CalculadoraOrcamentoAutomatico
- EstatisticasCompraService
- CalculadoraOrcamentoAutomatico

#### Enums
- PapelGrupo
- PlanoUsuario
- StatusLista
- TipoProduto
- TipoUnidade
- TipoUsuario

#### Repository Interfaces

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

### Application
- DTOs: 65
- UseCases: 100

#### DTOs
- AlterarNomeCategoriaDto
- CategoriaDto
- CriarCategoriaDto
- AdicionarItemCompraDto
- AlterarPrecoItemCompraDto
- AlterarQuantidadeItemCompraDto
- CriarCompraDto
- ListarComprasPeriodoDto
- RemoverItemCompraDto
- TotalGastoPeriodoDto
- ConviteGrupoDto
- CriarConviteGrupoDto
- EntrarGrupoPorCodigoDto
- ValidarConviteGrupoDto
- GastosMensaisDto
- GastosPorCategoriaDto
- MediaMensalGastosDto
- AdicionarMembroGrupoDto
- AlterarNomeGrupoDto
- CriarGrupoDto
- DesativarGrupoDto
- GrupoDto
- RemoverAdministradorGrupoDto
- RemoverMembroGrupoDto
- SairDoGrupoDto
- TornarUsuarioAdministradorGrupoDto
- AdicionarItemListaDto
- AlterarNomeListaComprasDto
- AlterarQuantidadeItemListaDto
- AlterarUnidadeItemListaDto
- CriarListaAPartirDeTemplateDto
- CriarListaComprasDto
- RemoverItemListaDto
- AdicionarItemListaPadraoDto
- AlterarNomeListaPadraoDto
- AlterarQuantidadeItemListaPadraoDto
- AlterarUnidadeItemListaPadraoDto
- CriarListaPadraoDto
- RemoverItemListaPadraoDto
- AlterarNomeMarcaDto
- CriarMarcaDto
- MarcaDto
- AlterarNomeMercadoDto
- CriarMercadoDto
- MercadoDto
- AlterarValorOrcamentoDTO
- CriarOrcamentoMensalDTO
- ObterOrcamentoDoMesDTO
- OrcamentoDto
- AlterarCategoriaProdutoDto
- AlterarMarcaProdutoDto
- AlterarNomeProdutoDto
- CriarProdutoDto
- ProdutoDto
- CorrigirPrecoRegistradoDto
- ListarPrecosPorMercadoDto
- RegistrarPrecoProdutoDto
- AlterarEmailUsuarioDto
- AlterarNomeUsuarioDto
- AlterarPlanoUsuarioDto
- AlterarSenhaUsuarioDto
- CriarUsuarioDto
- LoginUsuarioDto
- RecuperarSenhaUsuarioDto
- UsuarioDto

#### UseCases
- AlterarNomeCategoriaUseCase
- BuscarCategoriaPorIdUseCase
- CriarCategoriaUseCase
- DesativarCategoriaUseCase
- ListarCategoriasUseCase
- AdicionarItemCompraUseCase
- AlterarPrecoItemCompraUseCase
- AlterarQuantidadeItemCompraUseCase
- CriarCompraUseCase
- FinalizarCompraUseCase
- ListarComprasDoUsuarioUseCase
- ListarComprasPorPeriodoUseCase
- ObterCompraPorIdUseCase
- ObterMercadosMaisUsadosUseCase
- ObterProdutosMaisCompradosUseCase
- ObterTotalGastoPorPeriodoUseCase
- RemoverCompraDosRelatoriosUseCase
- RemoverItemCompraUseCase
- CancelarConviteGrupoUseCase
- CriarConviteGrupoUseCase
- EntrarGrupoPorCodigoUseCase
- ListarConvitesGrupoUseCase
- ValidarConviteGrupoUseCase
- ObterGastosMensaisUseCase
- ObterGastosPorCategoriaUseCase
- ObterMediaMensalGastosUseCase
- AdicionarMembroGrupoUseCase
- AlterarNomeGrupoUseCase
- BuscarGrupoPorIdUseCase
- CriarGrupoUseCase
- DesativarGrupoUseCase
- ListarGruposDoUsuarioUseCase
- RemoverAdministradorGrupoUseCase
- RemoverMembroGrupoUseCase
- SairDoGrupoUseCase
- TornarUsuarioAdministradorGrupoUseCase
- AdicionarItemListaUseCase
- AlterarNomeListaDeComprasUseCase
- AlterarQuantidadeItemListaUseCase
- AlterarUnidadeItemListaUseCase
- BuscarListaDeComprasPorIdUseCase
- CriarListaDeComprasAPartirDeTemplateUseCase
- CriarListaDeComprasUseCase
- DesativarListaDeComprasUseCase
- FinalizarListaDeComprasUseCase
- ListarListasDoGrupoUseCase
- ListarListasDoUsuarioUseCase
- ReabrirListaDeComprasUseCase
- RemoverItemListaUseCase
- AdicionarItemListaPadraoUseCase
- AlterarNomeListaPadraoUseCase
- AlterarQuantidadeItemListaPadraoUseCase
- AlterarUnidadeItemListaPadraoUseCase
- CriarListaPadraoUseCase
- DesativarListaPadraoUseCase
- ListarListasPadraoUsuarioUseCase
- ObterListaPadraoPorIdUseCase
- RemoverItemListaPadraoUseCase
- AlterarNomeMarcaUseCase
- BuscarMarcaPorIdUseCase
- CriarMarcaUseCase
- DesativarMarcaUseCase
- ListarMarcasUseCase
- AlterarNomeMercadoUseCase
- BuscarMercadoPorIdUseCase
- CriarMercadoUseCase
- DesativarMercadoUseCase
- ListarMercadosUseCase
- AlterarValorOrcamentoUseCase
- CalcularOrcamentoAutomaticoUseCase
- CriarOrcamentoMensalUseCase
- ListarOrcamentosUsuarioUseCase
- ObterOrcamentoDoMesUseCase
- AlterarCategoriaProdutoUseCase
- AlterarMarcaProdutoUseCase
- AlterarNomeProdutoUseCase
- BuscarProdutoPorNomeUseCase
- CriarProdutoUseCase
- DesativarProdutoUseCase
- ListarProdutosPorCategoriaUseCase
- ListarProdutosUseCase
- ObterProdutoPorIdUseCase
- CorrigirPrecoRegistradoUseCase
- ListarPrecosPorMercadoUseCase
- ListarPrecosProdutoUseCase
- ObterHistoricoPrecoProdutoUseCase
- ObterMelhorPrecoProdutoUseCase
- RegistrarPrecoProdutoUseCase
- AlterarEmailUsuarioUseCase
- AlterarNomeUsuarioUseCase
- AlterarPlanoUsuarioUseCase
- AlterarSenhaUsuarioUseCase
- BuscarUsuarioPorEmailUseCase
- BuscarUsuarioPorIdUseCase
- CriarUsuarioUseCase
- DesativarContaUseCase
- ListarUsuariosUseCase
- LoginUsuarioUseCase
- ReativarContaUseCase
- RecuperarSenhaUsuarioUseCase

### Infrastructure
- Repositories: 13

#### Repositories
- CategoriaRepositorio
- CompraRepositorio
- ConviteGrupoRepositorio
- GrupoRepositorio
- ListaDeComprasPadraoRepositorio
- ListaDeComprasRepositorio
- MarcaRepositorio
- MercadoRepositorio
- OrcamentoRepositorio
- ProdutoRepositorio
- RegistroDePrecoRepositorio
- RepositorioBase
- UsuarioRepositorio

### API
- Controllers: 14

#### Controllers
- BaseController
- CategoriaController
- CompraController
- ConviteGrupoController
- EstatisticasController
- GrupoController
- ListaDeComprasController
- ListaPadraoController
- MarcaController
- MercadoController
- OrcamentoController
- ProdutoController
- RegistroDePrecoController
- UsuarioController

