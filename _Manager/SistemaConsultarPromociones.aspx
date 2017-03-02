<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SistemaConsultarPromociones.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalConsultarPromociones" %>

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


        //Llenado de Combos
        <%= LlenarControlCategoria()%>

        //Tipo de Busqueda 
        var intTipoBusquedaId = "<%= intTipoBusquedaId()%>";

        if (intTipoBusquedaId == "1") {

            //Articulo
            document.getElementById('rbtArticulo').checked = true;
            
        }
        else if (intTipoBusquedaId == "2") {

            //Promocion
            document.getElementById('rbtPromocion').checked = true;

        }
        else if (intTipoBusquedaId == "3") {

            //Sucursal
            document.getElementById('rbtSucursal').checked = true;

        }
        else if (intTipoBusquedaId == "4") {

            //Categoria
            document.getElementById('rbtTipoEstrategia').checked = true;
        }
        else {
            //Sin seleccion de Tipo de Busqueda = -1
        }

        document.getElementById('hdnDelayOnFocus').value = 0;

        //VIGENCIA
        var intVigenciaId = "<%= intVigenciaId %>";

        if (intVigenciaId == "0") {
            document.getElementById('rbtTodas').checked = true;
        }    
        else if (intVigenciaId == "1") {
            document.getElementById('rbtVigentes').checked = true;
        }
        else if (intVigenciaId == "2") {
            document.getElementById('rbtNoVigentes').checked = true;
        }
        else if (intVigenciaId == "3") {
            document.getElementById('rbtProximasVigencias').checked = true;
        }
        else if (intVigenciaId == "4") {
            document.getElementById('rdbVigenteEnFechas').checked = true;
        }
        else { /*Sin seleccion de Vigencia = -1*/}

        //TIPO DE PROMOCION
        var intTipoPromocionId = "<%= intTipoPromocionId %>";

        if (intTipoPromocionId == "0") {
            document.getElementById('rbtTodos').checked = true;
        }
        else if (intTipoPromocionId == "1") {
            document.getElementById('rbtOfertas').checked = true;
        }
        else if (intTipoPromocionId == "2") {
            document.getElementById('rbtPromociones').checked = true;
        }
        else if (intTipoPromocionId == "3") {
            document.getElementById('rbtCupones').checked = true;
        }
        else { /*Sin seleccion de Tipo de Promocion*/}
        
        return (true);
    }

    function strGetCustomDateTime() {
        document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
        return (true);
    }


    function frmConsultarPromociones_onsubmit() {
        return (true);
    }

    function cmdTipoBusqueda_onfocus(id) {
        
        document.getElementById('tblResultados').innerHTML = '';
        document.getElementById('hdnTipoBusqueda').value = id;

        if(id == 1){

            document.getElementById('rbtArticulo').checked = true;
            document.getElementById('hdnDelayOnFocus').value = 1;

            //rbtPromocion
            document.getElementById('txtPromocion').value = '';
            document.getElementById('txtPromocionDescripcion').value = '';
            
            //rbtSucursal
            document.getElementById('txtSucursalId').value = '';
            document.getElementById('txtSucursalDescripcion').value = '';
            
            //rbtTipoEstrategia
            document.getElementById('cboCategoriaPromocion').value = '0';
            
        }
        else if (id == 2) {

            document.getElementById('rbtPromocion').checked = true;
            document.getElementById('hdnDelayOnFocus').value = 1;
            //Articulo
            document.getElementById('txtArticuloId').value = '';
            document.getElementById('txtDescripcionArticulo').value = '';

            //rbtSucursal
            document.getElementById('txtSucursalId').value = '';
            document.getElementById('txtSucursalDescripcion').value = '';
            
            //Categoria
            document.getElementById('cboCategoriaPromocion').value = '0';
        }
        else if (id == 3) {

            document.getElementById('rbtSucursal').checked = true;
            document.getElementById('hdnDelayOnFocus').value = 1;

            //Articulo
            document.getElementById('txtArticuloId').value = '';
            document.getElementById('txtDescripcionArticulo').value = '';

            //rbtPromocion
            document.getElementById('txtPromocion').value = '';
            document.getElementById('txtPromocionDescripcion').value = '';
            

            //Categoria
            document.getElementById('cboCategoriaPromocion').value = '0';
        }
        else if (id == 4) {

            document.getElementById('rbtTipoEstrategia').checked = true;
            document.getElementById('hdnDelayOnFocus').value = 0;

            //Articulo
            document.getElementById('txtArticuloId').value = '';
            document.getElementById('txtDescripcionArticulo').value = '';

            //rbtPromocion
            document.getElementById('txtPromocion').value = '';
            document.getElementById('txtPromocionDescripcion').value = '';
            
            //rbtSucursal
            document.getElementById('txtSucursalId').value = '';
            document.getElementById('txtSucursalDescripcion').value = '';
            
        }
    }



    function cboCategoriaPromocion_onchange() {

        document.getElementById('tblResultados').innerHTML = '';
        document.getElementById('rbtTipoEstrategia').checked = true;
        document.getElementById('hdnTipoBusqueda').value = 4;

        //Se limpian todos los campos de Tipo de Busqueda.

        //Articulo
        document.getElementById('txtArticuloId').value = '';
        document.getElementById('txtDescripcionArticulo').value = '';
        //rbtPromocion
        document.getElementById('txtPromocion').value = '';
        document.getElementById('txtPromocionDescripcion').value = '';

        //rbtSucursal
        document.getElementById('txtSucursalId').value = '';
        document.getElementById('txtSucursalDescripcion').value = '';

    }


    function txtArticuloId_onKeyPress(e) {

        document.getElementById('tblResultados').innerHTML = '';
        document.getElementById('rbtArticulo').checked = true;
        document.getElementById('hdnTipoBusqueda').value = 1;

        //Se limpia la descripcion del articulo 
        document.forms[0].elements['txtDescripcionArticulo'].value = '';

        //Se limpian todos los campos de Tipo de Busqueda.

        //rbtPromocion
        document.getElementById('txtPromocion').value = '';
        document.getElementById('txtPromocionDescripcion').value = '';

        //rbtSucursal
        document.getElementById('txtSucursalId').value = '';
        document.getElementById('txtSucursalDescripcion').value = '';

        //rbtTipoEstrategia
        document.getElementById('cboCategoriaPromocion').value = '0';


        //Se validan los caracteres permitidos.
        var key = window.event ? e.keyCode : e.wich;

        if (key == 13) {
            if (trim(document.forms[0].elements['txtArticuloId'].value) == '') {
                return (false);
            }
            txtArticuloId_onblur();
            return (true);
        }
            //No se permiten caracteres especiales para el Articulo.
        else if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || (key == 32)) {
            return true;
        }
        else {
            return false;
        }
    }

    function txtArticuloId_onblur() {

        if (trim(document.forms[0].elements['txtArticuloId'].value) == '') {
            document.forms[0].elements['txtArticuloId'].value = '';
           // document.forms[0].elements['hdnArticuloId'].value = '';
            document.forms[0].elements['txtDescripcionArticulo'].value = '';
            return false;
        }

        objArticuloLupa_onClick();
    }

    function objLupaArticulo_onclick() {

        if (trim(document.getElementById('txtArticuloId').value) == '') {
            return (false);
        }

        txtArticuloId_onblur();
    }

    function objArticuloLupa_onClick() {

        document.getElementById('rbtArticulo').checked = true;
        document.getElementById('tblResultados').value = '';
        //alert(document.getElementById('hdnDelayOnFocus').value);
        if (document.forms[0].elements['txtArticuloId'].value != "") {

            if (!isNaN(document.forms[0].elements['txtArticuloId'].value)) {

                // Es un numero
                if (document.forms[0].elements['txtArticuloId'].value != '0') {

                    //document.getElementById('hdnDelayOnFocus').value = 0;

                    document.forms[0].action = "<%=strFormAction%>?strCmd=BuscarArticulo";
                    document.forms[0].target = "ifrOculto";
                    document.forms[0].submit();
                    document.forms[0].target = '';
                    return (true);
            }
        }
        else {

            // Es una descripcion
                document.forms[0].elements['txtDescripcionArticulo'].value = '';
                //document.getElementById('hdnDelayOnFocus').value = 0;

            strParametros = '';
            strParametros = strParametros + '?strArticuloIdNombre=' + document.forms[0].elements['txtArticuloId'].value;
            strParametros = strParametros + '&strArticuloNombreId=txtDescripcionArticulo'
            strParametros = strParametros + '&strArticulo=txtArticuloId'
            Pop('PopArticulo.aspx' + strParametros, 500, 540);
        }
    }
        else {

            document.forms[0].elements['txtArticuloId'].value = '';
            document.forms[0].elements['txtDescripcionArticulo'].value = '';

            alert("Teclear número de artículo o descripción");
            return (false);
    }
}

//Promociones
function txtPromocionId_onKeyPress(e) {

    document.getElementById('tblResultados').innerHTML = '';
    document.getElementById('rbtPromocion').checked = true;
    document.getElementById('hdnTipoBusqueda').value = 2;

    //Se limpia la descripcion de la promocion.
    document.forms[0].elements['txtPromocionDescripcion'].value = '';

    //Se limpian todos los campos de Tipo de Busqueda.

    //rbtArticulo
    document.getElementById('txtArticuloId').value = '';
    document.getElementById('txtDescripcionArticulo').value = '';

    //rbtSucursal
    document.getElementById('txtSucursalId').value = '';
    document.getElementById('txtSucursalDescripcion').value = '';

    //rbtTipoEstrategia
    document.getElementById('cboCategoriaPromocion').value = '0';


    //Se validan los caracteres permitidos.
    var key = window.event ? e.keyCode : e.wich;

    //No se permiten caracteres especiales para el Articulo.
    if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || (key == 32)) {
        return true;
    }
    else {
        return false;
    }
}

function txtPromocion_onblur() {
    if (trim(document.getElementById('txtPromocion').value) == '') {
        document.getElementById('txtPromocionDescripcion').value = '';
    }
}

function cmdVerificarPromocion_onclick() {

    document.getElementById('rbtPromocion').checked = true;
    document.getElementById('tblResultados').value = '';
    
    var _tipoPromocionId = trim(document.getElementById('hdnTipoPromocion').value);

    if (fnValidaTipoPromocion() == false) {
        return (false);
    }

        if (trim(document.getElementById('txtPromocion').value) == '') {

            //Si el campo de promocion esta vacio.
            alert('Por favor capture el código o descripción de la promoción.')

        }
        else {

            if (!isNaN(document.getElementById('txtPromocion').value)) {

                //Si la busqueda es por "Codigo" de promocion.
                document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultarPorCodigo';
                document.forms[0].target = "ifrOculto";
                document.forms[0].submit();

            }
            else {

                //Si la busqueda es por "Descripcion" de promocion.
                window.open('PopPromocionesCupones.aspx?strPromocion=txtPromocion&amp;strPromocionNombreId=txtPromocionDescripcion&strPromocionIdNombre=' + document.getElementById('txtPromocion').value + '&intTipoPromocionId=' + _tipoPromocionId, "Benavides", "toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=1,width=600,height=500,statusbar=no")
            }
        }
    }

        //Fin de Promociones

        //Por Sucursal

        function txtSucursalId_onKeyPress(e) {

            document.getElementById('tblResultados').innerHTML = '';
            document.getElementById('rbtSucursal').checked = true;
            document.getElementById('hdnTipoBusqueda').value = 3;

            //Se limpia la descripcion del articulo 
            document.forms[0].elements['txtSucursalDescripcion'].value = '';

            //Se limpian todos los campos de Tipo de Busqueda.

            //Artriculo
            document.getElementById('txtArticuloId').value = '';
            document.getElementById('txtDescripcionArticulo').value = '';

            //rbtPromocion
            document.getElementById('txtPromocion').value = '';
            document.getElementById('txtPromocionDescripcion').value = '';

            //rbtTipoEstrategia
            document.getElementById('cboCategoriaPromocion').value = '0';


            //Se validan los caracteres permitidos.
            var key = window.event ? e.keyCode : e.wich;

            if (key == 13) {
                if (trim(document.forms[0].elements['txtArticuloId'].value) == '') {
                    return (false);
                }
                txtArticuloId_onblur();
                return (true);
            }
                //No se permiten caracteres especiales para el Articulo.
            else if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || (key == 32)) {
                return true;
            }
            else {
                return false;
            }
        }

        function cmdBuscarSucursal_onclick() {

            if (trim(document.getElementById('txtSucursalId').value) == '') {
                alert('Capture el nombre de la sucursal o el centro logistico');
                return (false);
            }
        
            var _valor = trim(document.getElementById('txtSucursalId').value)
        
            //if (!isNaN(document.getElementById('txtSucursalId').value)) {
            if(!isNaN(_valor.substring(1, 4))){
            
                //Si la busqueda es por "Codigo" de Sucursal (Centro Logistico).
                document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultarPorSucursal';
                document.forms[0].target = "ifrOculto";
                document.forms[0].submit();

            }
            else {
            
                //Si la busqueda es por "Descripcion" de la sucursal.
                window.open('PopSucursalCupones.aspx?strSucursal=txtSucursalId&amp;strSucursalNombreId=txtSucursalDescripcion&strSucursalId=' + document.getElementById('txtSucursalId').value, "Benavides", "toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=1,width=600,height=500,statusbar=no")
            }
        }
        //Fin Por Sucursal

        function cmdVigencia_onfocus(id) {

            document.getElementById('tblResultados').innerHTML = '';
            document.getElementById('hdnVigencia').value = id;

            if (id == 4) { document.getElementById('rdbVigenteEnFechas').checked = true; }

            return (true);
        }

        function cmdTipoPromocion_onfocus(id) {

            document.getElementById('tblResultados').innerHTML = '';
            document.getElementById('txtPromocionDescripcion').value = '';
            
            document.getElementById('hdnTipoPromocion').value = id;

            if (id == 0) {

                document.getElementById('txtPromocion').value = '';
                document.getElementById('txtPromocionDescripcion').values = '';
                document.getElementById('txtPromocion').disabled = true;
                document.getElementById('txtPromocionDescripcion').disabled = true;
                document.getElementById('objLupaPromocion').disabled = true;

            }
            else {
                document.getElementById('txtPromocion').disabled = false;
                document.getElementById('txtPromocionDescripcion').disabled = false;
                document.getElementById('objLupaPromocion').disabled = false;
            }


            return (true);
        }


        function cmdConsultar_onclick() {

            //Variables.
            var valida;

            document.getElementById('tblResultados').innerHTML = '';
            //alert(document.activeElement.id);

            //alert(document.getElementById('hdnDelayOnFocus').value);
            if (document.getElementById('hdnDelayOnFocus').value == 1) {
                
                //setTimeout(function () { alert("Hello"); }, 3000);
                document.getElementById('hdnDelayOnFocus').value = 0;
                setTimeout(fnValidaConsulta, 3000);
                
            }
            else {

                valida = fnValidaConsulta();
            //    valida = fnValidaCampos();
            

            /*valida = fnValidaCampos();
            if (valida) {

                document.forms[0].action = '<= strThisPageName%>?strCmd=cmdConsultar';
                document.forms[0].target = "ifrOculto";
                //document.forms[0].target = '_self';
                document.forms[0].submit();
            }*/
            }

            return (valida);
        }

    function fnValidaConsulta() {
        var valida;

        //alert(document.activeElement.id);

        //alert(document.getElementById('hdnDelayOnFocus').value);
        //if (document.getElementById('hdnDelayOnFocus').value == 1) {

        //    //setTimeout(function () { alert("Hello"); }, 3000);
        //    document.getElementById('hdnDelayOnFocus').value = 0;
        //    setTimeout(function () { alert("Hello"); }, 3000);

        //}
        //else{
        //    valida = fnValidaCampos();
        //}

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

            //--------------------------
            //Validacion Tipo Busqueda
            //--------------------------
            if (fnValidaTipoBusqueda() == false) {return(false); }

            //--------------------------
            //Validacion Vigencia
            //--------------------------
            if (fnValidaVigencia() == false) { return (false); }
    

            //--------------------------
            //Validacion Tipo de Promocion
            //--------------------------
            if (fnValidaTipoPromocion() == false) { return (false); }

            return (true);
        
        }

        function fnValidaTipoBusqueda() {

            var _tipoBusquedaId = trim(document.getElementById('hdnTipoBusqueda').value);

            if (_tipoBusquedaId == 1) {

                //Por Código Articulo
                var _articuloId = trim(document.getElementById('txtArticuloId').value);
                var _articuloDes = trim(document.getElementById('txtDescripcionArticulo').value);

                if ((_articuloId == '') || (_articuloDes == '')) {//Falta la validacion con el hdnfield
                    alert('Capture un articulo valido');
                    document.getElementById('txtArticuloId').focus();
                    return (false);
                }
            }
            else if (_tipoBusquedaId == 2) {

                //Por Promoción
                var _promocionId = trim(document.getElementById('txtPromocion').value);
                var _promocionDes = trim(document.getElementById('txtPromocionDescripcion').value);

                if (document.getElementById('txtPromocion').disabled == true) {
                    alert('Seleccione otro tipo de busqueda cuando el tipo de promocion sea "Todos".');
                    return (false);
                }

                if ((_promocionId == '') || (_promocionDes == '')) {
                    alert('Capture una promocion valida');
                    document.getElementById('txtPromocion').focus();
                    return (false);
                }

            }
            else if (_tipoBusquedaId == 3) {

                //Por Sucursal
                var _sucursalId = trim(document.getElementById('txtSucursalId').value);
                var _sucursalDes = trim(document.getElementById('txtSucursalDescripcion').value);

                if ((_sucursalId == '') || (_sucursalDes == '')) {
                    alert('Capture una sucursal valida');
                    document.getElementById('txtSucursalId').focus();
                    return (false);
                }
            }
            else if (_tipoBusquedaId == 4) {

                //Por categoria/estrategia
                var _categoriaId = document.getElementById('cboCategoriaPromocion').value;

                if ((document.getElementById('cboCategoriaPromocion').selectedIndex < 0) || (document.getElementById('cboCategoriaPromocion').value == '')) {

                    alert('Seleccione una categoria valida');
                    document.getElementById('cboCategoriaPromocion').focus();
                    return (false);
                }

            }
            else {

                alert('Seleccione el Tipo de Busqueda');
                return (false);
            }

            return (true);
        }

        function fnValidaVigencia() {

            var _vigenciaId = trim(document.getElementById('hdnVigencia').value);

            if ((_vigenciaId == 0 || _vigenciaId == 1 || _vigenciaId == 2 || _vigenciaId == 3 || _vigenciaId == 4) && _vigenciaId != '') {

                if ((_vigenciaId == 4) && (ValidaFechas("dtmFechaIni", "dtmFechaFin") == false)) {

                    return (false);
                }
            }
            else {

                alert('Seleccione la vigencia');
                return (false);
            }

            return (true);
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

        function fnValidaTipoPromocion() {

            var _tipoPromocionId = trim(document.getElementById('hdnTipoPromocion').value);
        
            if (_tipoPromocionId != 0 && _tipoPromocionId != 1 && _tipoPromocionId != 2 && _tipoPromocionId != 3 || _tipoPromocionId == '') {

                alert('Seleccione Tipo de Promocion');
                return (false);
            }
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
            document.getElementById('rdbVigenteEnFechas').checked = true;
            document.getElementById('hdnVigencia').value = 4;

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
<form name="frmConsultarPromociones" action="about:blank" method="post">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <A href="../_Manager/InicioHome.aspx">Central</A> : Confirmacion Asistencia </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
      <tr>
      <td class="tdgeneralcontent">
          <div id="divTitulo"></div>
          <h1>Consulta de Promociones
                              <!--Asistencia - Administrador--></h1>
		<p>Seleccione los filtros de la consulta y presione el boton Consultar. 
                              Los resultados de la consulta se mostraran en una tabla en la parte inferior de la pantalla.</p>
		<table style="width:100%;">
            <tr>
                <td colspan="4">
                    <h2>Tipo de B&uacute;squeda</h2>
                </td>
            </tr>
            <tr>
                <td class="tdtexttablebold" style="width: 150px">
                    <input type="radio" id="rbtArticulo" name="cmdTipoBusqueda" value="1" onfocus="return cmdTipoBusqueda_onfocus(this.value)"/>Por Código Articulo:
                </td>
                        <td class="tdtittablas" style="width: 240px" >
                            <input language='javascript' id="txtArticuloId" type="text" name="txtArticuloId" maxLength="16" size="30"  class="campotabla" onKeyPress=" return txtArticuloId_onKeyPress(event);" value='<%=Request.Form("txtArticuloId")%>' onfocus="return cmdTipoBusqueda_onfocus(1)" onblur="objArticuloLupa_onClick()" autocomplete='off'> 
                            <IMG style="CURSOR:pointer;" id="objLupaArticulo" onclick="javascript:objArticuloLupa_onClick()" border="0" align="absMiddle" src="../static/images/icono_lupa.gif" width="17" height="17">
                        </td>        
                <td class="tdtexttablebold" style="width: 100%" colspan="2">
                    <input class="campotablaresultado" name="txtDescripcionArticulo" readonly size="50" type="text" />
                </td>
                        <td class="tdpadleft5" style="width: 240px">    
                        </td>
                    </tr>
            <tr>
                <td class="tdtexttablebold" style="width: 150px">
                    <input type="radio" id="rbtPromocion" name="cmdTipoBusqueda" value="2" onfocus="return cmdTipoBusqueda_onfocus(this.value)">Por Promoción:
                </td>
                        <td class="tdtittablas" style="width: 240px" >
                            <input language='javascript' id="txtPromocion" type="text" name="txtPromocion" maxLength="16" size="30"  class="campotabla" onKeyPress=" return txtPromocionId_onKeyPress(event);" value='<%=Request.Form("txtPromocion")%>' onblur="cmdVerificarPromocion_onclick()" onfocus="return cmdTipoBusqueda_onfocus(2)" autocomplete='off'> 
                            <IMG style="CURSOR:pointer;" id="objLupaPromocion" onclick="javascript:cmdVerificarPromocion_onclick()" border="0" align="absMiddle" src="../static/images/icono_lupa.gif" width="17" height="17"> 
                        </td>        
                <td class="tdtexttablebold" colspan="2">
                    <input type="text" class="campotablaresultado" readOnly size="50" id="txtPromocionDescripcion" name="txtPromocionDescripcion">
                    
                </td>
                    </tr>
            <tr>
                <td class="tdtexttablebold" style="width: 150px">
                    <input type="radio" id="rbtSucursal" name="cmdTipoBusqueda" value="3" onfocus="return cmdTipoBusqueda_onfocus(this.value)">Por Sucursal:
                </td>
                        <td class="tdtittablas" style="width: 240px" >
                            <input language='javascript' id="txtSucursalId" type="text" name="txtSucursalId" maxLength="16" size="30"  class="campotabla"  onKeyPress=" return txtSucursalId_onKeyPress(event);" value='<%=Request.Form("txtSucursalId")%>' onfocus="return cmdTipoBusqueda_onfocus(3)" onblur="cmdBuscarSucursal_onclick()" autocomplete='off'> 
                            <IMG style="CURSOR:pointer;" id="IMG4" onclick="javascript:cmdBuscarSucursal_onclick()" border="0" align="absMiddle" src="../static/images/icono_lupa.gif" width="17" height="17"> 
                        </td>        
                <td class="tdtexttablebold" colspan="2">
                    <input type="text" class="campotablaresultado" readOnly size="50" id="txtSucursalDescripcion" name="txtSucursalDescripcion">
                </td>
                    </tr>
            <tr>
                        <td class="tdtexttablebold" style="width: 170px">
                            <input type="radio" id="rbtTipoEstrategia" name="cmdTipoBusqueda" value="4" onfocus="return cmdTipoBusqueda_onfocus(this.value)"/>Por categoria/estrategia:
                        </td>
                        <td class="tdpadleft5" style="width: 240px" colspan="3">
                            <select id="cboCategoriaPromocion" name="cboCategoriaPromocion" class="campotabla" style="width:150px" onchange="return cboCategoriaPromocion_onchange()">
							</select>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4"></td>
                    </tr>
            <tr>
                                    <td>&nbsp;</td>
                                </tr>
		<tr>
                                    <td class='txsubtitulo' colspan="4">
                                        <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">Vigencia&nbsp;
                                    </td>
                                </tr>
            <tr>
                <td class="tdtexttablebold" width="25%">
                                        <input type="radio" id="rbtVigentes" name="cmdVigencia" value="1" onfocus="return cmdVigencia_onfocus(this.value)"/>Vigentes
                                    </td>
                <td class="tdtexttablebold" width="25%">
                                        <input type="radio" id="rbtNoVigentes" name="cmdVigencia" value="2" onfocus="return cmdVigencia_onfocus(this.value)"/>No Vigentes
                                    </td>
                <td class="tdtexttablebold" width="25%">
                                        <input type="radio" id="rbtProximasVigencias" name="cmdVigencia" value="3" onfocus="return cmdVigencia_onfocus(this.value)"/>Proximas Vigencias
                                    </td>
                <td class="tdtexttablebold" width="25%">
                                        <input type="radio" id="rbtTodas" name="cmdVigencia" value="0" onfocus="return cmdVigencia_onfocus(this.value)"/>Todas
                                    </td>
            </tr>
            <tr>
                <td class="tdtexttablebold">
                    <input type="radio" id="rdbVigenteEnFechas" name="cmdVigencia" value="4" onfocus="return cmdVigencia_onfocus(this.value)"/>Vigentes en las fechas
                </td>
                                
                <td class="tdtexttablebold" style="width: 150px" align="right">Desde:&nbsp;
                        <input id="Text4" name="dtmFechaIni" class="field" size="10" maxLength="10" type="text" value="<%= strFirstDayOfMonth()%>" onKeyPress=" return dtmFecha_onKeyPress(event);" onfocus="return cmdVigencia_onfocus(4)"> 
                        <A href="javascript:cal1.popup()" onfocus="return cmdVigencia_onfocus(4)">
                          <IMG src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
											        alt="Clic para seleccionar la fecha."> 
                      </A> <br> 
                    </td>
                                    <td class="tdtexttablebold" style="width: 150px" align="right">Hasta:&nbsp;
                        <input id="Text7" name="dtmFechaFin" class="field" size="10" maxLength="10" type="text" value='<%= strFechaActual()%>' onKeyPress=" return dtmFecha_onKeyPress(event);" onfocus="return cmdVigencia_onfocus(4)"> 
                        <A href="javascript:cal2.popup()" onfocus="return cmdVigencia_onfocus(4)">
                          <IMG src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
											        alt="Clic para seleccionar la fecha."> 
                      </A> <br> 
                    </td>
                <td></td>
                                </tr>
            <tr>
            <td colspan="4" width="100%">
            </td>
		</tr>
        <tr>
                        <td class='txsubtitulo' colspan="4">
                            <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">Tipo de Promocion
                        </td>
                    </tr>
            <tr>
                <td class="tdtexttablebold">
                    <input type="radio" id="rbtTodos" name="cmdTipoPromocion" value="0" onfocus="return cmdTipoPromocion_onfocus(this.value)"/>Todos
                </td>
                <td class="tdtexttablebold">
                    <input type="radio" id="rbtOfertas" name="cmdTipoPromocion" value="1" onfocus="return cmdTipoPromocion_onfocus(this.value)"/>Ofertas
                </td>
                <td class="tdtexttablebold">
                    <input type="radio" id="rbtPromociones" name="cmdTipoPromocion" value="2" onfocus="return cmdTipoPromocion_onfocus(this.value)"/>Promociones
                </td>
                <td class="tdtexttablebold">
                    <input type="radio" id="rbtCupones" name="cmdTipoPromocion" value="3" onfocus="return cmdTipoPromocion_onfocus(this.value)"/>Cupones
                </td>
          </tr>
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
        <div id="divConsultaPromociones">
            <!--Consulta-->
            <%= Me.strTablaConsultaPromociones()%> 
            
            <!--Articulo-->
            <%= Me.strTablaConsultaCodigoArticulo()%>
            <!--Promocion-->
            <%= Me.strTablaConsultaCodigoPromocion()%>  
            <!--Sucursal-->
            <%= Me.strTablaConsultaCodigoSucursal()%>  
            

        </div>            
    </div>
    <script language="JavaScript">

        var strTotalDePartidas = "<%= strTotalDePartidas()%>"
        parent.document.getElementById('hdnTotalDePartidas').value = strTotalDePartidas;

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
