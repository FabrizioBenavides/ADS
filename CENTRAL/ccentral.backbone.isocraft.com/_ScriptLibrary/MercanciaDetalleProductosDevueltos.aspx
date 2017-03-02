<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaDetalleProductosDevueltos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaDetalleProductosDevueltos" codePage="28592"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : MercanciaDetalleProductosDevueltos.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página detalle de productos devueltos.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Carlos E. Pérez Torres
    ' Version       : 1.0
    ' Last Modified : October 14, 2003	
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

function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

// Escribimos las funciones para llenar los datos de la página.
function intProveedor() {
	document.write("<%=intProveedor%>");
	return(true);
}

function strFechaDevolucion() {
	document.write("<%=strFechaDevolucion%>");
	return(true);
}

function intFolio() {
	document.write("<%=intFolio%>");
	return(true);
}

function strNombreProveedor() {
	document.write("<%=strNombreProveedor%>");
	return(true);
}

function intDevolucionNumeroDocumento() {
	document.write("<%=intDevolucionNumeroDocumento%>");
	return(true);
}
function strDevolucionNumeroFactura() {
	document.write("<%=strDevolucionNumeroFactura%>");
	return(true);
}
function strDepartamentoNombre() {
	document.write("<%=strDepartamentoNombre%>");
	return(true);
}
function strMotivoDevolucion() {
	document.write("<%=strMotivoDevolucion%>");
	return(true);
}

function btnSalir_onclick() {
	document.location = 'MercanciaSalidas.aspx';
	return(true);
}

function cmdImprimir_onclick() {
	if (window.print) {
        document.ifrPageToPrint.document.all.ToPrintTxtMigaja.innerHTML=document.all.ToPrintTxtMigaja.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtFecha.innerHTML=document.all.ToPrintTxtFecha.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtSucursal.innerHTML=document.all.ToPrintTxtSucursal.innerText;
        document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML=document.all.ToPrintHtmContenido.innerHTML;
        
        //Mostrar Tabla de firmas
        document.ifrPageToPrint.document.all.divFirmasHTML.style.display='';
        
        document.ifrPageToPrint.focus();
        window.print();        
    } else {
        alert("Tu navegador no soporta la función: Print.")
    }
}

//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaDetalleProductosDevueltos">
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
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en :</span><span class="txdmigaja"> <a href="Mercancia.aspx" class="txdmigaja">Mercancía</a> 
                : <a href="MercanciaSalidas.aspx" class="txdmigaja">Salidas</a> 
                : <a href="MercanciaArchivoProductosDevueltos.aspx" class="txdmigaja">Devolución 
                de mercancía</a> : </span><span class="txdmigaja">Detalle de productos 
                devueltos</span></div></td>
            <td width="182" class="tdfechahora"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Detalle 
              de productos devueltos</span><span class="txcontenido">El reporte 
              de devolución de productos que seleccionó tiene los siguientes datos:</span> 
              <script language="JavaScript">crearDatosSucursal()</script> <br> 
              <div id="ToPrintHtmContenido"> 
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr> 
                    <td width="128" class="tdtittablas">Folio de Devolución:</td>
                    <td width="455" class="tdconttablas"><script language="javascript">intFolio()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Fecha de devolución:</td>
                    <td class="tdconttablas"><script language="javascript">strFechaDevolucion()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Motivo:</td>
                    <td class="tdconttablas"><script language="javascript">strMotivoDevolucion()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Proveedor:</td>
                    <td class="tdconttablas"><script language="javascript">strNombreProveedor()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Factura:</td>
                    <td class="tdconttablas"><script language="javascript">strDevolucionNumeroFactura()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">No. de Documento:</td>
                    <td class="tdconttablas"><script language="javascript">intDevolucionNumeroDocumento()</script> 
                    </td>
                  </tr>
                </table>
                <br>
                <script language="javascript">strRecordBrowserHTML()</script>
                <div id="divFirmasHTML" style="DISPLAY:none"> <br>
                  <br>
                  <br>
                  <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <tr> 
                      <td>_________________</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td>_________________</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td>_________________</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td>_________________</td>
                    </tr>
                    <tr> 
                      <td class="tdtittablas" align="center">Nombre y Firma</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Nombre y Firma</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Nombre y Firma</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Nombre y Firma</td>
                    </tr>
                    <tr> 
                      <td class="tdtittablas" align="center">Chofer Repartidor</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Rpte. de Ventas</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Capturó Devolución</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Gte. Sucursal</td>
                    </tr>
                  </table>
                  <br>
                  <table>
                    <tr> 
                      <td class="tdtittablas"> * Este documento no será válido 
                        sin el nombre y firma de autorización del representante 
                        del proveedor.* </td>
                    </tr>
                  </table>
                </div>
              </div>
              <!-- cerramos el div ToPrintHtmContenido -->
              <br> <input name="btnSalir" type="button" class="boton" value="Regresar" onClick=" return btnSalir_onclick()"> 
              &nbsp;&nbsp;&nbsp; <input name="btnRegresar" type="button" class="boton" value="Ver otro reporte" onClick="return history.go(-1)"> 
              &nbsp;&nbsp;&nbsp; <input name="btnImrpimir" type="button" class="boton" value="Imprimir este reporte" onClick="return cmdImprimir_onclick()"> 
              <br> <br> </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
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
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</HTML>
