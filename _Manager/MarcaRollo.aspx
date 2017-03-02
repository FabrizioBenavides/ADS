<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MarcaRollo.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMarcaRollo" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides : Administrador del Sistema Concentrador (CTX)</TITLE>
<%
    '====================================================================
    ' Page          : MarcaRollo.aspx
    ' Title         : Catálogo de Marcas de Rollos
    ' Description   : Catálogo de Marcas de Rollos
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Enrique Longoria
    ' Version       : 1.0
    ' Last Modified : Monday, Feb 1st, 2005
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
<script language="javascript" id="AuxMarcaRolloJS">
<!--
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
strSucursalNombre = "<%= strNombreSucursal %>";
strSucursalId = "<%= strSucursalId%>";

if (parent.parent.document.getElementById('divHtmlList') != null)
{
		<%= me.strActions(Request("strCmd"))%>		
		<%Select Case Request("strCmd")%>
		<% Case Me._NUEVO %>
			parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";
			parent.parent.document.forms[0].reset();
		<%Case Me._EDITAR%>	
			parent.parent.ponfocus();		
		<%Case Me._GUARDAR%>
			parent.parent.document.getElementById('divHtmlList').innerHTML="<%= me.strGenerarListado("")%>";				
			parent.parent.document.forms[0].reset();
		<%Case Me._BORRAR	%>		
			parent.parent.document.forms[0].reset();			
		<%Case Else%>
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
	document.forms[0].btnGuardar.focus()
	document.forms[0].strMarcaRolloNombre.select();	
	}
function doSubmit()
	{  	
		args = doSubmit.arguments;
		var action = args[0];		
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{params+= "&" + args[i] + "=" + args[i+1]}	
	 document.forms[0].action = "<%= strThisPageName %>?strCmd=" + action + params    
	    document.forms[0].target="ifrOculto";	
		document.forms[0].submit();
		document.forms[0].intMarcaRolloId.value="";
	}	
function cmdGuardar()
	{	
		if (validarCampos()==true)
		{//alert(document.forms[0].intMarcaRolloId.value)
			if (document.forms[0].intMarcaRolloId.value == "" || document.forms[0].intMarcaRolloId.value == "0")
				{doSubmit("<%=Me._NUEVO%>");}				
			else
			 {doSubmit("<%=Me._GUARDAR%>");}										
		}
	}

function ponfocus()
{	
	document.forms[0].intfocus.focus();
}

function cambiarActivo()
	{ if (document.forms[0].chkActivo.checked == true)
		{document.forms[0].blnMarcaRolloActivo.value="1";}
		else
		{document.forms[0].blnMarcaRolloActivo.value="0";}
	}
	
	function validarCampos()
	{
		var allValid = true;
		if(document.forms[0].strMarcaRolloNombre.value == "" || isNaN(document.forms[0].strMarcaRolloNombre.value)==false)
		{allValid=false;}		
		
		var checkOK = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzfSOZsozYAÁÂAÄAAÇEÉEËIÍÎIDNOÓÔOÖOUÚUÜÝ?ßaáâaäaaçeéeëiíîi?noóôoöouúuüý?y0123456789-";
		var checkStr = document.forms[0].strMarcaRolloNombre.value;

			for (i = 0;  i < checkStr.length;  i++)
			{
				ch = checkStr.charAt(i);
				for (j = 0;  j < checkOK.length;  j++)
				if (ch == checkOK.charAt(j))
					break;
				if (j == checkOK.length)
				{allValid = false;	break;}
			}
		if (allValid==false){alert("Favor de escribir un Nombre de Marca de Rollo válido."); 
		document.forms[0].strMarcaRolloNombre.select();
		return false;}
		else {return true;}
	}
	
	function clearPage()
	{document.forms[0].reset();	}
		
//-->
</script>	

	</HEAD>
	<body onload="javascript:window_onload()">
		<form id="frmMarcaRollo" name="frmMarcaRollo" action="about:blank" method="post">
			<input type="hidden" value="0" name="documentPrinted">
			<input type="hidden" value="0" name="documentExported">		
			<input type=hidden value="" name=intMarcaRolloId> 
			<input type=hidden value="0" name=blnMarcaRolloActivo> 
			<input type=hidden value="" name="strCmd"> 
			<input type=hidden value="" name=intNavegadorRegistrosPagina> 			
			<input type="hidden" value="0" name="documentPrinted">
			<input type="hidden" value="0" name="documentExported">
			
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
		<tr><td><script language="JavaScript">crearTablaHeader()</script>	</td></tr>
		</table>
				
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
		<tr><td width="10">&nbsp;</td><td class="tdtab" width="770">Está en : ADMIN : Catálogos : Marcas de Rollos</td></tr>
		</table>
				
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
		<tr><td class="tdgeneralcontent">
		<h1>Capturar Marcas de Rollos</h1>
		<p>Aquí podrá dar de alta o modificar las Marcas de Rollos. Capturar los datos y 
		seleccionar el botón "Agregar" para registrar un nuevo tipo de rollo.</p>
		<div id="divHtmlList" name="divHtmlList"><%= Me.strGenerarListado("")%></div>		
		<br>
		<input class="boton" onclick="javascript:doSubmit('<%=Me._IMPRIMIR %>')" type="button" value="Impresión" name="btnImprimir">		
		<input class="boton" onclick="javascript:doSubmit('<%=Me._EXPORTAR %>')" type="button" value="Exportar" name="btnExportar">					
		<br><br>
			<div id="divEdicion">
		<table class=tdenvolventetablas cellSpacing=0 cellPadding=0 width=100% border=0>
		<tr>
		<td class=txtitintabla style="WIDTH:91px; HEIGHT:28px" vAlign=center Align="right" width=20%>	<span class=tdtittablas3>Nombre:</span></td>
		<td class=txtitintabla style=HEIGHT:28px vAlign=center Align="left" width=80%><input class=field id=strMarcaRolloNombre type=text maxLength=50 size=50 name=strMarcaRolloNombre value=''></input></td>
		</tr>
		<tr>
		<td class=txtitintabla style=WIDTH:91px vAlign=center width=20% Align="right"><span class=tdtittablas3>Activo:</span></td>
		<td class=txtitintabla vAlign=center width=80% Align="left">
		<input class=field id=chkActivo type=checkbox  onClick=cambiarActivo() name=chkActivo  ></td>
		</tr>
		<tr>
		<td class=txtitintabla style=WIDTH:91px vAlign=center>&nbsp;</td><td class=txtitintabla vAlign=center>
		<input class=boton onclick=cmdGuardar() type=button value=Aceptar name=btnGuardar>
		<span class=tdpadleft5>
		<input class=boton onclick=javascript:clearPage() type=button value=Limpiar name=btnLimpiar></span></td>
		</tr>
		</table>
		</div>	
		</td></tr>
		</table>
		<input type="text" value="-1"  name="intfocus" style="position:absolute; left:-800px">
	
		<table cellSpacing="0" cellPadding="0" width="780" border="0">
		<tr><td><script language="JavaScript">crearTablaFooter()</script></td></tr>
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
