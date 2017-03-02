<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaEntradasComprasDirectas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaEntradasComprasDirectas" codePage="28592" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<%  '====================================================================
    ' Page          : MercanciaEntradasComprasDirectas.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página que muestra el menu Compras Directas de 
	'                 Entradas de Mercancias
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.A. Hernández D.
    ' Version       : 1.0
    ' Last Modified : Jueves, Agosto 18, 2003
	'                 20 de Marzo 2007             Actualizacion por SAP
    '                 16 de Marzo 2012 [JAHD]  remisiones de compra directa
    '====================================================================    
%>
<html>
<head>
<title>ADS</title>
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
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaEntradasComprasDirectas">
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
              </span><a href="Mercancia.aspx" class="txdmigaja">Mercancía</a><span class="txdmigaja"> 
              : <a href="MercanciaEntradas.aspx" class="txdmigaja">Entradas</a><span class="txdmigaja"> 
              : </span>Compras directas</span></td>
            <td width="187" class="tdfechahora"><script language="JavaScript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Compras 
              directas</span><span class="txcontenido">En esta parte usted puede 
              procesar o consultar los documentos vinculados a las compras que 
              hace directamente la sucursal.</span> <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="40%"><a href="MercanciaCapturarCompraDirecta.aspx" class="txsubtituloliga">Capturar 
                    Factura Compras Directas</a></td>
                  <td width="9%" rowspan="2">&nbsp;</td>
                  <td width="40%"><a href="MercanciaConsultaComprasDirectas.aspx" class="txsubtituloliga">Consultar 
                    registro de compras directas</a></td>
                </tr>
                <tr> 
                  <td width="40%" class="tdcontenidoliga">Capturar la factura 
                    de compra directa.</td>
                  <td width="40%" class="tdcontenidoliga">Consultar el registro 
                    histórica de compras directas vía sus notas de entrada.</td>
                </tr>
                <tr> 
                  <td width="266"><a href="MercanciaRemisionCompraDirectaCaptura.aspx" class="txsubtituloliga">Capturar 
                    Remision</a></td>
                  <td width="14" rowspan="2">&nbsp;</td>
                  <td width="277"><a href="MercanciaRemisionCompraDirectaConsultar.aspx" class="txsubtituloliga">Consultar 
                    Remisiones Capturadas</a></td>
                </tr>
                <tr> 
                  <td width="266" class="tdcontenidoliga">Capturar la remisi&oacute;n 
                    de compra directa.</td>
                  <td width="277" class="tdcontenidoliga">Consultar las remisiones 
                    de compra directa capturadas.</td>
                </tr>
                <tr> 
                  <td width="266"><a href="MercanciaRemisionCompraDirecta.aspx" class="txsubtituloliga">Imprimir 
                    Facturas del proveedor</a></td>
                  <td width="14" rowspan="2">&nbsp;</td>
                  <td width="277">&nbsp;</td>
                </tr>
                <tr> 
                  <td width="266" class="tdcontenidoliga">Imprimir la factura 
                    de las remisones ya capturadas. Y que el proveedor envia el 
                    PDF de la factura.</td>
                  <td width="277" class="tdcontenidoliga">&nbsp;</td>
                </tr>
                <tr> 
                  <td width="266"><a href="MercanciaConfirmarFacturaElectronicaPD.aspx" class="txsubtituloliga">Confirmar 
                    Factura Electrónica de Proveedores Directos</a></td>
                  <td width="14" rowspan="2">&nbsp;</td>
                  <td width="277">&nbsp;</td>
                </tr>
                <tr> 
                  <td width="266" class="tdcontenidoliga">Para confirmar una factura 
                    electrónica, elija primero un proveedor con facturas pendientes. 
                    Esto lo llevará a la lista de facturas, donde podrá elegir 
                    una para confirmar.</td>
                  <td width="277" class="tdcontenidoliga">&nbsp;</td>
                </tr>
              </table></td>
            <td width="187" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
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
