<%@ Page CodeBehind="ExportarDocumento.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsExportarDocumento" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="True" enableViewState="False" %>
<HTML>
	<HEAD>
		<title></title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<script language="javascript">
		
		function window_onload() 
		{
			window.opener.forms[0].documentExported ="1"
		} 
		</script>
	</HEAD>
	<body onload="window_onload()">
		<%= strRecordBrowserHTML() %>
	</body>
</HTML>
