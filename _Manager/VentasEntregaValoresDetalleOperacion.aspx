<%@ Page CodeBehind="VentasEntregaValoresDetalleOperacion.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasEntregaValoresDetalleOperacion" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
     document.forms[0].action = "<%= strFormAction %>";
     <%= strJavascriptWindowOnLoadCommands %>
}

function ObtenerNombreDireccion(){
	document.write("<%= strDireccionOperativaNombre %>");
}


function ObtenerNombreZona(){
	document.write("<%= strZonaOperativaNombre%>");
}

function ObtenerNombreSucursal(){
	document.write("<%= strSucursalNombre%>");
}

function ObtenerFecha(){
	document.write("<%= strFecha%>");
}

function ObtenerHora(){
	document.write("<%= strHora%>");
}

function ObtenerNombreOperacion(){

	document.write("<%= strOperacionEntregaValoresNombre%>");
	
}

function ObtenerNombreConcepto(){
	document.write("<%= strConceptoEntregaValoresNombre%>");
}

function ObtenerFolioRemision(){
	document.write("<%= strEntregaValoresFolioRemision%>");
}


function ObtenerNombreResponsable(){
	document.write("<%= strEmpleadoNombre%>");
}

function ObtenerFolioBolsa(){
	document.write("<%= strEntregaValoresFolioBolsa%>");
}

function ObtenerNombreRecolectora(){
	document.write("<%= strEmpresaValoresNombre%>");
}

function ObtenerImporteMonedaNacional(){
	document.write("<%= strEntregaValoresImporteMonedaNacional%>");
}

function ObtenerImporteDolares(){
	document.write("<%= strEntregaValoresImporteDolares%>");
}

function ObtenerImporteDocumentos(){
	document.write("<%= strEntregaValoresImporteDocumentos %>");
}

function cmdRegresar_onclick() {
  window.location.href = "VentasEntregaValoresDetalleSucursal.aspx?strCmd=Ver&intCompaniaId=<%= intCompaniaId%>&intSucursalId=<%= intSucursalId%>&cboOperacion=<%= intcboOperacion%>&cboRecolectora=<%= intcboRecolectora%>&txtFechaInicial=<%= strFechaInicial%>&txtFechaFinal=<%= strFechaFinal%>&cboDireccion=<%= intcboDireccion%>&cboZona=<%= intcboZona%>&intNavegadorRegistrosPagina=<%= intNavegadorRegistrosPaginaDetalleSucursal%>&intNavegadorRegistrosPaginaEntregaValores=<%= intNavegadorRegistrosPaginaEntregaValores%>";
}

function cmdImprimir_onclick() {
  window.print();
}

function cmdExportar_onclick() {
  var strFormAction = document.forms[0].action;  
  document.forms[0].action += "?strCmd=Exportar&intCompaniaId=<%= intCompaniaId%>&intSucursalId=<%= intSucursalId%>&cboOperacion=<%= intcboOperacion%>&cboRecolectora=<%= intcboRecolectora%>&txtFechaInicial=<%= strFechaInicial%>&txtFechaFinal=<%= strFechaFinal%>&cboDireccion=<%= intcboDireccion%>&cboZona=<%= intcboZona%>&intNavegadorRegistrosPaginaDetalleSucursal=<%= intNavegadorRegistrosPaginaDetalleSucursal%>&intEmpresaValoresId=<%= intEmpresaValoresId %>&intOperacionEntregaValoresId=<%= intOperacionEntregaValoresId %>&intConceptoEntregaValoresId=<%= intConceptoEntregaValoresId %>&intEmpleadoId=<%= intEmpleadoId %>&intEntregaValoresId=<%= intEntregaValoresId %>";
  document.forms[0].submit();  
  document.forms[0].action = strFormAction;
}

//-->
		</script>
</HEAD>
<body language="javascript" onload="return window_onload()"> 
<form action="about:blank" method="post"> 
  <table width="780" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td><script language="JavaScript">crearTablaHeader()</script></td> 
    </tr> 
  </table> 
  <table width="780" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td width="10">&nbsp;</td> 
      <td width="770" class="tdtab">Está en : <a href="VentasHome.aspx">Ventas</a> : <a href="VentasEntregaValores.aspx"> Entrega de valores </a>: <a href="VentasEntregaValoresDetalleSucursal.aspx">Detalle de sucursal</a> : Detalle de operación </td> 
    </tr> 
  </table> 
  <table width="780" border="0" cellpadding="0" cellspacing="0"> 
    <tr> 
      <td class="tdgeneralcontent"><h1>Detalle de operación </h1> 
        <h2>Datos de la operación </h2> 
        <table width="100%" border="0" cellspacing="0" cellpadding="0"> 
          <tr> 
            <td width="9%" class="tdtexttablebold">Dirección:</td> 
            <td width="31%" class="tdcontentableblue"><script language="javascript">ObtenerNombreDireccion()</script> </td> 
            <td width="11%" class="tdtexttablebold">Zona: </td> 
            <td width="22%" class="tdcontentableblue"><script language="javascript">ObtenerNombreZona()</script> </td> 
            <td width="9%" class="tdtexttablebold">Sucursal:</td> 
            <td width="18%" class="tdcontentableblue"><script language="javascript">ObtenerNombreSucursal()</script> </td> 
          </tr> 
        </table> 
        <hr> 
        <table width="90%" border="0" cellspacing="0" cellpadding="0"> 
          <tr> 
            <td width="16%" class="tdtexttablebold">Fecha:</td> 
            <td width="29%" class="tdcontentableblue"><script language="javascript">ObtenerFecha()</script> </td> 
            <td width="12%" class="tdtexttablebold">Hora: </td> 
            <td width="43%" class="tdcontentableblue"><script language="javascript">ObtenerHora()</script> </td> 
          </tr> 
          <tr> 
            <td class="tdtexttablebold">Operación:</td> 
            <td class="tdcontentableblue"><script language="javascript">ObtenerNombreOperacion()</script></td> 
            <td class="tdtexttablebold">Concepto:</td> 
            <td class="tdcontentableblue"><script language="javascript">ObtenerNombreConcepto()</script></td> 
          </tr> 
          <tr> 
            <td class="tdtexttablebold">Folio de remisión:</td> 
            <td class="tdcontentableblue"><script language="javascript">ObtenerFolioRemision()</script></td> 
            <td class="tdtexttablebold">Responsable:</td> 
            <td class="tdcontentableblue"><script language="javascript">ObtenerNombreResponsable()</script> </td> 
          </tr> 
          <tr> 
            <td class="tdtexttablebold">Folio de bolsa: </td> 
            <td class="tdcontentableblue"><script language="javascript">ObtenerFolioBolsa()</script></td> 
            <td class="tdtexttablebold">Recolectora:</td> 
            <td class="tdcontentableblue"><script language="javascript">ObtenerNombreRecolectora()</script></td> 
          </tr> 
          <tr> 
            <td class="tdtexttablebold">Importe m.n.:</td> 
            <td class="tdcontentableblue">
              <script language="javascript">ObtenerImporteMonedaNacional()</script> </td> 
            <td class="tdtexttablebold">Importe Dlls.: </td> 
            <td class="tdcontentableblue">
              <script language="javascript">ObtenerImporteDolares()</script></td> 
          </tr> 
          <tr> 
            <td class="tdtexttablebold">Importe doc.:</td> 
            <td class="tdcontentableblue">
              <script language="javascript">ObtenerImporteDocumentos()</script></td> 
            <td class="tdtexttablebold">&nbsp;</td> 
            <td class="tdcontentableblue"></td> 
          </tr> 
          <tr> 
            <td height="10" colspan="4"><img src="images/pixel.gif" width="1" height="10"></td> 
          </tr> 
        </table> 
        <br> 
        <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" onclick="return cmdRegresar_onclick()"
							value="Regresar"> 
&nbsp; 
        <input name="cmdImprimir" type="button" class="button" id="cmdImprimir" value="Imprimir" onclick="return cmdImprimir_onclick()"> 
&nbsp; 
        <input name="cmdExportar" type="button" class="button" id="cmdExportar" value="Exportar" onclick="return cmdExportar_onclick()"></td> 
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
</HTML>
