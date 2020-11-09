$("#tecnologia").click(function(event) {
    event.preventDefault();

    $.post("https://localhost:5001/Funcionario/Teste", function(dados, status) {
        $("#render").append(`
        <br/><br/>
        <label>Unidade GFT</label>
        <select class="form-control" asp-for="GftID" asp-items='@(new SelectList(@ViewBag.gfts, "Id", "Nome"))'></select>
        <span asp-validation-for="GftID"></span><br/>
    `);
    });
});