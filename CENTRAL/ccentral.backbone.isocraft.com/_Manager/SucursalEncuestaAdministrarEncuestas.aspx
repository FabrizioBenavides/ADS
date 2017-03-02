<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEncuestaAdministrarEncuestas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEncuestaAdministrarEncuestas"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
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

//-->
	</script>
</HEAD>
<body language="javascript" onload="return window_onload()">
<form method="post" action="about:blank" name="frmPage">
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
      <td class="tdgeneralcontent"><h1>Administrar Encuestas</h1>
        <p>Aquí podrá dar de alta nuevas encuestas. Editar o asignar a sucursales
          la encuesta seleccionada.</p>
        <%= strGetRecordBrowserHTML() %> <br>
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
</body>
