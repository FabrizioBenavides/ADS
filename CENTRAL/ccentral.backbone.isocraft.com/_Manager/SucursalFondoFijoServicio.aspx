<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalFondoFijoServicio.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalFondoFijoServicio" EnableSessionState="False" enableViewState="False"%>
<HTML>
<HEAD>
<title>ADS CENTRAL</title>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  SelectComboBoxElement(document.forms[0].elements["cboMes"], <%= intMes %>);
  SelectComboBoxElement(document.forms[0].elements["cboAnio"], <%= intAnio %>);
<%= strJavascriptWindowOnLoadCommands %>
<%= strLlenarDireccionComboBox() %>
<%= strLlenarZonaComboBox() %>
}

function cboDireccion_onchange() {
  if (document.forms[0].elements["cboDireccion"].selectedIndex > 0) {
    document.forms[0].elements["cboZona"].selectedIndex = 0;
    document.forms[0].submit();
  }
  return(true);
}

function cmdImprimir_onclick(){
	
	if (document.forms[0].elements["cboDireccion"].selectedIndex == 0) {
		alert("Por favor seleccione una dirección.");
		document.forms[0].elements["cboDireccion"].focus();
		return(false);
	} 
	if (document.forms[0].elements["cboZona"].selectedIndex == 0) {
		alert("Por favor seleccione una zona.");
		document.forms[0].elements["cboZona"].focus(); 
		return(false);
	}
	if (document.forms[0].elements["cboMes"].selectedIndex == 0) {
		alert("Por favor seleccione un mes.");
		document.forms[0].elements["cboMes"].focus(); 
		return(false);
	}
	if (document.forms[0].elements["cboAnio"].selectedIndex == 0) {
		alert("Por favor seleccione un año.");
		document.forms[0].elements["cboAnio"].focus(); 
		return(false);
	}
	var strParametros = ""

	strParametros = strParametros + "intDireccionId=" + document.forms[0].elements["cboDireccion"].value;
	strParametros = strParametros + "&intZonaId=" + document.forms[0].elements["cboZona"].value;
	strParametros = strParametros + "&intMes=" + document.forms[0].elements["cboMes"].value;
	strParametros = strParametros + "&intAnio=" + document.forms[0].elements["cboAnio"].value;
		
	window.open('popSucursalFondoFijoServicio.aspx?' + strParametros, 'Pop','width=850,height=540,left=0,top=0,resizable=yes,scrollbars=yes,menubar=yes,status=no' );
	return(true);
}

function frmMain_onsubmit() {

  if (document.forms[0].elements["cboDireccion"].selectedIndex == 0) {
      alert("Por favor seleccione una dirección.");
      document.forms[0].elements["cboDireccion"].focus();
      return(false);
  } 
  if (document.forms[0].elements["cboZona"].selectedIndex == 0) {
    alert("Por favor seleccione una zona.");
    document.forms[0].elements["cboZona"].focus(); 
    return(false);
  }
  if (document.forms[0].elements["cboMes"].selectedIndex == 0) {
    alert("Por favor seleccione un mes.");
    document.forms[0].elements["cboMes"].focus(); 
    return(false);
  }
  if (document.forms[0].elements["cboAnio"].selectedIndex == 0) {
    alert("Por favor seleccione un año.");
    document.forms[0].elements["cboAnio"].focus(); 
    return(false);
  }
  document.forms[0].elements["strCmd"].value = "Consultar";
  return(true);

}


//-->
		</script>
</HEAD>
<body language="javascript" onLoad="return window_onload()">
<form id="frmMain" action="about:blank" method="post" language=javascript onSubmit="return frmMain_onsubmit()">
  <input type="hidden" name="strCmd" value="" />
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <a href="SucursalHome.aspx">Sucursal</a> : 
        Consulta de fondo fijo servicios sucursal</td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Consulta de fondo fijo servicios de sucursal</h1>
        <p>En esta parte usted puede consultar los diferentes registros de 
          fondo fijo de servicios de sucursal.</p>
        <h2>Buscar movimientos de fondo fijo servicios</h2>
        <table width="60%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="tdtexttablebold">Dirección:</td>
            <td class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" language=javascript onChange="return cboDireccion_onchange()">
                <option value="0">-- Elija una direcci&oacute;n --</option selected>
              </select></td>
            <td class="tdtexttablebold">Mes:</td>
            <td class="tdpadleft5"><select name="cboMes" class="field" id="cboMes">
                <option value="0">--- Seleccionar --- </option>
                <option value="1">Enero</option>
                <option value="2">Febrero</option>
                <option value="3">Marzo</option>
                <option value="4">Abril</option>
                <option value="5">Mayo</option>
                <option value="6">Junio</option>
                <option value="7">Julio</option>
                <option value="8">Agosto</option>
                <option value="9">Septiembre</option>
                <option value="10">Octubre</option>
                <option value="11">Noviembre</option>
                <option value="12">Diciembre</option>
              </select></td>
          </tr>
          <tr>
            <td width="14%" class="tdtexttablebold">Zona: </td>
            <td width="86%" class="tdpadleft5"><select name="cboZona" class="field" id="cboZona">
                <option value="0">-- Elija una zona --</option selected>
              </select>
            </td>
            <td width="14%" class="tdtexttablebold">Año: </td>
            <td width="86%" class="tdpadleft5"><select name="cboAnio" class="field" id="cboAnio">
                <option value="0">--- Año --- </option>                
                <option value="2010">2010</option>
                <option value="2011">2011</option>
                <option value="2012">2012</option>
                <option value="2013">2013</option>
                <option value="2014">2014</option>
                <option value="2015">2015</option>
              </select>
            </td>
          </tr>
          <tr>
            <td colspan="4"><img src="images/pixel.gif" width="1" height="10"></td>
          </tr>
        </table>
        <input name="cmdConsulta" type="submit" class="button" id="cmdConsulta" value="Ejecutar consulta">
        <br>
        <%= strRecordBrowserHtml %> <br>
        <br>
        <input language="javascript" class="boton" id="cmdImprimir" onClick="return cmdImprimir_onclick()"
			type="button" value="Imprimir" name="cmdImprimir"> 
        &nbsp;<br>
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

