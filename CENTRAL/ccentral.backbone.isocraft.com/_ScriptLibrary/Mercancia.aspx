<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="Mercancia.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercancia" codePage="28592"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : Mercancia.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página home de mercacía.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Carlos E. Pérez Torres
    ' Version       : 1.0
    ' Last Modified : October 30, 2003
	'                 20 de Marzo 2007             Actualizacion por SAP
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
function window_onload() {
		MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
		document.forms[0].action = "<%=strFormAction%>"; 
         return(true);
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}
function btnSalir_onclick() {
	window.location = "MercanciaEntradas.aspx"
	return(true);
}
function strRemisionesHTML() {
	document.write("<%=strRemisionesHTML%>");
	return(true);
}
function strFacturasHTML() {
	document.write("<%=strFacturasHTML%>");
	return(true);
}
function strEnviosHTML() {
	document.write("<%=strEnviosHTML%>");
	return(true);
}
//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercancia">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="34" width="100%"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td width="100%"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><span class="txdmigaja">Está en :</span><span class="txdmigaja"> 
              Mercancía</span></td>
            <td width="187" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" class="tdtablacont"><span class="txtitulo">Mercancía</span><span class="txcontenido">Para 
              seguir el proceso de confirmación, elija una remisión de la lista 
              y haga clic en su número.<br>
              <br>
              </span> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Remisiones 
                    pendientes</span></td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                </tr>
                <tr> 
                  <td width="50%" valign="top"> <script language="javascript">strRemisionesHTML()</script> 
                  </td>
                  <td width="11" valign="top">&nbsp;</td>
                  <td width="50%" valign="top">&nbsp;</td>
                </tr>
                <tr> 
                  <td valign="top">&nbsp;</td>
                  <td valign="top">&nbsp;</td>
                  <td valign="top">&nbsp;</td>
                </tr>
                <tr> 
                  <td valign="top"><a href="MercanciaConfirmarRemisionElectronica.aspx" class="txliganormal">Ir 
                    a página de remisiones por confirmar</a></td>
                  <td valign="top">&nbsp;</td>
                  <td valign="top">&nbsp;</td>
                </tr>
              </table>
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td> <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Facturas 
                    pendientes</span> </td>
                  <td>&nbsp;</td>
                  <td> <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Envíos 
                    pendientes</span> </td>
                </tr>
                <tr> 
                  <td width="50%" valign="top"> <script language="javascript">strFacturasHTML()</script> 
                  </td>
                  <td width="11" valign="top">&nbsp;</td>
                  <td width="50%" valign="top"> 
                    <!--script language="javascript">strEnviosHTML()</script-->
                    <a href="CCRedirectorPOSAdmin.aspx?strPageName=MercanciaProcesarEnviosAutomaticos.aspx"
													class="txliganormal">Ir página 
                    de envíos por confirmar</a> </td>
                </tr>
                <tr> 
                  <td valign="top">&nbsp;</td>
                  <td valign="top">&nbsp;</td>
                  <td valign="top">&nbsp;</td>
                </tr>
                <tr> 
                  <td valign="top"><a href="MercanciaConfirmarFacturaElectronica.aspx" class="txliganormal">Ir 
                    a página de facturas por confirmar</a></td>
                  <td valign="top">&nbsp;</td>
                  <td valign="top"></td>
                </tr>
              </table>
              <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Otras 
              operaciones</span><span class="txcontenido">Puede ejecutar aquí 
              las siguientes operaciones, también disponibles a través del menú.</span> 
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="MercanciaConfirmarFacturaElectronica.aspx" class="txliganormal">Confirmar 
                    factura electrónica</a></td>
                  <td width="11">&nbsp;</td>
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="MercanciaConsultarFacturaRemision.aspx" class="txliganormal">Consultar 
                    archivo de facturas</a></td>
                  <td width="11">&nbsp;</td>
                  <td width="190" height="29" valign="top" class="tdliganormal">&nbsp;</td>
                </tr>
                <tr> 
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="MercanciaReciboTransferencias.aspx" class="txliganormal">Procesar 
                    recibo de transferencias</a></td>
                  <td width="11">&nbsp;</td>
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="MercanciaArchivoDeRecibos.aspx" class="txliganormal">Consultar 
                    archivo de recibos</a></td>
                  <td width="11">&nbsp;</td>
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="MercanciaConsultarEntradasProducto.aspx" class="txliganormal">Consultar 
                    entradas por producto</a></td>
                </tr>
                <tr> 
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="MercanciaCapturarCompraDirecta.aspx" class="txliganormal">Capturar 
                    compra directa</a></td>
                  <td width="11">&nbsp;</td>
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="MercanciaConsultaComprasDirectas.aspx" class="txliganormal">Consultar 
                    registro de compras directas</a></td>
                  <td width="11">&nbsp;</td>
                  <td width="190" height="29" valign="top" class="tdliganormal">&nbsp;</td>
                </tr>
                <tr> 
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="CCRedirectorPOSAdmin.aspx?strPageName=MercanciaProcesarEnviosAutomaticos.aspx" class="txliganormal">Procesar 
                    envios automaticos</a></td>
                  <td width="11">&nbsp;</td>
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="CCRedirectorPOSAdmin.aspx?strPageName=MercanciaCapturarTransferenciaManual.aspx" class="txliganormal">Capturar 
                    transferencias manuales</a></td>
                  <td width="11">&nbsp;</td>
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="CCRedirectorPOSAdmin.aspx?strPageName=MercanciaConsultarArchivoDeEnvios.aspx"
													class="txliganormal">Consultar 
                    archivo de envios</a></td>
                </tr>
                <tr> 
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="CCRedirectorPOSAdmin.aspx?strPageName=MercanciaConsultarSalidasProducto.aspx" class="txliganormal">Consultar 
                    salidas por producto</a></td>
                  <td width="11">&nbsp;</td>
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="CCRedirectorPOSAdmin.aspx?strPageName=MercanciaImpresionFormatoTrasferencias.aspx" class="txliganormal">Imprimir 
                    formato para transferencias</a></td>
                  <td width="11">&nbsp;</td>
                  <td width="190" height="29" valign="top" class="tdliganormal">&nbsp;</td>
                </tr>
                <tr> 
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="MercanciaCapturarDevoluciones.aspx" class="txliganormal">Capturar 
                    productos a devolver</a></td>
                  <td width="11">&nbsp;</td>
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="MercanciaArchivoProductosDevueltos.aspx" class="txliganormal">Archivo 
                    de productos devueltos</a></td>
                  <td width="11">&nbsp;</td>
                  <td width="190" height="29" valign="top" class="tdliganormal">&nbsp;</td>
                </tr>
                <tr> 
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="MercanciaConsultarLayout.aspx" class="txliganormal">Consultar 
                    layout</a></td>
                  <td width="11">&nbsp;</td>
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="MercanciaConsultarPlanogramas.aspx" class="txliganormal">Consultar 
                    Planogramas</a></td>
                  <td width="11">&nbsp;</td>
                  <td width="190" height="29" valign="top" class="tdliganormal">&nbsp;</td>
                </tr>
                <tr> 
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="MercanciaInventariosMaximosDeProductos.aspx" class="txliganormal">Consultar 
                    maximos por producto</a></td>
                  <td width="11">&nbsp;</td>
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="MercanciaCapturarMaximoSugerido.aspx" class="txliganormal">Capturar 
                    sugerencias de maximos</a></td>
                  <td width="11">&nbsp;</td>
                  <td width="190" height="29" valign="top" class="tdliganormal"><a href="MercanciaArchivoMaximoSugerido.aspx" class="txliganormal">Archivo 
                    de sugerencias de maximos</a></td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda('');</script> 
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
			</script>
</form>
</body>
</HTML>
