<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="popSistemaConsultarSucursalesClientes.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popSistemaConsultarSucursalesClientes" CodePage="28592" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html>
<head>
    <title>Benavides: Consulta Sucursales de Clientes</title>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/menu.css" rel="stylesheet" type="text/css" />
    <link href="css/estilo.css" rel="stylesheet" type="text/css" />
<%--    <script type="text/JavaScript" src="js/menu.js"></script>
    <script type="text/JavaScript" src="js/menu_items.js"></script>
    <script type="text/JavaScript" src="js/menu_tpl.js"></script>
    <script type="text/JavaScript" src="js/headerfooter.js"></script>--%>

    <script type="text/javascript">

        strUsuarioNombre = <%= strUsuarioNombre %>;

        function window_onload() {
            <%= strJavascriptWindowOnLoadCommands %>;
            establecerValorEncabezado();
        }

        function btnAsignarSucursales_onclick() {
            window.open("popSistemaClientesElegirSucursal.aspx", "Pop", "width=100, height=100," + 
                        "left=750, top=400, resizable=no, scrollbars=yes, menubar=no, status=no");
        }

        function btnBorrarSucursalesTodas_onclick() {
     
        }

        function btnExportarDatos_onclick() {
     
        }

        function btnCerrarVentana_onclick() {
            window.close();
        }

        function establecerValorEncabezado(){
            var strClienteABFId = "<%= strClienteABFId%>";
            var strClienteABFNombre = "<%= strClienteABFNombre%>";

            document.getElementById("TituloCliente").innerText= strClienteABFId + "-" + strClienteABFNombre;
        }

    </script>

</head>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0" onload="return window_onload()">
    <form id="frmSucursal" action="about:blank" method="post">
        <table height="158" cellspacing="0" cellpadding="0" width="100%" bgcolor="#ffffff" border="0">
            <tr>
                <td class="tdlogopop" colspan="2" height="21">
                    <img height="54" src="../static/images/logo_pop.gif" width="177">
                </td>
            </tr>
            <tr>
                <td width="2%">&nbsp;</td>
                <td valign="top" width="99%" height="10">
                    <h1 id="TituloCliente"></h1>
                </td>
            </tr>
        </table>
        <table width="800" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="800" class="tdgeneralcontentpop">
                    <h2>Sucursales Asignadas</h2>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td>
                                <div style="margin-left: 0px;">
                                    <input id="btnAsignarSucursales" name="btnAsignarSucursales" type="button"
                                        class="boton" value="Asignar Sucursales" onclick="btnAsignarSucursales_onclick()">
                                    <input id="btnBorrarSucursalesTodas" type="button" name="btnBorrarSucursalesTodas"
                                        class="boton" value="Borrar todas" onclick="btnBorrarSucursalesTodas_onclick()">
                                    <br>
                                    <br>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-left: 700px;">
                                     <input id="btnExportar" name="btnExportar" type="button"
                                        class="boton" value="Exportar Datos" onclick="return btnExportarDatos_onclick()">   
                                </div>
                            </td>
                        </tr>
                        <tr height="50">
                        </tr>
                        <tr>
                            <td>
                                <%= strConsultarSucursalesClientes%>
                            </td>
                        </tr>
                        <tr style="height: 100px;">
                            <td>
                                <input id="btnCerrarVentana" name="btnCerrarVentana" type="button"
                                    class="boton" value="Cerrar" onclick="return btnCerrarVentana_onclick()">   
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
