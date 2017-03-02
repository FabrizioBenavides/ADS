<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListadoParaInventariosRotativos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsListadoParaInventariosRotativos" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
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
		<script language="JavaScript" type="text/JavaScript" src="../static/scripts/InvRotUtils.js"></script>
		<script id="clientEventHandlersJS" language="javascript">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() 
{
  document.forms[0].action = "<%= strThisPageName %>";
  document.forms[0].boton1.focus()
  document.forms[0].txtListadoNombre.select()
  document.forms[0].txtListadoNombre.focus()
}
function showError(msg)
{	alert (msg)   }
function save()
{
	if (document.forms[0].txtListadoId.value == "" || document.forms[0].txtListadoId.value == "0")
	{	//registro nuevo
		cmdAgregar_onclick("agregar", "strCmd=Agregar")
	}
	else
	{	//actualizar registro
		cmdAgregar_onclick("actualizar", "strCmd=Guardar&intListadoId=" + document.forms[0].txtListadoId.value)
	}
}

function cmdAgregar_onclick(msg, action){
    if(document.forms[0].txtListadoNombre.value == "")
    {
        alert("Para " + msg + " un Listado \n\r es necesario teclear el Nombre del Listado");
    }
    else if (document.forms[0].rbOrdenamiento[0].checked == false 
			&& document.forms[0].rbOrdenamiento[1].checked == false)
    {
        alert("Para " + msg + " un Listado \n\r es necesario seleccionar un Ordenamiento");
    }
    else
    {	
		if (document.forms[0].rbOrdenamiento[0].checked)
		{	document.forms[0].txtOrdenamiento.value="1"	}
		
		if (document.forms[0].rbOrdenamiento[1].checked)
		{	document.forms[0].txtOrdenamiento.value="2"	}
		
        document.forms[0].action = "ListadoParaInventariosRotativos.aspx?" + action;
        document.forms[0].submit();
    }
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
	//alert ("params ? " + params)
    //document.forms[0].action = "ListadoParaInventariosRotativos.aspx?strCmd=" + action + "&" + param + "=" + id
    document.forms[0].action = "ListadoParaInventariosRotativos.aspx?strCmd=" + action + params
    document.forms[0].submit();  
}


function clearPage()
{
	document.forms[0].txtListadoId.value = "0"
	document.forms[0].txtOrdenamiento.value = ""
	document.forms[0].documentPrinted.value = "0"
	document.forms[0].txtListadoNombre.value = ""
	document.forms[0].rbOrdenamiento[0].checked = false
	document.forms[0].rbOrdenamiento[1].checked = false
}

//-->
		</script>
	</HEAD>
	<body onload="window_onload()">
		<form method="post" runat=server action="about:blank" name="frmListadoParaInventariosRotativos" ID="Form1">
			<input type="hidden" name="txtListadoId" value="<%= intListadoId %>" /> 
			<input type="hidden" name="txtOrdenamiento" value="<%= intOrdenamiento %>" />
			<input type="hidden" name="documentPrinted" value="0" />
			
			
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeader()</script></td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td width="770" class="tdtab">Está en : SUCURSAL : INV ROTATIVO : Listados Rotativos : Capturar Listado para Inventarios
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent"><h1>Capturar Listado para Inventarios Rotativos</h1>
						<p>
							Aquí podrá dar de alta o modificar los listados para la captura de Inventarios 
							Rotativos. Capturar los datos y seleccionar el botón "Agregar" para registrar 
							un nuevo listado.
						</p>
						<%= strRecordBrowserHTML() %>
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellpadding="0" cellspacing="0" class="tdenvolventetablas">
				<tr>
					<td width="20%" valign="center" class="txtitintabla" style="WIDTH: 91px; HEIGHT: 28px"><span class="tdtittablas3">Nombre:</span></td>
					<td width="80%" valign="center" class="txtitintabla" style="HEIGHT: 28px">
					
					<input type="text" name="txtListadoNombre" id="txtListadoNombre" runat="server" size="50" maxlength="50" class="field"></input>
					</td>
				</tr>
				<tr>
					<td valign="center" class="txtitintabla" style="WIDTH: 91px"><span class="tdtittablas3">Ordenamiento:</span></td>
					<td valign="center" class="txtitintabla"><table width="100%" border="0" class="tdenvolventetablas">
							<tr>
								<td width="28%" class="txtitintabla"><input name="rbOrdenamiento" type="radio" value="radiobutton" <%= rbOrdenamientoChecked(1) %> >
									Por Planograma
								</td>
								<td width="47%" class="txtitintabla"><input name="rbOrdenamiento" type="radio" value="radiobutton" <%= rbOrdenamientoChecked(2) %> >
									Alfabeticamente</td>
								<td width="25%">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td valign="center" class="txtitintabla" style="WIDTH: 91px">&nbsp;</td>
					<td valign="center" class="txtitintabla">
						<input name="boton1" type="button" class="boton" value="Aceptar" onclick="javascript:save()">
						<input name="boton2" type="button" class="boton" value="Impresión" onclick="javascript:doSubmit('Imprimir')">
						<span class="tdpadleft5">
						<input name="cmdLimpiar" type="button" class="boton" value="Limpiar" onclick="javascript:clearPage()">
						</span>
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaFooter()</script></td>
				</tr>
			</table>
			<script language="JavaScript">
				<!--
				new menu (MENU_ITEMS, MENU_POS);
				//-->
			</script>
		</form>

		<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
		
	</body>
</HTML>
