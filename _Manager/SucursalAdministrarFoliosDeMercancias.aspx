<%@ Page CodeBehind="SucursalAdministrarFoliosDeMercancias.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalAdministrarFoliosDeMercancias" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarDireccionComboBox() %>
<%= strLlenarZonaComboBox() %>
<%= strLlenarSucursalComboBox() %>
  SelectComboBoxElement(document.forms[0].elements["cboFolio"], "<%= intFolioId %>");
  document.forms[0].elements["txtFolioValorActual"].value = "<%= intFolioValorActual %>";
  document.forms[0].elements["txtFolioValorMaximo"].value = "<%= intFolioValorMaximo %>";
  if (document.forms[0].elements["cboFolio"].selectedIndex > 0) {
    document.forms[0].elements["cboFolio"].disabled = false;
    document.forms[0].elements["txtFolioValorActual"].disabled = false;
    document.forms[0].elements["txtFolioValorMaximo"].disabled = false;
    document.forms[0].elements["cmdSalvar"].disabled = false;
  } else {
    document.forms[0].elements["cboFolio"].disabled = true;
    document.forms[0].elements["txtFolioValorActual"].disabled = true;
    document.forms[0].elements["txtFolioValorMaximo"].disabled = true;
    document.forms[0].elements["cmdSalvar"].disabled = true;
  }
}

function cboDireccion_onchange() {
  document.forms[0].elements["cboZona"].selectedIndex = 0;
  if (document.forms[0].elements["cboDireccion"].selectedIndex > 0) {
    document.forms[0].elements["cboSucursal"].selectedIndex = 0;
    document.forms[0].submit();
  } else {
    DeleteComboBoxElements(document.forms[0].elements["cboZona"], 1);
    cboZona_onchange();
  }
  return(true);
}

function cboZona_onchange() {
  document.forms[0].elements["cboSucursal"].selectedIndex = 0;
  if (document.forms[0].elements["cboZona"].selectedIndex > 0) {
    document.forms[0].submit();
  } else {
    DeleteComboBoxElements(document.forms[0].elements["cboSucursal"], 1);
    cboSucursal_onchange();
  }
  return(true);
}

function cboSucursal_onchange() {
  document.forms[0].elements["cboFolio"].selectedIndex = 0;
  if (document.forms[0].elements["cboSucursal"].selectedIndex > 0) {
    document.forms[0].elements["cboFolio"].disabled = false;
  } else {
    document.forms[0].elements["cboFolio"].disabled = true;
  }
  cboFolio_onchange();
  return(true);
}

function cboFolio_onchange() {
  document.forms[0].elements["txtFolioValorActual"].value = "";
  document.forms[0].elements["txtFolioValorMaximo"].value = "";
  if (document.forms[0].elements["cboFolio"].selectedIndex > 0) {
    document.forms[0].action += "?strCmd=Buscar";
    document.forms[0].submit();
  } else {
    document.forms[0].elements["txtFolioValorActual"].disabled = true;
    document.forms[0].elements["txtFolioValorMaximo"].disabled = true;
    document.forms[0].elements["cmdSalvar"].disabled = true;
  }
}

function cmdSalvar_onclick() {
  document.forms[0].action += "?strCmd=Salvar";
  document.forms[0].submit();
  return(true);
}

function blnFormValidator(theForm) {
  
  var blnReturn = false;
  
  /* Validación del campo "txtFolioValorActual" */
  if (blnValidarCampo(theForm.elements["txtFolioValorActual"], true, "Valor actual", cintTipoCampoEntero, 10, 1, "") == true) {
  
    /* Validación del campo "txtFolioValorMaximo" */
    blnReturn = blnValidarCampo(theForm.elements["txtFolioValorMaximo"], true, "Valor máximo", cintTipoCampoEntero, 10, 1, "");
  
  } 

  return (blnReturn);
}

</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSucursalAdministrarFoliosDeMercancias" onSubmit="return blnFormValidator(this)">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : Sucursal : Mercanc&iacute;as : Administrar folios de mercanc&iacute;as </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Administrar folios de mercanc&iacute;as </h1>
        <h2>Configurar consulta de sucursales</h2>
        <p>Elija la sucursal cuyos folios contables desea consultar o actualizar. </p>
        <table width="60%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="16%" class="tdtexttablebold">* Direcci&oacute;n: </td>
            <td width="84%" class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" language=javascript onchange="return cboDireccion_onchange()">
                <option value="0">Elija una direcci&oacute;n </option selected>
              </select>
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold">* Zona: </td>
            <td class="tdpadleft5"><select name="cboZona" class="field" id="cboZona" language=javascript onchange="return cboZona_onchange()">
                <option value="0">Elija una zona </option selected>
              </select></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Sucursal:</td>
            <td class="tdpadleft5"><select name="cboSucursal" class="field" id="cboSucursal" language=javascript onchange="return cboSucursal_onchange()">
                <option value="0|0">Elija una sucursal</option selected>
              </select></td>
          </tr>
        </table>
        <br>
        <h2>Folios contables</h2>
        <table width="60%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="104" class="tdtexttablebold">Folio:</td>
            <td width="351" class="tdpadleft5"><select name="cboFolio" class="field" id="cboFolio" language=javascript onchange="return cboFolio_onchange()">
                <option value="0" selected>Elija una aplicación</option>
                <option value="1">Compras directas</option>
                <option value="2">Devoluciones</option>
                <option value="3">Facturas electr&oacute;nicas</option>
                <option value="4">Facturas manuales</option>
                <option value="5">Inventario agotado</option>
                <option value="6">Inventario negado</option>
                <option value="7">Inventario sugerido</option>
                <option value="8">Merma</option>
                <option value="9">Reclamaciones</option>
                <option value="10">Remisiones electr&oacute;nicas</option>
                <option value="11">Transferencias canceladas</option>
                <option value="12">Transferencias enviadas</option>
                <option value="13">Transferencias internas</option>
                <option value="14">Transferencias recibidas</option>
              </select></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Valor actual :</td>
            <td class="tdpadleft5"><input name="txtFolioValorActual" type="text" class="field" id="txtFolioValorActual" size="20" maxlength="10"></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Valor m&aacute;ximo: </td>
            <td class="tdpadleft5"><input name="txtFolioValorMaximo" type="text" class="field" id="txtFolioValorMaximo" size="20" maxlength="10"></td>
          </tr>
        </table>
        <br>
        <input name="cmdSalvar" type="submit" class="button" value="Actualizar folios" language=javascript onclick="return cmdSalvar_onclick()">
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
