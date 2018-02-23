layui.use(['form', 'layer', 'jquery','table', 'laytpl'], function () {
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
            title: "添加文章",
            type: 2,
            content: "/roles/editrole?roleId=0",
            success: function (layero, index) {
                var body = layui.layer.getChildFrame('body', index);
                if (edit) {
                    body.find(".newsName").val(edit.newsName);
                    body.find(".abstract").val(edit.abstract);
                    body.find(".thumbImg").attr("src", edit.newsImg);
                    body.find("#news_content").val(edit.content);
                    body.find(".newsStatus select").val(edit.newsStatus);
                    body.find(".openness input[name='openness'][title='" + edit.newsLook + "']").prop("checked", "checked");
                    body.find(".newsTop input[name='newsTop']").prop("checked", edit.newsTop);
                    form.render();
                }
                setTimeout(function () {
                    layui.layer.tips('点击此处返回文章列表', '.layui-layer-setwin .layui-layer-close', {
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

    $(".addRoles_btn").click(function () {
        addRole();
    })

})
