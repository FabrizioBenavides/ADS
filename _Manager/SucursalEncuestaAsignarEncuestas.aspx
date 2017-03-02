<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEncuestaAsignarEncuestas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEncuestaAsignarEncuestas"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HEAD>
	<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
	<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
	<link href="css/menu.css" rel="stylesheet" type="text/css">
	<link href="css/estilo.css" rel="stylesheet" type="text/css">
	<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
	<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
	<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
	<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
	<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
	<script language="JavaScript" src="js/calendario.js"></script>
	<script language="JavaScript" src="js/cal_format00.js"></script>
	<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {  
  document.forms[0].action = "<%= strFormAction %>";
  
  document.forms[0].elements["txtEncuestaId"].value = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(intEncuestaId) %>";
  document.forms[0].elements["txtEncuestaNombre"].value = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(strEncuestaNombre) %>";
  document.forms[0].elements["txtEncuestaDescripcion"].value = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(strEncuestaDescripcion) %>";
  
  document.forms[0].elements["txtEncuestaInicio"].value = "<%= dtmEncuestaInicio.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) %>";
  document.forms[0].elements["txtEncuestaFin"].value = "<%= dtmEncuestaFin.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) %>";
  
  document.forms[0].elements["chkEncuestaObligatoria"].checked = <%= blnEncuestaObligatoria.ToString().ToLower() %>;  
  document.forms[0].elements["chkEncuestaActivo"].checked = <%= blnEncuestaActivo.ToString().ToLower() %>;
  
  document.forms[0].elements["chkEncuestaObligatoria"].disabled = true;
  document.forms[0].elements["chkEncuestaActivo"].disabled = true;      
      
   <%= strJavascriptWindowOnLoadCommands %>
     
}

function cmdAsignarSucursales_onclick() {
  Pop('popEncuestaAsignarSucursalesAEncuesta.aspx?intEncuestaId=<%= intEncuestaId %>&strEncuestaNombre=<%= strEncuestaNombre %>','360','520');
}

function cmdBorrarTodasSucursales_onclick() {
  var blnReturn = confirm("¿Esta seguro(a) que desea borrar todas las sucursales asignadas a este cliente?");
  if ( blnReturn == true) {
    document.forms[0].action += "?strCmd=EliminarSucursales";
  }
  return(blnReturn);
}


function cmdCancelar_onclick() {
    window.location.href = "SucursalEncuestaAdministrarEncuestas.aspx";
}

function cmdGuardar_onclick() {

}

//-->
	</script>
</HEAD>
<body language="javascript" onLoad="return window_onload()">
	<form method="post" action="about:blank" name="frmPage">
		<table width="780" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td><script language="JavaScript">crearTablaHeader()</script>
				</td>
			</tr>
		</table>
		<table width="780" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td width="10">&nbsp;</td>
				<td width="770" class="tdtab">Está en : <a href="SucursalHome.aspx">Sucursal</a> : <a href="SucursalEncuestasHome.aspx">
						Encuestas</a> : Administrar&nbsp;encuesta</td>
			</tr>
		</table>
		<table width="780" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td class="tdgeneralcontent"><h1>Datos de la encuesta</h1>
					<p>Aquí podrá asignar la encuesta seleccionada a la (s) sucursal(es) indicadas.</p>
					<table border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td width="120" class="tdtexttablebold"><p>
									<label for="txtEncuestaNombre">Nombre en CTX:</label>
								</p>
							</td>
							<td width="499" class="tdpadleft5"><input name="txtEncuestaNombre" type="text" class="campotablaresultado" id="txtEncuestaNombre"
									size="80" maxlength="80" readonly>
							</td>
						</tr>
						<tr>
							<td class="tdtexttablebold"><label for="txtEncuestaDescripcion">Nombre en POS:</label>
							</td>
							<td class="tdpadleft5"><input name="txtEncuestaDescripcion" type="text" class="campotablaresultado" id="txtEncuestaDescripcion"
									size="80" maxlength="80" readonly>
							</td>
						</tr>
						<tr>
							<td valign="top" class="tdtexttablebold"><label for="txtEncuestaInicio">Fecha Inicio:</label>
							</td>
							<td class="tdpadleft5"><input name="txtEncuestaInicio" id="txtEncuestaInicio" class="campotablaresultado" size="12"
									maxlength="12" type="text" readonly>
							</td>
						</tr>
						<tr>
							<td valign="top" class="tdtexttablebold"><label for="txtEncuestaFin">Fecha Fin:</label>
							</td>
							<td class="tdpadleft5"><input name="txtEncuestaFin" id="txtEncuestaFin" class="campotablaresultado" size="12"
									maxlength="12" readonly type="text">
							</td>
						</tr>
						<tr>
							<td valign="top" class="tdtexttablebold"><label for="chkEncuestaObligatoria">¿Obligatoria 
									en POS?</label>
							</td>
							<td class="tdpadleft5">
								<input name="chkEncuestaObligatoria" type="checkbox" id="chkEncuestaObligatoria" value="True"
									class="campotablaresultado" >
							</td>
						</tr>
						<tr>
							<td valign="top" class="tdtexttablebold"><label for="chkEncuestaActivo">¿Activo?</label>
							</td>
							<td class="tdpadleft5">
								<input name="chkEncuestaActivo" type="checkbox" id="chkEncuestaActivo" value="True" class="campotablaresultado">									
							</td>
						</tr>
						<tr>
							<td height="10" colspan="2" align="right" valign="top" class="txaccion">&nbsp;</td>
						</tr>
						<tr>
							<td colspan="2" valign="top" class="tdtexttablebold">
								<input name="cmdCancelar" type="button" class="button" id="cmdCancelar" value="Regresar"
									language="javascript" onclick="return cmdCancelar_onclick()">
							</td>
						</tr>
					</table>
					<%= strGetRecordBrowserHTML() %>
				</td>
			</tr>
		</table>
		<input name="txtEncuestaId" type="hidden">
		<table width="780" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td><script language="JavaScript">crearTablaFooterCentral()</script>
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
