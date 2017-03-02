<%@ Page Language="vb" AutoEventWireup="false" Codebehind="popEncuestaAsignarSucursalesAEncuesta.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popEncuestaAsignarSucursalesAEncuesta" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HEAD>
	<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
	<link href="css/estilo.css" rel="stylesheet" type="text/css">
		<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
		<script id="clientEventHandlersJS" language="javascript">
<!--

function window_onload() {
        
   document.forms[0].action = "<%= strFormAction %>";
   
   var intDireccionId = "<%= intDireccionId %>";
   var intZonaId = "<%= intZonaId %>";
   
   document.forms[0].elements["txtEncuestaId"].value = "<%= intEncuestaId %>";   
   document.forms[0].elements["txtEncuestaDescripcion"].value = "<%= strEncuestaNombre %>";
      
   <%= strJavascriptWindowOnLoadCommands %>
   <%= strLlenarDireccionComboBox() %>
   <%= strLlenarZonaComboBox() %>
   <%= strLlenarSucursalComboBox() %>
   
   /* Deshabilitamos las zonas, si se han seleccionado todas las direcciones */
   if (intDireccionId == "-1") {
       document.forms[0].elements["cboDireccion"].options[1].selected = true;
       document.forms[0].elements["cboZona"].disabled = true;
   }
   
   if (intZonaId == "-1") {
       document.forms[0].elements["cboZona"].options[1].selected = true;
   }
   
   /* Deshabilitamos la opción de seleccionar todas las sucursales y el botón asignar,
      si no hay sucursales */
  if (document.forms[0].elements["cboSucursales"].length == 0) {
    document.forms[0].elements["chkSeleccionarTodasSucursales"].disabled = true;
    document.forms[0].elements["cmdAsignar"].disabled = true;
  }

}

function cboDireccion_onchange() {
  if (document.forms[0].elements["cboDireccion"].selectedIndex > 0) {
    document.forms[0].elements["cboZona"].selectedIndex = 0;
    document.forms[0].submit();
  }
  return(true);
}

function cboZona_onchange() {
  if (document.forms[0].elements["cboZona"].selectedIndex > 0) {
    document.forms[0].submit();
  }
}

function chkSeleccionarTodasSucursales_onclick() {
  SelectAllComboBoxElements(document.forms[0].elements["cboSucursales"], document.forms[0].elements["chkSeleccionarTodasSucursales"].checked);
}

function cmdCancelar_onclick() {
  window.close();
}

function cmdAsignar_onclick() {
  if (blnComboBoxHasAnElementSelected(document.forms[0].elements["cboSucursales"]) == false) {
    alert("Por favor seleccione al menos una sucursal.");
    document.forms[0].elements["cboSucursales"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=Asignar";
  return(true);
}

//-->
		</script>
</HEAD>
<body language="javascript" onload="return window_onload()">
	<form method="post" action="about:blank" name="frmPage">
		<table width="360" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td><script language="JavaScript">crearTablaHeaderPop()</script>
				</td>
			</tr>
		</table>
		<table width="360" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td class="tdgeneralcontentpop"><h2>Asignar sucursales
					</h2>
					<table width="100%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td width="19%" class="tdtexttablebold">Dirección:</td>
							<td width="81%" class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" language="javascript" onchange="return cboDireccion_onchange()">
									<option value="0" selected>--- Elija una dirección ---</option>
									<option value="-1">Todas las direcciones</option>
								</select>
							</td>
						</tr>
						<tr>
							<td class="tdtexttablebold">Zona:</td>
							<td class="tdpadleft5"><select name="cboZona" class="field" id="cboZona" language="javascript" onchange="return cboZona_onchange()">
									<option value="0" selected>Elija una zona</option>
									<option value="-1">Todas las zonas</option>
								</select>
							</td>
						</tr>
					</table>
					<br>
					<p>Elija la(s) sucursal(es) que desea asignar a la encuesta, y oprima el botón 
						“Asignar”. Para elegir más de una sucursal, haga clic en los nombres 
						correspondientes.
					</p>
					<table width="100%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td class="tdtexttablebold"><input name="chkSeleccionarTodasSucursales" type="checkbox" id="chkSeleccionarTodasSucursales"
									value="True" language="javascript" onclick="return chkSeleccionarTodasSucursales_onclick()">
								&nbsp;Seleccionar todas</td>
						</tr>
						<tr>
							<td class="tdblueframe"><select name="cboSucursales" size="10" multiple class="fieldcomment" id="cboSucursales">
								</select>
							</td>
						</tr>
					</table>
					<br>
					<span class="tdpadleft5">
        <input name="cmdCancelar" type="button" class="button" id="cmdCancelar" value="Cancelar"
							language="javascript" onclick="return cmdCancelar_onclick()">
&nbsp;&nbsp;
        <input name="cmdAsignar" type="submit" class="button" id="cmdAsignar" value="Asignar" language="javascript"
							onclick="return cmdAsignar_onclick()">
        </span></td>
			</tr>
		</table>
		<input name="txtEncuestaId" type="hidden"> <input name="txtEncuestaDescripcion" type="hidden">
		<table width="360" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td><script language="JavaScript">crearTablaFooterPop()</script>
				</td>
			</tr>
		</table>
	</form>
</body>
