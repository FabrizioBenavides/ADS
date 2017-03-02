<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaCapturarTransferenciaManual.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaCapturarTransferenciaManual" codePage="28592"%>
<HTML>
<HEAD>
<title>Benavides : Administrador de Puntos de Venta</title>
<%
    '====================================================================
    ' Page          : MercanciaCapturarTransferenciaManual.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Raúl Corral González
    ' Version       : 1.0
    ' Last Modified : Friday, October 31, 2003
    ' Modificacion  : Septiembre 24, 2004 ; Griselda Gómez Ponce
    '                 Se añade la funcion Trim() a los campos de Compania y Sucursal que recibe.
    '                 Jueves 18 de Noviembre 2004 [JAHD]
    '                 Ajustes por nuevo manejo de las transferencias TES-DEVOLUCIONES-RECLAMACIONES
	'                 20 de Marzo 2007             Actualizacion por SAP
    '====================================================================
%>
<meta name="description" content="Javascript Menu">
<meta name="keywords" content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
//Variables Globales
blnmControlesEncabezadoHabilitados=true;

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}
function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}
function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
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
	document.location.href='MercanciaSalidas.aspx';
}
function strHrefMigaja3(){
	document.location.href='MercanciaSalidasTransferenciasOtraSucursal.aspx';
}
function strHrefMigaja4(){
	document.location.href='';
}
function strTituloMigaja1(){
	document.write("Mercancía");
}
function strTituloMigaja2(){
	document.write("Salidas");
}
function strTituloMigaja3(){
	document.write("Transferencias a otra sucursal");
}

function strTituloPrincipalDePagina() {
	document.write("Capturar transferencia manual");
}
function strDescripcionPrincipalDePagina() {
	document.write("Para iniciar la captura de una transferencia manual, defina a qué sucursal se hará el envío. Luego capture uno por uno los productos que desea transferir. Si no conoce un código, haga clic en el icono en forma de lupa.");
}


function fnHabilitaDeshabilitaControlesEncabezado(blnHabilitar){
	if(blnHabilitar) {		
		document.forms(0).cboTipoTES.disabled=false;
		document.forms(0).cboTipoTES.className="campotabla";
		
		document.forms(0).cboMotivo.disabled=false;
		document.forms(0).cboMotivo.className="campotabla";
		
		document.forms(0).txtCompaniaQueRecibe.readOnly=false;
		document.forms(0).txtCompaniaQueRecibe.className="campotabla";
		document.forms(0).txtSucursalQueRecibe.readOnly=false;
		document.forms(0).txtSucursalQueRecibe.className="campotabla";
		
		document.forms(0).txtNumeroRemision.readOnly=false;
		document.forms(0).txtNumeroRemision.className="campotabla";
		
		document.forms(0).cboEmpleadoAutorizado.disabled=false;
		document.forms(0).cboEmpleadoAutorizado.className="campotabla";
				
		document.forms(0).txtObservaciones.readOnly=false;
		document.forms(0).txtObservaciones.className="campotabla";		
		
		blnmControlesEncabezadoHabilitados=true;
				
		document.all.divBotones.style.display='none'; 		
		
	}
	else {
	    document.forms(0).cboTipoTES.disabled=true;
		document.forms(0).cboTipoTES.className="campotablalectura";	
		
		document.forms(0).cboMotivo.disabled=true;
		document.forms(0).cboMotivo.className="campotablalectura";
		
		document.forms(0).txtCompaniaQueRecibe.readOnly=true;
		document.forms(0).txtCompaniaQueRecibe.className="campotablalectura";
		
		document.forms(0).txtSucursalQueRecibe.readOnly=true;		
		document.forms(0).txtSucursalQueRecibe.className="campotablalectura";
		
		document.forms(0).cboEmpleadoAutorizado.disabled=true;
		document.forms(0).cboEmpleadoAutorizado.className="campotablalectura";
		
		document.forms(0).txtNumeroRemision.readOnly=true;
		document.forms(0).txtNumeroRemision.className="campotablalectura";			
		
		document.forms(0).txtObservaciones.readOnly=true;
		document.forms(0).txtObservaciones.className="campotablalectura";	
		
		blnmControlesEncabezadoHabilitados=false;
		
		document.all.divBotones.style.display=''; 
	}
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
	
	// Genera Lista con Empleado para captura
	<%=strcboEmpleadoAutorizado%>;	
	<%= strJavascriptWindowOnLoadCommands %>
	
//       document.forms(0).cboTipoTES.focus();

	
	return(true);
}

function fnBloqueaPagina() {
  alert ("Página bloqueada hasta el día de mañana"); 
  document.all.tblDevo1.style.display='none';
  document.all.tblDevo2.style.display='none';
  document.all.tblDevo3.style.display='none';
  document.all.tblDevo4.style.display='none';
  document.all.tblCapturaBultos.style.display='none';
  document.all.TblBotones.style.display='none';
}

function cmdRegresar_onclick() {
	strHrefMigaja3();
}

function cmdImprimir_onclick() {
    intValor = (document.forms(0).txtIntFolioTransferencia.value) * 1;
    if ( intValor > 0  ) {
	if (window.print) {
        document.ifrPageToPrint.document.all.ToPrintTxtMigaja.innerHTML=document.all.ToPrintTxtMigaja.innerText;        
        document.ifrPageToPrint.document.all.ToPrintTxtSucursal.innerHTML=document.all.ToPrintTxtSucursal.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtFecha.innerHTML=document.all.ToPrintTxtFecha.innerText;
        document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML=document.all.ToPrintHtmContenido.innerHTML;
        
        //Ocultar 
        document.ifrPageToPrint.document.all.divCapturaDeProductos.style.display='none';
        document.ifrPageToPrint.document.all.tblCapturaBultos.style.display='none';
        document.ifrPageToPrint.document.all.TblBotones.style.display='none';
        
        //Mostrar Tabla de firmas
        document.ifrPageToPrint.document.all.divFirmasUp.style.display='';
        document.ifrPageToPrint.document.all.divFirmasDn.style.display='';
                 
        document.ifrPageToPrint.focus();
        window.print();       
         
    } 
    else {
        alert("Tu navegador no soporta la función: Print.")
    }
    }
}

function cmdBultos_onclick() {
   document.all.divCapturaDeProductos.style.display='none';
   
   document.all.divBultos.style.display='';   
   document.all.tblCapturaBultos.style.display='';

   document.forms(0).txtNumeroBulto.focus();
}


function cmdOtraCaptura_onclick(){
	document.location.href='MercanciaCapturarTransferenciaManual.aspx';
}


// Mandar ventana de consulta
function Pop(url, width, height) {
    var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	return(false);
}

//Buscada de Sucursal de Recibo
function objLupaSucursalRecibo_onClick() {
   if (document.forms(0).cboTipoTES.value < 1 || document.forms(0).cboMotivo.value <1)  {
   
       document.forms(0).txtCompaniaQueRecibe.value = "";
       document.forms(0).txtSucursalQueRecibe.value = "";
       document.forms(0).hdnCompaniaQueRecibe.value = '';
	   document.forms(0).hdnSucursalQueRecibe.value = '';
       
       if (document.forms(0).cboTipoTES.value < 1) {
           alert("Seleccionar el Tipo de Transferencia");
           document.forms(0).cboTipoTES.focus();
       }
       
       if (document.forms(0).cboMotivo.value <1) {
           alert("Seleccionar el Motivo de Transferencia");	
           document.forms(0).cboMotivo.focus();	      
       }       
       return(false);		
   }   
     
   if(document.forms(0).txtCompaniaQueRecibe.disabled==true){
       if(document.forms(0).txtSucursalQueRecibe.disabled==true){ return }
   }
   if(document.forms(0).txtCompaniaQueRecibe.readOnly==true){
       if(document.forms(0).txtSucursalQueRecibe.readOnly==true){ return }
   }
   	
   if(Trim(document.forms(0).txtCompaniaQueRecibe.value)==""){
       if(Trim(document.forms(0).txtSucursalQueRecibe.value)!=""){
           if(isNaN(document.forms(0).txtSucursalQueRecibe.value)){
               document.forms(0).txtCompaniaQueRecibe.value = document.forms(0).txtSucursalQueRecibe.value;
               document.forms(0).txtSucursalQueRecibe.value ='';
           }
       }
   }
   
   if(document.forms(0).txtCompaniaQueRecibe.value!="" ){
       if(!isNaN(document.forms(0).txtCompaniaQueRecibe.value)) {
           if(document.forms(0).txtCompaniaQueRecibe.value!='0' ) {
               document.forms(0).action = "<%=strFormAction%>?strCmd=BuscaSucursal";
               document.forms(0).target="ifrOculto";
               DoSubmit()
               document.forms(0).target='';
               return(true);
           }
           else {
               //el valor es cero
				     document.forms(0).txtCompaniaQueRecibe.value='';
				     document.forms(0).txtSucursalQueRecibe.value='';
				     document.forms(0).txtDescripcionSucursal.value=''; 				      
				     strEvalJs="opener.fnUpdCiaSucConfirma(intValorCia,intValorSuc,strNombre,0)"; 
				     strParametros = "";
				     strParametros = strParametros + "?strCompaniaIdNombre=" + document.forms(0).txtCompaniaQueRecibe.value;
			         strParametros = strParametros + "&strSucursalIdNombre=" + document.forms(0).txtSucursalQueRecibe.value;
				     strParametros = strParametros + "&strObjCiaId=txtCompaniaQueRecibe";
				     strParametros = strParametros + "&strObjSucId=txtSucursalQueRecibe";
				     strParametros = strParametros + "&strObjDescripcion=txtDescripcionSucursal";
				     Pop('PopSucursal.aspx'+ strParametros +'&strEvalJs='+strEvalJs,500,540);
			   } 
	     }
	      else{ 
		   	  document.forms(0).txtDescripcionSucursal.value='';
		   	  strEvalJs="opener.fnUpdCiaSucConfirma(intValorCia,intValorSuc,strNombre,0)"; 
		   	  strParametros = ""
			  strParametros = strParametros + "?strCompaniaIdNombre=" + document.forms(0).txtCompaniaQueRecibe.value;
			  strParametros = strParametros + "&strSucursalIdNombre=" + document.forms(0).txtSucursalQueRecibe.value;
			  strParametros = strParametros + "&strObjCiaId=txtCompaniaQueRecibe" 
			  strParametros = strParametros + "&strObjSucId=txtSucursalQueRecibe" 
			  strParametros = strParametros + "&strObjDescripcion=txtDescripcionSucursal" 
			  Pop('PopSucursal.aspx'+ strParametros +'&strEvalJs='+strEvalJs,500,540);
	          }
	       }
	else{
		alert("Teclear Número de sucursal o descripción");
		document.forms(0).txtCompaniaQueRecibe.focus();
        return(false);
	    }
}

    
// Busca articulo
function objLupaArticulo_onClick(){ 
	if (document.forms(0).txtIntArticuloId.value!="")
	    {
         if (!isNaN(document.forms(0).txtIntArticuloId.value))
             {
			   if (document.forms(0).txtIntArticuloId.value != '0')
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
				     
				     document.forms(0).txtStrArticuloDescripcion.value=''; 
				     strEvalJs="if(opener.document.forms[0].txtIntArticuloId.value!='0'){opener.objLupaArticulo_onClick()}";
				     strParametros='';
				     
					 strParametros=strParametros + '?strArticuloIdNombre=' + document.forms(0).txtIntArticuloId.value;
				     strParametros=strParametros + '&strArticuloNombreId=txtStrArticuloDescripcion' 
				     strParametros=strParametros + '&strArticulo=txtIntArticuloId' 
				     Pop('PopArticulo.aspx'+strParametros+'&strEvalJs='+strEvalJs,500,540);
			       }
			    return(false);
	         }
	      else{ 
		        
				document.forms(0).txtStrArticuloDescripcion.value=''; 
				strEvalJs="if(opener.document.forms[0].txtIntArticuloId.value!='0'){opener.objLupaArticulo_onClick()}";
				strParametros='';
				strParametros=strParametros + '?strArticuloIdNombre=' + document.forms(0).txtIntArticuloId.value;
				strParametros=strParametros + '&strArticuloNombreId=txtStrArticuloDescripcion' 
				strParametros=strParametros + '&strArticulo=txtIntArticuloId' 
				Pop('PopArticulo.aspx'+strParametros+'&strEvalJs='+strEvalJs,500,540);
	          }
	       }
	else{
		alert("Teclear número de artículo o descripción");
		document.forms(0).txtIntArticuloId.focus();
        return(false); 
	    }
}

// Da el foco a campo SucursalQueRecibe al captar un enter
function txtCompaniaQueRecibe_onKeyDown() {
	if(event.keyCode==13){ document.forms(0).txtSucursalQueRecibe.select(); }
}

// Ejecuta el onblur del campo SucursalQueRecibe al captar un enter
function txtSucursalQueRecibe_onKeyDown() { 
	if(event.keyCode==13){ txtSucursalQueRecibe_onblur() }
}

//Busca y valida la Sucursal de Recibo 
function txtSucursalQueRecibe_onblur() {
    strCiaSucursal = document.forms(0).txtCompaniaQueRecibe.value;
    strCiaSucursal = strCiaSucursal + document.forms(0).txtSucursalQueRecibe.value;
    strCiaSucursal = Trim(strCiaSucursal);
    
	if(strCiaSucursal==''){
		document.forms(0).hdnCompaniaQueRecibe.value = '';
		document.forms(0).hdnSucursalQueRecibe.value = '';
		document.forms(0).txtDescripcionSucursal.value='';
		return;
	}
		
	hdnCiaSucursal = document.forms(0).hdnCompaniaQueRecibe.value;
    hdnCiaSucursal = hdnCiaSucursal + document.forms(0).hdnSucursalQueRecibe.value;
    hdnCiaSucursal = Trim(hdnCiaSucursal);
    
	if(hdnCiaSucursal != strCiaSucursal) {	   	    
	    objLupaSucursalRecibo_onClick(); 
	}
}

function fnUpdCiaSucConfirma (intCompaniaQueRecibe, intSucursalQueRecibe, strDescripcionSucursal, intError){

   if(!isNaN(document.forms(0).txtCompaniaQueRecibe.value)) {
           if(document.forms(0).txtCompaniaQueRecibe.value!='0' ) {
               document.forms(0).action = "<%=strFormAction%>?strCmd=BuscaSucursal";
               document.forms(0).target="ifrOculto";
               DoSubmit()
               document.forms(0).target='';
               return(true);
           }
   }
}

function fnUpdCiaSucursalPorIframe(intCompaniaQueRecibe, intSucursalQueRecibe, strDescripcionSucursal, intUENSucursalQueRecibe, intError) {

   document.forms(0).hdnCompaniaQueRecibe.value=intCompaniaQueRecibe;
   document.forms(0).hdnSucursalQueRecibe.value=intSucursalQueRecibe;
   document.forms(0).txtCompaniaQueRecibe.value=intCompaniaQueRecibe;
   document.forms(0).txtSucursalQueRecibe.value=intSucursalQueRecibe;
   document.forms(0).txtDescripcionSucursal.value=strDescripcionSucursal;
   document.forms(0).hdnUENSucursalRecibo.value= intUENSucursalQueRecibe;
    
   var strMensajeError = "";
    
   if (strDescripcionSucursal.length < 1 && intError==0) {
       intError = -70;       
   }
   
   if(intError == 0){
       var intTipoTES = document.forms(0).cboTipoTES.value;   	
       if (intTipoTES >0) {
           if (intTipoTES == 1) {
               document.forms(0).txtObservaciones.focus();
           }
           else {       
               document.forms(0).cboEmpleadoAutorizado.focus();
           }   
       }
   }
   else {
       strMensajeError = "Error al Buscar Sucursal";

       if (intError == -80) {
           strMensajeError= "Sucursal que Recibe no debe ser igual a la que envia";
       }   
       if (intError == -90) {
           strMensajeError= "Sucursal que Recibe no Existe";       
       }                 
       if (intError == -100) {
           strMensajeError= "Capturar Sucursal que Recibe";       
       }       
       if (intError == -110) {
           strMensajeError= "Para TES Normales, Capturar Sucursal valida";       
       }
       if (intError == -120) {
           strMensajeError= "Para Devoluciones/Reclamaciones capturar en Sucursal un número de CEDIS";       
       }            
        
       document.forms(0).hdnCompaniaQueRecibe.value='';
       document.forms(0).hdnSucursalQueRecibe.value='';
       document.forms(0).txtCompaniaQueRecibe.value='';
       document.forms(0).txtSucursalQueRecibe.value='';
       
       if (intError != -70) {       
          alert(strMensajeError);
       }
       
       document.forms(0).txtCompaniaQueRecibe.focus();	   
   }
}

function txtNumeroRemision_onblur() { 
       if (document.forms(0).txtNumeroRemision.value == '' || isNaN(document.forms(0).txtNumeroRemision.value) ) {
           alert("Capture el Número de Remisión");
           document.forms(0).txtNumeroRemision.focus();
       }    
}

function txtIntArticuloId_onblur() {
	if(Trim(document.forms(0).txtIntArticuloId.value)=='') {
		document.forms(0).txtIntArticuloId.value = '';
		document.forms(0).hdnIntArticuloId.value = '';
		document.forms(0).txtStrArticuloDescripcion.value = '';
		return;
	}
	
	if(document.forms(0).txtIntArticuloId.value!=document.forms(0).hdnIntArticuloId.value){
	    objLupaArticulo_onClick();		
	}
	else {
	   document.forms(0).txtCantidad.focus(); 
	}
}

function txtCantidad_onblur() {
    document.forms(0).cmdAgregar.focus();  
}
	
function intAgregarArticulo() {	
	var valida = true; 		
			
	//No de Sucursal
	if(valida){ valida=blnValidarCampo(document.forms(0).txtCompaniaQueRecibe,true,"Compania que recibe",cintTipoCampoEntero,4,1,""); } 
	if(valida){ valida=blnValidarCampo(document.forms(0).txtSucursalQueRecibe,true,"Sucursal que recibe",cintTipoCampoEntero,4,1,""); } 
	if(valida){ 
		valida = blnValidarCampo(document.forms(0).txtDescripcionSucursal,true,"Verificar la Sucursal que Recibe",cintTipoCampoAlfanumerico,255,1,""); 
		document.forms(0).txtCompaniaQueRecibe.select();
	} 
	if(valida){ 
	  // Validar que la sucursal que Recibe no sea la misma que la que manda
	  var strCompaniaId = "<%=intCompaniaId%>";
	  var strSucursalId = "<%=intSucursalId%>";	
	  	  
	  if ( strCompaniaId == Trim(document.forms(0).txtCompaniaQueRecibe.value)  &&  strSucursalId == Trim(document.forms(0).txtSucursalQueRecibe.value)) {
	    alert("La Sucursal que Recibe no puede ser la misma que Envia, verificar");
	    valida = false;	  
	  }	
	} 
	
	//TIPO TES	
	if(valida){ valida=blnValidarCombo(document.forms(0).cboTipoTES,'-1','TIPO TES',true) }
	
	//MOTIVO
	if(valida){ valida=blnValidarCombo(document.forms(0).cboMotivo,'-1','Motivo',true) }
		
	
   // VALIDACION DE MOTIVOS CONTRA SUCURSAL DESTINO
   if (valida && document.forms(0).cboTipoTES.value == 1 && document.forms(0).hdnUENSucursalRecibo.value == 10 && document.forms(0).cboMotivo.value != 2 && document.forms(0).cboMotivo.value != 3 ) {   
       valida = false;
       alert("Transferencia y Motivo no validos al CEDIS");	      
       document.forms(0).txtCompaniaQueRecibe.focus();
   }	
   
   if (valida && (document.forms(0).cboTipoTES.value != 1 && document.forms(0).hdnUENSucursalRecibo.value != 10) ) {
	   valida = false;
       alert("Para Devoluciones/Reclamaciones capturar en Sucursal un número de CEDIS");	      
       document.forms(0).txtCompaniaQueRecibe.focus();
   } 
   
   if (valida && (document.forms(0).cboTipoTES.value != 1 && document.forms(0).cboEmpleadoAutorizado.value < 1 ) ) {
       valida = false;
	   alert("Para Devoluciones/Reclamaciones seleccionar Empleado"); 
	   document.forms(0).cboEmpleadoAutorizado.focus();   
   }
      
   if (valida && (document.forms(0).cboTipoTES.value != 1 &&  document.forms(0).txtNumeroRemision.value < 1 ) ) {
	   valida = false;
	   alert("Para Devoluciones/Reclamaciones capturar Remisión"); 
	   document.forms(0).txtNumeroRemision.focus();
   }
   
   //Codigo
   if(valida){ valida=blnValidarCampo(document.forms(0).txtIntArticuloId,true,"Código",cintTipoCampoEntero,20,1,""); }

   //Cantidad
   if(valida){ valida=blnValidarCampo(document.forms(0).txtCantidad,true,"Cantidad",cintTipoCampoEntero,15,1,""); } 
   if(valida){
		intTemporal = (document.forms(0).txtCantidad.value * 1);
		if(intTemporal<=0){
			valida=false;
			alert("El campo Cantidad debe ser mayor a cero.");	
			document.forms(0).txtCantidad.select();
		}
   }
   
   //submit
   if(valida){
	    document.forms(0).action = "<%=strFormAction%>?strCmd=AgregarArticulo";
	    document.forms(0).target="ifrOculto";
	    DoSubmit();
   }   	
}	

function intEliminarArticulo(intTransferenciaId, intArticuloId){
    var intEliminar = true;
	var strMensajeEliminar = "";
	
	intValor = (document.forms(0).txtIntFolioTransferencia.value) * 1;
	
	if (intEliminar && intValor>0) {
	  intEliminar = false;
	  
	  strMensajeEliminar = 'Imposible Eliminar, la transferencia ya fue registrada.';	  
	}
	
	if (intEliminar && document.all.tblCapturaBultos.style.display == '') {
	   intEliminar = false; 
	   
	   strMensajeEliminar = 'Imposible Eliminar, termine la captura de bultos.';
	}
	
	if (intEliminar) {
	  document.forms(0).action = "<%=strFormAction%>?strCmd=EliminarArticulo&intTransferenciaIdEliminar=" + intTransferenciaId + "&intArticuloIdEliminar=" + intArticuloId;
	  document.forms(0).target = 'ifrOculto';
	  DoSubmit();	
	}
	else{
	   alert(strMensajeEliminar);    
	}
}

function fnUpdArticuloPorIframe(intAccion, intTransferenciaId, strArticuloId, strArticuloDescripcion, strPrecioNormalConImpuesto, strListaArticulos, intRegistrosListaArticulos, intError) {
   document.forms(0).txtIntTransferenciaId.value = intTransferenciaId; 
   
   // BUSCAR DE ARTICULO
   if (intAccion == 0) { 
              
       document.forms(0).txtIntArticuloId.value = strArticuloId;
	   document.forms(0).hdnIntArticuloId.value = strArticuloId;
       document.forms(0).txtStrArticuloDescripcion.value = strArticuloDescripcion; 
       document.forms(0).hdnPrecioNormalConImpuesto.value = strPrecioNormalConImpuesto;
       
       if (intError == 0) {
           document.forms(0).txtCantidad.focus();
           document.forms(0).txtCantidad.select(); 
       }
       else {
           document.forms(0).txtIntArticuloId.value='';
           document.forms(0).txtStrArticuloDescripcion.value = '';           
           document.forms(0).txtCantidad.value='';
           document.forms(0).hdnIntArticuloId.value = '';
           document.forms(0).hdnPrecioNormalConImpuesto.value= '';
           
           alert("Artículo no encontrado."); 
 
           document.forms(0).txtIntArticuloId.focus();
           document.forms(0).txtIntArticuloId.select();           
       }
   }
   
   // AGREGAR Y ELIMINAR ARTICULO A LA TRANSFERENCIA
   if (intAccion == 1 || intAccion == 2) { 
       var strMensaje = "";              
       document.all.divRecordBrowser.innerHTML = strListaArticulos;                
                     	
       if (intRegistrosListaArticulos < 1) {
           fnHabilitaDeshabilitaControlesEncabezado(true); //Habiliar cuando no hay articulos en la transferencia
       } 
       else {
           fnHabilitaDeshabilitaControlesEncabezado(false); //Deshabilita si ya hay articulos en la transferencia
       }
       
       if (intError == 0) {
           document.forms(0).hdnArticulosTransferencia.value = intRegistrosListaArticulos;
       }
       else {           
           // AGREGAR ARTICULO A LA TRANSFERENCIA                                    
           if (intAccion == 1 ) { 
           
               strMensaje = "Error al agregar Articulo";
               
               if (intError == -100) {
                   strMensaje = "No se pudo iniciar el registro de la transferencia";
               }
               if (intError == -110) {
                   strMensaje = "No se pudo agregar el articulo a la transferencia";
               }
           }
           
           // ELIMINAR ARTICULO A LA TRANSFERENCIA                  
           if (intAccion == 2) { 
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

function intAgregarBulto() {   
   var valida=true;
   		
   // No de Sucursal
   if(valida){ valida=blnValidarCampo(document.forms(0).txtCompaniaQueRecibe,true,"Compania que recibe",cintTipoCampoEntero,4,1,""); } 
   if(valida){ valida=blnValidarCampo(document.forms(0).txtSucursalQueRecibe,true,"Sucursal que recibe",cintTipoCampoEntero,4,1,""); } 
   if(valida){ 
       valida=blnValidarCampo(document.forms(0).txtDescripcionSucursal,true,"Verificar la Sucursal que Recibe",cintTipoCampoAlfanumerico,255,1,""); 
       document.forms(0).txtCompaniaQueRecibe.select();
   } 
   if(valida){
       var strCompaniaId = "<%=intCompaniaId%>";
       var strSucursalId = "<%=intSucursalId%>";
       	  	  
       if ( strCompaniaId == Trim(document.forms(0).txtCompaniaQueRecibe.value)  &&  strSucursalId == Trim(document.forms(0).txtSucursalQueRecibe.value)) {
           alert("La Sucursal que Recibe no puede ser la misma que Envia, verificar");
           valida = false;	  
       }	
   } 
   	
   // Tipo de Transferencia
   if(valida) {valida=blnValidarCombo(document.forms(0).cboTipoTES,'-1','TIPO TES',true) }
   	
   // Tipo de Motivo
   if(valida){ valida=blnValidarCombo(document.forms(0).cboMotivo,'-1','Motivo',true) }

   //Tipo TES con MOTIVO		
   if (valida && document.forms(0).cboTipoTES.value == 1 && document.forms(0).hdnUENSucursalRecibo.value == 10 && document.forms(0).cboMotivo.value != 2 && document.forms(0).cboMotivo.value != 3 ) {
       valida = false;
       alert("Transferencia y Motivo no validos al CEDIS");	      
   }
   
   if (valida && (document.forms(0).cboTipoTES.value != 1 && document.forms(0).hdnUENSucursalRecibo.value != 10) ) {
       valida = false;       
       alert("Para Devoluciones/Reclamaciones capturar en Sucursal un número de CEDIS");	            
   }
   		
   //Numero de Bulto
   if(valida){ valida=blnValidarCampo(document.forms(0).txtNumeroBulto,true,"Número de Bulto",cintTipoCampoEntero,20,1,""); } 
   
   // Validaciones Terminadas
   if(valida){
	    document.forms(0).action = "<%=strFormAction%>?strCmd=AgregarBulto";
	    document.forms(0).target="ifrOculto";
	    DoSubmit();
   }	
}

function intEliminarBulto(intTransferenciaId, strBultoNumero) {
   var strMensajeEliminar = "";
   var intEliminar = true;
   intValor = (document.forms(0).txtIntFolioTransferencia.value) * 1;
   
   if(intValor>0){
       intEliminar =false;
       strMensajeEliminar = 'Imposible Eliminar, la transferencia ya fue registrada.';
   }
   
   if (intEliminar && document.all.tblCapturaBultos.style.display == 'none') {
	   intEliminar=false; 	   
	   strMensajeEliminar = 'Imposible Eliminar, debe entrar a captura de bultos.';
	}
	
   if (intEliminar) {
       document.forms(0).action = "<%=strFormAction%>?strCmd=EliminarBulto&intTransferenciaBultoEliminarId=" + intTransferenciaId + "&strNumeroBultoEliminarId=" + strBultoNumero;
       document.forms(0).target = 'ifrOculto';
       DoSubmit();
   }
   else {
      alert(strMensajeEliminar);
   }
}

function fnUpdBultoPorIframe(intAccion, strListaBultos,intRegistrosListaBultos, intError) {
   document.all.divDetalleBultos.innerHTML = strListaBultos;     
   document.forms(0).hdnBultosTransferencia.value = intRegistrosListaBultos;      
        
   if (intAccion == 1) { // Agregar de Bulto          
           if (intError == -100) {
               alert("No se encuentra detalle de transferencia, Bulto no puede agregarse");
           }
           if (intError == -110) {
               alert("Capturar el número de bulto");
           }
           if (intError == -120) {
               alert("Error al agregar Bulto a la transferencia");
           }              
   }    
   
   if(intAccion == 2) { // Eliminar Bulto
           if (intError == -100) {
               alert("No se pudo Eliminar el numero de Bulto");
           }                  
   }
   
   document.forms(0).txtNumeroBulto.value  ="";
   document.forms(0).txtNumeroBulto.focus();

}

function cmdCancelarBulto_onclick() {
   document.all.divCapturaDeProductos.style.display='';
   
   if (document.forms(0).hdnBultosTransferencia.value < 1) {
       document.all.divBultos.style.display='none';    
   }
   document.all.tblCapturaBultos.style.display='none';    
   
   document.forms(0).txtCifraDeControl.focus();
}


function txtCifraDeControl_onKeyDown(){
	if(event.keyCode==13){ document.forms(0).cmdRegistrar.click(); }
}

function cmdRegistrar_onclick() {
	valida=true; 
	
	//Sucursal que recibe
	if(valida){ valida=blnValidarCampo(document.forms(0).txtSucursalQueRecibe,true,"Sucursal que recibe",cintTipoCampoEntero,15,1,""); } 
	//Motivo Transferencia
	if(valida){ valida=blnValidarCombo(document.forms(0).cboMotivo,'-1','Motivo',true) }
    //Cifra Control
    if(valida){ valida=blnValidarCifraDeControl(); }
  
    if(valida){ 		
		document.forms(0).action = "<%=strFormAction%>?strCmd=RegistrarTransferencia";
	    document.forms(0).target="ifrOculto";
		DoSubmit(); 
	}
}

function fnRegistrarTransferenciaPorIframe(IntTransferenciaId,intTransferenciaFolio, strListaArticulos, intRegistrosListaArticulos, intError) {
   if (intError == 0) {   
	    document.forms(0).txtIntFolioTransferencia.value = intTransferenciaFolio;
		document.forms(0).cmdRegistrar.disabled=true;
		document.forms(0).cmdRegistrar.title='La transferencia ya fue registrada.';
		document.forms(0).txtCifraDeControl.readOnly=true;
		document.forms(0).txtCifraDeControl.className="campotabladeshabilitado";
		document.forms(0).txtCifraDeControl.title='La transferencia ya fue registrada.';
		document.forms(0).cmdAgregar.disabled=true;
		document.forms(0).cmdAgregar.title='La transferencia ya fue registrada.';
		document.all.divCapturaDeProductos.style.display='none';
		document.all.tblCapturaBultos.style.display='none';
		
		document.forms(0).cmdOtraCaptura.style.display='';
		document.forms(0).cmdBultos.style.display='none';	
		alert("Transferencia Registrada con el Folio : [" + intTransferenciaFolio + "]");
   }
   else {
        alert("No fue posible registrar la transferencia manual.");
   }
 
}


function cboTipoTES_onchange() {
   var intTipoTES = document.forms(0).cboTipoTES.value;   	
   
   var intCuentaElementos;
   
   intCuentaElementos = document.forms[0].elements["cboMotivo"];
   intCuentaElementos = intCuentaElementos.length - 1;
    
   for (i=intCuentaElementos;i>=0;i--) {  
       document.forms[0].elements["cboMotivo"].options[i] = null;   
   }  
   	
   if (intTipoTES == 1) {
       <%=strGeneraListaMotivosTES("cboMotivo")%>
       document.all.divDatosAdicionales.style.display='none';       
   }
   
   if (intTipoTES == 2) {
       <%=strGeneraListaMotivosDevoluciones("cboMotivo")%>
       document.all.divDatosAdicionales.style.display='';       
   }
   if (intTipoTES == 3) {    
       <%=strGeneraListaMotivosReclamaciones("cboMotivo")%>
       document.all.divDatosAdicionales.style.display='';       
   }
   
   document.forms(0).hdnCompaniaQueRecibe.value='';
   document.forms(0).hdnSucursalQueRecibe.value='';
   document.forms(0).txtCompaniaQueRecibe.value='';
   document.forms(0).txtSucursalQueRecibe.value='';
   document.forms(0).txtDescripcionSucursal.value='';

}

function blnValidarCifraDeControl(){
	valida=true;
	if (valida){
		intHdnTotalDePartidas = (document.forms(0).hdnArticulosTransferencia.value) * 1;
		if(intHdnTotalDePartidas<1){
			alert("Debe existir al menos un producto en el detalle.");
			valida=false;
		}
	}
	if (valida){ valida=blnValidarCampo(document.forms(0).txtCifraDeControl,true,"Cifra de control",cintTipoCampoEntero,10,1,""); } 
	if (valida){
		TotalDePartidas = document.forms(0).hdnArticulosTransferencia.value;
		TotalDePartidas = TotalDePartidas * 1;
		
		//La suma de todas las partidas debe ser igual a la cifra de control
		intTotal = 0;
		for (i = 1;  i < (TotalDePartidas+1);  i++) {
			intTotal = (intTotal*1) + (document.forms(0).elements('txtCantidad_'+i).value * 1);
		}
		
		inttxtCifraDeControl = (document.forms(0).txtCifraDeControl.value) * 1;
		if(inttxtCifraDeControl==intTotal){
			valida=true;
		}
		else {
			alert('La cifra de control no corresponde al total de artículos.');
			document.forms(0).txtCifraDeControl.select();
			valida=false;
			return(valida);
		}
	}
	intBultosTransferencia =  document.forms(0).hdnBultosTransferencia.value * 1;
	if (valida && intBultosTransferencia < 1) {
	   valida = confirm("No se capturaron bultos a la transferencia \rCONTINUAR?");
	}
	return(valida);
}

function cmdonKeyPressed(intObjeto,tecla) {
 if (tecla == 13 || tecla==9) {
       if (intObjeto==1) {
           document.forms(0).cboMotivo.focus();
       }
       if (intObjeto==2) {
           document.forms(0).txtCompaniaQueRecibe.focus();
       }   
        if (intObjeto==3) {
           document.forms(0).txtNumeroRemision.focus(); 
       }     
       if (intObjeto==11) {
       document.forms(0).txtObservaciones.focus();      
       }
       if (intObjeto==12) {
       document.forms(0).txtIntArticuloId.focus();      
       }
	   if (intObjeto==20) {
       document.forms(0).cmdAgregarBulto.focus();      
       }
       if (intObjeto==30) {
           txtIntArticuloId_onblur();     
       } 
       if (intObjeto==31) {
           document.forms(0).cmdAgregar.focus();   
       }        
       event.returnValue = false;
   }
  
}


//-->
</script>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaCapturarTransferenciaManual">
  <table cellSpacing="0" cellPadding="0" width="780" border="0">
    <tr>
      <input type="hidden" name="hdnCompaniaQueRecibe">
      <input type="hidden" name="hdnSucursalQueRecibe">
      <input type="hidden" name="hdnUENSucursalRecibo">
      <input type="hidden" name="txtIntTransferenciaId">
      <input type="hidden" name="hdnIntArticuloId">
      <input type="hidden" name="hdnPrecioNormalConImpuesto">
      <input type="hidden" name="hdnRemisionElectronicaId">
      <input type="hidden" name="hdnArticulosTransferencia">
      <input type="hidden" name="hdnBultosTransferencia">
    </tr>
    <tr>
      <td>
        <div id="ToPrintTxtSucursal">
          <table cellSpacing="0" cellPadding="0" width="780" border="0">
            <tr>
              <td class="tdnodesucursal" width="78">
                <script language="javascript">strCompaniaSucursal()</script>
              </td>
              <td class="tdnombresucursal" width="522">
                <script language="javascript">strSucursalNombre()</script>
              </td>
              <td class="tdbotonestop" width="170"> <a onmouseover="MM_swapImage('Image1','','../static/images/bsalir_on.gif',1)" onmouseout="MM_swapImgRestore()"
											href="javascript:cmdSalirImg_onclick()"><img height="19" alt="salir" src="../static/images/bsalir_off.gif" width="65" border="0"
												name="Image1"></a><a onmouseover="MM_swapImage('Image2','','../static/images/bayuda_on.gif',1)" onmouseout="MM_swapImgRestore()"
											href="#"><img height="19" alt="ayuda" src="../static/images/bayuda_off.gif" width="65" border="0"
												name="Image2"></a></td>
            </tr>
          </table>
        </div>
      </td>
    </tr>
    <tr>
      <td>
        <table cellSpacing="0" cellPadding="0" width="780" border="0">
          <tr>
            <td class="tdlogo" width="520" rowSpan="2"> <img src="../static/images/logo.gif" width="255" height="51"></td>
            <td width="90" height="26">&nbsp;</td>
            <td width="170" class="tdnombreusuario">
              <script language="javascript">strUsuarioNombre()</script>
            </td>
          </tr>
          <tr>
            <td width="90" height="51" align="right" class="tdbusqueda">&nbsp;</td>
            <td class="tdbusquedacampo" vAlign="middle" width="170">&nbsp; </td>
          </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td height="34"> <img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr>
      <td>
        <table cellSpacing="0" cellPadding="0" width="780" border="0">
          <tr>
            <td width="10" bgColor="#ffffff"> <img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja">
              <div id="ToPrintTxtMigaja"> <span class="txdmigaja">Está en : </span> <a href="javascript:strHrefMigaja1();" class="txdmigaja">
                <script language="javascript">strTituloMigaja1()</script>
                </a> <span class="txdmigaja">: <a class="txdmigaja" href="javascript:strHrefMigaja2();">
                <script language="javascript">strTituloMigaja2()</script>
                </a>: <a class="txdmigaja" href="javascript:strHrefMigaja3();">
                <script language="javascript">strTituloMigaja3()</script>
                </a>:
                <script language="javascript">strTituloPrincipalDePagina()</script>
                </span> </div>
            </td>
            <td width="187" class="tdfechahora">
              <div id="ToPrintTxtFecha">
                <script language="javascript">strGetCustomDateTime()</script>
              </div>
            </td>
          </tr>
          <tr>
            <td width="10">&nbsp;</td>
            <td class="tdtablacont" vAlign="top" width="583"> <span class="txtitulo">
              <script language="javascript">strTituloPrincipalDePagina()</script>
              </span><span class="txcontenido">
              <script language="javascript">strDescripcionPrincipalDePagina()
										</script>
              <br>
              </span>
              <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                <tr>
                  <td width="63" class="tdtittablas">Sucursal:</td>
                  <td class="tdconttablas" vAlign="middle" width="190">
                    <script language="javascript">strCompaniaSucursal()</script>
                    <script language="javascript">strSucursalNombre()</script>
                  </td>
                  <td class="tdtittablas" vAlign="middle" width="84">Fecha y
                    hora:</td>
                  <td class="tdconttablas" vAlign="middle" width="231">
                    <script language="javascript">strGetCustomDateTime()</script>
                  </td>
                </tr>
              </table>
              <br>
              <div id="ToPrintHtmContenido">
                <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                  <tr>
                    <td width="145" class="tdtittablas">Fecha de envío:</td>
                    <td class="campotablaresultado" valign="middle"> <%=clsCommons.strGetCustomDateTime("dd/MM/yyyy") %> </td>
                  </tr>
                  <tr>
                    <td class="tdtittablas" width="145">Transferencia:</td>
                    <td class="tdpadleft5" vAlign="middle">
                      <input class="campotabladeshabilitado" readOnly type="text" size="16" name="txtIntFolioTransferencia">
                    </td>
                  </tr>
                </table>
                <br>
                <span class="txsubtitulo"> <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Datos
                de la transferencia</span>
                <table  id="tblDevo1" cellSpacing="0" cellPadding="0" width="100%" border="0">
                  <tr>
                    <td class="tdtittablas" width="160">Tipo Transferencia:</td>
                    <td class="tdpadleft5" vAlign="middle">
                      <select class="campotabla" onchange="return cboTipoTES_onchange()" onkeypress="cmdonKeyPressed(1,event.keyCode);"
														name="cboTipoTES">
                        <option value="0" selected>Elija una condición</option>
                        <option value="1">TES SUCURSAL</option>
                        <option value="2">DEVOLUCIONES</option>
                        <option value="3">RECLAMACIONES</option>
                      </select>
                    </td>
                  </tr>
                  <tr>
                    <td class="tdtittablas" width="160" height="28">Motivo:</td>
                    <td class="tdpadleft5" vAlign="middle">
                      <select class="campotabla" onkeypress="cmdonKeyPressed(2,event.keyCode);" name="cboMotivo">
                      </select>
                    </td>
                  </tr>
                  <tr>
                    <td class="tdtittablas" width="160">Sucursal que recibe:</td>
                    <td class="tdpadleft5" >
                      <input class="campotabla" onkeydown="txtCompaniaQueRecibe_onKeyDown()" type="text" maxLength="4"
														size="4" name="txtCompaniaQueRecibe">
                      <input class="campotabla" onkeydown="txtSucursalQueRecibe_onKeyDown()" onblur="return txtSucursalQueRecibe_onblur()"
														type="text" maxLength="4" size="4" name="txtSucursalQueRecibe">
&nbsp; <a id="objLupaSucursalRecibo" onclick="return objLupaSucursalRecibo_onClick()" href="javascript:;"> <img height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"></a> <span class="txconttablasrojo">
                      <input class="campotablaresultado" id="txtDescripcionSucursal" readOnly maxLength="40"
															size="40" border="0" name="txtDescripcionSucursal">
                      </span></td>
                  </tr>
                </table>
                <div id="divDatosAdicionales" style="DISPLAY: none">
                  <table id="tblDevo2" cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <tr>
                      <td class="tdtittablas" width="160">Empleado autorizado: </td>
                      <td class="tdpadleft5" vAlign="middle">
                        <select class="campotabla" name="cboEmpleadoAutorizado" onkeypress="cmdonKeyPressed(3,event.keyCode);">
                          <option value="0" selected>Elija un empleado autorizado&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </option>
                        </select>
                      </td>
                    </tr>
                    <tr>
                      <td class="tdtittablas" width="160">Remisión:</td>
                      <td class="tdpadleft5" vAlign="middle" >
                        <input name="txtNumeroRemision" onkeypress="cmdonKeyPressed(11,event.keyCode);" onblur="return txtNumeroRemision_onblur()"
															class="campotabla" type="text" maxLength="12" size="12">
                      </td>
                    </tr>
                  </table>
                </div>
                <table id="tblDevo3" cellSpacing="0" cellPadding="0" width="100%" border="0">
                  <tr>
                    <td class="tdtittablas" width="160">Observaciones:</td>
                    <td class="tdpadleft5" vAlign="middle" >
                      <input name="txtObservaciones" onkeypress="cmdonKeyPressed(12,event.keyCode);" type="text"
														maxLength="2000" class="campotabla" size="90">
                    </td>
                  </tr>
                </table>
                <br>
                <span class="txsubtitulo"> <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Detalle
                de productos</span>
                <div id="divRecordBrowser"> </div>
                <div id="divBultos" style="DISPLAY: none"> <span class="txsubtitulo"> <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Bultos
                    en la transferencia </span>
                  <div width="440" id="divDetalleBultos" name="divDetalleBultos"></div>
                  <table id="tblCapturaBultos" class="tdenvolventetablas" width="100%" style="DISPLAY: none">
                    <tr>
                      <td class="tdtittablas3" align="left" width="383">Número
                        de Bulto</td>
                      <td class="tdtittablas3" width="197" rowspan="2" align="right" valign="middle">&nbsp;
                        <input class="boton" type="button" value="Agregar Bulto" name="cmdAgregarBulto" onclick="return intAgregarBulto()">
                        <input class="boton" type="button" value="Cancelar" name="cmdCancelarBulto" onclick="return cmdCancelarBulto_onclick()">
                      </td>
                    </tr>
                    <tr>
                      <td class="txtitintabla" vAlign="middle" width="383">
                        <input class="campotabla" name="txtNumeroBulto" onkeypress="cmdonKeyPressed(20,event.keyCode);"
															type="text" maxLength="40" size="40">
                      </td>
                    </tr>
                  </table>
                </div>
                <div id="divCapturaDeProductos">
                  <table id ="tblDevo4" class="tdenvolventetablas" width="100%">
                    <tr>
                      <td class="tdtittablas3" align="left" width="100">Código:</td>
                      <td class="tdtittablas3" align="left" width="120">Cantidad</td>
                      <td class="tdtittablas3" align="left" width="240">Descripción</td>
                      <td vAlign="middle" width="80" rowSpan="2">
                        <input class="boton" onclick="return intAgregarArticulo()" type="button" value="Agregar"
															name="cmdAgregar">
                      </td>
                    </tr>
                    <tr>
                      <td class="txtitintabla" vAlign="middle" width="190" height="21">
                        <input class="campotabla" onkeypress="cmdonKeyPressed(30,event.keyCode);" onblur="txtIntArticuloId_onblur();"
															type="text" maxLength="16" size="18" name="txtIntArticuloId">
                        <a id="objLupaArticulo" onclick="return objLupaArticulo_onClick();" border="0"> <img height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"> </a> </td>
                      <td class="tdpadleft5" vAlign="middle">
                        <input class="campotabla" onkeypress="cmdonKeyPressed(31,event.keyCode);" onblur="return txtCantidad_onblur()"
															type="text" maxLength="4" size="18" name="txtCantidad">
                      </td>
                      <td class="txtitintabla" vAlign="middle" width="300">
                        <input class="campotablaresultadoenvolventeazul" readOnly type="text" size="32" name="txtStrArticuloDescripcion">
                      </td>
                    </tr>
                  </table>
                </div>
                <br>
                <div id="divBotones" style="DISPLAY: none">
                  <table id="TblBotones" cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <tr>
                      <td width="317">&nbsp;&nbsp;
                        <input class="boton" onclick="return cmdRegresar_onclick()" type="button" value="Regresar"
															name="cmdRegresar">
                        <input class="boton" onclick="return cmdImprimir_onclick()" type="button" value="Imprimir"
															name="cmdImprimir">
                        <input class="boton" type="button" value="Bultos" name="cmdBultos" onclick="return cmdBultos_onclick()">
                        <input class="boton" style="DISPLAY: none" onclick="return cmdOtraCaptura_onclick()" type="button"
															value="Otra Captura" name="cmdOtraCaptura">
                      </td>
                      <td class="tdenvolventetablas" align="center" width="200" bgColor="#f4f6f8">
                        <table cellSpacing="0" cellPadding="0" width="230" border="0">
                          <tr>
                            <td class="tdtittablas3" width="156">Cifra de control</td>
                            <td width="91" rowSpan="2">
                              <input class="boton" onclick="return cmdRegistrar_onclick()" type="button" value="Registrar"
																		name="cmdRegistrar">
                            </td>
                          </tr>
                          <tr>
                            <td vAlign="top" height="30">
                              <input class="campotabla" onkeydown="txtCifraDeControl_onKeyDown()" type="text" maxLength="4"
																		size="16" name="txtCifraDeControl">
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                  </table>
                </div>
                <table id="divFirmasUp" style="DISPLAY: none">
                  <tr>
                    <td height="21">&nbsp;</td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                  </tr>
                  <tr>
                    <td>_________________</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td>_________________</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td>_________________</td>
                  </tr>
                  <tr>
                    <td class="tdtittablas" align="center">&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="tdtittablas" align="center">Nombre y Firma</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="tdtittablas" align="center">&nbsp;</td>
                  </tr>
                  <tr>
                    <td class="tdtittablas" align="center">Gerencia que Surte</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="tdtittablas" align="center">Empleado que Recibe</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td class="tdtittablas" align="center">Gerencia que Recibe</td>
                  </tr>
                </table>
                <table id="divFirmasDn" style="DISPLAY: none">
                  <tr>
                    <td>&nbsp;</td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <!--td class="tdtittablas"> * Este documento no será válido
                            sin el nombre y firma de autorización del representante
                            del proveedor.* </td-->
                  </tr>
                </table>
                <br>
                <br>
              </div>
              <!-- cerramos el div ToPrintHtmContenido -->
            </td>
            <td class="tdcolumnader" vAlign="top" width="187" rowSpan="2">
              <script language="javascript">strGeneraTablaAyuda("");
									</script>
            </td>
          </tr>
          <tr>
            <td class="tdbottom" colSpan="2"><script language="JavaScript">crearTablaFooter()</script>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);	
	//-->
			</script>
</form>
<iframe name="ifrOculto" height="0" width="0" src=""></iframe>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</HTML>
