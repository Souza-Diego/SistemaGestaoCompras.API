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
- DTOs: 29
- UseCases: 48

#### DTOs
- AtualizarCategoriaDto
- CategoriaDto
- CriarCategoriaDto
- ConviteGrupoDto
- CriarConviteGrupoDto
- EntrarGrupoPorCodigoDto
- AdicionarMembroGrupoDto
- AlterarNomeGrupoDto
- CriarGrupoDto
- GrupoDto
- RemoverMembroGrupoDto
- SairDoGrupoDto
- AdicionarItemListaDto
- AtualizarListaComprasDto
- CriarListaComprasDto
- RemoverItemListaDto
- AtualizarMarcaDto
- CriarMarcaDto
- MarcaDto
- AtualizarMercadoDto
- CriarMercadoDto
- MercadoDto
- AtualizarProdutoDto
- CriarProdutoDto
- ProdutoDto
- AlterarPerfilDto
- CriarUsuarioDto
- LoginUsuarioDto
- UsuarioDto

#### UseCases
- AtualizarCategoriaUseCase
- BuscarCategoriaPorIdUseCase
- CriarCategoriaUseCase
- DesativarCategoriaUseCase
- ListarCategoriasUseCase
- CancelarConviteGrupoUseCase
- CriarConviteGrupoUseCase
- EntrarGrupoPorCodigoUseCase
- ListarConvitesGrupoUseCase
- AdicionarMembroGrupoUseCase
- AlterarNomeGrupoUseCase
- BuscarGrupoPorIdUseCase
- CriarGrupoUseCase
- ListarGruposDoUsuarioUseCase
- RemoverMembroGrupoUseCase
- SairDoGrupoUseCase
- AdicionarItemListaUseCase
- AtualizarListaDeComprasUseCase
- BuscarListaDeComprasPorIdUseCase
- CriarListaDeComprasUseCase
- DesativarListaDeComprasUseCase
- FinalizarListaDeComprasUseCase
- ListarListasDeComprasUseCase
- ReabrirListaDeComprasUseCase
- RemoverItemListaUseCase
- AtualizarMarcaUseCase
- BuscarMarcaPorIdUseCase
- CriarMarcaUseCase
- DesativarMarcaUseCase
- ListarMarcasUseCase
- AtualizarMercadoUseCase
- BuscarMercadoPorIdUseCase
- CriarMercadoUseCase
- DesativarMercadoUseCase
- ListarMercadosUseCase
- AtualizarProdutoUseCase
- BuscarProdutoPorIdUseCase
- BuscarProdutosPorCategoriaUseCase
- BuscarProdutosPorNomeUseCase
- CriarProdutoUseCase
- DesativarProdutoUseCase
- ListarProdutosUseCase
- AlterarPerfilUseCase
- BuscarUsuarioPorEmailUseCase
- BuscarUsuarioPorIdUseCase
- CriarUsuarioUseCase
- DesativarContaUseCase
- LoginUsuarioUseCase

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

