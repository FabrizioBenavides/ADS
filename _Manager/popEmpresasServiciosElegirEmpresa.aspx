<%@ Page Language="vb" AutoEventWireup="false" Codebehind="popEmpresasServiciosElegirEmpresa.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popEmpresasServiciosElegirEmpresa"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
		<script language="javascript" id="clientEventHandlersJS">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  
  <%= strJavascriptWindowOnLoadCommands %>
  
  <%= strLlenarEmpresasComboBox() %>
  if (document.forms[0].elements["cboEmpresas"].length == 0) {
    document.forms[0].elements["cmdCerrar"].disabled = true;
    alert("No hay empresas disponibles.");
    window.close();
  }
}

function cmdCancelar_onclick() {
  window.close();
}

function cmdCerrar_onclick() {
  var blnSelected = false;
  for (var intCounter = 0; intCounter < document.forms[0].elements["cboEmpresas"].length; intCounter++) {
    blnSelected = document.forms[0].elements["cboEmpresas"].options[intCounter].selected;
    if (blnSelected == true) {
      break;
    }
  }
  if (blnSelected == true) {
    document.forms[0].action += "?strCmd=Cerrar";
    document.forms[0].submit();
  } else {
    alert("Por favor seleccione al menos una empresa.");
    return(false);
  }
}

		</script>
	</HEAD>
	<body onload="return window_onload()">
		<form name="frmPopSucursalElegirSucursales" action="about:blank" method="post">
			<table cellSpacing="0" cellPadding="0" width="360" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaHeaderPop()</script>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="360" border="0">
				<tr>
					<td class="tdgeneralcontentpop">
						<h2>Elegir empresas
						</h2>
						<p>Elija la empresa para la consulta de pagos y oprima el botón "Cerrar selección". 
							Para elegir más de una empresa, haga clic en los nombres correspondientes.
						</p>
						<table cellSpacing="0" cellPadding="0" width="60%" border="0">
							<tr>
								<td class="tdblueframe"><select multiple class="fieldcomment" id="cboEmpresas" size="10" name="cboEmpresas"></select>
								</td>
							</tr>
						</table>
						<br>
						<span class="tdpadleft5"><input class="button" onclick="return cmdCancelar_onclick()" type="button" value="Cancelar"
								name="cmdCancelar"> &nbsp;&nbsp; <input class="button" onclick="return cmdCerrar_onclick()" type="button" value="Cerrar selección"
								name="cmdCerrar"> </span>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="360" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaFooterPop()</script>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
