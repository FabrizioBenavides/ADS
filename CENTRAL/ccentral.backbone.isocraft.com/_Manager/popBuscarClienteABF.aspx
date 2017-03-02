<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="popBuscarClienteABF.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popBuscarClienteABF" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<HTML>
	<HEAD>
		<title>Sistema Administrador de Sucursal</title>
		<%
    '====================================================================
    ' Page          : popBuscarClienteABF.aspx
    ' Title         : popBuscarClienteABF.aspx
    ' Description   : Busca Clientes ABF
    ' Copyright     : 07/05/2014
    ' Company       : Benavides
    ' Author        : Rocio Esquivel [RERA]
    ' Version       : 1.0
    ' Last Modified :  
	'                 
    '====================================================================
	%>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
		<link href="../static/css/estilo.css" rel="stylesheet">
			<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
			<script language="javascript" id="clientEventHandlersJS">
<!--
function window_onload() {
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action = "<%= strFormAction %>";
  document.forms[0].elements["txtDescripcion"].value="";	
  return(true);
}

function strRecordBrowserHTML() {
  document.write("<%=strRecordBrowserHTML%>");
   return(true);
}

function cmdCerrar_onclick() {

	opener.document.forms[0].elements['<%=Request.QueryString("strCliente")%>'].value = "";
	opener.document.forms[0].elements['<%=Request.QueryString("strClienteABFDesc")%>'].value = "";
	
	window.close();
  return(true);
}

function ClosePopup(intValor,strNombre,intDepartamento)
{

	opener.document.forms[0].elements['<%=Request.QueryString("strCliente")%>'].value = intValor;
	opener.document.forms[0].elements['<%=Request.QueryString("strClienteABFDesc")%>'].value = strNombre;

		
	self.close();
	window.close();
    return(true);
 }
    


//-->
			</script>
	</HEAD>
	<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0"
		onUnload="return window_onunload()">
		<form name="frmPopArticulo" action="about:blank" method="post">
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
					<td valign="top" height="30"><span class="txtitulo">Catalogo Clientes</span><span class="txcontenido">Selecciona 
        el Cliente haciendo clic en el nombre.<br>
        <br>
        </span>
						<script language="javascript">strRecordBrowserHTML()</script>
						<span class="txcontenido"></span></td>
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
