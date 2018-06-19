$(document).ready(function () {

    var lblVerify = $("#lblVerify");
    var lblRegister = $("#lblRegister");
    var lblEmail = $("#lblEmail");
    lblEmail.hide();
    lblVerify.hide();
    lblRegister.hide();

    $("#btnSendCode").click(function () {

        if (mailIsEmpty()) {
            lblRegister.show();
            lblRegister.text("Chưa nhập Email!");
            return;
        }

        lblVerify.show();
        lblVerify.text("Xin chờ...");
        lblVerify.css("color", "green");

        $.ajax({
            url: "/Account/Send",
            type: "post",
            data: { email: $("#txtEmail").val() },
            success: function (data) {
                lblVerify.show();
                lblVerify.text("Gửi mã thành công!");
                lblVerify.css("color", "green");
            },
            error: function () {
                lblVerify.show();
                lblVerify.text("Gửi mã không thành công!");
                lblVerify.css("color", "red");
            }
        });
    });

    $("#txtEmail").blur(function () {
        $.ajax({
            url: "/Account/EmailIsExists",
            type: "post",
            data: { email: $("#txtEmail").val() },
            success: function (data) {
                if (data == "True") {
                    lblEmail.show();
                    lblEmail.text("Email đã tồn tại!");
                }
                else {
                    lblEmail.hide();
                }
            },
            error: function () {
                lblVerify.show();
                lblVerify.text("Gửi mã không thành công!");
                lblVerify.css("color", "red");
            }
        });
    });

    function mailIsEmpty() {
        if ($("#txtEmail").val().length == 0)
            return true;
        return false;
    }

    function checkPassMatch() {
        if ($("#txtPass").val().length < 6) {
            lblRegister.show();
            lblRegister.text("Mật khẩu phải dài hơn 6 kí tự!");
            return false;
        }
        if ($("#txtPass").val() != $("#txtConfirmPass").val()) {
            lblRegister.show();
            lblRegister.text("Mật khẩu không khớp!");
            return false;
        }
        return true;
    }
    
    function valEmail(mail) {
        var re = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
        if (re.test(mail))
            return true;
        return false;
    }

    $("#txtEmail").keyup(function () {
        if (!valEmail($("#txtEmail").val())) {
            lblEmail.show();
            lblEmail.text("Email không hợp lệ!");
            lblEmail.css("color", "red");
        }
        else {
            lblEmail.hide();
        }
    })

    $("#frmRegister").submit(function (e) {
        if (!valEmail($("#txtEmail").val()) || !checkPassMatch()) {
            e.preventDefault();
        }
    });

});