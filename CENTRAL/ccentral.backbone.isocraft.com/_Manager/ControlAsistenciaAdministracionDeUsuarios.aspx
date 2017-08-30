<%@ Page Language="vb" AutoEventWireup="false" EnableViewState="true" CodeBehind="ControlAsistenciaAdministracionDeUsuarios.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistenciaAdministracionDeUsuarios" %>

<html>
<head>
    <title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
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
            cargarValoresControles();
        }

        function cargarValoresControles() {
            var strCmd2;
            var txtNumeroEmpleado;

            strCmd2 = "<%=strCmd2%>";

            if (strCmd2 == "Buscar") {

                txtNumeroEmpleado = "<%=txtNumeroEmpleado%>";

                if (txtNumeroEmpleado == "0") {
                    document.getElementById("txtNumeroEmpleado").value = "";
                }
                else {
                    document.getElementById("txtNumeroEmpleado").value = txtNumeroEmpleado;
                }

                document.getElementById("cboTipoUsuario").value = "<%=cboTipoUsuario%>"; 
            }
        }

        function txtNumeroEmpleado_onKeyPress(e) {
            //No se permiten caracteres especiales ni letras.
            var key = window.event ? e.keyCode : e.which;
            if (key > 47 && key < 58 || key == 13) {
                return true;
            }
            else {
                return false;
            }
        }

        function btnRealizarConsulta_onclick() {
            var intGrupoUsuarioId = "<%= intGrupoUsuarioSeleccionadoId%>";
            var intEmpleadoId = document.getElementById("txtNumeroEmpleado").value;
            var intTipoUsuarioId = document.getElementById("cboTipoUsuario").value;

            document.forms[0].action = "ControlAsistenciaAdministracionDeUsuarios.aspx?" +
                                       "strCmd2=Buscar" +
                                       "&intEmpleadoId=" + intEmpleadoId +
                                       "&intTipoUsuarioIdParametro=" + intTipoUsuarioId;

            document.forms(0).submit();
        }

        function cmdDeshabilitarUsuario_onclick(intEmpleadoId, intUsuarioId) {

            window.location.href = "ControlAsistenciaAdministracionDeUsuarios.aspx?" +
                                   "strCmd2=Deshabilitar" +
                                   "&intEmpleadoId=" + intEmpleadoId +
                                   "&intUsuarioId=" + intUsuarioId;
        }

        function cmdEditarUsuario_onclick(intEmpleadoId, intUsuarioId, strUsuarioContrasena, dtmUsuarioExpiracion,
                                          blnUsuarioBloqueado, intTipoUsuarioId, blnUsuarioHabilitado) {

            window.location.href = "ControlAsistenciaAdministracionDeUsuariosAgregar.aspx?" +
                                   "strCmd2=Editar" +
                                   "&intEmpleadoId=" + intEmpleadoId +
                                   "&intUsuarioId=" + intUsuarioId +
                                   "&strUsuarioContrasena=" + strUsuarioContrasena +
                                   "&dtmUsuarioExpiracion=" + dtmUsuarioExpiracion +
                                   "&blnUsuarioBloqueado=" + blnUsuarioBloqueado +
                                   "&intTipoUsuarioIdParametro=" + intTipoUsuarioId +
                                   "&blnUsuarioHabilitado=" + blnUsuarioHabilitado;
        }

        new menu(MENU_ITEMS, MENU_POS);
    </script>
</head>
<body onload="return window_onload()">
    <form method="post" action="about:blank" name="frmSistemaAdministrarUsuariosControlAsistencia">
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
                <td width="770" class="tdtab">Est&aacute; en : Sucursal : Control de Asistencia : Administrar usuarios </td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <h1>Administrar usuarios de Control de Asistencia</h1>
                    <p>Aqu&iacute; podr&aacute; dar de alta o modificar los datos de un usuario de Control de Asistencia, además de asignarle sucursales. </p>
                    <table width="80%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="25%" class="tdtexttablebold">Grupo:</td>
                            <td width="24%" class="tdconttablas">Control de Asistencia
                            </td>
                            <td width="51%" class="tdpadleft5">&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="25%" class="tdtexttablebold">Rol Usuario:</td>
                            <td class="tdpadleft5">
                                <select id="cboTipoUsuario"  name="cboTipoUsuario" class="field" style="width: 125px">
                                    <option value="2">Coordinador RH</option>
                                    <option value="3">Supervisor Médico</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">N&uacute;mero de empleado: </td>
                            <td class="tdpadleft5">
                                <input id="txtNumeroEmpleado" type="text" class="field" size="15" maxlength="12" onkeypress=" return txtNumeroEmpleado_onKeyPress(event);">
                            </td>
                            <td class="tdpadleft5">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">&nbsp;</td>
                            <td class="tdpadleft5" colspan="2">
                                <br>
                                <br>
                                <input id="btnRealizarConsulta" type="button" class="boton" value="Realizar Consulta" onclick="btnRealizarConsulta_onclick();">
                                <input id="btnAgregarUsuario" type="button" class="boton" onclick="window.location = 'ControlAsistenciaAdministracionDeUsuariosAgregar.aspx?strCmd2=Agregar'" value="Agregar Usuario" />
                            </td>
                        </tr>
                    </table>
                    <br>
                    <%= strConsultarUsuarios()%>
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
