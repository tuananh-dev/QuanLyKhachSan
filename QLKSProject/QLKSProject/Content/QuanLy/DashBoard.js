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
function dashboard_Circle(url) {
    $(document).ready(function () {
        $.ajax({
            type: 'POST',
            url: '/api/' + url,
            headers: { 'content-type': 'application/json', 'data-type': 'json' },
            data: JSON.stringify({
                "thang": 7,
                "nam": 2020
            }),
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

//function dashboard_ThreeBar(url) {
//    $(document).ready(function () {
//        $.ajax({
//            type: 'POST',
//            url: '/api/' + url,
//            headers: { 'content-type': 'application/json', 'data-type': 'json' },
//            data: JSON.stringify({
               
//            }),
//            success: function (data) {

//                var obj = [];
//                $.each(data, function (index, val) { })
                

//            }
//        })
//    })
//}

Highcharts.chart('three-bar', {
    title: {
        text: 'Thống Kê Doanh Thu Theo Quý'
    },
    xAxis: {
        categories: ['Thuê Phòng', 'Massage', 'Thuê Xe', 'Giặt Ủi', 'Ăn Uống']
    },
    series: [{
        type: 'column',
        name: 'Tháng 1',
        data: [3, 2, 1, 3, 4]
    }, {
        type: 'column',
        name: 'Tháng 2',
        data: [2, 3, 5, 7, 6]
    }, {
        type: 'column',
        name: 'Tháng 3',
        data: [4, 3, 3, 9, 1]

    }, {
        type: 'spline',
        name: 'Trung Bình',
        data: [3, 2.67, 3, 6.33, 3.33],
        marker: {
            lineWidth: 2,
            lineColor: Highcharts.getOptions().colors[3],
            fillColor: 'white'
        }
    }]
});