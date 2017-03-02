<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SistemaRevisarAutorizacionRecetas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SistemaRevisarAutorizacionRecetas"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="css/menu.css" type="text/css" rel="stylesheet">
			<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
				<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/calendario.js"></script>
				<script language="JavaScript" src="js/cal_format00.js"></script>
				<script language="javascript" id="clientEventHandlersJS">
<!--
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
   document.forms[0].action = "<%= strFormAction %>";   
      
   var intDireccionId = "<%= intDireccionId %>";
   var intZonaId = "<%= intZonaId %>";
   var strSucursalId = "<%= strSucursalId %>";
    
   var intCompaniaid ="<%=intCompaniaid%>";
   var intSucursalid = "<%=intSucursalid%>";   
     
   document.forms[0].elements["txtRecetaInicio"].value = "<%= strRecetaInicio %>";
   document.forms[0].elements["txtRecetaFin"].value = "<%= strRecetaFin %>";
     
   if (intDireccionId == "-1") {
       document.forms[0].elements["cboDireccion"].options[1].selected = true;
       document.forms[0].elements["cboZona"].disabled = true;
       document.forms[0].elements["cboSucursal"].disabled = true;
   }
     
   if (intZonaId == "-1") {
       document.forms[0].elements["cboZona"].options[1].selected = true;
       document.forms[0].elements["cboSucursal"].disabled = true;
   }
     
   if (strSucursalId == "-1") {
       document.forms[0].elements["cboSucursal"].options[1].selected = true;
   }
     
   <%= strLlenarDireccionComboBox() %>
   <%= strLlenarZonaComboBox() %>
   <%= strLlenarSucursalComboBox() %>
   <%= strJavascriptWindowOnLoadCommands %>;  
            
   document.forms[0].elements["cmdImprimir"].focus();    
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
       document.forms[0].elements['cmdExportar'].disabled=false;
       document.forms[0].action = "<%= strFormAction %>";
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

function cmdRegresar_onclick() {
   window.location.href = "SistemaRecetas.aspx";
}

function cmdConsultar_onclick() {
   if (blnValidarSubmit()) {       
       document.forms[0].elements['cmdExportar'].disabled=false;
       document.forms[0].action = "<%= strFormAction %>" + "?strCmd=Consultar";
       document.forms[0].submit(); 
   }
}

function cmdImprimir_onclick() {
    if (blnValidarSubmit()) {
       document.ifrPageToPrint.document.all.divBody.innerHTML= "<%=strRecordBrowserImpresion%>";
       document.ifrPageToPrint.focus();
	   window.print();   
	       
    }
}

function cmdExportar_onclick() {
   if (blnValidarSubmit()) {          
       document.forms[0].action += "?strCmd=Exportar";
       document.forms[0].submit();  
       document.forms[0].action = "<%=strFormAction%>"; 
   }    
}




function txtRecetaInicio_onchange() {
   if(document.forms[0].elements["txtRecetaFin"].value == '') {
       document.forms[0].elements["txtRecetaFin"].focus();
   }
   else {
       if (blnValidarSubmit()) {       
           document.forms[0].elements['cmdExportar'].disabled=false;
           document.forms[0].action = "<%= strFormAction %>";
           document.forms[0].submit(); 
       }
   }
}

function txtRecetaFin_onchange() {
   if (blnValidarSubmit()) {       
       document.forms[0].elements['cmdExportar'].disabled=false;
       document.forms[0].action = "<%= strFormAction %>";
       document.forms[0].submit(); 
    }
}

//-->
				</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
		<form name="frmPage" action="about:blank" method="post">
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td width="770" class="tdtab">Est&aacute; en : <a href="Sistema.aspx">Sistema</a> : <a href="SistemaClientesEspeciales.aspx">Clientes especiales</a> : <a href="SistemaRecetas.aspx">Recetas</a> : Revisar Autorización Recetas </td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent" width="780">
						<h1>Reporte de Autorizaciones de Recetas</h1>
						<p>Aquí podrá consultar el empleado que autorizo la venta a crédito&nbsp;en las 
							sucursales.</p>
						<h2>Alcance de la Consulta</h2>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="tdtexttablebold" width="89">* Dirección:</td>
								<td class="tdpadleft5" width="120">
									<select name="cboDireccion" class="field" id="cboDireccion" language="javascript" onChange="return cboDireccion_onchange()">
										<option value="0" selected>--- Elija una dirección ---</option>
										<option value="-1">Todas las direcciones</option>
										<option>--------------------</option>
									</select>
								</td>
								<td width="79">&nbsp;</td>
								<td width="395">&nbsp;</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="89">* Zona:</td>
								<td class="tdpadleft5"><select name="cboZona" class="field" id="cboZona" onchange="return cboZona_onchange()">
										<option value="0" selected>-- Elija una zona --</option>
										<option value="-1">Todas las zonas</option>
										<option>--------------------</option>
									</select>
								</td>
								<td width="79">&nbsp;</td>
								<td width="395">&nbsp;</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="89">* Sucursal:</td>
								<td class="tdpadleft5">
									<select name="cboSucursal" class="field" id="cboSucursal" onchange="return cboSucursal_onchange()">
										<option value="0" selected>-- Elija una sucursal --</option>
										<option value="-1">Todas las sucursales</option>
										<option>--------------------</option>
									</select>
								</td>
								<td width="79">&nbsp;</td>
								<td width="395">&nbsp;</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="89">* Fecha Inicio:</td>
								<td class="tdpadleft5"><input class="field" id="txtRecetaInicio" type="text" maxLength="12" size="12" name="txtRecetaInicio"
										onchange="return txtRecetaInicio_onchange()"> <A href="javascript:cal1.popup()">
										<IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></A>
								</td>
								<td class="tdtexttablebold" width="79">* Fecha Fin:</td>
								<td class="tdpadleft5" width="395"><input class="field" id="txtRecetaFin" type="text" maxLength="12" size="12" name="txtRecetaFin"
										onchange="return txtRecetaFin_onchange()"> <A href="javascript:cal2.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></A></td>
							</tr>
						</table>
						<br>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="100%">
									<input language="javascript" class="button" id="cmdRegresar" onclick="return cmdRegresar_onclick()"
										type="button" value="Regresar" name="cmdRegresar"> <input language="javascript" class="button" id="cmdConsultar" onclick="return cmdConsultar_onclick()"
										type="button" value="Consultar" name="cmdConsultar"> <input language="javascript" class="button" id="cmdExportar" onclick="return cmdExportar_onclick()"
										type="button" value="Exportar" name="cmdExportar"> <input language="javascript" class="button" id="cmdImprimir" onclick="return cmdImprimir_onclick()"
										type="button" value="Imprimir" name="cmdImprimir">
								</td>
							</tr>
							<tr>
								<td width="100%">
									<%=strRecordBrowserHTML %>
									<br>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaFooterCentral()</script>
					</td>
				</tr>
			</table>
			<iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0"
				marginwidth="0"></iframe>
			<script language="JavaScript">
    <!--
    new menu (MENU_ITEMS, MENU_POS);
    //-->
			</script>
			<script language="JavaScript">
    <!-- // create calendar object(s) just after form tag closed
    var cal1 = new calendar(null, document.forms['frmPage'].elements['txtRecetaInicio']);
    var cal2 = new calendar(null, document.forms['frmPage'].elements['txtRecetaFin']);
    //-->
			</script>
		</form>
	</body>
</HTML>
