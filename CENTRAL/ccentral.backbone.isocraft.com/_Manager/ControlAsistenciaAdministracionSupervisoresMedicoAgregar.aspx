<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsistenciaAdministracionSupervisoresMedicoAgregar.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistenciaAdministracionSupervisoresMedicoAgregar" %>

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

            document.forms[0].action = "<%= strThisPageName %>";
            document.forms[0].elements["txtCmd"].value = "<%= strCmd %>";
            document.forms[0].elements["txtUsuarioId"].value = "<%= intUsuarioId %>";
            document.forms[0].elements["txtEmpleadoNombre"].value = "<%= strEmpleadoNombre %>";
            document.forms[0].elements["txtUsuarioNombre"].value = "<%= intEmpleadoId %>";
            document.forms[0].elements["txtUsuarioContrasena"].value = "<%= strUsuarioContrasena %>";
            document.forms[0].elements["txtUsuarioExpiracion"].value = "<%= dtmUsuarioExpiracion.ToString("dd/MM/yyyy") %>";
        }

        if ("<%= intUsuarioId %>" != "0") {

            document.getElementById('cmdBuscarEmpleado').style.display = 'none'
        }

        new menu(MENU_ITEMS, MENU_POS);
        var cal1 = new calendar(null, document.forms[0].elements['txtUsuarioExpiracion']);
    </script>
</head>
<body onload="return window_onload();">
    <form name="frmAgregarUsuarioControlAsistencia" method="post" onsubmit="return blnFormValidator(this)">
        <input type="hidden" name="txtSucursales">
        <input type="hidden" name="txtCmd">
        <input type="hidden" name="txtUsuarioId">
        <input type="hidden" name="txtActualizarContrasena" />
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
                            <td class="tdtexttablebold">Grupo:</td>
                            <td class="tdpadleft5">
                                <select name="cboGrupoUsuario" class="field" id="cboGrupoUsuario">
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Estatus: </td>
                            <td class="tdtexttablereg">
                                <input name="chkUsuarioHabilitado" type="radio" value="1" checked>
                                Habilitado&nbsp;&nbsp;&nbsp;
                                <input name="chkUsuarioHabilitado" type="radio" value="0">Deshabilitado
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">&iquest;Cuenta bloqueada? </td>
                            <td class="tdtexttablereg">
                                <input name="optCuentaBloqueada" type="radio" value="1" />
                                S&iacute;&nbsp;
                            <input name="optCuentaBloqueada" type="radio" value="0" />
                                No</td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Fecha de expiración :&nbsp;&nbsp;&nbsp; </td>
                            <td class="tdpadleft5">
                                <input name="txtUsuarioExpiracion" id="txtUsuarioExpiracion" class="field" size="12" maxlength="12"
                                    type="text">
                                <a href="javascript:cal1.popup()">
                                    <img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"></a></td>
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
                    <input name="cmdSalvar" type="submit" class="button" id="cmdSalvar" value="Guardar usuario">
                    &nbsp;&nbsp;
                    <input name="cmdNavegadorRegistrosAgregar" class="boton" id="cmdNavegadorRegistrosAgregar" onclick="cmdNavegadorRegistrosAgregar_onclick();" type="button" value="Asignar Consultorio" />
                    &nbsp;&nbsp;
                    <input name="cmdCancelar" type="button" class="button" id="cmdCancelar" onclick="return cmdCancelar_onclick()" value="Cancelar">
                    <br>
                        <%=strRecordBrowserHTML%>
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
    </form>
</body>
</html>