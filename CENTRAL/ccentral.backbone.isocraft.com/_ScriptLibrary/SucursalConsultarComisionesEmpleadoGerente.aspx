<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="SucursalConsultarComisionesEmpleadoGerente.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsSucursalConsultarComisionesEmpleadoGerente" codePage="28605"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%    '====================================================================
    ' Page          : SucursalConsultarComisionesEmpleadoGerente.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página donde se muestran las comisiones de une empleado
	'				  en el periodo actual
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Armando Calzada Mezura
    ' Version       : 1.0
    ' Last Modified : Sábado, Octubre 25, 2003
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
    document.forms[0].txtDiaInicio.value = "<%=strInicioPeriodo%>";
    document.forms[0].txtDiaFin.value = "<%=strFinPeriodo%>";
	document.forms[0].txtDiasCierre.value = <%=intDiasRestantes%>;
	document.forms[0].txtComisionEmpleado.value = "<%=strEmpleadoBusquedaComision%>";
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

function intEmpleadoBusquedaId() {
	document.write("<%=intEmpleadoBusquedaId%>");
	return(true);
}

function strSucursalNombre() {
	document.write("<%=strSucursalNombre%>");
	return(true);
}

function strEmpleadoBusquedaNombre() {
	document.write("<%=strEmpleadoBusquedaNombre%>");
	return(true);
}

function strEmpleadoBusquedaRol() {
	document.write("<%=strEmpleadoBusquedaRol%>");
	return(true);
}

function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

function cmdImprimir_onclick() {
	printContent();
	return(true);
}

function cmdRegresar_onclick() {
	location.href = "SucursalConsultarComisionesEmpleado.aspx";
	return(true);
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
                en :</span><span class="txdmigaja"> <a href="javascript:strRedireccionaPOSAdmin('Sucursal.aspx');"  class="txdmigaja">Sucursal</a> 
                : <a href="javascript:strRedireccionaPOSAdmin('SucursalEmpleados.aspx');" class="txdmigaja">Empleados</a> 
                : <a href="SucursalEmpleadosProcesarPrenomina.aspx" class="txdmigaja">Prenómina</a> 
                : Consultar comisiones por empleado gerente</span></div></td>
            <td width="182" class="tdfechahora"><script language="JavaScript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <div id="ToPrintHtmContenido"> 
                      <p><span class="txtitulo">Consultar comisiones por empleado 
                        gerente </span> 
                        <script language="JavaScript">crearDatosSucursal()</script>
                        <br>
                      <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                          <td width="117" class="tdtittablas">En proceso del:</td>
                          <td width="105" valign="middle" class="tdpadleft5"><input name="txtDiaInicio" type="text" class="campotabla" size="9" maxlength="4" readonly> 
                            <img src="../static/images/icono_calendario.gif" width="20" height="13" align="absMiddle"></td>
                          <td width="26" valign="middle" class="tdtittablas">Al:</td>
                          <td width="320" valign="middle" class="tdpadleft5"><input name="txtDiaFin" type="text" class="campotabla" size="9" maxlength="4" readonly> 
                            <img src="../static/images/icono_calendario.gif" width="20" height="13" align="absMiddle"></td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Días para cierre:</td>
                          <td colspan="3" valign="middle" class="tdpadleft5"> 
                            <input name="txtDiasCierre" type="text" class="campotablaroja" value="9" size="7" maxlength="7" readonly> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">No. de empleado:</td>
                          <td colspan="3" valign="middle" class="tdconttablas"><script language="javascript">intEmpleadoBusquedaId()</script>
                            - <span class="txconttablasrojo"> 
                            <script language="javascript">strEmpleadoBusquedaNombre()</script>
                            </span></td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Rol:</td>
                          <td colspan="3" valign="middle" class="tdconttablas"><script language="javascript">strEmpleadoBusquedaRol()</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Total de comisiones:</td>
                          <td colspan="3" valign="middle" class="tdpadleft5"><input name="txtComisionEmpleado" type="text" class="campotablaceleste" size="15" maxlength="4" readonly> 
                            &nbsp;</td>
                        </tr>
                      </table>
                      <br>
                      <script language="javascript">strRecordBrowserHTML();</script></p> 
                    </div>
                    <br> <input name="btnRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick();"> 
                    &nbsp;&nbsp; <input name="btnImprimir" type="button" class="boton" value="Imprimir la lista" onClick="return cmdImprimir_onclick();"> 
                    <br> <p></p></td>
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
