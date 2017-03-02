<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaEntradasRecepcion.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaEntradasRecepcion" codePage="28592" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : MercanciaEntradasRecepcion.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página que muestra el menu de Recepcion
	'                 en Entradas de Mercancias
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.A. Hernández D.
    ' Version       : 1.0
    ' Last Modified : Jueves, Agosto 18, 2003
    '                 20 de Marzo 2007             Actualizacion por SAP
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
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
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" >
<form action="about:blank" method="post" name="frmMercanciaEntradasRecepcion">
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
            <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><span class="txdmigaja">Está en : 
              </span><a href="Mercancia.aspx" class="txdmigaja">Mercanc&iacute;a</a><span class="txdmigaja"> 
              : <a href="MercanciaEntradas.aspx" class="txdmigaja">Entradas</a><span class="txdmigaja"> 
              : </span>Recepci&oacute;n de mercanc&iacute;a</span></td>
            <td width="187" class="tdfechahora"><script language="JavaScript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Recepci&oacute;n 
              de mercanc&iacute;a</span><span class="txcontenido">En esta parte 
              usted puede administrar todo lo relacionado con la entrada de mercancía 
              a su sucursal.</span> <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="40%"><a href="MercanciaConfirmarFacturaElectronica.aspx" class="txsubtituloliga">Confirmar 
                    factura electronica</a></td>
                  <td width="9%" rowspan="2">&nbsp;</td>
                  <td width="40%"><a href="MercanciaConsultarFacturaRemision.aspx" class="txsubtituloliga">Consultar 
                    archivo de facturas</a></td>
                </tr>
                <tr> 
                  <td width="40%" class="tdcontenidoliga">Confirmar las entregas 
                    de proveedores y capturar las excepciones que puedan surgir.</td>
                  <td width="40%" class="tdcontenidoliga">Examinar el registro 
                    histórico de facturas confirmadas.</td>
                </tr>
                <tr> 
                  <td width="40%"><a href="MercanciaConfirmarRemisionElectronica.aspx" class="txsubtituloliga">Confirmar 
                    Remisi&oacute;n electronica</a></td>
                  <td width="9%" rowspan="2">&nbsp;</td>
                  <td width="40%">&nbsp; </td>
                </tr>
                <tr> 
                  <td width="40%" class="tdcontenidoliga">Confirmar las entregas 
                    de proveedores y capturar las excepciones que puedan surgir.</td>
                  <td width="40%" class="tdcontenidoliga">&nbsp;</td>
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
</html>
