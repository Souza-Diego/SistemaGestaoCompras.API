# Architecture Snapshot

## Estrutura do Sistema

### Domain
- Entities: 17
- ValueObjects: 4
- Services: 2
- Enums: 6
- Repository Interfaces: 12

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
- ListaDeCompras
- ListaDeComprasPadrao
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
- DTOs: 16
- UseCases: 20

#### DTOs
- CriarConviteGrupoDto
- EntrarGrupoPorCodigoDto
- CriarGrupoDto
- RemoverMembroGrupoDto
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

#### UseCases
- CriarConviteGrupoUseCase
- EntrarGrupoPorCodigoUseCase
- CriarGrupoUseCase
- RemoverMembroGrupoUseCase
- AtualizarMarcaUseCase
- CriarMarcaUseCase
- DesativarMarcaUseCase
- ListarMarcasUseCase
- AtualizarMercadoUseCase
- CriarMercadoUseCase
- DesativarMercadoUseCase
- ListarMercadosUseCase
- AtualizarProdutoUseCase
- CriarProdutoUseCase
- DesativarProdutoUseCase
- ListarProdutosUseCase
- AlterarPerfilUseCase
- CriarUsuarioUseCase
- DesativarContaUseCase
- LoginUsuarioUseCase

### Infrastructure
- Repositories: 7

#### Repositories
- ConviteGrupoRepositorio
- GrupoRepositorio
- MarcaRepositorio
- MercadoRepositorio
- ProdutoRepositorio
- RepositorioBase
- UsuarioRepositorio

### API
- Controllers: 6

#### Controllers
- ConviteGrupoController
- GrupoController
- MarcaController
- MercadoController
- ProdutoController
- UsuarioController

