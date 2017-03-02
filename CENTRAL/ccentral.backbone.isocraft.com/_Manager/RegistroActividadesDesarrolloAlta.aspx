<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistroActividadesDesarrolloAlta.aspx.vb" Inherits="com.isocraft.backbone.ccentral.RegistroActividadesDesarrolloAlta" %>

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

        <%= LlenarComboClasificacion()%>

        var _intActividadId = "<%= intActividadId()%>";
        parent.document.getElementById('hdnActividadId').value = _intActividadId;


        if (_intActividadId > 0) {

            parent.document.getElementById('cboClasificacion').selectedIndex = "<%= intClasificacionId()%>";
            parent.document.getElementById('txtActividad').value = "<%= strDescripcionActividad()%>";
            parent.document.getElementById('txtTiempoEstimado').value = "<%= decTiempoEstimado()%>";
            

            if ("<%= intActivo()%>" == "1") {

                parent.document.getElementById('chkActiva').checked = true;
            }
            else {
                //parent.document.getElementById('chkActiva').checked = false;
            }


        }
        else {

            parent.document.getElementById('chkActiva').checked = true;
        }

    }

    function strGetCustomDateTime() {
        document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
        return (true);
    }

    function cmdGuardar_onclick() {

        //Variables.
        var valida;

        valida = fnValidaCampos();
        if (valida) {

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdGuardar';
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();
        }

        return (valida);
    }


    function fnValidaCampos() {

        //Variables
        var _clasificacion = document.getElementById('cboClasificacion').selectedIndex;
        var _txtActividad = document.getElementById('txtActividad');
        var _txtTiempoEstimado = trim(document.getElementById('txtTiempoEstimado').value);

        //Inicia validaciones
        if (_clasificacion == '0') {

            alert('Por favor seleccione la clasificacion.');
            return (false);
        }
        else if (fnValidaVacios(_txtActividad) == false) {

            alert('Ingrese el nombre de la actividad que quiere dar de alta.');
            return (false);
        }
        else if(validaFloat(_txtTiempoEstimado) == false){
        
        alert('Ingrese correctamente el Tiempo Estimado.')
        return (false);
        }
        else {

            return (true);
        }
    }

    function fnValidaVacios(txtCampo) {

        if (trim(txtCampo.value) == '') {

            //alert('No se puede dejar campos vacios');
            txtCampo.focus();
            return (false);
        }

        return (true);
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

    function cmdLimpiarCampos_onclick() {

        parent.document.getElementById('hdnActividadId').value = '0';
        document.getElementById('cboClasificacion').selectedIndex = '0';
        document.getElementById('txtActividad').value = '';
        document.getElementById('chkActiva').checked = false;
        document.getElementById('txtTiempoEstimado').value = '';

        document.forms[0].action = "<%=strFormAction%>?intActividad=0";
        //document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
    }

                //-->

    
    function txtActividad_onKeyPress(e) {

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
<form name="frmRegistroActidadesAlta" action="about:blank" method="post">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <A href="../_Manager/InicioHome.aspx">Central</A> : Registro de Actividades : Administración de Actividades</td>
    </tr>
  </table>
  
    <table width="780" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="tdgeneralcontent" >
                <h1>Administración de Actividades de Sistemas - Alta</h1>
		        <p>Seleccione y captura la informacion.<br> 
                   Una vez que tenga todos los datos de la actividad la puede guardar presionando el boton Guardar.
		        </p>

                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="50%" valign="top">
                            <table width="100%">
                                <tr>
                                    <td class='txsubtitulo' colspan="2"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">Filtros de Consulta</td>
                                </tr>
                                <tr>
                                    <td class="tdtexttablebold" style="width: 100px">Clasificacion</td>
                                    <td class="tdconttablas"  colspan="3"> 
                                        <select id="cboClasificacion" class="campotabla" name="cboClasificacion" class="campotabla" style="width:150px">
                                            <option selected="selected" value="0">&raquo; Seleccione &laquo;</option>
							            </select>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="tdtexttablebold" style="width: 100px">Actividad</td>
                                    <td class="tdconttablas" colspan="3"> 
                                        <input type="text" id="txtActividad" name="txtActividad"  size="50" maxLength="45" class="campotabla" onKeyPress=" return txtActividad_onKeyPress(event);" value='<%=Request.Form("txtActividad")%>'/>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="tdtexttablebold" style="width: 100px">Activa</td>
                                    <td class="tdconttablas" style="width: 150px"> 
                                        <input type="checkbox" id="chkActiva" name="chkActiva" value="Activa" disabled/>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="tdtexttablebold" style="width: 100px">Tiempo estimado</td>
                                    <td class="tdconttablas" colspan="4"> 
                                        <input type="text" id="txtTiempoEstimado" name="txtTiempoEstimado" class='campotabla' size="4" maxLength='4' onkeypress="return validaNumerico_onKeyPress(event)" /> Hrs.
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdtexttablebold" style="width: 150px"></td>
                                    <td class="tdconttablas"> 
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
		        <P>
                    <input type="hidden" id="hdnActividadId" name="hdnActividadId" />
                    <input language="javascript" class="button" id="btnLimpiarCampos" onclick="return cmdLimpiarCampos_onclick()" type="button" value="Limpiar campos" name="btnLimpiarCampos">
                    <input language="javascript" class="button" id="btnGuardar" onclick="return cmdGuardar_onclick()" type="button" value="Guardar" name="btnGuardar">
		        </P>
                <div id="tblReporte" class="tdconttablasrojo"></div>
		        <br>
		        <br>
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
    //-->
</script>
</form>
    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>
