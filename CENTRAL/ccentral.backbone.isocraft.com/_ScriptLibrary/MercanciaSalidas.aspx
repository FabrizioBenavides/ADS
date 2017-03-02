<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaSalidas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaSalidas" codePage="28592" %>
<HTML>
<HEAD>
<%
    '====================================================================
    ' Page          : MercanciaSalidas.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : HOME de Mercancias
    ' Copyright     : 2007 All rights reserved.
    ' Company       : Benavides
    ' Author        : J.Antonio Hernandez
    ' Version       : 1.0
    '                 20 de Marzo 2007             Actualizacion por SAP
    '====================================================================
%>
<title>Sistema Administrador de Sucursal</title>
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

function intCompaniaId() {
	return(<%=intCompaniaId%>);
}

function intSucursalId() {
	return(<%=intSucursalId%>);
}

function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
}

function strCompaniaSucursal() {
	document.write(intCompaniaId() + " - " + intSucursalId());
	return(true);
}

function strSucursalNombre() {
	document.write("<%=strSucursalNombre%>");
	return(true);
}

//-->
					</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaSalidas">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td height="34"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td> <table width="780" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><span class="txdmigaja">Está en : 
              </span><a href="Mercancia.aspx" class="txdmigaja">Mercancía</a><span class="txdmigaja"> 
              : Salidas</span></td>
            <td width="187" class="tdfechahora"><script language="JavaScript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"> <span class="txtitulo">Salidas</span><span class="txcontenido">En 
              esta parte usted puede revisar las salidas de mercancias de sucursales.</span> 
              <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="40%"><a href="CCRedirectorPOSAdmin.aspx?strPageName=MercanciaSalidasTransferenciasOtraSucursal.aspx" class="txsubtituloliga">Transferencias 
                    a otra sucursal</a></td>
                  <td width="9%" rowspan="2">&nbsp;</td>
                  <td width="40%"><a href="MercanciaSalidasDevoluciones.aspx" class="txsubtituloliga">Devolución 
                    de Mercancia</a></td>
                </tr>
                <tr> 
                  <td width="40%" class="tdcontenidoliga">En esta parte usted 
                    puede capturar lo relacionado con envío de mercancía manual 
                    o automático, y ver el registro histórico.</td>
                  <td width="40%" class="tdcontenidoliga">En esta parte usted 
                    puede capturar los productos devueltos a proveedores, y ver 
                    el registro histórico.</td>
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
</HTML>
