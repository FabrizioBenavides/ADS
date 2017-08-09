<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SucursalAdministrarRutaTransporte.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalAdministrarRutaTransporte" codePage="28592" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>Benavides : Administrar Rutas para Transporte</title>
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
        var mensajeError;

        function window_onload() {
            mostrarMensajeGuardarActualizar();
            establecerEstado();
        }

        function mostrarMensajeGuardarActualizar() {
            var valorMensajeGuardarActualizar = "<%= strJavascriptWindowOnLoadCommands %>";

            if (valorMensajeGuardarActualizar !== "") {
                <%= strJavascriptWindowOnLoadCommands %>;
                window.location.href = "SucursalAdministrarRutaTransporte.aspx";
            }
        }

        function establecerEstado() {
            var strCmd2;
            var intRutaTransportesId;
            var strRutaTransportesClave;
            var intFrecuencia;
            var borrarRuta = false;

            strCmd2 = "<%= strCmd2%>";

            if (strCmd2 === "Borrar") {
                intRutaTransportesId = "<%= intRutaTransportesId%>";
                strRutaTransportesClave = "<%= strRutaTransportesClave%>";

                borrarRuta = confirm("¿Desea eliminar la Ruta " + strRutaTransportesClave + " ?");

                if (borrarRuta) {
                    document.forms[0].action = "SucursalAdministrarRutaTransporte.aspx?strCmd2=Eliminar" +
                                               "&intRutaTransportesId=" + intRutaTransportesId +
                                               "&strRutaTransportesClave=" + strRutaTransportesClave;
                    document.forms(0).submit();
                }
                else {
                    window.location.href = "SucursalAdministrarRutaTransporte.aspx";
                }

            } else if (strCmd2 === "Agregar") {
                document.getElementById(' divCamposNuevoEditar').style.display = 'inline';
                document.getElementById('divCamposFiltro').style.display = 'none';
                document.getElementById('txtRutaTransportesClaveNuevo').focus();
            }
            else if (strCmd2 === "Actualizar") {
                document.getElementById(' divCamposNuevoEditar').style.display = 'inline';
                document.getElementById('divCamposFiltro').style.display = 'none';
                document.getElementById("hdnRutaTransportesId").value = "<%= intRutaTransportesId%>";
                document.getElementById("txtRutaTransportesClaveNuevo").value = "<%= strRutaTransportesClave%>";
                document.getElementById("cboRutaTransportesTipoIdNuevo").value = "<%= intRutaTransportesTipoId%>";
                document.getElementById("cboRutaTransportesDestinoNuevo").value = "<%= intDestinoId%>";
                document.getElementById("cboRutaTransportesProveedorNuevo").value = "<%= intProveedorId%>";
                document.getElementById("txtTolerancia").value = "<%= intTolerancia%>";
            }
}

function btnNuevaRuta_onclick() {
    document.forms[0].action = "SucursalAdministrarRutaTransporte.aspx?strCmd2=Agregar";
    document.forms[0].submit();
}

function btnCancelarRuta_onclick() {
    document.getElementById('divCamposFiltro').style.display = 'inline';
    window.location.href = "SucursalAdministrarRutaTransporte.aspx";
}

function btnGuardarRuta_onclick() {
    var strCmd2;

    if (!validarCamposVaciosRuta()) {
        strCmd2 = "<%= strCmd2 %>";

        if (strCmd2 == "Agregar") {
            agregarRuta();
        } else if (strCmd2 === "Actualizar") {
            actualizarRuta();
        }
    }
    else {
        window.alert(mensajeError);
    }
}

function btnBuscarRuta_onclick() {
    document.forms[0].action = "<%=strFormAction%>";
    document.forms[0].submit();
}

function agregarRuta() {
    var txtRutaTransportesClaveNuevo;
    var cboRutaTransportesTipoIdNuevo;
    var cboRutaTransportesDestinoNuevo;
    var cboRutaTransportesProveedorNuevo;
    var txtTolerancia;

    txtRutaTransportesClaveNuevo = document.getElementById("txtRutaTransportesClaveNuevo").value;
    cboRutaTransportesTipoIdNuevo = document.getElementById("cboRutaTransportesTipoIdNuevo").value;
    cboRutaTransportesDestinoNuevo = document.getElementById("cboRutaTransportesDestinoNuevo").value;
    cboRutaTransportesProveedorNuevo = document.getElementById("cboRutaTransportesProveedorNuevo").value;
    txtTolerancia = document.getElementById("txtTolerancia").value;

    document.forms[0].action = "SucursalAdministrarRutaTransporte.aspx?strCmd2=Nuevo" +
                               "&strRutaTransportesClave=" + txtRutaTransportesClaveNuevo +
                               "&intRutaTransportesTipoId=" + cboRutaTransportesTipoIdNuevo +
                               "&intDestinoId=" + cboRutaTransportesDestinoNuevo +
                               "&intProveedorId=" + cboRutaTransportesProveedorNuevo +
                               "&intTolerancia=" + txtTolerancia;

    document.forms(0).submit();
}

function actualizarRuta() {
    var hdnRutaTransportesId;
    var txtRutaTransportesClaveNuevo;
    var cboRutaTransportesTipoIdNuevo;
    var cboRutaTransportesDestinoNuevo;
    var cboRutaTransportesProveedorNuevo;
    var txtTolerancia;

    hdnRutaTransportesId = document.getElementById("hdnRutaTransportesId").value;
    txtRutaTransportesClaveNuevo = document.getElementById("txtRutaTransportesClaveNuevo").value;
    cboRutaTransportesTipoIdNuevo = document.getElementById("cboRutaTransportesTipoIdNuevo").value;
    cboRutaTransportesDestinoNuevo = document.getElementById("cboRutaTransportesDestinoNuevo").value;
    cboRutaTransportesProveedorNuevo = document.getElementById("cboRutaTransportesProveedorNuevo").value;
    txtTolerancia = document.getElementById("txtTolerancia").value;

    document.forms[0].action = "SucursalAdministrarRutaTransporte.aspx?strCmd2=Editar" +
                               "&intRutaTransportesId=" + hdnRutaTransportesId +
                               "&strRutaTransportesClave=" + txtRutaTransportesClaveNuevo +
                               "&intRutaTransportesTipoId=" + cboRutaTransportesTipoIdNuevo +
                               "&intDestinoId=" + cboRutaTransportesDestinoNuevo +
                               "&intProveedorId=" + cboRutaTransportesProveedorNuevo +
                               "&intTolerancia=" + txtTolerancia;
    document.forms(0).submit();
}

function validarCamposVaciosRuta() {
    var estaVacio = false;
    var txtRutaTransportesClaveNuevo = document.getElementById("txtRutaTransportesClaveNuevo").value;
    var cboRutaTransportesTipoIdNuevo = document.getElementById("cboRutaTransportesTipoIdNuevo").value;
    var cboRutaTransportesDestinoNuevo = document.getElementById("cboRutaTransportesDestinoNuevo").value;
    var cboRutaTransportesProveedorNuevo = document.getElementById("cboRutaTransportesProveedorNuevo").value;
    var txtTolerancia = document.getElementById("txtTolerancia").value;

    if (txtRutaTransportesClaveNuevo == "" || cboRutaTransportesTipoIdNuevo == -1 ||
        cboRutaTransportesDestinoNuevo == -1 || cboRutaTransportesProveedorNuevo == -1 ||
        txtTolerancia == "") {
        estaVacio = true;
        mensajeError = "Favor de capturar todos los campos.";
    }
    return estaVacio;
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

new menu(MENU_ITEMS, MENU_POS);
    </script>
</head>
<body onload="return window_onload()">
<form id="frmPrincipal" runat="server">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td> <script type="text/javascript">crearTablaHeader()</script> </td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : <a href="../_Manager/SucursalHome.aspx">Sucursal</a> 
        : Rutas para Transporte : Administrar Rutas para Transporte </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td class="tdgeneralcontent"> <table border="0" cellspacing="0" cellpadding="0" width="100%">
          <tr height="40"> 
            <td colspan="2"> <h1>Administrar Rutas para Transporte</h1>
              <p> Catálogo de Rutas, Frecuencias y Sucursales. </p>
              <h2>Administrar Rutas para Transporte</h2></td>
          </tr>
          <tr height="30"> 
            <td width="100%"> <div id="divCamposFiltro"> <span class="campotablaresultado">Ruta:</span> 
                <input id="txtRutaClaveFiltro" name="txtRutaClaveFiltro" class="field" maxlength="50" style="width: 125px" />
                <span class="campotablaresultado">Distribución:</span> 
                <select id="cboRutaTransportesTipoIdFiltro" name="cboRutaTransportesTipoIdFiltro" class="field" style="width: 125px">
                  <option value="-1">>> Elija tipo <<</option>
                  <option value="1">Foranea</option>
                  <option value="2">Local</option>
                  <option value="3">Regional</option>
                </select>
                <br />
                <br />
                <span class="campotablaresultado">Destino:</span> 
                <select id="cboRutaTransportesDestinoFiltro" name="cboRutaTransportesDestinoFiltro" class="field" style="width: 125px">
                  <option value="-1">>> Elija destino <<</option>
                  <%= LLenarControlDestino()%> 
                </select>
                <span class="campotablaresultado">Proveedor:</span> 
                <select id="cboRutaTransportesProveedorFiltro" name="cboRutaTransportesProveedorFiltro" class="field" style="width: 125px">
                  <option value="-1">>> Elija proveedor <<</option>
                  <%= LLenarControlProveedor()%> 
                </select>
                <input id="btnBuscarRuta" name="btnBuscarRuta"
                                        class="button" value="Buscar" type="button" onclick="btnBuscarRuta_onclick()" />
                <input id="btnNuevaRuta" name="btnNuevaRuta"
                                        class="button" value="Nuevo" type="button" onclick="return btnNuevaRuta_onclick()" />
              </div></td>
          </tr>
          <tr height="30"> </tr>
          <tr height="60"> 
            <td class="tdbluebold12" align="left" valign="middle"> <div id=" divCamposNuevoEditar" style="display: none"> 
                <div> 
                  <input type="hidden" id="hdnRutaTransportesId" name="hdnRutaTransportesId" value="" style="width: 125px" />
                  <span class="campotablaresultado">Ruta:</span> 
                  <input id="txtRutaTransportesClaveNuevo" name="txtRutaTransportesClaveNuevo" class="field" maxlength="15" style="width: 125px" />
                  <span class="campotablaresultado">Distribución:</span> 
                  <select id="cboRutaTransportesTipoIdNuevo" class="field" style="width: 125px">
                    <option value="-1">>> Elija tipo <<</option>
                    <option value="1">Foranea</option>
                    <option value="2">Local</option>
                    <option value="3">Regional</option>
                  </select>
                  <br />
                  <br />
                  <span class="campotablaresultado">Destino:</span> 
                  <select id="cboRutaTransportesDestinoNuevo" name="cboRutaTransportesDestinoNuevo" class="field" style="width: 125px">
                    <option value="-1">>> Elija destino <<</option>
                    <%= ControlDestino()%> 
                  </select>
                  <span class="campotablaresultado">Proveedor:</span> 
                  <select id="cboRutaTransportesProveedorNuevo" name="cboRutaTransportesProveedorNuevo" class="field" style="width: 125px">
                    <option value="-1">>> Elija proveedor <<</option>
                    <%= ControlProveedor()%> 
                  </select>
                  <span class="campotablaresultado">Tolerancia:</span> 
                  <input id="txtTolerancia" name="txtTolerancia" class="field" maxlength="3" style="width: 125px" onkeypress="return soloNumeros(event)" />
                  <input id="btnCancelarRuta" class="button" onclick="return btnCancelarRuta_onclick()"
                                            value="Cancelar" type="button" name="btnCancelarRuta">
                  <input id="btnGuardarRuta" class="button" onclick="return btnGuardarRuta_onclick()"
                                            value="Guardar" type="button" name="btnGuardarRuta">
                </div>
              </div></td>
          </tr>
          <tr height="20"> </tr>
          <tr> 
            <td colspan="2"> <%= strObtenerRutaTransportes()%> </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td> <script type="text/javascript">crearTablaFooterCentral()</script> </td>
    </tr>
  </table>
</form>
</body>
</html>
