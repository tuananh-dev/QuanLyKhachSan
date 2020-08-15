
function dashboard_Circle(data) {
    var month = data.thang;
    $.ajax({
        type: 'POST',
        url: '/SEP23Team2/api/QuanLy/XuatBaoCaoThongKeTheoThang',
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        data: JSON.stringify(data)
    }).done((data) => {
        var obj = [];
        $.each(data, function (index, val) {
            var rnd = Math.floor(Math.random() * 120) + 70;
            obj.push({ name: val.TenDichVu, y: val.DoanThu, z: rnd });

        });

        Highcharts.chart('circle', {
            chart: {
                type: 'variablepie'
            },
            title: {
                text: 'Thống Kê Doanh Thu Theo Tháng ' + month
            },
            tooltip: {
                headerFormat: '',
                pointFormat: '<span style="color:{point.color}">\u25CF</span> <b> {point.name}</b><br/>' +
                    'Doanh Thu (VND): <b>{point.y}</b><br/>'
            },
            series: [{
                minPointSize: 10,
                innerSize: '20%',
                zMin: 0,
                name: 'countries',
                data: obj
            }]
        });
    }).fail(function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.responseJSON.Message == 'Authorization has been denied for this request.') {
            window.location.href = "/SEP23Team2/404.cshtml";
        }
    })
}

function dashboard_ThreeBar(data, dsthang) {
    var quater = data.quy;
    $.ajax({
        type: 'POST',
        url: '/SEP23Team2/api/QuanLy/XuatBaoCaoThongKeTheoQuy',
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        data: JSON.stringify(data)
    }).done(data => {
        var ten = [];
        var t1 = [];
        var t2 = [];
        var t3 = [];
        var tb = [];
        $.each(data, function (index, val) {
            ten.push(val.TenDichVu);
            t1.push(val.DoanhThu1);
            t2.push(val.DoanhThu2);
            t3.push(val.DoanhThu3);
            tb.push(val.TrungBinh);
        })
        Highcharts.chart('threeBar', {
            title: {
                text: 'Thống Kê Doanh Thu Theo Quý ' + quater
            },
            xAxis: {
                categories: ten
            },
            series: [
                { type: 'column', name: dsthang[0], data: t1 },
                { type: 'column', name: dsthang[1], data: t2 },
                { type: 'column', name: dsthang[2], data: t3 },
                {
                    type: 'spline', name: 'Trung Bình', data: tb,
                    marker: { lineWidth: 2, lineColor: Highcharts.getOptions().colors[3], fillColor: 'white' }
                }
            ]
        });
    }).fail(function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.responseJSON.Message == 'Authorization has been denied for this request.') {
            window.location.href = "/SEP23Team2/404.cshtml";
        }
    })




}

function dashboard_FourBox(dataInput, url, callback) {
    $.ajax({
        type: 'POST',
        url: '/SEP23Team2/api/' + url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        data: JSON.stringify(dataInput)
    }).done(callback).fail(function (jqXHR, textStatus, errorThrown) {
        if (jqXHR.responseJSON.Message == 'Authorization has been denied for this request.') {
            window.location.href = "/SEP23Team2/404.cshtml";
        }
    })
}

function checkTangGiam(percent, progr) {
    var str = '';
    var tg = "Tăng ";
    progr.addClass("progress-bar-green")
    if (percent < 0) {
        tg = "Giảm ";
        progr.addClass("progress-bar-orange")
    }
    var pers = Math.abs(percent);
    pers = pers.toString().split(".");
    str += tg + pers[0] + "% so với ";
    return str;
}
