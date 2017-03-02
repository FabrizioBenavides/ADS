<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaCapturarMaximoSugerido.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaCapturarMaximoSugerido" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaCapturarMaximoSugerido.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para sugerir maximos
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Raúl Corral González
    ' Version       : 1.0
    ' Last Modified : Tuesday, November 18, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";

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

function strHrefMigaja1(){
	document.location.href='Mercancia.aspx';
}
function strHrefMigaja2(){
	document.location.href='MercanciaInventarios.aspx';
}
function strHrefMigaja3(){
	document.location.href='MercanciaInventariosMaximosDeProductos.aspx';
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
	document.write("Máximos de productos");
}
function strTituloPrincipalDePagina() {
	document.write("Capturar sugerencias de máximos");
}
function strDescripcionPrincipalDePagina() {  
	document.write("Para capturar una sugerencia de máximo de un producto, introduzca la clave del producto y oprima \42Consultar máximo\42. Capture luego el máximo de producto sugerido y oprima \42Sugerir máximo\42.");
}
function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
	
	var intInventarioSugeridoId=<%=intInventarioSugeridoId%>;
	document.forms(0).elements('intInventarioSugeridoId').value='<%=intInventarioSugeridoId%>';
	
	if(intInventarioSugeridoId>0){
		document.frmMercanciaCapturarMaximoSugerido.cmdRegresar.style.display="";
		document.frmMercanciaCapturarMaximoSugerido.cmdRegistrar.style.display="none";
	}
	else{
		document.frmMercanciaCapturarMaximoSugerido.cmdRegresar.style.display="none";
		document.frmMercanciaCapturarMaximoSugerido.cmdRegistrar.style.display="none";
	}
	
	document.forms(0).elements('txtIntArticuloId').value='<%=strtxtIntArticuloId%>';
	document.forms(0).elements('txtStrArticuloDescripcion').value='<%=strTxtStrArticuloDescripcion%>';
	
	document.forms(0).elements('txtIntArticuloId').select();
	
	document.forms(0).elements('hdnActual').value="<%=strHdnActual%>";
	document.forms(0).elements('hdnTresMeses').value="<%=strHdnTresMeses%>";
	document.forms(0).elements('hdnTeorico').value="<%=strHdnTeorico%>";
	document.forms(0).elements('hdnUnMes').value="<%=strHdnUnMes%>";
	document.forms(0).elements('hdnVigencia').value="<%=strHdnVigencia%>";
	document.forms(0).elements('hdnUnaSemana').value="<%=strHdnUnaSemana%>";
	document.forms(0).elements('HdnClaveVigencia').value = "<%=strHdnClaveVigencia%>"
	
	
	document.forms[0].elements['txtIntArticuloId'].focus();
	
	var strMensaje = "<%=strMensaje%>";
	if(strMensaje != ""){
		alert(strMensaje);
	}
}

function frmMercanciaCapturarMaximoSugerido_onsubmit() {
	document.forms(0).action="MercanciaCapturarMaximoSugerido.aspx"
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
				     strEvalJs="opener.fnLimpiaInventarioVentas();";
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
				strEvalJs="opener.fnLimpiaInventarioVentas();";
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

function fnBorrarPartida(intArticuloId){
	document.forms(0).elements('txtIntArticuloId').value=intArticuloId;
	document.forms(0).action = "<%=strFormAction%>?strCmd=BorrarArticulo";
	document.forms(0).target="";
	document.forms(0).submit();
}
function cmdRegistrar_onclick() {
	strParametros = '?';
	strParametros = strParametros + 'intInventarioSugeridoFolioId=' + document.forms(0).elements('intInventarioSugeridoId').value;
	document.location.href='MercanciaDetalleMaximosSugerido.aspx'+ strParametros;
}
function strRecordBrowserHTML() {
	document.write("<%=strGeneraTablaHTML%>");
}

function strHdnActual(){
	document.write("<%=strHdnActual%>");
}

function strHdnTresMeses(){
	document.write("<%=strHdnTresMeses%>");
}

function strHdnTeorico(){
	document.write("<%=strHdnTeorico%>");
}

function strHdnUnMes(){
	document.write("<%=strHdnUnMes%>");
}

function strHdnVigencia(){
	document.write("<%=strHdnVigencia%>");
}

function strHdnUnaSemana(){
	document.write("<%=strHdnUnaSemana%>");
}

function strHdnClaveVigencia(){
	document.write("<%=strHdnClaveVigencia%>");
}

function cmdConsultarMaximo_onclick() {
	valida=true;

	if (valida){ valida=blnValidarCampo(document.forms(0).elements("txtIntArticuloId"),true,"Código",cintTipoCampoEntero,14,1,""); } 

	if (valida){
	   document.forms(0).action = "<%=strFormAction%>?strCmd=ConsultarMaximos";
	   document.forms(0).target='';
	   document.forms(0).submit();
	}
}

function cmdMaximoSugerido_onclick() {
	valida=true;
	if (valida){ valida=blnValidarCampo(document.forms(0).elements("txtIntArticuloId"),true,"Código",cintTipoCampoEntero,14,1,""); } 
	if (valida){ valida=blnValidarCampo(document.forms(0).elements("txtMaximoSugerido"),true,"Máximo sugerido",cintTipoCampoEntero,14,1,""); } 
	if (valida){ 
		intMaximoSugerido = document.forms(0).elements("txtMaximoSugerido").value * 1;
		if(intMaximoSugerido<=0){
			valida=false;
			alert('El campo Máximo sugerido, debe ser mayor a cero.')
			document.forms(0).elements("txtMaximoSugerido").select();
		}
	}
	if (valida){
	  document.forms(0).action = "<%=strFormAction%>?strCmd=AgregarArticulo";
	  document.forms(0).target="";
	  document.forms(0).submit();
	}
}
function fnLimpiaInventarioVentas(){
	document.all.divActual.innerText='';
    document.all.divTresMeses.innerText='';
    document.all.divTeorico.innerText='';
    document.all.divUnMes.innerText='';
    document.all.divVigencia.innerText='';
    document.all.divUnaSemana.innerText='';

    document.forms(0).elements('hdnActual').value='';
    document.forms(0).elements('hdnTresMeses').value='';
    document.forms(0).elements('hdnTeorico').value='';
    document.forms(0).elements('hdnUnMes').value='';
    document.forms(0).elements('hdnVigencia').value='';
    document.forms(0).elements('hdnUnaSemana').value='';
}

function strMostrarFolio(){
	<% if intInventarioSugeridoId>0 then %>
	document.write("<table><tr><td class='tdconttablas'>Folio: <%=intInventarioSugeridoId%></td></tr></table>")
	<% end if %>
}
//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaCapturarMaximoSugerido" onSubmit="return frmMercanciaCapturarMaximoSugerido_onsubmit()">
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
            <td width="583" class="tdmigaja"> <div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en : </span> <a href="javascript:strHrefMigaja1();" class="txdmigaja"> 
                <script language="javascript">strTituloMigaja1()</script>
                </a> <span class="txdmigaja">: <a href="javascript:strHrefMigaja2();" class="txdmigaja"> 
                <script language="javascript">strTituloMigaja2()</script>
                </a> <span class="txdmigaja">: </span> <a href="javascript:strHrefMigaja3();" class="txdmigaja"> 
                <script language="javascript">strTituloMigaja3()</script>
                </a></span> <span class="txdmigaja">: 
                <script language="javascript">strTituloPrincipalDePagina()</script>
                </span></div></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"> <span class="txtitulo"> 
              <script language="javascript">strTituloPrincipalDePagina()</script>
              </span><span class="txcontenido"> 
              <script language="javascript">strDescripcionPrincipalDePagina()
          </script>
              </span> <script language="JavaScript">crearDatosSucursal()</script> 
              <br> <span class="txsubtitulo"> <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Máximo 
              de producto</span> <div id="ToPrintHtmContenido"> 
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr> 
                    <td class="tdtittablas"><nobr>Código:</nobr></td>
                    <td valign="middle" class="tdpadleft5" colspan="2" nowrap> 
                      <input type="hidden" name="hdnPrecioNormalConImpuesto"> 
                      <input name="txtIntArticuloId" type="text" class="campotabla" size="18" maxlength="15" onKeyDown="if(event.keyCode==13){document.forms[0].elements['objLupa'].click()} if(event.keyCode==9){document.forms[0].elements['objLupa'].click()}"> 
                      &nbsp; <a href="javascript:;" id="objLupa1" onClick="return objLupa1Articulo_onClick();"> 
                      <img src="../static/images/icono_lupa.gif" width="17" height="17" align="absMiddle" border="0" id="objLupa"></a> 
                      <span class="txconttablasrojo"> 
                      <input name="txtStrArticuloDescripcion" type="text" class="campotablaresultado" size="40" border="0" id="txtStrArticuloDescripcion" readonly>
                      </span></td>
                  </tr>
                  <tr> 
                    <td colspan="2" class="tdtittablas"> <input name="cmdConsultarMaximo" type="button" class="boton" value="Consultar máximo" onClick="return cmdConsultarMaximo_onclick()" style="DISPLAY:none"> 
                    </td>
                    <td width="255" rowspan="5" valign="middle"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                          <td colspan="2" class="tdtittablas3">Inventario</td>
                          <td width="21" class="tdtittablas3">&nbsp;</td>
                          <td width="95" class="tdtittablas3">Ventas</td>
                          <td width="56" class="tdtittablas3">&nbsp;</td>
                        </tr>
                        <tr> 
                          <td width="64" class="tdconttablasnopad" nowrap>Maximo</td>
                          <td width="72" class="tdconttablas" nowrap> <div id="divActual"> 
                              <script language="javascript">strHdnActual()</script>
                            </div></td>
                          <td class="tdconttablasnopad" nowrap>&nbsp;</td>
                          <td class="tdconttablasnopad" nowrap>Tres meses:</td>
                          <td class="tdconttablas" nowrap> <div id="divTresMeses"> 
                              <script language="javascript">strHdnTresMeses()</script>
                            </div></td>
                        </tr>
                        <tr> 
                          <td class="tdconttablasnopad" nowrap>Teórico</td>
                          <td class="tdconttablas" nowrap> <div id="divTeorico"> 
                              <script language="javascript">strHdnTeorico()</script>
                            </div></td>
                          <td class="tdtittablas3" nowrap>&nbsp;</td>
                          <td class="tdconttablasnopad" nowrap>Un mes:</td>
                          <td class="tdconttablas" nowrap> <div id="divUnMes"> 
                              <script language="javascript">strHdnUnMes()</script>
                            </div></td>
                        </tr>
                        <tr> 
                          <td class="tdconttablasnopad" nowrap>Días Inv.</td>
                          <td class="tdconttablas" nowrap> <div id="divVigencia"> 
                              <script language="javascript">strHdnVigencia()</script>
                            </div></td>
                          <td class="tdtittablas3" nowrap>&nbsp;</td>
                          <td class="tdconttablasnopad" nowrap>Una semana:</td>
                          <td class="tdconttablas" nowrap> <div id="divUnaSemana"> 
                              <script language="javascript">strHdnUnaSemana()</script>
                            </div></td>
                        </tr>
                        <tr> 
                          <td class="tdconttablasnopad" nowrap>Vigencia.</td>
                          <td class="tdconttablas" nowrap> <div id="divClaveVigencia"> 
                              <script language="javascript">strHdnClaveVigencia()</script>
                            </div></td>
                          <td class="tdtittablas3" nowrap>&nbsp;</td>
                          <td class="tdconttablasnopad" nowrap>&nbsp;</td>
                          <td class="tdconttablas" nowrap>&nbsp;</td>
                        </tr>
                      </table></td>
                  </tr>
                  <tr> 
                    <td colspan="2" class="tdtittablas">&nbsp;</td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Máximo sugerido:</td>
                    <td class="tdpadleft5"> <input name="txtMaximoSugerido" type="text" class="campotabla" size="16" maxlength="14" onKeyDown="if (event.keyCode==13){document.forms[0].elements['cmdMaximoSugerido'].click()} if (event.keyCode==9){document.forms[0].elements['cmdMaximoSugerido'].click()}"> 
                    </td>
                  </tr>
                  <tr> 
                    <td colspan="2" class="tdtittablas"> <input name="cmdMaximoSugerido" type="button" class="boton" value="Sugerir máximo" onClick="return cmdMaximoSugerido_onclick()"> 
                    </td>
                  </tr>
                  <tr> 
                    <td colspan="2" class="tdtittablas"></td>
                  </tr>
                </table>
                <script language="javascript">strMostrarFolio()</script>
                <script language="javascript">strRecordBrowserHTML()</script>
                <br>
                <input name="cmdRegresar" type="button" class="boton" value="Aceptar" style="DISPLAY:none" onClick="return cmdRegresar_onclick()">
                &nbsp;&nbsp;&nbsp; 
                <input name="cmdRegistrar" type="button" value="Registrar sugerencia" style="DISPLAY:none" onClick="return cmdRegistrar_onclick()" class="boton">
              </div>
              <br> <br> <br> </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda('');</script> 
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <input type="hidden" name="intInventarioSugeridoId">
  <input type="hidden" name="hdnActual">
  <input type="hidden" name="hdnTresMeses">
  <input type="hidden" name="hdnTeorico">
  <input type="hidden" name="hdnUnMes">
  <input type="hidden" name="hdnVigencia">
  <input type="hidden" name="hdnUnaSemana">
  <input type="hidden" name="hdnClaveVigencia">
</form>
<script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
</script>
<iframe name="ifrOculto" height="0" width="0" src></iframe>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"> 
</iframe>
</body>
</html>
