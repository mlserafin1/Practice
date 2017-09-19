function sumBetween(){
		var x=+document.getElementById("start").value;
		var y=+document.getElementById("end").value;
		var sum=0;
		var count=0;
		
		if(x<0 || y<0){
			alert("Starting and ending numbers must be positive.");
			return false;
		}
		if(y<=x){
			alert("Ending number must be greater than starting number.");
			return false;
		}
		for(var i=x;i<=y;i++){
				sum=sum+i;
				count=count+1;
		}
		
		document.getElementById("to").innerText=count;
		document.getElementById("st").innerText=x;
		document.getElementById("en").innerText=y;
		document.getElementById("su").innerText=sum;
}
		