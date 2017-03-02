<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaSalidasDevoluciones.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaSalidasDevoluciones" codePage="28592" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaSalidasDevoluciones.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : HOME de Mercancias
    ' Copyright     : 2007 All rights reserved.
    ' Company       : Benavides
    ' Author        : J.Antonio Hernandez
    ' Version       : 1.0
    '                 20 de Marzo 2007             Actualizacion por SAP
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script id="clientEventHandlersJS" language="javascript">
<!--
function window_onload() {
		MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
		document.forms[0].action = "<%=strFormAction%>"; 
    return(true);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}
//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaSalidasDevoluciones">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td height="34"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td><table width="780" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgcolor="#FFFFFF"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><span class="txdmigaja">Est&aacute; 
              en : </span><a href="Mercancia.aspx" class="txdmigaja"> Mercanc&iacute;a</a><span class="txdmigaja"> 
              : <a href="MercanciaSalidas.aspx" class="txdmigaja"> Salidas</a><span class="txdmigaja"> 
              : </span>Devoluci&oacute;n de mercanc&iacute;a</span></td>
            <td width="182" class="tdfechahora"><script language="JavaScript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Devoluci&oacute;n 
              de mercanc&iacute;a</span><span class="txcontenido">En esta parte 
              usted puede capturar los productos devueltos a proveedores, y ver 
              el registro hist&oacute;rico.</span> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="40%"><a href="MercanciaCapturarDevoluciones.aspx" class="txsubtituloliga">Capturar 
                    productos a devolver</a></td>
                  <td width="9%" rowspan="2">&nbsp;</td>
                  <td width="40%"><a href="MercanciaArchivoProductosDevueltos.aspx" class="txsubtituloliga">Consultar 
                    archivo de productos devueltos</a></td>
                </tr>
                <tr> 
                  <td width="40%" class="tdcontenidoliga">Capturar los productos 
                    a devolver a proveedores, registrando el motivo general.</td>
                  <td width="40%" class="tdcontenidoliga">Consultar el registro 
                    hist&oacute;rico de reportes de devoluci&oacute;n de productos 
                    a proveedores.</td>
                </tr>
                <tr> 
                  <td width="40%"><a href="MercanciaListadoDevoluciones.aspx" class="txsubtituloliga">Listado 
                    Devoluciones</a></td>
                  <td width="9%" rowspan="2">&nbsp;</td>
                  <td width="40%"><a href="MercanciaGuiaDevolucion.aspx" class="txsubtituloliga">Impresión 
                    Guia Devolución</a></td>
                </tr>
                <tr> 
                  <td width="40%" class="tdcontenidoliga">Consulta listado de 
                    productos a devolver</td>
                  <td width="40%" class="tdcontenidoliga">Imprimir la guia de 
                    la devolución, de RF</td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
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
</HTML>
