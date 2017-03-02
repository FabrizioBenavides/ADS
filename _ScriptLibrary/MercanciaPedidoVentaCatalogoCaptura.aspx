<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaPedidoVentaCatalogoCaptura.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaPedidoVentaCatalogoCaptura" codePage="28592" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaPedidoVentaCatalogoCaptura.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Captura de Pedidos Venta x Catalogo
    ' Copyright     : 2012 
    ' Company       : Farmacias Benavides
    ' Author        : [JAHD] 
    ' Version       : 1.0
    ' Last Modified : 
    '                 31 de Octubre 2012 [JAHD]
	'                 12 de Marzo   2013 [JAHD] Captura de Observaciones	
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

// Mandar ventana de consulta
function Pop(url, width, height) {
    var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=25,top=15,resizable=no,scrollbars=yes,menubar=no,status=no' );
	return(false);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}

function blnDatosPedido() {
	//Validaciones
	var valida=true; 	

	if(valida){ if(document.forms[0].elements['txtClienteFiscalRFC'].value==0 || (document.forms[0].elements['txtClienteFiscalRFC'].value).length < 1){alert("Indicar el RFC de Cliente"); valida=false;} }
		
	return valida;  
}

function blnValidarCifraDeControl() {
	valida=true;
	if (valida){ valida=blnValidarCampo(document.forms(0).elements('txtCifraDeControl'),true,"Cifra de control",cintTipoCampoEntero,10,1,""); } 
	
	if (valida){	    
		intCifraControlSistema = document.forms[0].elements['hdnTotalArticulosPedido'].value * 1;
		
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
		blnmControlesEncabezadoHabilitados=true;		
		document.all.divBotones.style.display='none'; 
	}
	else {
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

function objLupaCliente_onclick() {
    var valida = true;   
	strEvalJs="opener.fnUpLupaCliente();"; 		      
    Pop('popPedidoVentaCatalogoClienteAlta.aspx?strEvalJs='+strEvalJs,680,500);   
}

function fnUpLupaCliente() {
   
   document.forms[0].elements['hdnClienteFiscalRFC'].value = document.forms[0].elements['txtClienteFiscalRFC'].value ;
   
   if ( (document.forms[0].elements['txtClienteFiscalRFC'].value).length <1 ) {      
       document.forms[0].elements['imgLupaCliente'].focus();
       alert("Cliente no seleccionado");        
   }
   else {       
       document.forms[0].elements['rdoDomEntrega1'].focus();     
   }     
}	

function objLupaArticulo_onClick() { 
   var strArticulo;
   var intCuentaApostrofes;
   
   if (document.forms[0].txtArticuloId.value == "") {return(true);}
   
    // Es necesario haber seleccionado al cliente 
   valida =blnDatosPedido();
   if(valida==false){return(false); }

   if(valida) { 
       if(document.forms[0].elements['txtCajaId'].value==0 || (document.forms[0].elements['txtCajaId'].value).length < 1 || isNaN(document.forms[0].elements['txtCajaId'].value)) {
	       alert("Capturar el numero de caja donde se hizo la venta");
		   document.forms[0].elements['txtCajaId'].focus();
		   valida=false;
		   return(false);
	   } 
   }
   if(valida) { 
       if(document.forms[0].elements['txtTicketId'].value==0 || (document.forms[0].elements['txtTicketId'].value).length < 1 || isNaN(document.forms[0].elements['txtTicketId'].value)) {
	       alert("Capturar el numero de Ticket donde se cobro el articulo");
		   document.forms[0].elements['txtTicketId'].focus();
		   valida=false;
		   return(false);
       } 
   }
   	
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
			
			strParametros = strParametros + '&campoArticuloAutorizado=hdnArticuloAutorizado';
																	
            strParametros = strParametros + '&strArticuloIdNombre=' + document.forms[0].txtArticuloId.value;
			
			Pop('PopPedidoVentaCatalogoArticulo.aspx?'+strParametros+'&strEvalJs='+strEvalJs,500,540);
						
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
       document.forms[0].elements['txtArticuloId'].focus();   
   }
   else {       
       document.forms(0).txtCantidad.focus();     
   }  
}

function fnUpdArticuloPorIframe(strArticuloId,strDescripcionArticulo,
                       strClaveVigenciaArticuloId,  strClaveVigenciaArticuloNombre,
                       strEstacionalidadArticuloId, strEstacionalidadArticuloDescripcion,
                       strTipoAbastoArticuloId,     strTipoAbastoArticuloDescripcion,
                       strArticuloAutorizado, intError) {
					   					   
	document.forms(0).txtArticuloId.value = strArticuloId;
	document.forms(0).hdnArticuloEncontradoId.value = document.forms(0).txtArticuloId.value;
	document.forms(0).txtDescripcionArticulo.value = strDescripcionArticulo;

    document.forms(0).hdnClaveVigenciaArticuloId.value = strClaveVigenciaArticuloId;
	document.forms(0).txtClaveVigenciaArticuloNombre.value = strClaveVigenciaArticuloNombre;
	
    document.forms(0).hdnEstacionalidadArticuloId.value = strEstacionalidadArticuloId;
	document.forms(0).txtEstacionalidadArticuloDescripcion.value = strEstacionalidadArticuloDescripcion;	

    document.forms(0).hdnTipoAbastoArticuloId.value = strTipoAbastoArticuloId;
	document.forms(0).txtTipoAbastoArticuloDescripcion.value = strTipoAbastoArticuloDescripcion;
		    	
    document.forms(0).hdnArticuloAutorizado.value = strArticuloAutorizado;
		
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
   
   // Autorizado para venta por catalogo
   if(valida) {	       
       if (document.forms(0).hdnArticuloAutorizado.value != '1')  {
       alert("Articulo no autorizado para venta por catalogo");
       document.forms[0].txtArticuloId.focus();        
       return(false);
       }
   }  
   
   // Validamos que la cantidad sea un campo entero
   if (valida){valida=blnValidarCampo(document.forms['frmMercanciaPedidoVentaCatalogoCaptura'].elements['txtCantidad'],true,"Cantidad", cintTipoCampoEntero,20,1,""); }
   
   if (!valida){return(valida);}
      
   // Cantidad que sea mayor a cero
   if (parseInt(document.forms['frmMercanciaPedidoVentaCatalogoCaptura'].elements['txtCantidad'].value) <= 0){
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

function fnUpAgregarEliminarArticulo(intAccion, intPedidoCompraDirectaId, strRecordBrowserHTML, intTotalArticulosPedido, intError) {

    document.all.divDetalle.innerHTML = strRecordBrowserHTML;	
	document.forms[0].elements['hdnCapturaId'].value = intPedidoCompraDirectaId;
	document.forms[0].elements['hdnTotalArticulosPedido'].value = intTotalArticulosPedido;
    
    if (intTotalArticulosPedido < 1) {
          fnHabilitaDeshabilitaControlesEncabezado(true); //Habiliar cuando no hay articulos  
    } 
    else {
           fnHabilitaDeshabilitaControlesEncabezado(false); //Deshabilita si ya hay articulos 
    }
      
    if (intError == 0) {
         	document.forms(0).txtCajaId.value = '';
			document.forms(0).txtTicketId.value = '';
			
            document.forms(0).txtArticuloId.value = '';
	        document.forms(0).txtDescripcionArticulo.value = '';				   
   			document.forms(0).txtClaveVigenciaArticuloNombre.value='';
			document.forms(0).txtEstacionalidadArticuloDescripcion.value='';
			document.forms(0).txtTipoAbastoArticuloDescripcion.value='';            
     		document.forms(0).hdnArticuloCobrado.value ='0';
			document.forms(0).hdnArticuloCantidad.value ='0';
			document.forms(0).hdnArticuloAutorizado.value ='0';	          
	        document.forms(0).txtCantidad.value = '';
			
			if (intTotalArticulosPedido < 1) {
			    document.forms(0).txtObservaciones.focus();
			}
			else {
      			document.forms(0).txtCajaId.focus();
			}
				
	}
	else {   
       if (intAccion == 1) { // Agregar Articulo
	       if (intError==-100) {
               alert("ERROR, Articulo no pudo Agregarse");
		   }
		   if (intError==-200) {
		       alert ("Articulo no encontrado en CTF");
		   }
		   if (intError==-210) {
		       alert ("Cantidad de Articulo encontrado en CTF es diferente a la capturada");
		   }		   
       }
       if (intAccion == 2) { // Eliminar Articulo
           alert("ERROR, Articulo no pudo Eliminarse");
       }
       document.forms(0).txtArticuloId.focus();
   }
   	
}

// Elimina el Articulo seleccionado del detalle de la Compra directa
function cmdEliminar_onclick(intCajaId, intTicketId, intArticuloEliminar){
    document.forms[0].action = "<%=strFormAction%>?strCmd=EliminarArticulo" + "&intCajaEliminarId=" + intCajaId + "&intTicketEliminarId=" + intTicketId + "&intArticuloEliminarId=" + intArticuloEliminar; 
    document.forms[0].target="ifrOculto";
    DoSubmit();
    document.forms[0].target='';    
}

function cmdRegresar_onClick() {
   window.location.href = "MercanciaPedido.aspx";  
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
function fnUpRegistrarPedidoCompraDirecta(intPedidoVentaCatalogoId, intError) {
   if (intError==0) {
       strParametros = "?strPaginapadre=Captura"
       strParametros = strParametros + '&intPedidoVentaCatalogoId=' + intPedidoVentaCatalogoId ;

       window.location.href = "MercanciaPedidoVentaCatalogoDetalle.aspx" + strParametros;       
   }
   else { 
         alert ("No se registro el pedido de venta por catálogo, verifique los datos y reintente");
   }
}  

function window_onload() {
    blnValidaCTF = window.blnValidaCTF ? window.blnValidaCTF : false;
	
    if (blnValidaCTF == true) {
		document.forms[0].elements['hdnValidaCTF'].value = 1;
	}
	else {
	    document.forms[0].elements['hdnValidaCTF'].value = 0;
	}	
   
	document.forms[0].elements['txtFechaRegistro'].value = "<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy") %>";
    
	if(document.forms[0].elements['hdnTotalArticulosPedido'].value==0 || (document.forms[0].elements['hdnTotalArticulosPedido'].value).length < 1){
        fnHabilitaDeshabilitaControlesEncabezado(true);
		document.forms[0].elements['imgLupaCliente'].focus();
	}
	else {
        fnHabilitaDeshabilitaControlesEncabezado(false);
		document.forms[0].elements['txtArticuloId'].focus();
	}
    
	if("<%=blnEntregaEnSucursal%>"=="False") { document.forms[0].elements['rdoDomEntrega1'].checked=true; }	
	if("<%=blnEntregaEnSucursal%>"=="True"){ document.forms[0].elements['rdoDomEntrega2'].checked=true; }
	      
    return(true);                      
}

function cmdonKeyPressed(intObjeto,tecla) {
 if (tecla == 13 || tecla==9) { 
       if (intObjeto==3) {
       	   document.forms(0).txtCajaId.focus();     
       }
       if (intObjeto==4) {
       	   document.forms(0).txtTicketId.focus();     
       }
	   if (intObjeto==5) {
           document.forms(0).txtArticuloId.focus();    
       }
	   if (intObjeto==6) {
           document.forms(0).imgLupaArticulo.focus();      
       }	   	   
       if (intObjeto==7) {
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
       objLupaCliente_onclick();      
       }
	   if (intObjeto==2) {
        objLupaArticulo_onClick();
       }     
}
//-->
</script>
</HEAD>
<body leftMargin="0" topMargin="0" onload="return window_onload()" marginwidth="0" marginheight="0">
<form name="frmMercanciaPedidoVentaCatalogoCaptura" action="about:blank" method="post">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="34"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td> <table width="780" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgColor="#ffffff"> <img height="8" src="../static/images/pixel.gif" width="10"></td>
            <td class="tdmigaja" width="583"><span class="txdmigaja">Está en : 
              </span> <a class="txdmigaja" href="Mercancia.aspx"> Mercancía</a> 
              <span class="txdmigaja">: <a class="txdmigaja" href="MercanciaPedido.aspx">Pedidos</a></span> 
              <span class="txdmigaja">: <a class="txdmigaja" href="MercanciaPedidoVentaCatalogo.aspx">Pedido 
              Venta Catálogo</a></span> <span class="txdmigaja">: Capturar Pedido</span></td>
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
                        <td class="txtitintabla" vAlign="middle" width="20%"><input class="campotabladeshabilitado" readOnly size="16" name="txtIntFolioCDI"></td>
                      </tr>
                    </table>
                    <br> <table width="100%" class="tdenvolventetablas">
                      <tr> 
                        <td class="tdtittablas3" width="20%">Fecha Registro</td>
                        <td class="tdtittablas3" align="left" width="30%">RFC 
                          Cliente</td>
                        <td class="tdtittablas3" align="left" width="50%">Nombre</td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas3" align="left" width="20%"><input name="txtFechaRegistro" id="txtFechaRegistro" readOnly class="campotabla" size="10"
																maxlength="10"> 
                          <img src="../static/images/icono_calendario.gif" width="20" height="13" align="absMiddle"
																border="0"></td>
                        <td class="tdtittablas3" align="left" width="30%"><input name="txtClienteFiscalRFC" id="txtClienteFiscalRFC" readOnly class="campotabladeshabilitado"  autocomplete="off" size="16" maxlength="16" value='<%=Request.Form("txtClienteFiscalRFC")%>' tabindex="-1" > 
                          &nbsp;<a id="objLupaProveedor" onclick="return objLupaCliente_onclick()"><img name="imgLupaCliente" src="../static/images/icono_lupa.gif" width="17" height="17"
																	align="absMiddle" border="0" tabindex="1"></a></td>
                        <td class="tdtittablas3" align="left" width="50%"><input name="txtClienteFiscalRazonSocial" id="txtClienteFiscalRazonSocial" class="campotablaresultadoenvolventeazul" value='<%=Request.Form("txtClienteFiscalRazonSocial")%>' size="38" maxlength="50"  border="0" readonly tabindex="-1"></td>
                      </tr>
                    </table>
                    <span class="txsubtitulo"><br>
                    <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Entrega 
                    del Pedido<br>
                    </span> <table width="100%" class="tdenvolventetablas">
                      <tr> 
                        <td class="tdtittablas3" width="20%"><input id="rdoDomEntrega1" type="radio" value="0" name="rdoDomEntrega" tabindex="2">
                          Cliente</td>
                        <td class="tdtittablas3" align="left" width="30%"><input id="rdoDomEntrega2" type="radio" value="1" name="rdoDomEntrega" tabindex="-1">
                          Sucursal</td>
                      </tr>
                    </table>
                    <span class="txsubtitulo"><br>
                    <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Observaciones 
                    del Pedido<br>
                    </span> <table width="100%" class="tdenvolventetablas">
                      <tr> 
                        <td class="tdtittablas3" width="100%"><input name="txtObservaciones" type="text" class="campotabla" id="txtObservaciones" size="135" maxlength="840"   autocomplete="off"  onKeyPress="cmdonKeyPressed(3,event.keyCode); "  tabindex="3"  ></td>
                      </tr>
                    </table>
                    <span class="txsubtitulo"><br>
                    <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Detalle 
                    Pedido <br>
                    <div id="divDetalle" name="divDetalle"></div>
                    </span> <br> <table class="tdenvolventetablas" width="100%">
                      <tr> 
                        <td class="tdtittablas3" align="left" width="05%" >Caja</td>
                        <td class="tdtittablas3" align="left" width="15%" >Ticket</td>
                        <td class="tdtittablas3" align="left" width="20%">Código</td>
                        <td class="tdtittablas3" align="left" width="30%">Descripción</td>
                        <td class="tdtittablas3" align="left" width="10%">Cantidad</td>
                        <td class="tdtittablas3" align="center" width="10%" vAlign="middle" rowspan="2"> 
                          <input class="boton" id="cmdAgregar" onClick="return cmdAgregar_onclick()" type="button"
																value="Agregar" name="cmdAgregar" tabindex="8"> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdconttablas" width="5%"><input class="campotablahabilitadoderecha" id="txtCajaId" maxLength="02" size="02" name="txtCajaId" autocomplete="off" onkeypress="cmdonKeyPressed(4,event.keyCode);" tabindex="4"></td>
                        <td class="tdconttablas" width="15%"><input class="campotablahabilitadoderecha" id="txtTicketId" maxLength="10" size="10" name="txtTicketId" autocomplete="off" onkeypress="cmdonKeyPressed(5,event.keyCode);" tabindex="5"></td>
                        <td align="left" width="20%" class="txtitintabla"><input class="campotablahabilitadoderecha" id="txtArticuloId" onFocus="return txtArticuloId_onfocus()" maxlength="16" size="12" name="txtArticuloId" autocomplete="off" onKeyPress="cmdonKeyPressed(6,event.keyCode);" tabindex="6" onBlur="cmdEjecutarLupa(2);"> 
                          <a id="objLupaArticulo" onclick="return objLupaArticulo_onClick();"> 
                          <img name="imgLupaArticulo" height="17" src="../static/images/icono_lupa.gif" width="16" align="absMiddle" border="0" tabindex="-1"></a></td>
                        <td class="txtitintabla" vAlign="middle" width="30%"><input class="campotablaresultadoenvolventeazul" readOnly size="25" name="txtDescripcionArticulo" tabindex="-1"></td>
                        <td class="tdpadleft5" vAlign="middle" align="left" width="10%"><input class="campotablahabilitadoderecha" id="txtCantidad" onFocus="return txtCantidad_onfocus()" maxlength="04" size="04" name="txtCantidad" autocomplete="off" onKeyPress="cmdonKeyPressed(7,event.keyCode);" tabindex="7"></td>
                      </tr>
                      <tr> 
                        <td colspan="6"><table class="tdenvolventetablas" width="100%" border="0">
                            <tr> 
                              <td class="tdtittablas3" align="left" width="30%">Estado</td>
                              <td class="txtitintabla" vAlign="middle" width="70%"><input type='hidden' value='<%=Request.Form("hdnClaveVigenciaArticuloId")%>' name='hdnClaveVigenciaArticuloId'> 
                                <input class="campotablaresultadoenvolventeazul" readOnly name="txtClaveVigenciaArticuloNombre"
																			tabindex="-1" size="15"></td>
                            </tr>
                            <tr> 
                              <td class="tdtittablas3" align="left" width="30%">Estacionalidad</td>
                              <td class="txtitintabla" vAlign="middle" width="70%"><input type='hidden' value='<%=Request.Form("hdnEstacionalidadArticuloId")%>' name='hdnEstacionalidadArticuloId'> 
                                <input class="campotablaresultadoenvolventeazul" readOnly name="txtEstacionalidadArticuloDescripcion"
																			tabindex="-1" size="15"></td>
                            </tr>
                            <tr> 
                              <td class="tdtittablas3" align="left" width="30%" valign="top">Abastos</td>
                              <td class="txtitintabla" vAlign="top" width="70%"><input type='hidden' value='<%=Request.Form("hdnTipoAbastoArticuloId")%>' name='hdnTipoAbastoArticuloId'> 
                                <input class="campotablaresultadoenvolventeazul" readOnly name="txtTipoAbastoArticuloDescripcion"
																			tabindex="-1" size="10"> 
                                <input type='hidden' value='<%=Request.Form("hdnArticuloAutorizado")%>' name='hdnArticuloAutorizado'> 
                                <input type='hidden' value='<%=Request.Form("hdnArticuloCobrado")%>' name='hdnArticuloCobrado'> 
                                <input type="hidden" value='<%=Request.Form("hdnArticuloCantidad")%>' name="hdnArticuloCantidad">	
                              </td>
                            </tr>
                          </table></td>
                      </tr>
                    </table>
                    <br> <div id="divBotones" style="DISPLAY: none"> 
                      <table id="TblBotones" cellSpacing="0" cellPadding="0" width="100%" border="0">
                        <tr> 
                          <td width="317">&nbsp;&nbsp; <input class="boton" onClick="return cmdRegresar_onClick()" type="button" value="Regresar"
																	name="cmdRegresar" tabindex="-1"></td>
                          <td class="tdenvolventetablas" align="center" width="200" bgColor="#f4f6f8"> 
                            <table cellSpacing="0" cellPadding="0" width="230" border="0">
                              <tr> 
                                <td class="tdtittablas3" width="156">Cifra de 
                                  control</td>
                                <td width="91" rowSpan="2"><input class="boton" onClick="return cmdRegistrar_onClick()" type="button" value="Registrar"
																				name="cmdRegistrar" tabindex="9"> 
                                </td>
                              </tr>
                              <tr> 
                                <td vAlign="top" height="30"><input class="campotabla" onKeyPress="cmdonKeyPressed(8,event.keyCode);" maxlength="4"
																				size="16" name="txtCifraDeControl" tabindex="8"> 
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
    <input type='hidden' value='<%=Request.Form("hdnClienteFiscalId")%>' name='hdnClienteFiscalId'>
    <input type='hidden' value='<%=Request.Form("hdnClienteFiscalRFC")%>' name='hdnClienteFiscalRFC'>
    <input type='hidden' value='<%=Request.Form("hdnArticuloEncontradoId")%>' name='hdnArticuloEncontradoId'>
    <input type='hidden' value='<%=Request.Form("hdnArticuloAnteriorId")%>' name='hdnArticuloAnteriorId'>
    <input type="hidden" value='<%=Request.Form("hdnTotalArticulosPedido")%>' name="hdnTotalArticulosPedido">
    <input type="hidden" value='<%=Request.Form("hdnValidaCTF")%>' name="hdnValidaCTF">
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
