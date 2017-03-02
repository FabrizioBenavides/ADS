<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ReporteImagen.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsReporteImagen" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides : Administrador del Sistema Concentrador (CTX)</TITLE>
		<%
    '====================================================================
    ' Page          : ReporteImagen.aspx
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
		<script language="JavaScript" src="js/dateValidator.js" type="text/JavaScript"></script>
<script language="javascript" id="clientEventHandlersJS">
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
strSucursalNombre = "<%= strNombreSucursal %>";
strSucursalId = "<%= strSucursalId%>";
var iniText='-Todos-'
if (parent.parent.document != null){
<%= me.strActions(Request("strCmd"))%>	
<%Select Case Request("strCmd")%>
	<%Case "Reporte" %>
		newWindow('DetalleReporteImagen.aspx?t=t<%=strParametros()%>',1000,705);
	<%Case Me._CAMBIAR_PAG,"TraerListadoAdmin","TraerListadoCriterio"%>	
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";
	<%End Select%>}
//-->
</script>	

<%if Request("strCmd") ="" then %>	
<script language="javascript" id="ImagenJS">
<!--



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
val=document.forms[0].strDireccionOperativaNombre.value
if ( val ==iniText || val ==''){val='_';}
return val;
}

function AsignaTipoReporte()
{document.forms[0].intTipoReporteId.value=document.forms[0].selectTipoReporte.value
}

function AsignaTipoPago()
{document.forms[0].intTipoPagoId.value=document.forms[0].selectTipoPago.value
}

function obtenerValorBusquedaZona(){ 
var val;
val=document.forms[0].strZonaOperativaNombre.value
if ( val ==iniText || val ==''){val='_';}
return val;
}

function window_onload() 
{  
 document.forms[0].action = "<%= strThisPageName %>";
 document.forms[0].btnReporte.focus();
 llenarSucursales();
 selectSearch();
}

function llenarSucursales()
{
<% if Request("strFarmaciaId") = ""  %>
	document.forms[0].strFarmaciaId.value='';
<% else%>
	document.forms[0].strFarmaciaId.value='<%= Request("strFarmaciaId") %>';
	var labs='<%= Request("strFarmaciaId") %>';
	var idLabs=labs.split(',');	
	for(j=0;j<idLabs.length;j++)
	{ for (i=0;i<document.forms[0].cmbSucursal.options.length;i++)
		{
		if (document.forms[0].cmbSucursal[i].value==idLabs[j])
			{document.forms[0].cmbSucursal[i].selected=true;}
	}
	}
<% end if   %>  

<% if Request("strLaboratoriosId") = ""  %>
	document.forms[0].strLaboratoriosId.value='';
<% else%>
	document.forms[0].strLaboratoriosId.value='<%= Request("strLaboratoriosId") %>';
	var labs='<%= Request("strLaboratoriosId") %>';
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

function guardarDirId()
{document.forms[0].strZonaOperativaNombre.value=iniText;
document.forms[0].intZonaOperativaId.value='-1';
document.forms[0].strLaboratoriosId.value='-1';	
document.getElementById('divSucursal').innerHTML="<select name='cmbSucursal' class='comboTabla' size='4' Multiple>	<option value='-1'>- Todos -</option></select>"
}

function guardarZonaId()
{document.forms[0].strLaboratoriosId.value='-1';	
document.getElementById('divSucursal').innerHTML="<select name='cmbSucursal' class='comboTabla' size='4' Multiple>	<option value='-1'>- Todos -</option></select>"
doSubmit('LABORATORIO')
}

function obtenerSucursalesSeleccionadas()
{	
	if (document.forms[0].radFilter[0].checked==true)
	{
		document.forms[0].strFarmaciaId.value='-1';
		for (i=0;i<document.forms[0].cmbSucursal.options.length;i++)
		{	if(document.forms[0].cmbSucursal[i].selected==true)
			{document.forms[0].strFarmaciaId.value+=','+document.forms[0].cmbSucursal[i].value;}
			document.forms[0].strFarmaciaId.value=document.forms[0].strFarmaciaId.value.replace('-1,','');
		}
		if (document.forms[0].strFarmaciaId.value!='-1,')
		{document.forms[0].strFarmaciaId.value=document.forms[0].strFarmaciaId.value.replace('-1,','');}
	}
	else
	{
		document.forms[0].strLaboratoriosId.value='-1';
		for (i=0;i<document.forms[0].cmbSucursal.options.length;i++)
		{	if(document.forms[0].cmbSucursal[i].selected==true)
			{document.forms[0].strLaboratoriosId.value+=','+document.forms[0].cmbSucursal[i].value;}
			document.forms[0].strLaboratoriosId.value=document.forms[0].strLaboratoriosId.value.replace('-1,','');
		}
		if (document.forms[0].strLaboratoriosId.value!='-1,')
		{document.forms[0].strLaboratoriosId.value=document.forms[0].strLaboratoriosId.value.replace('-1,','');}
	}
}

function traerFechaInicio()
{	if(document.forms[0].dtmConsultaOrdenInicio.value=='')
	{calInicio.popup(0,true);}
}

function traerFechaFinal()
{	if(document.forms[0].dtmConsultaOrdenFinal.value=='')
	{calFinal.popup(0,true);}
}

function traerFechaPicker1()
{if(document.forms[0].dtmConsultaOrdenInicio.value !='')
	{	if(validateDate(document.forms[0].dtmConsultaOrdenInicio,'dd/MM/YYYY')==true)
		{	document.forms[0].dtmConsultaOrdenInicio.value='';
			calInicio.popup();	}
	}
	else {calInicio.popup();}
}

function traerFechaPicker2()
{if(document.forms[0].dtmConsultaOrdenFinal.value !='')
	{	if(validateDate(document.forms[0].dtmConsultaOrdenFinal,'dd/MM/YYYY')==true)
		{	document.forms[0].dtmConsultaOrdenFinal.value='';
			calFinal.popup();	}
	}
	else {calFinal.popup();}	
}

function selectSearch()
{
document.forms[0].radFilter[0].checked=true;
document.forms[0].intSucursalUEN.value=2;
document.forms[0].strDireccionOperativaNombre.value="-Todos-";
document.forms[0].strZonaOperativaNombre.value="-Todos-";
document.getElementById('divSucursal').innerHTML="<select name='cmbSucursal' class='comboTabla' size='4' Multiple>	<option value='-1'>- Todos -</option></select>";
document.forms[0].intDireccionOperativaId.value=-1;
document.forms[0].intZonaOperativaId.value=-1;
document.forms[0].strLaboratoriosId.value="-1";
document.forms[0].strFarmaciaId.value="-1";

}

function cleanSearch()
{document.forms[0].radFilter[1].checked=true;
document.forms[0].intSucursalUEN.value=12;
document.forms[0].strDireccionOperativaNombre.value="-Todos-";
document.forms[0].strZonaOperativaNombre.value="-Todos-";
document.getElementById('divSucursal').innerHTML="<select name='cmbSucursal' class='comboTabla' size='4' Multiple>	<option value='-1'>- Todos -</option></select>";
document.forms[0].intDireccionOperativaId.value=-1;
document.forms[0].intZonaOperativaId.value=-1;
document.forms[0].strLaboratoriosId.value="-1";
document.forms[0].strFarmaciaId.value="-1";
}

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
    var isOk=1;

	if (action == "Reporte")
	{	
		if (document.forms[0].radFilter[0].checked==true)
		 {document.forms[0].intTipodeBusqueda.value=2;}
		 else
		 {document.forms[0].intTipodeBusqueda.value=1;}
	
		if (document.forms[0].strLaboratoriosId.value=='')
		{
			document.forms[0].strLaboratoriosId.value='-1';
		}
		else
		{
			obtenerSucursalesSeleccionadas()
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
		openPopup('Listado de Direcciones','tblDireccionOperativa',obtenerValorBusqueda(),'intDireccionOperativaId','strDireccionOperativaNombre','&strDireccionOperativaNombre='+obtenerValorBusqueda(),'strZonaOperativaNombre');
		break;
	case 2:
		openPopup('Listado de Zonas','tblZonaOperativa',obtenerValorBusquedaZona(),'intZonaOperativaId','strZonaOperativaNombre','&strZonaOperativaNombre='+obtenerValorBusquedaZona()+'&intDireccionOperativaId='+document.forms[0].intDireccionOperativaId.value)
		break;
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
		<input type=hidden class=campotabla  name=intSucursalUEN size=10 value=-1>	
		<input type=hidden class=campotabla  name=intTipodeBusqueda	size=2 value=-1>											
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>	<td><script language="JavaScript">crearTablaHeader()</script></td></tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtab" width="770">Está en : ADMIN : Reportes : Imagen</td>
				</tr>
			</table>			
	<table cellSpacing="0" cellPadding="0" width="780" border="0" >
		<tr>
			<td class="tdgeneralcontent">								
				<h1><span class="txtitulo">Reporte de Imagen</span></h1>
				<p><span class='txsubtitulo'><br>
				<img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> Seleccione los parámetros del Reporte.</span> </p>
				<table cellSpacing="4" cellPadding="0"  border="0">
					<tr >	
						<td class="txtitintabla" align=right>Fechas:&nbsp;</td>
						<td class="txtitintabla">Inicio:&nbsp;
							<input type=text class=campotabla  name=dtmConsultaOrdenInicio size=10 value='' onclick='javascript:traerFechaInicio()'>&nbsp;<a href='javascript:traerFechaPicker1()'><img border='0' src='images/imgCalendarIcon.gif' alt='Seleccionar Fecha' ></a>																
							&nbsp;Final:&nbsp;
							<input type=text class=campotabla  name=dtmConsultaOrdenFinal size=10 value='' onclick='javascript:traerFechaFinal()'>&nbsp;<a href='javascript:traerFechaPicker2()'><img border='0' src='images/imgCalendarIcon.gif' alt='Seleccionar Fecha' ></a>																
						</td>
					</tr>
					<tr>
						<td class="txtitintabla" align=right>Tipo de Reporte:&nbsp;</td>
						<td colspan=1>
							<input type="hidden" class="field" name="intTipoReporteId"  value="-1" size="40">
							<select class="campotabla" name="selectTipoReporte"  onclick='javascript:AsignaTipoReporte()'>
								<option value="-1" selected>-Todas-</option>
								<option value="1">No Terminadas &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  </option>
								<option value="2">Terminadas</option>
							</select>
						</td>
					</tr>	
					<tr>
						<td class="txtitintabla" align=right>Tipo de Pago:&nbsp;</td>
						<td colspan=1>
							<input type="hidden" class="field" name="intTipoPagoId"  value="-1" size="40">
							<select class="campotabla" name="selectTipoPago"  onclick='javascript:AsignaTipoPago()'>
								<option value="-1" selected>-Todas-    </option>
								<option value="0">Con Anticipo &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;        </option>
								<option value="1">Liquidadas           </option>
							</select>						
						</td>
					</tr>
					<tr>
						<td class="txtitintabla" align=right></td>
						<td  class="txtitintabla" colspan=1>
						<input id="radFilter" type="radio"  name="radFilter" onclick="javascript:selectSearch()"> Farmacia:</input> 
						<input id="radFilter" type="radio"  name="radFilter" onclick="javascript:cleanSearch()"> Laboratorio:</input>			
						</td>
					</tr>	
					<tr>
							<td class="txtitintabla" align=right>Dirección:&nbsp;</td>
							<td colspan=1><input type="text" class="field" name="strDireccionOperativaNombre"  value="-Todos-" size="40" onblur=llenarconTodos() onFocus="javascript:guardarDirId()" onkeydown="check_Enter(event, 1)"><input type="hidden" value="-1"  name=intDireccionOperativaId>&nbsp;<a href="javascript:openPopup('Listado de Direcciones','tblDireccionOperativa',obtenerValorBusqueda(),'intDireccionOperativaId','strDireccionOperativaNombre','&strDireccionOperativaNombre='+obtenerValorBusqueda(),'strZonaOperativaNombre')"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Dirección Operativa"></a>
						</td>
					</tr>																	
					<tr>
						<td class="txtitintabla"  align=right>Zona:&nbsp;</td>
						<td colspan=1>
							<input class="field" type="text" name="strZonaOperativaNombre"  value="-Todos-" size="40"  onblur=llenarconTodosZona() onFocus="javascript:guardarZonaId()" onkeydown="check_Enter(event, 2)"><input type="hidden" value="-1"  name="intZonaOperativaId">&nbsp;<a href="javascript:openPopup('Listado de Zonas','tblZonaOperativa',obtenerValorBusquedaZona(),'intZonaOperativaId','strZonaOperativaNombre','&strZonaOperativaNombre='+obtenerValorBusquedaZona()+'&intDireccionOperativaId='+document.forms[0].intDireccionOperativaId.value)"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Zona Operativa"></a>
						</td>										
					</tr>																	
					<tr>
						<td class="txtitintabla" align=right >Sucursal:&nbsp;</td>
						<td><div id="divSucursal" name="divSucursal"><select name='cmbSucursal' class='comboTabla' size='4' Multiple>	<option value='-1'>- Todos -</option></select></div>
						<input type=hidden value="-1" name="strLaboratoriosId">
						<input type=hidden value="-1" name="strFarmaciaId">
						</td>
					</tr>		
					<tr>
						<td colspan=1></td>
						<td><input class="boton" onclick="javascript:doSubmit('Reporte')" type="button" value="Reporte" name="btnReporte"></td>
					</tr>
				</table>		
				<div id=divHtmlList name=divHtmlList ></div>	
				
				
				
				

				
										
			</td>
		</tr>
	</table>			
			
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
			<tr><td><script language="JavaScript">crearTablaFooter()</script></td></tr>
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
<%End If%>
</HTML>
