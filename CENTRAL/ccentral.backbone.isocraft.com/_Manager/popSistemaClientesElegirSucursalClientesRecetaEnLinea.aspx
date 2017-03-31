<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="popSistemaClientesElegirSucursalClientesRecetaEnLinea.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popSistemaClientesElegirSucursalClientesRecetaEnLinea" CodePage="28592" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html>
<head>
    <title>Benavides : Asignación de Sucursales a Clientes</title>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/menu.css" rel="stylesheet" type="text/css" />
    <link href="css/estilo.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

        strFechaHora = "<%= strHTMLFechaHora %>";

        function window_onload() {
            <%= strLlenarEstadoComboBox() %>
            <%= strLlenarCiudadComboBox() %>
            <%= strLlenarSucursalComboBox() %>
            <%= strJavascriptWindowOnLoadCommands %>

            habilitarCboCiudadYSucursal();
            matenerValorCboCadena();
            validarRecargaPagina();
        }

        function validarRecargaPagina(){
            var valorRecargaPaginaPrincipal = <%= intSeRecargoPaginaPrincipal%>;

            if(valorRecargaPaginaPrincipal == "1"){
                window.opener.location.reload(true);
            }
            else if(valorRecargaPaginaPrincipal == "2"){
                document.getElementById("cboEstado").selectedIndex = 0;
                document.getElementById("cboCiudad").selectedIndex = 0;
                document.getElementById("cboSucursal").selectedIndex = 0;
            }
        }

        function habilitarCboCiudadYSucursal() {
            var habilitarCboCiudad = "<%= habilitarCboCiudad%>";
            var habilitarCboSucursal = "<%= habilitarCboSucursal%>";

            if (habilitarCboCiudad == "true") {
                document.getElementById("cboCiudad").disabled = false;
            }

            if (habilitarCboSucursal == "true") {
                document.getElementById("cboSucursal").disabled = false;
            }
        }

        function matenerValorCboCadena() {
            var strCadenaId = "<%= intCadenaId%>";
            document.getElementById("cboCadena").value = strCadenaId;
        }

        function cboEstado_onchange() {
            var cboCadena = document.getElementById("cboCadena").value;
            var cboEstado = document.getElementById("cboEstado");
            var cboCiudad = document.getElementById("cboCiudad");
            var cboSucursal = document.getElementById("cboSucursal");
            var strClienteABFId = "<%= strClienteABFId%>";
            var strClienteRecetaEnLineaNombre = "<%= strClienteRecetaEnLineaNombre%>";

            if (cboEstado.selectedIndex > 0) {
                cboCiudad.selectedIndex = 0;
                document.forms[0].action = "<%= strFormAction %>" +
                                           "?habilitarCboCiudad=true" +
                                           "&strCadenaId="+ cboCadena +
                                           "&strClienteABFId=" + strClienteABFId +
                                           "&strClienteRecetaEnLineaNombre=" + strClienteRecetaEnLineaNombre;

                document.forms[0].submit();
            }
            else {
                cboCiudad.selectedIndex = 0;
                cboCiudad.disabled = true;

                cboSucursal.selectedIndex = 0;
                cboSucursal.disabled = true;
            }
            return (true);
        }

        function cboCiudad_onchange() {
            var cboCadena = document.getElementById("cboCadena").value;
            var cboCiudad = document.getElementById("cboCiudad");
            var cboSucursal = document.getElementById("cboSucursal");
            var strClienteABFId = "<%= strClienteABFId%>";
            var strClienteRecetaEnLineaNombre = "<%= strClienteRecetaEnLineaNombre%>";

            if (cboCiudad.selectedIndex > 0) {
                cboSucursal.selectedIndex = 0;
                document.forms[0].action = "<%= strFormAction %>" +
                                           "?habilitarCboCiudad=true" +
                                           "&habilitarCboSucursal=true" +
                                           "&strCadenaId=" + cboCadena +
                                           "&strClienteABFId=" + strClienteABFId +
                                           "&strClienteRecetaEnLineaNombre=" + strClienteRecetaEnLineaNombre;
                document.forms[0].submit();
            }
            else {
                cboSucursal.selectedIndex = 0;
                cboSucursal.disabled = true;
            }
            return (true);
        }

        function btnCerrarVentana_onclick() {
            var strClienteABFId = "<%= strClienteABFId%>";
            var strClienteRecetaEnLineaNombre = "<%= strClienteRecetaEnLineaNombre%>";

            window.open("popSistemaConsultarSucursalesClientesRecetaEnLinea.aspx?" +
                        "&strClienteABFId=" + strClienteABFId +
                        "&strClienteRecetaEnLineaNombre=" + strClienteRecetaEnLineaNombre,
                        "Pop", "width=800, height=600, left=150, top=30, resizable=no, scrollbars=yes, menubar=no, status=no");
        }

        function btnAsignarSucursales_onclick() {
            var cboCadena = document.getElementById("cboCadena").value;
            var cboEstado;
            var cboCiudad;
            var cboSucursal;
            var intCompaniaId;
            var intSucursalId;
            var strClienteABFId = "<%= strClienteABFId%>";
            var strClienteRecetaEnLineaNombre = "<%= strClienteRecetaEnLineaNombre%>";
            var confirmacion = true;

            if (cboCadena != "0") {
                 cboEstado = document.getElementById("cboEstado").value;
                 cboCiudad = document.getElementById("cboCiudad").value;
                 cboSucursal = document.getElementById("cboSucursal").value;

                 if(cboEstado == 0 && cboCiudad == 0 && cboSucursal == 0){
                     confirmacion = window.confirm("Al seleccionar todos los filtros de busqueda se eliminaran todas las sucursales previamente asignadas. ¿Desea asignar las sucursales?")  
                 }
                 
                 if(confirmacion){
                     intCompaniaId = obtenerIntCompaniaId(cboSucursal);
                     intSucursalId = obtenerIntSucursalId(cboSucursal);

                     document.forms[0].action = "<%= strFormAction %>" +
                                                "?strCmd2=Agregar" + 
                                                "&strClienteABFId=" + strClienteABFId +
                                                "&strClienteRecetaEnLineaNombre=" + strClienteRecetaEnLineaNombre;

                     document.forms[0].submit();
                 }
            }
            else {
                window.alert("Favor de seleccionar la Cadena.");
            }
        }

        function obtenerIntCompaniaId(cboSucursal) {
            var companiaSucursal;
            var intCompaniaId;

            companiaSucursal = cboSucursal.split('|');
            intCompaniaId = companiaSucursal[0];

            return intCompaniaId
        }

        function obtenerIntSucursalId(cboSucursal) {
            var companiaSucursal;
            var intSucursalId;

            companiaSucursal = cboSucursal.split('|');
            intSucursalId = companiaSucursal[1];

            return intSucursalId
        }

    </script>
</head>
<body onload="return window_onload()" >
    <form id="frmSucursales" action="about:blank" method="post">
        <table width="450" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="450" class="tdgeneralcontentpop">
                    <h2>Seleccionar Sucursal(es)</h2>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td class="tdtexttablebold" width="30%">* Cadena:</td>
                            <td class="tdpadleft5" width="70%">
                                <select name="cboCadena" class="field" id="cboCadena" >
                                    <option value="0" selected></option>
                                    <option value="1">FARMACIAS BENAVIDES S.A.B. DE C.V.</option>
                                    <option value="2">FARMACIAS ABC DE MEXICO S.A. DE C.V.</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">* Estado:</td>
                            <td class="tdpadleft5" width="70%">
                                <select name="cboEstado" class="field" id="cboEstado" language="javascript" onchange="return cboEstado_onchange()">
                                    <option value="0" selected>--- Todos ---</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">* Ciudad:</td>
                            <td class="tdpadleft5" width="70%">
                                <select name="cboCiudad" class="field" id="cboCiudad" onchange="return cboCiudad_onchange()" disabled="disabled">
                                    <option value="0" selected>--- Todas ---</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="30%">* Sucursal:</td>
                            <td class="tdpadleft5" width="70%">
                                <select name="cboSucursal" class="field" id="cboSucursal" disabled="disabled">
                                    <option value="0" selected>--- Todas ---</option>
                                </select>
                            </td>
                        </tr>
                    </table>
                    <br>
                    <input id="btnCerrarVentana" type="button" class="button" value="Cancelar" onclick="return btnCerrarVentana_onclick()">
                    <input id="btnAsignarSucursales" type="button" class="button" value="Asignar" onclick="return btnAsignarSucursales_onclick()">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>