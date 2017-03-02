<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="popPedidoVentaCatalogoClienteAlta.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popPedidoVentaCatalogoClienteAlta" codePage="28592" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<% 
    '====================================================================
    ' Page          : popPedidoVentaCatalogoClienteAlta.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : 
    ' Copyright     : 2012 All rights reserved.
    ' Company       : Farmacias Benavides
    ' Author        : [JAHD] 
    ' Version       : 1.0
    ' Last Modified : 
    '                 31 de Octubre 2012 [JAHD]   
	'                 12 de Marzo   2013 [JAHD] Captura entre calles domicilio de entrega
    '====================================================================	
%>
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" src="../static/scripts/ToolsValRFC.js"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script language="javascript" src="../static/scripts/tools.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
var blnSinSeleccion =true;

function strIniciaDatos() { 
   var frmPedidoVentaCatalogoClienteAlta = document.forms[0];
   
   frmPedidoVentaCatalogoClienteAlta.elements["txtCalle"].value = "";
   frmPedidoVentaCatalogoClienteAlta.elements["txtNoExterior"].value = "";
   frmPedidoVentaCatalogoClienteAlta.elements["txtNoInterior"].value = "";
   frmPedidoVentaCatalogoClienteAlta.elements["txtColonia"].value = "";
   frmPedidoVentaCatalogoClienteAlta.elements["txtEstado"].value = "";
   frmPedidoVentaCatalogoClienteAlta.elements["txtCiudad"].value = "";   
   frmPedidoVentaCatalogoClienteAlta.elements["txtCodigoPostal"].value = "";    
   frmPedidoVentaCatalogoClienteAlta.elements["txtTelefono"].value = "";
   frmPedidoVentaCatalogoClienteAlta.elements["txtEMail"].value = "";
   
   frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaCalle"].value = "";
   frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaNoExterior"].value = "";
   frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaNoInterior"].value = "";
   frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaEntreCalles"].value = "";
   frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaColonia"].value = "";
   frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaEstado"].value = "";
   frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaCiudad"].value = "";
   frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaCodigoPostal"].value = "";   
   frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaTelefono"].value = ""; 
   frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaMovil"].value = ""; 
}

function fnEliminaElementos(strNombreComboCd){
  var frmPedidoVentaCatalogoClienteAlta =document.forms[0];	
  var intCuentaElementos;
  
  intCuentaElementos = document.forms[0].elements[strNombreComboCd];
  intCuentaElementos = intCuentaElementos.length - 1;
 
  for (i=intCuentaElementos;i>=0;i--){  
   frmPedidoVentaCatalogoClienteAlta.elements[strNombreComboCd].options[i] = null;   
  }   
}

function cboEstado_onchange(objSelecciona) {    
	var frmPedidoVentaCatalogoClienteAlta =document.forms[0]; 
    var ifrNombre="";
	
	if (objSelecciona==1) {
	    ifrNombre = "ifrOculto";
	    strNombreComboEdo= "cboEstado";
		strNombreComboCd= "cboCiudad";
		strNombretxtCd = "txtCiudad";
	}
	else {
	    ifrNombre = "ifrOculto2";
     	strNombreComboEdo= "cboEntregaEstado";
		strNombreComboCd= "cboEntregaCiudad";
		strNombretxtCd = "txtEntregaCiudad";
	}    	
	strObjetosCombo = "&strNombreComboEdo=" + strNombreComboEdo + "&strNombreComboCd=" + strNombreComboCd + "&strNombretxtCd=" + strNombretxtCd	;
	
	frmPedidoVentaCatalogoClienteAlta.target=ifrNombre;
	frmPedidoVentaCatalogoClienteAlta.action = "<%=strFormAction%>?strCmd=BuscarCiudad" + strObjetosCombo + "&intEstadoId=" + document.forms[0].elements[strNombreComboEdo].options[document.forms[0].elements[strNombreComboEdo].selectedIndex].value;
	
	frmPedidoVentaCatalogoClienteAlta.submit();
	frmPedidoVentaCatalogoClienteAlta.target="";	    
}

function cboCiudad_onchange(objSelecciona) {
	var frmPedidoVentaCatalogoClienteAlta =document.forms[0];

	if (objSelecciona==1) {	
       frmPedidoVentaCatalogoClienteAlta.elements["txtCiudad"].value = frmPedidoVentaCatalogoClienteAlta.elements["cboCiudad"].value;  
	}
	else {
	   frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaCiudad"].value = frmPedidoVentaCatalogoClienteAlta.elements["cboEntregaCiudad"].value;  
	}  
}
function cmdAgregar_onclick() {
        var frmPedidoVentaCatalogoClienteAlta =document.forms[0];

		document.all.divClientes.innerHTML = "";     
		document.all.divClientes.style.display='none'; 
		document.all.divDireccionEntrega.style.display=''; 
				
       	frmPedidoVentaCatalogoClienteAlta.elements["txtRazonSocial"].readOnly = false;
    	frmPedidoVentaCatalogoClienteAlta.elements["txtCalle"].readOnly = false;
        frmPedidoVentaCatalogoClienteAlta.elements["txtNoExterior"].readOnly = false;
        frmPedidoVentaCatalogoClienteAlta.elements["txtNoInterior"].readOnly = false;    
        frmPedidoVentaCatalogoClienteAlta.elements["txtColonia"].readOnly = false;
        frmPedidoVentaCatalogoClienteAlta.elements["cboEstado"].disabled = false;
	    frmPedidoVentaCatalogoClienteAlta.elements["cboCiudad"].disabled = false;    
        frmPedidoVentaCatalogoClienteAlta.elements["txtCodigoPostal"].readOnly = false;         
        frmPedidoVentaCatalogoClienteAlta.elements["txtTelefono"].readOnly = false;
        frmPedidoVentaCatalogoClienteAlta.elements["txtEMail"].readOnly = false;
        	
    	frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaCalle"].readOnly = false;
        frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaNoExterior"].readOnly = false;
        frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaNoInterior"].readOnly = false;    
		frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaEntreCalles"].readOnly = false;  
        frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaColonia"].readOnly = false;
        frmPedidoVentaCatalogoClienteAlta.elements["cboEntregaEstado"].disabled = false;
     	frmPedidoVentaCatalogoClienteAlta.elements["cboEntregaCiudad"].disabled = false;    
        frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaCodigoPostal"].readOnly = false;         
        frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaTelefono"].readOnly = false; 
        frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaMovil"].readOnly = false; 
		
		frmPedidoVentaCatalogoClienteAlta.elements["txtRFC"].focus(); 
     				
}

function cmdBuscar_onclick() {
    var frmPedidoVentaCatalogoClienteAlta =document.forms[0];

	strIniciaDatos();	
	frmPedidoVentaCatalogoClienteAlta.action = "<%=strFormAction%>?strCmd=BuscarCliente"
    frmPedidoVentaCatalogoClienteAlta.target="ifrOculto";
    frmPedidoVentaCatalogoClienteAlta.submit();
    frmPedidoVentaCatalogoClienteAlta.target='';  
}

function cmdCerrar_onclick() {
    fnAceptarClientePorIframe(0,0,"",""); 
}

function fnRecordBrowserCliente(intRecordBrowserCliente,strRecordBrowserCliente){
    var frmPedidoVentaCatalogoClienteAlta =document.forms[0];
		
    if(intRecordBrowserCliente==0) {
     	cmdAgregar_onclick();
		alert ("Cliente no encontrado \r\r Capturar el Alta");
		frmPedidoVentaCatalogoClienteAlta.elements["txtRFC"].focus(); 
	}
	else {
	    document.all.divDireccionEntrega.style.display='none'; 
        document.all.divClientes.innerHTML = "<br><table cellSpacing=\"0\" cellPadding=\"0\" width=\"100%\" border=\"0\"><tr><td align=\"right\"><input class=\"boton\" onclick=\"return cmdAgregar_onclick()\" type=\"button\" value=\"Agregar\"name=\"cmdAgregar\">&nbsp;&nbsp;</td></tr></table><br>" + strRecordBrowserCliente;     
        document.all.divClientes.style.display='';     
	}		
}

function cmdSeleccionarCliente(intClienteFiscalId, strRFC, strRazonSocial, strCalle, strNoExterior, strNoInterior, strColonia, strCiudad, strEstado, strCodigoPostal, strTelefono, strEmail,strEntregaCalle,strEntregaNoExterior,strEntregaNoInterior,strEntregaEntreCalles,strEntregaColonia,intEntregaCiudadId,intEntregaEstadoId,strEntregaCodigoPostal,strEntregaTelefono,strEntregaMovil) {
    var frmPedidoVentaCatalogoClienteAlta = parent.document.forms[0];

    // Desactivamos el campo de RFC
    frmPedidoVentaCatalogoClienteAlta.elements["txtRFC"].value = strRFC;	    
    frmPedidoVentaCatalogoClienteAlta.elements["txtRFC"].readOnly =true;
	
    frmPedidoVentaCatalogoClienteAlta.elements["txtRazonSocial"].value = strRazonSocial;
	
    frmPedidoVentaCatalogoClienteAlta.elements["txtCalle"].value = strCalle;
    frmPedidoVentaCatalogoClienteAlta.elements["txtNoExterior"].value = strNoExterior;
    frmPedidoVentaCatalogoClienteAlta.elements["txtNoInterior"].value = strNoInterior;    
    frmPedidoVentaCatalogoClienteAlta.elements["txtColonia"].value = strColonia;    
    frmPedidoVentaCatalogoClienteAlta.elements["txtCiudad"].value = strCiudad;                            
    frmPedidoVentaCatalogoClienteAlta.elements["txtEstado"].value = strEstado;            
    frmPedidoVentaCatalogoClienteAlta.elements["txtTelefono"].value = strTelefono;    
    frmPedidoVentaCatalogoClienteAlta.elements["txtCodigoPostal"].value = strCodigoPostal;
    frmPedidoVentaCatalogoClienteAlta.elements["txtEMail"].value = strEmail;
    
	intElementos = (frmPedidoVentaCatalogoClienteAlta.elements["cboEstado"]).length - 1;	
    for (i= 0;i<=intElementos;i++) { 
       strEstadoBuscar = frmPedidoVentaCatalogoClienteAlta.elements["cboEstado"].options[i].value; 	                        
       if (strEstadoBuscar == strEstado){	
           frmPedidoVentaCatalogoClienteAlta.elements["cboEstado"].options[i].selected=true;
           parent.cboEstado_onchange(1);                  
       }                                                         
    }
	
	frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaCalle"].value = strEntregaCalle;
    frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaNoExterior"].value = strEntregaNoExterior;
    frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaNoInterior"].value = strEntregaNoInterior;    
	frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaEntreCalles"].value = strEntregaEntreCalles;
    frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaColonia"].value = strEntregaColonia;    
    frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaCiudad"].value = intEntregaCiudadId;                            
    frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaEstado"].value = intEntregaEstadoId;            
    frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaCodigoPostal"].value = strEntregaCodigoPostal;
    frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaTelefono"].value = strEntregaTelefono;
    frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaMovil"].value = strEntregaMovil;   
	
	intElementos = (frmPedidoVentaCatalogoClienteAlta.elements["cboEntregaEstado"]).length - 1;	
    for (i= 0;i<=intElementos;i++) {                         
       strEstadoBuscar = frmPedidoVentaCatalogoClienteAlta.elements["cboEntregaEstado"].options[i].value;
       if (strEstadoBuscar == intEntregaEstadoId){
           frmPedidoVentaCatalogoClienteAlta.elements["cboEntregaEstado"].options[i].selected=true;
           parent.cboEstado_onchange(2);                  
       }                                                         
    } 
				
	frmPedidoVentaCatalogoClienteAlta.elements["txtRazonSocial"].readOnly = false;
	frmPedidoVentaCatalogoClienteAlta.elements["txtCalle"].readOnly = false;
    frmPedidoVentaCatalogoClienteAlta.elements["txtNoExterior"].readOnly = false;
    frmPedidoVentaCatalogoClienteAlta.elements["txtNoInterior"].readOnly = false;    
    frmPedidoVentaCatalogoClienteAlta.elements["txtColonia"].readOnly = false;
    frmPedidoVentaCatalogoClienteAlta.elements["cboEstado"].disabled = false;
	frmPedidoVentaCatalogoClienteAlta.elements["cboCiudad"].disabled = false;    
    frmPedidoVentaCatalogoClienteAlta.elements["txtCodigoPostal"].readOnly = false;         
    frmPedidoVentaCatalogoClienteAlta.elements["txtTelefono"].readOnly = false;
    frmPedidoVentaCatalogoClienteAlta.elements["txtEMail"].readOnly = false;
	
	frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaCalle"].readOnly = false;
    frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaNoExterior"].readOnly = false;
    frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaNoInterior"].readOnly = false;    
	frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaEntreCalles"].readOnly = false;    
    frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaColonia"].readOnly = false;
    frmPedidoVentaCatalogoClienteAlta.elements["cboEntregaEstado"].disabled = false;
	frmPedidoVentaCatalogoClienteAlta.elements["cboEntregaCiudad"].disabled = false;    
    frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaCodigoPostal"].readOnly = false;         
    frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaTelefono"].readOnly = false;
    frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaMovil"].readOnly = false;      
    	  
	document.all.divDireccionEntrega.style.display=''; 
    document.all.divClientes.style.display='none';  
	frmPedidoVentaCatalogoClienteAlta.elements["txtRazonSocial"].focus();   
}	   

function cmdCancelar_onclick() {
    var frmPedidoVentaCatalogoClienteAlta = document.forms[0];
	
    frmPedidoVentaCatalogoClienteAlta.elements["txtRFC"].value = "";   
    frmPedidoVentaCatalogoClienteAlta.elements["txtRazonSocial"].value = "";   

    strIniciaDatos();
	
	document.all.divDireccionEntrega.style.display='none'; 
	document.all.divClientes.innerHTML = "";     
    document.all.divClientes.style.display='none'; 
	
	frmPedidoVentaCatalogoClienteAlta.elements["txtRFC"].readOnly =false;
	frmPedidoVentaCatalogoClienteAlta.elements["txtRFC"].focus();   
}

function validarEmail(valor) 
{       
   if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/ .test(valor))
   {   
      return true;
   } 
   else 
   {   
      return false;  
   }
}
function validarTelefono(valor) 
{  
   if (/^[0-9]{2,3}-? ?[0-9]{6,8}$/ .test(valor))
   {   
      return true;
   } 
   else 
   {   
      return false;  
   }
}
function cmdAceptar_onclick() {

   var frmPedidoVentaCatalogoClienteAlta = document.forms[0];
   var valida = true;   
   
   // Realizamos la validación de los campos

   //-------------------------------------------------------------------------------------------------   
   // **************************     R F C 
   //-------------------------------------------------------------------------------------------------
   // Que se capture un RFC
   if (Trim(frmPedidoVentaCatalogoClienteAlta.elements["txtRFC"].value) == "" || Trim(frmPedidoVentaCatalogoClienteAlta.elements["txtRFC"].value) == " "){
       alert("El campo de 'RFC' no debe de quedar vacío");
       frmPedidoVentaCatalogoClienteAlta.elements["txtRFC"].focus();
       return(false); 
   }      
   // Verificamos que sea un RFC valido
   if (valida){valida=blnValidarRFC(frmPedidoVentaCatalogoClienteAlta.elements["txtRFC"],"RFC",true);} 
       if (!valida){
		return(valida);
   }      
   // Que sean solo caracters permitidos 
   var checkOK = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789&$#";
   var checkStr = frmPedidoVentaCatalogoClienteAlta.elements["txtRFC"].value;
   var allValid = true;   
   for (i = 0;  i < checkStr.length;  i++) {
       ch = checkStr.charAt(i);
       for (j = 0;  j < checkOK.length;  j++) 
           if (ch == checkOK.charAt(j))
               break;
           if (j == checkOK.length)    {
               allValid = false;
               break;
           }
   }   
   if (!allValid)
   {
       alert("El RFC esta capturado incorrectamente.");
       frmPedidoVentaCatalogoClienteAlta.elements["txtRFC"].focus();
       return (false);
   }
   
    //-------------------------------------------------------------------------------------------------   
   // **************************  Raxon social
   //--------------------------------------------------------------------------------------------------
   if (valida){ 
       valida=blnValidarCampo(frmPedidoVentaCatalogoClienteAlta.elements["txtRazonSocial"],true,"Razon Social", cintTipoCampoCadenaDefinida,100,1,"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789&#-. $"); 
       if (!valida){return(valida);}
   }

   //-------------------------------------------------------------------------------------------------   
  // **************************  Datos domicilio FISCAL
  //-------------------------------------------------------------------------------------------------- 


  // **************************  Calle
   if (valida){ 
       valida=blnValidarCampo(frmPedidoVentaCatalogoClienteAlta.elements["txtCalle"],true,"Calle", cintTipoCampoCadenaDefinida,50,1,"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789&#-. $"); 
       if (!valida){return(valida);}
   }
  // **************************  No Exterior
   if (valida){ 
       valida=blnValidarCampo(frmPedidoVentaCatalogoClienteAlta.elements["txtNoExterior"],true,"No. Exterior", cintTipoCampoCadenaDefinida,15,1,"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789&#-. $"); 
       if (!valida){return(valida);}
   }
  // **************************  No Interior
   if (valida){ 
       valida=blnValidarCampo(frmPedidoVentaCatalogoClienteAlta.elements["txtNoInterior"],true,"No. Interior", cintTipoCampoCadenaDefinida,15,1,"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789&#-. "); 
       if (!valida){return(valida);}
     }           
  // **************************  Colonia
   if (valida){ 
       valida=blnValidarCampo(frmPedidoVentaCatalogoClienteAlta.elements["txtColonia"],true,"Colonia", cintTipoCampoCadenaDefinida,50,1,"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789&#-. $"); 
       if (!valida){return(valida);}
     }

  // **************************  Seleccionado Estado
   intIndice = frmPedidoVentaCatalogoClienteAlta.elements["cboEstado"].selectedIndex;
 
   if (parseInt(intIndice) < 1){
       alert("Seleccionar un estado");
       frmPedidoVentaCatalogoClienteAlta.elements["cboEstado"].focus();
       return(false); 
   }
  // **************************  Seleccionado ciudad
   intIndice = frmPedidoVentaCatalogoClienteAlta.elements["cboCiudad"].selectedIndex;
   
   if (parseInt(intIndice) < 1){
       alert("Seleccionar una Ciudad");
       frmPedidoVentaCatalogoClienteAlta.elements["cboCiudad"].focus();
       return(false); 
   }
   // **************************  Codigo Postal
   // 1 tipo de dato   
   if (valida){ 
       valida=blnValidarCampo(frmPedidoVentaCatalogoClienteAlta.elements["txtCodigoPostal"],true,"Codigo Postal", cintTipoCampoCadenaDefinida,5,5,"0123456789");
       if (!valida){return(valida);}
     }
   // 2 valor
   if (valida && frmPedidoVentaCatalogoClienteAlta.elements["txtCodigoPostal"].length <5){ 
       alert("Capturar un código postal valido");
       frmPedidoVentaCatalogoClienteAlta.elements["txtCodigoPostal"].focus();             
       return(false); 
     }   
	 
  // **************************  Telefono
   if (valida){ 
       valida=validarTelefono(frmPedidoVentaCatalogoClienteAlta.elements["txtTelefono"].value);
       if (!valida){alert(" Telefono de dirección fiscal invalido \n\n Verificar el formato capturado ");frmPedidoVentaCatalogoClienteAlta.elements["txtTelefono"].focus();  return(valida);}
   }	 
   // **************************  email
   if (valida && (frmPedidoVentaCatalogoClienteAlta.elements["txtEMail"].value).length>0){ 
       valida=validarEmail(frmPedidoVentaCatalogoClienteAlta.elements["txtEMail"].value);
       if (!valida){alert(" Correo invalido \n\n Verificar el formato capturado \n\n Si no cuenta con correo dejar vacio el campo");frmPedidoVentaCatalogoClienteAlta.elements["txtEMail"].focus(); return(valida);}
   }

   //-------------------------------------------------------------------------------------------------   
   // **************************  Datos domicilio ENTREGA
   //--------------------------------------------------------------------------------------------------

  // **************************  Calle
   if (valida){ 
       valida=blnValidarCampo(frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaCalle"],true,"Calle Entrega", cintTipoCampoCadenaDefinida,50,1,"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789&#-. $"); 
       if (!valida){return(valida);}
   }        

  // **************************  No Exterior
   if (valida){ 
       valida=blnValidarCampo(frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaNoExterior"],true,"No. Exterior Entrega", cintTipoCampoCadenaDefinida,15,1,"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789&#-. $"); 
       if (!valida){return(valida);}
   }        
  // **************************  No Interior
   if (valida){ 
       valida=blnValidarCampo(frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaNoInterior"],true,"No. Interior Entrega", cintTipoCampoCadenaDefinida,15,1,"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789&#-. "); 
       if (!valida){return(valida);}
     }  
  // **************************  EntreCalles
   if (valida){ 
       valida=blnValidarCampo(frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaEntreCalles"],true,"Entrecalles", cintTipoCampoCadenaDefinida,255,1,"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789&#-. "); 
       if (!valida){return(valida);}
     }          
  // **************************  Colonia
   if (valida){ 
       valida=blnValidarCampo(frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaColonia"],true,"Colonia Entrega", cintTipoCampoCadenaDefinida,50,1,"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789&#-. $"); 
       if (!valida){return(valida);}
     }     

  // **************************  Seleccionado Estado
   intIndice = frmPedidoVentaCatalogoClienteAlta.elements["cboEntregaEstado"].selectedIndex; 
   if (parseInt(intIndice) < 1){
       alert("Seleccionar un estado");
       frmPedidoVentaCatalogoClienteAlta.elements["cboEntregaEstado"].focus();
       return(false); 
   }
  // **************************  Seleccionado ciudad
   intIndice = frmPedidoVentaCatalogoClienteAlta.elements["cboEntregaCiudad"].selectedIndex;
   
   if (parseInt(intIndice) < 1){
       alert("Seleccionar una Ciudad");
       frmPedidoVentaCatalogoClienteAlta.elements["cboEntregaCiudad"].focus();
       return(false); 
   }
   // **************************  Codigo Postal
   // 1 tipo de dato   
   if (valida){ 
       valida=blnValidarCampo(frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaCodigoPostal"],true,"Codigo Postal Entrega", cintTipoCampoCadenaDefinida,5,5,"0123456789");
       if (!valida){return(valida);}
     }
   // 2 valor
   if (valida && frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaCodigoPostal"].value <length){ 
       alert("Capturar un código postal valido");
       frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaCodigoPostal"].focus();             
       return(false); 
    }     
     // **************************  Telefono
   if (valida){ 
       valida=validarTelefono(frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaTelefono"].value);
       if (!valida){alert(" Telefono de la dirección de entrega invalido \n\n Verificar el formato capturado "); frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaTelefono"].focus();  return(valida);}
   }      

   // **************************  Movil
   if (valida){ 
       valida=validarTelefono(frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaMovil"].value);
       if (!valida){alert(" Telefono adicional de la dirección de entrega invalido \n\n Verificar el formato capturado "); frmPedidoVentaCatalogoClienteAlta.elements["txtEntregaMovil"].focus(); return(valida);}
   }      
     	
    frmPedidoVentaCatalogoClienteAlta.target="ifrOculto";
    frmPedidoVentaCatalogoClienteAlta.action = "<%=strFormAction%>?strCmd=ActualizarCliente"
    frmPedidoVentaCatalogoClienteAlta.submit();      
    frmPedidoVentaCatalogoClienteAlta.target="";
}

function fnAceptarClientePorIframe(intResultado,intClienteFiscalId,strRFC, strlClienteFiscalRazonSocial) {
    if (intResultado < 0) {
	    alert("Error al actualizar informacion");
		opener.document.forms[0].elements['hdnClienteFiscalId'].value = 0;
        opener.document.forms[0].elements['txtClienteFiscalRFC'].value = '';
        opener.document.forms[0].elements['txtClienteFiscalRazonSocial'].value = '';
	}
	else { 
        opener.document.forms[0].elements['hdnClienteFiscalId'].value = intClienteFiscalId;
        opener.document.forms[0].elements['txtClienteFiscalRFC'].value = strRFC;
        opener.document.forms[0].elements['txtClienteFiscalRazonSocial'].value = strlClienteFiscalRazonSocial;
	}
    
    <% if Request.QueryString("strEvalJs")<>"" then %>
    eval("<%=Request.QueryString("strEvalJs")%>");
    <% end if %>
    blnSinSeleccion = false;
    self.close();   
}

function window_onunload() {
    if(blnSinSeleccion) {
        fnAceptarClientePorIframe(0,0,"",""); 
    }
}

function window_onload() {
   document.forms[0].action = "<%=strFormAction%>";
 
   <%=strCboEstado("cboEstado")%>
   <%=strCboEstado("cboEntregaEstado")%>

}
//-->
			</script>
</HEAD>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0"
		onload="return window_onload()" onunload="return window_onunload()" style="BACKGROUND-REPEAT:no-repeat">
<form name="frmpopPedidoVentaCatalogoClienteAlta" action="about:blank" method="post">
  <table height="62" cellspacing="0" cellpadding="0" width="100%" bgcolor="#ffffff" border="0">
    <tr> 
      <td class="tdlogopop" colspan="2" height="54"><script language="javascript">crearTablaHeaderPop()</script></td>
    </tr>
  </table>
  <table width="100%" class="tdenvolventetablas">
    <tr> 
      <td class="tdtittablas" width="30%">RFC</td>
      <td class="tdpadleft5" width="50%"><input class="campotablamayusculas" onkeydown="if(event.keyCode==13){document.forms[0].elements['txtRazonSocial'].focus();}"
							maxLength="20" name="txtRFC"> </td>
      <td class="tdtittablas" width="20%" rowspan="2"><input class="boton" onclick="return cmdBuscar_onclick()" type="button" value="Buscar"
							name="cmdBuscar"> &nbsp; <input class="boton" onclick="return cmdCerrar_onclick()" type="button" value="Cerrar"
							name="cmdCerrar"></td>
    </tr>
    <tr> 
      <td class="tdtittablas" >Nombre Completo del Cliente</td>
      <td class="tdpadleft5"><input class="campotabla" maxLength="100" size="70" name="txtRazonSocial"> 
      </td>
    </tr>
  </table>
  <div id="divClientes" name="divClientes" style="DISPLAY: none"></div>
  <div id="divDireccionEntrega" name="divDireccionEntrega" style="DISPLAY: none"><br>
    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
      <tr> 
        <td width="20%" valign="top"><span class="txsubtitulo"><IMG height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Domicilio</span> 
          <table cellSpacing="0" cellPadding="0" width="100%" border="0">
            <tr> 
              <td class="tdtxtablas" >Calle</td>
            </tr>
            <tr> 
              <td class="tdtxtablas" >No. Exterior</td>
            </tr>
            <tr> 
              <td class="tdtxtablas" >No. Interior</td>
            </tr>
            <tr> 
              <td class="tdtxtablas" height="20">Entre Calles</td>
            </tr>
            <tr> 
              <td class="tdtxtablas">Colonia</td>
            </tr>
            <tr> 
              <td class="tdtxtablas">Estado</td>
            </tr>
            <tr> 
              <td class="tdtxtablas">Ciudad</td>
            </tr>
            <tr> 
              <td class="tdtxtablas">C.P.</td>
            </tr>
            <tr> 
              <td class="tdtxtablas">Teléfono</td>
            </tr>
            <tr> 
              <td class="tdtxtablas">Celular o Tel. Adicional</td>
            </tr>
            <tr> 
              <td class="tdtxtablas">Correo:</td>
            </tr>
          </table></td>
        <td width="40%" valign="top"><span class="txsubtitulo"><IMG height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Fiscal</span> 
          <table cellSpacing="0" cellPadding="0" width="100%" border="0">
            <tr> 
              <td class="tdtxtablas" valign="top" ><input class="campotabla" onkeydown="if(event.keyCode==13){document.forms[0].elements['txtNoExterior'].focus();}"
											readOnly maxLength="50" size="50" name="txtCalle"> 
              </td>
            </tr>
            <tr> 
              <td class="tdtxtablas"><input class="campotabla" onKeyDown="if(event.keyCode==13){document.forms[0].elements['txtNoInterior'].focus();}"
											readonly maxlength="15" size="30" name="txtNoExterior"> 
              </td>
            </tr>
            <tr> 
              <td class="tdtxtablas"><input class="campotabla" onkeydown="if(event.keyCode==13){document.forms[0].elements['txtColonia'].focus();}"
											readOnly maxLength="15" size="30" name="txtNoInterior"> 
              </td>
            </tr>
            <tr> 
              <td class="tdtxtablas" height="17">&nbsp;</td>
            </tr>
            <tr> 
              <td class="tdtxtablas"><input class="campotabla" onkeydown="if(event.keyCode==13){document.forms[0].elements['cboEstado'].focus();}"
											readOnly maxLength="50" size="50" name="txtColonia"> 
              </td>
            </tr>
            <tr> 
              <td class="tdtxtablas"><select language="javascript" class="campotabla" id="cboEstado" disabled onchange="return cboEstado_onchange(1)"
											name="cboEstado">
                </select> <input type="hidden" name="txtEstado"> </td>
            </tr>
            <tr> 
              <td class="tdtxtablas"><select language="javascript" class="campotabla" id="cboCiudad" disabled onchange="return cboCiudad_onchange(1)"
											name="cboCiudad">
                </select> <input type="hidden" name="txtCiudad"> </td>
            </tr>
            <tr> 
              <td class="tdtxtablas"><input class="campotabla" onkeydown="if(event.keyCode==13){document.forms[0].elements['txtTelefono'].focus();}"
											readOnly maxLength="5" size="6" name="txtCodigoPostal"> 
              </td>
            </tr>
            <tr> 
              <td class="tdtxtablas"><input class="campotabla" onkeydown="if(event.keyCode==13){document.forms[0].elements['txtEMail'].focus();}"
											readOnly maxLength="15" size="30" name="txtTelefono"> 
              </td>
            </tr>
            <tr> 
              <td class="tdtxtablas">&nbsp;</td>
            </tr>
            <tr> 
              <td class="tdtxtablas"><input class="campotabla" onkeydown="if(event.keyCode==13){document.forms[0].elements['txtEntregaCalle'].focus();}"
											readOnly maxLength="50" size="50" name="txtEMail"> 
              </td>
            </tr>
          </table></td>
        <td width="40%" valign="top"><span class="txsubtitulo"><IMG height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Entrega</span> 
          <table cellSpacing="0" cellPadding="0" width="100%" border="0">
            <tr> 
              <td class="tdtxtablas" height="20"><input class="campotabla" onKeyDown="if(event.keyCode==13){document.forms[0].elements['txtEntregaNoExterior'].focus();}"
											readonly maxlength="50" size="50" name="txtEntregaCalle"> 
              </td>
            </tr>
            <tr> 
              <td class="tdtxtablas"><input class="campotabla" onKeyDown="if(event.keyCode==13){document.forms[0].elements['txtEntregaNoInterior'].focus();}"
											readonly maxlength="15" size="30" name="txtEntregaNoExterior"> 
              </td>
            </tr>
            <tr> 
              <td class="tdtxtablas"><input class="campotabla" onkeydown="if(event.keyCode==13){document.forms[0].elements['txtEntregaEntreCalles'].focus();}"
											readOnly maxLength="15" size="30" name="txtEntregaNoInterior"> 
              </td>
            </tr>
            <tr> 
              <td class="tdtxtablas"><input class="campotabla" onkeydown="if(event.keyCode==13){document.forms[0].elements['txtEntregaColonia'].focus();}" readOnly maxLength="255" size="50" name="txtEntregaEntreCalles"> 
              </td>
            </tr>
            <tr> 
              <td class="tdtxtablas"><input class="campotabla" onkeydown="if(event.keyCode==13){document.forms[0].elements['cboEntregaEstado'].focus();}"
											readOnly maxLength="50" size="50" name="txtEntregaColonia"> 
              </td>
            </tr>
            <tr> 
              <td class="tdtxtablas"><select language="javascript" class="campotabla" id="cboEntregaEstado" disabled onchange="return cboEstado_onchange(2)"
											name="cboEntregaEstado">
                </select> <input type="hidden" name="txtEntregaEstado"> </td>
            </tr>
            <tr> 
              <td class="tdtxtablas"><select language="javascript" class="campotabla" id="cboEntregaCiudad" disabled onchange="return cboCiudad_onchange(2)"
											name="cboEntregaCiudad">
                </select> <input type="hidden" name="txtEntregaCiudad"> </td>
            </tr>
            <tr> 
              <td class="tdtxtablas"><input class="campotabla" onkeydown="if(event.keyCode==13){document.forms[0].elements['txtEntregaTelefono'].focus();}"
											readOnly maxLength="5" size="6" name="txtEntregaCodigoPostal"> 
              </td>
            </tr>
            <tr> 
              <td class="tdtxtablas"><input class="campotabla" onKeyDown="if(event.keyCode==13){document.forms[0].elements['txtEntregaMovil'].focus();}" readonly maxlength="15" size="20" name="txtEntregaTelefono"> 
            </tr>
            <tr> 
              <td class="tdtxtablas"><input class="campotabla" onKeyDown="if(event.keyCode==13){document.forms[0].elements['cmdAceptar'].focus();}" readonly maxlength="15" size="20" name="txtEntregaMovil"></td>
            </tr>
            <tr> 
              <td class="tdtxtablas">&nbsp; </td>
            </tr>
          </table></td>
      </tr>
      <tr> 
        <td class="tdtittablas" colspan="3" align="center"><input class="boton" onclick="return cmdCancelar_onclick()" type="button" value="Cancelar"
								name="cmdCancelar"> &nbsp; <input class="boton" onclick="return cmdAceptar_onclick()" type="button" value="Aceptar"
								name="cmdAceptar"></td>
      </tr>
    </table>
  </div>
</form>
<iframe style="WIDTH:10%;HEIGHT:10%;DISPLAY: none" name="ifrOculto"></iframe>
<iframe style="WIDTH:10%;HEIGHT:10%;DISPLAY: none" name="ifrOculto2"></iframe>
</body>
</HTML>
