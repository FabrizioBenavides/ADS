<%@ Page CodeBehind="SucursalSinCierreInventario.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalSinCierreInventario" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="True" enableViewState="False" %>

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
		<script language="JavaScript" src="js/cal_format00.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/calendario.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="../static/scripts/InvRotUtils.js" type="text/JavaScript"></script>
		<script language="javascript" id="clientEventHandlersJS">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() 
{
  document.forms[0].action = "<%= strThisPageName %>";
}

function validateFilter()
{	
	var result = false
	if (! window.document.forms[0].radioSelDate[0].checked 
		&& !window.document.forms[0].radioSelDate[1].checked )
	{	alert ("Seleccione la fecha para filtrado de la lista.")	}
	else if (window.document.forms[0].radioSelDate[1].checked
		&& window.document.forms[0].selectedDate.value=="")
	{	alert ("Favor de seleccionar una fecha.")	}
	else if (document.forms[0].intDireccionId.selectedIndex <=0)
	{	alert ("Seleccione una dirección.")  	}
	else
	{	
		result = true	
		var myForm = window.document.forms[0]
		var intDireccion = myForm.intDireccionId.options[myForm.intDireccionId.selectedIndex].value
		myForm.selectedDirectionId.value = intDireccion
	}
	
	return result
}

function validateForm()
{
	var result = false
	if (currentAction == "filtrar")
	{	result = validateFilter()	}
	else if (document.forms[0].intDireccionId.selectedIndex >= 0 )
	{
		result = true
	}
	
	return result
}


function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{
		params+= "&" + args[i] + "=" + args[i+1]
	}
    document.forms[0].action = "SucursalSinCierreInventario.aspx?strCmd=" + action + params
    document.forms[0].submit();  
}

//-->
		</script>
</HEAD>
	<body onload="return window_onload()">
		<form name="frmSistemaAdministrarTiendas" onsubmit="return validateForm()" method="post" runAt="server" ID="Form1">
			<input type="hidden" name="documentPrinted" value="0"> <input type="hidden" name="documentExported" value="0">
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
					<td class="tdtab" width="770">Está en : INV ROTATIVO : Sucursales : Deshabilitar 
						sucursales
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Consulta de&nbsp; Sucursales sin Cierre&nbsp;de Inventario</h1>
						<p>Para consultar las sucursales que No han Cerrado su Inventario, seleccione una 
							fecha y una dirección, después&nbsp;presione "Aceptar".&nbsp;Para imprimir la 
							lista, presione el botón "Imprimir". Si desea exportar la lista, presione el 
							botón "Exportar", en caso de que aparezca una ventana preguntando si desea 
							"Abrir" (open) o Guardar (save), seleccione la opción "Abrir" (open).
						</p>
						<table cellSpacing="0" cellPadding="0" width="50%" border="0">
							<tr>
								<td class="tdtexttablebold" width="14%"><asp:radiobutton id="dateSelection1" runat="server" GroupName="radioSelDate" Text="Hoy"></asp:radiobutton></td>
								<td class="tdpadleft5" width="86%"><asp:textbox id="currentDate" runat="server" MaxLength="0" CssClass="fieldborderless"></asp:textbox></td>
							</tr>
							<tr>
								<td class="tdtexttablebold"><asp:radiobutton id="dateSelection2" runat="server" GroupName="radioSelDate" Text="Fecha"></asp:radiobutton></td>
								<td class="tdpadleft5"><asp:textbox id="selectedDate" runat="server" MaxLength="0" ReadOnly CssClass="field"></asp:textbox>&nbsp;<A href="javascript:javascript:cal1.popup()"><IMG border='0' src="images/imgCalendarIcon.gif"></A>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Dirección:</td>
								<td class="tdpadleft5">
									<asp:listbox id="intDireccionId" runat="server" Rows="1" CssClass="field"></asp:listbox></td>
							</tr>
							<tr>
								<td class="tdtexttablebold"></td>
								<td class="tdpadleft5">
								<input class="boton" id="btnAceptar" onclick="setAction('filtrar');" type="submit" value="Aceptar" name="btnAceptar" runat="server" onserverclick="btnAceptar_Click">
									<input type="hidden" id="selectedDirectionId" name="selectedDirectionId" runat="server">
								</td>
							</tr>
						</table>
						<BR>
						<%= strRecordBrowserHTML() %>
						<BR>
						<table cellSpacing="0" cellPadding="0" width="50%" border="0">
							<tr>
								<td class="tdpadleft5"><input class="boton" id="btnImprimir" onclick="setAction('Imprimir');" type="submit" value="Imprimir" name="btnImprimir" runat="server" onserverclick="btnImprimir_Click">
									<input class="boton" id="btnExportar" onclick="setAction('Exportar');" type="submit" value="Exportar" name="btnExportar" runat="server" onserverclick="btnExportar_Click">
								</td>
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
			
			<script language="JavaScript">
			<!-- // create calendar object(s) just after form tag closed
			var cal1 = new calendar(null, document.forms[0].elements["selectedDate"]);
			//-->
			</script>
			
		</form>
		<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
	</body>
</HTML>
