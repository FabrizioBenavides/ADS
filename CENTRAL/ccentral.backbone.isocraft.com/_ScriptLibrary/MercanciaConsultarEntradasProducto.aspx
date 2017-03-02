<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConsultarEntradasProducto.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaConsultarEntradasProducto" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaConsultarEntradasProducto.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página de consulta de entradas de productos 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Jorge Tamez Sánchez
    ' Version       : 1.0
    ' Last Modified : Martes, Noviembre 25, 2003
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
var strPaginaAyuda
strPaginaAyuda = "";

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}

// Submit
function frmMercanciaConsultarEntradasProducto_onsubmit() {
  valida=true;

  if (document.forms[0].elements['txtArticuloId'].value == ""){
     alert("Capturar correctamente el número de artículo.");
     return(false);
  }

  if (Trim(document.forms[0].elements['txtArticuloId'].value)==" "){
     alert("Capturar correctamente el número de artículo.");
     return(false);
  }  
  
  if (isNaN(document.forms[0].elements['txtArticuloId'].value)){
     alert("Capturar correctamente el número de artículo.");
     return(false);
  }
  
  if (parseInt(document.forms[0].elements['txtArticuloId'].value) <= 0){
     alert("Capturar correctamente el número de artículo.");
     return(false);
  }
  
  document.forms[0].action="<%=strFormAction%>?strCmd=Consultar";  
  return(valida);
}

// onload
function window_onload() {
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action = "<%=strFormAction%>";

  // Mensajes que se envian al usuario.
   if ("<%=strMensaje%>" != ""){
	    window.alert("<%=strMensaje%>");
   }

      document.forms[0].txtArticuloId.value="<%= Request.Form("txtArticuloId") %>";
      document.forms[0].elements['txtArticuloDescripcion'].value="<%= Request.Form("txtArticuloDescripcion") %>";
   
  //Articulo consultado 
   if ("<%=intArticuloId%>" != ""){
      document.forms[0].txtArticuloId.value="<%=intArticuloId%>";
      document.forms[0].elements['txtArticuloDescripcion'].value="<%=strArticuloDescripcion%>";
   }

   
     //Selecciona el mes consultado
   if ("<%=Request.Form("rdoMesConsulta")%>" == "1") {
     document.frmMercanciaConsultarEntradasProducto.rdoMesConsulta1.checked=true;     
   }
   
   if ("<%=Request.Form("rdoMesConsulta")%>" == "2") {
     document.frmMercanciaConsultarEntradasProducto.rdoMesConsulta2.checked=true;
   }
  
  return(true);
}

// RecordBrowser
function strRecordBrowserHTML(){
 document.write("<%=strRecordBrowserHTML%>");
 return(true);
}


// Buscamos Articulo
function cmdBuscarArticulo_onClick(){
	if (document.forms[0].elements['txtArticuloId'].value!=""){
      if (!isNaN(document.forms[0].elements['txtArticuloId'].value)) {
	  
	       if (document.forms[0].elements['hdnArticuloId'].value != document.forms[0].elements['txtArticuloId'].value){
                     document.forms[0].action="<%=strFormAction%>?strCmd=BuscarArticulo";
                     document.forms[0].target = "ifrOculto";
                     document.forms[0].submit();
                     document.forms[0].target = "";
            		 return(false);
		   }			 
	  }
	  else {
			url = "PopArticulo.aspx?strArticulo=txtArticuloId&strArticuloNombreId=txtArticuloDescripcion&strArticuloIdNombre=" + document.forms[0].elements['txtArticuloId'].value;
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

// Regresamos hacia Home
function cmdRegresar_onclick() {
  document.location ="MercanciaEntradasTransferencia.aspx";
  return(true) ;
}

// Inicializamos la consulta
function cmdLimpiar_onClick(){
 document.forms[0].elements['txtArticuloId'].value = '';
 document.forms[0].elements['txtArticuloDescripcion'].value = ''; 
 document.forms[0].action = "<%=strFormAction%>";
 document.forms[0].submit();
 return(true);
}

// Mandamos a ver las salidas del artículo
function cmdVerSalidas_onClick(){
 document.forms[0].action = "MercanciaConsultarSalidasProducto.aspx?strCmd=Consultar";
 document.forms[0].submit();
 return(true);
}

// impresión
function cmdImprimir_onClick(){

 document.forms[0].elements['cmdLimpiar'].style.display ="none";
 document.forms[0].elements['cmdVerSalidas'].style.display ="none";
 document.forms[0].elements['cmdImprimir'].style.display ="none";

 printContent();
 
 document.forms[0].elements['cmdLimpiar'].style.display="";
 document.forms[0].elements['cmdVerSalidas'].style.display="";
 document.forms[0].elements['cmdImprimir'].style.display=""; 
 return(true);
}

function cmdConsultar_onclick() {
  valida=true;

  if (document.forms[0].elements['txtArticuloId'].value == ""){
     alert("Capturar correctamente el número de artículo.");
     return(false);
  }

  if (Trim(document.forms[0].elements['txtArticuloId'].value)==" "){
     alert("Capturar correctamente el número de artículo.");
     return(false);
  }  
  
  if (isNaN(document.forms[0].elements['txtArticuloId'].value)){
     alert("Capturar correctamente el número de artículo.");
     return(false);
  }
  
  if (parseInt(document.forms[0].elements['txtArticuloId'].value) <= 0){
     alert("Capturar correctamente el número de artículo.");
     return(false);
  }
  
  document.forms[0].action="<%=strFormAction%>?strCmd=Consultar";  
  document.forms[0].submit();
  return(valida);
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaConsultarEntradasProducto" onSubmit="return frmMercanciaConsultarEntradasProducto_onsubmit()">
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
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Est&aacute; 
                en: <a href="Mercancia.aspx" class="txdmigaja">Mercanc&iacute;a</a>: 
                <a href="MercanciaEntradas.aspx" class="txdmigaja">Entradas</a>: 
                <a href="MercanciaEntradasTransferencia.aspx" class="txdmigaja">Transferencias 
                de otra sucursal</a>: Consultar entradas por producto</span></div></td>
            <td width="182" class="tdfechahora"><div id="ToPrintTxtFecha"> 
                <script language="javascript">strGetCustomDateTime()</script>
              </div></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Consultar entradas por producto</span><span class="txcontenido">Elija 
                      primero para qu&eacute; mes desea ver las entradas, y luego 
                      teclee el c&oacute;digo del producto deseado. Si no recuerda 
                      el c&oacute;digo, puede usar la funci&oacute;n de b&uacute;squeda. 
                      Para ejecutar la b&uacute;squeda, oprima &quot;Consultar&quot;.</span> 
                      <script language="JavaScript">crearDatosSucursal()</script>
                      <br>
                      <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle">Configuraci&oacute;n 
                      de la b&uacute;squeda</span> 
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td width="156" class="tdtittablas">Mes que desea consultar:</td>
                        <td colspan="3" class="tdconttablas"><input name="rdoMesConsulta" type="radio" id="rdoMesConsulta1" value="1" checked>
                          Actual&nbsp;&nbsp;&nbsp; <input type="radio" name="rdoMesConsulta" value="2" id="rdoMesConsulta2">
                          Anterior 
                          <input type="hidden" name="hdnArticuloId"> </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas">No. de artículo:</td>
                        <td width="129" valign="middle" class="tdpadleft5"> <input name="txtArticuloId" type="text" class="campotabla" id="txtArticuloId" size="16"
																	maxlength="16" onKeyDown="if (event.keyCode==13){document.forms[0].elements['imgLupa'].click();} if (event.keyCode==9){document.forms[0].elements['imgLupa'].click();}"> 
                          &nbsp; <a href="javascript:;" onClick="return cmdBuscarArticulo_onClick();"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="absmiddle"
																		id="imgLupa"></a></td>
                        <td width="283" colspan="2" class="tdconttablas"><input name="txtArticuloDescripcion" id="txtArticuloDescripcion" type="text" class="campotablaresultado"
																	size="35"> 
                        </td>
                      </tr>
                    </table>
                    <br> <input name="cmdRegresar" type="button" class="boton" id="cmdRegresar" value="Regresar"
														onClick="return cmdRegresar_onclick()"> 
                    &nbsp;&nbsp; <input name="cmdConsultar" type="button" class="boton" id="cmdConsultar" value="Consultar"
														onClick="return cmdConsultar_onclick()"> 
                    <br> <br> <script language="JavaScript">strRecordBrowserHTML()</script> 
                    <br> <br> </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda(strPaginaAyuda);</script> 
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
			</script>
</form>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
<iframe name="ifrOculto" width="0" height="0"></iframe>
</body>
</html>
