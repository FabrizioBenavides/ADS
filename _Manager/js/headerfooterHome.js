//Elongoria

function crearTablaFooter()
{
	document.write("<table width=\"780\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
	document.write("<tr><td class=\"tdbottom\">Sistema Administrador de Fotolab  - &copy; " + (new Date()).getFullYear() + " Farmacias Benavides</td></tr></table>");
}

function crearTablaHeaderPop()
{
	document.write("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
	document.write("<tr><td width=\"100%\"><img src=\"images/imgBenavidesLogoPop.gif\" width=\"152\" height=\"51\"></td></tr></table>");
	document.write("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
	document.write("<tr><td class=\"tdclosewindow\">" + getNowDate()+" </td></tr></table>");
}

function getNowDate(){
   var d, s = "";
   d = new Date();
		//dia
		if (d.getDate()<10)
		{s +="0"+ d.getDate() + "/";}
		else{s += d.getDate() + "/";}
		//mes
		if (d.getMonth()<10)
		{s +="0"+ d.getMonth() + "/";}
		else{s += d.getMonth() + "/";}
		//año
		 s += d.getFullYear();
		//hora
		s += "  ";
		if (d.getHours()<10)
		{s +="0"+ d.getHours() + ":";}
		else{s += d.getHours() + ":";}

		if (d.getMinutes()<10)
		{s +="0"+ d.getMinutes() + ":";}
		else{s += d.getMinutes() + ":";}

		if (d.getSeconds()<10)
		{s +="0"+ d.getSeconds() ;}
		else{s += d.getSeconds() ;}

   return(s);
}