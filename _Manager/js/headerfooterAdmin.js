// Variables del encabezado de todas las páginas
var strUsuarioNombre = "Sin nombre de usuario";
var strFechaHora = "Sin fecha y hora";

function MM_reloadPage(init) {  //reloads the window if Nav4 resized
  if (init==true) with (navigator) {if ((appName=="Netscape")&&(parseInt(appVersion)==4)) {
    document.MM_pgW=innerWidth; document.MM_pgH=innerHeight; onresize=MM_reloadPage; }}
  else if (innerWidth!=document.MM_pgW || innerHeight!=document.MM_pgH) location.reload();
}
MM_reloadPage(true);

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
function Pop(url, width, height) {
  var Win = window.open(url,"Pop",'width=' + width + ',height=' + height + ',left=250,top=130,resizable=no,scrollbars=auto,menubar=no,status=no' );
}

function crearTablaHeader() 
{
	document.write("<table width=\"780\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
	document.write("<tr><td width=\"75\" class=\"tdbranchnumber\">&nbsp;</td>");
	document.write("<td width=\"641\" class=\"tdbranchname\">&nbsp;</td>");
	document.write("<td width=\"64\" class=\"tdsignoutbutton\"><a href=\"../Default.aspx?strCmd=Salir\" onMouseOut=\"MM_swapImgRestore()\" onMouseOver=\"MM_swapImage('Image1','','images/bsalir_on.gif',1)\"><img src=\"images/bsalir_off.gif\" alt=\"salir\" name=\"Image1\" width=\"65\" height=\"19\" border=\"0\"></a></td></tr></table>");
	document.write("<table width=\"780\" height=\"60\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
	document.write("<tr><td width=\"206\" rowspan=\"2\" class=\"tdlogo\"><img src=\"images/imgBenavidesLogo.gif\" width=\"206\" height=\"60\"></td>");
	document.write("<td width=\"574\" height=\"26\" align=\"right\"><img src=\"images/imgSistemaLogo.gif\" width=\"218\" height=\"31\"></td></tr>");
	document.write("<tr><td width=\"574\" height=\"21\" valign=\"middle\" class=\"tdusername\">" + strUsuarioNombre + "</td></tr></table>");
	document.write("<table width=\"780\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
	document.write("<tr><td>HELP</td></tr>");
	document.write("<tr><td class=\"tdnavigate\">&nbsp;</td>");
	document.write("<td class=\"tddateandtime\">" + strFechaHora + "</td></tr></table>");
}

function crearTablaFooter()
{
	document.write("<table width=\"780\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
	document.write("<tr><td class=\"tdbottom\">Administrador del Sistema Concentrador CTX - &copy; " + (new Date()).getFullYear() + " Farmacias Benavides</td></tr></table>");
}

function crearTablaHeaderPop()
{
	document.write("<table width=\"580\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
	document.write("<tr><td width=\"152\"><img src=\"images/imgBenavidesLogoPop.gif\" width=\"152\" height=\"51\"></td>");
	document.write("<td align=\"right\"><img src=\"images/imgSistemaLogoPop.gif\" width=\"162\" height=\"51\"></td></tr></table>");
	document.write("<table width=\"600\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
	document.write("<tr><td class=\"tdclosewindow\">x <a href=\"#\" onClick=\"window.close();\">cerrar ventana </a> </td></tr></table>");
}

function crearTablaFooterPop()
{
	document.write("<div style='position:absolute;top:465'>");
	document.write("<table width=\"600\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
	document.write("<tr><td class=\"tdbottompop\">Administrador del Sistema Concentrador CTX  &copy; " + (new Date()).getFullYear() + " Farmacias Benavides</td></tr></table>");
document.write("</div>");
}

