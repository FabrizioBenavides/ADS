<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="SucursalCapturarPrenomina.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsSucursalCapturarPrenomina" codePage="28605"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%    '====================================================================
    ' Page          : SucursalCapturarPrenomina.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página donde se muestran los empleados de la sucursal
	'				  en el periodo actual
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Armando Calzada Mezura
    ' Version       : 1.0
    ' Last Modified : Miércoles, Octubre 22, 2003
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
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";

function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
    document.forms[0].action = "<%=strFormAction%>";
	document.forms[0].txtDiasCierre.value = <%=intDiasRestantes%>;
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

function strPeriodoPrenomina() {
	document.write("<%=strPeriodoPrenomina%>")
	return(true);		
}

function strRecordBrowserHTML(){
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

function cmdImprimir_onclick() {
	printContent();
	return(true);
}


function btnRegresar_onclick() {
	window.location="SucursalEmpleadosProcesarPrenomina.aspx"
	
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmSucursalCapturarPrenomina">
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
                en :</span><span class="txdmigaja"> <a href="javascript:strRedireccionaPOSAdmin('Sucursal.aspx');" class="txdmigaja">Sucursal</a> 
                : <a href="javascript:strRedireccionaPOSAdmin('SucursalEmpleados.aspx');" class="txdmigaja">Empleados</a> 
                : <a href="SucursalEmpleadosProcesarPrenomina.aspx" class="txdmigaja">Prenómina</a> 
                : Capturar prenómina</span></div></td>
            <td width="182" class="tdfechahora"> <script language="JavaScript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <div id="ToPrintHtmContenido"> 
                      <p><span class="txtitulo">Capturar Prenómina </span><span class="txcontenido">Desde 
                        aquí podrá capturar los conceptos de su prenómina. Para 
                        asignar los movimientos de un periodo o para consultar 
                        los que ya asignó, haga clic en la liga operativa correspondiente.</span> 
                        <script language="JavaScript">crearDatosSucursal()</script>
                        <br>
                      <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                          <td width="94" class="tdtittablas">En proceso del:</td>
                          <td width="233" valign="middle" class="tdconttablas"><script language="javascript">strPeriodoPrenomina();</script> 
                          </td>
                          <td width="101" valign="middle" class="tdtittablas">Días 
                            para cierre:</td>
                          <td width="140" valign="middle" class="tdpadleft5"><input name="txtDiasCierre" type="text" class="campotablaroja" size="9" maxlength="4" readonly> 
                          </td>
                        </tr>
                      </table>
                      <br>
                      <script language="javascript">strRecordBrowserHTML();</script>
                    </div>
                    <br> <input name="btnRegresar" type="button" class="boton" value="Regresar"  onClick="return btnRegresar_onclick()"> 
                    &nbsp;&nbsp; <input name="btnImprimir" type="button" class="boton" value="Imprimir la lista" onClick="return cmdImprimir_onclick();"> 
                    <br> </p> </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda('');</script>	
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
	//-->
</script>
</form>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</html>
