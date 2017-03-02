<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsistencia.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistencia" %>

<%@ Import Namespace="Benavides.POSAdmin.Commons" %>

<html>
<head>
    <title>Benavides: Control de Asistencia</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="css/menu.css" rel="stylesheet" type="text/css">
    <link href="css/estilo.css" rel="stylesheet" type="text/css">
    <script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="../static/scripts/tools.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/calendario.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/cal_format00.js"></script>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link rel="stylesheet" type="text/css" href="css/menu.css">
    <link rel="stylesheet" type="text/css" href="css/estilo.css">
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
        <%= LlenarControlTipoMovimientos()%>

            //Administrador = 1 Coordinador RH = 2
            var intTipoUsuarioId = "<%= intTipoUsuarioId()%>";
            if (intTipoUsuarioId == "1") {
                document.getElementById('divTitulo').innerHTML = '<h1>Asistencia - Administrador</h1>';
            }
            else {
                document.getElementById('divTitulo').innerHTML = '<h1>Asistencia - Coordinador RH</h1>';
                var trPerfil = document.getElementById('trPerfil');
                trPerfil.style.display = 'none';
            }

            var intDireccionId = "<%= intDireccionId %>";
            var intZonaId = "<%= intZonaId %>";

            if (intDireccionId == "-1") {
                document.forms[0].elements["cboDireccionOperativa"].options[1].selected = true;
                //document.forms[0].elements["cboZonaOperativa"].options[1].selected = true;
                //disabledZona();
            }
            if (intZonaId == "-1") {
                document.forms[0].elements["cboZonaOperativa"].options[1].selected = true;
            }

            var movimiento = "<%= intMovimientoId()%>";
            document.getElementById("cboTipoMovimientos").value = movimiento;

            //Radio button Tipo de Nomina
            var intTipoNomina = "<%= intTipoNomina()%>";
            if (intTipoNomina == "1") {
                document.forms[0].elements['rdPorQuincena'].checked = true;
            }
            if (intTipoNomina == "2") {
                document.forms[0].elements['rdPorSemana'].checked = true;
            }
            else {
            }

            //Radio button Tipo de Consulta
            var intTipoConsulta = "<%= intTipoConsulta()%>";
        if (intTipoConsulta == "1") {
            document.forms[0].elements['rdResumen'].checked = true;
        }
        if (intTipoConsulta == "2") {
            document.forms[0].elements['rdDetalle'].checked = true;
        }
        else {
        }

    }

    function strGetCustomDateTime() {
        document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
        return (true);
    }


    function frmControlAsistencia_onsubmit() {
        return (true);
    }

    function cmdRegresar_onclick() {
        //Redirecciona a usuario al "home" de Control de Asistencia.
        window.location = "AsistenciaNomina.aspx";
    }

    function disabledZona() {
        document.getElementById("cboZonaOperativa").disabled = true;
    }

    function cboDireccionOperativa_onchange() {

        if (document.getElementById("cboDireccionOperativa").selectedIndex != 0) {

            document.getElementById("cboZonaOperativa").value = "0";
            document.getElementById("cboSucursales").value = "0";

            if (document.getElementById("cboDireccionOperativa").selectedIndex == 1) {

                //document.getElementById("cboZonaOperativa").value = "-1";
                //document.getElementById("cboZonaOperativa").disabled = true;
            }
            else {
                document.getElementById("cboZonaOperativa").value = "0";
            }

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultarSucursal'
            document.forms[0].target = '_self';
            document.forms[0].submit();
            return (true);
        }

        //Si el usuario selecciona la opcion "Elija una Direccion" se resetean las opciones de las Zonas.
        document.getElementById("cboZonaOperativa").length = 0;
        document.forms[0].elements["cboZonaOperativa"].options[0] = new Option(">> Elija una zona <<", "0");

        //Si el usuario selecciona la opcion "Elija una Direccion" se resetean las opciones de las Sucursales.
        document.getElementById("cboSucursales").length = 0;
        document.forms[0].elements["cboSucursales"].options[0] = new Option(">> Elija una sucursal <<", "0");

        return (false);
    }

    function cboZonaOperativa_onchange() {

        if ((document.getElementById("cboDireccionOperativa").selectedIndex > 0) && (document.getElementById("cboZonaOperativa").selectedIndex != 0)) {

            document.getElementById("cboSucursales").value = "0";

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultarSucursales'
            document.forms[0].target = '_self';
            document.forms[0].submit();
        }

        //Si el usuario selecciona la opcion "Elija una Zona" se resetean las opciones de las Sucursales.
        document.getElementById("cboSucursales").length = 0;
        document.forms[0].elements["cboSucursales"].options[0] = new Option(">> Elija una sucursal <<", "0");

        return (false)
    }

    function cboSucursales_onchange() {
        document.getElementById('tblResultados').innerHTML = '';
        return (true);
    }

    function cboTipoMovimientos_onchange() {
        document.getElementById('tblResultados').innerHTML = '';
        return (true);
    }

    function cmdConsultar_onclick() {

        //Variables.
        var valida;

        valida = fnValidaCampos();
        if (valida) {

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultar';
            document.forms[0].target = "ifrOculto";
            //document.forms[0].target = '_self';
            document.forms[0].submit();
        }

        return (valida);
    }

    function fnValidaCampos() {

        var _empleadoId = trim(document.getElementById('txtEmpleadoId').value);
        var _empleadoDes = trim(document.getElementById('txtEmpleadoNombre').value);

        if (document.getElementById('cboSucursales').value == "0") {
            alert('Seleccione una sucursal');
            document.getElementById('cboSucursales').focus();
            return (false);
        }
        else if (document.getElementById('cboTipoMovimientos').value == "0") {
            alert('Seleccione un tipo de movimiento');
            document.getElementById('cboTipoMovimientos').focus();
            return (false);
        }
        else if ((_empleadoId == '' && _empleadoDes != '') || (_empleadoId != '' && _empleadoDes == '')) {
            alert('Capture un empleado valido');
            document.getElementById('txtEmpleadoId').focus();
            return (false);
        }
        else if (trim(document.getElementById('dtmFechaIni').value) == '' || trim(document.getElementById('dtmFechaIni').value) == '') {

            alert('Capture la fecha por favor');
            return (false);
        }
        else if (document.forms[0].elements["cmdTipoNomina"].checked == false) {
            alert('Seleccione el Tipo de Nomina');
            document.getElementById('rdPorSemana').focus();
            return (false);
        }
        else if (document.forms[0].elements["cmdTipoConsulta"].checked == false) {
            alert('Seleccione el Tipo de Consulta');
            document.getElementById('rdResumen').focus();
            return (false);
        }
        else if (ValidaFechas("dtmFechaIni", "dtmFechaFin") == false) {
            return (false);
        }
        else {
            return (true);
        }
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

                //Fecha hoy
                var dtmActual = document.getElementById("dtmFechaActual").value;
                var diaActual = dtmActual.substring(0, 2);
                var mesActual = dtmActual.substring(3, 5);
                var anioActual = dtmActual.substring(6, 10);

                //Validacion
                var date1 = (anioIni + mesIni + diaIni);
                var date2 = (anioFin + mesFin + diaFin);
                var date3 = (anioActual + mesActual + diaActual);

                //Validaciones de fecha por Tipo de Nomina (Semana y Quncena).
                var dateIni = new Date(anioIni + "/" + mesIni + "/" + diaIni);
                var dateIniDay = dateIni.getDay();

                var dateFin = new Date(anioFin + "/" + mesFin + "/" + diaFin);
                var dateFinDay = dateFin.getDay();

                //-Fecha para validar ultimo dia de quincena
                var mes = parseInt(mesFin,10) + 1;
                var endOfLastMonth = new Date(anioFin + "/" + mes + "/" + 1);
                endOfLastMonth.setDate(0);

                var lastDayLastMonth = endOfLastMonth.getDate()

                //-Tipo de Nomina 
                var tipoNomina = 1;
                if (document.forms[0].elements["rdPorSemana"].checked == true) {
                    tipoNomina = 2;
                }


                //-Validaciones
                if (date1 > date3) {
                    alert('La fecha de inicio no debe ser mayor que la fecha de hoy');
                    return (false);
                }
                else if (date2 > date3) {
                    alert('La fecha final no debe ser mayor que la fecha de hoy');
                    return (false);
                }
                else if (date1 > date2) {
                    alert('La fecha de inicio no debe ser mayor que la fecha final');
                    return (false);
                }
                else if ((tipoNomina == 1) && (parseInt(diaIni,10) != 1) && (parseInt(diaIni,10) != 16)) {

                    //-Valida fecha Inicial-Quincenal
                    alert('La fecha de inicio para periodo quincenal debe de ser inicio de quincena');
                    return (false);
                }
                else if ((tipoNomina == 1) && parseInt(diaFin,10) != 15 && parseInt(diaFin,10) != lastDayLastMonth) {

                    //-Valida fecha Final-Quincenal
                    alert('La fecha final para periodo quincenal debe de ser fin de quincena');
                    return (false);
                }
                else if ((tipoNomina == 2) && (dateIniDay != 1)) {

                    //-Valida fecha Inicial (Semanal)
                    alert('La fecha de inicio para periodo semanal debe de ser Lunes');
                    return (false);
                }
                else if ((tipoNomina == 2) && (dateFinDay != 0)) {

                    //-Valida fecha Final (Semanal)
                    alert('La fecha final para periodo semanal debe de ser Domingo');
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

        var confirmar = confirm('Desea exportar la informacion a Excel?');
        if (confirmar == true) {
            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdExportar';
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();

        return (true);
    }
}

function txtEmpleadoId_onKeyPress(e) {

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

function txtEmpleadoId_onblur() {
    //if (trim(document.getElementById('txtProveedorNombreId').value) == '') {
    //    document.getElementById('txtProveedorRazonSocial').value = '';
    //}

    return true;
}

function cmdBuscarEmpleado_onclick() {

    if (document.getElementById('txtEmpleadoId').value != '') {

        var url = 'PopEmpleado.aspx?strEmpleado=txtEmpleadoId&amp;strEmpleadoNombreId=txtEmpleadoNombre';

        var width = 400;
        var height = 540;
        url = url + '&strEmpleadoBuscar=' + document.forms[0].elements['txtEmpleadoId'].value;
        Pop(url, width, height);
    }
    else {
        //Si el codigo de Planograma esta vacio
        alert('Por favor capture el código o el nombre del empleado.')
    }
}

function Pop(url, width, height) {
    var Win = window.open(url, 'Pop', 'width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no');
    return false;
}

function cmdTipoNomina_onfocus() {
    document.getElementById('tblResultados').innerHTML = '';
    return (true);
}

function cmdTipoConsulta_onfocus() {
    document.getElementById('tblResultados').innerHTML = '';

    if (document.getElementById('rdResumen').checked == true) {
        parent.document.getElementById('rdResumen').checked = true
    }

    if (document.getElementById('rdDetalle').checked == true) {
        parent.document.getElementById('rdDetalle').checked = true
    }
    return (false);
}

function cmdVerDetalle_onclick(intEmpleadoId, intMovimientoId, intControlAsistenciaObservacionesId) {

    var dtmFechaInicio = parent.document.getElementById('dtmFechaIni').value;
    var dtmFechaFin = parent.document.getElementById('dtmFechaFin').value;

    //Parametros
    var strParametros = '?&strEmpleadoId=' + intEmpleadoId +
                        '&strMovimientoId=' + intMovimientoId +
                        '&strControlAsistenciaObservacionesId=' + intControlAsistenciaObservacionesId;

    strParametros = strParametros + '&dtmFechaInicio=' + dtmFechaInicio + '&dtmFechaFin=' + dtmFechaFin;

    window.location.href = 'ControlAsistenciaDetalle.aspx' + strParametros;
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

function cmdCancelar_onclick() {
    window.location.href = "InicioHome.aspx";
}

//CheckBox Todos
function fnMarcarTodos() {

    //var cont = 1;
    var hdnConfirmadoValor;
    var cont = 2;
    for (var x = 1; x < cont; x++) {

        //Se forma el id a buscar.
        idChkBox = "chkCodigo" + x;					//Se forma el identificador de los checkbox's
        trChkBox = document.getElementById(idChkBox);
        hdnConfirmadoValor = "hdnConfirmado" + x;

        //Si existe check box se selecciona o se quita la seleccion de "todos"	
        if (Boolean(trChkBox)) {
            if (("<%= intTipoUsuarioId()%>" == "1" && document.getElementById('chkCodigo').checked == true) ||
               (("<%= intTipoUsuarioId()%>" == "2") && document.getElementById('chkCodigo').checked == true && document.getElementById(hdnConfirmadoValor).value == '0')) {

                        trChkBox.checked = true
                    }
                    else if (("<%= intTipoUsuarioId()%>" == "1" && document.getElementById('chkCodigo').checked == false) ||
                        (("<%= intTipoUsuarioId()%>" == "2") && document.getElementById('chkCodigo').checked == false && document.getElementById(hdnConfirmadoValor).value == '0')) {
                        trChkBox.checked = false
                    }

                cont = cont + 1;
            }
        }
    }

    function fnMarcarUno() {

        //Si se quita la seleccion a una sucursal y el check box todos esta seleccionado tambien se le quita la seleccion.
        if (document.getElementById('chkCodigo').checked == true) {

            document.getElementById('chkCodigo').checked = false;

        }
    }

    function cmdConfirmar_onclick() {

        if (trim(document.getElementById('tblResultados').innerHTML) == '') {
            return (false);
        }
        else if (trim(document.getElementById('hdnTotalDePartidas').value) == '') {
            return (false);
        }
        else {

            var confirmar = confirm('Desea confirmar los registros seleccionados?');
            if (confirmar == true) {

                //document.getElementById('tblResultados').innerHTML = parent.document.getElementById('tblResultados').innerHTML;

                document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConfirmar';
            //document.forms[0].target = "ifrOculto";
                document.forms[0].submit();
        }
    }
}

function doSubmit(c, t, p) {
    if (p == null) {
        p = document.getElementById('txtCurrentPage').value;
    }
    else {
        document.getElementById('txtCurrentPage').value = p;
    }
    document.forms[0].action =
    '<%= strThisPageName%>?strCmd=cmdConsultar&pager=true&p=' + p;
    document.forms[0].target = "ifrOculto";
    document.forms[0].submit();
}

function mostrarCboAsistencia(obj) {
    var idCbo = obj.id;
    var soloNumero = idCbo.replace(/[^\d.]/g, '');
    var cboAsistencia = "cboAsistencia" + soloNumero;
    var lblObservacion = "lblObservacion" + soloNumero;
    var hdnCambioMovimiento = "hdnCambioMovimiento" + soloNumero;

    document.getElementById(cboAsistencia).style.display = 'inline';
    document.getElementById(cboAsistencia).style.width = '85px';
    document.getElementById(cboAsistencia).className = 'campotabla';
    document.getElementById(lblObservacion).style.display = 'inline';
    document.getElementById(lblObservacion).style.color = 'blue';
    document.getElementById(hdnCambioMovimiento).value = "true";
}

//-->
    </script>

    <style type="text/css">
        .auto-style1 {
            width: 4px;
        }
    </style>

</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onload="return window_onload()">
    <form name="frmMain" action="about:blank" method="post">
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <script language="JavaScript">crearTablaHeader()</script>
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="10">&nbsp;</td>
                <td width="770" class="tdtab">Está en : <a href="../_Manager/InicioHome.aspx">Central</a> : Confirmacion Asistencia </td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <div id="divTitulo"></div>
                    <%--<h1>Asistencia - Coordinador RH
                              <!--Asistencia - Administrador--></h1>--%>
                    <p>
                        Elija primero la sucursal y el periodo de asistencia presionando el boton Consultar. 
                              Cuando la consulta muestre resultados seleccione los registros por confirmar en la casilla de la derecha de los registros y confirme la asistencia 
                              del periodo elegido presionando el boton Confirmar que se encuentra al final de la pantalla.
                    </p>
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="4">
                                <h2>Criterios de Consulta</h2>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" style="width: 150px">Dirección</td>
                            <td class="tdpadleft5" style="width: 240px">
                                <select id="cboDireccionOperativa" name="cboDireccionOperativa" class="campotabla" style="width: 150px" onchange="return cboDireccionOperativa_onchange()">
                                    <option selected="selected" value="0">&raquo; Elija una dirección &laquo;</option>
                                    <%--<option value="-1">&raquo; Todas las direcciones &laquo;</option>--%>
                                </select>
                            </td>
                            <td class="tdtexttablebold" style="width: 150px">Tipo de movimiento</td>
                            <td class="tdtittablas" style="width: 240px">
                                <select id="cboTipoMovimientos" class="campotabla" name="cboTipoMovimientos" class="campotabla" style="width: 150px" onchange="return cboTipoMovimientos_onchange()">
                                    <option selected="selected" value="0">&raquo; Seleccione &laquo;</option>
                                    <option value="-1">&raquo; Todos los movimientos &laquo;</option>
                                </select></td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" style="width: 150px">Zona</td>
                            <td class="tdpadleft5" style="width: 240px">
                                <select id="cboZonaOperativa" class="campotabla" onchange="return cboZonaOperativa_onchange()" name="cboZonaOperativa" style="width: 150px">
                                    <option selected value="0">&raquo; Elija una zona &laquo;</option>
                                    <%--<option value="-1">&raquo; Todas las zonas &laquo;</option>--%>
                                </select>
                            </td>
                            <td class="tdtexttablebold" style="width: 150px">Empleado</td>
                            <td class="tdtittablas" style="width: 240px">
                                <input language='javascript' id="txtEmpleadoId" type="text" name="txtEmpleadoId" maxlength="16" size="16" class="campotabla" onblur="txtEmpleadoId_onblur()" onkeypress=" return txtEmpleadoId_onKeyPress(event);" value='<%=Request.Form("txtEmpleadoId")%>' autocomplete='off'>
                                <img style="CURSOR: pointer;" id="IMG1" onclick="javascript:cmdBuscarEmpleado_onclick()" border="0" align="absMiddle" src="../static/images/icono_lupa.gif" width="17" height="17">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" style="width: 150px">Sucursal</td>
                            <td class="tdpadleft5" style="width: 240px">
                                <select id="cboSucursales" class="campotabla" name="cboSucursales" style="width: 150px" onchange="return cboSucursales_onchange()">
                                    <option selected value="0">&raquo; Elija una sucursal &laquo;</option>
                                    <!--<option value="-1">&raquo; Todas las sucursales &laquo;</option>-->
                                    <%= LlenarControlSucursales()%>
                                </select>
                            </td>
                            <td class="tdtittablas" style="width: 390px" colspan="2">
                                <input type="text" class="campotablaresultado" readonly maxlength="46" size="46" id="txtEmpleadoNombre" name="txtEmpleadoNombre" value='<%=Request.Form("txtEmpleadoNombre")%>' style="width: 100%;">
                            </td>
                        </tr>
                        <tr id="trPerfil">
                            <td class="tdtexttablebold" style="width: 150px"></td>
                            <td class="tdpadleft5" style="width: 240px"></td>
                            <td class="tdtexttablebold" style="width: 150px">Perfil</td>
                            <td class="tdtittablas" style="width: 240px">
                                <select id="cboPerfiles" name="cboPerfiles" class="campotabla" style="width: 150px" onchange="">
                                    <option selected value="0">&raquo; Elija un perfil &laquo;</option>
                                    <%= LlenarPerfilesEmpleados()%>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" style="width: 150px">Observaciones</td>
                            <td class="tdpadleft5" style="width: 240px">
                                <select id="cboObservaciones" name="cboObservaciones" class="campotabla" style="width: 150px" >
                                    <option selected="selected" value="-1">&raquo; Elija una Observación &laquo;</option>
                                  <%--  <option value="-1">&raquo; Todas las observaciones &laquo;</option>--%>
                                    <%= LLenarControlObservaciones()%>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class='txsubtitulo' colspan="4">
                                <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">Período de Asistencia
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" style="width: 150px">Fecha inicio</td>
                            <td class="tdconttablas">
                                <input id="dtmFechaIni" name="dtmFechaIni" class="field" size="10" maxlength="10" type="text" value="<%= strFirstDayOfMonth()%>" onkeypress=" return dtmFecha_onKeyPress(event);">
                                <a href="javascript:cal1.popup()">
                                    <img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
                                        alt="Clic para seleccionar la fecha.">
                                </a>
                                <br>
                            </td>
                            <td class="tdtexttablebold" style="width: 150px">Fecha fin</td>
                            <td class="tdconttablas">
                                <input id="dtmFechaFin" name="dtmFechaFin" class="field" size="10" maxlength="10" type="text" value='<%= strFechaActual()%>' onkeypress=" return dtmFecha_onKeyPress(event);">
                                <a href="javascript:cal2.popup()">
                                    <img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
                                        alt="Clic para seleccionar la fecha.">
                                </a>
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" width="100%">
                                <table width="100%">
                                    <tr>
                                        <td width="50%" valign="top">
                                            <table width="100%">
                                                <tr>
                                                    <td class='txsubtitulo'>
                                                        <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">Tipo de Nomina
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdtexttablebold">
                                                        <input type="radio" id="rdPorSemana" name="cmdTipoNomina" value="2" checked="checked" onfocus="return cmdTipoNomina_onfocus()" />Por Semana
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdtexttablebold">
                                                        <input type="radio" id="rdPorQuincena" name="cmdTipoNomina" value="1" onfocus="return cmdTipoNomina_onfocus()" />Por Quincena
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div id="divConsultar" class="tdconttablasrojo"></div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>

                                        </td>
                                        <td width="50%" valign="top">
                                            <table width="100%">
                                                <tr>
                                                    <td class='txsubtitulo'>
                                                        <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">Tipo de consulta</td>
                                                </tr>
                                                <tr>
                                                    <td class="tdtexttablebold">
                                                        <input type="radio" id="rdResumen" name="cmdTipoConsulta" value="1" checked="checked" onfocus="return cmdTipoConsulta_onfocus()" />Resumen
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdtexttablebold">
                                                        <input type="radio" id="rdDetalle" name="cmdTipoConsulta" value="2" onfocus="return cmdTipoConsulta_onfocus()" />Detalle 
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <div id="divConfirmar" class="tdconttablasrojo"></div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <p>
                        <input type="hidden" id="dtmFechaActual" name="dtmFechaActual" value='<%= strFechaActual()%>' />
                        <input type="hidden" id="hdnTotalDePartidas" name="hdnTotalDePartidas">
                        <input type="hidden" id="hdnTipoUsuario" name="hdnTipoUsuario" value='<%= intTipoUsuarioId()%>'>

                        <input class="button" id="cmdConsultar" name="cmdConsultar" value="Consultar" onclick="return cmdConsultar_onclick()" type="button">
                        &nbsp;
                    </p>
                    <div id="tblResultados" class="tdconttablasrojo"></div>
                    <br>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td class="tdpadleft5" align="left" style="width: 65%;">
                                <div id="divBotones"></div>
                            </td>
                            <td class="tdpadleft5" align="right" style="width: 35%;">
                                <div id="divBotnoConfirmar"></div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellspacing="0" cellpadding="0">
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
    <div style="display: none;">
        <div id="divConsultaMovimientos">
            <%= Me.strTablaConsultaAsistencia()%>
        </div>
    </div>
    <script language="JavaScript">

        var strTotalDePartidas = "<%= strTotalDePartidas()%>"
        parent.document.getElementById('hdnTotalDePartidas').value = strTotalDePartidas;

        if (parent.document.getElementById('tblResultados').innerHTML == '') {

            parent.document.getElementById('divBotones').innerHTML = '<input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdCancelar_onclick()" style="margin-top:20px;">';
            parent.document.getElementById('divBotnoConfirmar').innerHTML = '';
        }
        else {
            var botones = '<input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdCancelar_onclick()" style="margin-top:20px;">';
            botones = botones + '<input id="cmdImprimir" name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()" style="margin-top:20px;">';
            botones = botones + '<input name="cmdExportar" type="button" class="boton" value="Exportar" onClick="return cmdExportar_onclick()" style="margin-top:20px;">';
            parent.document.getElementById('divBotones').innerHTML = botones
            parent.document.getElementById('divBotnoConfirmar').innerHTML = '<input name="cmdConfirmar" type="button" class="boton" value="Confirmar" onClick="return cmdConfirmar_onclick()" style="margin-top:20px;">';
        }

    </script>
    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>
