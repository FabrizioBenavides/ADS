<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="ifrSucursalCapturarPrenomina.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsifrSucursalCapturarPrenomina" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%  '====================================================================
    ' Page          : ifrSucursalCapturarPrenomina.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página iframe para calcular los días faltantes de prenómina.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Carlos E. Pérez Torres
    ' Version       : 1.0
    ' Last Modified : October 30, 2003
    '====================================================================
%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<title>Sistema Administrador de Sucursal</title>
<link rel="stylesheet" href="../static/css/estiloifr.css">
<script language="javascript" id="clientEventHandlersJS">
<!--
function intDiasRestantes() {
	document.write("<%=intDiasRestantes%>");
	return(true);
}

//-->
</script>
</head>
  <body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr> 
        <td width="327" class="tdtittablas">&nbsp;</td>
        <td width="241" align="right" valign="middle" class="tdtittablas">Faltan 
            <span class="txconttablasrojo"><script language="javascript">intDiasRestantes()</script> </span>d&iacute;as para el 
            cierre de pren&oacute;mina</td>
        </tr>
    </table>
  </body>
</html>
