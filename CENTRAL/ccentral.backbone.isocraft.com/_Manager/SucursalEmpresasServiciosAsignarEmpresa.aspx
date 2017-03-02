<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEmpresasServiciosAsignarEmpresa.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEmpresasServiciosAsignarEmpresa"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HEAD>
	<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
	<LINK href="css/menu.css" type="text/css" rel="stylesheet">
	<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
	<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
	<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
	<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
	<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
	<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
	<script language="JavaScript" src="js/calendario.js"></script>
	<script language="JavaScript" src="js/cal_format00.js"></script>
	<script language="javascript" id="clientEventHandlersJS">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {  
  document.forms[0].action = "<%= strFormAction %>";
 
  document.forms[0].elements["txtEmpresaServicioId"].value = "<%= intEmpresaServicioId %>";  
  document.forms[0].elements["txtEmpresaServicioNombre"].value = "<%= strEmpresaServicioNombre %>";
  document.forms[0].elements["chkEmpresaServicioActiva"].checked = <%= blnEmpresaServicioActiva.ToString().ToLower() %>;
  document.forms[0].elements["chkEmpresaServicioActiva"].disabled = true;
    
   <%= strJavascriptWindowOnLoadCommands %>
}

function cmdAsignarSucursales_onclick() {
  var Comision = 0
  Comision = parseFloat(document.forms[0].txtEmpresaComision.value);
  
  if (blnValidarCampo(document.forms[0].elements["txtEmpresaComision"], true, "Comisión", cintTipoCampoAlfanumerico, 50, 1, "") == true){
    if (checkDecimals(document.forms[0].elements["txtEmpresaComision"],document.forms[0].elements["txtEmpresaComision"].value,"Comisión")== true){
      Pop('popEmpresasServiciosAsignarSucursalesAEmpresa.aspx?intEmpresaServicioId=<%= intEmpresaServicioId %>&strEmpresaServicioNombre=<%= strEmpresaServicioNombre %>&fltComision=' + Comision ,'360','700');
      return(true);
    }
  }
    document.forms[0].elements["txtEmpresaComision"].focus();
    return(false);
}

function cmdBorrarTodasSucursales_onclick() {
  var blnReturn = confirm("¿Esta seguro(a) que desea borrar todas las sucursales asignadas a este cliente?");
  if ( blnReturn == true) {
	document.forms[0].elements["chkEmpresaServicioActiva"].disabled = false;
    document.forms[0].action += "?strCmd=EliminarSucursales";
  }
  return(blnReturn);
}

function cmdCancelar_onclick() {
    window.location.href = "SucursalEmpresasServiciosAdministrarEmpresas.aspx";   
}

function ActivateRow(intRowToShow) {
   var table = document.all? document.all.tableRegistro : document.getElementById('tableRegistro');
   table.rows[intRowToShow-1].style.display = 'none';
   table.rows[intRowToShow].style.display = '';
   table.rows[intRowToShow + 1].style.display = '';
}

function DeactivateRow(intRowToHide) {
  
   var table = document.all? document.all.tableRegistro : document.getElementById('tableRegistro');
   
   table.rows[intRowToHide- 1].style.display = '';
   table.rows[intRowToHide].style.display = 'none';
   table.rows[intRowToHide+ 1].style.display = 'none';	
}
				
function AllOpen() {
   var table = document.all? document.all.tableRegistro : document.getElementById('tableRegistro');
   <%=strAbreDetalleEmpresa%>	
}

 //Valida que se ingresen solo numeros con dos decimales maximo
function checkDecimals(fieldName, fieldValue, campo) {

  decallowed = 2;  // Que tantos decimales son permitidos?

  if (isNaN(fieldValue) || fieldValue == "") {
	alert("Por favor introduce un valor numérico en el campo \"" + campo + "\".");
	fieldName.select();
	fieldName.focus();
	return(false)
  }
  else {
    if (fieldValue.indexOf('.') == -1) fieldValue += ".";
    dectext = fieldValue.substring(fieldValue.indexOf('.')+1, fieldValue.length);
	if (dectext.length > decallowed)
	{
	  alert("El valor del campo \"" + campo + "\", debe tener a lo más " + decallowed + " decimales.");
	  fieldName.select();
	  fieldName.focus();
	  return(false);
    }
	else {
	  return(true);
    }
  }
}

//-->
	</script>
</HEAD>
<body language="javascript" onload="AllClosed();return window_onload()">
	<form name="frmPage" action="about:blank" method="post">
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
				<td class="tdtab" width="770">Está en : <A href="SucursalHome.aspx">Sucursal</A> : <A href="SucursalEmpresasServiciosHome.aspx">
						Empresas de Servicios</A> :<A href="SucursalEmpresasServiciosAdministrarEmpresas.aspx">
						Administrar Empresas </A>: Asignar Sucursales
				</td>
			</tr>
		</table>
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
			<tr>
				<td class="tdgeneralcontent">
					<h1>Datos de la empresa</h1>
					<p>Aquí podrá asignar la empresa de servicios seleccionada a la (s) sucursal(es) 
						indicadas.</p>
					<table cellSpacing="0" cellPadding="0" border="0">
						<tr>
							<td class="tdtexttablebold" width="120">
								<p><label for="txtEmpresaServicioId">Número:</label>
								</p>
							</td>
							<td class="tdpadleft5" width="499"><input class="campotablaresultado" id="txtEmpresaServicioId" readOnly type="text" maxLength="80"
									size="80" name="txtEmpresaServicioId">
							</td>
						</tr>
						<tr>
							<td class="tdtexttablebold"><label for="txtEmpresaServicioNombre">Empresa:</label>
							</td>
							<td class="tdpadleft5"><input class="campotablaresultado" id="txtEmpresaServicioNombre" readOnly type="text" maxLength="80"
									size="80" name="txtEmpresaServicioNombre">
							</td>
						</tr>
						<tr>
							<td class="tdtexttablebold" vAlign="top"><label for="chkEmpresaServicioActiva">¿Activa?</label>
							</td>
							<td class="tdpadleft5"><input class="campotablaresultado" id="chkEmpresaServicioActiva" type="checkbox" value="True"
									name="chkEmpresaServicioActiva">
							</td>
						</tr>
					</table>
					<table>
						<tr>
							<td class="tdtexttablebold" width="21%"><label for="txtEmpresaComision">Comision</label></td>
							<td class="tdpadleft5" width="29%"><input class="field" id="txtEmpresaComision" type="text" maxLength="20" size="20" name="txtEmpresaComision"></td>
							<td class="tdpadleft5" width="25%">&nbsp;</td>
							<td class="tdpadleft5" width="25%">&nbsp;</td>
						</tr>
						<tr>
							<td class="txaccion" vAlign="top" align="right" colSpan="4" height="10">&nbsp;</td>
						</tr>
						<tr>
							<td class="tdtexttablebold" vAlign="top" colSpan="4"><input language="javascript" class="button" id="cmdCancelar" onclick="return cmdCancelar_onclick()"
									type="button" value="Regresar" name="cmdCancelar">
							</td>
						</tr>
					</table>
					<%= strGetRecordBrowserHTML() %>
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
		<script>
	function AllClosed() {
   var table = document.all? document.all.tableRegistro : document.getElementById('tableRegistro');   
   <%=strCierraDetalleEmpresa%>	
   }
		</script>
	</form>
</body>
