<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" UICulture = "en" Culture="es-MX"  Explicit="True" Trace="False" Strict="True" CodeBehind="SucursalConfirmacionTransportes.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalConfirmacionTransportes"  codePage="28592" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD html 4.0 transitional//EN">
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" src="../static/scripts/cnfg.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">

        function window_onload() {
            mostrarMensajeGuardarActualizar();
        }

        function mostrarMensajeGuardarActualizar() {
            var valorMensajeGuardarActualizar = "<%= strJavascriptWindowOnLoadCommands %>";
            if (valorMensajeGuardarActualizar !== "") {
                window.alert(valorMensajeGuardarActualizar);
            }
        }

        function strGetCustomDateTime() {
            document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
            return (true);
        }

        function btnConsultar_onclick() {
            document.forms[0].action = "<%=strFormAction%>";
            document.forms[0].submit();
        }

        function btnConfirmarEntrega_onclick() {
            var rbtConfirmar;
            var confirmarEntrega;
            var idFechaEntregaMasAntigua;
            var idFechaEntregaSeleccionada;

            idFechaEntregaMasAntigua = encontrarIdFechaEntregaMasAntigua();
            rbtConfirmar = encontrarCheckboxValido();

            if (rbtConfirmar != undefined) {
                idFechaEntregaSeleccionada = rbtConfirmar.value;

                if (idFechaEntregaMasAntigua !== idFechaEntregaSeleccionada) {
                    window.alert("Se deben de confirmar las entregas mas antiguas a las mas recientes.");
                }
                else {
                    confirmarEntrega = confirm("¿Desea confirmar la entrega?");

                    if (confirmarEntrega) {
                        confirmarCalendario(rbtConfirmar);
                    }
                }
            }
            else {
                window.alert("Favor de seleccionar una entrega.");
            }
        }

        function confirmarCalendario(rbtConfirmar1) {
            var intCalendarioId;
            var cantidadMinutosTolerancia;
            var cboMotivoRetraso;
            var hdnConfirmacion;
            var diferenciaEnMinutos;

            var idRenglon = rbtConfirmar1.id.replace(/^\D+/g, '');
            var strRutaTransportesClave = document.getElementById("tablaCalendarioSucursal").rows[idRenglon].cells[0].innerText;
            var hdnFechaHoraEntregaProgramada = document.getElementById("hdnFechaHoraEntregaProgramada" + idRenglon).value;
            var strFechaHoraEntregaProgramada = document.getElementById("tablaCalendarioSucursal").rows[idRenglon].cells[4].innerText;
            diferenciaEnMinutos = obtenerDiferenciaEnMinutos(hdnFechaHoraEntregaProgramada);

            intCalendarioId = document.getElementById("rbtConfirmar" + idRenglon).value;
            cantidadMinutosTolerancia = document.getElementById("hdnTolerancia" + idRenglon).value;
            cboMotivoRetraso = document.getElementById("cboMotivoRetraso" + idRenglon);
            hdnConfirmacion = document.getElementById("hdnConfirmacion" + idRenglon);

            if (hdnConfirmacion.value == 'true') {
                if (cboMotivoRetraso.value == -1) {
                    window.alert("Favor de eligir un motivo de retraso.");
                }
                else {
                    document.forms[0].action = "SucursalConfirmacionTransportes.aspx?strCmd=Confirmar" +
                                               "&intCalendarioId=" + intCalendarioId +
                                               "&intMotivoRetrasoId=" + cboMotivoRetraso.value +
                                               "&strRutaTransportesClave=" + strRutaTransportesClave +
                                               "&strFechaHoraEntregaProgramada=" + strFechaHoraEntregaProgramada;

                    document.forms(0).submit();
                }
            }
            else if (diferenciaEnMinutos > cantidadMinutosTolerancia) {
                window.alert("La confirmación excedió el tiempo de tolerancia. Elija un motivo de retraso.");
                cboMotivoRetraso.style.display = "inline";
                hdnConfirmacion = 'true';
                document.getElementById("hdnConfirmacion" + idRenglon).value = 'true';
            }
            else {
                document.forms[0].action = "SucursalConfirmacionTransportes.aspx?strCmd=Confirmar" +
                                           "&intCalendarioId=" + intCalendarioId +
                                           "&strRutaTransportesClave=" + strRutaTransportesClave +
                                           "&strFechaHoraEntregaProgramada=" + strFechaHoraEntregaProgramada;

                document.forms(0).submit();
            }
        }

        function obtenerDiferenciaEnMinutos(hdnFechaHoraEntregaProgramada) {
            var dtmFechaHoyConFormato = "<%=dtmFechaHoyConFormato%>";
            var fechaHoraEntregaProgramada;
            var fechaHoyConFormato;
            var diferenciaEnMinutos;

            fechaHoraEntregaProgramada = new Date(hdnFechaHoraEntregaProgramada);
            fechaHoyConFormato = new Date(dtmFechaHoyConFormato);
            diferenciaEnMinutos = Math.round((fechaHoyConFormato - fechaHoraEntregaProgramada) / 60000);

            return diferenciaEnMinutos;
        }

        function encontrarCheckboxValido() {
            var checkboxes = document.getElementsByName('transportes');
            var checkboxValido;

            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked && !checkboxes[i].disabled) {
                    checkboxValido = checkboxes[i];
                    break;
                }
            }
            return checkboxValido;
        }

        function activarDesactivarBotonConfirmar(rbtConfirmar) {
            var transportes = document.getElementsByName("transportes");
            for (var i = 0; i < transportes.length; i++) {
                if (transportes[i].disabled == false) {
                    transportes[i].checked = false;
                }
            }
            rbtConfirmar.checked = true;
        }

        function encontrarIdFechaEntregaMasAntigua() {
            var tablaCalendarioSucursal = document.getElementById("tablaCalendarioSucursal");
            var cantidadRenglones = tablaCalendarioSucursal.rows.length;
            var fechasEntregaProgramadaConId = [];
            var fechasEntregaProgramada = [];
            var idFechaValido;
            var fechaMenosAntigua

            for (i = 1; i < cantidadRenglones; i++) {

                if (document.getElementById("tablaCalendarioSucursal").rows[i].cells[5].innerText == "") {
                    fechasEntregaProgramadaConId.push({
                        id: document.getElementById("tablaCalendarioSucursal").rows[i].cells[6].children[0].value,
                        fecha: new Date(document.getElementById("tablaCalendarioSucursal").rows[i].cells[7].children[0].value)
                    });

                    fechasEntregaProgramada.push(new Date(document.getElementById("tablaCalendarioSucursal").rows[i].cells[7].children[0].value));
                }
            }

            fechaMenosAntigua = new Date(Math.min.apply(null, fechasEntregaProgramada));

            for (i = 0; i < fechasEntregaProgramadaConId.length; i++) {

                if (fechasEntregaProgramadaConId[i].fecha.getTime() == fechaMenosAntigua.getTime()) {
                    idFechaValido = fechasEntregaProgramadaConId[i].id;
                    break;
                }
            }

            return idFechaValido;
        }

        function imprimirConfirmacion(ruta, fechaEntrega, fechaReal) {
            var strCentroLogisticoId = "<%=strCentroLogisticoId%>";
            var strSucursalNombre = "<%=strSucursalNombre%>";

            var ventanaNueva = window.open('', '', 'height=200, width=600');

            ventanaNueva.document.write("<H2>Confirmación de Transporte</H2>");
            ventanaNueva.document.write("<table id='reciboRenglon' width='100%' border='1'>");
            ventanaNueva.document.write("<tr>");
            ventanaNueva.document.write("<td>Sucursal</td><td>Nombre</td><td>Ruta</td><td>Fecha Entrega</td><td>Fecha Confirmación</td>");
            ventanaNueva.document.write("</tr>");
            ventanaNueva.document.write("<tr>");
            ventanaNueva.document.write("<td>" + strCentroLogisticoId + "</td>");
            ventanaNueva.document.write("<td>" + strSucursalNombre + "</td>");
            ventanaNueva.document.write("<td>" + ruta + "</td>");
            ventanaNueva.document.write("<td>" + fechaEntrega + "</td>");
            ventanaNueva.document.write("<td>" + fechaReal + "</td>");
            ventanaNueva.document.write("</tr>");
            ventanaNueva.document.write("</table>");

            ventanaNueva.document.close();
            ventanaNueva.focus();
            ventanaNueva.print();
            ventanaNueva.close();

            return false;
        }

    </script>
</head>
<body leftmargin="0" topmargin="0" onload="return window_onload()" marginwidth="0" marginheight="0">
<form name="frmSucursalConfirmacionTransportes" action="about:blank" method="post">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="34" width="100%"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td width="100%"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"> <span class="txdmigaja">Está en 
              : </span> <a class="txdmigaja" href="">Sucursal</a> <span class="txdmigaja">: 
              <a class="txdmigaja" href="SucursalConfirmacionTransportes.aspx">Rutas 
              para Transporte</a></span> <span class="txdmigaja"></span> <span class="txdmigaja">: 
              </span> <span class="txdmigaja"></span> <span class="txdmigaja"></span> 
              <span class="txdmigaja">Confirmación Rutas Transportes</span> </td>
            <td width="182" class="tdfechahora"> <script language="JavaScript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td colspan="2"> <div style="height: 30px;"> </div></td>
                </tr>
                <tr> 
                  <td class="tdconttablas" width="60%">Fecha Consulta: 
                    <input id="dtmFechaConsulta" name="dtmFechaConsulta" type="text" class="campotabla" size="10" maxlength="10"> 
                    <a href="javascript:objDtmFechaConsulta.popup();"> <img onclick="" height="13" alt="Clic para seleccionar la fecha."
                                        src="../static/images/icono_calendario.gif" width="20" border="0"></a> 
                    &nbsp;&nbsp;&nbsp;&nbsp; <input name="btnConsultar" type="button" class="boton" value="Consultar" onclick="return btnConsultar_onclick()" /> 
                  </td>
                  <td width="40%"><input name="btnConfirmarEntrega" type="button" class="boton" value="Confirmar" onclick="return btnConfirmarEntrega_onclick()" /> 
                  </td>
                </tr>
                <tr> 
                  <td colspan="2"> <div style="height: 30px;"> </div></td>
                </tr>
                <tr> 
                  <td colspan="2"> <%= strObtenerCalendario()%> </td>
                </tr>
                <tr> 
                  <td colspan="2"> <div style="height: 30px;"> </div></td>
                </tr>
                <tr> 
                  <td colspan="2"> <div style="height: 30px;"> </div></td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda('');</script>	
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
            new menu(MENU_ITEMS, MENU_POS);
            new menu(MENU_ITEMS2, MENU_POS2);
            var objDtmFechaConsulta = new calendar1(document.forms['frmSucursalConfirmacionTransportes'].elements['dtmFechaConsulta']);
        </script>
</form>
</body>
</html>
