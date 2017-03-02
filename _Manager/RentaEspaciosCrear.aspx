<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RentaEspaciosCrear.aspx.vb" Inherits="com.isocraft.backbone.ccentral.RentaEspaciosCrear" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
<HEAD>
<title>Benavides: Exhibiciones adicionales</title>
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
    <link href="css/menu.css" rel="stylesheet" type="text/css">
    <LINK rel="stylesheet" type="text/css" href="css/estilo.css">
    <script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="../static/scripts/tools.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/calendario.js"></script>
    <script language="JavaScript" type="text/JavaScript" src="js/cal_format00.js"></script>
    <script id="clientEventHandlersJS" language="javascript">

<!--
    strUsuarioNombre = "<%= strUsuarioNombre %>";
    strFechaHora = "<%= strHTMLFechaHora %>";

    function window_onload() {
        document.forms[0].action = "<%= strFormAction %>";

        var strExhibicionId = "<%= strExhibicionId()%>"; 
        document.forms[0].elements['hdnExhibicionCodigo'].value = strExhibicionId;

        //Se llenan los combos Division y Categoria.
        <%= LlenarControlDivision()%>
        <%= LlenarControlCategoria()%>

        <%= LlenarControlCatman()%>
        <%= LlenarControlSocioComercial()%>
        
        <%= LlenarControlTipoRenta()%>
        <%= LlenarControlTipoExhibicion()%>
        <%= LlenarControlEspacioPublicitario()%>
        <%= LlenarControlPlanSalida()%>
        <%= LlenarControlTipoPlanograma()%>
        <%= LlenarControlEstatus()%>

        //NUEVO
        if (strExhibicionId == 0) {

            document.getElementById('divTitulo').innerHTML = '<h1>Exhibiciones Adicionales - Nuevo</h1>';
            document.getElementById('cmdRegresar').value = 'Regresar';

            //Fechas
            document.getElementById('dtmFechaIni').value = '<%= strFirstDayOfMonth()%>';
            document.getElementById('dtmFechaFin').value = '<%= strLastDayOfMonth()%>';

            //Estatus
            document.getElementById('cboEstatus').selectedIndex = 1;
            document.getElementById('cboEstatus').disabled = true;

            document.getElementById('txtComentariosPlanSalida').value = '<%= strComentarios()%>';
        }
        else {

            document.getElementById('divTitulo').innerHTML = '<h1>Exhibiciones Adicionales - Editar</h1>';
            document.getElementById('cmdRegresar').value = 'Cancelar';

            document.getElementById('cboDivisionArticulos').value = '<%= strDivision()%>';
            document.getElementById('cboCategoriaArticulos').value = '<%= strCategoria()%>';
            document.getElementById('cboCatman').value = '<%= strCatman()%>';
            document.getElementById('cboSocioComercial').value = '<%= strSocioComercial()%>';
            document.getElementById('txtProveedorNombreId').value = '<%= strProveedorId()%>';
            document.getElementById('txtProveedorRazonSocial').value = '<%= strProveedorDescripcion()%>';
            document.getElementById('cboTipoRenta').value = '<%= strTipoRenta()%>';
            document.getElementById('cboTipoExhibicion').value = '<%= strTipoExhibicion()%>';
            document.getElementById('cboTipoEspacioPublicitario').value = '<%= strTipoEspacioPublicitario()%>';
            document.getElementById('txtNombreExhibicion').value = '<%= strNombreExhibicion()%>';
            document.getElementById('cboPlanSalida').value = '<%= strPlanSalida()%>';

            document.getElementById('txtComentariosPlanSalida').value = '<%= strComentarios()%>';
            document.getElementById('cboTipoPlanograma').value = '<%= strTipoPlanograma()%>'; 
            document.getElementById('txtPlanogramaId').value = '<%= strPlanogramaId()%>';
            document.getElementById('txtPlanogramaDescripcion').value = '<%= strPlanogramaDescripcion()%>';
            document.getElementById('txtCostoMerchandising').value = '<%= strCostoMerchandising()%>';
            document.getElementById('txtCostoCatman').value = '<%= strCostoCatMan()%>';
            document.getElementById('txtIngresoTotMerch').value = '<%= strIngresoTotalMerch()%>';
            document.getElementById('txtIngresoTotCatman').value = '<%= strIngresoTotalCatman()%>';
            document.getElementById('txtIngresoTotal').value = '<%= strIngresoTotal()%>';
            document.getElementById('cboEstatus').value = '<%= strEstatusId()%>';
            document.getElementById('dtmFechaIni').value = '<%= strFechaInicio()%>';
            document.getElementById('dtmFechaFin').value = '<%= strFechaFin()%>';

            document.getElementById('cboEstatus').disabled = false;
        }
        cboTipoRenta_onchange();
    }

function cmdCancelar_onclick() {
    window.location.href = "RentaEspaciosConsulta.aspx";
}

function frmConsultaRentaEspacios_onsubmit() {
    return true
}

function validaFloat(numero) {
    if (!/^([0-9])*[.]?[0-9]*$/.test(numero)) {
        alert("El valor " + numero + " no es un número valido");
        return (false)
    }
}


function cmdGuardar_onclick() {
    var valida = true;

    //Todos los campos son obligatorios    
    if (fnValidarCampos() == false){
        return (false);
    }
    
    var strRutaArchivo = trim(document.getElementById('txtArchivo').value);
    
    var strExtension = strRutaArchivo.substring(strRutaArchivo.lastIndexOf("."));

    if ((strRutaArchivo != '') && (strExtension != ".jpg" && strExtension != ".png" && strExtension != ".gif")) {
        alert('La extension del archivo debe ser .png, .jpg o .gif.');
        return (false);
    }

    if (document.getElementById('dtmFechaIni').value == '' || document.getElementById('dtmFechaIni').value == '') {

        alert('Capture la fecha por favor');
        return (false);
    }

    valida = ValidaFechas("dtmFechaIni", "dtmFechaFin")

    if (validaFloat(trim(document.getElementById('txtIngresoTotal').value)) == false || 
        validaFloat(trim(document.getElementById('txtCostoCatman').value)) == false ||
        validaFloat(trim(document.getElementById('txtCostoMerchandising').value)) == false ||
        validaFloat(trim(document.getElementById('txtIngresoTotMerch').value)) == false ||
        validaFloat(trim(document.getElementById('txtIngresoTotCatman').value)) == false) {
        return (false)
    }

    return (valida)
}

function fnFocusEnControl(control) {
    document.forms[0].elements[control].focus();
}
//Valida que los campos no esten vacios
function fnValidarCampos() {

    if (document.getElementById('cboDivisionArticulos').value == '0') { fnFocusEnControl('cboDivisionArticulos'); alert('El campo División es obligatorio'); return (false); }
    else if (document.getElementById('cboCategoriaArticulos').value == '0') { fnFocusEnControl('cboCategoriaArticulos'); alert('El campo Categoría es obligatorio'); return (false); }
    else if (document.getElementById('cboCatman').value == '0') { fnFocusEnControl('cboCatman'); alert('El campo Catman es obligatorio'); return (false); }
    else if (trim(document.getElementById('cboSocioComercial').value) == 0) { fnFocusEnControl('cboSocioComercial'); alert('El campo Socio Comercial es obligatorio'); return (false); }
    else if (trim(document.getElementById('txtProveedorRazonSocial').value) == '') { fnFocusEnControl('txtProveedorNombreId'); alert('El campo Proveedor es obligatorio'); return (false); }
    else if (document.getElementById('cboTipoRenta').value == '0') { fnFocusEnControl('cboTipoRenta'); alert('El campo Tipo de Renta es obligatorio'); return (false); }
    else if (document.getElementById('cboTipoRenta').value == '1' && document.getElementById('cboTipoExhibicion').value == '0') { fnFocusEnControl('cboTipoExhibicion'); alert('El campo Tipo de Exhibición es obligatorio'); return (false); }
    else if (document.getElementById('cboTipoRenta').value == '2' && document.getElementById('cboTipoEspacioPublicitario').value == '0') { fnFocusEnControl('cboTipoEspacioPublicitario'); alert('El campo Espacio de Publicitario es obligatorio'); return (false); }
    else if (trim(document.getElementById('txtNombreExhibicion').value) == '') { fnFocusEnControl('txtNombreExhibicion'); alert('El campo Nombre de la Exhibición es obligatorio'); return (false); }
    else if (document.getElementById('cboPlanSalida').value == '0') { fnFocusEnControl('cboPlanSalida'); alert('El campo Plan de Salida es obligatorio'); return (false); }
    else if (document.getElementById('cboEstatus').value == '0' && document.getElementById('hdnExhibicionCodigo').value > 0) { fnFocusEnControl('cboEstatus'); alert('El campo Estatus es obligatorio'); return (false); }
    else if (document.getElementById('cboTipoPlanograma').value == '0') { fnFocusEnControl('cboTipoPlanograma'); alert('El campo Tipo de Planograma es obligatorio'); return (false); }
    else if (trim(document.getElementById('txtPlanogramaDescripcion').value) == '') { fnFocusEnControl('txtPlanogramaId'); alert('El campo Planograma es obligatorio'); return (false); }
    else if (trim(document.getElementById('txtIngresoTotal').value) == '') { fnFocusEnControl('txtIngresoTotal'); alert('El campo Precio es obligatorio'); return (false); }
    else if (trim(document.getElementById('txtCostoCatman').value) == '') { fnFocusEnControl('txtCostoCatman'); alert('El campo Costo Catman es obligatorio'); return (false); }
    else if (trim(document.getElementById('txtCostoMerchandising').value) == '') { fnFocusEnControl('txtCostoMerchandising'); alert('El campo Costo de Merchandising es obligatorio'); return (false); }
    else if (trim(document.getElementById('txtIngresoTotMerch').value) == '') { fnFocusEnControl('txtIngresoTotMerch'); alert('El campo Costo de Publicidad es obligatorio'); return (false); }
    else if (trim(document.getElementById('txtIngresoTotCatman').value) == '') { fnFocusEnControl('txtIngresoTotCatman'); alert('El campo Costo de Proveedor es obligatorio'); return (false); }
    else if (trim(document.getElementById('txtArchivo').value) == '' && document.getElementById('hdnExhibicionCodigo').value == '0') { fnFocusEnControl('txtArchivo'); alert('El campo de la Imagen es obligatorio'); return (false); }
    else { return (true); }
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

            if (date1 > date2) {
                alert('La fecha de inicio no debe ser mayor');
                return (false);
            }
        }
    }

    return (valida);
}

function trim(stringToTrim) {
    return stringToTrim.replace(/^\s+|\s+$/g, "");
}

//Planograma
function cmdVerificarPlanograma_onclick() {

    if (document.getElementById('txtPlanogramaId').value != '') {
        var url = 'PopPlanograma.aspx?strPlanograma=txtPlanogramaId&amp;strPlanogramaNombreId=txtPlanogramaDescripcion';

        var width = 400;
        var height = 540;
        url = url + '&strPlanogramaBuscar=' + document.forms[0].elements['txtPlanogramaId'].value;
        Pop(url, width, height);
    }
    else {
        //Si el codigo de Planograma esta vacio
        alert('Por favor capture el código o descripción del planograma.')
    }
}

function txtPlanogramaId_onKeyPress(e) {

    //Se limpia la descripcion del articulo y se validan los caracteres permitidos.
    document.getElementById('txtPlanogramaDescripcion').value = '';

    //No se permiten caracteres especiales para el Articulo.
    var key = window.event ? e.keyCode : e.which;
    if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || (key == 32)) {
        return true;
    }
    else {
        return false
    }
}

function txtPlanograma_onblur() {
    if (trim(document.getElementById('txtPlanogramaId').value) == '') {
        document.getElementById('txtPlanogramaDescripcion').value = '';
    }
}

function txtArticuloId_onKeyPress(e) {

    //Se limpia la descripcion del articulo y se validan los caracteres permitidos.
    document.forms[0].elements['txtPromocionDescripcion'].value = '';

    var key = window.event ? e.keyCode : e.wich;

    //No se permiten caracteres especiales para el Articulo.
    if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || (key == 32)) {
        return true;
    }
    else {
        return false;
    }
}

function fnImprimir(strPromocioneAvanzada) {

    //Llamada desde el servidor para imprimir resultados de las consulta.
    document.ifrPageToPrint.document.all.divBody.innerHTML = strPromocioneAvanzada;
    document.ifrPageToPrint.focus();
    window.print();
}

    //PROVEEDOR             
function txtProveedorId_onKeyPress(e) {

    //Se limpia la descripcion del articulo y se validan los caracteres permitidos.
    document.forms[0].elements['txtProveedorRazonSocial'].value = '';

    var key = window.event ? e.keyCode : e.wich;

    //No se permiten caracteres especiales para el Articulo.
    if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || (key == 32)) {
        return true;
    }
    else {
        return false;
    }
}

function txtProveedorNombreId_onblur() {
    if (trim(document.getElementById('txtProveedorNombreId').value) == '') {
        document.getElementById('txtProveedorRazonSocial').value = '';
    }
}

function cmdVerificarProveedor_onclick() {

    var valida = true;
    var intCuentaApostrofes = 0;
    var strtxtProveedorNombreId = trim(document.forms[0].elements['txtProveedorNombreId'].value);

    //Validacion de Id de proveedor
    if (strtxtProveedorNombreId.length < 1 || strtxtProveedorNombreId == '') {
        alert("Teclear Número de proveedor o descripción");
        document.forms[0].elements['txtProveedorNombreId'].focus();
        return (false);
    }

    //Validacion de apostrofes en Id Proveedor
    intCuentaApostrofes = strtxtProveedorNombreId.search("'");

    if (intCuentaApostrofes != -1) {
        document.forms[0].elements['txtProveedorNombreId'].value = '';
        alert("No se deben de capturar apostrofes");
        document.forms[0].elements['txtProveedorNombreId'].focus();
        return (false);
    }

    //Se muestran resutados en base al Id de proveedor tecleado por usuario.
    strEvalJs = 'opener.txtProveedorNombreId_onblur();';
    strParametros = ''
    strParametros = strParametros + ' campoProveedorId=hdnProveedorId';
    strParametros = strParametros + '&campoProveedorNombreId=txtProveedorNombreId';
    strParametros = strParametros + '&campoProveedorRazonSocial=txtProveedorRazonSocial';
    strParametros = strParametros + '&strProveedorId=' + document.forms[0].elements['txtProveedorNombreId'].value;

    Pop('PopProveedor.aspx?' + strParametros + '&strEvalJs=' + strEvalJs, 500, 540);
}

function fnUpBuscarProveedor(intProveedorId, strProveedorNombreId, strProveedorRazonSocial, strProveedorRFC, intError) {

    if (intError == 0) {
        document.forms(0).hdnProveedorId.value = intProveedorId;
        document.forms(0).hdnProveedorNombreId.value = strProveedorNombreId;
        document.forms(0).txtProveedorRazonSocial.value = strProveedorNombreId;
        document.forms(0).txtProveedorRazonSocial.value = strProveedorRazonSocial;
    }
    else {
        alert("Proveedor no encontrado.");

        document.forms(0).hdnProveedorId.value = '';

        document.forms(0).hdnProveedorNombreId.value = '';
        document.forms(0).txtProveedorRazonSocial.value = '';
        document.forms(0).txtProveedorRazonSocial.value = '';

        document.forms(0).txtProveedorRazonSocial.focus();
        document.forms(0).txtProveedorRazonSocial.select();
    }
}
    //FIN DE PROVEEDOR

function Pop(url, width, height) {
    var Win = window.open(url, 'Pop', 'width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no');
    return false;
}

function cmdRegresar_onclick() {
    window.location.href = "RentaEspaciosConsulta.aspx";
}

//Funcionalidad de combos Division y Categoria
function cboDivisionArticulos_onchange() {
    document.forms[0].elements["cboCategoriaArticulos"].selectedIndex = 0;
    document.forms[0].submit();
}

//Funcionalidad de combos Tipo de exhibicion y Tipo de mueble
function cboTipoExhibicion_onchange() {
    document.forms[0].elements["cboTipoExhibicion"].selectedIndex = 0;
    document.forms[0].submit();
}

function cboTipoRenta_onchange() {
    var idTipoRenta = document.forms[0].elements["cboTipoRenta"].selectedIndex;

    if (idTipoRenta == 1) {

        document.forms[0].elements["cboTipoEspacioPublicitario"].selectedIndex = 0;
        document.getElementById("cboTipoEspacioPublicitario").disabled = true;
        document.getElementById("cboTipoExhibicion").disabled = false;
        //document.getElementById("cboTipoExhibicion").focus();
    }
    else if (idTipoRenta == 2) {

        document.forms[0].elements["cboTipoExhibicion"].selectedIndex = 0;
        document.getElementById("cboTipoEspacioPublicitario").disabled = false;
        document.getElementById("cboTipoExhibicion").disabled = true;
        //document.forms[0].elements["cboTipoEspacioPublicitario"].focus();
    }
    else {
        document.forms[0].elements["cboTipoEspacioPublicitario"].selectedIndex = 0;
        document.forms[0].elements["cboTipoExhibicion"].selectedIndex = 0;
    }
}

//Validacion de cajas de texto 
function validaAlfanumerico_onKeyPress(e) {

    var key = window.event ? e.keyCode : e.wich;
    //No se permiten caracteres especiales.
    if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || (key == 32)) {
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

//-->
		</script>
</HEAD>
<body language="javascript" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onload="return window_onload()">
<form id="frmCrearRentaEspacios" name="frmCrearRentaEspacios" onSubmit="return frmConsultaRentaEspacios_onsubmit()" method="post" action="about:blank"  runat="server">
  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
    <tr> 
      <td> <script language="JavaScript">crearTablaHeader()</script> </td>
    </tr>
  </table>
  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
    <tr> 
      <td width="10">&nbsp;</td>
      <td class="tdtab" width="770">Está en : <A href="../_Manager/InicioHome.aspx">Central</A> 
        : Exhibiciones Adicionales </td>
    </tr>
  </table>
    
  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
      <tr>
         <td class="tdgeneralcontent">
             <table border="0" cellSpacing="0" cellPadding="0" style="width:100%;">
                  <tr>
                      <td style="width:760px;"><div id="divTitulo"></div></td>
                      <td style="width:20px;">&nbsp;</td>
                  </tr>
            </table>
        <table border="0" cellSpacing="0" cellPadding="0" style="width:100%;">
            <tr>
                <td colspan="2">
                    <h2>Datos Generales:</h2>
                </td>
            </tr>
            <tr> 
            <td class="tdtexttablebold" style="width:140px;">División:</td>
            <td class="tdpadleft5" style="width:150px;">
                <select id="cboDivisionArticulos" name="cboDivisionArticulos" class="campotabla" onchange="return cboDivisionArticulos_onchange()" style="width:150px">
                    <option selected="selected" value="0">Seleccione</option>
                </select> 
            </td>
            <td style="width:15px;"></td>
            <td class="tdtexttablebold" style="width:90px;" align="left">Categoría:</td>
            <td class="tdconttablas" style="width:150px;">
                <select id="cboCategoriaArticulos" class="campotabla" name="cboCategoriaArticulos" class="campotabla" style="width:150px">
				    <option selected="selected" value="0">Seleccione</option>
				</select>
            </td>
            <td style="width:15px;"></td>
            <td class="tdtexttablebold" style="width:105px;" align="left">CATMAN:</td>
            <td class="tdconttablas" style="width:115px">
                <select id="cboCatman" class="campotabla" name="cboCatman" style="width:115px">
                <option selected value="0">Seleccione</option>
              </select>
            </td>
          </tr>
            <tr>
                <td class="tdtexttablebold" style="width:140px;">Socio comercial:</td>
                <td class="tdconttablas" style="width:150px;">
                    <select id="cboSocioComercial" name="cboSocioComercial" class="campotabla" style="width:150px">
                    <option selected="selected" value="0">Seleccione</option>
                </select>
                </td>
                <td style="width:15px;"></td>
                <td class="tdtexttablebold" style="width:90px;">Proveedor:</td>
                <td class="tdconttablas" colspan="4" style="width:385px;">
                    <input language='javascript' id="txtProveedorNombreId" type="text" name="txtProveedorNombreId" maxLength="16" size="16" class="campotabla"  onblur="txtProveedorNombreId_onblur()" onKeyPress=" return txtProveedorId_onKeyPress(event);" value='<%=Request.Form("txtProveedorNombreId")%>' autocomplete='off'> 
                    <IMG style="CURSOR:pointer;" id="objLupa" onclick="javascript:cmdVerificarProveedor_onclick()" border="0" align="absMiddle" src="../static/images/icono_lupa.gif" width="17" height="17"> 
                    <input type="text" class="campotablaresultado" readOnly maxlength="46" size="46" id="txtProveedorRazonSocial" name="txtProveedorRazonSocial" value='<%=Request.Form("txtProveedorRazonSocial")%>' style="width:245px;">
                </td>
            </tr>
            </table>
            <br />
             <table border="0" cellSpacing="0" cellPadding="0" style="width:100%;">
                 <tr>
                    <td colspan="2">
                        <h2>Datos Exhibición</h2>
                    </td>
                </tr>
            <tr>
                <td class="tdtexttablebold" style="width:140px;">Tipo de Renta:</td>
                <td class="tdconttablas" style="width:150px;">
                    <select id="cboTipoRenta" class="campotabla" name="cboTipoRenta" onchange="return cboTipoRenta_onchange()" style="width:150px;">
                    <option selected value="0">Seleccione</option>
                  </select>
                </td>
                <td style="width:15px;"></td>
                <td class="tdtexttablebold" align="left" style="width:90px;">Tipo de Exhibición:</td>
                <td class="tdconttablas" style="width:150px;">
                    <select id="cboTipoExhibicion" class="campotabla" name="cboTipoExhibicion"  style="width:150px;">
                        <option selected value="0">Seleccione</option>
                    </select>
                </td>
                <td style="width:15px;"></td>
                <td class="tdtexttablebold" align="left" style="width:105px;">Espacio Publicitario:</td>
                <td class="tdconttablas" style="width:115px">
                    <select id="cboTipoEspacioPublicitario" class="campotabla" name="cboTipoEspacioPublicitario" style="width:115px">
                    <option selected value="0">Seleccione</option>
                  </select>
                </td>
            </tr>
            <tr>
                <td class="tdtexttablebold" style="width:140px;">Nombre de la exhibición:</td>
                <td class="tdconttablas" style="width:150px;">
                    <input id="txtNombreExhibicion" type="text" name="txtNombreExhibicion" maxLength="40" size="14" class="campotabla"  onKeyPress=" return validaAlfanumerico_onKeyPress(event);" style="width:150px;" value="<%= strNombreExhibicion%>"> 
                </td>
                <td style="width:15px;"></td>
                <td class="tdtexttablebold" align="left" style="width:90px;">Plan de salida:</td>
                <td class="tdconttablas" style="width:150px;">
                    <select id="cboPlanSalida" class="campotabla" name="cboPlanSalida" style="width:150px;">
                    <option selected value="0">Seleccione</option>
                  </select>
                </td>
                <td style="width:15px;"></td>
                <td class="tdtexttablebold" align="left" style="width:105px;">Comentarios:</td>
                <td class="tdconttablas" style="width:115px;">
                    <textarea id="txtComentariosPlanSalida" name="txtComentariosPlanSalida" cols="5" rows="1" class="campotabla" style="width:115px;" onKeyPress=" return validaAlfanumerico_onKeyPress(event);"></textarea>
                </td>
            </tr>
            <tr>
                <td class="tdtexttablebold" style="width:140px;">Tipo de Planograma:</td>
                <td class="tdconttablas" style="width:150px;">
                    <select id="cboTipoPlanograma" class="campotabla" name="cboTipoPlanograma" style="width:150px;">
                    <option selected value="0">Sin Categoria</option>
                  </select>
                </td>
                <td style="width:15px;"></td>
                <td class="tdtexttablebold" align="left" style="width:90px;">Planograma:</td>
                <td class="tdconttablas" colspan="4">
                    <input id="txtPlanogramaId" type="text" name="txtPlanogramaId" maxLength="14" size="13" class="campotabla"  onblur="txtPlanograma_onblur()" onKeyPress=" return txtPlanogramaId_onKeyPress(event);" value='<%=Request.Form("txtPlanogramaId")%>'> 
                    <IMG style="CURSOR:pointer;" id="imgPlanograma" onclick="javascript:cmdVerificarPlanograma_onclick()"
										border="0" align="absMiddle" src="../static/images/icono_lupa.gif" width="17" height="17">
                    <input type="text" class="campotablaresultado" readOnly size="12" id="txtPlanogramaDescripcion" name="txtPlanogramaDescripcion" style="width:250px;" value='<%=Request.Form("txtPlanogramaDescripcion")%>'>
                </td>
            </tr>
              <tr>
                <td class="tdtexttablebold" style="width:140px;">Estatus:</td>
                <td class="tdconttablas" style="width:150px;">
                    <select id="cboEstatus" name="cboEstatus" class="campotabla" style="width:150px">
                    <option selected="selected" value="0">Seleccione</option>
                </select>
                </td>
             </tr>
             </table>
             <br />
             <table border="0" cellSpacing="0" cellPadding="0" style="width:100%;">
                 <tr>
                     <td style="width:390px;"><h2>Costos e Ingresos:</h2>
                         <table border="0" cellSpacing="0" cellPadding="0" style="width:390px;">
                             <tr>
                                <td colspan="2">
                                </td>
                            </tr>
                             <tr>
                                 <td class="tdtexttablebold" style="width:140px;">Costo Merch:</td>
                                 <td class="tdconttablas">
                                    <input id="txtCostoMerchandising" type="text" name="txtCostoMerchandising" maxLength="12" size="14" class="campotabla"  onKeyPress=" return validaNumerico_onKeyPress(event);" value="<%= strCostoMerchandising()%>"> 
                                 </td>
                             </tr>
                             <tr>
                                 <td class="tdtexttablebold" style="width:140px;">Costo CatMan:</td>
                                 <td class="tdconttablas">
                                    <input id="txtCostoCatman" type="text" name="txtCostoCatman" maxLength="12" size="14" class="campotabla"  onKeyPress=" return validaNumerico_onKeyPress(event);" value="<%= strCostoCatMan%>"> 
                                 </td>
                             </tr>
                             <tr>
                                 <td class="tdtexttablebold" style="width:140px;">Ingreso Total Merch:</td>
                                 <td class="tdconttablas">
                                    <input id="txtIngresoTotMerch" type="text" name="txtIngresoTotMerch" maxLength="12" size="14" class="campotabla"  onKeyPress=" return validaNumerico_onKeyPress(event);" value="<%= strIngresoTotalMerch()%>"> 
                                 </td>
                             </tr>
                             <tr>
                                 <td class="tdtexttablebold" style="width:140px;">Ingreso Total Catman:</td>
                                 <td class="tdconttablas">
                                    <input id="txtIngresoTotCatman" type="text" name="txtIngresoTotCatman" maxLength="12" size="14" class="campotabla"  onKeyPress=" return validaNumerico_onKeyPress(event);" value="<%= strIngresoTotalCatman()%>"> 
                                 </td>
                             </tr>
                             <tr>
                                 <td class="tdtexttablebold" style="width:140px;">Ingreso Total:</td>
                                 <td class="tdconttablas">
                                    <input id="txtIngresoTotal" type="text" name="txtIngresoTotal" maxLength="12" size="14" class="campotabla"  onKeyPress=" return validaNumerico_onKeyPress(event);" value="<%= strIngresoTotal()%>"> 
                                 </td>
                             </tr>
                         </table>
                     </td>
                     <td width="100%">
                          <table border="0" cellSpacing="0" cellPadding="0" style="width:100%;">
                              <tr align="center">
                                  <td colspan="2">
                                      <img id="imgDetalle" src="<%= strRutaImagen()%>" border="0" style="margin:10px; border:1px solid #ccc; width:120px; height:170px;" >
                                  </td>
                              </tr>
                              <tr width="100%"> 
                                <td class="tdtexttablebold" width="12%">Importar Imagen</td>
                                <td class="tdpadleft5"><input id="txtArchivo" class="field" size="53" type="file" name="txtArchivo"
										                    runat="server"> </td>
                              </tr>
                         </table> 
                     </td>
                 </tr>
             </table>
             <table>
                 <tr>
                                <td colspan="2">
                                    <h2>Vigencia:</h2>
                                </td>
                            </tr>
          <tr> 
            <td class="tdtexttablebold" >Fecha inicio:</td>
            <td class="tdconttablas"> 
                <input id="dtmFechaIni" name="dtmFechaIni" class="field" size="10" maxLength="10" type="text" value="<%= strFechaInicio()%>"> 
                <A href="javascript:cal1.popup()">
                  <IMG src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
											alt="Clic para seleccionar la fecha."> 
              </A> <br> 
            </td>
           <td></td>
            <td class="tdtexttablebold" >Fecha fin:</td>
            <td class="tdconttablas"> 
                <input id="dtmFechaFin" name="dtmFechaFin" class="field" size="10" maxLength="10" type="text" value="<%= strFechaFin()%>"> 
                <A href="javascript:cal2.popup()">
                  <IMG src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
											alt="Clic para seleccionar la fecha."> 
              </A> <br> 
            </td>
              <td></td>
              <td align="right">
                  <input type='hidden' value='<%=Request.Form("hdnProveedorId")%>' name='hdnProveedorId'>
                  <input type='hidden' value='<%=Request.Form("hdnProveedorNombreId")%>' name='hdnProveedorNombreId'>
                  <input type='hidden' value='<%=strExhibicionId()%>' name='hdnExhibicionCodigo'>
              </td>
          </TR>
        </table>
        <table border="0" cellSpacing="0" cellPadding="0" style="width:100%;">
            <tr>
              <td align="right">
                  <input id="cmdGuardar" class="button" value="Guardar" type="submit"name="cmdGuardar" onClick="return cmdGuardar_onclick()">
                  <input name="cmdRegresar" type="button" class="boton" value="Cancelar" onClick="return cmdRegresar_onclick()">
              </td>
            </tr>
        </table>
        </td>
    </tr>
  </table>
  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
    <tr> 
      <td> 
          <script language="JavaScript" type="text/javascript">crearTablaFooterCentral()</script> 
      </td>
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
  <div id="divConsultaExhibiciones"> 
  </div>
</div>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
<iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</HTML>
