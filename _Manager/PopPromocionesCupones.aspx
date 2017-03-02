<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PopPromocionesCupones.aspx.vb" Inherits="com.isocraft.backbone.ccentral.PopPromocionesCupones" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Catalogo de Promociones</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
		<link href="../static/css/estilo.css" rel="stylesheet">
		<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
		<script language="javascript" id="clientEventHandlersJS">

		    function window_onload() {
		        MM_preloadImages('../static/images/bsalir_on.gif', '../static/images/bayuda_on.gif');
		        document.forms[0].action = "<%= strFormAction %>";
  return (true);
}

function strRecordBrowserHTML() {
    document.write("<%=strRecordBrowserHTML%>");
    return (true);
}
function cmdCerrar_onclick() {
    opener.document.forms[0].elements['<%=Request.QueryString("strPromocion")%>'].value = 0;
    opener.document.forms[0].elements['<%=Request.QueryString("strPromocionNombreId")%>'].value = "";
	
	<% if Request.QueryString("strEvalJs")<>"" then %>
    eval("<%=Request.QueryString("strEvalJs")%>");
	<% end if %>

    window.close();
    return (true);
}

function ClosePopup(intValor, strNombre, intDepartamento) {
    opener.document.forms[0].elements['<%=Request.QueryString("strPromocion")%>'].value = intValor;
    opener.document.forms[0].elements['<%=Request.QueryString("strPromocionNombreId")%>'].value = strNombre;
	
	<% if Request.QueryString("strEvalJs")<>"" then %>
    eval("<%=Request.QueryString("strEvalJs")%>");
    <% end if %>		
	
	<% if Request.QueryString("strEvalJsClosePopup")<>"" then %>
    eval("<%=Request.QueryString("strEvalJsClosePopup")%>");
	<% end if %>

    self.close();
    return (true);
}

function window_onunload() {
	<% if Request.QueryString("strEvalJs")<>"" then %>
    eval("<%=Request.QueryString("strEvalJs")%>");
	<% end if %>
}
		</script>
	</HEAD>
    <body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0" onUnload="return window_onunload()">

    <form name="frmPopPromocionesCupones" action="about:blank" method="post">
			<table height="158" cellspacing="0" cellpadding="0" width="100%" bgcolor="#ffffff" border="0">
				<tr>
					<td class="tdlogopop" colspan="2" height="54"><script language="javascript">crearTablaHeaderPop()</script></td>
				</tr>
				<tr>
					<td width="2%">&nbsp;</td>
					<td valign="top" width="99%" height="10">&nbsp;</td>
				</tr>
				<tr>
					<td width="2%">&nbsp;</td>
					<td valign="top" height="30"><span class="txtitulo">Catalogo Promociones</span><span class="txcontenido">Selecciona 
							la promoción haciendo clic en el nombre.<br>
							<br>
						</span>
						<script language="javascript">strRecordBrowserHTML()</script>
						<span class="txcontenido"></span>
					</td>
				</tr>
				<tr>
					<td width="2%">&nbsp;</td>
					<td><input name="cmdCerrar" type="submit" class="boton" id="cmdCerrar" value="Cerrar" onClick="return cmdCerrar_onclick()">
						<br>
						<br>
					</td>
				</tr>
			</table>
		</form>
		<%= strJavascriptWindowOnLoadCommands %>
	</body>
</HTML>
