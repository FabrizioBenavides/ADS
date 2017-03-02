<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="SucursalAsignarCuotasDeVenta.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsSucursalAsignarCuotasDeVenta" codePage="28592"%>
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
  <%=strCboSucursal%>
  <%=strCboMesConsultar%>
  document.forms[0].elements["txtCuotaDeVenta"].value = "<%=intCuotaVenta%>";
  document.forms[0].elements["txtNombreCuota"].value = "<%=strNombreCuota%>";
  document.forms[0].elements["cboSucursal"].disabled=true;
}

function strZonaOperativaNombre(){
	document.write("<%=strZonaOperativaNombre%>");
}

function ValidarForma(){
	if (document.forms[0].elements["cboSucursal"].options[0].selected == true){
		alert("Favor de seleccionar una Sucursal.");
		document.forms[0].elements["cboSucursal"].focus();
		return(false);
	}
	<%if strCmd <> "Editar" then%>
	else if (document.forms[0].elements["cboMes"].options[0].selected == true){
		alert("Favor de seleccionar un mes.");
		document.forms[0].elements["cboMes"].focus();
		return(false);
	}
	<%end if%>
	else if (document.forms[0].elements["txtNombreCuota"].value == ""){
		alert("Favor escribir el nombre de la cuota.");
		document.forms[0].elements["txtNombreCuota"].focus();
		return(false);
	}
	else if (document.forms[0].elements["txtCuotaDeVenta"].value == "0"){
		alert("Favor escribir el valor de la cuota.");
		document.forms[0].elements["txtCuotaDeVenta"].focus();
		return(false);
	}
	else{
		return(true);
	}
}

function cmdAsignarCuota_onclick(){
    document.forms[0].elements["cboSucursal"].disabled=false;
	if (ValidarForma()){
		document.forms[0].action = "<%= strThisPageName %>?" + "<%=strAccion%>";
		document.forms[0].submit();
		return(true);
	}
	else{
		return(false);
	}
}

function strPrintAsignarOrModificar(){
	<%if strCmd <> "Editar" then%>
		document.write("Asignar ");
	<%else%>
		document.write("Modificar ");
	<%end if%>
}

function cmdCancelar_onclick() {
	window.location.href = "SucursalAdministrarCuotasDeVenta.aspx";;
}

//-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSucursalAsignarCuotasDeVenta">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : Sucursal : Asignar cuotas de venta</td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1><script language="javascript">strPrintAsignarOrModificar()</script> cuotas de venta</h1>
      <p>Para asignar o editar una cuota de venta de una sucursal, primero defina sucursal y mes, y luego asigne la cuota.</p>
      <h2><script language="javascript">strPrintAsignarOrModificar()</script> cuotas de venta</h2>
      <table width="44%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="100" class="tdtexttablebold">Zona: </td>
          <td width="200" class="tdcontentableblue"><script language="javascript">strZonaOperativaNombre()</script></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Sucursal:</td>
          <td class="tdpadleft5">
            <select name="cboSucursal" class="field" >
              <option value="0">Elija una sucursal</option>
            </select>
          </td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Mes: </td>
          <td class="tdpadleft5">
            <select name="cboMes" class="field">
            </select>
          </td>
        </tr>
        <tr>
          <td height="20" colspan="2"><img src="images/pixel.gif" width="1" height="20"></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Nombre de la cuota:</td>
          <td class="tdpadleft5"><input name="txtNombreCuota" type="text" class="field" size="50" maxlength="50"></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Cuota de venta:</td>
          <td class="tdpadleft5"><input name="txtCuotaDeVenta" type="text" class="field" size="15" maxlength="15"></td>
        </tr>
        <tr>
          <td height="10" colspan="2"><img src="images/pixel.gif" width="1" height="10"></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">&nbsp;</td>
          <td class="tdpadleft5"><input name="btnAsignar" type="button" class="button" <%if strCmd <> "Editar" then%> value="Asignar cuota" <%else%> value="Modificar cuota" <%end if%> onclick="return cmdAsignarCuota_onclick()">&nbsp;&nbsp;<input name="cmdCancelar" type="button" class="button" id="cmdCancelar" onclick="return cmdCancelar_onclick()" value="Cancelar"></td>
        </tr>
      </table>
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