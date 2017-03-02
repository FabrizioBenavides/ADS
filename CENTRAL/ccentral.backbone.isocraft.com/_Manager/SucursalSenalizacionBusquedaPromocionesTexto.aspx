<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalSenalizacionBusquedaPromocionesTexto.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalSenalizacionBusquedaPromocionesTexto" %>
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

function strRecordBrowserHTML() {
    var tabla = "<%= strRecordBrowserHTML()%>";

    if (tabla != 0) {
        document.write("<%= strRecordBrowserHTML()%>");
	}
    return (true);
}

function cmdCancelar_onclick() {
    window.location.href = "SucursalSenalizacion.aspx";
}

function cmdSalir_onclick() {
    window.location.href = "InicioHome.aspx";
}

function cmdConsultar_onclick() {
    var valida = true;

    if (document.getElementById('dtmFechaIni').value == '' || document.getElementById('dtmFechaIni').value == '') {

        alert('Capture la fecha');
        return (false);
    }

    valida = ValidaFechas("dtmFechaIni", "dtmFechaFin")

    if (valida) {
        document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultar'
	    document.forms[0].target = "ifrOculto";
	    document.forms[0].submit();
	}

    return (valida)
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
            var date1 = new Date(diaIni, mesIni, anioIni);
            var date2 = new Date(diaFin, mesFin, anioFin);


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

function txtPromocion_onblur() {
    if (trim(document.getElementById('txtPromocion').value) == '') {
        document.getElementById('txtPromocionDescripcion').value = '';
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

function cmdVerificarPromocion_onclick(url, width, height) {
    if (document.getElementById('txtPromocion').value == '') {
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
			        window.open('PopPromociones.aspx?strPromocion=txtPromocion&amp;strPromocionNombreId=txtPromocionDescripcion&strPromocionIdNombre=' + document.getElementById('txtPromocion').value, "Benavides", "toolbar=0,scrollbars=1,location=0,statusbar=0,menubar=0,resizable=1,width=600,height=500,statusbar=no")
			    }
            }
        }

        function cmdVerificarAccion_onclick(id, idFormato) {
            var intPromocionCodigo = id.substring(3);
            var accion = id.substring(0, 3);

            if (accion == 'Ver') {
                window.open('SucursalSenalizacionBusquedaPromocionesTextoPromocion.aspx?intPromocionCodigo=' + intPromocionCodigo + '&idFormato=' + idFormato, 'promocion', 'toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=1,width=800,height=600');
            }
            else if (accion == 'Imp') {

                cmdImprimir_onclick(intPromocionCodigo, idFormato);
            }
            else {
                window.open('SucursalSenalizacionEdicionPromocionesTextoPromocion.aspx?intPromocionCodigo=' + intPromocionCodigo + '&idFormato=' + idFormato, 'promocion', 'toolbar=0,scrollbars=0,location=0,statusbar=0,menubar=0,resizable=1,width=800,height=600');
            }
        }

        function cmdImprimir_onclick(CodigoId, idFormato) {
            
            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdImprimir&CodigoId=' + CodigoId + '&IdFormato=' + idFormato;
            document.forms[0].target = "ifrOculto";
            document.forms[0].submit();

            return(true);
        }

    function fnImprimir(strPromocioneAvanzada) {
        
        //Llamada desde el servidor para imprimir resultados de las consulta.
        document.ifrPageToPrint.document.all.divBody.innerHTML = strPromocioneAvanzada;
        document.ifrPageToPrint.focus();
        window.print();
    }

        //-->
		</script>
</HEAD>
<body language="javascript" onload="return window_onload()">
<form id="frmBusquedaAvanzadaPromociones" method="post" name="frmBusquedaAvanzadaPromociones" action="about:blank">
  <table  cellSpacing="0" cellPadding="0" style="width:780px;">
    <tr> 
      <td width="780px"> <script language="JavaScript">crearTablaHeader()</script> </td>
    </tr>
 </table>
  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
    <tr> 
      <%--<td width="10">&nbsp;</td>--%>
      <td class="tdtab" width="780px">Está en : <A href="../_Manager/SucursalHome.aspx">Sucursal</A> 
        : Promociones Texto </td>
    </tr>
  </table>
  <table border="0" cellSpacing="0" cellPadding="0" style="width:780px;">
    <tr> 
      <td class="tdgeneralcontent" colspan="8"> 
          <table border="0"  cellSpacing="0" cellPadding="0" style="width:100%;">
                  <tr>
                      <td style="width:780px;"><h1>Promoción Texto</h1></td>
                      <%--<td style="width:20px;">&nbsp;</td>--%>
                  </tr>
            </table>
          <%--<h2>Promoción Texto</h2>--%>
        <br> <table border="0" cellSpacing="0" cellPadding="0" style="width:100%;">
            <tr>
                <td colspan="8">
                    <h2>Datos de la Promoción:</h2>
                </td>
            </tr>
          <tr> 
            <td class="tdtexttablebold" width="150px;">Categoria de Promoción:</td>
            <td class="tdconttablas" colspan="7"><select id="cboCategoriaPromocion" class="campotabla" name="cboCategoriaPromocion">
                <option selected value="0">Sin Categoria</option>
                <option value="1">Folleto (Catalogo)</option>
                <option value="2">Fin de Semana (Prensa)</option>
                <option value="3">Impulso</option>
                <option value="4">Obsoletos</option>
                <option value="5">Internas</option>
                <option value="6">Aperturas</option>
              </select> <br> </td>
          </tr>
          <tr> 
            <td class="tdtexttablebold" width="150px;">Promoción:</td>
            <td class="tdconttablas" colspan="7"> 
                <input id="txtPromocion" type="text" name="txtPromocion" maxLength="14" size="14" class="campotabla" value="<%= strPromocionCodigo() %>" onblur="txtPromocion_onblur()" onKeyPress=" return txtArticuloId_onKeyPress(event);"> 
              <IMG style="CURSOR:pointer;" id="objLupa" onclick="javascript:cmdVerificarPromocion_onclick()"
										border="0" align="absMiddle" src="../static/images/icono_lupa.gif" width="17" height="17"> 
              <input type="text" class="campotablaresultado" readOnly size="12" id="txtPromocionDescripcion" name="txtPromocionDescripcion" style="width:300px;"> 
            </td>
          </tr>
          <tr> 
            <td class="tdtexttablebold" width="150px;">Fecha inicio:</td>
            <td class="tdconttablas" colspan="7"> <input id="dtmFechaIni" name="dtmFechaIni" class="field" size="10" maxLength="10" type="text" value="<%= strFirstDayOfMonth()%>"> 
              <A href="javascript:cal1.popup()"><IMG src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
											alt="Clic para seleccionar la fecha."> 
              </A> <br> 
            </td>
          </tr>
          <TR> 
            <td class="tdtexttablebold" width="150px;">Fecha fin:</td>
            <td class="tdconttablas" colspan="7"> <input id="dtmFechaFin" name="dtmFechaFin" class="field" size="10" maxLength="10" type="text" value="<%= strLastDayOfMonth()%>"> 
              <A href="javascript:cal2.popup()"><IMG src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"
											alt="Clic para seleccionar la fecha."> 
              </A> <br> </td>
          </TR>
          <tr> 
            <td>
                <input id="cmdConsultar" class="button" value="Consultar" type="button" name="cmdConsultar" onclick="return cmdConsultar_onclick();" style="margin-top:20px;">
            </td>
            <%--<td height="10">&nbsp;</td>--%>
            <td class="tdpadleft5" height="10" colSpan="7" align="right"> 
                <input id="cmdRegresar" class="button" onclick="return cmdCancelar_onclick()" value="Regresar" type="button" name="cmdRegresar" style="margin-top:20px;"> 
                <input id="cmdSalir" class="button" onclick="return cmdSalir_onclick()" value="Salir" type="button" name="cmdSalir" style="margin-top:20px;"> 
            </td>
          </tr>
          <%--<tr>
            <td style="width:780px;" colspan="8">
                <div id="tblPromociones" colspan="8"></div>
            </td>
          </tr>--%>  
        </table>
        <div id="tblPromociones" style="width:100%"></div>
      </td>
    </tr>
      <%--<tr>
          <td style="width:780px;" colspan="8">
            <div id="tblPromociones"></div>
          </td>
      </tr>--%>
      <%--<tr> 
      <td colspan="8"> 
          <script language="JavaScript" type="text/javascript">crearTablaFooterCentral()</script> 
      </td>
    </tr>--%>
  </table>
  <table border="0" cellSpacing="0" cellPadding="0" width="780px">
    <%--<tr>
            <td style="width:100%;" colspan="8">
                <div id="tblPromociones"></div>
            </td>
          </tr> --%> 
    <tr> 
      <td> <script language="JavaScript" type="text/javascript">crearTablaFooterCentral()</script> 
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
  <div id="divConsultaPromociones" colspan="8"> <%= Me.strTablaConsultaPromociones()%> <%= Me.strTablaConsultaPromocion()%> 
    <%= Me.strTablaConsultaCodigoPromocion()%> </div>
</div>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
<iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</HTML>
