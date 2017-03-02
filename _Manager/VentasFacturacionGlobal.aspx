<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" enableViewState="False" Explicit="True" Trace="False" Strict="True" CodeBehind="VentasFacturacionGlobal.aspx.vb"  Inherits="com.isocraft.backbone.ccentral.VentasFacturacionGlobal" codePage="28592" %>
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
   document.forms[0].optDiasFaltantes["<%= intoptDiasFaltantes %>"].checked = true;
   
   var intMesId = "<%= intMesId %>";      
   var intDireccionOperativaId = "<%= intDireccionOperativaId %>";
   var intZonaOperativaId = "<%= intZonaOperativaId %>";
   var strSucursalId = "<%= strSucursalId %>";
   
   var intCompaniaid ="<%=intCompaniaid%>";
   var intSucursalid ="<%=intSucursalid%>";
   
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

   <%= strLlenarMesComboBox() %>   
   <%= strLlenarDireccionComboBox() %>
   <%= strLlenarZonaComboBox() %>
   <%= strLlenarSucursalComboBox() %>
   <%= strJavascriptWindowOnLoadCommands %>

}
function cboMes_onchange() {
   if (document.forms[0].elements["cboMes"].selectedIndex > 0 && document.forms[0].elements["cboDireccion"].selectedIndex > 0) {
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
function  cmdConsultar_onclick() {
   if (blnValidarSubmit()) {
       document.forms[0].action = '<%= strFormAction %>';
   	   document.forms[0].target='';
       document.forms[0].submit(); 
    }
}
function blnValidarSubmit() {
   var blnValidar = true;
   
   if ( document.forms[0].elements["cboMes"].selectedIndex == 0 && document.forms[0].elements["cboDireccion"].selectedIndex == 0 && document.forms[0].elements["cboZona"].selectedIndex == 0 && document.forms[0].elements["cboSucursal"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar al menos algun criterio de Mes, Dirección, Zona, Sucursal");
   }
   
   if ( blnValidar && document.forms[0].elements["cboMes"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar el criterio de Mes");
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
    
    var paraInicio = '&intMesVenta=' + document.forms[0].elements["cboMes"].value + 
                     '&intDireccionOperativaId=' + document.forms[0].elements["cboDireccion"].value + 
                     '&intZonaOperativaId='      + document.forms[0].elements["cboZona"].value + 
                     '&strSucursalId='           + document.forms[0].elements["cboSucursal"].value + 
                     '&intDiasFaltantes=' + '<%= Request("optDiasFaltantes")%>'  +
                     '&blnMesDetallado=1' 
    				
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{
		params+= "&" + args[i] + "=" + args[i+1]
	}	
	
    if (action=="VerDetalleMes") {       
       url = 'popVentasFacturacionGlobalVer.aspx?strCmd=VerDetalleMes' + paraInicio + params;       
       var WinVerDetalleSucursal = window.open(url,'PopVerDetalleSucursal','width=720,height=600,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
       
       return;
    }
    
    if (action=="GenerarMes") {           	   
       if (confirm ("\r\rSe generara una factura por día del mes\n\r\n\rVerificar que este cargada toda la información de las sucursales\n\r\n\rContinuar") )  {
           url = 'VentasGenerarFactura.aspx?strCmd=Confirmar' + paraInicio + params;       
           var WinVerDetalleSucursal = window.open(url,'PopGenerarMes','width=780,height=600,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
	   }
       
       return;
    }
        
	if (action=="VerDetallaSucursal") {       
       url = 'popVentasFacturacionGlobalVer.aspx?strCmd=VerDetalleSucursal' + params;       
       var WinVerDetalleSucursal = window.open(url,'PopVerDetalleSucursal','width=720,height=600,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
       
       return;
    }
    

			
	document.forms[0].action = 'VentasFacturacionGlobal.aspx?strCmd=' + action + '&' + params;
	document.forms[0].submit(); 
	document.forms[0].target='';	
}

//-->
		</script>
	</HEAD>
	<body language="javascript" onLoad="return window_onload()">
		<form name="frmVentasFacturacionGlobal" action="about:blank" method="post">
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeader()</script></td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td class="tdtab" width="100%">Está en : <a href="VentasHome.aspx">Ventas</a>:Facturación Global</td>
				</tr>
			</table>
			<table cellspacing="0" cellpadding="0" width="780" border="0">
				<tr>
					<td width="2%">
					<td width="98%" class="tdgeneralcontent">
						<table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td valign="top" height="30"><h1>Facturación Global</h1>
									<p>
										En esta parte se genera la facura global de las ventas de todas las sucursales.</p>
								</td>
							</tr>
							<tr>
								<td><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Criterio 
										De Busqueda</span></td>
							</tr>
						</table>
						<table width="100%" class="tdEnvolventeTablaAzul" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td width="10%" class="tdtexttablebold">* Mes:</td>
								<td width="60%" class="tdpadleft5">
									<select name="cboMes" class="field" id="cboMes" onchange="return cboMes_onchange()">
										<option value="0" selected>-- Elija una mes --</option>
										<option>--------------------</option>
									</select>
								</td>
								<td width="30%">&nbsp;</td>
							</tr>
							<tr>
								<td width="10%" class="tdtexttablebold">* Dirección:</td>
								<td width="60%" class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" onchange="return cboDireccion_onchange()">
										<option value="0" selected>-- Elija una Dirección --</option>
										<option value="-1">Todas las Direcciones</option>
										<option>--------------------</option>
									</select>
								</td>
								<td width="30%" class="tdtexttablebold">
									<input type="radio" value="0" name="optDiasFaltantes" id="optDiasFaltantes"> Todo</td>
							</tr>
							<tr>
								<td width="10%" class="tdtexttablebold">* Zona:</td>
								<td width="60%" class="tdpadleft5">
									<select name="cboZona" class="field" id="cboZona" language="javascript" onChange="return cboZona_onchange()">
										<option value="0" selected>--- Elija un Zona ---</option>
										<option value="-1">Todos las zonas</option>
										<option>--------------------</option>
									</select>
								</td>
								<td width="30%" class="tdtexttablebold"><input type="radio" value="1" name="optDiasFaltantes" id="optDiasFaltantes">
									Con días Faltantes</td>
							</tr>
							<tr>
								<td width="10%" class="tdtexttablebold">* Sucursal:</td>
								<td width="60%" class="tdpadleft5">
									<select name="cboSucursal" class="field" id="cboSucursal" onchange="return cboSucursal_onchange()">
										<option value="0" selected>-- Elija una sucursal --</option>
										<option value="-1">Todas las sucursales</option>
										<option>--------------------</option>
									</select>
								</td>
								<td width="30%" class="tdtexttablebold"><input type="radio" value="2" name="optDiasFaltantes" id="optDiasFaltantes">
									Con días completo</td>
							</tr>
						</table>
						<br>
						<table width="100%" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td><input class="boton" id="cmdConsultar" onclick="return cmdConsultar_onclick()" type="button"
										value="Consultar" name="cmdConsultar"></td>
							</tr>
						</table>
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td><br><%= strRecordBrowser %><br>
								</td>
							</tr>
						</table>
					</td>
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
		</form>
		<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
	</body>
</HTML>
