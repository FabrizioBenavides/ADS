<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaSalidasTransferenciasOtraSucursal.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaSalidasTransferenciasOtraSucursal" codePage="28592" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : MercanciaSalidasTransferenciasOtraSucursal.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página en la cuál se puede Documentar lo relacionado con envío de Mercancía
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Jorge Tamez
    ' Version       : 1.0
    ' Last Modified : Lunes, Agosto 18, 2003
	'                 20 de Marzo 2007             Actualizacion por SAP
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

//-->
</script>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0"  onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaSalidasTransferenciasOtraSucursal">
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
            <td width="583" class="tdmigaja"><span class="txdmigaja">Est&aacute; 
              en : </span><a href="Mercancia.aspx" class="txdmigaja">Mercanc&iacute;a</a><span class="txdmigaja"> 
              : <a href="MercanciaSalidas.aspx" class="txdmigaja">Salidas</a> 
              : Transferencias a otra sucursal</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Transferencias 
              a otra sucursal</span><span class="txcontenido">En esta parte usted 
              puede documentar lo relacionado con env&iacute;o de mercanc&iacute;a 
              manual o autom&aacute;tico.</span> <table width="98%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="40%"><a href="MercanciaProcesarEnviosAutomaticos.aspx" class="txsubtituloliga">Procesar 
                    env&iacute;os autom&aacute;ticos</a></td>
                  <td width="9%" rowspan="6">&nbsp;</td>
                  <td width="40%"><a href="MercanciaCapturarTransferenciaManual.aspx" class="txsubtituloliga">Capturar 
                    transferencias manuales</a></td>
                </tr>
                <tr> 
                  <td width="40%" class="tdcontenidoliga">Procesar el env&iacute;o 
                    de mercanc&iacute;a conforme a las recomendaciones centrales.</td>
                  <td width="40%" class="tdcontenidoliga">Capturar manualmente 
                    las transferencias que no sean autom&aacute;ticas.</td>
                </tr>
                <tr> 
                  <td width="40%"><a href="MercanciaConsultarArchivoDeEnvios.aspx" class="txsubtituloliga">Consultar 
                    archivo de env&iacute;os</a></td>
                  <td width="40%"><a href="MercanciaConsultarSalidasProducto.aspx" class="txsubtituloliga">Consultar 
                    salidas por producto</a></td>
                </tr>
                <tr> 
                  <td width="40%" class="tdcontenidoliga">Consultar el registro 
                    hist&oacute;rico de env&iacute;os a otras sucursales.</td>
                  <td width="40%" class="tdcontenidoliga">Consultar el registro 
                    hist&oacute;rico de salidas por producto.</td>
                </tr>
                <tr> 
                  <td width="40%"><a href="MercanciaImpresionFormatoTrasferencias.aspx" class="txsubtituloliga">Imprimir 
                    formato para transferencias</a></td>
                  <td width="40%">&nbsp;</td>
                </tr>
                <tr> 
                  <td width="40%" class="tdcontenidoliga">Imprimir el formato 
                    necesario para registrar f&iacute;sicamente las mercanc&iacute;as 
                    a enviar.</td>
                  <td width="40%" class="tdcontenidoliga">&nbsp;</td>
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
</html>
