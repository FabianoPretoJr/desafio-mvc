var arr = [];
var aux = true;
var enderecoListarTecs = "https://localhost:5001/Vagas/Teste";
var enderecoObterTecs = "https://localhost:5001/Vagas/ObterJsonTec/"; 
var enderecoObterNomes = "https://localhost:5001/Vagas/ObterNomeTec/";

var str = $("#tecId").val();
var arr = str.split(",");
$("#tecId").val(arr); 
$("#tecIdAntigos").val(arr);

ObterTecs();

function ObterTecs() {
    var enderecoId = $("#id").val();
    var endrecoTemporario = enderecoObterTecs + enderecoId;

    $.post(endrecoTemporario, function(dados, status) {
        for(let i = 0; i < dados.length; i++)
        {
            endercoDeBusca = enderecoObterNomes + dados[i].tecnologiaID;
            $.post(endercoDeBusca, function(dados1, status) {
                $("#render").append(`
                <div style="display: flex;">
                    <select class="form-control" id="adcTec${dados[i].tecnologiaID}") onChange="adcArr(${dados[i].tecnologiaID})" disabled="true">
                        <option value="">${dados1}</option>
                    </select>
                    <a class="btn btn-danger" onClick="limparTec(${dados[i].tecnologiaID})" id="btnLimpar${dados[i].tecnologiaID}">Limpar</a>
                </div>
                <br/>
            `);
            });
        }
    });
}

$("#tecnologia").click(function() {
    if (aux) {
        $.post(enderecoListarTecs, function(dados, status) {
            $("#render").append(`
            <div style="display: flex;">
                <select class="form-control" id="adcTec${dados.id}") onChange="adcArr(${dados.id})">
                    <option value="">Selecione</option>
                    ${dados.map(item => {
                        return `<option key=${item.id} value="${item.id}">${item.nome}</option>`
                    })}
                </select>
                <a class="btn btn-danger" onClick="limpar(${dados.id})" id="btnLimpar${dados.id}">Limpar</a>
            </div>
            <br/>
        `);
        });
        aux = false;
    }
    else {
        alert("Adicione uma tecnologia antes de criar outro campo!");
    }
});

function limpar(id) {
    $(`#adcTec${id}`).hide();
    $(`#btnLimpar${id}`).hide();
    var index = arr.indexOf("" + id);
    arr.splice(index, 1);
    $("#tecId").val(arr);
    aux = true;
}

function limparTec(id) {
    $(`#adcTec${id}`).hide();
    $(`#btnLimpar${id}`).hide();
    var index = arr.indexOf("" + id);
    arr.splice(index, 1);
    $("#tecId").val(arr);
}

function adcArr(point) {
    var select = document.getElementById(`adcTec${point}`);
    $(`#adcTec${point}`).prop("disabled", true);
    arr.push(select.value);
    $("#tecId").val(arr);
    aux = true;
}