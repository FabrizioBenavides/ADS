<%@ Page CodeBehind="SistemaEditarGrupo.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaEditarGrupo" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
<script language="JavaScript" type="text/JavaScript" src="js/Tools.js"></script>
<script id=clientEventHandlersJS language=javascript>

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
<%= strJavascriptWindowOnLoadCommands %>
}

function blnFormValidator(theForm) {
  
  var blnReturn = false;

  /* Validación del campo "txtGrupoUsuarioNombre" */
  if (blnValidarCampo(document.forms[0].elements["txtGrupoUsuarioNombre"], true, "Nombre del grupo", cintTipoCampoAlfanumerico, 50, 1, "") == true) {
  
    /* Validación del campo "txtGrupoUsuarioNombreId" */
    if (blnValidarCampo(document.forms[0].elements["txtGrupoUsuarioNombreId"], true, "Identificador interno", cintTipoCampoAlfanumerico, 50, 1, "") == true) {
    
      /* Validación del campo "txtGrupoUsuarioDescription" */
      blnReturn = blnValidarCampo(document.forms[0].elements["txtGrupoUsuarioDescripcion"], true, "Descripción", cintTipoCampoAlfanumerico, 50, 1, "");
    
    }
  
  } 

  return (blnReturn);
}

function cmdRegresar_onclick() {
  window.location.href = "SistemaAdministrarGrupos.aspx";
}

// done hiding -->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSistemaEditarGrupo" onSubmit="return blnFormValidator(this)">
  <input type="hidden" name="txtGrupoUsuarioId" value="0">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : <a href="Sistema.htm">Sistema</a> : Administrar grupos  : Editar grupo </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Editar grupo </h1>
        <p>Llene o modifique los campos siguientes y luego oprima el bot&oacute;n para salvar los cambios. </p>
        <table width="60%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="30%" class="tdtexttablebold">Nombre del grupo:</td>
            <td width="70%" class="tdpadleft5"><input name="txtGrupoUsuarioNombre" type="text" class="field" id="txtGrupoUsuarioNombre" size="50" maxlength="50"></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Identificador interno:</td>
            <td class="tdpadleft5"><input name="txtGrupoUsuarioNombreId" type="text" class="field" id="txtGrupoUsuarioNombreId" size="50" maxlength="50"></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Replicable:</td>
            <td class="tdtexttablereg"><input name="optGrupoUsuarioReplicable" type="radio" value="1">
              S&iacute;
              <input name="optGrupoUsuarioReplicable" type="radio" value="0" checked="true">
              No</td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Del sistema:</td>
            <td class="tdtexttablereg"><input name="optGrupoUsuarioSistema" type="radio" value="1">
              S&iacute;
              <input name="optGrupoUsuarioSistema" type="radio" value="0" checked="true">
              No</td>
          </tr>
          <tr>
            <td valign="top" class="tdtexttablebold">Descripci&oacute;n:</td>
            <td class="tdpadleft5"><textarea name="txtGrupoUsuarioDescripcion" cols="52" rows="5" class="fieldcomment" id="txtGrupoUsuarioDescripcion"></textarea></td>
          </tr>
          <tr>
            <td height="10" colspan="2" valign="top"><img src="images/pixel.gif" width="1" height="10"></td>
          </tr>
          <tr>
            <td valign="top" class="tdtexttablebold">&nbsp;</td>
            <td class="tdpadleft5"><input type="button" name="cmdRegresar" value="Regresar" class="button" language=javascript onclick="return cmdRegresar_onclick()">
&nbsp;
              <input type="submit" name="cmdSalvar" value="Salvar grupo" class="button"></td>
          </tr>
        </table>
        <br>
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
