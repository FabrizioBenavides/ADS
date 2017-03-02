<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConfirmacionFactura.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaConfirmacionFactura" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaConfirmacionFactura.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página donde confirma las Facturaes
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Jueves, Octubre 23, 2003
    ' Modificacion  : Septiembre 20, 2004 ; Griselda Gómez Ponce
    '   Se imprime en la página la fecha y hora de la confirmación.
	'                 20 de Marzo 2007             Actualizacion por SAP
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
    
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/tools.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--

function window_onload() {
   MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
   document.forms[0].action = "<%=strFormAction%>";
   var strMensaje = "<%=strMensaje%>";
   var strConfirmada = "<%=strConfirmada%>";
   
   document.forms[0].elements['dtmRecepcionFactura'].value = "<%=dtmRecepcionFacturaCapturada%>";
   document.forms[0].elements['txtNumeroFactura'].value = "<%=strNumeroFacturaCapturada%>";
   document.forms[0].elements['dtmEmisionFactura'].value = "<%=dtmEmisionFacturaCapturada%>";
   document.forms[0].elements['txtMontoNetoFactura'].value = "<%=dblMontoNetoCapturado%>";
      
   if (strMensaje.length > 0) {
      alert(strMensaje);
   }
   
   if (strConfirmada.length > 0) { //Operacion Confirmada con exito
		document.forms[0].elements['cmdConfirmar'].disabled=true;
		document.forms[0].elements['dtmRecepcionFactura'].readOnly = true;
		document.forms[0].elements['txtNumeroFactura'].readOnly = true;
		document.forms[0].elements['dtmEmisionFactura'].readOnly = true;
		document.forms[0].elements['txtMontoNetoFactura'].readOnly = true;
		strConfirmacion = '<%=intConfirmacion%>';
		strFechaHora = '<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>';
		document.all.divFolioConfirmacion.innerHTML = 'La operación quedo confirmada con el folio: '+strConfirmacion + '  con fecha: '+strFechaHora;
		//Mandar Imprimir
		cmdValidar_onclick();
		cmdImprimir_onclick();
   }
   
   return(true);
}

function strCompaniaSucursal() {
	document.write(<%=intCompaniaId%> + " - " + <%=intSucursalId%>);
	return(true);
}
function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
	return(true);
}
function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}

function intProveedorId() {
   document.write("<%=intProveedorId%>");
   return(true);
}
function strProveedorRazonSocial() {
   document.write ("<%=strProveedorRazonSocial%>");
}
function strPedido() {
  document.write ("<%=intFacturaElectronicaPedido%>");
}

function frmMercanciaConfirmacionFactura_onsubmit() {
   var regreso = true;
      	
   if (regreso) {
       if (document.forms[0].elements['dtmRecepcionFactura'].value == ""){
           alert("Capturar la Fecha de Recepción de la Factura");
           document.forms[0].elements['dtmRecepcionFactura'].focus();
           regreso=false;
       }
   }
      
   if (regreso) {
       if (document.forms[0].elements['txtNumeroFactura'].value == "") {
           alert("Capturar la Factura a Confirmar");
           document.forms[0].elements['txtNumeroFactura'].focus();
           regreso=false;
       }
   }
   
   if (regreso) {
       if (document.forms[0].elements['dtmEmisionFactura'].value == ""){
	       alert("Capturar la Fecha Emisión de la Factura");
	       document.forms[0].elements['dtmEmisionFactura'].focus();
	       regreso=false;
       }
   }
   
   if (regreso) {
       if (document.forms[0].elements['txtMontoNetoFactura'].value == ""){
	       alert("Capturar el Neto Facturado");
	       document.forms[0].elements['txtMontoNetoFactura'].focus();
	       regreso=false;
       }
   }
      	
   if (regreso) {
       regreso = blnValidarCampo(document.forms[0].elements['dtmRecepcionFactura'],true,'Fecha Recepción de la Factura',cintTipoCampoFecha,10,10,'');
   }
   
   if (regreso){
       regreso = blnValidarCampo(document.forms[0].elements['dtmEmisionFactura'],true,'Fecha Emisión de la Factura',cintTipoCampoFecha,10,10,'');
   }
   
   if (regreso){
       regreso = blnValidarCampo(document.forms[0].elements['txtMontoNetoFactura'],true,'Monto Neto Facturado',cintTipoCampoReal,20,0,'');
   }
       
   if (regreso){
	   var strFacturaElectronicaNumero = "<%=strFacturaElectronicaNumero%>";
       var dtmFacturaElectronicaEmision = "<%=dtmFacturaElectronicaEmision%>";  
       var fltFacturaElectronicaNeto = <%=fltFacturaElectronicaImporteNeto%>;
                 
       var strFacturaNumero  = document.forms[0].elements['txtNumeroFactura'].value;
       var dtmFacturaEmision = document.forms[0].elements['dtmEmisionFactura'].value.substr(3,2)+"/"+document.forms[0].elements['dtmEmisionFactura'].value.substr(0,2)+"/"+document.forms[0].elements['dtmEmisionFactura'].value.substr(6,4);
       var fltFacturaNeto    = document.forms[0].elements['txtMontoNetoFactura'].value;
       
       var diferencia = Math.abs(fltFacturaElectronicaNeto-fltFacturaNeto);

	   if ( strFacturaNumero == strFacturaElectronicaNumero && dtmFacturaEmision == dtmFacturaElectronicaEmision && diferencia <= 1) {
	       regreso=true;
	   }
	   else{
	       alert("Datos no coinciden con Factura a Confirmar");
	       regreso=false;	       
       }
   }
   
   return (regreso);
}

function cmdValidar_onclick() {	
   var regreso = true;
   	
   if (regreso) {
       if (document.forms[0].elements['dtmRecepcionFactura'].value == ""){
	       alert("Capturar la Fecha de Recepción de la Factura");
	       regreso=false;
	   }
   }
   
   if (regreso) {   	
       if (document.forms[0].elements['txtNumeroFactura'].value=="") {
           alert("Capturar la Factura a Confirmar");
	       regreso=false;
	   }
   }
   
   if (regreso) {
	   if (document.forms[0].elements['dtmEmisionFactura'].value == ""){
	       alert("Capturar la Fecha Emisión de la Factura");
	       regreso=false;
	   }
	}
	
	if (regreso) {
       if (document.forms[0].elements['txtMontoNetoFactura'].value == ""){
	       alert("Capturar el Neto Facturado");
	       regreso=false;
       }
    }
	
	if (regreso) {	
	    regreso=blnValidarCampo(document.forms[0].elements['dtmRecepcionFactura'],true,'Fecha Recepción de la Factura',cintTipoCampoFecha,10,10,'');
	}
		
    if (regreso){
       regreso=blnValidarCampo(document.forms[0].elements['dtmEmisionFactura'],true,'Fecha Emisión de la Factura',cintTipoCampoFecha,10,10,'');
    }
    
    if (regreso){
       regreso = blnValidarCampo(document.forms[0].elements['txtMontoNetoFactura'],true,'Monto Neto Facturado',cintTipoCampoReal,20,0,'');
    }
    
   if (regreso){
	   var strFacturaElectronicaNumero = "<%=strFacturaElectronicaNumero%>";
       var dtmFacturaElectronicaEmision = "<%=dtmFacturaElectronicaEmision%>";  
       var fltFacturaElectronicaNeto = <%=fltFacturaElectronicaImporteNeto%>;
                 
       var strFacturaNumero  = document.forms[0].elements['txtNumeroFactura'].value;
       var dtmFacturaEmision = document.forms[0].elements['dtmEmisionFactura'].value.substr(3,2)+"/"+document.forms[0].elements['dtmEmisionFactura'].value.substr(0,2)+"/"+document.forms[0].elements['dtmEmisionFactura'].value.substr(6,4);
       var fltFacturaNeto    = document.forms[0].elements['txtMontoNetoFactura'].value;
       
       var diferencia = Math.abs(fltFacturaElectronicaNeto-fltFacturaNeto);
       
	   if ( strFacturaNumero == strFacturaElectronicaNumero && dtmFacturaEmision == dtmFacturaElectronicaEmision && diferencia <= 1) {
	       document.forms[0].elements['txtValidacion'].value = "DATOS VALIDOS";	
	       document.forms[0].elements['txtTotalFacturado'].value = <%=fltFacturaElectronicaImporteTotal%>;
	       document.forms[0].elements['txtIVAFacturado'].value = <%=fltFacturaElectronicaImporteIVA%>;
	       document.forms[0].elements['txtIVADescuento'].value = <%=fltFacturaElectronicaImporteIVADescuento%>;
	       document.forms[0].elements['txtDescuentoDespuesIVA'].value = <%=fltFacturaElectronicaImporteDescuentoDespuesIVA%>;
	   }
	   else{
	       document.forms[0].elements['txtValidacion'].value = "ERROR EN DATOS";	
	       document.forms[0].elements['txtTotalFacturado'].value ="";
	       document.forms[0].elements['txtIVAFacturado'].value ="";
	       document.forms[0].elements['txtIVADescuento'].value ="";
	       document.forms[0].elements['txtDescuentoDespuesIVA'].value ="";
       }
   }
   return (regreso);		
}


function cmdRegresar_onclick() {
window.location="MercanciaFacturasporConfirmar.aspx?intProveedorId="+ <%=intProveedorId%>;
}

function cmdImprimir_onclick() {
	if (window.print) {
        document.ifrPageToPrint.document.all.ToPrintTxtMigaja.innerHTML=document.all.ToPrintTxtMigaja.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtFecha.innerHTML=document.all.ToPrintTxtFecha.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtSucursal.innerHTML=document.all.ToPrintTxtSucursal.innerText;
        document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML=document.all.ToPrintHtmContenido.innerHTML;
        
        //Ocultar Validar Datos en el frame oculto
        document.ifrPageToPrint.document.all.cmdValidar.style.display='none';
        
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
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaConfirmacionFactura" onSubmit="return frmMercanciaConfirmacionFactura_onsubmit()"
			action="about:blank" method="post">
  <table width="850" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="34" width="100%"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td width="100%"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgcolor="#ffffff"> <img height="8" src="../static/images/pixel.gif" width="10"></td>
            <td class="tdmigaja" width="700"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en: <a class="txdmigaja" href="Mercancia.aspx">Mercancía</a>: 
                <a class="txdmigaja" href="MercanciaEntradas.aspx">Entradas</a>: 
                <a href="MercanciaEntradasRecepcion.aspx" class="txdmigaja">Recepción 
                de mercancía</a>: <a class="txdmigaja" href="MercanciaConfirmarFacturaElectronica.aspx">Confirmar 
                factura electrónica de mayoristas</a>: Solicitar confirmación</span></div></td>
            <td class="tdfechahora" width="182"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td class="tdtablacont" valign="top" width="700"> <span class="txtitulo">Solicitar 
              confirmación de factura</span><span class="txcontenido">Para confirmar, 
              capture número, fecha e importe neto de la factura, y luego oprima 
              el botón validar.</span><br> <span class="txsubtitulo"> <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle"> 
              Identificar documento</span> <script language="JavaScript">crearDatosSucursal()</script> 
              <div id="ToPrintHtmContenido"> 
                <table cellspacing="0" cellpadding="0" width="583" border="0">
                  <tr> 
                    <td class="tdconttablas" colspan="4" nowrap> <div id="divFolioConfirmacion"></div></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Proveedor:</td>
                    <td class="tdconttablas"> <span class="txconttablasrojo"> 
                      <script language="JavaScript">strProveedorRazonSocial()</script>
                      </span></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Pedido:</td>
                    <td class="tdconttablas" valign="top"> <script language="JavaScript">strPedido()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" width="163">Fecha de recepción</td>
                    <td class="tdpadleft5"> <input class="campotabla" type="text" maxlength="10" size="10" name="dtmRecepcionFactura"> 
                      <a href="javascript:objdtmRecepcionFactura.popup();"><img onClick="return blnValidarCampo(document.forms('frmMercanciaConfirmacionFactura').elements('dtmRecepcionFactura'),false,'Fecha',cintTipoCampoFecha,10,10,'');"
															height="13" alt="Clic para seleccionar la fecha." src="../static/images/icono_calendario.gif" width="20" border="0"></a> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">No. de factura:</td>
                    <td class="tdpadleft5"> <input class="campotabla" type="text" maxlength="20" size="30" name="txtNumeroFactura"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Fecha de factura:</td>
                    <td class="tdpadleft5"> <input class="campotabla" type="text" maxlength="10" size="10" name="dtmEmisionFactura"> 
                      <a href="javascript:objdtmEmisionFactura.popup();"><img onClick="return blnValidarCampo(document.forms('frmMercanciaConfirmacionFactura').elements('dtmEmisionFactura'),false,'Fecha',cintTipoCampoFecha,10,10,'');"
															height="13" alt="Clic para seleccionar la fecha." src="../static/images/icono_calendario.gif" width="20" border="0"></a> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" height="40">Neto facturado:</td>
                    <td class="tdpadleft5"> <input class="campotabla" type="text" maxlength="20" size="20" name="txtMontoNetoFactura"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" width="163">Total facturado:</td>
                    <td class="tdconttablas" width="410"> <input class="campotablaresultado" type="text" size="20" name="txtTotalFacturado" redonly="true"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">IVA facturado:</td>
                    <td class="tdconttablas"> <input class="campotablaresultado" type="text" size="20" name="txtIVAFacturado" redonly="true"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">IVA Descuento:</td>
                    <td class="tdconttablas" valign="top"> <input class="campotablaresultado" type="text" size="20" name="txtIVADescuento" redonly="true"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Descuento despues del IVA:</td>
                    <td class="tdconttablas" valign="top"> <input class="campotablaresultado" type="text" size="20" name="txtDescuentoDespuesIVA"
														redonly="true"> </td>
                  </tr>
                  <tr> 
                    <td height="10"> <input class="boton" onClick="return cmdValidar_onclick()" type="button" value="Validar datos"
														name="cmdValidar" id="cmdValidar"> 
                    </td>
                    <td class="tdconttablasrojo"> <input class="campotablaresultado" type="text" size="20" name="txtValidacion" redonly="true"> 
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
                      <td class="tdtittablas"> * Este documento no será válido 
                        sin el nombre y firma de autorización del representante 
                        del proveedor.* </td>
                    </tr>
                  </table>
                </div>
              </div>
              <!-- CERRAMOS div id="ToPrintHtmContenido" -->
              <br> <span class="txsubtitulo"> <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Procesar 
              documento</span> <span class="txcontenido">Si no hubo diferencias 
              en el envío, oprima “Confirmar factura”. En caso contrario, oprima 
              “Capturar excepciones” para registrar las cantidades recibidas.</span> 
              <br> <input class="boton" onClick="return cmdRegresar_onclick()" type="button" value="Otra factura"
										name="cmdRegresar"> &nbsp;&nbsp; <input class="boton" type="button" value="Capturar excepciones" name="cmdCaptura"> 
              &nbsp;&nbsp; <input class="boton" type="submit" value="Confirmar Factura" name="cmdConfirmar"> 
              &nbsp;&nbsp; <input class="boton" type="button" value="Imprimir" name="cmdImprimir" style="DISPLAY:none"
										onclick="return cmdImprimir_onclick()"> 
              <br> </td>
            <td class="tdcolumnader" valign="top" width="182" rowspan="2">&nbsp; </td>
          </tr>
          <tr> 
            <td class="tdbottom" colspan="2"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	var objdtmRecepcionFactura = new calendar1(document.forms['frmMercanciaConfirmacionFactura'].elements['dtmRecepcionFactura']);
	var objdtmEmisionFactura = new calendar1(document.forms['frmMercanciaConfirmacionFactura'].elements['dtmEmisionFactura']);
	//-->
			</script>
</form>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</HTML>
