<%@ Page CodeBehind="VentasProductosComplementariosConsultar.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasProductosComplementariosConsultar" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" type="text/css" rel="stylesheet">
<link href="css/estilo.css" type="text/css" rel="stylesheet">
<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

//Esta página no se está utilizando desde el proyecto Integración de comisiones al POS (IPC)
//Noviembre 2008 ATTE. Javier Augusto Pérez González -- SOFTTEK GDC Monterrey


strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

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
function window_onload() {
  var intArticuloId = <%= intArticuloId %>;
  document.frmMain.optProducto["<%= intProducto %>"].checked = true;
  document.forms[0].action = "<%= strFormAction %>";
  document.forms[0].elements["txtArticuloDescripcion"].value = "<%= strtxtArticuloDescripcion %>";
  document.forms[0].elements["txtArticuloEncontrado"].value = "<%= strtxtArticuloEncontrado %>";
  document.forms[0].elements["intArticuloId"].value = intArticuloId;
  <%= strJavascriptWindowOnLoadCommands %>
  if (intArticuloId == 0) {
    document.frmMain.optProducto[1].checked = true;
  }
}

function ConsultarArticulo() {
  if (blnValidarCampo(document.forms[0].elements["txtArticuloDescripcion"], true, "Producto específico", cintTipoCampoAlfanumerico, 255, 1, "") == true) {
    window.open("../_ScriptLibrary/PopArticulo.aspx?blnSucursal=false&strArticuloIdNombre=" + document.forms[0].elements["txtArticuloDescripcion"].value + "&strArticulo=intArticuloId&strArticuloNombreId=txtArticuloEncontrado&strEvalJs=opener.AutoSubmit()", "Pop", "width=500,height=540,left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no");
  }
}

function AutoSubmit() {
  if (cmdEjecutar_onclick() == true) {
    document.forms[0].submit();
  }
}

function cmdEjecutar_onclick() {
  if (document.frmMain.optProducto[0].checked == true) {
    if (document.forms[0].elements["intArticuloId"].value == "" || document.forms[0].elements["intArticuloId"].value == "0") {
      alert("Por favor seleccione un producto específico para poder consultar sus artículos complementarios.");
      return(false);
    }
  } else {
    document.forms[0].elements["intArticuloId"].value = "0";  
  }
  document.forms[0].action += "?strCmd=Consultar";
  return(true);
}

function txtArticuloDescripcion_onfocus() {
  document.frmMain.optProducto[0].checked = true;
}

function optProducto_onclick() {
  document.forms[0].elements["txtArticuloDescripcion"].value = "";
  document.forms[0].elements["txtArticuloEncontrado"].value = "";
}

function txtArticuloDescripcion_onkeydown(objEvent) {
  if (isEnterKey(objEvent)) {
    ConsultarArticulo();
    return(false);
  }
}

//-->
</script>
</head>
<body language="javascript" onLoad="return window_onload()">
<form name="frmMain" action="about:blank" method="post">
  <input type="hidden" name="intArticuloId" value="0" />
  <table cellspacing="0" cellpadding="0" width="780" border="0">
    <tr> 
      <td><script language="JavaScript">crearTablaHeader()</script> </td>
    </tr>
  </table>
  <table cellspacing="0" cellpadding="0" width="780" border="0">
    <tr> 
      <td width="10">&nbsp;</td>
      <td class="tdtab" width="770">Está en : <a href="Ventas.htm">Ventas</a> 
        : <a href="VentasProductosComplementarios.aspx"> Productos de venta cruzada</a> 
        : Consultar productos </td>
    </tr>
  </table>
  <table cellspacing="0" cellpadding="0" width="780" border="0">
    <tr> 
      <td class="tdgeneralcontent"><h1>Consultar productos </h1>
        <p>En esta parte usted puede consultar los productos que cuentan con artículos 
          de venta cruzada.</p>
        <h2>Buscar productos </h2>
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
          <tr> 
            <td class="tdtexttablebold" valign="top" width="147"><input type="radio" value="0" name="optProducto">
              Producto específico</td>
            <td class="tdpadleft5" valign="top" width="536"><input class="field" id="txtArticuloDescripcion" type="text" maxlength="30" size="30" name="txtArticuloDescripcion" language=javascript onfocus="return txtArticuloDescripcion_onfocus()" onkeydown="return txtArticuloDescripcion_onkeydown(event)"> 
              <a href="javascript:ConsultarArticulo()"><img height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"></a>&nbsp; 
              <input name="txtArticuloEncontrado" type="text" class="campotablaresultado" size="40" border="0" id="txtArticuloEncontrado" readonly></td>
          </tr>
          <tr> 
            <td class="tdtexttablebold" valign="top" colspan="2"><input type="radio" value="1" name="optProducto" language=javascript onclick="return optProducto_onclick()">
              Todos los productos con artículos de venta cruzada. </td>
          </tr>
          <tr> 
            <td colspan="2" height="10"><img height="10" src="images/pixel.gif" width="1"></td>
          </tr>
        </table>
        <input class="button" id="cmdEjecutar" type="submit" value="Ejecutar consulta" name="cmdEjecutar"
							language="javascript" onclick="return cmdEjecutar_onclick()"> 
        <br> <br> <%= strObtenerProductosConArticulosComplementarios() %> <br> 
      </td>
    </tr>
  </table>
  <table cellspacing="0" cellpadding="0" width="780" border="0">
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
</html>
