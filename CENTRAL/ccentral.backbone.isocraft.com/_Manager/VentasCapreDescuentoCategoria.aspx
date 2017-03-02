<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VentasCapreDescuentoCategoria.aspx.vb" Inherits="com.isocraft.backbone.ccentral.VentasCapreDescuentoCategoria" CodePage="28592" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html>
<head>
    <title>Benavides : CAPRE por Categoría</title>
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
            var intDivisionArticulosId;
            var intCategoriaArticulosId;
            var intCaprePorcentajeMaximo;
            var strClave;
            var cboCategoriaNuevoEditar;

            var borrarCategoria = false;

            strCmd2 = "<%= strCmd2%>";

            if (strCmd2 === "BorrarSingular") {

                intDivisionArticulosId = "<%= intDivisionArticulosId%>";
                intCategoriaArticulosId = "<%= intCategoriaArticulosId%>";
                strClave = "<%= strClave%>";

                borrarCategoria = confirm("¿Desea eliminar la categoría " + strClave + " ?");

                if (borrarCategoria) {
                    document.forms[0].action = "VentasCapreDescuentoCategoria.aspx?strCmd2=EliminarRegistroSingularCapreMaximoArticulo" +
                                               "&intDivisionArticulosId=" + intDivisionArticulosId +
                                               "&intCategoriaArticulosId=" + intCategoriaArticulosId;
                    document.forms(0).submit();
                }
                else {
                    window.location.href = "VentasCapreDescuentoCategoria.aspx";
                }

            } else if (strCmd2 == "AgregarSingular") {
                document.getElementById('divCamposNuevoEditar').style.display = 'inline';
                document.getElementById("cboDivisionNuevoEditar").value = "<%=intDivisionArticulosId%>";
              
            }
            else if (strCmd2 == "ActualizarSingular") {
                document.getElementById("txtDescuento").focus();
                document.getElementById('divCamposNuevoEditar').style.display = 'inline';
            
                document.getElementById("cboDivisionNuevoEditar").value = "<%=strDivisionArticulosNombreId%>";
                document.getElementById('cboDivisionNuevoEditar').disabled = true;

                cboCategoriaNuevoEditar = document.getElementById('cboCategoriaNuevoEditar');
                var opcionCategoria = document.createElement('option');
                cboCategoriaNuevoEditar.disabled = true
                opcionCategoria.selected = true;
                opcionCategoria.value = "<%=strCategoriaArticulosNombreId%>";;
                opcionCategoria.innerHTML = "<%=strCategoriaArticulosNombre%>"; 
                cboCategoriaNuevoEditar.appendChild(opcionCategoria);

                document.getElementById('txtDescuento').value = "<%=intCaprePorcentajeMaximo%>";
            }
        }

        function btnConsultarCategoria_onclick() {
            var cboDivision = document.getElementById("cboDivision").value;
            var txtCategoriaBuscar = document.getElementById("txtCategoriaBuscar").value;

            document.forms[0].action = "VentasCapreDescuentoCategoria.aspx?strCmd2=Consultar" +
                                       "&intDivisionArticulosIdFiltro=" + cboDivision +
                                       "&strCategoriaArticulosNombreFiltro=" + txtCategoriaBuscar;

            document.forms(0).submit();
        }

        function btnAgregarCategorias_onclick() {
            if (document.forms[0].elements["txtArchivo"].value.length < 1) {
                alert("Por favor especifique un valor para el campo \"Archivo\".");
                document.forms[0].elements["txtArchivo"].focus();
            }
            else {
                document.forms[0].action = "VentasCapreDescuentoCategoria.aspx?strCmd2=Agregar";
                document.forms[0].submit();
            }
        }

        function btnReemplazarCategorias_onclick() {
            if (document.forms[0].elements["txtArchivo"].value.length < 1) {
                alert("Por favor especifique un valor para el campo \"Archivo\".");
                document.forms[0].elements["txtArchivo"].focus();
            }
            else {
                if (confirm('¿Está seguro de reemplazar la lista de categorías?')) {
                    if (confirm("La siguiente acción reemplazará la lista de categorías. ¿Aun asi desea continuar?")) {
                        document.forms[0].action = "VentasCapreDescuentoCategoria.aspx?strCmd2=Reemplazar";
                        document.forms[0].submit();
                    }
                }
            }
        }

        function btnEliminarCategorias_onclick() {
            if (confirm('¿Está seguro de eliminar la lista de categorías?')) {
                if (confirm("La siguiente acción eliminara la lista de categorías. ¿Aun asi desea continuar?")) {
                    document.forms[0].action = "VentasCapreDescuentoCategoria.aspx?strCmd2=Eliminar";
                    document.forms[0].submit();
                }
            }
        }

        function btnExportarCategorias_onclick() {
            var concatenacionExportacion;
            var tablaReporte = document.getElementById('tablaCategoria');
            var guardar;

            if (tablaReporte != null) {
                concatenacionExportacion = "<table border='2px'>";
                concatenacionExportacion = concatenacionExportacion + "<tr bgcolor='#87AFC6'>";
                concatenacionExportacion = concatenacionExportacion + "<th>Clave</th>";
                concatenacionExportacion = concatenacionExportacion + "<th>Nombre Categoría</th>";
                concatenacionExportacion = concatenacionExportacion + "<th>Descuento(%)</th>";
                concatenacionExportacion = concatenacionExportacion + "</tr>";

                for (var i = 1, renglon; renglon = tablaReporte.rows[i]; i++) {
                    concatenacionExportacion = concatenacionExportacion + "<tr>";

                    for (var j = 2, columna; columna = renglon.cells[j]; j++) {
                        if (j < 5) {
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
                    guardar = iExportar.document.execCommand("SaveAs", true, "Descuento de Categorías.xls");
                }
            }
        }

        function btnNuevaCategoria_onclick() {
            document.forms[0].action = "VentasCapreDescuentoCategoria.aspx?strCmd2=AgregarSingular";
            document.forms[0].submit();
        }

        function btnCancelarCategoria_onclick() {
            window.location.href = "VentasCapreDescuentoCategoria.aspx";
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

        function cboDivisionNuevoEditar_onchange() {
            var cboDivisionNuevoEditar = document.getElementById("cboDivisionNuevoEditar");
            var intDivisionArticulosId = cboDivisionNuevoEditar.value;
            var valorSeleccionado = cboDivisionNuevoEditar.options[cboDivisionNuevoEditar.selectedIndex];

            document.getElementById("hdnIntDivisionArticulosId").value = valorSeleccionado.id;

            document.forms[0].action = "VentasCapreDescuentoCategoria.aspx?strCmd2=AgregarSingular" +
                                       "&intDivisionArticulosId=" + intDivisionArticulosId;

            document.forms[0].submit();
        }

        function btnGuardarCategoria_onclick() {
            var strCmd2;

            strCmd2 = "<%= strCmd2 %>";

            if (strCmd2 == "AgregarSingular") {
                agregarCategoria();
            } else if (strCmd2 === "ActualizarSingular") {
                actualizarCategoria();
            }
        }

        function agregarCategoria() {
            var cboDivisionNuevoEditar = document.getElementById("cboDivisionNuevoEditar").value;
            var cboCategoriaNuevoEditar = document.getElementById("cboCategoriaNuevoEditar").value;
            var txtDescuento = document.getElementById("txtDescuento").value;

            if (cboDivisionNuevoEditar != -1 && cboCategoriaNuevoEditar != -1 && txtDescuento != "") {

                if (txtDescuento >= 0 && txtDescuento < 101) {
                    document.forms[0].action = "VentasCapreDescuentoCategoria.aspx?strCmd2=AgregarRegistroSingularCapreMaximoArticulo" +
                                               "&strDivisionArticulosNombreId=" + cboDivisionNuevoEditar +
                                               "&strCategoriaArticulosNombreId=" + cboCategoriaNuevoEditar +
                                               "&intCaprePorcentajeMaximo=" + txtDescuento;

                    document.forms[0].submit();
                }
                else {
                    window.alert("El descuento debe estar entre 0 y 100%.");
                }
            }
            else {
                window.alert("Favor de capturar todos los campos.");
            }
        }

        function actualizarCategoria() {
            var cboDivisionNuevoEditar = document.getElementById("cboDivisionNuevoEditar").value;
            var cboCategoriaNuevoEditar = document.getElementById("cboCategoriaNuevoEditar").value;
            var txtDescuento = document.getElementById("txtDescuento").value;

            if (txtDescuento != "") {
                if (txtDescuento >= 0 && txtDescuento < 101) {
                    document.forms[0].action = "VentasCapreDescuentoCategoria.aspx?strCmd2=EditarRegistroSingularCapreMaximoArticulo" +
                                               "&strDivisionArticulosNombreId=" + cboDivisionNuevoEditar +
                                               "&strCategoriaArticulosNombreId=" + cboCategoriaNuevoEditar +
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
                    <a href="../_Manager/VentasHome.aspx">Ventas</a> : CAPRE por Categoría
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td>
                                <h1>CAPRE por Categoría</h1>
                                <p>
                                    Módulo para administrar descuentos por categoría de artículos. Las categorías
                                   que se encuentren en esta lista se les aplicará su respectivo porcentaje de descuento.
                                </p>
                                <p>
                                    <u>Agregar:</u> Guarda los registros obtenidos del archivo. Si la categoría ya existe, lo reemplaza por la categoría del archivo. 
                                    Si no existe, lo agrega a la lista.
                                </p>
                                <p>
                                    <u>Reemplazar:</u> Primero elimina todas las categorías actuales y después guarda las categorías que vienen del archivo.
                                </p>
                                <p>
                                    <u>Eliminar:</u> Elimina todas las categorías actuales.
                                </p>
                                <p>
                                    <u>Exportar:</u> Manda la lista de categorías actuales a un archivo de Excel.
                                </p>
                                <h2>Buscar por División y Categorías</h2>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input id="btnNuevaCategoria" class="button" type="button" value="Nuevo" onclick="btnNuevaCategoria_onclick()" style="margin-left: 650px;" />
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" width="50%">
                        <tr>
                            <td class="tdtexttablebold" style="width: 150px">División:</td>
                            <td class="tdpadleft5" style="width: 240px">
                                <select id="cboDivision" name="cboDivision"
                                    class="field" style="width: 136px">
                                    <option value="-1" selected="selected">Todas</option>
                                    <%= LLenarControlDivisionFiltro()%>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" style="width: 150px">Nombre Categoría:</td>
                            <td class="tdpadleft5" style="width: 240px">
                                <input class="field" id="txtCategoriaBuscar" type="text" autocomplete="off"
                                    maxlength="20" size="25" name="txtCategoria" />
                                <input id="btnConsultarCategoria" class="button" onclick="return btnConsultarCategoria_onclick()"
                                    value="Consultar" type="button" name="btnConsultarCategoria">
                            </td>
                        </tr>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr style="height: 50px;">
                            <td class="tdtexttablebold">Archivo:
                                <input name="txtArchivo" id="txtArchivo" type="file" class="field" size="55" runat="server">
                            </td>
                        </tr>
                        <tr style="height: 80px;">
                            <td>
                                <input id="btnAgregarCategorias" class="button" onclick="return btnAgregarCategorias_onclick()"
                                    value="Agregar" type="button" name="btnAgregarCategorias" title="Guarda los registros obtenidos del archivo. Si la sucursal ya existe, lo reemplaza por la categoría del archivo. Si no existe, lo agrega a la lista.">
                                <input id="btnReemplazarCategorias" class="button" onclick="return btnReemplazarCategorias_onclick()"
                                    value="Reemplazar" type="button" name="btnReemplazarCategorias" title="Primero elimina todo las categorías actuales y después guarda las categorías que vienen del archivo.">
                                <input id="btnEliminarCategorias" class="button" onclick="return btnEliminarCategorias_onclick()"
                                    value="Eliminar" type="button" name="btnEliminarCategorias" title="Elimina todas las categorías actuales.">
                                <input id="btnExportarCategorias" class="button" onclick="return btnExportarCategorias_onclick()"
                                    value="Exportar" type="button" name="btnExportarCategorias" title="Manda la lista de categorías actuales a un archivo de excel.">
                            </td>
                        </tr>
                        <tr height="80">
                            <td>
                                <div id="divCamposNuevoEditar" style="display: none">
                                    <input id="hdnIntDivisionArticulosId" name="hdnIntDivisionArticulosId" type="hidden" value=""  />
                                    <span class="campotablaresultado">División:</span>
                                    <select id="cboDivisionNuevoEditar" name="cboDivisionNuevoEditar" class="field" style="width: 136px" onchange="return cboDivisionNuevoEditar_onchange()">
                                        <option value="-1" selected="selected"></option>    
                                        <%= LLenarControlDivision()%>
                                    </select>
                                    <span class="campotablaresultado">Categoría:</span>
                                    <select id="cboCategoriaNuevoEditar" name="cboCategoriaNuevoEditar" class="field" style="width: 136px">
                                        <option value="-1" selected="selected"></option>    
                                        <%= LLenarControlCategoria()%>
                                    </select>
                                    <span class="campotablaresultado">Descuento(%):</span>
                                    <input id="txtDescuento" name="txtDescuento" class="field" maxlength="3" style="width: 50px" onkeypress="return soloNumeros(event)" />
                                    <input id="btnCancelarCategoria" class="button" onclick="return btnCancelarCategoria_onclick()"
                                        value="Cancelar" type="button" name="btnCancelarCategoria">
                                    <input id="btnGuardarCategoria" class="button" onclick="return btnGuardarCategoria_onclick()"
                                        value="Guardar" type="button" name="btnGuardarCategoria">
                                </div> 
                            </td>
                        </tr>
                        <tr>
                            <td><%= strObtenerCategorias()%></td>
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