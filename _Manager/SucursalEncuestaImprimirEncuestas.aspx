<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEncuestaImprimirEncuestas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEncuestaImprimirEncuestas"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
<%= strJavascriptWindowOnLoadCommands %>
}

function cmdRegresar_onclick() {
   window.location.href = "SucursalEncuestaAdministrarEncuestas.aspx";
}

function cmdImprimir_onclick() {
   printContent();
}

//-->
		</script>
</HEAD>
<body language="javascript" onload="return window_onload()">
<form method="post" action="about:blank" name="frmPage">
  <div id="ToPrintTxtSucursal"></div>
  <div id="ToPrintTxtMigaja"></div>
  <div id="ToPrintTxtFecha"></div>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script>
      </td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <a href="SucursalHome.aspx">Sucursal</a> : <a href="SucursalEncuestasHome.aspx"> Encuestas</a> :
        Administrar Encuestas</td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><p>
          <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar" language="javascript"  onclick="return cmdRegresar_onclick()">
          <input name="cmdImprimir" type="button" class="button" id="cmdImprimir" value="Imprimir" language="javascript" onclick="return cmdImprimir_onclick()">
          <br>
        </p>
        <div id="ToPrintHtmContenido"> <%= strGetRecordBrowserHTML() %></div>
      </td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaFooterCentral()</script>
      </td>
    </tr>
  </table>
  <script language="JavaScript">
  <!--
	  new menu (MENU_ITEMS, MENU_POS);
	//-->
			</script>
</form>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</HTML>
