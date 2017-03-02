<%@ Page CodeBehind="VentasAdministrarArticulosExceptosDeDescuento.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasAdministrarArticulosExceptosDeDescuento" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script id=clientEventHandlersJS language=javascript>
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarGrupoClienteEspecialComboBox() %>
<%= strTipoExceptoComboBox() %>
}

function cmdReemplazar_onclick() {
  if (document.forms[0].elements["cboGrupoClienteEspecial"].selectedIndex == 0) {
    alert("Por favor elija un \"Grupo de clientes especiales\".");
    document.forms[0].elements["cboGrupoClienteEspecial"].focus();
    return(false);
  }
  if (document.forms[0].elements["cboTipoExcepto"].selectedIndex == 0) {
    alert("Por favor elija un \"Tipo de excepto\".");
    document.forms[0].elements["cboTipoExcepto"].focus();
    return(false);
  }
  if (document.forms[0].elements["txtArticuloClienteEspecialArchivo"].value.length == 0) {
    alert("Por favor especifique un valor para el campo \"Archivo\".");
    document.forms[0].elements["txtArticuloClienteEspecialArchivo"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=Reemplazar";
  document.forms[0].submit();
  return(true);
}

function cmdAgregar_onclick() {
  if (document.forms[0].elements["cboGrupoClienteEspecial"].selectedIndex == 0) {
    alert("Por favor elija un \"Grupo de clientes especiales\".");
    document.forms[0].elements["cboGrupoClienteEspecial"].focus();
    return(false);
  }
  if (document.forms[0].elements["cboTipoExcepto"].selectedIndex == 0) {
    alert("Por favor elija un \"Tipo de excepto\".");
    document.forms[0].elements["cboTipoExcepto"].focus();
    return(false);
  }
  if (document.forms[0].elements["txtArticuloClienteEspecialArchivo"].value.length == 0) {
    alert("Por favor especifique un valor para el campo \"Archivo\".");
    document.forms[0].elements["txtArticuloClienteEspecialArchivo"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=Agregar";
  document.forms[0].submit();
  return(true);
}

function cboGrupoClienteEspecial_onchange() {
  document.forms[0].elements["cboTipoExcepto"].selectedIndex = 0;
  document.forms[0].submit();
}

function cmdLimpiar_onclick() {
  window.location.href = "VentasAdministrarArticulosExceptosDeDescuento.aspx";
}

function cboTipoExcepto_onchange() {
  if (document.forms[0].elements["cboTipoExcepto"].selectedIndex != 0) {
    document.forms[0].submit();
  }
}

-->
</script>
</head>
<body language=javascript onLoad="return window_onload()">
<form method="post" id="frmMain" name="frmMain" enctype="multipart/form-data" runat="server">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script>
      </td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <a href="Sistema.aspx">Sistema</a> : <a href="SistemaClientesEspeciales.aspx">Clientes
          especiales</a> : Asignar artículos exceptos de descuento </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Asignar artículos exceptos de descuento </h1>
        <p>Aquí podrá dar de alta en el sistema los art&iacute;culos exceptos
          de descuento y asign&aacute;rselos a un grupo de clientes especiales.</p>
        <h2>Seleccionar grupo, tipo de excepto y archivo con artículos</h2>
        <table border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td colspan="2"><p>1. Elija el grupo de clientes especiales y el
                tipo de excepto a ser aplicardo.</p>
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="cboGrupoClienteEspecial">Grupo
                de clientes especiales:</label>
            </td>
            <td class="tdpadleft5"><select name="cboGrupoClienteEspecial" id="cboGrupoClienteEspecial" class="field" language=javascript onChange="return cboGrupoClienteEspecial_onchange()">
                <option value="0">-- Elija un grupo --</option>
              </select>
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="cboTipoExcepto">Tipo de excepto:</label>
            </td>
            <td class="tdpadleft5"><select name="cboTipoExcepto" id="cboTipoExcepto" class="field" language=javascript onChange="return cboTipoExcepto_onchange()">
                <option value="0">-- Elija un tipo --</option>
              </select>
            </td>
          </tr>
          <tr>
            <td colspan="2"><img src="images/pixel.gif" width="1" height="10"></td>
          </tr>
          <tr>
            <td colspan="2"><p>2. Localice el archivo con la lista de artículos.</p>
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="txtArticuloClienteEspecialArchivo">Archivo:</label>
            </td>
            <td class="tdpadleft5"><input name="txtArticuloClienteEspecialArchivo" id="txtArticuloClienteEspecialArchivo" type="file" class="field" size="55" maxlength="55" runat="server">
            </td>
          </tr>
        </table>
        <br>
        <input name="cmdLimpiar" type="button" class="button" id="cmdLimpiar" value="Limpiar" language="javascript"
                onClick="return cmdLimpiar_onclick()">
&nbsp;&nbsp;
        <input name="cmdAgregar" type="button" class="button" id="cmdAgregar" value="Actualizar" language="javascript"
                onClick="return cmdAgregar_onclick()">
        <br>
        <br>
        <%= strGetRecordBrowserHTML() %> <br>
        <br>
      </td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaFooterCentral()</script>
      </td>
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
