<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConfirmarEnvioProductos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaConfirmarEnvioProductos" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaConfirmarEnvioProductos.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Raúl Corral González
    ' Version       : 1.0
    ' Last Modified : Friday, October 31, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<meta name="description" content="Javascript Menu">
<meta name="keywords" content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
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
function frmMercanciaConfirmarEnvioProductos_onsubmit() {
  valida=true;
  
  
  if (valida){ valida=blnValidarCifraDeControl(); }
  if (valida){ valida=blnValidarCampo(document.forms(0).elements('txtFechaDeConfirmacion'),true,"Fecha de confirmación",cintTipoCampoFecha,10,10,""); } 
  
  if (valida){
	TotalDePartidas = document.forms[0].elements['hdnTotalDePartidas'].value;
	TotalDePartidas = TotalDePartidas * 1
	//validar cada partida
	for (i = 1;  i < (TotalDePartidas+1);  i++) {
		valida=ValidarDetalle(document.forms(0).elements('txtConfirmada_'+i))
		
	   if(valida){
           if (document.forms(0).elements('txtConfirmada_'+i).value==""){
              alert("Teclear una cantidad confirmada");
              valida=false;
           } 
      }
      
	  if(valida==false){
			return(false);
			break;
		}
	}
  }
  
  if (valida){
  document.forms(0).action="<%=strFormAction%>?intTransferenciaId=<%=intTransferenciaId%>";
  }
  return(valida);
}
function strHrefMigaja1(){
	document.location.href='Mercancia.aspx';
}
function strHrefMigaja2(){
	document.location.href='CCRedirectorPOSAdmin.aspx?strPageName=MercanciaSalidas.aspx';
}
function strHrefMigaja3(){
	document.location.href='MercanciaProcesarEnviosAutomaticos.aspx';
}
function strHrefMigaja4(){
	document.location.href='#';
}
function strTituloMigaja1(){
	document.write("Mercancía");
}
function strTituloMigaja2(){
	document.write("Salidas");
}
function strTituloMigaja3(){
	document.write("Transferencias a otra sucursal");
}
function cmdOtraConsulta_onclick() {
	strHrefMigaja4();
}
function cmdImprimir_onclick() {
	if (window.print) {
        document.ifrPageToPrint.document.all.ToPrintTxtMigaja.innerHTML=document.all.ToPrintTxtMigaja.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtFecha.innerHTML=document.all.ToPrintTxtFecha.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtSucursal.innerHTML=document.all.ToPrintTxtSucursal.innerText;
        document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML=document.all.ToPrintHtmContenido.innerHTML;
        document.ifrPageToPrint.document.all.divFirmasUp.style.display='';
        document.ifrPageToPrint.focus();
        window.print();        
    } else {
        alert("Tu navegador no soporta la función: Print.")
    }
}
function strTituloPrincipalDePagina() {
	document.write("Confirmar envío de productos");
}
function strDescripcionPrincipalDePagina() {
	document.write("Confirme el envío de esta mercancía revisando las cantidades. Si no puede surtirlas, edite las cantidades antes de confirmar el envío.");
}
function strRecordBrowserHTML() {
	document.write("<%=strGeneraTablaHTML%>");
}
function strHdnFolioEnvio() {
	document.write("<%=strHdnFolioEnvio%>");
}
function strHdnNumeroDeOrden() {
	document.write("<%=strHdnNumeroDeOrden%>");
}
function strHdnFechaDeOrden() {
	document.write("<%=strHdnFechaDeOrden%>");
}
function strHdnMotivoDeTransferencia() {
	document.write("<%=strHdnMotivoDeTransferencia%>");
}
function strHdnSucursalQueRecibe() {
	document.write("<%=strHdnSucursalQueRecibe%>");
}

function strHdnCompaniaSucursalDestino() {
    document.write("<%=strHdnCompaniaSucursalDestino%>");
    return(true);
} 

function ValidarDetalle(objControl) {
	valida=true;
	if (valida){ valida=blnValidarCampo(objControl,false,"Confirmada",cintTipoCampoEntero,10,1,""); } 
  
   if(valida){
       if (parseInt(objControl.value) < 0){
           alert("Las cantidades confirmadas deben ser mayores o iguales a cero");
           valida=false;
        } 
   }     
	
	return(valida);
}

function txtCifraDeContro_onblur() {
    valida=true;
	return(valida);
}

function blnValidarCifraDeControl(){
	valida=true;
	if (valida){ valida=blnValidarCampo(document.forms(0).elements('txtCifraDeContro'),true,"Cifra de control",cintTipoCampoEntero,10,1,""); } 
	if (valida){
		TotalDePartidas = document.forms[0].elements['hdnTotalDePartidas'].value;
		TotalDePartidas = TotalDePartidas * 1
		
		//La suma de todas las partidas debe ser igual a la cifra de control
		intTotal = 0;
		for (i = 1;  i < (TotalDePartidas+1);  i++) {
			intTotal = (intTotal*1) + (document.forms(0).elements('txtConfirmada_'+i).value * 1);
		}
		
		intTxtCifraDeContro = (document.forms(0).elements('txtCifraDeContro').value) * 1;
		if(intTxtCifraDeContro==intTotal){
			valida=true;
		}
		else {
			alert('La cifra de control no corresponde al total de artículos por enviar.');
			document.forms(0).elements('txtCifraDeContro').select();
			valida=false;
			return(valida);
		}
	}
	return(valida);
}
function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
	document.forms[0].elements['txtFechaDeConfirmacion'].value='<%=strTxtFechaDeConfirmacion%>';
	document.forms[0].elements['txtFechaDeConfirmacion'].focus();
	
	document.forms[0].elements['hdnFolioEnvio'].value='<%=strHdnFolioEnvio%>';
	document.forms[0].elements['hdnNumeroDeOrden'].value='<%=strHdnNumeroDeOrden%>';
	document.forms[0].elements['hdnFechaDeOrden'].value='<%=strHdnFechaDeOrden%>';
	document.forms[0].elements['hdnMotivoDeTransferencia'].value='<%=strHdnMotivoDeTransferencia%>';
	document.forms[0].elements['hdnSucursalQueRecibe'].value='<%=strHdnSucursalQueRecibe%>';
	document.forms[0].elements['hdnCompaniaSucursalDestino'].value='<%=strHdnCompaniaSucursalDestino%>';
	
	var strMensaje = "<%=strMensaje%>";
	if(strMensaje != ""){
		alert(strMensaje);
	}
	
	var strAccionOnLoad = "<%=intAccionOnLoad%>"
	if(strAccionOnLoad=="1"){
		document.forms[0].elements['cmdConfirmar'].disabled=true;
		document.forms[0].elements['cmdConfirmar'].title='Los productos ya fueron confirmados.';
		document.forms[0].elements['cmdCancelar'].disabled=true;
		document.forms[0].elements['cmdCancelar'].title='Los productos ya fueron confirmados.';
		document.forms[0].elements['txtCifraDeContro'].disabled=true;
		document.forms[0].elements['txtCifraDeContro'].title='Los productos ya fueron confirmados.';
		document.forms[0].elements['txtFechaDeConfirmacion'].disabled=true;
	}
	
	return(true);
}
function cmdOtroEnvio_onclick() {
	strHrefMigaja3();
}
function DoObjCalendar1(){
	if(document.forms(0).elements('txtFechaDeConfirmacion').disabled==false){
		if(document.forms(0).elements('txtFechaDeConfirmacion').readOnly==false){
			objCalendar1.popup();
		}
	}
}
function cmdCancelar_onclick() {
	intTransferenciaId = "<%=intTransferenciaId%>";
	intNumeroOrden = document.forms[0].elements['hdnNumeroDeOrden'].value;
	strSucursalEsperaEnvio = document.forms[0].elements['hdnSucursalQueRecibe'].value;
	intSucursalEsperaEnvio = "<%=strIntSucursalQueRecibe%>";
	strFechaOrden = document.forms[0].elements['hdnFechaDeOrden'].value;
	strParametros = "";
	strParametros = strParametros + "?intTransferenciaId="     +intTransferenciaId;
	strParametros = strParametros + "&intNumeroOrden="         +intNumeroOrden;
	strParametros = strParametros + "&strFechaOrden="          +strFechaOrden;
	strParametros = strParametros + "&intSucursalEsperaEnvio=" +intSucursalEsperaEnvio;
	strParametros = strParametros + "&strSucursalEsperaEnvio=" +strSucursalEsperaEnvio;
	document.location.href = "MercanciaCancelarTransferencia.aspx" + strParametros;
}
//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaConfirmarEnvioProductos" onSubmit="return frmMercanciaConfirmarEnvioProductos_onsubmit()">
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
              <script language="javascript">strTituloPrincipalDePagina()</script>
              </span> <span class="txcontenido"> 
              <script language="javascript">strDescripcionPrincipalDePagina()</script>
              <br>
              </span> <script language="JavaScript">crearDatosSucursal()</script> 
              <br> <div id="ToPrintHtmContenido"><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" 
            height="11" align="absMiddle"> Datos de la transferencia</span> 
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr> 
                    <td class="tdtittablas">No. folio envio:</td>
                    <td class="tdconttablas"><script language="javascript">strHdnFolioEnvio()</script></td>
                    <td class="tdtittablas"  nowrap></td>
                    <td class="tdconttablas" nowrap></td>
                  </tr>
                  <tr> 
                    <td width="155" class="tdtittablas">No. de orden:</td>
                    <td width="428" class="tdconttablas"><script language="javascript">strHdnNumeroDeOrden()</script></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Fecha de la orden:</td>
                    <td class="tdconttablas"><script language="javascript">strHdnFechaDeOrden()</script></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Fecha de confirmación:</td>
                    <td valign="top" class="tdpadleft5"><input name="txtFechaDeConfirmacion" type="text" class="campotabla" size="10" maxlength="10"> 
                      <img src="../static/images/icono_calendario.gif" width="20" height="13" 
                     align="absMiddle" style="CURSOR:hand" onClick="if(blnValidarCampo(document.forms(0).elements('txtFechaDeConfirmacion'),false,'Fecha de confirmación',cintTipoCampoFecha,10,10,'')){DoObjCalendar1();}"></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" nowrap >Motivo de transferencia:</td>
                    <td class="tdconttablas"><script language="javascript">strHdnMotivoDeTransferencia()</script></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Sucursal que recibe:</td>
                    <td class="tdconttablas"><script language="javascript">strHdnCompaniaSucursalDestino()</script> 
                      &nbsp;&nbsp; <script language="javascript">strHdnSucursalQueRecibe()</script></td>
                  </tr>
                </table>
                <!-- -->
                <br>
                <script language="javascript">strRecordBrowserHTML()</script>
                <!-- Incia   Tabla de firmas -->
                <table id="divFirmasUp" style="display:none">
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>_________________</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>_________________</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>_________________</td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" align="center">&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="tdtittablas" align="center">Nombre y Firma</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="tdtittablas" align="center">&nbsp;</td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" align="center">Gerencia que Surte</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="tdtittablas" align="center">Empleado que Recibe</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="tdtittablas" align="center">Gerencia que Recibe</td>
                  </tr>
                </table>
                <table  id="divFirmasDn" style="display:none">
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                    <!--td class="tdtittablas"> * Este documento no será válido
                            sin el nombre y firma de autorización del representante
                            del proveedor.* </td-->
                  </tr>
                </table>
                <!-- Termina Tabla de firmas -->
              </div>
              <br> <br> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="317" nowrap>&nbsp; <input name="cmdImprimir"  type="button" class="boton" value="Imprimir"   onClick="return cmdImprimir_onclick()"> 
                    &nbsp; <input name="cmdOtroEnvio" type="button" class="boton" value="Otro envío" onClick="return cmdOtroEnvio_onclick()"> 
                    &nbsp; <input name="cmdCancelar" type="button" class="boton" value="Cancelar la orden"  onClick="return cmdCancelar_onclick()"> 
                  </td>
                  <td width="200" align="center" bgcolor="#f4f6f8" class="tdenvolventeazul"> 
                    <table width="230" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td width="156" class="tdtittablas">Cifra de control</td>
                        <td width="91"   rowspan="2"><input name="cmdConfirmar"     type="submit" class="boton" value="Confirmar"></td>
                      </tr>
                      <tr> 
                        <td height="30" valign="top"><input name="txtCifraDeContro" type="text"   class="campotabla" size="16" maxlength="4" onBlur="return txtCifraDeContro_onblur()"> 
                        </td>
                      </tr>
                    </table></td>
                </tr>
              </table>
              <br> </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
    <tr> 
      <td> <input type="hidden" name="rdoQueDeseaRecuperar"> <input type="hidden" name="rdoRangoDeConsulta"> 
        <input type="hidden" name="hdnFolioEnvio"> <input type="hidden" name="hdnNumeroDeOrden"> 
        <input type="hidden" name="hdnFechaDeOrden"> <input type="hidden" name="hdnMotivoDeTransferencia"> 
        <input type="hidden" name="hdnSucursalQueRecibe"> <input type="hidden" name="hdnCompaniaSucursalDestino" > 
      </td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	var objCalendar1 = new calendar1(document.forms(0).txtFechaDeConfirmacion);
	//-->
</script>
</form>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</html>
