<%@ Page CodeBehind="SucursalAsignarPoliticasDePosAUnaSucursal.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalAsignarPoliticasDePosAUnaSucursal" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
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
  document.forms[0].elements["txtDestinoCompaniaId"].value = "<%= intDestinoCompaniaId %>";
  document.forms[0].elements["txtDestinoSucursalId"].value = "<%= intDestinoSucursalId %>";
  document.forms[0].elements["chkTodoPoliticas"].checked = <%= strTodoPoliticas %>;
  document.forms[0].elements["chkTodoCajas"].checked = <%= strTodoCajas %>;
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarDireccionComboBox() %>
<%= strLlenarZonaComboBox() %>
<%= strLlenarSucursalComboBox() %>
<%= strLlenarCajaComboBox() %>
<%= strLlenarPoliticasComboBox() %>
<%= strLlenarCajasDestinoComboBox() %>
  if (document.forms[0].elements["cboSucursal"].selectedIndex > 0 && document.forms[0].elements["cboCajas"].length > 0 && document.forms[0].elements["cboPoliticas"].length > 0) {
    document.forms[0].elements["cmdAsignar"].disabled = false;
    document.forms[0].elements["chkTodoCajas"].disabled = false;
    document.forms[0].elements["cboCajas"].disabled = false;
    document.forms[0].elements["chkTodoPoliticas"].disabled = false;
    document.forms[0].elements["cboPoliticas"].disabled = false;
  } else {
    document.forms[0].elements["cmdAsignar"].disabled = true;
    document.forms[0].elements["chkTodoCajas"].disabled = true;
    document.forms[0].elements["cboCajas"].disabled = true;
    document.forms[0].elements["chkTodoPoliticas"].disabled = true;
    document.forms[0].elements["cboPoliticas"].disabled = true;
  }
  if (document.forms[0].elements["cboCajas"].length == 0) {
    alert("La sucursal no tiene cajas disponibles a las cuales asignarles políticas.");
    cmdRegresar_onclick();
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

function cboSucursal_onchange() {
  document.forms[0].submit();
  return(true);
}

function chkTodoPoliticas_onclick() {
  SelectAllComboBoxElements(document.forms[0].elements["cboPoliticas"], document.forms[0].elements["chkTodoPoliticas"].checked);
}

function chkTodoCajas_onclick() {
  SelectAllComboBoxElements(document.forms[0].elements["cboCajas"], document.forms[0].elements["chkTodoCajas"].checked);
}

function strDireccionOperativaNombre() {
  document.write("<%= strDireccionOperativaNombre %>");
}

function strZonaOperativaNombre() {
  document.write("<%= strZonaOperativaNombre() %>");
}

function strSucursalNombre() {
  document.write("<%= strSucursalNombre() %>");
}

function cmdRegresar_onclick() {
  window.location.href = "SucursalAdministrarPoliticasDePOS.aspx?intDireccionId=<%= intDestinoDireccionId %>&intZonaId=<%= intDestinoZonaId %>";
}

function blnFormValidator(theForm) {
  if (blnComboBoxHasAnElementSelected(document.forms[0].elements["cboPoliticas"]) == false) {
    alert("Por favor seleccione al menos una Política.");
    document.forms[0].elements["cboPoliticas"].focus(); 
    return(false);
  }
  if (blnComboBoxHasAnElementSelected(document.forms[0].elements["cboCajas"]) == false) {
      alert("Por favor seleccione al menos una Caja.");
      document.forms[0].elements["cboCajas"].focus();
      return(false);
  } 
  document.forms[0].action += "?strCmd=Asignar";
  return(true);
}

//-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmMain" onSubmit="return blnFormValidator(this)">
  <input type="hidden" name="txtDestinoDireccionId">
  <input type="hidden" name="txtDestinoZonaId">
  <input type="hidden" name="txtDestinoCompaniaId">
  <input type="hidden" name="txtDestinoSucursalId">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : Sucursal : Puntos de venta  : Asignar pol&iacute;ticas de POS a una sucursal </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Asignar pol&iacute;ticas de POS a una sucursal </h1>
        <p><strong>Sucursal a la que se le asignar&aacute;n pol&iacute;ticas de punto de venta </strong></p>
        <table width="50%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="16%" class="tdtexttablebold">Direcci&oacute;n:</td>
            <td width="84%" class="tdcontentableblue"><script language="javascript">strDireccionOperativaNombre()</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Zona: </td>
            <td class="tdcontentableblue"><script language="javascript">strZonaOperativaNombre()</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Sucursal:</td>
            <td class="tdcontentableblue"><script language="javascript">strSucursalNombre()</script></td>
          </tr>
        </table>
        <br>
        <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar" language=javascript onclick="return cmdRegresar_onclick()">
        <br>
        <br>
        <h2>Elija la sucursal cuyas pol&iacute;ticas de POS asignar&aacute;. </h2>
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
            <td class="tdpadleft5"><select name="cboSucursal" class="field" id="cboSucursal" language=javascript onchange="return cboSucursal_onchange()">
                <option value="0|0">Elija una sucursal</option selected>
              </select></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">* Caja </td>
            <td class="tdpadleft5"><select name="cboCaja" class="field" id="cboCaja" language=javascript onchange="return cboSucursal_onchange()">
                <option value="0">Elija una caja</option selected>
              </select></td>
          </tr>
        </table>
        <br>
        <br>
        <h2>Seleccione las pol&iacute;ticas que desea copiar de la caja seleccionada </h2>
        <table width="50%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="tdtexttablebold"><input name="chkTodoPoliticas" type="checkbox" id="chkTodoPoliticas" onclick="return chkTodoPoliticas_onclick()" value="true">
&nbsp;Seleccionar todas</td>
          </tr>
          <tr>
            <td width="81%" class="tdpadleft5"><select name="cboPoliticas" size="10" multiple="multiple" id="cboPoliticas">
              </select>
            </td>
          </tr>
        </table>
        <br>
        <h2>Defina a qu&eacute; caja o cajas se copiar&aacute;n las pol&iacute;ticas elegidas </h2>
        <table width="50%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="tdtexttablebold"><input name="chkTodoCajas" type="checkbox" id="chkTodoCajas" onclick="return chkTodoCajas_onclick()" value="true">
&nbsp;Seleccionar todas</td>
          </tr>
          <tr>
            <td width="81%" class="tdpadleft5"><select name="cboCajas" size="10" multiple="multiple" id="cboCajas">
              </select>
            </td>
          </tr>
        </table>
        <br>
        <span class="tdgeneralcontentpop"><span class="tdpadleft5">
        <input name="cmdAsignar" type="submit" class="button" value="Asignar pol&iacute;ticas">
        </span></span><br></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaFooter()</script></td>
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
