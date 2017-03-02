<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaDetalleReciboTransferencia.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaDetalleReciboTransferencias" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : MercanciaDetalleReciboTransferencia.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página Detalle de recibos archivados.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Carlos E. Pérez Torres
    ' Version       : 1.0
    ' Last Modified : October 14, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%><html>
<head>
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

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}


function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

// Escribimos las funciones para llenar los datos de la página.
function intFolio() {
	document.write("<%=intFolio%>");
	return(true);
}

function strNumeroOrden() {
	document.write("<%=strNumeroOrden%>");
	return(true);
}

function strFechaOrden() {
	document.write("<%=strFechaOrden%>");
	return(true);
}

function strFechaConfirmacion() {
	document.write("<%=strFechaConfirmacion%>");
	return(true);
}

function strMotivoTransferencia() {
	document.write("<%=strMotivoTransferencia%>");
	return(true);
}

function intMotivoTransferencia() {
	document.write("<%=intMotivoTransferencia%>");
	return(true);
}

function intCompaniaSucursalEnvia() {
	document.write("<%=intCompaniaSucursalEnvia%>");
	return(true);
}

function strCompaniaSucursalEnvia(){
    document.write("<%=strCompaniaSucursalEnvia%>");
    return(true);
}

function btnSalir_onclick() {
	document.location.href = 'MercanciaArchivoDeRecibos.aspx';
	return(true);
}

function window_onload() {
		MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
		document.forms[0].action = "<%=strFormAction%>"; 
         return(true);
}

function cmdImprimir_onclick() {
  document.ifrPageToPrint.document.all.divContenido.innerHTML = document.all.divImpresionHTML.innerHTML;        
  document.ifrPageToPrint.focus();
  window.print(); 
  return(true);
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0"  onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaDetalleReciboTransferencias">
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
            <td width="10" bgcolor="#FFFFFF"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><span class="txdmigaja">Est&aacute; 
              en : </span><a href="Mercancia.aspx" class="txdmigaja">Mercanc&iacute;a</a><span class="txdmigaja"> 
              : <a href="MercanciaEntradas.aspx" class="txdmigaja">Entradas</a></span><span class="txdmigaja"> 
              : </span><span class="txdmigaja"></span><span class="txdmigaja"><a href="MercanciaEntradasTransferencia.aspx" class="txdmigaja">Transferencias 
              de otra sucursal</a></span><span class="txdmigaja"> : </span><span class="txdmigaja"></span><span class="txdmigaja"></span><span class="txdmigaja"></span><span class="txdmigaja"></span><span class="txdmigaja"></span><span class="txdmigaja">Detalle 
              de recibo archivado</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Detalle 
              de recibo archivado</span><span class="txcontenido">La siguiente 
              tabla contiene los detalles del recibo hist&oacute;rico que seleccion&oacute;.</span> 
              <div id="divImpresionHTML"> 
                <script language="JavaScript">crearDatosSucursal()</script>
                <br>
                <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle"> 
                Datos de la transferencia recibida</span> 
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr> 
                    <td width="163" class="tdtittablas">No. de folio:</td>
                    <td width="410" class="tdconttablas"><script language="javascript">intFolio()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">No. de orden:</td>
                    <td class="tdconttablas"><script language="javascript">strNumeroOrden()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Fecha de la orden:</td>
                    <td class="tdconttablas"><script language="javascript">strFechaOrden()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Fecha de confirmaci&oacute;n:</td>
                    <td valign="top" class="tdconttablas"><script language="javascript">strFechaConfirmacion()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Motivo de transferencia:</td>
                    <td class="tdconttablas"><script language="javascript">intMotivoTransferencia()</script> 
                      <script language="javascript">strMotivoTransferencia()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Sucursal que env&iacute;a:</td>
                    <td class="tdconttablas"><script language="javascript">intCompaniaSucursalEnvia()</script> 
                      <script language="javascript">strCompaniaSucursalEnvia()</script> 
                    </td>
                  </tr>
                </table>
                <br>
                <script language="javascript">strRecordBrowserHTML()</script>
                <br>
              </div>
              <input name="btnSalir" type="button" class="boton" value="Regresar" onClick="return btnSalir_onclick()"> 
              &nbsp;&nbsp; <input name="btnImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()"> 
              &nbsp;&nbsp; <input name="btnRegresar" type="button" class="boton" value="Otro transferencia" onClick="history.go(-1)"> 
              <br> <br> </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
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
<iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0"></iframe>
</body>
</html>
