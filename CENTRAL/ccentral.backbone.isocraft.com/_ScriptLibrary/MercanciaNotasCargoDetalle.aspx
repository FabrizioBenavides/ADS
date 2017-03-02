<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaNotasCargoDetalle.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaNotasCargoDetalle" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaNotasCargoDetalle.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página que muestra el detalle de una nota de cargo
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Jorge Tamez Sánchez
    ' Version       : 1.0
    ' Last Modified : Miercoles, Diciembre 17, 2003
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
function frmMercanciaNotasCargoDetalle_onsubmit() {
  valida=true;
	return(valida);
}

function window_onload() {
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action = "<%=strFormAction%>";
  return(true);
}

function dtmFechaNotaCargo(){
 document.write("<%=dtmFechaNotaCargo%>");
 return(true);
}

function intProveedorId(){
 document.write("<%=intProveedorId%>");
 return(true);
}

function strRazonSocialProveedor(){
 document.write("<%=strRazonSocialProveedor%>");
 return(true);
}

function strNumeroFactura(){
 document.write("<%=strNumeroFactura%>");
 return(true);
}

function strFolioEntrada(){
 document.write("<%=strFolioEntrada%>");
 return(true);
}

function intDepartamentoNotaCargo(){
 document.write("<%=intDepartamentoNotaCargo%>");
 return(true);
}

function strNombreDepartamento(){
 document.write("<%=strNombreDepartamento%>");
 return(true);
}


function strImporteNeto(){
 document.write("<%=strImporteNeto%>");
 return(true);
}


function strTipoNotaCargo(){
 document.write("<%=strTipoNotaCargo%>");
 return(true);
}


function cmdVerOtraNota_onclick() {
 document.forms[0].action = "MercanciaNotasCargoProveedor.aspx?" + "<%=strFormActionParameters%>";
 document.forms[0].submit();
}

function cmdImprimir_onclick() {
 printContent();
 return(true);
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaNotasCargoDetalle" onSubmit="return frmMercanciaNotasCargoDetalle_onsubmit()">
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
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Est&aacute; 
                en : </span><a href="Mercancia.aspx" class="txdmigaja">Mercanc&iacute;a</a><span class="txdmigaja"> 
                : <a href="javascript:strRedireccionaPOSAdmin('MercanciaEntradas.aspx')" class="txdmigaja">Entradas</a></span><span class="txdmigaja"> 
                : </span><span class="txdmigaja"></span><span class="txdmigaja">Detalle 
                de nota de cargo</span></div></td>
            <td width="182" class="tdfechahora"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont">	
                    <p><span class="txtitulo">Detalle de nota de cargo</span> 
                    <div id="ToPrintHtmContenido"> 
                      <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                          <td width="117" class="tdtittablas">Fecha del cargo:</td>
                          <td class="tdconttablas"><script language="JavaScript">dtmFechaNotaCargo();</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Proveedor:</td>
                          <td width="451" valign="middle" class="tdconttablasrojo"><script language="JavaScript">intProveedorId();</script> 
                            &nbsp;&nbsp; <script language="JavaScript">strRazonSocialProveedor();</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">No. de factura:</td>
                          <td valign="middle" class="tdconttablas"><script language="JavaScript">strNumeroFactura();</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Folio de entrada:</td>
                          <td valign="middle" class="tdconttablas"><script language="JavaScript">strFolioEntrada();</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Departamento:</td>
                          <td valign="middle" class="tdconttablas"><script language="JavaScript">intDepartamentoNotaCargo();</script> 
                            &nbsp;&nbsp; <script language="JavaScript">strNombreDepartamento();</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Importe neto:</td>
                          <td valign="middle" class="tdconttablas"><script language="JavaScript">strImporteNeto();</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Tipo:</td>
                          <td valign="middle" class="tdconttablas"><script language="JavaScript">strTipoNotaCargo();</script> 
                          </td>
                        </tr>
                      </table>
                    </div>
                    <br> <input name="cmdVerOtraNota" type="button" class="boton" id="cmdVerOtraNota" value="Ver otra nota" onClick="return cmdVerOtraNota_onclick()"> 
                    &nbsp;&nbsp; <input name="cmdImprimir" type="button" class="boton" id="cmdImprimir" value="Imprimir" onClick="return cmdImprimir_onclick()"> 
                    <br> <br> </td>
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
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</html>
