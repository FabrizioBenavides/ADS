<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" enableViewState="False" Explicit="True" Trace="False" Strict="True" CodeBehind="popDatosSucursal.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popDatosSucursal" codePage="28592" %>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta content="Javascript Menu" name="description">
		<meta content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control"
			name="keywords">
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
		<script language="javascript" id="clientEventHandlersJS">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora     = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";  
}
function cmdBuscar_onclick() {
   document.forms[0].action = "<%=strFormAction%>?strCmd=Consultar";
   document.forms[0].target="ifrOculto";
   document.forms[0].submit();
   document.forms[0].target='';  
}

function fnConsultar(intCompaniaId,intSucursalId,strCentroLogisticoId,strSucursalNombre,intDireccionOperativaId,strDireccionOperativaNombre,intZonaOperativaId,strZonaOperativaNombre,intEstadoId,strEstadoNombre,intCiudadId,strCiudadNombre,intEncontrada) {
   document.forms[0].elements["txtCompaniaId"].value = intCompaniaId;
   document.forms[0].elements["txtSucursalId"].value = intSucursalId;
   document.forms[0].elements["txtCentroLogisticoId"].value = strCentroLogisticoId;
   document.forms[0].elements["txtSucursalNombre"].value    = strSucursalNombre;
   
   document.forms[0].elements["txtDireccionOperativaId"].value     = intDireccionOperativaId;
   document.forms[0].elements["txtDireccionOperativaNombre"].value = strDireccionOperativaNombre;

   document.forms[0].elements["txtZonaOperativaId"].value     = intZonaOperativaId;
   document.forms[0].elements["txtZonaOperativaNombre"].value = strZonaOperativaNombre;
   
   document.forms[0].elements["txtEstadoId"].value     = intEstadoId;
   document.forms[0].elements["txtEstadoNombre"].value = strEstadoNombre;
   document.forms[0].elements["txtCiudadId"].value     = intCiudadId;
   document.forms[0].elements["txtCiudadNombre"].value = strCiudadNombre;
   
   if (intEncontrada==0) { 
       alert("No Encontrada");
   }
}


		</script>
	</HEAD>
	<body onload="return window_onload()">
		<form name="frmDatosSucursal" action="about:blank" method="post">
			<table cellSpacing="0" cellPadding="0" width="600" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaHeaderPop2()</script>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="tdgeneralcontentpop">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="tdtexttablebold" vAlign="top" width="10%"><h2>Sucursal:</h2>
								</td>
								<td class="tdcontentableblue" vAlign="top" width="10%"><input class="field" id="txtBuscaSucursal" type="text" maxLength="6" size="6" name="txtBuscaSucursal">
								</td>
								<td class="tdcontentableblue" vAlign="top" width="5%"><span class="tdpadleft5"><input class="button" id="cmdBuscar" onclick="return cmdBuscar_onclick()" type="button"
											value="Buscar" name="cmdBuscar"> </span>
								</td>
								<td class="tdcontentableblue" vAlign="top" width="85%">&nbsp; Buscar por numero de 
									sucursal [CCSSSS] o por centro logistico</td>
							</tr>
						</table>
						<br>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="tdtexttablebold">Compañia
								</td>
								<td class="tdtexttablebold">Sucursal
								</td>
								<td class="tdtexttablebold">Centro logistico
								</td>
								<td class="tdtexttablebold">Nombre
								</td>
							</tr>
							<tr>
								<td class="tdcontentableblue"><input class="field" id="txtCompaniaId" readOnly type="text" size="6" name="txtCompaniaId">
								</td>
								<td class="tdcontentableblue"><input class="field" id="txtSucursalId" readOnly type="text" size="6" name="txtSucursalId">
								</td>
								<td class="tdcontentableblue"><input class="field" id="txtCentroLogisticoId" readOnly type="text" size="10" name="txtCentroLogisticoId">
								</td>
								<td class="tdcontentableblue"><input class="field" id="txtSucursalNombre" readOnly type="text" size="60" name="txtSucursalNombre">
								</td>
							</tr>
						</table>
						<br>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="tdtexttablebold" colSpan="2">Dirección Operativa
								</td>
								<td class="tdtexttablebold" colSpan="2">Zona Operativa
								</td>
							</tr>
							<tr>
								<td class="tdcontentableblue"><input class="field" id="txtDireccionOperativaId" readOnly type="text" size="6" name="txtDireccionOperativaId">
								</td>
								<td class="tdcontentableblue"><input class="field" id="txtDireccionOperativaNombre" readOnly type="text" size="44" name="txtDireccionOperativaNombre">
								</td>
								<td class="tdcontentableblue"><input class="field" id="txtZonaOperativaId" readOnly type="text" size="6" name="txtZonaOperativaId">
								</td>
								<td class="tdcontentableblue"><input class="field" id="txtZonaOperativaNombre" readOnly type="text" size="44" name="txtZonaOperativaNombre">
								</td>
							</tr>
						</table>
						<br>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="tdtexttablebold" colSpan="2">Estado
								</td>
								<td class="tdtexttablebold" colSpan="2">Ciudad
								</td>
							</tr>
							<tr>
								<td class="tdcontentableblue"><input class="field" id="txtEstadoId" readOnly type="text" size="6" name="txtEstadoId">
								</td>
								<td class="tdcontentableblue"><input class="field" id="txtEstadoNombre" readOnly type="text" size="44" name="txtEstadoNombre">
								</td>
								<td class="tdcontentableblue"><input class="field" id="txtCiudadId" readOnly type="text" size="6" name="txtCiudadId">
								</td>
								<td class="tdcontentableblue"><input class="field" id="txtCiudadNombre" readOnly type="text" size="44" name="txtCiudadNombre">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="600" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaFooterPop2()</script>
					</td>
				</tr>
			</table>
		</form>
		<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
	</body>
</HTML>
