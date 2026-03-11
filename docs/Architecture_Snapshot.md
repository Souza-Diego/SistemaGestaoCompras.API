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
- DTOs: 41
- UseCases: 63

#### DTOs
- AlterarNomeCategoriaDto
- CategoriaDto
- CriarCategoriaDto
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
- CriarListaComprasDto
- RemoverItemListaDto
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
- CriarListaDeComprasUseCase
- DesativarListaDeComprasUseCase
- FinalizarListaDeComprasUseCase
- ListarListasDoGrupoUseCase
- ListarListasDoUsuarioUseCase
- ReabrirListaDeComprasUseCase
- RemoverItemListaUseCase
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
- Repositories: 9

#### Repositories
- CategoriaRepositorio
- ConviteGrupoRepositorio
- GrupoRepositorio
- ListaDeComprasRepositorio
- MarcaRepositorio
- MercadoRepositorio
- ProdutoRepositorio
- RepositorioBase
- UsuarioRepositorio

### API
- Controllers: 9

#### Controllers
- BaseController
- CategoriaController
- ConviteGrupoController
- GrupoController
- ListaDeComprasController
- MarcaController
- MercadoController
- ProdutoController
- UsuarioController

