using System.ComponentModel;

namespace MercadoEletronico.Domain.Enums
{
    public enum Status
    {
        [Description("CODIGO_PEDIDO_INVALIDO")]
        CodigoPedidoInvalido = 0,
        [Description("REPROVADO")]
        Reprovado = 1,
        [Description("APROVADO")]
        Aprovado = 2,
        [Description("APROVADO_VALOR_A_MENOR")]
        AprovadoValorMenor = 3,
        [Description("APROVADO_VALOR_A_MAIOR")]
        AprovadoValorMaior = 4,
        [Description("APROVADO_QTD_A_MENOR")]
        AprovadoQuantidadeMenor = 5,
        [Description("APROVADO_QTD_A_MAIOR")]
        AprovadoQuantidadeMaior = 6
    }
}
