<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="SucursalConsultarCierrePrenomina.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsSucursalConsultarCierrePrenomina" codePage="28605"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%    '====================================================================
    ' Page          : SucursalConsultarCierrePrenomina.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para consultar el periodo de prenómina actual
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Armando Calzada Mezura
    ' Version       : 1.0
    ' Last Modified : Viernes, Octubre 22, 2003
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

function window_onload() {
	MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
    document.forms[0].action = "<%=strFormAction%>";
	document.forms[0].txtDiaCierre.value = <%=intDiaCierre%>;
    return(true);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}



function strPeriodoPrenomina() {
	document.write("<%=strPeriodoPrenomina%>")
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
                en :</span><span class="txdmigaja"> <a href="javascript:strRedireccionaPOSAdmin('Sucursal.aspx');"  class="txdmigaja">Sucursal</a> 
                : <a href="javascript:strRedireccionaPOSAdmin('SucursalEmpleados.aspx');" class="txdmigaja">Empleados</a> 
                : <a href="SucursalEmpleadosProcesarPrenomina.aspx" class="txdmigaja">Prenómina</a> 
                : Capturar prenómina</span></div></td>
            <td width="187" class="tdfechahora"><div id="ToPrintTxtFecha"> 
                <script language="JavaScript">strGetCustomDateTime()</script>
              </div></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"> <table width="583" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Consultar cierre de pren&oacute;mina 
                      </span><span class="txcontenido"> La fecha aquí marcada 
                      es el límite para la captura de movimientos del perído.</span> 
                      <br>
                      <script language="JavaScript">crearDatosSucursal()</script>
                      <br>
                    <div id="ToPrintHtmContenido"> 
                      <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                          <td width="88" class="tdtittablas">D&iacute;a de cierre:</td>
                          <td width="51" class="tdpadleft5"> <input name="txtDiaCierre" type="text" class="campotabla" size="4" maxlength="4" readonly> 
                          </td>
                          <td width="429" valign="middle" class="tdconttablasgris"><script language="javascript">strPeriodoPrenomina();</script> 
                          </td>
                        </tr>
                      </table>
                      <br>
                    </div>
                    <br> <input name="btnRegresar" type="button" class="boton" value="Regresar" onClick="return btnRegresar_onclick()"> 
                    &nbsp;&nbsp; <input name="btnImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick();"> 
                    <br> <p></p></td>
                </tr>
              </table></td>
            <td width="187" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom">Sistema Administrador de Puntos de 
              Venta - 2003 Farmacias Benavides</td>
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
