<%@ Page CodeBehind="SistemaBinesConsultar.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaBinesConsultar" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
	
function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";
  document.forms[0].elements["txtIDBin"].value = "<%= strtxtIDBin %>";
  <%= strLlenarEmisorComboBox() %>
  <%= strJavascriptWindowOnLoadCommands %>
}

function cmdEjecutar_onclick() {
  if(blnValidarCampo(document.forms[0].elements["txtIDBin"], false, "BIN", cintTipoCampoEntero, 10, 1, "")==false){
    return(false);
  }else{
    return(true);
  }
}

function cmdLimpiar_onclick() {
  document.forms[0].elements["cboEmisor"].selectedIndex = 0;
  document.forms[0].elements["txtIDBin"].value = "";
  document.forms[0].submit();
}

// done hiding -->
</script>
</head>
<body language=javascript onLoad="return window_onload()">
<form name="frmMain" action="about:blank" method="post">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : <a href="Sistema.htm">Sistema</a> : <a href="../_Manager/SistemaBines.aspx">BINes</a> : Consultar BINes </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Consultar BINes </h1>
        <p>En esta parte usted puede consultar los BINes que han sido dados de alta en el sistema. </p>
        <h2>B&uacute;squeda de BINes</h2>
        <table width="70%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="76" valign="top" class="tdtexttablebold">Emisor: </td>
            <td width="455" valign="top" class="tdpadleft5"><select name="cboEmisor" class="field" id="cboEmisor">
                <option value="0">--- Seleccione un emisor ---</option selected>
              </select>
            </td>
          </tr>
          <tr>
            <td valign="top" class="tdtexttablebold">BIN</td>
            <td valign="top" class="tdpadleft5"><input name="txtIDBin" type="text" class="field" id="txtIDBin" size="20" maxlength="20"></td>
          </tr>
          <tr>
            <td height="10" colspan="2" ><img src="images/pixel.gif" width="1" height="10"></td>
          </tr>
        </table>
        <input name="cmdEjecutar" type="submit" class="button" id="cmdEjecutar" value="Ejecutar consulta" language=javascript onClick="return cmdEjecutar_onclick()">
        <input name="cmdLimpiar" type="button" class="button" id="cmdLimpiar" value="Limpiar" language=javascript onclick="return cmdLimpiar_onclick()">
        <br>
        <br>
        <%= strObtenerBINes() %></td>
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
