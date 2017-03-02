<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="ifrInicio.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsifrInicio" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
	<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : ifrInicio.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página iframe para el Home de Inicio.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Carlos E. Pérez Torres
    ' Version       : 1.0
    ' Last Modified : October 30, 2003
    '====================================================================
%>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
		<link rel="stylesheet" href="../static/css/estiloifr.css">
			<script language="javascript" id="clientEventHandlersJS">
<!--
// <%= strFormAction %>
// <%= Request.Servervariables("SERVER_NAME") & ":" & Request.Servervariables("SERVER_PORT") %>
function strRemisionesHTML() {
	document.write("<%=strRemisionesHTML%>");
	return(true);
}

function strFacturasHTML() {
	document.write("<%=strFacturasHTML%>");
	return(true);
}

function strListadoInventariosHTML() {
	document.write("<%=strListadoInventariosHTML%>");
	return(true);
}

function strEnviosHTML() {
	document.write("<%=strEnviosHTML%>");
	return(true);
}

function strRecibosHTML() {
	document.write("<%=strRecibosHTML%>");
	return(true);
}

//-->
			</script>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Hoy toca inventariar ... </span>
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr class="trtitulos">
				<th width="480" class="rayita">
					Descripción</th>
				<th width="40" class="rayita">
					Articulos</th>
				<th width="40" class="rayita">
					Estado</th>
			</tr>
		</table>
		<script language="javascript">strListadoInventariosHTML()</script>
		<br>
		<span class="txcontenido"></span><br>
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Remisiones pendientes</span></td>
				<td width="31">&nbsp;</td>
				<td><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Facturas pendientes</span></td>
			</tr>
			<tr>
				<td width="270" valign="top"><script language="javascript">strRemisionesHTML()</script></td>
				<td width="31">&nbsp;</td>
				<td width="267" valign="top"><script language="javascript">strFacturasHTML()</script></td>
			</tr>
			<tr>
				<td valign="top">&nbsp;</td>
				<td>&nbsp;</td>
				<td valign="top">&nbsp;</td>
			</tr>
			<tr>
				<td valign="top"><a href="<%= strURLSucursal %>MercanciaConfirmarRemisionElectronica.aspx" class="txliganormal" target="_top">Ir 
						a página de remisiones por confirmar</a></td>
				<td>&nbsp;</td>
				<td valign="top"><a href="<%= strURLSucursal %>MercanciaConfirmarFacturaElectronica.aspx" class="txliganormal" target="_top">
						Ir a página de facturas por confirmar</a></td>
			</tr>
		</table>
		<br>
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Envíos pendientes</span></td>
				<td width="29">&nbsp;</td>
				<td><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Recibos pendientes</span></td>
			</tr>
			<tr>
				<td width="270" valign="top"><script language="javascript">strEnviosHTML()</script></td>
				<td width="29">&nbsp;</td>
				<td width="269" valign="top"><script language="javascript">strRecibosHTML()</script></td>
			</tr>
			<tr>
				<td valign="top">&nbsp;</td>
				<td>&nbsp;</td>
				<td valign="top">&nbsp;</td>
			</tr>
			<tr>
				<td valign="top"><a href="<%= strURLSucursal %>MercanciaConfirmarEnvioProductos.aspx" class="txliganormal" target="_top">Ir 
						a página de envíos por confirmar</a></td>
				<td>&nbsp;</td>
				<td valign="top"><a href="<%= strURLSucursal %>MercanciaConfirmarReciboDeProductos.aspx" class="txliganormal" target="_top">
						Ir a Recibos por confirmar</a></td>
			</tr>
		</table>
	</body>
</HTML>
