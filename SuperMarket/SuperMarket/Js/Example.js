$(document).ready(function () {

    $(".button").button();

    $(".chosen").chosen();
    $("#tabs").tabs();
    $(".Dialog").dialog(
    {
        dialogClass: "no-close",
        buttons:
        {

            "clear": clear,
            "Cancel": close
        }


    }
    )
    
    
    $("#btnSubmit").click(function () {
        var id = $("#txtId").val();
        var item = $(".chosen").val();
        var quant = $("#txtQuant");
        var price = $("#txtPrice").val();
        $(".Dialog").dialog("close");


    })
    $("#btnSales").click(function () {


    })
    $("#btnItems").click(function () {
        $(".Dialog").dialog("close");
        $("#Items").tabs("option", "active", 1);
    })
    $("#btnSale").click(function () {

        $(".Dialog").dialog({
            autoOpen: true
        });

    })




});
function clear() {
    $("#txtQuant").val("");


}
function close() {

    $(".Dialog").dialog("close");
}

