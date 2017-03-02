<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VentasCapreDescuentoProducto.aspx.vb" Inherits="com.isocraft.backbone.ccentral.VentasCapreDescuentoProducto" CodePage="28592" EnableViewState="true" EnableSessionState="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html>
<head>
    <title>Benavides : CAPRE por Producto</title>
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
            var strArticuloId;
            var borrarProducto = false;

            strCmd2 = "<%= strCmd2%>";

            if (strCmd2 === "BorrarSingular") {
                strArticuloId = "<%= strArticuloId%>";

                borrarProducto = confirm("¿Desea eliminar el producto " + strArticuloId + " ?");

                if (borrarProducto) {
                    document.forms[0].action = "VentasCapreDescuentoProducto.aspx?strCmd2=EliminarRegistroSingularCapreMaximoArticulo" +
                                               "&strArticuloId=" + strArticuloId;
                    document.forms(0).submit();
                }
                else {
                    window.location.href = "VentasCapreDescuentoProducto.aspx";
                }

            } else if (strCmd2 == "AgregarSingular") {
                document.getElementById('divCamposNuevoEditar').style.display = 'inline';
                document.getElementById("txtCodigo").focus();
            }
            else if (strCmd2 == "ActualizarSingular") {
                document.getElementById("txtDescuento").focus();
                document.getElementById('divCamposNuevoEditar').style.display = 'inline';
                document.getElementById("hdnArticuloId").value = "<%= strArticuloId%>";
                document.getElementById("txtCodigo").value = "<%= strArticuloId%>";
                document.getElementById("txtDescuento").value = "<%= intCaprePorcentajeMaximo%>";
                document.getElementById('txtCodigo').disabled = true;
            }
        }

        function btnConsultarProducto_onclick() {
            document.forms[0].action = "VentasCapreDescuentoProducto.aspx?strCmd2=EsConsulta";
            document.forms(0).submit();
        }

        function btnAgregarProductos_onclick() {
            if (document.forms[0].elements["txtArchivo"].value.length < 1) {
                alert("Por favor especifique un valor para el campo \"Archivo\".");
                document.forms[0].elements["txtArchivo"].focus();
            }
            else {
                document.forms[0].action = "VentasCapreDescuentoProducto.aspx?strCmd2=Agregar";
                document.forms[0].submit();
            }
        }

        function btnReemplazarProductos_onclick() {
            if (document.forms[0].elements["txtArchivo"].value.length < 1) {
                alert("Por favor especifique un valor para el campo \"Archivo\".");
                document.forms[0].elements["txtArchivo"].focus();
            }
            else {
                if (confirm('¿Está seguro de reemplazar la lista de productos?')) {
                    if (confirm("La siguiente acción reemplazará la lista de productos. ¿Aun asi desea continuar?")) {
                        document.forms[0].action = "VentasCapreDescuentoProducto.aspx?strCmd2=Reemplazar";
                        document.forms[0].submit();
                    }
                }
            }
        }

        function btnEliminarProductos_onclick() {
            if (confirm('¿Está seguro de eliminar la lista de productos?')) {
                if (confirm("La siguiente acción eliminara la lista de productos. ¿Aun asi desea continuar?")) {
                    document.forms[0].action = "VentasCapreDescuentoProducto.aspx?strCmd2=Eliminar";
                    document.forms[0].submit();
                }
            }
        }

        function btnExportarProductos_onclick() {
            var concatenacionExportacion;
            var tablaReporte = document.getElementById('tablaProducto');
            var guardar;

            if (tablaReporte != null) {
                concatenacionExportacion = "<table border='2px'>";
                concatenacionExportacion = concatenacionExportacion + "<tr bgcolor='#87AFC6'>";
                concatenacionExportacion = concatenacionExportacion + "<th>Código</th>";
                concatenacionExportacion = concatenacionExportacion + "<th>Nombre Producto</th>";
                concatenacionExportacion = concatenacionExportacion + "<th>Descuento(%)</th>";
                concatenacionExportacion = concatenacionExportacion + "</tr>";

                for (var i = 1, renglon; renglon = tablaReporte.rows[i]; i++) {

                    concatenacionExportacion = concatenacionExportacion + "<tr>";

                    for (var j = 0, columna; columna = renglon.cells[j]; j++) {
                        if (j < 3) {
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
                    guardar = iExportar.document.execCommand("SaveAs", true, "Descuento de Productos.xls");
                }
            }
        }

        function btnNuevoProducto_onclick() {
            document.forms[0].action = "VentasCapreDescuentoProducto.aspx?strCmd2=AgregarSingular";
            document.forms[0].submit();
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

        function btnCancelarProducto_onclick() {
            window.location.href = "VentasCapreDescuentoProducto.aspx";
        }

        function btnNuevoProducto_onclick() {
            document.forms[0].action = "VentasCapreDescuentoProducto.aspx?strCmd2=AgregarSingular";
            document.forms[0].submit();
        }

        function btnGuardarProducto_onclick() {
            var strCmd2;

            strCmd2 = "<%= strCmd2 %>";

            if (strCmd2 == "AgregarSingular") {
                agregarProducto();
            } else if (strCmd2 === "ActualizarSingular") {
                actualizarProducto();
            }
        }

        function agregarProducto() {
            var txtCodigo = document.getElementById("txtCodigo").value;
            var txtDescuento = document.getElementById("txtDescuento").value;
            
            if (txtCodigo != "" && txtDescuento != "") {

                if (txtDescuento >= 0 && txtDescuento < 101) {
                    document.forms[0].action = "VentasCapreDescuentoProducto.aspx?strCmd2=AgregarRegistroSingularCapreMaximoArticulo" +
                                               "&strArticuloId=" + txtCodigo +
                                               "&intCaprePorcentajeMaximo=" + txtDescuento;

                    document.forms[0].submit();
                }
                else {
                    window.alert("El descuento debe estar entre 0 y 100%.");
                }
            }
            else {
                window.alert("Favor de capturar el código del producto y/ó descuento.");
            }
        }

        function actualizarProducto() {
            var txtCodigo = document.getElementById("txtCodigo").value;
            var txtDescuento = document.getElementById("txtDescuento").value;

            if (txtDescuento != "") {

                if (txtDescuento >= 0 && txtDescuento < 101) {
                    document.forms[0].action = "VentasCapreDescuentoProducto.aspx?strCmd2=EditarRegistroSingularCapreMaximoArticulo" +
                                               "&strArticuloId=" + txtCodigo +
                                               "&intCaprePorcentajeMaximo=" + txtDescuento;
                    document.forms[0].submit();
                }
                else {
                    window.alert("El descuento debe estar entre 0 y 100%.");
                }
            }
            else {
                window.alert("Favor de capturar el descuento.");
            }
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
                    <a href="../_Manager/VentasHome.aspx">Ventas</a> : CAPRE por Producto
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                <h1>CAPRE por Producto</h1>
                                <p>
                                    Módulo para administrar descuentos por productos. Los productos
                                   que se encuentren en esta lista se les aplicará su respectivo porcentaje de descuento.
                                </p>
                                <p>
                                    <u>Agregar:</u> Guarda los registros obtenidos del archivo. Si el producto ya existe, lo reemplaza por el producto del archivo. 
                                    Si no existe, lo agrega a la lista.
                                </p>
                                <p>
                                    <u>Reemplazar:</u> Primero elimina todo los productos actuales y después guarda los productos que vienen del archivo.
                                </p>
                                <p>
                                    <u>Eliminar:</u> Elimina todos los productos actuales.
                                </p>
                                <p>
                                    <u>Exportar:</u> Manda la lista de productos actuales a un archivo de Excel.
                                </p>
                                <h2>Buscar por Producto</h2>
                                <input id="btnNuevoProducto" class="button" type="button" value="Nuevo" onclick="btnNuevoProducto_onclick()" style="margin-left: 700px;" />
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" width="50%">
                        <tr>
                            <td class="tdtexttablebold">Producto:</td>
                            <td class="tdpadleft5">
                                <input class="field" id="txtNombreProducto" type="text" autocomplete="off"
                                    maxlength="40" size="35" name="txtNombreProducto" />
                                <input id="btnConsultarProducto" class="button" onclick="return btnConsultarProducto_onclick()"
                                    value="Consultar" type="button" name="btnConsultarProducto">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">Archivo:</td>
                            <td class="tdpadleft5">
                                <input name="txtArchivo" id="txtArchivo" type="file" class="field" size="55" runat="server">
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr style="height: 80px;">
                            <td>
                                <input id="btnAgregarProductos" class="button" onclick="return btnAgregarProductos_onclick()"
                                    value="Agregar" type="button" name="btnAgregarProductos" title="Guarda los registros obtenidos del archivo. Si el producto ya existe, lo reemplaza por el producto del archivo. Si no existe, lo agrega a la lista.">
                                <input id="btnReemplazarProductos" class="button" onclick="return btnReemplazarProductos_onclick()"
                                    value="Reemplazar" type="button" name="btnReemplazarProductos" title="Primero elimina todo los productos actuales y después guarda los productos que vienen del archivo.">
                                <input id="btnEliminarProductos" class="button" onclick="return btnEliminarProductos_onclick()"
                                    value="Eliminar" type="button" name="btnEliminarProductos" title="Elimina todos los productos actuales.">
                                <input id="btnExportarProductos" class="button" onclick="return btnExportarProductos_onclick()"
                                    value="Exportar" type="button" name="btnExportarProductos" title="Manda la lista de productos actuales a un archivo de excel.">
                            </td>
                        </tr>
                        <tr height="80">
                            <td>
                                <div id="divCamposNuevoEditar" style="display: none">
                                    <input type="hidden" id="hdnArticuloId" name="hdnArticuloId" value="" />
                                    <span class="campotablaresultado">Código:</span>
                                    <input id="txtCodigo" name="txtCodigo" class="field" maxlength="10" style="width: 125px" onkeypress="return soloNumeros(event)" />
                                    <span class="campotablaresultado">Descuento(%):</span>
                                    <input id="txtDescuento" name="txtDescuento" class="field" maxlength="3" style="width: 125px" onkeypress="return soloNumeros(event)" />
                                    <input id="btnCancelarProducto" class="button" onclick="return btnCancelarProducto_onclick()"
                                        value="Cancelar" type="button" name="btnCancelarProducto">
                                    <input id="btnGuardarProducto" class="button" onclick="return btnGuardarProducto_onclick()"
                                        value="Guardar" type="button" name="btnGuardarProducto">
                                </div>
                            </td>
                        </tr>
                        
                        <tr>
                            <td><%= strObtenerProductos()%></td>
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
