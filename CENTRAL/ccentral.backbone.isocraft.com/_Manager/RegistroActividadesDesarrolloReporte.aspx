<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistroActividadesDesarrolloReporte.aspx.vb" Inherits="com.isocraft.backbone.ccentral.RegistroActividadesDesarrolloReporte" %>

<%@ Import Namespace="Benavides.POSAdmin.Commons"%>

<html>
<head>
    <title>Benavides: Registro de Actividades</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
<%--<script language="JavaScript" type="text/JavaScript" src="../static/scripts/tools.js"></script>--%>
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

    function cmdConsultar_onclick() {

        document.getElementById('tblReporte').innerHTML = '';

        //Variables.
        var valida;

        valida = fnValidaCampos();
        if (valida) {

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultar';
            //document.forms[0].target = "ifrOculto";
            document.forms[0].submit();
        }

        return (valida);
    }

    function fnValidaCampos() {

        if (trim(document.getElementById('dtmFechaIni').value) == '' ) {

            alert('Capture la fecha por favor');
            document.getElementById('dtmFechaIni').onfocus();
            return (false);
        }
        else if (fnValidaFecha("dtmFechaIni") == false) {
            return (false);
        }
        else {
            return (true);
        }
    }

    //Validacion de fecha.
    function fnValidaFecha(dtmFechaIni) {
        valida = true;

        //Validacion de Fecha inicial
        valida = blnValidarCampo(document.getElementById(dtmFechaIni), true, "Fecha Inicial", cintTipoCampoFecha, 10, 10, "");

            //Valida que la fecha inicial NO sea mayor que la fecha final.	
            if (valida) {

                //Fecha inicial
                var dtmInicio = document.getElementById(dtmFechaIni).value;
                var diaIni = dtmInicio.substring(0, 2)
                var mesIni = dtmInicio.substring(3, 5);
                var anioIni = dtmInicio.substring(6, 10);

                //Fecha hoy
                var dtmActual = document.getElementById("dtmFechaActual").value;
                var diaActual = dtmActual.substring(0, 2);
                var mesActual = dtmActual.substring(3, 5);
                var anioActual = dtmActual.substring(6, 10);

                //Validacion
                var date1 = (anioIni + mesIni + diaIni);
                var date3 = (anioActual + mesActual + diaActual);

                //-Validaciones
                if (date1 > date3) {
                    alert('La fecha de inicio no debe ser mayor que la fecha de hoy');
                    return (false);
                }
            }

        return (valida);
    }


    function trim(stringToTrim) {
        return stringToTrim.replace(/^\s+|\s+$/g, "");
    }

    function cmdImprimir_onclick() {

        //Validacion de resultados
        var tablaTotal = document.getElementById('tblReporte').innerHTML
        if (trim(tablaTotal) == 'Consulta sin resultados' || trim(tablaTotal) == '') {
            alert('No hay resultados de la consulta')
            return (false);
        }

        var confirmar = confirm('Desea imprimir la informacion?');
        if (confirmar) {

            document.forms[0].action = "<%=strFormAction%>?strCmd=cmdImprimir";
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
        document.forms[0].target = '';

    }

    return (false);
}

function fnImprimir(strReporteAsistencia) {

    //Llamada desde el servidor para imprimir resultados de las consulta.
    document.ifrPageToPrint.document.all.divBody.innerHTML = strReporteAsistencia;
    document.ifrPageToPrint.focus();
    window.print();

}

function dtmFecha_onKeyPress(e) {

    //No se permiten caracteres especiales para la fecha.
    var key = window.event ? e.keyCode : e.which;
    if (key > 46 && key < 58) {
        return true;
    }
    else {
        return false
    }
}

function cmdExportar_onclick() {

    //Validacion de resultados
    var tablaTotal = document.getElementById('tblReporte').innerHTML
    if (trim(tablaTotal) == 'Consulta sin resultados' || trim(tablaTotal) == '') {
        alert('No hay resultados de la consulta')
        return (false);
    }

    var confirmar = confirm('Desea exportar la informacion a Excel?');

    if (confirmar) {

        document.forms[0].action = "<%=strFormAction%>?strCmd=cmdExportar";
                document.forms[0].target = "ifrOculto";
                document.forms[0].submit();
            }

            return (false);
        }

        function doSubmit(c, t, p) {

            return;
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

    
    function cmdGuardar_onclick() {

        //-01.Se valida que la tabla de resultados no este vacia
        if (trim(document.getElementById('tblReporte').innerHTML) == '') {
            return (false);
        }
  
        //-02.Inicia rutina para validar cada una de las filas y columnas en la tabla de resultados.
        var i = 0;
        var intTotal = trim(document.getElementById('hdnTotalDeActividades').value);
        var comentarios = 0;
  
        for (i = 0; i < intTotal; i++) {

            txtLunesId = 'txtLunes' + i;
            txtLunes = document.getElementById(txtLunesId);

            txtMartesId = 'txtMartes' + i;
            txtMartes = document.getElementById(txtMartesId);

            txtMiercolesId = 'txtMiercoles' + i;
            txtMiercoles = document.getElementById(txtMiercolesId);

            txtJuevesId = 'txtJueves' + i;
            txtJueves = document.getElementById(txtJuevesId);

            txtViernesId = 'txtViernes' + i;
            txtViernes = document.getElementById(txtViernesId);

            txtSabadoId = 'txtSabado' + i;
            txtSabado = document.getElementById(txtSabadoId);

            txtDomingoId = 'txtDomingo' + i;
            txtDomingo = document.getElementById(txtDomingoId);

            if ((fnValidaVacios(txtLunes) == false) ||
                (fnValidaVacios(txtMartes) == false) ||
                (fnValidaVacios(txtMiercoles) == false) ||
                (fnValidaVacios(txtJueves) == false) ||
                (fnValidaVacios(txtViernes) == false) ||
                (fnValidaVacios(txtSabado) == false) ||
                (fnValidaVacios(txtDomingo) == false)){

                return (false);
            }

            if (validaFloat(trim(txtLunes.value)) == false ||
                validaFloat(trim(txtMartes.value)) == false ||
                validaFloat(trim(txtMiercoles.value)) == false ||
                validaFloat(trim(txtJueves.value)) == false ||
                validaFloat(trim(txtViernes.value)) == false ||
                validaFloat(trim(txtSabado.value)) == false ||
                validaFloat(trim(txtDomingo.value)) == false) {
                return (false)
            }
        }

        document.forms[0].action = "<%=strFormAction%>?strCmd=cmdGuardar";
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
        document.forms[0].target = '';
    }

    function fnValidaVacios(txtDia) {

        if (trim(txtDia.value) == '') {

            alert('No se puede dejar campos vacios');
            txtDia.focus();
            return (false);
        }
        else if (trim(txtDia.value) == '.') {

            alert('Por favor ingrese un dato valido');
            txtDia.focus();
            return (false);
        }

        return(true);
    }
	
    function txtTotal_onblur(intDiaId, intActividadId) {
        
        
        //Se suma el total de horas por actividad
        txtHrsTotal_onblur(intActividadId);

        //Se actualiza la suma del total de horas por dia
        if (intDiaId == 1) { txtLunes_onblur(); }
        else if (intDiaId == 2) { txtMartes_onblur();}
        else if (intDiaId == 3) { txtMiercoles_onblur(); }
        else if (intDiaId == 4) { txtJueves_onblur(); }
        else if (intDiaId == 5) { txtViernes_onblur(); }
        else if (intDiaId == 6) { txtSabado_onblur(); }
        else if (intDiaId == 7) { txtDomingo_onblur(); }

        //Suma total general de horas
        txtHrsTotalGeneral_onblur();

    }

    function txtHrsTotal_onblur(intActividadId) {
        
        var fltHrsTotal = 0.0;

        var txtLunesId = 'txtLunes' + intActividadId;
        var txtLunes = document.getElementById(txtLunesId);

        var txtMartesId = 'txtMartes' + intActividadId;
        var txtMartes = document.getElementById(txtMartesId);

        var txtMiercolesId = 'txtMiercoles' + intActividadId;
        var txtMiercoles = document.getElementById(txtMiercolesId);

        var txtJuevesId = 'txtJueves' + intActividadId;
        var txtJueves = document.getElementById(txtJuevesId);

        var txtViernesId = 'txtViernes' + intActividadId;
        var txtViernes = document.getElementById(txtViernesId);

        var txtSabadoId = 'txtSabado' + intActividadId;
        var txtSabado = document.getElementById(txtSabadoId);

        var txtDomingoId = 'txtDomingo' + intActividadId;
        var txtDomingo = document.getElementById(txtDomingoId);

        var txtHrsTotalId = 'txtHrsTotal' + intActividadId;
        var txtHrsTotal = document.getElementById(txtHrsTotalId);
        

        //Inicia la suma de horas por actividad
        if (trim(txtLunes.value) != '') {

            fltHrsTotal = fltHrsTotal + parseFloat(trim(txtLunes.value));

            }
        if (trim(txtMartes.value) != '') {

            fltHrsTotal = fltHrsTotal + parseFloat(trim(txtMartes.value));

            }
        if (trim(txtMiercoles.value) != '') {

            fltHrsTotal = fltHrsTotal + parseFloat(trim(txtMiercoles.value));

            }
        if (trim(txtJueves.value) != '') {

            fltHrsTotal = fltHrsTotal + parseFloat(trim(txtJueves.value));

            }
        if (trim(txtViernes.value) != '') {

            fltHrsTotal = fltHrsTotal + parseFloat(trim(txtViernes.value));

            }
        if (trim(txtSabado.value) != '') {

            fltHrsTotal = fltHrsTotal + parseFloat(trim(txtSabado.value));

            }
        if (trim(txtDomingo.value) != '') {

            fltHrsTotal = fltHrsTotal + parseFloat(trim(txtDomingo.value));

            }

        txtHrsTotal.value = fltHrsTotal
    }

    function txtHrsTotalGeneral_onblur() {

        var i = 0;
        var fltHrsTotalGeneral = 0.0;
        var intTotal = trim(document.getElementById('hdnTotalDeActividades').value);

        for (i = 0; i < intTotal; i++) {

            if (trim(document.forms[0].elements['txtHrsTotal' + i].value) != '') {

                fltHrsTotalGeneral = fltHrsTotalGeneral + parseFloat(trim(document.forms[0].elements['txtHrsTotal' + i].value));
            }
        }

        document.forms[0].elements['txtHrsTotalGeneral'].value = fltHrsTotalGeneral;
    }

    function txtLunes_onblur() {

        var i = 0;
        var fltTotalLunes = 0.0;
        var intTotal = trim(document.getElementById('hdnTotalDeActividades').value);

        for (i = 0; i < intTotal; i++) {

            if (trim(document.forms[0].elements['txtLunes' + i].value) != '') {

                fltTotalLunes = fltTotalLunes + parseFloat(trim(document.forms[0].elements['txtLunes' + i].value));
                
            }
        }

        document.forms[0].elements['txtHrsTotalLunes'].value = fltTotalLunes;

    }

    function txtMartes_onblur() {

        var i = 0;
        var fltTotalMartes = 0.0;
        var intTotal = trim(document.getElementById('hdnTotalDeActividades').value);

        for (i = 0; i < intTotal; i++) {

            if (trim(document.forms[0].elements['txtMartes' + i].value) != '') {

                fltTotalMartes = fltTotalMartes + parseFloat(trim(document.forms[0].elements['txtMartes' + i].value));

            }
        }

        document.forms[0].elements['txtHrsTotalMartes'].value = fltTotalMartes;

    }

    function txtMiercoles_onblur() {

        var i = 0;
        var fltTotalMiercoles = 0.0;
        var intTotal = trim(document.getElementById('hdnTotalDeActividades').value);

        for (i = 0; i < intTotal; i++) {

            if (trim(document.forms[0].elements['txtMiercoles' + i].value) != '') {

                fltTotalMiercoles = fltTotalMiercoles + parseFloat(trim(document.forms[0].elements['txtMiercoles' + i].value));

            }
        }

        document.forms[0].elements['txtHrsTotalMiercoles'].value = fltTotalMiercoles;
    }

    function txtJueves_onblur() {

        var i = 0;
        var fltTotalJueves = 0.0;
        var intTotal = trim(document.getElementById('hdnTotalDeActividades').value);

        for (i = 0; i < intTotal; i++) {

            if (trim(document.forms[0].elements['txtJueves' + i].value) != '') {

                fltTotalJueves = fltTotalJueves + parseFloat(trim(document.forms[0].elements['txtJueves' + i].value));

            }
        }

        document.forms[0].elements['txtHrsTotalJueves'].value = fltTotalJueves;

    }

    function txtViernes_onblur() {

        var i = 0;
        var fltTotalViernes = 0.0;
        var intTotal = trim(document.getElementById('hdnTotalDeActividades').value);

        for (i = 0; i < intTotal; i++) {

            if (trim(document.forms[0].elements['txtViernes' + i].value) != '') {

                fltTotalViernes = fltTotalViernes + parseFloat(trim(document.forms[0].elements['txtViernes' + i].value));

            }
        }

        document.forms[0].elements['txtHrsTotalViernes'].value = fltTotalViernes;

    }

    function txtSabado_onblur() {

        var i = 0;
        var fltTotalSabado = 0.0;
        var intTotal = trim(document.getElementById('hdnTotalDeActividades').value);

        for (i = 0; i < intTotal; i++) {

            if (trim(document.forms[0].elements['txtSabado' + i].value) != '') {

                fltTotalSabado = fltTotalSabado + parseFloat(trim(document.forms[0].elements['txtSabado' + i].value));

            }
        }

        document.forms[0].elements['txtHrsTotalSabado'].value = fltTotalSabado;

    }

    function txtDomingo_onblur() {

        var i = 0;
        var fltTotalDomingo = 0.0;
        var intTotal = trim(document.getElementById('hdnTotalDeActividades').value);

        for (i = 0; i < intTotal; i++) {

            if (trim(document.forms[0].elements['txtDomingo' + i].value) != '') {

                fltTotalDomingo = fltTotalDomingo + parseFloat(trim(document.forms[0].elements['txtDomingo' + i].value));

            }
        }

        document.forms[0].elements['txtHrsTotalDomingo'].value = fltTotalDomingo;

    }
    //-->

    function cmdRegresar_onclick() {

        document.forms[0].action = "<%=strFormAction%>?strCmd=cmdRegresar";
        document.forms[0].submit();
        document.forms[0].target = '';
    }

    function cmdAvanzar_onclick() {

        document.forms[0].action = "<%=strFormAction%>?strCmd=cmdAvanzar"; 
        document.forms[0].submit();
        document.forms[0].target = '';
    }

    function fnComentarios_onclick(intActividadId,intRegistroActividadId, intDiaId) {
        
        document.getElementById('hdnActividadComentarioId').value = intActividadId;
        document.getElementById('txtComentarios').value = '';
        document.getElementById('hdnComentarioId').value = intRegistroActividadId;
        document.getElementById('hdnIntDiaId').value = intDiaId;

        //if (intRegistroActividadId != 0) {

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultarComentarios';
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();
        //}

        if (document.getElementById('tblComentarios').style.display == 'none') {

            document.getElementById('tblComentarios').style.display = 'block'
        }
        document.getElementById('txtComentarios').focus();
        
    }

    function txtComentarios_onKeyPress(e) {

        var key = window.event ? e.keyCode : e.wich;

        
        //No se permiten caracteres especiales para el Articulo.
        if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || (key == 32) || (key == 44) || (key == 46)) {
            return true;
        }
        else {
            return false;
        }
    }

    function validaNumerico_onKeyPress(e) {

        var key = window.event ? e.keyCode : e.wich;

        //No se permiten caracteres especiales.
        if ((key > 47 && key < 58) || (key == 46)) {
            return true;
        }
        else {
            return false;
        }
    }

    function validaFloat(numero) {
        if (!/^([0-9])*[.]?[0-9]*$/.test(numero)) {
            alert("El valor " + numero + " no es un número valido");
            return (false)
        }
    }
</script>

    </head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onload="return window_onload()">
<form name="frmRegistroActidadesDesarrolloReporte" action="about:blank" method="post">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <A href="../_Manager/InicioHome.aspx">Central</A> : Registro de Actividades : Desarrollo</td>
    </tr>
  </table>
  
    <table width="780" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="tdgeneralcontent" >
                <h1>Registro de Actividades - Sistemas</h1>
		        <p>Elija el periodo de actividades presionando el boton Consultar.<br> 
                   Una vez que el sistema muestre sus actividades se puede guardar la informacion presionando el boton Guardar.
                   Los comentarios se guardan presionando el boton Guardar antes de cambiar a un comentario de otro dia.
		        </p>
                

                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="50%" valign="top">
                            <table width="100%">
                                <tr>
                                    <td class='txsubtitulo' colspan="2"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">Período de Consulta</td>
                                </tr>
                                <tr>
                                    <td class="tdtexttablebold" style="width: 150px">Fecha inicio</td>
                                    <td class="tdconttablas"> 
                                    <input id="dtmFechaIni" name="dtmFechaIni" class="field" size="10" maxLength="10" type="text" value="<%= strFechaActual()%>" onKeyPress=" return dtmFecha_onKeyPress(event);"> 
                                    <A href="javascript:cal1.popup()">
                                      <IMG src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
											                    alt="Clic para seleccionar la fecha."> 
                                  </A>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
		        <P>
                    <input type="hidden" id="dtmFechaActual" name="dtmFechaActual" value='<%= strFechaActual()%>' />
                    <input type="hidden" id="hdnComentarioId" name="hdnComentarioId"  />
		            <input class="button" id="cmdAgregar" name="cmdAgregar" value="Consultar" onclick="return cmdConsultar_onclick()" type="button">&nbsp;		
		        </P>
                <div id="tblReporte" class="tdconttablasrojo"></div>
		        <br>
		        <br>
                
                <table id="tblComentarios" width="100%" border="0" cellpadding="0" cellspacing="0" style="DISPLAY: none">
                    <tr >
                        <td class="tdtittablas" id="tdComentarios" width="100%" align="center">
                            <TEXTAREA onKeyPress=" return txtComentarios_onKeyPress(event);" id='txtComentarios' rows='3' cols='35' maxLength="50" name='txtComentarios'></TEXTAREA>
                            <%--<input id="btnGuardarComentarios" name="btnGuardarComentarios" type="button" class="boton" value="Aplicar Comentario" onClick="return cmdGuardarComentario_onclick()">--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            
                        </td>
                    </tr>
                </table>


		        <table cellSpacing="0" cellPadding="0" width="100%" border="0">
			        <tr>
                        <td align="right" width="10%"><input language="javascript" class="button" id="btnGuardar" onclick="return cmdGuardar_onclick()"
						        type="button" value="Guardar" name="btnGuardar">
				        </td>
				        <td align="right" width="80%"><%--<input language="javascript" class="button" id="cmdRegresar" onclick="return cmdCancelar_onclick()"
						        type="button" value="Regresar" name="cmdRegresar">--%>
				        </td>
				        <td align="right" width="10%"><%--<input language="javascript" class="button" id="cmdImprimir" onclick="return cmdImprimir_onclick()"
						        type="button" value="Imprimir" name="cmdImprimir">--%>
				        </td>
                        <td align="right" width="10%"><%--<input language="javascript" class="button" id="cmdExportar" onclick="return cmdExportar_onclick()"
						        type="button" value="Exportar" name="cmdExportar">--%>
				        </td>
			        </tr>
		        </table>
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
    //-->
</script>
</form>
    <div style="display:none;">
        <div id="divConsultaReporte">
            <%= Me.strTablaConsultaReporte()%>
        </div>
        <div id="divComentarios">
            <%= Me.strConsultarComentarios()%>
        </div>            
    </div>
        <script language="JavaScript" type="text/javascript">

            if (trim(document.getElementById('tblReporte').innerHTML) == '') {
            
                document.getElementById('btnGuardar').style.display = 'none'
            }


                //Validacion para mostrar comentarios
            if ("<%= strCmd %>" == 'cmdConsultarComentarios') {
                
                document.getElementById('tblComentarios').style.display = 'block';
            }
            else {
                
                document.getElementById('tblComentarios').style.display = 'none';
            }

            if ("<%= strCmd %>" == 'cmdGuardar') {

                document.getElementById('txtComentarios').value = '';
                parent.document.getElementById('tblComentarios').style.display = 'none';

            }

            if ("<%= strCmd %>" == 'cmdConsultar') {

                document.getElementById('dtmFechaIni').value = "<%= Request.Form("dtmFechaIni")%>";
            
            }
    </script>

    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>

