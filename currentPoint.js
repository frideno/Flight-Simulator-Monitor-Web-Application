var canvas = document.getElementById("mainCanvas");
var ctx = canvas.getContext("2d");

ctx.beginPath();
ctx.arc(100, 11575, 220, 0, 2 * Math.PI);
ctx.stroke();