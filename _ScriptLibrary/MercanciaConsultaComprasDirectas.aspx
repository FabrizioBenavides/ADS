<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConsultaComprasDirectas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaConsultaComprasDirectas" codePage="28592"%>
<HTML>
	<HEAD>
		<title>Sistema Administrador de Sucursal</title>
		<%
    '====================================================================
    ' Page          : MercanciaConsultaComprasDirectas.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para hacer consulta de las Compras Directas
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Sabado 25, 2003   
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
		<meta content="text/html; charset=iso-8859-2" http-equiv="Content-Type">
		<LINK rel="stylesheet" href="../static/css/menu.css">
			<LINK rel="stylesheet" href="../static/css/menu2.css">
				<LINK rel="stylesheet" href="../static/css/estilo.css">
					<script language="JavaScript" src="../static/scripts/menu.js"></script>
					<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
					<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
					<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
					<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
					<script language="JavaScript" src="../static/scripts/tools.js"></script>
					<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
					<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
					<script id="clientEventHandlersJS" language="JavaScript">
<!--

var strPaginaAyuda
strPaginaAyuda = "";

function window_onload() 
{   
   MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
   document.forms[0].action = "<%=strFormAction%>";
   
   var strMensaje = "<%=strMensaje%>";
   
   var rdoFiltroSeleccionado = "<%=rdoFiltroConsulta%>";
   var rdoOrdenSeleccionado = "<%=rdoOrdenConsulta%>";
   var cmbTipoCaptura = "<%=cmbTipoCaptura%>";
   
   var strRegistrosRecordBrowser = "<%=strRegistrosRecordBrowser%>";
   
   
   if (rdoFiltroSeleccionado == "1") {
     document.forms[0].elements['rdoFiltroConsulta1'].checked = true;     
   }
   if (rdoFiltroSeleccionado == "2") {
     document.forms[0].elements['rdoFiltroConsulta2'].checked = true;     
   }
   
   if (rdoOrdenSeleccionado == "1") {
     document.forms[0].elements['rdoOrdenConsulta1'].checked = true;     
   }   
   if (rdoOrdenSeleccionado == "2") {
     document.forms[0].elements['rdoOrdenConsulta2'].checked = true;     
   }
   if (rdoOrdenSeleccionado == "3") {
     document.forms[0].elements['rdoOrdenConsulta3'].checked = true;     
   }
   
	if( cmbTipoCaptura == "Manual" )
		document.getElementById( "cmbTipoCaptura" ).value = "Manual";
	
	else if( cmbTipoCaptura == "Confirmada" )
		document.getElementById( "cmbTipoCaptura" ).value = "Confirmada";
		
	else
		document.getElementById( "cmbTipoCaptura" ).value = "Todas";
   
   
   if (strMensaje.length > 0 ) {
       alert(strMensaje);
   }
   
   if (strRegistrosRecordBrowser.length > 0) 
   {   
       document.forms[0].elements['rdoFiltroConsulta1'].disabled = true;
       document.forms[0].elements['rdoFiltroConsulta2'].disabled = true;
       
       document.getElementById( "cmbTipoCaptura" ).disabled = true;
       
       document.forms[0].elements['cmdRegresar'].style.display  = 'none';
       document.forms[0].elements['cmdConsultar'].style.display = 'none';
       
   }   
   
}

function strCompaniaSucursal() {
	document.write(<%=intCompaniaId%> + " - " + <%=intSucursalId%>);
	return(true);
}
function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
function strUsuarioNombre() {
	document.write("<%=strUsuarioNombre%>");
	return(true);
}
function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}

function strRecordBrowserHTML(){  
     document.write("<%=strRecordBrowserHTML%>");   
}

function cmdRegresar_onclick() {
 document.location.href= "MercanciaEntradasComprasDirectas.aspx";
}

function rdoOrdenConsulta_onclick() {    
    var strRegistrosRecordBrowser = "<%=strRegistrosRecordBrowser%>";
    var rdoFiltroSeleccionado = "";
    var rdoOrdenSeleccionado  = "";
       
   if (document.forms[0].elements['rdoFiltroConsulta1'].checked==true) {
       rdoFiltroSeleccionado = "1";    
   }
   if (document.forms[0].elements['rdoFiltroConsulta2'].checked==true) {
       rdoFiltroSeleccionado = "2";    
   }
      
   if (document.forms[0].elements['rdoOrdenConsulta1'].checked == true) {
       rdoOrdenSeleccionado = "1";
   }
   if (document.forms[0].elements['rdoOrdenConsulta2'].checked == true) {
       rdoOrdenSeleccionado = "2";
   }
   if (document.forms[0].elements['rdoOrdenConsulta3'].checked == true) {
       rdoOrdenSeleccionado = "3";
   }
         
   if (strRegistrosRecordBrowser.length > 0) {   
	   document.forms[0].action = "<%=strFormAction%>" +"?cmdConsultar=Consultar&rdoFiltroConsulta="+rdoFiltroSeleccionado+"&rdoOrdenConsulta="+rdoOrdenSeleccionado;
	   document.forms[0].submit();
	}
}

function cmdOtra_onclick() {
   document.forms[0].elements['rdoFiltroConsulta1'].disabled=false;
   document.forms[0].elements['rdoFiltroConsulta2'].disabled=false;

   document.forms[0].elements['rdoFiltroConsulta1'].checked = false; 
   document.forms[0].elements['rdoFiltroConsulta2'].checked = false; 
   
   document.forms[0].elements['rdoOrdenConsulta1'].checked = false;     
   document.forms[0].elements['rdoOrdenConsulta2'].checked = false;     
   document.forms[0].elements['rdoOrdenConsulta3'].checked = false;     
   document.forms[0].action = "<%=strFormAction%>";
   
   document.forms[0].submit();      
}

function cmdImprimir_onclick() {
   printContent();
   return(true);
}

function frmMercanciaConsultaComprasDirectas_onsubmit() 
{
	var regreso = true;

	var rdoFiltroSeleccionado = "";
	var rdoOrdenSeleccionado  = "";
	
	var cmbTipoCaptura = document.getElementById ( "cmbTipoCaptura" ).value;
        
	if (document.forms[0].elements['rdoFiltroConsulta1'].checked==true) {
		rdoFiltroSeleccionado = "1";    
	}
	
	if (document.forms[0].elements['rdoFiltroConsulta2'].checked==true) {
		rdoFiltroSeleccionado = "2";    
	}
      
	if (document.forms[0].elements['rdoOrdenConsulta1'].checked == true) {
		rdoOrdenSeleccionado = "1";
	}
	
	if (document.forms[0].elements['rdoOrdenConsulta2'].checked == true) {
		rdoOrdenSeleccionado = "2";
	}
   
	if (document.forms[0].elements['rdoOrdenConsulta3'].checked == true) {
		rdoOrdenSeleccionado = "3";
	}

   
	if (rdoFiltroSeleccionado == "") {
		alert("Seleccionar algun criterio para la consulta");
		regreso = false;
	}
	
	if (regreso) 
	{
       if (rdoOrdenSeleccionado == "" ) 
       {
           alert("Seleccionar algun orden para la consulta");
           regreso = false;
       }
	}  
   
	document.forms[0].action = "<%=strFormAction%>" 
							 + "?cmdConsultar=Consultar" 
							 + "&rdoFiltroConsulta="
							 + rdoFiltroSeleccionado 
							 + "&rdoOrdenConsulta="
							 + rdoOrdenSeleccionado
							 + "&cmbTipoCaptura="
							 + cmbTipoCaptura;
   
	return(regreso);
}



//-->
					</script>
	</HEAD>
	<body onload="return window_onload()" leftMargin="0" topMargin="0" marginwidth="0" marginheight="0">
		<form onsubmit="return frmMercanciaConsultaComprasDirectas_onsubmit()" method="post" name="frmMercanciaConsultaComprasDirectas"
			action="about:blank">
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td height="98" vAlign="top" width="100%">
						<script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
				<tr>
					<td height="34" vAlign="top" width="100%"><IMG src="../static/images/pixel.gif" width="1" height="34"></td>
				</tr>
				<tr>
					<td width="100%">
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td bgColor="#ffffff" width="10"><IMG src="../static/images/pixel.gif" width="10" height="8"></td>
								<td class="tdmigaja" width="583">
									<div id="ToPrintTxtMigaja"><span class="txdmigaja">Está en : </span><A class="txdmigaja" href="Mercancia.aspx">Mercancía</A><span class="txdmigaja"> : <A class="txdmigaja" href="MercanciaEntradas.aspx">Entradas</A></span><span class="txdmigaja"> : </span><span class="txdmigaja"></span><span class="txdmigaja"><A class="txdmigaja" href="MercanciaEntradasComprasDirectas.aspx">Compras 
												directas </A>
										</span><span class="txdmigaja">: </span><span class="txdmigaja"></span><span class="txdmigaja"></span><span class="txdmigaja"></span><span class="txdmigaja">Consultar registro de compras 
            directas</span></div>
								</td>
								<td class="tdfechahora" width="182">
									<script language="javascript">strGetCustomDateTime()</script>
								</td>
							</tr>
							<tr>
								<td width="10">&nbsp;</td>
								<td vAlign="top" width="583">
									<table border="0" cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td class="tdtablacont" vAlign="top" width="100%" colSpan="3">
												<p><span class="txtitulo">Consultar registro de compras 
                  directas</span><span class="txcontenido">Utilice los filtros siguientes para 
                  configurar la consulta en el archivo, y luego oprima 
                  "Consultar".</span>
													<script language="JavaScript">crearDatosSucursal()</script>
												</p>
												
												<table border="0" cellSpacing="0" cellPadding="0" width="100%">
													<tr>
														<td class="tdtittablas" width="159">Rango de consulta:
														</td>
														<td class="tdconttablas" vAlign="middle" width="252">
															<table border="0" cellSpacing="0" cellPadding="0" width="100%">
																<tr>
																	<td class="tdconttablas" width="206"><input id="rdoFiltroConsulta1" value="1" type="radio" name="rdoFiltroConsulta">
																		Mes actual
																	</td>
																	<td class="tdconttablas" width="50%"><input style="Z-INDEX: 0" id="rdoFiltroConsulta2" value="2" type="radio" name="rdoFiltroConsulta">
																		Mes anterior
																	</td>
																</tr>
															</table>
														</td>
													</tr>
													
													<tr>
														<td class="tdtittablas" width="100">
															&nbsp;
														</td>
														
														<td class="tdconttablas" vAlign="middle" width="251">
														</td>
													</tr>
													
													<tr>
														<td class="tdtittablas" width="100">Ordenar por:
														</td>
														
														<td class="tdconttablas" vAlign="middle" width="251">
															
															<input	id="rdoOrdenConsulta1" 
																	onclick="return rdoOrdenConsulta_onclick()" 
																	value="1" 
																	type="radio"
																	name="rdoOrdenConsulta"> 
																	
																Nota de entrada															
														</td>
														
														<td>
														</td>
														
													</tr>
													
													<tr>
														<td class="tdtittablas" width="100">
															&nbsp;
														</td>
														
														<td class="tdconttablas" vAlign="middle" width="251">
															<input	id="rdoOrdenConsulta2" 
																	onclick="return rdoOrdenConsulta_onclick()" 
																	value="2" 
																	type="radio"
																	name="rdoOrdenConsulta"> 
																	
															Número de proveedor
														</td>
														
														<td>
														</td>
														
													</tr>
													
													<tr>
														<td class="tdtittablas" width="100">&nbsp;
														</td>
														
														<td class="tdconttablas" vAlign="middle" width="251">
															<input	id="rdoOrdenConsulta3" 
																	onclick="return rdoOrdenConsulta_onclick()" 
																	value="3" 
																	type="radio"
																	name="rdoOrdenConsulta"> 
															
															Fecha Recepción factura
														</td>
														
														<td>
														</td>
														
													</tr>

													<tr>
														<td class="tdtittablas" width="100">
															&nbsp;
														</td>
														
														<td class="tdconttablas" vAlign="middle" width="251">
														</td>
													</tr>
													
													<tr>
														<td class="tdtittablas" width="100">
															Tipo de Capturas: 
														</td>
														
														<td class="tdconttablas" vAlign="middle" width="251">
														
															<select id="cmbTipoCaptura" style="Z-INDEX: 0">
															
																<OPTION value="Todas" selected>
																	Todas
																</OPTION>
																
																<OPTION value="Manual">
																	Manuales
																</OPTION>
																
																<OPTION value="Confirmada">
																	Confirmadas
																</OPTION>
																
															</select>															
															
														</td>
														
														<td>
														</td>
														
													</tr>

													<tr>
														<td class="tdtittablas" width="100">
															&nbsp;
														</td>
														
														<td class="tdconttablas" vAlign="middle" width="251">
														</td>
													</tr>
																																																				
													<tr>
														<td class="tdtittablas" width="159">&nbsp; <input class="boton" onclick="return cmdRegresar_onclick()" value="Regresar" type="button"
																name="cmdRegresar"> &nbsp; <input class="boton" value="Consultar" type="submit" name="cmdConsultar">
														</td>
													</tr>
													
												</table>
												
												<script language="javascript">
													strRecordBrowserHTML()
												</script>
												
												<br>
											</td>
										</tr>
									</table>
								</td>
								
								<td class="tdcolumnader" vAlign="top" rowSpan="2" width="182">
									&nbsp;
								</td>
							</tr>
							
							<tr>
								<td class="tdbottom" colSpan="2">
									<script language="JavaScript">
										crearTablaFooter()
									</script>
								</td>
							</tr>
							
						</table>
					</td>
				</tr>
			</table>
			
			<script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
			</script>
		</form>
		<iframe height="0" src="../static/PageToPrint.htm" width="0" name="ifrPageToPrint"></iframe>
	</body>
</HTML>
