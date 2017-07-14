<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsistenciaReporte.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistenciaReporte" %>

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

        strUsuarioNombre = "<%= strUsuarioNombre() %>";
        strFechaHora = "<%= strHTMLFechaHora %>";

        function window_onload() {
            document.forms[0].action = "<%= strFormAction %>";

            <%= LlenarControlCoordinadoresRH()%>

            mantenerValorTipo();
        }

        function mantenerValorTipo() {
            var strCmd;
            var intTipoUsuarioId;

            intTipoUsuarioId = "<%= intTipoUsuarioId%>";
            strCmd = "<%=strCmd%>";

            if (strCmd == "Buscar" && intTipoUsuarioId > 0) {

                if (intTipoUsuarioId == 2) {
                    document.forms[0].elements["cboTipo"].selectedIndex = 1;
                }
                else {
                    if (intTipoUsuarioId == 3) {
                        document.forms[0].elements["cboTipo"].selectedIndex = 2;
                    }
                }
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

        function cboCoordinadoresRH_onchange() {
            document.getElementById("tblReporte").innerHTML = '';
            return (true);
        }

        function cboTipo_onchange() {
            document.getElementById("cboCoordinadoresRH").length = 0;
            document.forms[0].elements["cboCoordinadoresRH"].options[0] = new Option(">> Elija un coordinador/supervisor <<", "0");
            //document.forms[0].elements["cboCoordinadoresRH"].options[1] = new Option(">> Todos <<", "-1");

            if (document.forms[0].elements["cboTipo"].selectedIndex > 0) {
                document.forms[0].elements["cboCoordinadoresRH"].selectedIndex = 0;

                var intTipoUsuarioId = document.forms[0].elements["cboTipo"].value;

                document.forms[0].action = "ControlAsistenciaReporte.aspx?" +
                                           "strCmd=Buscar" +
                                           "&intTipoUsuarioId=" + intTipoUsuarioId;

                document.forms[0].submit();
            }
        }

        function cmdConsultar_onclick() {
            document.getElementById('tblReporte').innerHTML = '';

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

            //Validaciones
            if (document.getElementById('cboCoordinadoresRH').value == "0") {

                alert('Seleccione un Coordinador');
                document.getElementById('cboCoordinadoresRH').focus();
                return (false);

            }
            else if (trim(document.getElementById('dtmFechaIni').value) == '' || trim(document.getElementById('dtmFechaIni').value) == '') {

                alert('Capture la fecha por favor');
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
                    else if ((anioIni != anioFin) && ((parseInt(mesFin) + 12) - parseInt(mesIni)) > 2) {
                        alert('La diferencia entre Fecha de inicio y Fecha final NO debe ser mayor a 2 meses.');
                        return (false);
                    }
                    else if ((anioIni == anioFin) && ((parseInt(mesFin) - parseInt(mesIni)) > 2)) {
                        alert('La diferencia entre Fecha de inicio y Fecha final NO debe ser mayor a 2 meses.');
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
            var tablaTotal = document.getElementById('tblReporte').innerHTML
            if (trim(tablaTotal) == 'Consulta sin resultados' || trim(tablaTotal) == '') {
                alert('No hay resultados de la consulta')
                return (false);
            }

            var confirmar = confirm('Desea imprimir la informacion?');
            if (confirmar) {

                document.forms[0].action = "<%=strFormAction%>?strCmd=cmdImprimir";
                document.forms[0].target = "ifrOculto";
                document.forms[0].submit();
                document.forms[0].target = '';
        }

        return (false);
    }

    function fnImprimir(strReporteAsistencia) {
        //Llamada desde el servidor para imprimir resultados de las consulta.
        document.ifrPageToPrint.document.all.divBody.innerHTML = strReporteAsistencia;
        document.ifrPageToPrint.focus();
        window.print();
    }

    function dtmFecha_onKeyPress(e) {
        //No se permiten caracteres especiales para la fecha.
        var key = window.event ? e.keyCode : e.which;
        if (key > 46 && key < 58) {
            return true;
        }
        else {
            return false
        }
    }

    function cmdExportar_onclick() {
        //Validacion de resultados
        var tablaTotal = document.getElementById('tblReporte').innerHTML;

        if (trim(tablaTotal) == 'Consulta sin resultados' || trim(tablaTotal) == '') {
            alert('No hay resultados de la consulta')
            return (false);
        }

        var confirmar = confirm('Desea exportar la informacion a Excel?');

        if (confirmar) {
            document.forms[0].action = "<%=strFormAction%>?strCmd=cmdExportar";
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();
            }

            return (false);
     }

        function cmdCancelar_onclick() {
            window.location.href = "ControlAsistencia.aspx";
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
    </script>

    <style type="text/css">
        .auto-style1 {
            width: 4px;
        }
    </style>

</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onload="return window_onload()">
    <form name="frmReporteControlAsistencia" action="about:blank" method="post">
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
                <td width="770" class="tdtab">Est� en : <a href="../_Manager/InicioHome.aspx">Central</a> : Control de Asistencia : Reporte</td>
            </tr>
        </table>

        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <h1>Control de Asistencia - Reporte</h1>
                    <p>Elija primero el Coordinador RH / Supervisor M�dico y el periodo de asistencia presionando el boton Consultar.</p>

                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="50%" valign="top">
                                <table width="100%">
                                    <tr>
                                        <td class='txsubtitulo' colspan="2">
                                            <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">Coordinador RH / Supervisor M�dico
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdtexttablebold" style="width: 150px">Tipo</td>
                                        <td class="tdpadleft5" style="width: 240px">
                                            <select id="cboTipo" name="cboTipo" class="campotabla" style="width: 220px" onchange="return cboTipo_onchange()">
                                                <option selected="selected" value="0">&raquo; Elija un tipo &laquo;</option>
                                                <option value="2">&raquo; Coordinador RH &laquo;</option>
                                                <option value="3">&raquo; Supervisor M�dico &laquo;</option>
                                            </select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdtexttablebold" style="width: 150px">Coordinadores � Supervisores</td>
                                        <td class="tdpadleft5" style="width: 240px">
                                            <select id="cboCoordinadoresRH" name="cboCoordinadoresRH" class="campotabla" style="width: 220px" onchange="return cboCoordinadoresRH_onchange()">
                                                <option selected="selected" value="0">&raquo; Elija un coordinador/supervisor &laquo;</option>
                                                <option value="-1">&raquo; Todos &laquo;</option>
                                            </select>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="tdtexttablebold" style="width: 150px">Estatus</td>
                                        <td class="tdpadleft5" style="width: 240px">
                                            <select id="cboEstatus" name="cboEstatus" class="campotabla" style="width: 220px">
                                                <option selected="selected" value="-1">&raquo; Todos &laquo;</option>
                                                <option value="1">&raquo; Confirmados &laquo;</option>
                                                <option value="0">&raquo; No Confirmados &laquo;</option>
                                            </select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdtexttablebold" style="width: 150px">Tipo de Nomina</td>
                                        <td class="tdpadleft5" style="width: 240px">
                                            <select id="cboTipoNomina" name="cboTipoNomina" class="campotabla" style="width: 220px">
                                                <option selected="selected" value="0">&raquo; Todos &laquo;</option>
                                                <option value="2">&raquo; Por semana &laquo;</option>
                                                <option value="1">&raquo; Por Quincena &laquo;</option>
                                            </select>
                                        </td>
                                    </tr>
                                </table>
                            </td>

                            <td width="50%" valign="top">
                                <table width="100%">
                                    <tr>
                                        <td class='txsubtitulo' colspan="2">
                                            <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">Per�odo de Consulta</td>
                                    </tr>
                                    <tr>
                                        <td class="tdtexttablebold" style="width: 150px">Fecha inicio</td>
                                        <td class="tdconttablas">
                                            <input id="dtmFechaIni" name="dtmFechaIni" class="field" size="10" maxlength="10" type="text" value="<%= strFirstDayOfMonth()%>" onkeypress=" return dtmFecha_onKeyPress(event);">
                                            <a href="javascript:cal1.popup()">
                                                <img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
                                                    alt="Clic para seleccionar la fecha.">
                                            </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdtexttablebold" style="width: 150px">Fecha fin</td>
                                        <td class="tdconttablas">
                                            <input id="dtmFechaFin" name="dtmFechaFin" class="field" size="10" maxlength="10" type="text" value="<%= strFechaActual()%>" onkeypress=" return dtmFecha_onKeyPress(event);">
                                            <a href="javascript:cal2.popup()">
                                                <img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
                                                    alt="Clic para seleccionar la fecha.">
                                            </a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <p>
                        <input type="hidden" id="dtmFechaActual" name="dtmFechaActual" value='<%= strFechaActual()%>' />
                        <input class="button" id="cmdAgregar" name="cmdAgregar" value="Consultar" onclick="return cmdConsultar_onclick()" type="button">&nbsp;		
                    </p>
                    <div id="tblReporte" class="tdconttablasrojo"></div>
                    <br>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td align="right" width="80%">
                                <input language="javascript" class="button" id="cmdRegresar" onclick="return cmdCancelar_onclick()"
                                    type="button" value="Regresar" name="cmdRegresar">
                            </td>
                            <td align="right" width="10%">
                                <input language="javascript" class="button" id="cmdImprimir" onclick="return cmdImprimir_onclick()"
                                    type="button" value="Imprimir" name="cmdImprimir">
                            </td>
                            <td align="right" width="10%">
                                <input language="javascript" class="button" id="cmdExportar" onclick="return cmdExportar_onclick()"
                                    type="button" value="Exportar" name="cmdExportar">
                            </td>
                        </tr>
                    </table>
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
            new menu(MENU_ITEMS, MENU_POS);
            var cal1 = new calendar(null, document.forms[0].elements["dtmFechaIni"]);
            var cal2 = new calendar(null, document.forms[0].elements["dtmFechaFin"]);
        </script>
    </form>
    <div style="display: none;">
        <div id="divConsultaReporte">
            <%= Me.strTablaConsultaReporte()%>
        </div>
    </div>
    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>
