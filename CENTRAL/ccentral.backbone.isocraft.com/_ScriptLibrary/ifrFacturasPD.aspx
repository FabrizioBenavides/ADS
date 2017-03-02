<!-- codePage="28592" -->

<%@ Import Namespace="Benavides.POSAdmin.Commons"%>

<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="ifrFacturasPD.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ifrFacturasPD" %>

<HTML>
	<HEAD>
		<title>Sistema Administrador de Sucursal</title>
		
		<%  '====================================================================
			' Page          : ifrFacturasPD.aspx
			' Title         : Administracion POS y BackOffice
			' Description   : Página iframe para el Home del ADS.
			' Copyright     : 2012 All rights reserved.
			' Company       : Benavides
			' Consulting C. : Softtek
			' Author        : Victor Ollervides [VHOV]
			' Version       : 1.0
			' Created		: 14 de Junio de 2012
			' Last Modified : 
			'==================================================================== 
		%>
		
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
		
		<link rel="stylesheet" href="../static/css/estiloifr.css">
	
		<script language="javascript" id="clientEventHandlersJS">
		<!--
		
			function strFacturasHTML() 
			{
				document.write("<%=strFacturasHTML%>");
				return(true);
			}

		//-->
		</script>
	
	</HEAD>
	
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
		
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
		
			<tr>
				<td width="267" valign="top">
					<script language="javascript">
						strFacturasHTML()
					</script>
				</td>
			</tr>
		
			<tr>
				<td valign="top">
					&nbsp;
				</td>
			</tr>
		
			<tr>
				<td valign="top">
				
					<a	href="<%= strURLSucursal %>MercanciaConfirmarFacturaElectronicaPD.aspx" 
						class="txliganormal" target="_top">
						
						Ir a página de facturas por confirmar
					</a>
				</td>
			</tr>
			
		</table>
		
		<br>
		
	</body>
	
</HTML>
