<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SucursalReporteTarjetas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalReporteTarjetas" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
	<HEAD>
		<title>Benavides: Reporte de Tarjetas en Sucursal</title>
		<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="css/menu.css">
		<LINK rel="stylesheet" type="text/css" href="css/estilo.css">
		<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="../static/scripts/tools.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/calendario.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/cal_format00.js"></script>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="css/menu.css">
		<LINK rel="stylesheet" type="text/css" href="css/estilo.css">
		<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
		<script id="clientEventHandlersJS" language="javascript">
<!--

    strUsuarioNombre = "<%= strUsuarioNombre() %>";
    strFechaHora = "<%= strHTMLFechaHora %>";


    function window_onload() {
        document.forms[0].action = "<%= strFormAction %>";

        //Llenado de Combos
        <%= LlenarControlDireccion()%>
        <%= LlenarControlZona()%>
        <%= strLlenarEstadoComboBox() %>
        <%= strLlenarCiudadComboBox() %>
        
        var intDireccionId = "<%= intDireccionId %>";
        var intZonaId = "<%= intZonaId %>";
        var intSucursalId = "<%= intSucursalId%>";

        if (intDireccionId == "-1") {
            document.forms[0].elements["cboDireccionOperativa"].options[1].selected = true;
        }
        if (intZonaId == "-1") {
            document.forms[0].elements["cboZonaOperativa"].options[1].selected = true;
        }

        if (intSucursalId != '') {
            document.getElementById('cboSucursales').value = intSucursalId;
        }

        document.getElementById('cboCiudad').value = "<%=intCiudadId()%>";        
        
        

        

        document.getElementById('TipoEmpleado').value = "<%=strTipoEmpleadoId()%>";



    }

    function strGetCustomDateTime() {
        document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
        return (true);
    }

    function cboDireccionOperativa_onchange() {

        if (document.getElementById('tblResultados').innerHTML != '') {
            document.getElementById('tblResultados').innerHTML = '';
        }

        if (document.getElementById("cboDireccionOperativa").selectedIndex != 0) {

            document.getElementById("cboZonaOperativa").value = "0";
            document.getElementById("cboSucursales").value = "0";

            if (document.getElementById("cboDireccionOperativa").selectedIndex == 1) {

            }
            else {
                document.getElementById("cboZonaOperativa").value = "0";
            }

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultarSucursal'
            document.forms[0].target = '_self';
            document.forms[0].submit();
            return (true);
        }

        return (false);
    }

    function cboZonaOperativa_onchange() {

        if (document.getElementById('tblResultados').innerHTML != '') {
            document.getElementById('tblResultados').innerHTML = '';
        }

        if ((document.getElementById("cboDireccionOperativa").selectedIndex > 0) && (document.getElementById("cboZonaOperativa").selectedIndex != 0)) {

            document.getElementById("cboSucursales").value = "0";

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultarSucursales'
            document.forms[0].target = '_self';
            document.forms[0].submit();
    }

    //Si el usuario selecciona la opcion "Elija una Zona" se resetean las opciones de las Sucursales.
    document.getElementById("cboSucursales").length = 0;

    return (false)
}

    function cboEstado_onchange() {

        if (document.getElementById('tblResultados').innerHTML != '') {
            document.getElementById('tblResultados').innerHTML = '';
        }

    if (document.forms[0].elements["cboEstado"].selectedIndex > 0) {
        document.forms[0].elements["cboCiudad"].selectedIndex = 0;

        document.forms[0].action = "<%= strFormAction %>";
        document.forms[0].target = '_self';
        document.forms[0].submit();
    }

        return (true);
    }


    function cboCiudad_onchange() {

        if (document.getElementById('tblResultados').innerHTML != '') {
            document.getElementById('tblResultados').innerHTML = '';
        }

        if (document.forms[0].elements["cboEstado"].selectedIndex > 1 && document.forms[0].elements["cboCiudad"].selectedIndex > 0) {
            document.forms[0].elements["cboSucursalEstado"].selectedIndex = 0;

            document.forms[0].action = "<%= strFormAction %>";
            document.forms[0].submit();
        }
        return (true);
    }

    function blnValidarSubmit() {
        var blnValidar = true;

        if (document.forms[0].elements["cboEstado"].selectedIndex == 0 && document.forms[0].elements["cboCiudad"].selectedIndex == 0 && document.forms[0].elements["cboSucursalEstado"].selectedIndex == 0) {
            blnValidar = false;
            alert("Seleccionar al menos algun criterio de Estado, Ciudad o Sucursal");
        }

        if (blnValidar && document.forms[0].elements["cboEstado"].selectedIndex > 1 && document.forms[0].elements["cboCiudad"].selectedIndex == 0) {
            blnValidar = false;
            alert("Seleccionar el criterio de Ciudad");
        }

        if (blnValidar && document.forms[0].elements["cboCiudad"].selectedIndex > 1 && document.forms[0].elements["cboSucursalEstado"].selectedIndex == 0) {
            blnValidar = false;
            alert("Seleccionar el criterio de Sucursal");
        }

        return blnValidar;
    }


function cmdConsultar_onclick() {

	//Variables.
	var valida;

	valida = fnValidaCampos();
	if (valida) {
			document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultar';
			document.forms[0].target = "ifrOculto";
			document.forms[0].submit();
	}

	return (valida);
}

function fnValidaCampos() {
	return (true);
}

        //Validacion de fechas.
        function ValidaFechas(dtmFechaIni, dtmFechaFin) {
            valida = true;

            //Validacion de Fecha inicial
            valida = blnValidarCampo(document.getElementById(dtmFechaIni), true, "Fecha Inicial", cintTipoCampoFecha, 10, 10, "");

            //Validacion de Fecha final
            if (valida) {
                valida = blnValidarCampo(document.getElementById(dtmFechaFin), true, "Fecha Final", cintTipoCampoFecha, 10, 10, "");

                //Valida que la fecha inicial NO sea mayor que la fecha final.	
                if (valida) {

                    //Fecha inicial
                    var dtmInicio = document.getElementById(dtmFechaIni).value;
                    var diaIni = dtmInicio.substring(0, 2)
                    var mesIni = dtmInicio.substring(3, 5);
                    var anioIni = dtmInicio.substring(6, 10);

                    //Fecha final
                    var dtmFin = document.getElementById(dtmFechaFin).value;
                    var diaFin = dtmFin.substring(0, 2)
                    var mesFin = dtmFin.substring(3, 5);
                    var anioFin = dtmFin.substring(6, 10);

                    //Validacion
                    var date1 = (anioIni + mesIni + diaIni);
                    var date2 = (anioFin + mesFin + diaFin);

                    //Validaciones de fecha por Tipo de Nomina (Semana y Quncena).
                    var dateIni = new Date(anioIni + "/" + mesIni + "/" + diaIni);
                    var dateIniDay = dateIni.getDay();

                     if (date1 > date2) {
                        alert('La fecha de inicio no debe ser mayor que la fecha final');
                        return (false);
                    }
                }
            }

            return (valida);
        }

        function trim(stringToTrim) {
            return stringToTrim.replace(/^\s+|\s+$/g, "");
        }

        function cmdImprimir_onclick() {

            //Validacion de resultados
            var tablaTotal = document.getElementById('tblResultados').innerHTML;
            if (trim(tablaTotal) == 'Consulta sin resultados' || trim(tablaTotal) == '') {
                alert('No hay resultados de la consulta')
                return (false);
            }

            document.forms[0].action = "<%=strFormAction%>?strCmd=cmdImprimir";
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();
            document.forms[0].target = '';

            return (true);
        }

        function fnImprimir(strMovimientos) {

            //Llamada desde el servidor para imprimir resultados de la consulta.
            document.ifrPageToPrint.document.all.divBody.innerHTML = strMovimientos;
            document.ifrPageToPrint.focus();
            window.print();

        }

        function cmdExportar_onclick() {

            if (document.getElementById('tblResultados').innerHTML == '') {

                alert('Realice la consulta por favor');
                return (false);
            }

            var confirmar = confirm('Desea exportar la informacion?');
            if (confirmar == true) {

                document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdExportar';
                document.forms[0].target = "ifrOculto";
                document.forms[0].submit();
                return (true);

            }
        }

function txtEmpleadoNombreId_onKeyPress(e) {

    document.getElementById('tblResultados').innerHTML = '';

    //Se limpia la descripcion del empleado y se validan los caracteres permitidos.
    document.forms[0].elements['txtEmpleadoNombre'].value = '';

    var key = window.event ? e.keyCode : e.wich;

    //No se permiten caracteres especiales para el Articulo.
    if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || (key == 32)) {
        return true;
    }
    else {
        return false;
    }
}

function txtEmpleadoNombreId_onblur() {

    strEmpleadoCapturado = Trim(document.forms[0].elements['txtEmpleadoNombreId'].value);

    if (strEmpleadoCapturado.length > 0 && strEmpleadoCapturado != '0') {

        if (document.forms[0].elements['hdnEmpleadoNombreId'].value != document.forms[0].elements['txtEmpleadoNombreId'].value) {
            objLupaEmpleado_onclick();
        }
    }
    else {
        document.forms[0].elements['txtEmpleadoNombreId'].value = '';
        return true;
    }
}

function txtEmpleadoNombreId_onKeyDown() {

    if (document.getElementById('tblResultados').innerHTML != '') {
        document.getElementById('tblResultados').innerHTML = '';
    }

    if (event.keyCode == 13 && trim(document.getElementById('txtEmpleadoNombreId').value) != '') { txtEmpleadoNombreId_onblur() }

    document.getElementById('txtEmpleadoNombre').value = '';
    document.getElementById('txtEmpleadoNombre').blur = true;
}

function Pop(url, width, height) {
    var Win = window.open(url, 'Pop', 'width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no');
    return false;
}

function cmdBusquedaSucursal_onfocus(id) {

    if (document.getElementById('tblResultados').innerHTML != '') {
        document.getElementById('tblResultados').innerHTML = '';
    }

    if (id == 1) {

        fnInhabilitarPorEstado();
    }
    else if (id == 2) {

        fnInhabilitarPorZona()
    }

    return (true);
}

function fnInhabilitarPorEstado(){

    document.getElementById('cboDireccionOperativa').disabled = false;
    document.getElementById('cboZonaOperativa').disabled = false;
    document.getElementById('cboSucursales').disabled = false;

    document.getElementById('cboEstado').disabled = true;
    document.getElementById('cboCiudad').disabled = true;
    document.getElementById('cboSucursalEstado').disabled = true;

    document.getElementById('cboEstado').value = "0";
    document.getElementById('cboCiudad').value = "0";
    document.getElementById('cboSucursalEstado').value = "0";

    document.getElementById('rdPorZona').checked = true;

}

function fnInhabilitarPorZona() {

    document.getElementById('cboDireccionOperativa').disabled = true;
    document.getElementById('cboZonaOperativa').disabled = true;
    document.getElementById('cboSucursales').disabled = true;

    document.getElementById('cboEstado').disabled = false;
    document.getElementById('cboCiudad').disabled = false;
    document.getElementById('cboSucursalEstado').disabled = false;

    document.getElementById('cboDireccionOperativa').value = "0";
    document.getElementById('cboZonaOperativa').value = "0";
    document.getElementById('cboSucursales').value = "0";

    document.getElementById('rdPorEstado').checked = true;
}

function dtmFecha_onKeyPress(e) {

    document.getElementById('tblResultados').innerHTML = '';

    //No se permiten caracteres especiales para la fecha.
    var key = window.event ? e.keyCode : e.which;
    if (key > 46 && key < 58) {
        return true;
    }
    else {
        return false
    }
}

//Empleados
function objLupaEmpleado_onclick() {

	var valida = true;
	var intCuentaApostrofes = 0;
	var strEmpleadoCapturado = "";

	if (document.getElementById('tblResultados').innerHTML != '') {
		document.getElementById('tblResultados').innerHTML = '';
	}

	if (document.forms[0].elements['txtEmpleadoNombreId'].readOnly) {
		return (true);
	}

	//if (document.getElementById('cboSucursales').value == 0 && document.getElementById('cboSucursalEstado').value == 0) {
	//    alert('seleccione una sucursal');
	//    return (false);
	//}

	strEmpleadoCapturado = document.forms[0].elements['txtEmpleadoNombreId'].value;

	if (strEmpleadoCapturado.length < 1) {

		alert("Teclear Número de empleado o descripción");
		document.forms[0].elements['txtEmpleadoNombreId'].focus();
		return (false);
	}

	intCuentaApostrofes = strEmpleadoCapturado.search("'");

	if (intCuentaApostrofes != -1) {

		document.forms[0].elements['txtEmpleadoNombreId'].value = '';
		alert("No se deben de capturar apostrofes");
		document.forms[0].elements['txtEmpleadoNombreId'].focus();
		return (false);
	}

	var strtxtEmpleadoB = Trim((document.forms[0].elements['txtEmpleadoNombreId'].value).substring(0, 4));

	if (isNaN(strtxtEmpleadoB) || strtxtEmpleadoB.length < 1) // Esta capturando Descripcion
	{

		strEvalJs = "opener.txtEmpleadoNombreId_onblur();";
		strParametros = ''
		strParametros = strParametros + ' campoProveedorId=hdnEmpleadoId';
		strParametros = strParametros + '&campoEmpleadoNombreId=txtEmpleadoNombreId';
		strParametros = strParametros + '&campoEmpleadoNombre=txtEmpleadoNombre';
		strParametros = strParametros + '&strEmpleadoId=' + document.forms[0].elements['txtEmpleadoNombreId'].value;
		strParametros = strParametros + '&strTipoEmpleadoId=' + document.getElementById("TipoEmpleado").value;

		if (document.getElementById('rdPorZona').checked == true) {
			strParametros = strParametros + '&strCentroLogisticoId=' + document.getElementById('cboSucursales').value;
		}
		else if (document.getElementById('rdPorEstado').checked == true) {
			if (document.getElementById('cboSucursalEstado').value != '-1') {
				strParametros = strParametros + '&strCentroLogisticoId=' + Trim((document.getElementById('cboSucursalEstado').value).substring(0, 4));
			}
			else {
				strParametros = strParametros + '&strCentroLogisticoId=' + Trim((document.getElementById('cboSucursalEstado').value));
			}
		}
	    

		if (document.getElementById("chkActivos").checked == true) {
			strParametros = strParametros + '&blnActivos=1';

		}
		else {
			strParametros = strParametros + '&blnActivos=0';
		}


		Pop('PopEmpleadoVisitasCentral.aspx?' + strParametros + '&strEvalJs=' + strEvalJs, 500, 540);
	}
	else {

		document.forms[0].action = "<%=strFormAction%>?strCmd=BuscarEmpleado"
		document.forms[0].target = "ifrOculto";
		document.forms[0].submit();
		document.forms[0].target = '';
	}
}

function fnUpBuscarEmpleado(intEmpleadoId, strEmpleadoNombre, intError) {

    document.forms[0].elements['hdnEmpleadoId'].value = intEmpleadoId;
    document.forms[0].elements['txtEmpleadoNombreId'].value = intEmpleadoId;
    document.forms[0].elements['hdnEmpleadoNombreId'].value = strEmpleadoNombre;
    document.forms[0].elements['txtEmpleadoNombre'].value = strEmpleadoNombre;

    if (intError != 0) {

        document.forms[0].elements['txtEmpleadoNombreId'].focus();
        alert("Error, Empleado no encontrado");
    }
}

//Fin Empleados

function TipoEmpleado_onchange() {

    if (document.getElementById('tblResultados').innerHTML != '') {
        document.getElementById('tblResultados').innerHTML = '';
    }

    if (document.getElementById('TipoEmpleado').value > 0) {
        document.getElementById('hdnTipoEmpleado').value = document.getElementById('TipoEmpleado').options[document.getElementById('TipoEmpleado').selectedIndex].text;
    }
    
}

function cboSucursales_onchange() {

    if (document.getElementById('tblResultados').innerHTML != '') {
        document.getElementById('tblResultados').innerHTML = '';
    }

    if (document.getElementById('cboSucursales').value != 0) {

        document.getElementById('hdnSucursales').value = document.getElementById('cboSucursales').options[document.getElementById('cboSucursales').selectedIndex].text;
    }
    
}

function cboSucursalEstado_onchange() {

    if (document.getElementById('tblResultados').innerHTML != '') {
        document.getElementById('tblResultados').innerHTML = '';
    }

    if (document.getElementById('cboSucursalEstado').value != 0) {
        document.getElementById('hdnSucursalEstado').value = document.getElementById('cboSucursalEstado').options[document.getElementById('cboSucursalEstado').selectedIndex].text;
    }
}

function chkActivos_onfocus() {
    if (document.getElementById('tblResultados').innerHTML != '') {
        document.getElementById('tblResultados').innerHTML = '';
    }
}

    //-->
		</script>
	</HEAD>
	<body onload="return window_onload()" leftMargin="0" topMargin="0" marginheight="0" marginwidth="0">
		<form method="post" name="frmSucursalReporteDeVisitasCentral" action="about:blank">
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td>
						<script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtab" width="770">Está en : <A href="../_Manager/InicioHome.aspx">Sucursal</A>
						: Reporte de Tarjetas en Sucursales
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td class="tdgeneralcontent">
						<div id="txtitulo"></div>
						<h1>Reporte de Tarjetas</h1>
						<p>Elija primero la sucursal y los filtros del empleado asi como el tipo de tarjeta 
							presionando el boton Buscar.</p>
						<table style="WIDTH: 100%">
							<tr>
								<td colSpan="4">
									<h2><span class="txsubtitulo">Criterios de la Consulta</span></h2>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold"><input id="rdPorZona" onfocus="return cmdBusquedaSucursal_onfocus(this.value)" value="1"
										CHECKED type="radio" name="cmdBusquedaSucursal">Por Zona
								</td>
								<td></td>
								<td class="tdtexttablebold"><input id="rdPorEstado" onfocus="return cmdBusquedaSucursal_onfocus(this.value)" value="2"
										type="radio" name="cmdBusquedaSucursal">Por Estado
								</td>
								<td></td>
							</tr>
							<tr>
								<td style="WIDTH: 150px" class="tdtexttablebold">Dirección</td>
								<td style="WIDTH: 240px" class="tdpadleft5"><select style="WIDTH: 150px" id="cboDireccionOperativa" class="campotabla" onchange="return cboDireccionOperativa_onchange()"
										name="cboDireccionOperativa">
										<option selected value="0">-- Elija una dirección --</option>
										<option value="-1">-- Todas --</option>
									</select>
								</td>
								<td style="WIDTH: 150px" class="tdtexttablebold">Estado</td>
								<td style="WIDTH: 240px" class="tdtittablas"><select style="WIDTH: 150px" id="cboEstado" class="campotabla" onchange="return cboEstado_onchange()"
										name="cboEstado">
										<option selected value="0">--- Elija un estado ---</option>
										<%--<option value="-1">Todos los estados</option>--%>
										<option>--------------------</option>
									</select></td>
							</tr>
							<tr>
								<td style="WIDTH: 150px" class="tdtexttablebold">Zona</td>
								<td style="WIDTH: 240px" class="tdpadleft5"><select style="WIDTH: 150px" id="cboZonaOperativa" class="campotabla" onchange="return cboZonaOperativa_onchange()"
										name="cboZonaOperativa">
										<option selected value="0">-- Elija una zona --</option>
										<option value="-1">-- Todas --</option>
									</select>
								</td>
								<td style="WIDTH: 150px" class="tdtexttablebold">Ciudad</td>
								<td style="WIDTH: 240px" class="tdtittablas"><select style="WIDTH: 150px" id="cboCiudad" class="campotabla" onchange="return cboCiudad_onchange()"
										name="cboCiudad">
										<option selected value="0">-- Elija una ciudad --</option>
										<option value="-1">Todas las ciudades</option>
										<option>--------------------</option>
									</select>
								</td>
							</tr>
							<tr>
								<td style="WIDTH: 150px" class="tdtexttablebold">Sucursal</td>
								<td style="WIDTH: 240px" class="tdpadleft5"><select style="WIDTH: 150px" id="cboSucursales" class="campotabla" onchange="return cboSucursales_onchange()"
										name="cboSucursales">
										<option selected value="0">-- Elija una sucursal --</option>
										<option value="-1">Todas las sucursales</option>
										<%= LlenarControlSucursales()%>
									</select>
								</td>
								<td style="WIDTH: 150px" class="tdtexttablebold">Sucursal</td>
								<td style="WIDTH: 240px" class="tdtittablas"><select style="WIDTH: 150px" id="cboSucursalEstado" class="campotabla" onchange="return cboSucursalEstado_onchange()"
										name="cboSucursalEstado">
										<option selected value="0">-- Elija una sucursal --</option>
										<option value="-1">Todas las sucursales</option>
										<option>--------------------</option>
										<%= strLlenarSucursalComboBox() %>
									</select>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
	
								<td style="WIDTH: 150px" class="tdtexttablebold">Fecha inicio</td>
								<td class="tdconttablas"><input id=dtmFechaIni 
            class=field onkeypress=" return dtmFecha_onKeyPress(event);" 
            value="<%= strFirstDayOfMonth()%>" maxLength=10 size=10 
            name=dtmFechaIni> <A href="javascript:cal1.popup()"><IMG border="0" alt="Clic para seleccionar la fecha." align="absMiddle" src="images/imgCalendarIcon.gif"
											width="16" height="15"> </A>
									<br>
								</td>
							</tr>
							<tr>
								<td style="WIDTH: 150px" class="tdtexttablebold">Fecha fin</td>
								<td class="tdconttablas"><input id=dtmFechaFin 
            class=field onkeypress=" return dtmFecha_onKeyPress(event);" 
            value="<%= strFechaActual()%>" maxLength=10 size=10 name=dtmFechaFin 
            > <A href="javascript:cal2.popup()"><IMG border="0" alt="Clic para seleccionar la fecha." align="absMiddle" src="images/imgCalendarIcon.gif"
											width="16" height="15"> </A>
									<br>
								</td>
							</tr>
							<!---->
							<tr>
								<td style="WIDTH: 150px" class="tdtexttablebold">Empleados:</td>
								<td class="tdconttablas"><input 
            onblur="return txtEmpleadoNombreId_onblur()" 
            onkeydown=txtEmpleadoNombreId_onKeyDown() id=txtEmpleadoNombreId 
            class=campotabla value='<%=Request.Form("txtEmpleadoNombreId")%>' 
            maxLength=16 size=16 name=txtEmpleadoNombreId 
            autocomplete="off"> &nbsp;<A id="objLupaEmpleado" onclick="return objLupaEmpleado_onclick()" href="javascript:;"><IMG border="0" align="absMiddle" src="../static/images/icono_lupa.gif" width="17" height="17"></A>
								</td>
								<td style="WIDTH: 150px" class="tdtexttablebold">Tipo:</td>
								<td style="WIDTH: 240px" class="tdpadleft5"><select style="WIDTH: 150px" id="TipoTarjeta" class="campotabla" onchange="return TipoEmpleado_onchange()"
										name="TipoTarjeta">
										<option selected value="0">-- Elija --</option>
										<%--<option value="-1">Todos</option>--%>
										<option value="1">Verde</option>
										<option value="2">Amarilla</option>
										<option value="3">Roja</option>
										<option value="4">Todas</option>
										<%--<option value="-1">&raquo; Todas las direcciones &laquo;</option>--%>
									</select>
								</td>
							</tr>
							<tr>
								<td></td>
								<td><input id=txtEmpleadoNombre 
            class=campotablaresultadoenvolventeazul tabIndex=-1 border=0 
            value='<%=Request.Form("txtEmpleadoNombre")%>' readOnly maxLength=60 
            size=40 name=txtEmpleadoNombre></td>
							</tr>
							<tr>
								<td></td>
								<td><input id="cmdConsultar" class="button" onclick="return cmdConsultar_onclick()" value="Buscar"
										type="button" name="cmdConsultar"></td>
							</tr>
						</table>
						<br>
						<span class="txsubtitulo"><IMG align="absMiddle" src="../static/images/bullet_subtitulos.gif" width="17" height="11">Reporte 
							de Tarjetas</span>
						<div id="divRecordBrowser"></div>
						<br>
						<div id="tblResultados" class="tdconttablasrojo"></div>
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td style="WIDTH: 65%" class="tdpadleft5" align="left">
									<div id="divBotones"></div>
								</td>
								<td style="WIDTH: 35%" class="tdpadleft5" align="right"></td>
							</tr>
						</table>
						<P><input 
      value='<%=Request.Form("hdnEmpleadoNombreId")%>' type=hidden 
      name=hdnEmpleadoNombreId> <input 
      value='<%=Request.Form("hdnEmpleadoId")%>' type=hidden name=hdnEmpleadoId 
      > <input id=hdnSucursales 
      value='<%= Request.Form("hdnSucursales")%>' type=hidden name=hdnSucursales 
      > <input id=hdnSucursalEstado 
      value='<%= Request.Form("hdnSucursalEstado") %>' type=hidden 
      name=hdnSucursalEstado> <input id=hdnTipoEmpleado 
      value='<%=Request.Form("hdnTipoEmpleado")%>' type=hidden 
      name=hdnTipoEmpleado> &nbsp;</P>
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td>
						<script language="JavaScript">crearTablaFooterCentral()</script>
					</td>
				</tr>
			</table>
			<script language="JavaScript">
	<!--
    new menu(MENU_ITEMS, MENU_POS);
    var cal1 = new calendar(null, document.forms[0].elements["dtmFechaIni"]);
    var cal2 = new calendar(null, document.forms[0].elements["dtmFechaFin"]);
    //-->
			</script>
		</form>
		<div style="DISPLAY: none">
			<div id="divConsultaVisita">
				<%= strTablaConsultaVisita()%>
				&gt;
			</div>
		</div>
		<script language="JavaScript">

        var strFiltroSucursalId = "<%= strFiltroSucursalId()%>";

        if (strFiltroSucursalId == 1) {

            fnInhabilitarPorEstado();
        }
        else if (strFiltroSucursalId == 2) {

            fnInhabilitarPorZona()
        }
        else {

            fnInhabilitarPorEstado();
        
        }

        if (parent.document.getElementById('tblResultados').innerHTML == '') {

            parent.document.getElementById('divBotones').innerHTML = '';
        }
        else {
            var botones = '<input id="cmdImprimir" name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()" style="margin-top:20px;">';
            botones = botones + '<input name="cmdExportar" type="button" class="boton" value="Exportar" onClick="return cmdExportar_onclick()" style="margin-top:20px;">';
            parent.document.getElementById('divBotones').innerHTML = botones

        }
		</script>
		<iframe height="0" src="" width="0" name="ifrOculto"></iframe><iframe height="0" marginHeight="0" src="ifrImpresionDocumentos.aspx" width="0" name="ifrPageToPrint"
			marginWidth="0"></iframe>
	</body>
</HTML>
