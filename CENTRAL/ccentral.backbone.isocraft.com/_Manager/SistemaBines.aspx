<%@ Page CodeBehind="SistemaBines.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaBines" codePage="1252" EnableSessionState="False" enableViewState="False" %>
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
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script id=clientEventHandlersJS language=javascript>
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

// done hiding -->
</script>
</head>
<body language=javascript>
<form name="frmMain" action="about:blank" method="post">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : <a href="Sistema.htm">Sistema</a> : BINes </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>BINes</h1>
      <p>En esta parte usted puede administrar la informaci&oacute;n correspondiente a los BINes que son utilizados en el sistema. En concreto podr&aacute; realizar consultas, as&iacute; como dar de alta y editar BINes. </p>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="358"><a href="SistemaBinesConsultar.aspx" class="txbluebold12">Consultar BINes </a></td>
          <td width="43">&nbsp;</td>
          <td width="358"><a href="SistemaBinesAdministrarBinesPagoEnCuotas.aspx" class="txbluebold12">Administrar BINes para venta en cuotas</a></td>
        </tr>
        <tr>
          <td width="358"><p>Consulta de los BINes dados de alta en el sistema as&iacute; como su estatus.</p></td>
          <td width="43">&nbsp;</td>
          <td><p>Alta por archivo de los BINes que ser&aacute;n utilizados &uacute;nicamente en las promociones de venta en cuotas.</p></td>
        </tr>
        <tr>
          <td><a href="SistemaBinesAdministrarGenerales.aspx" class="txbluebold12">Administrar BINes generales </a></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><p>Alta por archivo de los BINes que ser&aacute;n utilizados en todo el sistema.</p></td>
          <td>&nbsp;</td>
          <td><p>&nbsp;</p></td>
        </tr>
      </table></td>
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
