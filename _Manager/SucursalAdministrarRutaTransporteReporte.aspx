<%@ Page Language="vb" AutoEventWireup="false" EnableViewState="true" UICulture = "en" Culture="es-MX" CodeBehind="SucursalAdministrarRutaTransporteReporte.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalAdministrarRutaTransporteReporte"  codePage="28592" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
<HEAD>
<title>Benavides : Reporte Rutas para Transporte</title>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script type="text/JavaScript" src="js/menu.js"></script>
<script type="text/JavaScript" src="js/menu_items.js"></script>
<script type="text/JavaScript" src="js/menu_tpl.js"></script>
<script type="text/JavaScript" src="js/headerfooter.js"></script>
<script type="text/JavaScript" src="../static/scripts/calendar1.js"></script>
<script type="text/javascript">

        strUsuarioNombre = "<%= strUsuarioNombre %>";
        strFechaHora = "<%= strHTMLFechaHora %>";
        var mensajeError;

        function window_onload() {
            cargarValoresControles();
        }

        function cargarValoresControles() {
            document.getElementById("txtRutaTransportesClave").value = "<%=txtRutaTransportesClave%>"; 
            document.getElementById("cboRutaTransportesTipoIdFiltro").value = "<%=cboRutaTransportesTipoIdFiltro%>"; 
            document.getElementById("cboRutaTransportesDestinoFiltro").value = "<%=cboRutaTransportesDestinoFiltro%>"; 
            document.getElementById("cboRutaTransportesProveedorFiltro").value = "<%=cboRutaTransportesProveedorFiltro%>"; 
            document.getElementById("txtCentroLogisticoId").value = "<%=txtCentroLogisticoId%>"; 
            document.getElementById("dtmFechaInicioEntrega").value = "<%=dtmFechaInicioEntrega%>"; 
            document.getElementById("dtmFechaFinEntrega").value = "<%=dtmFechaFinEntrega%>"; 
            document.getElementById("cboEntregaConfirmada").value = "<%=cboEntregaConfirmada%>"; 

            var botonesRetraso = document.getElementsByName("rbtRetraso");
            var botonRadioSeleccionado = "<%=rbtRetraso%>";

             for (var i = 0; i < botonesRetraso.length; i++) {
                 if (botonesRetraso[i].value == botonRadioSeleccionado) {
                     if (botonRadioSeleccionado == "Si") {
                         document.getElementById('lblMotivoRetraso').style.visibility = 'visible';
                         document.getElementById('cboMotivoRetraso').style.visibility = 'visible';
                     }
                     botonesRetraso[i].checked = true;
                     break;
                 }
             }

            document.getElementById("cboMotivoRetraso").value = "<%=cboMotivoRetraso%>"; 
        }

        function btnBuscarReporte_onclick() {
            var txtRutaTransportesClave = document.getElementById("txtRutaTransportesClave").value;
            var cboRutaTransportesTipoIdFiltro = document.getElementById("cboRutaTransportesTipoIdFiltro").value;
            var cboRutaTransportesDestinoFiltro = document.getElementById("cboRutaTransportesDestinoFiltro").value;
            var cboRutaTransportesProveedorFiltro = document.getElementById("cboRutaTransportesProveedorFiltro").value;
            var txtCentroLogisticoId = document.getElementById("txtCentroLogisticoId").value;
            var dtmFechaInicioEntrega = document.getElementById("dtmFechaInicioEntrega").value;
            var dtmFechaFinEntrega = document.getElementById("dtmFechaFinEntrega").value;
            var cboEntregaConfirmada = document.getElementById("cboEntregaConfirmada").value;
            var cboMotivoRetraso = document.getElementById("cboMotivoRetraso").value;

            var botonesRetraso = document.getElementsByName("rbtRetraso");
            var idRadioRetrasoSeleccionado;

            for (var i = 0; i < botonesRetraso.length; i++) {
                if (botonesRetraso[i].checked == true) {
                    idRadioRetrasoSeleccionado = botonesRetraso[i].value;
                }
            }

            if (validarBuscarReporte(dtmFechaInicioEntrega, dtmFechaFinEntrega, idRadioRetrasoSeleccionado, cboMotivoRetraso)) {

                document.forms[0].action = "SucursalAdministrarRutaTransporteReporte.aspx?strCmd2=Consultar" +
                                           "&strRutaTransportesClave=" + txtRutaTransportesClave +
                                           "&intRutaTransportesTipoId=" + cboRutaTransportesTipoIdFiltro +
                                           "&intDestinoId=" + cboRutaTransportesDestinoFiltro +
                                           "&intProveedorId=" + cboRutaTransportesProveedorFiltro +
                                           "&strCentroLogisticoId=" + txtCentroLogisticoId +
                                           "&dtmFechaHoraEntregaProgramadaInicio=" + dtmFechaInicioEntrega +
                                           "&dtmFechaHoraEntregaProgramadaFin=" + dtmFechaFinEntrega +
                                           "&intEntregaConfirmada=" + cboEntregaConfirmada +
                                           "&ConRetraso=" + idRadioRetrasoSeleccionado +
                                           "&intMotivoRetrasoId=" + cboMotivoRetraso;

                document.forms(0).submit();
            } else {
                window.alert(mensajeError);
            }
        }

        function validarBuscarReporte(fechaInicioEntrega, fechaFinEntrega, idRadioRetrasoSeleccionado, cboMotivoRetraso) {
            var busquedaValida = true;

            if (fechaInicioEntrega == "" || fechaFinEntrega == "") {
                busquedaValida = false;
                mensajeError = "Se requiere la fecha de inicio y fin para realizar la busqueda.";
            }

            if (idRadioRetrasoSeleccionado == "Si" && cboMotivoRetraso == -1) {
                busquedaValida = false;
                mensajeError = "Favor de elegir un motivo.";
            }

            return busquedaValida;
        }

        function mostrarOcultarMotivo(tipoMotivo) {
            if (tipoMotivo == "Mostrar") {
                document.getElementById('lblMotivoRetraso').style.visibility = 'visible';
                document.getElementById('cboMotivoRetraso').style.visibility = 'visible';
            }
            if (tipoMotivo == "Ocultar") {
                document.getElementById("cboMotivoRetraso").selectedIndex = "0";
                document.getElementById('lblMotivoRetraso').style.visibility = 'hidden';
                document.getElementById('cboMotivoRetraso').style.visibility = 'hidden';
            }
        }

        function btnExportarReporte_onclick() {
            var concatenacionReporte;
            var tablaReporte = document.getElementById('tablaReporte');
            var guardar;
            var dia, mes, anio;
            var fechaConFormato;
            var fechaHora;
            var separacionFecha;
            var separacionHora;
            var fechaEstimadaColumna = 8;
            var fechaRecepcionColumna = 9;

            concatenacionReporte = "<table border='2px'>";
            concatenacionReporte = concatenacionReporte + "<tr bgcolor='#87AFC6'>";
            concatenacionReporte = concatenacionReporte + "<th>Ruta</th>";
            concatenacionReporte = concatenacionReporte + "<th>Distribución</th>";
            concatenacionReporte = concatenacionReporte + "<th>Destino</th>";
            concatenacionReporte = concatenacionReporte + "<th>Proveedor</th>";
            concatenacionReporte = concatenacionReporte + "<th>SAP</th>";
            concatenacionReporte = concatenacionReporte + "<th>CIA</th>";
            concatenacionReporte = concatenacionReporte + "<th>Sucursal</th>";
            concatenacionReporte = concatenacionReporte + "<th>Región</th>";
            concatenacionReporte = concatenacionReporte + "<th>Fecha Estimada Entrega</th>";
            concatenacionReporte = concatenacionReporte + "<th>Hora Estimada Entrega</th>";
            concatenacionReporte = concatenacionReporte + "<th>Fecha Recepción</th>";
            concatenacionReporte = concatenacionReporte + "<th>Hora Recepción</th>";
            concatenacionReporte = concatenacionReporte + "<th>Estatus Entrega</th>";
            concatenacionReporte = concatenacionReporte + "<th>Motivo Retraso</th>";
            concatenacionReporte = concatenacionReporte + "</tr>";

            if (tablaReporte != null) {
                for (var i = 1, renglon; renglon = tablaReporte.rows[i]; i++) {

                    concatenacionReporte = concatenacionReporte + "<tr>";
                    for (var j = 0, columna; columna = renglon.cells[j]; j++) {

                        if (j == fechaEstimadaColumna) {
                            fechaHora = columna.innerHTML.split(" ");
                            separacionFecha = fechaHora[0];
                            separacionHora = fechaHora[1];
                            separacionFecha = separacionFecha.split("/");

                            fechaConFormato = new Date(separacionFecha[1] + "/" + separacionFecha[0] + "/" + separacionFecha[2] + " " + separacionHora);

                            dia = fechaConFormato.getDate();
                            mes = fechaConFormato.getMonth() + 1;
                            anio = fechaConFormato.getFullYear();

                            concatenacionReporte = concatenacionReporte + "<td>" + dia + "/" + mes + "/" + anio + "</td>";
                            concatenacionReporte = concatenacionReporte + "<td>" + fechaConFormato.getHours() + ":" + fechaConFormato.getMinutes() + "</td>";
                        }
                        else if (j == fechaRecepcionColumna) {
                            if (columna.innerHTML != "") {
                                fechaHora = columna.innerHTML.split(" ");
                                separacionFecha = fechaHora[0];
                                separacionHora = fechaHora[1];
                                separacionFecha = separacionFecha.split("/");

                                fechaConFormato = new Date(separacionFecha[1] + "/" + separacionFecha[0] + "/" + separacionFecha[2] + " " + separacionHora);

                                dia = fechaConFormato.getDate();
                                mes = fechaConFormato.getMonth() + 1;
                                anio = fechaConFormato.getFullYear();

                                concatenacionReporte = concatenacionReporte + "<td>" + dia + "/" + mes + "/" + anio + "</td>";
                                concatenacionReporte = concatenacionReporte + "<td>" + fechaConFormato.getHours() + ":" + fechaConFormato.getMinutes() + ":" + fechaConFormato.getSeconds() + "</td>";
                            }
                            else {
                                // Rellenar los espacios cuando no exista fecha y hora de confirmación.
                                concatenacionReporte = concatenacionReporte + "<td></td>";
                                concatenacionReporte = concatenacionReporte + "<td></td>";
                            }
                        }
                        else {
                            concatenacionReporte = concatenacionReporte + "<td>" + columna.innerHTML + "</td>";
                        }
                    }
                    concatenacionReporte = concatenacionReporte + "</tr>";
                }

                concatenacionReporte = concatenacionReporte + "</table>";

                var ua = window.navigator.userAgent;
                var msie = ua.indexOf("MSIE");

                if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./))
                {
                    iReporte.document.open("txt/html", "replace");
                    iReporte.document.write(concatenacionReporte);
                    iReporte.document.close();
                    iReporte.focus();
                    guardar = iReporte.document.execCommand("SaveAs", true, "Reporte de Rutas.xls");
                }
            }
        }

        new menu(MENU_ITEMS, MENU_POS);
		</script>
</HEAD>
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
      <td width="770" class="tdtab">Está en : <a href="../_Manager/SucursalHome.aspx">Sucursal</a> 
        : Reporte Rutas para Transporte : Reporte Rutas para Transporte </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td class="tdgeneralcontent"> <table border="0" cellspacing="0" cellpadding="0" width="100%">
          <tr height="40"> 
            <td colspan="2"> <h1>Reporte Rutas para Transporte</h1>
              <p> Reporte Rutas para Transporte </p>
              <h2>Reporte Rutas para Transporte</h2></td>
          </tr>
          <tr height="30"> 
            <td> <span class="campotablaresultado">Ruta:</span> <input id="txtRutaTransportesClave" name="txtRutaTransportesClave" class="field" maxlength="4"
										style="WIDTH: 75px"> <span class="campotablaresultado">Distribución:</span> 
              <select id="cboRutaTransportesTipoIdFiltro" name="cboRutaTransportesTipoIdFiltro" class="field"
										style="WIDTH: 125px">
                <option value="-1" selected>&gt;&gt; Elija tipo &lt;&lt;</option>
                <option value="1">Foranea</option>
                <option value="2">Local</option>
                <option value="3">Regional</option>
              </select> <span class="campotablaresultado">Destino:</span> <select id="cboRutaTransportesDestinoFiltro" name="cboRutaTransportesDestinoFiltro" class="field"
										style="WIDTH: 125px">
                <option value="-1" selected>&gt;&gt; Elija destino &lt;&lt;</option>
                <%= LLenarControlDestino()%> </select> <span class="campotablaresultado">Proveedor:</span> 
              <select id="cboRutaTransportesProveedorFiltro" name="cboRutaTransportesProveedorFiltro"
										class="field" style="WIDTH: 125px">
                <option value="-1" selected>&gt;&gt; Elija proveedor &lt;&lt;</option>
                <%= LLenarControlProveedor()%> </select> </td>
          </tr>
          <tr height="50"> 
            <td> <span class="campotablaresultado">Sucursal:</span> <input id="txtCentroLogisticoId" name="txtCentroLogisticoId" class="field" maxlength="4"
										style="WIDTH: 75px"> <span class="campotablaresultado">Fecha 
              Inicio Entrega:</span> <input id="dtmFechaInicioEntrega" name="dtmFechaInicioEntrega" class="campotabla" size="10"
										maxlength="10"> <a href="javascript:objDtmFechaInicioEntrega.popup();"><img onclick="" height="13" alt="Clic para seleccionar la fecha." src="../static/images/icono_calendario.gif"
											width="20" border="0"> </a><span class="campotablaresultado">Fecha 
              Fin Entrega:</span> <input id="dtmFechaFinEntrega" name="dtmFechaFinEntrega" class="campotabla" size="10" maxlength="10"> 
              <a href="javascript:objDtmFechaFinEntrega.popup();"><img onclick="" height="13" alt="Clic para seleccionar la fecha." src="../static/images/icono_calendario.gif"
											width="20" border="0"> </a> </td>
          </tr>
          <tr height="30"> 
            <td> <span class="campotablaresultado">Entrega Confirmada:</span> 
              <select id="cboEntregaConfirmada" name="cboEntregaConfirmada" class="field" style="WIDTH: 55px">
                <option value="-1" selected>Todas</option>
                <option value="0">No</option>
                <option value="1">Sí</option>
              </select> <span class="campotablaresultado">Con Retraso:</span> 
              <span class="campotablaresultado"> Si</span> <input type="radio" name="rbtRetraso" onclick="mostrarOcultarMotivo('Mostrar')" value="Si"> 
              <span class="campotablaresultado">No</span> <input type="radio" name="rbtRetraso" onclick="mostrarOcultarMotivo('Ocultar')" value="No"
										checked> <span class="campotablaresultado">Ambos</span> 
              <input type="radio" name="rbtRetraso" onclick="mostrarOcultarMotivo('Ocultar')" value="Ambos"> 
              <span id="lblMotivoRetraso" class="campotablaresultado" style="VISIBILITY: hidden">Motivo 
              Retraso:</span> <select id="cboMotivoRetraso" name="cboMotivoRetraso" class="field" style="WIDTH: 125px; VISIBILITY: hidden">
                <option value="-1" selected>&gt;&gt; Elija Motivo &lt;&lt;</option>
                <option value="0">Todos</option>
                <%= CrearOpcionesMotivoRetraso()%> </select> <br> </td>
          </tr>
          <tr height="30"> 
            <td align="right"><input id="btnBuscarRuta" name="btnBuscarRuta" 
										class="button" value="Buscar" type="button" onclick="btnBuscarReporte_onclick()"> 
              <input id="btnExportar" name="btnExportar" class="button" value="Exportar" type="button"
										onclick="btnExportarReporte_onclick()"></td>
          </tr>
          <tr height="30"> </tr>
          <tr> 
            <td> <div id="ReporteCalendario" runat="server"> </div></td>
          </tr>
        </table></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td> <script type="text/javascript">crearTablaFooterCentral()</script> </td>
    </tr>
  </table>
  <iframe id="iReporte" style="DISPLAY: none"></iframe>
  <script type="text/JavaScript">
            var objDtmFechaInicioEntrega = new calendar1(document.forms['frmPrincipal'].elements['dtmFechaInicioEntrega']);
            var objDtmFechaFinEntrega = new calendar1(document.forms['frmPrincipal'].elements['dtmFechaFinEntrega']);
			</script>
</form>
</body>
</HTML>
