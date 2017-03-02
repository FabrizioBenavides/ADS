<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaCancelarTransferencia.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaCancelarTransferencia" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : MercanciaCancelarTransferencia.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para cancelar transferencias
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Carlos E. Pérez Torres
    ' Version       : 1.0
    ' Last Modified : October 14, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%><html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language=JavaScript src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
function window_onload() {
		MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
		document.forms[0].action = "<%=strFormAction%>";
		<%if intPrintCambiarEstado > 0 then%>
			alert("El Folio de cancelación es: <%=intPrintCambiarEstado%>");
			window.location="MercanciaProcesarEnviosAutomaticos.aspx";
		<%end if%>
		document.forms[0].elements["txtFecha"].value = "<%=strFechaActual%>"
         return(true);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

function intPrintCambiarEstado() {
	document.write("<%=intPrintCambiarEstado%>");
	return(true);
}

function intNumeroOrden() {
	document.write("<%=intNumeroOrden%>");
	return(true);
}

function strFechaOrden() {
	document.write("<%=strFechaOrden%>");
	return(true);
}

function intSucursalEsperaEnvio() {
	document.write("<%=intSucursalEsperaEnvio%>");
	return(true);
}

function strSucursalEsperaEnvio() {
	document.write("<%=strSucursalEsperaEnvio%>");
	return(true);
}

function cmdValidarForma() {
	if (document.forms[0].elements["txtComentarios"].value == ""){
		alert("Por favor introduzca un comentario.");
		document.forms[0].elements["txtComentarios"].focus();
		return(false);
	}
	if (document.forms[0].elements["txtFecha"].value == "") {
		alert("Por favor introduzca una fecha.");
		document.forms[0].elements["txtFecha"].focus();
		return(false);
	}
	if (!(blnValidarCampo(document.forms('frmMercanciaCancelarTransferencia').elements('txtFecha'),false,'Fecha',cintTipoCampoFecha,10,10,''))){
		return(false);
	}
	return(true);

}

function cmdConsultar_onlcick() {
	if (cmdValidarForma()) {
		document.forms[0].action = "<%=strFormAction%>?strCmd=Consultar&intTransferenciaId=<%=intTransferenciaId%>&intNumeroOrden=<%=intNumeroOrden%>&strFechaOrden=<%=strFechaOrden%>&intSucursalEsperaEnvio=<%=intSucursalEsperaEnvio%>&strSucursalEsperaEnvio=<%=strSucursalEsperaEnvio%>";
		return(true);
	}
	else{
		return(false);
	}
}

function cmdRegresar_onclick() {
	window.location="MercanciaProcesarEnviosAutomaticos.aspx";
	return(true);
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0"  onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaCancelarTransferencia">
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
              : <a href="javascript:strRedireccionaPOSAdmin('MercanciaSalidas.aspx')" class="txdmigaja">Salidas</a> 
              : </span><span class="txdmigaja"> <a href="javascript:strRedireccionaPOSAdmin('MercanciaSalidasTransferenciasOtraSucursal.aspx')" class="txdmigaja">Transferencias 
              a otra sucursal</a> : </span><span class="txdmigaja"></span><span class="txdmigaja">Cancelar 
              transferencia</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Cancelar 
              transferencia </span><span class="txcontenido">Ha elegido cancelar 
              una transferencia sugerida por la administraci&oacute;n central. 
              Por favor registre las razones para dicha cancelaci&oacute;n, a 
              fin de poder mejorar el desempe&ntilde;o del sistema para servirle 
              mejor.</span><br> <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle"> 
              Razones para cancelar el env&iacute;o</span> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="63" class="tdtittablas">Sucursal:</td>
                  <td width="290" valign="middle" class="tdconttablas"><script language="javascript">strCompaniaSucursal()</script> 
                    <script language="javascript">strSucursalNombre()</script></td>
                  <td width="86" valign="middle" class="tdtittablas">Fecha y hora:</td>
                  <td width="144" valign="middle" class="tdconttablas"><script language="javascript">strGetCustomDateTime()</script></td>
                </tr>
              </table>
              <br> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="197" class="tdtittablas">Folio de cancelación:</td>
                  <td width="386" class="tdconttablasrojo"><script language="javascript">intPrintCambiarEstado()</script></td>
                </tr>
                <tr> 
                  <td width="197" class="tdtittablas">No. de orden</td>
                  <td width="386" class="tdconttablas"><script language="javascript">intNumeroOrden()</script></td>
                </tr>
                <tr> 
                  <td class="tdtittablas">Fecha de la orden:</td>
                  <td class="tdconttablas"><script language="javascript">strFechaOrden()</script></td>
                </tr>
                <tr> 
                  <td class="tdtittablas">Fecha de cancelaci&oacute;n:</td>
                  <td valign="top" class="tdpadleft5"> <input name="txtFecha" type="text" class="campotabla" size="10" maxlength="10"> 
                    <img src="../static/images/icono_calendario.gif" width="20" height="13" align="absmiddle" onClick="if (blnValidarCampo(document.forms('frmMercanciaCancelarTransferencia').elements('txtFecha'),false,'Fecha',cintTipoCampoFecha,10,10,'')) {objCalendar1.popup();};" alt="Clic para seleccionar la fecha." style="cursor:hand"></td>
                </tr>
                <tr> 
                  <td class="tdtittablas">Sucursal que esperaba el env&iacute;o:</td>
                  <td class="tdconttablas"><script language="javascript">intSucursalEsperaEnvio()</script> 
                    <script language="javascript">strSucursalEsperaEnvio()</script></td>
                </tr>
                <tr> 
                  <td class="tdtittablas">Razones de la cancelaci&oacute;n</td>
                  <td rowspan="2" class="tdconttablas"><textarea name="txtComentarios" cols="60" rows="6" class="txtbox"></textarea></td>
                </tr>
                <tr> 
                  <td class="tdtittablas">&nbsp;</td>
                </tr>
                <tr> 
                  <td>&nbsp;</td>
                  <td height="36" valign="bottom"> &nbsp; <input name="btnRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()"> 
                    &nbsp;&nbsp;&nbsp; <input name="btnConsultar" type="submit" class="boton" value="Aceptar" onClick="return cmdConsultar_onlcick()"> 
                    &nbsp;&nbsp;&nbsp; </td>
                </tr>
              </table>
              <br> <br> </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
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
	var objCalendar1 = new calendar1(document.forms['frmMercanciaCancelarTransferencia'].elements['txtFecha']);
	//-->
</script>
</form>
</body>
</html>
