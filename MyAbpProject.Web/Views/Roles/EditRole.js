layui.use(['form', 'layer', 'jquery'], function () {
    var form = layui.form
    layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery;

    form.on('submit()', function (data) {

        data.field.Permissions = [];
        var premissionCheckBoxs = $("input[name='Permission']:checked");
        if (premissionCheckBoxs) {
            $.each(premissionCheckBoxs, function (index, item) {
                data.field.Permissions.push($(item).val());
            })
        }
        alert(JSON.stringify(data.field));

        $.ajax({
            url: '/roles/addrole',
            type: 'POST',//默认以get提交，以get提交如果是中文后台会出现乱码
            dataType: 'json',
            data: data.field,
            async: false,
            success: function (data) {
                if (data.success) {
                    layer.alert("success", function (index) {
                        layer.close(index);
                        var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
                        parent.layer.close(index); //再执行关闭   
                    });
                } else {
                    layer.alert(data.error);
                }
            }
        })

        return false;
    })
});