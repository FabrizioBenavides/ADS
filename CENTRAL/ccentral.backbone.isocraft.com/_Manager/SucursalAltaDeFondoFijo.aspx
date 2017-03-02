<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalAltaDeFondoFijo.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalAltaDeFoliosDeFondoFijo" enableViewState="False" EnableSessionState="False"%>
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

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  <%= strJavascriptWindowOnLoadCommands %>
}

function cboDireccion_onchange() {
  if (document.forms[0].elements["cboDireccion"].selectedIndex > 0) {
    document.forms[0].elements["cboZona"].selectedIndex = 0;
    document.forms[0].submit();
  }
  return(true);
}

function cmdRegresar_onclick() {
    window.location.href = "SucursalFondoFijo.aspx";
}

function cmdAgregar_onclick() {
  if (document.forms[0].elements["txtArchivo"].value.length < 1) {
    alert("Por favor especifique un valor para el campo \"Archivo\".");
    document.forms[0].elements["txtArchivo"].focus();
    return(false);
  }
  document.forms[0].elements["strCmd"].value = "Agregar";
  return(true);
}

function cmdReemplazar_onclick() {
  if (document.forms[0].elements["txtArchivo"].value.length < 1) {
    alert("Por favor especifique un valor para el campo \"Archivo\".");
    document.forms[0].elements["txtArchivo"].focus();
    return(false);
  }
  document.forms[0].elements["strCmd"].value = "Reemplazar";
  return(true);
}

//-->
</script>
</HEAD>
<body language="javascript" onLoad="return window_onload()">
<form id="frmMain" action="about:blank" method="post" enctype="multipart/form-data" runat="server">
  <input type="hidden" name="strCmd" value="" />
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <a href="SucursalHome.aspx">Sucursal</a> : 
        Consulta de fondo fijo : Alta de registros </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Alta de registros </h1>
        <p>En esta parte usted puede importar registros de fondo fijo a partir de un archivo. <br>
        </p>
        <h2>Alta de&nbsp;registros de fondo fijo </h2>
        <table width="285" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="19%" class="tdtexttablebold">Archivo: </td>
            <td width="81%" class="tdpadleft5"><input name="txtArchivo" id="txtArchivo" type="file" class="field" size="55" maxlength="55"
                                        runat="server"></td>
          </tr>
          <tr>
            <td colspan="2" class="tdtexttablebold"><input name="cmdAgregar" type="submit" class="button" id="cmdAgregar" value="Agregar" language=javascript onClick="return cmdAgregar_onclick()">
              <input name="cmdReemplazar" type="submit" class="button" id="cmdReemplazar" value="Reemplazar" language=javascript onClick="return cmdReemplazar_onclick()"></td>
          </tr>
        </table>
        <br>
        <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar" language="javascript" onClick="return cmdRegresar_onclick()">
        &nbsp;<br>
      </td>
      <td width="155" class="tdgeneralcontent"><p>La operaci&oacute;n &quot;Agregar&quot; a&ntilde;ade nuevos registros y actualiza aquellos que han sido importados el d&iacute;a de hoy.<br>
          <br>
          La operaci&oacute;n &quot;Reemplazar&quot; elimina y agrega los registros del mes y a&ntilde;o para los cuales se asign&oacute; el fondo fijo. <br>
      Solamente ser&aacute;n afectados los registros dados de alta el d&iacute;a en curso.</p></td>
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
