layui.use(['form', 'layer', 'jquery', 'table', 'laytpl'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        laytpl = layui.laytpl,
        table = layui.table;

    //角色列表
    var tableIns = table.render({
        elem: '#rolesList',
        url: '/roles/roleslist',
        cellMinWidth: 95,
        page: true,
        height: "full-125",
        limits: [10, 15, 20, 25],
        limit: 10,
        id: "userListTable",
        cols: [[
            { type: "checkbox", fixed: "left", width: 50 },
            { field: 'name', title: '角色名称', minWidth: 100, align: "center" },
            {
                field: 'isStatic', title: '是否是静态', minWidth: 100, align: "center", templet: function (d) {
                    return d.isStatic ? "是" : "否";
                }
            },
            { field: 'description', title: '描述', align: 'center', minWidth: 150 },
            { title: '操作', minWidth: 175, templet: '#rolesListBar', fixed: "right", align: "center" }
        ]]
    });

    function addRole(edit) {
        var index = layui.layer.open({
            title: "添加角色",
            type: 2,
            content: "/roles/editrole?roleId=" + (edit != null && edit != undefined ? edit.id : 0),
            success: function (layero, index) {
                var body = layui.layer.getChildFrame('body', index);
                if (edit) {
                    body.find("input[name='Name']").val(edit.name);
                    body.find("input[name='DisplayName']").val(edit.displayName);
                    if (edit.isStatic) {
                        body.find("input[name='IsStatic']").attr("checked","checked");
                    }
                    body.find("input[name='Description']").val(edit.description);
                    $("input[name='Permission']").each(function (index, item) {
                        if (edit.permissions.contains($(item).val())) {
                            $(item).attr("ckeched", "checked");
                        }
                    })
                    form.render();
                }
           
                //绑定解锁按钮的点击事件
                body.find('button#close').on('click', function () {
                    layer.close(index);
                    location.reload();//刷新
                });
            }
        })
        layui.layer.full(index);
        //改变窗口大小时，重置弹窗的宽高，防止超出可视区域（如F12调出debug的操作）
        $(window).on("resize", function () {
            layui.layer.full(index);
        })
    }

    $(".addRoles_btn").click(function () {
        addRole();
    })

    //列表操作
    table.on('tool(rolesList)', function (obj) {
        var layEvent = obj.event,
            data = obj.data;

        if (layEvent === 'edit') { //编辑
            addRole(data);
        } else if (layEvent === 'del') { //删除
            layer.confirm('确定删除此角色？', { icon: 3, title: '提示信息' }, function (index) {
                $.ajax({
                    url: "/roles/deleterole",
                    type: 'POST',//默认以get提交，以get提交如果是中文后台会出现乱码
                    dataType: 'json',
                    data: { roleId: data.id },
                    async: false,
                    success: function (data) {
                        tableIns.reload();
                        layer.close(index);
                    }
                })
            });
        } else if (layEvent === 'look') { //预览
            layer.alert("此功能需要前台展示，实际开发中传入对应的必要参数进行文章内容页面访问")
        }
    });

})
