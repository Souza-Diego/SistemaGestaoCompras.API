using SistemaGestaoCompras.Application.DTOs.RegistroDePrecos;
using SistemaGestaoCompras.Application.UseCases.RegistroDePrecos;
using SistemaGestaoCompras.Domain.Interfaces.Repositories;
using Moq;
using SistemaGestaoCompras.Domain.Entities;

public class RegistrarPrecoProdutoTests
{
    [Fact]
    public async Task DeveRegistrarPreco()
    {
        var repoMock = new Mock<IRegistroDePrecoRepositorio>();

        var useCase = new RegistrarPrecoProdutoUseCase(repoMock.Object);

        var dto = new RegistrarPrecoProdutoDto
        {
            IdProduto = Guid.NewGuid(),
            IdMercado = Guid.NewGuid(),
            IdUsuario = Guid.NewGuid(),
            Preco = 10,
            QuantidadeReferencia = 1,
            UnidadeReferencia = "kg"
        };

        var resultado = await useCase.ExecutarAsync(dto);

        repoMock.Verify(r =>
            r.AdicionarAsync(It.IsAny<RegistroDePreco>()),
            Times.Once);
    }
}