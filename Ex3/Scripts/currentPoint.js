

function drawMap(ctx) {
	var img = document.getElementById("backgroundMap");
	ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
	
	
}
function drawPoint(ctx, x, y) {

	// bigger circle:
	ctx.beginPath();
	ctx.fillStyle = "blue";
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
var x = document.getElementById('xLocation').innerHTML;
var y = document.getElementById('yLocation').innerHTML;

drawMap(ctx);
drawPoint(ctx, x , y);
