<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaEntradas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaEntradas" codePage="28592" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<!doctype html public "-//w3c//dtd html 4.0 transitional//en">
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : MercanciaEntradas.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página que muestra el menu principal de Entradas de Mercancias
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.A. Hernández D.
    ' Version       : 1.0
    ' Last Modified : Jueves, Agosto 18, 2003
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

//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaEntradas">
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
              : Entradas</span></td>
            <td width="182" class="tdfechahora"><script language="JavaScript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Entradas</span><span class="txcontenido">En 
              esta parte usted puede administrar todo lo relacionado con la entrada 
              de mercancía a su sucursal.</span> <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="266"><a href="MercanciaEntradasRecepcion.aspx" class="txsubtituloliga">Recepcion 
                    de mercancia</a></td>
                  <td width="14" rowspan="6">&nbsp;</td>
                  <td width="277"><a href="MercanciaEntradasTransferencia.aspx" class="txsubtituloliga">Transferencias 
                    de otra sucursal</a></td>
                </tr>
                <tr> 
                  <td width="266" class="tdcontenidoliga">Confirmar facturas&nbsp;electronicas 
                    o consultar archivo histórico.</td>
                  <td width="277" class="tdcontenidoliga">Procesar recibos de 
                    transferencias, ver el archivo de transferencia recibidas. 
                    Y ver las entradas por producto.</td>
                </tr>
                <tr> 
                  <td width="266"><a href="MercanciaEntradasComprasDirectas.aspx" class="txsubtituloliga">Compras 
                    directas</a></td>
                  <td width="266">&nbsp;</td>
                </tr>
                <tr> 
                  <td width="266" class="tdcontenidoliga">Capturar compras directas 
                    o consultar el archivo histórico.</td>
                  <td width="266" class="tdcontenidoliga">&nbsp;</td>
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
