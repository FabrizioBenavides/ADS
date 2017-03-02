<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CompraDirectaModificarOrdenSugerida.aspx.vb" Inherits="com.isocraft.backbone.ccentral.CompraDirectaModificarOrdenSugerida"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : CompraDirectaModificarOrdenSugerida.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página donde se Muestra la ORden Sugerida para las compras directas
    ' Copyright     : 2004 All rights reserved.
    ' Company       : BENAVIDES
    ' Author        : J.Antonio Hernandez Dávila
    ' Version       : 1.0
    ' Last Modified : Jueves, 18 de Noviembre 2004
	'                 Jueves, 14 de Febrero 2008   ORDENES ASR
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================	
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<LINK href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
var checkOK = "0123456789.";
var intTotalCampos  = 1 + <%=intTotalCampos%>;
var intCampoSeleccionado = 0;


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

function strEliminacommas(objcampo){
 // Quita las comas 
   while (parseInt(objcampo.search(',')) > 0){
          objcampo = objcampo.replace(',','');
         }
  
  // quita el signo de pesos
  objcampo = objcampo.replace('$','');  
  return(objcampo);
}
 
function fnBuscaPuntoDecimal(strCampo){     
 var intCaracteresTotales;
 var intContador;
 var intCuentaPuntoDecimal;
 var straValidar; 
 
 intCaracteresTotales = strCampo.length;		
 intContador = 0;
 intCuentaPuntoDecimal = 0; 
		
        while (intContador <= intCaracteresTotales){
		   straValidar = strCampo.substring(intContador,intContador+1)
           if (straValidar == "."){
		       intCuentaPuntoDecimal = intCuentaPuntoDecimal + 1;
		       }		   		   
		       intContador = intContador + 1;
		} 
   return(intCuentaPuntoDecimal);
 }  

function fnMarcarTodos(){
	intTotalDePartidas = document.forms(0).txtArticulosLista.value * 1;
	
	if(document.forms(0).chkMarcarTodos.checked){
		document.forms(0).chkMarcarTodos.title='Desmarcar Todos';
	}else{
		document.forms(0).chkMarcarTodos.title='Marcar Todos';
	}
	
	for(i=1;i<=intTotalDePartidas;i++){
		document.forms(0).elements('chkart_'+i).checked = document.forms(0).chkMarcarTodos.checked;
	}
}   

function cmdCampo_onfocus(intValor) {
   intCampoSeleccionado = intValor;    
}

function cmdTeclaPulsada() {

   if (event.keyCode == 32) {
     strCampo  ='';
     strCampo1 =document.forms(0).elements(intCampoSeleccionado-1).name; 
     strCampo2 =document.forms(0).elements(intCampoSeleccionado-2).name; 
	 
	 if (strCampo1.substring(0,6) == 'chkart') {
         strCampo = strCampo1;
	 }
	 if (strCampo2.substring(0,6) == 'chkart') {
         strCampo = strCampo2;
	 }
	 document.forms(0).elements(strCampo).checked = !(document.forms(0).elements(strCampo).checked);
     event.returnValue = false;	   
   }
   
   if (event.keyCode == 13) {
       event.returnValue = false;
       
       for (i = 0; i < intTotalCampos; i++)       
       {
           intCampoSeleccionado = (intCampoSeleccionado + 1) % intTotalCampos; 
           
           if ( document.forms[0].elements[intCampoSeleccionado].readOnly !=true && document.forms[0].elements[intCampoSeleccionado].tabIndex >= 0) {
              break;              
           }
       }
       document.forms[0].elements[intCampoSeleccionado].focus();		   
	   document.forms[0].elements[intCampoSeleccionado].select();
   }
}
function blnIsNumber(checkStr) {

	var allValid = true;
  
	if (checkStr.length < 1) {
		allValid = false;
	}
  	else {
		for (i = 0;  i < checkStr.length;  i++)
		{
			ch = checkStr.charAt(i);
			for (j = 0;  j < checkOK.length;  j++)
				if (ch == checkOK.charAt(j))
					break;
				if (j == checkOK.length)
				{
					allValid = false;
					break;
				}
		}
  }
  
  return (allValid);
}

function intValidaCantidadRenglon(intRenglonValidar, intCampoValidar,intCantidad) {
   var valida = true;
   
   if ( blnIsNumber(document.forms[0].elements[intCampoValidar].value)==false) {
       valida = false;
       alert("Capturar un valor valido para la Cantidad");
   }
   
   if (valida && (document.forms[0].elements[intCampoValidar].value < 1 || document.forms[0].elements[intCampoValidar].value > 999999)) {
       valida = false;
       alert("Capturar correctamente, la cantida"); 
   }

   if (valida && document.forms[0].elements['hdnSoloOrden'].value == 1 && document.forms[0].elements[intCampoValidar].value > intCantidad) {
       valida = false;
       alert("La cantidad no puede ser mayor a la indicada en la orden"); 
   }
   
   if (valida) {
       var campoImporte  = "txtImp_" + intRenglonValidar ;
       var campoCosto    = "txtCos_" + intRenglonValidar ;
       var ImporteNuevo  = parseFloat(document.forms[0].elements[intCampoValidar].value) * parseFloat(document.forms[0].elements[campoCosto].value);
       if (blnIsNumber(ImporteNuevo)) {
           document.forms[0].elements[campoImporte].value = (Math.round(ImporteNuevo*100) / 100);
       }       
   }
   else {       
       document.forms[0].elements[intCampoValidar].select();
       document.forms[0].elements[intCampoValidar].focus();              
   }    
   
   return (valida);

}

function intValidaCostoRenglon(intRenglonValidar, intCampoValidar, CostoReposicion) {
   var valida = true;

   // Validamos que sea un numero correcto
   if (blnIsNumber(document.forms[0].elements[intCampoValidar].value)==false) {
       valida = false;
       alert("Capturar un valor valido para el Costo Unitario");       
   }
      
   if (valida) {               
       // Verificamos que no tenga mas de 2 puntos     
       strCostoUnitario = document.forms[0].elements[intCampoValidar].value;
       intInvalido = fnBuscaPuntoDecimal(strCostoUnitario);
       
       if (parseInt(intInvalido) > 1){
           valida = false;
           alert("Capturar correctamente el costo unitario.");           
       }  
       
       // CostoUnitario que sea mayor a cero
       if (parseFloat(document.forms[0].elements[intCampoValidar].value) <= 0){
           valida = false;
           alert("Capturar correctamente el costo unitario.");              
       }
       
       if (valida) {          
           // Validamos contra los margenes establecidos
           fltMargenInferiorCompra = document.forms[0].txtMargenInferiorCompra.value+1;
           fltMargenSuperiorCompra = document.forms[0].txtMargenSuperiorCompra.value+1;
           fltCostoReposicion      = CostoReposicion;
           
           fltMargenInferior = parseFloat(fltCostoReposicion) *  parseFloat(fltMargenInferiorCompra);
           fltMargenSuperior = parseFloat(fltCostoReposicion) *  parseFloat(fltMargenSuperiorCompra);
                
           fltCostoUnitario = document.forms[0].elements[intCampoValidar].value;
           fltCostoUnitario = strEliminacommas(fltCostoUnitario);
                 
           fltMargenMinimo = parseFloat(fltCostoReposicion) -  parseFloat(fltMargenInferior);
           fltMargenMaximo = parseFloat(fltCostoReposicion) +  parseFloat(fltMargenSuperior);

           if (!((parseFloat(fltMargenMinimo) <= parseFloat(fltCostoUnitario)) && (parseFloat(fltCostoUnitario) <= parseFloat(fltMargenMaximo)))){
               valida = false;
               alert("Costo unitario del artículo fuera del margen.");                         
           }
       }       
   }      
   
   if (valida) {
       var campoImporte  = "txtImp_" + intRenglonValidar ;
       var campoCantidad = "txtCan_" + intRenglonValidar ;
       var ImporteNuevo  = parseFloat(document.forms[0].elements[campoCantidad].value) * parseFloat(document.forms[0].elements[intCampoValidar].value);
       
       if (blnIsNumber(ImporteNuevo)) {
           document.forms[0].elements[campoImporte].value = (Math.round(ImporteNuevo*100) / 100);
       }
   }
   else {
       document.forms[0].elements[intCampoValidar].focus();    
   }
   

}

function cmdImportarparaCompra() {
   document.forms(0).action = "<%=strFormAction%>?strCmd=Importar";
   document.forms(0).target="ifrOculto";
   document.forms(0).submit();
}

function fnUpImportaArticulos(intError) {
    if (intError == 0) {
       document.forms(0).target="";
       document.forms[0].action = "MercanciaCapturarDetalleCompraDirecta.aspx";
       document.forms(0).submit();       
    }
    else {
       alert("Error al Importar la Orden Sugerida de Compra" + intError);       
    }
}

function window_onload() {
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.all.divDetalleOrden.innerHTML = "<%=strVerOrdenCompra%>"; 
  
  if (intTotalCampos >1 ) {		           
	 document.forms[0].elements[2].focus();
	 document.forms[0].elements[2].select();
  }
  return(true);
}
//-->
</script>
</HEAD>
<body onkeypress="cmdTeclaPulsada();" leftMargin="0" topMargin="0" onload="return window_onload()" marginwidth="0" marginheight="0">
<form name="frmCompraDirectaModificarOrdenSugerida" action="about:blank" method="post">
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
            <td width="583" class="tdmigaja"><span class="txdmigaja">Verificar 
              los articulos, puede cambiar la cantidad, costo y/o eliminar articulos 
              de ser necesario.</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td vAlign="top" width="583"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td class="txsubtitulo" width="100%"><br>
                    Proveedor: <%=strroveedorNombreId%> - <%=strRazonSocialProveedor%> 
                  </td>
                </tr>
                <tr> 
                  <td class="txsubtitulo" width="100%">Orden: <%=intFolioOrdenId%></td>
                </tr>
                <tr> 
                  <td width="100%"><div id="divDetalleOrden" name="divDetalleOrden"></div></td>
                </tr>
                <tr> 
                  <td width="100%" align="right"><input name="cmdImporta" type="button" class="boton" value="Continuar"
													language="javascript" title="Importa a la Compra Directa los códigos marcados de la Orden"
													onclick="return cmdImportarparaCompra()"> 
                    <br> <br></td>
                </tr>
              </table></td>
            <td class="tdcolumnader" vAlign="top" width="182" rowSpan="2">&nbsp;</td>
          </tr>
          <tr> 
            <td class="tdbottom" colSpan="2"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
  </table>
  <tr> 
    <input type='hidden' value='<%=Request.Form("txtCompraDirectaId")%>' name='txtCompraDirectaId'>
    <input type='hidden' value='<%=Request.Form("txtMargenInferiorCompra")%>' name='txtMargenInferiorCompra'>
    <input type='hidden' value='<%=Request.Form("txtMargenSuperiorCompra")%>' name='txtMargenSuperiorCompra'>
    <input type='hidden' value='<%=Request.Form("hdnProveedorId")%>' name='hdnProveedorId'>
    <input type='hidden' value='<%=Request.Form("hdnProveedorNombreId")%>' name='hdnProveedorNombreId'>
    <input type='hidden' value='<%=Request.Form("txtProveedorNombreId")%>' name='txtProveedorNombreId'>
    <input type='hidden' value='<%=Request.Form("txtRazonSocialProveedor")%>' name='txtRazonSocialProveedor'>
    <input type='hidden' value='<%=Request.Form("hdnSoloOrden")%>' name='hdnSoloOrden' >
    <input type='hidden' value='<%=Request.Form("hdnOrdenDisponible")%>' name='hdnOrdenDisponible' >
    <input type='hidden' value='<%=Request.Form("txtFolioOrdenId")%>' name='txtFolioOrdenId'>
    <input type='hidden' value='<%=Request.Form("txtRFC")%>' name='txtRFC'>
    <input type='hidden' value='<%=Request.Form("txtRFCOculto")%>' name='txtRFCOculto'>
    <input type='hidden' value='<%=Request.Form("txtNumeroFactura")%>' name='txtNumeroFactura'>
    <input type='hidden' value='<%=Request.Form("txtNumeroFacturaRuta")%>' name='txtNumeroFacturaRuta'>
    <input type='hidden' value='<%=Request.Form("txtFechaRecepcion")%>' name='txtFechaRecepcion'>
    <input type='hidden' value='<%=Request.Form("txtFechaFactura")%>' name='txtFechaFactura'>
    <input type='hidden' value='<%=Request.Form("cboIvaAplicado")%>' name='cboIvaAplicado'>
    <input type='hidden' value='<%=Request.Form("cboDescuento")%>' name='cboDescuento'>
    <input type='hidden' value='<%=Request.Form("chkAntesdeIva")%>' name='chkAntesdeIva'>
    <input type='hidden' value='<%=Request.Form("chkDespuesdeIva")%>' name='chkDespuesdeIva'>
    <input type='hidden' value='<%=Request.Form("txtSumaProductos")%>' name='txtSumaProductos'>
    <input type='hidden' value='<%=Request.Form("txtDescuentoAntesdeIva")%>' name='txtDescuentoAntesdeIva'>
    <input type='hidden' value='<%=Request.Form("txtTotalFacturado")%>' name='txtTotalFacturado'>
    <input type='hidden' value='<%=Request.Form("txtImporteIEPS")%>' name='txtImporteIEPS'>
    <input type='hidden' value='<%=Request.Form("txtIvaFacturado")%>' name='txtIvaFacturado'>
    <input type='hidden' value='<%=Request.Form("txtIvaDescuento")%>' name='txtIvaDescuento'>
    <input type='hidden' value='<%=Request.Form("txtDescuentoDespuesdeIva")%>' name='txtDescuentoDespuesdeIva'>
    <input type='hidden' value='<%=Request.Form("txtTotalNetoFacturado")%>' name='txtTotalNetoFacturado'>
  </tr>
</form>
<iframe name="ifrOculto" src width="0" height="0"></iframe>
</body>
</HTML>
