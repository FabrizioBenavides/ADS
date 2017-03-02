<%@ Page CodeBehind="SistemaBinesAdministrarGenerales.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaBinesAdministrarGenerales" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script id=clientEventHandlersJS language=javascript>
<!--
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";


function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";
  <%= strJavascriptWindowOnLoadCommands %>
}

function cmdAgregar_onclick() {
  if (document.forms[0].elements["txtArchivo"].value.length < 1) {
    alert("Por favor especifique un valor para el campo \"Archivo\".");
    document.forms[0].elements["txtArchivo"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=Agregar";
  return(true);
}

function cmdReemplazar_onclick() {
  if (document.forms[0].elements["txtArchivo"].value.length < 1) {
    alert("Por favor especifique un valor para el campo \"Archivo\".");
    document.forms[0].elements["txtArchivo"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=Reemplazar";
  return(true);
}

//-->
</script>
</head>
<body language=javascript onload="return window_onload()"> 
<form name="frmMain" action="about:blank" method="post" runat=server> 
  <table width="780" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td><script language="JavaScript">crearTablaHeader()</script></td> 
    </tr> 
  </table> 
  <table width="780" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td width="10">&nbsp;</td> 
      <td width="770" class="tdtab">Est&aacute; en : <a href="Sistema.htm">Sistema</a> : <a href="../_Manager/SistemaBines.aspx">Bines</a> : Administrar BINes generales </td> 
    </tr> 
  </table> 
  <table width="780" border="0" cellpadding="0" cellspacing="0"> 
    <tr> 
      <td class="tdgeneralcontent"><h1>Administrar BINes generales</h1> 
        <p>En esta parte usted administrar&aacute; los BINes generales del sistema. </p> 
        <h2>Agregar BINes</h2> 
        <table width="60%"  border="0" cellspacing="0" cellpadding="0"> 
          <tr> 
            <td width="12%" class="tdtexttablebold">Archivo:</td> 
            <td class="tdpadleft5"><input name="txtArchivo" id="txtArchivo" type="file" class="field" size="55" maxlength="55" runat="server"> 
              <br></td> 
          </tr> 
          <tr> 
            <td height="10" colspan="2"><img src="images/pixel.gif" width="1" height="10"></td> 
          </tr> 
          <tr> 
            <td height="10">&nbsp;</td> 
            <td height="10" colspan="2" class="tdpadleft5"><input name="cmdAgregar" type="submit" class="button" id="cmdAgregar" value="Agregar" language=javascript onclick="return cmdAgregar_onclick()"> 
&nbsp; 
              <input name="cmdReemplazar" type="submit" class="button" id="cmdReemplazar" value="Reemplazar" language=javascript onclick="return cmdReemplazar_onclick()"></td> 
          </tr> 
        </table> 
        <br> </td> 
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
