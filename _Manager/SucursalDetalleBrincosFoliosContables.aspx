<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalDetalleBrincosFoliosContables.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsSucursalDetalleBrincosFoliosContables"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="css/menu.css" rel="stylesheet" type="text/css">
		<link href="css/estilo.css" rel="stylesheet" type="text/css">
		<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
		<script language="JavaScript" src="js/calendario.js"></script>
		<script language="JavaScript" src="js/cal_format00.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
		<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "SucursalConsultarBrincosContables.aspx?strCmd=Consultar";
  document.forms[0].elements["txtFechaInicial"].value = "<%= strFechaInicial %>";
  document.forms[0].elements["txtFechaFinal"].value = "<%= strFechaFinal %>";
}

function cmdRegresar_onclick() {
  document.forms[0].submit();
}

function strHTMLAlcance() {
  document.write("<%= strHTMLAlcance %>");
}

function strFolioNombre() {
  document.write("<%= strFolioNombre %>");
}

function intTotalBrincos() {
  document.write("<%= intTotalBrincos %>");
}

function strFoliosFaltantesHTML() {
	document.write("<%= strFoliosFaltantesHTML %>");
	return(true);
}


// done hiding -->
		</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
		<form method="post" action="about:blank" name="frmMain" onSubmit="return blnFormValidator(this)">
			<input name="txtFechaInicial" id="txtFechaInicial" type="hidden"> <input name="txtFechaFinal" id="txtFechaFinal" type="hidden">
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeader()</script></td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td width="770" class="tdtab">Está en : Sucursal : 
							Mercancías : Consultar brincos 
							en folios contables : Detalle de brincos en folios contables
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent"><h1>Detalle de brincos en folios contables
						</h1>
						<table width="60%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="18%" class="tdtexttablebold">Alcance:</td>
								<td width="82%" class="tdcontentableblue"><strong><script language="javascript">strHTMLAlcance();</script></strong></td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Tipo de folio:</td>
								<td class="tdcontentableblue"><strong>Folios de <script language="javascript">strFolioNombre();</script> </strong>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Brincos:</td>
								<td class="tdcontentableblue"><strong><script language="javascript">intTotalBrincos();</script></strong></td>
							</tr>
						</table>
						<br>
						<h2>Folios faltantes
						</h2>
						<br>
						<script language="javascript">strFoliosFaltantesHTML();</script>
						<br>
				      <input name="btnConfigurarConsulta" type="button" class="button" value="Configurar otra consulta" onClick="cmdRegresar_onclick();">&nbsp;
				      <input name="btnInprimirReporte" type="button" class="button" value="Imprimir reporte" onClick="window.print();">
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaFooterCentral()</script></td>
				</tr>
			</table>
			<script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
			</script>
		</form>
	</body>
</HTML>
