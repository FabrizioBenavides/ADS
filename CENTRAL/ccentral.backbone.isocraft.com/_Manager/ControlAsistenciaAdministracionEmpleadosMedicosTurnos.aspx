<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsistenciaAdministracionEmpleadosMedicosTurnos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistenciaAdministracionEmpleadosMedicosTurnos" %>

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

            validarDiaDescanso();
        }

        function validarDiaDescanso() {
            var tieneDiaDescanso = '<%=strTieneDiaDescanso%>';
            var intEmpleadoId = '<%=intEmpleadoId%>';

            if (tieneDiaDescanso == "False") {
                window.alert("Debe seleccionar un día de descanso para continuar.");

                window.location.href = "ControlAsistenciaAdministracionEmpleadosModificaciones.aspx?strCmd=Editar" +
                                       "&intEmpleadoId=" + intEmpleadoId +
                                       "&blnUsuarioLocal=0";
            }
        }

        function cboEmpleados_onchange() {
            var intEmpleadoId = document.forms[0].elements["cboEmpleados"].value;
            document.location.href = "ControlAsistenciaAdministracionEmpleadosMedicosTurnos.aspx?intEmpleadoId=" + intEmpleadoId;
        }

        function btnRegresar_onclick() {
            document.location.href = "ControlAsistenciaAdministraciondeEmpleadosMedicos.aspx";
        }

        function btnAplicar_onclick() {
            var intEmpleadoId;
            var domingo;
            var lunes;
            var martes;
            var miercoles;
            var jueves;
            var viernes;
            var sabado;

            if (validarAplicarHorario()) {

                domingo = obtenerTurnoSeleccionadoPorDia('dia1');
                lunes = obtenerTurnoSeleccionadoPorDia('dia2');
                martes = obtenerTurnoSeleccionadoPorDia('dia3');
                miercoles = obtenerTurnoSeleccionadoPorDia('dia4');
                jueves = obtenerTurnoSeleccionadoPorDia('dia5');
                viernes = obtenerTurnoSeleccionadoPorDia('dia6');
                sabado = obtenerTurnoSeleccionadoPorDia('dia7');

                intEmpleadoId = document.forms[0].elements["cboEmpleados"].value;

                document.forms[0].action = "ControlAsistenciaAdministracionEmpleadosMedicosTurnos.aspx?strCmd2=Aplicar" +
                                           "&intEmpleadoId=" + intEmpleadoId +
                                           "&intDomingo=" + domingo +
                                           "&intLunes=" + lunes +
                                           "&intMartes=" + martes +
                                           "&intMiercoles=" + miercoles +
                                           "&intJueves=" + jueves +
                                           "&intViernes=" + viernes +
                                           "&intSabado=" + sabado;

                document.forms(0).submit();
            }
            else {
                window.alert("Favor de asignar todos los turnos por día.");
            }
        }

        function obtenerTurnoSeleccionadoPorDia(grupoNombreId) {
            var botones = document.getElementsByName(grupoNombreId);
            var botonSeleccionado;
            var valorDiaDescanso = 0;

            for (i = 0; i < botones.length; i++) {
                if (botones[i].checked) {
                    botonSeleccionado = botones[i].value;
                    break;
                }
            }
            
            if (botonSeleccionado == undefined) {
                botonSeleccionado = valorDiaDescanso;
            }

            return botonSeleccionado;
        }

        function validarAplicarHorario() {
            var tieneEmpleadoHorarioAsignado;
            var diaSemanaDescanso = '<%=intObtenerDiaSemanaDescanso()%>';
            var cantidadDiasDescanso = 1;
            var esValido = true;

            if (diaSemanaDescanso == 8) {
                cantidadDiasDescanso = 2;
            }
            
           tieneEmpleadoHorarioAsignado = '<%=strTieneHorarioEmpleadoAsignado()%>';

            if (tieneEmpleadoHorarioAsignado == "False") {
                esValido = validarHorarioNuevo(cantidadDiasDescanso);
            }
            
            return esValido;
        }

        // Valida si esta haciendo un nuevo horario o está modificando uno existente.
        function validarHorarioNuevo(cantidadDiasDescanso) {
            var botonesDiaSemana;
            var cantidadBotonesSeleccionados = 0;
            var cantidadDiasSemana = 7;
            var esValido = false;

            for (var i = 1; i <= cantidadDiasSemana; i++) {

                botonesDiaSemana = document.getElementsByName("dia" + i);

                for (var j = 0; j < botonesDiaSemana.length; j++) {

                    if (botonesDiaSemana[j].checked == true && botonesDiaSemana[j].disabled == false) {
                        cantidadBotonesSeleccionados = cantidadBotonesSeleccionados + 1;
                        break;
                    }
                }
            }

            if ((cantidadDiasDescanso == 1 && cantidadBotonesSeleccionados == 6) ||
                (cantidadDiasDescanso == 2 && cantidadBotonesSeleccionados == 5)) {
                esValido = true;
            }

            return esValido;
        }

        function btnImprimir_onclick() {
            printContent2();
            return (true);
        }

        new menu(MENU_ITEMS, MENU_POS);
    </script>
</head>
<body onload="return window_onload()">
    <form method="post" action="about:blank" name="frmControlAsistenciaAdministracionEmpleadosMedicosTurnos">
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <script language="JavaScript">crearTablaHeader()</script>
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <div id="ToPrintTxtMigaja">
                    <td width="10">&nbsp;</td>
                    <td width="770" class="tdtab">Est&aacute; en : Sucursal : Control de Asistencia : Administración de Empleados Médicos</td>
                </div>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <h1>Asignación de Horario Médico</h1>
                    <div id='ToPrintHtmContenido'> 
                        <table class="tdenvolventetablas" height="38" cellspacing="0" cellpadding="0" width="90%">
                            <tr>
                                <td class="tdtittablas3" valign="top" align="left" colspan="2">Empleado<br>
                                    <select id="cboEmpleados" name="cboEmpleados" class='campotabla' onchange='javascript:cboEmpleados_onchange()'>
                                        <%= LLenarComboEmpleados()%>
                                    </select>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                         <%= strGeneraTablaHorarioHTML()%>
                        <br />
                    </div>
                    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                        <tr> 
                          <td class="tdtittablas3"  width="100%"> 
                              <input class="boton" id="btnRegresar" style="width: 64px; height: 20px" 
                                  onclick="return btnRegresar_onclick()" type="button" value="Regresar" name="btnRegresar">&nbsp;  
                              <input class="boton" id="btnImprimir" style="width: 64px; height: 20px"
                                  onclick="return btnImprimir_onclick()" type="button" value="Imprimir" name="btnImprimir"> &nbsp;
                              <input class="boton" id="btnAplicar" style="width: 64px; height: 20px" 
                                  onclick="return btnAplicar_onclick()" type="button" value="Aplicar" name="btnAplicar"> 
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
    <iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</html>
