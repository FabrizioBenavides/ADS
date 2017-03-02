<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="RentaEspaciosConsulta.aspx.vb" Inherits="com.isocraft.backbone.ccentral.RentaEspaciosConsulta" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>

<HTML>
<HEAD>
<title>Benavides: Exhibiciones adicionales</title>
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

        document.getElementById('cboDivisionArticulos').value = '<%= intDivisionId()%>';

        document.onhelp = FALSE_FUNCTION;
        window.onhelp = FALSE_FUNCTION;

        // Disable the F1, F3 and F5 keys. Without this, browsers that have these
        // function keys assigned to a specific behaviour (i.e., opening a search
        // tab, or refreshing the page) will continue to execute that behaviour.
        //
        document.onkeydown = function disableKeys() {
            // Disable F1, F3 and F5 (112, 114 and 116, respectively).
            //
            if (typeof event != 'undefined') {
                if ((event.keyCode == 112) ||
                    (event.keyCode == 114) ||
                    (event.keyCode == 116)) {
                    event.keyCode = 0;
                    return false;
                }
            }
        };
    }

    var FALSE_FUNCTION = new Function("return false");

    //Funcionalidad de combos Division y Categoria
    function cboDivisionArticulos_onchange() {

        document.forms[0].elements["cboCategoriaArticulos"].selectedIndex = 0;

        document.forms[0].action = '<%= strThisPageName%>?strCmd='; 
        document.forms[0].target = '_self';
        document.forms[0].submit();
    }

    //Funcionalidad de combos Tipo de exhibicion y Tipo de mueble
    function cboTipoExhibicion_onchange() {
        document.forms[0].elements["cboTipoMueble"].selectedIndex = 0;

        document.forms[0].action = '<%= strThisPageName%>?strCmd=';
        document.forms[0].target = '_self';
        document.forms[0].submit();
    }

    function cboTipoRenta_onchange() {
        var idTipoRenta = document.forms[0].elements["cboTipoRenta"].selectedIndex;
     
        if (idTipoRenta == 1) {

            document.forms[0].elements["cboTipoEspacioPublicitario"].selectedIndex = 0;
            document.getElementById("cboTipoEspacioPublicitario").disabled = true;
            document.getElementById("cboTipoExhibicion").disabled = false;
            document.getElementById("cboTipoExhibicion").focus();
        }
        else if (idTipoRenta == 2) {

            document.forms[0].elements["cboTipoExhibicion"].selectedIndex = 0;
            document.getElementById("cboTipoEspacioPublicitario").disabled = false;
            document.getElementById("cboTipoExhibicion").disabled = true;
            document.forms[0].elements["cboTipoEspacioPublicitario"].focus();
        }
    else{
            document.forms[0].elements["cboTipoEspacioPublicitario"].selectedIndex = 0;
            document.forms[0].elements["cboTipoExhibicion"].selectedIndex = 0;
        }
    }
    
    //Botones
    function cmdNuevo_onclick() {
        window.location.href = "RentaEspaciosCrear.aspx?strFiltroId=0";
    }

    function cmdExportar_onclick() {

        if (document.getElementById('tblResultados').innerHTML == '') {

            alert('Realice la consulta por favor');
            return (false);
        }

        var confirmar = confirm('Desea exportar la informacion a Excel?');
        if (confirmar == true) {
            document.forms[0].action = '<%= strThisPageName%>?strCmd=Exportar'; 
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();

            return (true);
        }
    }

    function cmdRegresar_onclick() {
        window.location.href = "InicioHome.aspx";
    }

    function cmdReporteExhibicionesAdicionales_onclick() {
        var valida; //= true;

        valida = ValidaCampos();


        if (valida) {

            //Parametros
            var strParametros = '';

            strParametros = '';
            strParametros = '?strDivisionArticulosId=' + document.getElementById('cboDivisionArticulos').value;
            strParametros = strParametros + '&strCategoriaOperativaId=' + document.getElementById('cboCategoriaArticulos').value;
            strParametros = strParametros + '&strCatmanId=' + document.getElementById('cboCatman').value;
            strParametros = strParametros + '&strSocioComercial=' + document.getElementById('cboSocioComercial').value;
            strParametros = strParametros + '&strProveedorId=' + document.getElementById('txtProveedorNombreId').value;
            strParametros = strParametros + '&strTipoRentaId=' + document.getElementById('cboTipoRenta').value;
            strParametros = strParametros + '&strTipoExhibicionId=' + document.getElementById('cboTipoExhibicion').value;
            strParametros = strParametros + '&strTipoEspacioPublicitarioId=' + document.getElementById('cboTipoEspacioPublicitario').value;
            strParametros = strParametros + '&strNombreExhibicion=' + document.getElementById('txtNombreExhibicion').value;
            strParametros = strParametros + '&strPlanSalidaId=' + document.getElementById('cboPlanSalida').value;
            strParametros = strParametros + '&strTipoPlanogramaId=' + document.getElementById('cboTipoPlanograma').value;
            strParametros = strParametros + '&strPlanogramaCapturadoId=' + document.getElementById('txtPlanogramaId').value;
            strParametros = strParametros + '&strEstatusId=' + document.getElementById('cboEstatus').value;
            strParametros = strParametros + '&dtmFechaInicio=' + document.getElementById('dtmFechaIni').value;
            strParametros = strParametros + '&dtmFechaFin=' + document.getElementById('dtmFechaFin').value;
            strParametros = strParametros + '&strCmd=cmdReporteExhibicionesAdicionales';

            //Se redirecciona al usuario a la pagina de reportes
            window.open('RentaEspaciosReportes.aspx' + strParametros, 'reportes', 'toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=1,width=800,height=600');
        }
        return (valida)
    }

    function cmdReporteAsignaciones_onclick() {

        var valida;

        valida = ValidaCampos();


        if (valida) {

            //Parametros
            var strParametros = '';
            
            strParametros = '';
            strParametros = '?strDivisionArticulosId=' + document.getElementById('cboDivisionArticulos').value;
            strParametros = strParametros + '&strCategoriaOperativaId=' + document.getElementById('cboCategoriaArticulos').value;
            strParametros = strParametros + '&strCatmanId=' + document.getElementById('cboCatman').value;
            strParametros = strParametros + '&strSocioComercial=' + document.getElementById('cboSocioComercial').value;
            strParametros = strParametros + '&strProveedorId=' + document.getElementById('txtProveedorNombreId').value;
            strParametros = strParametros + '&strTipoRentaId=' + document.getElementById('cboTipoRenta').value;
            strParametros = strParametros + '&strTipoExhibicionId=' + document.getElementById('cboTipoExhibicion').value;
            strParametros = strParametros + '&strTipoEspacioPublicitarioId=' + document.getElementById('cboTipoEspacioPublicitario').value;
            strParametros = strParametros + '&strNombreExhibicion=' + document.getElementById('txtNombreExhibicion').value;
            strParametros = strParametros + '&strPlanSalidaId=' + document.getElementById('cboPlanSalida').value;
            strParametros = strParametros + '&strTipoPlanogramaId=' + document.getElementById('cboTipoPlanograma').value;
            strParametros = strParametros + '&strPlanogramaCapturadoId=' + document.getElementById('txtPlanogramaId').value;
            strParametros = strParametros + '&strEstatusId=' + document.getElementById('cboEstatus').value;
            strParametros = strParametros + '&dtmFechaInicio=' + document.getElementById('dtmFechaIni').value;
            strParametros = strParametros + '&dtmFechaFin=' + document.getElementById('dtmFechaFin').value;
            strParametros = strParametros + '&strCmd=cmdReporteAsignaciones';

            //Se redirecciona al usuario a la pagina de reportes
            window.open('RentaEspaciosReportes.aspx' + strParametros, 'reportes', 'toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=1,width=800,height=600');
        }
        return (valida)
    }

    function cmdConsultar_onclick() {
        var valida; //= true;
        
        valida = ValidaCampos();
        
        if (valida) {
            
                document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultar';
                document.forms[0].target = "ifrOculto";
                document.forms[0].submit();
        }

        return (valida)
    }

    //Validacion de campos.
    function ValidaCampos() {
        valida = true;

        var _proveedorId = trim(document.getElementById('txtProveedorNombreId').value);
        var _proveedorDes = trim(document.getElementById('txtProveedorRazonSocial').value);

        var _planoId = trim(document.getElementById('txtPlanogramaId').value);
        var _planoDesc = trim(document.getElementById('txtPlanogramaDescripcion').value);

        //Validacion de Proveedor
        if ((_proveedorId == '' && _proveedorDes != '') || (_proveedorId != '' && _proveedorDes == '')) {
            alert('Capture un proveedor valido');
            return (false);
        }

        //Validacion de Planograma
        if ((_planoId == '' && _planoDesc != '') || (_planoId != '' && _planoDesc == '')) {
            alert('Capture un planograma valido');
            return (false);
        }

        //Validacion de Fechas
        if (trim(document.getElementById('dtmFechaIni').value) == '' || trim(document.getElementById('dtmFechaFin').value) == '') {

            alert('Capture la fecha');
            return (false);
        }

        valida = ValidaFechas("dtmFechaIni", "dtmFechaFin")

        return (valida);
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

function trim(stringTotrim) {
    return stringTotrim.replace(/^\s+|\s+$/g, "");
}

    //Proveedor
function txtProveedorNombreId_onblur() {
    if (trim(document.getElementById('txtProveedorNombreId').value) == '') {
        document.getElementById('txtProveedorRazonSocial').value = '';
    }
}

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

function Pop(url, width, height) {
    var Win = window.open(url, 'Pop', 'width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no');
    return false;
}

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

    function cmdVerificarAccion_onclick(id) {

        var intExhibicionCodigo = id.substring(3);
        var accion = id.substring(0, 3);

        if (accion == 'Asi') {

            //window.location.href = 'RentaEspaciosAsignar.aspx?strExhibicionId=' + intExhibicionCodigo;
            //EJEMPLO... window.open('webpage.html', 'TLA','toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=800,height=665');
            
            
            //Parametros
            var strParametros = '?strExhibicionId=' + intExhibicionCodigo;

            window.open('RentaEspaciosAsignar.aspx' + strParametros, '_self', 'toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes');
        }
        else if (accion == 'Edi') {

            window.location.href = 'RentaEspaciosCrear.aspx?strFiltroId=1&strExhibicionId=' + intExhibicionCodigo;
        }
        else if (accion == 'Eli') {

            var confirmacion = confirm('Desea eliminar este registro?');
            if (confirmacion == true) {

                document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdEliminar&idExhibicion=' + intExhibicionCodigo;
                document.forms[0].target = "ifrOculto";
                document.forms[0].submit();
            }
            
        }
        else {
            window.location.href = 'RentaEspaciosDetalle.aspx?intExhibicionCodigo=' + intExhibicionCodigo;
        }
    }

    function cmdImprimir_onclick() {

        if (document.getElementById('tblResultados').innerHTML == '') {

            alert('Realice la consulta por favor');
            return (false);
        }

        var confirmar = confirm('Desea imprimir la información?');
        if (confirmar == true) {

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdImprimir';
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();

            return (true);
        }
    }

    function fnImprimir(strPromocioneAvanzada) {

        //Llamada desde el servidor para imprimir resultados de las consulta.
        document.ifrPageToPrint.document.all.divBody.innerHTML = strPromocioneAvanzada;
        document.ifrPageToPrint.focus();
        window.print();
    }

    function frmConsultaRentaEspacios_onsubmit() {
        return (true);
    }

    //-->
		</script>
    
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onload="return window_onload()">
<form id="frmConsultaRentaEspacios" method="post" name="frmConsultaRentaEspacios" action="about:blank" onSubmit="return frmConsultaRentaEspacios_onsubmit()">
  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
    <tr> 
      <td> <script language="JavaScript">crearTablaHeader()</script> </td>
    </tr>
  </table>
  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px; height: 26px;">
    <tr> 
      <td class="tdtab" style="width:780px;">
          Está en : <A href="../_Manager/InicioHome.aspx">Central</A> : Exhibiciones Adicionales
      </td>
    </tr>
  </table>
  <table border="1" cellSpacing="0" cellPadding="0" style="width:780px;">
      <tr>
         <td class="tdgeneralcontent">
             <table border="0"  cellSpacing="0" cellPadding="0" style="width:100%;">
                  <tr>
                      <td style="width:760px;"><h1>Exhibiciones Adicionales</h1></td>
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
                            <option selected="selected" value="0">&raquo; Todas &laquo;</option>
                        </select> 
                    </td>
                    <td style="width:15px;"></td>
                    <td class="tdtexttablebold" style="width:90px;" align="left">Categoría:</td>
                    <td class="tdconttablas" style="width:150px;">
                        <select id="cboCategoriaArticulos" class="campotabla" name="cboCategoriaArticulos" style="width:150px">
				            <option selected="selected" value="0">&raquo; Todas &laquo;</option>
				        </select>
                    </td>
                    <td style="width:15px;"></td>
                    <td class="tdtexttablebold" style="width:105px;" align="left">CATMAN:</td>
                    <td class="tdconttablas" style="width:115px;">
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
                    <td class="tdtexttablebold" align="left" style="width:90px;">Proveedor:</td>
                    <td class="tdconttablas" colspan="4">
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
                    <td class="tdconttablas" style="width:115px;">
                        <select id="cboTipoEspacioPublicitario" class="campotabla" name="cboTipoEspacioPublicitario" style="width:115px;">
                        <option selected value="0">Seleccione</option>
                      </select>
                    </td>
                </tr>
                <tr>
                    <td class="tdtexttablebold" >Nombre de la exhibición:</td>
                    <td class="tdconttablas">
                        <input id="txtNombreExhibicion" type="text" name="txtNombreExhibicion" maxLength="40" size="14" class="campotabla"  onKeyPress=" return validaAlfanumerico_onKeyPress(event);" value='<%=Request.Form("txtNombreExhibicion")%>' style="width:150px;"> 
                        
                    </td>
                    <td style="width:15px;"></td>
                    <td class="tdtexttablebold" align="left" style="width:90px;">Plan de salida:</td>
                    <td class="tdconttablas" >
                        <select id="cboPlanSalida" class="campotabla" name="cboPlanSalida" style="width:150px;">
                        <option selected value="0">Seleccione</option>
                      </select>
                    </td>
                </tr>
                <tr>
                    <td class="tdtexttablebold" style="width:140px;">Tipo de Planograma:</td>
                    <td class="tdconttablas" style="width:150px;">
                        <select id="cboTipoPlanograma" class="campotabla" name="cboTipoPlanograma" style="width:150px;">
                        <option selected value="0">Seleccione</option>
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
                     <td colspan="2">
                         <h2>Vigencia:</h2>
                     </td>
                </tr>
                  <tr> 
                    <td class="tdtexttablebold" >Fecha inicio:</td>
                    <td class="tdconttablas"> 
                        <input id="dtmFechaIni" name="dtmFechaIni" class="field" size="10" maxLength="10" type="text" value="<%= strFirstDayOfMonth()%>"> 
                        <A href="javascript:cal1.popup()">
                          <IMG src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
											        alt="Clic para seleccionar la fecha."> 
                      </A> <br> 
                    </td>
          
                   <td></td>
                    <td class="tdtexttablebold" >Fecha fin:</td>
                      <!---->
                    <td class="tdconttablas"> 
                        <input id="dtmFechaFin" name="dtmFechaFin" class="field" size="10" maxLength="10" type="text" value="<%= strLastDayOfMonth()%>"> 
                        <A href="javascript:cal2.popup()">
                          <IMG src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
											        alt="Clic para seleccionar la fecha."> 
                      </A> <br> 
                    </td>
                      <td></td>
                      <td align="right" style="width:50px;">
                          <input type='hidden' value='<%=Request.Form("hdnProveedorId")%>' name='hdnProveedorId'>
                          <input type='hidden' value='<%=Request.Form("hdnProveedorNombreId")%>' name='hdnProveedorNombreId'>
                          
                      </td>
                      <td></td>
                      <td></td>
                      <td class="tdconttablas" colspan="3" align="right" >
                        </td>
                  </TR>
                 <tr>
                     <td colspan="10">
                         
                         <input id="cmdReporteExhibicionesAdicionales" class="button" value="Reporte Exhibiciones" type="button" name="cmdReporteExhibicionesAdicionales" onclick="return cmdReporteExhibicionesAdicionales_onclick();" style="margin-top:20px;">
                         <input id="cmdReporteAsignaciones" class="button" value="Reporte Asignaciones" type="button" name="cmdReporteAsignaciones" onclick="return cmdReporteAsignaciones_onclick();" style="margin-top:20px;">
                         <input id="cmdConsultar" class="button" value="Consultar" type="button" name="cmdConsultar" onclick="return cmdConsultar_onclick();" style="margin-top:20px;">
                     </td>
                 </tr>
        </table>
        </td>
    </tr>
  </table>
  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
                 <tr>
                     <td style="width:100%;">
                         <div id="tblResultados"></div>
                     </td>
                 </tr>
                 <tr>
                     <td class="tdpadleft5" align="right" style="width:100%;">
                         <div id="divBotones"></div>
                     </td>
                 </tr>
                <tr>
                    <td style="width:100%;">&nbsp;</td>
                </tr>
                <tr>
                   <td style="width:100%";"><script language="JavaScript" type="text/javascript">crearTablaFooterCentral()</script></td>
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
      <%= Me.strTablaConsultaExhibiciones()%>  
  </div>
</div>
    <script language="JavaScript">
        if (parent.document.getElementById('tblResultados').innerHTML == '') {
            
            parent.document.getElementById('divBotones').innerHTML = '<input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()" style="margin-top:20px;">';
        }
        else {
            var botones = '<input name="cmdExportar" type="button" class="boton" value="Exportar" onClick="return cmdExportar_onclick()" style="margin-top:20px;">';
            botones = botones + '<input id="cmdImprimir" name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()" style="margin-top:20px;">';
            botones = botones + '<input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()" style="margin-top:20px;">';
            parent.document.getElementById('divBotones').innerHTML = botones
        }
    </script>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
<iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</HTML>

