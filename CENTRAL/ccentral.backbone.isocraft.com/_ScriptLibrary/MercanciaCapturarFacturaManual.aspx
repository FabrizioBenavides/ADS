<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaCapturarFacturaManual.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaCapturarFacturaManual" codePage="28592"%>
<title>Sistema Administrador de Sucursal</title>
<%
    '===================================================================
    ' Page          : MercanciaCapturarFacturaManual.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página donde capturan las Facturas manualmente
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Jorge Tamez Sánchez
    ' Version       : 1.0
    ' Last Modified : Viernes, Marzo 12, 2004
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%><html>
<head>
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/tools.js"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">

<!--
var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";
function window_onload() {
   MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
   document.forms[0].action = "<%=strFormAction%>";
   
   document.forms[0].elements['txtProveedor'].focus();
            
   return(true);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}

function frmMercanciaCapturarFacturaManual_onsubmit() {
   var regreso = true;
      	  
   return (regreso);
}

// Se valida la informacion y se almacena los datos de la Factura
function cmdCapturar_onclick() {
  var valida
  
  valida = true;
 

 // Validamos el número de proveedor
 if (Trim(document.forms[0].elements["txtProveedor"].value)==" "){
  document.forms[0].elements["txtProveedor"].value="";
 }
 
  if (Trim(document.forms[0].elements["txtProveedor"].value)==""){
   alert("Capturar el número de proveedor");
   return(false); 
 }
 
 if (isNaN(Trim(document.forms[0].elements["txtProveedor"].value))){
   alert("Capturar solamente números en el número de proveedor.");
   return(false); 
 }
 
 
 // Validamos las Fechas de Emision y Recepcion de Factura

  // Fecha de Emision
  if (valida){ valida=blnValidarCampo(document.forms[0].elements("dtmEmisionFactura"),true,"Fecha de Emisión",cintTipoCampoFecha,10,10,"");}
     if (!valida){
		return(valida);
	 }
 
  // Fecha de Recepcion
  if (valida){ valida=blnValidarCampo(document.forms[0].elements("dtmRecepcionFactura"),true,"Fecha de Recepción",cintTipoCampoFecha,10,10,"");}
     if (!valida){
		return(valida);
	 }


	// Fecha de Emision
	strDiaFechaEmision = document.forms[0].elements["dtmEmisionFactura"].value;
	strDiaFechaEmision = strDiaFechaEmision.substring(0,2);
	 
	strMesFechaEmision = document.forms[0].elements["dtmEmisionFactura"].value;
	strMesFechaEmision = strMesFechaEmision.substring(3,5);
	 
	strAnioFechaEmision = document.forms[0].elements["dtmEmisionFactura"].value;
	strAnioFechaEmision = strAnioFechaEmision.substring(6,10);
	 
	strFechaEmision = strMesFechaEmision + "/" + strDiaFechaEmision + "/" + strAnioFechaEmision;

    
	// Fecha de Recepcion
	strDiaFechaRecepcion = document.forms[0].elements["dtmRecepcionFactura"].value;
	strDiaFechaRecepcion = strDiaFechaRecepcion.substring(0,2);
	 
	strMesFechaRecepcion = document.forms[0].elements["dtmRecepcionFactura"].value;
	strMesFechaRecepcion = strMesFechaRecepcion.substring(3,5);
	 
	strAnioFechaRecepcion = document.forms[0].elements["dtmRecepcionFactura"].value;
	strAnioFechaRecepcion = strAnioFechaRecepcion.substring(6,10);
	 
	strFechaRecepcion = strMesFechaRecepcion + "/" + strDiaFechaRecepcion + "/" + strAnioFechaRecepcion;
	 	 
    // Fecha actual
    strFechaActual = "<%=dtmFechaActual%>";
    strFechaTope = "<%=dtmValidaFechaFactura%>";
    
    
	// La fecha de Emision de factura no puede ser mayor que la fecha actual
	if (Date.parse(strFechaEmision) > Date.parse(strFechaActual)){  
   	   alert("La fecha de emisión de la factura no puede ser mayor que la fecha actual.");
	   document.forms[0].elements["dtmEmisionFactura"].focus(); 
	   return(false);
	}
	
	// La fecha de recepcion no puede ser mayor que la fecha actual
	if (Date.parse(strFechaRecepcion) > Date.parse(strFechaActual)){  
	    alert("La fecha de recepción no puede ser mayor que la fecha actual.");
	   document.forms[0].elements["dtmRecepcionFactura"].focus();	    
	    return(false);
	}  	

	// La fecha de factura debe ser menor o igual que la fecha de recepcion
	if (Date.parse(strFechaEmision) > Date.parse(strFechaRecepcion)){
	   alert("La fecha de emisión de la factura no puede ser mayor que la fecha de recepcion."); 
       document.forms[0].elements["dtmEmisionFactura"].focus(); 	   
	   return(false);
	}
	
	// La fecha de emisión no debe de ser más antigua de dos meses
	if (Date.parse(strFechaEmision) < Date.parse(strFechaTope)){
	    alert("La fecha de emisión de la factura no puede ser más antigua de dos meses.");
        document.forms[0].elements["dtmEmisionFactura"].focus(); 	    
	    return(false);
	}
	
	// Se valida que se haya capturado algo en el campo de la factura
	if (Trim(document.forms[0].elements['txtNumeroFactura'].value) == "" || Trim(document.forms[0].elements['txtNumeroFactura'].value) == " "){
	   alert("Favor de capturar el Número de Factura");
       document.forms[0].elements["txtNumeroFactura"].focus();
	   return(false); 
	}
	
	// Validamos que no contenga caracteres invalidos	
  if (valida){ valida=blnValidarCampo(document.forms[0].elements['txtNumeroFactura'],true,"Número de Factura",cintTipoCampoCadenaDefinida,20,1,"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789");}
     if (!valida){
		return(valida);
	 }


   strNetoFacturado = document.forms[0].elements['txtMontoNetoFactura'].value;
   strTotalFacturado = document.forms[0].elements['txtTotalFacturado'].value;   
   strIVAFacturado = document.forms[0].elements['txtIVAFacturado'].value;
   strIVADescuento = document.forms[0].elements['txtIVADescuento'].value;
   strDescuentoDespuesIVA = document.forms[0].elements['txtDescuentoDespuesIVA'].value;
   
   /////////////////////////////////////////////////////////  
   // Validamos que se hayan capturado solamente importes
   /////////////////////////////////////////////////////////
   
   
    // Neto Facturado
	if (parseFloat(strNetoFacturado) <= 0){
	   alert("Favor de capturar el Monto Neto de la Factura");
	   document.forms[0].elements['txtMontoNetoFactura'].focus();	   
	   return(false);  
	}
	
	if (!(/^((\d+(\.\d*)?)|((\d*\.)?\d+))$/.test(strNetoFacturado)) ) { 
	   alert ("Capture un valor valido en el campo: Neto facturado");
	   return(false);
	}
	
	 // Total Facturado
	if (parseFloat(strTotalFacturado) <= 0){
	   alert("Favor de capturar el Total de la Factura");
	   document.forms[0].elements['txtTotalFacturado'].focus();	   
	   return(false);  
	}
	
	if (!(/^((\d+(\.\d*)?)|((\d*\.)?\d+))$/.test(strTotalFacturado)) ) { 
	   alert ("Capture un valor valido en el campo: Total facturado");
	   document.forms[0].elements['txtTotalFacturado'].focus();	   
	   return(false);
	}	
	
	// Iva Facturado
	if (!(/^((\d+(\.\d*)?)|((\d*\.)?\d+))$/.test(strIVAFacturado)) ) { 
	   alert ("Capture un valor valido en el campo: Iva facturado");
	   return(false);
	}

	
	// Iva Descuento
	if (!(/^((\d+(\.\d*)?)|((\d*\.)?\d+))$/.test(strIVADescuento)) ) { 
	   alert ("Capture un valor valido en el campo: Iva Descuento");
	   return(false);
	}
	
	
	// Descuento despues de Iva
	if (!(/^((\d+(\.\d*)?)|((\d*\.)?\d+))$/.test(strDescuentoDespuesIVA)) ) { 
	   alert ("Capture un valor valido en el campo: Descuento despues de iva");
	   return(false);
	}	
 
    // Validamos que el Iva Facturado sea menor que el Total Facturado
    if (parseFloat(strTotalFacturado) <= parseFloat(strIVAFacturado)){
	  alert("El iva Facturado debe ser menor que el total facturado.");      
	  return(false);
    }
    
    // Validamos que el Iva descuento sea menor que el Total Facturado
    if (parseFloat(strTotalFacturado) <= parseFloat(strIVADescuento)){
	  alert("El iva Descuento debe ser menor que el total facturado.");
	  return(false);
    }
    
    // Validamos que el descuento despues de iva sea menor que el Total Facturado
    if (parseFloat(strTotalFacturado) <= parseFloat(strDescuentoDespuesIVA)){
	  alert("El descuento despues de iva debe ser menor que el total facturado.");
	  return(false);
    }    
  
    // Validamos que el Neto Facturado = (Total Facturado + Iva Facturado - Iva Descuento - Descuento despues de iva)   
       
    fltDiferencia = (parseFloat(strNetoFacturado) - (parseFloat(strTotalFacturado) + parseFloat(strIVAFacturado) - parseFloat(strIVADescuento) - parseFloat(strDescuentoDespuesIVA)))
        
    fltDiferencia = Math.abs(fltDiferencia);
             
	if (parseFloat(fltDiferencia) > 0.01){
	  alert("El Neto facturado debe ser igual al (Total Facturado + Iva Fact - Iva Desc - Desc despues Iva). Existe una diferencia de: " + Math.round(fltDiferencia*100)/100);
	  return(false);
	}
	
	
     document.forms[0].action = "<%=strFormAction%>?strCmd=ValidaDocumento";
     document.forms[0].target="ifrOculto";
	 document.forms[0].submit();
     document.forms[0].target='';                  


}

// Número de proveedor
function cmdNumeroProveedor_onClick(){
   if (document.forms[0].elements["txtProveedor"].readOnly==true){
       return(true);
   }

	if (document.forms[0].elements['txtProveedor'].value!="")
	    {
         if (!isNaN(document.forms[0].elements['txtProveedor'].value))
             {
			   if (document.forms[0].elements['txtProveedor'].value != '0')
			      {	      
		             document.forms[0].action = "<%=strFormAction%>?strCmd=BuscaProveedor";
					 document.forms[0].target="ifrOculto";
				     document.forms[0].submit();
                     document.forms[0].target='';                  
			       return(true);
     		      }
			    else 
			        { 			        
			       //el valor es cero				       		     
				   document.forms[0].elements['txtProveedor'].value='';
				   document.forms[0].elements['txtRazonSocialProveedor'].value='';

			       strParametros = ''		
			       strParametros = strParametros + 'strProveedor=txtProveedor&';
			       strParametros = strParametros + 'strNombreProveedorId=txtRazonSocialProveedor';
				   strParametros = strParametros + '&strRFC=txtRFC';
				   strParametros = strParametros + '&strRFCOculto=txtRFCOculto';	   
				   
				   cmdBuscarProveedor_onClick('PopProveedor.aspx?'+strParametros,500,540);
			       }
			    return(false);
	         }
	      else{ 
		   	  document.forms[0].elements['txtRazonSocialProveedor'].value='';
			       strParametros = ''		
			       strParametros = strParametros + 'strProveedor=txtProveedor&';
			       strParametros = strParametros + 'strNombreProveedorId=txtRazonSocialProveedor';
				   strParametros = strParametros + '&strRFC=txtRFC';
				   strParametros = strParametros + '&strRFCOculto=txtRFCOculto';				   
				   				   
 			       cmdBuscarProveedor_onClick('PopProveedor.aspx?'+strParametros,500,540);
	          }
	       }
	else{
		alert("Teclear Número de proveedor o descripción");
		document.forms[0].elements['txtProveedor'].focus();
        return(false);
	    }	    	    
}

// Buscar por Número de proveedor
function cmdBuscarProveedor_onClick(url, width, height) {
         var strTipoProveedor
         
          strTipoProveedor = "ProveedorMayorista";
                      
          url=url+'&strProveedorId='+document.forms[0].elements['txtProveedor'].value + '&strTipoProveedorNombreId=' + strTipoProveedor;
          return Pop(url, width, height);
}

// Mandar ventana de consulta
function Pop(url, width, height) {
    var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	return(false);
}

 // Despliega los valores de proveedor
function fncActualizaProveedor(intEncontrado,intProveedorId,strRazonSocialProveedor){

 // Se encontro el proveedor 
 if (intEncontrado==1){
	 document.forms[0].elements['txtProveedor'].value=intProveedorId;
	 document.forms[0].elements['txtRazonSocialProveedor'].value=strRazonSocialProveedor;
 }
 else{
	 document.forms[0].elements['txtProveedor'].value='';
	 document.forms[0].elements['txtRazonSocialProveedor'].value='';
 	 document.forms[0].elements['txtProveedor'].focus();
     alert('Número de proveedor incorrecto');     
 }   
}

function fncValidaDocumento(intEncontrado,intResultado,strTipoDocumento,strEstadoDocumento){
  
  if (intEncontrado==1){
    // Se encontró un documento electronico con los mismos datos
    alert("Ya existe una " + strTipoDocumento + " en estado: " + strEstadoDocumento+ " .");
  }
  else{
     // No se encontró la factura/remision electronica se dara de alta la Manual
     if (intResultado!=0){ 
        alert("El documento fue dado de alta con el folio No. " + intResultado);
        document.all.divFolioConfirmacion.innerHTML = "La operación quedo confirmada con el folio: "+intResultado;
        document.forms[0].elements["cmdImprimir"].click();
        window.location = "<%=strFormAction%>";
     }
     else{
        alert("Ocurrió algún fallo al momento de dar de alta la factura manual.");
     }     
  }
    return(true);
}

function txtTotalFacturado_onfocus() {
 document.forms[0].elements['txtTotalFacturado'].select();
}

function txtMontoNetoFactura_onfocus() {
 document.forms[0].elements['txtMontoNetoFactura'].select();
}


function txtIVAFacturado_onfocus() {
document.forms[0].elements['txtIVAFacturado'].select();
}

function txtIVADescuento_onfocus() {
document.forms[0].elements['txtIVADescuento'].select();
}

function txtDescuentoDespuesIVA_onfocus() {
document.forms[0].elements['txtDescuentoDespuesIVA'].select();
}

function cmdImprimir_onclick() {
	if (window.print) {
        document.ifrPageToPrint.document.all.ToPrintTxtMigaja.innerHTML=document.all.ToPrintTxtMigaja.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtFecha.innerHTML=document.all.ToPrintTxtFecha.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtSucursal.innerHTML=document.all.ToPrintTxtSucursal.innerText;
        document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML=document.all.ToPrintHtmContenido.innerHTML;
        
        //Ocultar Validar Datos en el frame oculto
        document.ifrPageToPrint.document.all.cmdCapturar.style.display='none';

		document.ifrPageToPrint.document.all.imgLupa.style.display='none'
  	    document.ifrPageToPrint.document.all.Cal1.style.display='none'
  	    document.ifrPageToPrint.document.all.Cal2.style.display='none'		
		document.ifrPageToPrint.document.all.txtProveedor.className = 'campotablaresultado';
		document.ifrPageToPrint.document.all.txtRazonSocialProveedor.className = 'campotablaresultado';				
		document.ifrPageToPrint.document.all.dtmEmisionFactura.className = 'campotablaresultado';
		document.ifrPageToPrint.document.all.dtmRecepcionFactura.className = 'campotablaresultado';
		document.ifrPageToPrint.document.all.txtNumeroFactura.className = 'campotablaresultado';
		document.ifrPageToPrint.document.all.txtTotalFacturado.className = 'campotablaresultado';
		document.ifrPageToPrint.document.all.txtIVAFacturado.className = 'campotablaresultado';
		document.ifrPageToPrint.document.all.txtIVADescuento.className = 'campotablaresultado';
		document.ifrPageToPrint.document.all.txtDescuentoDespuesIVA.className = 'campotablaresultado';
		document.ifrPageToPrint.document.all.txtMontoNetoFactura.className = 'campotablaresultado';		
										
        
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
</head>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaCapturarFacturaManual" onSubmit="return frmMercanciaCapturarFacturaManual_onsubmit()" action="about:blank" method="post">
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
            <td width="10" bgcolor="#ffffff"> <img height="8" src="../static/images/pixel.gif" width="10"></td>
            <td class="tdmigaja" width="583"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en : </span><a class="txdmigaja"href="Mercancia.aspx">Mercancía</a><span class="txdmigaja"> 
                : <a class="txdmigaja" href="javascript:strRedireccionaPOSAdmin('MercanciaEntradas.aspx');">Entradas</a> 
                : </span><span class="txdmigaja"><a class="txdmigaja" href="javascript:strRedireccionaPOSAdmin('MercanciaEntradasRecepcion.aspx');">Recepcion 
                de Mercancía</a> : </span><span class="txdmigaja"></span> <span class="txdmigaja">Captura 
                de factura manual</span></div></td>
            <td class="tdfechahora" width="182"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td class="tdtablacont" valign="top" width="583"> <span class="txtitulo">Captura 
              de factura manual.</span><br> <script language="JavaScript">crearDatosSucursal()</script> 
              <span class="txsubtitulo"> <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle"> 
              Identificar documento</span> <div id="ToPrintHtmContenido"> 
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                  <tr> 
                    <td class="tdconttablas" colspan="4" nowrap> <div id="divFolioConfirmacion"></div></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Tipo de Documento:</td>
                    <td class="tdtittablas"><input type="radio" name="rdoTipoDocumento" id="rdoTipoDocumento0" value="0" checked>
                      Factura&nbsp;&nbsp;
                      <input type="radio" name="rdoTipoDocumento" id="rdoTipoDocumento1" value="1">
                      Remisión
                    <td width="10" class="tdconttablas"></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Proveedor:</td>
                    <td class="tdconttablas"><span class="txconttablasrojo"> 
                      <input type="text" name="txtProveedor" class="campotabla" maxlength="10" size="10" onKeyDown="if(event.keyCode==13){document.forms[0].elements['imgLupa'].click(); document.forms[0].elements['dtmEmisionFactura'].focus();} if(event.keyCode==9){document.forms[0].elements['imgLupa'].click();document.forms[0].elements['dtmEmisionFactura'].focus();}" autocomplete="off">
                      <a href="javascript:;" id="objLupa" onClick="return cmdNumeroProveedor_onClick();"><img src="../static/images/icono_lupa.gif" width="17" height="17" align="absMiddle" border="0" id="imgLupa"></a>&nbsp;&nbsp; 
                      <input type="text" name="txtRazonSocialProveedor" class="campotablaresultado" maxlength="40" size="40" readonly >
                      </span></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Fecha de Emisión:</td>
                    <td class="tdconttablas" valign="top"><input class="campotabla" type="text" maxlength="10" size="12" name="dtmEmisionFactura"> 
                      <a href="javascript:objdtmEmisionFactura.popup();"><img onClick="return blnValidarCampo(document.forms('frmMercanciaCapturarFacturaManual').elements('dtmEmisionFactura'),false,'Fecha',cintTipoCampoFecha,10,10,'');" height="13" alt="Clic para seleccionar la fecha." src="../static/images/icono_calendario.gif" width="20" border="0" id="Cal1"></a></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Fecha Recepcion:</td>
                    <td class="tdpadleft5"><input class="campotabla" type="text" maxlength="10" size="12" name="dtmRecepcionFactura"> 
                      <a href="javascript:objdtmRecepcionFactura.popup();"><img onClick="return blnValidarCampo(document.forms('frmMercanciaCapturarFacturaManual').elements('dtmRecepcionFactura'),false,'Fecha',cintTipoCampoFecha,10,10,'');" height="13" alt="Clic para seleccionar la fecha." src="../static/images/icono_calendario.gif" width="20" border="0" id="Cal2"></a></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" width="136">No. de factura:</td>
                    <td class="tdpadleft5"><input class="campotabla" type="text" maxlength="20" size="24" name="txtNumeroFactura"  value="" onKeyDown="if(event.keyCode==13){document.forms[0].elements['txtTotalFacturado'].focus();}" autocomplete="off"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Total facturado:</td>
                    <td class="tdpadleft5"><input class="campotablahabilitadoderecha" type="text" size="24" name="txtTotalFacturado" value="0" redonly="true" onKeyDown="if(event.keyCode==13){document.forms[0].elements['txtIVAFacturado'].focus();}" autocomplete="off" onFocus="return txtTotalFacturado_onfocus()"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" width="136">IVA facturado:</td>
                    <td class="tdconttablas" width="437"><input class="campotablahabilitadoderecha" type="text" size="24" value="0" name="txtIVAFacturado" redonly="true" onKeyDown="if(event.keyCode==13){document.forms[0].elements['txtIVADescuento'].focus();}" autocomplete="off" onFocus="return txtIVAFacturado_onfocus()"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">IVA Descuento:</td>
                    <td class="tdconttablas"><input class="campotablahabilitadoderecha" type="text" size="24" value="0" name="txtIVADescuento" redonly="true" onKeyDown="if(event.keyCode==13){document.forms[0].elements['txtDescuentoDespuesIVA'].focus();}" autocomplete="off" onFocus="return txtIVADescuento_onfocus()"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Desc despues del IVA:</td>
                    <td class="tdconttablas" valign="top"><input class="campotablahabilitadoderecha" type="text" size="24" value="0" name="txtDescuentoDespuesIVA" redonly="true" onKeyDown="if(event.keyCode==13){document.forms[0].elements['txtMontoNetoFactura'].focus();}" autocomplete="off" onFocus="return txtDescuentoDespuesIVA_onfocus()"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Neto facturado:</td>
                    <td class="tdconttablas" valign="top"><input class="campotablahabilitadoderecha" type="text" maxlength="20" size="24" name="txtMontoNetoFactura" value="0" onKeyDown="if(event.keyCode==13){document.forms[0].elements['cmdCapturar'].focus();}" autocomplete="off" onFocus="return txtMontoNetoFactura_onfocus()"></td>
                  </tr>
                </table>
                <div id="divFirmasHTML" style="DISPLAY:none"><br>
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
                <br>
                <input class="boton" type="button" value="Capturar Factura" name="cmdCapturar" onClick="return cmdCapturar_onclick()">
                &nbsp;&nbsp; 
                <input class="boton" type="button" value="Imprimir" name="cmdImprimir" style="DISPLAY:none" onClick="return cmdImprimir_onclick()">
                <br>
              </div>
              <!-- CERRAMOS div id="ToPrintHtmContenido" -->
            </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"><script language="javascript">strGeneraTablaAyuda('');</script></td>
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
	var objdtmEmisionFactura = new calendar1(document.forms['frmMercanciaCapturarFacturaManual'].elements['dtmEmisionFactura']);
	var objdtmRecepcionFactura = new calendar1(document.forms['frmMercanciaCapturarFacturaManual'].elements['dtmRecepcionFactura']);
	//-->
  </script>
</form>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
<iframe name="ifrOculto" width="0" height="0"></iframe>
</body>
</html>
