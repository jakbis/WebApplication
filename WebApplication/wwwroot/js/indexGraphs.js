var Sweets = {
    x: [2018, 2019, 2020, 2021, 2022,2023,2024],
    y: [18, 18, 28, 32],
    type: 'scatter'
};


var Salty = {
    x: [2018, 2019, 2020, 2021, 2022, 2023, 2024],
    y: [16, 20, 25, 30],
    type: 'scatter'
};


var Cakes = {
    x: [2018, 2019, 2020, 2021, 2022, 2023, 2024],
    y: [10, 20, 16, 25],
    type: 'scatter'
};

var data = [Sweets, Salty, Cakes];

Plotly.newPlot('statistic', data);
