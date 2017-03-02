<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsistenciaDetalle.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistenciaDetalle" %>
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

        document.getElementById('hdnEmpleadoId').value = '<%= strEmpleadoId()%>';
        document.getElementById('hdnMovimientoId').value = '<%= strMovimientoId()%>';
        document.getElementById('hdnFechaInicio').value = '<%= dtmFechaInicio()%>';
        document.getElementById('hdnFechaFin').value = '<%= dtmFechaFin()%>';
        document.getElementById('hdnControlAsistenciaObservacionesId').value = '<%= strControlAsistenciaObservacionesId()%>';
    }

    function strGetCustomDateTime() {
        document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
        return (true);
    }

    function frmControlAsistenciaDetalleArchivoAdam_onsubmit() {
        return (true);
    }

    function cmdRegresar_onclick() {

        //Redirecciona a usuario al "home" de Control de Asistencia.
        window.location = "ControlAsistencia.aspx";
    }

    function trim(stringToTrim) {
        return stringToTrim.replace(/^\s+|\s+$/g, "");
    }

    function cmdImprimir_onclick() {

        //Validacion de resultados
        var tablaTotal = document.getElementById('tblResultados').innerHTML
        if (trim(tablaTotal) == 'Detalle sin resultados' || trim(tablaTotal) == '') {
            alert('No hay detalle que imprimir')
            return (false);
        }

        var confirmar = confirm('Desea imprimir el detalle?');
        if (confirmar) {

            document.forms[0].action = "<%=strFormAction%>?strCmd=cmdImprimir";
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();

            return (true);
        }

        
        }

        function fnImprimir(strDetalleControlAsistencia) {

            //Llamada desde el servidor para imprimir resultados de las consulta.
            document.ifrPageToPrint.document.all.divBody.innerHTML = strDetalleControlAsistencia;
            document.ifrPageToPrint.focus();
            window.print();

        }

        function cmdExportar_onclick() {

            if (trim(document.getElementById('tblResultados').innerHTML) == '') {
                alert('No hay detalle que exportar');
                return (false);
            }
            else {

                var confirmar = confirm('Desea exportar el detalle a Excel?');

                if (confirmar) {

                    document.forms[0].action = "<%=strFormAction%>?strCmd=cmdExportar";
                    document.forms[0].target = "ifrOculto";
                    document.forms[0].submit();
                }
                
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
    //-->
</script>

    </head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onload="return window_onload()">
<form id="frmControlAsistenciaDetalle" name="frmControlAsistenciaDetalle" action="about:blank" method="post">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <A href="../_Manager/InicioHome.aspx">Central</A> : Control de Asistencia : Detalle </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Asistencia - Detalle de Movimientos</h1>
		<p>Detalle de Asistencia por empleado.</p>
		<table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width:100%;">
                    <div id="tblResultados"></div>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <input type="hidden" value='<%=Request.Form("hdnEmpleadoId")%>' name="hdnEmpleadoId" id="hdnEmpleadoId" />
                    <input type='hidden' value='<%=Request.Form("hdnMovimientoId")%>' name='hdnMovimientoId' id="hdnMovimientoId">
                    <input type='hidden' value='<%=Request.Form("hdnFechaInicio")%>' name='hdnFechaInicio' id="hdnFechaInicio">
                    <input type='hidden' value='<%=Request.Form("hdnFechaFin")%>' name='hdnFechaFin' id="hdnFechaFin">
                    <input type='hidden' value='<%=Request.Form("hdnControlAsistenciaObservacionesId")%>' name='hdnControlAsistenciaObservacionesId' id="hdnControlAsistenciaObservacionesId">

                    <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()" style="margin-top:20px;">
                    <input language="javascript" class="button" id="cmdImprimir" name="cmdImprimir" onclick="return cmdImprimir_onclick()" type="button" value="Imprimir" style="margin-top:20px;">
                    <input language="javascript" class="button" id="cmdExportar" onclick="return cmdExportar_onclick()" type="button" value="Exportar" name="cmdcmdExportar" style="margin-top:20px;">
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
    //-->
</script>
</form>
<div style="display:none;"> 
    <div id="divConsultaMovimientos"> 
        <%= Me.strTablaDetalleMovimientos()%>  
    </div>
</div>
    <iframe name="ifrOculto" src="" width="0" height="0"></iframe>
    <iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</html>