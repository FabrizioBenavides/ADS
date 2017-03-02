<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ReasignarLaboratorioAOrden.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsReasignarLaboratorioAOrden" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="true" enableViewState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Benavides : Administrador del Sistema Concentrador (CTX)</TITLE>
		<%
    '====================================================================
    ' Page          : ReasignarLaboratorioAOrden.aspx
    ' Title         : Reasignar Laboratorio a Ordenes
    ' Description   : Reasignar Laboratorio a Ordenes
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Carolina Caballero
    ' Version       : 1.0
    ' Last Modified : Thursday, October 20, 2005
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

//aqui debo de cambiar divH
//if ((parent.parent.document.getElementById('divHtmlList') != null) || (parent.parent.document.getElementById('divHtmlList1') != null)){
if ( (parent.parent.document.getElementById('divLaboratorioSelec') != null) || (parent.parent.document.getElementById('divOrdenesSelec') != null) ){
<%= me.strActions(Request("strCmd"))%>	
<%Select Case Request("strCmd")%>	
	<%Case "BuscarLaboratorio"	%>
			parent.parent.document.getElementById('divLaboratorioSelec').innerHTML="<%= me.strBuscarLaboratorio() %>";
			if (parent.parent.document.getElementById('divLaboratorioSelec').innerHTML == "")
			{	
				alert ("El Laboratorio no existe" );
				parent.parent.document.forms[0].strNumeroLaboratorio.value = "";
				parent.parent.document.forms[0].strNumeroLaboratorio.focus();
			}
			else
			{
				parent.parent.mostrarDiv('divLaboratorioSelec',true);	
				parent.parent.mostrarDiv('divTituloLaboratorio',true);	
				parent.parent.mostrarDiv('divBuscarOrdenes',true);	
				parent.parent.mostrarDiv('divBotonRegresar',true);
				parent.parent.mostrarDiv('divBuscarLaboratorio',false);	
				parent.parent.document.forms[0].strNumeroOrden.focus();
			}			
	
	<%Case "BuscarOrden" %>
			parent.parent.document.getElementById('divOrdenesSelec').innerHTML="<%= me.strBuscarOrden() %>";
			parent.parent.mostrarDiv('divOrdenesSelec',true);
			parent.parent.mostrarDiv('divBotonAsignarTodos',true);
			parent.parent.mostrarDiv('divBotonRegresar',true);
			parent.parent.document.forms[0].btnAsignarTodos.focus();
			parent.parent.document.forms[0].strNumeroOrden.value = "";
			parent.parent.document.forms[0].strNumeroOrden.focus();
			
		
	<%Case "ReasignarOrdenIndividual" %>		
		parent.parent.document.getElementById('divOrdenesSelec').innerHTML="<%= me.strBuscarOrden() %>";
		//parent.parent.mostrarDiv('divBotonAsignarTodos',false);	
		newWindow('Mensaje.aspx?strmensaje=Operación%20Exitosa',500,152)
	
	<%Case "ReasignarTodos" %>
		parent.parent.document.getElementById('divOrdenesSelec').innerHTML="<%= me.strBuscarOrden() %>";
		parent.parent.mostrarDiv('divBotonAsignarTodos',false);	
		newWindow('Mensaje.aspx?strmensaje=Operación%20Exitosa',500,152)
			
	<%Case "Regresar"	%>
		
		parent.parent.mostrarDiv('divTituloLaboratorio',false);		
		parent.parent.mostrarDiv('divBotonAsignarTodos',false);
		parent.parent.mostrarDiv('divBotonDesasignarTodos',false);
		parent.parent.mostrarDiv('divLaboratorioSelec',false);		
		parent.parent.mostrarDiv('divOrdenesSelec',false);	
		parent.parent.mostrarDiv('divPrincipalTexto',true);	
		parent.parent.mostrarDiv('divBotonBuscarClientes',false);
		parent.parent.mostrarDiv('divBotonRegresar',false);
		parent.parent.limpiarcampos();


	<%End Select %>
	} 
//-->
</script>	

<%if Request("strCmd") ="" then %>	
<script language="javascript" id="MarcaRolloJS">
<!--

function window_onload() 
{  
 document.forms[0].action = "<%= strThisPageName %>";
 document.forms[0].strNumeroLaboratorio.focus();	
}



function mostrarDiv(divNombre,blnMostrar)		//ok
{	
	var divObj=eval('document.getElementById("'+divNombre+'")');
	if (!blnMostrar)
	{
		divObj.style.position='absolute';				
		divObj.style.top='-800';				
		divObj.style.left='-800';	
	}
	else
	{	divObj.style.position='static';   }
}

function limpiarcampos()	//OK
{	
	document.forms[0].strNumeroLaboratorio.value="";
	document.forms[0].strNumeroOrden.value="";
	
	document.forms[0].strNumeroLaboratorio.focus();	//checar aqui
}

function check_Enter(e, fildselected)		//OK
{	var key;		
	if(window.event) // for IE
		{key = e.keyCode; }
	else if(e.which) // for Netscape-Firefox
		{key = e.which; }
	else 
		{return true;}			
	if (key==13)	
	{
		switch (fildselected)
		{
		case 1:
			//buscar laboratorio por numero de laboratorio
			doSubmit ('BuscarLaboratorio');
			break;
		case 2:
			//buscar numero de orden
			doSubmit ('BuscarOrden');
			break;
		}
	}
}

function doReturn()
{
	window.location.href ="ReasignarLaboratorioAOrden.aspx";
}

function doSubmit()	//ok
{
    args = doSubmit.arguments;
    var action = args[0];
    var isOk=1;
    
    if (action == 'BuscarLaboratorio')
    {
		//validar el numero de laboratorio
		if (document.forms[0].strNumeroLaboratorio.value == "")
		{	alert ("Teclee el número de Laboratorio por favor.");
			isOk=0;	
		}
		else 
		{
			var x = parseInt (document.forms[0].strNumeroLaboratorio.value)
			if (isNaN (x) )
			{   alert ("Teclee un número de Laboratorio válido por favor.");
				document.forms[0].strNumeroLaboratorio.value="";
				document.forms[0].strNumeroLaboratorio.focus();
				isOk=0;
			}
		}
    }
    else if (action == 'BuscarOrden')
    {	//agregar el nuevo # de orden al conjunto de # de ordenes
		
		//TODO FALTA VALIDAR EL strOrden
		if (document.forms[0].strNumeroOrden.value == "")
		{	alert ("Teclee el número de Orden por favor.");
			isOk=0;	
		}
		else 
		{
			var x = parseInt (document.forms[0].strNumeroOrden.value)			
			if (isNaN (x) || (x != document.forms[0].strNumeroOrden.value) )
			{   alert ("Teclee un número de Orden válido por favor.");
				document.forms[0].strNumeroOrden.value="";
				document.forms[0].strNumeroOrden.focus();			
				isOk=0;
			}
		}
				
		if (isOk == 1)
		{
			if (document.forms[0].strOrdenesIds.value == "")
				document.forms[0].strOrdenesIds.value = "''"+document.forms[0].strNumeroOrden.value+"''";
			else
				document.forms[0].strOrdenesIds.value += ",''"+document.forms[0].strNumeroOrden.value+"''";		
		}
    }
    else if (action == 'ReasignarOrdenIndividual')
    {	
		if (!confirm('¿Esta seguro que desea realizar la asignación?')  )
		{  isOk=0;  }    
    }
    else if (action == 'ReasignarTodos')
    {
		if (! confirm('¿Esta seguro que desea realizar la asignación?')  )
		{  isOk=0;  }
    }

	
	if (isOk==1)
	{
		document.forms[0].mostrar.value='si';
		var params = ""
		for (i=1; i < (args.length-1); i +=2)
		{  params+= "&" + args[i] + "=" + args[i+1]  }			
		document.forms[0].action = "<%= strThisPageName %>?strCmd=" + action + params    	
		document.forms[0].target="ifrOculto";	
		document.forms[0].submit();  
	}
}


//-->
</script>
	</HEAD>
	<body onload="window_onload()">
		<form id="Form1" name="frmLaboratorioAOrden" action="about:blank" method="post">	
			<input type=hidden value="" name="strOrdenesIds">
			<input type=hidden value="<%= strbotones %>" name=strbotones>
			<input type=hidden value="<%= Request("mostrar") %>" name=mostrar>	
				
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>	<td><script language="JavaScript">crearTablaHeader()</script></td></tr>
			</table>
				<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtab" width="770">Está en : ADMIN : Ordenes : Reasignar Laboratorio</td>
				</tr>
			</table>			
			<table cellSpacing="0" cellPadding="0" width="780" border="0" >
				<tr>
					<td class="tdgeneralcontent">
						<div id="divPrincipalTexto"style="position:static">
							<h1>Reasignación de Laboratorio a Ordenes </h1>
							<p>Busque el laboratorio para reasignarle las ordenes que se requieran. Despues busque las ordenes que se les requiera reasignar el Laboratorio.<br></p>	
						</div>
						<div id="divAsignacionTexto" style="position:absolute; top:-800; left:-800">
							<h1>Asignación de Farmacias a Laboratorios</h1>
							<p>Despues de seleccionar el Laboratorio, busque las Ordenes. Para reasignar el Laboratorio a una sola orden hacer click sobre el icono correspondiente, para reasignar a todos hacer click sobre el botón "Reasignar Todos".<br></p>	
						</div>
	
						<!-- BUSCAR LABORATORIO -->
						<div id="divBuscarLaboratorio">
						<br><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">  Búsqueda de Laboratorio </span>
							<table cellSpacing="0" cellPadding="0"  border="0" >																
							  <tr>
							    <td class="txtitintabla" align=right>Número de Laboratorio:&nbsp;</td>
								<td>
								  <input type="text" class="field" name="strNumeroLaboratorio"  value="<%=me.strNumeroLaboratorio()%>" size="40"  onkeydown="check_Enter(event, 1)">
								  <input class="boton" onclick="javascript:doSubmit('BuscarLaboratorio')" type="button" value="Buscar Laboratorio" name="btnBuscarLaboratorio">
								</td>
							   </tr>																																					
							</table>
						</div>
						<!-- TERMINA BUSCAR LABORATORIO -->
						<br>
						
						<div id=divTituloLaboratorio name=divTituloLaboratorio style="position:absolute; top:-800; left:-800"><p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> Laboratorio al que se le reasignarán Ordenes </span> </p></div>
						<div id=divLaboratorioSelec name=divLaboratorioSelec style="position:absolute; top:-800; left:-800"></div>
						
						
						<!--div id=divEncabezadoLista name=divEncabezadoLista style="position:absolute; top:-800; left:-800"></div>
						<div id=divHtmlList name=divHtmlList ></div>
						<div id=divEncabezadoDetalle name=divEncabezadoDetalle style="position:absolute; top:-800; left:-800"></div-->

						<!-- BUSCAR ORDENES -->
						<div id=divBuscarOrdenes name=divBuscarOrdenes style="position:absolute; top:-800; left:-800">
							<br/>
						    <p><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> Búsqueda de Ordenes a Reasignar </span> </p>						    
							<table  cellSpacing="0" cellPadding="0"  border="0" >
							  <tr>
								<td class="txtitintabla" align=right>Número de Orden:&nbsp;</td>
								<td>
								  <input type="text" class="field" name="strNumeroOrden"  value="" size="40" onkeydown="check_Enter(event, 2)">
								  <input class="boton" onclick="javascript:doSubmit('BuscarOrden')" type="button" value="Buscar Orden" name="btnBuscarOrden">
								</td>
							  </tr>
							</table>
						</div>
						<!-- TERMINA BUSCAR ORDENES -->		
							
						<!-- LISTADO DE ORDENES A REASIGNAR -->
						<br>
							<!--div id=divEncabezadoListaDetalle name=divEncabezadoListaDetalle style="position:absolute; top:-800; left:-800"></div -->
							<div id=divOrdenesSelec name=divOrdenesSelec >														
								<tr>
								<table cellSpacing="0" cellPadding="0"  border="0" >	
								  <tr>
									<td align = left>									
									  <div id=divBotonAsignarTodos name=divBotonAsignarTodos  style="position:absolute; top:-800; left:-800"><input class="boton" onclick="javascript:doSubmit('ReasignarTodos')" type="button" value="Asignar Todos" name="btnAsignarTodos"></div>										
									</td>
									<td>
										<div id=divBotonRegresar name=divBotonRegresar style="position:absolute; top:-800; left:-800"><input class="boton" onclick="javascript:doReturn()" type="button" value="Regresar" name="btnRegresar"></div>
									</td>
								</tr>
								</table>
							</div>	
						<!-- TERMINA LISTADO DE ORDENES A REASIGNAR -->
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
