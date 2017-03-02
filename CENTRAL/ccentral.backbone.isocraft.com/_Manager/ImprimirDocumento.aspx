<%@ Page CodeBehind="ImprimirDocumento.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsImprimirDocumento" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="True" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="../static/css/print.css" rel="stylesheet" type="text/css">
		<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js">
		</script>
		<script id="clientEventHandlersJS" language="javascript">
		
		strUsuarioNombre = "<%= strUsuarioNombre %>"; 
		strFechaHora = "<%= strHTMLFechaHora %>"; 
		function window_onload() 
		{
			window.focus();
			window.print()	
		} 
		</script>
	</HEAD>
	<body onload="window_onload()">
		<%= strRecordBrowserHTML() %>
	</body>
</HTML>
