﻿

function drawMap(ctx) {
	var img = document.getElementById("backgroundMap");
	ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
	
	
}
function drawPoint(ctx, x, y) {

	// bigger circle:
	ctx.beginPath();
	ctx.fillStyle = "yellow";
	ctx.arc(x, y, 5, 0, 2 * Math.PI);
	ctx.fill();
	// smaller circle:
	ctx.beginPath();
	ctx.fillStyle = "red";
	ctx.arc(x, y, 3, 0, 2 * Math.PI);
	ctx.fill();
}

// main:
var canvas = document.getElementById("mainCanvas");
canvas.width = window.innerWidth;
canvas.height = window.innerHeight;
var ctx = canvas.getContext('2d');
var x = Math.abs(document.getElementById('xLocation').innerHTML) + 200;
var y = Math.abs(document.getElementById('yLocation').innerHTML) + 200;

drawMap(ctx);
drawPoint(ctx, x , y);
