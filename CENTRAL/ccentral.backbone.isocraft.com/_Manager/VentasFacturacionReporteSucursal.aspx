<%@ Page Language="vb" AutoEventWireup="false" Codebehind="VentasFacturacionReporteSucursal.aspx.vb" Inherits="com.isocraft.backbone.ccentral.VentasFacturacionReporteSucursal"%>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<link href="css/estiloimpresion.css" rel="stylesheet" media="print" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="js/calendario.js"></script>
<script language="JavaScript" src="js/cal_format00.js"></script>
<script id="clientEventHandlersJS" language="javascript">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
   document.forms[0].action = "<%= strFormAction %>";
   
   var intDireccionOperativaId = "<%= intDireccionOperativaId %>";
   var intZonaOperativaId = "<%= intZonaOperativaId %>";
   var strSucursalId = "<%= strSucursalId %>";  
   var intCompaniaid = "<%=intCompaniaid%>";
   var intSucursalid = "<%=intSucursalid%>";
      
   if (intDireccionOperativaId == "-1") {
       document.forms[0].elements["cboDireccion"].options[1].selected = true;
       document.forms[0].elements["cboZona"].disabled = true;
       document.forms[0].elements["cboSucursal"].disabled = true;
   }     
   if (intZonaOperativaId == "-1") {
       document.forms[0].elements["cboZona"].options[1].selected = true;
       document.forms[0].elements["cboSucursal"].disabled = true;
   }     
   if (strSucursalId == "-1") {
       document.forms[0].elements["cboSucursal"].options[1].selected = true;
   }  

   document.forms[0].elements["cboEstado"].options["<%= intEstadoId %>"].selected = true;
   document.forms[0].txtEmisionInicio.value = "<%=strEmisionInicio %>";
   document.forms[0].txtEmisionFin.value = "<%=strEmisionFin %>";
   
   document.forms[0].txtCanceladaInicio.value = "<%=strCanceladaInicio %>";
   document.forms[0].txtCanceladaFin.value = "<%=strCanceladaFin %>";      
   document.forms[0].txtClienteRFC.value = "<%=strClienteRFC %>";

   <%= strLlenarDireccionComboBox() %>
   <%= strLlenarZonaComboBox() %>
   <%= strLlenarSucursalComboBox() %>
   <%= strJavascriptWindowOnLoadCommands %>

}

function cboEstado_onchange() {
   if (document.forms[0].elements["cboDireccion"].selectedIndex > 0) {
       document.forms[0].action = '<%= strFormAction %>';
   	   document.forms[0].target='';
       document.forms[0].submit(); 
    }
}
function cboDireccion_onchange() {
      
   if (document.forms[0].elements["cboDireccion"].selectedIndex > 0) {   
   
       document.forms[0].elements["cboZona"].selectedIndex = 0;  	   
       document.forms[0].action = '<%= strFormAction %>';
	   document.forms[0].target='';
       document.forms[0].submit();
   }
   
   return(true);
}

function cboZona_onchange() {
   if (document.forms[0].elements["cboZona"].selectedIndex > 0) {
       document.forms[0].elements["cboSucursal"].selectedIndex = 0;
       
       document.forms[0].action = '<%= strFormAction %>';
	   document.forms[0].target='';
       document.forms[0].submit();
   }
   return(true);
}

function cboSucursal_onchange() {
   if (blnValidarSubmit()) {
       document.forms[0].action = '<%= strFormAction %>';
   	   document.forms[0].target='';
       document.forms[0].submit(); 
    }
}

function blnValidarSubmit() {
   var blnValidar = true;
   
   if ( document.forms[0].elements["cboDireccion"].selectedIndex == 0 && document.forms[0].elements["cboZona"].selectedIndex == 0 && document.forms[0].elements["cboSucursal"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar al menos algun criterio de Dirección, Zona, Sucursal");
   }   
   
   if ( blnValidar && document.forms[0].elements["cboDireccion"].selectedIndex > 1 &&  document.forms[0].elements["cboZona"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar el criterio de Zona");
   }
   
   if ( blnValidar && document.forms[0].elements["cboZona"].selectedIndex > 1 &&  document.forms[0].elements["cboSucursal"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar el criterio de Sucursal");
   }      
   
   return blnValidar;
   
}

function doSubmit()
{   
    args = doSubmit.arguments;
    var action = args[0];
    var params = "";
    var url = "";
	
	if (action=="VerDetalle") {       
       url = 'VentasFacturacionReporteSucursalDetalle.aspx?';     
	   
	   for (i=1; i < (args.length-1); i +=2) {
		params+= "&" + args[i] + "=" + args[i+1];		
	   }
	   
	   url = url + params;  
       var WinDetalleFactura = window.open(url,'PopVerDetalleFactura','width=720,height=600,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );

       return;
    }  
	
	var params = ""
	for (i=1; i < (args.length-1); i +=2) 	{
		params+= "&" + args[i] + "=" + args[i+1]
	}
		
	document.forms[0].action = "VentasFacturacionReporteSucursal.aspx?strVer=" + "<%=strVer%>" + "&strCmd=" + action + params;
	document.forms[0].submit(); 
		
}

function cmdRegresar_onclick() {
    window.location='VentasFacturacion.aspx';
}

function  cmdConsultarDetalle_onclick() {
   if (blnValidarSubmit()) {
       document.forms[0].action = '<%= strFormAction %>'+'?strVer=1';
   	   document.forms[0].target='';
       document.forms[0].submit(); 
    }
}

function  cmdConsultarAgrupado_onclick() {
   if (blnValidarSubmit()) {
       document.forms[0].action = '<%= strFormAction %>'+'?strVer=2';
   	   document.forms[0].target='';
       document.forms[0].submit(); 
    }
}

function cmdLimpiar_onclick() {
  window.location.href = "<%= strThisPageName %>";
}
function cmdExportar_onclick() {				 
  document.forms[0].action = "VentasFacturacionReporteSucursal.aspx?strVer=" + "<%=strVer%>" + "&strAccion=Exportar" ;
  document.forms[0].target='';
  document.forms[0].submit(); 
}
//-->
		</script>
</HEAD>
<body language="javascript" onLoad="return window_onload()">
<form name="frmVentasFacturacionReporteSucursal" action="about:blank" method="post">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td class="tdtab" width="100%">Está en : <a href="VentasHome.aspx">Ventas</a>:Facturación 
        Global</td>
    </tr>
  </table>
  <table cellspacing="0" cellpadding="0" width="780" border="0">
    <tr> 
      <td width="2%"> 
      <td width="98%" class="tdgeneralcontent"> <table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
          <tr> 
            <td valign="top" height="30"><h1>Facturación Reporte</h1>
              <p> </p></td>
          </tr>
          <tr> 
            <td><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Criterio 
              De Busqueda</span></td>
          </tr>
        </table>
        <table width="100%" class="tdEnvolventeTablaAzul" cellSpacing="0" cellPadding="0" border="0">
          <tr> 
            <td width="15%" class="tdtexttablebold">Dirección:</td>
            <td width="35%" class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" onchange="return cboDireccion_onchange()">
                <option value="0" selected>-- Elija una Dirección --</option>
                <option value="-1">Todas las Direcciones</option>
                <option>--------------------</option>
              </select> </td>
            <td width="20%" class="tdtexttablebold">Estado:</td>
            <td width="30%" class="tdpadleft5"><select name="cboEstado" class="field" id="cboEstado" onchange="return cboEstado_onchange()">
                <option value="0" selected>-- Todos --</option>
                <option value="1" selected>-- Archivadas --</option>
                <option value="2" selected>-- Canceladas --</option>
              </select> </td>
          </tr>
          <tr> 
            <td width="15%" class="tdtexttablebold">Zona:</td>
            <td width="35%" class="tdpadleft5"> <select name="cboZona" class="field" id="cboZona" language="javascript" onChange="return cboZona_onchange()">
                <option value="0" selected>--- Elija un Zona ---</option>
                <option value="-1">Todos las zonas</option>
                <option>--------------------</option>
              </select> </td>
            <td width="20%" class="tdtexttablebold">Fecha Emisión:</td>
            <td width="30%" class="tdtexttablebold" valign="top"> <input class="field" id="txtEmisionInicio" type="text" maxLength="12" size="12" name="txtEmisionInicio"> 
              <a href="javascript:cal1.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></a> 
              &nbsp;&nbsp;&nbsp;&nbsp; <input class="field" id="txtEmisionFin" type="text" maxLength="12" size="12" name="txtEmisionFin"> 
              <a href="javascript:cal2.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></a> 
            </td>
          </tr>
          <tr> 
            <td width="15%" class="tdtexttablebold">Sucursal:</td>
            <td width="35%" class="tdpadleft5"> <select name="cboSucursal" class="field" id="cboSucursal" onchange="return cboSucursal_onchange()">
                <option value="0" selected>-- Elija una sucursal --</option>
                <option value="-1">Todas las sucursales</option>
                <option>--------------------</option>
              </select> </td>
            <td width="20%" class="tdtexttablebold">Fecha Cancelaci&oacute;n:</td>
            <td width="30%" class="tdtexttablebold" valign="top"> <input class="field" id="txtCanceladaInicio" type="text" maxLength="12" size="12" name="txtCanceladaInicio"> 
              <a href="javascript:cal3.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></a> 
              &nbsp;&nbsp;&nbsp;&nbsp; <input class="field" id="txtCanceladaFin" type="text" maxLength="12" size="12" name="txtCanceladaFin"> 
              <a href="javascript:cal4.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></a> 
            </td>
          </tr>
          <tr> 
            <td width="15%" class="tdtexttablebold">RFC CLIENTE:</td>
            <td width="75%" class="tdtexttablebold" valign="top" colspan="3"> 
              <input class="field" id="txtClienteRFC" type="text" autocomplete="off"  maxlength="50" size="40" name="txtClienteRFC"  value='<%=Request("txtClienteRFC")%>'> 
            </td>
          </tr>
        </table>
        <br> <table width="100%" cellSpacing="0" cellPadding="0" border="0">
          <tr> 		  
            <td>
			<input class="boton" id="cmdRegresar" type="button" value="Regresar" name="cmdRegresar"
							language="javascript" onclick="return cmdRegresar_onclick()"> &nbsp;
			<input class="boton" id="cmdConsultarDetalle" onclick="return cmdConsultarDetalle_onclick()" type="button"
										value="Consultar Detalle" name="cmdConsultarDetalle"> &nbsp;
<input class="boton" id="cmdConsultarAgrupado" onclick="return cmdConsultarAgrupado_onclick()" type="button"
										value="Consultar Agrupado" name="cmdConsultarAgrupado"> &nbsp; <input class="boton" id="cmdLimpiar" type="button" value="Limpiar" name="cmdLimpiar" language="javascript"
							onclick="return cmdLimpiar_onclick()"></td>										
          </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr> 
            <td><br> <%=strConsultarFacturas%><br> </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td><script language="JavaScript">crearTablaFooter()</script></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
			</script>
  <script language="JavaScript">
    <!-- // create calendar object(s) just after form tag closed
    var cal1 = new calendar(null, document.forms['frmVentasFacturacionReporteSucursal'].elements['txtEmisionInicio']);
    var cal2 = new calendar(null, document.forms['frmVentasFacturacionReporteSucursal'].elements['txtEmisionFin']);
    var cal3 = new calendar(null, document.forms['frmVentasFacturacionReporteSucursal'].elements['txtCanceladaInicio']);
    var cal4 = new calendar(null, document.forms['frmVentasFacturacionReporteSucursal'].elements['txtCanceladaFin']);
    //-->
</script>
</form>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
</body>
</HTML>
