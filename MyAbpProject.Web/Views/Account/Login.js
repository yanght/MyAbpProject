﻿layui.use(['form', 'layer', 'jquery'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer
    $ = layui.jquery;

    $(".loginBody .seraph").click(function () {
        layer.msg("这只是做个样式，至于功能，你见过哪个后台能这样登录的？还是老老实实的找管理员去注册吧", {
            time: 5000
        });
    })

    //登录按钮
    form.on("submit(login)", function (data) {
        var _this = $(this);
        $.ajax({
            url: "/account/login",
            type: 'POST',//默认以get提交，以get提交如果是中文后台会出现乱码
            dataType: 'json',
            data: data.field,
            async: false,
            success: function (data) {
                window.location.href = data.targetUrl;
            },
            error: function (data) {
                layer.alert(data.responseJSON.error.message);

            }
        })

        return false;
    })

    //表单输入效果
    $(".loginBody .input-item").click(function (e) {
        e.stopPropagation();
        $(this).addClass("layui-input-focus").find(".layui-input").focus();
    })
    $(".loginBody .layui-form-item .layui-input").focus(function () {
        $(this).parent().addClass("layui-input-focus");
    })
    $(".loginBody .layui-form-item .layui-input").blur(function () {
        $(this).parent().removeClass("layui-input-focus");
        if ($(this).val() != '') {
            $(this).parent().addClass("layui-input-active");
        } else {
            $(this).parent().removeClass("layui-input-active");
        }
    })
})
