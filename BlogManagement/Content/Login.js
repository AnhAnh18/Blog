$(document).ready(function () {

    var lblLogin = $("#lblLogin");
    lblLogin.hide();
    function valEmail(mail) {
        var re = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
        if (re.test(mail))
            return true;
        return false;
    }

    $("#txtEmail").keyup(function () {
        if (!valEmail($("#txtEmail").val())) {
            lblLogin.show();
            lblLogin.text("Email không hợp lệ!");
            lblLogin.css("color", "red");
        }
        else {
            lblLogin.hide();
        }
    })

    $("#frmLogin").submit(function (e) {
        if (!valEmail($("#txtEmail").val())) {
            e.preventDefault();
        }
    });
    
});