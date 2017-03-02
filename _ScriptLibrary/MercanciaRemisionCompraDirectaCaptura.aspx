<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaRemisionCompraDirectaCaptura.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaRemisionCompraDirectaCapturar" codePage="28592" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaRemisionCompraDirectaCaptura.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Captura de Remisiones de Compra Directa
    ' Copyright     : 2012 All rights reserved.
    ' Company       : Farmacias Benavides
    ' Author        : [JAHD] 
    ' Version       : 1.0
    ' Last Modified : 
    '                 16 de Marzo 2012 [JAHD]  remisiones de compra directa
    '====================================================================
%>
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
//Variables Globales
blnmControlesEncabezadoHabilitados=true;

function LTrim(s){
	// Devuelve una cadena sin los espacios del principio
	var i=0;
	var j=0;
	
	// Busca el primer caracter <> de un espacio
	for(i=0; i<=s.length-1; i++)
		if(s.substring(i,i+1) != ' '){
			j=i;
			break;
		}
	return s.substring(j, s.length);
}

function RTrim(s){
	// Quita los espacios en blanco del final de la cadena
	var j=0;
	
	// Busca el último caracter <> de un espacio
	for(var i=s.length-1; i>-1; i--)
		if(s.substring(i,i+1) != ' '){
			j=i;
			break;
		}
	return s.substring(0, j+1);
}

function Trim(s){
	// Quita los espacios del principio y del final
	return LTrim(RTrim(s));
}

// Mandar ventana de consulta
function Pop(url, width, height) {
    var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	return(false);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
 
function blnDatosRemision() {
	//Validaciones
	var valida=true; 
		
	//No de proveedor
	if(valida){ valida=blnValidarCampo(document.forms(0).elements("txtProveedorNombreId"),true,"No. de proveedor",cintTipoCampoAlfanumerico,15,1,""); } 
	if(valida){ if(document.forms[0].elements['hdnProveedorId'].value==0 || (document.forms[0].elements['hdnProveedorId'].value).length < 1){valida=false;} }
	
	// Validamos el numero de Remision (solamente letras y numeros)
    if (valida){valida=blnValidarCampo(document.forms("frmMercanciaRemisionCompraDirectaCaptura").elements("txtNumeroRemision"),true,"No. Remision", cintTipoCampoCadenaDefinida,20,1,"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789");}
        
    // Validamos la fecha de recepción
    if (valida){ valida=blnValidarCampo(document.forms("frmMercanciaRemisionCompraDirectaCaptura").elements("txtFechaRecepcion"),true,"Fecha de Recepcion",cintTipoCampoFecha,10,10,"");}
    
    // Validamos la fecha de Remision
    if (valida){ valida=blnValidarCampo(document.forms("frmMercanciaRemisionCompraDirectaCaptura").elements("txtFechaRemision"),true,"Fecha de Remision",cintTipoCampoFecha,10,10,"");}
  	
    // Fecha actual
	strFecha = "<%=dtmFechaActual%>";
	strDiaActual   = strFecha.substring(0,2);	 
	strMesActual   = strFecha.substring(3,5);	 
	strAnioActual  = strFecha.substring(6,10);
	strFechaActual = strMesActual + "/" + strDiaActual + "/" + strAnioActual;
	   
    // Fecha de recepcion
    strDiaFechaRecepcion  = (document.frmMercanciaRemisionCompraDirectaCaptura.txtFechaRecepcion.value).substring(0,2);   	 
    strMesFechaRecepcion  = (document.frmMercanciaRemisionCompraDirectaCaptura.txtFechaRecepcion.value).substring(3,5);  	 
    strAnioFechaRecepcion = (document.frmMercanciaRemisionCompraDirectaCaptura.txtFechaRecepcion.value).substring(6,10);
    strFechaRecepcion = strMesFechaRecepcion + "/" + strDiaFechaRecepcion + "/" + strAnioFechaRecepcion;
	
	// Fecha de Remision
    strDiaFechaRemision  = (document.frmMercanciaRemisionCompraDirectaCaptura.txtFechaRemision.value).substring(0,2); 
    strMesFechaRemision  = (document.frmMercanciaRemisionCompraDirectaCaptura.txtFechaRemision.value).substring(3,5);	 
    strAnioFechaRemision = (document.frmMercanciaRemisionCompraDirectaCaptura.txtFechaRemision.value).substring(6,10);
	strFechaRemision = strMesFechaRemision + "/" + strDiaFechaRemision + "/" + strAnioFechaRemision;
		 	  
    // La fecha de Recepcion no puede ser mayor que la fecha actual
	if (valida){
        if (Date.parse(strFechaRecepcion) > Date.parse(strFechaActual)){  
            alert("La fecha de recepcion no puede ser mayor que la fecha actual.");
			valida=false;
		}
	}    
	      
    // La fecha de Remision no puede ser mayor que la fecha actual
   	if (valida){
        if (Date.parse(strFechaRemision) > Date.parse(strFechaActual)){  
            alert("La fecha de Remision no puede ser mayor que la fecha actual.");
	        valida=false;
        }
    }
	   
    // La fecha de Remision debe ser menor o igual que la fecha de recepcion
   	if (valida){	
        if (Date.parse(strFechaRemision) > Date.parse(strFechaRecepcion)){
            alert("La fecha de Remision no puede ser mayor que la fecha de recepcion.");
			valida=false;
		}
	}
	
    return(valida); 
}

function blnValidarCifraDeControl() {
	valida=true;
	if (valida){ valida=blnValidarCampo(document.forms(0).elements('txtCifraDeControl'),true,"Cifra de control",cintTipoCampoEntero,10,1,""); } 
	
	if (valida){	    
		intCifraControlSistema = document.forms[0].elements['hdnArticulosCantidad'].value * 1;
		
		if(intCifraControlSistema==0){
			alert('Agregue al menos un producto a la Remision.');
			document.forms(0).txtIntArticuloId.focus();
			document.forms(0).txtIntArticuloId.select();
			valida=false;
			return(valida);
		}
				
		inttxtCifraDeControl = (document.forms(0).elements('txtCifraDeControl').value) * 1;
		
		if(inttxtCifraDeControl==intCifraControlSistema){
			valida=true;
		}
		else {
			alert('La cifra de control no corresponde al total de artículos.');
			document.forms(0).elements('txtCifraDeControl').select();
			valida=false;
			return(valida);
		}
	}
	return(valida);
}

function fnHabilitaDeshabilitaControlesEncabezado(blnHabilitar){
	if(blnHabilitar) {	
		document.forms(0).elements('txtProveedorNombreId').readOnly=false;
		document.forms(0).elements('txtProveedorNombreId').className="campotabla";

		document.forms(0).elements('txtNumeroRemision').readOnly=false;
		document.forms(0).elements('txtNumeroRemision').className="campotabla";

		document.forms(0).elements('txtFechaRecepcion').readOnly=false;
		document.forms(0).elements('txtFechaRecepcion').className="campotabla";

		document.forms(0).elements('txtFechaRemision').readOnly=false;
		document.forms(0).elements('txtFechaRemision').className="campotabla";		

		blnmControlesEncabezadoHabilitados=true;		
		document.all.divBotones.style.display='none'; 
	}
	else {
		document.forms(0).elements('txtProveedorNombreId').readOnly=true;
		document.forms(0).elements('txtProveedorNombreId').className="campotabladeshabilitado";
		
		document.forms(0).elements('txtNumeroRemision').readOnly=true;
		document.forms(0).elements('txtNumeroRemision').className="campotabladeshabilitado";

		document.forms(0).elements('txtFechaRecepcion').readOnly=true;
		document.forms(0).elements('txtFechaRecepcion').className="campotabladeshabilitado";

		document.forms(0).elements('txtFechaRemision').readOnly=true;
		document.forms(0).elements('txtFechaRemision').className="campotabladeshabilitado";		

		blnmControlesEncabezadoHabilitados=false;		
		document.all.divBotones.style.display=''; 
	}
}
//Habilitar Controles y hace submit
function DoSubmit(){
   if(blnmControlesEncabezadoHabilitados){
		document.forms(0).submit();
	}
	else{
		fnHabilitaDeshabilitaControlesEncabezado(true);
		document.forms(0).submit();
		fnHabilitaDeshabilitaControlesEncabezado(false);		
	}
}

function objLupaProveedor_onclick() {
   var valida = true;   
   var intCuentaApostrofes=0;  
   var strProveedorCapturado = "";
   
   if (document.forms[0].txtProveedorNombreId.value == "") {return(true);}
   
   if (document.forms[0].elements['txtProveedorNombreId'].readOnly) {
      return(true);
   }     
    
   strProveedorCapturado = Trim(document.forms[0].elements['txtProveedorNombreId'].value);   

   intCuentaApostrofes = strProveedorCapturado.search("'");
   if (intCuentaApostrofes != -1) {
       document.forms[0].elements['txtProveedorNombreId'].value = '';
       alert("No se deben de capturar apostrofes");
       document.forms[0].elements['txtProveedorNombreId'].focus();
       return(false);
   }   
   
   if (strProveedorCapturado.length > 0 && strProveedorCapturado!='0') {
      if (document.forms[0].elements['hdnProveedorNombreId'].value == document.forms[0].elements['txtProveedorNombreId'].value) {
	   document.forms[0].txtNumeroRemision.focus(); 
       return(true);
      }
   }
      
   var strtxtProveedorB = Trim((document.forms[0].elements['txtProveedorNombreId'].value).substring(0,4));
    
   if (isNaN(strtxtProveedorB) || strtxtProveedorB.length<1 ) // Esta capturando Descripcion
   {         
       strEvalJs="opener.fnUpLupaProveedor();"; 
       strParametros = ''		
       strParametros = strParametros + 'campoProveedorId=hdnProveedorId';
       strParametros = strParametros + '&campoProveedorNombreId=txtProveedorNombreId';
       strParametros = strParametros + '&campoProveedorRazonSocial=txtRazonSocialProveedor';       
       strParametros = strParametros + '&strProveedorId=' + document.forms[0].elements['txtProveedorNombreId'].value;
   
       Pop('PopRemisionCompraDirectaProveedor.aspx?'+strParametros+'&strEvalJs='+strEvalJs,500,540); 
	   
   }   
   else {   
       document.forms[0].action = "<%=strFormAction%>?strCmd=BuscaProveedor"
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';    
   }      
}
function fnUpLupaProveedor() {
   document.forms[0].elements['hdnProveedorNombreId'].value = document.forms[0].elements['txtProveedorNombreId'].value ;
   if ( (document.forms[0].elements['txtProveedorNombreId'].value).length <1 ) {      
       document.forms[0].elements['txtProveedorNombreId'].focus();
       alert("Error, Proveedor no encontrado");  
      
   }
   else {       
       document.forms[0].elements['txtNumeroRemision'].focus();     
   }  
}	
function fnUpBuscarProveedor(intProveedorId,strProveedorNombreId,strProveedorRazonSocial, intError) {      
   document.forms[0].elements['hdnProveedorId'].value= intProveedorId;
   document.forms[0].elements['txtProveedorNombreId'].value= strProveedorNombreId;
   document.forms[0].elements['hdnProveedorNombreId'].value= strProveedorNombreId;
   document.forms[0].elements['txtRazonSocialProveedor'].value= strProveedorRazonSocial;
 
   if (intError == 0 ) {       
       document.forms[0].elements['txtNumeroRemision'].focus();       
   }
   else {       
       document.forms[0].elements['txtProveedorNombreId'].focus();
       alert("Error, Proveedor no encontrado");       
   }   
}

function fnBuscarRemision() {
   if (document.forms[0].elements['txtNumeroRemision'].readOnly) {
       return(true);   
   }
         
   strRemisionCapturada = Trim(document.forms[0].elements['txtNumeroRemision'].value); 
      
   if((document.forms[0].elements['txtProveedorNombreId'].value != "0") && (document.forms[0].elements['txtProveedorNombreId'].value != "")) {        
      if (strRemisionCapturada.length >1) {           
             document.forms[0].action = "<%=strFormAction%>?strCmd=" + "BuscarRemision";
             document.forms[0].target="ifrOculto";
             document.forms[0].submit();
             document.forms[0].target=''; 
             return(true);
      }
   }
   else{
       if (strRemisionCapturada.length >1) { 
           alert("El número de proveedor debe ser\n\r capturado antes de ingresar \n\r el número de Remisión");
           document.forms[0].elements['txtProveedorNombreId'].focus();
	   }
   }
}

function fnUpBuscarRemision(strRazonSocialProveedor, intError) {    
   if (intError == 0 ) {       
       document.forms[0].elements['txtFechaRecepcion'].focus();       
   }
   else {              
       document.forms[0].elements['txtNumeroRemision'].value= '';
       document.forms[0].elements['txtNumeroRemision'].focus();
       alert("Error \r Remisión ya esta capturada");       
   }
}

function DoObjCalendar1(){
	if(document.forms[0].elements['txtFechaRecepcion'].readOnly==false){
		objCalendar1.popup();
	}
 }	

function DoObjCalendar2(){
	if(document.forms[0].elements['txtFechaRemision'].readOnly==false){
		objCalendar2.popup();
	}
}
function objLupaArticulo_onClick() { 
   var strArticulo;
   var intCuentaApostrofes;
   
   if (document.forms[0].txtArticuloId.value == "") {return(true);}
   
    // Es necesario tener del numero de proveedor 
   valida =blnDatosRemision();
   if(valida==false){return(false); }
	
   strArticulo = document.forms[0].elements['txtArticuloId'].value;
   intCuentaApostrofes = strArticulo.search("'");
   
   if (intCuentaApostrofes != -1){
       alert("No se deben de capturar apostrofes");
       document.forms[0].elements['txtArticuloId'].value = '';
       document.forms[0].elements['txtArticuloId'].focus();
       return(false);
   }
   
   if (document.forms[0].txtArticuloId.value != "") {
       if (!isNaN(document.forms[0].txtArticuloId.value) && document.forms[0].txtArticuloId.value != '0' ) {
			       document.forms[0].action = "<%=strFormAction%>?strCmd=BuscarArticulo&<%=strFormActionParameters%>";
			       document.forms[0].target="ifrOculto";
				   DoSubmit();
  		           document.forms[0].target='';
			       return(true);

	   }
	   else{ 
            document.forms(0).txtDescripcionArticulo.value='';
			strEvalJs="opener.fnUpLupaArticulo();"; 
			 
			strParametros='';
			strParametros = strParametros + 'campoArticuloId=txtArticuloId';
			strParametros = strParametros + '&campoArticuloDescripcion=txtDescripcionArticulo';
            strParametros = strParametros + '&strArticuloIdNombre=' + document.forms[0].txtArticuloId.value;
			strParametros = strParametros + '&intProveedorId=' + document.forms[0].elements['hdnProveedorId'].value;
			Pop('PopRemisionCompraDirectaArticulo.aspx?'+strParametros+'&strEvalJs='+strEvalJs,500,540);			
	   }
	}
	else{
		alert("Teclear número de artículo o descripción");
		document.forms[0].txtArticuloId.focus();
        return(false); 
	    }
}

function txtArticuloId_onfocus() {
 document.forms[0].txtArticuloId.select();
 return(true);
}

function fnUpLupaArticulo() {
   document.forms(0).hdnArticuloEncontradoId.value = document.forms(0).txtArticuloId.value; 
   
   if ( (document.forms[0].elements['txtArticuloId'].value).length <1 ) {   
       alert('Artículo no encontrado');   
       document.forms[0].elements['txtArticuloId'].focus();   
   }
   else {       
       document.forms[0].elements['txtCantidad'].focus();
   }  
}
function fnUpdArticuloPorIframe(strArticuloId,strDescripcionArticulo,intError){
	document.forms(0).txtArticuloId.value = strArticuloId;
	document.forms(0).hdnArticuloEncontradoId.value = document.forms(0).txtArticuloId.value;
	document.forms(0).txtDescripcionArticulo.value = strDescripcionArticulo;	
    	
	if(intError!=0) {
		alert('Artículo no encontrado');
		document.forms[0].elements['txtArticuloId'].focus(); 
    }   
	else {
	    document.forms[0].elements['txtCantidad'].focus();
	} 
}

function txtCantidad_onfocus() {
   document.forms[0].txtCantidad.select(); 
   return(true);
}

// Agrega el Articulo capturado al detalle del Remision 
function cmdAgregar_onclick() {
  var valida=true;
  
   //Validaciones
   valida = blnDatosRemision(); 
   if(valida==false){ return(false); }
   
   //Codigo 
   if(valida) {	       
       if (document.forms(0).txtArticuloId.value != document.forms(0).hdnArticuloEncontradoId.value)  {
       alert("Capturar correctamente el articulo a ingresar");
       document.forms[0].txtArticuloId.focus();        
       return(false);
       }
   }          
   
   // Validamos que la cantidad sea un campo entero
   if (valida){valida=blnValidarCampo(document.forms['frmMercanciaRemisionCompraDirectaCaptura'].elements['txtCantidad'],true,"Cantidad", cintTipoCampoEntero,20,1,""); }
   
   if (!valida){return(valida);}
      
   // Cantidad que sea mayor a cero
   if (parseInt(document.forms['frmMercanciaRemisionCompraDirectaCaptura'].elements['txtCantidad'].value) <= 0){
        alert("Capturar correctamente la cantidad.");
        document.forms[0].txtCantidad.focus();        
        return(false);
   }
	
    document.forms[0].action = "<%=strFormAction%>?strCmd=AgregarArticulo"; 
    document.forms[0].target="ifrOculto";
    DoSubmit();
    document.forms[0].target='';
    return(true);    
}

// Elimina el Articulo seleccionado del detalle de la Compra directa
function cmdEliminar_onclick(intArticuloEliminar){
    document.forms[0].action = "<%=strFormAction%>?strCmd=EliminarArticulo&intArticuloEliminarId=" + intArticuloEliminar; 
    document.forms[0].target="ifrOculto";
    DoSubmit();
    document.forms[0].target='';    
}

function fnUpAgregarEliminarArticulo(intAccion, intRemisionCompraDirectaId, strRecordBrowserHTML, intTotalArticulosRemision, intError){
    document.all.divDetalle.innerHTML = strRecordBrowserHTML;	
	document.forms[0].elements['hdnCapturaId'].value = intRemisionCompraDirectaId;
	document.forms[0].elements['hdnArticulosCantidad'].value = intTotalArticulosRemision;

    if (intTotalArticulosRemision < 1) {
          fnHabilitaDeshabilitaControlesEncabezado(true); //Habiliar cuando no hay articulos  
    } 
    else {
           fnHabilitaDeshabilitaControlesEncabezado(false); //Deshabilita si ya hay articulos 
    }
        
    if (intError == 0) {
       document.forms(0).txtArticuloId.value = '';
	   document.forms(0).txtDescripcionArticulo.value = '';	   	          
	   document.forms(0).txtCantidad.value = '';	
	}
	else {   
       if (intAccion == 1) { // Agregar Articulo
           alert("ERROR, Articulo no pudo Agregarse");
       }
       if (intAccion == 2) { // Eliminar Articulo
           alert("ERROR, Articulo no pudo Eliminarse");
       }
   }
   
   document.forms(0).txtArticuloId.focus();	
}


function cmdRegresar_onClick() {
   window.location.href = "MercanciaEntradasComprasDirectas.aspx";  
   return(true);
}


// Registrar compra Directa
function cmdRegistrar_onClick(){
    //Validaciones
	valida = blnDatosRemision(); 
	
    if(valida){ valida=blnValidarCifraDeControl(); }
    
    if(valida){
		document.forms[0].action = "<%=strFormAction%>?strCmd=Registrar"; 
        document.forms[0].target="ifrOculto";
        DoSubmit();
        document.forms[0].target='';
	}
	
   return(true);   
}

// Despliega el Folio asignado a el Remision de Compra Directa
function fnUpRegistrarRemisionCompraDirecta(intRemisionCompraDirectaId, intError) {
   if (intError==0) {
       strParametros = "?strPaginapadre=Captura"
       strParametros = strParametros + '&intRemisionCompraDirectaId=' + intRemisionCompraDirectaId ;

       window.location.href = "MercanciaRemisionCompraDirectaDetalle.aspx" + strParametros;       
   }
   else { 
         alert ("No se registro la Remision de compra directa, verifique los datos y reintente");
   }
}  

function window_onload() {
        
	if(document.forms[0].elements['hdnArticulosCantidad'].value==0 || (document.forms[0].elements['hdnArticulosCantidad'].value).length < 1){
        fnHabilitaDeshabilitaControlesEncabezado(true);
		document.forms[0].elements['txtProveedorNombreId'].focus();
	}
	else {
        fnHabilitaDeshabilitaControlesEncabezado(false);
		document.forms[0].elements['txtArticuloId'].focus();
	}
      
    return(true);                      
}

function cmdonKeyPressed(intObjeto,tecla) {

 if (tecla == 13 || tecla==9) { 
       if (intObjeto==1) {
          document.forms(0).imgLupaProveedor.focus();     
       }
	   if (intObjeto==2) {       
          fnBuscarRemision();    
       }
	   if (intObjeto==3) {
          document.forms[0].elements['txtFechaRemision'].focus();  
       }
	   if (intObjeto==4) {
          document.forms[0].elements['txtArticuloId'].focus();     
       }
	   if (intObjeto==5) {
           document.forms(0).imgLupaArticulo.focus();    
       }	     
       if (intObjeto==6) {
           document.forms(0).cmdAgregar.focus(); 
       }   	   
	   if (intObjeto==8) {
           document.forms(0).cmdRegistrar.focus();     
       }   
       event.returnValue = false;
   }
  
}

function cmdEjecutarLupa(intObjeto) { 
       if (intObjeto==1) {
       objLupaProveedor_onclick();      
       }
	   if (intObjeto==5) {
        objLupaArticulo_onClick();
       }     
}
//-->
</script>
</HEAD>
<body leftMargin="0" topMargin="0" onload="return window_onload()" marginwidth="0" marginheight="0">
<form name="frmMercanciaRemisionCompraDirectaCaptura" action="about:blank" method="post">
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
            <td width="10" bgColor="#ffffff"> <img height="8" src="../static/images/pixel.gif" width="10"></td>
            <td class="tdmigaja" width="583"><span class="txdmigaja">Está en : 
              </span><a class="txdmigaja" href="Mercancia.aspx"> Mercancía</a> 
              <span class="txdmigaja">:<a href="MercanciaEntradas.aspx" class="txdmigaja">Entradas</a>: 
              <a class="txdmigaja" href="MercanciaEntradasComprasDirectas.aspx">Compras 
              Directas</a></span><span class="txdmigaja"> </span><span class="txdmigaja">: 
              </span><span class="txdmigaja"> </span><span class="txdmigaja"></span><span class="txdmigaja">Captura 
              Remisi&oacute;n</span></td>
            <td class="tdfechahora" width="182"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td vAlign="top" width="583"> <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtablacont" vAlign="top" width="100%"><table width="100%" class="tdenvolventetablas">
                      <tr> 
                        <td class="tdtittablas3" align="left" width="30%">Proveedor</td>
                        <td class="tdtittablas3" align="left" width="50%">Razon 
                          Social</td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3" align="left" width="30%"><input name="txtProveedorNombreId" id="txtProveedorNombreId" type="text" class="campotabla"  autocomplete="off" size="16" maxlength="16" value='<%=Request.Form("txtProveedorNombreId")%>' onkeypress="cmdonKeyPressed(1,event.keyCode);"  tabindex="1" onBlur="cmdEjecutarLupa(1);"  > 
                          &nbsp;<a id="objLupaProveedor" onclick="return objLupaProveedor_onclick()"><img name="imgLupaProveedor" src="../static/images/icono_lupa.gif" width="17" height="17" align="absMiddle" border="0" tabindex="2" ></a></td>
                        <td class="tdtittablas3" align="left" width="50%"><input name="txtRazonSocialProveedor" id="txtRazonSocialProveedor" type="text" class="campotablaresultadoenvolventeazul" value='<%=Request.Form("txtRazonSocialProveedor")%>' size="38" maxlength="50"  border="0" readonly tabindex="-1"></td>
                      </tr>
                    </table>
                    <br> <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Datos 
                    Remisión</span> <table width="100%" class="tdenvolventetablas">
                      <tr> 
                        <td width="20%" class="tdtittablas3" >No. de Remisión:</td>
                        <td width="80%" class="tdtittablas3"><input name="txtNumeroRemision" id="txtNumeroRemision" type="text" class="campotabla" value='<%= Request.Form("txtNumeroRemision") %>' size="24" maxlength="20" onBlur="cmdonKeyPressed(2,13);" onkeypress="cmdonKeyPressed(2,event.keyCode);" tabindex="3"> 
                        </td>
                      </tr>
                      <tr> 
                        <td height="21" class="tdtittablas3">Fecha de Recepción:</td>
                        <td class="tdtittablas3"><input id="txtFechaRecepcion" name="txtFechaRecepcion" type="text" class="campotabla"  value='<%=Request.Form("txtFechaRecepcion")%>' size="10" maxlength="10" onkeypress="cmdonKeyPressed(3,event.keyCode);"  tabindex="4"> 
                          <img src="../static/images/icono_calendario.gif" width="20" height="13" align="absMiddle" border="0" style="CURSOR:hand" onClick="if(blnValidarCampo(document.forms('frmMercanciaRemisionCompraDirectaCaptura').elements('txtFechaRecepcion'),false,'Fecha Recepción',cintTipoCampoFecha,10,10,'')){DoObjCalendar1();}" ></td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3">Fecha de Remision</td>
                        <td class="tdtittablas3"><input id="txtFechaRemision" name="txtFechaRemision" type="text" class="campotabla" value='<%=Request.Form("txtFechaRemision")%>'  size="10" maxlength="10" onkeypress="cmdonKeyPressed(4,event.keyCode);"  tabindex="5"> 
                          <img src="../static/images/icono_calendario.gif" width="20" height="13" align="absMiddle" border="0" style="CURSOR:hand" onClick="if(blnValidarCampo(document.forms('frmMercanciaRemisionCompraDirectaCaptura').elements('txtFechaRemision'),false,'Fecha Remision',cintTipoCampoFecha,10,10,'')){DoObjCalendar2();}"></td>
                      </tr>
                    </table>
                    <span class="txsubtitulo"><br>
                    <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Detalle 
                    Remision<br>
                    <div id="divDetalle" name="divDetalle"></div>
                    </span> <br> <table class="tdenvolventetablas" width="100%">
                      <tr> 
                        <td class="tdtittablas3" align="left" width="25%">Código</td>
                        <td class="tdtittablas3" align="left" width="35%">Descripción</td>
                        <td class="tdtittablas3" align="left" width="10%">Cantidad</td>
                        <td class="tdtittablas3" align="center" width="20%" vAlign="middle" rowspan="2"> 
                          <input class="boton" id="cmdAgregar" onclick="return cmdAgregar_onclick()" type="button"
																value="Agregar" name="cmdAgregar" tabindex="9"> 
                        </td>
                      </tr>
                      <tr> 
                        <td align="left" width="25%" class="txtitintabla"> <input class="campotablahabilitadoderecha" id="txtArticuloId2" 
																onFocus="return txtArticuloId_onfocus()" type="text" maxlength="16" size="12" name="txtArticuloId"
																autocomplete="off" onKeyPress="cmdonKeyPressed(5,event.keyCode);" onBlur="cmdEjecutarLupa(5);" tabindex="6" > 
                          <a id="objLupaArticulo" onclick="return objLupaArticulo_onClick();" > 
                          <img  name="imgLupaArticulo" height="17" src="../static/images/icono_lupa.gif" width="16" align="absMiddle" border="0" tabindex="7"></a></td>
                        <td class="txtitintabla" vAlign="middle" width="35%"> 
                          <input class="campotablaresultadoenvolventeazul" readOnly type="text" size="25" name="txtDescripcionArticulo" tabindex="-1"> 
                        </td>
                        <td class="tdpadleft5" vAlign="middle" align="left" width="10%"> 
                          <input class="campotablahabilitadoderecha" id="txtCantidad" 
																onfocus="return txtCantidad_onfocus()" type="text" maxLength="8" size="12" name="txtCantidad"
																autocomplete="off" onkeypress="cmdonKeyPressed(6,event.keyCode);" tabindex="8"> 
                        </td>
                      </tr>
                    </table>
                    <br> <div id="divBotones" style="DISPLAY: none"> 
                      <table id="TblBotones" cellSpacing="0" cellPadding="0" width="100%" border="0">
                        <tr> 
                          <td width="317">&nbsp;&nbsp; <input class="boton" onClick="return cmdRegresar_onClick()" type="button" value="Regresar" name="cmdRegresar" tabindex="-1"></td>
                          <td class="tdenvolventetablas" align="center" width="200" bgColor="#f4f6f8"> 
                            <table cellSpacing="0" cellPadding="0" width="230" border="0">
                              <tr> 
                                <td class="tdtittablas3" width="156">Cifra de 
                                  control</td>
                                <td width="91" rowSpan="2"><input class="boton" onClick="return cmdRegistrar_onClick()" type="button" value="Registrar"
																		name="cmdRegistrar" tabindex="10"> 
                                </td>
                              </tr>
                              <tr> 
                                <td vAlign="top" height="30"><input class="campotabla" onKeyPress="cmdonKeyPressed(8,event.keyCode);" type="text" maxlength="4"
																		size="16" name="txtCifraDeControl" tabindex="9"> 
                                </td>
                              </tr>
                            </table></td>
                        </tr>
                      </table>
                    </div></td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
          <tr> 
            <td class="tdbottom" colSpan="2"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
  </table>
  <tr> 
    <input type='hidden' value='<%=Request.Form("hdnCapturaId")%>' name='hdnCapturaId'>
    <input type='hidden' value='<%=Request.Form("hdnProveedorId")%>' name='hdnProveedorId'>
    <input type='hidden' value='<%=Request.Form("hdnProveedorNombreId")%>' name='hdnProveedorNombreId'>
    <input type='hidden' value='<%=Request.Form("hdnArticuloEncontradoId")%>' name='hdnArticuloEncontradoId'>
    <input type='hidden' value='<%=Request.Form("hdnArticuloAnteriorId")%>' name='hdnArticuloAnteriorId'>
    <input type='hidden' value='<%=Request.Form("hdnArticulosCantidad")%>' name="hdnArticulosCantidad">
  </tr>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	var objCalendar1 = new calendar1(document.forms['frmMercanciaRemisionCompraDirectaCaptura'].elements['txtFechaRecepcion']);
    var objCalendar2 = new calendar1(document.forms['frmMercanciaRemisionCompraDirectaCaptura'].elements['txtFechaRemision']);
	//-->
			</script>
</form>
<iframe name="ifrOculto" width="0" height="0"></iframe>
</body>
</HTML>
