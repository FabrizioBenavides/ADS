<%@ Page CodeBehind="VentasOperacionesDEXDetalleSucursal.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasOperacionesDEXDetalleSucursal" EnableSessionState="False" codePage="1252" enableViewState="False" %>
<html>
<head>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
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

function cmdRegresar_onclick() {
  window.location.href = "VentasOperacionesDEX.aspx?&cboOperacion=<%= intTipoOperacionDEXId %>&optFecha=<%= intFechaId %>&cboDireccion=<%= intDireccionOperativaId %>&cboZona=<%= intZonaOperativaId %>&intNavegadorRegistrosPagina=<%=intPagina%>";
}
function cmdImprimir_onclick() {
  window.print();
}

function cmdExportar_onclick() {
  var strFormAction = document.forms[0].action;
  //document.forms[0].target = "_ExportingReport";
  document.forms[0].action += "?strCmd=Exportar&intCompaniaId=<%=intCompaniaId%>&intSucursalId=<%=intSucursalId%>&cboOperacion=<%=intTipoOperacionDEXId%>&optFecha=<%=intFechaId%>"
  document.forms[0].submit();
  //document.forms[0].target = "_self";
  document.forms[0].action = strFormAction;
}

function ObtenerNombreDireccion(){
	document.write("<%= strDireccionOperativaNombre %>");
}

function ObtenerNombreZona(){
	document.write("<%= strZonaOperativaNombre%>");
}

function ObtenerNombreSucursal(){
	document.write("<%= strSucursalNombre %>");
}

//-->
</script>
</head>
<body language="javascript" onLoad="return window_onload()"> 
<form name="frmMain" action="about:blank" method="post">
  <table width="780" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td><script language="JavaScript">crearTablaHeader()</script></td> 
    </tr> 
  </table> 
  <table width="780" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td width="10">&nbsp;</td> 
      <td width="770" class="tdtab">Está en : <a href="VentasHome.aspx">Ventas</a> : <a href="VentasOperacionesDEX.aspx"> Operaciones DEX </a>: Detalle de sucursal</td> 
    </tr> 
  </table> 
  <table width="780" border="0" cellpadding="0" cellspacing="0"> 
    <tr> 
      <td class="tdgeneralcontent"><h1>Detalle de sucursal</h1> 
        <p>En esta parte usted puede consultar el detalle de las operaciones de envíos, pagos y devoluciones a nivel sucursal.</p> 
        <h2>Datos de la sucursal</h2> 
        <table width="60%" border="0" cellspacing="0" cellpadding="0"> 
          <tr>
			<td width="13%" class="tdtexttablebold">Dirección:
			</td>
			<td colspan="3" class="tdcontentableblue"><script language="javascript">ObtenerNombreDireccion()</script>
			</td>
		  </tr>
		  <tr>
		    <td class="tdtexttablebold">Zona:
			</td>
			<td colspan="3" class="tdcontentableblue"><script language="javascript">ObtenerNombreZona()</script>
			</td>
		  </tr>
		  <tr>
		    <td class="tdtexttablebold">Sucursal:
			</td>
			<td colspan="3" class="tdcontentableblue"><script language="javascript">ObtenerNombreSucursal()</script>
			</td>
		  </tr>
		  <tr>
			<td height="10" colspan="4"><img src="images/pixel.gif" width="1" height="10"></td>
		  </tr>
		</table> 
        <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar" language=javascript onclick="return cmdRegresar_onclick()"> 
        <br> 
        <%= strObtenerOperacionesPorSucursalElegida()  %>
		<br> 
        <br>
		<input name="cmdImprimir" type="button" class="button" id="cmdImprimir" value="Imprimir" language=javascript onclick="return cmdImprimir_onclick()">
		&nbsp;
		<input name="cmdExportar" type="button" class="button" id="cmdExportar" value="Exportar" language=javascript onclick="return cmdExportar_onclick()">
		<br>
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
