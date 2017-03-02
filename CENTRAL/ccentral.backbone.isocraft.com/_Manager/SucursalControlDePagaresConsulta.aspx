<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SucursalControlDePagaresConsulta.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalControlDePagaresConsulta" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>

<html>
<head>
    <title>Benavides: Control de Pagares</title>
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


        //Llenado de Combos
        <%= LlenarControlDireccion()%>
        <%= LlenarControlZona()%>

        return (true);
    }

    function strGetCustomDateTime() {
        document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
        return (true);
    }

    function frmConsultarPromociones_onsubmit() {
        return (true);
    }

    function cmdCancelar_onclick() {
        window.location.href = "InicioHome.aspx";
    }
    function cmdAgregar_OnClick() {
        window.location.href = "SucursalControlDePagaresAlta.aspx";
    }

    function cboDireccionOperativa_onchange() {

        if (document.getElementById("cboDireccionOperativa").selectedIndex != 0) {

            document.getElementById("cboZonaOperativa").value = "0";
            document.getElementById("cboSucursales").value = "0";

            if (document.getElementById("cboDireccionOperativa").selectedIndex == 1) {

                //document.getElementById("cboZonaOperativa").value = "-1";
                //document.getElementById("cboZonaOperativa").disabled = true;
            }
            else {
                document.getElementById("cboZonaOperativa").value = "0";
            }

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultarSucursal'
            document.forms[0].target = '_self';
            document.forms[0].submit();
            return (true);
        }

        //Si el usuario selecciona la opcion "Elija una Direccion" se resetean las opciones de las Zonas.
        document.getElementById("cboZonaOperativa").length = 0;
        document.forms[0].elements["cboZonaOperativa"].options[0] = new Option(">> Elija una zona <<", "0");

        //Si el usuario selecciona la opcion "Elija una Direccion" se resetean las opciones de las Sucursales.
        document.getElementById("cboSucursales").length = 0;
        document.forms[0].elements["cboSucursales"].options[0] = new Option(">> Elija una sucursal <<", "0");

        return (false);
    }

    function cboZonaOperativa_onchange() {

        if ((document.getElementById("cboDireccionOperativa").selectedIndex > 0) && (document.getElementById("cboZonaOperativa").selectedIndex != 0)) {

            document.getElementById("cboSucursales").value = "0";

            //document.forms[0].action = '<= strThisPageName%>?strCmd=cmdConsultarSucursales'
            document.forms[0].action = '<%= strThisPageName%>'
            document.forms[0].target = '_self';
            document.forms[0].submit();
    }

    //Si el usuario selecciona la opcion "Elija una Zona" se resetean las opciones de las Sucursales.
    document.getElementById("cboSucursales").length = 0;
    document.forms[0].elements["cboSucursales"].options[0] = new Option(">> Elija una sucursal <<", "0");

    return (false)
}

function cboSucursales_onchange() {
    document.getElementById('tblResultados').innerHTML = '';
    return (true);
}

function txtAutorizacionId_onKeyPress(e) {

    document.getElementById('tblResultados').innerHTML = '';

    //Se validan los caracteres permitidos.
    var key = window.event ? e.keyCode : e.wich;

    //No se permiten caracteres especiales para el Articulo.
    if (key > 47 && key < 58) {
        return true;
    }
    else {
        return false;
    }
}


function cmdEliminar_onclick(intSolicitudPagareId, intAutorizacionId) {

    var _confirm = confirm('Desea eliminar la solicitud con autorizacion: ' + intAutorizacionId + "?");

    if (_confirm == true) {

        document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdEliminar&intSolicitudPagareId=' + intSolicitudPagareId;
        document.forms[0].target = "ifrOculto";
        //document.forms[0].target = '_self';
        document.forms[0].submit();
    }
    //alert('Eliminar' + intSolicitudPagareId);
}

    function cmdEditar_onclick(intSolicitudPagareId, intAutorizacionId) {

        var _confirm = confirm('Desea editar la solicitud con autorizacion: ' + intAutorizacionId + "?");

    if (_confirm == true) {

        window.location.href = "SucursalControlDePagaresAlta.aspx?intSolicitudPagareId=" + intSolicitudPagareId;
        
    }
}

    function cmdConsultar_onclick() {

        //Variables.
        var valida;

        document.getElementById('tblResultados').innerHTML = '';
        

            valida = fnValidaConsulta();

        return (valida);
    }

    function fnValidaConsulta() {
        var valida;

        valida = fnValidaCampos();
        if (valida) {

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultar';
                document.forms[0].target = "ifrOculto";
                //document.forms[0].target = '_self';
                document.forms[0].submit();
            }

            return (valida);

        }

        function fnValidaCampos() {

            if (fnValidaCombos() == false) {
                return(false);
            }

            //--------------------------
            //Validacion Vigencia
            //--------------------------

            if (ValidaFechas("dtmFechaIni", "dtmFechaFin") == false) {
                return (false);
            }
            return(true);
        }

        function fnValidaCombos() {

            if (document.getElementById('cboDireccionOperativa').value == "0") {
                //alert(document.getElementById('cboDireccionOperativa').value = "0");
                alert('Seleccione una direccion.');
                return(false);
            }
            else if (document.getElementById('cboZonaOperativa').value == "0") {
                alert('Seleccione una Zona');
                return (false);
            }
            else if (document.getElementById('cboSucursales').value == "0") {
                alert('Seleccione una sucursal');
                return (false);
            }
            else {
                return(true);
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

                    //Fecha hoy
                    var dtmActual = document.getElementById("dtmFechaActual").value;
                    var diaActual = dtmActual.substring(0, 2);
                    var mesActual = dtmActual.substring(3, 5);
                    var anioActual = dtmActual.substring(6, 10);

                    //Validacion
                    var date1 = (anioIni + mesIni + diaIni);
                    var date2 = (anioFin + mesFin + diaFin);
                    var date3 = (anioActual + mesActual + diaActual);

                    if (date1 > date2) {
                        alert('La fecha de inicio no debe ser mayor que la fecha final');
                        return (false);
                    }
                }
            }

            return (valida);
        }

        function trim(stringToTrim) {
            return stringToTrim.replace(/^\s+|\s+$/g, "");
        }

        function cmdImprimir_onclick() {

            //Validacion de resultados
            var tablaTotal = document.getElementById('tblResultados').innerHTML;
            if (trim(tablaTotal) == 'Consulta sin resultados' || trim(tablaTotal) == '') {
                alert('No hay resultados de la consulta')
                return (false);
            }

            document.forms[0].action = "<%=strFormAction%>?strCmd=cmdImprimir";
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();
            document.forms[0].target = '';

        return (true);
    }

    function fnImprimir(strPagares) {

        //Llamada desde el servidor para imprimir resultados de la consulta.
        document.ifrPageToPrint.document.all.divBody.innerHTML = strPagares;
        document.ifrPageToPrint.focus();
        window.print();

    }

    function cmdExportar_onclick() {

        if (document.getElementById('tblResultados').innerHTML == '') {

            alert('Realice la consulta por favor');
            return (false);
        }

        var confirmar = confirm('Desea exportar la informacion a Excel?');
        if (confirmar == true) {
            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdExportar';
                document.forms[0].target = "ifrOculto";
                document.forms[0].submit();

                return (true);
            }
        }

        function cmdBuscarEmpleado_onclick() {

            if (document.getElementById('txtArticuloId').value != '') {

                var url = 'PopEmpleado.aspx?strEmpleado=txtArticuloId&amp;strEmpleadoNombreId=txtEmpleadoNombre';

                var width = 400;
                var height = 540;
                url = url + '&strEmpleadoBuscar=' + document.forms[0].elements['txtArticuloId'].value;
                Pop(url, width, height);
            }
            else {
                //Si el codigo de Planograma esta vacio
                alert('Por favor capture el código o el nombre del empleado.')
            }
        }

        function Pop(url, width, height) {
            var Win = window.open(url, 'Pop', 'width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no');
            return false;
        }

        function cmdVerDetalle_onclick(intPromocionId, intTipoPromocionId, intTipoDetalleId) {

            //Parametros
            var strParametros = '?&strPromocionId=' + intPromocionId + '&strTipoPromocionId=' + intTipoPromocionId + '&strTipoDetalleId=' + intTipoDetalleId;

            if (intTipoDetalleId == 1) {
                //Articulos
                window.open('SistemaConsultarPromocionesDetalleArticulos.aspx' + strParametros, "Benavides", "toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=0,width=650,height=500,statusbar=no")
            }
            else {
                //Sucursales
                window.open('SistemaConsultarPromocionesDetalleSucursales.aspx' + strParametros, "Benavides", "toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=0,width=650,height=500,statusbar=no")
            }
        }

        function dtmFecha_onKeyPress(e) {

            document.getElementById('tblResultados').innerHTML = '';

            //No se permiten caracteres especiales para la fecha.
            var key = window.event ? e.keyCode : e.which;
            if (key > 46 && key < 58) {
                return true;
            }
            else {
                return false
            }
        }

        function doSubmit(c, t, p) {
            if (p == null) {
                p = document.getElementById('txtCurrentPage').value;
            }
            else {
                document.getElementById('txtCurrentPage').value = p;
            }
            document.forms[0].action =
            '<%= strThisPageName%>?strCmd=cmdConsultar&pager=true&p=' + p;
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();
        }

        //-->
</script>

    </head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onload="return window_onload()">
<form name="frmConsultarPagares" action="about:blank" method="post">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <A href="../_Manager/InicioHome.aspx">Central</A> : Consulta Pagares </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
      <tr>
      <td class="tdgeneralcontent">
          <div id="divTitulo"></div>
          <h1>Control de Pagares</h1>
		<p>Seleccione los filtros del pagare a buscar y presione el boton Consultar.</p>
		
          <table style="width:100%;">
            <tr>
                <td colspan="4">
                    <h2>Criterios de Consulta</h2>
                </td>
            </tr>
            <tr>
                        <td class="tdtexttablebold" style="width: 150px">Dirección</td>
                        <td class="tdpadleft5" style="width: 240px">
                            <select id="cboDireccionOperativa" name="cboDireccionOperativa" class="campotabla" style="width:150px" onchange="return cboDireccionOperativa_onchange()">
                                <option selected="selected" value="0">&raquo; Elija una dirección &laquo;</option>
                                <%--<option value="-1">&raquo; Todas las direcciones &laquo;</option>--%>
							</select>
                        </td>
                        <td class="tdtexttablebold" style="width: 150px">Autorizacion</td>
                        <td class="tdtittablas" style="width: 240px">
                            <input type="text" id="txtAutorizacion" name="txtAutorizacion" maxLength="16" size="16"  class="campotabla" onKeyPress=" return txtAutorizacionId_onKeyPress(event);" value='<%=Request.Form("txtAutorizacion")%>' autocomplete='off'>  
                            <%--<IMG style="CURSOR:pointer;" id="IMG1" onclick="javascript:cmdBuscarEmpleado_onclick()" border="0" align="absMiddle" src="../static/images/icono_lupa.gif" width="17" height="17">--%> 
                        </td>
                        
                    </tr>
                    <tr>
                        <td class="tdtexttablebold" style="width: 150px">Zona</td>
                        <td class="tdpadleft5" style="width: 240px">    
                            <select id="cboZonaOperativa" class="campotabla" onchange="return cboZonaOperativa_onchange()" name="cboZonaOperativa" style="width:150px">
                                <option selected value="0">&raquo; Elija una zona &laquo;</option>
                                <%--<option value="-1">&raquo; Todas las zonas &laquo;</option>--%>
                            </select>
                        </td>
                        <td class="tdtexttablebold" style="width: 150px">Estatus</td>
                        <td class="tdtittablas" style="width: 240px">
                            <select id="cboEstatusPagare" class="campotabla" name="cboEstatusPagare" class="campotabla" style="width:150px">
                                <%--<option selected="selected" value="0">&raquo; Seleccione &laquo;</option>--%>
                                <option selected="selected" value="-1">&raquo; Todos &laquo;</option>
                                <option value="0">&raquo; Sin Confirmar &laquo;</option>
                                <option value="1">&raquo; Confirmadas &laquo;</option>
							</select></td>
                    </tr>
                     <tr>
                         <td class="tdtexttablebold" style="width: 150px">Sucursal</td>
                        <td class="tdpadleft5" style="width: 240px">    
                            <select id="cboSucursales" class="campotabla" name="cboSucursales" style="width:150px" onchange="return cboSucursales_onchange()">
                                <option selected value="0">&raquo; Elija una sucursal &laquo;</option>
                                <option value="-1">&raquo; Todas las sucursales &laquo;</option>
                                <%= LlenarControlSucursales()%>
                            </select>
                        </td>
                         <td class="tdtittablas" style="width: 390px" colspan="2">
                         </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    
          </table>
          <table style="width:100%;">
              <tr>
                <td colspan="4">
                    <h2>Periodo de Consulta</h2>
                </td>
            </tr>
              <tr>
                        <td class="tdtexttablebold" style="width: 150px">Fecha inicio</td>
                        <td class="tdconttablas"> 
                        <input id="dtmFechaIni" name="dtmFechaIni" class="field" size="10" maxLength="10" type="text" value="<%= strFirstDayOfMonth()%>" onKeyPress=" return dtmFecha_onKeyPress(event);"> 
                        <A href="javascript:cal1.popup()">
                          <IMG src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
											        alt="Clic para seleccionar la fecha."> 
                      </A> <br> 
                    </td>
            <td class="tdtexttablebold" style="width: 150px">Fecha fin</td>
            <td class="tdconttablas"> 
                        <input id="dtmFechaFin" name="dtmFechaFin" class="field" size="10" maxLength="10" type="text" value='<%= strFechaActual()%>' onKeyPress=" return dtmFecha_onKeyPress(event);"> 
                        <A href="javascript:cal2.popup()">
                          <IMG src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
											        alt="Clic para seleccionar la fecha."> 
                      </A> <br> 
                    </td>
        </tr>
              <%--<tr>
                  <td colspan="2" align="right">--%>
                      <%--<input class="button" id="cmdConsultar" name="cmdConsultar" value="Consultar" onclick="return cmdConsultar_onclick()" type="button">--%>
                  <%--</td>
                  <td align="right" colspan="2">
                      <input class="button" type="button" id="cmdAgregar" name="cmdAgregar" value="Agregar Solicitud" onclick=" cmdAgregar_OnClick()" /> 
                  </td>
                  
              </tr>--%>
          </table>
		<P>
            <input type="hidden" id="dtmFechaActual" name="dtmFechaActual" value='<%= strFechaActual()%>' /> 
            <input type="hidden" id="hdnTipoBusqueda" name="hdnTipoBusqueda" value='<%= Request("hdnTipoBusqueda")%>'>
            <input type="hidden" id="hdnVigencia" name="hdnVigencia" value='<%= Request("hdnVigencia")%>'>
            <input type="hidden" id="hdnTipoPromocion" name="hdnTipoPromocion" value='<%= Request("hdnTipoPromocion")%>'>
            <input type="hidden" id="hdnDelayOnFocus" name="hdnDelayOnFocus" value='0'>

            <input type="hidden" id="hdnTotalDePartidas" name="hdnTotalDePartidas" >
            <input class="button" id="cmdConsultar" name="cmdConsultar" value="Consultar" onclick="return cmdConsultar_onclick()" type="button">
		
		&nbsp;</P>
          <div id="tblResultados" class="tdconttablasrojo"></div>
		<br>
		<table cellSpacing="0" cellPadding="0" width="100%" border="0">
            <tr>
                <td class="tdpadleft5" align="left" style="width:65%;">
                    <div id="divBotones"></div>
                </td>
                <td class="tdpadleft5" align="right" style="width:35%;">
                    
                </td>
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
    //-->
</script>
</form>
    <div style="display:none;">
        <div id="divConsultaSolicitudesPagare">
            <!--Consulta-->
            <%= Me.strTablaConsultaSolicitudPagare()%> 
            
        </div>            
    </div>
    <script language="JavaScript">

        //var strTotalDePartidas = "<= strTotalDePartidas()%>"
        //parent.document.getElementById('hdnTotalDePartidas').value = strTotalDePartidas;

        if (parent.document.getElementById('tblResultados').innerHTML != '') {

            var botones = '<input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdCancelar_onclick()" style="margin-top:20px;">';
            botones = botones + '<input id="cmdImprimir" name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()" style="margin-top:20px;">';
            botones = botones + '<input name="cmdExportar" type="button" class="boton" value="Exportar" onClick="return cmdExportar_onclick()" style="margin-top:20px;">';
            parent.document.getElementById('divBotones').innerHTML = botones
        }
    </script>
    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>
