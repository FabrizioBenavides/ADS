<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="ifrSucursalTransportes.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ifrSucursalTransportes" codePage="28592" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%  '====================================================================
    ' Page          : ifrSucursalTransportes.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página iframe para monstrar si esta pendiente de confirmar la vista del transportista
    '                 prenómina.
    ' Copyright     : 2016 All rights reserved.
    ' Company       : 
    ' Author        : 
    ' Version       : 1.0
    ' Last Modified : Oct 12, 2016
    '====================================================================
%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<title>Sistema Administrador de Sucursal</title>
<link rel="stylesheet" href="../static/css/estiloifr.css">
<script language="javascript" id="clientEventHandlersJS">
<!--
function strConfirmacionTransportePendiente() {
	document.write("<%=strConfirmacionTransportePendiente%>");
	return(true);
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr> 
    <td align="right" class="tdtittablas"><span class="txsubtituloliga">
      <script language="javascript">strConfirmacionTransportePendiente()</script>
      </span></td>
  </tr>
</table>
</body>
</html>
