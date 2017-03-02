<%@ Page CodeBehind="SistemaEmpresasRecolectorasAsignarRecolectoras.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaEmpresasRecolectorasAsignarRecolectoras" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<LINK href="css/menu.css" type="text/css" rel="stylesheet">
<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {

  var intDireccionOperativaId = "<%= intDireccionOperativaId %>";
  document.forms[0].action = "<%= strFormAction %>";
    
  if (intDireccionOperativaId == "-1") {
    document.forms[0].elements["cboDireccion"].options[1].selected = true;
    document.forms[0].elements["cboZona"].disabled = true;
  }    
    
  <%= strLlenarRecolectoraComboBox() %>
  <%= strLlenarDireccionComboBox() %>
  <%= strLlenarZonaComboBox() %>
  <%= strJavascriptWindowOnLoadCommands %>
  
  if (<%= intEmpresaValoresId%> == 0 || <%= intDireccionOperativaId%> == 0 || <%= intZonaOperativaId%> == 0)
  document.forms[0].elements["cmdElegirSucursales"].disabled = true;
}

function cboDireccion_onchange() {
  if (document.forms[0].elements["cboDireccion"].selectedIndex <= "0") {
    document.forms[0].elements["cboZona"].selectedIndex = 0; 
    document.forms[0].elements["cboZona"].disabled = true;
  }
  document.forms[0].submit();
  return(true);
}

function cboZona_onchange() {
  document.forms[0].submit();
  return(true);
}

function cmdElegirSucursales_onclick() {
  if(document.forms[0].elements["cboRecolectora"].selectedIndex == 0)
	alert("Elija una empresa recolectora");
  else{
  var intRecolectoraId = document.forms[0].elements["cboRecolectora"].options[document.forms[0].elements["cboRecolectora"].selectedIndex].value;
  var intDireccionOperativaId = document.forms[0].elements["cboDireccion"].options[document.forms[0].elements["cboDireccion"].selectedIndex].value;
  var intZonaOperativaId = document.forms[0].elements["cboZona"].options[document.forms[0].elements["cboZona"].selectedIndex].value;
  return Pop("popSistemaEmpresasRecolectorasElegirSucursales.aspx?intDireccionOperativaId=" + intDireccionOperativaId + "&intZonaOperativaId=" + intZonaOperativaId + "&intRecolectoraId=" + intRecolectoraId,"360","548")
  }
}

function cboRecolectora_onchange() {
  document.forms[0].submit();
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
</HEAD>
<body language="javascript" onload="return window_onload()"> 
<form name="frmMain" action="about:blank" method="post"> 
  <table cellSpacing="0" cellPadding="0" width="780" border="0"> 
    <tr> 
      <td> <script language="JavaScript">crearTablaHeader()</script> </td> 
    </tr> 
  </table> 
  <table cellSpacing="0" cellPadding="0" width="780" border="0"> 
    <tr> 
      <td width="10">&nbsp;</td> 
      <td class="tdtab" width="770">Está en : <A href="Sistema.aspx">Sistema</A> : <A href="SistemaEmpresasRecolectoras.aspx"> Empresas recolectoras</A> : Asignar recolectoras a sucursales </td> 
    </tr> 
  </table> 
  <table cellSpacing="0" cellPadding="0" width="780" border="0"> 
    <tr> 
      <td class="tdgeneralcontent"> <h1>Asignar recolectoras a sucursales </h1> 
        <p>En esta parte usted puede realizar asignaciones de empresas recolectoras a las sucursales. </p> 
        <h2>Definir sucursal blanco de asignación </h2> 
        <table cellSpacing="0" cellPadding="0" width="60%" border="0"> 
          <tr> 
            <td class="tdtexttablebold" width="28%">Empresa recolectora:</td> 
            <td class="tdpadleft5" width="72%"><select class="field" id="cboRecolectora" name="cboRecolectora" language=javascript onchange="return cboRecolectora_onchange()"> 
                <option value="0" selected>--- Elija una empresa ---</option> 
              </select></td> 
          </tr> 
          <tr> 
            <td class="tdtexttablebold">Dirección:</td> 
            <td class="tdpadleft5"><select language="javascript" class="field" id="cboDireccion" onchange="return cboDireccion_onchange()"
										name="cboDireccion"> 
                <option value="0" selected>--- Elija una dirección ---</option> 
              </select></td> 
          </tr> 
          <tr> 
            <td class="tdtexttablebold">Zona:</td> 
            <td class="tdpadleft5"><select language="javascript" class="field" id="cboZona" onchange="return cboZona_onchange()"
										name="cboZona"> 
                <option value="0" selected>--- Elija una zona ---</option> 
              </select></td> 
          </tr> 
          <tr> 
            <td colSpan="2" height="10"><IMG height="10" src="images/pixel.gif" width="1"></td> 
          </tr> 
        </table> 
        <input language="javascript" class="button" id="cmdElegirSucursales" onclick="return cmdElegirSucursales_onclick()"
							type="button" value="Elegir sucursales" name="cmdElegirSucursales"> 
        <br> 
        <br> 
        <br> 
        <%= strObtenerSucursalesPorZonaElegida() %> <br> 
        <input class="button" id="cmdImprimir" type="button" value="Imprimir" name="cmdImprimir" language=javascript onclick="return cmdImprimir_onclick()"> 
&nbsp;&nbsp; 
        <input class="button" id="cmdExportar" type="button" value="Exportar" name="cmdExportar" language=javascript onclick="return cmdExportar_onclick()"> 
        <br> 
        <br> </td> 
    </tr> 
  </table> 
  <table cellSpacing="0" cellPadding="0" width="780" border="0"> 
    <tr> 
      <td> <script language="JavaScript">crearTablaFooterCentral()</script> </td> 
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
