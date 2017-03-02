<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MercanciaDetalleFacturaElectronica.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaDetalleFacturaElectronica" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaDetalleFacturaElectronica.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página donde se muestra el detalle de la factura.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Griselda Gómez Ponce
    ' Version       : 1.0
    ' Last Modified : Jueves, Octubre 24, 2003
    '                 20 de Marzo 2007             Actualizacion por SAP
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

// Numero de Companía (despliegue basico)
function strCompaniaSucursal() {
	document.write(<%=intCompaniaId%> + " - " + <%=intSucursalId%>);
	return(true);
}

// Nombre de la sucursal (despliegue basico)
function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}

// Fecha actual (despliegue basico)
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}

// Nombre de Usuario (despliegue basico)
function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
	return(true);
}

function intFacturaElectronicaId() {
	document.write("<%=intFacturaElectronicaId%>");
	return(true);
}

function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

function strFacturaElectronicaNumero() {
	document.write("<%=strFacturaElectronicaNumero%>");
	return(true);
}
function intFacturaElectronicaPedido() {
	document.write("<%=intFacturaElectronicaPedido%>");
	return(true);
}
function dtmFacturaElectronicaEmisionDocumento() {
	document.write("<%=dtmFacturaElectronicaEmisionDocumento%>");
	return(true);
}

function strProveedorRazonSocial() {
	document.write("<%=strProveedorRazonSocial%>");
	return(true);
}


// Load de la pagina
function window_onload() {
 MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
 document.forms[0].action = "<%=strFormAction%>";
   
 var strMensaje = "<%=strMensaje%>";
 if (strMensaje!=""){
      window.alert(strMensaje);
 }
 
 return(true);
}


// Submit
function frmMercanciaDetalleFacturaElectronica_onsubmit() {
  valida=true;
	return(valida);
}

function cmdImprimir_onclick() {
   printContent();
    return(true);
}

function cmdRegresar_onclick() {
     window.location = "MercanciaFacturasPorConfirmar.aspx?intProveedorId=" + "<%=intProveedorId%>";
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaDetalleFacturaElectronica"
			onSubmit="return frmMercanciaDetalleFacturaElectronica_onsubmit()">
  <table width="870" border="0" cellpadding="0" cellspacing="0">
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
            <td width="660" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en: <a href="Mercancia.aspx" class="txdmigaja">Mercancía</a>: 
                <a href="MercanciaEntradas.aspx" class="txdmigaja">Entradas</a>: 
                <a href="MercanciaEntradasRecepcion.aspx" class="txdmigaja">Recepción 
                de mercancía</a>: <a href="MercanciaConfirmarFacturaElectronica.aspx" class="txdmigaja">Confirmar 
                factura electrónica de mayoristas</a>: Detalle de Factura</span></div></td>
            <td width="150" class="tdfechahora"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="680" valign="top"><table width="680" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Detalle de Factura</span><span class="txcontenido">Consulte 
                      los productos de la factura que desea confirmar.</span><span class="txcontenido"></span> 
                      <script language="JavaScript">crearDatosSucursal()</script>
                      <br>
                    <div id="ToPrintHtmContenido"><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> 
                      Factura en proceso</span> 
                      <table width="583" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                          <td width="125" class="tdtittablas">Proveedor:</td>
                          <td width="458" class="tdconttablas"><span class="txconttablasrojo"> 
                            <script language="javascript">strProveedorRazonSocial()</script>
                            </span></td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">No. de Factura:</td>
                          <td class="tdconttablas"><script language="javascript">strFacturaElectronicaNumero()</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">No. de Pedido:</td>
                          <td class="tdconttablas"><script language="javascript">intFacturaElectronicaPedido()</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Fecha de Factura:</td>
                          <td class="tdconttablas"><script language="javascript">dtmFacturaElectronicaEmisionDocumento()</script> 
                          </td>
                        </tr>
                      </table>
                      <br>
                      <script language="JavaScript">strRecordBrowserHTML()</script>
                    </div>
                    <br> <input name="cmdRegresar" type="button" class="boton" id="cmdRegresar" value="Regresar"
														onClick="return cmdRegresar_onclick()"> 
                    &nbsp;&nbsp; <input name="cmdImprimir" type="button" class="boton" id="cmdImprimir" value="Imprimir"
														onClick="return cmdImprimir_onclick()"> 
                    <br> <br> <p></p></td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
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
