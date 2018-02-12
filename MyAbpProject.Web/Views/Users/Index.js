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
        page: false,
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

})
