<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEmpresasServiciosAdministrarEmpresas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEmpresasServiciosAdministrarEmpresas"%>
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
<%= strJavascriptWindowOnLoadCommands %>
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

function cmdAgregar_onclick() {
	document.forms[0].action = "SucursalEmpresasServiciosAdministrarEmpresas.aspx?strCmd=Agregar"
    document.forms[0].submit(); 
   
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
						Empresas de Servicios</A> : Administrar Empresas</td>
			</tr>
		</table>
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
			<tr>
				<td class="tdgeneralcontent">
					<h1>Administrar Empresas</h1>
					<p>Aquí podrá dar de alta o modificar empresas de servicios. Asignar a sucursales 
						la empresa seleccionada y editar el formato de lectura.</p>
					<br>
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
