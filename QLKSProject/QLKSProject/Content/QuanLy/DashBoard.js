//$(document).ready(function () {
//    new Chart(document.getElementById("bar-chart"), {
//        type: 'bar',
//        data: {
//            labels: ['Red', 'Blue', 'Yellow', 'Green', 'Purple', 'Orange'],
//            datasets: [{
//                label: '# of Votes',
//                data: [12, 19, 3, 5, 2, 3],
//                backgroundColor: [
//                    'rgba(255, 99, 132, 0.2)',
//                    'rgba(54, 162, 235, 0.2)',
//                    'rgba(255, 206, 86, 0.2)',
//                    'rgba(75, 192, 192, 0.2)',
//                    'rgba(153, 102, 255, 0.2)',
//                    'rgba(255, 159, 64, 0.2)'
//                ],
//                borderColor: [
//                    'rgba(255, 99, 132, 1)',
//                    'rgba(54, 162, 235, 1)',
//                    'rgba(255, 206, 86, 1)',
//                    'rgba(75, 192, 192, 1)',
//                    'rgba(153, 102, 255, 1)',
//                    'rgba(255, 159, 64, 1)'
//                ],
//                borderWidth: 1
//            }]
//        },
//        options: {
//            scales: {
//                yAxes: [{
//                    ticks: {
//                        beginAtZero: true
//                    }
//                }]
//            }
//        }
//    });
//});
//$(document).ready(function () {
//    var ctx = document.getElementById('myChart').getContext('2d');
//    var myChart = new Chart(ctx, {
//        type: 'line',
//        data: {
//            labels: ['M', 'T', 'W', 'T', 'F', 'S', 'S'],
//            datasets: [{
//                label: 'Cost',
//                data: [
//                    randomScalingFactor(),
//                    randomScalingFactor(),
//                    randomScalingFactor(),
//                    randomScalingFactor(),
//                    randomScalingFactor(),
//                    randomScalingFactor(),
//                    randomScalingFactor()
//                ],
//                backgroundColor: "rgba(255,61,103,0.3)"
//            }, {
//                label: 'Earning',
//                data: [
//                    randomScalingFactor(),
//                    randomScalingFactor(),
//                    randomScalingFactor(),
//                    randomScalingFactor(),
//                    randomScalingFactor(),
//                    randomScalingFactor(),
//                    randomScalingFactor()
//                ],
//                backgroundColor: "rgba(34,206,206,0.3)"
//            }]
//        }
//    });
//});
function dashboard_Circle(data, url) {
    var thang = data.thang;
    $.ajax({
        type: 'POST',
        url: '/api/' + url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
            xhr.setRequestHeader("contentType", "application/json;charset=UTF-8");
        },
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        data: JSON.stringify(data),
        success: function (data) {

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
                    text: 'Thống Kê Doanh Thu Theo Tháng ' + thang
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
        }
    })
}

function dashboard_ThreeBar(data, url, thang) {
    var quater = data.quy;
    $.ajax({
        type: 'POST',
        url: '/api/' + url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
            xhr.setRequestHeader("contentType", "application/json;charset=UTF-8");
        },
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        data: JSON.stringify(data),
        success: function (data) {
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
                    { type: 'column', name: thang[0], data: t1 },
                    { type: 'column', name: thang[1], data: t2 },
                    { type: 'column', name: thang[2], data: t3 },
                    {
                        type: 'spline', name: 'Trung Bình', data: tb,
                        marker: { lineWidth: 2, lineColor: Highcharts.getOptions().colors[3], fillColor: 'white' }
                    }
                ]
            });

        }
    })




}

function dashboard_FourBox(dataInput, url, position) {
    $.ajax({
        type: 'POST',
        url: '/api/' + url,
        beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', 'bearer ' + sessionStorage.getItem('accessToken'));
        },
        headers: { 'content-type': 'application/json', 'data-type': 'json' },
        data: JSON.stringify(dataInput),
        success: function (data) {
            switch (url) {
                case 'QuanLy/SoSanhSoSanhThongKeTheoThang':
                    
                    position.tptt.html(checkTangGiam(data.TienThuePhong, position.progr_tptt) + " tháng trước");
                    position.progr_tptt.addClass("width-" + Math.abs(data.TienThuePhong));

                    position.dvtt.html(checkTangGiam(data.TienDichVu, position.progr_dvtt) + " tháng trước");
                    position.progr_dvtt.addClass("width-" + Math.abs(data.TienDichVu));
                    break;
                case 'QuanLy/SoSanhSoSanhThongKeTheoQuy':
                    position.tptq.html(checkTangGiam(data.TienThuePhong, position.progr_tptq) + " quý trước");
                    position.progr_tptq.addClass("width-" + Math.abs(data.TienThuePhong));
                    position.dvtq.html(checkTangGiam(data.TienDichVu, position.progr_dvtq) + " quý trước");
                    position.progr_dvtq.addClass("width-" + Math.abs(data.TienDichVu));
                    break;

            }
        }
    })
}

function checkTangGiam(percent,progr) {
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
