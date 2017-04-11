function displayEvens(){
				var result = new Array();
				var begin = +document.getElementById("start").value;
				var stop = +document.getElementById("end").value;
				var increment = +document.getElementById("step").value;
				if (begin == "" || isNaN(begin)){
					alert("Starting value must be a number.");
					return false;
				}
				if (stop == "" || isNaN(stop)){
					alert("Ending value must be a number.");
					return false;
				}
				if (increment == "" || isNaN(increment)){
					alert("Step value must be a number.");
					return false;
				}
					for (var i = begin;i <= stop;i=i + increment){
						if (i%2 == 0){
							result.push(i);
							
							}
					}
					document.getElementById("test").innerText=result;
			}