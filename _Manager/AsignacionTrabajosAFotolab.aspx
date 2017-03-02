<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AsignacionTrabajosAcom.isocraft.backbone.ccentral.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsAsignacionTrabajosAFotolab" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides : Administrador del Sistema Concentrador (CTX)</TITLE>
<%
    '====================================================================
    ' Page          : AsignacionTrabajosAcom.isocraft.backbone.ccentral.aspx
    ' Title         : Asignacion de los Trabajos a com.isocraft.backbone.ccentral.
    ' Description   : Asignacion de los Trabajos a com.isocraft.backbone.ccentral.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Jorge Ventura Cantu Campos
    ' Version       : 1.0
    ' Last Modified : Wednesday, March 3Th, 2005
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
<script language="javascript" id="clientEventHandlersJS">
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

var iniText='-Todos-';

if ((parent.parent.document.getElementById('divHtmlList') != null) || (parent.parent.document.getElementById('divHtmlList1') != null)){
<%= me.strActions(Request("strCmd"))%>	
<%Select Case Request("strCmd")%>
	<% Case Me._NUEVO %>			
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("1")%>";	
		parent.parent.document.forms[0].reset();	
	<%Case Me._GUARDAR%>	
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("1")%>";	
		parent.parent.document.forms[0].reset();	
	<%Case "BuscarTrabajos"	%>
		parent.parent.document.getElementById('divHtmlList1').innerHTML="<%= me.strGenerarListadoTrabajo("1")%>";	
		parent.parent.mostrarDiv('divHtmlList1',true);
		parent.parent.mostrarDiv('divBotonRegresar',false);
		if (parent.parent.document.forms[0].strbotones.value=='1')
			{parent.parent.mostrarDiv('divBotonAsignarTodos',true);}
		else
			{parent.parent.mostrarDiv('divBotonDesasignarTodos',true);}
	<%Case "AsignarTodos" %>
		<% me.AsignarFotolab("")%>
		newWindow('Mensaje.aspx?strmensaje=Operación%20Exitosa',500,152)
	<%Case "DesasignarTodos" %>
		<% me.DesasignarFotolab("")%>		
		newWindow('Mensaje.aspx?strmensaje=Operación%20Exitosa',500,152)
	<%Case "Asignar" %>
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("1")%>";
		parent.parent.mostrarDiv('divAsignacionTexto',true);		
		parent.parent.mostrarDiv('divDesasignacionTexto',false);
		parent.parent.mostrarDiv('divBotonRegresar',false);
		parent.parent.mostrarDiv('divFiltrosTrabajo',false);
		parent.parent.mostrarDiv('divBotonDesasignarTodos',false);
		parent.parent.mostrarDiv('divBotonAsignarTodos',false);
		parent.parent.vista1();
		parent.parent.document.forms[0].strbotones.value='1';	
	<%Case "Desasignar"	%>
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("1")%>";
		parent.parent.mostrarDiv('divAsignacionTexto',false);
		parent.parent.mostrarDiv('divDesasignacionTexto',true);
		parent.parent.mostrarDiv('divBotonDesasignarTodos',false);
		parent.parent.mostrarDiv('divFiltrosTrabajo',false);
		parent.parent.mostrarDiv('divBotonAsignarTodos',false);
		parent.parent.mostrarDiv('divBotonRegresar',false);	
		parent.parent.vista1();		
		parent.parent.document.forms[0].strbotones.value='2';
	<%Case "Regresar"%>
		parent.parent.vista2();
		parent.parent.mostrarDiv('divFiltrosLaboratorio',true);		
		parent.parent.mostrarDiv('divEncabezadoLista',false);		
		parent.parent.mostrarDiv('divHtmlList',false);		
		parent.parent.mostrarDiv('divHtmlList1',false);
		parent.parent.mostrarDiv('divPrincipalTexto',true);	
		parent.parent.mostrarDiv('divBotonRegresar',false);
		parent.parent.mostrarDiv('divEncabezadoDetalle',false);	
		parent.parent.mostrarDiv('divBotonAsignarTodos',false);
		parent.parent.mostrarDiv('divBotonDesasignarTodos',false);	
		parent.parent.mostrarDiv('divBotonRegresar',false);
		parent.parent.limpiarcampos();
	<%Case "Consultar"	%>
		parent.parent.document.forms[0].strbotones.value='3';
		parent.parent.vista2();
		parent.parent.mostrarDiv('divFiltrosLaboratorio',false);		
		parent.parent.mostrarDiv('divHtmlList',true);		
		parent.parent.mostrarDiv('divHtmlList1',true);	
		parent.parent.mostrarDiv('divConsultaTexto',true);
		parent.parent.mostrarDiv('divPrincipalTexto',false);
		parent.parent.mostrarDiv('divBotonRegresar',false);
	<%Case Me._BORRAR	%>		
		parent.parent.document.forms[0].reset();				
	<%Case "BrincoPagina" %>	
		parent.parent.document.getElementById('divHtmlList1').innerHTML="<%= me.strGenerarListadoTrabajo("")%>";	
	<%Case Me._CAMBIAR_PAG,"TraerListadoAdmin","TraerListadoCriterio"%>	
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";
	<%End Select%>
	} 	
//-->
</script>	

<%if Request("strCmd") ="" then %>	
<script language="javascript" id="MarcaRolloJS">
<!--
function vista1()
{	mostrarDiv('divFiltrosLaboratorio',false);
	mostrarDiv('divEncabezadoLista',false);
	mostrarDiv('divHtmlList',true);		
	mostrarDiv('divFiltrosTrabajo',true);			
	mostrarDiv('divPrincipalTexto',false);	
	mostrarDiv('divConsultaTexto',false);		
	mostrarDiv('divBotonRegresar',true);
	mostrarDiv('divEncabezadoDetalle',true);
	mostrarDiv('divHtmlList1',false);	
}

function vista2()
{	mostrarDiv('divAsignacionTexto',false);
	mostrarDiv('divDesasignacionTexto',false);	
	mostrarDiv('divConsultaTexto',false);		
	mostrarDiv('divFiltrosTrabajo',false);	
}

function llenarconTodos()
{
if (document.forms[0].intDireccionOperativaId.value=='-1')
{document.forms[0].strDireccionOperativaNombre.value=iniText;}
}

function llenarconTodosZona()
{
if (document.forms[0].intZonaOperativaId.value=='-1')
{document.forms[0].strZonaOperativaNombre.value=iniText;}
}
function obtenerValorBusqueda(){ 
var val;
val=document.forms[0].strDireccionOperativaNombre.value;
if ( val ==iniText || val ==''){val='_';}
return val;
}

function obtenerValorBusquedaZona(){ 
var val;
val=document.forms[0].strZonaOperativaNombre.value;
if ( val ==iniText || val ==''){val='_';}
return val;
}

function window_onload() 
{  
<% if CStr(Request("strCmd")) = Me._IMPRIMIR then  %>
	  printDocument();
<% elseif CStr(Request("strCmd")) = Me._EXPORTAR then  %>
	exportDocument();
  <% end if   %>

llenarLaboratorios();

 document.forms[0].action = "<%= strThisPageName %>";
}

function llenarLaboratorios()
{
<% if Request("strLaboratoriosId") = ""  %>
	document.forms[0].strLaboratoriosId.value='';
<% else%>
	document.forms[0].strLaboratoriosId.value='<%= Request("strLaboratoriosId") %>';
	var labs='<%= Request("strLaboratoriosId") %>';
	var idLabs=labs.split(',');	
	for(j=0;j<idLabs.length;j++)
	{ for (i=0;i<document.forms[0].cmbLaboratorio.options.length;i++)
		{
		if (document.forms[0].cmbLaboratorio[i].value==idLabs[j])
			{document.forms[0].cmbLaboratorio[i].selected=true;}
	}
	}
<% end if   %>  
}

function guardarDirId()
{document.forms[0].strZonaOperativaNombre.value=iniText;
document.forms[0].intZonaOperativaId.value='-1';
document.forms[0].strLaboratoriosId.value='-1';	
document.getElementById('divLaboratorio').innerHTML="<select name='cmbLaboratorio' class='comboTabla' size='4' Multiple>	<option value='-1'>- Todos -</option></select>"
}

function guardarZonaId()
{document.forms[0].strLaboratoriosId.value='-1';	
document.getElementById('divLaboratorio').innerHTML="<select name='cmbLaboratorio' class='comboTabla' size='4' Multiple>	<option value='-1'>- Todos -</option></select>"
doSubmit('LABORATORIO')
}

function obtenerLaboratoriosSeleccionados()
{	document.forms[0].strLaboratoriosId.value='-1';
	for (i=0;i<document.forms[0].cmbLaboratorio.options.length;i++)
	{	if(document.forms[0].cmbLaboratorio[i].selected==true)
		{document.forms[0].strLaboratoriosId.value+=','+document.forms[0].cmbLaboratorio[i].value;}
		document.forms[0].strLaboratoriosId.value=document.forms[0].strLaboratoriosId.value.replace('-1,','');
	}
	if (document.forms[0].strLaboratoriosId.value!='-1,')
	{document.forms[0].strLaboratoriosId.value=document.forms[0].strLaboratoriosId.value.replace('-1,','');}
}

function Encabezados(action)
{
if (action == 'Asignar')
{
	parent.parent.document.getElementById('divEncabezadoLista').innerHTML= '<p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> Laboratorios a los cuales se asignarán Trabajos </span> </p>' ;
	parent.parent.document.getElementById('divEncabezadoDetalle').innerHTML= '<br><p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">  Selección de Trabajos a Asignar </span> </p>' ;
	parent.parent.document.getElementById('divEncabezadoListaDetalle').innerHTML= '<br><p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">  Listado de Trabajos a Asignar </span> </p>' ;
}
else if (action == 'Desasignar')
{
	parent.parent.document.getElementById('divEncabezadoLista').innerHTML= '<p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> Laboratorios a los cuales se desasignarán Trabajos</span> </p>' ;
	parent.parent.document.getElementById('divEncabezadoDetalle').innerHTML= '<br><p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">  Selección de Trabajos a Desasignar </span> </p>' ;
	parent.parent.document.getElementById('divEncabezadoListaDetalle').innerHTML= '<br><p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">  Listado de Trabajos a Desasignar </span> </p>' ;
}
else if (action == 'Consultar')
{
	parent.parent.document.getElementById('divEncabezadoLista').innerHTML= '<p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> Laboratorio</span> </p>' ;
	parent.parent.document.getElementById('divEncabezadoDetalle').innerHTML= '<br><p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">  Listado de Trabajos Asignados </span> </p>' ;
	parent.parent.document.getElementById('divEncabezadoListaDetalle').innerHTML= '' ;
}
}

function mostrarDiv(divNombre,blnMostrar)
{	var divObj=eval('document.getElementById("'+divNombre+'")');
	if (!blnMostrar)
	{divObj.style.position='absolute';				
	divObj.style.top='-800';				
	divObj.style.left='-800';	
	}else{	divObj.style.position='static';}
}

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
    var isOk=1;
	if ((action == 'Asignar') || (action == 'Desasignar') || (action == 'Consultar'))
	{
		obtenerLaboratoriosSeleccionados()	
		Encabezados(action)
	}
	else if (action == 'BuscarTrabajos')
	{		
		if(document.forms[0].strTrabajo.value.length>8)	
			{document.forms[0].strCodigoDeBarras.value=document.forms[0].strTrabajo.value;}
		else{document.forms[0].strCodigoDeBarras.value='_';
		document.forms[0].strTrabajoId.value=document.forms[0].strTrabajo.value;
		}
	}
	else if ((action == 'AsignacionIndividual') || (action == 'AsignarTodos'))
	{ 
		if(document.forms[0].strTrabajo.value.length>8)	
			{document.forms[0].strCodigoDeBarras.value=document.forms[0].strTrabajo.value;}
		else{document.forms[0].strCodigoDeBarras.value='_';
		document.forms[0].strTrabajoId.value=document.forms[0].strTrabajo.value;}
		if (action == 'AsignarTodos')
		{mostrarDiv('divBotonDesasignarTodos',false);	
		mostrarDiv('divBotonRegresar',false);}
		
		if (action == 'AsignacionIndividual')
			{	parent.parent.mostrarDiv('divBotonAsignarTodos',true);	
				parent.parent.mostrarDiv('divBotonRegresar',false);}
		action='AsignarTodos';
		if (!confirm('¿Esta seguro que desea realizar la asignación?')==true)
			{isOk=0;}	
	}
	else if ((action == 'DesasignacionIndividual') || (action == 'DesasignarTodos'))
	{		
		if(document.forms[0].strTrabajo.value.length>8)	
				{document.forms[0].strCodigoDeBarras.value=document.forms[0].strTrabajo.value;}
		else	{document.forms[0].strCodigoDeBarras.value='_';
		document.forms[0].strTrabajoId.value=document.forms[0].strTrabajo.value;}
		//alert(args[2]);
		if (action == 'DesasignarTodos')
			{mostrarDiv('divBotonAsignarTodos',false);	
			mostrarDiv('divBotonRegresar',false);}
		if (action == 'DesasignacionIndividual')
			{	parent.parent.mostrarDiv('divBotonDesasignarTodos',true);	
				parent.parent.mostrarDiv('divBotonRegresar',false);}
		action='DesasignarTodos';
		if (!confirm('¿Esta seguro que desea realizar la Desasignación?')==true)
			{isOk=0;}	
	}
	else if (action == "Editar")
	{
		var paramLen=args[2].length;
		var intCompaniaId=args[2];	
		var intSucursalId=intCompaniaId.charAt(paramLen-3) +intCompaniaId.charAt(paramLen-2)+intCompaniaId.charAt(paramLen-1);
		intCompaniaId=intCompaniaId.replace(intSucursalId,'');					
		window.open('DetalleDeTrabajos.aspx?intSucursalIdDetalle='+intSucursalId+'&intCompaniaIdDetalle='+intCompaniaId, "Benavides", "scrollbars=auto,resizable=yes,width=600,height=500,statusbar=no")
		isOk=0;
	}
	
	if (isOk==1)
	{
	document.forms[0].mostrar.value='si';
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{params+= "&" + args[i] + "=" + args[i+1]}	
	 document.forms[0].action = "<%= strThisPageName %>?strCmd=" + action + params    	
	document.forms[0].target="ifrOculto";	
	document.forms[0].submit();  
	}
}

function limpiarcampos()
{	
	document.forms[0].intDireccionOperativaId.value="";
	document.forms[0].strDireccionOperativaNombre.value="";
	document.forms[0].strZonaOperativaNombre.value="";
	document.forms[0].intZonaOperativaId.value="";
	document.forms[0].cmbLaboratorio.value="";
	document.forms[0].strLaboratoriosId.value="";
	document.forms[0].strTrabajo.value="";
	document.forms[0].strTrabajoId.value="";
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
		openPopup('Listado de Direcciones','tblDireccionOperativa',obtenerValorBusqueda(),'intDireccionOperativaId','strDireccionOperativaNombre','&strDireccionOperativaNombre='+obtenerValorBusqueda(),'strZonaOperativaNombre');
		break;
	case 2:
		openPopup('Listado de Zonas','tblZonaOperativa',obtenerValorBusquedaZona(),'intZonaOperativaId','strZonaOperativaNombre','&strZonaOperativaNombre='+obtenerValorBusquedaZona()+'&intDireccionOperativaId='+document.forms[0].intDireccionOperativaId.value, 'cmbLaboratorio')
		break;
	case 3:
		doSubmit('BuscarTrabajos');
		break;
	}
	}
}

//-->
</script>
	</HEAD>
	<body onload="window_onload()">
		<form id="Form1" name="frmFotolabaFarmacias" action="about:blank" method="post">			

			<input type=hidden value="<%= strbotones %>" name=strbotones>
			<input type=hidden value="<%= Request("mostrar") %>" name=mostrar>		
			<input type="hidden" value="0" name="documentPrinted">
			<input type="hidden" value="0" name="documentExported">
			<input type="hidden" value="" name="strCodigoDeBarras">
			
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
					<td class="tdtab" width="770">Está en : ADMIN : Asignaciones :  Trabajos a Laboratorio </td>
				</tr>
			</table>
			
			<table cellSpacing="0" cellPadding="0" width="780" border="0" >
				<tr>
					<td class="tdgeneralcontent">
						<div id="divPrincipalTexto"style="position:static">
							<h1>Asignación de Trabajos a Laboratorios </h1>
							<p>Busque el laboratorio al cual se asignarán trabajos.<br></p>	
						</div>
						<div id="divAsignacionTexto" style="position:absolute; top:-800; left:-800">
							<h1>Asignación de Trabajos a Laboratorios</h1>
							<p> Seleccione el trabajo que se asignará a los laboratorios. Para asignar trabajos del listado, haga click en el icono del registro correspondiente. Para asignar todos, haga click en "Asignar Todos ".<br></p>	
						</div>
						<div id="divDesasignacionTexto" style="position:absolute; top:-800; left:-800">
							<h1>Desasignación de Trabajos a Laboratorios</h1>
							<p>Seleccione el trabajo que se desasignará de los laboratorios. Para desasignar trabajos del listado, haga click en el icono del registro correspondiente. Para desasignar todos, haga click en "Desasignar Todos ".<br></p>	
						</div>
						<div id="divConsultaTexto" style="position:absolute; top:-800; left:-800">
							<h1>Consulta de Trabajos a Laboratorios </h1>
							<p>Seleccione el laboratorio para consultar sus trabajos asignados.<br></p>	
						</div>		
						<!-- FILTROS -->
						<div id="divFiltrosLaboratorio">
						<br><p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">  Búsqueda de Laboratorio </span> </p>
							<table cellSpacing="0" cellPadding="0"  border="0" >																
							<tr><td  class="txtitintabla" colspan=2>
										<table>
										<tr>
										<td class="txtitintabla" align=right>Dirección:&nbsp;</td>
											<td><input type="text" class="field" name="strDireccionOperativaNombre"  value="-Todos-" size="40" onblur=llenarconTodos() onFocus="javascript:guardarDirId()" onkeydown="check_Enter(event, 1)">
											<input type=hidden value="-1"  name=intDireccionOperativaId><a href="javascript:openPopup('Listado de Direcciones','tblDireccionOperativa',obtenerValorBusqueda(),'intDireccionOperativaId','strDireccionOperativaNombre','&strDireccionOperativaNombre='+obtenerValorBusqueda(),'strZonaOperativaNombre')"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle"  alt="Buscar Dirección Operativa"></a></td>
										</tr>																	
										<tr>
										<td class="txtitintabla"  align=right>Zona:&nbsp;</td>
											<td><input class="field" type="text" name="strZonaOperativaNombre"  value="-Todos-" size="40"  onblur=llenarconTodosZona() onFocus="javascript:guardarZonaId()" onkeydown="check_Enter(event, 2)">
											<input type=hidden value="-1"  name="intZonaOperativaId" ><a href="javascript:openPopup('Listado de Zonas','tblZonaOperativa',obtenerValorBusquedaZona(),'intZonaOperativaId','strZonaOperativaNombre','&strZonaOperativaNombre='+obtenerValorBusquedaZona()+'&intDireccionOperativaId='+document.forms[0].intDireccionOperativaId.value, 'cmbLaboratorio')"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Zona Operativa"></a></td>										
										</tr>																	
										<tr>
										<td class="txtitintabla" align=right >Laboratorio:&nbsp;</td>
										<td><div id="divLaboratorio" name="divLaboratorio"><select name='cmbLaboratorio' class='comboTabla' size='4' Multiple>	<option value='-1'>- Todos -</option></select></div>
										<input type=hidden value="-1" name="strLaboratoriosId"></td>
										</tr>
										<tr>
										<td></td>	
											<td class="txtitintabla" ><input class="boton" onclick="javascript:doSubmit('Asignar')" type="button" value="Asignar" name="btnAsignar">
											&nbsp;<input class="boton" onclick="javascript:doSubmit('Desasignar')" type="button" value="Desasignar" name="btnDesasignar">		
										</tr>
										</table>									
							</td><td>									
							</td></tr>																																					
							</table>
						</div>
						<!-- terminan FILTROS -->						
						
			<div id=divEncabezadoLista name=divEncabezadoLista style="position:absolute; top:-800; left:-800"></div>			
			<div id=divHtmlList name=divHtmlList ></div>
			<!--listado de Labotarorios-->			
			<div id=divEncabezadoDetalle name=divEncabezadoDetalle style="position:absolute; top:-800; left:-800"></div>
			
			<!-- FILTROS Trabajo-->
			<div id=divFiltrosTrabajo name=divFiltrosTrabajo style="position:absolute; top:-800; left:-800">
				<table>
				<tr>
					<td class="txtitintabla" align=right>Trabajo:&nbsp;</td>
					<td><input type="text" class="field" name="strTrabajo"  value="" size="20" onkeydown="check_Enter(event, 3)"><input type="hidden" class="field" name="strTrabajoId"  value="" size="20"> &nbsp;<input class=boton onclick=javascript:doSubmit('BuscarTrabajos') type=button value='Buscar Trabajos' name=btnBuscarTrabajos></td>
				</tr>	
				</table>																								
			</div>			
		<!-- terminan FILTROS Trabajo -->	
			<br>				
				<div id=divEncabezadoListaDetalle name=divEncabezadoListaDetalle style="position:absolute; top:-800; left:-800"></div>
				
				<div id=divHtmlList1 name=divHtmlList1 ></div>						
				<br>	
				<div id=divBotonAsignarTodos name=divBotonAsignarTodos style="position:absolute; top:-800; left:-800">
					<input class="boton" onclick="javascript:doSubmit('AsignarTodos')" type="button" value="Asignar Todos" name="btnAsignarTodos">
					<input class=boton onclick=javascript:doSubmit('Regresar') type=button value='Regresar' name=btnRegresar1>
				</div>
				<div id=divBotonDesasignarTodos name=divBotonDesasignarTodos style="position:absolute; top:-800; left:-800">
					<input class="boton" onclick="javascript:doSubmit('DesasignarTodos')" type="button" value="Desasignar Todos" name="btnDesasignarTodos">
					<input class=boton onclick=javascript:doSubmit('Regresar') type=button value='Regresar' name=btnRegresar2>
				</div>
				<div id=divBotonRegresar name=divBotonRegresar style="position:absolute; top:-800; left:-800">
					<input class=boton onclick=javascript:doSubmit('Regresar') type=button value='Regresar' name=btnRegresar3>
					<!--input class=boton onclick=javascript:doSubmit('Regresar') type=button value='Regresar' name=btnRegresar-->
				</div>	
					</td>
				</tr>
			</table>			
			
			
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
			<tr><td>	<script language="JavaScript">crearTablaFooter()</script></td></tr>
			</table>
			<script language="JavaScript">
				<!--
				new menu (MENU_ITEMS, MENU_POS);
				//-->
			</script>
		</form>
		<iframe name="ifrOculto" src="" width="<%=frameW%>" height="<%=frameH%>"></iframe>
	</body>
<%End If%>
</HTML>
