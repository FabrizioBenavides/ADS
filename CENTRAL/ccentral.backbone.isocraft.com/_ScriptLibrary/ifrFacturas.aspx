<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="ifrFacturas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ifrFacturas" codePage="28592" %>
<HTML>
	<HEAD>
		<title>Sistema Administrador de Sucursal</title>
		<%  '====================================================================
    ' Page          : ifrFacturas.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página iframe para el Home del ADS.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Juan Colunga (juan@isocraft.com)
    ' Version       : 1.0
    ' Last Modified : June 14, 2005
    '====================================================================
%>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
		<link rel="stylesheet" href="../static/css/estiloifr.css">
			<script language="javascript" id="clientEventHandlersJS">
<!--
function strFacturasHTML() {
	document.write("<%=strFacturasHTML%>");
	return(true);
}

//-->
			</script>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td width="267" valign="top"><script language="javascript">strFacturasHTML()</script></td>
			</tr>
			<tr>
				<td valign="top">&nbsp;</td>
			</tr>
			<tr>
				<td valign="top"><a href="<%= strURLSucursal %>MercanciaConfirmarFacturaElectronica.aspx" class="txliganormal" target="_top">
						Ir a página de facturas por confirmar</a></td>
			</tr>
		</table>
		<br>
	</body>
</HTML>
