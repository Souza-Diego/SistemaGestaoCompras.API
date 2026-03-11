# Architecture Snapshot

## Estrutura do Sistema

### Domain
- Entities: 17
- ValueObjects: 4
- Services: 2
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
- DTOs: 55
- UseCases: 86

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
- AlterarCategoriaProdutoDto
- AlterarMarcaProdutoDto
- AlterarNomeProdutoDto
- CriarProdutoDto
- ProdutoDto
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
- AlterarCategoriaProdutoUseCase
- AlterarMarcaProdutoUseCase
- AlterarNomeProdutoUseCase
- BuscarProdutoPorNomeUseCase
- CriarProdutoUseCase
- DesativarProdutoUseCase
- ListarProdutosPorCategoriaUseCase
- ListarProdutosUseCase
- ObterProdutoPorIdUseCase
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
- Repositories: 11

#### Repositories
- CategoriaRepositorio
- CompraRepositorio
- ConviteGrupoRepositorio
- GrupoRepositorio
- ListaDeComprasPadraoRepositorio
- ListaDeComprasRepositorio
- MarcaRepositorio
- MercadoRepositorio
- ProdutoRepositorio
- RepositorioBase
- UsuarioRepositorio

### API
- Controllers: 11

#### Controllers
- BaseController
- CategoriaController
- CompraController
- ConviteGrupoController
- GrupoController
- ListaDeComprasController
- ListaPadraoController
- MarcaController
- MercadoController
- ProdutoController
- UsuarioController

