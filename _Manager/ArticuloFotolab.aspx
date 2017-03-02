<%@ Page Codebehind="Articulocom.isocraft.backbone.ccentral.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.ArticuloFotolab" Explicit="True" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides : Sistema Administrador de Puntos de Venta</TITLE>
<%
    '====================================================================
    ' Page          : Articulocom.isocraft.backbone.ccentral.aspx
    ' Title         : Catálogo de Articulos
    ' Description   : Catálogo de Clasificacion de Artículos Por Sucursal
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Jorge Ventura Cantu Campos
    ' Version       : 1.0
    ' Last Modified : Friday, February 11Th, 2005
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

<script language="javascript" id="AuxArticuloFotolabJS">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
strSucursalNombre = "<%= strNombreSucursal %>";
strSucursalId = "<%= strSucursalId%>";

if (parent.parent.document.getElementById('divHtmlList') != null){
//parent.parent.mostrarDiv('divEdicion',false);
<%= me.strActions(Request("strCmd"))%>		
<%Select Case Request("strCmd")%>
	<% Case Me._NUEVO %>			
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";	
		parent.parent.document.forms[0].reset();
	<%Case Me._EDITAR%>		
		parent.parent.mostrarDiv('divEdicion',true);
		parent.parent.ponfocus();		
	<%Case Me._GUARDAR%>	
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";			
		parent.parent.mostrarDiv('divEdicion',false);
		//parent.parent.document.forms[0].reset();
	<%Case Me._BORRAR	%>		
		parent.parent.document.forms[0].reset();
	<%Case me._TRAER_LISTADO, Me._TRAER_LISTADO_FILTRADO, Me._CAMBIAR_PAG%>		
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";		
	<%End Select%>
	} 
//-->
</script>	

<%if Request("strCmd") ="" then %>	
<script language="javascript" id="MarcaRolloJS">
<!--

function mostrarDiv(divNombre,blnMostrar)
{	var divObj=eval("document.getElementById('"+divNombre+"')");
	if (!blnMostrar)
	{divObj.style.position='absolute';				
	divObj.style.top='-800';				
	divObj.style.left='-800';	
	}else{	divObj.style.position='static';}
}

function window_onload() 
{
  <% if CStr(Request("strCmd")) = Me._IMPRIMIR then  %>
	  printDocument()
<% elseif CStr(Request("strCmd")) = Me._EXPORTAR then  %>
	exportDocument()
  <% end if   %>
  document.forms[0].action = "<%= strThisPageName %>";
}


function cambiarPermitidoOrden()
	{ if (document.forms[0].chkPermitidoOrden.checked == true)
		{document.forms[0].blnArticuloFotolabPermitidoOrden.value="1";}
		else
		{document.forms[0].blnArticuloFotolabPermitidoOrden.value="0";}
	}
	
	
function showError(msg)
{	alert (msg);   }

function selectSearch()
{document.forms[0].radFilter[0].checked=true;
document.forms[0].strArticulos.setfocus;}

function cleanSearch()
{document.forms[0].strArticulos.value='';}

function ponfocus()
{document.forms[0].intfocus.focus();}

function obtenerValorClasificacion(){ 
var val;
val=document.forms[0].strArticuloClasificacionNombre.value
if (val ==''){val='_';}
return val;
}

function validarFiltrado()
{
	if (!isNaN(document.forms[0].strArticulos.value))
	{
	if(document.forms[0].strArticulos.value.length>8)	
		{document.forms[0].strCodigoDeBarras.value=document.forms[0].strArticulos.value;}
	else{document.forms[0].strCodigoDeBarras.value='_';}
	}	
	else
	{document.forms[0].strCodigoDeBarras.value='_';}
}

function check_Enter(e)
{	var key;		
	if(window.event) // for IE
		{key = e.keyCode; }
	else if(e.which) // for Netscape-Firefox
		{key = e.which; }
	else 
		{return true;}			
	if (key==13)	
	{return doSubmit('Buscar');}
}

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
    var isOk=1;
    
	if (action == "Buscar")
	{	validarFiltrado();
		if (document.forms[0].radFilter[0].checked ==true)
		{
			if (document.forms[0].strArticulos.value.length > 0)			
				{action='<%= Me._TRAER_LISTADO_FILTRADO %>';}
			else
				{alert('Para hacer una búsqueda es necesario escribir el Dato del artículo');return false;	}				
		}
		else
			{action='<%= Me._TRAER_LISTADO%>';}	
	}
	else if (action == "<%= Me._Guardar%>")
	{
		if (validarCampos()==false) {isOk=0;}
	}
	

if (isOk==1)
{
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{params+= "&" + args[i] + "=" + args[i+1]}
	
    document.forms[0].action = "Articulocom.isocraft.backbone.ccentral.aspx?strCmd=" + action + params
	document.forms[0].target="ifrOculto";	
    document.forms[0].submit();
  }
}

function validarCampos()
{
document.forms[0].fltArticuloFotolabPrecioFoto.value=document.forms[0].fltArticuloFotolabPrecioFoto.value.replace(',','');
document.forms[0].fltArticuloFotolabPrecioRevelado.value=document.forms[0].fltArticuloFotolabPrecioRevelado.value.replace(',','')

if (isNaN(document.forms[0].fltArticuloFotolabPrecioFoto.value))
	{alert('Favor de Capturar un Precio por Foto válido.');return false;}
if (document.forms[0].fltArticuloFotolabPrecioFoto.value=="")
	{document.forms[0].fltArticuloFotolabPrecioFoto.value=0;}
	
if (isNaN(document.forms[0].fltArticuloFotolabPrecioRevelado.value))
	{alert('Favor de Capturar un Precio por Revelado válido.');return false;}
if (document.forms[0].fltArticuloFotolabPrecioRevelado.value=="")
	{document.forms[0].fltArticuloFotolabPrecioRevelado.value=0;}	
	
if (document.forms[0].strArticuloClasificacionNombre.value=="" || document.forms[0].intClasificacionArticuloId.value=="")
	{alert('Favor de seleccionar una Clasificación de Artículo válida.');return false;}	
	
return true;
}

//-->
</script>
	</HEAD>
	<body onload="window_onload()">
		<form id="Form1" name="frmArticulo" action="about:blank" method="post">		
			<input type="hidden" value="<%=Request("prevAction")%>" name="prevAction">			
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
					<td class="tdtab" width="770">Está en : ADMIN : Catálogos : Artículos </td>
				</tr>
			</table>
			
			<table cellSpacing="0" cellPadding="0" width="780" border="0" >
				<tr>
					<td class="tdgeneralcontent">
						<h1>Consulta de Artículos</h1>
						<p>Seleccione un Artículo del listado para consultarlo.</p>	
						<!-- FILTROS -->
						<table cellSpacing="0" cellPadding="0"  border="0" >
						<tr><td  class="txtitintabla"><input  id="radFilter" type="radio"  name="radFilter" onclick="javascript:selectSearch()" checked>&nbsp;Por Artículo:&nbsp;</input><input class="field" id="strArticulos" type="text" maxLength="50" size="40" name="strArticulos" value="<%= Request("strArticulos") %>" onclick="javascript:selectSearch()" onkeydown="check_Enter(event)"></input></td></tr>																
						<tr><td  class="txtitintabla"><input  id="radFilter" type="radio"  name="radFilter" onclick="javascript:cleanSearch()">&nbsp;Todos</input></td></tr>																	
						<tr><td >&nbsp;&nbsp;&nbsp;&nbsp;<input class="boton" onclick="javascript:doSubmit('Buscar');" type="button" value="Buscar" name="btnBuscar"></td></tr>																	
						</table>
						<!-- terminan FILTROS -->
						<br>													
				<div id="divHtmlList" name="divHtmlList"></div>	
												
				<br><br>
		<div id="divEdicion" style="position:absolute; top:-800; left:-800">
				<table class=tdenvolventetablas cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="txtitintabla" Align="right" width="20%"><span class="tdtittablas3">Número de Articulo:</span></td>
					<td class="tdconttablas" Align="left" width="80%"><div id="divArticuloFotolabId"></div>	<input type=hidden value="" name=intArticuloFotolabId> 		</td> 
				</tr>	
				<tr>
					<td class="txtitintabla" Align="right" width="20%"><span class="tdtittablas3">Descripción:</span></td>
					<td class="tdconttablas" Align="left" width="80%"><div id="divArticuloDescripcion"></div></td>
				</tr>	
				<tr>
					<td class="txtitintabla" Align="right" width="20%"><span class="tdtittablas3">Código de Barras:</span></td>
					<td class="tdconttablas" Align="left" width="80%"><div id="divCodigoBarraArticuloValor"></td>
				</tr>						
				<tr>
					<td class="txtitintabla" Align="right" width="15%"><span class="tdtittablas3">Precio por Foto:</span></td>					
					<td class="tdconttablas" Align="left" width="85%">$<input class=field  type=text  size=20 name=fltArticuloFotolabPrecioFoto value=''></td>
				</tr>	
				<tr>
					<td class="txtitintabla" Align="right" width="15%"><span class="tdtittablas3">Precio por Revelado:</span></td>					
					<td class="tdconttablas" Align="left" width="85%">$<input class=field  type=text  size=20 name=fltArticuloFotolabPrecioRevelado value=''></td>
				</tr>	
					<tr>
					<td class="txtitintabla" Align="right" width="15%"><span class="tdtittablas3">Capturable en Orden en Proceso:</span></td>					
					<td class="tdconttablas" Align="left" width="85%">
					<input class=field  type=hidden name=blnArticuloFotolabPermitidoOrden value=''>
					<input class=field id=chkPermitidoOrden type=checkbox  onClick=cambiarPermitidoOrden() name=chkPermitidoOrden  >
					</td>
				</tr>	
				<tr>
					<td class="txtitintabla" Align="right" width="20%"><span class="tdtittablas3">Clasificación:</span>
					<td class="tdconttablas" Align="left" width="85%">
					<input class=field type=text maxLength=30 size=30 name=strArticuloClasificacionNombre value=''>&nbsp;<input type=hidden size=4 value="" name=intClasificacionArticuloId>
					<a href="javascript:openPopup('Listado de Clasificaciones','popupClasificacion',obtenerValorClasificacion(),'intClasificacionArticuloId','strArticuloClasificacionNombre','&intArticuloFotolabId='+document.forms[0].intArticuloFotolabId.value+'&intClasificacionArticuloId='+document.forms[0].intClasificacionArticuloId.value)"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Clasificaciones"></a></td>
				</tr>
				<tr>
					<td class="txtitintabla" Align="right" width="20%"><span class="tdtittablas3">Clasificación 2:</span>
					<td class="tdconttablas" Align="left" width="85%">
					<input class=field  type=text maxLength=30 size=30 name=strClasificacionArticulo2Nombre value=''>&nbsp;<input type=hidden size=4 value="" name=intClasificacionArticulo2Id>
					<a href="javascript:openPopup('Listado de Clasificaciones 2','popupClasificacionArticulo2','_','intClasificacionArticulo2Id','strClasificacionArticulo2Nombre','&intArticuloFotolabId='+document.forms[0].intArticuloFotolabId.value+'&intClasificacionArticulo2Id='+document.forms[0].intClasificacionArticulo2Id.value)"><img src="../static/images/icono_lupa.gif" width="17" height="17" border="0" align="middle" alt="Clasificaciones 2"></a></td>
				</tr>
				<tr>
				<td class="txtitintabla" style="WIDTH: 91px" vAlign="center">&nbsp;</td>
				<td class="txtitintabla" vAlign="center">
					<input class="boton" onclick="javascript:doSubmit('<%= Me._GUARDAR %>')" type="button" value="Guardar" name="btnGuardar">						
				</td>
				</tr>						
				</table>
			</div>
					</td>
				</tr>
			</table>
			
<input type="text" value="-1"  name="intfocus" style="position:absolute; left:-800px">
			
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaFooter()</script>
					</td>
				</tr>
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
