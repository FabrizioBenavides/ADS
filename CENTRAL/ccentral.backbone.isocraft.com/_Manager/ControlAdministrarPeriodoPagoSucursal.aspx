<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAdministrarPeriodoPagoSucursal.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAdministrarPeriodoPagoSucursal" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html>
<head>
    <title>Benavides: Administrar Periodo de Pago Sucursal</title>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
    <link rel="stylesheet" type="text/css" href="css/menu.css">
    <link rel="stylesheet" type="text/css" href="css/estilo.css">
    <script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
    <%--<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>--%>

    <script id="clientEventHandlersJS" language="javascript">

        var strUsuarioNombre = "<%= strUsuarioNombre%>";
        var strFechaHora = "<%= strHTMLFechaHora %>";
        var mensajeError;

        function window_onload() {
            cargarControles();
            <%= strJavascriptWindowOnLoadCommands %>
        }

        function cargarControles() {
            var tipoDescripcion = { "SGBE": "SGBE", "SOBE": "SOBE" };
            var periodoNomina = { 1: "Quincena", 2: "Semana" };
            var strCompania;
            var strCEconomId;

            document.forms[0].elements["txtBuscarSucursal"].value = "<%=strBuscarSucursal%>";
            strCmd = "<%= strCmd %>";

            if (strCmd == "Actualizar") {
                document.getElementById('lblCentroLogisticoId').innerHTML = "<%= strCentroLogisticoId%>";
                document.getElementById('lblCompaniaId').innerHTML = "<%= intCompaniaId%>";
                document.getElementById('lblSucursalId').innerHTML = "<%= intSucursalId%>";
                document.getElementById('lblSucursal').innerHTML = "<%= strSucursalNombre%>";
                strCEconomId = "<%= strCEconomId%>";

                if (strCEconomId == "") {
                    document.getElementById('txtCEconomId').value = generarCodigoDescripcion();
                }
                else {
                    document.getElementById('txtCEconomId').value = strCEconomId;
                }

                strCompania = "<%= strCompania%>";
                if (strCompania == tipoDescripcion["SGBE"]) {
                    document.getElementById('cboDescripcion').value = tipoDescripcion["SGBE"];
                }
                else if (strCompania == tipoDescripcion["SOBE"]) {
                    document.getElementById('cboDescripcion').value = tipoDescripcion["SOBE"];
                }

                intPeriodoNominaId = "<%= intPeriodoNominaId%>";
                if (intPeriodoNominaId == periodoNomina[1]) {
                    document.getElementById('cboPeriodoNomina').value = 1;
                }
                else if (intPeriodoNominaId == periodoNomina[2]) {
                    document.getElementById('cboPeriodoNomina').value = 2;
                }
            }
            else {
                document.getElementById('divCamposEditar').style.display = 'none';
                document.getElementById('divBotonesCancelarGuardar').style.display = 'none';
            }
        }

        function cmdBuscarSucursal_onclick() {
            document.forms[0].action = "<%=strFormAction%>";
            document.forms[0].submit();
        }

        function cmdGuardar_onclick() {
            var strCmd = "";
            var strCentroLogisticoId;
            var intCompaniaId;
            var intSucursalId;
            var strCEconomId;
            var strCompania;
            var intPeriodoNominaId;

            strCmd = "<%= strCmd %>";
            strCentroLogisticoId = document.getElementById('lblCentroLogisticoId').innerHTML;
            intCompaniaId = document.getElementById('lblCompaniaId').innerHTML;
            intSucursalId = document.getElementById('lblSucursalId').innerHTML;
            strCEconomId = document.getElementById('txtCEconomId').value;
            strCompania = document.getElementById('cboDescripcion').value;
            intPeriodoNominaId = document.getElementById('cboPeriodoNomina').value;

            if (validarCamposVacios(mensajeError)) {

                if (strCmd == "Actualizar") {
                    document.forms[0].action = "ControlAdministrarPeriodoPagoSucursal.aspx?strCmd=Editar" +
                                               "&strCentroLogisticoId=" + strCentroLogisticoId +
                                               "&intCompaniaId=" + intCompaniaId +
                                               "&intSucursalId=" + intSucursalId +
                                               "&strCEconomId=" + strCEconomId +
                                               "&strCompania=" + strCompania +
                                               "&intPeriodoNominaId=" + intPeriodoNominaId;

                    document.forms(0).submit();
                }
            }
            else {
                window.alert(mensajeError);
            }
        }

        function cmdCancelar_onclick() {
            window.location.href = "ControlAdministrarPeriodoPagoSucursal.aspx";
        }

        function validarCamposVacios() {
            var esValido = true;
            var strCEconomId = document.getElementById('txtCEconomId').value;
            var strCompania = document.getElementById('cboDescripcion').value;
            var intPeriodoNominaId = document.getElementById('cboPeriodoNomina').value;

            if (strCEconomId == "" || strCompania == -1 || intPeriodoNominaId == -1) {
                esValido = false;
                mensajeError = "Favor de capturar todos los campos.";
            }

            if (strCEconomId.length < 8) {
                esValido = false;
                mensajeError = "La descripción debe ser de 8 digitos.";
            }

            return esValido;
        }

        function generarCodigoDescripcion() {
            var resultadoCodigo = "";
            var prefijo;
            var pad;
            var strCentroLogisticoId = document.getElementById('lblCentroLogisticoId').innerHTML;
            var primerLetra = strCentroLogisticoId.charAt(0);
            var soloDigitos = strCentroLogisticoId.match(/\d+/)[0]; 
            var cadena = "" + soloDigitos;
            var resultadoPad;

            switch (primerLetra) {
                case "M":
                    prefijo = "203L";
                    pad = "0000";
                    resultadoPad = pad.substring(0, pad.length - cadena.length) + cadena;
                    resultadoCodigo = prefijo + resultadoPad;
                    break;
                case "N":
                    prefijo = "203L";
                    pad = "1000";
                    resultadoPad = pad.substring(0, pad.length - cadena.length) + cadena;
                    resultadoCodigo = prefijo + resultadoPad;
                    break;
                case "X":
                    prefijo = "208L";
                    pad = "0000";
                    resultadoPad = pad.substring(0, pad.length - cadena.length) + cadena;
                    resultadoCodigo = prefijo + resultadoPad;
                    break;
            }

            return resultadoCodigo;
        }

    </script>
    <style type="text/css">
      
        .Etiqueta {
            font-size: 10px;
            font-weight: bold;
            color: #575757;
            height: 27px;
            font-family:Verdana, Arial, Helvetica, sans-serif;
        }
    </style>
</head>

<body language="javascript" onload="return window_onload()">
</body>

<form method="post" name="frmPage" action="about:blank">
    <table border="0" cellspacing="0" cellpadding="0" width="780">
        <tr>
            <td>
                <script language="JavaScript">crearTablaHeader()</script>
            </td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="780">
        <tr>
            <td width="10">&nbsp;</td>
            <td class="tdtab" width="770">Está en : <a href="SucursalHome.aspx">Sucursal</a>
                : Control de Asistencias
                : Administrar Periodo de Pago Sucursal</td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="780">
        <tr>
            <td class="tdgeneralcontent">
                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tr height="20">
                        <td colspan="2">
                            <h1>Administrar Periodo de Pago Sucursal</h1>
                        </td>
                    </tr>
                    <tr height="10">
                        <td class="tdtexttablebold" width="70%">Centro Logístico ó Sucursal: 
                            <input class="field" id="txtBuscarSucursal" type="text" autocomplete="off"
                                maxlength="5" size="45" name="txtBuscarSucursal"
                                value='<%=Request("strBuscarSucursal")%>'>
                        </td>
                        <td align="right" width="30%">
                            <input id="cmdBuscarSucursal" language="javascript" class="button"
                                onclick="return cmdBuscarSucursal_onclick()"
                                value="Buscar" type="button" name="cmdBuscarSucursal">
                        </td>
                    </tr>
                    <tr height="30">
                    </tr>
                    <tr height="60">
                        <td class="tdbluebold12" width="70%" align="left" valign="middle">
                            <div id="divCamposEditar">
                                <label id="lblCentroLogisticoId" class="tdbluebold12"></label>
                                &nbsp;&nbsp; 
                                <label id="lblCompaniaId" class="tdbluebold12"></label>
                                &nbsp;&nbsp; 
                                <label id="lblSucursalId" class="tdbluebold12"></label>
                                <label id="lblSucursal" class="tdbluebold12"></label>
                                &nbsp;&nbsp;
                                <br />
                                <br />
                                <span class="Etiqueta">Centro de Costo:</span>
                                <input id="txtCEconomId" name="txtCEconomId" class="field" maxlength="8" style="width: 110px" />
                                &nbsp;&nbsp;
                                <span class="Etiqueta">Descripción:</span>
                                <select id="cboDescripcion" name="cboDescripcion" class="field" style="width: 150px">
                                    <option value="-1">>> Elija una Descripción <<</option>
                                    <option value="SGBE">SGBE</option>
                                    <option value="SOBE">SOBE</option>
                                </select>
                                &nbsp;&nbsp;
                                <span class="Etiqueta">Periodo Nómina:</span>
                                <select id="cboPeriodoNomina" name="cboPeriodoNomina" class="field" style="width: 130px">
                                    <option value="-1">>> Elija un Periodo <<</option>
                                    <option value="1">Quincena</option>
                                    <option value="2">Semana</option>
                                </select>
                            </div>
                        </td>
                    </tr>
                    <tr height="20">
                        <td align="right" width="100%">
                            <div id="divBotonesCancelarGuardar">
                                <input id="cmdCancelar" language="javascript" class="button" onclick="return cmdCancelar_onclick()"
                                    value="Cancelar" type="button" name="cmdCancelar">
                                <input id="cmdGuardar" language="javascript" class="button" onclick="return cmdGuardar_onclick()"
                                    value=" Guardar" type="button" name="cmdGuardar">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><%= strObtenerSucursales()%> </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="780">
        <tr>
            <td>
                <script language="JavaScript">crearTablaFooterCentral()</script>
            </td>
        </tr>
    </table>
    <script language="JavaScript">
	<!--
    new menu(MENU_ITEMS, MENU_POS);
    //-->
    </script>
</form>
</html>
