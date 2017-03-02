<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaInventariosProductosNegados.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaInventariosProductosNegados" codePage="28592" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : MercanciaInventariosProductosNegados.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página que muestra los productos negados de Inventarios
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Carlos E. Pérez Torres
    ' Version       : 1.0
    ' Last Modified : Monday, August 19, 2003
	'                 20 de Marzo 2007           Actualizacion por SAP
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA	
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

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()"><form action="about:blank" method="post" name="frmMercanciaInventariosProductosNegados"> 
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
          <td width="10" bgcolor="#FFFFFF"><img src="../static/images/pixel.gif" width="10" height="8"></td>
          <td width="583" class="tdmigaja"><span class="txdmigaja">Est&aacute; 
            en : </span><span class="txdmigaja"><a href="Mercancia.aspx" class="txdmigaja">Mercanc&iacute;a</a><span class="txdmigaja"></span> 
            : </span><span class="txdmigaja"><a href="MercanciaInventarios.aspx" class="txdmigaja">Inventarios</a><span class="txdmigaja"></span> 
            : </span><span class="txdmigaja">Productos negados</span></td>
          <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
          </td>
        </tr>
        <tr> 
          <td width="10">&nbsp;</td>
          <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Productos 
            negados</span><span class="txcontenido">En esta parte se pued consultar 
            los productos negados en la sucursal.</span> <table width="100%" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="48%"><a href="CCRedirectorPOSAdmin.aspx?strPageName=MercanciaConsultarProductosNegados.aspx" class="txsubtituloliga">Consultar 
                  productos negados</a></td>
                <td width="5%" rowspan="2">&nbsp;</td>
                <td width="48%">&nbsp;</td>
              </tr>
              <tr> 
                <td width="48%" class="tdcontenidoliga">Consulta negados capturados.</td>
                <td width="48%" class="tdcontenidoliga">&nbsp;</td>
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
</body>
</html>
