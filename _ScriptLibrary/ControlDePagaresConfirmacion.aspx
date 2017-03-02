<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlDePagaresConfirmacion.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlDePagaresConfirmacion" %>

<%@ Import Namespace="Benavides.POSAdmin.Commons"%>

<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : ControlDePagaresConfirmacion.aspx
    ' Title         : Reportde de Solicitudes de Pagares.
    ' Description   : Reporte de solicitudes de pagares en sucursal. 
    ' Copyright     : 2015 All rights reserved.
    ' Company       : Deintec SA de CV
    ' Author        : Carlos Vazquez
    ' Version       : 1.0
    ' Last Modified : July 06, 2015
    '====================================================================	
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<meta content="Javascript Menu" name="description">
<meta content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control" name="keywords">
<LINK href="../static/css/menu.css" rel="stylesheet">
<LINK href="../static/css/menu2.css" rel="stylesheet">
<LINK href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
    //Variables Globales
    blnmControlesEncabezadoHabilitados = true;
    blnRevisando = false;

    var strPaginaAyuda
    strPaginaAyuda = "<%=strThisPageName() %>";

    function window_onload() {
        MM_preloadImages('../static/images/bsalir_on.gif', '../static/images/bayuda_on.gif');

        var Impresion = "<%=strImpresionReporte%>";

        if (Impresion != '') {
            parent.document.getElementById('divImpresionHTML').innerHTML = Impresion;
            document.getElementById('divImpresionHTML').innerHTML = Impresion;
        }

        return (true);
    }

    function strGetCustomDateTime() {
        document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
    return (true);
}


function strTituloPrincipalDePagina() {
    document.write("Consulta de Pagares Pendientes");
}
function strDescripcionPrincipalDePagina() {
    document.write("Capture el rango de fechas del pagare para realizar la busqueda.");
}

function cmdImprimir_onclick() {

    //Validacion de resultados
    var tablaTotal = document.getElementById('tblResultados').innerHTML;
    if (trim(tablaTotal) == '') {
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
        document.ifrPageToPrint.document.all.divContenido.innerHTML = strPagares;
    document.ifrPageToPrint.focus();
    window.print();

}

function DoObjCalendar1() {

    if (document.forms(0).elements('dtmFechaIni').readOnly == false) {
        document.getElementById('tblResultados').innerHTML = '';
        objCalendar1.popup()
    }
}

function DoObjCalendar2() {
    if (document.forms(0).elements('dtmFechaFin').readOnly == false) {
        document.getElementById('tblResultados').innerHTML = '';
        objCalendar2.popup()
    }
}

function cmdonKeyPressed(intObjeto, tecla) {

    if (document.getElementById('tblResultados').innerHTML != '') {
        document.getElementById('tblResultados').innerHTML = '';
    }
}

function cmdConsultar_onclick() {

    //Variables.
    var valida;

    valida = fnValidaCampos();
    if (valida) {

        document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultar';
        document.forms[0].submit();
    }

    return (valida);
}

function fnValidaCampos() {

        if (trim(document.getElementById('dtmFechaIni').value) == '' || trim(document.getElementById('dtmFechaIni').value) == '') {

        alert('Capture la fecha por favor');
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

            //Validacion
            var date1 = (anioIni + mesIni + diaIni);
            var date2 = (anioFin + mesFin + diaFin);

            //Validaciones de fecha por Tipo de Nomina (Semana y Quncena).
            var dateIni = new Date(anioIni + "/" + mesIni + "/" + diaIni);
            var dateIniDay = dateIni.getDay();

            var dateFin = new Date(anioFin + "/" + mesFin + "/" + diaFin);
            var dateFinDay = dateFin.getDay();

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

function chkActivos_onfocus() {
    if (document.getElementById('tblResultados').innerHTML != '') {
        document.getElementById('tblResultados').innerHTML = '';
    }
}

function cmdConfirmar_onclick() {
    
    if (trim(document.getElementById('tblResultados').innerHTML) == '') {
        return (false);
    }
    else if (trim(document.getElementById('hdnTotalDePartidas').value) == '') {
        return (false);
    }
    else {
        if (!fnValidaRegistros()) {
            return(false);
        }
    
    
        var confirmar = confirm('Desea confirmar los registros seleccionados?');
        if (confirmar == true) {

            //document.getElementById('tblResultados').innerHTML = parent.document.getElementById('tblResultados').innerHTML;

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConfirmar';
            //document.forms[0].target = "ifrOculto";
            document.forms[0].submit();
        }
    }
}

    function fnValidaRegistros() {

        var intPorConfirmar = 0;
        var intDeshabilitados = 0;

        var strTotalDePartidas = document.getElementById('hdnTotalDePartidas').value;
        strTotalDePartidas = parseInt(strTotalDePartidas) + 1;
        
        for (var i = 1; i < strTotalDePartidas; i++) {
            
            //ids
            idChkBox = 'chkCodigo' + i;
            trChkBox = document.getElementById(idChkBox);
            hdnConfirmadoValor = "hdnConfirmado" + i;

            //Existe
            if (Boolean(trChkBox)) {

                //Check Habilitado
                if (!trChkBox.disabled) {

                    //Check seleccionado
                    if (trChkBox.checked == true && document.getElementById(hdnConfirmadoValor).value == '0') {

                        intPorConfirmar = parseInt(intPorConfirmar) + 1;
                    }
                }
                else {
                    
                    intDeshabilitados = parseInt(intDeshabilitados) + 1;
                    
                }
            }
        }

        //Validaciones
        if (parseInt(intDeshabilitados) == strTotalDePartidas - 1) {
            return(false);
        }
        else if (parseInt(intPorConfirmar) == 0) {
            alert('Seleccione las solicitudes a confirmar.');
            return(false);
        }
        else if (parseInt(intPorConfirmar) > 0) {
            return (true);
        }
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
//-->
</script>
</HEAD>
<body leftMargin="0" topMargin="0" onload="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmControlDePagaresConfirmacion" action="about:blank" method="post">
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
            <td width="10" bgColor="#ffffff"><IMG height="8" src="../static/images/pixel.gif" width="10"></td>
            <td class="tdmigaja" width="583"> <div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en : </span><a href="javascript:strRedireccionaPOSAdmin('Sucursal.aspx');" class="txdmigaja">Sucursal</a> 
                <span class="txdmigaja">: Consulta de Pagares Pendientes
                </span></div></td>
            <td class="tdfechahora" width="182"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td class="tdtablacont" vAlign="top" width="583"><span class="txtitulo"> 
              <script language="javascript">strTituloPrincipalDePagina()</script>
              </span><span class="txcontenido"> 
              <script language="javascript">strDescripcionPrincipalDePagina()</script>
              <br>
              </span> <script language="JavaScript">crearDatosSucursal()</script> 
              <br> <div id="ToPrintHtmContenido"> 
                <span class="txsubtitulo"><IMG height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Criterios de la Consulta</span> 
                <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                  <tr> 
                    <td class="tdtittablas" width="25%">Fecha de Inicio:</td>
                    <td class="tdpadleft5" width="75%" vAlign="middle"><input class="campotabla" onkeypress="cmdonKeyPressed(1,event.keyCode);" type="text" size="10"
														id="dtmFechaIni" name="dtmFechaIni" value="<%= strFirstDayOfMonth()%>"> 
                      <IMG style="CURSOR: hand" onclick="if(blnValidarCampo(document.forms(0).elements('dtmFechaIni'),false,'Fecha de inicio',cintTipoCampoFecha,10,10,'')){DoObjCalendar1();}"
														height="13" src="../static/images/icono_calendario.gif" width="20" align="absMiddle"></td>
                  </tr>
                    <tr> 
                    <td class="tdtittablas" width="25%" style="height: 27px">Fecha Fin:</td>
                    <td class="tdpadleft5" width="75%" vAlign="middle" style="height: 27px"><input class="campotabla" onkeypress="cmdonKeyPressed(1,event.keyCode);" type="text" size="10"
														id="dtmFechaFin"  name="dtmFechaFin" value="<%= strFechaActual()%>"> 
                      <IMG style="CURSOR: hand" onclick="if(blnValidarCampo(document.forms(0).elements('dtmFechaFin'),false,'Fecha fin',cintTipoCampoFecha,10,10,'')){DoObjCalendar2();}"
														height="13" src="../static/images/icono_calendario.gif" width="20" align="absMiddle"></td>
                  </tr>
                  <tr>
                        <td height="29" class="tdtittablas" width="25%"></td>
                        <td><input class="boton" type="button" id="cmdBuscar" name="cmdBuscar" value="Buscar" onclick="return cmdConsultar_onclick()"></td>
                    </tr>
                </table>
                <br>
                <div id="tblResultados" class="tdconttablasrojo"></div>
                <br>
                  <table id="TblBotones" cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <tr> 
                        <td align="left" style="width:65%;">
                            <div id="divBotones"></div>
                        </td>
                      <td  align="right" style="width:35%;">
                          <div id="divBotnoConfirmar"></div>
                      </td>
                    </tr>
                  </table>
                <br>
              </div>
              <!-- cerramos el div ToPrintHtmContenido -->
            </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"></td>
          </tr>
          <tr> 
            <td class="tdbottom" colSpan="2"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
      <input type="hidden" id="hdnTotalDePartidas" name="hdnTotalDePartidas" >
  </table>
  <script language="JavaScript">
	<!--
    new menu(MENU_ITEMS, MENU_POS);
    new menu(MENU_ITEMS2, MENU_POS2);
    var objCalendar1 = new calendar1(document.forms[0].elements['dtmFechaIni']);
    var objCalendar2 = new calendar1(document.forms[0].elements['dtmFechaFin']);
    //-->
			</script>
</form>
    <div style="display:none;">
        <div id="divConsultaVisita">
            <%= Me.strTablaConsultaSolicitudPagares()%>
        </div>            
    </div>
    <script language="JavaScript">

        var strTotalDePartidas = "<%= strTotalDePartidas()%>";
        parent.document.getElementById('hdnTotalDePartidas').value = strTotalDePartidas;

        if (parent.document.getElementById('tblResultados').innerHTML == '') {

            //parent.document.getElementById('divBotones').innerHTML = '<input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdCancelar_onclick()" style="margin-top:20px;">';
            parent.document.getElementById('divBotnoConfirmar').innerHTML = '';
        }
        else {
            //var botones = '<input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdCancelar_onclick()" style="margin-top:20px;">';
            var botones = '<input id="cmdImprimir" name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()" style="margin-top:20px;">';
            botones = botones + '<input name="cmdExportar" type="button" class="boton" value="Exportar" onClick="return cmdExportar_onclick()" style="margin-top:20px;">';
            parent.document.getElementById('divBotones').innerHTML = botones
            parent.document.getElementById('divBotnoConfirmar').innerHTML = '<input name="cmdConfirmar" type="button" class="boton" value="Confirmar" onClick="return cmdConfirmar_onclick()" style="margin-top:20px;">';

        }
    </script>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0"></iframe>
</body>
</HTML>
