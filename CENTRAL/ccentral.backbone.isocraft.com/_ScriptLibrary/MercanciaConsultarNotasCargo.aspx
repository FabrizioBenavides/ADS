<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConsultarNotasCargo.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaConsultarNotasCargo" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaConsultarNotasCargo.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para consultar notas de cargo
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Jorge Tamez Sánchez
    ' Version       : 1.0
    ' Last Modified : Lunes, Diciembre 15, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
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
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--

blnConsultaProveedor=true;

var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";


// Despliegue basico
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

function strGeneraTipoNotaCargoHTML(){
 document.write("<%=strGeneraTipoNotaCargoHTML%>");
 return(true);
}

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


// Número de proveedor
function cmdNumeroProveedor_onClick(){
  
       if (document.forms[0].elements['txtProveedor'].value == "") {
           alert("Capturar número/nombre");
           return(false);
       }
       else {
           if (isNaN(document.forms[0].elements['txtProveedor'].value)){
              var url = 'PopProveedor.aspx?strProveedor=txtProveedor&strNombreProveedorId=txtRazonSocialProveedor&strProveedorId=' + document.forms[0].elements['txtProveedor'].value + '&strTipoProveedorNombreId=SinProveedor';
               Pop(url, 400,540);
           }
           else {
               document.forms[0].action = "<%=strFormAction%>?strCmd=BuscarProveedor&intProveedor="+document.forms[0].elements['txtProveedor'].value; 
		       document.forms[0].target="ifrOculto";
		       document.forms[0].submit();
		       document.forms[0].target='';
           }
       }   
}

// Mandar ventana de consulta
function Pop(url, width, height) {
    var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	return(false);
}

function window_onload() {   
   MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
   document.forms[0].action = "<%=strFormAction%>";
   strFiltro = "<%=Request("rdoFiltro")%>";
   
   
   
   document.frmMercanciaConsultarNotasCargo.txtProveedor.focus();
   // Traemos valor seleccionado
   //document.frmMercanciaConsultarNotasCargo.txtProveedor.value =  "<%= Request("txtProveedor") %>";
   //document.frmMercanciaConsultarNotasCargo.txtRazonSocialProveedor.value = "<%= Request("txtRazonSocialProveedor") %>";
   //document.forms[0].elements['txtRegresa'].value = "<%= Request("txtRegresa") %>";
    
   if (strFiltro == "1"){
   document.frmMercanciaConsultarNotasCargo.rdoFiltro1.checked=true;
   document.frmMercanciaConsultarNotasCargo.rdoFiltro2.checked=false;    
   }
   
   if (strFiltro == "2"){
   document.frmMercanciaConsultarNotasCargo.rdoFiltro1.checked=false;
   document.frmMercanciaConsultarNotasCargo.rdoFiltro2.checked=true;
   
   document.frmMercanciaConsultarNotasCargo.txtFechaInicial.value = "<%= Request("txtFechaInicial") %>";
   document.frmMercanciaConsultarNotasCargo.txtFechaFinal.value = "<%= Request("txtFechaFinal") %>";       
   }

  return(true);
}

function DoObjCalendar1(){
	if(document.forms[0].elements['txtFechaInicial'].readOnly==false){
		objCalendar1.popup();
	}
 }	

function DoObjCalendar2(){ 
	if(document.forms[0].elements['txtFechaFinal'].readOnly==false){
		objCalendar2.popup();
	}
}

// Cancelar, manda hacia el Home
function cmdCancelar_onclick() {
 strRedireccionaPOSAdmin('MercanciaEntradas.aspx');
 return(true);
}

//Fecha inicial
function txtFechaInicial_onfocus() {
 document.frmMercanciaConsultarNotasCargo.rdoFiltro2.checked=true;
 return(true);
}

//Fecha final
function txtFechaFinal_onfocus() {
 document.frmMercanciaConsultarNotasCargo.rdoFiltro2.checked=true;
 return(true);
}


function rdoFiltro1_onclick() {
 document.frmMercanciaConsultarNotasCargo.txtFechaInicial.value = '';
 document.frmMercanciaConsultarNotasCargo.txtFechaFinal.value = ''; 
 return(true);
}

function cmdConsultar_onclick() {
  valida=true;

 document.all.objLupa.click();
 
 strCampo = document.forms[0].elements['txtProveedor'].value;
 strCampo = Trim(strCampo);
  
  
//  if (strCampo == "" || strCampo == " " || parseInt(strCampo) == 0) {
//      alert("Capturar número/nombre");
//      return(false);
//  }
 
 if (blnConsultaProveedor==true){
   return(false);
 }
     
  //Validamos la opción del filtro por rango de fechas  
  if (document.frmMercanciaConsultarNotasCargo.rdoFiltro2.checked==true){
      if (valida){ 
          valida=blnValidarCampo(document.forms("frmMercanciaConsultarNotasCargo").elements("txtFechaInicial"),true,"Fecha Inicial",cintTipoCampoFecha,10,10,"");
     
          if (valida==false){
              document.frmMercanciaConsultarNotasCargo.txtFechaInicial.value='';
              return(valida)
          } 
      } 
      if (valida){ 
          valida=blnValidarCampo(document.forms("frmMercanciaConsultarNotasCargo").elements("txtFechaFinal"),true,"Fecha Final",cintTipoCampoFecha,10,10,"");
     
          if (valida==false){
              document.frmMercanciaConsultarNotasCargo.txtFechaFinal.value='';     
              return(valida)
          } 
      } 
  }
   
  document.forms[0].action = "MercanciaNotasCargoProveedor.aspx";
       
  document.forms[0].submit();
  return(valida);
}

function txtProveedor_onblur() {
}
//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaConsultarNotasCargo">
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
            <td width="10" bgcolor="#FFFFFF"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><span class="txdmigaja">Est&aacute; 
              en : </span><a href="Mercancia.aspx" class="txdmigaja">Mercanc&iacute;a</a><span class="txdmigaja"> 
              : <a href="javascript:strRedireccionaPOSAdmin('MercanciaEntradas.aspx')" class="txdmigaja">Entradas</a></span><span class="txdmigaja"> 
              : Consultar notas de cargo</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Consultar 
              notas de cargo</span><span class="txcontenido">Tenga presente que 
              las notas de cargo se mostrar&aacute;n con al menos un d&iacute;a 
              de demora respecto a la operaci&oacute;n. Utilice los filtros siguientes 
              para configurar la consulta en el archivo, y luego oprima &quot;Consultar&quot;.</span> 
              <br> <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle"> 
              Filtros de consulta</span><br> <script language="JavaScript">strGeneraTipoNotaCargoHTML()</script> 
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td class="tdtittablas">De que proveedor:</td>
                  <td width="160" class="tdconttablas"><input name="txtProveedor" type="text" class="campotabla" id="txtProveedor" size="15" maxlength="15" onBlur="return txtProveedor_onblur()"> 
                    <a href="javascript:;" id="objLupa" onClick="return cmdNumeroProveedor_onClick();"><img src="../static/images/icono_lupa.gif" width="17" height="17" align="absMiddle" border="0"></a>&nbsp;&nbsp;&nbsp;</td>
                  <td colspan="2" class="tdconttablas">&nbsp; <input name="txtRazonSocialProveedor" type="text" class="campotablaresultado" size="40" maxlength="40" readonly="true"></td>
                  <td width="6" class="tdconttablas">&nbsp;</td>
                </tr>
                <tr> 
                  <td class="tdtittablas">Recuperar notas:</td>
                  <td height="36" colspan="4" valign="middle" class="tdconttablas"> 
                    <input name="rdoFiltro" type="radio" value="1" id="rdoFiltro1" checked onClick="return rdoFiltro1_onclick()">
                    Del mes en curso</td>
                </tr>
                <tr> 
                  <td>&nbsp;</td>
                  <td height="36" valign="middle" class="tdconttablas"> <input type="radio" name="rdoFiltro" id="rdoFiltro2" value="2">
                    De &nbsp; <input name="txtFechaInicial" type="text" class="campotabla" id="txtFechaInicial" size="10" maxlength="10" onFocus="return txtFechaInicial_onfocus()"> 
                    <img src="../static/images/icono_calendario.gif" width="20" height="13" align="absmiddle" style="CURSOR:hand" onClick="document.frmMercanciaConsultarNotasCargo.rdoFiltro2.checked=true;if(blnValidarCampo(document.forms('frmMercanciaConsultarNotasCargo').elements('txtFechaInicial'),false,'Fecha Inicial',cintTipoCampoFecha,10,10,'')){objCalendar1.popup();}"></td>
                  <td width="17" height="36" valign="middle" class="tdconttablas">Al</td>
                  <td width="280" height="36" valign="middle" class="tdconttablas"> 
                    <input name="txtFechaFinal" type="text" class="campotabla" id="txtFechaFinal" size="10" maxlength="10" onFocus="return txtFechaFinal_onfocus()"> 
                    <img src="../static/images/icono_calendario.gif" width="20" height="13" align="absmiddle" style="CURSOR:hand" onClick="document.frmMercanciaConsultarNotasCargo.rdoFiltro2.checked=true;if(blnValidarCampo(document.forms('frmMercanciaConsultarNotasCargo').elements('txtFechaFinal'),false,'Fecha Final',cintTipoCampoFecha,10,10,'')){objCalendar2.popup();}">&nbsp;&nbsp;</td>
                  <td height="36" valign="middle" class="tdconttablas">&nbsp;</td>
                </tr>
                <tr> 
                  <td>&nbsp;</td>
                  <td height="36" colspan="4" valign="bottom" class="tdconttablas">&nbsp;</td>
                </tr>
                <tr> 
                  <td>&nbsp;</td>
                  <td height="36" colspan="4" valign="bottom" class="tdconttablas"><input name="cmdCancelar" type="button" class="boton" id="cmdCancelar" value="Cancelar" onClick="return cmdCancelar_onclick()"> 
                    &nbsp;&nbsp; <input name="cmdConsultar" type="submit" class="boton" id="cmdConsultar" value="Consultar" onClick="return cmdConsultar_onclick()"> 
                    &nbsp;&nbsp; </td>
                </tr>
              </table>
              <br> <br> </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</script>	
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
    var objCalendar1 = new calendar1(document.forms['frmMercanciaConsultarNotasCargo'].elements['txtFechaInicial']);	
    var objCalendar2 = new calendar1(document.forms['frmMercanciaConsultarNotasCargo'].elements['txtFechaFinal']);
	//-->
</script>
</form>
<iframe name="ifrOculto" height="0" width="0" src=""></iframe>
</body>
</html>
