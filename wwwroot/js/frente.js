/*Declaracao de variaveis */
var enderecoProduto = "https://localhost:44361/Produtos/Produto/";
var produto;
/* */
$("#pesquisar").click(function () {
    var codProduto = $("#codProduto").val();
    var enderecoTemporario = enderecoProduto + codProduto;
    $.post(enderecoTemporario, function (dados, status) {
        produto = dados;
    }).fail(function () {
        alert("Código do produto inválido");
});
});