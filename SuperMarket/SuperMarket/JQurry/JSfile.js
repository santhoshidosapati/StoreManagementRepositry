$(document).ready(function () {
    $("#tabs").tabs();
    $("#btntabLogin").button();

    $("#first-div").dialog({
        autoOpen: false,
        modal: true,
        draggable: false,
        resizable: false
    });

    $("#btnjqlogin").click(function(){

    })





    AjaxCall('Main.aspx?GetUsers=true', 'POST', BindUser, Failure);


    $(".chosen-selec").chosen({
        disable_search_threshold: 5,
        placeholder_text: "My language message.", 
        no_results_text: "Oops, nothing found!",
        allow_single_deselect: true,
        search_contains: true
    });

    $("#btntabLogin").click(function () {

        $("#first-div").dialog("open");
        return false;
    });

    

})
function BindUser(data) {
    var users = JSON.parse(data);
    BindDropDown("#ddlselect", users, "StudentName", "Studentid");
}

function Failure(XHR, msg, exception) {
    alert(exception);
}
function BindDropDown(selector, data, dataMember, valueMember) {
    $(selector).empty();
    for (var obj in data) {
        $(selector).append("<option value = " + data[obj][valueMember] + ">" + data[obj][dataMember] + "</option>")
    }
    $(selector).trigger("chosen:updated");
}
function AjaxCall(url, callType, successCall, FailureCallBack) {
    $.ajax({
        url: url,
        type: callType,
        async: true,
        success: successCall,
        error: FailureCallBack
    });
} function Ajaxcallforinsert(url, callType, successCall, FailureCallBack) {
    $.ajax({
        url: ,
        type: callType,
        async: true,
        success: successCall,
        error: FailureCallBack
    });
}
