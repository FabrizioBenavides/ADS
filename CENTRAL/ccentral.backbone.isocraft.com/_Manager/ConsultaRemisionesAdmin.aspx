<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ConsultaRemisionesAdmin.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsConsultaRemisionesAdmin" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides : Sistema Administrador de Puntos de Venta</TITLE>
<%
    '====================================================================
    ' Page          : ConsultaRemisionesAdmin.aspx
    ' Title         : consulta de Remisiones
    ' Description   : consulta de Remisiones
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Enrique Longoria
    ' Version       : 1.0
    ' Last Modified : Monday, Mar 17th, 2005
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
		<script language="JavaScript" src="js/Validator.js" type="text/JavaScript"></script>		
		
<script language="javascript" id="reloadable">
<!--
	strUsuarioNombre = "<%= strUsuarioNombre %>";
	strFechaHora = "<%= strHTMLFechaHora %>";
	strSucursalNombre = "<%= strNombreSucursal %>";
	strSucursalId = "<%= strSucursalId%>";

if (parent.parent.document != null)
{
<%= me.strActions(Request("strCmd"))%>		
<%Select Case Request("strCmd")%>	
	<%Case Me._TRAER_LISTADO%>	
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%=strGenerarListado("")%>";	
		parent.parent.mostrarDiv('divDetalleRemision',false);
		parent.parent.mostrarDiv('divListadoRemisiones',true);		
	<%Case Me._EDITAR%>	
		parent.parent.mostrarDiv('divDetalleRemision',true);
		parent.parent.mostrarDiv('divListadoRemisiones',false);			
		parent.parent.mostrarDiv('divDetalleOrden',false);
		parent.parent.document.getElementById('divListadoOrdenesRemision').innerHTML="<%=strListadoDeOrdenes()%>";			
	<%Case "VerOrden"%>	
		parent.parent.mostrarDiv('divDetalleOrden',true);
		parent.parent.mostrarDiv('divDetalleRemision',false);		
		parent.parent.mostrarDiv('divListadoRemisiones',false);					
		parent.parent.document.getElementById('divListadoTrabajosOrden').innerHTML="<%=strListadoDeTrabajos()%>";		
	<%End Select%>	
	} 	
	//-->
</script>	

<%if Request("strCmd") ="" then %>	
<script language="javascript" id="notReloadable">
<!--	
initText='-Todos-';
function doSubmit()
	{  	
	args = doSubmit.arguments;
	var action = args[0];		
	var isOk=1;
	
	//validacion de fechas
	if ((document.forms[0].dtmOrdenFechaEntregaIngresadaInicio.value.length==0 && document.forms[0].dtmOrdenFechaEntregaIngresadaFin.value.length>0  )
	 || (document.forms[0].dtmOrdenFechaEntregaIngresadaFin.value.length==0 && document.forms[0].dtmOrdenFechaEntregaIngresadaInicio.value.length>0  )	)
	 {alert('Favor de completar el rango de Fechas.'); isOk=0;}
	 if (document.forms[0].dtmOrdenFechaEntregaIngresadaInicio.value.length>0 &&document.forms[0].dtmOrdenFechaEntregaIngresadaFin.value.length>0  )	 
	 {
		if (validateDate(document.forms[0].dtmOrdenFechaEntregaIngresadaInicio,'dd/MM/yyyy')==false)	{isOk=0;}
	if (validateDate(document.forms[0].dtmOrdenFechaEntregaIngresadaFin,'dd/MM/yyyy')==false)	{isOk=0;}	
	if (validateStartAndEndDate("dtmOrdenFechaEntregaIngresadaInicio","dtmOrdenFechaEntregaIngresadaFin",'dd/MM/YYYY')==false)
		{alert('La Fecha de Fin  debe ser mayor o igual que la de Inicio.\nFavor de verificar  el rango de las fechas.')	; isOk=0;return false;}
	}
	
	if (isOk==1)
		{
		var params = ""
		for (i=1; i < (args.length-1); i +=2)
		{params+= "&" + args[i] + "=" + args[i+1];}
		document.forms[0].action = "<%= strThisPageName %>?strCmd="+action+ params;
		document.forms[0].target="ifrOculto";		
		document.forms[0].submit();
		}else{return false;}
}	

function traerFecha(objFecha,objCalendar){	
	var fechaObj=eval('document.forms[0].'+objFecha);	
	if (fechaObj.value=='')
	{objCalendar.popup(0,true);}
}

function obtenerValorBusqueda(objNombre)
{
//alert(objNombre);
 var val=eval('document.forms[0].'+objNombre+'.value');
	if (val=='' || val==initText){val='_';}
	return val;
}

function traerFechaPicker(objFecha,objCalendar)
{
var textboxFecha=eval('document.forms[0].'+objFecha);
	if(textboxFecha.value !='')
	{ //if(validateDate(textboxFecha,'dd/MM/YYYY')==true)
		{	textboxFecha.value='';
			objCalendar.popup();	}
	}
	else {objCalendar.popup();}	
}

function llenarConTodos(obj,idObj,isVisible,toClean)
{
	var IdObj =eval('document.forms[0].'+idObj);
	if(isVisible==0)
		{if (obj.value==''){obj.value=initText;IdObj.value='-1';}}
		else
		{if (obj.value==initText)obj.value='';}	
		
	if(toClean==3)
	{cleanFarm();}
	else if(toClean==2)
	{cleanFarm();
	cleanLab();
	}else if(toClean==1)
	{cleanZona();
	cleanLab();
	cleanFarm();
	}
	
}
function regresar(intLevel)
{
	if (intLevel==1)
	{
		mostrarDiv('divDetalleRemision',false);
		mostrarDiv('divListadoRemisiones',true);
	}
	else
	{
		mostrarDiv('divDetalleOrden',false);
		mostrarDiv('divDetalleRemision',true);
	}	
}


function cleanLab()
{document.forms[0].strLaboratorioNombre.value=initText;
document.forms[0].intLaboratorioCcsss.value='-1';
}
function cleanFarm()
{document.forms[0].strFarmaciaNombre.value=initText;
document.forms[0].intFarmaciaCcsss.value='-1';
}
function cleanZona()
{document.forms[0].strZonaOperativaNombre.value=initText;
document.forms[0].intZonaOperativaId.value='-1';
}

function mostrarDiv(divNombre,blnMostrar)
{	var divObj=eval("document.getElementById('"+divNombre+"')");
	if (!blnMostrar)
	{divObj.style.position='absolute';				
	divObj.style.top='-800';				
	divObj.style.left='-800';	
	}else{	divObj.style.position='static';}
}

function check_Enter(e, fildselected)
{	var key;		
	if(window.event) // for IE
		{key = e.keyCode; }
	else if(e.which) // for Netscape-Firefox
		{key = e.which; }
	else 
		{return true;}			
	if (key==13)	
	{
	switch (fildselected){
	case 1:
		openPopup('Listado de Direcciones','tblDireccionOperativa',obtenerValorBusqueda('strDireccionOperativaNombre'),'intDireccionOperativaId','strDireccionOperativaNombre','&strDireccionOperativaNombre='+obtenerValorBusqueda('strDireccionOperativaNombre'),'strZonaOperativaNombre')
		break;
	case 2:
		openPopup('Listado de Zonas','tblZonaOperativa',obtenerValorBusqueda('strZonaOperativaNombre'),'intZonaOperativaId','strZonaOperativaNombre','&strZonaOperativaNombre='+obtenerValorBusqueda('strZonaOperativaNombre')+'&intDireccionOperativaId='+document.forms[0].intDireccionOperativaId.value, 'strLaboratorioNombre')
		break;
	case 3:
		openPopup('Listado Farmacias','popupSucursalesRemisiones',obtenerValorBusqueda('strLaboratorioNombre'),'intLaboratorioCcsss','strLaboratorioNombre','&strSucursalNombre='+obtenerValorBusqueda('strLaboratorioNombre')+'&intDireccionOperativaId='+document.forms[0].intDireccionOperativaId.value+'&intZonaOperativaId='+document.forms[0].intZonaOperativaId.value+'&intUENId=12', 'strFarmaciaNombre')
		break;
	case 4:
		openPopup('Farmacias','popupClientesPorLaboratorioR',obtenerValorBusqueda('strFarmaciaNombre'),'intFarmaciaCcsss','strFarmaciaNombre','&strBusquedaCliente='+obtenerValorBusqueda('strFarmaciaNombre')+'&intLaboratorioCcsss='+document.forms[0].intLaboratorioCcsss.value, 'btnBuscar')
		break;
	}
	}
}
	
//-->
</script>
	</HEAD>
	<body>
		<form id="Form1" name="frmConsultaRemisionesAdmin"  action="about:blank" method="post" >	
		<input type="hidden" value="" name="intOrdenId">
			
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
		<tr><td><script language="JavaScript">crearTablaHeader()</script>	</td></tr>
		</table>
				
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
		<tr><td width="10">&nbsp;</td><td class="tdtab" width="770">Está en : Admin : Remisiones : Consulta</td></tr>
		</table>

	<!-- inicia divListadoRemisiones-->
		<div id="divListadoRemisiones" >
		
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
		<tr><td class="tdgeneralcontent">
		<h1>Consulta de Remisiones </h1>
		<p>Seleccione para consultar las órdenes Entregadas. 
		Para señalar en proceso una orden, consúltela dando click en la imagen en forma de lupa.</p>		
		
		<!--inician filtros -->
		<div id="divFiltros">
			<table  cellSpacing="0" cellPadding="0"  border="0" border=1>																	
					<tr>								
						<td class="txtitintabla"  align=right>Fechas:&nbsp;</td>
						<td class="tdconttablas">
							Entre <input type=text class=campotabla  name=dtmOrdenFechaEntregaIngresadaInicio   size=10 onclick=javascript:traerFecha('dtmOrdenFechaEntregaIngresadaInicio',cal1)>&nbsp;<a href=javascript:traerFechaPicker('dtmOrdenFechaEntregaIngresadaInicio',cal1)><img border='0' src='images/imgCalendarIcon.gif' alt='Seleccionar Fecha' ></a>						
							y <input type=text class=campotabla  name=dtmOrdenFechaEntregaIngresadaFin  size=10  onclick=javascript:traerFecha('dtmOrdenFechaEntregaIngresadaFin',cal2)>&nbsp;<a href=javascript:traerFechaPicker('dtmOrdenFechaEntregaIngresadaFin',cal2)><img border='0' src='images/imgCalendarIcon.gif' alt='Seleccionar Fecha' ></a>						
						</td>										
					</tr>																	
					<tr>
							<td class="txtitintabla" align=right>Dirección:&nbsp;</td>
							<td><input type="text" class="field" name="strDireccionOperativaNombre" value="-Todos-" size="40" onkeydown="check_Enter(event, 1)" onblur=llenarConTodos(this,'intDireccionOperativaId',0) onFocus="llenarConTodos(this,'intDireccionOperativaId',1,1)">
							<input type=hidden value="-1"  name=intDireccionOperativaId><a href="javascript:openPopup('Listado de Direcciones','tblDireccionOperativa',obtenerValorBusqueda('strDireccionOperativaNombre'),'intDireccionOperativaId','strDireccionOperativaNombre','&strDireccionOperativaNombre='+obtenerValorBusqueda('strDireccionOperativaNombre'), 'strZonaOperativaNombre')"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Dirección Operativa"></a></td>
					</tr>																	
					<tr>
							<td class="txtitintabla"  align=right>Zona:&nbsp;</td>
							<td><input class="field" type="text" name="strZonaOperativaNombre"  value="-Todos-" size="40"  onblur=llenarConTodos(this,'intZonaOperativaId',0) onFocus="llenarConTodos(this,'intZonaOperativaId',1,2)" onkeydown="check_Enter(event, 2)">
							<input type=hidden value="-1"  name="intZonaOperativaId" ><a href="javascript:openPopup('Listado de Zonas','tblZonaOperativa',obtenerValorBusqueda('strZonaOperativaNombre'),'intZonaOperativaId','strZonaOperativaNombre','&strZonaOperativaNombre='+obtenerValorBusqueda('strZonaOperativaNombre')+'&intDireccionOperativaId='+document.forms[0].intDireccionOperativaId.value, 'strLaboratorioNombre')"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Zona Operativa"></a></td>										
					</tr>																	
					<tr>
							<td class="txtitintabla"  align=right>Laboratorio:&nbsp;</td>
							<td><input class="field" type="text" name="strLaboratorioNombre"  value="-Todos-" size="40"  onblur=llenarConTodos(this,'intLaboratorioCcsss',0) onFocus="llenarConTodos(this,'intLaboratorioCcsss',1,3)" onkeydown="check_Enter(event, 3)">
							<input type=hidden value="-1"  name="intLaboratorioCcsss" ><a href="javascript:openPopup('Listado Farmacias','popupSucursalesRemisiones',obtenerValorBusqueda('strLaboratorioNombre'),'intLaboratorioCcsss','strLaboratorioNombre','&strSucursalNombre='+obtenerValorBusqueda('strLaboratorioNombre')+'&intDireccionOperativaId='+document.forms[0].intDireccionOperativaId.value+'&intZonaOperativaId='+document.forms[0].intZonaOperativaId.value+'&intUENId=12', 'strFarmaciaNombre')"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Laboratorio"></a></td>										
					</tr>	
						<tr>
							<td class="txtitintabla"  align=right>Farmacia:&nbsp;</td>
							<td><input class="field" type="text" name="strFarmaciaNombre"  value="-Todos-" size="40"  onblur=llenarConTodos(this,'intFarmaciaCcsss',0) onFocus="llenarConTodos(this,'intFarmaciaCcsss',1)" onkeydown="check_Enter(event, 4)">
							<input type=hidden value="-1"  name="intFarmaciaCcsss" ><a href="javascript:openPopup('Farmacias','popupClientesPorLaboratorioR',obtenerValorBusqueda('strFarmaciaNombre'),'intFarmaciaCcsss','strFarmaciaNombre','&strBusquedaCliente='+obtenerValorBusqueda('strFarmaciaNombre')+'&intLaboratorioCcsss='+document.forms[0].intLaboratorioCcsss.value, 'btnBuscar')"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Laboratorio"></a></td>																	
						</tr>	
					<tr>
							<td class="txtitintabla" align=right >&nbsp;</td>
							<td class="txtitintabla" ><input class="boton" onclick="javascript:doSubmit('<%=Me._TRAER_LISTADO%>')" type="button" value="Buscar" name="btnBuscar"></td>
					</tr>	
			</table>	
			</div>
		<!--terminan filtros-->
			
		<div id="divHtmlList" ></div>
		<br>		
		</td></tr>
		</table>
	
	</div>		
	<!-- termina divListadoRemisiones-->
	

<!-- inicia divDetalleRemision-->
<div id="divDetalleRemision" style="position:absolute; top:-800; left:-800">

<table cellSpacing="0" cellPadding="0" width="780" border="0">
		<tr><td class="tdgeneralcontent">
		<h1>Detalle de Remisión</h1>
		<p>Seleccione la orden para ver su detalle.</p>		
		
		<table class="tdenvolventetablas" width=100%>
			<tr><td class=txtitintabla  Align="right"  width="15%">No. Remisión:</td><td class="tdconttablas" Align="left" ><div id="divRemisionSecuencia"></div></td></tr>			
			<tr><td class=txtitintabla  Align="right">Laboratorio:</td><td class="tdconttablas" Align="left" ><div id="divRemisionLaboratorio"></div></td></tr>
			<tr><td class=txtitintabla  Align="right">Farmacia:</td><td class="tdconttablas" Align="left" ><div id="divRemisionFarmacia"></div></td></tr>
			<tr><td class=txtitintabla  Align="right">Fecha:</td><td class="tdconttablas" Align="left" ><div id="divRemisionFecha"></div></td></tr>			
			<tr><td class=txtitintabla  Align="right">No. Ordenes:</td><td class="tdconttablas" Align="left" ><div id="divRemisionNoOrdenes"></div></td></tr>
			<tr><td class=txtitintabla  Align="right">No. Fotos:</td><td class="tdconttablas" Align="left" ><div id="divRemisionNoFotos"></div></td></tr>
			<tr><td class=txtitintabla  Align="right">Importe Bruto:</td><td class="tdconttablas" Align="left" ><div id="divRemisionImporteBruto"></div></td></tr>
			<tr><td class=txtitintabla  Align="right">Porcentaje Iva:</td><td class="tdconttablas" Align="left" ><div id="divRemisionPorcentajeIva"></div></td></tr>
			<tr><td class=txtitintabla  Align="right">Importe Iva:</td><td class="tdconttablas" Align="left" ><div id="divRemisionImporteIva"></div></td></tr>						
		</table>			
		
		<div id="divListadoOrdenesRemision"></div>
		<input class="boton" onclick="javascript:regresar(1)" type="button" value="Regresar" name="btnRegresar">					
		</td></tr>
</table>		
					
</div>	
<!-- termina divDetalleRemision-->

<!-- inicia divDetalleOrden-->
<div id="divDetalleOrden" style="position:absolute; top:-800; left:-800">

<table cellSpacing="0" cellPadding="0" width="780" border="0">
		<tr><td class="tdgeneralcontent">
		<h1>Detalle de Orden</h1>
		<p>Seleccione el Trabajo para ver su detalle.</p>		
		
		<table class="tdenvolventetablas" width=100%>
			<tr><td class=txtitintabla  Align="right"  width="15%">Número de Orden:</td><td class="tdconttablas" Align="left" ><div id="divCodigoOrden"></div></td></tr>									
			<tr><td class=txtitintabla  Align="right">Fecha de Ingreso:</td><td class="tdconttablas" Align="left" ><div id="divOrdenFecha"></div></td></tr>
			<tr><td class=txtitintabla  Align="right">No. Trabajos:</td><td class="tdconttablas" Align="left" ><div id="divOrdenNoTrabajos"></div></td></tr>
			<tr><td class=txtitintabla  Align="right">No. Fotos:</td><td class="tdconttablas" Align="left" ><div id="divOrdenNoFotos"></div></td></tr>
			<tr><td class=txtitintabla  Align="right">Importe Bruto:</td><td class="tdconttablas" Align="left" ><div id="divOrdenImporte"></div></td></tr>
			<tr><td class=txtitintabla  Align="right">Porcentaje Iva:</td><td class="tdconttablas" Align="left" ><div id="divOrdenPorcentajeIva"></div></td></tr>
			<tr><td class=txtitintabla  Align="right">Importe Iva:</td><td class="tdconttablas" Align="left" ><div id="divOrdenImporteIva"></div></td></tr>						
		</table>			
		
		<div id="divListadoTrabajosOrden"></div>
		<input class="boton" onclick="javascript:regresar()" type="button" value="Regresar" name="btnRegresar">					
		</td></tr>
</table>		
					
</div>	
<!-- termina divDetalleOrden-->

							
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
		<tr><td><script language="JavaScript">crearTablaFooter()</script></td></tr>
		</table>
		
		<script language="JavaScript">
		<!--
		new menu (MENU_ITEMS, MENU_POS);
		var cal1 = new calendar(null, document.forms[0].elements["dtmOrdenFechaEntregaIngresadaInicio"]);		
		var cal2 = new calendar(null, document.forms[0].elements["dtmOrdenFechaEntregaIngresadaFin"]);		
		//-->
		</script>

</form>
<iframe name="ifrOculto" src="" width="<%=frameW%>" height="<%=frameH%>"></iframe>
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
	function exportMe() 
	{			
		var myWindow=window.open("<%= strThisPageName %>?strCmd=<%=Me._VENTANA_EXCEL%><%=strExportarListado()%>", "exportDocument", "menubar=yes,scrollbars=yes,resizable=yes,width=400,height=400,statusbar=no");								
	} 
</script>		
<body onload=exportMe()>
<form id="frmExportar" name="frmExportar" action="about:blank" method="post">
</form>
</body>
<%Else if Request("strCmd") = Me._VENTANA_EXCEL then  %>	
	<%cambiaExcel%>
	<BODY>
		<%= strGenerarImpresion%>
	</BODY>
<%End If%>
</HTML>
