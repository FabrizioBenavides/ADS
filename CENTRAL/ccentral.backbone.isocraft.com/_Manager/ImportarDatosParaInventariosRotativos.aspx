<%@ Page CodeBehind="ImportarDatosParaInventariosRotativos.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsImportarDatosParaInventariosRotativos" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<HTML>
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
		<script language="JavaScript" src="../static/scripts/InvRotUtils.js" type="text/JavaScript"></script>
		<script language="javascript" id="clientEventHandlersJS">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  //if (document.forms[0].intListadoId.value != "" && document.forms[0].intListadoId.value != "0")
  {	
    document.forms[0].x.focus()
    document.forms[0].Document.select()
	document.forms[0].Document.focus()
  }  
}

//function doSubmit(action, param, id) 
function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
	if (action == "Borrar")
	{	
		if (!confirm ("¿Esta seguro de borrar los registros relacionados a este Listado?") )
			return;
	}
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{
		params+= "&" + args[i] + "=" + args[i+1]
	}
	
	if (action == "MostrarRegistros")
	{
		window.open("MostrarDetalleParaInventariosRotativos.aspx?strCmd=" + action + params, "showRecords", "status=yes,width=800,height=450,resizable=no,scrollbars=yes")
	}
	else
	{
		document.forms[0].action = "ImportarDatosParaInventariosRotativos.aspx?strCmd=" + action + params
		document.forms[0].submit();  
	}
}

//-->
		</script>
	</HEAD>
	<body onload="return window_onload()">
		<form name="frmSistemaAdministrarTiendas" id="Form1" enctype="multipart/form-data" runAt="server" action="" method="post">
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
					<td class="tdtab" width="770">Está en : INV ROTATIVO : Listados Rotativos : 
						Importar datos
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Importar Datos para Listado para Inventarios Rotativos</h1>
						<p>Seleccione el listado y después seleccione el archivo para importar los datos. 
							Seleccione "Vista Previa" para ver los primeros 100 registros. Seleccione 
							"Importar" para realizar la carga de datos.
						</p>
						<%= strRecordBrowserHTML() %>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0" class="tdenvolventetablas">
							<tr>
								<td class="tdtexttablebold" width="25%">Nombre:</td>
								<td class="tdpadleft5" width="75%">
									<input type="hidden" runat="server" name="uploadListadoId" id="uploadListadoId">
									<input type="hidden" runat="server" name="uploadFecha" id="uploadFecha"> <input type="hidden" runat="server" name="uploadUser" id="uploadUser">
									<input type="hidden"  name="intListadoId" value="<%= intListadoId %>" > <input type="text" runat="server" id="txtListadoNombre" readonly name="txtListadoNombre" size="50"></td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Archivo de datos:</td>
								<td class="tdpadleft5"><input type="file" runAt="server" id="Document" name="Document" Width="219px"></td>
							</tr>
							<tr>
								<td class="tdtexttablebold"></td>
								<td class="tdpadleft5">
									<input id="ButtonPrevio" name="ButtonPrevio" runat="server" type="submit" class="boton" value="Vista Previa" onclick="setAction('vistaPrevia')" onserverclick="cargaPrevia">
									<input id="ButtonImportar" name="ButtonImportar" runat="server" type="submit" class="boton" value="Importar" onserverclick="importar">
									<input id="ButtonLimpiar" name="ButtonLimpiar" runat="server" type="submit" class="boton" value="Limpiar" onserverclick="limpiar">&nbsp;
								</td>
							</tr>
						</table>
						<%= strVistaPreviaHTML() %>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td id="x">
						<script language="JavaScript">crearTablaFooter()</script>
					</td>
				</tr>
			</table>
			<script language="JavaScript">
				<!--
				new menu (MENU_ITEMS, MENU_POS);
				//-->
			</script>
			<input type="text" name='x' class='fieldborderless' size='1' maxlength='0' readonly onfocus='blur()'>
		</form>
	</body>
</HTML>
