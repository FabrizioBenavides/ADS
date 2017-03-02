<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaCapturarCompraDirecta.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaCapturarCompraDirecta" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaCapturarCompraDirecta.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Captura Inicio de Compras Directas
    ' Copyright     : 2008 All rights reserved.
    ' Company       : BENAVIDES
    ' Author        : J.Antonio Hernandez Dávila
    ' Version       : 1.0
    ' Last Modified : 
    ' Last Modified : Viernes, Octubre 24, 2003
    '                 Viernes, Noviembre 26, 2004 [Ajustes por Orden Sugerida]
    '                 Enero 2007, [Cambio de numero de proveedor sap]
	'                 Jueves, 14 de Febrero 2008   ORDENES ASR
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '                 16 de Marzo 2012 [JAHD]  remisiones de compra directa
    '                 18 de Septiembre 2012 [JAHD] No Captura de Costo de Articulo	
    '====================================================================	
%>
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/ToolsValRFC.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--

var strPaginaAyuda
strPaginaAyuda = "";

function LTrim(s){
	// Devuelve una cadena sin los espacios del principio
	var i=0;
	var j=0;
	var intCaracter=0;
	
	// Busca el primer caracter <> de un espacio
	for(i=0; i<=s.length-1; i++)
		if(s.substring(i,i+1) != ' '){
			j=i;
			intCaracter=1;
			break;
		}
		
		if (intCaracter==0) {
		   return "";    
		}
		else {
	       return s.substring(j, s.length);
	    }
}

function RTrim(s){
	// Quita los espacios en blanco del final de la cadena
	var j=0;
	var intCaracter=0;
	
	// Busca el último caracter <> de un espacio
	for(var i=s.length-1; i>-1; i--)
		if(s.substring(i,i+1) != ' '){		
			j=i;
			intCaracter=1;
			break;
		}
				
		if (intCaracter==0) {
		    return "";
		}
		else {
		     return s.substring(0, j+1);
		}
}

function Trim(s){
	// Quita los espacios del principio y del final
	return LTrim(RTrim(s));
}


// Funcion donde Eliminamos los guiones de alguna cadena.
function strEliminaGuiones(objCampo){
 var strInicial, strFinal, strResultado;
 
 strInicial = objCampo;
 strFinal = strInicial.split("-");

    strResultado = '';
    for (intContador = 0; intContador < strFinal.length; intContador++){
         strResultado = strResultado + strFinal[intContador];  
    }
    

 strInicial = strResultado;
 strFinal = strInicial.split(" ");

  strResultado = '';
  for (intContador = 0; intContador < strFinal.length; intContador++){
       strResultado = strResultado + Trim(strFinal[intContador]);
  }
    
 return(strResultado); 
}

// Funcion donde Eliminamos las Comas de alguna Cadena
function strEliminacommas(objcampo){ 
 while (parseInt(objcampo.search(',')) > 0){
  objcampo = objcampo.replace(',','');
  }
  
  return(objcampo);
}

// Mandar ventana de consulta
function Pop(url, width, height) {
   var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
       
   return(false);
}

// funcion que va hacia el codebehind utilizando el iframe
function fncEjecutaCodebehind(objNombreCampo,objAccion,objVerificaReadOnly){

  if (objVerificaReadOnly==true){
         if (document.forms[0].elements[objNombreCampo].readOnly==false){         
             document.forms[0].action = "<%=strFormAction%>?strCmd="+objAccion;
             document.forms[0].target="ifrOculto";
             document.forms[0].submit();
             document.forms[0].target='';
             }       
     } 
     else{
             document.forms[0].action = "<%=strFormAction%>?strCmd=" + objAccion;
             document.forms[0].target="ifrOculto";
             document.forms[0].submit();
             document.forms[0].target='';     
     }
     return(true);     
 }          

function fnUbicaCursor(objCampo){
  // Esta habilitado antes de iva
  if (document.forms[0].elements['chkAntesdeIva'].checked==true && document.forms[0].elements['chkDespuesdeIva'].checked==false){
 
       if (parseInt(objCampo) == 0 ){
          document.forms[0].elements['txtSumaProductos'].focus();
       }

       if (parseInt(objCampo) == 1 ){
          document.forms[0].elements['txtDescuentoAntesdeIva'].focus();
       }
  
       if (parseInt(objCampo) == 2 ){
          document.forms[0].elements['txtIvaFacturado'].focus(); 
       }
  }
 
 return(true);
}

// Fecha Actual (despliegue basico)
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}


// Habilita botones en inicio
function fnHabilitaBotonesInicio() {
       document.frmMercanciaCapturarCompraDirecta.txtCompraDirectaId.value = '';
	   
       document.frmMercanciaCapturarCompraDirecta.hdnProveedorId.value = '';
       document.frmMercanciaCapturarCompraDirecta.hdnProveedorNombreId.value = '';
       document.frmMercanciaCapturarCompraDirecta.txtProveedorNombreId.value = '';
	   document.frmMercanciaCapturarCompraDirecta.txtRazonSocialProveedor.value = '';

	   document.frmMercanciaCapturarCompraDirecta.hdnCapturaRemision.value = '';
	   document.frmMercanciaCapturarCompraDirecta.hdnRemisionDisponible.value = '';
       document.frmMercanciaCapturarCompraDirecta.hdnRemisionId.value = '';
       document.frmMercanciaCapturarCompraDirecta.txtRemisionFolio.value = '';
	   	   
	   document.frmMercanciaCapturarCompraDirecta.hdnSoloOrden.value = '';
	   document.frmMercanciaCapturarCompraDirecta.hdnOrdenDisponible.value = '';
       document.frmMercanciaCapturarCompraDirecta.txtFolioOrdenId.value = '';
	   
   	   document.frmMercanciaCapturarCompraDirecta.hdnCapturaCosto.value = '';
	   document.frmMercanciaCapturarCompraDirecta.hdnMargenFactura.value = '';
          
       document.frmMercanciaCapturarCompraDirecta.txtRFC.value = '';
       document.frmMercanciaCapturarCompraDirecta.txtRFCOculto.value = '';
	   	   
       document.frmMercanciaCapturarCompraDirecta.txtNumeroFacturaRuta.value = '';	   
       document.frmMercanciaCapturarCompraDirecta.txtNumeroFactura.value = '';
	   
       document.frmMercanciaCapturarCompraDirecta.txtFechaRecepcion.value = '';
       document.frmMercanciaCapturarCompraDirecta.txtFechaFactura.value = '';
	   
       document.frmMercanciaCapturarCompraDirecta.cboIvaAplicado.value = '';
       document.frmMercanciaCapturarCompraDirecta.cboDescuento.value = '';
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.value = '';
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.value = '';
    
       document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.value='';
       document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.value='';
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.value='';     
       document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.value = '';
       document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.value= '';		  
       document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.value= '';
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.value='';    
       document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.value='';
              
       // Generamos opciones de Iva aplicado
       <%=strGeneracboIvaAplicadoHTML("cboIvaAplicado")%>
       		 
      // Generamos opciones de Descuento
      <%=strGeneraDescuentoHTML("cboDescuento")%>
          
       // Deshabiliamos los checkboxs
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked=false;
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked=false;
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.disabled=true;
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.disabled=true;
       
       // Deshabilita campos de captura      
       document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.readOnly=true;
   	   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.readOnly=true
       document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.readOnly=true;
       
       document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.className="campotabladeshabilitadoderecha"
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.className="campotabladeshabilitadoderecha";
       document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.className="campotabladeshabilitadoderecha";
       document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.className="campotabladeshabilitadoderecha";
   	   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.className="campotabladeshabilitadoderecha";
       document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.className="campotabladeshabilitadoderecha";
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.className="campotabladeshabilitadoderecha";
       document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.className="campotabladeshabilitadoderecha";
           
       return(true);	
}


// Preparamos el ambiente cuando se vaya a modificar los importes
function fnHabilitaBotonesModificarImporte() {
    
   // Generamos opciones de Iva aplicado
   <%=strGeneracboIvaAplicadoHTML("cboIvaAplicado")%>
   		 		 
   // Generamos opciones de Descuento
   <%=strGeneraDescuentoHTML("cboDescuento")%>
  	
   if ("<%=Request.Form("chkAntesdeIva")%>" == "1"){             
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked = true;
   }  
   
   if ("<%=Request.Form("chkDespuesdeIva")%>" == "1"){
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked = true;
   }
   
   // Datos del Proveedor   
   document.frmMercanciaCapturarCompraDirecta.txtProveedorNombreId.readOnly=true;
   document.frmMercanciaCapturarCompraDirecta.txtRazonSocialProveedor.readOnly=true;
   document.frmMercanciaCapturarCompraDirecta.txtRFC.readOnly=true;
   
   // Datos de Factura		
   document.frmMercanciaCapturarCompraDirecta.txtNumeroFactura.readOnly=true;
   document.frmMercanciaCapturarCompraDirecta.txtNumeroFacturaRuta.readOnly=true;		
   document.frmMercanciaCapturarCompraDirecta.txtFechaRecepcion.readOnly=true;
   document.frmMercanciaCapturarCompraDirecta.txtFechaFactura.readOnly=true;
   
   // Importes
   document.forms[0].elements['txtCampoEnviado'].value = "0";
   
   // Compra con Descuento
   if ("<%=Request.Form("cboDescuento")%>" == "1") {
       // Antes y Despues de IVA
       if ((document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked==true)  && (document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked==true)){                   
                   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.readOnly=false;
				   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.readOnly=false;                   
                   document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.className="campotabladeshabilitadoderecha";
                   document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.className = "campotabladeshabilitadoderecha";
                   
                   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.focus();
       }
       // Antes de iva   
       if ((document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked==true)  && (document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked==false)){
                   
                   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.readOnly=false;
			   	   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.readOnly=false;                   
                   document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.className="campotabladeshabilitadoderecha";
                   document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.className = "campotabladeshabilitadoderecha";                            
                   document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.className = "campotabladeshabilitadoderecha";                            
                   document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.className = "campotabladeshabilitadoderecha";
                   
                   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.focus();                
       }
       // Despues de iva            
      if ((document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked==false)  && (document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked==true)){                   
                   document.forms[0].elements['txtCampoEnviado'].value = "3";                   
                   
                   document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.readOnly=false;
				   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.readOnly=false;                          
                   document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.readOnly=false;
                                                        
                   document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.className = "campotabladeshabilitadoderecha";                            
                   document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.className = "campotabladeshabilitadoderecha";                            
                   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.className="campotabladeshabilitadoderecha";
                   
                   document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.focus();
       }                                                                                                       
   } 
   
   //Compra sin descuento      
   if ("<%=Request.Form("cboDescuento")%>" == "2"){
   			       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.disabled=true;
			       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.disabled=true;			       
			       
                   document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.readOnly=false;
				   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.readOnly=false;
                   
                   document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.className = "campotabladeshabilitadoderecha";
                   document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.className = "campotabladeshabilitadoderecha";
                   document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.className = "campotabladeshabilitadoderecha";
                   document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.className = "campotabladeshabilitadoderecha";
                   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.className="campotabladeshabilitadoderecha";
   }                                                      								         				

   return(true);
}

// Preparamos el ambiente cuando se vaya a modificar datos generales
function fnHabilitaBotonesModificarDatos(){   
   
   // Generamos opciones de Iva aplicado
   <%=strGeneracboIvaAplicadoHTML("cboIvaAplicado")%>
   		 		 
   // Generamos opciones de Descuento
   <%=strGeneraDescuentoHTML("cboDescuento")%>
   
   if ("<%=Request.Form("chkAntesdeIva")%>" == "1"){             
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked = true;
   }
   if ("<%=Request.Form("chkDespuesdeIva")%>" == "1"){
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked = true;
   }
   
   document.forms[0].elements['txtCampoEnviado'].value = "0";
   
   // COMPRA CON DESCUENTO
   if ("<%=Request.Form("cboDescuento")%>" == "1"){            
        // Descuento antes y Despues de IVA
       if ((document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked==true)  && (document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked==true)){                   
                   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.readOnly=false;
				   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.readOnly=false;                   
                   document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.className="campotabladeshabilitadoderecha";
                   document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.className = "campotabladeshabilitadoderecha";
                   
                   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.focus();
       }
       
       // Descuento Antes de iva   
       if ((document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked==true)  && (document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked==false)){                   
                   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.readOnly=false;
				   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.readOnly=false;                   
                   document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.className="campotabladeshabilitadoderecha";
                   document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.className = "campotabladeshabilitadoderecha";                            
                   document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.className = "campotabladeshabilitadoderecha";                            
                   document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.className = "campotabladeshabilitadoderecha";
                   
                   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.focus();                                   
       }
       
       // Despues Despues de iva            
       if ((document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked==false)  && (document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked==true)){                  
                   document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.readOnly=false;
				   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.readOnly=false;
                   document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.readOnly=false;                          
                   document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.readOnly=false;                                                        
                   document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.className = "campotabladeshabilitadoderecha";                            
                   document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.className = "campotabladeshabilitadoderecha";                            
                   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.className="campotabladeshabilitadoderecha";
                   
                   document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.focus();
                   document.forms[0].elements['txtCampoEnviado'].value = "3"; 
       }                                                                                                       
   } 
   
   // COMPRA SIN DESCUENTO      
   if ("<%=Request.Form("cboDescuento")%>" == "2") {
  	           document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.disabled=true;
  	           document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.disabled=true;			       			       
               document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.readOnly=false;
               document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.readOnly=false;
			   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.readOnly=false;                   
               document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.className = "campotabladeshabilitadoderecha";
               document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.className = "campotabladeshabilitadoderecha";
               document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.className = "campotabladeshabilitadoderecha";
               document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.className = "campotabladeshabilitadoderecha";
               document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.className="campotabladeshabilitadoderecha";
   }
   
   return(true);
}

 
function cboDescuento_onchange() {        
   // Combo de Tipo de Descuento se Inicializan los campos al
   // cambiar el tipo de descuento
          
   // ------ Suma productos  --------------1
   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.value=0;
   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.readOnly=true;
   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.className="campotabladeshabilitadoderecha";
          
   // ------ Descuento Antes de Iva -------2
   
   document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.value=0; 
   document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.readOnly=true;
   document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.className="campotabladeshabilitadoderecha";    
   
   // ------ Total Facturado --------------3
   document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.value=0;
   document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.readOnly=true;
   document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.className="campotabladeshabilitadoderecha";
   
   // ------ Iva Facturado ----------------4   
   document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.value=0;
   document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.readOnly=true;
   document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.className="campotabladeshabilitadoderecha";
   
   // ------ IEPS  ------------------------5
   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.value =0;
   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.readOnly=true;
   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.className="campotabladeshabilitadoderecha";
   
   // ------ Iva Descuento ----------------6  
   document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.value=0;    
   document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.readOnly=true;
   document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.className="campotabladeshabilitadoderecha";
    
   // ------ Descuento despues de iva -----7
   document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.value=0; 
   document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.readOnly=true;
   document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.className="campotabladeshabilitadoderecha";
   
   // ------ Total Neto Facturado ---------8
   document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.value=0;
   document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.readOnly=true;
   document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.className="campotabladeshabilitadoderecha";
        
   // No se ha selecionado ninguna opción del descuento
   if (document.frmMercanciaCapturarCompraDirecta.cboDescuento.selectedIndex == 0) { 
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.value=0;
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.value=0;
        
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.disabled = true;
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked = false;
                
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.disabled = true;     
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked = false;       
   }
       
    // Se seleccionó la opción "Tiene descuento"    
   if (document.frmMercanciaCapturarCompraDirecta.cboDescuento.selectedIndex == 1) {
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.value=0;
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.value=0;      
               
       // Habilitamos las opciones de Descuento antes y despues de iva 
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.disabled=false;
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.disabled=false;
              
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked=false;
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked=false;
   }
         
   // Se seleccionó la opción "NO tiene descuento"
   if (document.frmMercanciaCapturarCompraDirecta.cboDescuento.selectedIndex == 2){
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.value=0;
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.value=0;
       
       // Deshabilitamos las opciones de Descuento antes y despues de iva
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.disabled= true ;
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.disabled=true ;
       
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked = false;
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked = false;
       
       // Habilitamos los Campos de Captura
       document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.readOnly =false;
       document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.className="campotablahabilitadoderecha";
       
  	   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.readOnly =false;
       document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.className="campotablahabilitadoderecha";	
       	
       document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.readOnly =false;
       document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.className="campotablahabilitadoderecha";
       
       document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.focus();
   }
   
   return(true);    
}

// Verificamos que campos aplicarán cuando se de click en checkbox Antes de iva
function chkAntesdeIva_onclick() {

   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.value=0;
   document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.value=0;
   document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.value=0;     
   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.value = 0;
   document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.value=0;		  
   document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.value=0;
   document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.value=0;    
   document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.value=0;
                
   if (document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked) { 
       // Se Marco Descuento Antes de IVA       
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.value=1;
                              
       //Habilitamos los Campos de Captura       
       document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.readOnly=false;
       document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.className="campotablahabilitadoderecha";
               
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.readOnly=false;
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.className="campotablahabilitadoderecha";
       
       document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.readOnly=false;
       document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.className="campotablahabilitadoderecha";       
        
       document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.readOnly=false;
       document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.className="campotablahabilitadoderecha";           
       	
       // Deshabilitados los Campos de Captura
       document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.className="campotabladeshabilitadoderecha";
      			 
       if (document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked){
           // Maneja Descuento Despues de IVA
           document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.readOnly=false;
           document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.className="campotablahabilitadoderecha";  
               
           document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.readOnly=false;
           document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.className="campotablahabilitadoderecha";
       }
       else {
           // No Maneja Descuento Despues de IVA
                  
           document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.readOnly=true;
           document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.className="campotabladeshabilitadoderecha";  
           
           document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.readOnly=true;
           document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.className="campotabladeshabilitadoderecha";             
       }
                                                              
       document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.className="campotabladeshabilitadoderecha";          
   }
   else{
       // Se Desmarco Descuento Antes de IVA
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.value=0;                    
       
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked=false; //Se desmarca Descuento Despues de IVA tambien              
              
       document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.className="campotabladeshabilitadoderecha";
       
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.className="campotabladeshabilitadoderecha";
             
       document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.className="campotabladeshabilitadoderecha";
       
       document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.className="campotabladeshabilitadoderecha";                                   
     
       document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.className="campotabladeshabilitadoderecha";                                   
	 
	   document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.className="campotabladeshabilitadoderecha";  
   
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.className="campotabladeshabilitadoderecha";
      
       document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.className="campotabladeshabilitadoderecha"; 
   }
   
   document.forms[0].elements['txtCampoEnviado'].value="0";
   
   if(document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked) {
       document.forms[0].elements['txtSumaProductos'].focus();
   }
   
   return(true);
}

// Verificamos que campos aplicarán cuando se de click en checkbox Despues de iva
function chkDespuesdeIva_onclick() {

   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.value= 0;
   document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.value= 0;     
   document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.value= 0;   
   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.value= 0;
   document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.value= 0;
   document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.value= 0;
   document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.value= 0;    
   document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.value= 0;
      
   if (document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked) {
       // Se marco Descuento Despues de IVA
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.value=1; 
       
       // Habilitamos los campos de la Captura    
       if (document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked) {
           // Maneja Descuento Antes DE IVA
           document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.readOnly=true;
           document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.className="campotabladeshabilitadoderecha";
       }
       else{
           // No Maneja Descuento Antes DE IVA
           document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.readOnly=false;
           document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.className="campotablahabilitadoderecha";
       }

	   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.readOnly=false;
       document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.className="campotablahabilitadoderecha";
              
       document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.readOnly=false;
       document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.className="campotablahabilitadoderecha";
            
       document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.readOnly=false;
       document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.className="campotablahabilitadoderecha";

       document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.readOnly=false;
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.className="campotablahabilitadoderecha";
                                   
       // Deshabilitamos los campos de la Captura
       document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.className="campotabladeshabilitadoderecha";
   }
   else {
       // Se Desmarco Descuento Despues de IVA            
       document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.value=0;           
       
       document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked=false; //Se desmarca Descuento Antes de IVA tambien 
       
       document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.className="campotabladeshabilitadoderecha";
        
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.className="campotabladeshabilitadoderecha";
       
       document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.className="campotabladeshabilitadoderecha";
       
       document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.className="campotabladeshabilitadoderecha";				 				 
       
       document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.className="campotabladeshabilitadoderecha";           
                                         
       document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.className="campotabladeshabilitadoderecha";  
    
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.className="campotabladeshabilitadoderecha";
       
       document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.readOnly=true;
       document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.className="campotabladeshabilitadoderecha"; 
   }
   
   document.forms[0].elements['txtCampoEnviado'].value="0";       
   
   if(document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked) {
       document.forms[0].elements['txtSumaProductos'].focus();
   }  
   
   if(!(document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked) && document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked) {       
       document.forms[0].elements['txtTotalFacturado'].focus();
   }     
         
   return(true);                   
  
}

function txtSumaProductos_onblur() {
    dblSumaProductos = document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.value;
    dblSumaProductos =  strEliminacommas(dblSumaProductos);
   
    if (isNaN(dblSumaProductos)){
        document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.value=0;
    }

    if (parseFloat(dblSumaProductos) < 0){
        document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.value=0;
       }
      if (document.forms[0].elements['txtIvaFacturado'].value>0) {
         document.frmMercanciaCapturarCompraDirecta.txtValidaIva.value = 1;
      }
      else {
         document.frmMercanciaCapturarCompraDirecta.txtValidaIva.value = 0;
      }      
                
      if (parseFloat(dblSumaProductos) > 0){  
         if (document.forms[0].elements['txtIdentificaClick'].value== "0"){
             fncEjecutaCodebehind('txtSumaProductos','Calculo',true);
         }   
      }
          
      return(false);
}

function txtDescuentoAntesdeIva_onblur() {
   dblDescuentoAntesdeIva = document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.value;
   dblDescuentoAntesdeIva = strEliminacommas(dblDescuentoAntesdeIva);
      
   if (isNaN(dblDescuentoAntesdeIva)){
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.value=0;          
   }
   
   if (parseFloat(dblDescuentoAntesdeIva) < 0){
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.value=0;
   }
   
   document.frmMercanciaCapturarCompraDirecta.txtValidaIva.value = 0;
     
   if (document.forms[0].elements['txtIvaFacturado'].value>0) {
       document.frmMercanciaCapturarCompraDirecta.txtValidaIva.value = 1;
   }
   else {
       document.frmMercanciaCapturarCompraDirecta.txtValidaIva.value = 0;
   }
        
   if (parseFloat(dblDescuentoAntesdeIva) > 0){   
       if (document.forms[0].elements['txtIdentificaClick'].value== "0"){
           fncEjecutaCodebehind('txtDescuentoAntesdeIva','Calculo',true); 
       }  
   }   
    return(false);          
}


function cboIvaAplicado_onchange() {      
   dblTotalFacturado = document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.value;
              
   document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.value=0;
   
   if (parseFloat(dblTotalFacturado) > 0){                
       fncEjecutaCodebehind('','Calculo',false);                
   }    
      return(true);  
}

function txtTotalFacturado_onblur() {
   dblTotalFacturado = document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.value;
   dblTotalFacturado = strEliminacommas(dblTotalFacturado);
      
   if (isNaN(dblTotalFacturado)){
       document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.value = 0;          
   }
   
   if (parseFloat(dblTotalFacturado) < 0){
       document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.value=0;
   }

   document.frmMercanciaCapturarCompraDirecta.txtValidaIva.value = 0;
      
   if (document.forms[0].elements['txtIvaFacturado'].value>0) {
      document.frmMercanciaCapturarCompraDirecta.txtValidaIva.value = 1;
   }
   else {
      document.frmMercanciaCapturarCompraDirecta.txtValidaIva.value = 0;
   }
      
   if (parseFloat(dblTotalFacturado) > 0){
       if (document.forms[0].elements['txtIdentificaClick'].value== "0"){ 
           fncEjecutaCodebehind('txtTotalFacturado','Calculo',true);
       }    
   } 
   return(false);
}

function txtImporteIeps_onblur() {
   dblImporteIEPS = document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.value;
   dblImporteIEPS = strEliminacommas(dblImporteIEPS);
      
   if (isNaN(dblImporteIEPS)){
       document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.value =0;          
   }

   if (parseFloat(dblImporteIEPS) < 0){
       document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.value=0;
   }

   if (parseFloat(dblImporteIEPS) > 0){
       fncEjecutaCodebehind('txtImporteIEPS','Calculo',false);
   } 
   return(false);
}

function txtIvaFacturado_onblur() {
   dblIvaFacturado = document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.value;
   dblIvaFacturado =  strEliminacommas(dblIvaFacturado);
        
   if (isNaN(dblIvaFacturado) || (dblIvaFacturado == "")){
       document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.value=0;          
   }
   
   if (parseFloat(dblIvaFacturado) < 0){
       document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.value=0;
   }
                           
   document.frmMercanciaCapturarCompraDirecta.txtValidaIva.value = 1;
      
   if (parseFloat(dblIvaFacturado) > 0){
       if (document.forms[0].elements['txtIdentificaClick'].value== "0"){ 
           fncEjecutaCodebehind('txtIvaFacturado','Calculo',true);      
       }    
   }   
   
   return(false);
}

function txtIvaDescuento_onblur() {
   dblIvaDescuento = document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.value;
   dblIvaDescuento = strEliminacommas(dblIvaDescuento)
    
   if (isNaN(dblIvaDescuento) || (dblIvaDescuento == "")){
       document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.value=0;          
   }
   
   if (parseFloat(dblIvaDescuento) < 0){
       document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.value=0;
   }
                       
   document.frmMercanciaCapturarCompraDirecta.txtValidaIva.value = 1;
      
   if (parseFloat(dblIvaDescuento) > 0){
       if (document.forms[0].elements['txtIdentificaClick'].value== "0"){      
           fncEjecutaCodebehind('txtIvaDescuento','Calculo',true);
       }    
   } 
   return(false);
}

function txtDescuentoDespuesdeIva_onblur() { 
   txtDescuentoDespuesdeIva = document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.value;
   txtDescuentoDespuesdeIva =  strEliminacommas(txtDescuentoDespuesdeIva);
           
   if (isNaN(txtDescuentoDespuesdeIva)){
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.value = 0;          
   }

   if (parseFloat(txtDescuentoDespuesdeIva) < 0){
       document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.value=0;
   }
         
   document.frmMercanciaCapturarCompraDirecta.txtValidaIva.value = 0;
      
   if (document.forms[0].elements['txtIvaFacturado'].value>0) {
       document.frmMercanciaCapturarCompraDirecta.txtValidaIva.value = 1;
   }
   else {
       document.frmMercanciaCapturarCompraDirecta.txtValidaIva.value = 0;
   }
      
   if (parseFloat(txtDescuentoDespuesdeIva) > 0) {      
       if (document.forms[0].elements['txtIdentificaClick'].value== "0"){
           fncEjecutaCodebehind('txtDescuentoDespuesdeIva','Calculo',true);
       }    
   } 
   
   return(false);
}

function txtSumaProductos_onfocus() {
   document.forms[0].elements['txtCampoEnviado'].value="1";
   document.forms[0].elements['txtSumaProductos'].select();
   return(true);
}

function txtDescuentoAntesdeIva_onfocus() {
   document.forms[0].elements['txtCampoEnviado'].value="2";
   document.forms[0].elements['txtDescuentoAntesdeIva'].select();
   return(true); 
}

function txtTotalFacturado_onfocus() {
   document.forms[0].elements['txtCampoEnviado'].value="3";
   document.forms[0].elements['txtTotalFacturado'].select();
   return(true);
}


function txtIvaFacturado_onfocus() {
   document.forms[0].elements['txtCampoEnviado'].value="4";
   document.forms[0].elements['txtIvaFacturado'].select();
   return(true);    
}

function txtIvaDescuento_onfocus() {
   document.forms[0].elements['txtCampoEnviado'].value="5";
   document.forms[0].elements['txtIvaDescuento'].select();
   return(true);  
}

function txtDescuentoDespuesdeIva_onfocus() {
   document.forms[0].elements['txtCampoEnviado'].value="6";
   document.forms[0].elements['txtDescuentoDespuesdeIva'].select();
   return(true); 
}

function txtImporteIEPS_onfocus() {
   document.forms[0].elements['txtCampoEnviado'].value="7";
   document.forms[0].elements['txtImporteIEPS'].select();
   return(true);
}

function txtRFC_onfocus() {
  if (document.forms[0].elements['txtRFC'].readOnly==false){
    strValor = LTrim(RTrim(document.forms[0].elements['txtProveedorNombreId'].value));
    strCuenta = strValor.length;
  
    if (parseInt(strCuenta) > 0){
       // Buscamos el proveedor 
       fncEjecutaCodebehind('','BuscaProveedor',false);  
    }
     
     if (parseInt(strCuenta) == 0){
       document.forms[0].elements['txtProveedorNombreId'].focus();
     }
    
 }
       
 return(true);
}


function DoObjCalendar1(){
	if(document.forms[0].elements['txtFechaRecepcion'].readOnly==false){
		objCalendar1.popup();
	}
 }	

function DoObjCalendar2(){
	if(document.forms[0].elements['txtFechaFactura'].readOnly==false){
		objCalendar2.popup();
	}
}


function fnValidarHeaderFactura() {
   var valida=true;
   
   var dblSumaProductos, dblDescuentoAntesdeIva, dblTotalFacturado, dblIvaFacturado, dblIvaDescuento, dblDescuentoDespuesdeIva, dblTotalNetoFacturado, dblIvaAplicado, strRFCCapturado,  strRFCInicial;
   	
   strRFCCapturado = document.forms[0].elements['txtRFC'].value;
   strRFCCapturado = strRFCCapturado.toUpperCase();
   strRFCCapturado = Trim(strRFCCapturado);
       
   strRFCInicial = document.forms[0].elements['txtRFCOculto'].value;
   strRFCInicial = strRFCInicial.toUpperCase();
   strRFCInicial = Trim(strRFCInicial);
        
   if (parseInt(strRFCCapturado.search('-')) > 0){
       alert("El RFC debe ser capturado sin guiones");
       return(false);
   }  
   
	// Validamos el Número de proveedor
   if (valida){valida=blnValidarCampo(document.forms("frmMercanciaCapturarCompraDirecta").elements("txtProveedorNombreId"),true,"No. de Proveedor", cintTipoCampoAlfanumerico,20,1,""); }
   if (!valida){
	   return(valida);
   }
   	 
   // Validamos el campo de RFC 
   if (valida){valida= blnValidarRFC(document.forms("frmMercanciaCapturarCompraDirecta").elements("txtRFC"),"RFC",false);} 
   if (!valida){
       return(valida);
   }
   
   // Validamos si el proveedor es de remisiones
   if (valida) {
       blnCapturaRemision = document.forms[0].elements['hdnCapturaRemision'].value;
       blnRemisionDisponible = document.forms[0].elements['hdnRemisionDisponible'].value;
              
       if(blnCapturaRemision == 1 && (document.forms[0].elements['txtRemisionFolio'].value).length < 1 ) {
               valida=false;
			   alert("Activar la lupa para seleccionar la Remisión");		   
       }
    }
		   
      // Validamos si es necesario tener seleccionada Orden de Compra  
   if (valida) {
       blnSoloOrden = document.forms[0].elements['hdnSoloOrden'].value;
	   blnOrdenDisponible = document.forms[0].elements['hdnOrdenDisponible'].value;

       if(blnSoloOrden==1){           
           valida=blnValidarCampo(document.forms("frmMercanciaCapturarCompraDirecta").elements("txtFolioOrdenId"),true,"Folio de Orden", cintTipoCampoReal,10,1,"");	      		   
	   } 
       else {
           if(blnOrdenDisponible==1) {
                valida=blnValidarCampo(document.forms("frmMercanciaCapturarCompraDirecta").elements("txtFolioOrdenId"),true,"Folio de Orden", cintTipoCampoReal,10,1,"");	      
                //valida= false;
                //alert("Hay Ordenes de compra disponibles para el proveedor, seleccionarla");
		   }
	   }
   }
   if (!valida){
       return(valida);
   }
            
   // Validamos el numero de factura (solamente letras y numeros)
   if (valida){valida=blnValidarCampo(document.forms("frmMercanciaCapturarCompraDirecta").elements("txtNumeroFactura"),true,"No. Factura", cintTipoCampoCadenaDefinida,20,1,"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789");}
   if (!valida){
       return(valida);
   }

   
   // Validamos la fecha de recepción
   if (valida){ valida=blnValidarCampo(document.forms("frmMercanciaCapturarCompraDirecta").elements("txtFechaRecepcion"),true,"Fecha de Recepción",cintTipoCampoFecha,10,10,"");}
   if (!valida){
		return(valida);
   }
   
   // Fecha de recepcion
   strDiaFechaRecepcion = document.frmMercanciaCapturarCompraDirecta.txtFechaRecepcion.value;
   strDiaFechaRecepcion = strDiaFechaRecepcion.substring(0,2);
   	 
   strMesFechaRecepcion = document.frmMercanciaCapturarCompraDirecta.txtFechaRecepcion.value;
   strMesFechaRecepcion = strMesFechaRecepcion.substring(3,5);
   	 
   strAnioFechaRecepcion = document.frmMercanciaCapturarCompraDirecta.txtFechaRecepcion.value;
   strAnioFechaRecepcion = strAnioFechaRecepcion.substring(6,10);
    
   strFechaRecepcion = strMesFechaRecepcion + "/" + strDiaFechaRecepcion + "/" + strAnioFechaRecepcion;

	// Fecha de Factura
	strDiaFechaFactura = document.frmMercanciaCapturarCompraDirecta.txtFechaFactura.value;
	strDiaFechaFactura = strDiaFechaFactura.substring(0,2);
	 
	strMesFechaFactura = document.frmMercanciaCapturarCompraDirecta.txtFechaFactura.value;
	strMesFechaFactura = strMesFechaFactura.substring(3,5);
	 
	strAnioFechaFactura = document.frmMercanciaCapturarCompraDirecta.txtFechaFactura.value;
	strAnioFechaFactura = strAnioFechaFactura.substring(6,10);
	 
	strFechaFactura = strMesFechaFactura + "/" + strDiaFechaFactura + "/" + strAnioFechaFactura;
	 
	 
	// Fecha actual
	strFecha = "<%=dtmFechaActual%>";
	 
	strDiaActual = strFecha;
	strDiaActual = strDiaActual.substring(0,2);
	 
	strMesActual = strFecha;
	strMesActual = strMesActual.substring(3,5);
	 
	strAnioActual = strFecha;
	strAnioActual = strAnioActual.substring(6,10);
	 
	strFechaActual = strMesActual + "/" + strDiaActual + "/" + strAnioActual;
	 	  
   // La fecha de recepcion no puede ser mayor que la fecha actual
   if (Date.parse(strFechaRecepcion) > Date.parse(strFechaActual)){  
       alert("La fecha de recepción no puede ser mayor que la fecha actual.");
       return(false);
   }
   	    
   // Validamos la fecha de factura
   if (valida){ valida=blnValidarCampo(document.forms("frmMercanciaCapturarCompraDirecta").elements("txtFechaFactura"),true,"Fecha de Factura",cintTipoCampoFecha,10,10,"");}
   if (!valida){
		return(false);
   }
   	       
   // La fecha de factura no puede ser mayor que la fecha actual
   if (Date.parse(strFechaFactura) > Date.parse(strFechaActual)){  
	    alert("La fecha de factura no puede ser mayor que la fecha actual.");
	    return(false);
   }
   
   // La fecha de factura debe ser menor o igual que la fecha de recepcion
   if (Date.parse(strFechaFactura) > Date.parse(strFechaRecepcion)){
	     alert("La fecha de factura no puede ser mayor que la fecha de recepcion.");
	     return(false);
  }
  
  // Validamos el iva aplicado
	if (valida){valida=blnValidarCombo(document.forms("frmMercanciaCapturarCompraDirecta").elements("cboIvaAplicado"),"-1","Iva aplicado",true);}
	if (!valida){
		return(false);
	}
    	
	// Vallidamos el iva descuento
	if (valida){valida=blnValidarCombo(document.forms("frmMercanciaCapturarCompraDirecta").elements("cboDescuento"),"0","Iva Descuento",true);}
	if (!valida){
		return(false);
	}
   // Validamos el monto de IEPS (valor decimal)
   if (valida){valida=blnValidarCampo(document.forms("frmMercanciaCapturarCompraDirecta").elements("txtImporteIEPS"),true,"Importe IEPS", cintTipoCampoReal,10,1,"");}
   if (!valida){
		return(valida);
   }
   
   // VALIDAMOS QUE EL IVA SELECCIONADO SEA VALIDO SEGUN LA FECHA DE LA FACTURA
   dblIvaSeleccionado = document.frmMercanciaCapturarCompraDirecta.cboIvaAplicado.options[document.frmMercanciaCapturarCompraDirecta.cboIvaAplicado.selectedIndex].value;
   dblIvaSeleccionado = strEliminacommas(dblIvaSeleccionado);
 
   
   if (strAnioFechaFactura < 2014 && (dblIvaSeleccionado==16.00) && (document.frmMercanciaCapturarCompraDirecta.cboIvaAplicado.selectedIndex==1) ) {  
	    alert("El IVA seleccionado no corresponde a la fecha de factura.");
	    return(false);
   }
   if (strAnioFechaFactura > 2013 && (dblIvaSeleccionado==11.00) && (document.frmMercanciaCapturarCompraDirecta.cboIvaAplicado.selectedIndex==4) ) {  
	    alert("El IVA seleccionado no corresponde a la fecha de factura.");
	    return(false);
   }   
   
	///////////////////////////////////////////
	/// Validaciones de importes capturados ///
	/////////////////////////////////////////// 	 
	 
	dblSumaProductos = document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.value;
	dblSumaProductos = strEliminacommas(dblSumaProductos);
	dblSumaProductos = parseFloat(dblSumaProductos);
	  
	dblDescuentoAntesdeIva = document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.value;
	dblDescuentoAntesdeIva = strEliminacommas(dblDescuentoAntesdeIva);
	dblDescuentoAntesdeIva = parseFloat(dblDescuentoAntesdeIva);
	  
	dblTotalFacturado = document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.value;
	dblTotalFacturado = strEliminacommas(dblTotalFacturado);
	dblTotalFacturado = parseFloat(dblTotalFacturado);
	 
	dblIvaFacturado = document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.value;
	dblIvaFacturado = strEliminacommas(dblIvaFacturado);
	dblIvaFacturado = parseFloat(dblIvaFacturado);
	  
	dblIvaDescuento = document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.value;
	dblIvaDescuento = strEliminacommas(dblIvaDescuento);
	dblIvaDescuento = parseFloat(dblIvaDescuento);
	   
	dblDescuentoDespuesdeIva = document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.value;
	dblDescuentoDespuesdeIva = strEliminacommas(dblDescuentoDespuesdeIva);
	dblDescuentoDespuesdeIva = parseFloat(dblDescuentoDespuesdeIva);
	  
	dblTotalNetoFacturado = document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.value; 
	dblTotalNetoFacturado = strEliminacommas(dblTotalNetoFacturado);
	dblTotalNetoFacturado = parseFloat(dblTotalNetoFacturado);

	dblImporteIEPS = document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.value; 
	dblImporteIEPS = strEliminacommas(dblImporteIEPS );
	dblImporteIEPS = parseFloat(dblImporteIEPS);

 
	// Verificamos si esta seleccionada la opción de "No Tiene Descuento"
   if (document.frmMercanciaCapturarCompraDirecta.cboDescuento.selectedIndex == 2) 
   {
       if (parseFloat(dblTotalFacturado) <= parseFloat(dblIvaFacturado)) {
           alert("El Iva facturado no puede ser mayor o igual al total facturado.");
           return(false);             
       }  
       // Validamos el iva facturado vs (Total facturado * iva aplicado)
               dblIvaAplicado = document.frmMercanciaCapturarCompraDirecta.cboIvaAplicado.options[document.frmMercanciaCapturarCompraDirecta.cboIvaAplicado.selectedIndex].value;
               dblIvaAplicado = strEliminacommas(dblIvaAplicado);
               dblIvaAplicado = parseFloat(dblIvaAplicado)/100;
               
               dblIvaOriginal = (parseFloat(dblTotalFacturado) * parseFloat(dblIvaAplicado))+1;
               dblIvaMinimo = (parseFloat(dblTotalFacturado) * parseFloat(dblIvaAplicado)) - ( (parseFloat(dblTotalFacturado) * parseFloat(dblIvaAplicado)) * 0.10);
               
               //1
               if (Math.abs(parseFloat(dblIvaFacturado) - (parseFloat(dblTotalFacturado) * parseFloat(dblIvaAplicado))) > 1) {
                   if ( parseFloat(dblIvaFacturado) < parseFloat(dblIvaMinimo)  ) {
                       
                       alert("El iva debe corresponder a la Clave Capturada.");
                       document.forms[0].elements['txtIvaFacturado'].select(); 
                       return(false);
                   }
                   if ( parseFloat(dblIvaFacturado) > parseFloat(dblIvaOriginal)  ) {
                       
                       alert("El iva debe corresponder a la Clave Capturada.");
                       document.forms[0].elements['txtIvaFacturado'].select(); 
                       return(false);
                   }                   
               }     
   }             
   
   // Verificamos si esta seleccionada la opción de "Tiene Descuento"
   if (document.frmMercanciaCapturarCompraDirecta.cboDescuento.selectedIndex == 1)
   {
       // Verificamos si esta seleccionada la opción de "Descuento antes de iva"
       if (document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked==true)
       {
           if (document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked==false) 
           {
               // Validamos que no quede vacío el descuento antes de iva
               if (parseFloat(dblDescuentoAntesdeIva) == 0){
                   alert("No ha capturado el descuento antes de iva");
                   return(false); 
               }
               
               // Validamos el iva facturado vs (Total facturado * iva aplicado)
               dblIvaAplicado = document.frmMercanciaCapturarCompraDirecta.cboIvaAplicado.options[document.frmMercanciaCapturarCompraDirecta.cboIvaAplicado.selectedIndex].value;
               dblIvaAplicado = strEliminacommas(dblIvaAplicado);
               dblIvaAplicado = parseFloat(dblIvaAplicado)/100;
                              
               //2
               dblIvaOriginal = (parseFloat(dblTotalFacturado) * parseFloat(dblIvaAplicado))+1;
               dblIvaMinimo = (parseFloat(dblTotalFacturado) * parseFloat(dblIvaAplicado)) - ( (parseFloat(dblTotalFacturado) * parseFloat(dblIvaAplicado)) * 0.10);
               
               if (Math.abs(parseFloat(dblIvaFacturado) - (parseFloat(dblTotalFacturado) * parseFloat(dblIvaAplicado))) > 1) {
                   if ( parseFloat(dblIvaFacturado) < parseFloat(dblIvaMinimo)  ) {
                       alert("El iva debe corresponder a la Clave Capturada.");
                       document.forms[0].elements['txtIvaFacturado'].select(); 
                       return(false);
                   }
                   if ( parseFloat(dblIvaFacturado) > parseFloat(dblIvaOriginal)  ) {
                       alert("El iva debe corresponder a la Clave Capturada.");
                       document.forms[0].elements['txtIvaFacturado'].select(); 
                       return(false);
                   }                   
               }
                                                          
               if ((parseFloat(dblSumaProductos) <= parseFloat(dblDescuentoAntesdeIva)) && parseFloat(parseFloat(dblSumaProductos))){
               alert("El descuento antes de iva no puede ser mayor o igual a la suma.");
               return(false);             
               }
                  
               if ((parseFloat(dblTotalFacturado) <= parseFloat(dblIvaFacturado)) && parseFloat(dblTotalFacturado) > 0){
               alert("El iva facturado debe ser menor que el total facturado.")
               return(false);
               }                                                      
           }                          
       }
         
       // "Descuento despues de iva"
       if (document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked==true){
           if (document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked==false){
               
               // Validamos que no quede vacío el descuento antes de iva
               if (parseFloat(dblDescuentoDespuesdeIva) == 0){
               alert("No ha capturado el descuento despues de iva");
               return(false); 
               }
                                                            
               if ((parseFloat(dblTotalFacturado) <= parseFloat(dblIvaFacturado)) && parseFloat(dblTotalFacturado) > 0){
               alert("El iva facturado debe ser menor que el total facturado.");
               return(false);
               }
                       
               if ((parseFloat(dblTotalFacturado) <= parseFloat(dblDescuentoDespuesdeIva)) && parseFloat(dblTotalFacturado) > 0){
               alert("El descuento despues de iva debe ser menor que el total facturado.")
               return(false);
               }
                         
               // Validamos el iva Descuento vs (Descuento despues de iva * iva Descueno)
               dblIvaAplicado = document.frmMercanciaCapturarCompraDirecta.cboIvaAplicado.options[document.frmMercanciaCapturarCompraDirecta.cboIvaAplicado.selectedIndex].value;
               dblIvaAplicado = strEliminacommas(dblIvaAplicado);
               dblIvaAplicado = parseFloat(dblIvaAplicado)/100;
               
               //na
               dblIvaOriginal = (parseFloat(dblDescuentoDespuesdeIva) * parseFloat(dblIvaAplicado) ) + 1;
               dblIvaMinimo   = (parseFloat(dblDescuentoDespuesdeIva) * parseFloat(dblIvaAplicado)) - ( (parseFloat(dblDescuentoDespuesdeIva) * parseFloat(dblIvaAplicado)) * 0.10);

               if (Math.abs(parseFloat(dblIvaDescuento) - (parseFloat(dblDescuentoDespuesdeIva) * parseFloat(dblIvaAplicado))) > 1) {
                   if ( parseFloat(dblIvaDescuento) < parseFloat(dblIvaMinimo)  ) {
                       alert("El iva debe corresponder a la Clave Capturada.");
                       document.forms[0].elements['txtIvaDescuento'].select(); 
                       return(false);
                   }
                   if ( parseFloat(dblIvaDescuento) > parseFloat(dblIvaOriginal)  ) {
                       alert("El iva debe corresponder a la Clave Capturada.");
                       document.forms[0].elements['txtIvaDescuento'].select(); 
                       return(false);
                   }                   
               }
                                                                                                
           }
       }
                                    
       // "Despues y Antes de iva"
       if (document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.checked==true){
           if (document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.checked==true){
                              
               // Validamos que no quede vacío el descuento antes de iva
               if (parseFloat(dblDescuentoAntesdeIva) == 0){
               alert("No ha capturado el descuento antes de iva");
               return(false); 
               } 
                              
               // Validamos que no quede vacío el descuento antes de iva
               if (parseFloat(dblDescuentoDespuesdeIva) == 0){
               alert("No ha capturado el descuento despues de iva");
               return(false); 
               }

               // Descuento antes de iva es menor la suma de productos
               if ((parseFloat(dblSumaProductos) <= parseFloat(dblDescuentoAntesdeIva)) && parseFloat(parseFloat(dblSumaProductos))){
               alert("El descuento antes de iva no puede ser mayor o igual a la suma.");
               return(false);             
               }
               
               if ((parseFloat(dblTotalFacturado) <= parseFloat(dblDescuentoDespuesdeIva)) && parseFloat(dblTotalFacturado) > 0){
               alert("El descuento despues de iva debe ser menor que el total facturado.")
               return(false);
               }                         
                                                          
               // Validamos el iva facturado vs (Total facturado * iva aplicado)
               dblIvaAplicado = document.frmMercanciaCapturarCompraDirecta.cboIvaAplicado.options[document.frmMercanciaCapturarCompraDirecta.cboIvaAplicado.selectedIndex].value
               dblIvaAplicado = strEliminacommas(dblIvaAplicado);
               dblIvaAplicado = parseFloat(dblIvaAplicado)/100;
              
               dblIvaOriginal = (parseFloat(dblTotalFacturado) * parseFloat(dblIvaAplicado))+1;
               dblIvaMinimo = (parseFloat(dblTotalFacturado) * parseFloat(dblIvaAplicado)) - ( (parseFloat(dblTotalFacturado) * parseFloat(dblIvaAplicado)) * 0.10);
               
               //3
               if (Math.abs(parseFloat(dblIvaFacturado) - (parseFloat(dblTotalFacturado) * parseFloat(dblIvaAplicado))) > 1) {
                   if ( parseFloat(dblIvaFacturado) < parseFloat(dblIvaMinimo)  ) {
                       alert("El iva debe corresponder a la Clave Capturada.");
                       document.forms[0].elements['txtIvaFacturado'].select(); 
                       return(false);
                   }
                   if ( parseFloat(dblIvaFacturado) > parseFloat(dblIvaOriginal)  ) {
                       alert("El iva debe corresponder a la Clave Capturada.");
                       document.forms[0].elements['txtIvaFacturado'].select(); 
                       return(false);
                   }                   
               }      
               
               // Descuento debe ser menor que Descuento despues de iva
               if (parseFloat(dblDescuentoDespuesdeIva) <= parseFloat(dblIvaDescuento)){
               alert("El Iva Descuento debe ser menor desc. despues de iva");
               return(false);
               }
                                                                                        
               // Validamos el iva facturado contra el total facturado                               
               if (parseFloat(dblTotalFacturado) <= parseFloat(dblIvaFacturado)){
               alert("El iva facturado de ser menor que el total facturado.");
               return(false);
               }
                                              
               // Suma productos contra Descuento antes de iva                               
               if ((parseFloat(dblSumaProductos) <= parseFloat(dblDescuentoAntesdeIva)) && parseFloat(dblSumaProductos) > 0){
               alert("El descuento antes iva debe ser menor que la suma de productos.");
               return(false);
               }
                        
               if ((parseFloat(dblTotalFacturado) <= parseFloat(dblDescuentoDespuesdeIva)) && parseFloat(dblTotalFacturado)){
               alert("El descuento despues de iva debe ser menor a el total facturado.");
               return(false);
               }
           }
       }
   }
                                              
   // El total facturado debe ser mayor a cero
   if (parseFloat(dblTotalFacturado) <= 0){
       alert("El total facturado debe ser mayor a 0.");
       return(false);
   }

                                 
   // Verificamos el total neto facturado
   if (Math.abs(parseFloat(dblTotalNetoFacturado) - (parseFloat(dblTotalFacturado) + parseFloat(dblIvaFacturado) - parseFloat(dblIvaDescuento) - parseFloat(dblDescuentoDespuesdeIva) + parseFloat(dblImporteIEPS) ) ) > 1) {
       alert("El Neto es el Total + Iva Fact - Iva del Desc - Desc. Desp Iva + IEPS");                            
       return(false);                  
   }  

   document.frmMercanciaCapturarCompraDirecta.cboIvaAplicado.disabeld=false;
   document.frmMercanciaCapturarCompraDirecta.cboDescuento.disabled=false;
   
	return(true);

}

function objLupaProveedor_onclick() {
   var valida = true;   
   var intCuentaApostrofes=0;  
   var strProveedorCapturado = "";
      
   if (document.forms[0].elements['txtProveedorNombreId'].readOnly) {
      return(true);
   }
      
   strProveedorCapturado = document.forms[0].elements['txtProveedorNombreId'].value;
   
   if (strProveedorCapturado.length< 1) {
       alert("Teclear Número de proveedor o descripción");
       document.forms[0].elements['txtProveedorNombreId'].focus();
       return(false);
   }
     
   intCuentaApostrofes = strProveedorCapturado.search("'");
   
   if (intCuentaApostrofes != -1) {
       document.forms[0].elements['txtProveedorNombreId'].value = '';
       alert("No se deben de capturar apostrofes");
       document.forms[0].elements['txtProveedorNombreId'].focus();
       return(false);
   }
   
   
   var strtxtProveedorB = Trim((document.forms[0].elements['txtProveedorNombreId'].value).substring(0,4));
	   
   if (isNaN(strtxtProveedorB) || strtxtProveedorB.length<1 ) // Esta capturando Descripcion
   {   
       
       strEvalJs="opener.txtProveedorNombreId_onblur();"; 
       strParametros = ''		
       strParametros = strParametros + ' campoProveedorId=hdnProveedorId';
       strParametros = strParametros + '&campoProveedorNombreId=txtProveedorNombreId';
       strParametros = strParametros + '&campoProveedorRazonSocial=txtRazonSocialProveedor';       
       strParametros = strParametros + '&campoProveedorRFC=txtRFCOculto';              
       strParametros = strParametros + '&campoSoloOrden=hdnSoloOrden';
       strParametros = strParametros + '&campoOrdenDisponible=hdnOrdenDisponible';
	   strParametros = strParametros + '&campoCapturaRemision=hdnCapturaRemision';
       strParametros = strParametros + '&campoRemisionDisponible=hdnRemisionDisponible';	   
       strParametros = strParametros + '&campoCapturaCosto=hdnCapturaCosto';
       strParametros = strParametros + '&campoMargenFactura=hdnMargenFactura';	   
       strParametros = strParametros + '&strTipoProveedorNombreId=';
       strParametros = strParametros + '&strProveedorId=' + document.forms[0].elements['txtProveedorNombreId'].value;
	   strParametros = strParametros + '&intTipoVigencia=1'; // Solo proveedores vigentes
	   
       Pop('PopProveedor.aspx?'+strParametros+'&strEvalJs='+strEvalJs,500,540); 
   }   
   else {
   
       document.forms[0].action = "<%=strFormAction%>?strCmd=BuscaProveedor"
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';    
   }   
}

// Ejecuta el onblur del campo StxtProveedorNombreId al captar un enter
function txtProveedorNombreId_onKeyDown() { 
	if(event.keyCode==13){ txtProveedorNombreId_onblur() }
}

function txtProveedorNombreId_onblur() {
   strProveedorCapturado = Trim(document.forms[0].elements['txtProveedorNombreId'].value); 

   if (strProveedorCapturado.length > 0 && strProveedorCapturado!='0') {
      if (document.forms[0].elements['hdnProveedorNombreId'].value != document.forms[0].elements['txtProveedorNombreId'].value) {
           objLupaProveedor_onclick(); 
      }
   }
   else {
      document.forms[0].elements['hdnCapturaCosto'].value='';
      document.forms[0].elements['hdnMargenFactura'].value='';   
   
      document.forms[0].elements['hdnCapturaRemision'].value='';
      document.forms[0].elements['hdnRemisionDisponible'].value='';

      document.forms[0].elements['hdnRemisionId'].value='';
      document.forms[0].elements['txtRemisionFolio'].value='';
	  
      document.forms[0].elements['txtFolioOrdenId'].value='';
      document.forms[0].elements['hdnSoloOrden'].value='';
	  document.forms[0].elements['hdnOrdenDisponible'].value='';
	  
      document.forms[0].elements['txtProveedorNombreId'].value='';
      document.forms[0].elements['txtProveedorNombreId'].focus();
      return true;
   }
}
	
function fnUpBuscarProveedor(intProveedorId,strProveedorNombreId,strProveedorRazonSocial,strProveedorRFC,blnSoloOrden,blnOrdenDisponible,blnCapturaRemision,blnRemisionDisponible,blnCapturaCosto,fltMargenFactura, intError) {
      
   document.forms[0].elements['hdnProveedorId'].value= intProveedorId;
   document.forms[0].elements['txtProveedorNombreId'].value= strProveedorNombreId;
   document.forms[0].elements['hdnProveedorNombreId'].value= strProveedorNombreId;
   document.forms[0].elements['txtRazonSocialProveedor'].value= strProveedorRazonSocial;
   document.forms[0].elements['txtRFCOculto'].value= strProveedorRFC;
 
   document.forms[0].elements['hdnCapturaRemision'].value=blnCapturaRemision;
   document.forms[0].elements['hdnRemisionDisponible'].value=blnRemisionDisponible; 
   document.forms[0].elements['hdnRemisionId'].value='';
   document.forms[0].elements['txtRemisionFolio'].value='';
    
   document.forms[0].elements['hdnSoloOrden'].value=blnSoloOrden;
   document.forms[0].elements['hdnOrdenDisponible'].value=blnOrdenDisponible;      
   document.forms[0].elements['txtFolioOrdenId'].value='';
 
   document.forms[0].elements['hdnCapturaCosto'].value=blnCapturaCosto;
   document.forms[0].elements['hdnMargenFactura'].value=fltMargenFactura;   
    
   if (intError == 0 ) {       
       document.forms[0].elements['txtRFC'].focus();       
   }
   else {       
       document.forms[0].elements['txtProveedorNombreId'].focus();
       alert("Error, Proveedor no encontrado");       
   }
}

function txtRFC_onblur() {
   if (document.forms[0].elements['txtRFC'].readOnly) {
       return(true); 
   }
   
   strProveedorCapturado = Trim(document.forms[0].elements['txtProveedorNombreId'].value); 
   strRFCCapturado = Trim(document.forms[0].elements['txtRFC'].value);

   if (strProveedorCapturado.length < 1) {
       alert("El número de proveedor debe ser\n\r capturado antes de ingresar \n\r el RFC");
       document.forms[0].elements['txtProveedorNombreId'].focus();   
       return(true);    
   }
   
   document.forms[0].elements['txtRFCOculto'].value = strEliminaGuiones(strRFCCapturado);

   if (strRFCCapturado.length>1 && document.forms[0].elements['hdnOrdenDisponible'].value=='1') {
      cmdVerOrden_onclick();
   }
   return(true);
}

function objLupaRemision_onclick() {        
   if (document.forms[0].elements['txtProveedorNombreId'].readOnly==true) {
      return;
   }
   
   strProveedorCapturado = Trim(document.forms[0].elements['txtProveedorNombreId'].value);    
   if (strProveedorCapturado.length < 1) {
       alert("El número de proveedor debe ser\n\r capturado para ver \n\r las Remisiones");
       document.forms[0].elements['txtProveedorNombreId'].focus();   
       return;    
   }
            
   strRFCCapturado = document.forms[0].elements['txtRFC'].value;      
   if (strRFCCapturado.length<1) {
       alert("El RFC del proveedor debe ser\n\r capturado para ver \n\r las Remisiones");
       document.forms[0].elements['txtRFC'].focus();   
       return; 
   }
      
   var strParametros = '';       
   strParametros = strParametros + 'intProveedorId='+ document.forms[0].elements['hdnProveedorId'].value + '&'; 
   strParametros = strParametros + 'campoRemisionId=hdnRemisionId&campoRemisionFolio=txtRemisionFolio';
   	                 
   var WinOrdenes = window.open('popRemisionCompraDirectaConsultar.aspx?'+ strParametros,'PopRemisiones','width=580,height=480,left=240,top=120,resizable=no,scrollbars=yes,menubar=no,status=no' );    
     
}

function cmdVerOrden_onclick() {        
   if (document.forms[0].elements['txtProveedorNombreId'].readOnly==true) {
      return;
   }
   
   strProveedorCapturado = Trim(document.forms[0].elements['txtProveedorNombreId'].value);    
   if (strProveedorCapturado.length < 1) {
       alert("El número de proveedor debe ser\n\r capturado para ver \n\r las ORDENES");
       document.forms[0].elements['txtProveedorNombreId'].focus();   
       return;    
   }
            
   strRFCCapturado = document.forms[0].elements['txtRFC'].value;      
   if (strRFCCapturado.length<1) {
       alert("El RFC del proveedor debe ser\n\r capturado para ver \n\r las ORDENES");
       document.forms[0].elements['txtRFC'].focus();   
       return; 
   }
      
   var strParametros = '';       
   strParametros = strParametros + 'intProveedorId='+ document.forms[0].elements['hdnProveedorId'].value + '&'; 
   strParametros = strParametros + 'strProveedorNombreId='+ document.forms[0].elements['txtProveedorNombreId'].value + '&'; 
   strParametros = strParametros + 'strProveedorRazonSocial=' + document.forms[0].elements['txtRazonSocialProveedor'].value + '&'; 
   strParametros = strParametros + 'campoOrdenId=txtFolioOrdenId';
   	                 
   var WinOrdenes = window.open('MercanciaConsultaOrdenesCompraDirecta.aspx?'+ strParametros,'PopOrdenes','width=460,height=420,left=240,top=120,resizable=no,scrollbars=yes,menubar=no,status=no' );    
     
}

function txtNumeroFactura_onblur() {
   if (document.forms[0].elements['txtNumeroFactura'].readOnly) {
       return(true);   
   }
         
   strFacturaCapturada = Trim(document.forms[0].elements['txtNumeroFactura'].value); 
      
   if((document.forms[0].elements['txtProveedorNombreId'].value != "0") && (document.forms[0].elements['txtProveedorNombreId'].value != "")) {        
      if (strFacturaCapturada.length >1) {           
        fncEjecutaCodebehind('txtNumeroFactura','BuscarFactura',true);
        return(true);
      }
   }
   else{
       alert("El número de proveedor debe ser\n\r capturado antes de ingresar \n\r el número de factura");
       document.forms[0].elements['txtProveedorNombreId'].focus();
   }
}

function fnUpBuscarFactura(strRazonSocialProveedor, intError) 
{    
	if( intError == 0 ) 
	{       
		document.forms[0].elements['txtFechaRecepcion'].focus();       
	}
   
	else 
	{                 
		document.forms[0].elements['txtNumeroFactura'].value= '';
		document.forms[0].elements['txtNumeroFactura'].focus();
		
		if( intError == -101 )	
			alert("Error, Favor de confirma el documento en el módulo 'Confirmar factura electrónica de proveedores directos' "); 
		
		else if( intError == -102 )	
			alert("Error, El documento ya había sido confirmado en el módulo 'Confirmar factura electrónica de proveedores directos' "); 
				
		else	// -103
			alert("Error, Factura ya esta capturada");       
	}
}

function fnUpCalculoImportes(dblSumaProductos, dblDescuentoAntesdeIva, dblTotalFacturado, dblImporteIEPS, dblIvaFacturado, dblIvaDescuento, dblDescuentoDespuesdeIva, dblTotalNetoFacturado) {
   document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.value= dblSumaProductos;
   document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.value= dblDescuentoAntesdeIva;     
   document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.value= dblTotalFacturado;   
   document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.value= dblImporteIEPS;
   document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.value= dblIvaFacturado;
   document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.value= dblIvaDescuento;
   document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.value= dblDescuentoDespuesdeIva;    
   document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.value= dblTotalNetoFacturado;
   
   // SIN DESCUENTOS
   if (document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.value == 0 && document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.value == 0) {
   
       if (document.frmMercanciaCapturarCompraDirecta.txtCampoEnviado.value == 3) {
           document.frmMercanciaCapturarCompraDirecta.txtImporteIEPS.select();
       }
       if (document.frmMercanciaCapturarCompraDirecta.txtCampoEnviado.value == 7) {
           document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.select();
       }
       
   }
   
   // Descuento Antes y Despues de IVA
   if (document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.value == 1 && document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.value == 1) {
       if (document.frmMercanciaCapturarCompraDirecta.txtCampoEnviado.value == 0) {
           document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.select();
       }
       if (document.frmMercanciaCapturarCompraDirecta.txtCampoEnviado.value == 1) {
           document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.select();
       }
       if (document.frmMercanciaCapturarCompraDirecta.txtCampoEnviado.value == 2) {
           document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.select();
       }
       if (document.frmMercanciaCapturarCompraDirecta.txtCampoEnviado.value == 4) {
           document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.select();
       }
       if (document.frmMercanciaCapturarCompraDirecta.txtCampoEnviado.value == 5) {
          document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.select();
       }
       if (document.frmMercanciaCapturarCompraDirecta.txtCampoEnviado.value == 6) { 
           document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.select();
       }
   }
   
   // Descuento Despues de Iva
   if (document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.value == 0 && document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.value == 1) {
       if (document.frmMercanciaCapturarCompraDirecta.txtCampoEnviado.value == 0) {
           document.frmMercanciaCapturarCompraDirecta.txtTotalFacturado.select();
       }
       if (document.frmMercanciaCapturarCompraDirecta.txtCampoEnviado.value == 3) {
           document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.select();
       }                        
       if (document.frmMercanciaCapturarCompraDirecta.txtCampoEnviado.value == 4) {
           document.frmMercanciaCapturarCompraDirecta.txtDescuentoDespuesdeIva.select();
       }                        
       if (document.frmMercanciaCapturarCompraDirecta.txtCampoEnviado.value == 5) {
           document.frmMercanciaCapturarCompraDirecta.txtTotalNetoFacturado.select();
       }                        
       if (document.frmMercanciaCapturarCompraDirecta.txtCampoEnviado.value == 6) {
           document.frmMercanciaCapturarCompraDirecta.txtIvaDescuento.select();
       }
   }
                        
   // Descuento Antes de Iva
   if (document.frmMercanciaCapturarCompraDirecta.chkAntesdeIva.value == 1 && document.frmMercanciaCapturarCompraDirecta.chkDespuesdeIva.value == 0) {                    
       if (document.frmMercanciaCapturarCompraDirecta.txtCampoEnviado.value == 0) {
           document.frmMercanciaCapturarCompraDirecta.txtSumaProductos.select();
       }
       if (document.frmMercanciaCapturarCompraDirecta.txtCampoEnviado.value == 1) {
           document.frmMercanciaCapturarCompraDirecta.txtDescuentoAntesdeIva.select();
       }
       if (document.frmMercanciaCapturarCompraDirecta.txtCampoEnviado.value == 2) {
           document.frmMercanciaCapturarCompraDirecta.txtIvaFacturado.select();
       }                    
   }
}


function cmdCancelar_onclick() {    
   if (confirm("Cancelar la Captura de la Compra Directa?")) {
       window.location.href = "MercanciaCapturarCompraDirecta.aspx";               	  
   }   
   return(true);
}

function cmdCapturaDetalle_onclick() {
   if (fnValidarHeaderFactura()) {
       document.forms[0].action = "<%=strFormAction%>?strCmd=AltaCompra";
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';
    }  
}


function cmdContinuar_onclick() {
   if (fnValidarHeaderFactura()) {       
       
       var strReinicio="blnReinicio=0"  
       
       if ("<%=strCmd%>" == "ModificarDatos") {
           strReinicio="blnReinicio=1"  
       }
       document.forms[0].action = "<%=strFormAction%>?strCmd=ActualizarCompra&" + strReinicio;
       
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';
   }
   
}

function fnUpCompraDirecta(intAccionCompraDirecta, intNumeroDeCompra, fltMargenInferiorCompra, fltMargenSuperiorCompra, intError) {
   var blnRegreso = true;
        
   if (intError == 0) {
       document.frmMercanciaCapturarCompraDirecta.cboIvaAplicado.disabeld=false;
       document.frmMercanciaCapturarCompraDirecta.cboDescuento.disabled=false;
       
       document.forms[0].elements['txtCompraDirectaId'].value = intNumeroDeCompra; 
	   
	   document.forms[0].elements['txtMargenInferiorCompra'].value = fltMargenInferiorCompra; 
	   document.forms[0].elements['txtMargenSuperiorCompra'].value = fltMargenSuperiorCompra;      

       // INICIA CAPTURA DETALLE
       if (intAccionCompraDirecta == 1) { // Inicia Captura Detalle Con Orden
           document.forms[0].action = "CompraDirectaModificarOrdenSugerida.aspx?strCmd=Consultar";
       }
       if (intAccionCompraDirecta == 2) { // Inicia Captura Detalle Sin Orden
           document.forms[0].action ="MercanciaCapturarDetalleCompraDirecta.aspx";
       }
       // CONTINUA CAPTURA DETALLE
       if (intAccionCompraDirecta == 3) {
          document.forms[0].action = "MercanciaCapturarDetalleCompraDirecta.aspx";
       }
	   	   
       document.forms[0].submit();           
   }
   else {
       blnRegreso = false;
       
       if (intError == -90) {          
          alert("ERROR \n\r El proveedor solo acepta captura por ORDEN y no hay disponibles");  
       }
       if (intError == -95) {          
          alert("ERROR \n\r Hay Ordenes disonibles debe seleccionarla");  
       } 
       if (intError == -100) {          
           if (intAccionCompraDirecta == 1 || intAccionCompraDirecta == 2) {
               alert("ERROR \n\r No se puede iniciar la captura de la Compra");           
           }
           if (intAccionCompraDirecta == 3) {
               alert("ERROR \n\r No se puede guardar cambios de la Compra");           
           }           
       }
              
       if (blnRegreso) {
          blnRegreso = false;
          alert("Se detecto un error inesperado en captura de la compra")          
       }
              
       document.location.href='MercanciaCapturarCompraDirecta.aspx';
   }  
      
   return (blnRegreso); 
}

/// Load de página ///
function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
	document.forms[0].action = "<%=strFormAction%>"
	
	if(	document.forms[0].elements['txtCompraDirectaId'].value< 1) {
       document.all.tblBotonesInicio.style.display=''; 
       document.all.tblBotonesCaptura.style.display='none'; 	
	}
	else {
       document.all.tblBotonesInicio.style.display='none'; 
       document.all.tblBotonesCaptura.style.display=''; 
	}
    	
	var strCmd = "<%=strCmd%>";
	
	if (strCmd=="") {	    
       fnHabilitaBotonesInicio();  //Inicio       	   
	}
	
    if (strCmd=="ModificarImporte") {	
       fnHabilitaBotonesModificarImporte();  //Modificar solo importe       
    }  
      
    if (strCmd=="ModificarDatos") {
       var intElimina = parseInt("<%=intEliminaDetalle%>")
       
       if (intElimina < 0) {
           alert("Ocurrió una falla al momento de eliminar el detalle de las compras directas.");
           fnHabilitaBotonesInicio(); 	        
       }
       else {
           fnHabilitaBotonesModificarDatos(); // Modificar los datos
       }
       document.forms[0].elements['txtProveedorNombreId'].focus();
       
    }     
}

//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaCapturarCompraDirecta">
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
            <td width="583" class="tdmigaja"><span class="txdmigaja">Está en : 
              </span><a href="Mercancia.aspx" class="txdmigaja">Mercancía</a><span class="txdmigaja"> 
              : <a href="MercanciaEntradas.aspx" class="txdmigaja">Entradas</a></span><span class="txdmigaja"> 
              : </span><span class="txdmigaja"></span><span class="txdmigaja"><a href="MercanciaEntradasComprasDirectas.aspx" class="txdmigaja">Compras 
              directas </a> </span><span class="txdmigaja"> : </span><span class="txdmigaja"></span><span class="txdmigaja"></span><span class="txdmigaja">Capturar 
              compra directa</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="75%" valign="top" > <span class="txtitulo">Captura 
                    Compra Directa</span> <span class="txcontenido">Capturar primero 
                    datos del proveedor (verificar ordenes cargadas). Capturar 
                    datos factura (numero, fecha, iva, descuento). Capturar importes 
                    de la factura (Verficar bien su documento fisco). Continuar 
                    con el detalle de los productos.</span><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Datos 
                    Proveedor</span> <table width="99%" class="tdenvolventetablas">
                      <tr> 
                        <td class="tdtittablas3" align="left" width="25%">Proveedor</td>
                        <td class="tdtittablas3" align="left" width="15%">RFC</td>
                        <td class="tdtittablas3" align="left" width="50%">Razon 
                          Social</td>
                        <td class="tdtittablas3" align="left" width="10%"><a class="txaccion" href="javascript:;" onclick="return cmdVerOrden_onclick()" ><img src="../static/images/bOrden.gif" width="44" height="13" align="absMiddle" border="0" id="cmdVerOrden" name="cmdVerOrden"></a></td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3" align="left" width="25%"><input name="txtProveedorNombreId" id="txtProveedorNombreId" type="text" class="campotabla"  autocomplete="off" size="16" maxlength="16" onBlur="return txtProveedorNombreId_onblur()" onKeyDown="txtProveedorNombreId_onKeyDown()" value='<%=Request.Form("txtProveedorNombreId")%>' > 
                          &nbsp;<a id="objLupaProveedor" href="javascript:;" onclick="return objLupaProveedor_onclick()"><img src="../static/images/icono_lupa.gif" width="17" height="17" align="absMiddle" border="0"></a></td>
                        <td class="tdtittablas3" align="left" width="15%"><input name="txtRFC" id="txtRFC" type="text" class="campotablamayusculas"   size="16" maxlength="14" onFocus="return txtRFC_onfocus()" onBlur="return txtRFC_onblur()" value='<%=Request.Form("txtRFC")%>'></td>
                        <td class="tdtittablas3" align="left" width="50%"><input name="txtRazonSocialProveedor" id="txtRazonSocialProveedor" type="text" class="campotablaresultadoenvolventeazul" value='<%=Request.Form("txtRazonSocialProveedor")%>' size="40" maxlength="60"  border="0" readonly tabindex="-1"></td>
                        <td class="tdtittablas3" align="left" width="10%"><input name="txtFolioOrdenId" id="txtFolioOrdenId"  type="text" class="campotablaresultadoenvolventeazul" value='<%=Request.Form("txtFolioOrdenId")%>' size="8"  border="0" readonly tabindex="-1"></td>
                      </tr>
                    </table>
                    <br> <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Datos 
                    factura</span> <table width="99%" class="tdenvolventetablas">
                      <tr> 
                        <td width="20%" class="tdtittablas3" >Folio Remisión&nbsp;&nbsp;&nbsp;<a id="objLupaRemision" href="javascript:;" onclick="return objLupaRemision_onclick()"><img src="../static/images/icono_lupa.gif" width="17" height="17" align="absMiddle" border="0"></a>:</td>
                        <td width="80%" class="tdtittablas3"><input name="txtRemisionFolio" id="txtRemisionFolio"  type="text" class="campotablaresultadoenvolventeazul" value='<%=Request.Form("txtRemisionFolio")%>' size="20"  border="0" readonly tabindex="-1"> 
                          <input type='hidden' name='hdnRemisionId' value= '<%=Request.Form("hdnRemisionId")%>'> 
                        </td>
                      </tr>
                      <tr> 
                        <td width="20%" class="tdtittablas3" >No. de factura:</td>
                        <td width="80%" class="tdtittablas3"><input name="txtNumeroFactura" id="txtNumeroFactura" type="text" class="campotabla" value='<%= Request.Form("txtNumeroFactura") %>' size="24" maxlength="20" onblur="return txtNumeroFactura_onblur()"> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3">Fecha de recepción:</td>
                        <td class="tdtittablas3"><input id="txtFechaRecepcion" name="txtFechaRecepcion" type="text" class="campotabla"  value='<%=Request.Form("txtFechaRecepcion")%>' size="10" maxlength="10" > 
                          <img src="../static/images/icono_calendario.gif" width="20" height="13" align="absMiddle" border="0" style="CURSOR:hand" onClick="if(blnValidarCampo(document.forms('frmMercanciaCapturarCompraDirecta').elements('txtFechaRecepcion'),false,'Fecha Recepción',cintTipoCampoFecha,10,10,'')){DoObjCalendar1();}"></td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3">Fecha de factura</td>
                        <td class="tdtittablas3"><input id="txtFechaFactura" name="txtFechaFactura" type="text" class="campotabla" value='<%=Request.Form("txtFechaFactura")%>'  size="10" maxlength="10"> 
                          <img src="../static/images/icono_calendario.gif" width="20" height="13" align="absMiddle" border="0" style="CURSOR:hand" onClick="if(blnValidarCampo(document.forms('frmMercanciaCapturarCompraDirecta').elements('txtFechaFactura'),false,'Fecha Factura',cintTipoCampoFecha,10,10,'')){DoObjCalendar2();}"></td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3">IVA Aplicado:</td>
                        <td class="tdtittablas3"><select name="cboIvaAplicado" class="campotabla" id="cboIvaAplicado" onChange="return cboIvaAplicado_onchange()">
                          </select></td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3">Descuento:</td>
                        <td class="tdtittablas3"> <select id="cboDescuento" name="cboDescuento" class="campotabla" onChange="return cboDescuento_onchange()">
                          </select> </td>
                      </tr>
                      <tr> 
                        <td height="78" class="tdtittablas3">Tipo de descuento:</td>
                        <td class="tdtittablas3"><input id="chkAntesdeIva" name="chkAntesdeIva" type="checkbox" value='<%=Request.Form("chkAntesdeIva")%>' onClick="return chkAntesdeIva_onclick()">
                          Antes del IVA &nbsp;&nbsp; <input id="chkDespuesdeIva" name="chkDespuesdeIva" type="checkbox"  value='<%=Request.Form("chkDespuesdeIva")%>' onClick="return chkDespuesdeIva_onclick()">
                          Después del IVA</td>
                      </tr>
                    </table>
                    <br> <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Importes 
                    Factura</span> <table width="99%" class="tdenvolventetablas">
                      <tr> 
                        <td width="30%" class="tdtittablas3" valign="baseline">Suma 
                          de productos:</td>
                        <td width="70%" class="tdtittablas3"><input id="txtSumaProductos" name="txtSumaProductos" type="text" class="campotablahabilitadoderecha" value='<%=Request.Form("txtSumaProductos")%>' readonly autocompletesizemaxlength="16" onKeyDown="if(event.keyCode==13){document.forms[0].elements['txtIdentificaClick'].value='0';document.forms[0].elements['txtSumaProductos'].blur();}  if(event.keyCode==9){document.forms[0].elements['txtIdentificaClick'].value='0';}" onFocus="return txtSumaProductos_onfocus()" onBlur="return txtSumaProductos_onblur()" onClick="document.forms[0].elements['txtIdentificaClick'].value='1';document.forms[0].elements['txtCampoEnviado'].value='1';"="off"="18"></td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3">Descuento antes del IVA:</td>
                        <td class="tdtittablas3"> <input id="txtDescuentoAntesdeIva" name="txtDescuentoAntesdeIva" type="text" class="campotablahabilitadoderecha" value='<%=Request.Form("txtDescuentoAntesdeIva")%>' readonly autocompletesizemaxlength="16" onKeyDown="if(event.keyCode==13){document.forms[0].elements['txtIdentificaClick'].value='0';document.forms[0].elements['txtDescuentoAntesdeIva'].blur();} if(event.keyCode==9){document.forms[0].elements['txtIdentificaClick'].value='0';}" onFocus="return txtDescuentoAntesdeIva_onfocus()" onClick="document.forms[0].elements['txtIdentificaClick'].value='1';document.forms[0].elements['txtCampoEnviado'].value='2';" onBlur="return txtDescuentoAntesdeIva_onblur()"="off"="18"></td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3">Total facturado:</td>
                        <td class="tdtittablas3"> <input id="txtTotalFacturado" name="txtTotalFacturado" type="text" class="campotablahabilitadoderecha" value='<%=Request.Form("txtTotalFacturado")%>' readonly autocompletesizemaxlength="16" onKeyDown="if(event.keyCode==13){event.keyCode;document.forms[0].elements['txtIdentificaClick'].value='0';document.forms[0].elements['txtTotalFacturado'].blur();}  if(event.keyCode==9){document.forms[0].elements['txtIdentificaClick'].value='0';}" onFocus="return txtTotalFacturado_onfocus()"  onClick="document.forms[0].elements['txtIdentificaClick'].value='1';document.forms[0].elements['txtCampoEnviado'].value='3';" onBlur="return txtTotalFacturado_onblur()" ="off"="18"></td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3">Importe IEPS:</td>
                        <td class="tdtittablas3"> <input id="txtImporteIEPS" name="txtImporteIEPS" type="text" class="campotablahabilitadoderecha" value='<%=Request.Form("txtImporteIEPS")%>' readonly autocompletesizemaxlength="16" onKeyDown="if(event.keyCode==13){event.keyCode;document.forms[0].elements['txtIdentificaClick'].value='0';document.forms[0].elements['txtImporteIEPS'].blur();}  if(event.keyCode==9){document.forms[0].elements['txtIdentificaClick'].value='0';}" onfocus="return txtImporteIEPS_onfocus()" onClick="document.forms[0].elements['txtIdentificaClick'].value='1';document.forms[0].elements['txtCampoEnviado'].value='7';" onBlur="return txtImporteIeps_onblur()"="off"="18"></td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3">IVA facturado:</td>
                        <td class="tdtittablas3"> <input name="txtIvaFacturado" type="text" class="campotablahabilitadoderecha" value='<%=Request.Form("txtIvaFacturado")%>' readonly autocompletesizemaxlength="16"  onKeyDown="if(event.keyCode==13){document.forms[0].elements['txtIdentificaClick'].value='0';document.forms[0].elements['txtIvaFacturado'].blur();} if(event.keyCode==9){document.forms[0].elements['txtIdentificaClick'].value='0';}" onFocus="return txtIvaFacturado_onfocus()"  onClick="document.forms[0].elements['txtIdentificaClick'].value='1';document.forms[0].elements['txtCampoEnviado'].value='4';" onBlur="return txtIvaFacturado_onblur()"="off"="18"></td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3">IVA descuento:</td>
                        <td class="tdtittablas3"> <input id="txtIvaDescuento" name="txtIvaDescuento" type="text" class="campotablahabilitadoderecha" value='<%=Request.Form("txtIvaDescuento")%>'  readonly autocompletesizemaxlength="16"  onKeyDown="if(event.keyCode==13){document.forms[0].elements['txtIdentificaClick'].value='0';document.forms[0].elements['txtIvaDescuento'].blur();} if(event.keyCode==9){document.forms[0].elements['txtIdentificaClick'].value='0';}" onFocus="return txtIvaDescuento_onfocus()" onClick="document.forms[0].elements['txtIdentificaClick'].value='1';document.forms[0].elements['txtCampoEnviado'].value='5';" onBlur="return txtIvaDescuento_onblur()"="off"="18"> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3">Descuento despues del IVA:</td>
                        <td class="tdtittablas3"> <input id="txtDescuentoDespuesdeIva" name="txtDescuentoDespuesdeIva" type="text" class="campotablahabilitadoderecha" value='<%=Request.Form("txtDescuentoDespuesdeIva")%>' readonly autocompletesizemaxlength="16" onKeyDown="if(event.keyCode==13){document.forms[0].elements['txtIdentificaClick'].value='0';document.forms[0].elements['txtDescuentoDespuesdeIva'].blur();} if(event.keyCode==9){document.forms[0].elements['txtIdentificaClick'].value='0';}" onFocus="return txtDescuentoDespuesdeIva_onfocus()"  onClick="document.forms[0].elements['txtIdentificaClick'].value='1';document.forms[0].elements['txtCampoEnviado'].value='6';" onBlur="return txtDescuentoDespuesdeIva_onblur()"="off"="18"></td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3">Total neto facturado:</td>
                        <td class="tdtittablas3"> <input  id="txtTotalNetoFacturado" name="txtTotalNetoFacturado" type="text" class="campotablahabilitadoderecha" value='<%=Request.Form("txtTotalNetoFacturado")%>' readonly autocompletesizemaxlength="16" onKeyDown="if(event.keyCode==13){document.forms[0].elements['txtIdentificaClick'].value='0';document.forms[0].elements['txtIdentificaClick'].value='0';document.forms[0].elements['cmdValidar'].focus();} if(event.keyCode==9){document.forms[0].elements['txtIdentificaClick'].value='0';}"="off"="18"> 
                        </td>
                      </tr>
                    </table>
                    <br> <table width="99%" id="tblBotonesInicio" style="DISPLAY: none" cellSpacing="0" cellPadding="0" class="tdenvolventetablas" border="0">
                      <tr> 
                        <td class="tdtittablas3" colspan="2" align="right"> <input id="cmdCapturaDetalle" name="cmdCapturaDetalle" type="button" class="boton" value="Iniciar Captura Detalle " onclick="return cmdCapturaDetalle_onclick()" title="Captura del Detalle de la Compra sugiriendo articulos a partir de orden"> 
                        </td>
                      </tr>
                    </table>
                    <table width="99%" id="tblBotonesCaptura" style="DISPLAY: none" cellSpacing="0" cellPadding="0" class="tdenvolventetablas" border="0">
                      <tr> 
                        <td colspan="2" align="left"> <input id="cmdCancelar" name="cmdCancelar" type="button" class="boton" value="Cancelar" onclick="return cmdCancelar_onclick()"> 
                          <input id="cmdContinuar" name="cmdContinuar" type="button" class="boton" value="Continuar Captura Detalle" onclick="return cmdContinuar_onclick()"> 
                        </td>
                      </tr>
                    </table>
                    <br> </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda(strPaginaAyuda);</script> 
            </td>
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
    var objCalendar1 = new calendar1(document.forms['frmMercanciaCapturarCompraDirecta'].elements['txtFechaRecepcion']);
    var objCalendar2 = new calendar1(document.forms['frmMercanciaCapturarCompraDirecta'].elements['txtFechaFactura']);
	//-->
			</script>
  <tr> 
    <input type="hidden" name="txtCampoEnviado" value="0">
    <input type="hidden" name="txtIdentificaClick" value="0">
    <input type="hidden" name="txtValidaIva" value="0">
    <input type="hidden" name="txtCompraDirectaId" value= "<%=intCompraDirectaId()%>">
    <input type="hidden" name="txtMargenInferiorCompra" value= '<%=Request.Form("txtMargenInferiorCompra")%>'>
    <input type="hidden" name="txtMargenSuperiorCompra" value= '<%=Request.Form("txtMargenSuperiorCompra")%>'>
    <input type='hidden' name='hdnProveedorId' value= '<%=Request.Form("hdnProveedorId")%>'>
    <input type='hidden' name='hdnProveedorNombreId' value= '<%=Request.Form("hdnProveedorNombreId")%>'>
    <input type='hidden' name='hdnSoloOrden' value= '<%=Request.Form("hdnSoloOrden")%>'>
    <input type='hidden' name='hdnCapturaRemision' value= '<%=Request.Form("hdnCapturaRemision")%>'>
    <input type='hidden' name='hdnCapturaCosto' value= '<%=Request.Form("hdnCapturaCosto")%>'>
    <input type='hidden' name='hdnMargenFactura' value= '<%=Request.Form("hdnMargenFactura")%>'>
  </tr>
  <input type='hidden' name='hdnOrdenDisponible' value= '<%=Request.Form("hdnOrdenDisponible")%>'>
  <input type='hidden' name='hdnRemisionDisponible' value= '<%=Request.Form("hdnRemisionDisponible")%>'>
  <tr> 
    <input type='hidden' name='txtRFCOculto' value= '<%=Request.Form("txtRFCOculto")%>'>
    <input type='hidden' name='txtNumeroFacturaRuta'  value= '<%=Request.Form("txtNumeroFacturaRuta")%>'>
  </tr>
</form>
<iframe name="ifrOculto" height="0" width="0" src=""></iframe>
</body>
</HTML>
