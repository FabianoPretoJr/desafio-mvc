var arr = [];
var cont = 0;
var aux = true;

$("#tecnologia").click(function() {
    if (aux) {
        cont = cont + 1;
        $.post("https://localhost:5001/Funcionario/Teste", function(dados, status) {
            $("#render").append(`
            <div style="display: flex;">
                <select class="form-control" id="adcTec${cont}") onChange="adcArr(${cont})">
                    <option value="">Selecione</option>
                    ${dados.map(item => {
                        return `<option key=${item.id} value="${item.id}">${item.nome}</option>`
                    })}
                </select>
                <a class="btn btn-danger" onClick="limpar(${cont})" id="btnLimpar${cont}">Limpar</a>
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

function limpar(point) {
    console.log(point);
    $(`#adcTec${point}`).hide();
    $(`#btnLimpar${point}`).hide();
    arr.splice((point - 1), 1);
    $("#tecId").val(arr);
    aux = true;
}

function adcArr(point) {
    var select = document.getElementById(`adcTec${point}`);
    $(`#adcTec${point}`).prop("disabled", true);
    arr.push(select.value);
    $("#tecId").val(arr);
    aux = true;
}