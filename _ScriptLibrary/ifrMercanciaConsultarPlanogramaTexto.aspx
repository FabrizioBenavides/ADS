<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="ifrMercanciaConsultarPlanogramaTexto.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ifrMercanciaConsultarPlanogramaTexto" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%  '====================================================================
    ' Page          : ifrMercanciaConsultarPlanogramaTexto.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página que muestra en un iframe los planos de ubicación de los productos.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Armando Calzada Mezura
    ' Version       : 1.0
    ' Last Modified : October 31, 2003
    '====================================================================
%>
<html>
<head>
<title>iframe</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link rel="stylesheet" href="../static/css/print.css">
<script language="javascript" id="clientEventHandlersJS">
<!--

function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

function strEncabezadoPlanogramaHTML() {
	document.write("<%=strEncabezadoPlanogramaHTML%>");
	return(true);
}
//-->
</script>
</head>
<body bgcolor="#FFFFFF" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
<tr><td width="99%" valign="top"><script language="javascript">strEncabezadoPlanogramaHTML()</script></td></tr>
<tr><td width="99%" valign="top"><script language="javascript">strRecordBrowserHTML()</script></td></tr>
</table>
</body>
</html>