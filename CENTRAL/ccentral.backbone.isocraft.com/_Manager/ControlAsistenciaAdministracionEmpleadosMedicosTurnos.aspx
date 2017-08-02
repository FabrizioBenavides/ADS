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
            var esValido = false;
            var cantidadDiasSemana = 7;
            var botones;
            var cantidadBotonesAValidar;
            var cantidadBotonesSeleccionados = 0;
            var yaTieneHorarioAsignado;
            var diaSemanaDescanso = '<%=intObtenerDiaSemanaDescanso()%>';
            var sabadoYDomingo = 8;

            yaTieneHorarioAsignado = validarYaTieneHorarioAsignado();
    
            if (yaTieneHorarioAsignado == true) {

                cantidadBotonesAValidar = 5;

                if (diaSemanaDescanso == sabadoYDomingo) {
                    cantidadBotonesAValidar = cantidadBotonesAValidar - 1;
                }
            }
            else {
                cantidadBotonesAValidar = 6;

                if (diaSemanaDescanso == sabadoYDomingo) {
                    cantidadBotonesAValidar = cantidadBotonesAValidar - 1;
                }
            }

            for (var i = 1; i <= cantidadDiasSemana; i++) {

                botones = document.getElementsByName("dia" + i);

                for (var j = 0; j < botones.length; j++) {
                
                    if (botones[j].checked == true && botones[j].disabled == false) {
                        cantidadBotonesSeleccionados = cantidadBotonesSeleccionados + 1;
                        break;
                    }
                }
            }

            if (cantidadBotonesSeleccionados == cantidadBotonesAValidar) {
                esValido = true;
            }

            return esValido;
        }

        // Valida si esta haciendo un nuevo horario o está modificando.
        function validarYaTieneHorarioAsignado() {
            var yaTieneHorarioAsignado = false;
            var cantidadDiasSemana = 7;
            var botones;
            var cantidadBotonesDeshabilitadosPorDia = 0;

            for (var i = 1; i <= cantidadDiasSemana; i++) {

                botones = document.getElementsByName("dia" + i);

                for (var j = 0; j < botones.length; j++) {

                    if (botones[j].disabled) {
                        cantidadDeshabilitados = cantidadBotonesDeshabilitadosPorDia + 1;
                        break;
                    }
                }
            }

            if (cantidadBotonesDeshabilitadosPorDia == 1) {
                yaTieneHorarioAsignado = false;
            }
            else if (cantidadBotonesDeshabilitadosPorDia == 2) {
                yaTieneHorarioAsignado = true;
            }

            return yaTieneHorarioAsignado;
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
                <td width="10">&nbsp;</td>
                <td width="770" class="tdtab">Est&aacute; en : Sucursal : Control de Asistencia : Administración de Empleados Médicos</td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <h1>Asignación de Horario Médico</h1>
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
</body>
</html>
