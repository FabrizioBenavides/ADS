<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SistemaConsultarPromocionesDetalleArticulos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SistemaConsultarPromocionesDetalleArticulos" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
<HEAD>
<title>Benavides: Busqueda avanzada de promociones</title>
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
    strUsuarioNombre = "<%= strUsuarioNombre %>";
    strFechaHora = "<%= strHTMLFechaHora %>";


    function window_onload() {
        document.forms[0].action = "<%= strFormAction %>";
    }



function cmdCancelar_onclick() {
    window.close();
}

function cmdSalir_onclick() {
}

function trim(stringToTrim) {
    return stringToTrim.replace(/^\s+|\s+$/g, "");
}

function txtArticuloId_onKeyPress(e) {

    //Se limpia la descripcion del articulo y se validan los caracteres permitidos.
    //document.forms[0].elements['txtPromocionDescripcion'].value = '';

    var key = window.event ? e.keyCode : e.wich;

    //No se permiten caracteres especiales para el Articulo.
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
       //-->
</script>
</HEAD>
<body language="javascript" onload="return window_onload()">
<form id="frmVerDetalleArticulosCupones" method="post" name="frmVerDetalleArticulosCupones" action="about:blank">
  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
    <tr> 
      <td class="tdtab" width="780px">Está en : Sistema : Consulta de Promociones
        : Detalle de Articulos Por Promocion</td>
    </tr>
  </table>
  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
    <tr> 
      <td class="tdgeneralcontent" colspan="8"> 
          <table border="0"  cellSpacing="0" cellPadding="0" style="width:100%;">
                  <tr>
                      <td style="width:780px;"><h1>Articulos</h1></td>
                  </tr>
            </table>
        <br> <table border="0" cellSpacing="0" cellPadding="0" style="width:100%;">
            <tr>
                <td colspan="8">
                    <h2>Detalle de los Articulos</h2>
                </td>
            </tr>
          <tr> 
            <td>
                <input id="cmdRegresar" class="button" onclick="return cmdCancelar_onclick()" value="Regresar" type="button" name="cmdRegresar" style="margin-top:20px;"> 

                <input type="hidden" id="hdnPromocionId" name="hdnPromocionId" value='<%= intPromocionId()%>' /> 
                <input type="hidden" id="hdnTipoPromocionId" name="hdnTipoPromocionId" value='<%= intTipoPromocionId()%>' /> 
            </td>
            <td class="tdpadleft5" height="10" colSpan="7" align="left"> 
            </td>
          </tr>
        </table>
        <div id="tblArticulos" style="width:80%"></div>
      </td>
    </tr>
  </table>
  <table border="0" cellSpacing="0" cellPadding="0" width="780px">
    <tr> 
      <td> <script language="JavaScript" type="text/javascript">crearTablaFooterCentral()</script> 
      </td>
    </tr>
  </table>
</form>
<div style="display:none;"> 
  <div id="divConsultaArticulos" colspan="8"> 
      <%= Me.strTablaConsultaArticulos()%> 
  </div>
</div>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
<iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</HTML>
