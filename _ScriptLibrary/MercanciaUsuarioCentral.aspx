<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MercanciaUsuarioCentral.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaUsuarioCentral"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : MercanciaUsuarioCentral.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página que muestra el menu principal de Mercancias
    '                 para usuarios centrales 
    ' Copyright     : 2005-2006 All rights reserved.
    ' Company       : Benavides S.A. 
    ' Author        : J.Antonio Hernandez
    ' Version       : 1.0
    ' Last Modified : Lunes, Mayo 30, 2005
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
<script language="JavaScript" src="../static/scripts/tools.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
    document.forms[0].action = "<%=strFormAction%>";
    return(true);
}

function strCompaniaSucursal(){
	document.write(<%=intCompaniaId%> + " - " + <%=intSucursalId%>);
	return(true);
}
function strSucursalNombre() {
	document.write("<%=strSucursalNombre%>");
	return(true);
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}
function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
}
//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaEntradas">
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
              Mercancía</span></td>
            <td width="182" class="tdfechahora"><script language="JavaScript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"> <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td colspan="3"> <span class="txtitulo">Compras Directas</span></td>
                </tr>
                <tr> 
                  <td><a href="MercanciaCapturarCompraDirecta.aspx" class="txsubtituloliga">Capturar 
                    compra directa</a></td>
                  <td width="2%" rowspan="2">&nbsp;</td>
                  <td><a href="MercanciaConsultaComprasDirectas.aspx" class="txsubtituloliga">Consultar 
                    registro de compras directas</a></td>
                  <td width="0%">&nbsp;</td>
                <tr> 
                  <td width="49%" class="tdcontenidoliga">Capturar los productos 
                    comprendidos en una compra directa.</td>
                  <td width="49%" class="tdcontenidoliga">Consultar el registro 
                    histórica de compras directas vía sus notas de entrada.</td>
                </tr>
                <td align="right">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
                <tr> 
                  <td colspan="3"> <span class="txtitulo">Transferencias a otra 
                    sucursal</span></td>
                </tr>
                <tr> 
                  <td> <a href="MercanciaConsultarArchivoDeEnvios.aspx" class="txsubtituloliga">Consultar 
                    envíos</a></td>
                  <td width="2%" rowspan="4">&nbsp;</td>
                  <td>&nbsp;</td>
                <tr> 
                  <td width="49%" class="tdcontenidoliga">Consultar el registro 
                    histórico de envíos a otras sucursales.</td>
                  <td width="49%" class="tdcontenidoliga">&nbsp;</td>
                </tr>
              </table>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
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
