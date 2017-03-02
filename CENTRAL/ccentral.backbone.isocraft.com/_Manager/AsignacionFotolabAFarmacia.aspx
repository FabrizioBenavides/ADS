<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AsignacionFotolabAFarmacia.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsAsignacionFotolabAFarmacia" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides : Administrador del Sistema Concentrador (CTX)</TITLE>
		<%
    '====================================================================
    ' Page          : AsignacionFotolabAFarmacia.aspx
    ' Title         : Asignacion de los Fotolabs a las Farmacias.
    ' Description   : Asignacion de los Fotolabs a las Farmacias.
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
	<%Case "BuscarClientes"	%>
		parent.parent.document.getElementById('divHtmlList1').innerHTML="<%= me.strGenerarListadoSucursal("1")%>";	
		parent.parent.mostrarDiv('divHtmlList1',true);
		parent.parent.mostrarDiv('divBotonBuscarClientes',true);		
		if (parent.parent.document.forms[0].strbotones.value=='1')
			{parent.parent.mostrarDiv('divBotonAsignarTodos',true);}
		else
		{parent.parent.mostrarDiv('divBotonDesasignarTodos',true);}
		parent.parent.mostrarDiv('divBotonRegresar1',false);
		parent.parent.mostrarDiv('divBotonRegresar2',true);
	<%Case "AsignarTodos" %>
		<% me.AsignarFotolab("")%>
		parent.parent.mostrarDiv('divBotonAsignarTodos',false);	
		newWindow('Mensaje.aspx?strmensaje=Operaci�n%20Exitosa',500,152)
	<%Case "DesasignarTodos" %>
		<% me.DesasignarFotolab("")%>		
		parent.parent.mostrarDiv('divBotonDesasignarTodos',false);	
		newWindow('Mensaje.aspx?strmensaje=Operaci�n%20Exitosa',500,152)
	<%Case "Asignar" %>
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("1")%>";
		parent.parent.mostrarDiv('divAsignacionTexto',true);
		parent.parent.mostrarDiv('divDesasignacionTexto',false);
		parent.parent.mostrarDiv('divPrincipalTexto',false);	
		parent.parent.mostrarDiv('divBotonRegresar1',true);		
		parent.parent.vista1();
		parent.parent.document.forms[0].strbotones.value='1';	
		parent.parent.document.forms[0].strDireccionOperativaNombreSucursal.focus();
	<%Case "Desasignar"	%>
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("1")%>";
		parent.parent.mostrarDiv('divAsignacionTexto',false);
		parent.parent.mostrarDiv('divDesasignacionTexto',true);	
		parent.parent.mostrarDiv('divPrincipalTexto',false);
		parent.parent.mostrarDiv('divBotonRegresar1',true);
		parent.parent.vista1();
		parent.parent.document.forms[0].strbotones.value='2';
		parent.parent.document.forms[0].strDireccionOperativaNombreSucursal.focus();
	<%Case "Regresar"	%>
		parent.parent.vista2();		
		parent.parent.mostrarDiv('divEncabezadoDetalle',false);
		parent.parent.mostrarDiv('divEncabezadoLista',false);		
		parent.parent.mostrarDiv('divBotonAsignarTodos',false);
		parent.parent.mostrarDiv('divBotonDesasignarTodos',false);
		parent.parent.mostrarDiv('divEncabezadoLista',false);			
		parent.parent.mostrarDiv('divHtmlList',false);		
		parent.parent.mostrarDiv('divHtmlList1',false);	
		parent.parent.mostrarDiv('divPrincipalTexto',true);	
		parent.parent.mostrarDiv('divBotonBuscarClientes',false);
		parent.parent.mostrarDiv('divBotonRegresar1',false);
		parent.parent.mostrarDiv('divBotonRegresar2',false);
		parent.parent.limpiarcampos();
	<%Case "Consultar"%>
		parent.parent.vista2();				
		parent.parent.mostrarDiv('divHtmlList',true);
		parent.parent.mostrarDiv('divPrincipalTexto',false);				
		parent.parent.mostrarDiv('divBotonRegresar1',false);
		parent.parent.mostrarDiv('divBotonRegresar2',true);
	<%Case Me._BORRAR	%>		
		parent.parent.document.forms[0].reset();				
	<%Case Me._CAMBIAR_PAG,"TraerListadoAdmin","TraerListadoCriterio"%>	
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";	
		<%Case "BrincoPagina" %>	
		parent.parent.document.getElementById('divHtmlList1').innerHTML="<%= me.strGenerarListadoSucursal("")%>";		
	<%End Select%>
	} 
//-->
</script>	

<%if Request("strCmd") ="" then %>	
<script language="javascript" id="MarcaRolloJS">
<!--
	function vista1()
	{
		parent.parent.mostrarDiv('divFiltrosLaboratorio',false);
		parent.parent.mostrarDiv('divEncabezadoLista',true);
		parent.parent.mostrarDiv('divHtmlList',true);				
		parent.parent.mostrarDiv('divPrincipalTexto',false);	
		parent.parent.mostrarDiv('divConsultaTexto',false);	
		parent.parent.mostrarDiv('divBotonBuscarClientes',true);	
		parent.parent.mostrarDiv('divFiltrosSucursal',true);	
		parent.parent.mostrarDiv('divEncabezadoDetalle',true);
	}
	
	function vista2()
	{
		parent.parent.mostrarDiv('divFiltrosLaboratorio',true);
		parent.parent.mostrarDiv('divDesasignacionTexto',false);	
		parent.parent.mostrarDiv('divAsignacionTexto',false);		
		parent.parent.mostrarDiv('divConsultaTexto',false);
		parent.parent.mostrarDiv('divBotonBuscarClientes',false);		
		parent.parent.mostrarDiv('divFiltrosSucursal',false);	
	}
function llenarconTodos()
{
if (document.forms[0].intDireccionOperativaId.value=='-1')
{document.forms[0].strDireccionOperativaNombre.value=iniText;}
}

function llenarconTodosZona()
{
if (document.forms[0].intZonaOperativaId.value=='-1')
{document.forms[0].strZonaOperativaNombre.value=iniText;
 }
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

function llenarconTodosSucursal()
{
if (document.forms[0].intDireccionOperativaIdSucursal.value=='-1')
{document.forms[0].strDireccionOperativaNombreSucursal.value=iniText;}
}

function llenarconTodosZonaSucursal()
{
if (document.forms[0].intZonaOperativaIdSucursal.value=='-1')
{document.forms[0].strZonaOperativaNombreSucursal.value=iniText;}
}
function obtenerValorBusquedaSucursal(){ 
var val;
val=document.forms[0].strDireccionOperativaNombreSucursal.value
if ( val ==iniText || val ==''){val='_';}
return val;
}

function obtenerValorBusquedaZonaSucursal(){ 
var val;
val=document.forms[0].strZonaOperativaNombreSucursal.value
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
llenarSucursal();

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

function llenarSucursal()
{
	//alert(strSucursalId)
<% if Request("strSucursalId") = ""  %>
	document.forms[0].strSucursalId.value='';
<% else%>
	document.forms[0].strSucursalId.value='<%= Request("strSucursalId") %>';
	var labs='<%= Request("strSucursalId") %>';
	var idLabs=labs.split(',');	
	for(j=0;j<idLabs.length;j++)
	{ for (i=0;i<document.forms[0].cmbSucursal.options.length;i++)
		{
		if (document.forms[0].cmbSucursal[i].value==idLabs[j])
			{document.forms[0].cmbSucursal[i].selected=true;}
	}
	}
<% end if   %>  
}

function guardarDirIdSucursal()
{document.forms[0].strZonaOperativaNombreSucursal.value=iniText;
document.forms[0].intZonaOperativaIdSucursal.value='-1';
document.forms[0].strSucursalId.value='-1';	
document.getElementById('divSucursales').innerHTML="<select name='cmbSucursal' class='comboTabla' size='4' Multiple>	<option value='-1'>- Todos -</option></select>"
}

function guardarZonaIdSucursal()
{document.forms[0].strSucursalId.value='-1';	
document.getElementById('divSucursales').innerHTML="<select name='cmbSucursal' class='comboTabla' size='4' Multiple>	<option value='-1'>- Todos -</option></select>"
doSubmit('SUCURSALES')
}

function obtenerSucursalesSeleccionados()
{document.forms[0].strSucursalId.value='-1';
		
	for (i=0;i<document.forms[0].cmbSucursal.options.length;i++)
	{	if(document.forms[0].cmbSucursal[i].selected==true)

		{document.forms[0].strSucursalId.value+=','+document.forms[0].cmbSucursal[i].value;}
		document.forms[0].strSucursalId.value=document.forms[0].strSucursalId.value.replace('-1,','');
	}
	if (document.forms[0].strSucursalId.value!='-1,')
	{document.forms[0].strSucursalId.value=document.forms[0].strSucursalId.value.replace('-1,','');}
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
	parent.parent.document.getElementById('divEncabezadoLista').innerHTML= '<p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> Laboratorios a los cuales se asignar�n Farmacias </span> </p>' ;
	parent.parent.document.getElementById('divEncabezadoDetalle').innerHTML= '<br><p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">  Selecci�n de Farmacias a Asignar </span> </p>' ;
	parent.parent.document.getElementById('divEncabezadoListaDetalle').innerHTML= '<br><p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">  Listado de Farmacias a Asignar </span> </p>' ;
}
else if (action == 'Desasignar')
{
	parent.parent.document.getElementById('divEncabezadoLista').innerHTML= '<p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> Laboratorios a los cuales se desasignar�n Farmacias</span> </p>' ;
	parent.parent.document.getElementById('divEncabezadoDetalle').innerHTML= '<br><p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">  Selecci�n de Farmacias a Desasignar </span> </p>' ;
	parent.parent.document.getElementById('divEncabezadoListaDetalle').innerHTML= '<br><p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">  Listado de Farmacias a Desasignar </span> </p>' ;
}
else if (action == 'Consultar')
{
	parent.parent.document.getElementById('divEncabezadoLista').innerHTML= '<p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> Laboratorio</span> </p>' ;
	parent.parent.document.getElementById('divEncabezadoDetalle').innerHTML= '<br><p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">  Listado de Farmacias Asignados </span> </p>' ;
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

function limpiarcampos()
{	
	document.forms[0].intDireccionOperativaId.value="";
	document.forms[0].strDireccionOperativaNombre.value="";
	document.forms[0].strZonaOperativaNombre.value="";
	document.forms[0].intZonaOperativaId.value="";
	document.forms[0].cmbLaboratorio.value="";
	document.forms[0].strLaboratoriosId.value="";
	document.forms[0].strDireccionOperativaNombreSucursal.value="";
	document.forms[0].intDireccionOperativaIdSucursal.value="";
	document.forms[0].strZonaOperativaNombreSucursal.value="";
	document.forms[0].intZonaOperativaIdSucursal.value="";
	document.forms[0].cmbSucursal.value="";
	document.forms[0].strSucursalId.value="";
	document.forms[0].strFarmaciaId.value="";
	document.forms[0].strDireccionOperativaNombre.focus();
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
		openPopup('Listado de Direcciones de Sucursales','tblDireccionOperativaSucursal',obtenerValorBusquedaSucursal(),'intDireccionOperativaIdSucursal','strDireccionOperativaNombreSucursal','&strDireccionOperativaNombreSucursal='+obtenerValorBusquedaSucursal(), 'strZonaOperativaNombreSucursal')
		break;
	case 4:
		openPopup('Listado de Zonas por Sucursal','tblZonaOperativaSucursal',obtenerValorBusquedaZonaSucursal(),'intZonaOperativaIdSucursal','strZonaOperativaNombreSucursal','&strZonaOperativaNombreSucursal='+obtenerValorBusquedaZonaSucursal()+'&intDireccionOperativaIdSucursal='+document.forms[0].intDireccionOperativaIdSucursal.value, 'cmbSucursal')
		break;
	}
	}
}

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
    var isOk=1;
	if ((action == 'Asignar') || (action == 'Desasignar') || (action == 'Consultar'))
	{
		obtenerLaboratoriosSeleccionados();
		Encabezados(action);
	}
	else if (action == 'BuscarClientes')
	{obtenerSucursalesSeleccionados();
	document.forms[0].strFarmaciaId.value=document.forms[0].strSucursalId.value }	
	
	else if (action == 'AsignacionIndividual')
	{ document.forms[0].strFarmaciaId.value=args[2];
	  action='AsignarTodos';
		if (!confirm('�Esta seguro que desea realizar la asignaci�n?')==true)
		{isOk=0;}	
	}
	else if (action == 'DesasignacionIndividual')
	{	document.forms[0].strFarmaciaId.value=args[2];
		action='DesasignarTodos';
		if (!confirm('�Esta seguro que desea realizar la desasignaci�n?')==true)
		{isOk=0;}	
	}	
	else if (action == 'AsignarTodos')
	{	if (!confirm('�Esta seguro que desea realizar la asignaci�n?')==true)
		{isOk=0;}	
	}
	else if (action == 'DesasignarTodos')
	{	if (!confirm('�Esta seguro que desea realizar la desasignaci�n?')==true)
		{isOk=0;}	
	}	
	else if (action == "Editar")
	{
		var paramLen=args[2].length;
		var intCompaniaId=args[2];	
		var intSucursalId=intCompaniaId.charAt(paramLen-3) +intCompaniaId.charAt(paramLen-2)+intCompaniaId.charAt(paramLen-1);
		intCompaniaId=intCompaniaId.replace(intSucursalId,'');					
		window.open('DetalleDeLaboratorio.aspx?intSucursalIdDetalle='+intSucursalId+'&intCompaniaIdDetalle='+intCompaniaId, "Benavides", "scrollbars=auto,resizable=yes,width=600,height=500,statusbar=no")
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


//-->
</script>
	</HEAD>
	<body onload="window_onload()">
		<form id="Form1" name="frmFotolabaFarmacias" action="about:blank" method="post">			
			<input type=hidden value="<%= intSucursalIdDetalle %>" name=intSucursalIdDetalle>
			<input type=hidden value="<%= intCompaniaIdDetalle %>" name=intCompaniaIdDetalle>	
			<input type=hidden value="<%= intSucursalIdDetalleSucursal %>" name=intSucursalIdDetalleSucursal>
			<input type=hidden value="<%= intCompaniaIdDetalleSucursal %>" name=intCompaniaIdDetalleSucursal>	
			<input type=hidden value="<%= strbotones %>" name=strbotones>
			<input type=hidden value="<%= Request("mostrar") %>" name=mostrar>	
				
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>	<td><script language="JavaScript">crearTablaHeader()</script></td></tr>
			</table>
				<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtab" width="770">Est� en : ADMIN : Asignaciones : Farmacia a Laboratorio</td>
				</tr>
			</table>			
			<table cellSpacing="0" cellPadding="0" width="780" border="0" >
				<tr>
					<td class="tdgeneralcontent">
						<div id="divPrincipalTexto"style="position:static">
							<h1>Asignaci�n de Farmacias a Laboratorios </h1>
							<p>Busque los Laboratorios al cual se le Asignar�n las Farmacias.<br></p>	
						</div>
						<div id="divAsignacionTexto" style="position:absolute; top:-800; left:-800">
							<h1>Asignaci�n de Farmacias a Laboratorios</h1>
							<p>De la lista de Laboratorios seleccionados, busque las farmacias a asignar. Para asignar una Farmacia hacer click sobre el icono correspondiente, para asignar todos hacer click sobre el bot�n "Asignar Todos".<br></p>	
						</div>
						<div id="divDesasignacionTexto" style="position:absolute; top:-800; left:-800">
							<h1>Desasignaci�n de Farmacias a Laboratorios </h1>
							<p>De la lista de Laboratorios seleccionados, busque las farmacias a desasignar. Para desasignar un cliente hacer click sobre el icono correspondiente, para desasignar todos hacer click sobre el bot�n "Desasignar Todos". <br></p>	
						</div>
						<div id="divConsultaTexto" style="position:absolute; top:-800; left:-800">
							<h1>Consulta de Farmacias a Laboratorios </h1>
							<p>Para consultar las Farmacias que est�n asignados a un Laboratorio, hacer click sobre el icono en forma de lupa correspondiente.<br></p>	
						</div>		
						<!-- FILTROS -->
						<div id="divFiltrosLaboratorio">
						<br><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">  B�squeda de Laboratorio </span>
							<table cellSpacing="0" cellPadding="0"  border="0" >																
							<tr><td  class="txtitintabla" colspan=2>
									<table>
										<tr>
										<td class="txtitintabla" align=right>Direcci�n:&nbsp;</td>
											<td><input type="text" class="field" name="strDireccionOperativaNombre"  value="-Todos-" size="40" onblur=llenarconTodos() onFocus="javascript:guardarDirId()" onkeydown="check_Enter(event, 1)">
											<input type=hidden value="-1"  name=intDireccionOperativaId>&nbsp;
											<a href="javascript:openPopup('Listado de Direcciones','tblDireccionOperativa',obtenerValorBusqueda(),'intDireccionOperativaId','strDireccionOperativaNombre','&strDireccionOperativaNombre='+obtenerValorBusqueda(),'strZonaOperativaNombre')"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Direcci�n Operativa"></a></td>
										</tr>														
										<tr>
										<td class="txtitintabla"  align=right>Zona:&nbsp;</td>
											<td><input class="field" type="text" name="strZonaOperativaNombre"  value="-Todos-" size="40"  onblur=llenarconTodosZona() onFocus="javascript:guardarZonaId()" onkeydown="check_Enter(event, 2)">
											<input type=hidden value="-1"  name="intZonaOperativaId" >&nbsp;
											<a href="javascript:openPopup('Listado de Zonas','tblZonaOperativa',obtenerValorBusquedaZona(),'intZonaOperativaId','strZonaOperativaNombre','&strZonaOperativaNombre='+obtenerValorBusquedaZona()+'&intDireccionOperativaId='+document.forms[0].intDireccionOperativaId.value, 'cmbLaboratorio')"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Zona Operativa"></a></td>										
										</tr>							
										<tr>
											<td class="txtitintabla" align=right >Laboratorio:&nbsp;</td>
											<td><div id="divLaboratorio" name="divLaboratorio"><select name='cmbLaboratorio' class='comboTabla' size='4' Multiple>	<option value='-1'>- Todos -</option></select></div>
											<input type=hidden value="-1" name="strLaboratoriosId"></td>
										</tr>	
										<tr>
											<td></td>
											<td class="txtitintabla"><input class="boton" onclick="javascript:doSubmit('Asignar')" type="button" value="Asignar" name="btnAsignar">
											&nbsp;<input class="boton" onclick="javascript:doSubmit('Desasignar')" type="button" value="Desasignar" name="btnDesasignar"></td>							
										</tr>
									</table>									
							</td><td>									
							</td></tr>																																					
							</table>
						</div>
						<!-- terminan FILTROS -->						
						<br>
						
						<div id=divEncabezadoLista name=divEncabezadoLista style="position:absolute; top:-800; left:-800"></div>
						<div id=divHtmlList name=divHtmlList ></div>
						<div id=divEncabezadoDetalle name=divEncabezadoDetalle style="position:absolute; top:-800; left:-800"></div>
						
						<!-- FILTROS Sucursal -->
						<div id=divFiltrosSucursal name=divFiltrosSucursal style="position:absolute; top:-800; left:-800">
							<table  cellSpacing="0" cellPadding="0"  border="0" >
							<tr>
								<td class="txtitintabla" align=right>Direcci�n:&nbsp;</td>
								<td colspan=2><input type="text" class="field" name="strDireccionOperativaNombreSucursal"  value="-Todos-" size="40" onblur=llenarconTodosSucursal() onFocus="javascript:guardarDirIdSucursal()" onkeydown="check_Enter(event, 3)">
									<input type=hidden value="-1"  name=intDireccionOperativaIdSucursal>&nbsp;
									<a href="javascript:openPopup('Listado de Direcciones de Sucursales','tblDireccionOperativaSucursal',obtenerValorBusquedaSucursal(),'intDireccionOperativaIdSucursal','strDireccionOperativaNombreSucursal','&strDireccionOperativaNombreSucursal='+obtenerValorBusquedaSucursal(), 'strZonaOperativaNombreSucursal')"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Direcci�n Operativa de Sucursal"></a></td>
							</tr>													
							<tr>
								<td class="txtitintabla"  align=right>Zona:&nbsp;</td>
								<td colspan=2><input class="field" type="text" name="strZonaOperativaNombreSucursal"  value="-Todos-" size="40"  onblur=llenarconTodosZonaSucursal() onFocus="javascript:guardarZonaIdSucursal()" onkeydown="check_Enter(event, 4)">
									<input type=hidden value="-1"  name="intZonaOperativaIdSucursal" >&nbsp;
									<a href="javascript:openPopup('Listado de Zonas por Sucursal','tblZonaOperativaSucursal',obtenerValorBusquedaZonaSucursal(),'intZonaOperativaIdSucursal','strZonaOperativaNombreSucursal','&strZonaOperativaNombreSucursal='+obtenerValorBusquedaZonaSucursal()+'&intDireccionOperativaIdSucursal='+document.forms[0].intDireccionOperativaIdSucursal.value, 'cmbSucursal')"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Zona Operativa por Sucursal"></a></td>										
							</tr>																	
							<tr>
								<td class="txtitintabla" align=right >Farmacia:&nbsp;</td>
								<td colspan=2><div id="divSucursales" name="divsucursales"><select name='cmbSucursal' class='comboTabla' size='4' Multiple>	<option value='-1'>- Todos -</option></select></div>
									<input type=hidden value="-1" name="strSucursalId">
									<input type=hidden value="-1" name=strFarmaciaId>	</td>
							</tr>
							<tr>
								<td></td>
								<td>
							<table cellSpacing="0" cellPadding="0"  border="0" >	<tr>
								<td></td>
								<td align = left><div id=divBotonBuscarClientes name=divBotonBuscarClientes style="position:absolute; top:-800; left:-800">
								<input class=boton onclick=javascript:doSubmit('BuscarClientes') type=button value='Buscar Farmacias' name=btnBuscarClientes></td>
								<td>
									<div id=divBotonRegresar1 name=divBotonRegresar1 style="position:absolute; top:-800; left:-800"><input class=boton onclick=javascript:doSubmit('Regresar') type=button value='Regresar' name=btnRegresar1></div>
								</td>
							</tr>
							</table>
							</td>
							</tr>		
							</table>									
						</div>			
						
						<!-- terminan FILTROS Sucursal -->			
						<br>
							<div id=divEncabezadoListaDetalle name=divEncabezadoListaDetalle style="position:absolute; top:-800; left:-800"></div>
							<div id=divHtmlList1 name=divHtmlList1 >														
								<tr>
								<table cellSpacing="0" cellPadding="0"  border="0" >	<tr>
									<td></td>
									<td align = left><div id=divBotonBuscarClientes name=divBotonBuscarClientes></div>
										<div id=divBotonAsignarTodos name=divBotonAsignarTodos  style="position:absolute; top:-800; left:-800"><input class="boton" onclick="javascript:doSubmit('AsignarTodos')" type="button" value="Asignar Todos" name="btnAsignarTodos"></div>
										<div id=divBotonDesasignarTodos name=divBotonDesasignarTodos style="position:absolute; top:-800; left:-800">&nbsp;<input class="boton" onclick="javascript:doSubmit('DesasignarTodos')" type="button" value="Desasignar Todos" name="btnDesasignarTodos"></div>
									</td>
									<td>
										<div id=divBotonRegresar2 name=divBotonRegresar2 style="position:absolute; top:-800; left:-800"><input class=boton onclick=javascript:doSubmit('Regresar') type=button value='Regresar' name=btnRegresar2></div>
									</td>
								</tr>
								</table>
							</div>	
			</tr>
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
