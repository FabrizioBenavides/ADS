<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistroActividadesDesarrolloAsignacion.aspx.vb" Inherits="com.isocraft.backbone.ccentral.RegistroActividadesDesarrolloAsignacionAdmin" %>
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

        var confirmar = confirm('¿Desea exportar la informacion a Excel?');

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

        if(document.getElementById('cboClasificacion').selectedIndex == '0'){
        
            alert('Seleccione la clasificacion.');
            return (false);
        }
        else if (document.getElementById('cboActividad').selectedIndex == '0') {

            alert('Seleccione una actividad.');
            return (false);
    }
       

        document.forms[0].action = "<%=strFormAction%>?strCmd=cmdAsignar";
        document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
        document.forms[0].target = '';
}

    //-->

    function cboClasificacion_onchange() {

        document.getElementById('tblReporte').innerHTML = '';

        if (document.getElementById('cboClasificacion').selectedIndex != 0) {

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultarActividad'
            document.forms[0].target = '_self';
            document.forms[0].submit();
            return (true);
        }

        return (false);
    }

    function cboActividad_onchange() {

        return (true);
    }

    function cmdCambiarAsignacion_onclick(intActividadId, strCmdEstatus) {

        var confirmar = confirm('¿Desea cambiar el estatus de la asignacion de esta actividad?');
        if (confirmar) {

            //Si la actividad no esta asignada se asigna (0 = No Asignada, 1 = Asignada)
            if (strCmdEstatus == 0) {

                strCmd = 'cmdAsignar';
            }
            else {
                strCmd = 'cmdDesAsignar';
            }


            document.getElementById('hdnActividadId').value = intActividadId;
            //document.forms[0].action = "<=strFormAction%>?strCmd=cmdAsignar";
            document.forms[0].action = '<%= strThisPageName%>?intActividadId=' + intActividadId + '&strCmd=' + strCmd;
            document.forms[0].target = '_self';
            document.forms[0].submit();
        }

        return(false);
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
      <td width="770" class="tdtab">Está en : <A href="../_Manager/InicioHome.aspx">Central</A> : Registro de Actividades : Administración de Actividades</td>
    </tr>
  </table>
  
    <table width="780" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td class="tdgeneralcontent" >
                <h1>Administración de Actividades de Sistemas - Asignación</h1>
		        <p>Seleccione la clasificacion para ver las actividades disponibles.<br> 
                   Una vez que el sistema muestre las actividades, las podra asignar o desasignar mediante el boton de la seccion Acciones.
		        </p>
                

                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="50%" valign="top">
                            <table width="100%">
                                <tr>
                                    <td class='txsubtitulo' colspan="2"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">Filtros de Consulta</td>
                                </tr>
                                <tr>
                                    <td class="tdtexttablebold" style="width: 100px">Recurso</td>
                                    <td class="tdconttablas" colspan="4"> 
                                        <%= strUsuarioNombre()%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdtexttablebold" style="width: 100px">Clasificación</td>
                                    <td class="tdconttablas"  colspan="3"> 
                                        <select id="cboClasificacion" class="campotabla" name="cboClasificacion" class="campotabla" style="width:150px" onchange="return cboClasificacion_onchange()">
                                            <option selected="selected" value="-1">&raquo; Seleccione &laquo;</option>
							            </select>
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
                    <input type="hidden" id="hdnActividadId" name="hdnActividadId"  />
		        </P>
		        <br>
                <div id="tblReporte" class="tdconttablasrojo"></div>
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
        <div id="divConsultaActividadesRecurso">
            <%= Me.strTablaConsultaActividadesRecursos()%>
        </div>
    </div>
        <script language="JavaScript" type="text/javascript">


            if ("<%= strCmd %>" == 'cmdGuardar') {

                //document.getElementById('txtComentarios').value = '';
                //parent.document.getElementById('tblComentarios').style.display = 'none';

            }

    </script>

    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>
