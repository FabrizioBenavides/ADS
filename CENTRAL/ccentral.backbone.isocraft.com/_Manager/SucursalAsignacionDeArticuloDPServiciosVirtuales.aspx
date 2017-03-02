<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalAsignacionDeArticuloDPServiciosVirtuales.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalAsignacionDeArticuloDPServiciosVirtuales" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
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
		<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
		<script language="JavaScript" src="js/masked_input.js"> type="text/JavaScript"</script>
		<script id="clientEventHandlersJS" language="javascript">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
 
function window_onload() {

   document.forms[0].action = "<%= strFormAction %>";

   document.forms[0].elements["txtTipoServicioVirtualDescripcion"].value = "<%= strTipoServicioVirtualDescripcion %>";
   
   if("<%= strCmd %>" == "Editar"||"<%= strCmd %>" == "Guardar")
   {
    
	document.forms[0].elements["txtCodigoProducto"].value = "<%= strServicioVirtualCodigoProducto %>";
    document.forms[0].elements["txtDescripcion"].value = "<%= strServicioVirtualDescripcion %>";
    
    //JPMB Recuperamos Los Datos de Los servicios
    document.forms[0].elements["txtintServicioVirtualId"].value = "<%= intServicioVirtualId %>";
    document.forms[0].elements["txtintTipoServicioVirtualId"].value = "<%= intTipoServicioVirtualId %>";	
    document.forms[0].elements["txtIntArticuloServicioPromocionesArticuloId"].value = "<%= IntArticuloServicioPromocionesArticuloId %>";	
   }
   

   
   
<%= strJavascriptWindowOnLoadCommands %>
}

//Se Declara el comando Para el CMD, para que se relacione con El Case de .vb 
//11  Junio 2013 JPMB ' cmdGuardar_onclick
function cmdGuardar_onclick ()
{
     document.forms[0].action += "?strCmd=Guardar&intTipoServicioId=" + <%= intTipoServicioVirtualId() %> + "&intServicioID=" + <%= intServicioVirtualId() %>;
     //document.forms[0].action += "?strCmd=Guardar&intServicioVirtualId=" + <%= intServicioVirtualId()%>;
     document.forms(0).submit();
 
}
function cmdRegresar_onclick() {
   window.location.href = "SucursalAsignacionDeArticuloServiciosVirtuales.aspx?intTipoServicioId=" + <%= intTipoServicioVirtualId() %> + "&strCmd=Asignar";
}

// PPSV JPMB 16/07/2013 Función que verifica si se estan introduciendo datos numéricos
// Entra Como Parte de La Validacion del Bug De las Lista 
function isNumber()
{
	var charCode = event.keyCode;
	if (charCode > 31 && (charCode < 48 || charCode > 57))
	{
		return false;
	}
	return true;
}


function ConsultarArticulo() {
				
	if (blnValidarCampo(document.forms[0].elements["txtIntArticuloServicioPromocionesArticuloId"], true, "Producto específico", cintTipoCampoAlfanumerico, 255, 1, "") == true) {
		
		window.open("../_ScriptLibrary/PopArticulo.aspx?blnSucursal=false&strArticuloIdNombre=" + document.forms[0].elements["txtIntArticuloServicioPromocionesArticuloId"].value + "&strArticulo=txtIntArticuloServicioPromocionesArticuloId&strArticuloNombreId=txtArticuloEncontrado&strEvalJs=opener.AutoSubmit()", "Pop", "width=500,height=540,left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no");
		
	}
}

function AutoSubmit() {

	//document.forms[0].elements["txtIntArticuloServicioPromocionesArticuloId"].value = document.forms[0].elements["txtArticuloEncontrado"].value;
	
}

function txtIntArticuloServicioPromocionesArticuloId_onkeydown(objEvent) {
	if (isEnterKey(objEvent)) {
		ConsultarArticulo();
		return(false);
	}
}

function isEnterKey(evt) {

	if (!evt) {
		
		evt = window.event
	} else if (!evt.keyCode) {
		
		evt.keyCode = evt.which
	}
	
	return (evt.keyCode == 13)
}					



		</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
		<form method="post" name="frmPage" action="SucursalAsignacionDeArticuloDPEmpresasServicios.aspx">
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td>
						<script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtab" width="770">Está en : <A href="SucursalHome.aspx">Sucursal</A> :&nbsp;Promoción 
						de Servicios&nbsp;: <A onclick="cmdRegresar_onclick()" href="#">&nbsp;Servicios 
							Virtuales </A>:Asignar Código DP Servicios Virtuales
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Promoción&nbsp;Asignación de Artículo&nbsp;Servicios Virtuales</h1>
						<p>Aquí podrá dar de alta o modificar&nbsp;el codigo DP de un servicio virtual.</p>
						<br>
						<table border="0" cellSpacing="0" cellPadding="0">
							<tr>
								<td style="WIDTH: 182px" class="tdtexttablebold" height="46" width="182"><label for="txtEmpresaNombre">Tipo 
										de Servicio:</label>
								</td>
								<td class="tdpadleft5"><input id="txtTipoServicioVirtualDescripcion" class="field" readOnly maxLength="50" size="80"
										name="txtTipoServicioVirtualDescripcion">
								</td>
							</tr>
							<tr>
								<td style="WIDTH: 182px">&nbsp;</td>
							</tr>
						</table>
						<h2>Definir&nbsp;Servicio Virtual</h2>
						<table border="0" cellSpacing="0" cellPadding="0">
							<tr>
								<td style="WIDTH: 179px" class="tdtexttablebold"><label for="txtDescripcion"> 
										Servicio:</label>
								</td>
								<td class="tdpadleft5"><input id="txtDescripcion" class="field" readOnly maxLength="80" size="80" name="txtDescripcion">
								</td>
							</tr>
							<tr>
								<td style="WIDTH: 179px" class="tdtexttablebold"><label for="txtCodigoProducto">Código 
										producto:</label>
								</td>
								<td class="tdpadleft5"><input id="txtCodigoProducto" class="field" readOnly maxLength="80" size="80" name="txtCodigoProducto">
								</td>
							</tr>
							<tr>
								<td style="WIDTH: 179px" class="tdtexttablebold">
									<label for="txtIntArticuloServicioPromocionesArticuloId">Artículo ID:</label>
								</td>
								<td class="tdpadleft5">
									<input id="txtIntArticuloServicioPromocionesArticuloId" class="field" maxLength="80" size="80" name="txtIntArticuloServicioPromocionesArticuloId" onkeydown="return txtIntArticuloServicioPromocionesArticuloId_onkeydown(event)">
									<a href="javascript:ConsultarArticulo()">
										<img height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0">
									</a>
									<input name="txtArticuloEncontrado" type="text" class="campotablaresultado" size="40" border="0" id="txtArticuloEncontrado"  onchange="javascript:AsignarValorCampo()" readonly>
								</td>
							</tr>
						</table>
						<br>
						<br>
						<table>
							<tr>
								<td class="tdtexttablebold" vAlign="top" colSpan="2" align="right">
									<input id="cmdRegresar" language="javascript" class="button" onclick="return cmdRegresar_onclick()" value="Regresar" type="button" name="cmdRegresar">
								</td>
								<td class="tdtexttablebold" vAlign="top" colSpan="2" align="right">
									<input class="button" onclick="return cmdGuardar_onclick()" value="Guardar" type="button" name="cmdGuardar">
								</td>
							</tr>
						</table>
						<br>
						<BR>
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td>
						<script language="JavaScript">crearTablaFooterCentral()</script>
					</td>
				</tr>
				<tr>
					<td class="tdpadleft5" rowSpan="2">
							<select style="display:none;" id="cboIntegrador" class="campotabla" onchange="cboIntegrador_onChange(this.form.cboIntegrador)" name="cboIntegrador">
								<option selected value="0">» Elija integrador «</option>
							</select>
							<input id="txtintServicioVirtualId" class="field" readOnly maxLength="50" size="30" name="txtintServicioVirtualId" style="display:none;"> 
							<input id="txtintTipoServicioVirtualId" class="field" readOnly maxLength="50" size="30" name="txtintTipoServicioVirtualId" style="display:none;">
					</td>
				</tr>
			</table>
			<script language="JavaScript">
 
	  new menu (MENU_ITEMS, MENU_POS);

			</script>
		</form>
	</body>
</HTML>
