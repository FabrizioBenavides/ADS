<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsistenciaMovimientosEmpleadosMedicos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistenciaMovimientosEmpleadosMedicos" %>


<html>
<head>
    <title>Benavides : Control de Asistencia</title>
    <link href="css/menu.css" rel="stylesheet" type="text/css">
    <link href="css/estilo.css" rel="stylesheet" type="text/css">
    <script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
    <script type="text/JavaScript" src="../static/scripts/calendar1.js"></script>
    <script language="JavaScript" type="text/JavaScript">

        strUsuarioNombre = "<%= strUsuarioNombre %>";
        strFechaHora = "<%= strHTMLFechaHora %>";

        function window_onload() {

        }

        new menu(MENU_ITEMS, MENU_POS);
    </script>

</head>
<body onload="return window_onload()">
    <form id="frmControlAsistenciaMovimientosEmpleadosMedicos" method="post" action="about:blank">
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
                <td width="770" class="tdtab">Est&aacute; en : Sucursal : Control de Asistencia</td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <h1>Consulta de Movimientos Empleados Médicos</h1>
                    <p>Consulta de Movimientos Empleados Médicos</p>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="25%" class="tdtexttablebold">Empleado:</td>
                            <td class="tdpadleft5">
                                <input id="txtNumeroEmpleado" type="text" class="field" size="15" maxlength="12" onkeypress="return txtNumeroEmpleado_onKeyPress(event);">
                            </td>
                        </tr>
                        <tr>
                            <td width="25%" class="tdtexttablebold">Fecha Inicial:</td>
                            <td>
                                <input id="dtmFechaInicio" name="dtmFechaInicio" class="campotabla" size="10" maxlength="10">
                                <a href="javascript:dtmFechaInicio.popup();">
                                    <img onclick="" height="13" alt="Clic para seleccionar la fecha."
                                        src="../static/images/icono_calendario.gif" width="20" border="0">
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%" class="tdtexttablebold">Fecha Final:</td>
                            <td>
                                <input id="dtmFechaFin" name="dtmFechaFin" class="campotabla" size="10" maxlength="10">
                                <a href="javascript:dtmFechaFin.popup();">
                                    <img onclick="" height="13" alt="Clic para seleccionar la fecha." src="../static/images/icono_calendario.gif"
                                        width="20" border="0">
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input id="btnRegresar" type="button" class="boton" value="Regresar" onclick="window.location = ''">
                                <input id="btnImprimir" type="button" class="boton" value="Imprimir" onclick="">
                                <input id="btnBuscar" type="button" class="boton" value="Buscar" onclick="">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%--<%= strConsultarMovimientosEmpleadosMedicos()%>--%>
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
        <script type="text/JavaScript">
            var dtmFechaInicio = new calendar1(document.forms['frmControlAsistenciaMovimientosEmpleadosMedicos'].elements['dtmFechaInicio']);
            var dtmFechaFin = new calendar1(document.forms['frmControlAsistenciaMovimientosEmpleadosMedicos'].elements['dtmFechaFin']);
        </script>
    </form>
</body>
</html>
