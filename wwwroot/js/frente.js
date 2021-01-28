//Declaração de variáveis
var enderecoProduto = "https://localhost:5001/Produtos/Produto/";
var produto;
var pedido = [];
var totalPedido = 0.0;

/* Funções */

$("#posVenda").hide();
$("#totalPedido").html(totalPedido);

function atualizarValorTotal() {
    $("#totalPedido").html(totalPedido);
}

function preencherFormulario(dadosProduto) {
    $("#campoNome").val(dadosProduto.nome);
    $("#campoCategoria").val(dadosProduto.categoria.nome);
    $("#campoFornecedor").val(dadosProduto.fornecedor.nome);
    $("#campoPreco").val(dadosProduto.precodeVenda);
}

function limparForm() {
    $("#codProduto").val("");
    $("#campoNome").val("");
    $("#campoCategoria").val("");
    $("#campoFornecedor").val("");
    $("#campoPreco").val("");
    $("#campoQuantidade").val("");
}

function addProdutoTabela(p, pQtd) {

    //clocando objeto produto pra um json
    var produtoTmp = {};
    Object.assign(produtoTmp, produto);

    var _pedido = { produto: produtoTmp, quantidade: pQtd, subtotal: produtoTmp.precodeVenda * pQtd }
    totalPedido += _pedido.subtotal;
    $("#totalPedido").html(totalPedido);

    pedido.push(produtoTmp);

    $("#tb_pedido").append(`<tr>
        <td>${p.id}</td>
        <td>${p.nome}</td>
        <td>${pQtd}</td>
        <td>${p.precodeVenda} R$ </td>
        <td>${p.medicao}</td>
        <td>${p.precodeVenda * pQtd} R$ </td>
        <td><button class="btn btn-danger">Remover</button></td>
    </tr>`);
}

//
$("#formProduto").on("submit", function(event) {
    //não deixa o jQuery recarregar a página
    event.preventDefault();
    var produtoTabela = produto;

    if ($("#campoQuantidade").val() > 0 && !isNaN($("#campoQuantidade").val())) {
        var qtd = $("#campoQuantidade").val();

        console.log(produtoTabela);
        console.log(qtd);

        addProdutoTabela(produtoTabela, qtd);
        //var produto = undefined;
        limparForm();
    } else {
        alert("Valor de Quantidade inválido");
    }
});

/* Ajax */
$("#pesquisar").click(function() {
    var codProduto = $("#codProduto").val();
    var EnderecoTmp = enderecoProduto + codProduto;
    $.post(EnderecoTmp, function(dados, status) {
        produto = dados;

        var med = "";

        switch (produto.medicao) {
            case 0:
                med = "Litro";
                break;
            case 1:
                med = "Kg";
                break;
            case 2:
                med = "Unidade";
                break;
            default:
                med = "Unidade";
                break;
        }

        produto.medicao = med;

        preencherFormulario(produto);
    }).fail(function() {
        alert("Produto inválido");
    });
});

/* Finalização de Pedido */
$("#btnFinalizaPedido").click(function() {
    if (totalPedido <= 0) {
        alert("Compra inválida!! Nenhum produto foi adicionado ao pedido. ");
        return;
    }
    //recebendo valor por jquery
    var valorPago = $("#valorPago").val();
    console.log(typeof valorPago);
    //verificando valor pago
    if (!isNaN(valorPago)) {
        valorPago = parseFloat(valorPago);
        if (valorPago >= totalPedido) {
            $("#posVenda").show();
            $("#preVenda").hide();
            $("#valorPago").prop("disabled", true);
            //calculando troco
            var troco = valorPago - totalPedido;
            $("#troco").val(troco);
        } else {
            alert("O valor pago é muito baixo");
            return;
        }
    } else {
        alert("Valor pago inválido.");
        return;
    }
});
//tratando modal de finalização de Pedido
function restaurarModal() {
    $("#posVenda").hide();
    $("#preVenda").show();
    $("#valorPago").prop("disabled", false);
    $("#valorPago").val();
    $("#troco").val();
}
$("#fecharModal").click(function() {
    restaurarModal();
});