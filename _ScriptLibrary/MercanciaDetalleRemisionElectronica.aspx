<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MercanciaDetalleRemisionElectronica.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaDetalleRemisionElectronica" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaDetalleRemisionElectronica.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página donde se muestra el detalle de la remisión.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Jorge Tamez Sánchez
    ' Version       : 1.0
    ' Last Modified : Day, Month Day, 2003
	'                 20 de Marzo 2007             Actualizacion por SAP
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
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
// Load de la pagina
function window_onload() {
 MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
 document.forms[0].action = "<%=strFormAction%>";
 return(true);
}

// Submit
function frmMercanciaDetalleRemisionElectronica_onsubmit() {
  valida=true;
	return(valida);
}
// Fecha actual (despliegue basico)
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}

function strRecordBrowserHTML(){
 document.write("<%=strRecordBrowserHTML%>");
}


// Razon Social del Proveedor
function strProveedorRazonSocial(){
 document.write("<%=strProveedorRazonSocial%>");
  return(true);
}

// Número de Remision ElectronicaID
function intRemisionElectronicaId(){
 document.write("<%=intRemisionElectronicaId%>");
 return(true); 
}
// Número de Remision Electronica
function strRemisionElectronicaNumero(){
 document.write("<%=strRemisionElectronicaNumero%>");
 return(true); 
}

// Fecha de Emisión de la Remisión
function dtmRemisionElectronicaEmisionDocumento(){
 document.write("<%=dtmRemisionElectronicaEmisionDocumento%>");
 return(true); 
}

// Regresamos a la siguiente página
function cmdRegresar_onclick() {
 window.location = "MercanciaRemisionPorConfirmar.aspx?intProveedorId=" + "<%=intProveedorId%>";
}

// Mandamos a imprimir la información
function cmdImprimir_onclick() {
 printContent();
 return(true);
}

//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaDetalleRemisionElectronica" onSubmit="return frmMercanciaDetalleRemisionElectronica_onsubmit()">
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
                : <a href="MercanciaEntradas.aspx" class="txdmigaja">Entradas</a> 
                : <a href="MercanciaConfirmarRemisionElectronica.aspx" class="txdmigaja">Confirmar 
                remisión electrónica</a> : </span><span class="txdmigaja"></span><span class="txdmigaja"></span><span class="txdmigaja"></span><span class="txdmigaja">Excepciones 
                en remisiones</span></div></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="583" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Detalle de remisiones electrónicas</span><br>
                      <script language="JavaScript">crearDatosSucursal()</script>
                      <br>
                    <div id="ToPrintHtmContenido"> <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> 
                      Remisión en proceso</span> 
                      <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr> 
                          <td width="125" class="tdtittablas">Proveedor:</td>
                          <td width="458" class="tdconttablas"><span class="txconttablasrojo"> 
                            <script language="JavaScript">strProveedorRazonSocial()</script>
                            </span></td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">No. de remisión:</td>
                          <td class="tdconttablas"><script language="JavaScript">strRemisionElectronicaNumero()</script> 
                          </td>
                        </tr>
                        <tr> 
                          <td class="tdtittablas">Fecha de remisión:</td>
                          <td class="tdconttablas"><script language="JavaScript">dtmRemisionElectronicaEmisionDocumento()</script> 
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
                    <br> <br> <P></P></td>
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
</HTML>
