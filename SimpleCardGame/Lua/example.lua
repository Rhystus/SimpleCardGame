--this is lua script file, it will call lua in C#
--Function out welcome
function hello()
	print("welcome lvtutorial.com");
end
 
--Function return a string
function returnHello()
	return "lvtutorial.com";
end
 
--Function return total of two numbers
function sumAandB(a, b)
	return a+b;
end
 
--Function return table
function getTable()
	local ltable = {
		username = "lvtutorial.com",
		fullname = "Welcome lvtutorial",
		age = 20
	};	
	--table.insert(ltable, ltable1);
	return ltable;
end;