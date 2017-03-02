<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ifrPagaresPendientes.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ifrPagaresPendientes" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
	<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : ifrRecibos.aspx
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
    // <%= strFormAction %>
			    // <%= Request.Servervariables("SERVER_NAME") & ":" & Request.Servervariables("SERVER_PORT") %>

			    function strPagaresHTML() {
			        document.write("<%=strPagaresHTML%>");
    return (true);
}

//-->
			</script>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td width="269" valign="top"><script language="javascript">strPagaresHTML()</script></td>
			</tr>
			<tr>
				<td valign="top">&nbsp;</td>
			</tr>
			<tr>
			    <td valign="top"><a href="<%= strURLSucursal %>ControlDePagaresConfirmacion.aspx" class="txliganormal" target="_top">
                <%--<td valign="top"><a href="http://localhost:51017/ADS/_ScriptLibrary/ControlDePagaresConfirmacion.aspx" class="txliganormal" target="_top">--%>
						Ir a Pagares por confirmar</a></td>
			</tr>
		</table>
		<br>
	</body>
</HTML>
