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
            content: "/users/EditUser?roleId=" + (edit != null && edit != undefined ? edit.id : 0),
            success: function (layero, index) {
                var body = layui.layer.getChildFrame('body', index);
                if (edit) {
                    body.find(".userName").val(edit.userName);  //登录名
                    body.find(".userEmail").val(edit.userEmail);  //邮箱
                    body.find(".userSex input[value=" + edit.userSex + "]").prop("checked", "checked");  //性别
                    body.find(".userGrade").val(edit.userGrade);  //会员等级
                    body.find(".userStatus").val(edit.userStatus);    //用户状态
                    body.find(".userDesc").text(edit.userDesc);    //用户简介
                    form.render();
                }
                setTimeout(function () {
                    layui.layer.tips('点击此处返回用户列表', '.layui-layer-setwin .layui-layer-close', {
                        tips: 3
                    });
                }, 500)
            }
        })
        layui.layer.full(index);
        //改变窗口大小时，重置弹窗的宽高，防止超出可视区域（如F12调出debug的操作）
        $(window).on("resize", function () {
            layui.layer.full(index);
        })
    }

    $(".addUser_btn").click(function () {
        addUser();
    })
})
