<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SistemaConsultarPromocionesMasiva.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalConsultarPromocionesMasiva" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>


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
    <link rel="stylesheet" type="text/css" href="css/menu.css">
    <link rel="stylesheet" type="text/css" href="css/estilo.css">
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
        <%= LlenarControlSubCategoriaArticulos() %>
        <%= LlenarControlGrupoArticulos() %>

        //Llenado de Combos
        <%= LlenarControlDireccion()%>
        <%= LlenarControlZona()%>

        //Tipo de Busqueda 
        var intTipoBusquedaId = "<%= intTipoBusquedaId()%>";

        cmdTipoBusqueda_onfocus(intTipoBusquedaId);

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
        else { /*Sin seleccion de Vigencia = -1*/ }

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
        else { /*Sin seleccion de Tipo de Promocion*/ }
    }

    function strGetCustomDateTime() {
        document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
        return (true);
    }


    function frmControlAsistencia_onsubmit() {
        return (true);
    }

    function cmdRegresar_onclick() {
        //Redirecciona a usuario al "home" de Control de Asistencia.
        window.location = "AsistenciaNomina.aspx";
    }

    function cmdTipoBusqueda_onfocus(id) {

        document.getElementById('tblResultados').innerHTML = '';
        document.getElementById('hdnTipoBusqueda').value = id;

        if (id == "1") {

            //Por Archivo
            document.getElementById('rbtArchivo').checked = true;

            document.getElementById('txtArchivo').disabled = false;
            document.getElementById('cboDivisionArticulos').disabled = true;
            document.getElementById('cboCategoriaArticulos').disabled = true;
            document.getElementById('cboSubCategoriaArticulos').disabled = true;
            document.getElementById('cboGrupoArticulos').disabled = true;
            document.getElementById('cboDireccionOperativa').disabled = true;
            document.getElementById('cboZonaOperativa').disabled = true;

            document.getElementById('cboDivisionArticulos').value = "0";
            document.getElementById('cboCategoriaArticulos').value = "0";
            document.getElementById('cboSubCategoriaArticulos').value = "0";
            document.getElementById('cboGrupoArticulos').value = "0";
            document.getElementById('cboDireccionOperativa').value = "0";
            document.getElementById('cboZonaOperativa').value = "0";
        }
        else if (id == "2") {

            //Por Categoria
            document.getElementById('rbtCategoria').checked = true;

            document.getElementById('cboDivisionArticulos').disabled = false;
            document.getElementById('cboCategoriaArticulos').disabled = false;
            document.getElementById('cboSubCategoriaArticulos').disabled = false;
            document.getElementById('cboGrupoArticulos').disabled = false;

            document.getElementById('txtArchivo').disabled = true;
            document.getElementById('cboDireccionOperativa').disabled = true;
            document.getElementById('cboZonaOperativa').disabled = true;

            document.getElementById('cboDireccionOperativa').value = "0";
            document.getElementById('cboZonaOperativa').value = "0";
        }
        else if (id == "3") {

            //Por Region Operativa
            document.getElementById('rbtRegionOperativa').checked = true;

            document.getElementById('cboDireccionOperativa').disabled = false;
            document.getElementById('cboZonaOperativa').disabled = false;

            document.getElementById('txtArchivo').disabled = true;
            document.getElementById('cboDivisionArticulos').disabled = true;
            document.getElementById('cboCategoriaArticulos').disabled = true;
            document.getElementById('cboSubCategoriaArticulos').disabled = true;
            document.getElementById('cboGrupoArticulos').disabled = true;

            document.getElementById('cboDivisionArticulos').value = "0";
            document.getElementById('cboCategoriaArticulos').value = "0";
            document.getElementById('cboSubCategoriaArticulos').value = "0";
            document.getElementById('cboGrupoArticulos').value = "0";
        }
        else {
            //Sin seleccion de Tipo de Busqueda = -1

            document.getElementById('txtArchivo').disabled = true;
            document.getElementById('cboDivisionArticulos').disabled = true;
            document.getElementById('cboCategoriaArticulos').disabled = true;
            document.getElementById('cboSubCategoriaArticulos').disabled = true;
            document.getElementById('cboGrupoArticulos').disabled = true;
            document.getElementById('cboDireccionOperativa').disabled = true;
            document.getElementById('cboZonaOperativa').disabled = true;
        }
    }

    //Funcionalidad de combos Division y Categoria
    function cboDivisionArticulos_onchange() {

        document.forms[0].elements["cmdTipoBusqueda"][1].checked = true;
        document.forms[0].elements["cboCategoriaArticulos"].selectedIndex = 0;
        document.forms[0].elements["cboSubCategoriaArticulos"].selectedIndex = 0;

        document.forms[0].action = '<%= strThisPageName%>?strCmd=';
        document.forms[0].target = '_self';
        document.forms[0].submit();
    }

    function cboCategoriaArticulos_onchange() {
        document.forms[0].elements["cmdTipoBusqueda"][1].checked = true;
        document.forms[0].elements["cboSubCategoriaArticulos"].selectedIndex = 0;

        document.forms[0].action = '<%= strThisPageName%>?strCmd=';
        document.forms[0].target = '_self';
        document.forms[0].submit();
    }

    function cboSubCategoriaArticulos_onchange() {

        document.forms[0].elements["cmdTipoBusqueda"][1].checked = true;
        document.forms[0].elements["cboGrupoArticulos"].selectedIndex = 0;
        document.forms[0].action = '<%= strThisPageName%>?strCmd=';
        document.forms[0].target = '_self';
        document.forms[0].submit();
    }

    function cboGrupoArticulos_onchange() {
        document.forms[0].elements["cmdTipoBusqueda"][1].checked = true;
        //document.forms[0].submit();
    }

    function disabledZona() {
        document.getElementById("cboZonaOperativa").disabled = true;
    }


    function txtArchivo_onfocus() {

        document.getElementById("rbtArchivo").checked = true;
        document.getElementById("txtArchivo").disabled = false;
        
    }

    function cboDireccionOperativa_onchange() {

        document.getElementById("rbtRegionOperativa").checked = true;

        if (document.getElementById("cboDireccionOperativa").value != "0") {

            document.getElementById("cboZonaOperativa").value = "0";

            document.forms[0].action = '<%= strThisPageName%>?strCmd=';
            document.forms[0].target = '_self';
            document.forms[0].submit();

            }

            return (false);
        }

        function cboZonaOperativa_onchange() {

            document.getElementById("rbtRegionOperativa").checked = true;
            return (true);
        }
        
        function cboTipoMovimientos_onchange() {
            document.getElementById('tblResultados').innerHTML = '';
            return (true);
        }

        function cmdVigencia_onfocus(id) {

            document.getElementById('tblResultados').innerHTML = '';
            document.getElementById('hdnVigencia').value = id;
            
            if (id == 4) { document.getElementById('rdbVigenteEnFechas').checked = true; }
            
            return (true);
        }

        function cmdTipoPromocion_onfocus(id) {

            document.getElementById('tblResultados').innerHTML = '';
            document.getElementById('hdnTipoPromocion').value = id;
            return (true);
        }

        function cmdConsultar_onclick() {

            //Variables.
            var valida;

            valida = fnValidaCampos();
            if (valida) {

                document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultar';
                document.forms[0].target = "ifrOculto";
                document.forms[0].target = '_self';
                document.forms[0].submit();
            }

            return (valida);
        }

        function fnValidaCampos() {

            //--------------------------
            //Validacion Tipo Busqueda
            //--------------------------
            if (fnValidaTipoBusqueda() == false) { return (false); }

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
                var _archivoRuta = trim(document.getElementById('txtArchivo').value);

                if (_archivoRuta == '') {

                    alert('Indique la ruta del archivo');
                    document.getElementById('txtArchivo').focus();
                    return (false);
                }
                else {

                    var extension = _archivoRuta.substring(_archivoRuta.length - 3)

                    if (extension.toUpperCase() != 'CSV') {

                        alert('El formato del archivo debe de ser .CSV');
                        return (false);
                    }

                    //El campo "hdnCargadoDeSucursales" indicara como se cargo la tabla de las sucursales, en este caso sera cmdImportar.
                    //document.getElementById('hdnCargadoDeSucursales').value = 'cmdImportar';

                    //document.forms[0].action = '<= strThisPageName%>?strCmd=cmdImportar'
                    //document.forms[0].target = '_self';
                    //document.forms[0].submit();
                }
            }
            else if (_tipoBusquedaId == 2) {

                //Por Promoción
                var _divisionId = trim(document.getElementById('cboDivisionArticulos').value);
                var _categoriaId = trim(document.getElementById('cboCategoriaArticulos').value);
                var _subCategoriaId = trim(document.getElementById('cboSubCategoriaArticulos').value);
                var _grupo = trim(document.getElementById('cboGrupoArticulos').value);

                if (_divisionId == '0') {
                    alert('Capture una division valida');
                    document.getElementById('cboDivisionArticulos').focus();
                    return (false);
                }
            }
            else if (_tipoBusquedaId == 3) {

                //Por Sucursal
                var _direccionId = trim(document.getElementById('cboDireccionOperativa').value);
                var _zonaId = trim(document.getElementById('cboZonaOperativa').value);

                if (_direccionId == '0') {
                    alert('Capture una direccion valida');
                    document.getElementById('cboDireccionOperativa').focus();
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

            if ((_vigenciaId == 0 || _vigenciaId == 1 || _vigenciaId == 2 || _vigenciaId == 3 || _vigenciaId == 4) && (_vigenciaId != '')) {

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

        function cmdTipoNomina_onfocus() {
            document.getElementById('tblResultados').innerHTML = '';
            return (true);
        }

        function cmdTipoConsulta_onfocus() {
            document.getElementById('tblResultados').innerHTML = '';

            if (document.getElementById('rdResumen').checked == true) {
                parent.document.getElementById('rdResumen').checked = true
            }

            if (document.getElementById('rdDetalle').checked == true) {
                parent.document.getElementById('rdDetalle').checked = true
            }
            return (false);
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
    <form id="frmConsultarPromocionesMasiva" name="frmConsultarPromocionesMasiva" action="about:blank" method="post" onsubmit="return frmConsultarPromocionesMasiva_onsubmit()" runat="server">
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <script language="JavaScript">crearTablaHeader()</script>
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="10">&nbsp;</td>
                <td width="770" class="tdtab">Está en : <a href="../_Manager/InicioHome.aspx">Central</a> : Confirmacion Asistencia </td>
            </tr>
        </table>
        <table width="780" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td class="tdgeneralcontent">
                    <div id="divTitulo"></div>
                    <h1>Consulta Masiva de Promociones
                              <!--Asistencia - Administrador-->
                    </h1>
                    <p>
                        Seleccione los filtros de la consulta y presione el boton Consultar. 
                              Los resultados de la consulta seran exportados a un archivo.
                    </p>
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="4">
                                <h2>Tipo de B&uacute;squeda</h2>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" colspan="4">
                                <input id="rbtArchivo" value="1" type="radio" name="cmdTipoBusqueda" onfocus="return cmdTipoBusqueda_onfocus(this.value)">Por archivo de codigos de articulo
                            </td>

                        </tr>
                        <tr width="100%">
                            <td class="tdtexttablebold" width="12%" align="right">Archivo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td class="tdpadleft5" colspan="3">
                                    <input id="txtArchivo" class="field" maxlength="55" size="55" type="file" name="txtArchivo" runat="server">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" colspan="4">
                                <input id="rbtCategoria" value="2" type="radio" name="cmdTipoBusqueda" onfocus="return cmdTipoBusqueda_onfocus(this.value)">Por Categoria
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" class="tdtexttablebold" width="12%" align="right">División:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td class="tdpadleft5" style="width: 150px;" colspan="3">
                                <select id="cboDivisionArticulos" name="cboDivisionArticulos" class="campotabla" onchange="return cboDivisionArticulos_onchange()" style="width: 250px">
                                    <option selected="selected" value="0">&raquo; Elija una division &laquo;</option>
                                    <%--<option selected="selected" value="0">&raquo; Todas &laquo;</option>--%>
                                </select>
                            </td>

                        </tr>
                        <tr>
                            <%--<td colspan="2"></td>--%>
                            <td class="tdtexttablebold" class="tdtexttablebold" width="12%" align="right">Categoría:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td class="tdconttablas" style="width: 150px;" colspan="3">
                                <select id="cboCategoriaArticulos" class="campotabla" name="cboCategoriaArticulos" onchange="return cboCategoriaArticulos_onchange()" style="width: 250px">
                                    <%--<option selected="selected" value="0">&raquo; Elija una categoria &laquo;</option>--%>
                                    <option selected="selected" value="0">&raquo; Todas &laquo;</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <%--<td colspan="2"></td>--%>
                            <td class="tdtexttablebold" class="tdtexttablebold" width="12%" align="right">SubCategoría:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td class="tdconttablas" style="width: 150px;" colspan="3">
                                <select id="cboSubCategoriaArticulos" class="campotabla" name="cboSubCategoriaArticulos" onchange="return cboSubCategoriaArticulos_onchange()" style="width: 250px">
                                    <%--<option selected="selected" value="0">&raquo; Elija una subcategor&iacute;as &laquo;</option>--%>
                                    <option selected="selected" value="0">&raquo; Todas &laquo;</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <%--<td colspan="2"></td>--%>
                            <td class="tdtexttablebold" class="tdtexttablebold" width="12%" align="right">Grupo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td class="tdconttablas" style="width: 150px;" colspan="3">
                                <select id="cboGrupoArticulos" class="campotabla" name="cboGrupoArticulos" style="width: 250px">
                                    <%--<option selected="selected" value="0">&raquo; Elija un grupo &laquo;</option>--%>
                                    <option selected="selected" value="0">&raquo; Todos &laquo;</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" colspan="4">
                                <input id="rbtRegionOperativa" value="3" type="radio" name="cmdTipoBusqueda" onfocus="return cmdTipoBusqueda_onfocus(this.value)">Por Region
                    Operativa</td>
                        </tr>
                        <tr>
                            <%--<td colspan="2"></td>--%>
                            <td class="tdtexttablebold" class="tdtexttablebold" width="12%" align="right">Dirección:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td class="tdconttablas" style="width: 150px;" colspan="3">
                                <select id="cboDireccionOperativa" class="campotabla" onchange="return cboDireccionOperativa_onchange()" name="cboDireccionOperativa" style="width: 250px">
                                    <option selected value="0">&raquo; Elija una dirección &laquo;</option>
                                    <%--<option value="0">&raquo; Todas &laquo;</option>--%>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <%--<td colspan="2"></td>--%>
                            <td class="tdtexttablebold" class="tdtexttablebold" width="12%" align="right">Zona:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td class="tdconttablas" style="width: 150px;" colspan="3">
                                <select id="cboZonaOperativa" class="campotabla" name="cboZonaOperativa" onchange="return cboZonaOperativa_onchange()" style="width: 250px">
                                    <%--<option selected value="0">&raquo; Elija una zona &laquo;</option>--%>
                                    <option value="0">&raquo; Todas &laquo;</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                        <tr>
                            <td class='txsubtitulo' colspan="4">
                                <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">Vigencia&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold" width="25%">
                                <input type="radio" id="rbtVigentes" name="cmdVigencia" value="1" onfocus="return cmdVigencia_onfocus(this.value)" />Vigentes
                            </td>
                            <td class="tdtexttablebold" width="25%">
                                <input type="radio" id="rbtNoVigentes" name="cmdVigencia" value="2" onfocus="return cmdVigencia_onfocus(this.value)" />No Vigentes
                            </td>
                            <td class="tdtexttablebold" width="25%">
                                <input type="radio" id="rbtProximasVigencias" name="cmdVigencia" value="3" onfocus="return cmdVigencia_onfocus(this.value)" />Proximas Vigencias
                            </td>
                            <td class="tdtexttablebold" width="25%">
                                <input type="radio" id="rbtTodas" name="cmdVigencia" value="0" onfocus="return cmdVigencia_onfocus(this.value)" />Todas
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">
                                <input type="radio" id="rdbVigenteEnFechas" name="cmdVigencia" value="4" onfocus="return cmdVigencia_onfocus(this.value)" />Vigentes en las fechas
                            </td>
                            <td class="tdtexttablebold" style="width: 150px" align="right">Desde:&nbsp;
                                <input id="dtmFechaIni" name="dtmFechaIni" class="field" size="10" maxlength="10" type="text" value="<%= strFirstDayOfMonth()%>" onkeypress=" return dtmFecha_onKeyPress(event);" onfocus="return cmdVigencia_onfocus(4)">
                                <a href="javascript:cal1.popup()" onfocus="return cmdVigencia_onfocus(4)">
                                    <img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle" alt="Clic para seleccionar la fecha.">
                                </a>
                                <br>
                            </td>
                            <td class="tdtexttablebold" style="width: 150px" align="right">Hasta:&nbsp;
                                <input id="dtmFechaFin" name="dtmFechaFin" class="field" size="10" maxlength="10" type="text" value='<%= strFechaActual()%>' onkeypress=" return dtmFecha_onKeyPress(event);" onfocus="return cmdVigencia_onfocus(4)">
                                <a href="javascript:cal2.popup()" onfocus="return cmdVigencia_onfocus(4)">
                                    <img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
                                        alt="Clic para seleccionar la fecha.">
                                </a>
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class='txsubtitulo' colspan="4">
                                <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">Tipo de Promocion
                            </td>
                        </tr>
                        <tr>
                            <td class="tdtexttablebold">
                                <input type="radio" id="rbtTodos" name="cmdTipoPromocion" value="0" onfocus="return cmdTipoPromocion_onfocus(this.value)" />Todos
                            </td>
                            <td class="tdtexttablebold">
                                <input type="radio" id="rbtOfertas" name="cmdTipoPromocion" value="1" onfocus="return cmdTipoPromocion_onfocus(this.value)" />Ofertas
                            </td>
                            <td class="tdtexttablebold">
                                <input type="radio" id="rbtPromociones" name="cmdTipoPromocion" value="2" onfocus="return cmdTipoPromocion_onfocus(this.value)" />Promociones
                            </td>
                            <td class="tdtexttablebold">
                                <input type="radio" id="rbtCupones" name="cmdTipoPromocion" value="3" onfocus="return cmdTipoPromocion_onfocus(this.value)" />Cupones
                            </td>
                        </tr>

                    </table>
                    <p>
                        <input type="hidden" id="dtmFechaActual" name="dtmFechaActual" value='<%= strFechaActual()%>' />
                        <input type="hidden" id="hdnTipoBusqueda" name="hdnTipoBusqueda" value='<%= Request("hdnTipoBusqueda")%>'>
                        <input type="hidden" id="hdnVigencia" name="hdnVigencia" value='<%= Request("hdnVigencia")%>'>
                        <input type="hidden" id="hdnTipoPromocion" name="hdnTipoPromocion" value='<%= Request("hdnTipoPromocion")%>'>
                        <input type="hidden" id="hdnCargadoDeSucursales" name="hdnCargadoDeSucursales">
                        <input type="hidden" id="hdnArchivo" name="hdnArchivo">
                        <input type="hidden" id="hdnTotalDePartidas" name="hdnTotalDePartidas">

                        <input class="button" id="cmdConsultar" name="cmdConsultar" value="Consultar" onclick="return cmdConsultar_onclick()" type="button">
                        &nbsp;
                    </p>
                    <div id="tblResultados" class="tdconttablasrojo"></div>
                    <br>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td class="tdpadleft5" align="left" style="width: 65%;">
                                <div id="divBotones"></div>
                            </td>
                            <td class="tdpadleft5" align="right" style="width: 35%;">
                                <div id="divBotnoConfirmar"></div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table width="780" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    <script language="JavaScript">crearTablaFooterCentral()</script>
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
    <div style="display: none;">
        <div id="divConsultaMovimientos">
            <%--<= Me.strTablaConsultarPromociones()%>--%>
        </div>
    </div>
    <script language="JavaScript" type="text/javascript">

        //var strTotalDePartidas = "<= strTotalDePartidas()%>"
        //parent.document.getElementById('hdnTotalDePartidas').value = strTotalDePartidas;

        //if (parent.document.getElementById('tblResultados').innerHTML == '') {

        //    parent.document.getElementById('divBotones').innerHTML = '<input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdCancelar_onclick()" style="margin-top:20px;">';
        //    parent.document.getElementById('divBotnoConfirmar').innerHTML = '';
        //}
        //else {
        //    var botones = '<input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdCancelar_onclick()" style="margin-top:20px;">';
        //    botones = botones + '<input id="cmdImprimir" name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()" style="margin-top:20px;">';
        //    botones = botones + '<input name="cmdExportar" type="button" class="boton" value="Exportar" onClick="return cmdExportar_onclick()" style="margin-top:20px;">';
        //    parent.document.getElementById('divBotones').innerHTML = botones
        //    parent.document.getElementById('divBotnoConfirmar').innerHTML = '<input name="cmdConfirmar" type="button" class="boton" value="Confirmar" onClick="return cmdConfirmar_onclick()" style="margin-top:20px;">';

        //}

        //Variable que indica la ruta del archivo con el que se cargaron las sucursales.
        document.getElementById('hdnArchivo').value = '<%= strArchivo()%>';

        var strTotalDePartidas = "<%= strTotalDePartidas()%>"
        parent.document.getElementById('hdnTotalDePartidas').value = strTotalDePartidas;
    </script>
    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>
