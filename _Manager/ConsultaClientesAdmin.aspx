<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ConsultaClientesAdmin.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsConsultaClientesAdmin" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides : Administrador del Sistema Concentrador (CTX)</TITLE>
		<%
    '====================================================================
    ' Page          : ConsultaClientesAdmin.aspx
    ' Title         : Catálogo de Clientes (Vista de Administracion)
    ' Description   : Consulta de Clientes.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Enrique Longoria
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
		<script language="JavaScript" src="js/FotoLabUtils.js" type="text/JavaScript"></script>
<script language="javascript" id="clientEventHandlersJS">
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
strSucursalNombre = "<%= strNombreSucursal %>";
strSucursalId = "<%= strSucursalId%>";
var iniText='-Todos-'

if (parent.parent.document.getElementById('divHtmlList') != null){
<%= me.strActions(Request("strCmd"))%>		
<%Select Case Request("strCmd")%>
	<% Case Me._NUEVO %>			
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";	
		parent.parent.document.forms[0].reset();	
	<%Case Me._GUARDAR%>	
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";	
		parent.parent.document.forms[0].reset();
	<%Case Me._EDITAR	%>			
		parent.parent.document.getElementById('divEdicion').style.position='static';	
		parent.parent.ponfocus();		
	<%Case Me._BORRAR	%>		
		parent.parent.document.forms[0].reset();				
	<%Case Me._CAMBIAR_PAG,"TraerListadoAdmin","TraerListadoCriterio"%>	
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";
		parent.parent.mostrarDiv('divEdicion',false);			
	<%End Select%>
	} 
	
//-->
</script>	

<%if Request("strCmd") ="" then %>	
<script language="javascript" id="MarcaRolloJS">
<!--
function llenarconTodos()
{
if (document.forms[0].intDireccionOperativaId.value=='-1')
{document.forms[0].strDireccionOperativaNombre.value=iniText;}
}

function mostrarDiv(divNombre,blnMostrar)
{	var divObj=eval("document.getElementById('"+divNombre+"')");
	if (!blnMostrar)
	{divObj.style.position='absolute';				
	divObj.style.top='-800';				
	divObj.style.left='-800';	
	}else{	divObj.style.position='static';}
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

function obtenerValorBusquedaZona(){ 
var val;
val=document.forms[0].strZonaOperativaNombre.value
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

if(document.forms[0].strCliente.value != '')
{document.forms[0].radFilter[0].checked=true;}
else 
{document.forms[0].radFilter[1].checked=true;
llenarSucursales();}

 document.forms[0].action = "<%= strThisPageName %>";
 document.forms[0].btnBuscar.focus();
}

function llenarSucursales()
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

function selectRadio()
{document.forms[0].strCliente.value='';
document.forms[0].radFilter[1].checked=true;}

function guardarDirId()
{document.forms[0].strZonaOperativaNombre.value=iniText;
document.forms[0].intZonaOperativaId.value='-1';
document.forms[0].strLaboratoriosId.value='-1';	
document.getElementById('divLaboratorio').innerHTML="<select name='cmbLaboratorio' class='comboTabla' size='5' onclick='javascript:selectRadio()'   Multiple>	<option value='-1'>- Todos -</option></select>"
}

function guardarZonaId()
{document.forms[0].strLaboratoriosId.value='-1';	
document.getElementById('divLaboratorio').innerHTML="<select name='cmbLaboratorio' class='comboTabla' size='5' onclick='javascript:selectRadio()'   Multiple>	<option value='-1'>- Todos -</option></select>"
doSubmit('LABORATORIO')
}

function obtenerLaboratoriosSeleccionados()
{document.forms[0].strLaboratoriosId.value='-1';
	for (i=0;i<document.forms[0].cmbLaboratorio.options.length;i++)
	{	if(document.forms[0].cmbLaboratorio[i].selected==true)
		{document.forms[0].strLaboratoriosId.value+=','+document.forms[0].cmbLaboratorio[i].value;}
	}
	if (document.forms[0].strLaboratoriosId.value!='-1,')
	{document.forms[0].strLaboratoriosId.value=document.forms[0].strLaboratoriosId.value.replace('-1,','');}
}

function selectSearch()
{document.forms[0].strCliente.focus();
document.forms[0].radFilter[0].checked=true;
}

function cleanSearch()
{document.forms[0].strCliente.value='';
}

function ponfocus()
{	
	document.forms[0].intfocus.focus();
}

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
	if (action == "Buscar")
	{		
		if (document.forms[0].radFilter[0].checked ==true)
			{
				if (document.forms[0].strCliente.value.length > 0)			
					{action='TraerListadoCriterio';	}
				else{									
					alert('Para hacer una búsqueda  es necesario escribir datos del Cliente válido'); 
					document.forms[0].strCliente.focus();		
					document.forms[0].radFilter[0].checked=true;	
					return false;}	
		}else
			{action='TraerListadoAdmin';
			obtenerLaboratoriosSeleccionados()
			document.forms[0].radFilter[1].checked=true;}		
				
	}
	
	document.forms[0].mostrar.value='si';
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{params+= "&" + args[i] + "=" + args[i+1]}	
	 document.forms[0].action = "<%= strThisPageName %>?strCmd=" + action + params    
	  
	if (action == "<%= Me._EDITAR%>")
	{
		var paramLen=args[2].length;
		var intCompaniaId=args[2];	
		var intSucursalId=intCompaniaId.charAt(paramLen-3) +intCompaniaId.charAt(paramLen-2)+intCompaniaId.charAt(paramLen-1);
		intCompaniaId=intCompaniaId.replace(intSucursalId,'');	
		document.forms[0].action=document.forms[0].action.replace('intSucursalId','aux')
		document.forms[0].action+='&intSucursalIdDetalle='+intSucursalId+'&intCompaniaIdDetalle='+intCompaniaId;	
	}		
	
	document.forms[0].target="ifrOculto";	
	document.forms[0].submit();  
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
		doSubmit('Buscar')
		break;	
		
	}
	}
}
//-->
</script>
	</HEAD>
	<body onload="window_onload()">
		<form id="Form1" name="frmCliente" action="about:blank" method="post">			
				<input type=hidden value="<%= intSucursalIdDetalle %>" name=intSucursalIdDetalle>
			<input type=hidden value="<%= intCompaniaIdDetalle %>" name=intCompaniaIdDetalle>		
			<input type=hidden value="<%= Request("mostrar") %>" name=mostrar>		
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>	<td><script language="JavaScript">crearTablaHeader()</script></td></tr>
			</table>		
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtab" width="770">Está en : ADMIN : Catálogos : Farmacias </td>
				</tr>
			</table>	
			<table cellSpacing="0" cellPadding="0" width="780" border="0" >
				<tr>
					<td class="tdgeneralcontent">
						<h1>Consulta de Farmacias</h1>
						<p>Aquí podrá consultar las  Farmacias.<br>
						Para buscar por Farmacia elegir la búsqueda Por Farmacia y para buscar todas las Farmacias elegir Todos y oprimir Buscar .</p>	
						<!-- FILTROS -->
						<table cellSpacing="0" cellPadding="0"  border="0" >
						<tr>
							<td>
								<input id="radFilter" type="radio"  name="radFilter" onclick="javascript:selectSearch()"/>
							</td>
							<td class="txtitintabla">Por Farmacia:&nbsp;</td>
							<td>
								<input class="field" id="strCliente" type="text" maxLength="50" size="30" name="strCliente" value="<%= Request("strCliente") %>" onclick="javascript:selectSearch()" onkeydown="check_Enter(event, 3)"></input>
							</td>
						</tr>																	
						<tr>		
							<td rowspan=3>
								<input  id="radFilter" type="radio"  name="radFilter" onclick="javascript:cleanSearch()"/>
							</td>
									<td class="txtitintabla" align=right>Dirección:&nbsp;</td>
										<td><input type="text" class="field" name="strDireccionOperativaNombre"  value="-Todos-" size="40" onblur=llenarconTodos() onFocus="javascript:guardarDirId()" onclick='javascript:selectRadio()' onkeydown="check_Enter(event, 1)">
										<input type=hidden value="-1"  name=intDireccionOperativaId><a href="javascript:openPopup('Listado de Direcciones','tblDireccionOperativa',obtenerValorBusqueda(),'intDireccionOperativaId','strDireccionOperativaNombre','&strDireccionOperativaNombre='+obtenerValorBusqueda(),'strZonaOperativaNombre')"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Dirección Operativa"></a></td>
									</tr>
									<tr>
									<td class="txtitintabla"  align=right>Zona:&nbsp;</td>
										<td><input class="field" type="text" name="strZonaOperativaNombre"  value="-Todos-" size="40"  onblur=llenarconTodosZona() onclick='javascript:selectRadio()' onFocus="javascript:guardarZonaId()" onkeydown="check_Enter(event, 2)">
										<input type="hidden" value="-1"  name="intZonaOperativaId" ><a href="javascript:openPopup('Listado de Zonas','tblZonaOperativa',obtenerValorBusquedaZona(),'intZonaOperativaId','strZonaOperativaNombre','&strZonaOperativaNombre='+obtenerValorBusquedaZona()+'&intDireccionOperativaId='+document.forms[0].intDireccionOperativaId.value, 'cmbLaboratorio')"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Buscar Zona Operativa"></a></td>										
									</tr>																	
									<tr>
									<td class="txtitintabla" align=right >Farmacia:&nbsp;</td>
									<td><div id="divLaboratorio" name="divLaboratorio"><select name='cmbLaboratorio' class='comboTabla' size='5' onclick='javascript:selectRadio()'   Multiple>	<option value='-1'>- Todos -</option></select></div>
									<input type="hidden" value="-1" name="strLaboratoriosId"></td>
							</td>						
						</tr>					
						<tr>
						<td>&nbsp;</td>
							<td class="txtitintabla" ><input class="boton" onclick="javascript:doSubmit('Buscar')" type="button" value="Buscar" name="btnBuscar"></td></tr>																																
						</table>
						<!-- terminan FILTROS -->
						<br>						
						<div id=divHtmlList name=divHtmlList></div>						
						<br><br>
				<div id="divEdicion" style="position:absolute; top:-800; left:-800">
				<table class="tdenvolventetablas" cellSpacing="0" cellPadding="0" width="100%" border="0" >				
				<tr><td class="txtitintabla" Align="right" width="20%">Farmacia:&nbsp;</td><td class="tdconttablas" colspan=2 Align="left" width="80%"><div id=divSucursalccsss></div></td></tr>	
				<tr>	<td class="txtitintabla" Align="right" width="20%">Razón Social:&nbsp;</td><td class="tdconttablas" colspan=2  Align="left" width="80%"><div id=divSucursalRazonSocial></div></td></tr>						
				<tr><td class="txtitintabla" Align="right" width="20%">Dirección Operativa:&nbsp;</td><td class="tdconttablas" colspan=2  Align="left" width="80%"><div id=divSucursalDireccionOperativa></div></td></tr>	
				<tr><td class="txtitintabla" Align="right" width="20%">Zona Operativa:&nbsp;</td><td class="tdconttablas" colspan=2  Align="left" width="80%"><div id=divSucursalZonaOperativa></div></td></tr>	
				<tr>	<td class="txtitintabla" vAlign="top" Align="right" width="20%">Laboratorios Asociadas:&nbsp;</td><td class="tdconttablas" Align="left" width="78%"><br><div id=divRecordBrowserHTMLSuc></div><br></td><td>&nbsp;</td></tr>													
				</table>	
			</div>
					</td>
				</tr>
			</table>			
			
<input type="text" value="-1"  name="intfocus" style="position:absolute; left:-800px">
					
			
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

</HTML>
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