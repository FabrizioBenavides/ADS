<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalCorresponsaliaConfigurarTickets.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalCorresponsaliaConfigurarTickets"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<LINK href="css/menu.css" type="text/css" rel="stylesheet">
			<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
				<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
				<script language="javascript" id="clientEventHandlersJS">
<!--

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarTipoServicioComboBox() %>
<%= strLlenarInformacionTicket() %>
}

function almacenar_descripcion(){
var indice = document.forms[0].cboTipoServicio.selectedIndex;
var texto = document.forms[0].cboTipoServicio.options[indice].text;
var valor = document.forms[0].cboTipoServicio.options[indice].value;
document.forms[0].strServicioDescripcion.value = texto;
}

function cboTipoServicio_onchange() {
  almacenar_descripcion();
  document.forms[0].submit();
  return(true);
}

function cmdCancelar_onclick() {
   window.location.href = "SucursalCorresponsaliaServicios.aspx";
  }

function cmdGuardar_onclick() {
       document.forms[0].action += "?strCmd=Salvar";
       almacenar_descripcion();
       document.forms(0).submit();
       
 }

//-->
				</script>
	</HEAD>
	<body onload="window_onload()">
		<form name="frmSucursalCorresponsaliaConfigurarTickets" action="about:blank" method="post">
			<input type="hidden" name="strServicioDescripcion">
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
					<td class="tdtab" width="770">Está en : Sucursal : Corresponsalía : Configuración 
						de Ticket
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Tickets&nbsp;Corresponsalía Bancomer
						</h1>
						<p>Elija el tipo de servicio, ingrese el texto del ticket y presione "Aceptar"
						</p>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="tdtexttablebold" width="140">Tipo de Servicio:</td>
								<td class="tdpadleft5"><select class="campotabla" id="cboTipoServicio" onchange="return cboTipoServicio_onchange()"
										name="cboTipoServicio">
										<option value="0" selected>» Elija un Tipo de Servicio «</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="140">Información del Ticket:</td>
								<td class="tdpadleft5"><textarea language="javascript" id="txtTicket" name="txtTicket" rows="5" cols="50"> </textarea></td>
							</tr>
						</table>
						<br>
						<input class="button" type="button" value="Regresar" name="cmdCancelar" onclick="return cmdCancelar_onclick()">
						<input class="button" type="button" value="Aceptar" name="cmdGuardar" onclick="return cmdGuardar_onclick()">
						<br>
						<br>
						&nbsp;
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
