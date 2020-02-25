/*Declaracao de variaveis */
var enderecoProduto = "https://localhost:44361/Produtos/Produto/";
var produto;
var compra = [];
var __totalVenda__ = 0.0;

/* Inicio */
$("posVenda").hide();
atualizarTotal();

/* Funções */
function atualizarTotal() {
    $("#totalVenda").html(__totalVenda__);
};

function preencherFormulario(dadosProduto) {
    $("#campoNome").val(dadosProduto.nome);
    $("#campoCategoria").val(dadosProduto.categoria.nome);
    $("#campoFornecedor").val(dadosProduto.fornecedor.nome);
    $("#campoPrecoDeVenda").val(dadosProduto.precoVenda);
}

function zerarFormulario() {
    $("#campoNome").val("");
    $("#campoCategoria").val("");
    $("#campoFornecedor").val("");
    $("#campoPrecoDeVenda").val("");
    $("#campoQuantidade").val("");
    $("#codProduto").val("");
    }

function adicionarNaTabela(p, q) {

    var produtoTemp = {};
    Object.assign(produtoTemp, produto);

    var venda = { produto: produtoTemp, quantidade: q, subtotal: produtoTemp.precoVenda * q };
    __totalVenda__ += venda.subtotal;
    atualizarTotal();

    compra.push(produtoTemp);

$("#produtos").append(`<tr>
<td>${p.id}</td>
<td>${p.nome}</td>
<td>${q}</td>
<td>${p.precoVenda}</td>
<td>${p.unidadeMedida}</td>
<td>R$ ${p.precoVenda * q}</td>
<td><button class='btn btn-danger'>Remover</button></td>
</tr>
`)
}

$("#produtoForm").on("submit", function (event) {
    event.preventDefault();
    var produtoParaTabela = produto;
    var qtd = $("#campoQuantidade").val();
    if (qtd < 1) {
        qtd = 1;
    }
    adicionarNaTabela(produto, qtd)
    //var produto = undefined;
    zerarFormulario();
});

/* Ajax */
$("#pesquisar").click(function () {
    var codProduto = $("#codProduto").val();
    var enderecoTemporario = enderecoProduto + codProduto;
    $.post(enderecoTemporario, function (dados, status) {
        produto = dados;

        var med = ""

        switch (produto.unidadeMedida) {
            case 0:
                med = "LT";
                break;
            case 1:
                med = "KG";
                break;
            case 2:
                med = "UN";
                break;
            default:
                med = "UN";
        }

        produto.unidadeMedida = med;

        preencherFormulario(produto);
    }).fail(function () {
        alert("Código do produto inválido");
});
});

/* Finalizar venda */
$("#finalizarVendaBTN").click(function () {
    if (__totalVenda__ <= 0) {
        alert("Compra inválida, nenhum produto adicionado");
        return;
    }

    var _valorPago = $("#valorPago").val();

    if (!isNaN(_valorPago)) {
        _valorPago = parseFloat(_valorPago);
        if (_valorPago >= __totalVenda__) {
            $("#posvenda").show();
            $("#prevenda").hide();
            $("#valorPago").prop("disabled",true);

            var _troco = _valorPago - __totalVenda__;
            $("#troco").val(_troco);
        }
        else {
            alert("Valor pago é menor que o total da venda");
            return;
        }
    }
    else {
        alert("Valor pago, inválido!");
        return;
    }

});

function restaurarModal() {
    $("#posvenda").hide();
    $("#prevenda").show();
    $("#valorPago").prop("disabled", false);
    $("#troco").val("");
    $("#valorPago").val("");

}

$("#fecharModal").click(function() {
    restaurarModal();
});