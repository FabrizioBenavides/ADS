<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaListadoDevoluciones.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaListadoDevoluciones" codePage="28592" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaConsultarLayout.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : P�gina de productos Reclamados.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hern�ndez D�vila
    ' Version       : 1.0
    ' Last Modified : Miercoles, Noviembre 05, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
	'                 15 de Octubre 2012 [JAHD] Ruta de documentos PDF
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/tools.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--



var strPaginaAyuda
strPaginaAyuda = "";

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function strCompaniaSucursal() {
	document.write(<%=intCompaniaId%> + " - " + <%=intSucursalId%>);
	return(true);
}
function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
	return(true);
}
function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}
function window_onload() {
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action = "<%=strFormAction%>"; 
  document.iframeLayout.document.location = strUrlADSDoc() +  "pdf/Devo/" + "<%=strCentroLogisticoId%>" + ".pdf";  
}
  

function cmdRegresar_onclick() {
     window.location="MercanciaSalidasDevoluciones.aspx";
}


//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaDevolucionListado" action="about:blank" method="post">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="34" width="100%"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td width="100%"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><span class="txdmigaja">Est� en : 
              </span><a href="Mercancia.aspx" class="txdmigaja"> Mercanc�a</a><span class="txdmigaja"> 
              : <a href="MercanciaSalidas.aspx" class="txdmigaja"> Salidas</a><span class="txdmigaja"> 
              : </span><a href="MercanciaSalidasDevoluciones.aspx" class="txdmigaja"> 
              Devoluciones</a></span><span class="txdmigaja">: </span><span class="txdmigaja"> 
              </span><span class="txdmigaja">Listado</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Listado Devoluciones</span> 
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" height="460">
                      <tr> 
                        <td><iframe name="iframeLayout" id="iframeLayout" src="" frameborder="0" width="100%" scroll="yes"
																	height="100%" marginwidth="0" marginheight="0"> 
                          </iframe> </td>
                      </tr>
                    </table>
                    <br> <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()">	
                    <br> </p> </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda('');</script> 
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
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
</HTML>
