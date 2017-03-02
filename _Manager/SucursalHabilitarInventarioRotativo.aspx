<%@ Page CodeBehind="SucursalHabilitarInventarioRotativo.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalHabilitarInventarioRotativo" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="False" enableViewState="False" %>
<HTML>
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
		<script language="JavaScript" src="js/cal_format00.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/calendario.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="../static/scripts/InvRotUtils.js" type="text/JavaScript"></script>
		<script id="clientEventHandlersJS" language="javascript">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";


function window_onload() 
{
   document.forms[0].action = "<%= strThisPageName %>";
   document.forms[0].btnSave.focus()
   document.forms[0].intCompania.focus()
}

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
	if (action == "Borrar")
	{	
		if (!confirm ("¿Esta seguro de borrar este registro?") )
			return;
	}
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{
		params+= "&" + args[i] + "=" + args[i+1]
	}
    document.forms[0].action = "SucursalHabilitarInventarioRotativo.aspx?strCmd=" + action + params
    document.forms[0].submit();  
}

function validateDates()
{	var result = false

alert("validateDate!")
alert("window.document.forms[0].radioSelDate[0].checked? " + window.document.forms[0].radioSelDate[0].checked)
alert("window.document.forms[0].radioSelDate[1].checked? " + window.document.forms[1].radioSelDate[0].checked)

	if (! window.document.forms[0].radioSelDate[0].checked 
		&& !window.document.forms[0].radioSelDate[1].checked )
	{
		alert ("Seleccione la fecha para filtrado de la lista.")
	}
	else if (window.document.forms[0].radioSelDate[1].checked
		&& window.document.forms[0].selectedDate.value=="")
	{
		alert ("Favor de seleccionar una fecha.")
	}
	else
	{	result = true	}
	
	return result
}

function validateData()
{	
	var result = false
	if (window.document.forms[0].intCompania.value == "")
	{
		alert ("Teclee el número de Compañía.")
		window.document.forms[0].intCompania.focus()
	}
	else if (window.document.forms[0].intSucursal.value == "" )
	{
		alert ("Teclee el número de Sucursal.")
		window.document.forms[0].intSucursal.focus()
	}
	else
	{	result = true	}
	
	return result
}


function validateForm()
{
	var result = false
	alert("validateForm !, currentAction? " + currentAction )
	if (currentAction == "filtrar")
	{	result = validateDates()	}
	else if (currentAction == "Guardar")
	{	result = validateData()  }
	
	return result
}

function moveToIfEnter(obj)
{
	if (window.event.keyCode == 13) 
	{
		obj.focus()
	}
}

//-->
		</script>
	</HEAD>
	<body onload="return window_onload()">
		<form runAt="server" method="post" name="frmDeshabilitarSucursal" onsubmit="return validateForm()" ID="frmDeshabilitarSucursal">
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeader()</script></td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td width="770" class="tdtab">Está en : INV ROTATIVO : Sucursales : Consultar 
						sucursales sin cierre de inventarios
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent"><h1>Sucursales Deshabilitadas para Captura de Inventario 
							Rotativo</h1>
						<p>
							Seleccione una fecha para consultar el listado. Para deshabilitar una sucursal, 
							teclee su número y dar click en el botón "Grabar". Para habilitar una sucursal, 
							seleccione el&nbsp;icono para borrarlo de la lista.
						</p>
						<table width="50%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="14%" class="tdtexttablebold">
									<asp:RadioButton id="dateSelection1" Text="Hoy" GroupName="radioSelDate" runat="server"></asp:RadioButton>
								</td>
								<td width="86%" class="tdpadleft5">
									<asp:TextBox id="currentDate" runat="server" MaxLength='0' CssClass="fieldborderless"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold"><asp:RadioButton id="dateSelection2" Text="Fecha" GroupName="radioSelDate" runat="server"></asp:RadioButton></td>
								<td class="tdpadleft5">
									<asp:TextBox id="selectedDate" runat="server" MaxLength='0' CssClass="field" ReadOnly></asp:TextBox>
									<a href="javascript:cal1.popup()"><img border="0" src="images/imgCalendarIcon.gif"></a>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold"></td>
								<td class="tdpadleft5">
									<input name="btnAceptar" runat="server" type="button" class="boton" value="Aceptar" onclick="setAction('filtrar');" onserverclick="btnAceptar_Click" ID="btnAceptar">
								</td>
							</tr>
						</table>
						<BR>
						<%= strRecordBrowserHTML() %>
						<BR>
						<table width="100%" border="0" cellpadding="0" cellspacing="0" class="tdenvolventetablas">
							<tr>
								<td width="20%" valign="center" class="txtitintabla" style="WIDTH: 91px; HEIGHT: 28px"><span class="tdtittablas3">Compañía:</span></td>
								<td width="80%" valign="center" class="txtitintabla" style="HEIGHT: 28px">&nbsp;
									<asp:TextBox id="intCompania" runat="server" name="intCompania" onKeyPress="moveToIfEnter(intSucursal)"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td valign="center" class="txtitintabla" style="WIDTH: 91px; HEIGHT: 16px"><span class="tdtittablas3">Sucursal:</span></td>
								<td valign="center" class="txtitintabla" style="HEIGHT: 16px">&nbsp;
									<asp:TextBox id="intSucursal" runat="server" name="intSucursal" onKeyPress="moveToIfEnter(btnSave)"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td valign="center" class="txtitintabla" style="WIDTH: 91px">&nbsp;</td>
								<td valign="center" class="txtitintabla">
									<input name="btnSave" runat="server" type="button" class="boton" value="Grabar" onclick="setAction('Guardar');" onserverclick="btnSave_Click" ID="btnSave">
									&nbsp; <span class="tdpadleft5"><input name="cmdLimpiar" type="reset" class="boton" value="Limpiar">&nbsp;
									</span>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaFooterCentral()</script></td>
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
	</body>
</HTML>
