<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaArchivoProductosNegados.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaArchivoProductosNegados" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaArchivoProductosNegados.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página de productos negados.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Carlos E. Pérez Torres
    ' Version       : 1.0
    ' Last Modified : Lunes, Octubre 27, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/ToolsValRFC.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
function window_onload() {
	var resultado;

	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
	document.forms[0].action = "<%=strFormAction%>";
	<%=strcboEmpleadoAutorizado%>
	
	// Recuperamos los valores consultados
	document.forms[0].elements["txtFechaInicio"].value = "<%=Request.Form("txtFechaInicio")%>"
	document.forms[0].elements["txtFechaFin"].value = "<%=Request.Form("txtFechaFin")%>"
	document.forms[0].elements["txtArticuloId"].value = "<%=strArticuloInternoId%>"
	document.forms[0].elements["txtArticuloDescripcion"].value = "<%=strArticuloNombreId%>"

	// Opción para traer el artículo
	if ("<%=strCmd()%>"=="Ver"){
	
		resultado="<%=strBuscarArticuloDescripcion%>";
	
		if (resultado!="0"){
			    document.forms[0].elements['txtArticuloId'].value="<%=strArticuloInternoId%>";
		        document.forms[0].elements['txtArticuloDescripcion'].value="<%=strArticuloNombreId%>";
		    }
		    
		else {
		    alert("Codigo Articulo No existe");
		    document.forms[0].elements['txtArticuloId'].focus();
		}
	}
	else {
		document.forms[0].elements['txtArticuloId'].focus();
	}
	return(true);
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}
function btnRegresar_onclick() {
   document.location = 'MercanciaInventariosProductosNegados.aspx';
	return(true);

}
function cmdValidarForma() {
	if (document.forms[0].elements["txtFechaInicio"].value == ""){
		alert("Por favor seleccione la fecha inicial.");
		document.forms[0].elements["txtFechaInicio"].focus();
		return(false);
	}
	else if (!(blnValidarCampo(document.forms('frmMercanciaArchivoProductosNegados').elements('txtFechaInicio'),false,'Fecha Inicio',cintTipoCampoFecha,10,10,'')) ) {
		document.forms[0].elements["txtFechaInicio"].value = "";
		document.forms[0].elements["txtFechaInicio"].focus();
		return(false);
	}
	if (document.forms[0].elements["txtFechaFin"].value == ""){
		alert("Por favor seleccione la fecha final.");
		document.forms[0].elements["txtFechaFin"].focus();
		return(false);
	}
	else if (!(blnValidarCampo(document.forms('frmMercanciaArchivoProductosNegados').elements('txtFechaFin'),false,'Fecha Final',cintTipoCampoFecha,10,10,'')) ) {
		document.forms[0].elements["txtFechaFin"].value = "";
		document.forms[0].elements["txtFechaFin"].focus();
		return(false);
	}
	return(true);
}

function cmdConsultar_onclick(){
	if (!(cmdValidarForma())) {
		return(false);
	}
	else {
		document.forms[0].action = "<%=strFormAction%>?strCmd=Consultar";
		return(true);
	}
}

function cmdDetectaNumero_onClick(){
	if (document.forms[0].elements['txtArticuloId'].value!=""){
      if (!isNaN(document.forms[0].elements['txtArticuloId'].value)) {
			document.forms[0].action = "<%=strFormAction%>?strCmd=Ver";
			document.forms[0].submit();
			return(false);
	  }
	  else {
			cmdBuscarArticulo_onClick('PopArticulo.aspx?strArticulo=txtArticuloId&strArticuloNombreId=txtArticuloDescripcion',500,540);
	  }
	}
	else {
		alert("Teclear Código o Descripcion");
        return false;
	}
	
}

function cmdBuscarArticulo_onClick(url, width, height) {
          url=url+'&strArticuloIdNombre='+document.forms[0].elements['txtArticuloId'].value;
          return Pop(url, width, height);
}
 
function Pop(url, width, height) {
    var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	 return (false);
}

function strRecordBrowser() {
	document.write("<%=strRecordBrowser%>");
	return(true);
}


//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaArchivoProductosNegados">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="34" width="100%"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td width="100%"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><span class="txdmigaja">Está en : 
              </span><a href="Mercancia.aspx" class="txdmigaja">Mercancía</a><span class="txdmigaja"> 
              : <a href="MercanciaInventarios.aspx" class="txdmigaja">Inventarios</a></span><span class="txdmigaja"> 
              </span><span class="txdmigaja">: </span><span class="txdmigaja"> 
              <a href="MercanciaInventariosProductosNegados.aspx" class="txdmigaja">Productos 
              negados </a></span> <span class="txdmigaja">: </span> <span class="txdmigaja">Archivo 
              de productos negados</span></td>
            <td width="187" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" class="tdtablacont"> <p><span class="txtitulo">Archivo 
                      de productos negados</span><span class="txcontenido">Configure 
                      la consulta que desea hacer sobre los reportes de productos 
                      negados en su sucursal.</span> 
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td width="137" class="tdtittablas">Empleado autorizado:</td>
                        <td colspan="3" class="tdconttablas"> <select name="cboEmpleadoAutorizado" class="campotabla">
                            <option value="0" selected>&gt;&gt;Elija el Empleado 
                            Autorizado&lt;&lt;</option>
                          </select> </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas">Consultar desde el:</td>
                        <td width="128" valign="middle" class="tdpadleft5"><input name="txtFechaInicio" type="text" class="campotabla" size="10" maxlength="10"> 
                          <a href="javascript:objCalendar1.popup();"><img src="../static/images/icono_calendario.gif" width="20" height="13" border="0" onClick="return blnValidarCampo(document.forms('frmMercanciaArchivoProductosNegados').elements('txtFechaInicio'),false,'Fecha Inicio',cintTipoCampoFecha,10,10,'');" style="CURSOR:hand"></a> 
                        </td>
                        <td width="62" valign="middle" class="tdtittablas">Y hasta 
                          el:</td>
                        <td width="241" valign="middle" class="tdpadleft5"><input name="txtFechaFin" type="text" class="campotabla" size="9" maxlength="4"> 
                          <a href="javascript:objCalendar2.popup();"><img src="../static/images/icono_calendario.gif" width="20" height="13" border="0" onClick="return blnValidarCampo(document.forms('frmMercanciaArchivoProductosNegados').elements('txtFechaFin'),false,'Fecha Final',cintTipoCampoFecha,10,10,'');" style="CURSOR:hand"></a> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas">Consultar por producto:</td>
                        <td valign="middle" class="tdpadleft5"> <input name="txtArticuloId" type="text" class="campotabla" size="16" maxlength="16"> 
                          <a href="javascript:;" onClick="return cmdDetectaNumero_onClick();"><img src="../static/images/icono_lupa.gif" width="17" height="17" align="absMiddle" border="0"></a> 
                        </td>
                        <td colspan="2" valign="middle" class="tdconttablasrojo"><input class="campotablaresultado" type="text" size="50" name="txtArticuloDescripcion" readonly> 
                        </td>
                      </tr>
                    </table>
                    <br> <input name="btnConsultar" type="submit" class="boton" value="Consultar" onClick="return cmdConsultar_onclick();"> 
                    <br> <br> <br> <script language="javascript">strRecordBrowser()</script> 
                    <br> <input name="btnRegresar" type="button" class="boton" value="Regresar"  onClick="return btnRegresar_onclick()"> 
                    &nbsp;&nbsp; <input name="btnLimpiar" type="button" class="boton" value="Limpiar" style="display:none"> 
                    &nbsp;&nbsp; <br> <br> </p> </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"><script language="javascript">strGeneraTablaAyuda('');</script> 
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	var objCalendar1 = new calendar1(document.forms['frmMercanciaArchivoProductosNegados'].elements['txtFechaInicio']);
	var objCalendar2 = new calendar1(document.forms['frmMercanciaArchivoProductosNegados'].elements['txtFechaFin']);
	//-->
</script>
</form>
</body>
</html>
