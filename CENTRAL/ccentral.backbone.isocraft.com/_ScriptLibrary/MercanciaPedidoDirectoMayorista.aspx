<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaPedidoDirectoMayorista.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaPedidoDirectoMayorista" codePage="28592" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<!doctype html public "-//w3c//dtd html 4.0 transitional//en">
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  
    '====================================================================
    ' Page          : MercanciaPedidoDirectoMayorista.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   :  
    ' Copyright     : 2012 All rights reserved.
    ' Company       : Farmacias Benavides
    ' Author        : [JAHD] 
    ' Version       : 1.0
    ' Last Modified : 
    '                 24 de Febrero 2012 [JAHD] 
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
<form action="about:blank" method="post" name="frmMercanciaPedidoDirectoMayorista">
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
              : Pedido Directo Mayoristas</span></td>
            <td width="182" class="tdfechahora"><script language="JavaScript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Pedido 
              Directo Mayoristas</span><span class="txcontenido">En esta parte 
              usted puede administrar los pedidos directos a Mayoristas.</span> 
              <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="266"><a href="MercanciaPedidoDirectoMayoristaCaptura.aspx" class="txsubtituloliga">Capturar 
                    Pedido</a></td>
                  <td width="14" rowspan="7">&nbsp;</td>
                  <td width="277"><a href="MercanciaPedidoDirectoMayoristaConsultar.aspx" class="txsubtituloliga">Consultar 
                    Pedidos Capturados</a></td>
                </tr>
                <tr> 
                  <td width="266" class="tdcontenidoliga">Capturar el pedido directo 
                    al proveedor mayorista.</td>
                  <td width="277" class="tdcontenidoliga">Consultar los pedidos 
                    directos capturados al proveedor mayorista.</td>
                </tr>
                <tr> 
                  <td width="266"><a href="MercanciaPedidoDirectoMayoristaStock.aspx" class="txsubtituloliga">Consulta 
                    Stock Mayoristas</a></td>
                  <td width="277">&nbsp;</td>
                </tr>
                <tr> 
                  <td width="266" class="tdcontenidoliga">Consulta el Stock para 
                    Pedido Directo Mayorista</td>
                  <td width="277" class="tdcontenidoliga">&nbsp;</td>
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
