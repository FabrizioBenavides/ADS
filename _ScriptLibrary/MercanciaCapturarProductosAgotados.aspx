<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaCapturarProductosAgotados.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaCapturarProductosAgotados" codePage="28592"%>
<%
    '====================================================================
    ' Page          : MercanciaCapturarProductosAgotados.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para capturar productos agotados
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Raúl Corral González
    ' Version       : 1.0
    ' Last Modified : Monday, November 17, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
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
function strGetCustomDateTimeDMY(blnRegresarString){
	if(blnRegresarString){
	  return("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy") %>");
	}
	else {
	  document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy") %>");
	  return(true);
	}
}
function strGetCustomDateTimeNombreDia() {
	document.write("<%=clsCommons.strNombreDia(cdate(clsCommons.strGetCustomDateTime("MM/dd/yyyy"))) %>");
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

function strHrefMigaja1(){
	document.location.href='Mercancia.aspx';
}
function strHrefMigaja2(){
	document.location.href='CCRedirectorPOSAdmin.aspx?strPageName=MercanciaInventarios.aspx';
}
function strHrefMigaja3(){
	document.location.href='CCRedirectorPOSAdmin.aspx?strPageName=MercanciaInventariosProductosAgotados.aspx';
}
function strHrefMigaja4(){
	document.location.href='';
}
function cmdRegresar_onclick() {
	strHrefMigaja3();
}

function strTituloMigaja1(){
	document.write("Mercancía");
}
function strTituloMigaja2(){
	document.write("Inventarios");
}
function strTituloMigaja3(){
	document.write("Productos agotados");
}
function strTituloPrincipalDePagina() {
	document.write("Capturar productos agotados");
}
function strDescripcionPrincipalDePagina() { 
	document.write("Capture el código de un producto agotado en su sucursal y una vez seguro de que es el deseado, agréguelo al reporte. Repita el proceso las veces que sea necesario.");
}

function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
	
	intInventarioAgotadoId = "<%=Request("intInventarioAgotadoId")%>";
	document.forms[0].elements['txtIntArticuloId'].focus();
		
	var strMensaje = "<%=strMensaje%>";
	if(strMensaje != ""){
		alert(strMensaje);
	}
}

function frmMercanciaCapturarProductosAgotados_onsubmit() {
	document.forms(0).action="MercanciaCapturarProductosAgotados.aspx"
	return(true); 
}

// Buscar articulo 
function objLupa1Articulo_onClick(){ 
	if (document.forms(0).elements('txtIntArticuloId').value!="")
	    {
         if (!isNaN(document.forms(0).elements('txtIntArticuloId').value))
             {
			   if (document.forms(0).elements('txtIntArticuloId').value != '0')
			      { 
			       document.forms(0).action = "<%=strFormAction%>?strCmd=BuscarArticulo";
			       document.forms(0).target="ifrOculto";
			       document.forms(0).submit();
				   document.forms(0).target='';
			       return(true);
     		      }
			    else 
			        { 
				     //el valor es cero  		     
				     document.forms(0).elements('txtStrArticuloDescripcion').value=''; 
				     strEvalJs="";
				     strParametros='';
					 strParametros=strParametros + '?strArticuloIdNombre=' + document.forms(0).elements('txtIntArticuloId').value;
				     strParametros=strParametros + '&strArticuloNombreId=txtStrArticuloDescripcion' 
				     strParametros=strParametros + '&strArticulo=txtIntArticuloId' 
				     Pop('PopArticulo.aspx'+strParametros+'&strEvalJs='+strEvalJs,500,540);
			       }
			    return(false);
	         }
	      else{ 
		        
				document.forms(0).elements('txtStrArticuloDescripcion').value=''; 
				strEvalJs="";
				strParametros='';
				strParametros=strParametros + '?strArticuloIdNombre=' + document.forms(0).elements('txtIntArticuloId').value;
				strParametros=strParametros + '&strArticuloNombreId=txtStrArticuloDescripcion' 
				strParametros=strParametros + '&strArticulo=txtIntArticuloId' 
				Pop('PopArticulo.aspx'+strParametros+'&strEvalJs='+strEvalJs,500,540);
	          }
	       }
	else{
		alert("Teclear número de artículo o descripción");
		document.forms(0).elements('txtIntArticuloId').focus();
        return(false); 
	    }
}

// Mandar ventana de consulta
function Pop(url, width, height) {
    var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
	return(false);
}
function cmdAgregarArticulo_onclick() {
	valida=true;
	if (valida){ valida=blnValidarCampo(document.forms(0).elements("txtIntArticuloId"),true,"Código de producto agotado",cintTipoCampoEntero,14,1,""); } 
	if (valida){
	  document.forms(0).action = "<%=strFormAction%>?strCmd=AgregarArticulo";	  
	  document.forms(0).target="ifrOculto";
	  document.forms(0).submit();
	  document.forms(0).target="";	  
	}
}
function fnBorrarPartida(intArticuloId){
	document.forms(0).action = "<%=strFormAction%>?strCmd=BorrarArticulo&txtIntArticuloId=" + intArticuloId;
	document.forms(0).target="ifrOculto";
	document.forms(0).submit();
	document.forms(0).target="";
}

function cmdRegistrar_onclick() {
	strParametros = '?';
	strParametros = strParametros + 'intFolioInventarioAgotadoId=' + document.forms(0).elements('intInventarioAgotadoId').value;
	document.location.href='MercanciaDetalleProductosAgotados.aspx'+ strParametros;
}

function strMostrarFolio(objInventarioId){     
     
     if (parseInt(objInventarioId) > 0 ){ 
     	  document.all.divFolio.innerHTML ="<table><tr><td class='tdconttablas'>Folio: " + objInventarioId + "</td></tr></table>"
     } 	  

}

function strRecordBrowserHTML(strRecordBrowser, intInventarioAgotadoId) {
 
  if (parseInt(intInventarioAgotadoId) > 0){
      intCuenta = strRecordBrowser.length;
      document.all.divDetalle.innerHTML= strRecordBrowser;
      document.forms[0].elements['intInventarioAgotadoId'].value= intInventarioAgotadoId;      
      strMostrarFolio(intInventarioAgotadoId);
      strMostrarBotonesHTML(intInventarioAgotadoId);
      document.forms[0].elements['txtIntArticuloId'].value='';
      document.forms[0].elements['txtStrArticuloDescripcion'].value='';
      document.forms[0].elements['txtIntArticuloId'].focus();      
   }
   else
   {
    document.all.divDetalle.innerHTML="<br>";
   }

}

function cmdImprimir_onclick(){
 printContent();
 return(true);
}

function strMostrarBotonesHTML(intInventarioAgotadoId){  
  
  if (parseInt(intInventarioAgotadoId) > 0){
          strBotones = '<input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()">';
          strBotones = strBotones + '&nbsp;&nbsp;<input name="cmdRegistrar" type="button" value="Registrar reporte" style="DISPLAY:none" onClick="return cmdRegistrar_onclick()" class="boton">&nbsp;&nbsp;';
          strBotones = strBotones + '<input name="cmdImprimir" type="Button" class="boton" value="Imprimir la lista" onClick="return cmdImprimir_onclick()">';
          
          document.all.divBotones.innerHTML = strBotones;
   }
}


//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaCapturarProductosAgotados" onSubmit="return frmMercanciaCapturarProductosAgotados_onsubmit()">
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
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja"> 
                Está en : </span> <a href="javascript:strHrefMigaja1();" class="txdmigaja"> 
                <script language="javascript">strTituloMigaja1()</script>
                </a><span class="txdmigaja"> : <a href="javascript:strHrefMigaja2();" class="txdmigaja"> 
                <script language="javascript">strTituloMigaja2()</script>
                </a> : <a href="javascript:strHrefMigaja3();" class="txdmigaja"> 
                <script language="javascript">strTituloMigaja3()</script>
                </a> : 
                <script language="javascript">strTituloPrincipalDePagina()</script>
                </span></div></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"> <span class="txtitulo"> 
              <script    language="javascript">strTituloPrincipalDePagina()</script>
              </span> <span class="txcontenido"> 
              <script language="javascript">strDescripcionPrincipalDePagina()</script>
              <input type="hidden" name="intInventarioAgotadoId">
              <input type="hidden" name="hdnArticuloAnteriorId">
              <br>
              </span> <script language="JavaScript">crearDatosSucursal()</script> 
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="224" class="tdtittablas"><nobr>Código de producto 
                    agotado:</nobr></td>
                  <td  valign="middle" class="tdpadleft5" nowrap><input type="hidden" name="hdnPrecioNormalConImpuesto"> 
                    <input  name="txtIntArticuloId" type="text" class="campotabla" size="18" maxlength="15" onKeyDown="if(event.keyCode==13){document.forms[0].elements['objLupa'].click();} if(event.keyCode==9){document.forms[0].elements['objLupa'].click();}"> 
                    &nbsp; <a href="javascript:;" id="objLupa1" onClick="return objLupa1Articulo_onClick();"><img src="../static/images/icono_lupa.gif" width="17" height="17" align="absMiddle" border="0" id="objLupa"></a> 
                    <span class="txconttablasrojo"> 
                    <input	name="txtStrArticuloDescripcion" class="campotablaresultado" size="40" maxlength="40" border="0" id="txtStrArticuloDescripcion" readonly>
                    </span></td>
                  <td width="305" class="tdconttablas"></td>
                </tr>
              </table>
              <br> <input name="cmdAgregarArticulo" type="button" class="boton" value="Agregar al reporte" onClick="return cmdAgregarArticulo_onclick()"> 
              <br> <br> <div id="ToPrintHtmContenido"> 
                <div id="divFolio"> 
                  <script language="javascript">strMostrarFolio()</script>
                </div>
                <div id="divDetalle"> 
                  <script language="javascript">strRecordBrowserHTML()</script>
                </div>
                <br>
              </div>
              <div id="divBotones"> 
                <script language="JavaScript">strMostrarBotonesHTML()</script>
              </div>
              <br> <br> 
              <!-- </td>
              </tr>
            </table> -->
            </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"><script language="javascript">strGeneraTablaAyuda('');</script></td>
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
	//-->
</script>
</form>
<iframe name="ifrOculto" height="0" width="0" src=""></iframe>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</html>
