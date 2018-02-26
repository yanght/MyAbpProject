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
            //{ field: 'userSex', title: '用户性别', align: 'center' },
            //{
            //    field: 'userStatus', title: '用户状态', align: 'center', templet: function (d) {
            //        return d.userStatus == "0" ? "正常使用" : "限制使用";
            //    }
            //},
            //{
            //    field: 'userGrade', title: '用户等级', align: 'center', templet: function (d) {
            //        if (d.userGrade == "0") {
            //            return "注册会员";
            //        } else if (d.userGrade == "1") {
            //            return "中级会员";
            //        } else if (d.userGrade == "2") {
            //            return "高级会员";
            //        } else if (d.userGrade == "3") {
            //            return "钻石会员";
            //        } else if (d.userGrade == "4") {
            //            return "超级会员";
            //        }
            //    }
            //},
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
                            $(item).attr("ckeched", "checked");
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

    //列表操作
    table.on('tool(userList)', function (obj) {
        var layEvent = obj.event,
            data = obj.data;

        if (layEvent === 'edit') { //编辑
            addUser(data);
        } else if (layEvent === 'usable') { //启用禁用
            var _this = $(this),
                usableText = "是否确定禁用此用户？",
                btnText = "已禁用";
            if (_this.text() == "已禁用") {
                usableText = "是否确定启用此用户？",
                    btnText = "已启用";
            }
            layer.confirm(usableText, {
                icon: 3,
                title: '系统提示',
                cancel: function (index) {
                    layer.close(index);
                }
            }, function (index) {
                _this.text(btnText);
                layer.close(index);
            }, function (index) {
                layer.close(index);
            });
        } else if (layEvent === 'del') { //删除
            layer.confirm('确定删除此用户？', { icon: 3, title: '提示信息' }, function (index) {
                // $.get("删除文章接口",{
                //     newsId : data.newsId  //将需要删除的newsId作为参数传入
                // },function(data){
                tableIns.reload();
                layer.close(index);
                // })
            });
        }
    });
})
