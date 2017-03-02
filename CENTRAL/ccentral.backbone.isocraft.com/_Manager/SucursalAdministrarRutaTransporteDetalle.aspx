<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SucursalAdministrarRutaTransporteDetalle.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalAdministrarRutaTransporteDetalle" codePage="28592" %>
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
            var blnCambiarSucursalDeRutaAlGuardar = "<%= blnCambiarSucursalDeRutaAlGuardar%>";
            var blnCambiarSucursalDeRutaAlActualizar = "<%= blnCambiarSucursalDeRutaAlActualizar%>";

            mostrarMensajeGuardarActualizar();
            cargarDatosRutaTransporte();
            establecerEstadoSucursal();
            establecerEstadoFrecuencia();

            if (blnCambiarSucursalDeRutaAlGuardar == "True") {
                ReasignarRutaASucursalAlGuardar();
            }
            if (blnCambiarSucursalDeRutaAlActualizar == "True") {
                ReasignarRutaASucursalAlActualizar();
            }
        }

        function mostrarMensajeGuardarActualizar() {
            var valorMensajeGuardarActualizar = "<%= strJavascriptWindowOnLoadCommands %>";

            if (valorMensajeGuardarActualizar != "") {
                window.alert(valorMensajeGuardarActualizar);
            }
        }

        function ReasignarRutaASucursalAlGuardar() {
            var cambiarRuta = false;
            var intRutaTransportesSucursalIdReasignar;
            var intRutaTransportesIdReasignar;
            var strCentroLogisticoId;
            var strHoraEntrega;

            cambiarRuta = confirm("¿Desea cambiar de Ruta la Sucursal seleccionada?");

            if (cambiarRuta) {
                intRutaTransportesSucursalIdReasignar = "<%= intRutaTransportesSucursalIdReasignar%>";
                intRutaTransportesIdReasignar = "<%= intRutaTransportesIdReasignar%>";
                strCentroLogisticoId = "<%= strCentroLogisticoId%>";
                strHoraEntrega = "<%= strHoraEntrega%>";

                document.forms[0].action = "SucursalAdministrarRutaTransporteDetalle.aspx?strCmd2=ReasignarRutaASucursalAlGuardar" +
                                           "&intRutaTransportesSucursalIdReasignar=" + intRutaTransportesSucursalIdReasignar +
                                           "&intRutaTransportesIdReasignar=" + intRutaTransportesIdReasignar +
                                           "&strCentroLogisticoId=" + strCentroLogisticoId +
                                           "&strHoraEntrega=" + strHoraEntrega;
                document.forms(0).submit();
            }
        }

        function ReasignarRutaASucursalAlActualizar() {
            var cambiarRuta = false;
            var intRutaTransportesSucursalId;
            var intRutaTransportesId;
            var strCentroLogisticoId;
            var strHoraEntrega;
            var intRutaTransportesSucursalIdEliminar;

            cambiarRuta = confirm("¿Desea cambiar de Ruta la Sucursal seleccionada?");

            if (cambiarRuta) {
                intRutaTransportesSucursalId = "<%= intRutaTransportesSucursalId%>";
                intRutaTransportesId = "<%= intRutaTransportesId%>";
                strCentroLogisticoId = "<%= strCentroLogisticoId%>";
                strHoraEntrega = "<%= strHoraEntrega%>";
                intRutaTransportesSucursalIdEliminar = "<%= intRutaTransportesSucursalIdEliminar%>";

                document.forms[0].action = "SucursalAdministrarRutaTransporteDetalle.aspx?strCmd2=ReasignarRutaASucursalAlActualizar" +
                                           "&intRutaTransportesSucursalId=" + intRutaTransportesSucursalId +
                                           "&intRutaTransportesId=" + intRutaTransportesId +
                                           "&strCentroLogisticoId=" + strCentroLogisticoId +
                                           "&strHoraEntrega=" + strHoraEntrega +
                                           "&intRutaTransportesSucursalIdEliminar=" + intRutaTransportesSucursalIdEliminar;
                document.forms(0).submit();
            }
        }

        function cargarDatosRutaTransporte() {
            document.getElementById('Clave').innerHTML = "<%= strRutaTransportesClave%>";
            document.getElementById('Tipo').innerHTML = "<%= strRutaTransportesTipoNombre%>";
            document.getElementById('Destino').innerHTML = "<%= strDestinoNombre%>";
            document.getElementById('Proveedor').innerHTML = "<%= strProveedorNombre%>";
            document.getElementById('Tolerancia').innerHTML = "<%= intTolerancia%>";

            document.getElementById('hdnRutaTransportesId').value = "<%= intRutaTransportesId%>";
            document.getElementById('hdnRutaTransportesClave').value = "<%= strRutaTransportesClave%>";
            document.getElementById('hdnRutaTransportesTipoNombre').value = "<%= strRutaTransportesTipoNombre%>";
            document.getElementById('hdnDestinoNombre').value = "<%= strDestinoNombre%>";
            document.getElementById('hdnProveedorNombre').value = "<%= strProveedorNombre%>";
            document.getElementById('hdnTolerancia').value = "<%= intTolerancia%>";
        }

        function establecerEstadoSucursal() {
            var strCmd2;
            var intRutaTransportesSucursalId;
            var strCentroLogisticoId;

            strCmd2 = "<%= strCmd2%>";

            if (strCmd2 === "BorrarSucursal") {
                intRutaTransportesSucursalId = "<%= intRutaTransportesSucursalId%>";
                    strCentroLogisticoId = "<%= strCentroLogisticoId%>";

                    borrarRuta = confirm("¿Desea eliminar la Sucursal " + strCentroLogisticoId + "?");

                    if (borrarRuta) {
                        document.forms[0].action = "SucursalAdministrarRutaTransporteDetalle.aspx?strCmd2=EliminarSucursal" +
                                                   "&intRutaTransportesSucursalId=" + intRutaTransportesSucursalId +
                                                   "&strCentroLogisticoId=" + strCentroLogisticoId;

                        document.forms(0).submit();
                    }
                }
                else if (strCmd2 == "AgregarSucursal") {
                    document.getElementById('divSucursalNuevoEditar').style.display = 'inline';
                    document.getElementById("txtCentroLogisticoId").focus();
                }
                else if (strCmd2 == "ActualizarSucursal") {
                    document.getElementById('divSucursalNuevoEditar').style.display = 'inline';
                    document.getElementById("txtCentroLogisticoId").focus();
                    document.getElementById("txtCentroLogisticoId").value = "<%= strCentroLogisticoId%>";
                document.getElementById("txtHoraEntrega").value = "<%= strHoraEntrega%>";
            }
}

function btnRegresar_onclick() {
    window.location = "SucursalAdministrarRutaTransporte.aspx";
}

function btnNuevaSucursal_onclick() {
    document.forms[0].action = "SucursalAdministrarRutaTransporteDetalle.aspx?strCmd2=AgregarSucursal";
    document.forms[0].submit();
}

function btnCancelarSucursal_onclick() {
    document.getElementById('divSucursalNuevoEditar').style.display = 'none';
}

function btnGuardarSucursal_onclick() {
    var strCmd2;

    if (!validarCamposVaciosSucursal() && validarFormatoHoraEntrega()) {
        strCmd2 = "<%= strCmd2 %>";

        if (strCmd2 == "AgregarSucursal") {
            agregarSucursal();
        } else if (strCmd2 == "ActualizarSucursal") {
            actualizarSucursal();
        }
    }
    else {
        window.alert(mensajeError);
    }
}

function agregarSucursal() {
    var hdnRutaTransportesId;
    var txtCentroLogisticoId;
    var txtHoraEntrega;

    hdnRutaTransportesId = document.getElementById("hdnRutaTransportesId").value;
    txtCentroLogisticoId = document.getElementById("txtCentroLogisticoId").value;
    txtHoraEntrega = document.getElementById("txtHoraEntrega").value;

    document.forms[0].action = "SucursalAdministrarRutaTransporteDetalle.aspx?strCmd2=NuevoSucursal" +
                               "&intRutaTransportesId=" + hdnRutaTransportesId +
                               "&strCentroLogisticoId=" + txtCentroLogisticoId +
                               "&strHoraEntrega=" + txtHoraEntrega;

    document.forms(0).submit();
}

function actualizarSucursal() {
    var intRutaTransportesSucursalId;
    var txtCentroLogisticoId;
    var txtHoraEntrega;

    intRutaTransportesSucursalId = "<%= intRutaTransportesSucursalId%>";
    txtCentroLogisticoId = document.getElementById("txtCentroLogisticoId").value;
    txtHoraEntrega = document.getElementById("txtHoraEntrega").value;

    document.forms[0].action = "SucursalAdministrarRutaTransporteDetalle.aspx?strCmd2=EditarSucursal" +
                               "&intRutaTransportesSucursalId=" + intRutaTransportesSucursalId +
                               "&strCentroLogisticoId=" + txtCentroLogisticoId +
                               "&strHoraEntrega=" + txtHoraEntrega;
    document.forms(0).submit();
}

function validarCamposVaciosSucursal() {
    var estaVacio = false;
    var txtCentroLogisticoId = document.getElementById("txtCentroLogisticoId").value;
    var txtHoraEntrega = document.getElementById("txtHoraEntrega").value;

    if (txtCentroLogisticoId == "" || txtHoraEntrega == "") {
        estaVacio = true;
        mensajeError = "Favor de capturar todos los campos.";
    }
    return estaVacio;
}

function validarFormatoHoraEntrega() {
    var esValido = false;
    var txtHoraEntrega = document.getElementById("txtHoraEntrega").value;

    esValido = /^([0-1][0-9]|2[0-3]):([0-5][0-9])$/.test(txtHoraEntrega);

    if (!esValido) {
        mensajeError = "Favor de capturar la hora con el formato correcto (24hrs).";
    }

    return esValido;
}

function btnNuevaFrecuencia_onclick() {
    document.forms[0].action = "SucursalAdministrarRutaTransporteDetalle.aspx?strCmd2=AgregarFrecuencia";
    document.forms[0].submit();
}

function establecerEstadoFrecuencia() {
    var strCmd2;
    var intRutaTransportesFrecuenciaId;
    var intFrecuencia;
    strCmd2 = "<%= strCmd2%>";


    if (strCmd2 == "BorrarFrecuencia") {
        intRutaTransportesFrecuenciaId = "<%= intRutaTransportesFrecuenciaId%>";
        intFrecuencia = "<%= intFrecuencia%>";

        borrarRuta = confirm("¿Desea eliminar la Frecuencia " + intFrecuencia + "?");

        if (borrarRuta) {
            document.forms[0].action = "SucursalAdministrarRutaTransporteDetalle.aspx?strCmd2=EliminarFrecuencia" +
                                       "&intRutaTransportesFrecuenciaId=" + intRutaTransportesFrecuenciaId +
                                       "&intFrecuencia=" + intFrecuencia;

            document.forms(0).submit();
        }
    }

    else if (strCmd2 == "AgregarFrecuencia") {
        document.getElementById('divFrecuenciaNuevoEditar').style.display = 'inline';
        document.getElementById("txtFrecuencia").focus();
    }
    else if (strCmd2 == "ActualizarFrecuencia") {
        document.getElementById('divFrecuenciaNuevoEditar').style.display = 'inline';
        document.getElementById("txtFrecuencia").focus();
        document.getElementById("txtFrecuencia").value = "<%= intFrecuencia%>";
        document.getElementById("cboSurtido").value = "<%= strRutaTransportesDiaSurtido%>";
        document.getElementById("cboEntrega").value = "<%= strRutaTransportesDiaEntrega%>";
    }
}

function btnCancelarFrecuencia_onclick() {
    document.getElementById('divFrecuenciaNuevoEditar').style.display = 'none';
}

function btnGuardarFrecuencia_onclick() {
    var strCmd2;

    if (!validarCamposVaciosFrecuencia()) {
        strCmd2 = "<%= strCmd2 %>";

        if (strCmd2 == "AgregarFrecuencia") {
            agregarFrecuencia();
        }
        else {
            actualizarFrecuencia();
        }
    }
    else {
        window.alert(mensajeError);
    }
}

function validarCamposVaciosFrecuencia() {
    var estaVacio = false;
    var txtFrecuencia = document.getElementById("txtFrecuencia").value;
    var cboSurtido = document.getElementById("cboSurtido").value;
    var cboEntrega = document.getElementById("cboEntrega").value;

    if (txtFrecuencia == "" || cboSurtido == -1 || cboEntrega == -1) {
        estaVacio = true;
        mensajeError = "Favor de capturar todos los campos.";
    }
    return estaVacio;
}

function agregarFrecuencia() {
    var hdnRutaTransportesId;
    var txtFrecuencia;
    var cboSurtido;
    var cboEntrega;

    hdnRutaTransportesId = document.getElementById("hdnRutaTransportesId").value;
    txtFrecuencia = document.getElementById("txtFrecuencia").value;
    cboSurtido = document.getElementById("cboSurtido").value;
    cboEntrega = document.getElementById("cboEntrega").value;

    document.forms[0].action = "SucursalAdministrarRutaTransporteDetalle.aspx?strCmd2=NuevoFrecuencia" +
                               "&intRutaTransportesId=" + hdnRutaTransportesId +
                               "&intFrecuencia=" + txtFrecuencia +
                               "&strRutaTransportesDiaSurtido=" + cboSurtido +
                               "&strRutaTransportesDiaEntrega=" + cboEntrega;

    document.forms(0).submit();
}

function actualizarFrecuencia() {
    var intRutaTransportesFrecuenciaId;
    var txtFrecuencia;
    var cboSurtido;
    var cboEntrega;

    intRutaTransportesFrecuenciaId = "<%= intRutaTransportesFrecuenciaId%>";
    txtFrecuencia = document.getElementById("txtFrecuencia").value;
    cboSurtido = document.getElementById("cboSurtido").value;
    cboEntrega = document.getElementById("cboEntrega").value;

    document.forms[0].action = "SucursalAdministrarRutaTransporteDetalle.aspx?strCmd2=EditarFrecuencia" +
                               "&intRutaTransportesFrecuenciaId=" + intRutaTransportesFrecuenciaId +
                               "&intFrecuencia=" + txtFrecuencia +
                               "&strRutaTransportesDiaSurtido=" + cboSurtido +
                               "&strRutaTransportesDiaEntrega=" + cboEntrega;

    document.forms(0).submit();
}


function soloNumerosHora(valor) {
    valor = (valor) ? valor : window.event;
    var esValido = true;
    var valorCodigo = (valor.which) ? valor.which : valor.keyCode;

    if (valorCodigo > 31 && (valorCodigo < 48 || valorCodigo > 58)) {
        esValido = false;
    }

    return esValido;
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
  <input type="hidden" value='<%=Request.Form("hdnRutaTransportesId")%>' id="hdnRutaTransportesId" name="hdnRutaTransportesId" />
  <input type="hidden" value='<%=Request.Form("hdnRutaTransportesClave")%>' id="hdnRutaTransportesClave" name="hdnRutaTransportesClave" />
  <input type="hidden" value='<%=Request.Form("hdnRutaTransportesTipoNombre")%>' id="hdnRutaTransportesTipoNombre" name="hdnRutaTransportesTipoNombre" />
  <input type="hidden" value='<%=Request.Form("hdnDestinoNombre")%>' id="hdnDestinoNombre" name="hdnDestinoNombre" />
  <input type="hidden" value='<%=Request.Form("hdnProveedorNombre")%>' id="hdnProveedorNombre" name="hdnProveedorNombre" />
  <input type="hidden" value='<%=Request.Form("hdnTolerancia")%>' id="hdnTolerancia" name="hdnTolerancia" />
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td class="tdgeneralcontent"> <table border="0" cellspacing="0" cellpadding="0" width="100%">
          <tr height="10"> 
            <td> <input type="button" id="btnRegresar" name="btnRegresar" class="boton" value="Regresar"
										onclick="btnRegresar_onclick()" /> </td>
          </tr>
          <tr height="30"> 
            <td></td>
          </tr>
          <tr> 
            <td> <span class="campotablaresultado">Ruta:</span> <span id="Clave" class="campotablaresultado"> 
              </span><span class="campotablaresultado" style="margin-left: 40px;">Distribución:</span> 
              <span id="Tipo" class="campotablaresultado"></span><span class="campotablaresultado" style="margin-left: 40px;"> 
              Destino:</span> <span id="Destino" class="campotablaresultado"></span><span class="campotablaresultado" style="margin-left: 40px;"> 
              Proveedor:</span> <span id="Proveedor" class="campotablaresultado"></span><span class="campotablaresultado" style="margin-left: 40px;"> 
              Tolerancia:</span> <span id="Tolerancia" class="campotablaresultado"></span> 
            </td>
          </tr>
          <tr height="20"> 
            <td></td>
          </tr>
          <tr height="50"> 
            <td class="tdbluebold12" align="left" valign="middle"> <div id="divFrecuenciaNuevoEditar" style="display: none; position: static"> 
                <input type="hidden" id="hdnRutaTransportesFrecuenciaId" name="hdnRutaTransportesFrecuenciaId"
											value="" />
                <span class="campotablaresultado">Frecuencia:</span> 
                <input id="txtFrecuencia" name="txtFrecuencia" class="field" maxlength="1" style="width: 80px"
											onkeypress="return soloNumeros(event)" />
                <span class="campotablaresultado">Surtido:</span> 
                <select id="cboSurtido" class="field">
                  <option value="-1">>> Elija día <<</option>
                  <option value="Diario">Diario</option>
                  <option value="Lunes">Lunes</option>
                  <option value="Martes">Martes</option>
                  <option value="Miércoles">Miércoles</option>
                  <option value="Jueves">Jueves</option>
                  <option value="Viernes">Viernes</option>
                  <option value="Sábado">Sabado</option>
                  <option value="Domingo">Domingo</option>
                </select>
                <span class="campotablaresultado">Entrega:</span> 
                <select id="cboEntrega" class="field">
                  <option value="-1">>> Elija día <<</option>
                  <option value="Diario">Diario</option>
                  <option value="Lunes">Lunes</option>
                  <option value="Martes">Martes</option>
                  <option value="Miércoles">Miércoles</option>
                  <option value="Jueves">Jueves</option>
                  <option value="Viernes">Viernes</option>
                  <option value="Sábado">Sabado</option>
                  <option value="Domingo">Domingo</option>
                </select>
                <input id="btnCancelarFrecuencia" class="button" onclick="return btnCancelarFrecuencia_onclick()"
											value="Cancelar" type="button" name="btnCancelarSucursal">
                <input id="btnGuardarFrecuencia" class="button" onclick="return btnGuardarFrecuencia_onclick()"
											value="Guardar" type="button" name="btnGuardarSucursal">
              </div></td>
          </tr>
          <tr align="right"> 
            <td> <input type="button" id="btnNuevaFrecuencia" name="btnNuevaFrecuencia" class="boton" value="Nuevo"
										onclick="btnNuevaFrecuencia_onclick()" /> 
            </td>
          </tr>
          <tr height="10"> 
            <td></td>
          </tr>
          <tr> 
            <td> <%= strObtenerFrecuencias()%> </td>
          </tr>
          <tr height="50"> 
            <td class="tdbluebold12" align="left" valign="middle"> <div id="divSucursalNuevoEditar" style="display: none; position: static"> 
                <input type="hidden" id="hdnRutaTransportesSucursalId" name="hdnRutaTransportesSucursalId"
											value="" />
                <span class="campotablaresultado">Sucursal:</span> 
                <input id="txtCentroLogisticoId" name="txtCentroLogisticoId" class="field" maxlength="15"
											style="width: 80px" />
                <span class="campotablaresultado">Hora Entrega:</span> 
                <input id="txtHoraEntrega" name="txtHoraEntrega" onkeypress="return soloNumerosHora(event)"
											class="field" maxlength="5" style="width: 80px" />
                <input id="btnCancelarSucursal" class="button" onclick="return btnCancelarSucursal_onclick()"
											value="Cancelar" type="button" name="btnCancelarSucursal">
                <input id="btnGuardarSucursal" class="button" onclick="return btnGuardarSucursal_onclick()"
											value="Guardar" type="button" name="btnGuardarSucursal">
              </div></td>
          </tr>
          <tr align="right"> 
            <td> <input type="button" id="btnNuevaSucursal" name="btnNuevaSucursal" class="boton" value="Nuevo"
										onclick="btnNuevaSucursal_onclick()" /> 
            </td>
          </tr>
          <tr height="10"> 
            <td></td>
          </tr>
          <tr> 
            <td> <%= strObtenerSucursales()%> </td>
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
