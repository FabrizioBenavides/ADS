<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SucursalReporteDeVisitas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalReporteDeVisitas" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>

<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : SucursalReporteDeVisitas.aspx
    ' Title         : Reportde de Visitas.
    ' Description   : Reporte de Visitas en sucursal. 
    ' Copyright     : 2014 All rights reserved.
    ' Company       : Deintec SA de CV
    ' Author        : Carlos Vazquez
    ' Version       : 1.0
    ' Last Modified : October 07, 2014
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

        if(Impresion != ''){
            parent.document.getElementById('divImpresionHTML').innerHTML = Impresion;
            document.getElementById('divImpresionHTML').innerHTML = Impresion;
        }
					            
        return (true);
    }

function strGetCustomDateTime() {
    document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
    return (true);
}

function strTituloMigaja3() {
    document.write("Reporte de Visitas");
}
function strTituloPrincipalDePagina() {
    document.write("Consulta Reporte de Visitas en Sucursal");
}
function strDescripcionPrincipalDePagina() {
    document.write("Capture el rango de fechas, el tipo  de empleado y el empleado para que filtre su busqueda.");
}


    //Empleados
function objLupaEmpleado_onclick() {

    var valida = true;
    var intCuentaApostrofes = 0;
    var strEmpleadoCapturado = "";

    if (document.forms[0].elements['txtEmpleadoNombreId'].readOnly) {
        return (true);
    }

    strEmpleadoCapturado = document.forms[0].elements['txtEmpleadoNombreId'].value;

    if (strEmpleadoCapturado.length < 1) {

        alert("Teclear Número de empleado o descripción");
        document.forms[0].elements['txtEmpleadoNombreId'].focus();
        return (false);
    }

    intCuentaApostrofes = strEmpleadoCapturado.search("'");

    if (intCuentaApostrofes != -1) {

        document.forms[0].elements['txtEmpleadoNombreId'].value = '';
        alert("No se deben de capturar apostrofes");
        document.forms[0].elements['txtEmpleadoNombreId'].focus();
        return (false);
    }

    var strtxtEmpleadoB = Trim((document.forms[0].elements['txtEmpleadoNombreId'].value).substring(0, 4));

    if (isNaN(strtxtEmpleadoB) || strtxtEmpleadoB.length < 1) // Esta capturando Descripcion
    {

        strEvalJs = "opener.txtEmpleadoNombreId_onblur();";
        strParametros = ''
        strParametros = strParametros + ' campoProveedorId=hdnEmpleadoId';
        strParametros = strParametros + '&campoEmpleadoNombreId=txtEmpleadoNombreId';
        strParametros = strParametros + '&campoEmpleadoNombre=txtEmpleadoNombre';
        strParametros = strParametros + '&strEmpleadoId=' + document.forms[0].elements['txtEmpleadoNombreId'].value;
        strParametros = strParametros + '&strTipoEmpleadoId=' + document.getElementById("TipoEmpleado").value;
        strParametros = strParametros + '&strCompaniaId=' + "<%= intCompaniaId()%>";
        strParametros = strParametros + '&strSucursalId=' + "<%= intSucursalId()%>";
        
        if (document.getElementById("chkActivos").checked == true) {
            strParametros = strParametros + '&blnActivos=1';

        }
        else {
            strParametros = strParametros + '&blnActivos=0';
        }

        Pop('PopEmpleadoVisitas.aspx?' + strParametros + '&strEvalJs=' + strEvalJs, 500, 540);
    }
    else {

        document.forms[0].action = "<%=strFormAction%>?strCmd=BuscarEmpleado"
       document.forms[0].target = "ifrOculto";
       document.forms[0].submit();
       document.forms[0].target = '';
   }
}

function txtEmpleadoNombreId_onblur() {
    strEmpleadoCapturado = Trim(document.forms[0].elements['txtEmpleadoNombreId'].value);

    if (strEmpleadoCapturado.length > 0 && strEmpleadoCapturado != '0') {
        if (document.forms[0].elements['hdnEmpleadoNombreId'].value != document.forms[0].elements['txtEmpleadoNombreId'].value) {
            objLupaEmpleado_onclick();
        }
    }
    else {

        document.forms[0].elements['txtEmpleadoNombreId'].value = '';
        //document.forms[0].elements['txtEmpleadoNombreId'].focus();
        return true;
    }
}

function fnUpBuscarEmpleado(intEmpleadoId, strEmpleadoNombre, intError) {

    document.forms[0].elements['hdnEmpleadoId'].value = intEmpleadoId;
    document.forms[0].elements['txtEmpleadoNombreId'].value = intEmpleadoId;
    document.forms[0].elements['hdnEmpleadoNombreId'].value = strEmpleadoNombre;
    document.forms[0].elements['txtEmpleadoNombre'].value = strEmpleadoNombre;

    if (intError != 0) {
        
        document.forms[0].elements['txtEmpleadoNombreId'].focus();
        alert("Error, Empleado no encontrado");
    }
}
    //Fin Empleados

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

    function fnImprimir(strReporte) {

        //Llamada desde el servidor para imprimir resultados de la consulta.
        document.ifrPageToPrint.document.all.divContenido.innerHTML = strReporte;
        document.ifrPageToPrint.focus();
        window.print();

    }


// Mandar ventana de consulta
function Pop(url, width, height) {
    var Win = window.open(url, 'Pop', 'width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no');
    return (false);
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

function txtEmpleadoNombreId_onKeyDown() {
    if (event.keyCode == 13) { txtEmpleadoNombreId_onblur() }
    if (event.keyCode == 9) { txtEmpleadoNombreId_onblur() }

    document.getElementById('tblResultados').innerHTML = '';
    document.getElementById('txtEmpleadoNombre').value = '';
}

function txtEmpleadoNombreId_onblur() {
    strEmpleadoCapturado = Trim(document.forms[0].elements['txtEmpleadoNombreId'].value);

    if (strEmpleadoCapturado.length > 0 && strEmpleadoCapturado != '0') {
        if (document.forms[0].elements['hdnEmpleadoNombreId'].value != document.forms[0].elements['txtEmpleadoNombreId'].value) {
            objLupaEmpleado_onclick();
        }
    }
    else {
        document.forms[0].elements['txtEmpleadoNombreId'].value = '';
        return true;
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
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
    }

    return (valida);
}

        function fnValidaCampos() {

            var _empleadoId = trim(document.getElementById('txtEmpleadoNombreId').value);
            var _empleadoDes = trim(document.getElementById('txtEmpleadoNombre').value);

            if (document.getElementById('TipoEmpleado').value == "0") {

                alert('Seleccione un Tipo de Empleado');
                document.getElementById('TipoEmpleado').focus();
                return (false);
            }
            else if ((_empleadoId == '' && _empleadoDes != '') || (_empleadoId != '' && _empleadoDes == '')) {
                alert('Capture un empleado valido');
                document.getElementById('txtEmpleadoId').focus();
                return (false);
            }
            else if (trim(document.getElementById('dtmFechaIni').value) == '' || trim(document.getElementById('dtmFechaIni').value) == '') {

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

        function TipoEmpleado_onchange() {

            if (document.getElementById('tblResultados').innerHTML != '') {
                document.getElementById('tblResultados').innerHTML = '';
            }

            if (document.getElementById('TipoEmpleado').value > 0) {
                document.getElementById('hdnTipoEmpleado').value = document.getElementById('TipoEmpleado').options[document.getElementById('TipoEmpleado').selectedIndex].text;
            }
        }

        function chkActivos_onfocus() {
            if (document.getElementById('tblResultados').innerHTML != '') {
                document.getElementById('tblResultados').innerHTML = '';
            }
        }

//-->
</script>
</HEAD>
<body leftMargin="0" topMargin="0" onload="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmSucursalReporteDeVisitas" action="about:blank" method="post">
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
                <span class="txdmigaja">: <a href="javascript:strRedireccionaPOSAdmin('SucursalEmpleados.aspx');" class="txdmigaja">Empleados</a>
                    : Reporte de Visitas en Sucursal
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
                    <td class="tdtittablas" width="25%">Fecha Fin:</td>
                    <td class="tdpadleft5" width="75%" vAlign="middle"><input class="campotabla" onkeypress="cmdonKeyPressed(1,event.keyCode);" type="text" size="10"
														id="dtmFechaFin"  name="dtmFechaFin" value="<%= strFechaActual()%>"> 
                      <IMG style="CURSOR: hand" onclick="if(blnValidarCampo(document.forms(0).elements('dtmFechaFin'),false,'Fecha fin',cintTipoCampoFecha,10,10,'')){DoObjCalendar2();}"
														height="13" src="../static/images/icono_calendario.gif" width="20" align="absMiddle"></td>
                  </tr>
                    <tr>
                        <td height="29" class="tdtittablas" width="25%">Solo activos:</td>
                        <td class="tdpadleft5" vAlign="middle" width="75%"><input type="checkbox" id="chkActivos" name="chkActivos" onfocus="return chkActivos_onfocus()"/></td>
                    </tr>
                  <tr> 
                    <td height="29" class="tdtittablas" width="25%">Tipo Empleado:</td>
                    <td class="tdpadleft5" vAlign="middle" width="75%">
                        <select class="campotabla" onchange="return TipoEmpleado_onchange()" id="TipoEmpleado" name="TipoEmpleado">
                            <option selected="selected" value="0">-- Elija --</option>
                            <%--<option value="-1">Todos</option>--%>
                            <option value="1">Gerente de Zona</option>
                            <option value="2">Empleados</option>
                            <option value="3">Externos</option>
                      </select> </td>
                  </tr>
                    <tr> 
                    <td height="29" class="tdtittablas" width="25%">Empleado:</td>
                    <td class="tdpadleft5" vAlign="middle" width="75%">
                        <input name="txtEmpleadoNombreId" id="txtEmpleadoNombreId" type="text" class="campotabla"  autocomplete="off" size="16" maxlength="16" onBlur="return txtEmpleadoNombreId_onblur()" onKeyDown="txtEmpleadoNombreId_onKeyDown()" value='<%=Request.Form("txtEmpleadoNombreId")%>' > 
                          &nbsp;<a id="objLupaEmpleado" href="javascript:;" onclick="return objLupaEmpleado_onclick()"><img src="../static/images/icono_lupa.gif" width="17" height="17" align="absMiddle" border="0"></a> 
                        <input name="txtEmpleadoNombre" id="txtEmpleadoNombre" type="text" class="campotablaresultadoenvolventeazul" value='<%=Request.Form("txtEmpleadoNombre")%>' size="40" maxlength="60"  border="0" readonly tabindex="-1">
                    </td>
                  </tr>
                  <tr>
                        <td height="29" class="tdtittablas" width="25%"></td>
                        <td><input class="boton" type="button" id="cmdBuscar" name="cmdBuscar" value="Buscar" onclick="return cmdConsultar_onclick()"></td>
                    </tr>
                </table>
                <br>
                <span class="txsubtitulo"><IMG height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Reporte de visitas</span> 
                <div id="tblResultados" class="tdconttablasrojo"></div>
                <br>
                <br>
                  <div id="divBotones" > 
                  <table id="TblBotones" cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <tr> 
                      <td width="317">&nbsp;&nbsp; 
                          <div id="divImpresionHTML" style="DISPLAY:none">
					            <%=strImpresionReporte%>
                          </div>
                        <input class="boton" onclick="return cmdImprimir_onclick()" type="button" value="Imprimir"
															name="cmdImprimir"> 
                      </td>
                    </tr>
                  </table>
                </div>
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
    <tr> 
          <input type="hidden" id="hdnTipoEmpleado" name="hdnTipoEmpleado" value= '<%=Request.Form("TipoEmpleado")%>'> 
          <input type='hidden' name='hdnEmpleadoId' value= '<%=Request.Form("hdnEmpleadoId")%>'> 
          <input type='hidden' name='hdnEmpleadoNombreId' value= '<%=Request.Form("hdnEmpleadoNombreId")%>'> 
      </td>
    </tr>
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
            <%= Me.strTablaConsultaVisita()%>
        </div>            
    </div>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0"></iframe>
</body>
</HTML>
