<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MercanciaInsumosMateriaPrimaConfirmada.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaInsumosMateriaPrimaConfirmada" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>

<HTML>
	<HEAD>
		<title>Sistema Administrador de Sucursal</title>
		<%
'====================================================================
' Page          : MercanciaInsumosMateriaPrimaConfirmada.aspx
' Title         : Administracion POS y BackOffice
' Description   : Página de Detalle de compra directa capturada
' Copyright     : 2014
' Company       : Deintec
' Author        : Carlos Vazquez
' Version       : 1.0
' Last Modified : Jueves, 14 de Agosto 2014
'                 
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
        document.write("<%=intCompaniaId%>" + " - " + "<%=intSucursalId%>");
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
// Load
function window_onload() {
    MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
    document.forms[0].action = "<%=strFormAction%>";      
   return(true);                      
}

function cmdImprimir_onclick() {
    document.ifrPageToPrint.document.all.divContenido.innerHTML = document.all.divImpresionHTML.innerHTML;        
    document.ifrPageToPrint.focus();
    window.print(); 
    return(true);
}

//-->
					</script>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
		<form action="about:blank" method="post" name="frmMercanciaFacturaInsumosConfirmada">
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
				</tr>
				<tr>
					<td valign="top" height="34" width="100%"><img src="../static/images/pixel.gif" width="1" height="34"></td>
				</tr>
				<tr>
					<td width="100%">
						<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
								<td width="583" class="tdmigaja"><span class="txdmigaja">Está en : 
              </span><a href="Mercancia.aspx" class="txdmigaja">Mercancía</a><span class="txdmigaja"> 
              : <a href="MercanciaEntradas.aspx" class="txdmigaja">Entradas</a></span><span class="txdmigaja"> 
              : </span><span class="txdmigaja"></span><span class="txdmigaja"><a href="MercanciaEntradasComprasDirectas.aspx" class="txdmigaja">Compras 
											directas </a>
									</span><span class="txdmigaja"> : </span><span class="txdmigaja"></span><span class="txdmigaja"></span><span class="txdmigaja">Capturar 
              insumos de materia prima</span></td>
								<td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
							</tr>
							<tr>
								<td width="10">&nbsp;</td>
								<td width="583" valign="top">
									<table width="100%" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td width="99%" valign="top" class="tdtablacont">
												<script language="JavaScript">crearDatosSucursal()</script>
												<br>
												<table width="100%" cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td class="txsubtitulo" vAlign="middle">Insumos de Materia Prima Registrados con Folio:
															<%=intFacturaInsumosFolio%>
														</td>
													</tr>
												</table>
												<table class="tdenvolventetablas" width="100%">
													<tr>
														<td class="tdtittablas3" align="left" width="80%">Proveedor</td>
														<td class="tdtittablas3" align="left" width="20%"><%--Orden--%></td>
													</tr>
													<tr>
														<td class="campotablaresultadoenvolventeazul" align="left" width="80%"><%=strProveedorNombreId%>
															-
															<%=strProveedorRazonSocial%>
														</td>
														<td class="campotablaresultadoenvolventeazul" align="left" width="20%"></td>
													</tr>
												</table>
												<br>
												<table class="tdenvolventetablas" width="100%">
													<tr>
														<td class="tdtittablas3" align="left" width="35%">No Factura</td>
														<td class="tdtittablas3" align="left" width="20%">Fecha Factura</td>
														<td class="tdtittablas3" align="left" width="20%">Fecha Recepción</td>
														<td class="tdtittablas3" align="left" width="25%">Total Facturado</td>
													</tr>
													<tr>
														<td class="campotablaresultadoenvolventeazul" align="left" width="35%"><%=strFacturaInsumosNumeroFactura%></td>
														<td class="campotablaresultadoenvolventeazul" align="left" width="20%"><%=strFacturaInsumosFechaFactura%></td>
														<td class="campotablaresultadoenvolventeazul" align="left" width="20%"><%=strFacturaInsumosFechaRecepcion%></SCRIPT></td>
														<td class="campotablaresultadoenvolventeazul" align="left" width="25%"><%=fltFacturaInsumosImporteTotalFactura%></SCRIPT></td>
													</tr>
												</table>
												
												<br>
												
												<table cellSpacing="0" cellPadding="0" border="0" width="100%">
													
													<tr>
														<td>
															<%=strDetalleFactura%>
															
															<div id="divImpresionHTML" style="DISPLAY:none">
																 
																<%=strImpresionFactura%>
																
																<script language="JavaScript">
																    crearTablaFirmaCompras()
																</script>
																
															</div>
															
															<input	name="cmdImprimir" 
																	type="button" 
																	class="boton" 
																	value="Imprimir" 
																	onClick="return cmdImprimir_onclick()">
														</td>
													</tr>
													
												</table>
												
											</td>
										</tr>
										
									</table>
								</td>
								<td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
							</tr>
							<tr>
								<td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<script language="JavaScript">
	<!--
    new menu (MENU_ITEMS, MENU_POS);
    new menu (MENU_ITEMS2, MENU_POS2);
    //-->
			</script>
		</form>
		<iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0"></iframe>
	</body>
</HTML>
