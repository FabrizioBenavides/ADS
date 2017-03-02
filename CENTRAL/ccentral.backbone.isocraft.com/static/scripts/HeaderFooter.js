function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}

function strRCookie(nombre) {
   var lsRegExp = /\+/g;
   
   a = document.cookie.substring(document.cookie.indexOf(nombre + '=') + nombre.length + 1,document.cookie.length);
   if(a.indexOf(';') != -1)a = unescape(a.substring(0,a.indexOf(';')));
   
   
   return a.replace(lsRegExp, " ");  

} 

function crearTablaHeader() 
{
   // si se cerro la sesion lo manda a la firma
   if(strRCookie("intUsuarioId")=="0"){
       window.location = "/Default.aspx";
       return(true);
   }
              
   strHeaderCLId = strRCookie("strCentroLogisticoId");
   strHeaderSucNom = strRCookie("strSucursalNombre") + " (" + strRCookie("intCompaniaId") + strRCookie("intSucursalId") + ")";
   strHeaderEmpNom = strRCookie("strEmpleadoNombre");
   strHeaderGpoNom = strRCookie("strGrupoUsuarioNombre");
   strHeaderCadena = strRCookie("strCadenaImagen");
   
   document.write("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
   document.write("<tr>");
   document.write("<td width=\"78\"  class=\"tdnodesucursal\">"   + strHeaderCLId + "</td>");
   document.write("<td width=\"515\" class=\"tdnombresucursal\">" + strHeaderSucNom + "</td>");
   document.write("<td width=\"182\" class=\"tdbotonestop\" align=\"right\"><a href=\"javascript:cmdSalirImg_onclick()\" onMouseOut=\"MM_swapImgRestore()\" onMouseOver=\"MM_swapImage('Image1','','../static/images/bsalir_on.gif',1)\"><img src=\"../static/images/bsalir_off.gif\" alt=\"salir\" name=\"Image1\" width=\"65\" height=\"19\" border=\"0\"></a><a href=\"#\" onMouseOut=\"MM_swapImgRestore()\" onMouseOver=\"MM_swapImage('Image2','','../static/images/bayuda_on.gif',1)\"><img src=\"../static/images/bayuda_off.gif\" alt=\"ayuda\" name=\"Image2\" width=\"65\" height=\"19\" border=\"0\"></a></td>");
   document.write("</tr>");
   document.write("</table>");
   
   document.write("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
   document.write("<tr>");
   document.write("<td width=\"593\" class=\"tdlogo\" rowspan=\"2\"><img src=\"../static/images/" + strHeaderCadena + "/logo.gif\" width=\"255\" height=\"48\"></td>");
   document.write("<td width=\"182\" class=\"tdnombreusuario\" >" + strHeaderEmpNom + "</td>");
   document.write("</tr>");
   document.write("<tr>");
   document.write("<td width=\"182\" class=\"tdnombreusuario\" >" + strHeaderGpoNom + "</td>");
   document.write("</tr>");
  document.write("</table>");
}

function crearTablaFooter() 
{
strFooterCadena = strRCookie("strCadenaRazonSocial");

document.write("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
document.write("<tr><td class=\"tdbottom\">Sistema Administrador de Sucursal - &copy; " + (new Date()).getFullYear() + " " + strFooterCadena +"</td></tr></table>");
}

function strFechaHora() {
   var dn="AM";
   var dtmFecha = new Date();
         
   var strDD = (dtmFecha.getDate());          
   var strMM = (dtmFecha.getMonth()+1);       
   var strAAAA=(dtmFecha.getFullYear());
         
   var strHH=dtmFecha.getHours(); 
   var strMI=dtmFecha.getMinutes(); 
   var strSS=dtmFecha.getSeconds(); 
      
   if (strDD<10) strDD = "0" + strDD;
   if (strMM<10) strMM = "0" + strMM;   
   if (strHH>12) {dn="PM"; strHH=strHH-12;} 
   if (strHH==0) strHH=12;           
   if (strHH<10) strHH="0"+ strHH;    
   if (strMI<10) strMI="0"+ strMI;    
   if (strSS<10) strSS="0"+ strSS; 
   
   return strDD+"/"+strMM+"/"+strAAAA+" - "+strHH+":"+strMI+":"+strSS+' '+dn;
}

function crearDatosSucursal() 
{   
   
   strDatoSuc = strRCookie("strCentroLogisticoId") + " - " + strRCookie("strSucursalNombre") + " (" + strRCookie("intCompaniaId") + strRCookie("intSucursalId") + ")";
      
   document.write("<table class=\"tdenvolventetablas\" cellSpacing=\"0\" cellPadding=\"0\" width=\"99%\" border=\"0\">");
   document.write("<tr>");
   document.write("<td class=\"txcontazul\" vAlign=\"middle\" width=\"60%\">");
   document.write("<div id=\"ToPrintTxtSucursal\">" + strDatoSuc  + "</div>");
   document.write("</td>");
   document.write("<td class=\"txcontazul\" vAlign=\"middle\" align=\"right\" width=\"40%\">");
   document.write("<div id=\"ToPrintTxtFecha\">" + strFechaHora() + "</div>");
   document.write("</td>");
   document.write("</tr>");
   document.write("</table>");
   
}

function crearTablaHeaderPop()
{
    strCadenaImagen = strRCookie("strCadenaImagen");

    document.write("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
    document.write("<tr>");
    document.write("<td width=\"100%\"><img src=\"../static/images/" + strCadenaImagen + "/logo_pop.gif\" width=\"177\" height=\"54\"></td>");
    document.write("</tr>");
    document.write("</table>");

}

function crearTablaHeader2() 
{

strHeaderCLId = strRCookie("strCentroLogisticoId");
strHeaderSucNom = strRCookie("strSucursalNombre") + " (" + strRCookie("intCompaniaId") + strRCookie("intSucursalId") + ")";
strHeaderEmpNom = strRCookie("strEmpleadoNombre");
strHeaderGpoNom = strRCookie("strGrupoUsuarioNombre");
strHeaderCadena = strRCookie("strCadenaImagen");

document.write("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
document.write("<tr>");
document.write("<td width=\"78\"  class=\"tdnodesucursal\">"   + strHeaderCLId + "</td>");
document.write("<td width=\"515\" class=\"tdnombresucursal\">" + strHeaderSucNom + "</td>");
document.write("</tr>");
document.write("</table>");

document.write("<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
document.write("<tr>");
document.write("<td width=\"593\" class=\"tdlogo\" rowspan=\"2\"><img src=\"../static/images/" + strHeaderCadena + "/logo.gif\" width=\"255\" height=\"48\"></td>");
document.write("<td width=\"182\" class=\"tdnombreusuario\" >" + strHeaderEmpNom + "</td>");
document.write("</tr>");
document.write("<tr>");
document.write("<td width=\"182\" class=\"tdnombreusuario\" >" + strHeaderGpoNom + "</td>");
document.write("</tr>");
document.write("</table>");
}     

function crearTablaEspera()
{
    strCadenaImagen = strRCookie("strCadenaImagen");

    document.write("<table id=\"tblEsperaProceso\" borderColor=\"#000066\" height=\"150\" cellSpacing=\"0\" cellPadding=\"0\" width=\"200\" border=\"1\">");
    document.write("<tr>"); 
    document.write("<td><IMG height=\"41\" src=\"../static/images/" + strCadenaImagen + "/logoEspera.gif\" width=\"48\" border=\"0\"> </td>");
    document.write("<td vAlign=\"middle\" align=\"center\" width=\"100%\" bgColor=\"#cccccc\" height=\"100%\"><font face=\"Arial\" color=\"#000066\" size=\"4\"><b>Espere a que finalice el proceso.</b></font> </td>");
    document.write("</tr>");
    document.write("</table>");

}

function crearLogoImp()
{
    strCadenaImagen = strRCookie("strCadenaImagen");

    document.write("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
    document.write("<tr>");
    document.write("<td width=\"125%\" height=\"25\"><img src=\"../static/images/" + strCadenaImagen + "/logo.gif\" width=\"125\" height=\"25\"></td>");
    document.write("</tr>");
    document.write("</table>");

}
