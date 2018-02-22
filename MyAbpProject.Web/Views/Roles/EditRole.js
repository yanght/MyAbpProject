layui.use(['form', 'layer'], function () {
    var form = layui.form
    layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery;

    form.on('submit()', function (data) {

        alert(JSON.stringify(data));
        return false;


        var index = layer.load(1);

        $.post("/roles/addrole", data.filed, function (data) {
            layer.close(index);
            if (obj.success) {
                layer.alert("success");
            } else {
                layer.alert("error");
            }
        })
        
        return false;
    })
});