<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEmpresasServiciosEditarSucursal.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEmpresasServiciosEditarSucursal"%>
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
	<script language="javascript" id="clientEventHandlersJS">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
 document.forms[0].action = "<%= strFormAction %>";
 
  document.forms[0].elements["txtCompaniaId"].value = "<%= intCompaniaId %>";
  document.forms[0].elements["txtSucursalId"].value = "<%= intSucursalId %>";  
  document.forms[0].elements["txtSucursalNombre"].value = "<%= strSucursalNombre %>";
   
  <%= strJavascriptWindowOnLoadCommands %>
}

function cmdCancelar_onclick() {
   window.location.href = "SucursalEmpresasServiciosAsignarEmpresa.aspx?intEmpresaServicioId=<%= intEmpresaServicioId %>&intCompaniaId=<%= intCompaniaId %>&intSucursalId=<%= intSucursalId %>";
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
						Administrar Empresas </A>: <A href="SucursalEmpresasServiciosAsignarEmpresa.aspx">
						Asignar Sucursales </A>: Editar Sucursal
				</td>
			</tr>
		</table>
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
			<tr>
				<td class="tdgeneralcontent">
					<h1>Edición de Sucursal</h1>
					<p>Aquí podrá eliminar empresas de servicios de la sucursal</p>
					<table cellSpacing="0" cellPadding="0" border="0">
						<tr>
							<td class="tdtexttablebold" width="120">
								<p><label for="txtCompaniaId">Compania:</label>
								</p>
							</td>
							<td class="tdpadleft5" width="499"><input class="campotablaresultado" id="txtCompaniaId" readOnly type="text" maxLength="80"
									size="80" name="txtCompaniaId">
							</td>
						</tr>
						<tr>
							<td class="tdtexttablebold" width="120">
								<p><label for="txtSucursalId">Sucursal:</label>
								</p>
							</td>
							<td class="tdpadleft5" width="499"><input class="campotablaresultado" id="txtSucursalId" readOnly type="text" maxLength="80"
									size="80" name="txtSucursalId">
							</td>
						</tr>
						<tr>
							<td class="tdtexttablebold"><label for="txtSucursalNombre">Nombre:</label>
							</td>
							<td class="tdpadleft5"><input class="campotablaresultado" id="txtSucursalNombre" readOnly type="text" maxLength="80"
									size="80" name="txtSucursalNombre">
							</td>
						</tr>
						<tr>
							<td width="120" height="20"></td>
						</tr>
						<tr>
							<td width="120"><input class="button" id="cmdCancelar" onclick="return cmdCancelar_onclick()" type="button"
									value="Regresar" name="cmdCancelar">
								<br>
							</td>
						</tr>
						<tr>
							<td width="10" height="10"></td>
						</tr>
						<tr>
							<%= strGetRecordBrowserHTML() %>
						</tr>
					</table>
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
