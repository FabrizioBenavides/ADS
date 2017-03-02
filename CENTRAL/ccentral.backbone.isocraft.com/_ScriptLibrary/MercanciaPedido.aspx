<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaPedido.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaPedido" codePage="28592" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<!doctype html public "-//w3c//dtd html 4.0 transitional//en">
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  
    '====================================================================
    ' Page          : MercanciaPedido.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   :  
    ' Copyright     : 2012 All rights reserved.
    ' Company       : Farmacias Benavides
    ' Author        : [JAHD] 
    ' Version       : 1.0
    ' Last Modified : 
    '                 31 de Octubre 2012 [JAHD] 
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
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaPedido">
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
              </span><a href="Mercancia.aspx" class="txdmigaja"> Mercancía</a><span class="txdmigaja"> 
              : Pedidos</span></td>
            <td width="182" class="tdfechahora"><script language="JavaScript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Mercancia 
              Pedidos</span><span class="txcontenido">En esta parte usted puede 
              administrar los pedidos.</span> <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="266"><a href="MercanciaPedidoDirectoMayorista.aspx" class="txsubtituloliga">Pedido 
                    Directo Mayorista.</a></td>
                  <td width="14" rowspan="6">&nbsp;</td>
                  <td width="277"><a href="MercanciaPedidoVentaCatalogo.aspx" class="txsubtituloliga">Pedido 
                    Venta Catálogo.</a></td>
                </tr>
                <tr> 
                  <td width="266" class="tdcontenidoliga">En esta parte usted 
                    puede administrar los pedidos directos a mayoristas.</td>
                  <td width="277" class="tdcontenidoliga">En esta parte usted 
                    puede administrar los pedidos de venta por catálogo.</td>
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
