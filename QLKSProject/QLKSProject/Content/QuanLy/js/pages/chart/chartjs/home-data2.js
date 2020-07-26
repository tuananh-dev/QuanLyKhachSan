//$(document).ready(function() 
//		{
//	new Chart(document.getElementById("bar-chart"), {
//		type: 'bar',
//		data: {
//			labels: ["2013", "2014", "2015", "2016"],
//			datasets: [
//			           {
//			        	   label: "Cost",
//			        	   backgroundColor: "#01B8AA",
//			        	   data: [
//			                      randomScalingFactor(),
//			                      randomScalingFactor(),
//			                      randomScalingFactor(),
//			                      randomScalingFactor(),
//			                      randomScalingFactor(),
//			                      randomScalingFactor(),
//			                      randomScalingFactor()
//			                  ]
//			           }, {
//			        	   label: "Earing",
//			        	   backgroundColor: "#5F6B6D",
//			        	   data: [
//			                      randomScalingFactor(),
//			                      randomScalingFactor(),
//			                      randomScalingFactor(),
//			                      randomScalingFactor(),
//			                      randomScalingFactor(),
//			                      randomScalingFactor(),
//			                      randomScalingFactor()
//			                  ]
//			           }
//			           ]
//		},
//		options: {
//			title: {
//				display: true,
//				text: 'University Earing & Cost (in Millions)'
//			}
//		}
//	});
//		});
//$(document).ready(function() 
//		{
//	var ctx = document.getElementById('myChart').getContext('2d');
//	var myChart = new Chart(ctx, {
//		type: 'line',
//		data: {
//			labels: ['M', 'T', 'W', 'T', 'F', 'S', 'S'],
//			datasets: [{
//				label: 'Cost',
//				data: [
//		                randomScalingFactor(),
//		                randomScalingFactor(),
//		                randomScalingFactor(),
//		                randomScalingFactor(),
//		                randomScalingFactor(),
//		                randomScalingFactor(),
//		                randomScalingFactor()
//		            ],
//				backgroundColor: "rgba(255,61,103,0.3)"
//			}, {
//				label: 'Earning',
//				data: [
//		                randomScalingFactor(),
//		                randomScalingFactor(),
//		                randomScalingFactor(),
//		                randomScalingFactor(),
//		                randomScalingFactor(),
//		                randomScalingFactor(),
//		                randomScalingFactor()
//		            ],
//				backgroundColor: "rgba(34,206,206,0.3)"
//			}]
//		}
//	});
//		});
Highcharts.chart('container', {
    chart: {
        type: 'variablepie'
    },
    title: {
        text: 'Countries compared by population density and total area.'
    },
    tooltip: {
        headerFormat: '',
        pointFormat: '<span style="color:{point.color}">\u25CF</span> <b> {point.name}</b><br/>' +
            'Area (square km): <b>{point.y}</b><br/>' +
            'Population density (people per square km): <b>{point.z}</b><br/>'
    },
    series: [{
        minPointSize: 10,
        innerSize: '20%',
        zMin: 0,
        name: 'countries',
        data: [{
            name: 'Spain',
            y: 505370,
            z: 92.9
        }, {
            name: 'France',
            y: 551500,
            z: 118.7
        }, {
            name: 'Poland',
            y: 312685,
            z: 124.6
        }, {
            name: 'Czech Republic',
            y: 78867,
            z: 137.5
        }, {
            name: 'Italy',
            y: 301340,
            z: 201.8
        }, {
            name: 'Switzerland',
            y: 41277,
            z: 214.5
        }, {
            name: 'Germany',
            y: 357022,
            z: 235.6
        }]
    }]
});
