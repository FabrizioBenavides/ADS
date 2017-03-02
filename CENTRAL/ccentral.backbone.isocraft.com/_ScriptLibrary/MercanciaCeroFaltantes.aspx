<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="MercanciaCeroFaltantes.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaCeroFaltantes" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons" %>
<HTML>
	<HEAD>
		<title>Sistema Administrador de Sucursal</title>
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

function strCompaniaSucursal(){
    document.write(<%=intCompaniaId%> + " - " + <%=intSucursalId%>);
	return(true);
}
function strSucursalNombre() {
    document.write("<%=strSucursalNombre%>");
    return(true);
}
function strGetCustomDateTime() {
    document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
    return(true);
}

//-->
					</script>
	</HEAD>
	<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
		<form action="about:blank" method="post" name="frmMercanciaCeroFaltantes">
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
              </span><a href="Mercancia.aspx" class="txdmigaja">Mercancía</a><span class="txdmigaja"> 
              : Cero Faltantes</span></td>
								<td width="182" class="tdfechahora"><script language="JavaScript">strGetCustomDateTime()</script>
								</td>
							</tr>
							<tr>
								<td width="10">&nbsp;</td>
								<td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Cero Faltantes</span><span class="txcontenido">En 
              esta parte usted puede consultar todo lo relacionado con los faltantes 
              de mercancía a su sucursal.</span>
									<table width="98%" border="0" cellpadding="0" cellspacing="0">
										<tr>
											<td width="266"><a href="MercanciaCeroFaltantesResumen.aspx" class="txsubtituloliga">Cero 
													Faltantes - Resumen</a></td>
											<td width="14" rowspan="6">&nbsp;</td>
											<td width="277"><a href="MercanciaCeroFaltantesNivelDeProductos.aspx" class="txsubtituloliga">Cero 
													Faltantes - Nivel de Productos</a></td>
										</tr>
										<tr>
											<td width="266" class="tdcontenidoliga">Consulta del Resumen de Ceros Faltantes 
												para las Sucursales involucradas con la Sucursal que esta realizando la 
												consulta.</td>
											<td width="277" class="tdcontenidoliga">Consulta de Cero Faltantes a nivel detalle 
												de productos.</td>
										</tr>
										<tr>
											<td width="266"></td>
											<td width="266"></td>
										</tr>
										<tr>
											<td width="266" class="tdcontenidoliga"></td>
											<td width="266" class="tdcontenidoliga"></td>
										</tr>
									</table>
								</td>
								<td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
							</tr>
							<tr>
								<td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script>
								</td>
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
	</body>
</HTML>
