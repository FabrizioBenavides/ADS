<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistroActividadesDesarrolloAsignacionAdmin.aspx.vb" Inherits="com.isocraft.backbone.ccentral.RegistroActividadesDesarrolloAdminActividades" %>

<%@ Import Namespace="Benavides.POSAdmin.Commons"%>

<html>
<head>
    <title>Benavides: Registro de Actividades</title>
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

        <%= LlenarComboClasificacion()%>
        <%= LlenarComboActividad()%>

    }

    function strGetCustomDateTime() {
        document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
        return (true);
    }

    function trim(stringToTrim) {
        return stringToTrim.replace(/^\s+|\s+$/g, "");
    }

    function cmdImprimir_onclick() {

        //Validacion de resultados
        var tablaTotal = document.getElementById('tblRecursos').innerHTML
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
        var tablaTotal = document.getElementById('tblRecursos').innerHTML
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


        function cmdAsignar_onclick() {

            //-01.Se valida que la tabla de resultados no este vacia
            if (trim(document.getElementById('tblRecursos').innerHTML) == '') {
                return (false);
            }

            if (document.getElementById('cboClasificacion').selectedIndex == '0') {

                alert('Seleccione la clasificacion.');
                return(false);
            }

            if (document.getElementById('cboActividad') == '0') {

                alert('Seleccione una actividad.');
                return (false);
            }

            //-02.Inicia rutina para validar cada una de las filas y columnas en la tabla de resultados.
            var i = 0;
            var intTotal = trim(document.getElementById('strTotalDePartidas').value);

            document.forms[0].action = "<%=strFormAction%>?strCmd=cmdAsignar";
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();
            document.forms[0].target = '';

    }

    //-->

    function cboClasificacion_onchange() {

        if (document.getElementById('cboClasificacion').selectedIndex != 0) {

            document.getElementById("cboActividad").value = "0";
        }

        document.getElementById("tblRecursos").innerHTML = '';

        document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultarActividad'
        document.forms[0].target = '_self';
        document.forms[0].submit();

        return true;
    }

    function cboActividad_onchange() {

        document.getElementById("tblRecursos").innerHTML = '';

        if (document.getElementById('cboActividad').selectedIndex != 0) {

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultarActividadAsignada'
            document.forms[0].target = '_self';
            document.forms[0].submit();
            return (true);
        }
        return (false);
    }
</script>

    </head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onload="return window_onload()">
<form name="frmRegistroActividadesDesarrolloAdmin" action="about:blank" method="post">
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
                <h1>Asignación de Actividades de Sistemas Por Jefatura</h1>
		        <p>Elija los filtros de las actividades y presionane el boton Consultar.<br> 
                   Una vez que el sistema muestre sus actividades puede asignar la actvidad a los recursos.
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
                                        <select id="cboClasificacion" class="campotabla" name="cboClasificacion" class="campotabla" style="width:150px" onchange="return cboClasificacion_onchange()">
                                            <option selected="selected" value="0">&raquo; Seleccione &laquo;</option>
							            </select>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td class="tdtexttablebold" style="width: 100px">Actividad</td>
                                    <td class="tdconttablas" colspan="3"> 
                                        <select id="cboActividad" class="campotabla" name="cboActividad" class="campotabla" style="width:150px" onchange="return cboActividad_onchange()">
                                            <option selected="selected" value="0">&raquo; Seleccione &laquo;</option>
							            </select>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    
                                </tr>
                                <tr>
                                    <td class="tdtexttablebold" style="width: 100px"><%--Compartida--%></td>
                                    <td class="tdconttablas" style="width: 150px"> 
                                        <%--<input type="checkbox" id="chkActividadCompartida" name="chkActividadCompartida" disabled />--%>
                                    </td>
                                    
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
		        <P>
                    <input type="hidden" id="strTotalDePartidas" name="strTotalDePartidas" value='<%= strTotalDePartidas()%>' />
		        </P>
                <div id="tblRecursos" class="tdconttablasrojo"></div>
		        <br>
		        <br>
                <input language="javascript" class="button" id="btnGuardar" onclick="return cmdAsignar_onclick()" type="button" value="Guardar" name="btnGuardar">
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
    <div style="display:none;">
        <div id="divConsultaRecursos">
            <%= Me.strTablaConsultaRecursos()%>
        </div>
    </div>
        <script language="JavaScript" type="text/javascript">

            document.getElementById('strTotalDePartidas').value = "<%= strTotalDePartidas()%>"

            if (trim(document.getElementById('tblRecursos').innerHTML) == '') {

                document.getElementById('btnGuardar').style.display = 'none'
            }

    </script>

    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>
