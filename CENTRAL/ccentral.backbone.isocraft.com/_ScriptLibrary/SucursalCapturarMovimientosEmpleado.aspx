<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="SucursalCapturarMovimientosEmpleado.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsSucursalCapturarMovimientosEmpleado" codePage="28605" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : SucursalCapturarMovimientosEmpleado.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página donde se capturan los movimientos de los empleados 
	'				  de la sucursal en el periodo actual
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Armando Calzada Mezura
    ' Version       : 1.0
    ' Last Modified : Jueves, Octubre 23, 2003
    ' Modificacion  : Septiembre 15, 2004; Griselda Gómez Ponce
    '                Se anade validación del tab y enter en la clave del concepto.
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";

var checkOK = "0123456789.";


function blnIsNumber(checkStr) {

	var allValid = true;
  
	if (checkStr.length < 1) {
		allValid = false;
	}
  	else {
		for (i = 0;  i < checkStr.length;  i++)
		{
			ch = checkStr.charAt(i);
			for (j = 0;  j < checkOK.length;  j++)
				if (ch == checkOK.charAt(j))
					break;
				if (j == checkOK.length)
				{
					allValid = false;
					break;
				}
		}
  }
  
  return (allValid);
}

function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
    document.forms[0].action = "<%=strFormAction%>";
	document.forms[0].txtDiasCierre.value = <%=intDiasRestantes%>;
	<% if intError = 0 then %>
		document.forms[0].txtConcepto.value = "<%=strConceptoId%>";
		document.forms[0].txtConceptoNombre.value = "<%=strConceptoNombre%>";
		document.forms[0].txtCantidadMaxima.value = "<%=strCantidadMaxima%>";
		document.forms[0].txtConceptoId.value = "<%=intConceptoId%>";
	<% elseif intError = -100 then %>
			alert("Concepto no existe. Favor de ingresar un código existente");
			document.forms[0].elements['txtConcepto'].focus();
	<% end if %>
	document.forms[0].txtCantidad.value = "<%=strCantidad%>";
	document.forms[0].txtFechaRegistro.value = "<%=strFechaRegistro%>";
	if (document.forms[0].elements['txtConcepto'].value==""){
	    document.forms[0].elements['txtConceptoNombre'].value="";
	 document.forms[0].elements['txtConcepto'].focus();
	}
	else {
	 document.forms[0].elements['txtCantidad'].focus() 
	}
	
    return(true);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

function intCompaniaId() {
	return(<%=intCompaniaId%>);
}

function intSucursalId() {
	return(<%=intSucursalId%>);
}

function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
}

function strCompaniaSucursal() {
	document.write(intCompaniaId() + " - " + intSucursalId());
	return(true);
}

function strSucursalNombre() {
	document.write("<%=strSucursalNombre%>");
	return(true);
}

function strPeriodoPrenomina() {
	document.write("<%=strPeriodoPrenomina%>")
	return(true);		
}

function intEmpleadoBusquedaId() {
	document.write("<%=intEmpleadoBusquedaId%>");
	return(true);
}

function intPuestoEmpleadoBusquedaId() {
	document.write("<%=intPuestoEmpleadoBusquedaId%>");
	return(true);
}

function strEmpleadoBusquedaNombre() {
	document.write("<%=strEmpleadoBusquedaNombre%>");
	return(true);
}

function strRecordBrowserHTML(){
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

function cmdImprimir_onclick() {
	printContent();
	return(true);
}

function cmdRegresar_onclick() {
	location.href = "SucursalCapturarPrenomina.aspx";
	return(true);
}

function cmdBuscarConcepto_onClick() {
	if (document.forms[0].elements['txtConcepto'].value!="") {
		if (document.forms[0].elements['txtConcepto'].value.length == 3) {
			document.forms[0].action += "&strCmd=Consultar";
			document.forms[0].submit();
			return(false);
		}
		else {
			url = "PopConceptoPrenomina.aspx?strConceptoPrenomina=" + document.forms[0].elements['txtConcepto'].value;
			width = 500;
			height = 540;
			return Pop(url, width, height);
		}
	}
	else {
		alert("Teclear código o descripcion del movimiento a buscar");
		document.forms[0].elements['txtConcepto'].focus();
        return false;
	}
}

function txtBuscarConcepto_onKeyDown(){
	if (event.keyCode==13) {cmdBuscarConcepto_onClick()}
	if (event.keyCode==9) {cmdBuscarConcepto_onClick()}
}

function Pop(url, width, height) {
    var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	 return (false);
}

function cmdAgregar_onclick() {
	var theForm = document.forms[0];

	var dtmFechaInicio = new Date("<%=dtmInicioPeriodo%>");
	var dtmFechaFin = new Date("<%=dtmFinPeriodo%>");
	
	var mDia = theForm.txtFechaRegistro.value.substring(0,2);
	var mMes = theForm.txtFechaRegistro.value.substring(3,5);
	var mAnio = theForm.txtFechaRegistro.value.substring(6,10);
	var	dtmFechaRecord = new Date(mMes + "/" + mDia + "/" + mAnio);
	
	if (theForm.txtConcepto.value == "") {
		alert("Teclear código o descripcion del movimiento a agregar");
		theForm.txtConcepto.focus();
        return false;
	}
		
	if (theForm.txtCantidad.value == "") {
		alert("Teclear cantidad a registrar");
		theForm.txtCantidad.focus();
        return false;
	}

	if (blnIsNumber(theForm.txtCantidad.value) == false) {
		alert("Por favor introduzca un valor numérico en el concepto \"Cantidad\".");
		theForm.txtCantidad.value = "";
        theForm.txtCantidad.focus();
		return (false);
    }

	if (parseInt(theForm.txtCantidad.value) == 0) {
		alert("Por favor introduzca un valor numérico mayor a cero en el concepto \"Cantidad\".");
		theForm.txtCantidad.value = "";
        theForm.txtCantidad.focus();
        return(false);
	}
	
	if (parseFloat(theForm.txtCantidad.value)  > parseFloat(theForm.txtCantidadMaxima.value)) {
		alert("La cantidad a registrar no debe ser mayor a " + theForm.txtCantidadMaxima.value);
		theForm.txtCantidad.value = "";
		theForm.txtCantidad.focus();
        return false;
	}
	
	if (dtmFechaInicio.getTime() > dtmFechaRecord.getTime()) {
		alert("La fecha de registro debe de estar en el rango del periodo actual. Favor de capturar una fecha válida");
		return(false);
	}

	if (dtmFechaFin.getTime() < dtmFechaRecord.getTime()) {
		alert("La fecha de registro debe de estar en el rango del periodo actual. Favor de capturar una fecha válida");
		return(false);
	}

	theForm.action += "&strCmd=Agregar";
	theForm.submit();
	return(false);
}
//-->
					</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmASucursalCapturarMovimientosEmpleado">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="34" width="100%"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td width="100%"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en :</span><span class="txdmigaja"> <a href="javascript:strRedireccionaPOSAdmin('Sucursal.aspx');" class="txdmigaja">Sucursal</a> 
                : <a href="javascript:strRedireccionaPOSAdmin('SucursalEmpleados.aspx');" class="txdmigaja">Empleados</a> 
                : <a href="SucursalEmpleadosProcesarPrenomina.aspx" class="txdmigaja">Prenómina</a> 
                : </span><span class="txdmigaja">Capturar movimientos de empleado</span></div></td>
            <td width="187" class="tdfechahora"> <script language="JavaScript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Capturar movimientos de empleado 
                      </span><span class="txcontenido"> Aquí puede registrar y 
                      consultar los movimientos de un empleado que se reflejarán 
                      en la prenómina. Para cada movimiento capture el concepto 
                      y la cantidad y oprima "Agregar". Al terminar, oprima "Salvar 
                      movimientos"&#8217;.</span> 
                      <script language="JavaScript">crearDatosSucursal()</script>
                      <br>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td width="94" class="tdtittablas">En proceso del:</td>
                        <td width="233" valign="middle" class="tdconttablas"><script language="javascript">strPeriodoPrenomina();</script> 
                        </td>
                        <td width="101" valign="middle" class="tdtittablas">Días 
                          para cierre:</td>
                        <td width="140" valign="middle" class="tdpadleft5"><input name="txtDiasCierre" type="text" class="campotablaroja" size="9" maxlength="4" readonly> 
                        </td>
                      </tr>
                    </table>
                    <br> <div id="ToPrintHtmContenido"> 
                      <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                          <td width="140" class="tdtittablas">No. de empleado:</td>
                          <td colspan="2" valign="middle" class="tdconttablas"><script language="javascript">intEmpleadoBusquedaId();</script> 
                            <span class="txconttablasrojo"> 
                            <script language="javascript">strEmpleadoBusquedaNombre();</script>
                            </span></td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Puesto:</td>
                          <td colspan="2" valign="middle" class="tdconttablas"><script language="javascript">intPuestoEmpleadoBusquedaId();</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Concepto:</td>
                          <td width="68" valign="middle" class="tdpadleft5"> <input name="txtConcepto" type="text" onKeyDown="return txtBuscarConcepto_onKeyDown()"
																		class="campotabla" size="9" maxlength="9"> 
                          </td>
                          <td width="360" valign="middle" class="tdpadleft5"><a href="javascript:;" onClick="return cmdBuscarConcepto_onClick();"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="absMiddle"></a>&nbsp; 
                            <input class="campotablaresultado" type="text" size="50" name="txtConceptoNombre" readonly> 
                            &nbsp; <input type="hidden" name="txtConceptoId"> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Cantidad:</td>
                          <td colspan="2" valign="middle" class="tdpadleft5"><input name="txtCantidad" type="text" class="campotabla" size="9" maxlength="9"> 
                            &nbsp; <input type="hidden" name="txtCantidadMaxima"> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Fecha del movimiento:</td>
                          <td colspan="2" valign="middle" class="tdpadleft5"><input name="txtFechaRegistro" type="text" class="campotabla" size="9" maxlength="4" readonly> 
                            <a href="javascript:objCalendar1.popup();"><img src="../static/images/icono_calendario.gif" width="20" height="13" border="0" align="absMiddle"
																			onClick="return blnValidarCampo(document.forms('frmASucursalCapturarMovimientosEmpleado').elements('txtFechaRegistro'),false,'Fecha',cintTipoCampoFecha,10,10,'');"
																			alt="Clic para seleccionar la fecha."></a></td>
                        </tr>
                      </table>
                      <br>
                      <input name="btnAgregar" type="button" class="boton" value="Agregar" onClick="return cmdAgregar_onclick();">
                      <br>
                      <script language="javascript">strRecordBrowserHTML();</script>
                    </div>
                    <br> <input name="btnRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()"> 
                    &nbsp;&nbsp; <input name="btnImprimir" type="button" class="boton" value="Imprimir la lista" onClick="return cmdImprimir_onclick();"> 
                    <br> </td>
                </tr>
              </table></td>
            <td width="187" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda('');</script> 
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	var objCalendar1 = new calendar1(document.forms['frmASucursalCapturarMovimientosEmpleado'].elements['txtFechaRegistro']);
	//-->
			</script>
</form>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</HTML>
