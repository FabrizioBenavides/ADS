<%@ Page CodeBehind="popSistemaVincularSucursal.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsPopSistemaVincularSucursal" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="css/estilo.css" rel="stylesheet" type="text/css">
		<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
		<script id="clientEventHandlersJS" language="javascript">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  document.forms[0].elements["txtTiendaId"].value = "<%= intTiendaId %>";
  document.forms[0].elements["txtDireccionId"].value = "<%= intDireccionId %>";
  document.forms[0].elements["txtZonaId"].value = "<%= intZonaId %>";
  document.forms[0].elements["txtNombreSucursal"].value = "<%= strNombreSucursal %>";
  
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarSucursalesComboBox() %>
  if (document.forms[0].elements["cboSucursales"].length == 0) {
    document.forms[0].elements["cmdCerrar"].disabled = true;
    alert("No hay sucursales disponibles.");
    window.opener.location.href = "SistemaAdministrarTiendas.aspx?strCmd=Consultar&intDireccionId=<%=intDireccionId%>&intZonaId=<%=intZonaId%>";
    window.close();
  }
}

function strTiendaNombre() {
  document.write("<%= strTiendaNombre %>");
}

function strCiudadNombre() {
  document.write("<%= strCiudadNombre %>");
}

function strEstadoNombre() {
  document.write("<%= strEstadoNombre %>");
}

function strDireccionOperativaNombre() {
  document.write("<%= strDireccionOperativaNombre %>");
}

function strZonaOperativaNombre() {
  document.write("<%= strZonaOperativaNombre() %>");
}

function cmdCancelar_onclick() {
  window.close();
}

function chkTodo_onclick() {
  for (var intCounter = 0; intCounter < document.forms[0].elements["cboSucursales"].length; intCounter++) {
    document.forms[0].elements["cboSucursales"].options[intCounter].selected = document.forms[0].elements["chkTodo"].checked;
  }
}

function cmdCerrar_onclick() {
  var blnSelected = false;
  for (var intCounter = 0; intCounter < document.forms[0].elements["cboSucursales"].length; intCounter++) {
    blnSelected = document.forms[0].elements["cboSucursales"].options[intCounter].selected;
    if (blnSelected == true) {
      break;
    }
  }
  if (blnSelected == true) {
    document.forms[0].action += "?strCmd=Cerrar";
    document.forms[0].submit();
  } else {
    alert("Por favor seleccione al menos una sucursal.");
    document.forms[0].elements["cboSucursales"].focus();
    return(false);
  }
}

		</script>
	</HEAD>
	<body onload="return window_onload()">
		<form method="post" action="about:blank" name="frmPopSistemaVincularSucursal">
			<input type="hidden" name="txtTiendaId"> <input type="hidden" name="txtDireccionId">
			<input type="hidden" name="txtZonaId">
			<table width="360" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeaderPop()</script></td>
				</tr>
			</table>
			<table width="360" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td class="tdgeneralcontentpop"><h2>Vincular sucursales
						</h2>
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="19%" class="tdtexttablebold">
									Tienda:
								</td>
								<td width="81%" class="tdcontentableblue"><script language="javascript">strTiendaNombre()</script></td>
							</tr>
							<tr>
								<td width="19%" class="tdtexttablebold">
									Estado:
								</td>
								<td width="81%" class="tdcontentableblue"><script language="javascript">strEstadoNombre()</script></td>
							</tr>
							<tr>
								<td width="19%" class="tdtexttablebold">
									Ciudad:
								</td>
								<td width="81%" class="tdcontentableblue"><script language="javascript">strCiudadNombre()</script></td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Direcci�n:</td>
								<td class="tdcontentableblue"><script language="javascript">strDireccionOperativaNombre()</script></td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Zona:
								</td>
								<td class="tdcontentableblue"><script language="javascript">strZonaOperativaNombre()</script></td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Descripci�n Sucursal:
								</td>
								<td class="tdcontentableblue"><input name="txtNombreSucursal" type="text" class="field" id="txtNombreSucursal" size="50"
										maxlength="50"></td>
							</tr>
						</table>
						<span class="tdpadleft5">
							<br>
							<input name="cmdConsultar" type="submit" class="button" value="Enlistar sucursales">
						</span>&nbsp;<br>
						<p>Elija la sucursal a la que quiere vincular a la tienda y oprima el bot�n 
							"Vincular". Para elegir m�s de una sucursal, haga clic en los nombres 
							correspondientes.
						</p>
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td class="tdtexttablebold"><input type="checkbox" name="chkTodo" value="checkbox" onclick="return chkTodo_onclick()">
									&nbsp;Seleccionar todas</td>
							</tr>
							<tr>
								<td width="81%" class="tdpadleft5"><select name="cboSucursales" size="10" multiple>
									</select>
								</td>
							</tr>
						</table>
						<br>
						<span class="tdpadleft5"><input name="cmdCancelar" type="button" class="button" value="Cancelar" onclick="return cmdCancelar_onclick()">
							&nbsp;&nbsp; <input name="cmdCerrar" type="button" class="button" value="Vincular" onclick="return cmdCerrar_onclick()">
						</span>
					</td>
				</tr>
			</table>
			<table width="360" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaFooterPop()</script></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
