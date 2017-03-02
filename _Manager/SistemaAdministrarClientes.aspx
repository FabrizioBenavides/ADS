<%@ Page CodeBehind="SistemaAdministrarClientes.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaAdministrarClientes" codePage="1252" enableViewState="False" EnableSessionState="False"%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/menu.css" rel="stylesheet" type="text/css" />
<link href="css/estilo.css" rel="stylesheet" type="text/css" />
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
  document.forms[0].action = "<%= strFormAction %>";
  document.forms[0].elements["txtClienteEspecialNombreId"].value = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(Isocraft.Web.Convert.ConvertFromSafeSQLServerString(strClienteEspecialNombreId)) %>";
  document.forms[0].elements["txtClienteEspecialNombre"].value = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(Isocraft.Web.Convert.ConvertFromSafeSQLServerString(strClienteEspecialNombre)) %>";
<%= strLlenarGrupoClienteEspecialComboBox() %>
<%= strJavascriptWindowOnLoadCommands %>
}

function cmdLimpiar_onclick() {
  window.location.href = "<%= strFormAction %>";
}

//-->
</script>
</head>
<body language=javascript onLoad="return window_onload()">
<form method="POST" action="about:blank" name="frmPage">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : <a href="Sistema.aspx">Sistema</a> : <a href="SistemaClientesEspeciales.aspx">Clientes especiales</a> : Administrar clientes </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Administrar clientes </h1>
        <p>Aqu&iacute; podr&aacute; consultar, revisar y modificar los datos de un cliente especial, incluyendo las sucursales a las que aplicar&aacute; su<br />
          convenio.</p>
        <h2>B&uacute;squeda de clientes especiales </h2>
        <table width="90%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="134" class="tdtexttablebold"><label for="cboGrupoClienteEspecial">Grupo:</label></td>
            <td width="188" class="tdpadleft5"><select name="cboGrupoClienteEspecial" class="field" id="cboGrupoClienteEspecial">
                <option value="0">--- Elija un grupo ---</option selected>
              </select>
            </td>
            <td width="125" class="tdpadleft5">&nbsp;</td>
            <td width="236" class="tdpadleft5">&nbsp;</td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="txtClienteEspecialNombreId">Nombre identificador:</label></td>
            <td class="tdpadleft5"><input name="txtClienteEspecialNombreId" type="text" class="field" id="txtClienteEspecialNombreId" size="35" maxlength="35" />
            </td>
            <td class="tdtexttablebold"><label for="txtClienteEspecialNombre">Nombre del cliente:</label></td>
            <td class="tdpadleft5"><input name="txtClienteEspecialNombre" type="text" class="field" id="txtClienteEspecialNombre" size="35" maxlength="35" />
            </td>
          </tr>
        </table>
        <br />
        <input name="cmdLimpiar" type="button" class="button" id="cmdLimpiar" value="Limpiar"  language=javascript onClick="return cmdLimpiar_onclick()"/>
        <input name="cmdBuscar" type="submit" class="button" id="cmdBuscar" value="Buscar" />
        <br />
        <br />
        <%= strGetRecordBrowserHTML() %> <br />
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
	new menu (MENU_ITEMS, MENU_POS);
	//-->
</script>
</form>
</body>
</html>
