<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaCapturarMermaControlada.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaCapturarMermaControlada" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaCapturarMermaControlada.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Griselda Gómez Ponce
    ' Version       : 1.0
    ' Last Modified : Sábado, 25 Octubre, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--

var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";

function window_onload(){
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action="<%=strFormAction%>";
  document.forms[0].txtFechaCaptura.value = "<%=dtmFechaCaptura%>";
  document.forms[0].txtMermaId.value = "<%=intMermaId%>";
      
  <%=strGeneraComboMotivoMerma%>;
  
  // Cuando ya se asignó una Id de Merma ya no se puede modificar al Fecha
   if (<%=intMermaId%>!=0){
	     document.forms[0].txtFechaCaptura.readOnly=true;
   }
	
  // Mensajes que se envian al usuario.
   if ("<%=strMensaje%>" != ""){
	    window.alert("<%=strMensaje%>");
   }
	
  // Si el articulo no se encuentra, entonces manda el mensaje de Error	
   if("<%=intError%>" == "-100"){
     alert("Codigo Articulo No existe");
   }
   
      if ("<%=strCmd%>"!="AgregarArticulo"){
      <% if intError = 0 then %>
      document.forms[0].txtArticuloId.value="<%=intArticuloId%>";
      document.forms[0].hdnArticuloId.value="<%=intArticuloId%>";
      document.forms[0].txtArticuloDescripcion.value="<%=strArticuloDescripcion%>";
     <% end if %>
   }
   

   if ( "<%=strCmd%>"=="Registrar"){
      //Inicializamos valores
      document.forms[0].txtFechaCaptura.value = '';
      document.forms[0].txtMermaId.value = 0;
      document.forms[0].cboMotivoMerma.value = 0;
      document.forms[0].submit();
   }
   
  <% if Request.QueryString.Count=0 andalso Request.Form.Count=0 then %>
		document.forms(0).txtFechaCaptura.focus(); 
	<% else %>
		<% Select Case Trim(Request("strCmd")) %>
		<% Case "Agregar" %>
			document.forms(0).txtArticuloId.select();
		<% Case "Borrar" %>
			document.forms(0).txtArticuloId.select();
		<% end Select %>
	<% end if %>
	
  return(true);		
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}

function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

function txtFechaCaptura_onblur() {
  valida=true;
  valida=blnValidarCampo(document.forms[0].elements('txtFechaCaptura'),false,'Fecha',cintTipoCampoFecha,10,10,'')
  return(valida);
}
 
function txtCantidadArticulo_onblur() {
   valida = true;
   if (valida){
      valida=blnValidarCampo(document.forms[0].elements("txtCantidadArticulo"),false,"Cantidad",cintTipoCampoEntero,5,1,"");
   }
   
   if (document.forms[0].txtCantidadArticulo.value < 0){
       window.alert("Cantidad inválida");
       document.forms[0].txtCantidadArticulo.focus();
       valida=false;
   }
 
   return(valida);
}


function strbtnAgregar(){
   document.write("<%=strbtnAgregar%>");
   return(true);
}

function cmdBuscarArticulo_onClick(){
	if (document.forms[0].txtArticuloId.value!=""){
      if (!isNaN(document.forms[0].txtArticuloId.value)) {
		   document.forms[0].target="ifrOculto";
           document.forms[0].action="<%=strFormAction%>?strCmd=BuscarArticulo";
           document.forms[0].submit();
           document.forms[0].target="";
			return(false);
	  }
	  else {
			strEvalJsClosePopup = "&strEvalJsClosePopup=opener.fnUpdArticuloPorIframe(intValor,strNombre,'',0)"; 
			url = "PopArticulo.aspx?strArticulo=txtArticuloId&strArticuloNombreId=txtArticuloDescripcion&strArticuloIdNombre=" + document.forms[0].txtArticuloId.value;
			url = url+strEvalJsClosePopup;
			width = 500;
			height = 540;
			return Pop(url, width, height);

	  }
	}
	else {
		alert("Teclear Código o Descripcion");
        return false;
	}
	
}


function Pop(url, width, height) {
    var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	 return false;
}


function cmdAgregar_onclick() {
    // Validamos que todos los campos se hayan capturado correctamente
    valida=true;
    
    //Valida fecha de captura
    if (document.forms[0].txtFechaCaptura.value==""){
       alert("Capturar fecha de merma");
       document.forms[0].txtFechaCaptura.focus();
       return false;
    }
    

    //Fecha de captura no sea mayor al dia de hoy   
    strFecha=document.forms[0].elements("txtFechaCaptura").value.substr(3,2) + "/" +document.forms[0].elements("txtFechaCaptura").value.substr(0,2)+"/"+document.forms[0].elements("txtFechaCaptura").value.substr(6,4)
    if (Date.parse(strFecha) > Date.parse("<%=clsCommons.strGetCustomDateTime("MM/dd/yyyy")%>") ){
        alert("Fecha merma inválida");
        document.forms[0].txtFechaCaptura.focus();
       return false;
    }
 
    
    if (blnValidarCampo(document.forms[0].elements('txtFechaCaptura'),false,'Fecha',cintTipoCampoFecha,10,10,'')){
    }
    else{
         return false;
    }
 
       
    if (isNaN(document.forms[0].txtArticuloId.value)) {
        	url = "PopArticulo.aspx?strArticulo=txtArticuloId&strArticuloNombreId=txtArticuloDescripcion&strArticuloIdNombre=" + document.forms[0].txtArticuloId.value;
			width = 500;
			height = 540;
			return Pop(url, width, height);
    }
 
 
    if ((document.forms[0].txtArticuloId.value == "")||(document.forms[0].txtArticuloId.value == 0)) {
		alert("Capturar: Código.");
		document.forms[0].txtArticuloId.focus();
        return false;
	}
    
    if ((document.forms[0].txtCantidadArticulo.value == "") || (document.forms[0].txtCantidadArticulo.value==0)) {
		alert("Capturar: Cantidad .");
		document.forms[0].txtCantidadArticulo.focus();
        return false;
	}
	
	if (document.forms[0].cboMotivoMerma.value == 0) {
		alert("Seleccionar: Motivo Merma.");
		document.forms[0].cboMotivoMerma.focus();
        return false;
	}
  
    document.forms[0].action="<%=strFormAction%>?strCmd=AgregarArticulo";
    document.forms[0].submit();
    
}

function cmdRegistrar_onclick() {    
   if ((document.forms[0].txtCifraControl.value=="") || (document.forms[0].txtCifraControl.value != <%=intCifraControl%>)) {
      window.alert("Cifra Control incorrecta");
      document.forms[0].txtCifraControl.value=0;
      document.forms[0].txtCifraControl.focus();
      document.forms[0].txtCifraControl.select();
     return(false);
     }
   else{
      document.forms[0].action="<%=strFormAction%>?strCmd=Registrar";
      document.forms[0].submit();
   }
}

function cmdCancelar_onclick() {
   document.forms[0].action="<%=strFormAction%>?strCmd=Cancelar";
   document.forms[0].submit();
}

function cmdRegresar_onclick() {
   //Regresamos al home de Mermas
   strRedireccionaPOSAdmin('MercanciaMermas.aspx');
}

function DoObjCalendar1(){
	if(document.forms(0).txtFechaCaptura.readOnly==false){
		objCalendar1.popup();
	}
}


function txtArticuloId_onKeyDown() { 
	if(event.keyCode==13){ txtArticuloId_onblur() }
	if(event.keyCode==9) { txtArticuloId_onblur() }
}

function txtArticuloId_onblur() { 
	if(Trim(document.forms(0).txtArticuloId.value)==''){
		document.forms(0).txtArticuloId.value = '';
		document.forms(0).hdnArticuloId.value = '';
		document.forms(0).txtArticuloDescripcion.value = '';
		return
	}
	
	if(document.forms(0).txtArticuloId.value!=document.forms(0).hdnArticuloId.value){
		if(isNaN(document.forms(0).txtArticuloId.value)){ 
			//escribo letras
			cmdBuscarArticulo_onClick()
		}
		else {
			//escribio un numero
			cmdBuscarArticulo_onClick()
		}
	}
}

function fnUpdArticuloPorIframe(strArticuloId,strArticuloDescripcion,strPrecioUnitario,intError){
    if(intError == 0){ strArticuloDescripcion = Trim(strArticuloDescripcion); }
	document.forms(0).txtArticuloId.value = strArticuloId;
	document.forms(0).hdnArticuloId.value = strArticuloId;
    document.forms(0).txtArticuloDescripcion.value = strArticuloDescripcion; 
    if(intError == 0){
		document.forms(0).txtCantidadArticulo.focus(); 
		document.forms(0).txtCantidadArticulo.select();
	}
	else{	
		alert("Artículo no encontrado.");
		document.forms(0).txtArticuloId.focus();
	}
}
//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaCapturarMermaControlada">
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
              : </span><span class="txdmigaja"><a href="javascript:strRedireccionaPOSAdmin('MercanciaMermas.aspx')" class="txdmigaja">Merma</a></span><span class="txdmigaja"> 
              : </span><span class="txdmigaja">Capturar merma controlada</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" valign="top" class="tdtablacont"> <p><span class="txtitulo">Capturar 
                      merma controlada</span><span class="txcontenido">Llene el 
                      siguiente formulario para registrar en el sistema las mermas. 
                      Al terminar, oprima el botón 'Registrar merma'. Si no conoce 
                      el código de un producto, oprima el botón 'Buscar producto'.</span><br>
                      <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Datos 
                      del reporte</span> 
                      <script language="JavaScript">crearDatosSucursal()</script>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td class="tdtittablas" width="136">Fecha de captura:</td>
                        <td valign="middle" class="tdpadleft5"> <input name="txtFechaCaptura" type="text" class="campotabla" size="10" maxlength="10" onBlur="return txtFechaCaptura_onblur()"> 
                          <img src="../static/images/icono_calendario.gif" width="20" style="cursor:hand" height="13" onClick="if(blnValidarCampo(document.forms[0].elements('txtFechaCaptura'),false,'Fecha',cintTipoCampoFecha,10,10,'')){DoObjCalendar1();}"> 
                        </td>
                      </tr>
                    </table>
                    <br> <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Detalle 
                    de productos mermados</span> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tbody>
                        <tr> 
                          <td width="82" class="tdtittablas">Código:</td>
                          <td width="122" class="tdpadleft5" nowrap><nobr> 
                            <input name="hdnArticuloId" type="hidden">
                            <input name="txtArticuloId" type="text" class="campotabla" size="14" onBlur="return txtArticuloId_onblur()" onKeyDown="txtArticuloId_onKeyDown()">
                            <a href="javascript:;" onClick="return cmdBuscarArticulo_onClick();"><img height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"></a> 
                            &nbsp; 
                            <input class="campotablaresultado" type="text" size="50" name="txtArticuloDescripcion" readonly>
                            </nobr> </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Cantidad:</td>
                          <td class="tdpadleft5"><input name="txtCantidadArticulo" type="text" class="campotabla" size="14" onBlur="return txtCantidadArticulo_onblur()"> 
                          </td>
                        </tr>
                        <tr> 
                          <td height="27" class="tdtittablas">Motivo:</td>
                          <td height="27" class="tdpadleft5" width="122"><select name="cboMotivoMerma" class="campotabla">
                            </select></td>
                        </tr>
                    </table>
                    <script language="javascript">strbtnAgregar()</script> <input name="txtMermaId" type="hidden" value="0"> 
                    <br> <script language="javascript">strRecordBrowserHTML()</script></P> 
                  </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp; </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr></TBODY>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
    var objCalendar1 = new calendar1(document.forms[0].elements['txtFechaCaptura']);
	//-->
</script>
</form>
<iframe name="ifrOculto" width=00 height=00></iframe>
</body>
</html>
