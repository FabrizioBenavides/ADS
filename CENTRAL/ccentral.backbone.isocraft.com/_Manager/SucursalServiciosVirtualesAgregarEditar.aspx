<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalServiciosVirtualesAgregarEditar.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalServiciosVirtualesAgregarEditar" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
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
		<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/masked_input.js"> type="text/JavaScript"</script>
		<script language="javascript" id="clientEventHandlersJS">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

var cboIntegradorValorOriginal;

function window_onload() {

   document.forms[0].action = "<%= strFormAction %>";
   <%= strLlenarTipoTicketComboBox() %>
   <%= strLlenarTipoMovimientoComboBox() %>
   
   // STKLDI CJBG 05/07/2012 Llamando a metodo para rellenar opciones del combo box de integrador
   <%= strLlenarIntegradorComboBox() %>
   
      //STKTARJETASDEREGALO 04/05/2013 llamando el Metodo para llenar las opciones de conbox de forma de pago. JPMB
	<%= strLLenarFormaDePago %>
	
	// SOFTTEK-LFLJ-10/OCT/2013.T1.1. (inicio)
   // ServicioVirtual-Tienda llenar combos: cboDireccionOperativa, cboZonaOperativa, cboTienda
   <%=strLlenarcboDireccionOperativa%>
   <%=strLlenarcboZonaOperativa%>
   <%=strLlenarcboTienda%>
   // SOFTTEK-LFLJ-10/OCT/2013.T1.1. (fin)   
	   
   document.forms[0].elements["txtTipoServicioVirtualDescripcion"].value = "<%= strTipoServicioVirtualDescripcion %>";
   
      // Validamos que el comando de entrada , este activa solo para la seccion de tarjetas de regalo .
   	if("<%= strCmd %>" == "Agregar")
	{
		// Si la descripcion no concuerda con el nombre de Tipo de Servicio no deplegamos los demas Datos.
		if("<%= strTipoServicioVirtualDescripcion %>" != "TARJETAS DE REGALO")
		  {
		document.getElementById('DivTarjetaRegalo').style.display='none';
		document.getElementById('DivFormaPago').style.display='none';
		document.forms[0].elements["txtTextoTicket"].disabled = true;
		document.forms[0].elements["chkFacturaVenta"].disabled = true;
		document.forms[0].elements["chkFacturaAplicaComision"].disabled = true;
		document.forms[0].elements["chkTarjetaActiva"].disabled = true;
		document.forms[0].elements["cboFormaDePago"].disabled = true;
			}
	
	}
   
   if("<%= strCmd %>" == "Editar")
   {
    
	document.forms[0].elements["txtCodigoProducto"].value = "<%= strServicioVirtualCodigoProducto %>";
    document.forms[0].elements["txtDescripcion"].value = "<%= strServicioVirtualDescripcion %>";
    document.forms[0].elements["cboTipo"].value = "<%= intTipoMovimientoServicioVirtualId %>";
    document.forms[0].elements["cboTipoTicket"].value = "<%= intTipoTicketId %>";
    document.forms[0].elements["txtTransaccionCTF"].value = "<%= intServicioVirtualTransaccionCTFId %>";
    document.forms[0].elements["txtCTFCampoCompuestoId"].value = "<%= intServicioVirtualTransaccionCTFCampoCompuestoId %>";
    document.forms[0].elements["txtCTFLongitudCampoCompuesto"].value = "<%= intServicioVirtualTransaccionCTFCampoCompuestoLongitud %>";
    document.forms[0].elements["txtComision"].value = "<%= fltServicioVirtualComision %>";
    document.forms[0].elements["txtComisionCTF"].value = "<%= intServicioVirtualTransaccionCTFComisionId %>";
    document.forms[0].elements["txtComisionCTFsinImpuesto"].value = "<%= intServicioVirtualTransaccionCTFComisionFPSinImpuesto %>";
    document.forms[0].elements["txtComisionCTFinterior"].value = "<%= intServicioVirtualTransaccionCTFComisionFPImpuestoInteriorId  %>";
    document.forms[0].elements["txtComisionCTFfrontera"].value = "<%= intServicioVirtualTransaccionCTFComisionFPImpuestoFronteraId  %>";
    document.forms[0].elements["chkDesglose"].checked = <%= blnServicioVirtualDesgloseImpuesto.ToString().ToLower()  %>;
    document.forms[0].elements["txtClaveImpresion"].value = "<%= intServicioVirtualClaveImpresion %>";
    document.forms[0].elements["chkReimpresion"].checked = <%= blnServicioVirtualReImpresion.ToString().ToLower() %>;
    document.forms[0].elements["txtReferencia"].value = "<%= strServicioVirtualLeyendaReferencia %>";
    document.forms[0].elements["txtAutorizacion"].value = "<%= strServicioVirtualCampoAutorizacion %>";
    document.forms[0].elements["txtImporte"].value = "<%= strServicioVirtualCampoImporte %>";
    document.forms[0].elements["txtMonto"].value = "<%= strServicioVirtualCampoMonto %>";
    document.forms[0].elements["txtCantidad"].value = "<%= strServicioVirtualCampoCantidad %>";
    document.forms[0].elements["txtCamposNoAlmacenados"].value = "<%= strServicioVirtualCamposNoAlmacenados %>";
    document.forms[0].elements["chkReversa"].checked = <%= blnServicioVirtualReversa.ToString().ToLower() %>;
    document.forms[0].elements["chkImprimirCancelacion"].checked = <%= blnServicioVirtualImprimirTicketCancelacion.ToString.ToLower() %>;
    document.forms[0].elements["txtClaveCancelacion"].value = "<%= intServicioVirtualClaveImpresionCancelacion %>";
    document.forms[0].elements["chkOperacionExitosa"].checked = <%= blnServicioVirtualConfirmarOperacionExitosa.ToString.ToLower() %>;
    document.forms[0].elements["txtLeyendaExitosa"].value = "<%= strServicioVirtualLeyendaOperacionExitosa %>";
    document.forms[0].elements["txtMontoMaximoEgreso"].value = "<%= fltServicioVirtualMontoMaximo %>";
    
    // STKIUSACFE CJBG 22/06/2013 - Agregando campos respectivos a la comision del integrador
    document.forms[0].elements["txtComisionIntegrador"].value = "<%= fltServicioVirtualComisionIntegrador %>";
    document.forms[0].elements["txtComisionIntegradorCTF"].value = "<%= intServicioVirtualTransaccionCTFComisionIntegradorId %>";
    document.forms[0].elements["txtComisionIntegradorCTFsinImpuesto"].value = "<%= intServicioVirtualTransaccionCTFComisionIntegradorFPSinImpuesto %>";
    document.forms[0].elements["txtComisionIntegradorCTFinterior"].value = "<%= intServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoInteriorId  %>";
    document.forms[0].elements["txtComisionIntegradorCTFfrontera"].value = "<%= intServicioVirtualTransaccionCTFComisionIntegradorFPImpuestoFronteraId  %>";
    document.forms[0].elements["chkSeparaComisionIntegrador"].checked = <%= blnServicioVirtualSeparaComisionIntegrador.ToString().ToLower()  %>;
    
    // STKLDI CJBG 05/07/2012 Agregando nuevos campos
    document.forms[0].elements["chkValidarSupervisor"].checked = <%= blnServicioVirtualValidarSupervisor.ToString.ToLower() %>;
    document.forms[0].elements["cboIntegrador"].value = "<%= intIntegradorServicioVirtualId %>";
	
	document.forms[0].elements["cmdAgregar"].disabled = false;

	// STKTARJETAS DE REGALO Validación 15/06/2013 (EBCV)
	if("<%= strTipoServicioVirtualDescripcion %>" == "TARJETAS DE REGALO")
	  {
	// STKTARJETAS DE REGALO  Juan Pablo Martinez Bautista 03/06/2013 (JPMB)
    document.forms[0].elements["txtTextoTicket"].value= "<%= strServicioVirtualTextoTicket %>";
	document.forms[0].elements["chkFacturaVenta"].checked = <%= blnServicioVirtualFacturaVenta.ToString.ToLower() %>;
	document.forms[0].elements["chkFacturaAplicaComision"].checked= <%= blnServicioVirtualFacturaAplicaComision.ToString.ToLower() %>;
	document.forms[0].elements["chkTarjetaActiva"].checked= <%= blnServicioVirtualTarjetaActiva.ToString.ToLower() %>;
	    
	//Seleccion Acerca De Las Formas De Pago  (JPMB)
	document.forms[0].elements["cboFormaDePago"].value = "<%= intFormaDePagoId %>";

	document.forms[0].elements["cmdAgregar"].disabled = false;
	}
	// STKTARJETAS DE REGALO Validación 15/06/2013 (EBCV)
	else
	{

    document.getElementById('DivTarjetaRegalo').style.display='none';
    document.getElementById('DivFormaPago').style.display='none';
	document.forms[0].elements["txtTextoTicket"].disabled = true;
	document.forms[0].elements["chkFacturaVenta"].disabled = true;
	document.forms[0].elements["chkFacturaAplicaComision"].disabled = true;
	document.forms[0].elements["chkTarjetaActiva"].disabled = true;
	document.forms[0].elements["cboFormaDePago"].disabled = true;
	}
	
	// Variabla que llevará cuenta del valor original de cboIntegrador para regresarlo en caso de ser necesario
	cboIntegradorValorOriginal = document.forms[0].elements["cboIntegrador"].selectedIndex;
	
	if(checkParemeterExists("strServicioVirtualCampoVariableDuplicado") == true)
	{
		alert('No se permite duplicar un Id Campo en un mismo tipo de propiedad.');
	}
	
	 // SOFTTEK-LFLJ-10/OCT/2013.T1.1. (inicio)
    // ServicioVirtual-Tienda: habilitar/deshabilitar: cmdAgregarTiendas
	document.forms[0].elements["cmdAgregarTiendas"].disabled = true;
	if (document.forms[0].elements["cboDireccionOperativa"].selectedIndex > 0) {	
		if (document.forms[0].elements["cboZonaOperativa"].selectedIndex > 0) {
			if (document.forms[0].elements["cboTienda"].length > 0) {
				document.forms[0].elements["cmdAgregarTiendas"].disabled = false;
			}	
		}
	}
    // SOFTTEK-LFLJ-10/OCT/2013.T1.1. (fin)
	
   }
   else
   {
        //No hacer nada
   }
   
    // STKLDI CJBG 05/07/2012 Llamada función para validaciones de los nuevos campos configurables
	validarCamposConfigurables();
  
<%= strJavascriptWindowOnLoadCommands %>
}

// JPMB validando que solo este Selecionado un check  
function desactivaCheckBox(idCheckBox){
	document.getElementById (idCheckBox).checked=false;
}


function checkParemeterExists(parameter)
{
   //Get Query String from url
   fullQString = window.location.search.substring(1);
   
   paramCount = 0;
   queryStringComplete = "?";

   if(fullQString.length > 0)
   {
       //Split Query String into separate parameters
       paramArray = fullQString.split("&");
       
       //Loop through params, check if parameter exists.  
       for (i=0;i<paramArray.length;i++)
       {
         currentParameter = paramArray[i].split("=");
         if(currentParameter[0] == parameter) //Parameter already exists in current url
         {
            return true;
         }
       }
   }
   
   return false;
}

function cmdGuardar_onclick() {
    if (ValidarCampos()){
         //document.forms[0].action += "?strCmd=Salvar&intTipoServicioId=" + <%= intTipoServicioVirtualId() %> + "&intServicioID=" + <%= intServicioVirtualId() %>;
         document.forms[0].action += "?strCmd=Salvar&intTipoServicioId=" + <%= intTipoServicioVirtualId() %> + "&intServicioID=" + <%= intServicioVirtualId() %> + "&blnIntegradorServicioVirtualIdCambio=" + ValidarCambioIntegrador();
         document.forms(0).submit();
    }
}

function cmdAgregar_onclick(){
    if (ValidarCamposDatoAdicional()){
         document.forms[0].action += "?strCmd=AgregarDato&intTipoServicioId=" + <%= intTipoServicioVirtualId() %> + "&intServicioID=" + <%= intServicioVirtualId() %>;
         document.forms(0).submit();
    }
}

function cmdRegresar_onclick() {
   window.location.href = "SucursalServiciosVirtuales.aspx?intTipoServicioId=" + <%= intTipoServicioVirtualId() %> + "&strCmd=Asignar";
}

// JPMB . Activa El Case Para La Forma De Pago
function cmdAgregarFormaDePago_onclick()
{
document.forms[0].action += "?strCmd=AgregarFormaDePago&intTipoServicioId=" + <%= intTipoServicioVirtualId() %> + "&intServicioID=" + <%= intServicioVirtualId() %> + "&blnIntegradorServicioVirtualIdCambio=" + ValidarCambioIntegrador();
         document.forms(0).submit();
}

// STKLDI CJBG 05/07/2012 Validaciones de los nuevos campos configurables
function validarCamposConfigurables() 
{
	cboIntegrador_onLoad(document.forms[0].elements["cboIntegrador"]);
	cboPropiedadCampo_onChange(document.forms[0].elements["cboPropiedadCampo"]);
	cboTipoCampo_onChange(document.forms[0].elements["cboTipoCampo"]);
}

// STKLDI CJBG 05/07/2012 Función que lleva control de lógica de los campos dependientes de cboIntegrador en carga de página
function cboIntegrador_onLoad(dropdown) 
{
	var botonAgregarCampoVariable = document.forms[0].elements["cmdAgregarCampoVariable"];
	var inputLDITipoIdCampo = document.forms[0].elements["txtLDITipoIdCampo"];
	var inputLDISubtipoIdCampo = document.forms[0].elements["txtLDISubtipoIdCampo"];
	
	// stkIUSACFE CJBG 10/07/2013
	// Agregando campo de comisión del integrador.
	var inputComisionIntegrador = document.forms[0].elements["txtComisionIntegrador"];
	
	// Si la opcion seleccionada en cboIntegrador no es LDI
	if ((dropdown.options[dropdown.selectedIndex].value != "2"))
	{
		// Deshabilitamos txtLDITipoIdCampo
		inputLDITipoIdCampo.disabled = true;
		inputLDITipoIdCampo.value = "";
		inputLDITipoIdCampo.className = "fieldblue";
		
		// Deshabilitamos txtLDISubtipoIdCampo
		inputLDISubtipoIdCampo.disabled = true;
		inputLDISubtipoIdCampo.value = "";
		inputLDISubtipoIdCampo.className = "fieldblue";
	}
	// De lo contrario
	else
	{
		// Habilitamos txtLDITipoIdCampo
		inputLDITipoIdCampo.disabled = false;
		inputLDITipoIdCampo.className = "field";
		
		// Habilitamos txtLDISubtipoIdCampo
		inputLDISubtipoIdCampo.disabled = false;
		inputLDISubtipoIdCampo.className = "field";
	}
	
	// stkIUSACFE CJBG 10/07/2013
	// Si la opcion seleccionada en cboIntegrador es IUSA
	//if ((dropdown.options[dropdown.selectedIndex].value == "4"))
	//{
		// Habilitamos txtComisionIntegrador
		//inputComisionIntegrador.disabled = false;
		//inputComisionIntegrador.className = "field";
	//}
	// De lo contrario
	//else
	//{
		// Deshabilitamos txtComisionIntegrador
		//inputComisionIntegrador.disabled = true;
		//inputComisionIntegrador.value = "";
		//inputComisionIntegrador.className = "fieldblue";
	//}
	
	// Si la opción seleccionada en cboIntegrador no es OffLine o LDI, o si no estamos en modo de edición
	// stkIUSACFE CJBG 10/07/2013 - Modificando validación, hay nuevo integrador.
	//if ((dropdown.selectedIndex<2 || "<%= strCmd %>" != "Editar"))
    if ((dropdown.selectedIndex < 2 || dropdown.selectedIndex > 3 || "<%= strCmd %>" != "Editar"))
    {
		// Deshabilitamos el boton para Agregar Campos Variables
		botonAgregarCampoVariable.disabled = true;
    }
    // De lo contrario
    else
    {
		// Habilitamos el boton para Agregar Campos Variables
		botonAgregarCampoVariable.disabled = false;
    }
}

// STKLDI CJBG 05/07/2012 Función que lleva control de lógica de los campos dependientes de los cambios en cboIntegrador
function cboIntegrador_onChange(dropdown) 
{
	var botonAgregarCampoVariable = document.forms[0].elements["cmdAgregarCampoVariable"];
	var inputLDITipoIdCampo = document.forms[0].elements["txtLDITipoIdCampo"];
	var inputLDISubtipoIdCampo = document.forms[0].elements["txtLDISubtipoIdCampo"];
	
	// stkIUSACFE CJBG 10/07/2013
	// Agregando campo de comisión del integrador.
	var inputComisionIntegrador = document.forms[0].elements["txtComisionIntegrador"];
	
	// Si el usuario confirma un cambio en la opción seleccionada en cboIntegrador
	if (confirm("El cambio de integrador requiere que guarde los cambios del servicio virtual.\nTambien se eliminaran los campos variables existentes al guardar los cambios.\n¿Esta seguro que desea continuar?")==true)
	{
		// Si la opcion seleccionada en cbo Integrador no es OffLine or LDI
		if ((dropdown.options[dropdown.selectedIndex].value != "2"))
		{
			// Deshabilitamos txtLDITipoIdCampo
			inputLDITipoIdCampo.disabled = true;
			inputLDITipoIdCampo.value = "";
			inputLDITipoIdCampo.className = "fieldblue";
		
			// Deshabilitamos txtLDITipoIdCampo
			inputLDISubtipoIdCampo.disabled = true;
			inputLDISubtipoIdCampo.value = "";
			inputLDISubtipoIdCampo.className = "fieldblue";
		}
		// De lo contrario
		else
		{
			// Habilitamos txtLDITipoIdCampo
			inputLDITipoIdCampo.disabled = false;
			inputLDITipoIdCampo.className = "field";
			
			// Habilitamos txtLDITipoIdCampo
			inputLDISubtipoIdCampo.disabled = false;
			inputLDISubtipoIdCampo.className = "field";
		}
		
		// stkIUSACFE CJBG 10/07/2013
		// Si la opcion seleccionada en cboIntegrador es IUSA
		//if ((dropdown.options[dropdown.selectedIndex].value == "4"))
		//{
			// Habilitamos txtComisionIntegrador
			//inputComisionIntegrador.disabled = false;
			//inputComisionIntegrador.className = "field";
		//}
		// De lo contrario
		//else
		//{
			// Deshabilitamos txtComisionIntegrador
			//inputComisionIntegrador.disabled = true;
			//inputComisionIntegrador.value = "";
			//inputComisionIntegrador.className = "fieldblue";
		//}
	
		// Deshabilitamos el boton para Agregar Campos Variables
		botonAgregarCampoVariable.disabled = true;
		
		// La variable que registra la opción original de cboIntegrador es actualizada con el valor nuevo 
		cboIntegradorValorOriginal = dropdown.selectedIndex;
	}
	// De lo contrario
	else
	{
		// Regresamos la opcion original a cboIntegrador antes de haber sido cambiada
		dropdown.selectedIndex = cboIntegradorValorOriginal;
		dropdown.options[dropdown.selectedIndex].value = dropdown.options[cboIntegradorValorOriginal].value;
	}
}

// STKLDI CJBG 05/07/2012 Función que lleva control de lógica de los campos dependientes de los cambios en cboTipoCampo
function cboTipoCampo_onChange(dropdown)
{
	var inputDiasVencimiento = document.forms[0].elements["txtDiasVencimientoCampo"];
	var inputValorCampo = document.forms[0].elements["txtValorCampo"];
	var cboPropiedadCampo = document.getElementById("cboPropiedadCampo");
	
	// Si la opción seleccionada en tipo campo no es Fecha
	if (dropdown.options[dropdown.selectedIndex].value != "fecha" || 
		cboPropiedadCampo.options[cboPropiedadCampo.selectedIndex].value == "respuesta" ||
		cboPropiedadCampo.options[cboPropiedadCampo.selectedIndex].value == "default")
	{
		// Deshabilitamos txtDiasVencimientoCampo
		inputDiasVencimiento.disabled = true;
		inputDiasVencimiento.value = "";
		inputDiasVencimiento.className = "fieldblue";
			
		// Deshabilitamos txtValorCampo
			
			
		if (dropdown.options[dropdown.selectedIndex].value == "numerico")
		{
			// Aplicamos una mascara tipo numero en txtValorCampo
			inputValorCampo.onkeypress = "";
			MaskedInput
			({
				elm: document.getElementById('txtValorCampo'),
				format: '         ',
				allowed: '0123456789.',
				separator: '',
				typeon: ' '
			});
			inputValorCampo.value = "";
			inputValorCampo.onkeydown = "";
			inputValorCampo.onkeyup = "";
				
		}
		else
		{
			inputValorCampo.value = "";
			inputValorCampo.onkeypress = "";
			inputValorCampo.onkeydown = "";
			inputValorCampo.onkeyup = "";
		}
	}
		//De lo contrario
	else
	{
		// Habilitamos txtDiasVencimientoCampo
		inputDiasVencimiento.disabled = false;
		inputDiasVencimiento.className = "field";
			
		// Si la opción seleccionada en cboPropiedadCampo no es Solicitud o vacio
		if (cboPropiedadCampo.options[cboPropiedadCampo.selectedIndex].value != "solicitud" &&
			cboPropiedadCampo.options[cboPropiedadCampo.selectedIndex].value != "respuesta" &&
			cboPropiedadCampo.options[cboPropiedadCampo.selectedIndex].value != "default")
		{
			// Aplicamos una mascara tipo Fecha en txtValorCampo
			inputValorCampo.onkeypress = "";
			MaskedInput
			({
				elm: document.getElementById('txtValorCampo'),
				format: 'dd/mm/aaaa',
				allowed: '0123456789',
				separator: '\/',
				typeon: 'dma'
			});
		}
    }
}

// STKLDI CJBG 07/07/2012 Función que verifica si se estan introduciendo datos numéricos
function isNumber()
{
	var charCode = event.keyCode;
	if (charCode > 31 && (charCode < 48 || charCode > 57))
	{
		return false;
	}
	return true;
}

// STKLDI CJBG 07/07/2012 Función que verifica si se estan introduciendo datos numéricos en valor
function isNumberValor()
{
	var charCode = event.keyCode;
	var cboTipoCampo = document.getElementById("cboTipoCampo");
	
	// Si Numérico es la opcion seleccionado en cboTipoCampo
	if (cboTipoCampo.options[cboTipoCampo.selectedIndex].value == "numerico")
	{
		if ((charCode < 32 && (charCode > 47 || charCode < 58)) || charCode == 110)
		{
			return true;
		}
	}
	return false;
}

// STKLDI CJBG 05/07/2012 Función que lleva control de lógica de los campos dependientes de los cambios en cboPropiedadCampo
function cboPropiedadCampo_onChange(dropdown)
{
	var inputValorCampo = document.forms[0].elements["txtValorCampo"];
	var inputCtdCaracteresCampo = document.forms[0].elements["txtCtdCaracteresCampo"];
	var cboTipoCampo = document.getElementById("cboTipoCampo");
	
	// Si la opción seleccionada en cboPropiedadCampo es la default vacia 
	if (dropdown.options[dropdown.selectedIndex].value == "default")
	{
		// Deshabilitamos txtValorCampo
		inputValorCampo.disabled = true;
		inputValorCampo.value = "";
		inputValorCampo.className = "fieldblue";
	
		// Deshabilitamos txtCtdCaracteresCampo
		inputCtdCaracteresCampo.disabled = true;
		inputCtdCaracteresCampo.value = "";
		inputCtdCaracteresCampo.className = "fieldblue";
	}
	// De lo contrario
	else
	{
		// Si la opción seleccionada en cboPropiedadCampo es diferente de Solicitud
		if (dropdown.options[dropdown.selectedIndex].value != "solicitud")
		{
			if (dropdown.options[dropdown.selectedIndex].value == "respuesta")
			{
				
				// Deshabilitamos txtValorCampo
				inputValorCampo.disabled = true;
				inputValorCampo.value = "";
				inputValorCampo.className = "fieldblue";
				
				// Habilitamos txtCtdCaracteresCampo
				inputCtdCaracteresCampo.disabled = true;
				inputCtdCaracteresCampo.value = "";
				inputCtdCaracteresCampo.className = "fieldblue";
			}
			else
			{

			
				// Habilitamos txtValorCampo
				inputValorCampo.disabled = false;
				inputValorCampo.className = "field";
			
				// Deshabilitamos txtCtdCaracteresCampo
				inputCtdCaracteresCampo.disabled = true;
				inputCtdCaracteresCampo.value = "";
				inputCtdCaracteresCampo.className = "fieldblue";
			}
		}
		// De lo contrario
		else
		{
		
			// Deshabilitamos txtValorCampo
			inputValorCampo.disabled = true;
			inputValorCampo.value = "";
			inputValorCampo.className = "fieldblue";
				
			// Habilitamos txtCtdCaracteresCampo
			inputCtdCaracteresCampo.disabled = false;
			inputCtdCaracteresCampo.className = "field";
		}
		
		//Llamamos a la funcion cboTipoCampo_onChange
		cboTipoCampo_onChange(document.getElementById("cboTipoCampo"));
    }
}

// STKLDI CJBG 05/07/2012 Función activada cuando se da click en la nueva opción para agregar campos variables.
function cmdAgregarCampoVariable_onClick() 
{
   if (ValidarCamposVariables())
   {
         document.forms[0].action += "?strCmd=AgregarCampoVariable&intTipoServicioId=" + <%= intTipoServicioVirtualId() %> + "&intServicioID=" + <%= intServicioVirtualId() %>;
         document.forms(0).submit();
    }
}

function blnValidarComboBox(objCampo,strDiferenteDe,strEtiquetaCampo,blnRequerido) {
  if(objCampo.selectedIndex<1 && blnRequerido) {
    objCampo.selectedIndex=0;
    alert("Seleccione un " + strEtiquetaCampo + ".");
    return(false);
  }
  //Solo validara cuando especifiquen que sea diferente de Algo
  if(strDiferenteDe!='') {
    if(objCampo.value==strDiferenteDe) {
      objCampo.selectedIndex=0;
      MostrarMensaje(objCampo,strEtiquetaCampo,cintTipoCampoCombo,2)
      return(false);
    }
  }
  return(true);
}

function ValidarCamposDatoAdicional(){
   var blnReturn = false;
   //Debe ingresarse el id y el nombre del campo a agregar
   if ((blnValidarCampo(document.forms[0].elements["txtCampoId"], true, "ID Campo", cintTipoCampoEntero, 4, 1, "") == true) &&
       (blnValidarCampo(document.forms[0].elements["txtNombreCampo"], true, "Nombre campo", cintTipoCampoAlfanumerico, 255, 1, "") == true) &&
	   <%= intServicioVirtualId() %> != 0 )
   {
   blnReturn = true;
   }
   else
   {
   return(false);
   }
   
   //El id del dato adicional no puede estar repetido
   if (ValidarDatoAdicionalId() == true)
   {
    blnReturn = true;
   }
   else
   {
    alert("El Id del dato adicional esta repetido, favor de cambiarlo.");
    return(false);
   }
   
   return(blnReturn);
}

// STKLDI CJBG 07/07/2012 Función que valida nos datos necesarios para dar de alta un campo variable
function ValidarCamposVariables(){
	var blnReturn = true;
   
	var inputLDITipoIdCampo = document.forms[0].elements["txtLDITipoIdCampo"];
	var inputLDISubtipoIdCampo = document.forms[0].elements["txtLDISubtipoIdCampo"];
	var cboPropiedadCampo = document.forms[0].elements["cboPropiedadCampo"];
	var cboTipoCampo = document.forms[0].elements["cboTipoCampo"];
	var inputValorCampo = document.forms[0].elements["txtValorCampo"];
	var inputCtdCaracteres = document.forms[0].elements["txtCtdCaracteresCampo"];
	var inputDiasVencimiento = document.forms[0].elements["txtDiasVencimientoCampo"];
   
    // Valida que txtDescripcionCampo sea alfanumérico
	if ((blnValidarCampo(document.forms[0].elements["txtDescripcionCampo"], true, "Descripcion", cintTipoCampoAlfanumerico, 50, 1, "") == false))
	{
		return(false);
	}
	
	// Si el txtLDITipoIdCampo no esta deshabilitado
	if (inputLDITipoIdCampo.disabled != true)
	{
		// Valida que txtLDITipoIdCampo sea tipo entero
		if (blnValidarCampo(document.forms[0].elements["txtLDITipoIdCampo"], true, "Tipo LDI", cintTipoCampoEntero, 5, 1, "") == false)
		{
			return(false);
		}
	}
	
	// Si el txtLDISubtipoIdCampo no esta deshabilitado
	if (inputLDISubtipoIdCampo.disabled != true)
	{
		// Valida que txtLDISubtipoIdCampo sea tipo entero
		if (blnValidarCampo(document.forms[0].elements["txtLDISubtipoIdCampo"], true, "Subtipo LDI", cintTipoCampoEntero, 5, 1, "") == false)
		{
			return(false);
		}
	}
	
	// Valida que el elemento seleccionado en cboPropiedadCampo no sea el default vacio
    if (blnValidarComboBox(cboPropiedadCampo, "", "Propiedad Campo", true) == false){
        return(false);
    }
    
    // Valida que el elemento seleccionado en cboTipoCampo no sea el default vacio
    if (blnValidarComboBox(cboTipoCampo, "", "Tipo Campo", true) == false){
        return(false);
    }
	
	// Si txtValorCampo no esta deshabilitado 
	if (inputValorCampo.disabled != true)
	{
		// Si Fecha es la opcion seleccionado en cboTipoCampo
		if (cboTipoCampo.options[cboTipoCampo.selectedIndex].value == "fecha")
		{
			// Valida que txtValorCampo tenga un valor de tipo fecha
			if (blnValidarCampo(document.forms[0].elements["txtValorCampo"], true, "Valor", cintTipoCampoFecha, 10, 1, "") == false)
			{
				return(false);
			}
		}
		// De lo contrario
		else
		{
			// Si Numérico es la opcion seleccionado en cboTipoCampo
			if (cboTipoCampo.options[cboTipoCampo.selectedIndex].value == "numerico")
			{
				// Valida que txtValorCampo tenga un valor de tipo numérico
				if (blnValidarCampo(document.forms[0].elements["txtValorCampo"], true, "Valor", cintTipoCampoReal, 30, 1, "") == false)
				{
					return(false);
				}
			}
			// De lo contrario
			else
			{
				// Valida que txtValorCampo tenga un valor de tipo alfanumérico
				if (blnValidarCampo(document.forms[0].elements["txtValorCampo"], true, "Valor", cintTipoCampoAlfanumerico, 30, 1, "") == false)
				{
					return(false);
				}
			}
		}
	}
	
	// Si txtCtdCaracteresCampo no esta deshabilitado
	if (inputCtdCaracteres.disabled != true)
	{
		// Valida que txtCtdCaracteresCampo tenga un valor de tipo numérico entero
		if (blnValidarCampo(document.forms[0].elements["txtCtdCaracteresCampo"], true, "Ctd. Caracteres", cintTipoCampoEntero, 5, 1, "") == false)
		{
			return(false);
		}
	}
	
	// Si txtDiasVencimientoCampo no esta deshabilitado
	if (inputDiasVencimiento.disabled != true)
	{
		// Valida que txtDiasVencimientoCampo tenga un valor de tipo numérico entero
		if (blnValidarCampo(document.forms[0].elements["txtDiasVencimientoCampo"], true, "Días de Vencimiento", cintTipoCampoEntero, 5, 1, "") == false)
		{
			return(false);
		}
    }
      
   return(blnReturn);
}

// Función que se activa al cambiar el valor seleccionado en cboIntegrador
function ValidarCambioIntegrador()
{
   // Deshabilita el boton de Agregar en la seccion de campos aariables
   var blnReturn = document.forms[0].elements["cmdAgregarCampoVariable"].disabled;
   return(blnReturn);
}

function ValidarDatoAdicionalId(){
  var strIds = "<%= strBuscarIdsDatosAdicionales %>";
  var strId = 0;
  var blnReturn = true;
  
  if (strIds != "")
  {
    arrIds = strIds.split("|");
    while (arrIds.length != 0){
      strId = arrIds.pop();
        if (strId == document.forms[0].elements["txtCampoId"].value){
        return(false);
        }
    }
  }
return(blnReturn);
}

function ValidarCodigoProducto(){
  var strCodigos = "<%= strBuscarCodigosProductos %>";
  var strCodigo = 0;
  var blnReturn = true;
  
  if (strCodigos != "")
  {
    arrCodigos = strCodigos.split("|");
    while (arrCodigos.length != 0){
      strCodigo = arrCodigos.pop();
        if (strCodigo == document.forms[0].elements["txtCodigoProducto"].value){
        return(false);
        }
    }
  }
return(blnReturn);
}

function ValidarCampos(){

  var blnReturn = false;
  //Primero validamos que los datos esten correctos
  if ((blnValidarCampo(document.forms[0].elements["txtCodigoProducto"], true, "Código producto", cintTipoCampoAlfanumerico, 255, 1, "") == true) &&
      (blnValidarCampo(document.forms[0].elements["txtDescripcion"], true, "Descripción POS", cintTipoCampoAlfanumerico, 255, 1, "") == true) &&
      (blnValidarCampo(document.forms[0].elements["txtTransaccionCTF"], false, "Transaccion CTF", cintTipoCampoEntero, 4, 1, "") == true) &&
      (blnValidarCampo(document.forms[0].elements["txtCTFCampoCompuestoId"], false, "Campo compuesto para Transacción CTF", cintTipoCampoEntero, 4, 1, "") == true) &&
      (blnValidarCampo(document.forms[0].elements["txtCTFLongitudCampoCompuesto"], false, "Longitud del campo compuesto", cintTipoCampoEntero, 4, 1, "") == true) &&
      (blnValidarCampo(document.forms[0].elements["txtClaveImpresion"], true, "Clave de impresión", cintTipoCampoEntero, 4, 1, "") == true) &&
      (blnValidarCampo(document.forms[0].elements["txtComisionCTF"], false, "Transacción comisión CTF", cintTipoCampoEntero, 4, 0, "") == true) &&
      (blnValidarCampo(document.forms[0].elements["txtComisionCTFsinImpuesto"], false, "Forma pago Comisión CTF sin impuesto", cintTipoCampoEntero, 4, 0, "") == true) &&
      (blnValidarCampo(document.forms[0].elements["txtComisionCTFinterior"], false, "Forma pago comisión CTF interior", cintTipoCampoEntero, 4, 0, "") == true) &&
      (blnValidarCampo(document.forms[0].elements["txtComisionCTFfrontera"], false, "Forma pago comisión CTF exterior", cintTipoCampoEntero, 4, 0, "") == true) &&
      (blnValidarCampo(document.forms[0].elements["txtClaveCancelacion"], false, "Clave de impresión de cancelación", cintTipoCampoEntero, 4, 0, "") == true) &&
      (blnValidarCampo(document.forms[0].elements["txtMontoMaximoEgreso"], false, "Monto máximo egreso", cintTipoCampoReal, 9, 0, "") == true) &&
      (blnValidarCampo(document.forms[0].elements["txtComision"], false, "Comisión", cintTipoCampoReal, 9, 0, "") == true) )
  {
      blnReturn = true;
      
      //Debe seleccionar un elemento del combo box Tipo
      if (blnValidarComboBox(document.forms[0].elements["cboTipo"], "", "Tipo", true) == false){
          return(false);
      }
      
      //Debe seleccionar un elemento del combo box Tipo
      if (blnValidarComboBox(document.forms[0].elements["cboIntegrador"], "", "Integrador", true) == false){
          return(false);
      }
      
      //Si el tipo no es informativo...
      if (strTextoSeleccionadoEnCbo(document.forms[0].elements["cboTipo"]).toLowerCase().indexOf('informativo') == -1){
        //... debe seleccionar un elemento del combo box Tipo ticket
        if (blnValidarComboBox(document.forms[0].elements["cboTipoTicket"], "", "Tipo ticket", true) == false){
            return(false);
        }
        //... entonces la transaccion CTF es requerida
        if (blnValidarCampo(document.forms[0].elements["txtTransaccionCTF"], true, "Transaccion CTF", cintTipoCampoEntero, 4, 1, "") == false){
            return(false);
        }
        
        //... entonces el campo compuesto Id es requerido
        if (blnValidarCampo(document.forms[0].elements["txtCTFCampoCompuestoId"], true, "Campo compuesto para Transacción CTF", cintTipoCampoEntero, 4, 1, "") == false){
            return(false);
        }
        
        //... entonces la longitud del campo compuesto Id es requerida
        if (blnValidarCampo(document.forms[0].elements["txtCTFLongitudCampoCompuesto"], true, "Longitud del campo compuesto", cintTipoCampoEntero, 4, 1, "") == false){
            return(false);
        }
      }
      
      //Si se encuentra un valor en la comision entonces tiene que haber un valor especificado
      //   en txtComisionCTF, txtComisionCTFinterior, txtComisionCTFfrontera y txtComisionCTFsinImpuesto
      if (document.forms[0].elements["txtComision"].value != ""){
          if((blnValidarCampo(document.forms[0].elements["txtComisionCTF"], true, "Transacción comisión CTF", cintTipoCampoEntero, 4, 1, "") == true) &&
             (blnValidarCampo(document.forms[0].elements["txtComisionCTFsinImpuesto"], true, "Forma pago Comisión CTF sin impuesto", cintTipoCampoEntero, 4, 1, "") == true) &&
             (blnValidarCampo(document.forms[0].elements["txtComisionCTFinterior"], true, "Forma pago comisión CTF interior", cintTipoCampoEntero, 4, 1, "") == true) &&
             (blnValidarCampo(document.forms[0].elements["txtComisionCTFfrontera"], true, "Forma pago comisión CTF exterior", cintTipoCampoEntero, 4, 1, "") == true)  )
          {
              blnReturn = true;
          }else{
              return(false);
          }   
       }
       
       //Si se encuentra seleccionada la casilla de desglose tiene que haber una comision
      if (document.forms[0].elements["chkDesglose"].checked == true){
         if (blnValidarCampo(document.forms[0].elements["txtComision"], true, "Comisión", cintTipoCampoReal, 9, 1, "") == true){
            blnReturn = true;
         }else{
            return(false);
         }
      }
      
      //Si se encuentra seleccionada la casilla de imprimir ticket de cancelacion se debe especificar la clave de cancelacion
      if (document.forms[0].elements["chkImprimirCancelacion"].checked == true){
         if (blnValidarCampo(document.forms[0].elements["txtClaveCancelacion"], true, "Clave de impresión de cancelación", cintTipoCampoEntero, 4, 0, "") == true){
            blnReturn = true;
         }else{
            return(false);
         }
      }      
     
     //Si el combo box de tipo es Ingreso tiene que especificarse un importe
     if (strTextoSeleccionadoEnCbo(document.forms[0].elements["cboTipo"]).toLowerCase().indexOf('ingreso') != -1)
     {
         if (blnValidarCampo(document.forms[0].elements["txtImporte"], true, "Importe", cintTipoCampoAlfanumericoConPipe, 255, 1, "") == true)
            {
              blnReturn = true;
            }
            else
            {
              return(false);
            }
     }
     
     //Si el combo box de tipo es Egreso tiene que especificarse un monto maximo y un importe
     if (strTextoSeleccionadoEnCbo(document.forms[0].elements["cboTipo"]).toLowerCase().indexOf('egreso') != -1)
     {
         if (blnValidarCampo(document.forms[0].elements["txtImporte"], true, "Importe", cintTipoCampoAlfanumericoConPipe, 255, 1, "") == true)
            {
              blnReturn = true;
            }
            else
            {
              return(false);
            }
     }
     
     //El codigo del producto no puede estar repetido
     if (ValidarCodigoProducto() == true)
     {
      blnReturn = true;
     }
     else
     {
      alert("El código de producto esta repetido, favor de cambiarlo.");
      return(false);
     }
     
  }else{
		blnReturn = false;
  }
  
  
  return(blnReturn);  
  
}

function cmdSeleccionar_onclick() {
   var intSolicitudActualizacionId = 0;
   return Pop("SucursalServicioVirtualCamposAgregarEditar.aspx","460","480")
}

// SOFTTEK-LFLJ-10/OCT/2013.T1.1.
// ServicioVirtual-Tienda. cboDireccionOperativa
function cboDireccionOperativa_onChange(dropdown) {
	document.forms[0].action += "?strCmd=Editar&intTipoServicioId=" + <%= intTipoServicioVirtualId() %> + "&intServicioID=" + <%= intServicioVirtualId() %>;
    document.forms[0].submit();
}
// SOFTTEK-LFLJ-10/OCT/2013.T1.1.
// ServicioVirtual-Tienda. cboZonaOperativa
function cboZonaOperativa_onChange(dropdown) {
 // if (document.forms[0].elements["cboZonaOperativa"].selectedIndex > 0) {
 	document.forms[0].action += "?strCmd=Editar&intTipoServicioId=" + <%= intTipoServicioVirtualId() %> + "&intServicioID=" + <%= intServicioVirtualId() %>;
	document.forms[0].submit();
 // }
}
// SOFTTEK-LFLJ-10/OCT/2013.T1.1.
// ServicioVirtual-Tienda. chkTiendaTodas
function chkTiendaTodas_onClick() {
  for (var intCounter = 0; intCounter < document.forms[0].elements["cboTienda"].length; intCounter++) {
    document.forms[0].elements["cboTienda"].options[intCounter].selected = document.forms[0].elements["chkTiendaTodas"].checked;
  }
}
// SOFTTEK-LFLJ-10/OCT/2013.T1.1.
// ServicioVirtual-Tienda. cmdAgregarTiendas
function cmdAgregarTiendas_onClick()
{
  var blnSelected = false;
  
  for (var intCounter = 0; intCounter < document.forms[0].elements["cboTienda"].length; intCounter++) {
    blnSelected = document.forms[0].elements["cboTienda"].options[intCounter].selected;
    if (blnSelected == true) {
      break;
    }
  }

  if (blnSelected == true) {
    document.forms[0].action += "?strCmd=AgregarTiendas&intTipoServicioId=" + <%= intTipoServicioVirtualId() %> + "&intServicioID=" + <%= intServicioVirtualId() %>;
    document.forms[0].submit();
  } 
  else {
    alert("Por favor seleccione al menos una Tienda.");
    document.forms[0].elements["cboTienda"].focus();
    return(false);
  }
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
					<td class="tdtab" width="770">Está en : <A href="SucursalHome.aspx">Sucursal</A> : <A href="SucursalTipoServicioVirtual.aspx">
							Tipo de Servicios</A> : <A onclick="cmdRegresar_onclick()" href="#">Administrar&nbsp;Servicios 
							Virtuales </A>: Agregar - Editar&nbsp;Servicio Virtual
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Servicios Virtuales</h1>
						<p>Aquí podrá dar de alta o modificar&nbsp;un servicio virtual.</p>
						<br>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="tdtexttablebold" width="163" height="46"><label for="txtEmpresaNombre">Tipo 
										de Servicio Virtual:</label>
								</td>
								<td class="tdpadleft5"><input class="field" id="txtTipoServicioVirtualDescripcion" readOnly maxLength="50" size="80"
										name="txtTipoServicioVirtualDescripcion">
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
						</table>
						<h2>Definir&nbsp;Servicio Virtual</h2>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="tdtexttablebold" width="168" height="46"><label for="txtDescripcion">Descripción 
										POS:</label>
								</td>
								<td class="tdpadleft5" style="WIDTH: 206px"><input class="field" id="txtDescripcion" maxLength="255" size="30" name="txtDescripcion">
								</td>
								<td class="tdtexttablebold" width="168" height="46"><label for="txtTipoMovimiento">Tipo 
										ticket:</label></td>
								<td class="tdpadleft5"><select class="campotabla" id="cboTipoTicket" name="cboTipoTicket">
										<option value="0" selected>» Elija tipo ticket «</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="168" height="46"><label for="txtCodigoProducto">Código 
										producto:</label>
								</td>
								<td class="tdpadleft5" style="WIDTH: 206px"><input class="field" id="txtCodigoProducto" maxLength="50" size="30" name="txtCodigoProducto">
								</td>
								<td class="tdtexttablebold" width="168" height="46"><label for="txtTipo">Tipo:</label></td>
								<td class="tdpadleft5"><select class="campotabla" id="cboTipo" name="cboTipo">
										<option value="0" selected>» Elija tipo «</option>
									</select>
								</td>
							</tr>
							<TR>
								<TD class="tdtexttablebold" height="46" width="168">Validar Supervisor:</TD>
								<TD style="WIDTH: 206px" class="tdpadleft5"><INPUT style="Z-INDEX: 0" id="chkValidarSupervisor" class="fieldborderless" value="True"
										CHECKED type="checkbox" name="chkValidarSupervisor"></TD>
								<TD class="tdtexttablebold" height="46" width="168">Integrador:</TD>
								<TD class="tdpadleft5" rowSpan="2"><SELECT id="cboIntegrador" class="campotabla" onchange="cboIntegrador_onChange(this.form.cboIntegrador)"
										name="cboIntegrador">
										<OPTION selected value="0">» Elija integrador «</OPTION>
									</SELECT>
								</TD>
							</TR>
						</table>
						<br>
						<h2>Afectación Contable</h2>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TBODY>
								<tr>
									<td class="tdtexttablebold" width="168" height="46"><label for="txtTransaccionCTF">Transacción 
											CTF:</label>
									</td>
									<td class="tdpadleft5" style="WIDTH: 206px"><input class="field" id="txtTransaccionCTF" maxLength="4" size="4" name="txtTransaccionCTF">
									</td>
								</tr>
								<tr>
									<td height="2">&nbsp;</td>
								</tr>
								<tr>
									<td class="tdtexttablebold" width="168" height="46"><label for="txtComisionCTFinterior">Campo 
											compuesto para Transaccion CTF:</label>
									</td>
									<td class="tdpadleft5" style="WIDTH: 206px"><input class="field" id="txtCTFCampoCompuestoId" maxLength="4" size="4" name="txtCTFCampoCompuestoId">
									</td>
									<td class="tdtexttablebold" width="168" height="46"><label for="txtCTFLongitudCampoCompuesto">Longitud 
											del campo compuesto:</label>
									</td>
									<td class="tdpadleft5"><input class="field" id="txtCTFLongitudCampoCompuesto" maxLength="4" size="4" name="txtCTFLongitudCampoCompuesto">
									</td>
								</tr>
								<tr>
									<td height="2">&nbsp;</td>
								</tr>
								<tr>
									<td class="tdtexttablebold" width="168" height="46"><label for="txtComision">Comisión 
											($) :</label>
									</td>
									<td class="tdpadleft5" style="WIDTH: 206px"><input class="field" id="txtComision" maxLength="9" size="9" name="txtComision">
									</td>
									<td class="tdtexttablebold" width="168" height="46"><label for="txtComisionCTF">Transacción 
											comisión CTF:</label>
									</td>
									<td class="tdpadleft5"><input class="field" id="txtComisionCTF" maxLength="4" size="4" name="txtComisionCTF">
									</td>
								</tr>
								<tr>
									<td height="2">&nbsp;</td>
								</tr>
								<tr>
									<td class="tdtexttablebold" width="168" height="46"><label for="txtComisionCTFsinImpuesto">Forma 
											pago Comisión CTF sin impuesto:</label>
									</td>
									<td class="tdpadleft5" style="WIDTH: 206px"><input class="field" id="txtComisionCTFsinImpuesto" maxLength="4" size="4" name="txtComisionCTFsinImpuesto">
									</td>
									<td class="tdtexttablebold" width="168" height="46"><label for="txtComisionCTFinterior">Forma 
											pago comisión CTF interior:</label>
									</td>
									<td class="tdpadleft5"><input class="field" id="txtComisionCTFinterior" maxLength="4" size="4" name="txtComisionCTFinterior">
									</td>
								</tr>
								<tr>
									<td height="2">&nbsp;</td>
								</tr>
								<tr>
									<td class="tdtexttablebold" width="168" height="46"><label for="txtComisionCTFfrontera">Forma 
											pago comisión CTF frontera:</label>
									</td>
									<td class="tdpadleft5" style="WIDTH: 206px"><input class="field" id="txtComisionCTFfrontera" maxLength="4" size="4" name="txtComisionCTFfrontera">
									</td>
								</tr>
								<tr>
									<td height="2">&nbsp;</td>
								</tr>
								<tr>
									<!-- stkIUSACFE CJBG 10/07/2013 Agregando comisión para el integrador -->
									<td class="tdtexttablebold" width="168" height="46"><label for="txtComisionIntegrador"> 
											Comisión Integrador ($) :</label>
									</td>
									<td class="tdpadleft5" style="WIDTH: 206px"><input class="field" id="txtComisionIntegrador" maxLength="9" size="9" name="txtComisionIntegrador">
									</td>
									<td class="tdtexttablebold" width="168" height="46"><label for="txtComisionIntegradorCTF">Transacción 
											Comisión Integrador CTF:</label>
									</td>
									<td class="tdpadleft5"><input class="field" id="txtComisionIntegradorCTF" maxLength="4" size="4" name="txtComisionIntegradorCTF">
									</td>
								</tr>
								<tr>
									<td height="2">&nbsp;</td>
								</tr>
								<tr>
									<td class="tdtexttablebold" width="168" height="46"><label for="txtComisionIntegradorCTFsinImpuesto">Forma 
											pago Comisión Integrador CTF sin impuesto:</label>
									</td>
									<td class="tdpadleft5" style="WIDTH: 206px"><input class="field" id="txtComisionIntegradorCTFsinImpuesto" maxLength="4" size="4" name="txtComisionIntegradorCTFsinImpuesto">
									</td>
									<td class="tdtexttablebold" width="168" height="46"><label for="txtComisionIntegradorCTFinterior">Forma 
											pago Comisión Integrador CTF interior:</label>
									</td>
									<td class="tdpadleft5"><input class="field" id="txtComisionIntegradorCTFinterior" maxLength="4" size="4" name="txtComisionIntegradorCTFinterior">
									</td>
								</tr>
								<tr>
									<td height="2">&nbsp;</td>
								</tr>
								<tr>
									<td class="tdtexttablebold" width="168" height="46"><label for="txtComisionIntegradorCTFfrontera">Forma 
											pago Comisión Integrador CTF frontera:</label>
									</td>
									<td class="tdpadleft5" style="WIDTH: 206px"><input class="field" id="txtComisionIntegradorCTFfrontera" maxLength="4" size="4" name="txtComisionIntegradorCTFfrontera">
									</td>
									<td class="tdtexttablebold" height="46" width="168">Separar Comisión Integrador de 
										Monto:</td>
									<td style="WIDTH: 206px" class="tdpadleft5"><INPUT style="Z-INDEX: 0" id="chkSeparaComisionIntegrador" class="fieldborderless" value="True"
											CHECKED type="checkbox" name="chkSeparaComisionIntegrador">
									</td>
								</tr>
								<tr>
									<td height="2">&nbsp;</td>
								</tr>
							</TBODY>
						</table>
						<br>
						<h2>Campos Configurables</h2>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="tdtexttablebold" width="168" height="46"><label for="txtCamposNoAlmacenados">Lista 
										de campos no almacenados: </label>
								</td>
								<td class="tdpadleft5" style="WIDTH: 206px"><input class="field" id="txtCamposNoAlmacenados" maxLength="255" size="30" name="txtCamposNoAlmacenados">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="168" height="46"><label for="txtAutorizacion">Autorización:</label>
								</td>
								<td class="tdpadleft5" style="WIDTH: 206px"><input class="field" id="txtAutorizacion" maxLength="50" size="30" name="txtAutorizacion">
								</td>
								<td class="tdtexttablebold" width="168" height="46"><label for="txtCantidad">Cantidad:</label>
								</td>
								<td class="tdpadleft5"><input class="field" id="txtCantidad" maxLength="50" size="30" name="txtCantidad">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="168" height="46"><label for="txtImporte">Precio:</label>
								</td>
								<td class="tdpadleft5" style="WIDTH: 206px"><input class="field" id="txtImporte" maxLength="50" size="30" name="txtImporte">
								</td>
								<td class="tdtexttablebold" width="168" height="46">Monto:</td>
								<td class="tdpadleft5"><input class="field" id="txtMonto" maxLength="50" size="30" name="txtMonto">
								</td>
							</tr>
						</table>
						<br>
						<h2>Otras Configuraciones</h2>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="tdtexttablebold" width="168" height="46">Re impresión:
								</td>
								<td class="tdpadleft5" style="WIDTH: 206px"><input class="fieldborderless" id="chkReimpresion" type="checkbox" CHECKED value="True"
										name="chkReimpresion">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="168" height="46">Confirmación de operación 
									exitosa:
								</td>
								<td class="tdpadleft5" style="WIDTH: 206px"><input class="fieldborderless" id="chkOperacionExitosa" type="checkbox" CHECKED value="True"
										name="chkOperacionExitosa"></td>
								<td class="tdtexttablebold" width="168" height="46">Leyenda para confirmación de 
									operación exitosa:
								</td>
								<td class="tdpadleft5"><input class="field" id="txtLeyendaExitosa" maxLength="255" size="30" name="txtLeyendaExitosa">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="168" height="46">Reversa:
								</td>
								<td class="tdpadleft5" style="WIDTH: 206px"><input class="fieldborderless" id="chkReversa" type="checkbox" CHECKED value="True" name="chkReversa">
								</td>
								<td class="tdtexttablebold" width="168" height="46"><label for="txtClaveImpresion">Clave 
										de impresión:</label>
								</td>
								<td class="tdpadleft5"><input class="field" id="txtClaveImpresion" maxLength="4" size="4" name="txtClaveImpresion">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="168" height="46">Imprimir ticket de cancelación:
								</td>
								<td class="tdpadleft5" style="WIDTH: 206px"><input class="fieldborderless" id="chkImprimirCancelacion" type="checkbox" CHECKED value="True"
										name="chkImprimirCancelacion">
								</td>
								<td class="tdtexttablebold" width="168" height="46"><label for="txtClaveCancelacion">Clave 
										de impresión de cancelación:</label>
								</td>
								<td class="tdpadleft5"><input class="field" id="txtClaveCancelacion" maxLength="4" size="4" name="txtClaveCancelacion">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="168" height="46">Desglose de Impuesto:
								</td>
								<td class="tdpadleft5" colSpan="3"><input class="fieldborderless" id="chkDesglose" type="checkbox" CHECKED value="True" name="chkDesglose">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="168" height="46"><label for="txtMontoMaximoEgreso">Monto 
										máximo egreso:</label>
								</td>
								<td class="tdpadleft5" style="WIDTH: 206px"><input class="field" id="txtMontoMaximoEgreso" maxLength="9" size="9" name="txtMontoMaximoEgreso">
								</td>
								<td class="tdtexttablebold" width="168" height="46"><label for="txtReferencia">Leyenda 
										para Referencia:</label>
								</td>
								<td class="tdpadleft5"><input class="field" id="txtReferencia" maxLength="255" size="30" name="txtReferencia">
								</td>
							</tr>
						</table>
						<br>
						<%-- Comienza El Apartado Para Las Configuraciones 
					' Nombre   : Tarjetas de Regalo. chkFacturaVenta chkFacturaAplicaComision  txtTextoTicket chkTarjetaActiva
					' Proyecto : PPSV
					' Fecha    : 30-05-2013		 JPMB			--%>
						<div id="DivTarjetaRegalo">
							<h2>Configuraciones De Tarjetas De Regalo</h2>
							<table border="0" cellSpacing="0" cellPadding="0" width="100%">
								<TBODY>
									<tr>
										<td class="tdtexttablebold" height="46" width="168"><label for="txtFacturaVenta">Factura 
												de Venta:</label>
										</td>
										<td style="WIDTH: 206px" class="tdpadleft5"><INPUT id="chkFacturaVenta" class="fieldborderless" onclick="desactivaCheckBox('chkFacturaAplicaComision')"
												type="checkbox" name="chkFacturaVenta" value="true">
										</td>
										<td class="tdtexttablebold" height="46" width="168"><label for="txtFacturaAplicaComision">Factura 
												Comisión:</label>
										</td>
										<td class="tdpadleft5"><INPUT id="chkFacturaAplicaComision" class="fieldborderless" onclick="desactivaCheckBox('chkFacturaVenta')"
												type="checkbox" name="chkFacturaAplicaComision" value="true">
										</td>
									</tr>
									<tr>
										<td height="2">&nbsp;</td>
									</tr>
									<tr>
										<td class="tdtexttablebold" height="46" width="168"><label for="txtTipoMovimiento">Texto 
												ticket:</label></td>
										<td class="tdtexttablebold" height="46" width="168"><input id="txtTextoTicket" class="field" maxLength="255" size="30" name="txtTextoTicket">
										</td>
					</td>
					<TD class="tdtexttablebold" height="46" width="168">Tarjeta Activa:</TD>
					<TD style="WIDTH: 206px" class="tdpadleft5"><INPUT style="Z-INDEX: 0" id="chkTarjetaActiva" class="fieldborderless" value="True" CHECKED
							type="checkbox" name="chkTarjetaActiva"></TD>
				</tr>
				<tr>
					<td height="2">&nbsp;</td>
				</tr>
			</table>
			</DIV>
			<%-- Termina el Apartado De Tarjetas De Regalo --%>
			<table>
				<tr>
					<td class="tdtexttablebold" vAlign="top" align="right" colSpan="2"><input language="javascript" class="button" id="cmdRegresar" onclick="return cmdRegresar_onclick()"
							type="button" value="Regresar" name="cmdRegresar">
					</td>
					<td class="tdtexttablebold" vAlign="top" align="right" colSpan="2"><input class="button" onclick="return cmdGuardar_onclick()" type="button" value="Guardar"
							name="cmdGuardar">
					</td>
				</tr>
			</table>
			<br>
			<%-- Inicia La Forma De Pago JPMB--%>
			<div id="DivFormaPago">
				<h2>Forma de Pago</h2>
				<table border="0" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td class="tdtexttablebold" height="46" width="100"><label for="txtCampoId">Forma de 
								Pago:</label>
						</td>
						<td class="tdpadleft5" width="244"><SELECT id="cboFormaDePago" class="campotabla" name="cboFormaDePago">
								<OPTION selected value="0">» Elija Forma de Pago «</OPTION>
							</SELECT>
						</td>
					<tr>
						<td class="tdtexttablebold" vAlign="top" colSpan="4" align="right"><input id="cmdAgregarFormaPago" language="javascript" class="button" onclick="return cmdAgregarFormaDePago_onclick()"
								value="Agregar" type="button" name="cmdAgregar">
						</td>
					</tr>
				</table>
				<table border="0" cellSpacing="0" cellPadding="0" width="100%">
					<tr>
						<td>
							<%= strGetRecordBrowserHTMLFormaDePago() %>
						</td>
					</tr>
				</table>
			</div>
			<%-- Termina La Opcion Para La Forma De Pago--%>
			<br>
			<h2>Datos Adicionales</h2>
			<table cellSpacing="0" cellPadding="0" width="85%" border="0">
				<tr>
					<td class="tdtexttablebold" width="100" height="46"><label for="txtCampoId">Id campo:</label>
					</td>
					<td class="tdpadleft5" width="244"><input class="field" id="txtCampoId" maxLength="4" size="4" name="txtCampoId">
					</td>
					<td class="tdtexttablebold" width="100" height="46"><label for="txtNombreCampo">Nombre 
							campo:</label>
					</td>
					<td class="tdpadleft5"><input class="field" id="txtNombreCampo" maxLength="50" size="50" name="txtNombreCampo">
					</td>
				</tr>
				<tr>
					<td height="4">&nbsp;</td>
				</tr>
				<tr>
					<td class="tdtexttablebold" vAlign="top" align="right" colSpan="4"><input language="javascript" class="button" id="cmdAgregar" onclick="return cmdAgregar_onclick()"
							type="button" value="Agregar" name="cmdAgregar">
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="75%" border="0">
				<tr>
					<td>
						<%= strGetRecordBrowserHTML() %>
					</td>
				</tr>
			</table>
			<BR>
			<BR>
			<H2>Campo Variable</H2>
			<TABLE id="TableConfiguracionCampos" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD class="tdtexttablebold" height="24" width="30"><label>POS:</label></TD>
					<TD class="tdtexttablebold" height="24" width="175"><label>&nbsp;&nbsp;Descripción:</label></TD>
					<TD class="tdtexttablebold" height="24" width="50">&nbsp;LDI Id<br>
						Servicio:</TD>
					<TD class="tdtexttablebold" height="24" width="50">&nbsp;Id<br>
						Campo:</TD>
					<TD class="tdtexttablebold" height="24" width="125"><label>Propiedad:</label></TD>
					<TD class="tdtexttablebold" height="24" width="98"><label>&nbsp;Tipo:</label></TD>
					<TD class="tdtexttablebold" height="24" width="70"><label>&nbsp;Valor:</label></TD>
					<TD class="tdtexttablebold" height="24" width="50"><label>Tamaño:</label></TD>
					<TD class="tdtexttablebold" height="24"><label>Días de Vencimiento:</label></TD>
				</TR>
				<TR>
					<TD class="tdpadleft5" height="29" width="30"><INPUT style="Z-INDEX: 0" id="CheckBoxPOS" class="fieldborderless" value="True" CHECKED
							type="checkbox" name="CheckBoxPOS"></TD>
					<TD class="tdtexttablereg" height="29" width="175">&nbsp; <INPUT id="txtDescripcionCampo" class="field" maxLength="50" size="34" name="txtDescripcionCampo"></TD>
					<TD class="tdpadleft5" height="29" width="50"><input id="txtLDITipoIdCampo" class="field" maxLength="5" size="4" name="txtLDITipoIdCampo"
							onkeypress="return isNumber()"></TD>
					<TD class="tdpadleft5" height="29" width="50"><input id="txtLDISubtipoIdCampo" class="field" maxLength="5" size="4" name="txtLDISubtipoIdCampo"
							onkeypress="return isNumber()"></TD>
					<TD class="tdpadleft5" height="29" width="125"><SELECT id="cboPropiedadCampo" class="campotabla" onchange="cboPropiedadCampo_onChange(this.form.cboPropiedadCampo)"
							name="cboPropiedadCampo">
							<OPTION selected value="default">» Elija propiedad «</OPTION>
							<OPTION value="envio">Envío</OPTION>
							<OPTION value="solicitud">Solicitud</OPTION>
							<OPTION value="respuesta">Respuesta</OPTION>
							<OPTION value="impresion">Impresión</OPTION>
						</SELECT></TD>
					<TD class="tdpadleft5" height="29" width="98"><SELECT id="cboTipoCampo" class="campotabla" onchange="cboTipoCampo_onChange(this.form.cboTipoCampo)"
							name="cboTipoCampo">
							<OPTION selected value="default">» Elija tipo «</OPTION>
							<OPTION value="numerico">Numérico</OPTION>
							<OPTION value="alfanumerico">Alfanumérico</OPTION>
							<OPTION value="fecha">Fecha</OPTION>
						</SELECT></TD>
					<TD class="tdpadleft5" height="29" width="70"><input id="txtValorCampo" class="field" maxLength="30" size="9" onkeypress="return isNumberValor()"
							name="txtValorCampo"></TD>
					<TD class="tdpadleft5" height="29" width="50"><input id="txtCtdCaracteresCampo" class="field" maxLength="5" size="4" name="txtCtdCaracteresCampo"
							onkeypress="return isNumber()"></TD>
					<TD class="tdpadleft5" height="29"><input id="txtDiasVencimientoCampo" class="field" maxLength="5" size="4" name="txtDiasVencimientoCampo"
							onkeypress="return isNumber()"></TD>
				</TR>
				<TR>
					<TD class="tdtexttablebold" height="29" vAlign="top" width="754" colSpan="9" align="right"><INPUT id="cmdAgregarCampoVariable" language="javascript" class="button" disabled onclick="return cmdAgregarCampoVariable_onClick()"
							value="Agregar" type="button" name="cmdAgregarCampoVariable">
					</TD>
				</TR>
			</TABLE>
			<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td>
						<%= strGetRecordBrowserHTMLCamposConfigurables() %>
					</td>
				</tr>
			</TABLE>
			<BR>
			
			<%-- ServicioVirtual-Tienda.(Inicio)					                 --%>
			<%-- Actualización: Asignación de Tiendas a Servicios Virtuales.T1.1.    --%>
			<%-- Fecha        : 10/OCT/2013		 									 --%>
			<%-- Autor        : SOFTTEK-LFLJ.                                        --%>
			
			<H2>Tienda</H2>
			<TABLE id="TablaTienda" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD class="tdtexttablebold" height="24" width="30%"><label>Dirección:</label></TD>
					<TD class="tdtexttablebold" height="24" width="30%"><label>&nbsp;Zona:</label></TD>
					<TD class="tdtexttablebold" height="24" width="40%"><label>&nbsp;Tienda:</label></TD>
				</TR>
				<TR>
					<TD class="tdpadleft5" height="29" width="30%">
						<SELECT id="cboDireccionOperativa" language="javascript" class="campotabla" onchange="cboDireccionOperativa_onChange(this.form.cboDireccionOperativa)"
							name="cboDireccionOperativa">
							<OPTION selected value="0">» Elija Dirección «</OPTION>
						</SELECT>
					</TD>
					<TD class="tdpadleft5" height="29" width="30%">
						<SELECT id="cboZonaOperativa" language="javascript" class="campotabla" onchange="cboZonaOperativa_onChange(this.form.cboZonaOperativa)"
							name="cboZonaOperativa">
							<OPTION selected value="0">» Elija Zona «</OPTION>
						</SELECT>
					</TD>
					<TD class="tdtexttablebold" height="24" width="40%">
						<input type="checkbox" name="chkTiendaTodas" value="checkbox" onclick="return chkTiendaTodas_onClick()">&nbsp;Seleccionar 
						todas
					</TD>
				</TR>
				<TR>
					<TD class="tdtexttablebold" height="24" width="30%"></TD>
					<TD class="tdtexttablebold" height="24" width="30%"></TD>
					<TD class="tdpadleft5">
						<SELECT name="cboTienda" size="10" multiple id="cboTienda" class="comboTabla" language="javascript"
							onchange="cboTienda_onChange(this.form.cboTienda)">
						</SELECT>
					</TD>
				</TR>
				<TR>
					<TD class="tdtexttablebold" height="29" vAlign="top" width="754" colSpan="3" align="right">
						<INPUT id="cmdAgregarTiendas" language="javascript" class="button" disabled onclick="return cmdAgregarTiendas_onClick()"
							value="Agregar" type="button" name="cmdAgregarTiendas">
					</TD>
				</TR>
			</TABLE>
			<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD>
						<%= strGetRecordBrowserHTMLTiendas() %>
					</TD>
				</TR>
			</TABLE>
			<BR>
			
			<%-- ServicioVirtual-Tienda.(Fin) --%>
			
			</TD></TR></TBODY></TABLE>
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
