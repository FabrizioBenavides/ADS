<%@ Page Language="vb" AutoEventWireup="false" Codebehind="VentasProductosComplementariosCargaArchivo.aspx.vb" Inherits="com.isocraft.backbone.ccentral.VentasProductosComplementariosCargaArchivo" codePage="1252" EnableSessionState="False" enableViewState="False" %>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script id="clientEventHandlersJS" language="javascript">
<!--

//Esta página no se está utilizando desde el proyecto Integración de comisiones al POS (IPC)
//Noviembre 2008 ATTE. Javier Augusto Pérez González -- SOFTTEK GDC Monterrey

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
    document.forms[0].action = "<%= strFormAction %>";
    <%= strJavascriptWindowOnLoadCommands %>
}

function cmdConsultar_onclick() {
  window.location.href = "VentasProductosComplementariosConsultar.aspx";
}

function cmdReemplazar_onclick() {
  if (document.forms[0].elements["txtArchivo"].value.length < 1) {
    alert("Por favor especifique un valor para el campo \"Archivo\".");
    document.forms[0].elements["txtArchivo"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=Reemplazar";
  return(true);
}

function cmdAgregar_onclick() {
  if (document.forms[0].elements["txtArchivo"].value.length < 1) {
    alert("Por favor especifique un valor para el campo \"Archivo\".");
    document.forms[0].elements["txtArchivo"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=Agregar";
  return(true);
}

//-->
		</script>
</HEAD>
<body language="javascript" onLoad="return window_onload()">
<form name="frmMain" action="about:blank" method="post" runat="server" ID="Form1">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <a href="Ventas.htm">Ventas</a> 
        : <a href="VentasProductosComplementarios.aspx"> Productos de venta cruzada</a> 
        : Agregar productos por archivo </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td class="tdgeneralcontent"><h1>Agregar productos por archivo </h1>
        <p>En esta parte usted puede agregar productos padre y sus artículos de 
          venta cruzada por medio de un archivo. </p>
        <h2>Buscar archivo </h2>
        <table width="60%" border="0" cellspacing="0" cellpadding="0">
          <tr> 
            <td width="12%" class="tdtexttablebold">Archivo:</td>
            <td class="tdpadleft5"><input name="txtArchivo" id="txtArchivo" type="file" class="field" size="55" maxlength="55"
										runat="server"> <br> </td>
          </tr>
          <tr> 
            <td height="10" colspan="2"><img src="images/pixel.gif" width="1" height="10"></td>
          </tr>
          <tr> 
            <td height="10">&nbsp;</td>
            <td height="10" colspan="2" class="tdpadleft5"><input name="cmdAgregar" type="submit" class="button" id="cmdAgregar" value="Agregar" language="javascript"
										onclick="return cmdAgregar_onclick()"> 
              &nbsp; <input name="cmdReemplazar" type="submit" class="button" id="cmdReemplazar" value="Reemplazar"
										language="javascript" onClick="return cmdReemplazar_onclick()"></td>
          </tr>
        </table>
        <br> <br> <input name="cmdConsultar" type="button" class="button" id="cmdConsultar" value="Consultar productos"
							language="javascript" onClick="return cmdConsultar_onclick()"></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td><script language="JavaScript">crearTablaFooterCentral()</script></td>
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
