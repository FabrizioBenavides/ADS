<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ReporteProduccionAdmin.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsReporteProduccionAdmin" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides : Sistema Administrador de Puntos de Venta</TITLE>
<%
    '====================================================================
    ' Page          : ReporteProduccionAdmin.aspx
    ' Title         : Reporte de Produccion de Admin
    ' Description   : Reporte de Produccion Admin
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Enrique Longoria
    ' Version       : 1.0
    ' Last Modified : Monday, Mar 29th, 2005
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
	<%Case Me._CAMBIAR_PAG%>	
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%=strGenerarListado("")%>";		
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
	
	//obtengo las sucursales Seleccionadas
	obtenerSucursalesSeleccionados();
	
	//validacion de fechas
	if ((document.forms[0].dtmOrdenFechaEntregaIngresadaInicio.value.length==0 && document.forms[0].dtmOrdenFechaEntregaIngresadaFin.value.length>0  )
	 || (document.forms[0].dtmOrdenFechaEntregaIngresadaFin.value.length==0 && document.forms[0].dtmOrdenFechaEntregaIngresadaInicio.value.length>0  )	)
	 {alert('Favor de completar el rango de Fechas.'); isOk=0;return false;}
	 
	if (document.forms[0].dtmOrdenFechaEntregaIngresadaInicio.value.length>0 &&document.forms[0].dtmOrdenFechaEntregaIngresadaFin.value.length>0  )	 
	{	if (validateDate(document.forms[0].dtmOrdenFechaEntregaIngresadaInicio,'dd/MM/yyyy')==false)	{isOk=0;}
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
		
	if(toClean==2)//eligo Zona
	{cleanSucursal(); if(isVisible){obtenerListado();}
	}else if(toClean==1)//eligo Dirección
	{cleanZona();
	cleanSucursal();
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

function obtenerSucursalesSeleccionados()
{	document.forms[0].intSucursalCcsss.value='-1';
		
	for (i=0;i<document.forms[0].cmbSucursal.options.length;i++)
	{	
		if(document.forms[0].cmbSucursal[i].selected==true)
		{document.forms[0].intSucursalCcsss.value+=','+document.forms[0].cmbSucursal[i].value;}
		document.forms[0].intSucursalCcsss.value=document.forms[0].intSucursalCcsss.value.replace('-1,','');
	}
	if (document.forms[0].intSucursalCcsss.value!='-1,')
	{document.forms[0].intSucursalCcsss.value=document.forms[0].intSucursalCcsss.value.replace('-1,','');}
}
function obtenerListado()
{doSubmit('SUCURSALES');}

function cleanSucursal()
{
	document.getElementById('divSucursal').innerHTML="<select name='cmbSucursal' class='comboTabla' size='5' Multiple><option value='-1'>-Todos-</option></select>";
	document.forms[0].intSucursalCcsss.value='-1';	
}

function cleanZona()
{document.forms[0].strZonaOperativaNombre.value=initText;
document.forms[0].intZonaOperativaId.value='-1';
}

function cleanDireccion()
{document.forms[0].strDireccionOperativaNombre.value=initText;
document.forms[0].intDireccionOperativaId.value='-1';
}

function mostrarDiv(divNombre,blnMostrar)
{	var divObj=eval("document.getElementById('"+divNombre+"')");
	if (!blnMostrar)
	{divObj.style.position='absolute';				
	divObj.style.top='-800';				
	divObj.style.left='-800';	
	}else{	divObj.style.position='static';}
}

function changeUEN(objRadio)
{
document.forms[0].intUENId.value=objRadio.id;
cleanDireccion();
cleanZona();
cleanSucursal();
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
		openPopup('Listado de Zonas','tblZonaOperativa',obtenerValorBusqueda('strZonaOperativaNombre'),'intZonaOperativaId','strZonaOperativaNombre','&strZonaOperativaNombre='+obtenerValorBusqueda('strZonaOperativaNombre')+'&intDireccionOperativaId='+document.forms[0].intDireccionOperativaId.value)
		break;
	case 3:
		openPopup('Listado de Clasificaciones','popupClasificacion2',document.forms[0].strClasificacionArticuloNombre.value,'intClasificacionArticuloId','strClasificacionArticuloNombre','&strClasificacionArticuloNombre='+document.forms[0].strClasificacionArticuloNombre.value)
		break;
	}
	}
}

//-->
</script>
	</HEAD>
	<body>
		<form id="Form1" name="frmReporteProduccion"  action="about:blank" method="post" >		
			<input type=hidden value="-1"  name=auxObj>
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
		<tr><td><script language="JavaScript">crearTablaHeader()</script>	</td></tr>
		</table>
				
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
		<tr><td width="10">&nbsp;</td><td class="tdtab" width="770">Está en : Admin : Reportes : Producción</td></tr>
		</table>
		
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
		<tr><td class="tdgeneralcontent">
		<h1>Reporte de Producción (por Clasificación)</h1>
		<p>Seleccione los parámetros de filtrado para el Reporte de Producción.</p>		
		
		<!--inician filtros -->
		<div id="divFiltros">
			<table  cellSpacing="0" cellPadding="0"  border="0" >																	
					<tr>								
						<td class="txtitintabla"  align=right>Fechas:&nbsp;</td>
						<td class="tdconttablas">
							Entre <input type=text class=campotabla  name=dtmOrdenFechaEntregaIngresadaInicio   size=10 onclick=javascript:traerFecha('dtmOrdenFechaEntregaIngresadaInicio',cal1)>&nbsp;<a href=javascript:traerFechaPicker('dtmOrdenFechaEntregaIngresadaInicio',cal1)><img border='0' src='images/imgCalendarIcon.gif' alt='Seleccionar Fecha' ></a>						
							y <input type=text class=campotabla  name=dtmOrdenFechaEntregaIngresadaFin  size=10  onclick=javascript:traerFecha('dtmOrdenFechaEntregaIngresadaFin',cal2)>&nbsp;<a href=javascript:traerFechaPicker('dtmOrdenFechaEntregaIngresadaFin',cal2)><img border='0' src='images/imgCalendarIcon.gif' alt='Seleccionar Fecha' ></a>						
						</td>	
													
					</tr>	
					<tr>
						<td>&nbsp;</td>
						<td class="tdconttablas">
						<input type=radio id=12 name=radioSucursal onClick="changeUEN(this)" checked>Laboratorio&nbsp;<input type=radio id=2 name=radioSucursal onClick="changeUEN(this)">Farmacia						
						<input type=hidden value="12"  name=intUENId>	</td>												
					</tr>																
					<tr>
							<td class="txtitintabla" align=right>Dirección:&nbsp;</td>
							<td><input type="text" class="field" name="strDireccionOperativaNombre"  value="-Todos-" size="40" onblur=llenarConTodos(this,'intDireccionOperativaId',0) onFocus="llenarConTodos(this,'intDireccionOperativaId',1,1)" onkeydown="check_Enter(event, 1)">
							<a href="javascript:openPopup('Listado de Direcciones','tblDireccionOperativa',obtenerValorBusqueda('strDireccionOperativaNombre'),'intDireccionOperativaId','strDireccionOperativaNombre','&strDireccionOperativaNombre='+obtenerValorBusqueda('strDireccionOperativaNombre'),'strZonaOperativaNombre')"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Dirección Operativa"></a>
							<input type=hidden value="-1"  name=intDireccionOperativaId>							
							</td>						
							
					</tr>																		
					<tr>
							<td class="txtitintabla"  align=right>Zona:&nbsp;</td>
							<td><input class="field" type="text" name="strZonaOperativaNombre"  value="-Todos-" size="40"  onblur=llenarConTodos(this,'intZonaOperativaId',0) onFocus="llenarConTodos(this,'intZonaOperativaId',1,2)" onkeydown="check_Enter(event,2)">
							<input type=hidden value="-1"  name="intZonaOperativaId" >							
							<a href="javascript:openPopup('Listado de Zonas','tblZonaOperativa',obtenerValorBusqueda('strZonaOperativaNombre'),'intZonaOperativaId','strZonaOperativaNombre','&strZonaOperativaNombre='+obtenerValorBusqueda('strZonaOperativaNombre')+'&intDireccionOperativaId='+document.forms[0].intDireccionOperativaId.value)"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Zona Operativa"></a></td>																	
					</tr>	
					<tr>
							<td class="txtitintabla" align=right >Sucursal:&nbsp;</td>
							<td>
							<div id="divSucursal">
								<select name='cmbSucursal' class='comboTabla' size='5' Multiple>
								<option value='-1'>-Todos-</option>
								</select>
							</div>
							<input type=hidden value="-1" name="intSucursalCcsss">							
							</td>						
					</tr>				
					<tr>		
						<td class="txtitintabla" Align="right"><span class="tdtittablas3">Clasificación:&nbsp;</span>
						<td><input class=field  type=text   name=strClasificacionArticuloNombre value="-Todos-"  onblur=llenarConTodos(this,'intClasificacionArticuloId',0) onFocus="llenarConTodos(this,'intClasificacionArticuloId',1)" onkeydown="check_Enter(event, 3)">
						<input type=hidden value="-1" name=intClasificacionArticuloId><a href="javascript:openPopup('Listado de Clasificaciones','popupClasificacion2',document.forms[0].strClasificacionArticuloNombre.value,'intClasificacionArticuloId','strClasificacionArticuloNombre','&strClasificacionArticuloNombre='+document.forms[0].strClasificacionArticuloNombre.value)"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Clasificaciones"></a>
						</td>
					</tr>
						<tr>	
							<td>&nbsp;</td>
							<td class="txtitintabla" ><input class="boton" onclick="javascript:doSubmit('<%=Me._TRAER_LISTADO%>')" type="button" value="Mostrar Reporte" name="btnBuscar"></td>							
					</tr>

			</table>	
			</div>
		<!--terminan filtros-->
			
		<div id="divHtmlList" ></div>
		
		<br>		
		</td></tr>
		</table>	
							
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
	var myWindow=window.open("<%= strThisPageName %>?strCmd=<%=Me._VENTANA_EXCEL%><%=strExportarListado()%>", "exportDocument", "menubar=yes,scrollbars=yes,resizable=yes,width=400,height=400,statusbar=no");								
</script>		
<%Else if Request("strCmd") = Me._VENTANA_EXCEL then  %>	
	<%cambiaExcel%>
	<BODY>
		<%= strGenerarImpresion%>
	</BODY>
<%End If%>
</HTML>
