<%@ Page CodeBehind="VentasOperacionesDEX.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasOperacionesDEX" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
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
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  var intDireccionId = "<%= intDireccionOperativaId %>";
  var intZonaId = "<%= intZonaOperativaId %>";
  var intFechaId = <%= intFechaId %>;
  document.forms[0].action = "<%= strFormAction %>";
    document.forms[0].elements["optFecha"][intFechaId].checked = true;    
  if (intDireccionId == "0") {
     document.forms[0].elements["cboDireccion"].options[0].selected = true;
     document.forms[0].elements["cboZona"].disabled = true;
   }
   if (intZonaId == "0") {
     document.forms[0].elements["cboZona"].options[0].selected = true;
   }
   <%= strLlenarOperacionComboBox() %>
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

function cmdImprimir_onclick() {
  window.print();
}

function cmdExportar_onclick() {
  var strFormAction = document.forms[0].action;
  //document.forms[0].target = "_ExportingReport";
  document.forms[0].action += "?strCmd=Exportar";
  document.forms[0].submit();
  //document.forms[0].target = "_self";
  document.forms[0].action = strFormAction;
}
//-->
		</script>
</head>
<body language="javascript" onLoad="return window_onload()"> 
<form action="about:blank" method="post"> 
  <table width="780" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td><script language="JavaScript">crearTablaHeader()</script></td> 
    </tr> 
  </table> 
  <table width="780" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td width="10">&nbsp;</td> 
      <td width="770" class="tdtab">Está en : <a href="Ventas.htm">Ventas</a> : Operaciones DEX</td> 
    </tr> 
  </table> 
  <table width="780" border="0" cellpadding="0" cellspacing="0"> 
    <tr> 
      <td class="tdgeneralcontent"><h1>Operaciones DEX </h1> 
        <p>En esta parte usted puede realizar consultas de envíos, pagos y devoluciones por concepto de Dinero Express.</p> 
        <h2>Cofigurar reporte </h2> 
        <table width="60%" border="0" cellspacing="0" cellpadding="0"> 
          <tr> 
            <td width="14%" class="tdtexttablebold">Operación: </td> 
            <td width="86%" class="tdpadleft5"><select name="cboOperacion" class="field" id="cboOperacion"> 
            <option selected value="0">--- Elija una operación ---</option>
            <option value="-1">Todas las operaciones</option> 
              </select> </td> 
          </tr> 
          <tr> 
            <td class="tdtexttablebold">Fecha:</td> 
            <td class="tdtexttablereg"><input name="optFecha" type="radio" value="0" checked> 
              Mes actual&nbsp;&nbsp;&nbsp;&nbsp; 
              <input name="optFecha" type="radio" value="1"> 
              Mes anterior </td> 
          </tr> 
          <tr> 
            <td class="tdtexttablebold">Dirección:</td> 
            <td class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" language="javascript" onChange="return cboDireccion_onchange()"> 
                <option value="0" selected>--- Elija una dirección ---</option> 
                <option value="-1">Todas las direcciones</option>
              </select></td> 
          </tr> 
          <tr> 
            <td class="tdtexttablebold">Zona:</td> 
            <td class="tdpadleft5"><select name="cboZona" class="field" id="cboZona"> 
                <option value="0" selected>--- Elija una zona ---</option> 
                <option value="-1">Todas las zonas</option>
              </select></td> 
          </tr> 
          <tr> 
            <td colspan="2"><img src="images/pixel.gif" width="1" height="10"></td> 
          </tr> 
        </table> 
        <input name="cmdBuscar" type="submit" class="button" id="cmdBuscar" value="Ejecutar consulta"> 
        <br> 
        <br> 
        <%= strObtenerSucursalesPorZonaElegida()  %> <br> 
        <input name="cmdImprimir" type="button" class="button" id="cmdImprimir" value="Imprimir" language=javascript onClick="return cmdImprimir_onclick()"> 
		&nbsp; 
        <input name="cmdExportar" type="button" class="button" id="cmdExportar" value="Exportar" language=javascript onClick="return cmdExportar_onclick()"> 
        <br> </td> 
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
