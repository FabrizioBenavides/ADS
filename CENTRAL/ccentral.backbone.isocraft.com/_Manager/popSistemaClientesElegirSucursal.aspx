<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="popSistemaClientesElegirSucursal.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popSistemaClientesElegirSucursal" CodePage="28592" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html>
<head>
    <title>Benavides : Asignación de Sucursales a Clientes</title>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/menu.css" rel="stylesheet" type="text/css" />
    <link href="css/estilo.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        function window_onload() {

            <%= strLlenarEstadoComboBox() %>
            <%= strLlenarCiudadComboBox() %>
            <%= strLlenarSucursalComboBox() %>
            <%= strJavascriptWindowOnLoadCommands %>
        }

        function btnCerrarVentana_onclick() {
            window.open("popSistemaConsultarSucursalesClientes.aspx?" +
                      "&strClienteABFId=" +
                      "&strClienteABFNombre=",
                      "Pop", "width=800, height=600, left=150, top=30, resizable=no, scrollbars=yes, menubar=no, status=no");
        }

    </script>
</head>
<body onload="return window_onload()">
    <form id="frmSucursales" action="about:blank" method="post">
        <table width="450" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="450" class="tdgeneralcontentpop">
                    <h2>Seleccionar Sucursal(es)</h2>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td class="tdtexttablebold" width="30%">* Cadena:</td>
                            <td class="tdpadleft5" width="70%">
                                <select name="cboCadena" class="field" id="cboCadena" onchange="return cboCadena_onchange()">
                                    <option value="0" selected>--- Todas ---</option>
                                    <option value="1">FARMACIAS BENAVIDES S.A.B. DE C.V.</option>
                                    <option value="2">FARMACIAS ABC DE MEXICO S.A. DE C.V.</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">* Estado:</td>
                            <td class="tdpadleft5" width="70%">
                                <select name="cboEstado" class="field" id="cboEstado" language="javascript" onchange="return cboEstado_onchange()">
                                    <option value="0" selected>--- Elija un estado ---</option>
                                    <option>--------------------</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">* Ciudad:</td>
                            <td class="tdpadleft5" width="70%">
                                <select name="cboCiudad" class="field" id="cboCiudad" onchange="return cboCiudad_onchange()">
                                    <option value="0" selected>-- Elija una ciudad --</option>
                                    <option>--------------------</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">* Sucursal:</td>
                            <td class="tdpadleft5" width="70%">
                                <select name="cboSucursal" class="field" id="cboSucursal" onchange="return cboSucursal_onchange()">
                                    <option value="0" selected>-- Elija una sucursal --</option>
                                    <option>--------------------</option>
                                </select>
                            </td>
                        </tr>
                    </table>
                    <br>
                    <input name="btnCerrarVentana" type="button" class="button" value="Cancelar" onclick="return btnCerrarVentana_onclick()">
                    <input id ="btnAsignarSucursales" name="btnAsignarSucursales" type="button" class="button" value="Asignar" onclick="" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>