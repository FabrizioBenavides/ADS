<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DetalleReporteImagen.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsDetalleReporteImagen" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides</TITLE>
		<%
    '====================================================================
    ' Page          : CapturaConsumidorcom.isocraft.backbone.ccentral.aspx
    ' Title         : Pantalla de captura de Consumidor
    ' Description   :Pantalla de captura de Consumidor
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Enrique Longoria
    ' Version       : 1.0
    ' Last Modified : Monday, Feb 16th, 2005
    '====================================================================
%>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="css/menu.css" type="text/css" rel="stylesheet">
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/FotoLabUtils.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/calendario.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/cal_format00.js" type="text/JavaScript"></script>
		<style>
		.textomensaje {
font-family: Arial, Helvetica, sans-serif;
font-size: 12px;
color: #00005C;
padding: 0 0 5px 0;
}
.tdmensaje {
font-size: 9px;
color: #767373;
background-color: #E6E6E6;
padding-left: 10px;
border-bottom: 1px solid #666;
border-top: 1px solid #C2C2C2;
}
</style>
<script language="javascript" id="clientEventHandlersJS">
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
strSucursalNombre = "<%= strNombreSucursal %>";
strSucursalId = "<%= strSucursalId%>";

<%Select Case Request("strCmd")%>
	<%Case Me._CAMBIAR_PAG,"TraerListadoAdmin","TraerListadoCriterio"%>	
		parent.parent.document.getElementById('divHtmlList').innerHTML= "<%= me.strGenerarListado("")%>";
	<%End Select%>
	
//-->
</script>


<%if Request("strCmd") ="" then %>	
	<script language="javascript" id="ImagenJS">
	function window_onload() 
	{
		<%= me.strDetalleImagen()%>
		document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("1")%>";
	}

	function doSubmit()
	{  args = doSubmit.arguments;
		var action = args[0];
		var params = ""
		for (i=1; i < (args.length-1); i +=2)
		{params+= "&" + args[i] + "=" + args[i+1]}	
		document.forms[0].action = "<%= strThisPageName %>?strCmd=" + action + params    
		document.forms[0].target="ifrDetalleImagen";	
		document.forms[0].submit();  
	}
	//-->
	</script>
		</HEAD>
		<body onload="window_onload()">
	<form id="Form1" name="frmImagen" action="about:blank" method="post">	

	<input type=hidden class=campotabla  name=dtmInicio size=10 value=<%= Request("dtmInicio")%>>	
	<input type=hidden class=campotabla  name=dtmFinal size=10 value=<%= Request("dtmFinal")%>>	
	<input type=hidden class=campotabla  name=intSucursalUEN size=10 value=<%= Request("intSucursalUEN")%>>	
	<input type=hidden class=campotabla  name=intTipodeBusqueda size=10 value=<%= Request("intTipodeBusqueda")%>>	
	<input type=hidden class=campotabla  name=dtmConsultaOrdenInicio size=10 value=<%= Request("dtmConsultaOrdenInicio")%>>	
	<input type=hidden class=campotabla  name=dtmConsultaOrdenFinal size=10 value=<%= Request("dtmConsultaOrdenFinal")%>>	
	<input type=hidden class=campotabla  name=intTipoReporteId size=10 value=<%= Request("intTipoReporteId")%>>	
	<input type=hidden class=campotabla  name=intTipoPagoId size=10 value=<%= Request("intTipoPagoId")%>>	
	<input type=hidden class=campotabla  name=strDireccionOperativaNombre size=10 value=<%= Request("strDireccionOperativaNombre")%>>	
	<input type=hidden class=campotabla  name=intDireccionOperativaId size=10 value=<%= Request("intDireccionOperativaId")%>>
	<input type=hidden class=campotabla  name=strZonaOperativaNombre size=10 value=<%= Request("strZonaOperativaNombre")%>>	
	<input type=hidden class=campotabla  name=intZonaOperativaId size=10 value=<%= Request("intZonaOperativaId")%>>
	<input type=hidden class=campotabla  name=strLaboratoriosId size=10 value=<%= Request("strLaboratoriosId")%>>	
	<input type=hidden class=campotabla  name=strFarmaciaId size=10 value=<%= Request("strFarmaciaId")%>>
		
					<table width="100%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td width="152"><img src="images/imgBenavidesLogoPop.gif" width="152" height="51"></td>
						</tr>
					</table>
					<table width="100%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td class="tdclosewindow">x <a href="#" onClick="window.close();">cerrar ventana </a> </td>
						</tr>
					</table>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0" >
			<tr>
				<td class="tdgeneralcontent">	
					<table  border="0" cellspacing="0" cellpadding="0" width="100%">
						<tr>
							<td class="textomensaje"><br><div id=divHtmlList name=divHtmlList></div>	
							<br><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">  Ordenes  en Proceso Terminadas </span>
							<!-- inicio Div EXTRA -->
							<div id=divExtra >					    
								<table class="tdenvolventetablas" cellSpacing="0" cellPadding="0" width="100%" border="0" >				
								<tr><td class="txtitintabla" Align="right" width="20%">Ordenes:&nbsp;</td><td class="tdconttablas" colspan=2  Align="left" width="80%"><div id=divTrabajo name=divTrabajo></div></td></tr>	
								<tr><td class="txtitintabla" Align="right" width="20%">Tiempo:&nbsp;</td><td class="tdconttablas" colspan=2 Align="left" width="80%"><div id=divTiempo name=divTiempo></div></td></tr>	
								<tr><td class="txtitintabla" Align="right" width="20%">Promedio:&nbsp;</td><td class="tdconttablas" colspan=2  Align="left" width="80%"><div id=divPromedio name=divPromedio></div></td></tr>													
								</table>						
							</div>
							<!-- termina Div EXTRA -->

							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
					<table cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>	
						<td>
							<div style='position:absolute;top:690'>
							<table border="0" cellpadding="0" cellspacing="0" width="100%" >
							<tr>
								<td class="tdmensaje">Sistema Administrador de Puntos de Venta  &copy; 2005 Farmacias Benavides</td>
							</tr>
							</table>
							</div>
						</td>
					</tr>	
					</table>

		</form>	
		<iframe name="ifrDetalleImagen" src="" width="<%=frameW%>" height="<%=frameH%>"></iframe>	
		</body>
<%Else if Request("strCmd") =Me._IMPRIMIR then  %>
<LINK href="css/print.css" type="text/css" rel="stylesheet">
</HEAD>
<script>
		function printMe()
		 {	window.focus();
			window.print()	
		} 		
</script>		
<body onload=printMe()>
	<div id="divImprimir"><%= strGenerarImpresion%></div>
</form>
</body>
<%Else if Request("strCmd") = Me._EXPORTAR then  %>	
</HEAD>
<script>				
	var myWindow=window.open("<%= strThisPageName %>?strCmd=<%=Me._VENTANA_EXCEL%><%=strExportarListado()%>", "exportDocument", "menubar=yes,scrollbars=yes,resizable=yes,width=400,height=400,statusbar=no");								
</script>		
<%Else if Request("strCmd") = Me._VENTANA_EXCEL then  %>	
	<%cambiaExcel%>
	<BODY>
		<%= strGenerarImpresion%>
	</BODY>
<%End If%>
</HTML>
