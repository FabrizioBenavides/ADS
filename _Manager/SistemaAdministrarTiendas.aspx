<%@ Page CodeBehind="SistemaAdministrarTiendas.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaAdministrarTiendas" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
		<script id="clientEventHandlersJS" language="javascript">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  <%=strCboDireccion%>
  <%=strCboZona%>
  if (document.forms[0].elements["cmdNavegadorRegistrosAgregar"] != null) {
    document.forms[0].elements["cmdNavegadorRegistrosAgregar"].disabled = <%= strBooleanoSucursalesDisponibles %>;
  }
}

function cmdNavegadorRegistrosAgregar_onclick(intDireccionOperativaId,intZonaOperativaId){
    if((intDireccionOperativaId == 0) || (intZonaOperativaId == 0)){
        alert("Para agregar una Tienda \n\r es necesario seleccionar una Dirección Operativa y una Zona Operativa");
    }
    else{
        document.forms[0].action += "?strCmd=Agregar";
        document.forms[0].submit();
    }
}

function blnFormValidator(theForm) {
  
  var blnReturn = false;
  
  if (document.forms[0].elements("cboDireccionOperativa").selectedIndex > 0){
    if (document.forms[0].elements("cboZonaOperativa").selectedIndex > 0){
      blnReturn = true
	}
	else{
	  blnReturn = false
	  alert("Debe selecionar una Zona Operativa para ralizar \n\r la administración de tiendas");
	  document.forms[0].elements("cboZonaOperativa").focus();
	}
  }
  else {
	  blnReturn = true
  }

  return (blnReturn);
}

function cboZonaOperativa_onchange() {
  if (document.forms[0].elements["cboZonaOperativa"].selectedIndex > 0) {
    document.forms[0].submit();
  }
}

function cboDireccionOperativa_onchange() {
  document.forms[0].submit();
}

//-->
		</script>
	</HEAD>
	<body onload="return window_onload()">
		<form method="post" action="about:blank" name="frmSistemaAdministrarTiendas" onSubmit="return blnFormValidator(this)">
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeader()</script></td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td width="770" class="tdtab">Está en : Sistema : Administrar tiendas
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent"><h1>Administrar tiendas</h1>
						<p>Aquí podrá dar de alta o modificar los datos de una tienda, incluyendo las 
							sucursales que tiene vinculadas. Solo se podrán agregar tiendas si existen 
							sucursales disponibles para la dirección y zona seleccionadas.
						</p>
						<table width="50%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="14%" class="tdtexttablebold">Dirección:</td>
								<td width="86%" class="tdpadleft5"><select name="cboDireccionOperativa" class="field" language="javascript" onchange="return cboDireccionOperativa_onchange()">
										<option value="0" selected>Elija una dirección</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Zona:</td>
								<td class="tdpadleft5"><select name="cboZonaOperativa" class="field" language="javascript" onchange="return cboZonaOperativa_onchange()">
										<option value="0" selected>Elija una zona</option>
									</select>
								</td>
							</tr>
						</table>
						<br>
						<%= strRecordBrowserHTML() %>
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
