<%@ Page CodeBehind="ifrEnvios.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsifrEnvios" %>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
		<link rel="stylesheet" href="../static/css/estiloifr.css">
			<script language="javascript" id="clientEventHandlersJS">
<!--


function strEnviosHTML() {
	document.write("<%=strEnviosHTML%>");
	return(true);
}

//-->
			</script>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">		
		<table width="100%" border="0" cellpadding="0" cellspacing="0">			
			<tr>
				<td width="270" valign="top"><script language="javascript">strEnviosHTML()</script></td>
			</tr>
			<tr>
				<td valign="top">&nbsp;</td>			
			</tr>	
			<tr>		
			    <td valign="top"><a href="<%= strURLSucursal %>MercanciaConfirmarEnvioProductos.aspx" class="txliganormal" target="_top">Ir 
						a página de envíos por confirmar</a></td>
			</tr>
		</table>
		<br>
	</body>
</HTML>