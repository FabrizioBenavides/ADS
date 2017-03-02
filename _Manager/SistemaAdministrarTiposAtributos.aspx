<%@ Page CodeBehind="SistemaAdministrarTiposAtributos.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaAdministrarTiposAtributos" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
  document.forms[0].elements["txtTipoAtributoNombreId"].value = "<%= strTipoAtributoNombreId %>";
  document.forms[0].elements["txtTipoAtributoNombre"].value = "<%= strTipoAtributoNombre %>";
  document.forms[0].elements["txtTipoAtributoCaracteresPermitidos"].value = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(strTipoAtributoCaracteresPermitidos) %>";
  document.forms[0].elements["txtTipoAtributoFormato"].value = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(strTipoAtributoFormato) %>";
  document.forms[0].elements["txtTipoAtributoDescripcion"].value = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(strTipoAtributoDescripcion) %>";
  document.forms[0].elements["chkTipoAtributoActivo"].checked = <%= blnTipoAtributoActivo.ToString().ToLower() %>;
  document.forms[0].elements["txtTipoAtributoId"].value = "<%= intTipoAtributoId %>";
  <%= strJavascriptWindowOnLoadCommands %>
  if (strCmd == "Agregar") {
    document.forms[0].elements["txtTipoAtributoNombreId"].focus();
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

  /* Validación del campo "txtTipoAtributoNombreId" */
  if (blnValidarCampo(document.forms[0].elements["txtTipoAtributoNombreId"], true, "Nombre identificador", cintTipoCampoAlfanumerico, 50, 1, "") == true) {

    /* Validación del campo "txtTipoAtributoNombre" */
    if(blnValidarCampo(document.forms[0].elements["txtTipoAtributoNombre"], true, "Nombre descriptivo", cintTipoCampoAlfanumerico, 255, 1, "") == true){

      /* Validación del campo "txtTipoAtributoDescripcion" */
      if(blnValidarCampo(document.forms[0].elements["txtTipoAtributoDescripcion"], true, "Descripción", cintTipoCampoAlfanumericoExtendido, 1024, 1, "") == true){

        /* Validación del campo "txtTipoAtributoCaracteresPermitidos" */
        if (document.forms[0].elements["txtTipoAtributoCaracteresPermitidos"].value.length == 0) {
          alert("Por favor establezca un valor para el campo \"Caracteres permitidos\".");
          document.forms[0].elements["txtTipoAtributoCaracteresPermitidos"].focus();
        } else if (document.forms[0].elements["txtTipoAtributoCaracteresPermitidos"].value.length > 255) {
          alert("Por favor introduzca a lo más 255 caracteres en el campo \"Caracteres permitidos\".");
          document.forms[0].elements["txtTipoAtributoCaracteresPermitidos"].focus();
        } else {
          blnReturn = true;
        }
        
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
  <input type="hidden" name="txtTipoAtributoId">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : <a href="Sistema.aspx">Sistema</a> : <a href="SistemaClientesEspeciales.aspx">Clientes especiales </a> : Administrar tipos de atributos</td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Administrar tipos de atributos</h1>
        <p>Aqu&iacute; podr&aacute; dar de alta o modificar los tipos de atributos a los que pertenece un atributo.</p>
        <h2>Informaci&oacute;n del tipo de atributo</h2>
        <table  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="tdtexttablebold"><label for="txtTipoAtributoNombreId">Tipo de dato:</label></td>
            <td class="tdpadleft5"><input name="txtTipoAtributoNombreId" type="text" class="field" id="txtTipoAtributoNombreId" size="50" maxlength="50" />
&nbsp;<span class="txrojobold">*</span></td>
          </tr>
          <tr>
            <td valign="middle" class="tdtexttablebold"><p>
              <label for="txtTipoAtributoNombre">Nombre:</label>
              <label for="txtTipoAtributoNombre"></label>
              </p>
            </td>
            <td class="tdpadleft5"><input name="txtTipoAtributoNombre" type="text" class="field" id="txtTipoAtributoNombre" size="118" maxlength="255" />
&nbsp;<span class="txrojobold">*</span>&nbsp;<span class="txblueregular">(Visto en el POS) </span></td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="txtTipoAtributoDescripcion">Descripci&oacute;n:</label></td>
            <td class="tdpadleft5"><textarea name="txtTipoAtributoDescripcion" cols="120" rows="2" class="fieldcomment" id="txtTipoAtributoDescripcion"></textarea>
&nbsp;<span class="txrojobold">*</span></td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="txtTipoAtributoCaracteresPermitidos">Caracteres permitidos:</label></td>
            <td class="tdpadleft5"><input name="txtTipoAtributoCaracteresPermitidos" type="text" class="fieldcomment" id="txtTipoAtributoCaracteresPermitidos" size="118" maxlength="255">
&nbsp;<span class="txrojobold">*</span></td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="txtTipoAtributoFormato">Formato:</label></td>
            <td class="tdpadleft5"><textarea name="txtTipoAtributoFormato" cols="120" rows="2" class="fieldcomment" id="txtTipoAtributoFormato"></textarea></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">&nbsp;</td>
            <td class="tdpadleft5"><span class="txblueregular">(Expresi&oacute;n regular VB.Net) </span></td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="chkTipoAtributoActivo">&iquest;Activo?</label></td>
            <td class="tdpadleft5"><input name="chkTipoAtributoActivo" type="checkbox" class="fieldborderless" id="chkTipoAtributoActivo" value="True"></td>
          </tr>
          <tr>
            <td colspan="2" align="right" valign="top" class="txaccion"><img src="images/pixel.gif" width="1" height="10" />Los campos marcados con asterisco (<span class="tdpadleft5"><span class="txrojobold">*</span></span>) son obligatorios.</td>
          </tr>
        </table>
        <span class="tdpadleft5">
        <input name="cmdLimpiar" type="button" class="button" id="cmdLimpiar" value="Limpiar" onClick="return cmdLimpiar_onclick()">
        <input name="cmdGuardar" type="submit" class="button" id="cmdGuardar" value="Guardar"  onClick="return cmdGuardar_onclick()"/>
        </span><br />
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
