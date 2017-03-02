<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaArchivoProductosReclamados.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaArchivoProductosReclamados" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaArchivoProductosReclamados.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página de productos Reclamados.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Martes, Octubre 28, 2003
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
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--

var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";

function window_onload() {
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action = "<%=strFormAction%>"; 
  document.forms[0].elements["txtFechaInicio"].value = "<%=Request.Form("txtFechaInicio")%>"
  document.forms[0].elements["txtFechaFin"].value = "<%=Request.Form("txtFechaFin")%>"
  document.forms[0].elements["txtProveedor"].value = "<%=Request.Form("txtProveedor")%>"
  document.forms[0].elements["txtRazonSocialProveedor"].value = "<%=Request.Form("txtRazonSocialProveedor")%>"
  
  <%If Request.Form("rdoConsulta") = "1" then%>
     document.forms[0].elements["rdoConsulta"][0].checked = true;
  <%else if Request.Form("rdoConsulta") = "2" then%>
	 document.forms[0].elements["rdoConsulta"][1].checked = true;
  <%else%>
     document.forms[0].elements["rdoConsulta"][2].checked = true;
  <%End If%>
  
  intCuenta = "<%= strRecordBrowser.length %>";
  strCmd = "<%=strCmd%>";
           
  if (parseInt(intCuenta) > 0 &&  strCmd=="Consultar"){
           document.forms[0].elements['btnSalir'].style.display = "";
  }     
  
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
function btnSalir_onclick() {
	document.location = 'MercanciaSalidasReclamaciones.aspx';
	return(true);
}

function cmdValidarForma() {
	if ((document.forms[0].elements["rdoConsulta"][0].checked != true) && (document.forms[0].elements["rdoConsulta"][1].checked != true)  && (document.forms[0].elements["rdoConsulta"][2].checked != true)){
		alert("Por favor seleccione una consulta.");
		return(false);
	}
	else if ((document.forms[0].elements["rdoConsulta"][0].checked == true) && ( Trim(document.forms[0].elements["txtProveedor"].value) == " " || document.forms[0].elements["txtProveedor"].value == "" )){
		alert("Por favor seleccione un proveedor.");
		document.forms[0].elements["txtProveedor"].focus();
		return(false);
	}
	else if ( (document.forms[0].elements["rdoConsulta"][1].checked == true) && ((document.forms[0].elements["txtFechaInicio"].value == "") || (document.forms[0].elements["txtFechaFin"].value == "")) ){
		alert("Por favor seleccione las fechas.");
		document.forms[0].elements["txtFechaInicio"].focus();
		return(false);
	}
	else{
		return(true);
	}		
}

function cmdConsultar_onclick(){
	if (cmdValidarForma()==false) {
		return(false);
	}
	else {
		document.forms[0].action = "<%=strFormAction%>?strCmd=Consultar";
		document.forms[0].submit();
		return(true);
	}
}

function cmdActivaRadio1(){
	document.forms[0].elements["rdoConsulta"][1].checked = true;
	document.forms[0].elements["txtProveedor"].value = "";
	document.forms[0].elements["txtRazonSocialProveedor"].value = "";
	return(true);
}

function cmdActivaRadio0(){
	document.forms[0].elements["rdoConsulta"][0].checked = true;
	document.forms[0].elements["txtFechaInicio"].value = "";
	document.forms[0].elements["txtFechaFin"].value = "";
	return(true);
}

// Lupa para listar proveedores
function objLupaProveedor_onClick(){
	if (document.forms[0].elements['txtProveedor'].value!="" && document.forms[0].elements['txtProveedor'].value != '0')
	{
       var strtxtProveedorB = Trim((document.forms[0].elements['txtProveedor'].value).substring(0,4));
	   	 
       if (!isNaN(strtxtProveedorB)) // Esta capturando Descripcion
       {
           document.forms[0].elements['txtRazonSocialProveedor'].value='';
           
		   strEvalJs='opener.fnBusquedaProveedorPorIframe();';		
           strParametros = 'campoProveedorId=hdnProveedorId';
           strParametros = strParametros + '&campoProveedorNombreId=txtProveedor';
           strParametros = strParametros + '&campoProveedorRazonSocial=txtRazonSocialProveedor';                
           strParametros = strParametros + '&strTipoProveedorNombreId=';
           strParametros = strParametros + '&strProveedorId=' + document.forms[0].elements['txtProveedor'].value;		     
           
		   Pop('PopProveedor.aspx?'+strParametros+'&strEvalJs='+strEvalJs,500,540); 
		   return;
       }
       else // Esta capturando el numero de proveedor
       {
           document.forms[0].action = "<%=strFormAction%>?strCmd=BuscaProveedor";
           document.forms[0].target="ifrProveedor";
           document.forms[0].submit();
           document.forms[0].target='';
           return;
       }
   }
   else
   {
		alert("Teclear Número de proveedor o descripción");
		document.forms[0].elements['txtProveedor'].focus();
        return;
   }

}

function fnBusquedaProveedorPorIframe() {
 var hdnProveedorId = document.forms[0].elements['hdnProveedorId'].value*1;
 if (hdnProveedorId==0) {
    document.forms[0].elements['txtProveedor'].value = '';
    document.forms[0].elements['txtProveedor'].focus();
 }
 else {
    document.forms[0].elements['btnConsultar'].focus();
 } 
}

function fnUpdProveedorPorIframe(strBusquedaProveedorId, strBusquedaProveedorNombreId,strProveedorNombre,intError){
    document.forms(0).txtRazonSocialProveedor.value = strProveedorNombre;
    
    if(intError == 0){
        document.forms(0).hdnProveedorId.value = strBusquedaProveedorId;
		document.forms(0).txtProveedor.value = strBusquedaProveedorNombreId;
		document.forms(0).hdnProveedor.value = strBusquedaProveedorNombreId;
        document.forms[0].elements['btnConsultar'].focus();
	}
	else{
		alert("Proveedor no encontrado.");
		document.forms(0).hdnProveedorId.value = '';
		document.forms(0).txtProveedor.value = '';
		document.forms(0).hdnProveedor.value = '';
		document.forms(0).txtProveedor.focus();
		document.forms(0).txtProveedor.select();
	}
}


// Mandar ventana de consulta
function Pop(url, width, height) {
    var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	return(false);
}

function txtProveedor_onblur() {
   if(Trim(document.forms[0].elements['txtProveedor'].value)==''){
   	   document.forms[0].txtProveedor.value = '';
	   document.forms[0].hdnProveedor.value = '';
       document.forms[0].txtRazonSocialProveedor.value = '';
	   return;
   }
   
   if(document.forms[0].elements['txtProveedor'].value != document.forms[0].elements['hdnProveedor'].value) {
      document.forms(0).hdnProveedor.value = '';
	  objLupaProveedor_onClick();
      return;    
   }
}

function strRecordBrowser() {
	document.write("<%=strRecordBrowser%>");
	return(true);
}
//-->

</script>
</head>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form action="about:blank" method="post" name="frmMercanciaArchivoProductosReclamados">
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
            <td class="tdmigaja" width="583"><span class="txdmigaja">Está en :</span><span class="txdmigaja"> 
              <a class="txdmigaja" href="Mercancia.aspx">Mercancía</a> : <a class="txdmigaja" href="MercanciaSalidas.aspx">Salidas</a> 
              : <a class="txdmigaja" href="MercanciaSalidasReclamaciones.aspx">Reclamaciones</a> 
              : Archivo de productos reclamados</span></td>
            <td class="tdfechahora" width="187"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td valign="top" width="583"> <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtablacont" width="100%" colspan="3"> <span class="txtitulo">Archivo 
                    de productos reclamados</span> <table cellspacing="0" cellpadding="0" width="100%" border="0">
                      <tr> 
                        <td class="tdtittablas"> <input type="radio" value="1" name="rdoConsulta">
                          Por proveedor</td>
                        <td class="tdpadleft5" valign="middle" colspan="2"> <input name="txtProveedor" type="text" class="campotabla" size="15" onFocus="return cmdActivaRadio0();"
																onKeyDown="if (event.keyCode==13){document.forms[0].elements['imgLupa'].click();} if (event.keyCode==9){document.forms[0].elements['imgLupa'].click();}"> 
                          &nbsp; <a id="objLupa" onClick="return objLupaProveedor_onClick();"><img src="../static/images/icono_lupa.gif" width="17" height="17" align="absMiddle" border="0"
																	id="imgLupa"></a></td>
                        <td class="tdconttablas" valign="middle"> <span class="txconttablasrojo"> 
                          <input name="txtRazonSocialProveedor" class="campotablaresultado" size="45" maxlength="45"
																	border="0" id="txtRazonSocialProveedor" onFocus="return cmdActivaRadio0();" readonly>
                          </span> </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas" width="129"> <input type="radio" value="2" name="rdoConsulta">
                          Por fecha Entre:</td>
                        <td class="tdpadleft5" valign="middle" width="100"> <input name="txtFechaInicio" type="text" class="campotabla" size="10" maxlength="10" onFocus="return cmdActivaRadio1();"> 
                          <a href="javascript:objCalendar1.popup();"><img src="../static/images/icono_calendario.gif" width="20" height="13" border="0" onClick="return cmdActivaRadio1(); blnValidarCampo(document.forms('frmMercanciaArchivoProductosDevueltos').elements('txtFechaInicio'),false,'Fecha Inicio',cintTipoCampoFecha,10,10,'');"
																	style="CURSOR:hand"></a></td>
                        <td class="tdtittablas" valign="middle" align="center" width="32"> 
                          Y:</td>
                        <td class="tdpadleft5" valign="middle" width="307"> <input name="txtFechaFin" type="text" class="campotabla" size="10" maxlength="10" onFocus="return cmdActivaRadio1();"> 
                          <a href="javascript:objCalendar2.popup();"><img src="../static/images/icono_calendario.gif" width="20" height="13" border="0" onClick="return cmdActivaRadio1(); blnValidarCampo(document.forms('frmMercanciaArchivoProductosDevueltos').elements('txtFechaFin'),false,'Fecha Fin',cintTipoCampoFecha,10,10,'');"
																	style="CURSOR:hand"></a></td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas"> <input type="radio" value="3" name="rdoConsulta">
                          Todos los folios</td>
                        <td class="tdpadleft5" valign="middle" colspan="3">&nbsp;</td>
                      </tr>
                    </table>
                    <br> <input name="btnSalir" type="button" class="boton" value="Regresar" onClick="return btnSalir_onclick();"
													style="display:none"> <input name="btnConsultar" type="button" class="boton" value="Consultar" onClick="return cmdConsultar_onclick();"> 
                    <br> <script language="javascript">strRecordBrowser()</script> 
                  </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"><script language="javascript">strGeneraTablaAyuda(strPaginaAyuda);</script> 
            </td>
          </tr>
          <tr> 
            <td class="tdbottom" colspan="2"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
          <tr> 
            <td colspan="2"> <input type='hidden' name='hdnProveedorId' value= '<%=Request.Form("hdnProveedorId")%>'> 
              <input type='hidden' name='hdnProveedorNombreId' value= '<%=Request.Form("hdnProveedorNombreId")%>'> 
              <input type="hidden" name="hdnProveedor" value= '<%=Request.Form("hdnProveedor")%>'> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	var objCalendar1 = new calendar1(document.forms(0).elements('txtFechaInicio'));
	var objCalendar2 = new calendar1(document.forms(0).elements('txtFechaFin'));
	//-->
</script>
</form>
<iframe name="ifrProveedor" src width="0" height="0"></iframe>
</body>
</html>
