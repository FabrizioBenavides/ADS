<%@ Page Language="vb" AutoEventWireup="false" Codebehind="popSistemaElegirSucursalActualizar.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popSistemaElegirSucursalActualizar"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="css/estilo.css" rel="stylesheet" type="text/css">
			<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
			<script id="clientEventHandlersJS" language="javascript">


strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarDireccionComboBox() %>
<%= strLlenarZonaComboBox() %>
<%= strLlenarSucursalComboBox() %>

if (document.forms[0].elements["cboSucursal"].length > 0)  {
   document.all.tblSucursales.style.display='';   
}
else {
   document.all.tblSucursales.style.display='none';
}
  
}

function cmdCancelar_onclick() {
  window.close();
}

function cmdCerrar_onclick() {
  regreso = true;
  
  if (document.forms[0].elements["cboDireccion"].value < 0) {
       alert("Seleccionar la Dirección o selecionar todas");
       regreso = true;
  }
  if (regreso && document.forms[0].elements["cboZona"].value < 0) {
       alert("Seleccionar la Zona o selecionar todas");
       regreso = true;
  }
   
   
   if(regreso) {   
       document.forms[0].action += "?strCmd=Cerrar";
       document.forms[0].submit();
   } 
   else {
       alert("Selecionar al menos una sucursal.");
       document.forms[0].elements["cboDireccion"].focus();
       return(false);
   }
}

function cboDireccion_onchange() {
   document.all.tblSucursales.style.display = 'none';
  
  if (document.forms[0].elements["cboDireccion"].selectedIndex > 0) {
    document.forms[0].elements["cboZona"].selectedIndex = 0;
    document.forms[0].submit();
  }
  return(true);
}

			
function cboZona_onchange() {
   document.all.tblSucursales.style.display=''; 
   document.forms[0].action += "?strCmd=?";
   document.forms[0].submit();
   	
}

			</script>
</HEAD>
<body onload="return window_onload()">

<form method="post" action="about:blank">
<table width="450" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td width="450" class="tdgeneralcontentpop"><h2>Seleccionar Sucursal(es) a Actualizar 
							Catálogos</h2>
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td class="tdtexttablebold">Dirección:</td>
								<td class="tdpadleft5" colspan="2"><select name="cboDireccion" class="field" onchange="return cboDireccion_onchange()">
										<option value="-1">Seleccionar la Direccion Operativa</option>
										<option value="0" selected>Todas las Direcciones</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Zona:</td>
								<td class="tdpadleft5" colspan="2"><select name="cboZona" class="field" onchange="return cboZona_onchange()">
										<option value="-1">Seleccionar la Zona Operativa</option>
										<option value="0" selected>Todas las Zonas</option>
									</select>
								</td>
							</tr>
						</table>
						<br>
						<p>Elija las sucursales que desea seleccionar y oprima el botón cerrar selección. 
							Para elegir más de una sucursal, haga clic en los nombres correspondientes.
						</p>
						<table id="tblSucursales" width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="81%" class="tdpadleft5"><select name="cboSucursal" size="18" multiple>
									</select>
								</td>
							</tr>
						</table>
						<input name="cmdCancelar" type="button" class="button" value="Cancelar" onclick="return cmdCancelar_onclick()">
						&nbsp; <input name="cmdCerrar" type="button" class="button" value="Cerrar selección" onclick="return cmdCerrar_onclick()">
					</td>
				</tr>
			</table>
</form>
</body>
</html>
