<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaPedidoDirectoMayoristaCaptura.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaPedidoDirectoMayoristaCaptura" codePage="28592" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaPedidoDirectoMayoristaCaptura.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Captura de Pedidos Directos al Mayorista 
    ' Copyright     : 2012 All rights reserved.
    ' Company       : Farmacias Benavides
    ' Author        : [JAHD] 
    ' Version       : 1.0
    ' Last Modified : 
    '                 24 de Febrero 2012 [JAHD] 
	'                 04 de Junio   2012 [JAHD] 
	'                 12 de Marzo   2013 [JAHD] Valida para venta garantizada registro en CTF
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
<script language="JavaScript" src="../static/scripts/cnfg.js"></script>
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
 
function blnDatosPedido() {
	//Validaciones
	var valida=true; 	
	
	//No de proveedor
	if(valida){ valida=blnValidarCampo(document.forms(0).elements("txtProveedorNombreId"),true,"No. de proveedor",cintTipoCampoAlfanumerico,15,1,""); } 
	if(valida){ if(document.forms[0].elements['hdnProveedorId'].value==0 || (document.forms[0].elements['hdnProveedorId'].value).length < 1){valida=false;} }
	return valida;  
}

function blnValidarCifraDeControl() {
	valida=true;
	if (valida){ valida=blnValidarCampo(document.forms(0).elements('txtCifraDeControl'),true,"Cifra de control",cintTipoCampoEntero,10,1,""); } 
	
	if (valida){	    
		intCifraControlSistema = document.forms[0].elements['hdnArticulosCantidad'].value * 1;
		
		if(intCifraControlSistema==0){
			alert('Agregue al menos un producto a el pedido.');
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

		blnmControlesEncabezadoHabilitados=true;		
		document.all.divBotones.style.display='none'; 
	}
	else {
		document.forms(0).elements('txtProveedorNombreId').readOnly=true;
		document.forms(0).elements('txtProveedorNombreId').className="campotabladeshabilitado";

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
   
   if (strProveedorCapturado.length > 0 && strProveedorCapturado!='0') {
      if (document.forms[0].elements['hdnProveedorNombreId'].value == document.forms[0].elements['txtProveedorNombreId'].value) {
	   document.forms[0].cboMotivoPedidoCompraDirecta.focus(); 
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
   
       Pop('PopPedidoDirectoMayoristaProveedor.aspx?'+strParametros+'&strEvalJs='+strEvalJs,500,540); 
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
       document.forms[0].elements['cboMotivoPedidoCompraDirecta'].focus();     
   }  
}	
function fnUpBuscarProveedor(intProveedorId,strProveedorNombreId,strProveedorRazonSocial, intError) {      
   document.forms[0].elements['hdnProveedorId'].value= intProveedorId;
   document.forms[0].elements['txtProveedorNombreId'].value= strProveedorNombreId;
   document.forms[0].elements['hdnProveedorNombreId'].value= strProveedorNombreId;
   document.forms[0].elements['txtRazonSocialProveedor'].value= strProveedorRazonSocial;
 
   if (intError == 0 ) {       
       document.forms[0].elements['cboMotivoPedidoCompraDirecta'].focus();       
   }
   else {       
       document.forms[0].elements['txtProveedorNombreId'].focus();
       alert("Error, Proveedor no encontrado");       
   }   
}

function cboMotivoPedidoCompraDirecta_onchange() {
    
	if (document.forms[0].elements['cboMotivoPedidoCompraDirecta'].value=='2') { 	
	    document.forms[0].elements['hdnValidaMotivo'].value = 1;
		document.forms[0].elements['txtCajaId'].value='';
		document.forms[0].elements['txtCajaId'].readOnly=false;
		document.forms[0].elements['txtCajaId'].className="campotabla";
		
	    document.forms[0].elements['txtTicketId'].value='';
		document.forms[0].elements['txtTicketId'].readOnly=false;
		document.forms[0].elements['txtTicketId'].className="campotabla";
		
	}
	else {
	    document.forms[0].elements['hdnValidaMotivo'].value = 0;
	    document.forms[0].elements['txtCajaId'].value='1';
		document.forms[0].elements['txtCajaId'].readOnly=true;
		document.forms[0].elements['txtCajaId'].className="campotablalectura";
		
	    document.forms[0].elements['txtTicketId'].value='1';
		document.forms[0].elements['txtTicketId'].readOnly=true;
		document.forms[0].elements['txtTicketId'].className="campotablalectura";		
    } 
}

function objLupaArticulo_onClick() { 
   var strArticulo;
   var intCuentaApostrofes;
   
   if (document.forms[0].txtArticuloId.value == "") {return(true);}
   
    // Es necesario tener del numero de proveedor 
   valida =blnDatosPedido();
   if(valida==false){  alert("Capturar el proveedor"); return(false); }
	
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
			document.forms(0).txtClaveVigenciaArticuloNombre.value='';
			document.forms(0).txtEstacionalidadArticuloDescripcion.value='';
			document.forms(0).txtTipoAbastoArticuloDescripcion.value='';                        
			document.forms(0).hdnArticuloAutorizado.value ='0';			
			document.all.divProveedorAutorizado.innerHTML = '';
			
			strEvalJs="opener.fnUpLupaArticulo();"; 
			 
			strParametros='';
			strParametros = strParametros + 'campoArticuloId=txtArticuloId';
			strParametros = strParametros + '&campoArticuloDescripcion=txtDescripcionArticulo';
			
            strParametros = strParametros + '&campoClaveVigenciaArticuloId=hdnClaveVigenciaArticuloId';
            strParametros = strParametros + '&campoClaveVigenciaArticuloNombre=txtClaveVigenciaArticuloNombre';
			 
            strParametros = strParametros + '&campoEstacionalidadArticuloId=hdnEstacionalidadArticuloId';
            strParametros = strParametros + '&campoEstacionalidadArticuloDescripcion=txtEstacionalidadArticuloDescripcion';
			
            strParametros = strParametros + '&campoTipoAbastoArticuloId=hdnTipoAbastoArticuloId';
            strParametros = strParametros + '&campoTipoAbastoArticuloDescripcion=txtTipoAbastoArticuloDescripcion';

            strParametros = strParametros + '&campoProveedoresAutorizadosNo=hdnProveedoresAutorizadosNo';
            strParametros = strParametros + '&campoArticuloAutorizado=hdnArticuloAutorizado';			
																	
            strParametros = strParametros + '&strArticuloIdNombre=' + document.forms[0].txtArticuloId.value;
            strParametros = strParametros + '&intProveedorId=' + document.forms[0].elements['hdnProveedorId'].value;
			
			Pop('PopPedidoDirectoMayoristaArticulo.aspx?'+strParametros+'&strEvalJs='+strEvalJs,500,540);			
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
       document.forms[0].action = "<%=strFormAction%>?strCmd=BuscarProveedorAutorizado&strArticuloStock=" + document.forms(0).txtArticuloId.value;
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';     
   }  
}

function fnUpdProveedorAutorizadoPorIframe (strRecordBrowserProveedorAutorizadoHTML) {
   document.all.divProveedorAutorizado.innerHTML = strRecordBrowserProveedorAutorizadoHTML;
   document.forms(0).txtCantidad.focus();   
}

function fnUpdArticuloPorIframe(strArticuloId,strDescripcionArticulo,
                       strClaveVigenciaArticuloId,  strClaveVigenciaArticuloNombre,
                       strEstacionalidadArticuloId, strEstacionalidadArticuloDescripcion,
                       strTipoAbastoArticuloId,     strTipoAbastoArticuloDescripcion,
					   strProveedoresAutorizadosNo, strRecordBrowserProveedorAutorizadoHTML,
                       strArticuloAutorizado,
                       intError) {
					   
	document.forms(0).txtArticuloId.value = strArticuloId;
	document.forms(0).hdnArticuloEncontradoId.value = document.forms(0).txtArticuloId.value;
	document.forms(0).txtDescripcionArticulo.value = strDescripcionArticulo;

    document.forms(0).hdnClaveVigenciaArticuloId.value = strClaveVigenciaArticuloId;
	document.forms(0).txtClaveVigenciaArticuloNombre.value = strClaveVigenciaArticuloNombre;
	
    document.forms(0).hdnEstacionalidadArticuloId.value = strEstacionalidadArticuloId;
	document.forms(0).txtEstacionalidadArticuloDescripcion.value = strEstacionalidadArticuloDescripcion;	

    document.forms(0).hdnTipoAbastoArticuloId.value = strTipoAbastoArticuloId;
	document.forms(0).txtTipoAbastoArticuloDescripcion.value = strTipoAbastoArticuloDescripcion;
	
    document.forms(0).hdnProveedoresAutorizadosNo.value = strProveedoresAutorizadosNo;    	
    document.forms(0).hdnArticuloAutorizado.value = strArticuloAutorizado;
    
    document.all.divProveedorAutorizado.innerHTML = strRecordBrowserProveedorAutorizadoHTML;
		
	if(intError!=0) {
		alert('Artículo no encontrado');
		document.forms[0].elements['txtArticuloId'].focus(); 
    }   
	else {
	    document.forms(0).txtCantidad.focus();
	} 
}

function txtCantidad_onfocus() {
   document.forms[0].txtCantidad.select(); 
   return(true);
}

// Agrega el Articulo capturado al detalle del pedido 
function cmdAgregar_onclick() {
  var valida=true;
  
   //Validaciones
   valida = blnDatosPedido(); 
   if(valida==false){ return(false); }
   
   //Codigo 
   if(valida) {	       
       if (document.forms(0).txtArticuloId.value != document.forms(0).hdnArticuloEncontradoId.value)  {
       alert("Capturar correctamente el articulo a ingresar");
       document.forms[0].txtArticuloId.focus();        
       return(false);
       }
   }          
   
   // Autorizado al proveedor
   if(valida) {	       
       if (document.forms(0).hdnArticuloAutorizado.value != '1')  {
       alert("Articulo no empatado con el proveedor indicado");
       document.forms[0].txtArticuloId.focus();        
       return(false);
       }
   }  
   
   // Validacion proveedor cel
   if(valida) {	       
       if (document.forms(0).txtProveedorNombreId.value == '110215Z3' && document.forms(0).hdnTipoAbastoArticuloId.value != 2)  {
       alert("Articulo no se puede pedir al almacen");
       document.forms[0].txtArticuloId.focus();        
       return(false);
       }
   }
   
   if (parseInt(document.forms[0].elements["cboMotivoPedidoCompraDirecta"].value) <= 0){
        alert("Capturar correctamente el motivo");
        document.forms[0].cboMotivoPedidoCompraDirecta.focus();        
        return(false);
   }
   
   // Validamos que la cantidad sea un campo entero
   if (valida){valida=blnValidarCampo(document.forms['frmMercanciaPedidoDirectoMayoristaCaptura'].elements['txtCantidad'],true,"Cantidad", cintTipoCampoEntero,20,1,""); }
   
   if (!valida){return(valida);}
      
   // Cantidad que sea mayor a cero
   if (parseInt(document.forms['frmMercanciaPedidoDirectoMayoristaCaptura'].elements['txtCantidad'].value) <= 0){
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
function cmdEliminar_onclick(intMotivoPedidoCompraDirectaEliminarId, intCajaEliminarId, intTicketEliminarId, intArticuloEliminar){
    document.forms[0].action = "<%=strFormAction%>?strCmd=EliminarArticulo" + "&intMotivoPedidoCompraDirectaEliminarId=" + intMotivoPedidoCompraDirectaEliminarId + "&intCajaEliminarId=" + intCajaEliminarId + "&intTicketEliminarId=" + intTicketEliminarId + "&intArticuloEliminarId=" + intArticuloEliminar; 
    document.forms[0].target="ifrOculto";
    DoSubmit();
    document.forms[0].target='';    
}

function fnUpAgregarEliminarArticulo(intAccion, intPedidoCompraDirectaId, strRecordBrowserHTML, intTotalArticulosPedido, intError){

    document.all.divDetalle.innerHTML = strRecordBrowserHTML;	
	document.forms[0].elements['hdnCapturaId'].value = intPedidoCompraDirectaId;
	document.forms[0].elements['hdnArticulosCantidad'].value = intTotalArticulosPedido;

    if (intTotalArticulosPedido < 1) {
          fnHabilitaDeshabilitaControlesEncabezado(true); //Habiliar cuando no hay articulos  
    } 
    else {
           fnHabilitaDeshabilitaControlesEncabezado(false); //Deshabilita si ya hay articulos 
    }
        
    if (intError == 0) {
                        document.forms(0).txtArticuloId.value = '';
	                document.forms(0).txtDescripcionArticulo.value = '';	   
   			document.forms(0).txtClaveVigenciaArticuloNombre.value='';
			document.forms(0).txtEstacionalidadArticuloDescripcion.value='';
			document.forms(0).txtTipoAbastoArticuloDescripcion.value='';
			document.forms(0).hdnArticuloAutorizado.value ='0';	          
	                document.forms(0).txtCantidad.value = '';	
	                document.all.divProveedorAutorizado.innerHTML = '';	
	}
	else {   
       if (intAccion == 1) { // Agregar Articulo
           if (intError==-100) {
               alert("ERROR, Articulo no pudo Agregarse");
		   }
		   if (intError==-200) {
		       alert ("Articulo no registrado en Ticket de venta CTF");
		   }
		   if (intError==-210) {
		       alert ("Cantidad de Articulo en el pedido es mayor a la registrada en Ticket de venta CTF");
		   }
       }
       if (intAccion == 2) { // Eliminar Articulo
           alert("ERROR, Articulo no pudo Eliminarse");
       }
   }
   
   document.forms(0).cboMotivoPedidoCompraDirecta.options[0].selected=true;
   document.forms(0).cboMotivoPedidoCompraDirecta.focus();	
}


function cmdRegresar_onClick() {
   window.location.href = "MercanciaEntradas.aspx";  
   return(true);
}


// Registrar compra Directa
function cmdRegistrar_onClick(){
    //Validaciones
	valida = blnDatosPedido(); 
	
    if(valida){ valida=blnValidarCifraDeControl(); }
    
    if(valida){
		document.forms[0].action = "<%=strFormAction%>?strCmd=Registrar"; 
        document.forms[0].target="ifrOculto";
        DoSubmit();
        document.forms[0].target='';
	}
	
   return(true);   
}

// Despliega el Folio asignado a el Pedido de Compra Directa
function fnUpRegistrarPedidoCompraDirecta(intPedidoCompraDirectaId, intError) {
   if (intError==0) {
       strParametros = "?strPaginapadre=Captura"
       strParametros = strParametros + '&intPedidoCompraDirectaId=' + intPedidoCompraDirectaId ;

       window.location.href = "MercanciaPedidoDirectoMayoristaDetalle.aspx" + strParametros;       
   }
   else { 
         alert ("No se registro el pedido de compra, verifique los datos y reintente");
   }
}  

function window_onload() {

    <%=strLlenarMotivoPedidoCompraDirectaComboBox%>
	
    blnValidaCobroCTF = window.blnValidaCobroCTF ? window.blnValidaCobroCTF : false;
	
    if (blnValidaCobroCTF == true) {
		document.forms[0].elements['hdnValidaCTF'].value = 1;
	}
	else {
	    document.forms[0].elements['hdnValidaCTF'].value = 0;
	}	
    
	document.forms[0].elements['txtFechaRegistro'].value = "<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy") %>";
    
	if(document.forms[0].elements['hdnArticulosCantidad'].value==0 || (document.forms[0].elements['hdnArticulosCantidad'].value).length < 1){
        fnHabilitaDeshabilitaControlesEncabezado(true);
		document.forms[0].elements['txtProveedorNombreId'].focus();
	}
	else {
        fnHabilitaDeshabilitaControlesEncabezado(false);
		document.forms[0].elements['cboMotivoPedidoCompraDirecta'].focus();
	}
      
    return(true);                      
}

function cmdonKeyPressed(intObjeto,tecla) {
 if (tecla == 13 || tecla==9) { 
       if (intObjeto==1) { //proveedor
       document.forms(0).imgLupaProveedor.focus();     
       }
	   if (intObjeto==2) {//motivo
	   
	       if (document.forms[0].elements['cboMotivoPedidoCompraDirecta'].value=='2') { // Venta garantizada
		       document.forms(0).txtCajaId.focus(); 
		   }
		   else {
		       document.forms(0).txtArticuloId.focus();
		   }          
       }
	   if (intObjeto==3) {//caja
       document.forms(0).txtTicketId.focus();    
       }	   
	   if (intObjeto==4) {//ticket
       document.forms(0).txtArticuloId.focus();    
       }
	   if (intObjeto==5) {//articulo
       document.forms(0).txtCantidad.focus();      
       }	   
       if (intObjeto==6) {//cantidad
           document.forms(0).cmdAgregar.focus();     
       }      
	   if (intObjeto==7) {//cifra control
           document.forms(0).cmdRegistrar.focus();     
       }   
       event.returnValue = false;      
   }  
}


function cmdEjecutarLupa(intObjeto) { 
       if (intObjeto==1) {
       objLupaProveedor_onclick();      
       }
	   if (intObjeto==2) {
        objLupaArticulo_onClick();
       }     
}
//-->
</script>
</HEAD>
<body leftMargin="0" topMargin="0" onload="return window_onload()" marginwidth="0" marginheight="0">
<form name="frmMercanciaPedidoDirectoMayoristaCaptura" action="about:blank" method="post">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="34"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td > <table width="780" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgColor="#ffffff"> <img height="8" src="../static/images/pixel.gif" width="10"></td>
            <td class="tdmigaja" width="583"><span class="txdmigaja">Está en : 
              </span><a class="txdmigaja" href="Mercancia.aspx"> Mercancía</a> 
              <span class="txdmigaja">: <a class="txdmigaja" href="MercanciaPedidoDirectoMayorista.aspx"> 
              Pedido Directo Mayoristas</a></span><span class="txdmigaja"> </span><span class="txdmigaja">: 
              </span><span class="txdmigaja"> </span><span class="txdmigaja"></span><span class="txdmigaja">Capturar 
              Pedido</span></td>
            <td class="tdfechahora" width="182"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td vAlign="top" width="583"> <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtablacont" vAlign="top" width="100%"> <table width="100%" cellSpacing="0" cellPadding="0" border="0">
                      <tr> 
                        <td class="tdtittablas3" vAlign="middle" align="right" width="80%">Folio: 
                        </td>
                        <td class="txtitintabla" vAlign="middle" width="20%"><input class="campotabladeshabilitado" readOnly type="text" size="16" name="txtIntFolioCDI"></td>
                      </tr>
                    </table>
                    <br> <table width="100%" class="tdenvolventetablas">
                      <tr> 
                        <td class="tdtittablas3" width="20%">Fecha Registro</td>
                        <td class="tdtittablas3" align="left" width="30%">Proveedor</td>
                        <td class="tdtittablas3" align="left" width="50%">Razon 
                          Social</td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3" align="left" width="20%"><input name="txtFechaRegistro"  id="txtFechaRegistro"  readOnly type="text" class="campotabla" size="10" maxlength="10" > 
                          <img src="../static/images/icono_calendario.gif" width="20" height="13" align="absMiddle" border="0" ></td>
                        <td class="tdtittablas3" align="left" width="30%"><input name="txtProveedorNombreId" id="txtProveedorNombreId" type="text" class="campotabla"  autocomplete="off" size="16" maxlength="16" onkeypress="cmdonKeyPressed(1,event.keyCode);" value='<%=Request.Form("txtProveedorNombreId")%>' tabindex="1"  onBlur="cmdEjecutarLupa(1);" > 
                          &nbsp;<a id="objLupaProveedor" onclick="return objLupaProveedor_onclick()"><img  name="imgLupaProveedor" src="../static/images/icono_lupa.gif" width="17" height="17" align="absMiddle" border="0" tabindex="2" ></a></td>
                        <td class="tdtittablas3" align="left" width="50%"><input name="txtRazonSocialProveedor" id="txtRazonSocialProveedor" type="text" class="campotablaresultadoenvolventeazul" value='<%=Request.Form("txtRazonSocialProveedor")%>' size="38" maxlength="50"  border="0" readonly tabindex="-1"></td>
                      </tr>
                    </table>
                    <span class="txsubtitulo"><br>
                    <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Detalle 
                    Pedido <br>
                    <div id="divDetalle" name="divDetalle"></div>
                    </span> <br> <table class="tdenvolventetablas" width="100%">
                      <tr> 
                        <td class="tdtittablas3" align="left" width="10%">Motivo</td>
                        <td class="tdtittablas3" align="left" width="20%">Caja-Ticket</td>
                        <td class="tdtittablas3" align="left" width="20%">Código</td>
                        <td class="tdtittablas3" align="left" width="30%">Descripción</td>
                        <td class="tdtittablas3" align="left" width="10%">Cantidad</td>
                        <td class="tdtittablas3" align="center" width="10%" vAlign="middle" rowspan="2"> 
                          <input class="boton" id="cmdAgregar" onclick="return cmdAgregar_onclick()" type="button"
																value="Agregar" name="cmdAgregar" tabindex="9"> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdconttablas" width="10%" > <select name="cboMotivoPedidoCompraDirecta" class="campotabla" id="cboMotivoPedidoCompraDirecta" onkeypress="cmdonKeyPressed(2,event.keyCode);"  onChange="return cboMotivoPedidoCompraDirecta_onchange()"tabindex="3">
                            <option value="0" selected>-Seleccionar-</option>
                            <option>-------------</option>
                          </select></td>
                        <td class="tdconttablas" width="20%"><input class="campotablahabilitadoderecha" id="txtCajaId" maxLength="02" size="01" name="txtCajaId" autocomplete="off" onkeypress="cmdonKeyPressed(3,event.keyCode);" tabindex="4"> 
                          <input class="campotablahabilitadoderecha" id="txtTicketId" maxLength="8" size="4" name="txtTicketId" autocomplete="off" onkeypress="cmdonKeyPressed(4,event.keyCode);" tabindex="5"></td>
                        <td align="left" width="20%" class="txtitintabla"> <input class="campotablahabilitadoderecha" id="txtArticuloId" 
																onFocus="return txtArticuloId_onfocus()" type="text" maxlength="16" size="6" name="txtArticuloId"
																autocomplete="off" onKeyPress="cmdonKeyPressed(5,event.keyCode);" tabindex="6" onBlur="cmdEjecutarLupa(2);"   > 
                          <a id="objLupaArticulo" onclick="return objLupaArticulo_onClick();" > 
                          <img  name="imgLupaArticulo" height="17" src="../static/images/icono_lupa.gif" width="16" align="absMiddle" border="0" tabindex="7"></a></td>
                        <td class="txtitintabla" vAlign="middle" width="30%"> 
                          <input class="campotablaresultadoenvolventeazul" readOnly type="text" size="17" name="txtDescripcionArticulo" tabindex="-1"> 
                        </td>
                        <td class="tdpadleft5" vAlign="middle" align="left" width="10%"> 
                          <input class="campotablahabilitadoderecha" id="txtCantidad" 
																onfocus="return txtCantidad_onfocus()" type="text" maxLength="8" size="04" name="txtCantidad"
																autocomplete="off" onkeypress="cmdonKeyPressed(6,event.keyCode);" tabindex="8"> 
                        </td>
                      </tr>
                      <tr> 
                        <td colspan="6" valign="top" > <table class="tdenvolventetablas" width="100%" border="0" cellpadding="0" cellspacing="0" >
                            <tr> 
                              <td width="30%"> <table width="100%" border="0" cellpadding="0" cellspacing="0" height="120">
                                  <tr> 
                                    <td class="tdtittablas3" align="left" width="10%">Estado</td>
                                    <td class="txtitintabla" vAlign="middle" width="30%"> 
                                      <input type='hidden' value='<%=Request.Form("hdnClaveVigenciaArticuloId")%>' name='hdnClaveVigenciaArticuloId'> 
                                      <input class="campotablaresultadoenvolventeazul" readOnly type="text" name="txtClaveVigenciaArticuloNombre" tabindex="-1" size="15"> 
                                    </td>
                                  </tr>
                                  <tr> 
                                    <td class="tdtittablas3" align="left" width="10%">Estacionalidad</td>
                                    <td class="txtitintabla" vAlign="middle" width="30%"> 
                                      <input type='hidden' value='<%=Request.Form("hdnEstacionalidadArticuloId")%>' name='hdnEstacionalidadArticuloId'> 
                                      <input class="campotablaresultadoenvolventeazul" readOnly type="text" name="txtEstacionalidadArticuloDescripcion" tabindex="-1" size="15"> 
                                    </td>
                                    <td class="txtitintabla" vAlign="middle" width="60%" height="5" rowspan="2"> 
                                      <input type='hidden' value='<%=Request.Form("hdnArticuloAutorizado")%>' name='hdnArticuloAutorizado'> 
                                      <input type='hidden' value='<%=Request.Form("hdnProveedoresAutorizadosNo")%>' name='hdnProveedoresAutorizadosNo'> 
                                    </td>
                                  </tr>
                                  <tr> 
                                    <td class="tdtittablas3" align="left" width="10%" valign="top">Abastos</td>
                                    <td class="txtitintabla" vAlign="top" width="30%" > 
                                      <input type='hidden' value='<%=Request.Form("hdnTipoAbastoArticuloId")%>' name='hdnTipoAbastoArticuloId'> 
                                      <input class="campotablaresultadoenvolventeazul" readOnly type="text" name="txtTipoAbastoArticuloDescripcion" tabindex="-1" size="10"> 
                                    </td>
                                  </tr>
                                </table></td>
                              <td width="70%" valign="top"><div id="divProveedorAutorizado" name="divProveedorAutorizado"></div></td>
                            </tr>
                          </table></td>
                      </tr>
                    </table>
                    <br> <div id="divBotones" style="DISPLAY: none"> 
                      <table id="TblBotones" cellSpacing="0" cellPadding="0" width="100%" border="0">
                        <tr> 
                          <td width="317">&nbsp;&nbsp; <input class="boton" onclick="return cmdRegresar_onClick()" type="button" value="Regresar" name="cmdRegresar" tabindex="-1"> 
                          </td>
                          <td class="tdenvolventetablas" align="center" width="200" bgColor="#f4f6f8"> 
                            <table cellSpacing="0" cellPadding="0" width="230" border="0">
                              <tr> 
                                <td class="tdtittablas3" width="156">Cifra de 
                                  control</td>
                                <td width="91" rowSpan="2"><input class="boton" onClick="return cmdRegistrar_onClick()" type="button" value="Registrar"
																		name="cmdRegistrar" tabindex="11"> 
                                </td>
                              </tr>
                              <tr> 
                                <td vAlign="top" height="30"><input class="campotabla" onKeyPress="cmdonKeyPressed(7,event.keyCode);" type="text" maxlength="4"
																		size="16" name="txtCifraDeControl" tabindex="10"> 
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
    <input type="hidden" value='<%=Request.Form("hdnArticulosCantidad")%>' name="hdnArticulosCantidad">
    <input type="hidden" value='<%=Request.Form("hdnValidaCTF")%>' name="hdnValidaCTF">
    <input type="hidden" value='<%=Request.Form("hdnValidaMotivo")%>' name="hdnValidaMotivo">
  </tr>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
			</script>
</form>
<iframe name="ifrOculto" width="0" height="0"></iframe>
</body>
</HTML>
