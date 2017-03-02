<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsistenciaArchivoAdam.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistenciaArchivoAdam" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>

<html>
<head>
    <title>Benavides: Control de Asistencia</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/tools.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/calendario.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/cal_format00.js"></script>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<LINK rel="stylesheet" type="text/css" href="css/menu.css">
<LINK rel="stylesheet" type="text/css" href="css/estilo.css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script id="clientEventHandlersJS" language="javascript">
<!--

    strUsuarioNombre = "<%= strUsuarioNombre() %>";
    strFechaHora = "<%= strHTMLFechaHora %>";


    function window_onload() {
        document.forms[0].action = "<%= strFormAction %>";
    }

    function strGetCustomDateTime() {
        document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
        return (true);
    }

    function frmControlAsistenciaArchivoAdamArchivoAdam_onsubmit() {
        return (true);
    }

    function cmdRegresar_onclick() {

        //Redirecciona a usuario al "home" de Control de Asistencia.
        window.location = "ControlAsistencia.aspx";
    }

function trim(stringToTrim) {
    return stringToTrim.replace(/^\s+|\s+$/g, "");
}

function fnGenerarArchivoAdam(intTotalDeRegistros, intRegistrosConfirmados) {

    var confirmar = confirm('Desea Generar el Archivo Adam de un total de: ' + "\n" + intTotalDeRegistros + ' Registros y ' + intRegistrosConfirmados + ' Confirmados?');
    if (confirmar == true) {
        document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdGenerarArchivo';
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
    }
}

function cmdGenerarArchivo_onclick() {

    var valida;

    valida = fnValidaCampos();
    if (valida) {

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdInformacionGenerarArchivo';
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();
    }
}

    function fnValidaCampos() {

        //Validacion de los campos    
        if (trim(document.getElementById('dtmFechaIni').value) == '' || trim(document.getElementById('dtmFechaIni').value) == '') {

            alert('Capture la fecha por favor');
            return (false);
        }
        else if (trim(document.getElementById('dtmFechaPago').value) == '') {
            alert('Capture la fecha de pago por favor');
            document.getElementById('dtmFechaPago').focus();
            return (false);
        }
        else if (ValidaFechas("dtmFechaIni", "dtmFechaFin") == false) {
            return (false);
        }
        else {
            return (true);
        }
    }

    //Validacion de fechas.
    function ValidaFechas(dtmFechaIni, dtmFechaFin) {
        valida = true;

        //Validacion de Fecha inicial
        valida = blnValidarCampo(document.getElementById(dtmFechaIni), true, "Fecha Inicial", cintTipoCampoFecha, 10, 10, "");

        //Validacion de Fecha final
        if (valida) {
            valida = blnValidarCampo(document.getElementById(dtmFechaFin), true, "Fecha Final", cintTipoCampoFecha, 10, 10, "");

            //Valida que la fecha inicial NO sea mayor que la fecha final.	
            if (valida) {

                //Fecha inicial
                var dtmInicio = document.getElementById(dtmFechaIni).value;
                var diaIni = dtmInicio.substring(0, 2)
                var mesIni = dtmInicio.substring(3, 5);
                var anioIni = dtmInicio.substring(6, 10);

                //Fecha final
                var dtmFin = document.getElementById(dtmFechaFin).value;
                var diaFin = dtmFin.substring(0, 2)
                var mesFin = dtmFin.substring(3, 5);
                var anioFin = dtmFin.substring(6, 10);

                //Fecha de pago
                var dtmPago = document.getElementById("dtmFechaPago").value;
                var diaPago = dtmPago.substring(0,2);
                var mesPago = dtmPago.substring(3, 5);
                var anioPago = dtmPago.substring(6, 10);

                //Fecha hoy
                var dtmActual = document.getElementById("dtmFechaActual").value;
                var diaActual = dtmActual.substring(0, 2);
                var mesActual = dtmActual.substring(3, 5);
                var anioActual = dtmActual.substring(6, 10);

                //Validacion
                var date1 = (anioIni + mesIni + diaIni);
                var date2 = (anioFin + mesFin + diaFin);
                var date3 = (anioPago + mesPago + diaPago);
                var date4 = (anioActual + mesActual + diaActual);

                //Validaciones de fecha por Tipo de Nomina (Semana y Quncena).
                var dateIni = new Date(anioIni + "/" + mesIni + "/" + diaIni);
                var dateIniDay = dateIni.getDay();

                var dateFin = new Date(anioFin + "/" + mesFin + "/" + diaFin);
                var dateFinDay = dateFin.getDay();

                //-Fecha para validar ultimo dia de quincena
                var mes = parseInt(mesFin) + 1;
                var endOfLastMonth = new Date(anioFin + "/" + mes + "/" + 1);
                endOfLastMonth.setDate(0);

                var lastDayLastMonth = endOfLastMonth.getDate()

                //-Tipo de Nomina 
                var tipoNomina = 1;
                if (document.forms[0].elements["rdPorSemana"].checked == true) {
                    tipoNomina = 2;
                }

                if (date1 > date4) {
                    alert('La fecha de inicio no debe ser mayor que la fecha de hoy');
                    return (false);
                }
                else if (date2 > date4) {
                    alert('La fecha final no debe ser mayor que la fecha de hoy');
                    return (false);
                }
                else if(date3 > date4){
                    alert('La fecha de pago no debe ser mayor que la fecha de hoy');
                    return (false);
                }
                else if (date1 > date2) {
                    alert('La fecha de inicio no debe ser mayor que la fecha final');
                    return (false);
                }
                //else if ((tipoNomina == 1) && (parseInt(diaIni) != 1) && (parseInt(diaIni) != 16)) {

                //    //-Valida fecha Inicial-Quincenal
                //    alert('La fecha de inicio para periodo quincenal debe de ser inicio de quincena');
                //    return (false);
                //}
                //else if ((tipoNomina == 1) && parseInt(diaFin) != 15 && parseInt(diaFin) != lastDayLastMonth) {

                //    //-Valida fecha Final-Quincenal
                //    alert('La fecha final para periodo quincenal debe de ser fin de quincena');
                //    return (false);
                //}
                //else if ((tipoNomina == 2) && (dateIniDay != 1)) {

                //    //-Valida fecha Inicial (Semanal)
                //    alert('La fecha de inicio para periodo semanal debe de ser Lunes');
                //    return (false);
                //}
                //else if ((tipoNomina == 2) && (dateFinDay != 0)) {

                //    //-Valida fecha Final (Semanal)
                //    alert('La fecha final para periodo semanal debe de ser Domingo');
                //    return (false);
                //}
            }
        }

        return (valida);
    }

        //-->
</script>

    </head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onload="return window_onload()">
<form id="frmControlAsistenciaArchivoAdam" name="frmControlAsistenciaArchivoAdam" action="about:blank" method="post" runat="server">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <A href="../_Manager/InicioHome.aspx">Central</A> : Control de Asistencia : Generar Archivo Nómina </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Asistencia - Generar Archivo Nómina Administrador</h1>
		<p>Elija el período de asistenciay de pago y presione el botón Generar XLS.</p>
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="4">
                    <h2>Período de Asistencia</h2>
                </td>
            </tr>
            <tr>
                <td class="tdtexttablebold">Fecha inicio:</td>
                <td class="tdpadleft5"> 
                    <input id="dtmFechaIni" name="dtmFechaIni" class="field" size="10" maxLength="10" type="text" value="<%= strFirstDayOfMonth()%>"> 
                        <A href="javascript:cal1.popup();">
                            <IMG src="../static/images/icono_calendario.gif" width="20" height="13" border="0" align="absMiddle" alt="Clic para seleccionar la fecha."> 
                         </A> <br> 
                </td>
                <td class="tdtexttablebold" >Fecha fin:</td>
                <td class="tdpadleft5" > 
                    <input id="dtmFechaFin" name="dtmFechaFin" class="field" size="10" maxLength="10" type="text" value="<%= strToday()%>"> 
                        <A href="javascript:cal2.popup()">
                            <IMG src="../static/images/icono_calendario.gif" width="20" height="13" border="0" align="absMiddle" alt="Clic para seleccionar la fecha."> 
                        </A> <br> 
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td class='txsubtitulo' colspan="4">
                    <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">Período de Pago
                </td>
            </tr>
            <tr>
                <td class="tdtexttablebold" style="width: 150px">Fecha</td>
                <td class="tdpadleft5"> 
                    <input id="dtmFechaPago" name="dtmFechaPago" class="field" size="10" maxLength="10" type="text" value="<%= strToday()%>"> 
                        <A href="javascript:cal3.popup()">
                            <IMG src="../static/images/icono_calendario.gif" width="20" height="13" border="0" align="absMiddle" alt="Clic para seleccionar la fecha."> 
                        </A> <br> 
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td class='txsubtitulo'>
                    <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">Tipo de Nomina
                </td>
            </tr>
            <tr>
                                    <td class="tdtexttablebold">
                                        <input type="radio" id="rdPorSemana" name="cmdTipoNomina" value="2" checked="checked" />Por Semana
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdtexttablebold">
                                        <input type="radio" id="rdPorQuincena" name="cmdTipoNomina" value="1"/>Por Quincena
                                    </td>
                                </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td colspan="2">
                    <input type="hidden" id="dtmFechaActual" name="dtmFechaActual" value='<%= strFechaActual()%>' /> 
                    <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()" style="margin-top:20px;">
                    <input id="cmdConsultar" name="cmdConsultar" type="button" class="boton" value="Generar XLS" onClick="return cmdGenerarArchivo_onclick()" style="margin-top:20px;">
                </td>
            </tr>
            <tr>
                <td colspan="4"><div id="tblResultados"></div></td>
            </tr>
		</table>
      </td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaFooterCentral()</script></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
      new menu(MENU_ITEMS, MENU_POS);
      var cal1 = new calendar(null, document.forms[0].elements["dtmFechaIni"]);
      var cal2 = new calendar(null, document.forms[0].elements["dtmFechaFin"]);
      var cal3 = new calendar(null, document.forms[0].elements["dtmFechaPago"]);
      
    //-->
</script>
</form>
    <div style="display:none;">
        <div id="divConsultaMensaje">
            <%--<= Me.strTablaConsultaMensaje()%>--%>
        </div>            
    </div>
    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>
