<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaDetalleCompraDirecta.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaDetalleCompraDirecta" codePage="28592"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
'====================================================================
' Page          : MercanciaDetalleCompraDirecta.aspx
' Title         : Administracion POS y BackOffice
' Description   : Página de consulta de Detalle de compra directa capturada
' Copyright     : 2008
' Company       : BENAVIDES
' Author        : J.Antonio Hernández Dávila
' Version       : 1.0
' Last Modified :Lunes, Noviembre 10, 2003 
'                Jueves, 14 de Febrero 2008
'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
'                Viernes 29 Agosto 2014 Carlos Vazquez (Control de Cafe)    
'====================================================================	
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/tools.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--

var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";


function window_onload() {
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action = "<%=strFormAction%>"; 
  
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

function cmdRegresar_onclick() {    
    window.location = "MercanciaConsultaComprasDirectas.aspx?cmdConsultar=Consultar&rdoFiltroConsulta="+"<%=rdoFiltroConsulta%>" + "&rdoOrdenConsulta="+ "<%=rdoOrdenConsulta%>";
}

function cmdImprimir_onclick() {
  document.ifrPageToPrint.document.all.divContenido.innerHTML = document.all.divImpresionHTML.innerHTML;        
  document.ifrPageToPrint.focus();
  window.print(); 
  return(true);
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaDetalleCompraDirecta" action="about:blank" method="post">
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
              </span><a href="Mercancia.aspx" class="txdmigaja">Mercancía</a><span class="txdmigaja"> 
              : <a href="MercanciaEntradas.aspx" class="txdmigaja">Entradas</a></span><span class="txdmigaja"> 
              : </span><span class="txdmigaja"></span><span class="txdmigaja"><a href="MercanciaEntradasComprasDirectas.aspx" class="txdmigaja">Compras 
              directas </a></span><span class="txdmigaja"> : </span><span class="txdmigaja">Detalle 
              de compra directa</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"> <script language="JavaScript">crearDatosSucursal()</script> 
              <br> <table width="99%" cellSpacing="0" cellPadding="0" border="0">
                <tr> 
                  <td class="txsubtitulo" vAlign="middle"  >Compra Registrada 
                    con Folio: <%=intCompraDirectaFolio%></td>
                </tr>
              </table>
              <table class="tdenvolventetablas" width="99%">
                <tr> 
                  <td class="tdtittablas3" align="left" width="80%">Proveedor</td>
                  <td class="tdtittablas3" align="left" width="20%">Orden</td>
                </tr>
                <tr> 
                  <td class="campotablaresultadoenvolventeazul" align="left" width="80%"><%=strProveedorNombreId%> 
                    - <%=strProveedorRazonSocial%></td>
                  <td class="campotablaresultadoenvolventeazul" align="left" width="20%"><%=intFolioOrdenId%></td>
                </tr>
              </table>
              <br> <table class="tdenvolventetablas" width="99%">
                <tr> 
                  <td class="tdtittablas3" align="left" width="35%">No Factura</td>
                  <td class="tdtittablas3" align="left" width="20%">Fecha Factura</td>
                  <td class="tdtittablas3" align="left" width="20%0">Fecha Recepción</td>
                  <td class="tdtittablas3" align="left" width="25%">Total Facturado</td>
                </tr>
                <tr> 
                  <td class="campotablaresultadoenvolventeazul" align="left" width="35%"><%=strCompraDirectaNumeroFactura%></td>
                  <td class="campotablaresultadoenvolventeazul" align="left" width="20%"><%=strCompraDirectaFechaFactura%></td>
                  <td class="campotablaresultadoenvolventeazul" align="left" width="20%"><%=strCompraDirectaFechaRecepcion%></script></td>
                  <td class="campotablaresultadoenvolventeazul" align="left" width="25%"><%=fltCompraDirectaImporteTotalFactura%></script></td>
                </tr>
              </table>
              <br> <table cellSpacing="0" cellPadding="0" border="0" width="99%">
                <tr> 
                  <td> <%=strDetalleCompra%> <div id="divImpresionHTML" style="display:none"><%=strImpresionCompra%> 
                      <script language="JavaScript">crearTablaFirmaCompras()</script>
                    </div>
                    <input name="cmdRegresar" type="button" class="boton" value="Otro Detalle" onClick="return cmdRegresar_onclick()"> 
                    &nbsp; <input name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()"> 
                  </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
        </table></td>
    </tr>
    <tr> 
      <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
    </tr>
  </table></td>
  </tr> </table> 
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
</script>
</form>
<iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0"></iframe>
</body>
</html>
