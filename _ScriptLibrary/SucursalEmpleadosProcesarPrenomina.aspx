<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="SucursalEmpleadosProcesarPrenomina.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEmpleadosProcesarPrenomina" codePage="28605"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%    '====================================================================
    ' Page          : SucursalEmpleadosProcesarPrenomina.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página Inicio de Prenomina
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Armando Calzada Mezura
    ' Version       : 1.0
    ' Last Modified : Sábado, Noviembre 15, 2003
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
         return(true);
}

function strCompaniaSucursal() {
	document.write(<%=intCompaniaId%> + " - " + <%=intSucursalId%>);
	return(true);
}

function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
	return(true);
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload();">
<form action="about:blank" method="post" name="frmSucursalEmpleadosProcesarPrenomina">
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
            <td width="583" class="tdmigaja"><span class="txdmigaja">Está en : 
              </span><a href="javascript:strRedireccionaPOSAdmin('Sucursal.aspx');" class="txdmigaja">Sucursal</a> 
              : <a href="javascript:strRedireccionaPOSAdmin('SucursalEmpleados.aspx');" class="txdmigaja">Empleados</a><span class="txdmigaja"> 
              : Procesar prenómina</span></td>
            <td width="182" class="tdfechahora"><script language="JavaScript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Procesar 
              prenómina</span><span class="txcontenido">En esta parte usted puede 
              ejecutar las funciones relacionadas con la elaboración de la prenómina 
              de empleados. En particular, puede ejecutar las siguientes tareas:<br>
              </span> <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="48%"><a href="SucursalCapturarPrenomina.aspx" class="txsubtituloliga">Capturar 
                    prenómina </a></td>
                  <td width="5%" rowspan="5">&nbsp;</td>
                  <td width="48%"><a href="SucursalConsultarComisionesEmpleado.aspx" class="txsubtituloliga">Consultar 
                    comisiones por empleado</a></td>
                </tr>
                <tr> 
                  <td width="48%" class="tdcontenidoliga">Capturar cada periodo 
                    de pago, para los empleados, los movimientos que deben considerarse 
                    para calcular su pago, tanto a favor (horas extra, primas 
                    dominicales) como en contra (faltas).</td>
                  <td width="48%" class="tdcontenidoliga">Consultar, para todos 
                    los empleados de la sucursal, las comisiones que se incluirán 
                    en su pago dentro del periodo actual.</td>
                </tr>
                <tr> 
                  <td><a href="SucursalConsultarCierrePrenomina.aspx" class="txsubtituloliga">Consultar 
                    cierre de prenómina</a></td>
                  <td>&nbsp;</td>
                </tr>
                <tr> 
                  <td class="tdcontenidoliga">Consultar cuáles serán los días 
                    de cierre, así como el periodo de pago cubierto, para asegurarse 
                    de cerrar a tiempo el envío de la prenómina.</td>
                  <td class="tdcontenidoliga">&nbsp;</td>
                </tr>
              </table>
              <span class="txcontenido"> </span> </td>
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
	//-->
</script>
</form>
</body>
</html>
