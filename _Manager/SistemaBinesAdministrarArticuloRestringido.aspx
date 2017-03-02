<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SistemaBinesAdministrarArticuloRestringido.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsSistemaBinesAdministrarArticuloRestringido" codePage="1252" EnableSessionState="False" enableViewState="False" %>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="css/menu.css">
		<LINK rel="stylesheet" type="text/css" href="css/estilo.css">
		<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
		<script id="clientEventHandlersJS" language="javascript">
<!--
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";


function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";
  <%= strJavascriptWindowOnLoadCommands %>
}

function cmdAgregar_onclick() {
  if (document.forms[0].elements["txtArchivo"].value.length < 1) {
    alert("Por favor especifique un valor para el campo \"Archivo\".");
    document.forms[0].elements["txtArchivo"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=Agregar";
  return(true);
}
//-->
		</script>
	</HEAD>
	<body onload="return window_onload()" language="javascript">
		<form id="Form1" method="post" name="frmMain" action="about:blank" runat="server">
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtab" width="770">Está en : <A href="Sistema.htm">Sistema</A> : <A href="../_Manager/SistemaBines.aspx">
							BINes</A> : Administrar Articulo Restringido
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Administrar Articulo Restringido</h1>
						<p>En esta parte usted administrará los Articulos Restringidos del sistema.
						</p>
						<h2>Articulo Restringido</h2>
						<table cellSpacing="0" cellPadding="0" width="60%" border="0">
							<tr>
								<td class="tdtexttablebold" width="12%">Archivo:</td>
								<td class="tdpadleft5"><input id="txtArchivo" class="field" maxLength="55" size="55" type="file" name="txtArchivo"
										runat="server">
									<br>
								</td>
							</tr>
							<tr>
								<td height="10" colSpan="2"><IMG src="images/pixel.gif" width="1" height="10"></td>
							</tr>
							<tr>
								<td height="10">&nbsp;</td>
								<td class="tdpadleft5" height="10" colSpan="2"><input onclick="return cmdAgregar_onclick()" id="cmdAgregar" class="button" language="javascript"
										type="submit" value="Agregar" name="cmdAgregar">&nbsp;&nbsp;
								</td>
							</tr>
						</table>
						<br>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaFooterCentral()</script>
					</td>
				</tr>
			</table>
			<script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
			</script>
		</form>
	</body>
</HTML>
