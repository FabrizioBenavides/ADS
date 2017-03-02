<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConfirmacionRemision.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaConfirmacionRemision" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaConfirmacionRemision.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : P�gina donde confirma las remisiones
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hern�ndez D�vila
    ' Version       : 1.0
    ' Last Modified : Miercoles, Octubre 22, 2003
    ' Modificacion  : Septiembre 20, 2004 ; Griselda G�mez Ponce
    '   Se imprime en la p�gina la fecha y hora de la confirmaci�n.
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta name="description" content="Javascript Menu">
<meta name="keywords" content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
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
   var strMensaje = "<%=strMensaje%>";
   var strConfirmada = "<%=strConfirmada%>";
     
   document.forms[0].elements['dtmRecepcionRemision'].value = "<%=dtmRecepcionRemision%>";
   document.forms[0].elements['txtNumeroRemision'].value = "<%=strNumeroRemisionCapturada%>";
   document.forms[0].elements['dtmEmisionRemision'].value = "<%=dtmEmisionRemisionCapturadaId%>";
   
   
   if (strMensaje.length > 0) {
      alert(strMensaje);
   }
   
   if (strConfirmada.length > 0) {
        //Operacion Confirmada con exito
		document.forms[0].elements['cmdConfirmar'].disabled=true;
		document.forms[0].elements['dtmRecepcionRemision'].readOnly = true;
		document.forms[0].elements['txtNumeroRemision'].readOnly = true;
		document.forms[0].elements['dtmEmisionRemision'].readOnly = true;
        strConfirmacion = '<%=intConfirmacion%>';
        strFechaHora = '<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>';
		document.all.divFolioConfirmacion.innerHTML = 'La operaci�n quedo confirmada con el folio: '+strConfirmacion + '  con fecha: '+strFechaHora;
		//Mandar Imprimir
		cmdValidar_onclick();
		cmdImprimir_onclick();
   }
   
   return(true);
}

function cmdImprimir_onclick() {
	if (window.print) {
        document.ifrPageToPrint.document.all.ToPrintTxtMigaja.innerHTML=document.all.ToPrintTxtMigaja.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtFecha.innerHTML=document.all.ToPrintTxtFecha.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtSucursal.innerHTML=document.all.ToPrintTxtSucursal.innerText;
        document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML=document.all.ToPrintHtmContenido.innerHTML;
        
        //Ocultar Validar Datos en el frame oculto
        document.ifrPageToPrint.document.all.cmdValidar.style.display='none';
        
        //Mostrar Tabla de firmas
        document.ifrPageToPrint.document.all.divFirmasHTML.style.display='';
        
        document.ifrPageToPrint.focus();
        window.print();        
    } else {
        alert("Tu navegador no soporta la funci�n: Print.")
    }
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}

function strNombreProveedor() {
   document.write ("<%=strProveedorRazonSocial%>");
}

function frmMercanciaConfirmacionRemision_onsubmit() {
   var regreso = true;
   	
   if (regreso) {
       if (document.forms[0].elements['dtmRecepcionRemision'].value == ""){
           alert("Capturar la Fecha de Recepci�n de la Remisi�n")
           regreso=false;
       }
   }
      
   if (regreso) {
       if (document.forms[0].elements['txtNumeroRemision'].value == "") {
           alert("Capturar la Remisi�n a Confirmar");
           regreso=false;
       }
   }
   
   if (regreso) {
       if (document.forms[0].elements['dtmEmisionRemision'].value == ""){
	       alert("Capturar la Fecha Emisi�n de la Remisi�n")
	       regreso=false;
       }
   }
   	
   if (regreso) {	
       regreso = blnValidarCampo(document.forms[0].elements['dtmRecepcionRemision'],true,'Fecha Recepci�n de la Remisi�n',cintTipoCampoFecha,10,10,'');
   }
   
   if (regreso){
       regreso = blnValidarCampo(document.forms[0].elements['dtmEmisionRemision'],true,'Fecha Emisi�n de la Remisi�n',cintTipoCampoFecha,10,10,'');
   }
       
   if (regreso){
	   var strRemisionElectronicaNumero = "<%=strRemisionElectronicaNumero%>";
       var dtmRemisionElectronicaEmision = "<%=dtmRemisionElectronicaEmision%>";       
          
       var strRemisionNumero  = document.forms[0].elements['txtNumeroRemision'].value;
       var dtmRemisionEmision = document.forms[0].elements['dtmEmisionRemision'].value.substr(3,2)+"/"+document.forms[0].elements['dtmEmisionRemision'].value.substr(0,2)+"/"+document.forms[0].elements['dtmEmisionRemision'].value.substr(6,4);   
	    	
	   if ( strRemisionNumero == strRemisionElectronicaNumero && dtmRemisionEmision == dtmRemisionElectronicaEmision) {
	       regreso=true;
	   }
	   else{
	       alert("Datos no coinciden con Remisi�n a Confirmar");
	       regreso=false;	       
       }
   }
   
   return (regreso);		   
}

function cmdValidar_onclick() {	
   var regreso = true;
   	
   if (regreso) {
       if (document.forms[0].elements['dtmRecepcionRemision'].value == ""){
	       alert("Capturar la Fecha de Recepci�n de la Remisi�n")
	       regreso=false;
	   }
   }
   
   if (regreso) {   	
       if (document.forms[0].elements['txtNumeroRemision'].value=="") {
           alert("Capturar la Remisi�n a Confirmar");
	       regreso=false;
	   }
   }
   
   if (regreso) {
	   if (document.forms[0].elements['dtmEmisionRemision'].value == ""){
	       alert("Capturar la Fecha Emisi�n de la Remisi�n")
	       regreso=false;
	   }
	}
	
	if (regreso) {	
	    regreso=blnValidarCampo(document.forms[0].elements['dtmRecepcionRemision'],true,'Fecha Recepci�n de la Remisi�n',cintTipoCampoFecha,10,10,'');
	}
		
    if (regreso){
       regreso=blnValidarCampo(document.forms[0].elements['dtmEmisionRemision'],true,'Fecha Emisi�n de la Remisi�n',cintTipoCampoFecha,10,10,'');
    }
    
    if (regreso){
	   var strRemisionElectronicaNumero = "<%=strRemisionElectronicaNumero%>";
       var dtmRemisionElectronicaEmision = "<%=dtmRemisionElectronicaEmision%>";       
          
       var strRemisionNumero  = document.forms[0].elements['txtNumeroRemision'].value;
       var dtmRemisionEmision = document.forms[0].elements['dtmEmisionRemision'].value.substr(3,2)+"/"+document.forms[0].elements['dtmEmisionRemision'].value.substr(0,2)+"/"+document.forms[0].elements['dtmEmisionRemision'].value.substr(6,4);   
	    	
	   if ( strRemisionNumero == strRemisionElectronicaNumero && dtmRemisionEmision == dtmRemisionElectronicaEmision) {
	       document.forms[0].elements['txtValidacion'].value = "DATOS VALIDOS";	
	   }
	   else{
	       document.forms[0].elements['txtValidacion'].value = "ERROR EN DATOS";	
       }
   }
   return (regreso);		
}


function cmdRegresar_onclick() {
   window.location="MercanciaRemisionporConfirmar.aspx?intProveedorId="+ <%=intProveedorId%>;
}

//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload();">
<form action="about:blank" method="post" name="frmMercanciaConfirmacionRemision" onSubmit="return frmMercanciaConfirmacionRemision_onsubmit()">
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
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Est� 
                en : </span><a href="Mercancia.aspx" class="txdmigaja">Mercanc�a</a><span class="txdmigaja"> 
                : <a href="MercanciaEntradas.aspx" class="txdmigaja">Entradas</a> 
                : <a href="MercanciaEntradasConfirmarRemision.aspx"
												class="txdmigaja">Confirmar remisi�n 
                electr�nica</a> : </span><span class="txdmigaja">Confirmaci�n 
                de remisi�n</span></div></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Confirmaci�n 
              de remisi�n</span><span class="txcontenido">Para confirmar, capture 
              n�mero y fecha de la remisi�n, y luego oprima el bot�n validar.</span> 
              <script language="JavaScript">crearDatosSucursal()</script> <br> 
              <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> 
              Identificar documento</span> <div id="ToPrintHtmContenido"> 
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr> 
                    <td class="tdconttablas" colspan="4" nowrap> <div id="divFolioConfirmacion"></div></td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Proveedor:</td>
                    <td class="tdconttablas"> <span class="txconttablasrojo"> 
                      <script language="JavaScript">strNombreProveedor()</script>
                      </span> </td>
                  </tr>
                  <tr> 
                    <td width="163" class="tdtittablas">Fecha de Recepci�n</td>
                    <td width="410" class="tdconttablas"><input name="dtmRecepcionRemision" type="text" class="campotabla" size="10" maxlength="10"> 
                      <a href="javascript:objdtmRecepcionRemision.popup();"><img onClick="return blnValidarCampo(document.forms('frmMercanciaConfirmacionRemision').elements('dtmRecepcionRemision'),false,'Fecha',cintTipoCampoFecha,10,10,'');"
															height="13" alt="Clic para seleccionar la fecha." src="../static/images/icono_calendario.gif" width="20" border="0"></a> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">No. de remisi�n:</td>
                    <td class="tdpadleft5"><input name="txtNumeroRemision" type="text" class="campotabla" size="20" maxlength="20"> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Fecha de remisi�n:</td>
                    <td class="tdpadleft5"><input name="dtmEmisionRemision" type="text" class="campotabla" size="10" maxlength="10"> 
                      <a href="javascript:objdtmEmisionRemision.popup();"><img onClick="return blnValidarCampo(document.forms('frmMercanciaConfirmacionRemision').elements('dtmEmisionRemision'),false,'Fecha',cintTipoCampoFecha,10,10,'');"
															height="13" alt="Clic para seleccionar la fecha." src="../static/images/icono_calendario.gif" width="20" border="0"></a> 
                    </td>
                  </tr>
                  <tr> 
                    <td height="40"><input name="cmdValidar" type="button" class="boton" value="Validar datos" onClick="return cmdValidar_onclick()"> 
                    </td>
                    <td class="tdconttablasrojo"><input name="txtValidacion" type="text" class="campotablaresultado" size="20" redonly="true"> 
                    </td>
                  </tr>
                </table>
                <div id="divFirmasHTML" style="DISPLAY:none"> <br>
                  <br>
                  <br>
                  <br>
                  <br>
                  <br>
                  <table>
                    <tr> 
                      <td>_________________</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td>_________________</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td>_________________</td>
                    </tr>
                    <tr> 
                      <td class="tdtittablas" align="center">Nombre y Firma</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Nombre y Firma</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Nombre y Firma</td>
                    </tr>
                    <tr> 
                      <td class="tdtittablas" align="center">Chofer Repartidor</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Captur� Documento</td>
                      <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                      <td class="tdtittablas" align="center">Gte. Sucursal</td>
                    </tr>
                  </table>
                  <br>
                  <table>
                    <tr> 
                      <td class="tdtittablas"> * Este documento no ser� v�lido 
                        sin el nombre y firma de autorizaci�n del representante 
                        del proveedor.* </td>
                    </tr>
                  </table>
                </div>
              </div>
              <!-- CERRAMOS div id="ToPrintHtmContenido" -->
              <br> <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Procesar 
              documento</span> <span class="txcontenido">Si no hubo diferencias 
              en el env�o, oprima �Confirmar remisi�n�. En caso contrario, oprima 
              �Capturar excepciones� para registrar las cantidades recibidas.</span> 
              <br> <input name="cmdRegresar" type="button" class="boton" value="Otra remisi�n" onClick="return cmdRegresar_onclick()"> 
              &nbsp;&nbsp;&nbsp; <input name="cmdCaptura" type="button" class="boton" value="Capturar excepciones"> 
              &nbsp;&nbsp;&nbsp; <input name="cmdConfirmar" type="submit" class="boton" value="Confirmar remisi�n"> 
              <br> <br> </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda(strPaginaAyuda);</script> 
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
	
	var objdtmRecepcionRemision = new calendar1(document.forms['frmMercanciaConfirmacionRemision'].elements['dtmRecepcionRemision']);
	var objdtmEmisionRemision = new calendar1(document.forms['frmMercanciaConfirmacionRemision'].elements['dtmEmisionRemision']);
	//-->
			</script>
</form>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</HTML>
