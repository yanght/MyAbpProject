layui.use(['form', 'layer', 'jquery'], function () {
    var form = layui.form
    layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery;

    form.on('submit()', function (data) {
        var url = '/roles/addrole';
        var roleId = $("#roleId").val();
        data.field.Permissions = [];

        var premissionCheckBoxs = $("input[name='Permission']:checked");
        if (premissionCheckBoxs) {
            $.each(premissionCheckBoxs, function (index, item) {
                data.field.Permissions.push($(item).val());
            })
        }
        //alert(JSON.stringify(data.field));
        if (roleId > 0) {
            url = '/roles/updaterole'
        }
        $.ajax({
            url: url,
            type: 'POST',//默认以get提交，以get提交如果是中文后台会出现乱码
            dataType: 'json',
            data: data.field,
            async: false,
            success: function (data) {
                if (data.success) {
                    layer.alert("success", function (index) {
                        $("#close").click();
                        layer.close(index);
                    });
                } else {
                    layer.alert(data.error);
                }
            }
        })

        return false;
    })

    form.on('checkbox(roleMenu)', function (data) {


        console.log(data);

        form.render('checkbox');
    })
});