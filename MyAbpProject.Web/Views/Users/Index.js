layui.use(['form', 'layer', 'table', 'laytpl'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        laytpl = layui.laytpl,
        table = layui.table;

    //用户列表
    var tableIns = table.render({
        elem: '#userList',
        url: '/users/userlist',
        cellMinWidth: 95,
        page: true,
        request: {
            pageName: 'SkipCount' //页码的参数名称，默认：page
            , limitName: 'MaxResultCount' //每页数据量的参数名，默认：limit
        },
        height: "full-125",
        limits: [10, 15, 20, 25],
        limit: 10,
        id: "userListTable",
        cols: [[
            { type: "checkbox", fixed: "left", width: 50 },
            { field: 'userName', title: '用户名', minWidth: 100, align: "center" },
            {
                field: 'emailAddress', title: '用户邮箱', minWidth: 200, align: 'center', templet: function (d) {
                    return '<a class="layui-blue" href="mailto:' + d.emailAddress + '">' + d.emailAddress + '</a>';
                }
            },
            { field: 'phoneNumber', title: '手机', align: 'center' },
            { field: 'isActive', title: '用户状态', align: 'center', templet: '#activeSwitchTpl', unresize: true },
            { field: 'lastLoginTime', title: '最后登录时间', align: 'center', minWidth: 150 },
            { title: '操作', minWidth: 175, templet: '#userListBar', fixed: "right", align: "center" }
        ]]
    });

    //添加用户
    function addUser(edit) {
        var index = layui.layer.open({
            title: "添加用户",
            type: 2,
            content: "/users/EditUser?userId=" + (edit != null && edit != undefined ? edit.id : 0),
            success: function (layero, index) {
                var body = layui.layer.getChildFrame('body', index);
                if (edit) {
                    body.find("input[name='UserName']").val(edit.userName);
                    body.find("input[name='Name']").val(edit.name);
                    body.find("input[name='Surname']").val(edit.surname);
                    body.find("input[name='PhoneNumber']").val(edit.phoneNumber);
                    body.find("input[name='EmailAddress']").val(edit.emailAddress);
                    body.find("input[name='Password']").text(edit.password);
                    if (edit.isActive) {
                        body.find("input[name='IsActive']").attr("checked", "checked");
                    }
                    $("input[name='Rolename']").each(function (index, item) {
                        if (edit.roles.contains($(item).val())) {
                            $(item).attr("checked", "checked");
                        }
                    })
                    form.render();
                }
                //绑定解锁按钮的点击事件
                body.find('button#close').on('click', function () {
                    layer.close(index);
                    location.reload();//刷新
                })
            }
        });

        layui.layer.full(index);
        //改变窗口大小时，重置弹窗的宽高，防止超出可视区域（如F12调出debug的操作）
        $(window).on("resize", function () {
            layui.layer.full(index);
        })
    }

    $(".addUser_btn").click(function () {
        addUser();
    })

    //搜索
    $(".search_btn").on("click", function () {

        table.reload("userListTable", {
            page: {
                curr: 1 //重新从第 1 页开始
            },
            where: {
                UserName: $("input[name='UserName']").val(),  //搜索的关键字
                PhoneNumber: $("input[name='PhoneNumber']").val(),
                IsActive: $("select[name='IsActive']").val()
            }
        })

    });

    //批量删除
    $(".delAll_btn").click(function () {
        var checkStatus = table.checkStatus('userListTable'),
            data = checkStatus.data,
            userIds = [];
        if (data.length > 0) {
            for (var i in data) {
                userIds.push(data[i].id);
            }
            layer.confirm('确定删除选中的用户？', { icon: 3, title: '提示信息' }, function (index) {

                alert(userIds);

                tableIns.reload();
                layer.close(index);
            })
        } else {
            layer.msg("请选择需要删除的用户");
        }
    })

    //列表操作
    table.on('tool(userList)', function (obj) {
        var layEvent = obj.event,
            data = obj.data;

        if (layEvent === 'edit') { //编辑
            addUser(data);
        } else if (layEvent === 'del') { //删除
            layer.confirm('确定删除此用户？', { icon: 3, title: '提示信息' }, function (index) {
                $.post("/users/deleteuser", {
                    userId: data.id  //将需要删除的userId作为参数传入
                }, function (data) {
                    if (data.success) {
                        tableIns.reload();
                        layer.close(index);
                    } else {
                        layer.msg(data.error.message);
                    }
                })
            });
        }
    });

    //监听用户状态操作
    form.on('switch(isActive)', function (obj) {
        $.post("/users/changeuserstatus", { userId: this.value }, function (result) {
            if (result.success) {
                layer.msg("success")
            } else {
                layer.msg(result.error.msg)
            }
        })
    });
})
