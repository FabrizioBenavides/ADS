<%@ Page CodeBehind="SistemaAdministrarAtributos.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaAdministrarAtributos" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
  var strCmd = "<%= strCmd %>";
  document.forms[0].action = "<%= strFormAction %>";
  document.forms[0].elements["txtRecordBrowserSelectedPage"].value = "<%= intSelectedPage %>";
  document.forms[0].elements["txtAtributoId"].value = "<%= intAtributoId %>";
  document.forms[0].elements["chkAtributoRecapturaObligatoria"].checked = <%= blnAtributoRecapturaObligatoria.ToString().ToLower() %>;
  document.forms[0].elements["txtAtributoDescripcion"].value = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(strAtributoDescripcion) %>";
  document.forms[0].elements["txtAtributoNombre"].value = "<%= strAtributoNombre %>";
  document.forms[0].elements["txtAtributoValorLongitudMinima"].value = "<%= intAtributoValorLongitudMinima %>";
  document.forms[0].elements["txtAtributoValorLongitudMaxima"].value = "<%= intAtributoValorLongitudMaxima %>";
  document.forms[0].elements["txtAtributoValorMinimo"].value = "<%= strAtributoValorMinimo %>";
  document.forms[0].elements["txtAtributoValorMaximo"].value = "<%= strAtributoValorMaximo %>";
  document.forms[0].elements["chkAtributoActivo"].checked = <%= blnAtributoActivo.ToString().ToLower() %>;
<%= strLlenarTipoAtributoComboBox() %>
<%= strLlenarAtributoNombreIdComboBox() %>
<%= strLlenarAtributoAlgoritmoValidacionComboBox %>
<%= strJavascriptWindowOnLoadCommands %>
  if (strCmd == "Agregar") {
    document.forms[0].elements["cboTipoAtributo"].focus();
  }
}

function cmdGuardar_onclick() {
  var blnReturn = blnFormValidator();
  if ( blnReturn == true) {
    document.forms[0].action += "?strCmd=Salvar";
  }
  return (blnReturn);
}

function blnFormValidator() {

  var blnReturn = false;

  /* Validación del campo "cboTipoAtributo" */
  if (document.forms[0].elements["cboTipoAtributo"].selectedIndex == 0) {
    alert("Por favor establezca un valor para el campo \"Tipo\".");
    document.forms[0].elements["cboTipoAtributo"].focus();
    return(blnReturn);
  }

  /* Validación del campo "cboAtributoNombreId" */
  if (document.forms[0].elements["cboAtributoNombreId"].selectedIndex == 0) {
    alert("Por favor establezca un valor para el campo \"Nombre identificador\".");
    document.forms[0].elements["cboAtributoNombreId"].focus();
    return(blnReturn);
  }

  /* Validación del campo "txtAtributoNombre" */
  if(blnValidarCampo(document.forms[0].elements["txtAtributoNombre"], true, "Nombre descriptivo", cintTipoCampoAlfanumerico, 255, 1, "") == true) {

    /* Validación del campo "txtAtributoDescripcion" */
    if(blnValidarCampo(document.forms[0].elements["txtAtributoDescripcion"], true, "Descripción", cintTipoCampoAlfanumericoExtendido, 1024, 1, "") == true) {

      /* Validación del campo "txtAtributoValorLongitudMinima" */
      if(blnValidarCampo(document.forms[0].elements["txtAtributoValorLongitudMinima"], true, "Longitud mínima", cintTipoCampoEntero, 9, 1, "") == true) {

        /* Validación del campo "txtAtributoValorLongitudMaxima" */
        blnReturn = blnValidarCampo(document.forms[0].elements["txtAtributoValorLongitudMaxima"], true, "Longitud máxima", cintTipoCampoEntero, 9, 1, "");

      }
      
    }
    
  }
    
  return (blnReturn);
}

function cmdLimpiar_onclick() {
  window.location.href = "<%= strFormAction %>";
}

//-->
</script>
</head>
<body onLoad="return window_onload()">
<form method="POST" action="about:blank" name="frmPage">
  <input type="hidden" name="txtAtributoId" />
  <input type="hidden" name="txtRecordBrowserSelectedPage" />
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : <a href="Sistema.aspx">Sistema</a> : <a href="SistemaClientesEspeciales.aspx">Clientes especiales </a> : Administrar atributos</td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Administrar atributos</h1>
        <p>Aqu&iacute; podr&aacute; modificar los atributos que son incluidos en los tipos de recetas asignados a clientes especiales.</p>
        <h2>Informaci&oacute;n del atributo</h2>
        <table width="100%"  border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td class="tdtexttablebold"><label for="cboTipoAtributo">Tipo de dato:</label></td>
            <td colspan="3" class="tdpadleft5"><select name="cboTipoAtributo" class="field" id="cboTipoAtributo">
                <option value="0">--- Elija un tipo ---</option>
              </select>
              <span class="txrojobold">*</span> </td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="cboAtributoNombreId">Correspondencia con BENSFACT :</label></td>
            <td class="tdpadleft5"><select name="cboAtributoNombreId" class="field" id="cboAtributoNombreId">
                <option value="">--- Elija un identificador ---</option>
              </select>
&nbsp;<span class="txrojobold">*</span></td>
            <td class="tdtexttablebold"><label for="txtAtributoNombre">Nombre en POS:</label></td>
            <td class="tdpadleft5"><input name="txtAtributoNombre" type="text" class="field" id="txtAtributoNombre" size="35" maxlength="35" />
&nbsp;<span class="txrojobold">*</span></td>
          </tr>
          <tr>
            <td valign="middle" class="tdtexttablebold"><label for="txtAtributoDescripcion">Nombre en CTX :</label></td>
            <td colspan="3" class="tdpadleft5"><textarea name="txtAtributoDescripcion" cols="120" rows="2" class="fieldcomment" id="txtAtributoDescripcion"></textarea>
&nbsp;<span class="txrojobold">*</span></td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="txtAtributoValorLongitudMinima">Longitud m&iacute;nima:</label></td>
            <td class="tdpadleft5"><input name="txtAtributoValorLongitudMinima" type="text" class="field" id="txtAtributoValorLongitudMinima" size="35" maxlength="35" />
&nbsp;<span class="txrojobold">*</span></td>
            <td class="tdtexttablebold"><label for="txtAtributoValorLongitudMaxima">Longitud m&aacute;xima:</label></td>
            <td class="tdpadleft5"><input name="txtAtributoValorLongitudMaxima" type="text" class="field" id="txtAtributoValorLongitudMaxima" size="35" maxlength="35" />
&nbsp;<span class="txrojobold">*</span></td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="txtAtributoValorMinimo">Valor m&iacute;nimo:</label></td>
            <td class="tdpadleft5"><input name="txtAtributoValorMinimo" type="text" class="field" id="txtAtributoValorMinimo" size="35" maxlength="35" /></td>
            <td class="tdtexttablebold"><label for="txtAtributoValorMaximo">Valor m&aacute;ximo:</label></td>
            <td class="tdpadleft5"><input name="txtAtributoValorMaximo" type="text" class="field" id="txtAtributoValorMaximo" size="35" maxlength="35" /></td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="cboAtributoAlgoritmoValidacion">Algoritmo de validaci&oacute;n:</label></td>
            <td class="tdpadleft5"><select name="cboAtributoAlgoritmoValidacion" class="field" id="cboAtributoAlgoritmoValidacion">
                <option value="0">--- Elija un algoritmo ---</option>
              </select></td>
            <td colspan="2" class="tdtexttablebold"><label for="chkAtributoRecapturaObligatoria">&iquest;Recaptura obligatoria ?</label>
              <input name="chkAtributoRecapturaObligatoria" type="checkbox" class="fieldborderless" id="chkAtributoRecapturaObligatoria" value="True" />
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="chkAtributoActivo">&iquest;Activo?</label></td>
            <td class="tdpadleft5"><input name="chkAtributoActivo" type="checkbox" class="fieldborderless" id="chkAtributoActivo" value="True"></td>
            <td colspan="2" class="tdtexttablebold">&nbsp;</td>
          </tr>
          <tr>
            <td colspan="4" align="right" valign="top" class="txaccion"><img src="images/pixel.gif" width="1" height="10" />Los campos marcados con asterisco (<span class="tdpadleft5"><span class="txrojobold">*</span></span>) son obligatorios.</td>
          </tr>
        </table>
        <span class="tdpadleft5">
        <input name="cmdLimpiar" type="button" class="button" id="cmdLimpiar" value="Limpiar" language=javascript onClick="return cmdLimpiar_onclick()">
        <input name="cmdGuardar" type="submit" class="button" id="cmdGuardar" value="Guardar"  language=javascript onClick="return cmdGuardar_onclick()"/>
        </span><br />
        <br />
        <%= strGetRecordBrowserHTML() %> <br />
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
