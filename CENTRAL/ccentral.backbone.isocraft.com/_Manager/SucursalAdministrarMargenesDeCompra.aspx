<%@ Page CodeBehind="SucursalAdministrarMargenesDeCompra.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalAdministrarMargenesDeCompra" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="description" content="Javascript Menu">
<meta name="keywords" content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script id=clientEventHandlersJS language=javascript>
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  document.forms[0].elements["txtSucursales"].value = "<%= strSucursales %>";
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarDireccionComboBox() %>
<%= strLlenarZonaComboBox() %>
  cboZona_onchange();
}

function cboDireccion_onchange() {
  document.forms[0].elements["cboZona"].selectedIndex = 0;
  document.forms[0].submit();
  return(true);
}

function cboZona_onchange() {
  if (document.forms[0].elements["cboZona"].selectedIndex > 0) {
    document.forms[0].elements["cmdElegirSucursales"].disabled = false;
  } else {
    document.forms[0].elements["cmdElegirSucursales"].disabled = true;
  }
  return(true);
}

function cmdAsignar_onclick() {
  if ( blnFormValidator(document.forms[0]) == true ) {
    document.forms[0].action += "?strCmd=Asignar";
    document.forms[0].submit();
  }
}

function blnFormValidator(theForm) {
  var blnReturn = false;

  /* Validación del campo "txtSucursalMargenInferiorCompra" */
  if (theForm.elements["txtSucursalMargenInferiorCompra"] != null) {
      if (blnValidarCampo(theForm.elements["txtSucursalMargenInferiorCompra"], true, "Margen inferior de compra", cintTipoCampoReal, 10, 1, "") == true) {		   
          /* Validación del campo "txtSucursalMargenSuperiorCompra" */
          if (blnValidarCampo(theForm.elements["txtSucursalMargenSuperiorCompra"], true, "Margen superior de compra", cintTipoCampoReal, 10, 1, "") == true) {
			  if (parseInt(theForm.elements["txtSucursalMargenInferiorCompra"].value) > 0 && parseInt(theForm.elements["txtSucursalMargenInferiorCompra"].value) <= 100) {
				  if (parseInt(theForm.elements["txtSucursalMargenSuperiorCompra"].value) > 0 && parseInt(theForm.elements["txtSucursalMargenSuperiorCompra"].value) <= 100) {
				      if (parseInt(theForm.elements["txtSucursalMargenInferiorCompra"].value) > parseInt(theForm.elements["txtSucursalMargenSuperiorCompra"].value)) {
				          alert("El valor del margen inferior debe ser menor al del margen superior.");
				      } else {
						blnReturn = true;
				      }
				  }else {
				    alert("El valor del margen superior debe estar entre 0 y 100.");
				  }
			  } else {
				alert("El valor del margen inferior debe estar entre 0 y 100.");
			  }
          }
      }
  } else {
    blnReturn = true;
  }

  return (blnReturn);
}

function cmdElegirSucursales_onclick() {
  var intDireccionId = document.forms[0].elements["cboDireccion"].options[document.forms[0].elements["cboDireccion"].selectedIndex].value;
  var intZonaId = document.forms[0].elements["cboZona"].options[document.forms[0].elements["cboZona"].selectedIndex].value;
  return Pop("popSucursalMargenesDeCompraElegirSucursales.aspx?intDireccionId=" + intDireccionId + "&intZonaId=" + intZonaId, "360", "548");
}

function cmdCancelar_onClick() {
	window.location.href = "SucursalAdministrarMargenesDeCompra.aspx";;
}

//-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSucursalAsignarTipoDeCambio">
  <input type="hidden" name="txtSucursales">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : Sucursal : Asignaci&oacute;n de cuotas : Administrar m&aacute;rgenes de compra </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Administrar m&aacute;rgenes de compra </h1>
      <p>Para poder administrar los m&aacute;rgenes de compra, seleccione una zona, y luego defina a qu&eacute; sucursales aplicar&aacute; los m&aacute;rgenes. </p>
      <h2>Sucursales</h2>
      <table width="50%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="20%" class="tdtexttablebold">* Direcci&oacute;n:</td>
          <td width="80%" class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" language=javascript onchange="return cboDireccion_onchange()">
              <option value="0" selected>Elija una direcci&oacute;n</option>
            </select>
          </td>
        </tr>
        <tr>
          <td class="tdtexttablebold">* Zona:</td>
          <td class="tdpadleft5"><select name="cboZona" class="field" id="cboZona" language=javascript onchange="return cboZona_onchange()">
              <option value="0" selected>Elija una zona</option>
            </select></td>
        </tr>
      </table>
      <br>
      <input name="cmdElegirSucursales" type="button" class="button" id="cmdElegirSucursales" onClick="return cmdElegirSucursales_onclick()" value="Elegir sucursales">
      <br>
      <%= strRecordBrowserHTML() %>
      <br>      
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
