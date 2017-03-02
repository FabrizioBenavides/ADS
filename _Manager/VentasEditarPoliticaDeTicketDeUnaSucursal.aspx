<%@ Page CodeBehind="VentasEditarPoliticaDeTicketDeUnaSucursal.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsEditarPoliticaDeTicketDeUnaSucursal" %>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<meta name="description" content="Javascript Menu">
		<meta name="keywords" content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control">
		<link href="css/menu.css" rel="stylesheet" type="text/css">
		<link href="css/estilo.css" rel="stylesheet" type="text/css">
		<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
		<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function strDireccionOperativaNombre() {
  document.write("<%= strDireccionOperativaNombre %>");
}

function strZonaOperativaNombre() {
  document.write("<%= strZonaOperativaNombre() %>");
}

function strSucursalNombre() {
  document.write("<%= strSucursalNombre() %>");
}

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
<%= strJavascriptWindowOnLoadCommands %>
  document.forms[0].elements["txtPoliticaTicketNombre"].value = "<%= strPoliticaTicketNombre %>";
  document.forms[0].elements["txtPoliticaTicketValor"].value = "<%= strPoliticaTicketValor %>";
}

function blnFormValidator(theForm) {
  
  var blnReturn = false;
  
  if (blnValidarCampo(document.forms[0].elements["txtPoliticaTicketNombre"], true, "Nombre de la política", cintTipoCampoAlfanumerico, 50, 1, "") == true) {
    blnReturn = blnValidarCampo(document.forms[0].elements["txtPoliticaTicketValor"], true, "Valor de la política", cintTipoCampoAlfanumerico, 400, 1, "");
    if (blnReturn == true) {
      document.forms[0].action += "&strCmd=<%= strCmd %>";
    }
  } 
  
  return (blnReturn);
}

function cmdRegresar_onclick() {
  window.location.href = "VentasAsignarPoliticasDeTicketAUnaSucursal.aspx?intDireccionId=<%= intDireccionId %>&intZonaId=<%= intZonaId %>&intCompaniaId=<%= intCompaniaId %>&intSucursalId=<%= intSucursalId %>";
}

-->
		</script>
	</HEAD>
	<body onload="return window_onload()">
		<form method="post" action="about:blank" name="frmVentasAdministrarPoliticasDeTickets"
			onSubmit="return blnFormValidator(this)">
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeader()</script></td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td width="770" class="tdtab">
						Está en : Ventas : Tickets : Administrar políticas de tickets : Editar política 
						de ticket&nbsp;de una sucursal
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent"><h2>Editar política de ticket de una sucursal
						</h2>
						<table width="50%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="20%" class="tdtexttablebold">
									Dirección:
								</td>
								<td width="80%" class="tdcontentableblue"><script language="javascript">strDireccionOperativaNombre()</script></td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Zona:</td>
								<td class="tdcontentableblue"><script language="javascript">strZonaOperativaNombre()</script></td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Sucursal:
								</td>
								<td class="tdcontentableblue"><script language="javascript">strSucursalNombre()</script></td>
							</tr>
						</table>
						<span class="tdpadleft5">
							<br>
						</span>
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="20%" class="tdtexttablebold">Nombre de la política:
								</td>
								<td width="80%" class="tdpadleft5"><input name="txtPoliticaTicketNombre" type="text" class="field" id="txtPoliticaTicketNombre"
										size="50" maxlength="50"></td>
							</tr>
							<tr>
								<td valign="top" class="tdtexttablebold">Valor de la política:</td>
								<td class="tdpadleft5"><textarea name="txtPoliticaTicketValor" cols="120" rows="5" class="fieldcomment" id="txtPoliticaTicketValor"
										size="400"></textarea></td>
							</tr>
						</table>
						<br>
						<span class="tdpadleft5"><input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar"
								language="javascript" onclick="return cmdRegresar_onclick()"> &nbsp;&nbsp; <input name="cmdSalvar" type="submit" class="button" id="cmdSalvar" value="Salvar datos">
						</span>
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaFooterCentral()</script></td>
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
