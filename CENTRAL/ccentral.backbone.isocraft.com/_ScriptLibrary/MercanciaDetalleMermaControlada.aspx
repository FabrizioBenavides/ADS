<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaDetalleMermaControlada.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaDetalleMermaControlada" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaDetalleMermaControlada.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Griselda Gómez Ponce
    ' Version       : 1.0
    ' Last Modified : Day, Month Day, 2003
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



function window_onLoad() {
   MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
    document.forms[0].action="<%=strFormAction%>";
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
function frmMercanciaDetalleMermaControlada_onsubmit() {
  valida=true;
	return(valida);
}

function intMermaFolio() {
	document.write("<%=intMermaFolio%>");
	return(true);
}

function intMermaId() {
	document.write("<%=intMermaId%>");
	return(true);
}

function strFechaRegistroMerma() {
	document.write("<%=strFechaRegistroMerma%>");
	return(true);
}

function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

function cmdRegresar_onclick() {
     //Redireccionamos a la página de archivo de merma controlada para otra consulta
     history.go(-1);
}

function cmdImprimir_onclick() {
    var1 = document.all.ToPrintHtmContenido1.innerHTML;
    var2 = document.all.ToPrintHtmContenido2.innerHTML;
    
    document.all.ToPrintHtmContenido.innerHTML=var1+var2;
    printContent();
    document.all.ToPrintHtmContenido.innerHTML="";
    return(true);
}


function cmdSalir_onclick() {
   //Redireccionamos al home de Mermas
   strRedireccionaPOSAdmin('MercanciaMermas.aspx');
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onLoad()">
<form action="about:blank" method="post" name="frmMercanciaDetalleMermaControlada">
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
                en : </span><a href="Mercancia.aspx" class="txdmigaja">Mercancía</a><span class="txdmigaja"> 
                : </span><span class="txdmigaja"><a href="javascript:strRedireccionaPOSAdmin('MercanciaMermas.aspx')" class="txdmigaja">Merma</a></span><span class="txdmigaja"> 
                : </span><span class="txdmigaja"></span><span class="txdmigaja">Detalle 
                merma controlada archivada</span></div></td>
            <td width="182" class="tdfechahora"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td height="48" colspan="3" valign="top" > <p><span class="txtitulo">Detalle 
                      de merma controlada archivada</span><span class="txcontenido">Los 
                      siguientes son los detalles del reporte de merma solicitado.</span></p></td>
                </tr>
                <tr> 
                  <td colspan="3"> <script language="JavaScript">crearDatosSucursal()</script></td>
                </tr>
                <tr> 
                  <td colspan="3" valign="top">&nbsp;</td>
                </tr>
                <tr> 
                  <td width="22%" valign="top" bgcolor="#f4f6f8" class="tdenvolventeazul"> 
                    <div id="ToPrintHtmContenido1"> 
                      <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                          <td class="tdtittablas2">Folio de control:</td>
                        </tr>
                        <tr> 
                          <td class="tdconttablasnopad"><script language="javascript">intMermaFolio()</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas2">Fecha de reporte:</td>
                        </tr>
                        <tr> 
                          <td class="tdconttablasnopad"><script language="javascript">strFechaRegistroMerma()</script> 
                          </td>
                        </tr>
                      </table>
                    </div></td>
                  <td width="3%" valign="top">&nbsp;</td>
                  <td width="75%" valign="top"><div id="ToPrintHtmContenido2"> 
                      <script language="javascript">strRecordBrowserHTML()</script>
                    </div></td>
                </tr>
                <tr> 
                  <td colspan="3"></td>
                </tr>
              </table>
              <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="25%" valign=top></td>
                  <td width="75%" valign="top"> <p><br>
                      <input name="cmdSalir" type="button" class="boton" value="Regresar" onClick="return cmdSalir_onclick()">
                      &nbsp;&nbsp;&nbsp; 
                      <input name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()">
                      &nbsp;&nbsp;&nbsp; 
                      <input name="cmdRegresar" type="button" class="boton" value="Otra merma" onClick="return cmdRegresar_onclick()">
                      <br>
                    </p>
                    <p> </p></td>
                </tr>
              </table></td>
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
<div id="ToPrintHtmContenido"></div>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</html>
