# Architecture Snapshot

## Estrutura do Sistema

### Domain
- Entities: 17
- ValueObjects: 4
- Services: 2
- Enums: 6
- Repository Interfaces: 10

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
- IOrcamentoRepositorio
- IProdutoRepositorio
- IRegistroDePrecoRepositorio
- IRepositorioBase
- IUsuarioRepositorio

### Application
- DTOs: 10
- UseCases: 12

#### DTOs
- CriarConviteGrupoDto
- EntrarGrupoPorCodigoDto
- CriarGrupoDto
- RemoverMembroGrupoDto
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
- AtualizarProdutoUseCase
- CriarProdutoUseCase
- DesativarProdutoUseCase
- ListarProdutosUseCase
- AlterarPerfilUseCase
- CriarUsuarioUseCase
- DesativarContaUseCase
- LoginUsuarioUseCase

### Infrastructure
- Repositories: 5

#### Repositories
- ConviteGrupoRepositorio
- GrupoRepositorio
- ProdutoRepositorio
- RepositorioBase
- UsuarioRepositorio

### API
- Controllers: 3

#### Controllers
- ConviteGrupoController
- GrupoController
- UsuarioController

