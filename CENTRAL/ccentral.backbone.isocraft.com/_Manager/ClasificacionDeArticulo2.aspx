<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ClasificacionDeArticulo2.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsClasificacionDeArticulo2" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides : Sistema Administrador de Puntos de Venta</TITLE>
<%
    '====================================================================
    ' Page          : ClasificacionDeArticuloDetalle.aspx
    ' Title         : Catálogo deClasificacionDeArticuloDetalle
    ' Description   : Catálogo de Clasificacion de Artículos Detalle
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.' Author        :Jorge Ventura Cantu Campos
    ' Version       : 1.0
    ' Last Modified : Friday, February 11Th, 2005
    '====================================================================
%>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="css/menu.css" type="text/css" rel="stylesheet">
		<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/menu_Far.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
		<script language="JavaScript" src="js/FotoLabUtils.js" type="text/JavaScript"></script>		
		<script language="javascript" id="clientEventHandlersJS">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
strSucursalNombre = "<%= strNombreSucursal %>";
strSucursalId = "<%= strSucursalId%>";

if (parent.parent.document.getElementById('divHtmlList') != null){
<%= me.strActions(Request("strCmd"))%>		
<%Select Case Request("strCmd")%>
	<% Case Me._NUEVO %>			
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";	
		parent.parent.document.forms[0].reset();
	<%Case Me._EDITAR%>	
	parent.parent.document.getElementById('divEdicion').style.position='static';
	parent.parent.ponfocus();	
	<%Case Me._GUARDAR%>	
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";	
		parent.parent.document.forms[0].reset();
	<%Case Me._BORRAR	%>		
		parent.parent.document.forms[0].reset();
	<%Case Else%>
		<%= me.strActions(Request("strCmd"))%>
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";		
		parent.parent.document.getElementById('divEdicion').style.position='absolute';	
	<%End Select%>
	} 

//-->
</script>	

<%if Request("strCmd") ="" then %>	
<script language="javascript" id="MarcaRolloJS">
<!--

	
	function window_onload() {
	<% if CStr(Request("strCmd")) = "Imprimir" then  %>
		printDocument()
	<% end if   %>
	document.forms[0].action = "<%= strThisPageName %>";
	//document.forms[0].strMarcaRolloNombre.select();	
	}

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{params+= "&" + args[i] + "=" + args[i+1]}
    document.forms[0].action = "ClasificacionDeArticulo2.aspx?strCmd=" + action + params
document.forms[0].target="ifrOculto";
    document.forms[0].submit();  
}

function ponfocus()
{	
	document.forms[0].intfocus.focus();
}

function showError(msg)
{	alert (msg);   }

//-->
		</script>
	</HEAD>
	<body onload="window_onload()">
		<form id="Form1" name="frmClasificacionArticulo" action="about:blank" method="post">
			<input type=hidden value="<%= intClasificacionArticuloId %>" name=intClasificacionArticuloId> 
			<input type=hidden value="<%= intActivo %>" name=blnClasificacionArticuloActivo> 
			<input type=hidden value="" name="strCmd"> 
			<input type=hidden value="" name=intNavegadorRegistrosPagina> 	

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
					<td class="tdtab" width="770">Está en : FARMACIA : Catálogos : Clasificación de Artículos </td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Consulta Clasificación de Artículos</h1>
						<p>Seleccione una Clasificación de Artículos del listado para consultarla.
						</p>
			<div id="divHtmlList" name="divHtmlList"><%= Me.strGenerarListado("")%></div>
						<br>					
						<input class="boton" onclick="javascript:doSubmit('<%=Me._IMPRIMIR %>')" type="button" value="Impresión" name="btnImprimir">		
						<input class="boton" onclick="javascript:doSubmit('<%=Me._EXPORTAR %>')" type="button" value="Exportar" name="btnExportar">	
					<br>	
					<br>
					<div id="divEdicion" style="position:absolute; top:-800; left:-800">
					<table class="tdenvolventetablas" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td class="txtitintabla"  vAlign="center"  Align="right" width="15%"><span class="tdtittablas3">No. Clasificación:</span></td>
							<td class=tdconttablas Align="left" width="85%"><div id="divClasificacionId"></div></td>
						</tr>
						<tr>
							<td class="txtitintabla"  vAlign="center" Align="right" width="15%"><span class="tdtittablas3">Nombre:</span></td>
							<td class=tdconttablas Align="left" width="85%"><div id="divClasificacionNombre"></div></td>
						</tr>
						<tr>
							<td class="txtitintabla" vAlign="center" Align="right" width="15%"><span class="tdtittablas3">Activo:</span></td>			
							<td class=tdconttablas Align="left" width="85%"><div id="divClasificacionActivo"></div></td>
						</tr>	
					</table>
					</div>
					</td>
				</tr>
			</table>

<input type="text" value="-1"  name="intfocus" style="position:absolute; left:-800px" >

		<table cellSpacing="0" cellPadding="0" width="780" border="0">
			<tr>
				<td><script language="JavaScript">crearTablaFooter()</script></td>
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
