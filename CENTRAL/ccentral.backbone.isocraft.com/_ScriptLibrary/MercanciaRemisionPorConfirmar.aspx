<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaRemisionPorConfirmar.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaRemisionPorConfirmar" codePage="28592"%>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaRemisionPorConfirmar.aspx 
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página donde se muestran las remisiones por confirmar
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Jorge Tamez Sánchez
    ' Version       : 1.0
    ' Last Modified : Martes, Octubre 21, 2003
    '                 20 de Marzo 2007             Actualizacion por SAP
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%><html>
<head>
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
// Load de la pagina 
function window_onload() {
   MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
   document.forms[0].action = "<%=strFormAction%>";
   return(true);
}

// Submit 
function frmMercanciaRemisionPorConfirmar_onsubmit() {
  valida=true;
	return(valida);
}
// Fecha actual (despliegue basico)
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}

 // Gerenamos el recorbrowser
function strRecordBrowserHTML(){
 document.write("<%=strRecordBrowserHTML%>");
 return(true);
}

// Mandar a la página anterior de remisiones
function cmdRegresar_onclick() {
 window.location = "MercanciaConfirmarRemisionElectronica.aspx";
 return(true);
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaRemisionPorConfirmar" onSubmit="return frmMercanciaRemisionPorConfirmar_onsubmit()">
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
            <td width="583" class="tdmigaja"><span class="txdmigaja">Está en : 
              </span><a href="Mercancia.aspx" class="txdmigaja">Mercancía</a><span class="txdmigaja"> 
              : <a href="MercanciaEntradas.aspx" class="txdmigaja">Entradas</a> 
              : <a href="MercanciaConfirmarRemisionElectronica.aspx" class="txdmigaja">Confirmar 
              remisión electrónica</a> : </span><span class="txdmigaja"></span><span class="txdmigaja">Remisiones 
              por confirmar</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Remisiones 
              por confirmar</span><span class="txcontenido">Para seguir el proceso 
              de confirmación, elija una remisión de la lista.</span> <br> <script language="JavaScript">crearDatosSucursal()</script> 
              <br> <script language="JavaScript">strRecordBrowserHTML()</script> 
              <br> <input name="cmdRegresar" type="button" class="boton" id="cmdRegresar" value="Regresar"
										onClick="return cmdRegresar_onclick()"> 
              <br> <br> </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"><script language="javascript">strGeneraTablaAyuda('');</script> 
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
			</script>
</form>
</body>
</html>
