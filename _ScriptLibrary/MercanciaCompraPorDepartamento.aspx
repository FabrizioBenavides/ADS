<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaCompraPorDepartamento.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaCompraporDepartamento" codePage="28605"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%    '====================================================================
    ' Page          : MercanciaCompraporDepartamento.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para consultar las compras por departamento
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Armando Calzada Mezura
    ' Version       : 1.0
    ' Last Modified : Jueves, Octubre 30, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
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
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";


function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
    document.forms[0].action = "<%=strFormAction%>";
   //Iniciliza la lista de los meses
   <%=strGeneraListaMeses("cboMesConsulta")%>;
    return(true);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

function intCompaniaId() {
	return(<%=intCompaniaId%>);
}

function intSucursalId() {
	return(<%=intSucursalId%>);
}

function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
}

function strCompaniaSucursal() {
	document.write(intCompaniaId() + " - " + intSucursalId());
	return(true);
}

function strSucursalNombre() {
	document.write("<%=strSucursalNombre%>");
	return(true);
}

function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

function cmdConsultar_onClick() {
	var theForm = document.forms[0];

	if (theForm.cboMesConsulta.value == "0") {
		alert("Seleccionar el mes a consultar");
		theForm.cboMesConsulta.focus();
        return false;
	}

	theForm.action += "?strCmd=Consultar";
	theForm.submit();	
	return(false);
}

function cmdRegresar_onClick() {
	strRedireccionaPOSAdmin('MercanciaEntradasConsultaGasto.aspx');
	return(false);
}

function cmdImprimir_onclick() {
	printContent();
	return(true);
}

function cmdPresupuesto_onClick() {
	document.location.href = "MercanciaPresupuestoCompras.aspx?strCmd=Consultar&cboMesConsulta=" + document.forms[0].cboMesConsulta.value;
	return(false);
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaCompraporDepartamento">
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
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en :</span><span class="txdmigaja"> <a href="Mercancia.aspx" class="txdmigaja">Mercancía</a> 
                : <a href="javascript:strRedireccionaPOSAdmin('MercanciaEntradas.aspx')" class="txdmigaja">Entradas</a> 
                : <a href="javascript:strRedireccionaPOSAdmin('MercanciaEntradasConsultaGasto.aspx')" class="txdmigaja">Consultar 
                gastos</a> : Compras por departamento</span></div></td>
            <td width="182" class="tdfechahora"> <script language="JavaScript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <div id="ToPrintHtmContenido"> 
                      <p><span class="txtitulo">Compras por departamento </span><span class="txcontenido"> 
                        Elija el mes a consultar.</span> 
                        <script language="JavaScript">crearDatosSucursal()</script>
                      <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                          <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                              <tr> 
                                <td width="106" class="tdtittablas">Mes a consultar:</td>
                                <td width="477" valign="middle" class="tdpadleft5"><select name="cboMesConsulta" class="campotabla">
                                  </select></td>
                              </tr>
                            </table>
                            <br> <input name="btnConsultar" type="button" class="boton" value="Consultar" onClick="return cmdConsultar_onClick()"> 
                            <br> </td>
                        </tr>
                      </table>
                      <br>
                      <script language="javascript">strRecordBrowserHTML();</script>
                    </div></td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp; </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
    <tr> 
      <td> <input class="campotabla" type="hidden" size="5" name="txtReclamacionId" readonly> 
        <input class="campotabla" type="hidden" size="5" name="txtDepartamentoId" readonly> 
        <input class="campotabla" type="hidden" size="5" name="txtDepartamentoProveedorId" readonly></td>
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
</body>
</html>
