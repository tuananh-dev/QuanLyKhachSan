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
    $(document).ready(function () {
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

                Highcharts.chart('chart', {
                    chart: {
                        type: 'variablepie'
                    },
                    title: {
                        text: 'Thống Kê Doanh Thu Theo Tháng'
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
    })
}

function dashboard_ThreeBar(data, url) {
    $(document).ready(function () {
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
                Highcharts.chart('chart', {
                    title: {
                        text: 'Thống Kê Doanh Thu Theo Quý'
                    },
                    xAxis: {
                        categories: ten
                    },
                    series: [
                        { type: 'column', name: 'Tháng 1', data: t1 },
                        { type: 'column', name: 'Tháng 2', data: t2 },
                        { type: 'column', name: 'Tháng 3', data: t3 },
                        {
                            type: 'spline', name: 'Trung Bình', data: tb,
                            marker: { lineWidth: 2, lineColor: Highcharts.getOptions().colors[3], fillColor: 'white' }
                        }
                    ]
                });

            }
        })
        
    })


}

