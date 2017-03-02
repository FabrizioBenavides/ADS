<%@ Page CodeBehind="SucursalAsignarCuentasEnLote.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalAsignarCuentasEnLote" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="description" content="Javascript Menu">
<meta name="keywords" content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
<script id=clientEventHandlersJS language=javascript>
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  document.forms[0].elements["txtDestinoDireccionId"].value = "<%= intDestinoDireccionId %>";
  document.forms[0].elements["txtDestinoZonaId"].value = "<%= intDestinoZonaId %>";
  document.forms[0].elements["chkTodoSucursales"].checked = <%= strTodoSucursales %>;
  document.forms[0].elements["chkTodoCuentas"].checked = <%= strTodoCuentas %>;
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarDireccionComboBox() %>
<%= strLlenarZonaComboBox() %>
<%= strLlenarSucursalComboBox() %>
<%= strLlenarSucursalesDestinoComboBox() %>
<%= strLlenarCuentasComboBox() %>
<%= strLlenarTipoCuentaComboBox() %>
  if (document.forms[0].elements["cboSucursal"].selectedIndex > 0 && document.forms[0].elements["cboSucursales"].length > 0 && document.forms[0].elements["cboCuentas"].length > 0) {
    document.forms[0].elements["cmdAsignar"].disabled = false;
    document.forms[0].elements["chkTodoSucursales"].disabled = false;
    document.forms[0].elements["cboSucursales"].disabled = false;
    document.forms[0].elements["chkTodoCuentas"].disabled = false;
    document.forms[0].elements["cboCuentas"].disabled = false;
  } else {
    document.forms[0].elements["cmdAsignar"].disabled = true;
    document.forms[0].elements["chkTodoSucursales"].disabled = true;
    document.forms[0].elements["cboSucursales"].disabled = true;
    document.forms[0].elements["chkTodoCuentas"].disabled = true;
    document.forms[0].elements["cboCuentas"].disabled = true;
  }
}

function cboDireccion_onchange() {
  document.forms[0].elements["cboZona"].selectedIndex = 0;
  document.forms[0].elements["cboSucursal"].selectedIndex = 0;
  document.forms[0].submit();
  return(true);
}

function cboZona_onchange() {
  document.forms[0].elements["cboSucursal"].selectedIndex = 0;
  document.forms[0].submit();
  return(true);
}

function cboTipoCuenta_onchange() {
  document.forms[0].submit();
  return(true);
}

function chkTodoCuentas_onclick() {
  SelectAllComboBoxElements(document.forms[0].elements["cboCuentas"], document.forms[0].elements["chkTodoCuentas"].checked);
}

function chkTodoSucursales_onclick() {
  SelectAllComboBoxElements(document.forms[0].elements["cboSucursales"], document.forms[0].elements["chkTodoSucursales"].checked);
}

function strDireccionOperativaNombre() {
  document.write("<%= strDireccionOperativaNombre %>");
}

function strZonaOperativaNombre() {
  document.write("<%= strZonaOperativaNombre() %>");
}

function cmdRegresar_onclick() {
  window.location.href = "SucursalAsignarCuentaSucursal.aspx?intDireccionId=<%= intDestinoDireccionId %>&intZonaId=<%= intDestinoZonaId %>";
}

function blnFormValidator(theForm) {
  if (blnComboBoxHasAnElementSelected(document.forms[0].elements["cboSucursales"]) == false) {
      alert("Por favor seleccione al menos una Sucursal.");
      document.forms[0].elements["cboSucursales"].focus();
      return(false);
  } 
  if (blnComboBoxHasAnElementSelected(document.forms[0].elements["cboCuentas"]) == false) {
    alert("Por favor seleccione al menos una Cuenta.");
    document.forms[0].elements["cboCuentas"].focus(); 
    return(false);
  }
  document.forms[0].action += "?strCmd=Asignar";
  return(true);
}

function cboSucursal_onchange() {
  document.forms[0].submit();
  return(true);
}

//-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSucursalAsignarCuentasEnLote" onSubmit="return blnFormValidator(this)">
  <input type="hidden" name="txtSucursales">
  <input type="hidden" name="txtDestinoDireccionId">
  <input type="hidden" name="txtDestinoZonaId">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : Sucursal : Asignar cuentas a sucursales : Asignar cuentas en lote </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Asignar cuentas en lote</h1>
        <h2>Definir sucursal origen (de ella se copiar&aacute;n las cuentas) </h2>
        <p>Elija la sucursal cuyas cuentas asignar&aacute; a un lote de sucursales. </p>
        <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar" language=javascript onclick="return cmdRegresar_onclick()">
        <br>
        <br>
        <table width="50%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="27%" class="tdtexttablebold">* Direcci&oacute;n: </td>
            <td width="73%" class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" language=javascript onchange="return cboDireccion_onchange()">
                <option value="0">Elija una direcci&oacute;n</option selected>
              </select>
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold">* Zona: </td>
            <td class="tdpadleft5"><select name="cboZona" class="field" id="cboZona" language=javascript onchange="return cboZona_onchange()">
                <option value="0">Elija una zona</option selected>
              </select>
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold">* Sucursal</td>
            <td class="tdpadleft5"><select name="cboSucursal" class="field" id="cboSucursal" language=javascript  onchange="return cboSucursal_onchange()">
                <option value="0|0">Elija una sucursal</option selected>
              </select></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">* Tipo de cuenta</td>
            <td class="tdpadleft5"><select name="cboTipoCuenta" class="field" id="cboTipoCuenta" language=javascript onchange="return cboTipoCuenta_onchange()">
                <option value="0">Todos los tipos</option selected>
              </select></td>
          </tr>
        </table>
        <br>
        <br>
        <h2>Definir sucursales destino (a ellas se asignar&aacute;n las cuentas) </h2>
        <table width="50%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="11%" class="tdtexttablebold">Direcci&oacute;n: </td>
            <td width="89%" class="tdcontentableblue"><script language="javascript">strDireccionOperativaNombre()</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Zona: </td>
            <td class="tdcontentableblue"><script language="javascript">strZonaOperativaNombre()</script></td>
          </tr>
        </table>
        <br>
        <table width="50%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="tdtexttablebold"><input type="checkbox" name="chkTodoSucursales" value="true" language=javascript onclick="return chkTodoSucursales_onclick()">
&nbsp;Seleccionar todas</td>
          </tr>
          <tr>
            <td width="81%" class="tdpadleft5"><select name="cboSucursales" size="10" multiple="multiple" id="cboSucursales">
              </select>
            </td>
          </tr>
        </table>
        <br>
        <br>
        <h2>Definir cuentas que se asignar&aacute;n </h2>
        <table width="50%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="tdtexttablebold"><input type="checkbox" name="chkTodoCuentas" value="true" language=javascript onclick="return chkTodoCuentas_onclick()">
&nbsp;Seleccionar todas</td>
          </tr>
          <tr>
            <td width="81%" class="tdpadleft5"><select name="cboCuentas" size="10" multiple="multiple" id="cboCuentas">
              </select>
            </td>
          </tr>
        </table>
        <br>
        <input name="cmdAsignar" type="submit" class="button" value="Asignar cuentas">
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