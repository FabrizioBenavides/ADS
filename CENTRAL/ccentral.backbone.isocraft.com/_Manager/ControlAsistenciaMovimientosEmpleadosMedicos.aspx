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

            cargarDatosFiltro();
        }

        function cargarDatosFiltro() {
            var strCmd2;

            strCmd2 = "<%= strCmd2 %>";
            
            if (strCmd2 == "mostrarPaginaMovimientos") {
                document.getElementById("txtNombreEmpleado").value = "<%=NombreEmpleado%>";
                document.getElementById("dtmFechaInicio").value =  "<%=dtmFechaActualPrimerDiaMes%>";
                document.getElementById("dtmFechaFin").value = "<%=dtmFechaHoy%>";
            }

        }

        function btnRegresar_onclick() {
            window.location.href = "ControlAsistenciaAdministraciondeEmpleadosMedicos.aspx";

        }

        function btnBuscar_onclick() {

            // validar campos vacios
            var intEmpleadoId = "<%=intEmpleadoId%>";
            var dtmFechaInicio = document.getElementById("dtmFechaInicio").value;
            var dtmFechaFin = document.getElementById("dtmFechaFin").value;

            document.forms[0].action = "ControlAsistenciaMovimientosEmpleadosMedicos.aspx?strCmd2=Buscar" +
                                       "&intEmpleadoId=" + intEmpleadoId +
                                       "&dtmFechaInicio=" + dtmFechaInicio +
                                       "&dtmFechaFin=" + dtmFechaFin;

            document.forms(0).submit();
        }

        function validarCamposVacios() {

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
                            <td>
                                <input id="txtNombreEmpleado" type="text" class="field" size="60" maxlength="12" onkeypress="return txtNumeroEmpleado_onKeyPress(event);" readonly="readonly">
                            </td>
                        </tr>
                        <tr>
                            <td width="25%" class="tdtexttablebold">Fecha Inicial:</td>
                            <td>
                                <input id="dtmFechaInicio" name="dtmFechaInicio" class="campotabla" size="15" maxlength="10">
                                <a href="javascript:dtmFechaInicio.popup();">
                                    <img onclick="" height="13" alt="Clic para seleccionar la fecha."
                                        src="../static/images/icono_calendario.gif" width="20" border="0">
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td width="25%" class="tdtexttablebold">Fecha Final:</td>
                            <td>
                                <input id="dtmFechaFin" name="dtmFechaFin" class="campotabla" size="15" maxlength="10">
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
                                <input id="btnRegresar" type="button" class="boton" value="Regresar" onclick="return btnRegresar_onclick();">
                                <input id="btnImprimir" type="button" class="boton" value="Imprimir" onclick="">
                                <input id="btnBuscar" type="button" class="boton" value="Buscar" onclick="return btnBuscar_onclick();">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%= strConsultarMovimientosEmpleadosMedicos()%>
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
