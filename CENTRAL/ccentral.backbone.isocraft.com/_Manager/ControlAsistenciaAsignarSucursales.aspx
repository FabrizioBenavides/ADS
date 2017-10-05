<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsistenciaAsignarSucursales.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistenciaAsignarSucursales" %>

<html>
<head>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
    <link href="css/estilo.css" rel="stylesheet" type="text/css">
    <script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
    <script id="clientEventHandlersJS" language="javascript">

        strUsuarioNombre = "<%= strUsuarioNombre %>";
        strFechaHora = "<%= strHTMLFechaHora %>";

        function window_onload() {
            document.forms[0].action = "<%= strThisPageName %>";
            document.forms[0].elements["txtEmpleadoId"].value = "<%= intEmpleadoId %>";
            document.forms[0].elements["txtEmpleadoNombre"].value = "<%= strEmpleadoNombre %>";
            document.forms[0].elements["txtGrupoUsuarioNombre"].value = "<%= strGrupoUsuarioNombre %>";

            <%= strJavascriptWindowOnLoadCommands %>
            <%= strLlenarDireccionComboBox() %>
            <%= strLlenarZonaComboBox() %>
        }

    function strEmpleadoId() {
        document.write("<%=intEmpleadoId()%>");
    }

    function strEmpleadoNombre() {
        document.write("<%=strEmpleadoNombre()%>");
    }

    function strGrupoUsuarioNombre() {
        document.write("<%=strGrupoUsuarioNombre()%>");
    }

    function cmdCancelar_onclick() {
        window.close();
    }

    function chkTodo_onclick() {
        for (var intCounter = 0; intCounter < document.forms[0].elements["cboSucursal"].length; intCounter++) {
            document.forms[0].elements["cboSucursal"].options[intCounter].selected = document.forms[0].elements["chkTodo"].checked;
        }
    }

    function cmdCerrar_onclick() {
        var blnSelected = false;

        var sucursalesExistentes = window.opener.document.getElementById("sucursalesExistentes").value;

        for (var intCounter = 0; intCounter < document.forms[0].elements["cboSucursal"].length; intCounter++) {

            blnSelected = document.forms[0].elements["cboSucursal"].options[intCounter].selected;

            if (blnSelected == true) {
                break;
            }
        }

        if (document.getElementById('cboDireccion').value > '0' && document.getElementById('cboZona').value == '-1') {
            blnSelected = true;
        }

        if (blnSelected == true) {
            document.forms[0].action += "?strCmd=Cerrar&strSucursalesExistentes=" + sucursalesExistentes;
            document.forms[0].submit();
        }
        else {
            alert("Por favor seleccione al menos una sucursal.");
            document.forms[0].elements["cboSucursal"].focus();
            return (false);
        }
    }

    function cboDireccion_onchange() {
        if (document.forms[0].elements["cboDireccion"].selectedIndex > 0) {
            document.forms[0].elements["cboZona"].selectedIndex = 0;
            document.forms[0].submit();
        }
        return (true);
    }

    </script>
</head>
<body onload="return window_onload()">
    <form method="POST" action="about:blank" name="frmPopSucursalVincularSucursalUsuario">
        <input type="hidden" name="txtEmpleadoId">
        <input type="hidden" name="txtEmpleadoNombre">
        <input type="hidden" name="txtGrupoUsuarioNombre">
        <table width="360" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <script language="JavaScript">crearTablaHeaderPop()</script>
                </td>
            </tr>
        </table>
        <table width="360" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="tdgeneralcontentpop">
                    <h2>Asignar Sucursales a usuario </h2>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="19%" class="tdtexttablebold">Usuario: </td>
                            <td width="81%" class="tdcontentableblue">
                                <script language="javascript">strEmpleadoId()</script>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Nombre:</td>
                            <td class="tdcontentableblue">
                                <script language="javascript">strEmpleadoNombre()</script>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Grupo: </td>
                            <td class="tdcontentableblue">
                                <script language="javascript">strGrupoUsuarioNombre()</script>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Direcci&oacute;n:</td>
                            <td class="tdpadleft5">
                                <select id="cboDireccion" name="cboDireccion" class="field" onchange="return cboDireccion_onchange()">
                                    <option value="0">Elija una direcci&oacute;n</option>
                                </select></td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Zona:</td>
                            <td class="tdpadleft5">
                                <select id="cboZona" name="cboZona" class="field">
                                    <option value="0">Elija una zona</option>
                                    <option value="-1">Todas las zonas</option>
                                </select>
                            </td>
                        </tr>
                    </table>
                    <span class="tdpadleft5">
                        <br>
                        <input name="cmdConsultar" type="submit" class="button" value="Enlistar sucursales">
                    </span>
                    <br>
                    <br>
                    <p>Elija las sucursales que desea asignar al coordinador indicado y oprima el botón cerrar selección. Para elegir m&aacute;s de una sucursal, haga clic en los nombres correspondientes. </p>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="tdtexttablebold">
                                <input type="checkbox" name="chkTodo" value="checkbox" onclick="return chkTodo_onclick()">
                                &nbsp;Seleccionar todas</td>
                        </tr>
                        <tr>
                            <td width="81%" class="tdpadleft5">
                                <select name="cboSucursal" size="10" multiple="multiple">
                                    <%= strLlenarSucursalComboBox() %>
                                </select>
                            </td>
                        </tr>
                    </table>
                    <br>
                    <span class="tdpadleft5">
                        <input name="cmdCancelar" type="button" class="button" value="Cancelar" onclick="return cmdCancelar_onclick()">
                        &nbsp;&nbsp;
                        <input name="cmdCerrar" type="button" class="button" value="Cerrar selecci&oacute;n" onclick="return cmdCerrar_onclick()">
                    </span>
                </td>
            </tr>
        </table>
        <table width="360" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <script language="JavaScript">crearTablaFooterPop()</script>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
