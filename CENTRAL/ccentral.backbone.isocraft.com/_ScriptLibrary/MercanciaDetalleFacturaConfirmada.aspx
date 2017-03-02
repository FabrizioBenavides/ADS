<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaDetalleFacturaConfirmada.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaDetalleFacturaConfirmada" codePage="28592"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaDetalleFacturaConfirmada.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página que muestra el detalle de las facturas ya confirmadas.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Jorge Tamez Sánchez
    ' Version       : 1.0
    ' Last Modified : Jueves, Octubre 23, 2003
    ' Modificacion  : Septiembre 20, 2004 ; Griselda Gómez Ponce
    '     Se incluye en la página la fecha y hora de la confirmación.    
	
'                 20 de Marzo 2007             Actualizacion por SAP
'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
'====================================================================
%>
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--

// Numero de Companía (despliegue basico)
function strCompaniaSucursal() {
	document.write(<%=intCompaniaId%> + " - " + <%=intSucursalId%>);
	return(true);
}

// Nombre de la sucursal (despliegue basico)
function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}

// Fecha actual (despliegue basico)
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}

// Nombre de Usuario (despliegue basico)
function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
	return(true);
}


// Razon social de Proveedor
function strProveedorRazonSocial() {
	document.write("<%=strProveedorRazonSocial%>");
	return(true);
}

// Número de pedido de la factura
function intFacturaElectronicaPedido(){
 document.write("<%=intFacturaElectronicaPedido%>");
 return(true); 
}

// Número de factura electronica
function strFacturaElectronicaNumero(){
 document.write("<%=strFacturaElectronicaNumero%>");
 return(true); 
}

// Fecha de factura
function dtmFacturaElectronicaEmisionDocumento(){
 document.write("<%=dtmFacturaElectronicaEmisionDocumento%>");
 return(true);
}

// Importe total facturado
function fltFacturaElectronicaImporteTotal(){
 document.write("<%=fltFacturaElectronicaImporteTotal%>");
 return(true);
}

// Importe de IVA
function fltFacturaElectronicaImporteIVA(){
 document.write("<%=fltFacturaElectronicaImporteIVA%>");
 return(true);
}

// Importe del IVA del descuento
function fltFacturaElectronicaImporteIVADescuento(){
 document.write("<%=fltFacturaElectronicaImporteIVADescuento%>");
 return(true);
}

// Importe del IVA después del descuento
function fltFacturaElectronicaImporteDescuentoDespuesIVA(){
 document.write("<%=fltFacturaElectronicaImporteDescuentoDespuesIVA%>");
 return(true);
}

// Importe neto de la factura
function fltFacturaElectronicaImporteNeto(){
 document.write("<%=fltFacturaElectronicaImporteNeto%>");
}

// Folio de Factura
function intEstadoFacturaElectronicaFolio(){
 document.write("<%=intEstadoFacturaElectronicaFolio%>");
 return(true);
}

//Fecha y hora de la Captura de la confirmacion
function dtmEstadoFacturaElectronicaUltimaModificacion(){
 document.write("<%=dtmEstadoFacturaElectronicaUltimaModificacion%>");
 return(true);
}

// Mandamos imprimir el documento
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
  return(true);
}

// Realizamos otra consulta
function cmdOtraConsulta_onclick() {
 window.location = "MercanciaConsultarFacturaRemision.aspx"
}

// Revisamos otra factura
function cmdOtraFactura_onclick() {
 history.go(-1)
}

// Load de la pagina
function window_onload() {
 MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
 document.forms[0].action = "<%=strFormAction%>";
   
}

// Submit
function frmMercanciaDetalleFacturaElectronica_onsubmit() {
  valida=true;
	return(valida);
}



//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaDetalleFacturaElectronica"
			onSubmit="return frmMercanciaDetalleFacturaElectronica_onsubmit()">
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
                en: <a href="Mercancia.aspx" class="txdmigaja">Mercancía</a>: 
                <a href="MercanciaEntradas.aspx" class="txdmigaja">Entradas</a>: 
                <a href="MercanciaEntradasRecepcion.aspx" class="txdmigaja">Recepción 
                de mercancía</a>: <a href="MercanciaConsultarFacturaRemision.aspx" class="txdmigaja">Archivo 
                de facturas:</a> Detalle de factura confirmada</span></div></td>
            <td width="182" class="tdfechahora"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="583" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Detalle de Factura Confirmada</span><span class="txcontenido"></span> 
                      <script language="JavaScript">crearDatosSucursal()</script>
                      <br>
                    <div id="ToPrintHtmContenido"> 
                      <table width="583" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                          <td width="125" class="tdtittablas">Proveedor:</td>
                          <td width="458" class="tdconttablas"><span class="txconttablasrojo"> 
                            <script language="javascript">strProveedorRazonSocial()</script>
                            </span></td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">No. de Pedido:</td>
                          <td class="tdconttablas"><span class="txconttablasrojo"> 
                            <script language="javascript">intFacturaElectronicaPedido()</script>
                            </span></td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">No. de Factura:</td>
                          <td class="tdconttablas"><script language="javascript">strFacturaElectronicaNumero()</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Fecha de Factura:</td>
                          <td class="tdconttablas"><script language="javascript">dtmFacturaElectronicaEmisionDocumento()</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Total Facturado:</td>
                          <td class="tdconttablas"><script language="JavaScript">fltFacturaElectronicaImporteTotal()</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">IVA Facturado:</td>
                          <td class="tdconttablas"><script language="JavaScript">fltFacturaElectronicaImporteIVA()</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">IVA Descuento:</td>
                          <td class="tdconttablas"><script language="JavaScript">fltFacturaElectronicaImporteIVADescuento()</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Desc. despues IVA:</td>
                          <td class="tdconttablas"><script language="JavaScript">fltFacturaElectronicaImporteDescuentoDespuesIVA()</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Neto Facturado:</td>
                          <td class="tdconttablas"><script language="JavaScript">fltFacturaElectronicaImporteNeto()</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Folio:</td>
                          <td class="tdconttablas"><script language="JavaScript">intEstadoFacturaElectronicaFolio()</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Fecha y hora Confirmacion:</td>
                          <td class="tdconttablas"><script language="JavaScript">dtmEstadoFacturaElectronicaUltimaModificacion()</script> 
                          </td>
                        </tr>
                      </table>
                      <div id="divFirmasHTML" style="DISPLAY:none"> <br>
                        <br>
                        <br>
                        <br>
                        <br>
                        <br>
                        <table>
                          <tr> 
                            <td>_________________</td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td>_________________</td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td>_________________</td>
                          </tr>
                          <tr> 
                            <td class="tdtittablas" align="center">Nombre y Firma</td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td class="tdtittablas" align="center">Nombre y Firma</td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td class="tdtittablas" align="center">Nombre y Firma</td>
                          </tr>
                          <tr> 
                            <td class="tdtittablas" align="center">Chofer Repartidor</td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td class="tdtittablas" align="center">Capturó Documento</td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td class="tdtittablas" align="center">Gte. Sucursal</td>
                          </tr>
                        </table>
                        <br>
                        <table>
                          <tr> 
                            <td class="tdtittablas"> * Este documento no será 
                              válido sin el nombre y firma de autorización del 
                              representante del proveedor.* </td>
                          </tr>
                        </table>
                      </div>
                    </div>
                    <!-- termina el ToPrintHtmContenido  -->
                    <br> <input name="cmdOtraFactura" type="button" class="boton" id="cmdOtraFactura" value="Otra Factura"
														onClick="return cmdOtraFactura_onclick()"> 
                    &nbsp;&nbsp; <input name="cmdOtraConsulta" type="button" class="boton" id="cmdOtraConsulta" value="Otra Consulta"
														onClick="return cmdOtraConsulta_onclick()"> 
                    &nbsp;&nbsp; <input name="cmdImprimir" type="button" class="boton" id="cmdImprimir" value="Imprimir documento"
														onClick="return cmdImprimir_onclick()"> 
                    <br> <br> <P></P></td>
                </tr>
              </table></td>
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
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</HTML>
