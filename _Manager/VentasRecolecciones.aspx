<%@ Page CodeBehind="VentasRecolecciones.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsVentasRecolecciones" EnableSessionState="False" codePage="1252" enableViewState="False" %>
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

   var intcboDireccion = "<%= intDireccionOperativaId %>";
   var intcboZona = "<%= intZonaOperativaId %>";
   var intoptFecha = <%= intFechaId %>;
   document.forms[0].action = "<%= strFormAction %>";
   if(intoptFecha >= 0)
     document.forms[0].elements["optFecha"][intoptFecha].checked = true;   
   document.forms[0].elements["cboTipo"].value = "<%= strTipoRecoleccion %>";
   document.forms[0].elements["cboEstatus"].value = <%= intEstatus %>;
   if (intcboDireccion == "-1") {
     document.forms[0].elements["cboDireccion"].options[1].selected = true;
     document.forms[0].elements["cboZona"].disabled = true;
   }
   if (intcboZona == "-1") {
     document.forms[0].elements["cboZona"].options[1].selected = true;
   }
   <%= strLlenarTipoRecoleccionComboBox() %>
   <%= strLlenarEstatusRecoleccionComboBox() %>
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

//-->
		</script>
</head>
<body language="javascript" onLoad="return window_onload()"> 
<form > 
  <table width="780" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td><script language="JavaScript">crearTablaHeader()</script></td> 
    </tr> 
  </table> 
  <table width="780" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td width="10">&nbsp;</td> 
      <td width="770" class="tdtab">Está en : <a href="VentasHome.aspx">Ventas</a> : Recolecciones </td> 
    </tr> 
  </table> 
  <table width="780" border="0" cellpadding="0" cellspacing="0"> 
    <tr> 
      <td class="tdgeneralcontent"><h1>Recolecciones</h1> 
        <p>En esta parte usted pude realizar consultas de recolecciones de tipo Normal y DEX realizadas en las sucursales.</p> 
        <h2>Cofigurar reporte </h2> 
        <table width="60%" border="0" cellspacing="0" cellpadding="0"> 
          <tr> 
            <td class="tdtexttablebold">Tipo:</td> 
            <td class="tdpadleft5"><select name="cboTipo" class="field" id="cboTipo"> 
                <option value=" "> --- Todos los Tipos --- </option> 
              </select></td> 
          </tr> 
          <tr> 
            <td width="14%" class="tdtexttablebold">Estatus: </td> 
            <td width="86%" class="tdpadleft5"><select name="cboEstatus" class="field" id="cboEstatus"> 
                <option value=""> --- Todos los Estatus --- </option> 
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
            <td class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" language=javascript onChange="return cboDireccion_onchange()"> 
                <option value="0" selected> --- Todas las direcciones --- </option> 
              </select></td> 
          </tr> 
          <tr> 
            <td class="tdtexttablebold">Zona:</td> 
            <td class="tdpadleft5"><select name="cboZona" class="field" id="cboZona"> 
                <option value="0" selected> --- Todas las zonas --- </option> 
              </select></td> 
          </tr> 
          <tr> 
            <td colspan="2"><img src="images/pixel.gif" width="1" height="10"></td> 
          </tr> 
        </table> 
        <input name="cmdConsulta" type="submit" class="button" id="cmdConsulta" value="Ejecutar consulta"> 
        <br>
			<%= strBuscarRecoleccionesPorSucursalElegida() %> 
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
