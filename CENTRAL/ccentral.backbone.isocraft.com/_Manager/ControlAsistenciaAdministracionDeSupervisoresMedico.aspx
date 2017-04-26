<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsistenciaAdministracionDeSupervisoresMedico.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistenciaAdministracionDeSupervisoresMedico" %>

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
            document.forms[0].action = "<%= strThisPageName %>";
            <%= strJavascriptWindowOnLoadCommands %>
        }

        function txtEmpleadoId_onKeyPress(e) {
            //No se permiten caracteres especiales ni letras.
            var key = window.event ? e.keyCode : e.which;

            if (key > 47 && key < 58 || key == 13) {
                return true;
            }
            else {
                return false
            }
        }

        function cmdRealizarConsulta_onclick() {
            if (blnFormValidator()) {
                document.forms[0].submit();
            }
        }

        function blnFormValidator() {
            var theForm = document.forms[0];
            var blnReturn = false;

            blnReturn = blnValidarCampo(document.forms[0].elements["txtEmpleadoId"], true, "Número de empleado", cintTipoCampoEntero, 15, 1, "")
          
            return (blnReturn);
        }

        function cmdDeshabilitarUsuario_onclick(intEmpleadoId, intUsuarioId) {
            window.location.href = 'ControlAsistenciaAdministracionDeSupervisoresMedico.aspx' +
                                   '?strCmd2=Desasignar&intEmpleadoId=' + intEmpleadoId + '&intUsuarioId=' + intUsuarioId;
        }

        function cmdEditarUsuario_onclick(intEmpleadoId, intUsuarioId) {
            window.location.href = 'ControlAsistenciaAdministracionDeSupervisoresMedico.aspx' +
                                   '?strCmd2=Editar&intEmpleadoId=' + intEmpleadoId + '&intUsuarioId=' + intUsuarioId;
        }

        new menu(MENU_ITEMS, MENU_POS);
    </script>
</head>
<body onload="return window_onload()">
    <form method="POST" action="about:blank" name="frmSistemaAdministrarUsuariosControlAsistencia">
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
                <td width="770" class="tdtab">Est&aacute; en : Sucursal : Control de Asistencia : Administrar usuarios Supervisor Médico</td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <h1>Control Asistencia Administrar Usuario Supervisor Médico</h1>
                    <p>Aqu&iacute; podr&aacute; dar de alta o modificar los datos de un usuario de tipo Supervisor Médico de Control de Asistencia, 
                        además de asignarle sucursales. 
                    </p>
                    <table width="80%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="25%" class="tdtexttablebold">Grupo:</td>
                            <td width="24%" class="tdconttablas">Control de Asistencia
                            </td>
                            <td width="51%" class="tdpadleft5">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">N&uacute;mero de empleado: </td>
                            <td class="tdpadleft5">
                                <input name="txtEmpleadoId" type="text" class="field" size="15" maxlength="12" onkeypress=" return txtEmpleadoId_onKeyPress(event);"></td>
                            <td class="tdpadleft5">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">&nbsp;</td>
                            <td class="tdpadleft5" colspan="2">
                                <br>
                                <br>
                                <input name="cmdRealizarConsulta" type="button" class="button" value="Realizar Consulta" onclick="cmdRealizarConsulta_onclick();">
                                <input name="cmdNavegadorRegistrosAgregar" type="button" class="boton" id="cmdNavegadorRegistrosAgregar" onclick="window.location = 'ControlAsistenciaAdministracionSupervisoresMedicoAgregar.aspx?strCmd2=Agregar'" value="Agregar Usuario" />
                            </td>
                        </tr>
                    </table>
                    <br>
                    <%= strRecordBrowserHTML %>
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
