<%@ Page CodeBehind="SistemaEmpresasRecolectorasAdministrarEmpresasRecolectoras.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaEmpresasRecolectorasAdministrarEmpresasRecolectoras" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
    document.forms[0].action = "<%= strFormAction %>";
    <%= strJavascriptWindowOnLoadCommands %>
}
function cmdImprimir_onclick() {
  window.print();
}
function cmdAgregarEmpresa_onclick() {
  window.location.href = "SistemaEmpresasRecolectorasEditarEmpresa.aspx";
}

//-->
</script>
</head>
<body language="javascript" onLoad="return window_onload()"> 
<form> 
  <table width="780" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td><script language="JavaScript">crearTablaHeader()</script></td> 
    </tr> 
  </table> 
  <table width="780" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td width="10">&nbsp;</td> 
      <td width="770" class="tdtab">Está en : <a href="Sistema.aspx">Sistema</a> : <a href="SistemaEmpresasRecolectoras.aspx"> Empresas recolectoras</a> : Administrar empresas recolectoras</td> 
    </tr> 
  </table> 
  <table width="780" border="0" cellpadding="0" cellspacing="0"> 
    <tr> 
      <td class="tdgeneralcontent"><h1>Administrar empresas recolectoras </h1> 
        <p>En esta parte usted puede realizar consultas y dar de alta las empresas recolectoras que se utilizarán en el sistema. </p>
		<%= strObtenerEmpresasdeValores()  %>
		<br> 
        <br>
		<input name="cmdImprimir" type="button" class="button" id="cmdImprimir" value="Imprimir" language=javascript onClick="return cmdImprimir_onclick()">
		&nbsp;
		<input name="cmdAgregar" type="button" class="button" id="cmdAgregar" value="Agregar empresa" language=javascript onClick="return cmdAgregarEmpresa_onclick()"> 
        <br>
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
