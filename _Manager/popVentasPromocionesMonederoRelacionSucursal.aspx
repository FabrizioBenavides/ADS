<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" enableViewState="False" Explicit="True" Trace="False" Strict="True" CodeBehind="popVentasPromocionesMonederoRelacionSucursal.aspx.vb"      Inherits="com.isocraft.backbone.ccentral.popVentasPromocionesMonederoRelacionSucursal" codePage="28592" %>
<HTML>
	<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<%  '====================================================================
    ' Page          : popVentasPromocionesMonederoRelacionSucursal.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : 
    ' Copyright     : 2007
    ' Company       : Farmacias Benavides
    ' Author        : J.Antonio Hernandez    
    ' Last Modified : 01 de Noviembre 2007
    '====================================================================
%>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
			<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
			<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
			<script language="javascript" id="clientEventHandlersJS">

<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
   document.forms[0].action = "<%= strFormAction %>";   
      
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
   
   <%= strLlenarDireccionComboBox() %>
   <%= strLlenarZonaComboBox() %>
   <%= strLlenarSucursalComboBox() %>
   <%= strJavascriptWindowOnLoadCommands %>
      
}

function cboDireccion_onchange() {
      
   if (document.forms[0].elements["cboDireccion"].selectedIndex > 0) {   
       document.forms[0].elements["cboZona"].selectedIndex = 0;  
       
       var parametrosInicio = 'intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>';         
       
       document.forms[0].action = '<%= strFormAction %>?' + parametrosInicio;
       document.forms[0].submit();
   }
   
   return(true);
}

function cboZona_onchange() {
   if (document.forms[0].elements["cboZona"].selectedIndex > 0) {
       document.forms[0].elements["cboSucursal"].selectedIndex = 0;
       
       var parametrosInicio = 'intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>';
       
       document.forms[0].action = '<%= strFormAction %>?' + parametrosInicio ;
	   document.forms[0].target='';
       document.forms[0].submit();
   }
   return(true);
}

function cboSucursal_onchange() {
   if (blnValidarSubmit()) {
   
       var parametrosInicio = 'intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>';
       document.forms[0].action = '<%= strFormAction %>?' + parametrosInicio ;
   	   document.forms[0].target='';
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

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];  
    var parametrosInicio = 'intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>';
         
	if (action == "AgregarSucursal") 	{
        document.forms[0].target="ifrOculto";
	}
	
	if (action == "EliminarSucursal")
	{	
		if  (!confirm ('Esta seguro de eliminar la sucursal de la promoción?') )  {
			return;
		}
		else {
             document.forms[0].target="ifrOculto";
		}
	}
	
	if (action == "EliminarMasiva")
	{	
       if  (confirm ('Se eliminaran todas las sucursales del listado, continuar?') )  {
           
           var parametrosAccion = '?strCmd=EliminarSucursal&intPromocionEliminarId=' + '<%=Request("intPromocionId")%>' + '&intDireccionEliminarId=' + document.forms[0].elements["cboDireccion"].value + '&intZonaEliminarId=' + document.forms[0].elements["cboZona"].value + '&intCompaniaEliminarId=0&intSucursalEliminarId=0';
                      	
	       document.forms[0].action = 'popVentasPromocionesMonederoRelacionSucursal.aspx' + parametrosAccion + '&' + parametrosInicio ;
	       document.forms[0].target="ifrOculto";	       
	       document.forms[0].submit(); 
	       document.forms[0].target='';
       }
       else {
           return;
	   }
	}
		
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{
		params+= "&" + args[i] + "=" + args[i+1]
	}
			
	document.forms[0].action = 'popVentasPromocionesMonederoRelacionSucursal.aspx?strCmd=' + action + '&' + parametrosInicio + params;
	document.forms[0].submit(); 
	document.forms[0].target='';	
}

function fnUpAgregarSucursal(intErrorAgregar,intContadorAlta) {
    if (intErrorAgregar == -100) {
       alert("Error al agregar las sucursales a la promoción seleccionada");
	}
	else {
	   if (intContadorAlta>0) {
	  		alert("Se agregaron/actualizaron [" + intContadorAlta + "] sucursales");   
	  		
			 var parametrosInicio = 'intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>';
			 
			 document.forms[0].action = '<%=strFormAction%>?' + parametrosInicio; 
             document.forms[0].submit();   
       }
	   else {
	   		alert("No hubo sucursales por agregar, verifique");   
	   }
	}
}

function fnUpEliminarSucursal(intActualizacion) {

    if (intActualizacion > 0) {
    
        alert ('Se eliminaron de la promocion [' + intActualizacion + '] Sucursales');
        
        var parametrosInicio = 'intPromocionId=' + '<%=Request("intPromocionId")%>' + '&strPromocionNombre=' + '<%=Request("strPromocionNombre")%>' + '&dtmPromocionInicio=' + '<%=Request("dtmPromocionInicio")%>' + '&dtmPromocionFin=' + '<%=Request("dtmPromocionFin")%>';
         	
	    document.forms[0].action = 'popVentasPromocionesMonederoRelacionSucursal.aspx?' + parametrosInicio;
	    document.forms[0].submit(); 	    
    }
    else {
       if (intActualizacion < 0) {
            alert ('No se pudo hacer la eliminación de sucursales');
       }
    }	        
}

function cmdCerrar_onclick() {	
    opener.document.forms[0].elements['cmdEjecutar'].onclick();
	window.close();	
	return(true);
}

//-->
</script>
</head>
<body language="javascript" leftMargin="0" topMargin="0" onload="return window_onload()">
<form name="frmMonederoRelacionSucursal" method="post" encType="multipart/form-data" runat="server">
<table height="158" cellSpacing="0" cellPadding="0" width="700" border="0">
				<tr>
					<td width="2%">&nbsp;</td>
					<td width="96%">
						<table width="100%" align="center">
							<tr>
								<td class="tdlogopop" height="21">
									<img height="54" src="../static/images/logo_pop.gif" width="177"></td>
							</tr>
							<tr>
								<td width="100%" valign="top" height="30"><h1>Relación Sucursal Promoción Monedero
									</h1>
									<p>
										En esta parte se pueden consultar y/o agregar promociones a las sucursales.</p>
								</td>
							</tr>
						</table>
						<table width="100%" class="tdEnvolventeTablaAzul" cellspacing="0" cellpadding="0" border="0">
							<tr>
								<td width="10%" class="tdtexttablebold" valign="middle">Promoción:</td>
								<td width="90%" class="tdtextablaBoldAzul" valign="middle"><%= Request("intPromocionId") %>
									-
									<%= Request("strPromocionNombre") %>
								</td>
							</tr>
							<tr>
								<td width="10%" class="tdtexttablebold" valign="middle">Vigencia:</td>
								<td width="90%" class="tdtextablaBoldAzul" valign="middle"><%= Request("dtmPromocionInicio") %>
									al
									<%= Request("dtmPromocionFin") %>
								</td>
							</tr>
						</table>
						<br>
						<table width="100%" class="tdEnvolventeTablaGris" cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td width="15%" class="tdtexttablebold">* Dirección:</td>
								<td width="85%" class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" onchange="return cboDireccion_onchange()">
										<option value="0" selected>-- Elija una Dirección --</option>
										<option value="-1">Todas las Direcciones</option>
										<option>--------------------</option>
									</select>
								</td>
							</tr>
							<tr>
								<td width="15%" class="tdtexttablebold">* Zona:</td>
								<td width="85%" class="tdpadleft5">
									<select name="cboZona" class="field" id="cboZona" language="javascript" onChange="return cboZona_onchange()">
										<option value="0" selected>--- Elija un Zona ---</option>
										<option value="-1">Todos las zonas</option>
										<option>--------------------</option>
									</select>
								</td>
							</tr>
							<tr>
								<td width="15%" class="tdtexttablebold">* Sucursal:</td>
								<td width="85%" class="tdpadleft5">
									<select name="cboSucursal" class="field" id="cboSucursal" onchange="return cboSucursal_onchange()">
										<option value="0" selected>-- Elija una sucursal --</option>
										<option value="-1">Todas las sucursales</option>
										<option>--------------------</option>
									</select>
								</td>
							</tr>
						</table>
						<table width="100%">
							<tr>
								<td><input class="boton" id="cmdCerrar" onclick="return cmdCerrar_onclick()" type="button"
										value="Cerrar" name="cmdCerrar">
								</td>
							</tr>
							<tr>
								<td>
									<br>
									<span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Sucursales 
              Incluidas</span>
									<%= strConsultarSucursales %>
								</td>
							</tr>
						</table>
					</td>
					<td width="2%">&nbsp;</td>
				</tr>
			</table>
		</form>
		<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
	</body>
</HTML>
