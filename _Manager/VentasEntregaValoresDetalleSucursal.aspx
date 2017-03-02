<%@ Page CodeBehind="VentasEntregaValoresDetalleSucursal.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasEntregaValoresDetalleSucursal" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
    intSucursalId = <%= intSucursalId %>; 
    <%= strJavascriptWindowOnLoadCommands %>
    
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

function ObtenerFechaInicial(){
	document.write("<%= strFechaInicial %>");
}

function ObtenerFechaFinal(){
	document.write("<%= strFechaFinal %>");
}

function strTotalEnvioMonedaNacional(){
	document.write("<%= strTotalEnvioMonedaNacional %>");
}

function strTotalEnvioDolares(){
	document.write("<%= strTotalEnvioDolares %>");
}

function strTotalEnvioDocumentos(){
	document.write("<%= strTotalEnvioDocumentos %>");
}

function strTotalRecepcionMonedaNacional(){
	document.write("<%= strTotalRecepcionMonedaNacional %>");
}

function strTotalRecepcionDolares(){
	document.write("<%= strTotalRecepcionDolares %>");
}

function strTotalRecepcionDocumentos(){
	document.write("<%= strTotalRecepcionDocumentos %>");
}

function cmdImprimir_onclick() {
  window.print();
}

function cmdExportar_onclick() {

  window.location.href="VentasEntregaValoresDetalleSucursal.aspx?strCmd=Exportar&intCompaniaId=<%= intCompaniaId%>&intSucursalId=<%= intSucursalId%>&txtFechaInicial=<%= strFechaInicial%>&txtFechaFinal=<%= strFechaFinal%>&cboOperacion=<%= intcboOperacion%>&cboRecolectora=<%= intcboRecolectora%>&cboDireccion=<%= intcboDireccion%>&cboZona=<%= intcboZona%>&intNavegadorRegistrosPaginaEntregaValores=<%= intNavegadorRegistrosPaginaEntregaValores%>"; 
  
}

function cmdRegresar_onclick() {
  location.href = 'VentasEntregaValores.aspx?intCompaniaId=<%= intCompaniaId%>&intSucursalId=<%= intSucursalId%>&txtFechaInicial=<%= strFechaInicial%>&txtFechaFinal=<%= strFechaFinal%>&cboOperacion=<%= intcboOperacion%>&cboRecolectora=<%= intcboRecolectora%>&cboDireccion=<%= intcboDireccion%>&cboZona=<%= intcboZona%>&intNavegadorRegistrosPagina=<%= intNavegadorRegistrosPaginaEntregaValores%>';  
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
      <td width="770" class="tdtab">Está en : <a href="VentasHome.aspx">Ventas</a> : <a href="VentasEntregaValores.aspx"> Entrega de Valores </a>: Detalle de sucursal</td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Detalle de sucursal</h1>
        <p>En esta parte usted puede consultar el detalle de las entregas de valores a nivel sucursal.</p>
        <h2>Datos de la sucursal</h2>
        <table width="60%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="13%" class="tdtexttablebold">Dirección: </td>
            <td width="87%" class="tdcontentableblue"><script language="javascript">ObtenerNombreDireccion()</script>
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Zona: </td>
            <td class="tdcontentableblue"><script language="javascript">ObtenerNombreZona()</script>
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Sucursal: </td>
            <td class="tdcontentableblue"><script language="javascript">ObtenerNombreSucursal()</script>
            </td>
          </tr>
          <tr>
            <td colspan="2" class="tdtexttablebold">Importes consolidados del &nbsp;
              <script language="javascript">ObtenerFechaInicial()</script>
              &nbsp; al &nbsp;
              <script language="javascript">ObtenerFechaFinal()</script>
              </td>
          </tr>
          <tr>
            <td colspan="2" class="tdtexttablebold"><table width="100%" >
                <tr>
                  <td class="tdtexttablebold">&nbsp;</td>
                  <td class="tdtexttablebold">Env&iacute;o M.N:</td>
                  <td class="tdcontentableblue"><script language="JavaScript" type="text/JavaScript">strTotalEnvioMonedaNacional()</script>&nbsp;</td>
                  <td class="tdtexttablebold">Env&iacute;o Dls.:</td>
                  <td class="tdcontentableblue"><script language="JavaScript" type="text/JavaScript">strTotalEnvioDolares()</script>&nbsp;</td>
                  <td class="tdtexttablebold">Env&iacute;o Docs.:</td>
                  <td class="tdcontentableblue"><script language="JavaScript" type="text/JavaScript">strTotalEnvioDocumentos()</script>&nbsp;</td>
                </tr>
                <tr>
                  <td class="tdtexttablebold">&nbsp;</td>
                  <td class="tdtexttablebold">Recepci&oacute;n M.N:</td>
                  <td class="tdcontentableblue"><script language="JavaScript" type="text/JavaScript">strTotalRecepcionMonedaNacional()</script>&nbsp;</td>
                  <td class="tdtexttablebold">Recepci&oacute;n Dls.:</td>
                  <td class="tdcontentableblue"><script language="JavaScript" type="text/JavaScript">strTotalRecepcionDolares()</script>&nbsp;</td>
                  <td class="tdtexttablebold">Recepci&oacute;n Docs.:</td>
                  <td class="tdcontentableblue"><script language="JavaScript" type="text/JavaScript">strTotalRecepcionDocumentos()</script>&nbsp;</td>
                </tr>
              </table></td>
          </tr>
          <tr>
            <td height="10" colspan="2"><img src="images/pixel.gif" width="1" height="10"></td>
          </tr>
        </table>
        <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" onClick="return cmdRegresar_onclick()"
							value="Regresar">
        <br>
        <br>
        <%= strObtenerEntregaValores() %> <br>
        <input name="cmdImprimir" type="button" class="button" id="cmdImprimir" value="Imprimir"
							language="javascript" onClick="return cmdImprimir_onclick()">
&nbsp;
        <input name="cmdExportar" type="button" class="button" id="cmdExportar" value="Exportar"
							language="javascript" onClick="return cmdExportar_onclick()">
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
