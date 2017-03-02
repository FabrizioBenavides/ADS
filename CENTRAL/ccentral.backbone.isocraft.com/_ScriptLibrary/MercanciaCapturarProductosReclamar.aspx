<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaCapturarProductosReclamar.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaCapturarProductosReclamar" codePage="28605"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaCapturarProductosReclamar.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Benavides
    ' Author        : J.Antonio
    ' Version       : 1.0
    ' Last Modified : 27-Oct-2006
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<meta content="Javascript Menu" name="description">
<meta content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control" name="keywords">
<LINK href="../static/css/menu.css" rel="stylesheet">
<LINK href="../static/css/menu2.css" rel="stylesheet">
<LINK href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--




//Variables Globales
blnmControlesEncabezadoHabilitados=true;

var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";
	
function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
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

function strHrefMigaja1(){
	document.location.href='Mercancia.aspx';
}
function strHrefMigaja2(){
	document.location.href='CCRedirectorPOSAdmin.aspx?strPageName=MercanciaEntradas.aspx';
}
function strHrefMigaja3(){
	document.location.href='CCRedirectorPOSAdmin.aspx?strPageName=MercanciaEntradasReclamaciones.aspx';
}
function strHrefMigaja4(){
	document.location.href='';
}
function strTituloMigaja1(){
	document.write("Mercancía");
}
function strTituloMigaja2(){
	document.write("Entradas");
}
function strTituloMigaja3(){
	document.write("Reclamación de mercancía");
}
function strTituloPrincipalDePagina() {
	document.write("Capturar reclamaciones");
}
function strDescripcionPrincipalDePagina() {
	document.write("Capture el proveedor al que se están reclamando productos, y luego capture los artículos en reclamación.");
}

function fnHabilitaDeshabilitaControlesEncabezado(blnHabilitar){
	if(blnHabilitar) {	
		document.forms(0).elements('txtFechaDeReclamacion').readOnly=false;
		document.forms(0).elements('txtFechaDeReclamacion').className="campotabla";
		document.forms(0).elements('cmbMotivo').disabled=false;
		document.forms(0).elements('cmbMotivo').className="campotabla";
		document.forms(0).elements('cboDepartamentos').disabled=false;
		document.forms(0).elements('cboDepartamentos').className="campotabla";
		document.forms(0).elements('rdoTipoProveedor1').disabled=false;
		document.forms(0).elements('rdoTipoProveedor2').disabled=false;		
		document.forms(0).elements('txtProveedor').readOnly=false;
		document.forms(0).elements('txtProveedor').className="campotabla";
		document.forms(0).elements('txtNumeroFactura').readOnly=false;
		document.forms(0).elements('txtNumeroFactura').className="campotabla";
    	document.forms(0).elements('txtNoDeDocumento').readOnly=false;
		document.forms(0).elements('txtNoDeDocumento').className="campotabla";		
		blnmControlesEncabezadoHabilitados=true;
		
		document.all.divBotones.style.display='none'; 
	}
	else {

		document.forms(0).elements('txtFechaDeReclamacion').readOnly=true;
		document.forms(0).elements('txtFechaDeReclamacion').className="campotabladeshabilitado";
		document.forms(0).elements('cmbMotivo').disabled=true;
		document.forms(0).elements('cmbMotivo').className="campotabladeshabilitado";
		document.forms(0).elements('cboDepartamentos').disabled=true;
		document.forms(0).elements('cboDepartamentos').className="campotabladeshabilitado";		
     	document.forms(0).elements('rdoTipoProveedor1').disabled=true;
		document.forms(0).elements('rdoTipoProveedor2').disabled=true;
		document.forms(0).elements('txtProveedor').readOnly=true;
		document.forms(0).elements('txtProveedor').className="campotabladeshabilitado";
		document.forms(0).elements('txtNumeroFactura').readOnly=true;
		document.forms(0).elements('txtNumeroFactura').className="campotabladeshabilitado";		
		document.forms(0).elements('txtNoDeDocumento').readOnly=true;
		document.forms(0).elements('txtNoDeDocumento').className="campotabladeshabilitado";
		blnmControlesEncabezadoHabilitados=false;
		
		document.all.divBotones.style.display=''; 
	}
}

function blnValidarCifraDeControl(){
	valida=true;
	if (valida){ valida=blnValidarCampo(document.forms(0).elements('txtCifraDeControl'),true,"Cifra de control",cintTipoCampoEntero,10,1,""); } 
	
	if (valida){
	    
		TotalDePartidas = document.forms[0].elements['hdnTotalArticulosReclamacion'].value;
		TotalDePartidas = TotalDePartidas * 1
		
		if(TotalDePartidas==0){
			alert('Agregue al menos un producto a la reclamación.');
			document.forms(0).txtIntArticuloId.focus();
			document.forms(0).txtIntArticuloId.select();
			valida=false;
			return(valida);
		}
		
		//La suma de todas las partidas debe ser igual a la cifra de control
		intTotal = 0;
		for (i = 1;  i < (TotalDePartidas+1);  i++) {
			intTotal = (intTotal*1) + (document.forms(0).elements('txtCantidad_'+i).value * 1);
		}
		
		inttxtCifraDeControl = (document.forms(0).elements('txtCifraDeControl').value) * 1;
		
		if(inttxtCifraDeControl==intTotal){
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

//Habilitar Controles y hacer submit
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

function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
		
	<%=strGeneraComboDepartamento()%>
	//Generar lista con motivos de reclamaciones
	<%=strGeneraListaMotivosDeReclamacion("cmbMotivo")%>
	

	<%if strCmbMotivo<>"" then%>
	document.forms[0].elements['cmbMotivo'].value='<%=strCmbMotivo%>';
	<%end if%>
	
	var strRdoTipoProveedor = "<%=Lcase(strRdoTipoProveedor)%>"
	if(strRdoTipoProveedor=="proveedordirecto"){ document.forms[0].elements['rdoTipoProveedor1'].checked=true; }
	if(strRdoTipoProveedor=="proveedormayorista"){ document.forms[0].elements['rdoTipoProveedor2'].checked=true; }

	if(document.forms[0].elements['hdnTotalArticulosReclamacion'].value==0){
        fnHabilitaDeshabilitaControlesEncabezado(true);
		document.forms[0].elements['txtFechaDeReclamacion'].focus();
	}
	else {
        fnHabilitaDeshabilitaControlesEncabezado(false);
		document.forms[0].elements['txtIntArticuloId'].focus();
	}
			
	return(true);
}

function cmdRegresar_onclick() {
	strHrefMigaja3();
}

function cmdImprimir_onclick() {
    intValor = (document.forms(0).elements('txtReclamacionFolio').value) * 1;
	
	if(intValor>0) {
	
	if (window.print) {
        document.ifrPageToPrint.document.all.ToPrintTxtMigaja.innerHTML   =document.all.ToPrintTxtMigaja.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtFecha.innerHTML    =document.all.ToPrintTxtFecha.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtSucursal.innerHTML =document.all.ToPrintTxtSucursal.innerText;
        document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML=document.all.ToPrintHtmContenido.innerHTML;
        
        //Ocultar 
        document.ifrPageToPrint.document.all.divCapturaDeProductos.style.display='none';
		document.ifrPageToPrint.document.all.divBotones.style.display='none';
		        
        //Mostrar Tabla de firmas
        document.ifrPageToPrint.document.all.divFirmasHTML.style.display='';
        
        document.ifrPageToPrint.focus();
        window.print();        
    } else {
        alert("Tu navegador no soporta la función: Print.")
    }
    }
}

function cmdOtraReclamacion_onclick(){
  window.location = "MercanciaCapturarProductosReclamar.aspx";
  return(true);
}

// Mandar ventana de consulta
function Pop(url, width, height) {
    var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	return(false);
}

function DoObjCalendar1(){
	if(document.forms(0).elements('txtFechaDeReclamacion').readOnly==false){
		objCalendar1.popup()
	}
}

function fnUpdCboDepartamentos(strCase){
	TotalDePartidas = document.forms[0].elements['hdnTotalArticulosReclamacion'].value;
	TotalDePartidas = TotalDePartidas * 1

	if(TotalDePartidas<1){
		document.forms(0).cboDepartamentos.value = 0;
		if(strCase=='AgregarArticulo'){
			document.forms(0).cboDepartamentos.value = document.forms(0).hdnDepartamentos.value;
		}
	}
	else{
		if((document.forms(0).hdnDepartamentos.value * 1)>0){
			document.forms(0).cboDepartamentos.value = document.forms(0).hdnDepartamentos.value;
		}
		if(strCase=='EliminarArticulo' && TotalDePartidas==1){
			// Si es Borrar, Mandar cero Si solo hay una partida
			document.forms(0).cboDepartamentos.value = 0;
		}
	}
}

function strNombreDelDepartamento(){ 
	document.write("<%=strTextoSeleccionadoEnCboDepartamento%>");
}

// Buscar por Número de proveedor
function cmdBuscarProveedor_onClick(url, width, height) {
         var strTipoProveedor
         
         // Esta seleccionado el proveedor directo 
         if (document.forms(0).elements('rdoTipoProveedor1').checked){
             strTipoProveedor = "ProveedorDirecto";
             }

         // Esta seleccionado el proveedor mayorista
         if (document.forms(0).elements('rdoTipoProveedor2').checked){
             strTipoProveedor = "ProveedorMayorista";
           }

          url=url+'&strProveedorId='+document.forms[0].elements['txtProveedor'].value + '&strTipoProveedorNombreId=' + strTipoProveedor;

          return Pop(url, width, height);
}

// Lupa para listar proveedores
function objLupaProveedor_onClick(){

	if (document.forms[0].elements['txtProveedor'].value!="")
	    {
         if (!isNaN(document.forms[0].elements['txtProveedor'].value))
             {
			   if (document.forms[0].elements['txtProveedor'].value != '0')
			      {
			       document.forms[0].action = "<%=strFormAction%>?strCmd=BuscarProveedor";
			       document.forms[0].target="ifrOculto";
			       DoSubmit()
			       document.forms[0].target='';
			       return(true);
     		      }
			    else 
			        { 
				     //el valor es cero  		 
				     document.forms[0].elements['txtProveedor'].value='';
				     document.forms[0].elements['txtRazonSocialProveedor'].value=''; 
				     strEvalJs='';
				     cmdBuscarProveedor_onClick('PopProveedor.aspx?strProveedor=txtProveedor&strNombreProveedorId=txtRazonSocialProveedor'+'&strEvalJs='+strEvalJs,500,540);
			       }
			    return(false);
	         }
	      else{ 
		   	  document.forms[0].elements['txtRazonSocialProveedor'].value='';

			  strEvalJs='opener.fnBusquedaProveedorPorIframe();';
			  cmdBuscarProveedor_onClick('PopProveedor.aspx?strProveedor=txtProveedor&strNombreProveedorId=txtRazonSocialProveedor'+'&strEvalJs='+strEvalJs,500,540);
	          }
	       }
	else{
		alert("Teclear Número de proveedor o descripción");
		document.forms[0].elements['txtProveedor'].focus();
        return(false);
	    }
}


// Lupa para listar articulos
function objLupaArticulo_onClick(){ 
    // Es necesario tener los datos de la reclamación
	// el numero de proveedor 
	valida =blnDatosReclamacion();
	if(valida==false){ return(false); }
	
   valida= blnValidarCampo(document.forms(0).elements("txtProveedor"),true,"No. de proveedor",cintTipoCampoEntero,15,1,"");
   if(valida==false){ return(false); }
   	
	if (document.forms(0).elements('txtIntArticuloId').value!="")
	    {
         if (!isNaN(document.forms(0).elements('txtIntArticuloId').value))
             {
			   if (document.forms(0).elements('txtIntArticuloId').value != '0')
			      {
			       document.forms(0).action = "<%=strFormAction%>?strCmd=BuscarArticulo";
			       document.forms(0).target="ifrOculto";
				   DoSubmit();
				   document.forms(0).target='';
			       return(true);
     		      }
			    else 
			        { 
				     //el valor es cero  		     
				     document.forms(0).elements('txtIntArticuloId').value='';
				     document.forms(0).elements('txtStrArticuloDescripcion').value=''; 
				     
				     
				     strEvalJs="if(opener.document.forms[0].txtIntArticuloId.value!='0'){opener.objLupaArticulo_onClick()}";
				     
				     
				     strTemporal='0';
				     if(document.forms(0).elements('rdoTipoProveedor1').checked){
				        strTemporal = document.forms(0).elements('rdoTipoProveedor1').value;
				     }
				     if(document.forms(0).elements('rdoTipoProveedor2').checked){
				        strTemporal = document.forms(0).elements('rdoTipoProveedor2').value;
				     }
				     
				     strParametros='';
				     strParametros=strParametros + '?hdnArticulosCompletos=1'
				     strParametros=strParametros + '&strArticuloIdNombre=' + document.forms(0).elements('txtIntArticuloId').value;
				     strParametros=strParametros + '&intProveedorId=' + document.forms(0).elements['txtProveedor'].value;

					 strParametros=strParametros + '&intTipoProveedorId=' + strTemporal;
					 strParametros=strParametros + '&intDepartamentoId='  + document.forms(0).elements['cboDepartamentos'].value;
				     strParametros=strParametros + '&objIntArticuloId=txtIntArticuloId' 
				     strParametros=strParametros + '&objStrArticuloDescripcion=txtStrArticuloDescripcion' 
				     strParametros=strParametros + '&objIntDepartamentoId=cboDepartamentos' 
				     strParametros=strParametros + '&objFltArticuloSucursalCostoReposicion=' 
				     
				     Pop('PopArticuloProveedor.aspx'+strParametros+'&strEvalJs='+strEvalJs,500,540);
			       }
			    return(false);
	         }
	      else{ 
           	   	  document.forms(0).elements('txtStrArticuloDescripcion').value=''; 			      			      
			      			  
		          strTemporal='0';
		          if(document.forms(0).elements('rdoTipoProveedor1').checked){
		            strTemporal = document.forms(0).elements('rdoTipoProveedor1').value;
		          }
		          if(document.forms(0).elements('rdoTipoProveedor2').checked){
		            strTemporal = document.forms(0).elements('rdoTipoProveedor2').value;
		          }
		          		          
	              strParametros='';
		          strParametros=strParametros + '?hdnArticulosCompletos=1'
		          strParametros=strParametros + '&strArticuloIdNombre=' + document.forms(0).elements('txtIntArticuloId').value;
		          strParametros=strParametros + '&intProveedorId=' + document.forms(0).elements['txtProveedor'].value;
		          strParametros=strParametros + '&intTipoProveedorId=' + strTemporal;
		          strParametros=strParametros + '&intDepartamentoId=' + document.forms(0).elements['cboDepartamentos'].value;
		          strParametros=strParametros + '&objIntArticuloId=txtIntArticuloId' 
		          strParametros=strParametros + '&objStrArticuloDescripcion=txtStrArticuloDescripcion' 
		          strParametros=strParametros + '&objIntDepartamentoId=cboDepartamentos' 
		          strParametros=strParametros + '&objFltArticuloSucursalCostoReposicion=' 
		          
		          strEvalJs="if(opener.document.forms[0].txtIntArticuloId.value!='0'){opener.objLupaArticulo_onClick();}";
		          		          
		          Pop('PopArticuloProveedor.aspx'+strParametros+'&strEvalJs='+strEvalJs,500,540);
	          }
	       }
	else{
		alert("Teclear número de artículo o descripción");
		document.forms(0).elements('txtIntArticuloId').focus();
        return(false); 
	    }
}

function txtProveedor_onKeyDown() {
	if(event.keyCode==13){ txtProveedor_onblur() }
	if(event.keyCode==9) { txtProveedor_onblur() }
}

function txtIntArticuloId_onKeyDown() { 
	if(event.keyCode==13){ txtIntArticuloId_onblur() }
	if(event.keyCode==9) { txtIntArticuloId_onblur() }
}

function txtProveedor_onblur() {
	if(Trim(document.forms(0).elements('txtProveedor').value)==''){
		document.forms(0).txtProveedor.value = '';
		document.forms(0).hdnProveedor.value = '';
		document.forms(0).txtRazonSocialProveedor.value = '';
		return
	}

	if(document.forms(0).elements('txtProveedor').value!=document.forms(0).elements('hdnProveedor').value){
	    document.forms(0).hdnProveedor.value = '';
		if(isNaN(document.forms(0).elements('txtProveedor').value)){ 
			//escribo letras
			objLupaProveedor_onClick()
		}
		else {
			//escribio un numero
			objLupaProveedor_onClick()
		}
	}
}
function txtNumeroFactura_onblur() { 
   var intValidaFactura = true;
   
   if ( document.forms(0).txtProveedor.value == '' && document.forms(0).txtNumeroFactura.value == '') {
       intValidaFactura = false;      
   }
   else {  
       var intMotivoReclamacion = document.forms[0].elements['cmbMotivo'].value*1;
	   
		if(document.forms(0).elements('rdoTipoProveedor2').checked && (intMotivoReclamacion==3 || intMotivoReclamacion==4 || intMotivoReclamacion==5)) {	   
			if (intValidaFactura && (document.forms(0).txtProveedor.value == '' || isNaN(document.forms(0).txtProveedor.value))) {
				intValidaFactura = false;
				alert ("Capture el Número de Proveedor de la Factura");
				document.forms(0).txtProveedor.focus();
			}
			if (document.forms(0).hdnProveedor.value == '' ) {
			   intValidaFactura = false;
			}
			else {
			if (intValidaFactura && (document.forms(0).txtNumeroFactura.value == '')) {
				intValidaFactura = false;
				alert("Capture el Número de Factura");
				document.forms(0).txtNumeroFactura.focus();
			} 
			}
		}
		else {
			intValidaFactura = false;
		}
   }

   if (intValidaFactura) {
       document.forms(0).action = "<%=strFormAction%>?strCmd=BuscarFactura";
       document.forms(0).target="ifrOculto";
       DoSubmit();
       document.forms(0).target='';
       return(true);    
   }   
   
}

function txtIntArticuloId_onblur() {
	if(Trim(document.forms(0).elements('txtIntArticuloId').value)==''){
		document.forms(0).txtIntArticuloId.value = '';
		document.forms(0).hdnIntArticuloId.value = '';
		document.forms(0).txtStrArticuloDescripcion.value = '';
		return
	}
	
	if(document.forms(0).elements('txtIntArticuloId').value!=document.forms(0).elements('hdnIntArticuloId').value){
		if(isNaN(document.forms(0).elements('txtIntArticuloId').value)){ 
			//escribo letras
			objLupaArticulo_onClick()
		}
		else {
			//escribio un numero
			objLupaArticulo_onClick()
		}
	}
}

function txtCantidad_onblur() {
    document.forms(0).cmdAgregar.focus();  
}

function cmdInicializaProveedor() {
   document.forms(0).txtProveedor.value='';
   document.forms(0).txtNumeroFactura.value = '';
}

function fnBusquedaProveedorPorIframe() {
 var intProveedor = document.forms[0].elements['txtProveedor'].value*1;
 if (intProveedor==0) {
    document.forms[0].elements['txtProveedor'].value = '';
 }
 document.forms[0].elements['txtProveedor'].focus();
}

function fnUpdProveedorPorIframe(strProveedorId,strProveedorNombre,intError){
    document.forms(0).txtRazonSocialProveedor.value = strProveedorNombre;
    
    if(intError == 0){
		document.forms(0).txtProveedor.value = strProveedorId;
		document.forms(0).hdnProveedor.value = strProveedorId;
		document.forms(0).txtNumeroFactura.focus();
		document.forms(0).txtNumeroFactura.select();
	}
	else{
		alert("Proveedor no encontrado.");
		document.forms(0).txtProveedor.value = '';
		document.forms(0).hdnProveedor.value = '';
		document.forms(0).txtProveedor.focus();
		document.forms(0).txtProveedor.select();
	}
}

function fnUpdFacturaPorIframe(intFacturaElectronicaId, intError) {
   document.forms(0).hdnFacturaElectronicaId.value = intFacturaElectronicaId;
   
   if(intError == 0) {       
       document.forms(0).txtNoDeDocumento.focus();
   }
   else {
       strMensajeError = "Error al Buscar Factura";
       
       if (intError == -100) {
           strMensajeError= "Factura no encontrada";
       }
       
       document.forms(0).txtNumeroFactura.value='';
       
       alert(strMensajeError);
       
       document.forms(0).txtProveedor.focus();       
   }
}


function fnUpdArticuloPorIframe(strAccion, strListaHTML, intRegistrosLista, intReclamacionId, intArticuloBuscadoId, strArticuloBuscadoDescripcion, intArticuloBuscadoDepartamento, intError) {

	document.forms[0].elements['hdnReclamacionId'].value = intReclamacionId;
			
	// BUSCAR DE ARTICULO
    if (strAccion == 'BUSCAR') { 
    
		document.forms(0).txtIntArticuloId.value = intArticuloBuscadoId;
		document.forms(0).hdnIntArticuloId.value = intArticuloBuscadoId;
    	document.forms(0).txtStrArticuloDescripcion.value = strArticuloBuscadoDescripcion; 
	    document.forms(0).hdnDepartamentos.value = intArticuloBuscadoDepartamento;
	    
	    if(intArticuloBuscadoDepartamento >0){
			document.forms(0).cboDepartamentos.value = intArticuloBuscadoDepartamento;
			strTemporal = strTextoSeleccionadoEnCbo(document.forms(0).elements('cboDepartamentos'))
			document.all.divNombreDelDepartamento.innerHTML = strTemporal; 
						
			TotalDePartidas = document.forms[0].elements['hdnTotalArticulosReclamacion'].value;
			TotalDePartidas = TotalDePartidas * 1
			
			if(TotalDePartidas<1){ //Si no hay partidas -> Poner en cero el departamento para poder escojer cualquier producto
				document.forms(0).cboDepartamentos.value = 0;	
			}
    	}
    	
	    if(intError == 0) {
			document.forms(0).txtCantidad.focus();
			document.forms(0).txtCantidad.select();
		}
		else{
		
        	document.forms(0).txtCantidad.value='';			
			alert("Artículo no encontrado.");
			document.forms(0).txtIntArticuloId.focus();
			document.forms(0).txtIntArticuloId.select();
		}		
	}
	
	// AGREGAR - ELIMINAR ARTICULO
    if (strAccion == 'AGREGAR' || strAccion == 'ELIMINAR' ) { 
       var strMensaje = "";              
       document.all.divRecordBrowser.innerHTML = strListaHTML;                
                     	
       if (intRegistrosLista < 1) {
           fnHabilitaDeshabilitaControlesEncabezado(true); //Habiliar cuando no hay articulos en la reclamación
       } 
       else {
           fnHabilitaDeshabilitaControlesEncabezado(false); //Deshabilita si ya hay articulos en la reclamación
       }
       
       if (intError == 0) {
           	document.forms[0].elements['hdnTotalArticulosReclamacion'].value = intRegistrosLista;
       }
       else {           
           // AGREGAR ARTICULO A LA Reclamacion                                    
           if (strAccion == 'AGREGAR' ) { 
           
               strMensaje = "Error al agregar Articulo";
               
               if (intError == -90) {
                   strMensaje = "Capturar una factura valida para el proveedor";
               }
               
               if (intError == -100) {
                   strMensaje = "No se pudo iniciar el registro de la reclamación";
               }
               if (intError == -110) {
                   strMensaje = "No se pudo agregar el articulo a la reclamación";
               }
			   if (intError == -120) {
                   strMensaje = "El articulo no existe para el proveedor";
               }
           }
           
           // ELIMINAR ARTICULO A LA TRANSFERENCIA                  
           if (strAccion == 'ELIMINAR') { 
               strMensaje = "Error al eliminar Articulo";
           
               if (intError == -100) {
                   strMensaje = "No se pudo eliminar el articulo de la transferencia";
               }                  
           }           
           alert(strMensaje);           
       }
              
       document.forms(0).txtIntArticuloId.value = '';
       document.forms(0).txtStrArticuloDescripcion.value = '';
       document.forms(0).txtCantidad.value = '';              
       document.forms(0).txtIntArticuloId.focus();	
	
	}
	
}

function fnRegistrarReclamacionPorIframe(strListaHTML, intRegistrosLista, intReclamacionId, intReclamacionFolioId, intError) {
   if (intError == 0) {   
   	    document.forms[0].elements['txtReclamacionFolio'].value=intReclamacionFolioId;
		
		document.forms[0].elements['cmdRegistrar'].disabled=true;
		document.forms[0].elements['cmdRegistrar'].title='La reclamación ya fue registrada.';
		
		document.forms[0].elements['txtCifraDeControl'].readOnly=true;
		document.forms[0].elements['txtCifraDeControl'].className="campotabladeshabilitado";
		document.forms[0].elements['txtCifraDeControl'].title='La reclamación ya fue registrada.';
		
		document.forms[0].elements['cmdAgregar'].disabled=true;
		document.forms[0].elements['cmdAgregar'].title='La reclamación ya fue registrada.';
			    
		document.all.divCapturaDeProductos.style.display='none';				
		document.forms(0).cmdOtraCaptura.style.display='';
		
		alert("Reclamación Registrada con el Folio : [" + intReclamacionFolioId + "]");
   }
   else {
        alert("No fue posible registrar la Reclamación.");
   }

}

function blnDatosReclamacion() {
	//Validaciones
	var valida=true; 
	
	//fecha de reclamacion
	if(valida){ valida=blnValidarCampo(document.forms(0).elements("txtFechaDeReclamacion"),true,"Fecha de reclamación",cintTipoCampoFecha,10,10,""); } 
	
    if(valida){
	    strFecha=document.forms[0].elements("txtFechaDeReclamacion").value.substr(3,2) + "/" +document.forms[0].elements("txtFechaDeReclamacion").value.substr(0,2)+"/"+document.forms[0].elements("txtFechaDeReclamacion").value.substr(6,4)
        if (Date.parse(strFecha) > Date.parse("<%=clsCommons.strGetCustomDateTime("MM/dd/yyyy")%>") ){
            alert("Fecha reclamación inválida");
            document.forms[0].elements("txtFechaDeReclamacion").focus();
            valida=false;
        }
     }
	 //Motivo
	if(valida){ valida=blnValidarCombo(document.forms(0).elements('cmbMotivo'),'-1','Motivo',true) }
	
	//Departamentos
    if(valida){ valida=blnValidarCombo(document.forms(0).elements('cboDepartamentos'),'-1','Departamento',true) }

	//No de proveedor
	if(valida){ valida=blnValidarCampo(document.forms(0).elements("txtProveedor"),true,"No. de proveedor",cintTipoCampoEntero,15,1,""); } 
	
	//Factura
	if(valida) {  
       var intMotivoReclamacion = document.forms[0].elements['cmbMotivo'].value*1;
	   var hdnFacturaElectronicaId = document.forms[0].elements['hdnFacturaElectronicaId'].value*1;

	   if ( document.forms(0).elements('rdoTipoProveedor2').checked && hdnFacturaElectronicaId < 1 && (intMotivoReclamacion==3 || intMotivoReclamacion==4 || intMotivoReclamacion==5) ) {
          alert ("La Factura debe existir como confirmada");
		  document.forms(0).elements("txtNumeroFactura").focus();
          valida=false;
	   }
	   else {
	     valida=blnValidarCampo(document.forms(0).elements("txtNumeroFactura"),true,"Factura",cintTipoCampoAlfanumerico,20,1,""); 
	   }
	}
	
	//No de documento
	if(valida){ valida=blnValidarCampo(document.forms(0).elements("txtNoDeDocumento"),true,"No. de documento",cintTipoCampoEntero,5,1,""); } 

	return valida;
  
}

function intAgregarArticulo() {
	//Validaciones
	valida = blnDatosReclamacion(); 
	
	//Codigo
   if(valida){ valida=blnValidarCampo(document.forms(0).elements("txtIntArticuloId"),true,"Código",cintTipoCampoEntero,20,1,""); }
   if(valida) {	 
       if (document.forms(0).elements("txtIntArticuloId").value <=0) {
			document.forms(0).elements("txtIntArticuloId").value='';
			document.forms(0).elements("txtIntArticuloId").focus();
			valida=false;
	   }   
   }
   
	//Cantidad
	if(valida){ valida=blnValidarCampo(document.forms(0).elements("txtCantidad"),true,"Cantidad",cintTipoCampoEntero,15,1,""); } 
	
	if(valida){
	    if (document.forms(0).elements("txtCantidad").value <= 0){
	        alert("Cantidad no válida");
	        document.forms(0).elements("txtCantidad").focus();
	        valida=false;
 	    }
	}
	
	//submit
	if(valida){
	  fnUpdCboDepartamentos('AgregarArticulo')
      strTemporal = strTextoSeleccionadoEnCbo(document.forms(0).elements('cboDepartamentos'))
      strTemporal = "&strTextoSeleccionadoEnCboDepartamento=" + strTemporal;
	  
	  document.forms[0].action = "<%=strFormAction%>?strCmd=AgregarArticulo" + strTemporal;
	  document.forms[0].target="ifrOculto";
      DoSubmit();
      document.forms[0].target='';
	}

}

function intEliminarArticulo(intReclamacionId, intArticuloId) {
	intValor = (document.forms(0).elements('txtReclamacionFolio').value) * 1;
	
	if(intValor>0){
	  alert('Imposible borrar, la reclamación ya fue registrada.');
	}
	else{
	  fnUpdCboDepartamentos('Borrar')
      strTemporal = strTextoSeleccionadoEnCbo(document.forms(0).elements('cboDepartamentos'))
      strTemporal = "&strTextoSeleccionadoEnCboDepartamento=" + strTemporal;
      
      document.forms(0).action = "<%=strFormAction%>?strCmd=EliminarArticulo&intReclamacionEliminarId=" + intReclamacionId + "&intArticuloEliminarId=" + intArticuloId +strTemporal;
	  	  
	  document.forms(0).target="ifrOculto";
      DoSubmit();
      document.forms(0).target='';
	}
}
function txtCifraDeControl_onKeyDown(){
	if(event.keyCode==13){ document.forms(0).cmdRegistrar.click(); }
}
function cmdRegistrar_onclick() {

    //Validaciones
	valida = blnDatosReclamacion(); 
	
    if(valida){ valida=blnValidarCifraDeControl(); }
    
    if(valida){
        strTemporal = strTextoSeleccionadoEnCbo(document.forms(0).elements('cboDepartamentos'))
        strTemporal = "&strTextoSeleccionadoEnCboDepartamento=" + strTemporal;
        document.forms(0).action="<%=strFormAction%>?strCmd=Registrar" + strTemporal;
    }
    
    if(valida){ 
		fnUpdCboDepartamentos()
		
		document.forms(0).target="ifrOculto";
        DoSubmit();
        document.forms(0).target='';
	}

}


function cmdonKeyPressed(intObjeto,tecla) {
 if (tecla == 13 || tecla==9) {
       if (intObjeto==1) {
           document.forms(0).cmbMotivo.focus();
       }
       if (intObjeto==2) {
           document.forms(0).rdoTipoProveedor1.focus();
       }   
        if (intObjeto==3) {
           document.forms(0).txtProveedor.focus(); 
       }     
       if (intObjeto==4) {
       document.forms(0).txtNumeroFactura.focus();      
       }
       if (intObjeto==5) {
       document.forms(0).txtNoDeDocumento.focus();      
       }
       if (intObjeto==6) {
       document.forms(0).txtIntArticuloId.focus();      
       }
	   if (intObjeto==10) {
       document.forms(0).txtCantidad.focus();      
       }
       if (intObjeto==11) {
           document.forms(0).cmdAgregar.focus();     
       }        
       event.returnValue = false;
   }
  
}
//-->
</script>
</HEAD>
<body leftMargin="0" topMargin="0" onload="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaCapturarReclamaciones" action="about:blank" method="post">
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
            <td width="10" bgColor="#ffffff"><IMG height="8" src="../static/images/pixel.gif" width="10"></td>
            <td class="tdmigaja" width="583"> <div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en : </span><A class="txdmigaja" href="javascript:strHrefMigaja1();"> 
                <script language="javascript">strTituloMigaja1()</script>
                </A> <span class="txdmigaja">: <A class="txdmigaja" href="javascript:strHrefMigaja2();"> 
                <script language="javascript">strTituloMigaja2()</script>
                </A>: <A class="txdmigaja" href="javascript:strHrefMigaja3();"> 
                <script language="javascript">strTituloMigaja3()</script>
                </A>: 
                <script language="javascript">strTituloPrincipalDePagina()</script>
                </span></div></td>
            <td class="tdfechahora" width="187"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td class="tdtablacont" vAlign="top" width="583"><span class="txtitulo"> 
              <script language="javascript">strTituloPrincipalDePagina()</script>
              </span><span class="txcontenido"> 
              <script language="javascript">strDescripcionPrincipalDePagina()</script>
              <br>
              </span> <script language="JavaScript">crearDatosSucursal()</script> 
              <br> <div id="ToPrintHtmContenido"> 
                <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                  <tr> 
                    <td class="tdtittablas" width="30%">Folio de Reclamación:</td>
                    <td class="tdpadleft5" vAlign="middle" width="70%"><input class="campotabladeshabilitado" readOnly type="text" maxLength="4" size="18" name="txtReclamacionFolio"> 
                    </td>
                  </tr>
                </table>
                <br>
                <span class="txsubtitulo"><IMG height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Datos 
                de la Reclamación</span> 
                <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                  <tr> 
                    <td class="tdtittablas" width="190">Fecha de Reclamación:</td>
                    <td class="tdpadleft5" vAlign="middle" colSpan="3"><input class="campotabla" onkeypress="cmdonKeyPressed(1,event.keyCode);" type="text" size="10"
														name="txtFechaDeReclamacion"> 
                      <IMG style="CURSOR: hand" onclick="if(blnValidarCampo(document.forms(0).elements('txtFechaDeReclamacion'),false,'Fecha de Reclamación',cintTipoCampoFecha,10,10,'')){DoObjCalendar1();}"
														height="13" src="../static/images/icono_calendario.gif" width="20" align="absMiddle"></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Motivo Reclamación:</td>
                    <td class="tdpadleft5" vAlign="middle" width="200"><select class="campotabla" onkeypress="cmdonKeyPressed(2,event.keyCode);" onchange="cmdInicializaProveedor()"
														name="cmbMotivo">
                      </select> </td>
                    <td class="tdtittablas" vAlign="top" width="88">Departamento:</td>
                    <td class="tdconttablas" vAlign="middle" width="290"> <select class="campotabla" style="DISPLAY: none" name="cboDepartamentos">
                      </select> <div id="divNombreDelDepartamento"> 
                        <script language="javascript">strNombreDelDepartamento()</script>
                      </div></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" width="166">Tipo de proveedor:</td>
                    <td class="tdconttablas" vAlign="top" colSpan="3"><input onkeypress="cmdonKeyPressed(3,event.keyCode);" id="rdoTipoProveedor1" type="radio"
														onchange="cmdInicializaProveedor()" value="ProveedorDirecto" name="rdoTipoProveedor">
                      Directo&nbsp;&nbsp;&nbsp; <input onkeypress="cmdonKeyPressed(3,event.keyCode);" id="rdoTipoProveedor2" type="radio"
														onchange="cmdInicializaProveedor()" value="ProveedorMayorista" name="rdoTipoProveedor">
                      Mayorista</td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" title="No. de proveedor ó Clave del proveedor">No. 
                      de proveedor:</td>
                    <td class="tdpadleft5" colSpan="3"><input class="campotabla" onkeypress="cmdonKeyPressed(4,event.keyCode);" id="txtProveedor"
														onkeydown="txtProveedor_onKeyDown()" onblur="return txtProveedor_onblur()" type="text" maxLength="16" size="16" name="txtProveedor"> 
                      &nbsp; <A id="objLupaProveedor" onclick="return objLupaProveedor_onClick();" href="javascript:;"> 
                      <IMG height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"></A> 
                      <span class="txconttablasrojo"> 
                      <input class="campotablaresultado" id="txtRazonSocialProveedor" readOnly maxLength="40"
															size="40" border="0" name="txtRazonSocialProveedor">
                      </span></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" width="166">No. de Factura:</td>
                    <td class="tdpadleft5" vAlign="middle" colSpan="3"><input class="campotabla" onkeypress="cmdonKeyPressed(5,event.keyCode);" onblur="return txtNumeroFactura_onblur()"
														type="text" size="20" name="txtNumeroFactura"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">No. de Documento:</td>
                    <td class="tdpadleft5" vAlign="middle" colSpan="3"><input class="campotabla" onkeypress="cmdonKeyPressed(6,event.keyCode);" type="text" maxLength="5"
														size="20" name="txtNoDeDocumento"> 
                    </td>
                    <td class="txconttablasrojo" vAlign="middle" width="2">&nbsp;</td>
                  </tr>
                </table>
                <br>
                <span class="txsubtitulo"><IMG height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Detalle 
                de productos reclamados</span> 
                <div id="divRecordBrowser"></div>
                <br>
                <div id="divCapturaDeProductos"> 
                  <table class="tdenvolventetablas" width="100%">
                    <tr> 
                      <td class="tdtittablas3" align="left" width="100">Código:</td>
                      <td class="tdtittablas3" align="left" width="120">Cantidad</td>
                      <td class="tdtittablas3" align="left" width="240">Descripción</td>
                      <td vAlign="middle" width="80" rowSpan="2"><input class="boton" type="button" name="cmdAgregar" onclick="return intAgregarArticulo()"
															value="Agregar"> </td>
                    </tr>
                    <tr> 
                      <td class="txtitintabla" vAlign="middle" width="190" height="21"><input class="campotabla" onkeypress="cmdonKeyPressed(10,event.keyCode);" onblur="txtIntArticuloId_onblur();"
															type="text" maxLength="16" size="18" name="txtIntArticuloId"> 
                        <a id="objLupaArticulo" onclick="return objLupaArticulo_onClick();" border="0"> 
                        <IMG height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"> 
                        </a> </td>
                      <td class="tdpadleft5" vAlign="middle"><input class="campotabla" onkeypress="cmdonKeyPressed(11,event.keyCode);" onblur="return txtCantidad_onblur()"
															type="text" maxLength="4" size="18" name="txtCantidad"> 
                      </td>
                      <td class="txtitintabla" vAlign="middle" width="300"><input class="campotablaresultadoenvolventeazul" readOnly type="text" size="32" name="txtStrArticuloDescripcion"> 
                      </td>
                    </tr>
                  </table>
                </div>
                <br>
                <div id="divBotones" style="DISPLAY: none"> 
                  <table id="TblBotones" cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <tr> 
                      <td width="317">&nbsp;&nbsp; <input class="boton" onclick="return cmdRegresar_onclick()" type="button" value="Regresar"
															name="cmdRegresar"> 
                        <input class="boton" onclick="return cmdImprimir_onclick()" type="button" value="Imprimir"
															name="cmdImprimir"> 
                        <input class="boton" style="DISPLAY: none" onclick="return cmdOtraReclamacion_onclick()"
															type="button" value="Otra Captura" name="cmdOtraCaptura"> 
                      </td>
                      <td class="tdenvolventetablas" align="center" width="200" bgColor="#f4f6f8"> 
                        <table cellSpacing="0" cellPadding="0" width="230" border="0">
                          <tr> 
                            <td class="tdtittablas3" width="156">Cifra de control</td>
                            <td width="91" rowSpan="2"><input class="boton" onclick="return cmdRegistrar_onclick()" type="button" value="Registrar"
																		name="cmdRegistrar"> 
                            </td>
                          </tr>
                          <tr> 
                            <td vAlign="top" height="30"><input class="campotabla" onkeydown="txtCifraDeControl_onKeyDown()" type="text" maxLength="4"
																		size="16" name="txtCifraDeControl"> 
                            </td>
                          </tr>
                        </table></td>
                    </tr>
                  </table>
                </div>
                <br>
                <div id="divFirmasHTML" style="DISPLAY: none"> 
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
                      <td class="tdtittablas" align="center">Capturó Reclamación</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Gte. Sucursal</td>
                    </tr>
                  </table>
                  <br>
                  <table>
                    <tr> 
                      <td class="tdtittablas">* Este documento no será válido 
                        sin el nombre y firma de autorización del representante 
                        del proveedor.* </td>
                    </tr>
                  </table>
                </div>
              </div>
              <!-- cerramos el div ToPrintHtmContenido -->
            </td>
            <td class="tdcolumnader" vAlign="top" width="182" rowSpan="2">&nbsp;</td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
    <tr> 
      <td> <input type="hidden" name="hdnFacturaElectronicaId" value= '<%=Request.Form("hdnFacturaElectronicaId")%>'> 
        <input type="hidden" name="hdnReclamacionId"> <input type="hidden" name="hdnProveedor"> 
        <input type="hidden" name="hdnDepartamentos"> <input type="hidden" name="hdnIntArticuloId"> 
        <input type="hidden" name="hdnTotalArticulosReclamacion"> </td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	var objCalendar1 = new calendar1(document.forms[0].elements['txtFechaDeReclamacion']);
	//-->
			</script>
</form>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</HTML>
