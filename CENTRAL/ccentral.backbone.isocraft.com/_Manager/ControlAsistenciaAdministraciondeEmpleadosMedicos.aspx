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

        function mostrarPaginaMovimientos_onclick(intEmpleadoId, NombreEmpleado) {
            window.location.href = "ControlAsistenciaMovimientosEmpleadosMedicos.aspx?strCmd2=mostrarPaginaMovimientos" +
                                   "&intEmpleadoId=" + intEmpleadoId +
                                   "&NombreEmpleado=" + NombreEmpleado;
        }

        function mostrarPaginaAdministracionEmpleados_onclick(intEmpleadoId) {
            window.location.href = "ControlAsistenciaAdministracionEmpleadosModificaciones.aspx?strCmd=Editar" +
                                   "&intEmpleadoId=" + intEmpleadoId +
                                   "&blnUsuarioLocal=0";
        }

        function mostrarPaginaAsignacionHorario_onclick(intEmpleadoId) {
            window.location.href = "ControlAsistenciaAdministracionEmpleadosMedicosTurnos.aspx?strCmd2=detalle" +
                                   "&intEmpleadoId=" + intEmpleadoId;
        }

        function btnImprimir_onclick() {
            var cadenaImprimir;
            var tblAdminEmpleados = document.getElementById('tblAdminEmpleados');
            var ventanaNueva = window.open('', '', 'height=800, width=1000');

            if (tblAdminEmpleados != null) {
                
                cadenaImprimir = "<H2>Catálogo de Empleados Médicos</H2>";
                cadenaImprimir = cadenaImprimir + "<table border='1px'>";
                cadenaImprimir = cadenaImprimir + "<tr bgcolor='#87AFC6'>";
                cadenaImprimir = cadenaImprimir + "<th>No. Empleado</th>";
                cadenaImprimir = cadenaImprimir + "<th>Nombre</th>";
                cadenaImprimir = cadenaImprimir + "<th>Sucursal</th>";
                cadenaImprimir = cadenaImprimir + "</tr>";

                for (var i = 1, renglon; renglon = tblAdminEmpleados.rows[i]; i++) {
                    cadenaImprimir = cadenaImprimir + "<tr>";

                    for (var j = 0, columna; columna = renglon.cells[j]; j++) {

                        if (j <= 2) {
                            cadenaImprimir = cadenaImprimir + "<td>" + columna.innerHTML + "</td>";
                        }
                    }
                    cadenaImprimir = cadenaImprimir + "</tr>";
                }

                cadenaImprimir = cadenaImprimir + "</table>";

                ventanaNueva.document.write(cadenaImprimir);

                ventanaNueva.document.close();
                ventanaNueva.focus();
                ventanaNueva.print();
                ventanaNueva.close();
            }
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
                                <input id="btnImprimir" type="button" class="boton" value="Imprimir" onclick="btnImprimir_onclick()">
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
