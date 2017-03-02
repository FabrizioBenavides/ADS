<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="Test.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsTest" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
  <head>
<%
    '====================================================================
    ' Page          : SucursalEmpleadosRecibosSueldos.aspx
    ' Title         : Administracion POS y BackSOffice
    ' Description   : Página de Comisiones Diferenciadas de Empleados.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Miercoles, Mayo 11, 2004
    '====================================================================
%>
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/tools.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">



<!--
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


function strCompaniaSucursal() {
	document.write("");
	return(true);
}
function strSucursalNombre() {
	document.write("&nbsp;");
	return(true);
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
function strUsuarioNombre() {
	document.write("");
	return(true);
}
function strSucursalNombre() {
	document.write("&nbsp;");
	return(true);
}
function window_onload() {
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action = ""; 
  document.iframeLayout.document.location =  "";
  
}
function frmSucursalEmpleadosRecibosSueldos_onsubmit() { 
   var regreso = true;
   return(regreso);
}
  

function cmdRegresar_onclick() {
    strRedireccionaPOSAdmin("SucursalEmpleados.aspx");
}


//-->
</script>
</head>
<body leftmargin="0" topmargin="0" onload="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmSucursalEmpleadosRecibosSueldos" onsubmit="return frmSucursalEmpleadosRecibosSueldos_onsubmit()" action="about:blank" method="post">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td><table width="780" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="78" class="tdnodesucursal"><script language="javascript">strCompaniaSucursal()</script> 
            </td>
            <td width="522" class="tdnombresucursal"><script language="javascript">strSucursalNombre()</script> 
            </td>
            <td width="170" class="tdbotonestop"><a href="javascript:cmdSalirImg_onclick()" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image1','','../static/images/bsalir_on.gif',1)"><img src="../static/images/bsalir_off.gif" alt="salir" name="Image1" width="65" height="19" border="0"></a><a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image2','','../static/images/bayuda_on.gif',1)"><img src="../static/images/bayuda_off.gif" alt="ayuda" name="Image2" width="65" height="19" border="0"></a></td>
          </tr>
        </table></td>
    </tr>
    <tr> 
      <td><table width="780" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="520" rowspan="2" class="tdlogo"><img src="../static/images/logo.gif" width="255" height="51"></td>
            <td width="90" height="26">&nbsp;</td>
            <td width="170" class="tdnombreusuario"><script language="javascript">strUsuarioNombre()</script> 
            </td>
          </tr>
          <tr> 
            <td width="90" height="51" align="right" class="tdbusqueda">&nbsp;</td>
            <td width="170" valign="middle" class="tdbusquedacampo">&nbsp; </td>
          </tr>
        </table></td>
    </tr>
    <tr> 
      <td height="34"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td><table width="780" border="0" cellpadding="0" cellspacing="0">
             <tr> 
            <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en :</span><span class="txdmigaja"> <a href="javascript:strRedireccionaPOSAdmin('Sucursal.aspx')" class="txdmigaja">Sucursal</a> 
                : <a href="javascript:strRedireccionaPOSAdmin('SucursalEmpleados.aspx')" class="txdmigaja">Empleados</a> 
                : Archivo Recibos de Sueldos</span></div></td>
            <td width="187" class="tdfechahora"><div id="ToPrintTxtFecha">
                <script language="javascript">strGetCustomDateTime()</script>
              </div></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" > <table width="583" border="0" cellpadding="0" cellspacing="0" >
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p> 
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" height="460">
                      <tr> 
                        <td><iframe name="iframeLayout" id="iframeLayout" src="" frameborder="0" width="100%" scroll="yes" height="100%" marginwidth="0" marginheight="0"> 
                          </iframe> </td>
                      </tr>
                    </table>
                    <br> <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onclick="return cmdRegresar_onclick()">
                    &nbsp;&nbsp;&nbsp;                     &nbsp;&nbsp; <br> </p> </td>
                </tr>
              </table></td>
            <td width="187" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom">Sistema Administrador de Puntos de 
              Venta - 2003 Farmacias Benavides</td>
          </tr>
        </table></td>
    </tr>
  </table>
  <p> 
    <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
</script>
  </p>
</form>
</body>
</html>
