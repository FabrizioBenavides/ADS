<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SucursalControlDePagaresAlta.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalControlDePagaresAlta" %>

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

        var _intSolicitudPagareId = "<%= intSolicitudPagareId()%>";
        parent.document.getElementById('intSolicitudPagareId').value = _intSolicitudPagareId;

        return (true);
    }

    function strGetCustomDateTime() {
        document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
        return (true);
    }

    function frmConsultarPromociones_onsubmit() {
        return (true);
    }

    function trim(stringToTrim) {
        return stringToTrim.replace(/^\s+|\s+$/g, "");
    }

    function frmAltaPagares_onsubmit(objForm) {
    
        return fnValidaCampos();
    }

    function fnValidaCampos() {
        var valida;

        var _afiliacionId = trim(document.getElementById('txtAfiliacionId').value);
        var _afiliacionDes = trim(document.getElementById('txtDescripcionSucursalPagare').value);

        if ((_afiliacionId == '') || (_afiliacionDes == '') || (_afiliacionDes == 'Consulta sin resultados')) {//Falta la validacion con el hdnfield

            alert('Capture un numero de afiliacion valido');

            document.getElementById('txtAfiliacionId').value = '';
            document.getElementById('txtDescripcionSucursalPagare').value = '';
            document.getElementById('txtAfiliacionId').focus();

            return (false);
        }

        if (trim(document.getElementById('txtAutorizacion').value) == '' || trim(document.getElementById('txtAutorizacion').value) == '0') {

            alert('Capture un numero de autorizacion valido');
            document.getElementById('txtAutorizacion').focus();
            return (false);
        }

        if (trim(document.getElementById('txtImporte').value) == '' || trim(document.getElementById('txtImporte').value) == '.') {

            alert('Por favor capture el importe');
            document.getElementById('txtImporte').focus();
            return (false);
        }
        else {

            if (validaFloat(trim(document.getElementById('txtImporte').value)) == false) {
                return (false);
            }
        }

        if (trim(document.getElementById('dtmFechaPagare').value) == '') {

            alert('Por favor capture la fecha');
            document.getElementById('dtmFechaPagare').focus();
            return (false);
        }
        else {

            //Validacion de Fecha inicial
            valida = blnValidarCampo(document.getElementById('dtmFechaPagare'), true, "Fecha Inicial", cintTipoCampoFecha, 10, 10, "");
        }

        return (valida);

    }

    function validaFloat(numero) {
        if (!/^([0-9])*[.]?[0-9]*$/.test(numero)) {
            alert("El valor " + numero + " no es un número valido");
            return (false)
        }
    }

    function txtAfiliacionId_onKeyPress(e) {

        //Se limpia la descripcion del articulo 
        document.forms[0].elements['txtDescripcionSucursalPagare'].value = '';

        //Se validan los caracteres permitidos.
        var key = window.event ? e.keyCode : e.wich;

            //No se permiten caracteres especiales para el Articulo.
         if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123)) {
            return true;
        }
        else {
            return false;
        }
    }

    function txtAfiliacionId_onblur() {

        if (trim(document.forms[0].elements['txtAfiliacionId'].value) == '') {
            document.forms[0].elements['txtAfiliacionId'].value = '';
            document.forms[0].elements['txtDescripcionSucursalPagare'].value = '';
            return false;
        }

        objAfiliacionLupa_onClick();
    }

    function objLupaArticulo_onclick() {

        if (trim(document.getElementById('txtAfiliacionId').value) == '') {
            return (false);
        }

        txtAfiliacionId_onblur();
    }

    function objAfiliacionLupa_onClick() {

        document.getElementById('tblResultados').value = '';
        
        if ((trim(document.forms[0].elements['txtAfiliacionId'].value) != "") && (trim(document.getElementById('txtDescripcionSucursalPagare').value) != 'Consulta sin resultados')) {

            if (!isNaN(document.forms[0].elements['txtAfiliacionId'].value)) {

                // Es un numero
                if (document.forms[0].elements['txtAfiliacionId'].value != '0') {

                    document.forms[0].action = "<%=strFormAction%>?strCmd=BuscarSucursalPagare";
                    document.forms[0].target = "ifrOculto";
                    document.forms[0].submit();
                    document.forms[0].target = '';
                    return (true);
                }
            }
            else {

                // Es una descripcion
                document.forms[0].elements['txtDescripcionSucursalPagare'].value = '';

                strParametros = '';
                strParametros = strParametros + '?strAfiliacionId=' + document.forms[0].elements['txtAfiliacionId'].value;
                strParametros = strParametros + '&strSucursalNombreId=txtDescripcionSucursalPagare'
                strParametros = strParametros + '&strAfiliacion=txtAfiliacionId'
                Pop('PopSucursalPagare.aspx' + strParametros, 500, 540);
        }
    }
    else {

        document.forms[0].elements['txtAfiliacionId'].value = '';
        document.forms[0].elements['txtDescripcionSucursalPagare'].value = '';

        alert("Teclear número de afiliación o descripción");
        return (false);
    }
}

function txtAutorizacionId_onKeyPress(e) {

    //Se validan los caracteres permitidos.
    var key = window.event ? e.keyCode : e.wich;

    //Solo se permiten caracteres alfanumericos.
    if (key > 47 && key < 58) {
        return true;
    }
    else {
        return false;
    }
}

    //Por Sucursal
    function txtImporte_onKeyPress(e) {

        var key = window.event ? e.keyCode : e.wich;

        if (key == 46) {
            
            var _importe = trim(document.getElementById('txtImporte').value);

            if (_importe.indexOf('.') >= 0) {
                return (false);
            }
        }

        //No se permiten caracteres especiales.
        if ((key > 47 && key < 58) || (key == 46)) {
            return true;
        }
        else {
            return false;
        }
    }

    function cmdGuardar_onclick() {
        
            //Variables.
            var valida = fnValidaCampos();
    
                if (valida) {
    
                    document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdGuardar';
                    //document.forms[0].target = "ifrOculto";
                    //document.forms[0].target = '_self';
                    document.forms[0].submit();
                }

        return (valida);
    }

    //Validacion de fecha.
    function ValidaFechas(dtmFechaPagare) {
        valida = true;

        //Validacion de Fecha inicial
        valida = blnValidarCampo(document.getElementById(dtmFechaPagare), true, "Fecha Inicial", cintTipoCampoFecha, 10, 10, "");

        return (valida);
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

        function fnImprimir(strPromociones) {

            //Llamada desde el servidor para imprimir resultados de la consulta.
            document.ifrPageToPrint.document.all.divBody.innerHTML = strPromociones;
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

        function Pop(url, width, height) {
            var Win = window.open(url, 'Pop', 'width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no');
            return false;
        }

        function dtmFecha_onKeyPress(e) {

            //document.getElementById('tblResultados').innerHTML = '';

            //No se permiten caracteres especiales para la fecha.
            var key = window.event ? e.keyCode : e.which;
            if (key > 46 && key < 58) {
                return true;
            }
            else {
                return false
            }
        }

        function cmdCancelar_onclick() {
            window.location.href = "InicioHome.aspx";
        }

        function cmdEliminar_onclick(id) {

            var _confirm = confirm('Desea eliminar esta solicitud?');
            if (_confirm) {

                document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdEliminar';
                document.forms[0].target = "ifrOculto";
                document.forms[0].submit();

                return (true);
            }
        }

    function fnLimpiarCampos() {

        parent.document.getElementById('tblResultados').innerHTML = '';
        parent.document.getElementById('txtAfiliacionId').value = '';
        parent.document.getElementById('txtDescripcionSucursalPagare').value = '';
        parent.document.getElementById('txtAutorizacion').value = '';
        parent.document.getElementById('txtImporte').value = '';
        parent.document.getElementById('dtmFechaPagare').value = ''

        //alert('La solicitud se elimino con exito!');
        //parent.window.location.href = "SucursalControlDePagaresConsulta.aspx";
                                
        window.top.location.href = "SucursalControlDePagaresConsulta.aspx";
    }

    function cmdLimpiar_onclick() {

        document.getElementById('intSolicitudPagareId').value = '0';
        document.getElementById('txtAfiliacionId').value = '0';
        document.getElementById('txtDescripcionSucursalPagare').value = '';
        document.getElementById('txtAutorizacion').value = '0';
        document.getElementById('txtImporte').value = '0';
        document.getElementById('dtmFechaPagare').value = "<%= strFirstDayOfMonth()%>";

        document.forms[0].action = '<%= strThisPageName%>';
        //document.forms[0].target = "ifrOculto";
        //document.forms[0].target = '_self';
        document.forms[0].submit();
    }

        //-->
</script>

    </head>

<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onload="return window_onload()">
<form id="frmAltaPagares" name="frmAltaPagares" action="about:blank" method="post" >
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <A href="../_Manager/InicioHome.aspx">Central</A> : Alta Pagares </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
      <tr>
      <td class="tdgeneralcontent">
          <div id="divTitulo"></div>
          <h1>Control de Pagares</h1>
		<p>Llene los campos del pagare a solicitar y presione el boton Guardar para crear la solicitud. </p>
		<table style="width:100%;">
            <tr>
                <td colspan="4">
                    <h2>Alta de solicitud de pagares a sucursales</h2>
                </td>
            </tr>
            <tr>
                <td class="tdtexttablebold" style="width: 150px">
                    Afiliacion:
                </td>
                <td class="tdtittablas" style="width: 150px">
                    <input language='javascript' id="txtAfiliacionId" type="text" name="txtAfiliacionId" maxLength="16" size="16"  class="campotabla" onKeyPress=" return txtAfiliacionId_onKeyPress(event);" value='<%=Request.Form("txtAfiliacionId")%>' onblur="objAfiliacionLupa_onClick()" autocomplete='off'> 
                    <IMG style="CURSOR:pointer;" id="objLupaArticulo" onclick="javascript:objAfiliacionLupa_onClick()" border="0" align="absMiddle" src="../static/images/icono_lupa.gif" width="17" height="17">
                </td>        
                <td class="tdtexttablebold" colspan="2">
                    <input class="campotablaresultado" id="txtDescripcionSucursalPagare" name="txtDescripcionSucursalPagare" value='<%= Request.Form("txtDescripcionSucursalPagare") %>' readonly size="50" type="text" />
                </td>
            </tr>
            <tr>
                <td class="tdtexttablebold" style="width: 150px">
                    Autorizacion:
                </td>
                <td class="tdtittablas" style="width: 150px" >
                    <input type="text" id="txtAutorizacion" name="txtAutorizacion" maxLength="16" size="16"  class="campotabla" onKeyPress=" return txtAutorizacionId_onKeyPress(event);" value='<%=Request.Form("txtAutorizacion")%>' autocomplete='off'> 
                </td>        
                <td class="tdtexttablebold" colspan="2">
                </td>
            </tr>
            <tr>
                <td class="tdtexttablebold" style="width: 150px">
                    Importe:
                </td>
                <td class="tdtittablas" style="width: 150px" >
                    <input language='javascript' id="txtImporte" type="text" name="txtImporte" maxLength="16" size="16"  class="campotabla"  onKeyPress=" return txtImporte_onKeyPress(event);" value='<%=Request.Form("txtImporte")%>' autocomplete='off'> 
                </td>        
                <td class="tdtexttablebold">
                </td>
            </tr>
            <tr>
                <td class="tdtexttablebold" style="width: 150px">Fecha:
                </td>
                <td class="tdtittablas" style="width: 150px">
                            <input id="dtmFechaPagare" name="dtmFechaPagare" class="field" size="10" maxLength="10" type="text" value="<%= strFirstDayOfMonth()%>" onKeyPress=" return dtmFecha_onKeyPress(event);">
                            <A href="javascript:cal1.popup()">
                          <IMG src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
											        alt="Clic para seleccionar la fecha."> 
                      </A> <br>
                </td>
            </tr>
		</table>
		<P>
            <input type="hidden" id="intSolicitudPagareId" name="intSolicitudPagareId" >

            <input type="hidden" id="dtmFechaActual" name="dtmFechaActual" value='<%= strFechaActual()%>' /> 
            <input type="hidden" id="hdnTipoBusqueda" name="hdnTipoBusqueda" value='<%= Request("hdnTipoBusqueda")%>'>
            <input type="hidden" id="hdnVigencia" name="hdnVigencia" value='<%= Request("hdnVigencia")%>'>
            <input type="hidden" id="hdnTipoPromocion" name="hdnTipoPromocion" value='<%= Request("hdnTipoPromocion")%>'>
            <input type="hidden" id="hdnDelayOnFocus" name="hdnDelayOnFocus" value='0'>
            

            <input class="button" id="cmdGuardar" name="cmdGuardar" value="Guardar" onclick="return cmdGuardar_onclick()" type="button">
            <input class="button" id="cmdLimpiar" name="cmdLimpiar" value="Limpiar campos" onclick="return cmdLimpiar_onclick()" type="button">
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
    var cal1 = new calendar(null, document.forms[0].elements["dtmFechaPagare"]);
    //-->
</script>
</form>
    <div style="display:none;">
        <div id="divConsultaPromociones">
            <!--Consulta-->
            <%= Me.strTablaConsultaPagare()%> 
            
            <!--Sucursal-->
            <%= Me.strTablaConsultaCodigoSucursal()%>

        </div>            
    </div>
    <script language="JavaScript">

        if ("<%= strCmd%>" == "cmdEliminar") {

            fnLimpiarCampos();
            
        }
    </script>
    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>
