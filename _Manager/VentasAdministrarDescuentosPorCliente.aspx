<%@ Page CodeBehind="VentasAdministrarDescuentosPorCliente.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasAdministrarDescuentosPorCliente" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="description" content="Javascript Menu">
<meta name="keywords" content="JavaScript menu, javascript, html, client side, netscape, explorer, IE, menu, DHTML, DOM, control">
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

function isEnterKey(evt) {
  if (!evt) {
    // grab IE event object
    evt = window.event
  } else if (!evt.keyCode) {
    // grab NN4 event info
    evt.keyCode = evt.which
  }
  return (evt.keyCode == 13)
}

function cmdBuscarCliente_onclick() {
  var strSourceValue = document.forms[0].elements["txtCliente"].value;
  if (strSourceValue.length > 0) {
    Pop("popSucursalBuscarClientesEspeciales.aspx?strTargetFieldOne=txtClienteEspecialId&strTargetFieldTwo=lblClienteEspecialNombre&strTargetFieldThree=txtCliente&strTargetFieldFour=txtClienteEspecialNombre&strSourceValue=" + strSourceValue, "360", "467");
  } else {
    alert("Por favor escriba un valor en el campo \"Cliente\".");
    document.forms[0].elements["txtCliente"].focus();
  }
}

function cmdLimpiar_onclick() {
  window.location.href = "SistemaAsignarArticulosPrecioFijo.aspx";
}

function cmdAgregar_onclick() {
  if (document.forms[0].elements["txtClienteEspecialId"].value.length == 0) {
    alert("Por favor especifique un cliente.");
    document.forms[0].elements["txtCliente"].focus();
    return(false);
  }
  if (document.forms[0].elements["txtArticuloClienteEspecialArchivo"].value.length == 0) {
    alert("Por favor especifique un valor para el campo \"Archivo\".");
    document.forms[0].elements["txtArticuloClienteEspecialArchivo"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=Agregar";
  document.forms[0].submit();
  return(true);
}

function cmdReemplazar_onclick() {
  if (document.forms[0].elements["txtClienteEspecialId"].value.length == 0) {
    alert("Por favor especifique un cliente.");
    document.forms[0].elements["txtCliente"].focus();
    return(false);
  }
  if (document.forms[0].elements["txtArticuloClienteEspecialArchivo"].value.length == 0) {
    alert("Por favor especifique un valor para el campo \"Archivo\".");
    document.forms[0].elements["txtArticuloClienteEspecialArchivo"].focus();
    return(false);
  }
  document.forms[0].action += "?strCmd=Reemplazar";
  document.forms[0].submit();
  return(true);
}

function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";
  document.forms[0].elements["txtClienteEspecialId"].value = "<%= intClienteEspecialId %>";
  document.forms[0].elements["txtClienteEspecialNombre"].value = "<%= strClienteEspecialNombre %>";
  document.all.lblClienteEspecialNombre.innerHTML = document.forms[0].elements["txtClienteEspecialNombre"].value;
<%= strJavascriptWindowOnLoadCommands %>
}

function txtCliente_onkeydown(objEvent) {
  if (isEnterKey(objEvent)) {
    cmdBuscarCliente_onclick();
    return(false);
  }
}

// done hiding -->
        </script>
</head>
<body language="javascript" onLoad="return window_onload()">
<form method="post" id="frmMain" name="frmMain" enctype="multipart/form-data" runat="server">
  <input type="hidden" name="txtClienteEspecialId">
  <input type="hidden" name="txtClienteEspecialNombre">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script>
      </td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <a href="Sistema.aspx">Sistema</a> : <a href="SistemaClientesEspeciales.aspx">Clientes
          especiales</a> : Asignar descuentos por cliente </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Asignar descuentos por cliente </h1>
        <p>Aquí podrá dar de alta en el sistema artículos con descuentos y asignárselos
          a un cliente especial.</p>
        <h2>Buscar cliente especial y archivo con artículos</h2>
        <table border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td colspan="3"><p>1. Escriba el código o el nombre del cliente y
                oprima el botón "Buscar". Puede usar parte del identificador
                o del nombre.</p>
            </td>
          </tr>
          <tr>
            <td width="65" class="tdtexttablebold"><label for="txtCliente">Cliente:</label>
            </td>
            <td width="683" class="tdpadleft5"><input name="txtCliente" type="text" class="field" id="txtCliente" size="35" maxlength="35"
                    language="javascript" onKeyDown="return txtCliente_onkeydown()">
              <input name="cmdBuscarCliente" type="button" class="button" id="cmdBuscarCliente" value="Buscar"
                    language="javascript" onClick="return cmdBuscarCliente_onclick()">
            </td>
            <td width="100%" class="tdcontentableblue"><div id="lblClienteEspecialNombre"></div>
            </td>
          </tr>
          <tr>
            <td colspan="3"><img src="images/pixel.gif" width="1" height="10"></td>
          </tr>
          <tr>
            <td colspan="3"><p>2. Localice el archivo con la lista de artículos
                y su descuento</p>
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="txtArticuloClienteEspecialArchivo">Archivo:</label>
            </td>
            <td class="tdpadleft5"><input name="txtArticuloClienteEspecialArchivo" type="file" class="field" id="txtArticuloClienteEspecialArchivo"
                    size="35" title="Archivo" runat="server">
            </td>
            <td class="tdpadleft5">&nbsp;</td>
          </tr>
          <tr>
            <td colspan="3"><img src="images/pixel.gif" width="1" height="10"></td>
          </tr>
        </table>
        <p>
          <input name="cmdLimpiar" type="button" class="button" id="cmdLimpiar" value="Limpiar" language="javascript"
                onClick="return cmdLimpiar_onclick()">
&nbsp;&nbsp;
          <input name="cmdAgregar" type="button" class="button" id="cmdAgregar" value="Actualizar" language="javascript"
                onClick="return cmdAgregar_onclick()">
          <br>
          <br>
          <%= strGetRecordBrowserHTML() %> <br>
        </p>
        <br>
      </td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaFooterCentral()</script>
      </td>
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
