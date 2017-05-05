<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsistenciaAdministracionDeUsuariosAgregar.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistenciaAdministracionDeUsuariosAgregar" %>

<html>
<head>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <meta http-equiv="Content-Type" content="text/html; charset=Windows-1252">
    <title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
    <link href="css/menu.css" rel="stylesheet" type="text/css">
    <link href="css/estilo.css" rel="stylesheet" type="text/css">
    <script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
    <script language="JavaScript" src="js/calendario.js"></script>
    <script language="JavaScript" src="js/cal_format00.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
    <script language="JavaScript" type="text/JavaScript" id="clientEventHandlersJS">

        strUsuarioNombre = "<%= strUsuarioNombre %>";
        strFechaHora = "<%= strHTMLFechaHora %>";

        function window_onload() {
            <%= strJavascriptWindowOnLoadCommands %>

            document.forms[0].elements["txtUsuarioExpiracion"].value = "<%= dtmFechaUsuarioExpiracion.ToString("dd/MM/yyyy")%>";
        }

        function cmdBuscarEmpleado_onclick() {
            var strEmpleado = trim(document.forms[0].elements["txtEmpleadoNombre"].value);

            if (strEmpleado == '') {
                return (false);
            }

            return Pop("popSistemaBuscarEmpleado.aspx?strEmpleado=" + strEmpleado, "400", "548")
        }

        function cmdCancelar_onclick() {
            window.location.href = "ControlAsistenciaAdministracionDeUsuarios.aspx";
        }

        function txtEmpleadoNombre_onKeyPress(e) {
            //No se permiten caracteres especiales ni letras.
            var key = window.event ? e.keyCode : e.which;
            if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || key == 13 || key == 32) {
                return true;
            }
            else {
                return false
            }
        }

        function txtUsuarioContrasena_onKeyPress(e) {
            //No se permiten caracteres especiales ni letras.
            var key = window.event ? e.keyCode : e.which;
            if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || key == 13) {
                return true;
            }
            else {
                return false
            }
        }

        function trim(stringToTrim) {
            return stringToTrim.replace(/^\s+|\s+$/g, "");
        }

        function blnFormValidator(theForm) {
            var blnReturn = false;

            /* ValidaciÃ³n del campo "Empleado" */
            if (trim(document.getElementById("txtEmpleadoNombre").value) == '') {
                alert('Seleccione un empleado por favor');
                return (false);
            }

            /* ValidaciÃ³n del campo "txtUsuarioNombre" */
            if (blnValidarCampo(document.forms[0].elements["txtUsuarioNombre"], true, "Empleado", cintTipoCampoAlfanumerico, 20, 1, "") == true) {

                /* ValidaciÃ³n del campo "txtContraseÃ±a" */
                if (blnValidarCampo(document.forms[0].elements["txtUsuarioContrasena"], true, "ContraseÃ±a", cintTipoCampoAlfanumerico, 35, 1, "") == true) {

                    blnReturn = blnValidarCampo(document.forms[0].elements["txtUsuarioExpiracion"], true, "Fecha de ExpiraciÃ³n", cintTipoCampoFecha, 10, 10, "");
                }
            }

            if (blnReturn == true) {
                if (document.forms[0].elements["cboGrupoUsuario"].value == 0) {

                    blnReturn = false;
                    alert("Es necesario seleccionar un Grupo \n\r para realizar la operaciÃ³n del usuario");

                    document.forms[0].elements["cboGrupoUsuario"].focus();
                }
            }

            return (blnReturn);
        }

        function cmdSalvar_onclick() {
            var intEmpleadoId = document.getElementById("txtUsuarioNombre").value;
            var intTipoUsuarioId = document.getElementById("cboTipoUsuario").value;
            var strUsuarioContrasena = document.getElementById("txtUsuarioContrasena").value;

            var chkUsuarioHabilitado = document.getElementsByName("chkUsuarioHabilitado");
            var blnUsuarioHabilitado;

            var optCuentaBloqueada = document.getElementsByName("optCuentaBloqueada");
            var blnUsuarioBloqueado;

            for (var i = 0; i < chkUsuarioHabilitado.length; i++) {
                if (chkUsuarioHabilitado[i].checked == true) {
                    blnUsuarioHabilitado = chkUsuarioHabilitado[i].value;
                    break;
                }
            }

            for (var i = 0; i < optCuentaBloqueada.length; i++) {
                if (optCuentaBloqueada[i].checked == true) {
                    blnUsuarioBloqueado = optCuentaBloqueada[i].value;
                    break;
                }
            }

            document.forms[0].action = "ControlAsistenciaAdministracionDeUsuariosAgregar.aspx?strCmd2=Guardar" +
                                       "&intEmpleadoId=" + intEmpleadoId +
                                       "&intTipoUsuarioId=" + intTipoUsuarioId +
                                       "&strUsuarioContrasena=" + strUsuarioContrasena +
                                       "&blnUsuarioHabilitado=" + blnUsuarioHabilitado +
                                       "&blnUsuarioBloqueado=" + blnUsuarioBloqueado;

            document.forms(0).submit();
        }

        function cmdNavegadorRegistrosAgregar_onclick() {
            var intEmpleadoId = trim(document.getElementById('txtUsuarioNombre').value);
            var strEmpleadoNombre = trim(document.getElementById('txtEmpleadoNombre').value);
            var intGrupoId = 28;
            var strGrupoUsuarioNombre = "Control de Asistencia";

            return Pop("ControlAsistenciaAsignarSucursales.aspx?intEmpleadoId=" + intEmpleadoId +
                                                                "&strEmpleadoNombre=" + strEmpleadoNombre +
                                                                "&intGrupoId=" + intGrupoId +
                                                                "&strGrupoUsuarioNombre=" + strGrupoUsuarioNombre, "400", "600")
        }

        function eliminarSucursal(element) {
            var borrarSucursal = false;
            var nombreSucursal = element.parentNode.parentNode.cells[2].innerText;
            var indiceRenglon = element.parentNode.parentNode.rowIndex;

            borrarSucursal = confirm("¿Desea desaginar la sucursal " + nombreSucursal + "?");

            if (borrarSucursal) {
                document.getElementById("tablaSucursalesAsignadas").deleteRow(indiceRenglon);
            }
        }

        function btnEliminarSucursales_onclick() {
            var borrarSucursales = false;
            var tablaSucursalesAsignadas = document.getElementById("tablaSucursalesAsignadas");
            borrarSucursales = confirm("¿Desea desaginar todas las sucursales?");

            if (borrarSucursales) {
                tablaSucursalesAsignadas.innerHTML = "";
            }
        }


        new menu(MENU_ITEMS, MENU_POS);
    </script>
</head>
<body onload="return window_onload();">
    <form name="frmAgregarUsuarioControlAsistencia" method="post">
        <input type="hidden" id="dtmFechaActual" name="dtmFechaActual" value='<%= strFechaActual()%>' />
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
                <td width="770" class="tdtab">Está en : Sucursal : Control de Asistencia : Administrar usuarios : Asignar usuario </td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <h1>Asignar usuario </h1>
                    <p>Llene los campos necesarios para crear/editar el usuario elegido de Control de Asistencia. </p>
                    <h2>Datos del usuario</h2>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="tdtexttablebold">Empleado:</td>
                            <td class="tdcontentableblue"><span class="tdpadleft5">
                                <input name="txtEmpleadoNombre" type="text" class="field" id="txtEmpleadoNombre" size="50"
                                    maxlength="50" onkeypress=" return txtEmpleadoNombre_onKeyPress(event);">
                                &nbsp;
                                <input name="cmdBuscarEmpleado" type="button" class="button" id="cmdBuscarEmpleado" value="Buscar empleado"
                                    onclick="cmdBuscarEmpleado_onclick();">
                            </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Nombre de usuario:</td>
                            <td class="tdcontentableblue"><span class="tdpadleft5">
                                <input name="txtUsuarioNombre" type="text" class="fieldborderless" id="txtUsuarioNombre" size="35"
                                    maxlength="35" readonly>
                            </span></td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Contraseña:</td>
                            <td class="tdpadleft5">
                                <input name="txtUsuarioContrasena" type="password" class="field" id="txtUsuarioContrasena"
                                    size="35" maxlength="35" language="javascript" onchange="return txtUsuarioContrasena_onchange()" onkeypress=" return txtUsuarioContrasena_onKeyPress(event);"></td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Rol Usuario:</td>
                            <td class="tdpadleft5">
                                <select id="cboTipoUsuario" class="field" style="width: 125px">
                                    <option value="2">Coordinador RH</option>
                                    <option value="3">Supervisor Médico</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Estatus: </td>
                            <td class="tdtexttablereg">
                                <input name="chkUsuarioHabilitado" type="radio" value="1" checked>
                                Habilitado&nbsp;&nbsp;&nbsp;
                                <input name="chkUsuarioHabilitado" type="radio" value="0">
                                Deshabilitado</td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">&iquest;Cuenta bloqueada? </td>
                            <td class="tdtexttablereg">
                                <input name="optCuentaBloqueada" type="radio" value="1" />
                                S&iacute;&nbsp;
                                <input name="optCuentaBloqueada" type="radio" value="0" />
                                No
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Fecha de expiración :&nbsp;&nbsp;&nbsp; </td>
                            <td class="tdpadleft5">
                                <input name="txtUsuarioExpiracion" id="txtUsuarioExpiracion" class="field" size="12" maxlength="12" type="text">
                                <a href="javascript:cal1.popup()">
                                    <img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle">
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="tdtexttablebold"><span class="tdtexttablereg">
                                <input type="checkbox" name="chkUsuarioAlcance" value="1" disabled>
                                Operar sólo en el ámbito del Concentrador Central</span>
                            </td>
                        </tr>
                        <tr class="txaccion">
                            <td colspan="2">&nbsp;</td>
                        </tr>
                    </table>
                    <input name="cmdSalvar" type="button" class="button" id="cmdSalvar" value="Guardar usuario" onclick="cmdSalvar_onclick();">
                    &nbsp;&nbsp;
                    <input name="cmdNavegadorRegistrosAgregar" class="boton" id="cmdNavegadorRegistrosAgregar" onclick="cmdNavegadorRegistrosAgregar_onclick();" type="button" value="Vincular sucursales" />
                    &nbsp;&nbsp;
                    <input name="cmdCancelar" type="button" class="button" id="cmdCancelar" onclick="return cmdCancelar_onclick();" value="Cancelar">
                    <br /><br />
                    <input id="btnEliminarSucursales" type="button" class="button" style="margin-left:600px;"
                        onclick="return btnEliminarSucursales_onclick();" value="Eliminar Sucursales" />
                    <div id="sucursales">

                    </div>
                    <br>
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
            var cal1 = new calendar(null, document.forms[0].elements['txtUsuarioExpiracion']);
        </script>
    </form>
</body>
</html>
