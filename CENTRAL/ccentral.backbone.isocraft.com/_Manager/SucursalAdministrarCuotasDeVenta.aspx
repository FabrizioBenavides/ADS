<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="SucursalAdministrarCuotasDeVenta.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsSucursalAdministrarCuotasDeVenta" codePage="28592"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  <%=strCboDireccion%>
  <%=strCboZona%>
  <%=strCboSucursal%>
  <%=strCboMesConsultar%>
  <%if blnConsultarTodos = 1 then%>
	  document.forms[0].elements["cboMes"].options[1].selected=true;
  <%end if%>
}

function RecargarPagina_onchange(){
	document.forms[0].submit();
	return(true);
}

function ValidarForma(){
	if (document.forms[0].elements["cboDireccionOperativa"].options[0].selected == true){
		alert("Favor de seleccionar una Dirección Operativa.");
		document.forms[0].elements["cboDireccionOperativa"].focus();
		return(false);
	}
	else if (document.forms[0].elements["cboZonaOperativa"].options[0].selected == true){
		alert("Favor de seleccionar una Zona Operativa.");
		document.forms[0].elements["cboZonaOperativa"].focus();
		return(false);
	}
	else if (document.forms[0].elements["cboSucursal"].options[0].selected == true){
		alert("Favor de seleccionar una Sucursal.");
		document.forms[0].elements["cboSucursal"].focus();
		return(false);
	}
	else if (document.forms[0].elements["cboMes"].options[0].selected == true){
		alert("Favor de seleccionar un mes a consultar.");
		document.forms[0].elements["cboMes"].focus();
		return(false);
	}
	else{
		return(true);
	}
}

function Consultar_onclick(){
	if (ValidarForma()){
		document.forms[0].action = "<%= strThisPageName %>?strCmd=Buscar";
		document.forms[0].submit();
		return(true);
	}
	else{
		return(false);
	}
}

function cmdNavegadorRegistrosAgregar_onclick(intDireccionId, intZonaId) {
		document.forms[0].action = "SucursalAsignarCuotasDeVenta.aspx?intDireccionId=" + intDireccionId + "&intZonaId=" + intZonaId + "&strCmd=Agregar";
		document.forms[0].submit();
		return(true);
//  return Pop("popAsignarCuotaDeVenta.aspx?intDireccionId=" + intDireccionId + "&intZonaId=" + intZonaId, "360", "440")
}

//-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSucursalAdministrarCuotasDeVenta">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : Sucursal : Administrar cuotas de venta</td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Administrar cuotas de venta</h1>
      <p>Para asignar o editar una cuota de venta de una sucursal, primero defina sucursal y mes, y luego asigne la cuota.</p>
      <h2>Configurar consulta de sucursales</h2>
      <table width="44%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="76" class="tdtexttablebold">* Direcci&oacute;n:</td>
          <td width="235" class="tdpadleft5">
			<select name="cboDireccionOperativa" class="field" onchange="return RecargarPagina_onchange()">
              <option value="0">>>Elija una direcci&oacute;n<<</option>
            </select>
          </td>
        </tr>
        <tr>
          <td class="tdtexttablebold">* Zona:</td>
          <td class="tdpadleft5">
			<select name="cboZonaOperativa" class="field" onchange="return RecargarPagina_onchange()">
              <option value="0">>>Elija una zona<<</option>
            </select>
          </td>
        </tr>
        <tr>
          <td class="tdtexttablebold">* Sucursal:</td>
          <td class="tdpadleft5">
			<select name="cboSucursal" class="field">
              <option value="0">>>Elija una sucursal<<</option>
            </select>
          </td>
        </tr>
        <tr>
          <td class="tdtexttablebold">* Mes:</td>
          <td class="tdpadleft5">
			<select name="cboMes" class="field">
              <option value="0">>>Elija un mes a desplegar<<</option>
              <option value="01/01/2000">Todos</option>
            </select>
          </td>
        </tr>
      </table>
      <br>
      <input name="btnConsultar" type="button" class="button" value="Realizar consulta" onclick="return Consultar_onclick()">
      <br>
      <br>
      <!-- Se imprime el Record Browser -->
      <%=RecordBrowserHTML%>
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
</html>