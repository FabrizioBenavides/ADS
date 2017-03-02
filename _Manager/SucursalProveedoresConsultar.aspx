<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" enableViewState="False" Explicit="True" Trace="False" Strict="True" CodeBehind="SucursalProveedoresConsultar.aspx.vb"      Inherits="com.isocraft.backbone.ccentral.SucursalProveedoresConsultar" codePage="28592" %>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="css/menu.css" type="text/css" rel="stylesheet">
		<link href="css/estilo.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
		<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
		<script language="javascript" id="clientEventHandlersJS">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";
  
  document.frmMain.optArticulo["<%= intOpcArticulo %>"].checked = true;
  document.frmMain.optSucursal["<%= intOpcSucursal %>"].checked = true;
  document.frmMain.optProveedor.value = "<%=strOpcProveedor %>";
     
  <%= strJavascriptWindowOnLoadCommands %>;
  
}

function cmdLimpiar_onclick() {
  window.location.href = "<%= strThisPageName %>";
}
function cmdEjecutar_onclick() {
   document.forms[0].action = "<%=strFormAction%>";
   document.forms[0].submit();
}

function popVerConsulta(strCmd,intProveedorId,strProveedorNombreId,strProveedorRazonSocial) {
   url = 'popSucursalProveedoresConsultar.aspx?strCmd=' + strCmd + '&intproveedorId=' + intProveedorId + '&strProveedorNombreId=' + strProveedorNombreId + '&strProveedorRazonSocial=' + strProveedorRazonSocial  ;
      
   var Win = window.open(url,'Pop','width=770,height=640,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
            
}
function fnEliminarSucursales (intError,intContador) {
	if (intError< 0) {
       alert("No se pudo eliminar las sucursales asignadas");
	}
	else {
	  alert("Se eliminaron las [" + intContador + "] sucursales asignadas");      
    }          	
}

function cmdRegresar_onclick() {
    window.location="SucursalMercanciasProveedores.aspx"
}

//-->
		</script>
	</HEAD>
	<body language="javascript" onLoad="return window_onload()">
		<form name="frmMain" action="about:blank" method="post">
			<table cellspacing="0" cellpadding="0" width="780" border="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
			</table>
			<table cellspacing="0" cellpadding="0" width="780" border="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtab" width="770">Está en : <a href="SucursalHome.aspx">Sucursal</a> :<a href="SucursalMercancias.aspx">Mercancias</a>:<a href="SucursalMercanciasProveedores.aspx">Proveedores</a>:Consultar</td>
				</tr>
			</table>
			<table cellspacing="0" cellpadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent"><h1>Consulta de Proveedores</h1>
						<p>En esta parte se puede consultar los proveedores para las capturas de mercancia 
							de sucursales.</p>
						<h2>Criterio de Busqueda</h2>
						<table cellspacing="0" cellpadding="0" width="100%" border="0">
							<tr>
								<td class="tdTituloAzul" valign="top" width="40%">Articulos</td>
								<td width="20%">&nbsp;&nbsp;</td>
								<td class="tdTituloAzul" valign="top" width="40%">Sucursales</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" valign="top"><input type="radio" value="0" name="optArticulo">
									Todos</td>
								<td width="20">&nbsp;&nbsp;</td>
								<td class="tdtexttablebold" valign="top"><input type="radio" value="0" name="optSucursal">
									Todos</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" valign="top"><input type="radio" value="1" name="optArticulo">
									Sin Articulos Autorizados</td>
								<td width="20">&nbsp;&nbsp;</td>
								<td class="tdtexttablebold" valign="top"><input type="radio" value="1" name="optSucursal">
									Sin Sucursales Asignadas</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" valign="top"><input type="radio" value="2" name="optArticulo">
									Con Articulos Autorizados</td>
								<td width="20">&nbsp;&nbsp;</td>
								<td class="tdtexttablebold" valign="top"><input type="radio" value="2" name="optSucursal">
									Con Sucursales Asignados</td>
							</tr>
						</table>
						<table cellspacing="0" cellpadding="0" width="100%" border="0">
							<tr>
								<td class="tdtexttablebold" width="100">Proveedor:</td>
								<td class="tdpadleft5" valign="top">
									<input class="field" id="optProveedor" type="text" autocomplete="off"  maxlength="12" size="24" name="optProveedor"  value='<%=Request("strOpcProveedor")%>'>
								</td>
							</tr>
							<tr>
								<td colspan="2" height="10"><img height="10" src="images/pixel.gif" width="1"></td>
							</tr>
						</table>
						<input class="boton" id="cmdRegresar" type="button" value="Regresar" name="cmdRegresar"
							language="javascript" onclick="return cmdRegresar_onclick()"> &nbsp; <input class="boton" id="cmdEjecutar" type="button" value="Ejecutar consulta" name="cmdEjecutar"
							language="javascript" onclick="return cmdEjecutar_onclick()"> &nbsp; <input class="boton" id="cmdLimpiar" type="button" value="Limpiar" name="cmdLimpiar" language="javascript"
							onclick="return cmdLimpiar_onclick()">
						<br>
						<%= strConsultarProveedores%>
						<br>
					</td>
				</tr>
				<tr>
					<input type="hidden" name="intProveedorId" value="<%=intProveedorId%>" >
				</tr>
			</table>
			<table cellspacing="0" cellpadding="0" width="780" border="0">
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
</HTML>
