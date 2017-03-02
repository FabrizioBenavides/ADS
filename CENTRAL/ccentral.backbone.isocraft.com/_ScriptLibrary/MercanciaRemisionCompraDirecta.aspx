<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaRemisionCompraDirecta.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaRemisionCompraDirecta" codePage="28592" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<!doctype html public "-//w3c//dtd html 4.0 transitional//en">
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  
    '====================================================================
    ' Page          : MercanciaRemisionCompraDirecta.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   :  
    ' Copyright     : 2012 All rights reserved.
    ' Company       : Farmacias Benavides
    ' Author        : [JAHD] 
    ' Version       : 1.0
    ' Last Modified : 
    '                 16 de Marzo 2012 [JAHD]  remisiones de compra directa
	'                 15 de Octubre 2012 [JAHD] Ruta de documentos PDF
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
    document.forms[0].action = "<%=strFormAction%>";
    return(true);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

function cmdBuscar_onclick() {
document.forms(0).submit();
}
function cmdRegresar_onclick() {
   window.location.href = "MercanciaEntradasComprasDirectas.aspx";  
   return(true);
}

function strImprimeFactura(strFactura) { 
    var url = strUrlADSDoc() + 'PDF/Facturas/' + strFactura  
    var WinVerFactura = window.open(url,'PopFactura','width=820,height=620,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );

}

//-->
		</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaRemisionCompraDirecta">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td height="34"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td><table width="780" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><span class="txdmigaja">Está en : 
              </span><a href="Mercancia.aspx" class="txdmigaja"> Mercancía</a> 
              <span class="txdmigaja">:<a href="MercanciaEntradas.aspx" class="txdmigaja">Entradas</a>: 
              <a class="txdmigaja" href="MercanciaEntradasComprasDirectas.aspx">Compras 
              Directas</a></span><span class="txdmigaja"> </span><span class="txdmigaja">: 
              </span><span class="txdmigaja"> </span><span class="txdmigaja"></span><span class="txdmigaja">Impresión 
              Factura</span></td>
            <td width="182" class="tdfechahora"><script language="JavaScript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <span class="txtitulo">Imprimir Facturas del Proveedor</span> 
                    <span class="txsubtitulo">Buscar la NOTA DE VENTA impresa 
                    en el documento fisico que les dejo el proveedor.<br>
                    Igual a a siguiente imagen.<br>
                    <img src="../static/images/NOTAVENTA.jpg"  width="258"  height="373"  align="absmiddle"> 
                    <br>
                    Capturar en una casilla las letra y en otra casilla los numeros. 
                    <br>
                    </span> <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Datos 
                    Remisión</span> <table width="100%" class="tdenvolventetablas">
                      <tr> 
                        <td width="10%" class="tdtittablas3" >Remisión:</td>
                        <td width="70%" class="tdtittablas3"><input name="txtSerieRemision"  id="txtSerieRemision"  type="text" class="campotabla" value='<%= Request.Form("txtSerieRemision") %>'  size="08" maxlength="08"> 
                          <input name="txtNumeroRemision" id="txtNumeroRemision" type="text" class="campotabla" value='<%= Request.Form("txtNumeroRemision") %>' size="12" maxlength="12"> 
                        </td>
                        <td width="20%" class="tdtittablas3" align="center"  vAlign="middle"><input class="boton" id="cmdBuscar" onclick="return cmdBuscar_onclick()" type="button" value="Buscar" name="cmdBuscar"> 
                        </td>
                      </tr>
                    </table>
                    <br> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td valign="top"><%=strListaFacturasHTML%></td>
                      </tr>
                    </table>
                    <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()">	
                  </td>
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
</body>
</HTML>
