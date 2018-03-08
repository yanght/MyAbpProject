layui.use(['form', 'layer', 'table', 'laytpl'], function () {
    var form = layui.form,
        layer = parent.layer === undefined ? layui.layer : top.layer,
        $ = layui.jquery,
        laytpl = layui.laytpl,
        table = layui.table;

    var tableIns = table.render({
        elem: '#auditLogs',
        url: '/Systems/auditLogs',
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
            { field: 'tenantId', title: '租户Id', minWidth: 100, align: "center" },
            { field: 'userId', title: '用户Id', align: 'center' },
            { field: 'serviceName', title: '服务名称', align: 'center', templet: '#activeSwitchTpl', unresize: true },
            { field: 'methodName', title: '方法名称', align: 'center', minWidth: 150 },
            { field: 'parameters', title: '请求参数', align: 'center', minWidth: 150 },
            { field: 'executionTime', title: '执行时间', align: 'center', minWidth: 150 },
            { field: 'clientIpAddress', title: '客户端IP', align: 'center', minWidth: 150 },
            { field: 'clientName', title: '客户端机器名', align: 'center', minWidth: 150 },
            { field: 'browserInfo', title: '浏览器', align: 'center', minWidth: 150 },
            { field: 'customData', title: '自定义信息', align: 'center', minWidth: 150 },
            {
                field: 'exception', title: '异常', align: 'center', minWidth: 150, templet: function (obj) {
                    return JSON.stringify(obj.exception);
                }
            },
            { title: '操作', minWidth: 175, templet: '#auditLogsBar', fixed: "right", align: "center" }
        ]]
    });
})