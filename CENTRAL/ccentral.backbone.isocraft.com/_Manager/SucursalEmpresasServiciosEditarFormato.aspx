<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEmpresasServiciosEditarFormato.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEmpresasServiciosEditarFormato"%>
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

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {

  document.forms[0].action = "<%= strFormAction %>";
  
  <%= strLlenarDatosComboBox() %>
  
  document.forms[0].elements["txtEmpresaServicioId"].value = "<%= intEmpresaServicioId %>";
  document.forms[0].elements["txtEmpresaServicioNombre"].value = "<%= strEmpresaServicioNombre %>";
  document.forms[0].elements["txtRowCounter"].value = "<%= intRowCounter %>";
  document.forms[0].elements["cmdAgregarDato"].disabled = <%= blnModoAgregarDatos.ToString().ToLower() %>;

  <%= strJavascriptWindowOnLoadCommands %>
  
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

function blnFormValidator() {   
   var blnReturn = false;
   var i = 0;
   var intColumnCounter = 10;
   var intHiddenColumnCounter = 11;
   var componente;
   
    for (i=0; i<<%= intRowCounter %>; i++)
    {
		blnReturn = false;
		
		/*Validar datos obligatorios*/
		
		/*Validar Descripción*/
		if(blnValidarCampo(document.forms[0].elements["txt"+i.toString()+"5"], true, "Descripción del dato", cintTipoCampoAlfanumerico, 50, 1, "") == true)
		{
			/*Validar Longitud*/
			if(blnValidarCampo(document.forms[0].elements["txt"+i.toString()+"8"], true, "Longitud", cintTipoCampoEntero, 50, 1, 0) == true)
			{
				/*Validar Posicion*/
				if(blnValidarCampo(document.forms[0].elements["txt"+i.toString()+"9"], true, "Posición", cintTipoCampoEntero, 50, 1, 0) == true)
				{
					blnReturn = true;
				}
			}
		}
				
		/*Validar datos opcionales*/
		if (blnReturn==true){
			while (document.getElementById("txt"+i.toString()+intHiddenColumnCounter.toString()) != null){
				componente = document.forms[0].elements["txt"+i.toString()+intHiddenColumnCounter.toString()].value.split('|')
				
				if(componente[1]=="TXT")
				{
					/*Validar Alfanumérico*/
					if(blnValidarCampo(document.forms[0].elements["txt"+i.toString()+intColumnCounter.toString()], true, componente[0], cintTipoCampoAlfanumerico, 50, 1, "") == true)
					{
						blnReturn = true;
					}
					else
					{
						blnReturn = false;
					}
				}
				if(componente[1]=="TXTINT")
				{
					/*Validar Entero*/
					if(blnValidarCampo(document.forms[0].elements["txt"+i.toString()+intColumnCounter.toString()], true, componente[0], cintTipoCampoEntero, 50, 1, 0) == true)
					{
						blnReturn = true;
					}
					else
					{
						blnReturn = false;
					}
				}
				if(componente[1]=="TXTFLT")
				{
					/*Validar Número con Decimales*/
					if (checkDecimals(document.forms[0].elements["txt"+i.toString()+intColumnCounter.toString()],document.forms[0].elements["txt"+i.toString()+intColumnCounter.toString()].value,componente[0])== true)
					{
						blnReturn = true;
					}
					else
					{
						blnReturn = false;
					}
				}
				
				intHiddenColumnCounter = intHiddenColumnCounter + 2;
				intColumnCounter = intColumnCounter + 2;
				
				if(blnReturn == false)
				{
					break;
				}
			}
			
		}
			
		/*Reestablecer valor iniciales de las columnas*/	
		intHiddenColumnCounter = 11;
		intColumnCounter = 10;
		
		if(blnReturn == false)
		{
			break;
		}
	}
		
	return (blnReturn);
}

function cmdComenzarEdicion_onclick() {
	document.forms[0].action += "?strCmd=Habilitar&blnModoAgregarDatos=True";
}


function cmdAgregarDato_onclick() {
	document.forms[0].action += "?strCmd=AgregarDato";
}

function habiliarCampos(){
	var i = 0;
	for (i=0; i<<%= intRowCounter %>; i++)
    {
		document.forms[0].elements["txt"+i.toString()+"8"].disabled = false;	
    }
}

function cmdGuardar_onclick() {

   var blnReturn = blnFormValidator();

   if(blnReturn==true){
		if ( document.forms[0].elements["cmdAgregarDato"].disabled == true) {
			habiliarCampos();
			document.forms[0].action += "?strCmd=Salvar";
		}
		else{
			document.forms[0].action += "?strCmd=Regresar";
		}
   }
   
   return (blnReturn);
}

function cmdCboFecha_onchange(row,column) {
	var cbo = "cbo"+row.toString()+column.toString();
	var txt = "txt"+row.toString()+"8";
	
	document.forms[0].elements[txt].value = document.forms[0].elements[cbo].value.split('').length.toString();
	document.forms[0].elements[txt].disabled = true;
}

function cmdCancelar_onclick() {
   	   window.location.href = "SucursalEmpresasServiciosAdministrarEmpresas.aspx";
}

//-->
				</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
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
							Administrar Empresas </A>: Formato de Lectura
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Formato de Lectura</h1>
						<p>Aquí podrá editar el formato de lectura para la empresa de servicios 
							seleccionada. Es importante validar este formato ya que será el que interprete 
							el POS para efectuar el pago.
						</p>
						<h1><%=strEmpresaServicioNombre%></h1>
						<h2>Agregar Datos al Formato</h2>
						<table class="tdenvolventetablas" width="100%">
							<tr>
								<td class="tdtittablas3" align="left" width="13%"><label>Tipo de Dato:</label></td>
								<td class="tdpadleft5" align="left" width="20%"><select language="javascript" class="field" id="cboDatos" name="cboDatos"></select></td>
								<td class="tdtittablas3" align="left" width="10%"><input class="button" id="cmdAgregarDato" onclick="return cmdAgregarDato_onclick()" type="submit"
										value="Agregar Dato" name="cmdAgregarDato"></td>
								<td class="tdtittablas3" align="left"><input class="button" id="cmdComenzarEdicion" onclick="return cmdComenzarEdicion_onclick()"
										type="submit" value="Comenzar Edición" name="cmdComenzarEdicion"></td>
							</tr>
						</table>
						<br>
						<h2>Editar el Formato de Lectura</h2>
						<table class="tdenvolventetablas" width="100%">
							<tr>
								<td id="tdEditarFormato">
									<table>
										<%= strHTMLFormatHeaders%>
										<%= strInterfazHTML%>
									</table>
								</td>
							</tr>
						</table>
						<table cellSpacing="0" cellPadding="0" width="700" border="0">
							<tr>
								<td class="txaccion" vAlign="top" align="right" colSpan="2" height="10">&nbsp;</td>
							</tr>
							<tr>
								<td width="24%"><input class="button" id="cmdCancelar" onclick="return cmdCancelar_onclick()" type="button"
										value="Regresar" name="cmdCancelar"> <input class="button" id="cmdGuardar" onclick="return cmdGuardar_onclick()" type="submit"
										value="Guardar" name="cmdGuardar">
								</td>
							</tr>
						</table>
						<span class="tdpadleft5"></span><br>
					</td>
				</tr>
			</table>
			<input type="hidden" name="txtEmpresaServicioId"> <input type="hidden" name="txtEmpresaServicioNombre">
			<input type="hidden" name="txtRowCounter">
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
