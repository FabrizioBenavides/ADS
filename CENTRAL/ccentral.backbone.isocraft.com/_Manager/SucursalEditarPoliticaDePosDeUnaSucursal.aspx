<%@ Page CodeBehind="SucursalEditarPoliticaDePosDeUnaSucursal.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalEditarPoliticaDePosDeUnaSucursal" %>
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
<script id=clientEventHandlersJS language=javascript>
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function strDireccionOperativaNombre() {
  document.write("<%= strDireccionOperativaNombre %>");
}

function strZonaOperativaNombre() {
  document.write("<%= strZonaOperativaNombre() %>");
}

function strSucursalNombre() {
  document.write("<%= strSucursalNombre() %>");
}

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarTipoDatoPoliticaPosComboBox() %>
<%= strLlenarCajaComboBox() %>
  document.forms[0].elements["txtPoliticaPOSSucursalValor"].value = "<%= strPoliticaPOSSucursalValor %>";
  if (document.forms[0].elements["cboTipoDatoPoliticaPOS"].length == 0 || document.forms[0].elements["cboCaja"].length == 0) {
    cmdRegresar_onclick();
  }
}

function blnFormValidator(theForm) {
  var blnReturn = blnValidarCampo(document.forms[0].elements["txtPoliticaPOSSucursalValor"], true, "Valor de la política", cintTipoCampoAlfanumerico, 255, 1, "");
  if (blnReturn == true) {
    document.forms[0].action += "&strCmd=<%= strCmd %>";
  }
  return (blnReturn);
}

function cmdRegresar_onclick() {
  window.location.href = "SucursalVerPoliticasDePOSDeUnaSucursal.aspx?intDireccionId=<%= intDireccionId %>&intZonaId=<%= intZonaId %>&intCompaniaId=<%= intCompaniaId %>&intSucursalId=<%= intSucursalId %>";
}

-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmMain" onSubmit="return blnFormValidator(this)">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : Sucursal : Puntos de venta  : Ver pol&iacute;ticas de POS de una sucursal: Editar pol&iacute;tica de POS de una sucursal </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h2>Editar pol&iacute;tica de POS de una sucursal </h2>
        <table width="50%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="20%" class="tdtexttablebold"> Direcci&oacute;n: </td>
            <td width="80%" class="tdcontentableblue"><script language="javascript">strDireccionOperativaNombre()</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Zona:</td>
            <td class="tdcontentableblue"><script language="javascript">strZonaOperativaNombre()</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Sucursal: </td>
            <td class="tdcontentableblue"><script language="javascript">strSucursalNombre()</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Caja:</td>
            <td class="tdcontentableblue">&nbsp;</td>
          </tr>
        </table>
        <span class="tdpadleft5"> <br>
        </span>
        <table width="100%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="tdtexttablebold">Formato de datos: </td>
            <td class="tdpadleft5"><select name="cboTipoDatoPoliticaPOS" class="field" id="cboTipoDatoPoliticaPOS">
              </select></td>
          </tr>
          <tr>
            <td width="20%" class="tdtexttablebold">Valor de la pol&iacute;tica:</td>
            <td width="80%" class="tdpadleft5"><textarea name="txtPoliticaPOSSucursalValor" cols="128" rows="2" class="fieldcomment" id="txtPoliticaPOSSucursalValor"></textarea></td>
          </tr>
          <tr>
            <td valign="top" class="tdtexttablebold">Caja:</td>
            <td class="tdpadleft5"><select name="cboCaja" class="field" id="cboCaja">
              </select></td>
          </tr>
        </table>
        <br>
        <span class="tdpadleft5">
        <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar" language=javascript onclick="return cmdRegresar_onclick()">
&nbsp;&nbsp;
        <input name="cmdSalvar" type="submit" class="button" id="cmdSalvar" value="Salvar datos">
        </span> </td>
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
