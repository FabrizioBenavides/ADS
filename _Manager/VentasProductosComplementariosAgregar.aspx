<%@ Page CodeBehind="VentasProductosComplementariosAgregar.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasProductosComplementariosAgregar" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<LINK href="css/menu.css" type="text/css" rel="stylesheet">
<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

//Esta página no se está utilizando desde el proyecto Integración de comisiones al POS (IPC)
//Noviembre 2008 ATTE. Javier Augusto Pérez González -- SOFTTEK GDC Monterrey


strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";
  document.forms[0].elements["intArticuloId"].value = "<%= intArticuloId%>";
  document.forms[0].elements["intArticuloComplementarioId"].value = "<%= intArticuloComplementarioId%>";
  document.forms[0].elements["txtArticuloDescripcion"].value = "<%= strtxtArticuloDescripcion %>";
  document.forms[0].elements["txtArticuloComplementarioDescripcion"].value = "<%= strtxtArticuloComplementarioDescripcion %>";
  document.forms[0].elements["txtArticuloEncontrado"].value = "<%= strtxtArticuloEncontrado %>";
  document.forms[0].elements["txtArticuloComplementarioEncontrado"].value = "<%= strtxtArticuloComplementarioEncontrado %>";
  <%= strJavascriptWindowOnLoadCommands %>
}

function ConsultarArticulo() {
  if (blnValidarCampo(document.forms[0].elements["txtArticuloDescripcion"], true, "Producto padre", cintTipoCampoAlfanumerico, 255, 1, "") == true) {
    window.open("../_ScriptLibrary/PopArticulo.aspx?blnSucursal=false&strArticuloIdNombre=" + document.forms[0].elements["txtArticuloDescripcion"].value + "&strArticulo=intArticuloId&strArticuloNombreId=txtArticuloEncontrado&strEvalJs=opener.AutoSubmit()", "Pop", "width=500,height=540,left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no");
  }
}

function ConsultarArticuloComplementario() {
  if(document.forms[0].elements["txtArticuloEncontrado"].value == ""){
		alert("Seleccionar primero un articulo padre");
  }
  else{	
	if (blnValidarCampo(document.forms[0].elements["txtArticuloComplementarioDescripcion"], true, "Seleccionar Artículo", cintTipoCampoAlfanumerico, 255, 1, "") == true) {
		window.open("../_ScriptLibrary/PopArticulo.aspx?blnSucursal=false&strArticuloIdNombre=" + document.forms[0].elements["txtArticuloComplementarioDescripcion"].value + "&strArticulo=intArticuloComplementarioId&strArticuloNombreId=txtArticuloComplementarioEncontrado&strEvalJs=opener.AutoSubmit2()", "Pop", "width=500,height=540,left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no");
	}
  }
}

function cmdConsultar_onclick() {
  window.location.href = "<%= "VentasProductosComplementariosConsultar.aspx?strCmd=Consultar&intArticuloId=" & intArticuloId %>";
  return(true);
}

function cmdRegresar_onclick() {
  window.location.href = "<%= "VentasProductosComplementariosConsultar.aspx?strCmd=Consultar&intArticuloId=" & intArticuloId %>";
  return(true);
}

function strEncabezadoPagina() {
  var strOrigen = "<%= strOrigen %>";
  if (strOrigen == "Editar"||strOrigen == "Detalle") {
    document.write("Editar productos individualmente");
  } else {
    document.write("Agregar productos individualmente");
  }
}

function ImprimirBotonesNavegacion() {
  var strOrigen = "<%= strOrigen %>";
  if (strOrigen != "Menu"&&strOrigen != "Detalle") {
    document.write("<input name=\"cmdRegresar\" type=\"button\" class=\"button\" id=\"cmdRegresar\" value=\"Regresar\" onClick=\"return cmdRegresar_onclick()\">");
  } else {
    document.write("<input name=\"cmdConsultar\" type=\"button\" class=\"button\" id=\"cmdConsultar\" value=\"Consultar productos\" onClick=\"return cmdConsultar_onclick()\">");
  }
}

function cmdRegistrar_onclick() {
  if (document.forms[0].elements["intArticuloId"].value < 1) {
    alert("Por favor estableza un valor para el producto padre.");
    document.forms[0].elements["txtArticuloDescripcion"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=Registrar&strOrigen="+ "<%= strOrigen %>" ;
  document.forms[0].submit();
}

function cmdAsignar_onclick() {
  if (document.forms[0].elements["intArticuloComplementarioId"].value < 1) {
    alert("Por favor estableza un valor para el artículo complementario.");
    document.forms[0].elements["txtArticuloComplementarioDescripcion"].focus();
    return(false);
  }
  if (document.forms[0].elements["intArticuloId"].value == document.forms[0].elements["intArticuloComplementarioId"].value) {
    alert("El producto no puede ser un artículo complementario de sí mismo.\n\r\n\rPor favor establezca un artículo complementario diferente.");
    document.forms[0].elements["txtArticuloComplementarioDescripcion"].value = "";
    document.forms[0].elements["txtArticuloComplementarioEncontrado"].value = "";
    document.forms[0].elements["intArticuloComplementarioId"].value = "0";
    document.forms[0].elements["txtArticuloComplementarioDescripcion"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=Salvar&strOrigen="+"<%= strOrigen %>";
  document.forms[0].submit();
}

function cmdLimpiar_onclick() {
  window.location.href = "<%= strThisPageName %>"+"?strCmd=Limpiar"+"&strOrigen="+"<%= strOrigen %>";
}

function txtArticuloDescripcion_onkeydown(objEvent) {
  if (isEnterKey(objEvent)) {
    ConsultarArticulo();
    return(false);
  }
}

function AutoSubmit() {
  cmdRegistrar_onclick();
}

function AutoSubmit2() {
  cmdAsignar_onclick();
}

function isEnterKey(evt) {
  if (!evt) {
    // grab IE event object
    evt = window.event
  } else if (!evt.keyCode) {
    // grab NN4 event info
    evt.keyCode = evt.which
  }
  return (evt.keyCode == 13)
}

function txtArticuloComplementarioDescripcion_onkeydown(objEvent) {
  if (isEnterKey(objEvent)) {
    ConsultarArticuloComplementario();
    return(false);
  }
}

//-->
</script>
</HEAD>
<body language="javascript" onLoad="return window_onload()">
<form name="frmMain" action="about:blank" method="post">
  <input type="hidden" value="0" name="intArticuloId">
  <input type="hidden" value="0" name="intArticuloComplementarioId">
  <table cellSpacing="0" cellPadding="0" width="780" border="0">
    <tr> 
      <td><script language="JavaScript">crearTablaHeader()</script> </td>
    </tr>
  </table>
  <table cellSpacing="0" cellPadding="0" width="780" border="0">
    <tr> 
      <td width="10">&nbsp;</td>
      <td class="tdtab" width="770">Está en : <A href="Ventas.htm">Ventas</A> 
        : <A href="VentasProductosComplementarios.aspx"> Productos de venta cruzada</A> 
        : 
        <script language="javascript">strEncabezadoPagina()</script> </td>
    </tr>
  </table>
  <table cellSpacing="0" cellPadding="0" width="780" border="0">
    <tr> 
      <td class="tdgeneralcontent"><h1> 
          <script language="javascript">strEncabezadoPagina()</script>
        </h1>
        <p>En esta parte usted puede agregar productos de manera individual y 
          posteriormente asignarles artículos de venta cruzada. </p>
        <h2>Agregar un producto </h2>
        <table cellSpacing="0" cellPadding="0" border="0">
          <tr> 
            <td class="tdtexttablebold" vAlign="top" colSpan="2">1. Seleccionar 
              producto padre </td>
          </tr>
          <tr> 
            <td class="tdtexttablebold" vAlign="top">Producto padre: </td>
            <td class="tdpadleft5" vAlign="top"><span class="tdpadleft5"> 
              <input class="field" id="txtArticuloDescripcion" type="text" maxLength="30" size="30" name="txtArticuloDescripcion" language=javascript onkeydown="return txtArticuloDescripcion_onkeydown(event)">
              <A href="javascript:ConsultarArticulo()"><IMG height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"></A> 
              <input class="campotablaresultado" id="txtArticuloEncontrado" readOnly type="text" size="40"
											border="0" name="txtArticuloEncontrado">
              </span> </td>
          </tr>
          <tr> 
            <td class="tdtexttablebold" vAlign="top">&nbsp;</td>
            <td class="tdpadleft5" vAlign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
              <input language="javascript" class="button" id="cmdRegistrar" onClick="return cmdRegistrar_onclick()"
										type="button" value="Registrar" name="cmdRegistrar"></td>
          </tr>
          <tr> 
            <td class="tdtexttablebold" vAlign="top" colSpan="2">2. Asignar artículos 
              de venta cruzada</td>
          </tr>
          <tr> 
            <td class="tdtexttablebold" vAlign="top">Seleccionar artículo: </td>
            <td class="tdpadleft5" vAlign="top"><input class="field" id="txtArticuloComplementarioDescripcion" type="text" maxLength="30"
										size="30" name="txtArticuloComplementarioDescripcion" language=javascript onkeydown="return txtArticuloComplementarioDescripcion_onkeydown(event)"> 
              <A href="javascript:ConsultarArticuloComplementario()"> <IMG height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"></A> 
              <input class="campotablaresultado" id="txtArticuloComplementarioEncontrado" readOnly type="text"
										size="40" border="0" name="txtArticuloComplementarioEncontrado"></td>
          </tr>
          <tr> 
            <td class="tdtexttablebold" vAlign="top">&nbsp;</td>
            <td class="tdpadleft5" vAlign="top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
              <input language="javascript" class="button" id="cmdAsignar" onClick="return cmdAsignar_onclick()"
										type="button" value="Asignar" name="cmdAsignar"></td>
          </tr>
          <tr> 
            <td class="tdtexttablebold" vAlign="top"><span class="tdpadleft5"> 
              <input language="javascript" class="button" id="cmdLimpiar" onClick="return cmdLimpiar_onclick()"
											type="button" value="Limpiar" name="cmdLimpiar">
              </span> </td>
            <td class="tdpadleft5" vAlign="top">&nbsp;</td>
          </tr>
        </table>
        <%= strObtenerProductosComplementariosDeUnArticulo()%> <br> <script language="javascript">ImprimirBotonesNavegacion()</script> 
      </td>
    </tr>
  </table>
  <table cellSpacing="0" cellPadding="0" width="780" border="0">
    <tr> 
      <td><script language="JavaScript">crearTablaFooterCentral()</script> </td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
			</script>
</form>
</body>
</HTML>
