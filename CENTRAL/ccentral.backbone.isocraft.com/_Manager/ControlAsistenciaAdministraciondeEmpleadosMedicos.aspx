<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsistenciaAdministraciondeEmpleadosMedicos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistenciaAdministraciondeEmpleadosMedicos" %>

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
    
    <script language="JavaScript" type="text/JavaScript">

        strUsuarioNombre = "<%= strUsuarioNombre %>";
        strFechaHora = "<%= strHTMLFechaHora %>";

        function window_onload() {
            <%= strJavascriptWindowOnLoadCommands %>
        }

        function mostrarPaginaMovimientos_onclick(intEmpleadoId, Nombre) {
            window.location.href = "ControlAsistenciaMovimientosEmpleadosMedicos.aspx?" +
                                   "intEmpleadoId=" + intEmpleadoId +
                                   "&Nombre=" + Nombre;
        }

        function mostrarPaginaAsignacionDias_onclick(intEmpleadoId) {

        }

        function mostrarPaginaAsignacionHorario_onclick(intEmpleadoId) {

        }


        new menu(MENU_ITEMS, MENU_POS);
    </script>
</head>
<body onload="return window_onload()">
    <form method="post" action="about:blank" name="frmControlAsistenciasAdministraciondeEmpleadosMedicos">
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
                <td width="770" class="tdtab">Est&aacute; en : Sucursal : Control de Asistencia : Administración de Empleados Médicos</td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <h1>Administración de Empleados Médicos</h1>
                    <p>Administración de empleados médicos asignados a sucursales.</p>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <%= strConsultarEmpleadosMedicos()%>
                            </td>
                        </tr>
                        <tr>
                            <td><br /></td>
                        </tr>
                        <tr>
                            <td>
                                <input id="btnImprimir" type="button" class="boton" value="Imprimir" onclick="">
                                <input id="btnRegresar" type="button" class="boton" value="Regresar" onclick="window.location = ''">
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
    </form>
</body>
</html>
