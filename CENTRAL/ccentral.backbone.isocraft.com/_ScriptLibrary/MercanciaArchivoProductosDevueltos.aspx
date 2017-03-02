<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaArchivoProductosDevueltos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaArchivoProductosDevueltos" codePage="28592"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaArchivoProductosDevueltos.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página de productos devueltos.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Carlos E. Pérez Torres
    ' Version       : 1.0
    ' Last Modified : Lunes, Octubre 27, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/ToolsValRFC.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
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
         
         return(true);
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

function btnSalir_onclick() {
	document.location = 'MercanciaSalidasDevoluciones.aspx';
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
	   
       if (isNaN(strtxtProveedorB) || strtxtProveedorB.length<1 ) // Esta capturando Descripcion
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

function fnUpBuscarProveedor(intProveedorId,strProveedorNombreId,strProveedorRazonSocial,strProveedorRFC, intError) {

    document.forms(0).txtRazonSocialProveedor.value = strProveedorRazonSocial;

    if(intError == 0){
        document.forms(0).hdnProveedorId.value = intProveedorId;
		document.forms(0).txtProveedor.value = strProveedorNombreId;
		document.forms(0).hdnProveedor.value = strProveedorNombreId;
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

function strRecordBrowser() {
	document.write("<%=strRecordBrowser%>");
	return(true);
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

//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaArchivoProductosDevueltos">
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
            <td width="583" class="tdmigaja"><span class="txdmigaja">Está en :</span><span class="txdmigaja"> 
              <a href="Mercancia.aspx" class="txdmigaja">Mercancía</a> : <a href="MercanciaSalidas.aspx" class="txdmigaja">Salidas</a> 
              : <a href="MercanciaSalidasDevoluciones.aspx" class="txdmigaja">Devolución 
              de mercancía</a> : Archivo de productos devueltos</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Archivo de productos devueltos</span> 
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td class="tdtittablas"><input type="radio" name="rdoConsulta" value="1">
                          Por proveedor</td>
                        <td colspan="2" valign="middle" class="tdpadleft5"> <input name="txtProveedor" type="text" class="campotabla" size="15" onFocus="return cmdActivaRadio0();"
																	onKeyDown="if (event.keyCode==13){document.forms[0].elements['imgLupa'].click();} if (event.keyCode==9){document.forms[0].elements['imgLupa'].click();}"> 
                          &nbsp; <a id="objLupa" onClick="return objLupaProveedor_onClick();"><img src="../static/images/icono_lupa.gif" width="17" height="17" align="absMiddle" border="0"
																		id="imgLupa"></a></td>
                        <td valign="middle" class="tdconttablas"><span class="txconttablasrojo"> 
                          <input name="txtRazonSocialProveedor" class="campotablaresultado" size="45" maxlength="45"
																		border="0" id="txtRazonSocialProveedor" onFocus="return cmdActivaRadio0();" readonly>
                          </span> </td>
                      </tr>
                      <tr> 
                        <td width="129" class="tdtittablas"><input type="radio" name="rdoConsulta" value="2">
                          Por fecha Entre:</td>
                        <td width="100" valign="middle" class="tdpadleft5"><input name="txtFechaInicio" type="text" class="campotabla" size="10" maxlength="10" onFocus="return cmdActivaRadio1();"> 
                          <a href="javascript:objCalendar1.popup();"><img src="../static/images/icono_calendario.gif" width="20" height="13" border="0" onClick="return cmdActivaRadio1(); blnValidarCampo(document.forms('frmMercanciaArchivoProductosDevueltos').elements('txtFechaInicio'),false,'Fecha Inicio',cintTipoCampoFecha,10,10,'');"
																		style="CURSOR:hand"></a></td>
                        <td width="30" align="center" valign="middle" class="tdtittablas">Y:</td>
                        <td width="309" valign="middle" class="tdpadleft5"><input name="txtFechaFin" type="text" class="campotabla" size="10" maxlength="10" onFocus="return cmdActivaRadio1();"> 
                          <a href="javascript:objCalendar2.popup();"><img src="../static/images/icono_calendario.gif" width="20" height="13" border="0" onClick="return cmdActivaRadio1(); blnValidarCampo(document.forms('frmMercanciaArchivoProductosDevueltos').elements('txtFechaFin'),false,'Fecha Fin',cintTipoCampoFecha,10,10,'');"
																		style="CURSOR:hand"></a></td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas"><input type="radio" name="rdoConsulta" value="3">
                          Todos los folios</td>
                        <td colspan="3" valign="middle" class="tdpadleft5">&nbsp;</td>
                      </tr>
                    </table>
                    <br> <input name="btnConsultar" type="button" class="boton" value="Consultar" onClick="return cmdConsultar_onclick();"> 
                    <br> <br> <script language="javascript">strRecordBrowser()</script> 
                    <br> <input name="btnSalir" type="button" class="boton" value="Regresar" onClick="return btnSalir_onclick();"
														style="DISPLAY:none"> 
                    &nbsp;&nbsp; <br> <br> </p> </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"><script language="javascript">strGeneraTablaAyuda('');</script></td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
    <tr> 
      <td> <input type='hidden' name='hdnProveedorId' value= '<%=Request.Form("hdnProveedorId")%>'> 
        <input type='hidden' name='hdnProveedorNombreId' value= '<%=Request.Form("hdnProveedorNombreId")%>'> 
        <input type="hidden" name="hdnProveedor" value= '<%=Request.Form("hdnProveedor")%>'> 
      </td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	var objCalendar1 = new calendar1(document.forms['frmMercanciaArchivoProductosDevueltos'].elements['txtFechaInicio']);
	var objCalendar2 = new calendar1(document.forms['frmMercanciaArchivoProductosDevueltos'].elements['txtFechaFin']);
	//-->
			</script>
</form>
<iframe name="ifrProveedor" height="0" width="0" src=""></iframe>
</body>
</HTML>
