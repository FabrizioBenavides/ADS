<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="ifrHoyTocaInventariar.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ifrHoyTocaInventariar" codePage="28592" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
	<HEAD>
<title>Sistema Administrador de Sucursal</title>
		<%  '====================================================================
    ' Page          : ifrHoyTocaInventariar.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página iframe para el Home de Inicio.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Juan Colunga (juan@isocraft.com)
    ' Version       : 1.0
    ' Last Modified : June 16, 2005
    '====================================================================
%>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
		<link rel="stylesheet" href="../static/css/estiloifr.css">
			<script language="javascript" id="clientEventHandlersJS">
<!--
function strListadoInventariosHTML() {
	document.write("<%=strListadoInventariosHTML%>");
	return(true);
}

//-->
			</script>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">		
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
			<tr class="trtitulos">
				<th width="80%" class="rayita">
					Descripción</th>
				<th width="20%" class="rayita">
					Articulos</th>
			</tr>
		</table>
		<script language="javascript">strListadoInventariosHTML()</script>		
	</body>
</HTML>
