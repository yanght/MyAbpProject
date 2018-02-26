layui.use(['form', 'layer'], function () {
    var form = layui.form
    layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery;

    form.on("submit(addUser)", function (data) {
        //弹出loading
        var index = top.layer.msg('数据提交中，请稍候', { icon: 16, time: false, shade: 0.8 });
        data.field.RoleNames = [];
        var rolenamesCheckBoxs = $("input[name='Rolename']:checked");
        if (rolenamesCheckBoxs) {
            $.each(rolenamesCheckBoxs, function (index, item) {
                data.field.RoleNames.push($(item).val());
            })
        }
        var url = '/users/adduser';
        var userId = $("#userId").val();
        if (userId > 0) {
            url = '/users/updateuser'
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


        //setTimeout(function () {
        //    top.layer.close(index);
        //    top.layer.msg("用户添加成功！");
        //    layer.closeAll("iframe");
        //    //刷新父页面
        //    parent.location.reload();
        //}, 2000);
        return false;
    })

    //格式化时间
    function filterTime(val) {
        if (val < 10) {
            return "0" + val;
        } else {
            return val;
        }
    }
    //定时发布
    var time = new Date();
    var submitTime = time.getFullYear() + '-' + filterTime(time.getMonth() + 1) + '-' + filterTime(time.getDate()) + ' ' + filterTime(time.getHours()) + ':' + filterTime(time.getMinutes()) + ':' + filterTime(time.getSeconds());

})