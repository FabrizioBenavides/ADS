<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConsultarSalidasProducto.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaConsultarSalidasProducto" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaConsultarSalidasProducto.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Griselda Gómez Ponce
    ' Version       : 1.0
    ' Last Modified : Lunes, 17 Noviembre, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
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
strPaginaAyuda = "";

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
function frmMercanciaConsultarSalidasProducto_onsubmit() {
  valida=true;
	return(valida);
}


function window_onLoad(){
   MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
   document.forms[0].action = "<%=strFormAction%>";
   
  // Mensajes que se envian al usuario.
   if ("<%=strMensaje%>" != ""){
	    window.alert("<%=strMensaje%>");
   }
   
  //Articulo consultado 
   if ("<%=intArticuloId%>"!=""){   
      document.forms[0].hdnArticuloId.value="<%=intArticuloId%>";
      document.forms[0].txtArticuloId.value="<%=intArticuloId%>";
      document.forms[0].txtArticuloDescripcion.value="<%=strArticuloDescripcion%>";
   }
   
     //Selecciona el mes consultado
   if ("<%=rdoMesConsulta%>" == "1") {
     document.forms[0].elements['rdoMesConsultaActual'].checked = true;     
   }
   if ("<%=rdoMesConsulta%>" == "2") {
     document.forms[0].elements['rdoMesConsultaAnterior'].checked = true;     
   }
  
}

function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

function strbtnConsultar() {
	document.write("<%=strbtnConsultar%>");
	return(true);
}


function cmdBuscarArticulo_onClick(){
	if (document.forms[0].elements['txtArticuloId'].value!=""){
      if (!isNaN(document.forms[0].elements['txtArticuloId'].value)) {
           document.forms[0].action="<%=strFormAction%>?strCmd=BuscarArticulo";
           document.forms[0].submit();
			return(false);
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


function cmdConsultar_onclick() {
   if (document.forms[0].elements['rdoMesConsultaActual'].checked == false && document.forms[0].elements['rdoMesConsultaAnterior'].checked == false) {
       alert("Seleccionar mes de consulta");
       return(false);
   }
   
   if (document.forms[0].elements['txtArticuloId'].value==""){
         window.alert("Capturar código o descripción del artículo");
         document.forms[0].elements('txtArticuloId').focus();
         return(false);
   }

   if (document.forms[0].elements['txtArticuloId'].value<0){
         window.alert("Código artículo inválido");
         document.forms[0].elements('txtArticuloId').focus();
         return(false);
   }
              
   document.forms[0].action="<%=strFormAction%>?strCmd=Consultar";
   document.forms[0].submit();
   return(true);
}

function cmdRegresar_onclick() {
   //Redireccionamos a la página de salidas
     window.location  ="MercanciaSalidasTransferenciasOtraSucursal.aspx";
}

// Redireccionamos hacia página de entradas
function cmdVerEntradas_onclick() {
 document.forms[0].action = "MercanciaConsultarEntradasProducto.aspx?strCmd=Consultar";
 document.forms[0].submit();
 return(true);
}

function cmdImprimir_onclick() {
   //Imprimimos los contenidos de la página
   
    var1 = document.all.HtmContenido1.innerHTML;
    var2 = document.all.HtmContenido2.innerHTML;
    var3 = document.all.HtmContenido3.innerHTML;
    
    document.all.ToPrintHtmContenido.innerHTML=var1+var2+var3;
    printContent();
    document.all.ToPrintHtmContenido.innerHTML="";
    return(true);
}

function txtArticuloId_onKeyDown() { 
	if(event.keyCode==13){ txtArticuloId_onblur() }
	if(event.keyCode==9) { txtArticuloId_onblur() }
}

function txtArticuloId_onblur() {

  if (Trim(document.forms[0].elements['txtArticuloId'].value)=='') {
   	   document.forms[0].txtArticuloId.value = '';
	   document.forms[0].hdnArticuloId.value = '';
       document.forms[0].txtArticuloDescripcion.value = '';
	   return;
   }
   
   if(document.forms[0].elements['txtArticuloId'].value != document.forms[0].elements['hdnArticuloId'].value) {
      cmdBuscarArticulo_onClick();      
   }

}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" onLoad="return window_onLoad()" marginheight="0" marginwidth="0">
<form name="frmMercanciaConsultarSalidasProducto" onSubmit="return frmMercanciaConsultarSalidasProducto_onsubmit()" action="about:blank" method="post">
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
            <td class="tdmigaja" width="583"> <div id="ToPrintTxtMigaja"> <span class="txdmigaja">Está 
                en : </span> <a class="txdmigaja" href="Mercancia.aspx">Mercancía</a><span class="txdmigaja"> 
                : <a class="txdmigaja" href="MercanciaSalidas.aspx"> Salidas</a> 
                : </span><span class="txdmigaja"> <a class="txdmigaja" href="MercanciaSalidasTransferenciasOtraSucursal.aspx"> 
                Transferencias a otra sucursal</a> : </span><span class="txdmigaja"> 
                </span><span class="txdmigaja"></span><span class="txdmigaja"> 
                </span><span class="txdmigaja">Consultar salidas por producto</span></div></td>
            <td class="tdfechahora" width="182"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td valign="top" width="583"> <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtablacont" colspan="3"> <p><span class="txtitulo">Consultar 
                      salidas por producto</span><span class="txcontenido">Elija 
                      primero para qué mes desea ver las salidas, y luego teclee 
                      el código del producto deseado. Si no recuerda el código, 
                      puede usar la función de búsqueda. Para ejecutar la búsqueda, 
                      oprima "Consultar".</span><br>
                      <span class="txsubtitulo"> <img height="11" src="../static/images/bullet_subtitulos.gif" width="17"> 
                      Configuración de la búsqueda</span> </p>
                    <script language="JavaScript">crearDatosSucursal()</script> 
                    <br> <table cellspacing="0" cellpadding="0" width="100%" border="0">
                      <tr> 
                        <td class="tdtittablas" width="163">Mes que desea consultar:</td>
                        <td class="tdconttablas" width="410"> <input type="radio" value="1" name="rdoMesConsulta" id="rdoMesConsultaActual">
                          Actual&nbsp;&nbsp;&nbsp; <input type="radio" value="2" name="rdoMesConsulta" id="rdoMesConsultaAnterior">
                          Anterior</td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas">Código de producto:</td>
                        <td class="tdpadleft5" valign="middle"> <input name="hdnArticuloId" type="hidden" class="campotabla" size="18"> 
                          <input name="txtArticuloId" class="campotabla" type="text" size="14" onBlur="return txtArticuloId_onblur()" onKeyDown="txtArticuloId_onKeyDown()"> 
                          &nbsp;&nbsp; <a href="javascript:;" onClick="return cmdBuscarArticulo_onClick();"> 
                          <img height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"> 
                          </a></td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas">&nbsp;</td>
                        <td class="tdconttablasrojo" valign="middle" width="350" colspan="3"> 
                          <input class="campotablaresultado" type="text" size="50" name="txtArticuloDescripcion" readonly> 
                        </td>
                      </tr>
                    </table>
                    <script language="javascript">strbtnConsultar()</script> </td>
                </tr>
                <tr> 
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                </tr>
                <script language="javascript">strRecordBrowserHTML()</script>
                <tr> 
                  <td colspan="3"><br> </td>
                </tr>
              </table></td>
            <td class="tdcolumnader" valign="top" width="182" rowspan="2">&nbsp; </td>
          </tr>
          <tr> 
            <td class="tdbottom" colspan="2"><script language="JavaScript">crearTablaFooter()</script> 
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
<div id="ToPrintHtmContenido"></div>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"> 
</iframe>
</body>
</html>
