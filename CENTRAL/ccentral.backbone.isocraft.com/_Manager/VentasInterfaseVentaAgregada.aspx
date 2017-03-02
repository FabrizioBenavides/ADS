<%@ Page Language="vb" AutoEventWireup="false" Codebehind="VentasInterfaseVentaAgregada.aspx.vb" Inherits="com.isocraft.backbone.ccentral.VentasInterfaseSapVentaAgregada"   codePage="1252"  EnableSessionState="False" enableViewState="False"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="css/menu.css" rel="stylesheet" type="text/css">
		<link href="css/estilo.css" rel="stylesheet" type="text/css">
		<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
		<script language="JavaScript" src="js/calendario.js"></script>
		<script language="JavaScript" src="js/cal_format00.js"></script>
		<script language="javascript" id="clientEventHandlersJS">
<!--
   strUsuarioNombre = "<%= strUsuarioNombre %>";
   strFechaHora = "<%= strHTMLFechaHora %>";
   
function window_onload() {
   document.forms[0].action = "<%= strFormAction %>";   
   document.all.EsperaProceso.style.visibility="hidden"; 
         
   var intDireccionId = "<%= intDireccionId %>";
   var intZonaId = "<%= intZonaId %>";
   var strCompaniaSucursalId = "<%= strCompaniaSucursalId %>";
   
   var intCompaniaid ="<%=intCompaniaid%>";
   var intSucursalid = "<%=intSucursalid%>";   

        
   document.forms[0].elements["txtFechaInicio"].value = "<%= strFechaInicio %>";
   document.forms[0].elements["txtFechaFin"].value = "<%= strFechaFinal %>";
     
   if (intDireccionId == "-1") {
       document.forms[0].elements["cboDireccion"].options[1].selected = true;
       document.forms[0].elements["cboZona"].disabled = true;
       document.forms[0].elements["cboSucursal"].disabled = true;
   }
     
   if (intZonaId == "-1") {
       document.forms[0].elements["cboZona"].options[1].selected = true;
       document.forms[0].elements["cboSucursal"].disabled = true;
   }
     
   if (strCompaniaSucursalId == "-1|-1") {
       document.forms[0].elements["cboSucursal"].options[1].selected = true;
   }
     
   <%= strLlenarDireccionComboBox() %>
   <%= strLlenarZonaComboBox() %>
   <%= strLlenarSucursalComboBox() %>
   <%= strJavascriptWindowOnLoadCommands %>;  
      
   document.forms[0].elements["cmdConsultar"].focus();    
}

function cboDireccion_onchange() {
   if (document.forms[0].elements["cboDireccion"].selectedIndex > 0) {
       document.forms[0].elements["cboZona"].selectedIndex = 0;
       
       document.forms[0].action = "<%= strFormAction %>";
       document.forms[0].submit();
   }
   return(true);
}

function cboZona_onchange() {
   if (document.forms[0].elements["cboZona"].selectedIndex > 0) {
       document.forms[0].elements["cboSucursal"].selectedIndex = 0;
       
       document.forms[0].action = "<%= strFormAction %>";
       document.forms[0].submit();
   }
   return(true);
}

function cboSucursal_onchange() {
   if (blnValidarSubmit()) {   
       document.forms[0].elements['cmdGenerar'].disabled=false;    
       document.forms[0].action = "<%= strFormAction %>" + "?strCmd=Consultar";
       document.forms[0].submit(); 
    }
    
}
function blnValidarSubmit() {
   var blnValidar = true;
   
   if ( document.forms[0].elements["cboDireccion"].selectedIndex == 0 && document.forms[0].elements["cboZona"].selectedIndex == 0 && document.forms[0].elements["cboSucursal"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar al menos algun criterio de Dirección, Zona o Sucursal");
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

function cmdLimpiar_onclick() {
    window.location.href = "VentasInterfaseVentaAgregada.aspx";
}


function cmdConsultar_onclick() {
   if (blnValidarSubmit()) {       
       document.forms[0].elements['cmdGenerar'].disabled=false;
       document.forms[0].action = "?strCmd=Consultar";
       document.forms[0].submit(); 
       document.forms[0].action = "<%=strFormAction%>"; 
    }
}

function cmdGenerar_onclick() {
   if (blnValidarSubmit()) {          
 	   document.all.EsperaProceso.style.visibility="visible"; 
	   document.all.EsperaProceso.focus();       
	   document.forms[0].elements['cmdGenerar'].disabled=true;
	   
       document.forms[0].action = "?strCmd=Generar";
       document.forms[0].submit();  
       document.forms[0].action = "<%=strFormAction%>"; 
   }    
}
function cmdSolicitar_onclick(){
 	   document.all.EsperaProceso.style.visibility="visible"; 
	   document.all.EsperaProceso.focus();       
	   document.forms[0].elements['cmdNavegadorRegistrosAgregar'].disabled=true;
	   
       document.forms[0].action = "?strCmd=Consultar&strRBCmd=Solicitar";
       document.forms[0].submit();  
       document.forms[0].action = "<%=strFormAction%>";    
}

//-->
		</script>
	</HEAD>
	<body onload="return window_onload()">
		<form name="frmVentasInterfaseSapVentaAgregada" action="about:blank" method="post">
			<table id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
			</table>
			<table id="Table3" cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtab" width="770">Está en : Ventas : Interfase SAP : Venta Agregada</td>
				</tr>
			</table>
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent"><h1>Interfase SAP Venta Agregada</h1>
						<p>Seleccionar los criterio&nbsp;para verificar&nbsp;la venta agregada.Al consultar 
							se mostraran las sucursales cuya venta agregada no se encuentra en concetrador. 
							De la lista desplegada se pueden solicitar para que las sucursales las 
							trasmitan al concentrador. Al generar se creara el archivo con la venta de las 
							sucursales que ya esten en concentrador.</p>
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="20%" class="tdtexttablebold">* Dirección:
								</td>
								<td width="30%" class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" language="javascript" onchange="return cboDireccion_onchange()">
										<option value="0" selected>--- Elija una dirección ---</option>
										<option value="-1">Todas las direcciones</option>
										<option>--------------------</option>
									</select>
								</td>
								<td width="50%" colSpan="2">&nbsp;</td>
							</tr>
							<tr>
								<td width="20%" class="tdtexttablebold">* Zona:
								</td>
								<td width="30%" class="tdpadleft5"><select name="cboZona" class="field" id="cboZona" language="javascript" onchange="return cboZona_onchange()">
										<option value="0" selected>-- Elija una zona --</option>
										<option value="-1">Todas las zonas</option>
										<option>--------------------</option>
									</select></td>
								<td width="50%" colSpan="2">&nbsp;</td>
							</tr>
							<tr>
								<td width="20%" class="tdtexttablebold">* Sucursal:</td>
								<td width="30%" class="tdpadleft5"><select name="cboSucursal" class="field" id="cboSucursal" language="javascript" onchange="return cboSucursal_onchange(this)">
										<option value="0|0" selected>-- Elija una sucursal --</option>
										<option value="-1|-1">Todas las sucursales</option>
										<option>--------------------</option>
									</select></td>
								<td width="50%" colSpan="2">&nbsp;</td>
							</tr>
							<tr>
								<td width="20%" class="tdtexttablebold">* Fecha Inicio:</td>
								<td width="30%" class="tdpadleft5"><input class="field" id="txtFechaInicio" type="text" maxLength="12" size="12" name="txtFechaInicio"><A href="javascript:cal1.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></A></td>
								<td width="20%" class="tdtexttablebold">* Fecha Inicio:</td>
								<td width="30%" class="tdpadleft5"><input class="field" id="txtFechaFin" type="text" maxLength="12" size="12" name="txtFechaFin"><A href="javascript:cal2.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></A></td>
							</tr>
						</table>
						<br>
						<table border="0" STYLE="TABLE-LAYOUT:fixed" width="100%" cellspacing="0" cellpadding="0">
							<tr>
								<td colspan="4">
									<input name="cmdConsultar" type="button" class="button" value="Consultar" language="javascript"
										onclick="return cmdConsultar_onclick()">&nbsp;&nbsp; <input name="cmdGenerar" type="button" class="button" value="Generar" language="javascript"
										onclick="return cmdGenerar_onclick()">
								</td>
							</tr>
						</table>
						<div ID="EsperaProceso" style="Z-INDEX:5;LEFT:25%;VISIBILITY:hidden;POSITION:absolute;TOP:50%">
							<table border="1" bordercolor="#000066" cellpadding="0" cellspacing="0" height="150" width="200"
								id="tblEsperaProceso">
								<tr>
									<td>
										<img src="../static/images/logoEspera.gif" height="41" width="48" border="0">
									</td>
									<td width="100%" height="100%" bgcolor="#cccccc" align="center" valign="middle">
										<font face="Arial" size="4" color="#000066"><b>Espere a que finalice el proceso.</b></font>
									</td>
								</tr>
							</table>
						</div>
						<div id="divSucursal">
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td><br>
										<%=strRecordBrowserHTML %>
										<br>
									</td>
								</tr>
							</table>
						</div>
					</td>
				</tr>
			</table>
			<table id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaFooterCentral()</script>
					</td>
				</tr>
			</table>
			<script language="JavaScript">
           <!--
           new menu (MENU_ITEMS, MENU_POS);
           //-->
			</script>
			<script language="JavaScript">
           <!-- // create calendar object(s) just after form tag closed
           var cal1 = new calendar(null, document.forms['frmVentasInterfaseSapVentaAgregada'].elements['txtFechaInicio']);
           var cal2 = new calendar(null, document.forms['frmVentasInterfaseSapVentaAgregada'].elements['txtFechaFin']);
           //-->
			</script>
		</form>
		<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
	</body>
</HTML>
