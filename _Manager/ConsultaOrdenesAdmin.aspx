<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ConsultaOrdenesAdmin.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsConsultaOrdenesAdmin" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides : Administrador del Sistema Concentrador (CTX)</TITLE>
		<%
    '====================================================================
    ' Page          : ConsultaOrdenesAdmin.aspx
    ' Title         : Consulta de Ordenes por Administrador (Vista de Administracion)
    ' Description   : Consulta de Ordenes.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Jorge Ventura Cantu Campos
    ' Version       : 1.0
    ' Last Modified : Wednesday, February 9Th, 2005
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
		<script language="JavaScript" src="js/calendario.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/cal_format00.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/Validator.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/FotoLabUtils.js" type="text/JavaScript"></script>		

<script language="javascript" id="clientEventHandlersJS">
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
strSucursalNombre = "<%= strNombreSucursal %>";
strSucursalId = "<%= strSucursalId%>";
var iniText='-Todos-'

if (parent.parent.document != null){
<%= me.strActions(Request("strCmd"))%>		
<%Select Case Request("strCmd")%>
	<%Case Me._EDITAR	%>				
		parent.parent.mostrarDiv('divFiltrado',false);		
		parent.parent.mostrarDiv('divListadoOrdenes',false);
		parent.parent.mostrarDiv('divBotonRegresa',true); 	
		parent.parent.mostrarDiv('divDetalleOrden',true);
		parent.parent.document.getElementById('divListadoTrabajos').innerHTML="<%= me.strGenerarlistadoTrabajos("1")%>";	
	<%Case Me._BORRAR	%>	
		parent.parent.mostrarDiv('divFiltrado',true);		
		parent.parent.mostrarDiv('divListadoOrdenes',false);	
		parent.parent.mostrarDiv('divDetalleOrden',false);		
		parent.parent.mostrarDiv('divBotonRegresa',false); 		
		parent.parent.document.forms[0].reset();	
	<%Case "Regresar"	%>
		parent.parent.mostrarDiv('divFiltrado',true);		
		parent.parent.mostrarDiv('divListadoOrdenes',true);	
		parent.parent.mostrarDiv('divDetalleOrden',false);
		parent.parent.mostrarDiv('divBotonRegresa',false); 	
	<%Case "TRAERDETALLETRABAJO"%>			
		<%= me.strDesplegarValoresDetalle()%>				
	<%Case "TraerListadoAdmin","TraerListadoCriterio"%>
		parent.parent.mostrarDiv('divListadoOrdenes',true);	
		parent.parent.document.getElementById('divListadoOrdenes').innerHTML="<%= me.strGenerarListado("1")%>";	
	<%Case Me._CAMBIAR_PAG%>	
		parent.parent.document.getElementById('divListadoOrdenes').innerHTML="<%= me.strGenerarListado("")%>";		
	<%Case "CambiarLaboratorio"%>	
		var lab  = parent.parent.document.forms[0].intLaboratorioId.value;
		var pos  = lab.indexOf (",")
		var val1 = lab.substring(0,pos)
		var val2 = lab.substring(pos+1,lab.length)
		parent.parent.document.getElementById('divDatoLaboratorio').innerHTML=
			(val1*1000) + (val2*1)	+ " "
			+ parent.parent.document.forms[0].strLaboratorioNombre.value;		
		parent.parent.document.forms[0].strLaboratorioNombre.value = "";
		parent.parent.document.forms[0].intLaboratorioId.value="";		
	<%End Select%>
	} 
	
//-->
</script>	

<%if Request("strCmd") ="" then %>	
<script language="javascript" id="MarcaRolloJS">
<!--

function mostrarDiv(divNombre,blnMostrar)
{	
    var divObj=eval("document.getElementById('"+divNombre+"')");
	if (!blnMostrar)
	{divObj.style.position='absolute';				
		divObj.style.top='-800';				
		divObj.style.left='-800';	
	}else{	divObj.style.position='static';	}
}

function llenarconTodosFinder(objHidden, objTxt)
{
	if (objTxt.value=="")
	{  
		objHidden.value='-1';  
		objTxt.value=iniText;
	}
}

function llenarconTodos()
{
	llenarconTodosFinder (document.forms[0].intDireccionOperativaId,
						  document.forms[0].strDireccionOperativaNombre )
}

function llenarconTodos_cliente()
{
	llenarconTodosFinder (document.forms[0].intConsumidorFotolabId,
						  document.forms[0].strConsumidorFotolabNombre )
}

function llenarconTodosZona()
{
	llenarconTodosFinder (document.forms[0].intZonaOperativaId,
						  document.forms[0].strZonaOperativaNombre )
}

function llenarconTodosFarmacia()
{
	llenarconTodosFinder (document.forms[0].intFarmaciaId,
						  document.forms[0].strFarmaciaNombre )
}

function llenarconTodosCliente()
{
	llenarconTodosFinder (document.forms[0].intConsumidorFotolabId,
						  document.forms[0].strConsumidorFotolabNombre )

	//if (document.forms[0].strConsumidorFotolabNombre.value=="")
	//{  
	//	document.forms[0].intConsumidorFotolabId.value='-1';  
	//	document.forms[0].strConsumidorFotolabNombre.value=iniText;
	//}
}

function obtenerValorBusqueda(){ 
var val;
val=document.forms[0].strDireccionOperativaNombre.value
if ( val ==iniText || val ==''){val='_';}
return val;
}

function AsignaEstatus()
{document.forms[0].intEstatusId.value=document.forms[0].selectEstatus.value;
selectRadio();
}


function obtenerValorBusquedaZona(){ 
var val;
val=document.forms[0].strZonaOperativaNombre.value
if ( val ==iniText || val ==''){val='_';}
return val;
}

function obtenerValorBusquedaFarmacia(){ 
var val;
val=document.forms[0].strFarmaciaNombre.value
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

if(document.forms[0].strOrden.value != '')
{document.forms[0].radFilter[0].checked=true;}
else 
{document.forms[0].radFilter[1].checked=true;}

 document.forms[0].action = "<%= strThisPageName %>";
 document.forms[0].btnBuscar.focus();
}

function selectRadio()
{document.forms[0].strOrden.value='';
document.forms[0].radFilter[1].checked=true;}

function guardarDirId()
{document.forms[0].strZonaOperativaNombre.value=iniText;
document.forms[0].intZonaOperativaId.value='-1';
document.forms[0].intFarmaciaId.value='-1';	
}

function guardarZonaId()
{
document.forms[0].strFarmaciaNombre.value=iniText;
document.forms[0].intFarmaciaId.value='-1';	
}

function selectSearch()
{document.forms[0].strOrden.focus();
document.forms[0].radFilter[0].checked=true;
}

function cleanSearch()
{document.forms[0].strOrden.value='';
}

function traerFecha(objFecha,objCalendar){	
	var fechaObj=eval('document.forms[0].'+objFecha);	
	if (fechaObj.value=='')
	{objCalendar.popup(0,true);}
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

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
    var isOk=1;

    if (action == "Borrar")
	{if (!confirm('¿Está seguro que desea cancelar La orden ' + document.forms[0].strOrden.value + ' ?'))
			{isOk=0;}
	}
	if (action == "Buscar")
	{	
		if (document.forms[0].intFarmaciaId=='')
		{
			document.forms[0].intFarmaciaId.value='-1';
		}		
		if (document.forms[0].strOrden.value=='')
		{
			document.forms[0].strOrdenId.value='-';
		}
		else
		{
			document.forms[0].strOrdenId.value = document.forms[0].strOrden.value;
		}
		if ((isEmpty(document.forms[0].dtmConsultaOrdenFinal)==true) && (isEmpty(document.forms[0].dtmConsultaOrdenInicio)==true))
		{
			document.forms[0].dtmFinal.value="01/01/1900"
			document.forms[0].dtmInicio.value="01/01/1900"
		}
		else
		{
			if ((isEmpty(document.forms[0].dtmConsultaOrdenFinal)==false) && (isEmpty(document.forms[0].dtmConsultaOrdenInicio)==false))
			{
				if(validateDate(document.forms[0].dtmConsultaOrdenFinal, 'dd/MM/YYYY')==false) 
				{
					return false;
				}

				if(validateDate(document.forms[0].dtmConsultaOrdenInicio, 'dd/MM/YYYY')==false) 
				{
					return false;
				}
			}
			else
			{
				if (isEmpty(document.forms[0].dtmConsultaOrdenFinal)==false)
				{
					if(validateDate(document.forms[0].dtmConsultaOrdenFinal, 'dd/MM/YYYY')==false) 
					{
					return false;
					}
				}
				else
				{
					alert("Incorpore una fecha válida. A la Fecha de Final")
					return false;
				}
				if (isEmpty(document.forms[0].dtmConsultaOrdenInicio)==false)
				{
					if(validateDate(document.forms[0].dtmConsultaOrdenInicio, 'dd/MM/YYYY')==false) 
					{
					return false;
					}
				}
				else
				{
					alert("Incorpore una fecha válida. A la Fecha de Inicio")
					return false;
				}
			}		
			if (validateStartAndEndDate('dtmConsultaOrdenInicio', 'dtmConsultaOrdenFinal', 'dd/MM/YYYY')== false)
			{	
				alert('La Fecha Final, no puede ser anterior a la Fecha de inicio');
				return false;
			}
			document.forms[0].dtmFinal.value=document.forms[0].dtmConsultaOrdenFinal.value
			document.forms[0].dtmInicio.value=document.forms[0].dtmConsultaOrdenInicio.value
		}
		

		if (document.forms[0].radFilter[0].checked ==true)
			{
				if (document.forms[0].strOrden.value.length > 0)			
					{action='TraerListadoCriterio';	}
				else{									
					alert('Para hacer una búsqueda  es necesario escribir un No. de Orden válido'); 
					document.forms[0].strOrden.focus();		
					document.forms[0].radFilter[0].checked=true;	
					return false;}	
		}else
		{action='TraerListadoAdmin';
		document.forms[0].radFilter[1].checked=true;	}
	}
	if (isOk==1)
	{
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{params+= "&" + args[i] + "=" + args[i+1]}	
	 document.forms[0].action = "<%= strThisPageName %>?strCmd=" + action + params    	
	document.forms[0].target="ifrOculto";	
	document.forms[0].submit();  
	}
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
		doSubmit('Buscar');
		break;
	case 2:
		openPopup('Listado de Direcciones','tblDireccionOperativa',obtenerValorBusqueda(),'intDireccionOperativaId','strDireccionOperativaNombre','&strDireccionOperativaNombre='+obtenerValorBusqueda())
		break;
	case 3:
		openPopup('Listado de Zonas','tblZonaOperativa',obtenerValorBusquedaZona(),'intZonaOperativaId','strZonaOperativaNombre','&strZonaOperativaNombre='+obtenerValorBusquedaZona()+'&intDireccionOperativaId='+document.forms[0].intDireccionOperativaId.value)
		break;
	case 4:
		openPopup('Listado de Farmacias','tblLaboratorio',obtenerValorBusquedaFarmacia(),'intFarmaciaId','strFarmaciaNombre','&strFarmaciaNombre='+obtenerValorBusquedaFarmacia()+'&intZonaOperativaid='+document.forms[0].intZonaOperativaId.value+'&intDireccionOperativaId='+document.forms[0].intDireccionOperativaId.value)
		break;
	case 5:
		openConsPopUp();
		break;
		}
	}
}
function openConsPopUp()
{
	if (document.forms[0].strConsumidorFotolabNombre.value == iniText)
	{  document.forms[0].strConsumidorFotolabNombre.value = "";  }
	
	openPopup('Listado de Clientes','tblConsumidorFotolab',document.getElementById('strConsumidorFotolabNombre').value,'intConsumidorFotolabId','strConsumidorFotolabNombre','','');
}

function obtenerValorBusquedaLaboratorio()
{ 
	var val;
	val=document.forms[0].strLaboratorioNombre.value
	if ( val ==iniText || val ==''){val='_';}
	return val;
}
function reasignarLaboratorio()
{
	if (document.forms[0].intLaboratorioId.value == "-1" 
		|| document.forms[0].intLaboratorioId.value == ""  )
	{
		alert ("Para realizar esta opción debe seleccionar un laboratorio.");
	}
	else
	{
		if (confirm ("¿Desea reasignar Laboratorio a esta orden?") )
		{
			doSubmit('CambiarLaboratorio');
		}
		else
		{
			document.forms[0].intLaboratorioId.value = "";
			document.forms[0].strLaboratorioNombre.value = "";
		}
	}
}
//-->
</script>
	</HEAD>
	<body onload="window_onload()">
		<form id="Form1" name="frmCliente" action="about:blank" method="post">			
		<input type=hidden class=campotabla  name=dtmInicio size=10 value=''>															
		<input type=hidden class=campotabla  name=dtmFinal size=10 value=''>													
		<input type=hidden class=campotabla  name=strOrdenId size=10 value=''>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>	<td><script language="JavaScript">crearTablaHeader()</script></td></tr>
			</table>
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
		<tr><td width="10">&nbsp;</td><td class="tdtab" width="770">Está en : ADMIN : Ordenes : Consulta </td></tr>
		</table>		
<table cellSpacing="0" cellPadding="0" width="780" border="0" >
				<tr>
					<td class="tdgeneralcontent">								
<!-- FILTROS -->						
<div id=divFiltrado>	
					<h1><span class="txtitulo">Consulta de Ordenes </span></h1>
					<p><span class="tdtablacont"><span class="txcontenido">Seleccione el criterio de b&uacute;squeda para la consulta de Ordenes.</span></span></p>
					<span class='txsubtitulo'><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> B&uacute;squeda de Ordenes </span> </p>
			
						<table cellSpacing="4" cellPadding="0"  border="0">
									<tr>
									<td ><input id="radFilter" type="radio"  name="radFilter" onclick="javascript:selectSearch()"></td>
									<td class="txtitintabla" >Número de Orden:&nbsp; </td>
									<td><input class="field" id="strOrden" type="text" maxLength="50" size="20" name="strOrden" value="<%= Request("strOrden") %>" onclick="javascript:selectSearch()" onKeyPress="check_Enter(event, 1)"/></td>
									</tr>
									<tr colspan=5>	
										<td rowspan=6>
											<input  id="radFilter" type="radio"  name="radFilter" onclick="javascript:cleanSearch()"></input>
										</td>
										
										<td class="txtitintabla" align=right>Fechas:&nbsp;</td>
										<td class="txtitintabla">Inicio:&nbsp;
											<input type=text class=campotabla  name=dtmConsultaOrdenInicio size=10 value='' onclick=javascript:traerFecha('dtmConsultaOrdenInicio',calInicio)>&nbsp;<a href=javascript:traerFechaPicker('dtmConsultaOrdenInicio',calInicio)><img border='0' src='images/imgCalendarIcon.gif' alt='Seleccionar Fecha' ></a>																
											&nbsp;Final:&nbsp;
											<input type=text class=campotabla  name=dtmConsultaOrdenFinal size=10 value='' onclick=javascript:traerFecha('dtmConsultaOrdenFinal',calFinal)>&nbsp;<a href=javascript:traerFechaPicker('dtmConsultaOrdenFinal',calFinal)><img border='0' src='images/imgCalendarIcon.gif' alt='Seleccionar Fecha' ></a>																
										</td>
									</tr>
									<tr>
										<td class="txtitintabla" align=right>Estatus:&nbsp;</td>
										<td colspan=1>
											<input type="hidden" class="field" name="intEstatusId"  value="-1" size="40">
											<select class="campotabla" name="selectEstatus"  onclick='javascript:AsignaEstatus()'>
												<option value="-1" selected>-Todos-</option>
												<option value="1">Ingresada</option>
												<option value="2">Entregada Ingresada</option>
												<option value="3">En Proceso</option>
												<option value="4">Terminada</option>
												<option value="5">Entregada Terminada</option>
												<option value="6">Recibida</option>
												<option value="7">Cancelada</option>
											</select>
										</td>
									</tr>		
									<tr>
										<td class="txtitintabla" align=right>Dirección:&nbsp;</td>
										<td colspan=1><input type="text" class="field" name="strDireccionOperativaNombre"  value="-Todos-" size="40" onblur="javascript:llenarconTodos()" onFocus="javascript:guardarDirId()" onclick='javascript:selectRadio()' onKeyPress="check_Enter(event, 2)">
											<input type="hidden" value="-1"  name=intDireccionOperativaId>&nbsp;
											<a href="javascript:openPopup('Listado de Direcciones','tblDireccionOperativa',obtenerValorBusqueda(),'intDireccionOperativaId','strDireccionOperativaNombre','&strDireccionOperativaNombre='+obtenerValorBusqueda())"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Dirección Operativa"></a>
										</td>
									</tr>																	
									<tr>
										<td class="txtitintabla"  align=right>Zona:&nbsp;</td>
										<td colspan=1>
											<input class="field" type="text" name="strZonaOperativaNombre"  value="-Todos-" size="40"  onblur=llenarconTodosZona() onclick='javascript:selectRadio()' onFocus="javascript:guardarZonaId()" onKeyPress="check_Enter(event, 3)" >
											<input type="hidden" value="-1"  name="intZonaOperativaId" >&nbsp;
											<a href="javascript:openPopup('Listado de Zonas','tblZonaOperativa',obtenerValorBusquedaZona(),'intZonaOperativaId','strZonaOperativaNombre','&strZonaOperativaNombre='+obtenerValorBusquedaZona()+'&intDireccionOperativaId='+document.forms[0].intDireccionOperativaId.value)"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Zona Operativa"></a>
										</td>										
									</tr>																	
									<tr>
										<td class="txtitintabla" align=right >Farmacia:&nbsp;</td>
										<td colspan=1>
											<input class="field" type="text" name="strFarmaciaNombre"  value="-Todos-" size="40"  onblur=llenarconTodosFarmacia() onclick='javascript:selectRadio()' onKeyPress="check_Enter(event, 4)">
											<input type="hidden" value="-1"  name="intFarmaciaId" >&nbsp;
											<a href="javascript:openPopup('Listado de Farmacias','tblLaboratorio',obtenerValorBusquedaFarmacia(),'intFarmaciaId','strFarmaciaNombre','&strFarmaciaNombre='+obtenerValorBusquedaFarmacia()+'&intZonaOperativaid='+document.forms[0].intZonaOperativaId.value+'&intDireccionOperativaId='+document.forms[0].intDireccionOperativaId.value)"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Farmacias"></a>
										</td>
									</tr>		
									
									<tr>	
										<td class="txtitintabla" align=right >Cliente:&nbsp;</td>
										<td  colspan=1>								
											<div id="divConsumidorFotolabNombre">								
											<input type='text' class='campotabla'  value='-Todos-' size=40 name='strConsumidorFotolabNombre' id='strConsumidorFotolabNombre' onblur="llenarconTodosCliente()" onclick='javascript:selectRadio()' onKeyPress="check_Enter(event, 5)"  >&nbsp;
											<input type="hidden"  value="-1" name="intConsumidorFotolabId">							
											<a href=javascript:openConsPopUp()><img src='../static/images/icono_lupa.gif' width='17' height='17' border='0' align='middle' alt='Buscar Cliente'></a>&nbsp;
											</div>										
											
										</td>
									</tr>
																		
									
									<tr>
									<td class="txtitintabla" align=right ></td>
									<td colspan=1></td>
									<td><input class="boton" onclick="javascript:doSubmit('Buscar')" type="button" value="Buscar" name="btnBuscar"></td>
									</tr>
									</table>									
				
</div>
<!-- terminan FILTROS -->

<br>
<!-- inicio LISTADO DE ORDENES  -->
<div id=divListadoOrdenes style="position:absolute; top:-800; left:-800"></div>
<!-- termina LISTADO DE ORDENES -->


<!-- inicio DETALLE DE ORDEN -->
<input type="hidden" id="IntOrdenId" name="IntOrdenId"  />
<div id=divDetalleOrden style="position:absolute; top:-800; left:-800">					
					<h1><span class="txtitulo">Detalle de Orden </span></h1>
					<p><span class='txsubtitulo'><br>
					<img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> Detalle de Orden </span> </p>	        
					<table class="tdenvolventetablas" cellSpacing="0" cellPadding="0" width="100%" border="0" >				
						<tr>
						  <td class="txtitintabla" Align="right" width="20%">Farmacia:&nbsp;</td>
						  <td class="tdconttablas" colspan=2  Align="left" width="80%"><div id=divDatoCliente></div></td>
						</tr>	
						<tr>
						  <td class="txtitintabla" Align="right" width="20%">Laboratorio:&nbsp;</td>
						  <td class="tdconttablas" Align="left" width="40%"><div id=divDatoLaboratorio></div></td>
						  
						  <td class="tdconttablas" Align="left" width="40%">
						  <!--Elongoria 01/Ene/2006 -->
						  <!--La opcion de reasignacion de laboratorio fue ocultada-->
						    <table border=1 style="visibility:hidden">
						      <tr>
						        <td>
						          <input class="field" type="text" name="strLaboratorioNombre"  value="" size="30"  onKeyPress="check_Enter(event,2)">
								  <input type="hidden" value="-1"  name="intLaboratorioId" ><a href="javascript:openPopup('Listado de Laboratorios','popupLabIngOrd',document.forms[0].strLaboratorioNombre.value,'intLaboratorioId','strLaboratorioNombre','&strLaboratorioNombre='+document.forms[0].strLaboratorioNombre.value)"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Reasignar Laboratorio"></a>
						        </td>
						        <td>
						          <input class="boton" onclick="javascript:reasignarLaboratorio()" type="button" value="Reasignar" name="btnCambiarLaboratorio">						          
						        </td>
						      </tr>
						    </table>
						  </td>
						</tr>	
						<tr>
						  <td class="txtitintabla" Align="right" width="20%">Orden:&nbsp;</td>
						  <td class="tdconttablas" colspan=2  Align="left" width="80%"><div id=divDatoOrden></div></td>
						</tr>
						<tr>
						<td class="txtitintabla" Align="right" width="20%">Formato Rollo:&nbsp;</td>
						<td class="tdconttablas" colspan=2  Align="left" width="80%"><div id=divFormatoRollo></div></td>
						</tr>		
						<tr>
						  <td class="txtitintabla" vAlign="top" Align="right" width="20%">Estatus:&nbsp;</td>
						  <td class="tdconttablas" colspan=2 Align="left" width="80%"><br><div id=divDatoEstatus></div><br></td>						  
						</tr>			
						<tr>
						  <td class="txtitintabla" Align="right" width="20%">Fecha Ingreso:&nbsp;</td>
						  <td class="tdconttablas" colspan=2  Align="left" width="80%"><div id=divDatoFecha></div></td>
						</tr>						
						<tr>
						  <td class="txtitintabla" vAlign="top" Align="right" width="20%"><div id=divDatoAnticipoLbl>Anticipo:</div></td>
						  <td class="tdconttablas" colspan=2 Align="left" width="80%"><br><div id=divDatoAnticipo></div><br></td>
						</tr>	
						<tr>
						  <td class="txtitintabla" Align="right" width="20%"><div id="divPrepagoLbl"></div></td>
						  <td class="tdconttablas" colspan=2  Align="left" width="80%"><div id=divDatoPrepago></div></td>
						</tr>					
						<tr>
						  <td class="txtitintabla" vAlign="top" Align="right" width="20%">Fecha de Ultima Modificación:&nbsp;</td>
						  <td class="tdconttablas" colspan=2 Align="left" width="80%"><br><div id=divFechaModificado></div><br></td>
						</tr>	
						<tr>
						  <td class="txtitintabla" vAlign="top" Align="right" width="20%">Modificado Por:&nbsp;</td>
						  <td class="tdconttablas" colspan="2" Align="left" width="80%"><br><div id=divModificadoPor></div><br></td>						  
						</tr>	
					</table>						
								
					<!-- inicio LISTADO DE TRABAJOS -->
					<div id=divListadoTrabajos></div>

</div>
<!-- termina DETALLE DE ORDEN -->
<br>
<div id=divBotonRegresa style="position:absolute; top:-800; left:-800">	
	<input class="boton" onclick="javascript:doSubmit('Regresar')" type="button" value="Regresar" name="btnRegresar">
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
				var calInicio = new calendar(null, document.forms[0].elements["dtmConsultaOrdenInicio"]);		
				var calFinal = new calendar(null, document.forms[0].elements["dtmConsultaOrdenFinal"]);	
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
		 {
			window.focus();
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
