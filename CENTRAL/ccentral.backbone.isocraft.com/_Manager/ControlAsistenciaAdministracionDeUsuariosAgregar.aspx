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
            var strCmd2 = "<%= strCmd2%>";

            if (strCmd2 == "Agregar") {
                document.forms[0].elements["txtUsuarioExpiracion"].value = "<%= dtmFechaUsuarioExpiracion.ToString("dd/MM/yyyy")%>";
            }
            
            if (strCmd2 == "Editar") {
                cargarValoresControles();
            }
        }

        function cargarValoresControles() {
            document.getElementById("txtUsuarioNombre").value = "<%=intEmpleadoId%>";
            document.getElementById("txtUsuarioContrasena").value = "<%=strUsuarioContrasena%>";
            document.getElementById("cboTipoUsuario").value = "<%=intTipoUsuarioId%>";

            document.getElementById("cmdBuscarEmpleado").disabled = true;

            if("<%=blnUsuarioHabilitado%>" == "True"){
                document.forms[0].elements['chkUsuarioHabilitado'][0].checked = true;
            }
            else{
                document.forms[0].elements['chkUsuarioHabilitado'][1].checked = true;
            }
            
            if ("<%=blnUsuarioBloqueado%>" == "True") {
                document.forms[0].elements['optCuentaBloqueada'][0].checked = true;
            }
            else {
                document.forms[0].elements['optCuentaBloqueada'][1].checked = true;
            }

            document.getElementById("txtUsuarioExpiracion").value = "<%= dtmFechaUsuarioExpiracion.ToString("dd/MM/yyyy")%>";
        }

        function cmdBuscarEmpleado_onclick() {
            var strEmpleado = trim(document.forms[0].elements["txtEmpleadoNombre"].value);

            if (strEmpleado == '') {
                return (false);
            }

            return Pop("popSistemaBuscarEmpleado.aspx?strEmpleado=" + strEmpleado, "400", "548");
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
                return false;
            }
        }

        function txtUsuarioContrasena_onKeyPress(e) {
            //No se permiten caracteres especiales ni letras.
            var key = window.event ? e.keyCode : e.which;
            if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || key == 13) {
                return true;
            }
            else {
                return false;
            }
        }

        function trim(stringToTrim) {
            return stringToTrim.replace(/^\s+|\s+$/g, "");
        }

        function cmdSalvar_onclick() {
            var objValidar = {
                mensajeError: "",
                esInvalido: false
            };

            objValidar= validarGuardarUsuario();

            if (objValidar.esInvalido == false) {
                salvarUsuario();
            }
            else {
                window.alert(objValidar.mensajeError);
            }
        }

        function validarGuardarUsuario() {
            var objValidar = {
                mensajeError: "",
                esInvalido: false
            };

            var tablaSucursalesAsignadas = document.getElementById("tablaSucursalesAsignadas");

            if (document.getElementById("txtUsuarioNombre").value == "") {
                objValidar.mensajeError = "Seleccione un empleado por favor.";
                objValidar.esInvalido = true;
            }

            else if (document.getElementById("txtUsuarioContrasena").value == "") {
                objValidar.mensajeError = "Escriba una contraseña por favor.";
                objValidar.esInvalido = true;
            }

            else if (document.getElementById("cboTipoUsuario").value == "0") {
                objValidar.mensajeError = "Seleccione el rol del usuario.";
                objValidar.esInvalido = true;
            }

            else if (document.getElementById("txtUsuarioExpiracion").value == "") {
                objValidar.mensajeError = "Seleccione la fecha de expiración por favor.";
                objValidar.esInvalido = true;
            }

            else if (tablaSucursalesAsignadas != null) {
                if (tablaSucursalesAsignadas.rows.length < 2) {
                    objValidar.mensajeError = "Seleccione las sucursales a vincular.";
                    objValidar.esInvalido = true;
                }
            }
            else {
                objValidar.mensajeError = "Seleccione las sucursales a vincular.";
                objValidar.esInvalido = true;
            }

            return objValidar;
        }

        function salvarUsuario() {
            var intUsuarioId = "<%=intUsuarioId%>";
            var intEmpleadoId = document.getElementById("txtUsuarioNombre").value;
            var intTipoUsuarioId = document.getElementById("cboTipoUsuario").value;
            var strUsuarioContrasena = document.getElementById("txtUsuarioContrasena").value;
            var strUsuarioContrasenaAnterior = "<%=strUsuarioContrasena%>";
            var strCmd2 = "<%= strCmd2%>";
            var chkUsuarioHabilitado = document.getElementsByName("chkUsuarioHabilitado");
            var blnUsuarioHabilitado;
            var optCuentaBloqueada = document.getElementsByName("optCuentaBloqueada");
            var blnUsuarioBloqueado;

            var txtUsuarioExpiracion = document.getElementById("txtUsuarioExpiracion").value;
            var companiasSucursales;

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

            var companiasSucursales = obtenerCompaniasSucursales();

            if (strCmd2 == "Agregar") {
                document.forms[0].action = "ControlAsistenciaAdministracionDeUsuariosAgregar.aspx?strCmd2=Guardar" +
                                           "&intEmpleadoId=" + intEmpleadoId +
                                           "&strUsuarioContrasena=" + strUsuarioContrasena +
                                           "&intTipoUsuarioId=" + intTipoUsuarioId +
                                           "&blnUsuarioHabilitado=" + blnUsuarioHabilitado +
                                           "&blnUsuarioBloqueado=" + blnUsuarioBloqueado +
                                           "&dtmUsuarioExpiracion=" + txtUsuarioExpiracion +
                                           "&strCompaniasSucursalesSeleccionadas=" + companiasSucursales;
            }
            else if (strCmd2 == "Editar") {
                document.forms[0].action = "ControlAsistenciaAdministracionDeUsuariosAgregar.aspx?strCmd2=Modificar" +
                                           "&intUsuarioId=" + intUsuarioId +
                                           "&intEmpleadoId=" + intEmpleadoId +
                                           "&strUsuarioContrasena=" + strUsuarioContrasena +
                                           "&strUsuarioContrasenaAnterior=" + strUsuarioContrasenaAnterior +
                                           "&intTipoUsuarioId=" + intTipoUsuarioId +
                                           "&blnUsuarioHabilitado=" + blnUsuarioHabilitado +
                                           "&blnUsuarioBloqueado=" + blnUsuarioBloqueado +
                                           "&dtmUsuarioExpiracion=" + txtUsuarioExpiracion +
                                           "&strCompaniasSucursalesSeleccionadas=" + companiasSucursales;
            }
            
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

        function eliminarSucursal(elemento) {
            var borrarSucursal = false;
            var nombreSucursal = elemento.parentNode.parentNode.cells[2].innerText;
            var indiceRenglon = elemento.parentNode.parentNode.rowIndex;

            borrarSucursal = confirm("¿Desea desasignar la sucursal " + nombreSucursal + "?");

            if (borrarSucursal) {
                document.getElementById("tablaSucursalesAsignadas").deleteRow(indiceRenglon);
            }
        }

        function btnEliminarSucursales_onclick() {
            var borrarSucursales = false;
            var tablaSucursalesAsignadas = document.getElementById("tablaSucursalesAsignadas");
   
            if (tablaSucursalesAsignadas != null) {

                if (tablaSucursalesAsignadas.rows.length > 1) {

                    borrarSucursales = confirm("¿Desea desasignar todas las sucursales?");

                    if (borrarSucursales) {

                        for (var i = 1; i < tablaSucursalesAsignadas.rows.length;) {
                            tablaSucursalesAsignadas.deleteRow(i);
                        }
                    }
                }
            }
        }

        function obtenerCompaniasSucursales() {
            var tablaSucursalesAsignadas = document.getElementById("tablaSucursalesAsignadas");
            var companiasSucursales = "";

            if (tablaSucursalesAsignadas != null) {

                if (tablaSucursalesAsignadas.rows.length > 0) {

                    for (var i = 1, renglon; renglon = tablaSucursalesAsignadas.rows[i]; i++) {
                        companiasSucursales = companiasSucursales + renglon.cells[0].innerText + "," + renglon.cells[1].innerText + "|";
                    }
                }
            }

            return companiasSucursales;
        }

        function cboTipoUsuario_onchange() {
            var tablaSucursalesAsignadas = document.getElementById("tablaSucursalesAsignadas");

            if (tablaSucursalesAsignadas != null) {
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
                            <td class="tdcontentableblue">
                                <span class="tdpadleft5">
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
                            <td class="tdcontentableblue">
                                <span class="tdpadleft5">
                                <input name="txtUsuarioNombre" type="text" class="fieldborderless" id="txtUsuarioNombre" size="35"
                                    maxlength="35" readonly>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Contraseña:</td>
                            <td class="tdpadleft5">
                                <input name="txtUsuarioContrasena" type="password" class="field" id="txtUsuarioContrasena"
                                    size="35" maxlength="35" language="javascript" onchange="return txtUsuarioContrasena_onchange()" 
                                    onkeypress=" return txtUsuarioContrasena_onKeyPress(event);">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Rol Usuario:</td>
                            <td class="tdpadleft5">
                                <select id="cboTipoUsuario" class="field" style="width: 125px" onchange="cboTipoUsuario_onchange()">
                                    <option value="0"></option>
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
                                <input name="optCuentaBloqueada" type="radio" value="1" checked/>
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
                            <td colspan="2" class="tdtexttablebold">
                                <span class="tdtexttablereg">
                                <input type="checkbox" name="chkUsuarioAlcance" value="1" disabled>
                                Operar sólo en el ámbito del Concentrador Central</span>
                            </td>
                        </tr>
                        <tr class="txaccion">
                            <td colspan="2">&nbsp;</td>
                        </tr>
                    </table>

                    <input name="cmdSalvar" type="button" class="button" id="cmdSalvar" value="Guardar usuario" 
                        onclick="cmdSalvar_onclick();">
                    &nbsp;&nbsp;
                    <input name="cmdNavegadorRegistrosAgregar" class="boton" id="cmdNavegadorRegistrosAgregar" 
                        onclick="cmdNavegadorRegistrosAgregar_onclick();" type="button" value="Vincular sucursales" />
                    &nbsp;&nbsp;
                    <input name="cmdCancelar" type="button" class="button" id="cmdCancelar" onclick="return cmdCancelar_onclick();" value="Cancelar">
                    <br /><br />
                    <input id="btnEliminarSucursales" type="button" class="button" style="margin-left: 650px;"
                        onclick="return btnEliminarSucursales_onclick();" value="Eliminar Sucursales" />
                    <br /><br />

                    <div id="sucursales">
                        <%=strObtenerSucursalesPorCoordinadorRH()%>
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
