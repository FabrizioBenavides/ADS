<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="ifrVentasMovimientosAntibioticos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ifrVentasMovimientosAntibioticos" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%  '====================================================================
    ' Page          : ifrVentasMovimientosAntibioticos.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : 
    ' Copyright     : 2012
    ' Company       : 
    ' Author        : 
    ' Version       : 
    ' Last Modified : 
    '====================================================================
%>
<html>
<head>
<title>ifrVentasMovimientosAntibioticos</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link rel="stylesheet" href="../static/css/estiloifr.css">
<script language="javascript" id="clientEventHandlersJS">
<!--

function window_onLoad() 
{

}
function cmdImprimir_onclick() 
{
				strParametros = '';		      
				strParametros = strParametros + 'strSelected=' + '<%= strSelected %>';
				strParametros = strParametros + '&strTipoMovimientoAntibioticoId=' + '<%= strTipoMovimientoAntibioticoId %>';
				strParametros = strParametros + '&strIndicadorMovimiento='  + '<%= strIndicadorMovimiento %>';
				strParametros = strParametros + "&strOrdenId="  + '<%= strOrdenId %>';
				strParametros = strParametros + '&strFechaInicial=' + '<%= strFechaInicial %>';
				strParametros = strParametros + '&strFechaFinal=' + '<%= strFechaFinal %>';
				
				window.open('PopMovimientosAntibioticos.aspx?' + strParametros, 'Pop','width=980,height=580,left=0,top=0,resizable=yes,scrollbars=yes,menubar=yes,status=no' );
				
}


//-->
</script>
</head>
<body bgcolor="#FFFFFF" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onload="return window_onLoad()">
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
  <tr> 
    <td width="10%" valign="top"> <input type="hidden" name="intNavegadorRegistrosPagina"> 
      <%= strGetRecordBrowserHTML()%><br> </td>
  </tr>
</table>
</body>
</html>
