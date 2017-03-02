<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalSenalizacionBusquedaPromocionesTextoPromocion.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalSenalizacionBusquedaPromocionesTextoPromocion" %>
<HTML>
	<HEAD>
		<title>Benavides: Detalle de Promoción</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="css/menu.css" rel="stylesheet" type="text/css">
		<link href="css/estilo.css" rel="stylesheet" type="text/css">
		<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
		<script id="clientEventHandlersJS" language="javascript">

<!--
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";


function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";
}

function cmdCancelar_onclick() {
    window.close();
}

//-->
		</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
		<form name="frmMain" action="about:blank" method="post" runat="server" ID="Form2">
			<table style="width:780px;" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td class="tdtab">Está en : <a href="../_Manager/SucursalHome.aspx">Sucursal</a> : Promociones Texto
					</td>
				</tr>
			</table>
			<table style="width:780px;" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent">
						<h2>Consultar detalle de Promoción</h2>
						<br>
						<table style="width:750px;" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td style="width:150px" class="tdtexttablebold">Formato:</td>
								<td class="tdconttablas" style="width:650px" align='left'>
									<%= strFormato()%>
								</td>
							</tr>
                            <tr>
								<td style="width:150px" class="tdtexttablebold">Promoción:</td>
								<td class="tdconttablas" style="width:650px" align='left'>
									<%= strPromocion()%>
								</td>
							</tr>
							
							<tr>
                                
								<td style="width:150px" class="tdtexttablebold">Imagen a mostrar:</td>
								<td class="tdconttablas" style="width:650px" align='left'>
                                    <%= strNombreImagen()%>
								</td>
							</tr>
							<tr>
								<td colSpan="2" style="text-align:center">
								    <img src="<%= strRutaImagen()%>" style="margin:10px; border:1px solid #ccc; width:300px; height:275px;" >
								</td>
							</tr>
							<tr>
								<td colspan="2" class="tdpadleft5" style="text-align:center">
                                    <input 
                                        style="margin:20px;"
                                        class="button" id="cmdRegresar" 
                                        onclick="return cmdCancelar_onclick()" 
                                        type="button" value="Regresar" name="cmdRegresar"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table style="width:780px;"  border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaFooterCentral()</script></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
