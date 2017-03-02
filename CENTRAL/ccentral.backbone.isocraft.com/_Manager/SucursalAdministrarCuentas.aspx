<%@ Page CodeBehind="SucursalAdministrarCuentas.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalAdministrarCuentas" Explicit="True" Trace="False" Strict="True" codePage="1252" %>


<html>
<head>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";

<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarTipoCuentaComboBox() %>

if (document.forms[0].elements["cboTipoCuenta"].options[document.forms[0].elements["cboTipoCuenta"].selectedIndex].text == "Pseudocuenta"){
		document.all.tipoReferencia.style.display = "";
		document.forms[0].elements["cboTipoReferencia"].selectedIndex = <%=intTipoReferenciaId%>
}
  
}

function cboTipoCuenta_onchange(){

   	if (document.forms[0].elements["cboTipoCuenta"].options[document.forms[0].elements["cboTipoCuenta"].selectedIndex].text == "Pseudocuenta"){
		document.all.tipoReferencia.style.display = "";
	}
	else{
	 document.forms[0].submit();	
	}
	
}

function cboTipoReferencia_onchange(){
  document.forms[0].submit();
}
</script>
</head>
<body onload="return window_onload();">
<form method="POST" action="about:blank" name="frmSucursalAdministrarCuentas">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : Sistema : Cuentas : Administrar cuentas</td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Administrar cuentas</h1>
      <p>En esta parte del sistema usted administrar&aacute; las cuentas (pseudocuentas, contables, bancarias) que maneja el sistema. </p>
      <table width="60%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="57%" class="tdtexttablebold">Elija el tipo de cuenta que quiere ver </td>
          <td width="43%" class="tdpadleft5"><select name="cboTipoCuenta" class="field" onchange="return cboTipoCuenta_onchange();">
              <option value="0">Todos los tipos</option >
            </select>
          </td>
        </tr>
        <tr id="tipoReferencia" style="{display:none}">
          <td class="tdtexttablebold">Elija el tipo de transferencia que quiere ver </td>
          <td class="tdpadleft5">
           <select name="cboTipoReferencia" class="field" onchange="return cboTipoReferencia_onchange();">
              <option value="0" selected>Todos los tipos</option>
              <option value="1">Ninguno</option>
              <option value="2">Por formas de pago</option>
              <option value="3">Por departamento</option>
              <option value="4">Por devoluciones</option>
              <option value="5">Por tipo de ticket</option>
           </select>
          </td>
        </tr>
      </table>
      <br>
      <%=strRecordBrowserHTML%>
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
