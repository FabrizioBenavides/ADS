<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VentasCapreDescuentoRematadora.aspx.vb" Inherits="com.isocraft.backbone.ccentral.VentasCapreDescuentoRematadora" CodePage="28592" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html>
<head>
    <title>Benavides : Sucursales Rematadoras</title>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/menu.css" rel="stylesheet" type="text/css" />
    <link href="css/estilo.css" rel="stylesheet" type="text/css" />
    <script type="text/JavaScript" src="js/menu.js"></script>
    <script type="text/JavaScript" src="js/menu_items.js"></script>
    <script type="text/JavaScript" src="js/menu_tpl.js"></script>
    <script type="text/JavaScript" src="js/headerfooter.js"></script>
    <script type="text/javascript">

        strUsuarioNombre = "<%= strUsuarioNombre %>";
        strFechaHora = "<%= strHTMLFechaHora %>";

        function window_onload() {
            <%= strJavascriptWindowOnLoadCommands %>;
            establecerEstado();
        }

        function establecerEstado() {
            var strCmd2;
            var strCentroLogisticoId;
            var borrarSucursal = false;

            strCmd2 = "<%= strCmd2%>";

            if (strCmd2 == "BorrarSingular") {
                strCentroLogisticoId = "<%= strCentroLogisticoId%>";

                borrarSucursal = confirm("¿Desea eliminar la sucursal " + strCentroLogisticoId + " ?");

                if (borrarSucursal) {
                    document.forms[0].action = "VentasCapreDescuentoRematadora.aspx?strCmd2=EliminarRegistroSingularSucursalRematadora" +
                                               "&strCentroLogisticoId=" + strCentroLogisticoId;
                    document.forms(0).submit();
                }
                else {
                    window.location.href = "VentasCapreDescuentoRematadora.aspx";
                }

            } else if (strCmd2 == "AgregarSingular") {
                document.getElementById('divCamposNuevoEditar').style.display = 'inline';
                document.getElementById('txtLocalSap').focus();

            }
            else if (strCmd2 === "ActualizarSingular") {
                document.getElementById('divCamposNuevoEditar').style.display = 'inline';
                document.getElementById("hdnLocalSap").value = "<%= strCentroLogisticoId%>";
                document.getElementById("txtLocalSap").value = "<%= strCentroLogisticoId%>";
                document.getElementById("txtDescuento").value = "<%= fltCaprePorcentajeMaximo%>";

                document.getElementById("txtLocalSap").focus();
            }
        }

        function btnGuardarRematadora_onclick() {
            var strCmd2;

            if (!validarCamposVaciosSucursal()) {
                strCmd2 = "<%= strCmd2 %>";

                if (strCmd2 == "AgregarSingular") {
                    agregarSucursal();
                } else if (strCmd2 === "ActualizarSingular") {
                    actualizarSucursal();
                }
            }
            else {
                window.alert("Favor de capturar todos los campos.");
            }
        }

        function validarCamposVaciosSucursal() {
            var estaVacio = false;
            var txtLocalSap = document.getElementById("txtLocalSap").value;
            var txtDescuento = document.getElementById("txtDescuento").value;

            if (txtLocalSap == "" || txtDescuento == "") {
                estaVacio = true;
            }

            return estaVacio;
        }

        function agregarSucursal() {
            var txtLocalSap = document.getElementById("txtLocalSap").value;
            var txtDescuento = document.getElementById("txtDescuento").value;

            if (txtDescuento >= 0 && txtDescuento < 101) {
                document.forms[0].action = "VentasCapreDescuentoRematadora.aspx?strCmd2=AgregarRegistroSingularSucursalRematadora" +
                                           "&strCentroLogisticoId=" + txtLocalSap +
                                           "&fltCaprePorcentajeMaximo=" + txtDescuento;

                document.forms[0].submit();
            }
            else {
                window.alert("El descuento debe estar entre 0 y 100%");
            }
        }

        function actualizarSucursal() {
            var hdnLocalSap = document.getElementById("hdnLocalSap").value;
            var txtLocalSap = document.getElementById("txtLocalSap").value;
            var txtDescuento = document.getElementById("txtDescuento").value;

            if (txtDescuento >= 0 && txtDescuento < 101) {
                document.forms[0].action = "VentasCapreDescuentoRematadora.aspx?strCmd2=EditarRegistroSingularSucursalRematadora" +
                                           "&strCentroLogisticoId=" + hdnLocalSap +
                                           "&strCentroLogisticoIdValorNuevo=" + txtLocalSap +
                                           "&fltCaprePorcentajeMaximo=" + txtDescuento;

                document.forms[0].submit();
            }
            else {
                window.alert("El descuento debe estar entre 0 y 100%");
            }
        }

        function btnCancelarRematadora_onclick() {
            window.location.href = "VentasCapreDescuentoRematadora.aspx";
        }

        function soloNumeros(valor) {
            valor = (valor) ? valor : window.event;
            var esValido = true;
            var valorCodigo = (valor.which) ? valor.which : valor.keyCode;

            if (valorCodigo > 31 && (valorCodigo < 48 || valorCodigo > 57)) {
                esValido = false;
            }

            return esValido;
        }

        function btnAplicarDescuento_onclick() {
            var txtPorcentajePrecio = document.getElementById("txtPorcentajePrecio");

            if (txtPorcentajePrecio.value == "") {
                alert("Debe escribir una cantidad para aplicar el porcentaje.");
                txtPorcentajePrecio.focus();
            }
            else {

                if (txtPorcentajePrecio.value > 0 && txtPorcentajePrecio.value < 100) {
                    if (confirm('¿Esta seguro de aplicar el descuento a la lista de sucursales?')) {

                        document.forms[0].action = "VentasCapreDescuentoRematadora.aspx?strCmd2=Aplicar&" +
                                                   "fltCaprePorcentajeMaximo=" + txtPorcentajePrecio.value;
                        document.forms[0].submit();
                    }
                }
                else {
                    alert("Debe aplicar un porcentaje entre 0% y 100%");
                }
            }
        }

        function btnAgregarSucursales_onclick() {
            if (document.forms[0].elements["txtArchivo"].value.length < 1) {
                alert("Por favor especifique un valor para el campo \"Archivo\".");
                document.forms[0].elements["txtArchivo"].focus();
            }
            else {
                document.forms[0].action = "VentasCapreDescuentoRematadora.aspx?strCmd2=Agregar";
                document.forms[0].submit();
            }
        }

        function btnReemplazarSucursales_onclick() {
            if (document.forms[0].elements["txtArchivo"].value.length < 1) {
                alert("Por favor especifique un valor para el campo \"Archivo\".");
                document.forms[0].elements["txtArchivo"].focus();
            }
            else {
                if (confirm('¿Está seguro de reemplazar la lista de sucursales?')) {
                    if (confirm("La siguiente acción reemplazará la lista de sucursales. ¿Aun asi desea continuar?")) {
                        document.forms[0].action = "VentasCapreDescuentoRematadora.aspx?strCmd2=Reemplazar";
                        document.forms[0].submit();
                    }
                }
            }
        }

        function btnEliminarSucursales_onclick() {
            if (confirm('¿Está seguro de eliminar la lista de sucursales?')) {
                if (confirm("La siguiente acción eliminara la lista de sucursales. ¿Aun asi desea continuar?")) {
                    document.forms[0].action = "VentasCapreDescuentoRematadora.aspx?strCmd2=Eliminar";
                    document.forms[0].submit();
                }
            }
        }

        function btnExportarSucursales_onclick() {
            var concatenacionExportacion;
            var tablaReporte = document.getElementById('tablaSucursales');
            var guardar;

            if (tablaReporte != null) {
                concatenacionExportacion = "<table border='2px'>";
                concatenacionExportacion = concatenacionExportacion + "<tr bgcolor='#87AFC6'>";
                concatenacionExportacion = concatenacionExportacion + "<th>Local SAP</th>";
                concatenacionExportacion = concatenacionExportacion + "<th>CIA SUC</th>";
                concatenacionExportacion = concatenacionExportacion + "<th>Nombre Sucursal</th>";
                concatenacionExportacion = concatenacionExportacion + "<th>Región</th>";
                concatenacionExportacion = concatenacionExportacion + "<th>Zona</th>";
                concatenacionExportacion = concatenacionExportacion + "<th>Descuento(%)</th>";
                concatenacionExportacion = concatenacionExportacion + "</tr>";
      
                for (var i = 1, renglon; renglon = tablaReporte.rows[i]; i++) {
                    concatenacionExportacion = concatenacionExportacion + "<tr>";

                    for (var j = 0, columna; columna = renglon.cells[j]; j++) {

                        if (j < 6) {
                            concatenacionExportacion = concatenacionExportacion + "<td>" + columna.innerHTML + "</td>";
                        }
                    }

                    concatenacionExportacion = concatenacionExportacion + "</tr>";
                }

                concatenacionExportacion = concatenacionExportacion + "</table>";

                var ua = window.navigator.userAgent;
                var msie = ua.indexOf("MSIE");

                if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./)) {
                    iExportar.document.open("txt/html", "replace");
                    iExportar.document.write(concatenacionExportacion);
                    iExportar.document.close();
                    iExportar.focus();
                    guardar = iExportar.document.execCommand("SaveAs", true, "Sucursales Rematadoras.xls");
                }
            }
        }

        function btnNuevaSucursal_onclick() {
            document.forms[0].action = "VentasCapreDescuentoRematadora.aspx?strCmd2=AgregarSingular";
            document.forms[0].submit();
        }

        new menu(MENU_ITEMS, MENU_POS);
    </script>
</head>
<body onload="return window_onload()">
    <form id="frmPrincipal" action="about:blank" method="post" runat="server">
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <script type="text/javascript">crearTablaHeader()</script>
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="10">&nbsp;</td>
                <td width="770" class="tdtab">Est&aacute; en : 
                    <a href="../_Manager/VentasHome.aspx">Ventas</a> : 
                    Sucursales Rematadoras
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr height="40">
                            <td colspan="2">
                                <h1>Administrar Lista de Sucursales Rematadoras</h1>
                                <p>
                                    Módulo para administrar las sucursales que SOLO son de tipo rematadoras. Las sucursales
                                    que se encuentren en esta lista se les aplicará su respectivo procetaje de descuento.
                                </p>
                                <p>
                                    <u>Aplicar:</u> Aplica el descuento a todas las sucursales de la lista actual.
                                </p>
                                <p>
                                    <u>Agregar:</u> Guarda los registros obtenidos del archivo. Si la sucursal ya existe, lo reemplaza por la sucursal del archivo. Si no existe lo agrega a la lista.
                                </p>
                                <p>
                                    <u>Reemplazar:</u> Primero elimina todas las sucursales actuales y después guarda las sucursales que vienen del archivo.
                                </p>
                                <p>
                                    <u>Eliminar:</u> Elimina todas las sucursales actuales.
                                </p>
                                <p>
                                    <u>Exportar:</u> Manda la lista de sucursales actuales a un archivo de Excel.
                                </p>
                                <h2>Cambio de Precio</h2>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="70%">Porcentaje Máximo Cambio de Precio: 
                            <input class="field" id="txtPorcentajePrecio" type="text" autocomplete="off"
                                maxlength="5" size="5" name="txtPorcentajePrecio" value="50" onkeypress="return soloNumeros(event)" />
                                %
                                <input id="btnAplicarDescuento" class="button" onclick="return btnAplicarDescuento_onclick()"
                                    value="Aplicar" type="button" name="btnAplicarDescuento" title="Aplica el descuento a todas las sucursales de la lista.">
                                <input id="btnNuevaSucursal" class="button" type="button" value="Nuevo" onclick="btnNuevaSucursal_onclick()" style="margin-left: 370px;" />
                            </td>
                        </tr>
                        <tr style="height: 50px;">
                            <td class="tdtexttablebold">Archivo:
                                <input name="txtArchivo" id="txtArchivo" type="file" class="field" size="55" runat="server">
                            </td>
                        </tr>
                        <tr style="height: 50px;">
                            <td align="left">
                                <input id="btnAgregarSucursales" class="button" onclick="return btnAgregarSucursales_onclick()"
                                    value="Agregar" type="button" name="btnAgregarSucursales" title="Guarda los registros obtenidos del archivo. Si la sucursal ya existe, lo remplaza por la sucursal del archivo. Si no existe lo agrega a la lista.">
                                <input id="btnReemplazarSucursales" class="button" onclick="return btnReemplazarSucursales_onclick()"
                                    value="Reemplazar" type="button" name="btnReemplazarSucursales" title="Primero elimina todo las sucursales actuales y después guarda las sucursales que vienen del archivo.">
                                <input id="btnEliminarSucursales" class="button" onclick="return btnEliminarSucursales_onclick()"
                                    value="Eliminar" type="button" name="btnEliminarSucursales" title="Elimina todas las sucursales actuales.">
                                <input id="btnExportarSucursales" class="button" onclick="return btnExportarSucursales_onclick()"
                                    value="Exportar" type="button" name="btnExportarSucursales" title="Manda la lista de sucursales actuales a un archivo de excel.">
                            </td>
                        </tr>
                        <tr height="80">
                            <td>
                                <div id="divCamposNuevoEditar" style="display: none">
                                    <input type="hidden" id="hdnLocalSap" name="hdnLocalSap" value="" />
                                    <span class="campotablaresultado">Local SAP:</span>
                                    <input id="txtLocalSap" name="txtLocalSap" class="field" maxlength="5" style="width: 125px" />
                                    <span class="campotablaresultado">Descuento(%):</span>
                                    <input id="txtDescuento" name="txtDescuento" class="field" maxlength="3" style="width: 125px" onkeypress="return soloNumeros(event)" />
                                    <input id="btnCancelarRematadora" class="button" onclick="return btnCancelarRematadora_onclick()"
                                        value="Cancelar" type="button" name="btnCancelarRematadora">
                                    <input id="btnGuardarRematadora" class="button" onclick="return btnGuardarRematadora_onclick()"
                                        value="Guardar" type="button" name="btnGuardarRematadora">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td><%= strObtenerSucursalesRematadoras()%></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <iframe id="iExportar" style="display: none"></iframe>
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <script type="text/javascript">crearTablaFooterCentral()</script>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
