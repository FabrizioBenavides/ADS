<%@ Page CodeBehind="SistemaRevisarRecetas.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaRevisarRecetas" codePage="1252" enableViewState="False" EnableSessionState="False"%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/menu.css" rel="stylesheet" type="text/css" />
<link href="css/estilo.css" rel="stylesheet" type="text/css" />
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="js/calendario.js"></script>
<script language="JavaScript" src="js/cal_format00.js"></script>
<script id=clientEventHandlersJS language=javascript>
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  var intDireccionId = "<%= intDireccionId %>";
  var intZonaId = "<%= intZonaId %>";
  var intEstadoFormaCaptura = <%= intEstadoFormaCaptura %> - 1;
  document.forms[0].action = "<%= strFormAction %>";
  document.forms[0].elements["txtFechaInicial"].value = "<%= strtxtFechaInicial %>";
  document.forms[0].elements["txtFechaFinal"].value = "<%= strtxtFechaFinal %>";
  if (intDireccionId == "-1") {
    document.forms[0].elements["cboDireccion"].options[1].selected = true;
    document.forms[0].elements["cboZona"].disabled = true;
  }
  if (intZonaId == "-1") {
    document.forms[0].elements["cboZona"].options[1].selected = true;
  }
  document.forms[0].elements["cboEstadoFormaCaptura"].options[intEstadoFormaCaptura].selected = true;
<%= strLlenarDireccionComboBox() %>
<%= strLlenarZonaComboBox() %>
<%= strJavascriptWindowOnLoadCommands %>
}

function cboDireccion_onchange() {
  if (document.forms[0].elements["cboDireccion"].selectedIndex > 0) {
    document.forms[0].elements["cboZona"].selectedIndex = 0;
    document.forms[0].submit();
  }
  return(true);
}

function cmdExportar_onclick() {
  //document.forms[0].target = "_ExportingReport";
  document.forms[0].action += "?strCmd=Exportar";
  document.forms[0].submit();
  //document.forms[0].target = "_self";
  document.forms[0].action = "<%=strFormAction%>";
}

//-->
</script>
</head>
<body language=javascript onLoad="return window_onload()">
<form method="POST" action="about:blank" name="frmPage">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : <a href="Sistema.aspx">Sistema</a> : <a href="SistemaClientesEspeciales.aspx">Clientes especiales</a> : <a href="SistemaRecetas.aspx">Recetas</a> : Revisar recetas </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Revisar recetas </h1>
        <p>Aqu&iacute; podr&aacute; buscar y modificar las recetas que fueron dadas de alta por los puntos de venta. </p>
        <h2>B&uacute;squeda de sucursales </h2>
        <table  border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td class="tdtexttablebold"><label for="txtFechaInicial">Desde:</label></td>
            <td class="tdpadleft5"><input name="txtFechaInicial" id="txtFechaInicial"type="text" class="field" size="12" maxlength="12" />
              <a href="javascript:cal1.popup()"><img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absmiddle" /></a></td>
            <td class="tdtexttablebold"><label for="txtFechaFinal">Hasta:</label></td>
            <td class="tdpadleft5"><input name="txtFechaFinal" id="txtFechaFinal"type="text" class="field" size="12" maxlength="12" />
              <a href="javascript:cal2.popup()"><img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absmiddle" /></a></td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="cboDireccion">Direcci&oacute;n:</label></td>
            <td class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" language=javascript onChange="return cboDireccion_onchange()">
                <option value="0">--- Elija una direcci&oacute;n ---</option selected>
                <option value="-1">Todas las direcciones</option>
                <option>--------------------</option>
              </select>
&nbsp;&nbsp; </td>
            <td class="tdpadleft5">&nbsp;</td>
            <td class="tdpadleft5">&nbsp;</td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="cboZona">Zona:</label></td>
            <td class="tdpadleft5"><select name="cboZona" class="field" id="cboZona">
                <option value="0">-- Elija una zona --</option selected>
                <option value="-1">Todas las zonas</option>
                <option>--------------------</option>
              </select>
&nbsp;</td>
            <td class="tdpadleft5">&nbsp;</td>
            <td class="tdpadleft5">&nbsp;</td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="cboEstadoFormaCaptura">Estado de las recetas:</label></td>
            <td class="tdpadleft5"><select name="cboEstadoFormaCaptura" class="field" id="cboEstadoFormaCaptura">
                <option value="1">Con error</option>
                <option value="2">Sin error</option>
              </select>
&nbsp;</td>
            <td class="tdpadleft5">&nbsp;</td>
            <td class="tdpadleft5">&nbsp;</td>
          </tr>
          <tr>
            <td height="10" colspan="4"><img src="images/pixel.gif" width="1" height="10" /></td>
          </tr>
        </table>
        <input name="cmdBuscar" type="submit" class="button" id="cmdBuscar" value="Buscar" />
        <input name="cmdExportar" type="button" class="button" id="cmdExportar" value="Exportar"  language=javascript onclick="return cmdExportar_onclick()"/>
        <br />
        <br />
        <%= strGetRecordBrowserHTML() %> <br />
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
  <script language="JavaScript">
    <!-- // create calendar object(s) just after form tag closed
    var cal1 = new calendar(null, document.forms['frmPage'].elements['txtFechaInicial']);
    var cal2 = new calendar(null, document.forms['frmPage'].elements['txtFechaFinal']);
    //-->
  </script>
</form>
</body>
</html>
