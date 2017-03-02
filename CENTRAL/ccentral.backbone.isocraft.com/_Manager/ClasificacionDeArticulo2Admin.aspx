<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ClasificacionDeArticulo2Admin.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsClasificacionDeArticulo2Admin" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides : Administrador del Sistema Concentrador (CTX)</TITLE>
<%
    '====================================================================
    ' Page          : ClasificacionDeArticulo.aspx
    ' Title         : Catálogo deClasificacionDeArticulo
    ' Description   : Catálogo de Clasificacion de Artículos
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Enrique Longoria
    ' Version       : 1.0
    ' Last Modified : Monday, January 31Th, 2005
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
<!--
	strUsuarioNombre = "<%= strUsuarioNombre %>";
	strFechaHora = "<%= strHTMLFechaHora %>";
	strSucursalNombre = "<%= strNombreSucursal %>";
	strSucursalId = "<%= strSucursalId%>";

if (parent.parent.document.getElementById('divHtmlList') != null){
<%= me.strActions(Request("strCmd"))%>		
<%Select Case Request("strCmd")%>
	<% Case Me._NUEVO %>			
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";	
		parent.parent.clearPage();
	<%Case Me._EDITAR%>		
		parent.parent.ponfocus();			
	<%Case Me._GUARDAR%>	
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";	
		parent.parent.clearPage();
	<%Case Me._BORRAR	%>		
		parent.parent.clearPage();
	<%Case Else%>
		<%= me.strActions(Request("strCmd"))%>
		parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";		
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
  document.forms[0].btnGuardar.focus();
	}

function cambiarActivo()
{
if (document.forms[0].chkActivo.checked == true)
{document.forms[0].blnClasificacionArticuloActivo.value="1";}
else
{document.forms[0].blnClasificacionArticuloActivo.value="0";}
}


function ponfocus()
{	
	document.forms[0].intfocus.focus();
}

function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];	
    //alert(action)
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{params+= "&" + args[i] + "=" + args[i+1]}
    document.forms[0].action = "ClasificacionDeArticulo2Admin.aspx?strCmd="+action+ params
    document.forms[0].target="ifrOculto";
    document.forms[0].submit();  
}

function cmdGuardar()
	{	
		
		if (validarCampos()==true)
		{
			if (document.forms[0].intClasificacionArticuloId.value == "" || document.forms[0].intClasificacionArticuloId.value == "0")
				{
				//en caso de que no se puedan agregar	
				//doSubmit("<%=Me._NUEVO%>");
				}			
			else
				{doSubmit("<%=Me._GUARDAR%>");}										
		}
	}


	function validarCampos()
	{
		var allValid = true;
		if(document.forms[0].strClasificacionArticuloNombre.value == "" || isNaN(document.forms[0].strClasificacionArticuloNombre.value)==false)
		{allValid=false;}		
		
		var checkOK = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzfSOZsozYAÁÂAÄAAÇEÉEËIÍÎIDNOÓÔOÖOUÚUÜÝ?ßaáâaäaaçeéeëiíîi?noóôoöouúuüý?y0123456789-";
		var checkStr = document.forms[0].strClasificacionArticuloNombre.value;

			for (i = 0;  i < checkStr.length;  i++)
			{
				ch = checkStr.charAt(i);
				for (j = 0;  j < checkOK.length;  j++)
				if (ch == checkOK.charAt(j))
					break;
				if (j == checkOK.length)
				{allValid = false;	break;}
			}
		if (allValid==false){alert("Favor de escribir un Nombre de Clasificación de Artículo válido.");
		document.forms[0].strClasificacionArticuloNombre.select();
		 return false;}
		 else {return true;}
	}
	
	
	function clearPage()
	{document.forms[0].reset();
	document.forms[0].intClasificacionArticuloId.value="";	
	}

//-->
		</script>
	</HEAD>
	<body onload="window_onload()">

	
		<form id="Form1" name="frmClasificacionArticulo" action="about:blank" method="post">
			<input type=hidden value="" name=intClasificacionArticuloId> 
			<input type=hidden value="0" name=blnClasificacionArticuloActivo> 			
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
					<td class="tdtab" width="770">Está en : ADMIN : Catálogos : Tipo de Artículo </td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Catálogo de Tipo de Artículo</h1>
						<p>Aquí podrá dar de alta o modificar las Tipo de Artículo. Capturar los datos y 
							seleccionar el botón "Aceptar" para registrar un  nuevo Tipo de Artículo.
						</p>
						<div id="divHtmlList" name="divHtmlList"><%= Me.strGenerarListado("")%></div>
						<br>
						<input class="boton" onclick="javascript:doSubmit('<%=Me._IMPRIMIR %>')" type="button" value="Impresión" name="btnImprimir">		
						<input class="boton" onclick="javascript:doSubmit('<%=Me._EXPORTAR %>')" type="button" value="Exportar" name="btnExportar">						
			
			<br><br>			
			<table class="tdenvolventetablas" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="txtitintabla" style=" HEIGHT: 28px" vAlign="center" align=right width="28%"><span class="tdtittablas3">Nombre:</span></td>
					<td class="txtitintabla" style="HEIGHT:28px" vAlign="center" Align="left" width=72%><input class=field id="strClasificacionArticuloNombre" type="text" maxLength="50" size="50" name="strClasificacionArticuloNombre" value=""></input></td>
					</td>
				</tr>
				<tr>
					<td class="txtitintabla"  vAlign="center" align=right><span class="tdtittablas3">Activo:</span></td>
					<td class=txtitintabla vAlign=center  Align="left"><input class=field id=chkActivo type=checkbox  onClick=cambiarActivo() name=chkActivo ></td>
				</tr>
				<tr>
					<td class="txtitintabla"  vAlign="center">&nbsp;</td>
					<td class="txtitintabla" vAlign="center">
						<input class="boton" onclick="javascript:cmdGuardar()" type="button" value="Aceptar" name="btnGuardar">												
						<span class="tdpadleft5"><input class="boton" onclick="javascript:clearPage()" type="button" value="Limpiar" name="cmdLimpiar">
						</span>
					</td>
				</tr>
			</table>
			
					</td>
				</tr>
			</table>
			<input type="text" value="-1"  name="intfocus" style="position:absolute; left:-800px">
	
	<table cellSpacing="0" cellPadding="0" width="780" border="0">
	<tr>	<td><script language="JavaScript">crearTablaFooter()</script></td></tr>
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
