<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaCapturarTransferenciaInterna.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaCapturarTransferenciaInterna" codePage="28592"%>
<html>
<head>
<%
    '====================================================================
    ' Page          : MercanciaCapturarTransferenciaInterna.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página de Transferencias Internas.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Miercoles, Noviembre  12, 2003
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
<script language="JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">


<!--
var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";



function window_onload() {
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action = "<%=strFormAction%>";   
      
  <%=strGeneraComboDepartamentoSurtidor%>
  <%=strGeneraComboDepartamentoReceptor%>
  <%=strGeneraComboCuentaGasto%>
  
  var strMensaje = "<%=strMensaje%>"; 
  var rdoSeleccionado = "<%=intTipoTransferenciaInterna%>"; 
  var strRegistrosRB  = "<%=strRegistrosRecordBrowser%>";  
  
    
  if (rdoSeleccionado == "1") {
       document.forms[0].rdoTipoTransferencia1.checked = true;
  }
      
  if (rdoSeleccionado == "2") {
       document.forms[0].rdoTipoTransferencia2.checked = true;
  }  
  
  document.forms[0].dtmTransferencia.value = "<%=dtmFechaTransferencia%>";
  
  if (strRegistrosRB.length > 0) {
      document.forms[0].rdoTipoTransferencia1.disabled=true;
      document.forms[0].rdoTipoTransferencia2.disabled=true;
      document.forms[0].dtmTransferencia.disabled=true;
      document.forms[0].cboDepartamentoSurtidor.disabled=true;
      document.forms[0].cboDepartamentoReceptor.disabled=true;
      document.forms[0].cboCuentaGasto.disabled=true;
      
  }
  
  if (strMensaje.length > 0) {
       alert(strMensaje);
  }
    
  <% if Request.QueryString.Count=0 andalso Request.Form.Count=0 then %>
		document.forms(0).rdoTipoTransferencia1.focus();
  <% end if %>
	
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
function strRecordBrowserHTML(){  
     document.write("<%=strRecordBrowserHTML%>");   
}

function Pop(url, width, height) {
    var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	return false;
}

function cmdVerificarArticulo_onclick(url, width, height){
   if (isNaN(document.forms[0].txtArticuloId.value)){
       url=url + '&strArticuloIdNombre='+document.forms[0].txtArticuloId.value;
       url=url + "&strEvalJsClosePopup=" + "opener.fnUpdArticuloPorIframe(intValor,strNombre,100)"
       Pop(url, width, height);        
   }
   else {
           var rdoSeleccionado = "";
           if (document.forms[0].rdoTipoTransferencia1.checked == true) {
               rdoSeleccionado = "1";             
           }
           if (document.forms[0].rdoTipoTransferencia2.checked == true) {
               rdoSeleccionado = "2";             
           } 
           var dtmTransferencia = document.forms[0].dtmTransferencia.value;
           var cboDeptoSurtidor = document.forms[0].cboDepartamentoSurtidor.value;
           var cboDeptoReceptor = document.forms[0].cboDepartamentoReceptor.value;
           var cboCuentaGasto   = document.forms[0].cboCuentaGasto.value;
                                 
           document.forms[0].action = "<%=strFormAction%>?strCmd=Consultar&intTipoTransferencia=" + rdoSeleccionado + "&dtmTransferencia=" + dtmTransferencia + "&intDeptoSurtidorId=" + cboDeptoSurtidor +"&intDeptoReceptorId=" + cboDeptoReceptor + "&intCuentaGastoId=" + cboCuentaGasto + "&txtArticuloId=" + document.forms[0].txtArticuloId.value + "&txtTransferenciaInternaFolioId=<%=intTransferenciaInternaFolioId%>";        
           document.forms[0].target="ifrArticulo";
           document.forms[0].submit();
           document.forms[0].target='';      
           document.forms[0].action = "<%=strFormAction%>";          
   }
}

function fnUpdArticuloPorIframe(strArticuloId,strArticuloDescripcion,intError){
	document.forms(0).txtArticuloId.value = '';
	document.forms(0).hdnArticuloId.value = '';
    document.forms(0).txtArticuloDescripcion.value = '';     

   if(intError == -1) {    
       alert("Artículo no existe. Favor de ingresar un código existente.");
       document.forms(0).txtArticuloId.focus();
       document.forms(0).txtArticuloId.select();
   }
   else {
       if (intError == -100) {
           alert("Articulo no pertenece al Departamento Surtidor");
           document.forms(0).txtArticuloId.focus();
           document.forms(0).txtArticuloId.select();
       }
       else {
           document.forms(0).txtArticuloId.value = strArticuloId;
           document.forms(0).hdnArticuloId.value = strArticuloId;
           document.forms(0).txtArticuloDescripcion.value = strArticuloDescripcion; 
           
           if(intError == 100){ 
               cmdVerificarArticulo_onclick('PopArticulo.aspx?strArticulo=txtArticuloId&amp;strArticuloNombreId=txtArticuloDescripcion',400,540)        
           }
           else {
               document.forms(0).txtCantidad.focus();
               document.forms(0).txtCantidad.select();
           }
       }
   }	       
}

function DoobjdtmTransferencia() {
   if (document.forms[0].dtmTransferencia.disabled == false)  {       
       objdtmTransferencia.popup();         
   }
}

function frmMercanciaCapturarTransferenciaInterna_onsubmit() { 
   var regreso = true;         
   
   if (document.forms[0].cmdAgregar.value == 'Agregar') {
       var blnConsultaArticulo = false;
   
       if (document.forms[0].txtArticuloId.value == 0) {
           alert("Capturar el código o descripción del artículo");
           document.forms[0].txtArticuloId.focus();
           regreso = false;
       }
       
       if (regreso && document.forms[0].txtCantidad.value == 0) {
           alert("Capturar la cantidad del artículo");
           document.forms[0].txtCantidad.focus();
           regreso = false;
       }
       
       if(regreso) {
           regreso = blnValidarCampo(document.forms[0].elements['dtmTransferencia'],true,'Fecha de la Transferencia',cintTipoCampoFecha,10,10,'');
       }       
	   
	   if (regreso) {
	   	
	    varFechaTransferencia = document.forms[0].elements("dtmTransferencia").value.substr(3,2) + "/" +document.forms[0].elements("dtmTransferencia").value.substr(0,2)+"/"+document.forms[0].elements("dtmTransferencia").value.substr(6,4)
	    
	    if (Date.parse(varFechaTransferencia) > Date.parse("<%=clsCommons.strGetCustomDateTime("MM/dd/yyyy")%>") ){
           alert("Fecha Envio Transferencia inválida");
           document.forms[0].dtmTransferencia.focus();
           regreso = false;
        }	  
	   }
       
       if (regreso ) {   
           regreso = blnValidarCampo(document.forms[0].elements['txtCantidad'],true,'Cantidad del articulo',cintTipoCampoEntero,5,0,'');
           var intCantidad = document.forms[0].txtCantidad.value * 1;
           if (intCantidad < 0) {
               alert("La Cantidad no puede ser negativa");
               regreso = false;           
           }
       }           
                        
       if (regreso) {
           if (isNaN(document.forms[0].txtArticuloId.value)) {
               blnConsultaArticulo = true;
               var url = 'PopArticulo.aspx?strArticulo=txtArticuloId&strArticuloNombreId=txtArticuloDescripcion&strArticuloBuscar='+document.forms[0].txtArticuloId.value;
               Pop(url, 400, 540);  
               regreso = false;
           }
       }    
       
       if (regreso) {
           var rdoSeleccionado = "";
           
           if (document.forms[0].rdoTipoTransferencia1.checked == true) {
               rdoSeleccionado = "1";             
           }
                  
           if (document.forms[0].rdoTipoTransferencia2.checked == true) {
               rdoSeleccionado = "2";             
           }
                  
           var dtmTransferencia = document.forms[0].dtmTransferencia.value;
           var cboDeptoSurtidor = document.forms[0].cboDepartamentoSurtidor.value;
           var cboDeptoReceptor = document.forms[0].cboDepartamentoReceptor.value;
           var cboCuentaGasto   = document.forms[0].cboCuentaGasto.value;                                   
           
           if (cboDeptoSurtidor == "0") {
              alert ("Seleccionar el Departamento que Surte");
              document.forms[0].cboDepartamentoSurtidor.focus();
              regreso = false;
           }
           
           if (regreso) {
               if (rdoSeleccionado == 1 && cboDeptoReceptor != "0") {
                   alert ("Para Consumo no seleccionar Departamento Receptor");
                   document.forms[0].cboDepartamentoReceptor.focus();
                   regreso = false;
               }   
               if (rdoSeleccionado == 2 && cboDeptoReceptor == "0") {
                   alert ("Seleccionar el Departamento que Recibe");
                   document.forms[0].cboDepartamentoReceptor.focus();
                   regreso = false;
               }           
           }
           
           if (regreso) {
				if (rdoSeleccionado == 1) { //Radio de Consumo Seleccionado
					if (cboCuentaGasto == "0") {
						alert ("Seleccionar la Cuenta de Gastos");
						document.forms[0].cboCuentaGasto.focus();
						regreso = false;
					} 
				}
           }
                      
           if (blnConsultaArticulo) {           
               document.forms[0].action="<%=strFormAction%>?strCmd=Consultar&intTipoTransferenciaInterna=" + rdoSeleccionado + "&dtmTransferencia=" + dtmTransferencia + "&intDeptoSurtidorId=" + cboDeptoSurtidor +"&intDeptoReceptorId=" + cboDeptoReceptor + "&intCuentaGastoId=" + cboCuentaGasto + "&txtArticuloId=" + document.forms[0].txtArticuloId.value + "&txtTransferenciaInternaFolioId=<%=intTransferenciaInternaFolioId%>";
           }
           else {                  
               document.forms[0].action="<%=strFormAction%>?strCmd=Agregar&intTipoTransferenciaInterna=" + rdoSeleccionado + "&dtmTransferencia=" + dtmTransferencia + "&intDeptoSurtidorId=" + cboDeptoSurtidor +"&intDeptoReceptorId=" + cboDeptoReceptor + "&intCuentaGastoId=" + cboCuentaGasto + "&txtArticuloId=" + document.forms[0].txtArticuloId.value + "&txtTransferenciaInternaFolioId=<%=intTransferenciaInternaFolioId%>";        
           }
       }
       
   }
   
   return(regreso);
}  


function cmdCancelar_onclick() {
   var rdoSeleccionado = "";
   if (document.forms[0].rdoTipoTransferencia1.checked == true) {
       rdoSeleccionado = "1";             
   }
   if (document.forms[0].rdoTipoTransferencia2.checked == true) {
       rdoSeleccionado = "2";             
   }
   
   var dtmTransferencia = document.forms[0].dtmTransferencia.value;
   var cboDeptoSurtidor = document.forms[0].cboDepartamentoSurtidor.value;
   var cboDeptoReceptor = document.forms[0].cboDepartamentoReceptor.value;
   var cboCuentaGasto   = document.forms[0].cboCuentaGasto.value;       
   
   document.forms[0].action="<%=strFormAction%>?strCmd=Cancelar&intTipoTransferenciaInterna=" + rdoSeleccionado + "&dtmTransferencia=" + dtmTransferencia + "&intDeptoSurtidorId=" + cboDeptoSurtidor +"&intDeptoReceptorId=" + cboDeptoReceptor + "&intCuentaGastoId=" + cboCuentaGasto + "&txtArticuloId=" + document.forms[0].txtArticuloId.value + "&txtTransferenciaInternaFolioId=<%=intTransferenciaInternaFolioId%>";        
   document.forms[0].submit();
}

function cmdImprimir_onclick() {
   printContent();
   return(true);
}

function cmdRegistrar_onclick() {
   var rdoSeleccionado = "";
   if (document.forms[0].rdoTipoTransferencia1.checked == true) {
       rdoSeleccionado = "1";             
   }
   if (document.forms[0].rdoTipoTransferencia2.checked == true) {
       rdoSeleccionado = "2";             
   }
   
   if (document.forms[0].hdnTotalCantidad.value == document.forms[0].txtCifra.value) {
      
       var dtmTransferencia = document.forms[0].dtmTransferencia.value;
       var cboDeptoSurtidor = document.forms[0].cboDepartamentoSurtidor.value;
       var cboDeptoReceptor = document.forms[0].cboDepartamentoReceptor.value;
       var cboCuentaGasto   = document.forms[0].cboCuentaGasto.value;       
          
       document.forms[0].action="<%=strFormAction%>?strCmd=Registrar&intTipoTransferenciaInterna=" + rdoSeleccionado + "&dtmTransferencia=" + dtmTransferencia + "&intDeptoSurtidorId=" + cboDeptoSurtidor +"&intDeptoReceptorId=" + cboDeptoReceptor + "&intCuentaGastoId=" + cboCuentaGasto + "&txtArticuloId=" + document.forms[0].txtArticuloId.value + "&txtTransferenciaInternaFolioId=<%=intTransferenciaInternaFolioId%>";   
       document.forms[0].submit();
   }
   else{
       alert("Cifra Control Incorrecta");
       document.forms[0].txtCifra.select();
   }
}

function txtArticuloId_onKeyDown() { 
	if(event.keyCode==13){ txtArticuloId_onblur() }
	if(event.keyCode==9) { txtArticuloId_onblur() }
}

function txtArticuloId_onblur() {
   if(Trim(document.forms[0].txtArticuloId.value)==''){
   	   document.forms[0].txtArticuloId.value = '';
	   document.forms[0].hdnArticuloId.value = '';
       document.forms[0].txtArticuloDescripcion.value = '';
	   return;
   }
   
   if(document.forms[0].txtArticuloId.value != document.forms[0].hdnArticuloId.value) {      	
        cmdVerificarArticulo_onclick('PopArticulo.aspx?strArticulo=txtArticuloId&amp;strArticuloNombreId=txtArticuloDescripcion',400,540);		
     
   }
}

function cmdAgregar_onclick() {
	valida=frmMercanciaCapturarTransferenciaInterna_onsubmit();
	if(valida){
		document.forms(0).submit();
	}
}

//-->


</script>
</head>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaCapturarTransferenciaInterna" onSubmit="return frmMercanciaCapturarTransferenciaInterna_onsubmit()" action="about:blank" method="post">
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
            <td class="tdmigaja" width="583"><span class="txdmigaja">Está en: 
              </span><a class="txdmigaja" href="Mercancia.aspx">Mercancía</a> 
              <span class="txdmigaja">: <a class="txdmigaja" href="javascript:strRedireccionaPOSAdmin('MercanciaSalidas.aspx');"> 
              Salidas</a> : <a class="txdmigaja" href="javascript:strRedireccionaPOSAdmin('MercanciaSalidasTransferenciasInternas.aspx');"> 
              Transferencias Internas</a>: Capturar transferencia interna </span> 
            </td>
            <td class="tdfechahora" width="182"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td valign="top" width="583"> <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtablacont" width="75%"> <p><span class="txtitulo">Capturar 
                      transferencia interna</span><span class="txcontenido">Llene 
                      el siguiente formulario para registrar en el sistema una 
                      transferencia interna. Cuando termine, oprima el botón &quot;Registrar 
                      transferencia&quot;. Si no conoce el código de un producto, 
                      oprima el botón &quot;Buscar producto&quot;.</span><br>
                      <span class="txsubtitulo"> <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle"> 
                      Datos de la transferencia</span> </p>
                    <script language="JavaScript">crearDatosSucursal()</script> 
                    <br> <table cellspacing="0" cellpadding="0" width="100%" border="0">
                      <tr> 
                        <td class="tdtittablas" width="158">Tipo de transferencia:</td>
                        <td class="tdconttablas" colspan="2"> <input id="rdoTipoTransferencia1" type="radio" value="1" name="rdoTipoTransferencia">
                          Consumo&nbsp;&nbsp;&nbsp; <input id="rdoTipoTransferencia2" type="radio" value="2" name="rdoTipoTransferencia">
                          Venta </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas">Fecha de transferencia:</td>
                        <td class="tdconttablas" colspan="2"> <input class="campotabla" type="text" maxlength="10" size="10" name="dtmTransferencia"> 
                          <img style="CURSOR: hand" onClick="if(blnValidarCampo(document.forms(0).elements('dtmTransferencia'),false,'Fecha de la Transferencia',cintTipoCampoFecha,10,10,'')){DoobjdtmTransferencia();}" height="13" src="../static/images/icono_calendario.gif" width="20" align="absMiddle"> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas">Departamento que surte:</td>
                        <td class="tdconttablas" colspan="2"> <select class="campotabla" id="cboDepartamentoSurtidor" name="cboDepartamentoSurtidor">
                          </select> </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas">Departamento que recibe:</td>
                        <td class="tdconttablas" colspan="2"> <select class="campotabla" id="cboDepartamentoReceptor" name="cboDepartamentoReceptor">
                          </select> </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas">Cuenta de gastos:</td>
                        <td class="tdconttablas" width="130"> <select class="campotabla" id="cboCuentaGasto" name="cboCuentaGasto">
                          </select> </td>
                        <td class="tdconttablas" width="294"></td>
                      </tr>
                    </table>
                    <p><span class="txsubtitulo"> <img height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Detalle 
                      de productos</span> <span class="txcontenido">Para cada 
                      producto, capture código y cantidad. Luego oprima &quot;Agregar&quot;</span> 
                    </p>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                      <tr> 
                        <td class="tdtittablas" width="68" height="37">Códgo de 
                          producto:</td>
                        <td class="tdpadleft5" width="130" height="37"> <input class="campotabla" type="hidden" size="18" name="hdnArticuloId"> 
                          <input class="campotabla" onKeyDown="txtArticuloId_onKeyDown()" onBlur="return txtArticuloId_onblur()" type="text" maxlength="14" size="13" name="txtArticuloId"> 
                          &nbsp;&nbsp;&nbsp; <a href="javascript:cmdVerificarArticulo_onclick('PopArticulo.aspx?strArticulo=txtArticuloId&amp;strArticuloNombreId=txtArticuloDescripcion',400,540)"> 
                          <img height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"></a> 
                        </td>
                        <td class="tdconttablas" valign="middle" height="37"> 
                          <input class="campotablaresultado" readonly type="text" size="46" name="txtArticuloDescripcion"> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas">Cantidad:</td>
                        <td class="tdpadleft5" width="130"> <input class="campotabla" type="text" maxlength="4" size="16" name="txtCantidad"> 
                        </td>
                        <td class="tdconttablasrojo" align="right" width="389"> 
                          <input class="boton" onClick="return cmdAgregar_onclick()" type="button" align="right" value="Agregar" name="cmdAgregar"> 
                        </td>
                      </tr>
                    </table>
                    <br> <script language="JavaScript">strRecordBrowserHTML()</script> 
                    <br> <p></p></td>
                </tr>
              </table></td>
            <td class="tdcolumnader" valign="top" width="182" rowspan="2">&nbsp;</td>
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
	var objdtmTransferencia = new calendar1(document.forms[0].elements['dtmTransferencia']);
	//-->
  </script>
</form>
<iframe name="ifrArticulo" src width="0" height="0"></iframe>
</body>
</html>
