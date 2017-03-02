<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaInventarios.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaInventarios" codePage="28592" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : MercanciaInventarios.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página que muestra el menu principal de Inventarios de Mercancias
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.A. Hernández D.
    ' Version       : 1.0
    ' Last Modified : Saturday, August 18, 2003
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


//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaInventarios">
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
              </span><span class="txdmigaja"><a href="Mercancia.aspx" class="txdmigaja">Mercancía</a><span class="txdmigaja"></span> 
              : Inventarios</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Inventarios</span><span class="txcontenido">En 
              esta parte usted puede consultar layouts y planogramas. Captura 
              y consultar negados y maximos.</span> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="40%"><a href="ConsultaInventarioRotativo.aspx" class="txsubtituloliga">Listados 
                    Rotativos</a></td>
                  <td width="9%" rowspan="8">&nbsp;</td>
                  <td width="40%"><a href="MercanciaInventariosPlanogramas.aspx" class="txsubtituloliga">Planogramas</a></td>
                </tr>
                <tr> 
                  <td width="40%" class="tdcontenidoliga">Consultar el listado 
                    para la toma de inventarios Rotativos.</td>
                  <td width="40%" class="tdcontenidoliga">Consultar lo planogramas 
                    y layouts de la sucursal.</td>
                </tr>
                <tr> 
                  <td width="40%"><a href="MercanciaInventariosProductosNegados.aspx" class="txsubtituloliga">Productos 
                    negados</a></td>
                  <td width="40%"><a href="MercanciaInventariosMaximosDeProductos.aspx" class="txsubtituloliga">Máximos 
                    de productos</a></td>
                </tr>
                <tr> 
                  <td width="40%" class="tdcontenidoliga">Registrar los productos 
                    negados en su sucursal, así como consultar el registro histórico 
                    de los mismos.</td>
                  <td width="40%" class="tdcontenidoliga">Consultar los máximos 
                    de productos, hacer sugerencias y consultar el archivo de 
                    sugerencias.</td>
                </tr>
                <tr> 
                  <td width="40%"><a href="MercanciaArticulosObsoletos.aspx" class="txsubtituloliga">Productos 
                    obsoletos</a></td>
                  <td width="40%"><a href="MercanciaInventariosCapturaLibre.aspx" class="txsubtituloliga">Inventario 
                    Libre</a></td>
                </tr>
                <tr> 
                  <td width="40%" class="tdcontenidoliga">Consultar los articulos 
                    obsoletos con inventario teórico.</td>
                  <td width="40%" class="tdcontenidoliga">En esta parte puede 
                    imprimir, capturar o consultar.</td>
                </tr>
                <tr> 
                  <td width="40%"><a href="MercanciaConsultarCerosFaltantes.aspx" class="txsubtituloliga">Ceros 
                    Faltantes</a></td>
                  <td width="40%"><a href="MercanciaConsultaDiasInventario.aspx" class="txsubtituloliga">Dias 
                    de Inventario</a></td>
                </tr>
                <tr> 
                  <td width="40%" class="tdcontenidoliga">Reporte de Ceros Faltantes.</td>
                  <td width="40%" class="tdcontenidoliga">Consulta los dias de 
                    inventario por división</td>
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
