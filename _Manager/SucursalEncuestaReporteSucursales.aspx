<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEncuestaReporteSucursales.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEncuestaReporteSucursales"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="css/menu.css" type="text/css" rel="stylesheet">
			<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
				<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/calendario.js"></script>
				<script language="JavaScript" src="js/cal_format00.js"></script>
				<script language="javascript" id="clientEventHandlersJS">
<!--


strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";
function LTrim(s){
	// Devuelve una cadena sin los espacios del principio
	var i=0;
	var j=0;
	var intCaracter=0;
	
	// Busca el primer caracter <> de un espacio
	for(i=0; i<=s.length-1; i++)
		if(s.substring(i,i+1) != ' '){
			j=i;
			intCaracter=1;
			break;
		}
		
		if (intCaracter==0) {
		   return "";    
		}
		else {
	       return s.substring(j, s.length);
	    }
}

function RTrim(s){
	// Quita los espacios en blanco del final de la cadena
	var j=0;
	var intCaracter=0;
	
	// Busca el último caracter <> de un espacio
	for(var i=s.length-1; i>-1; i--)
		if(s.substring(i,i+1) != ' '){		
			j=i;
			intCaracter=1;
			break;
		}
				
		if (intCaracter==0) {
		    return "";
		}
		else {
		     return s.substring(0, j+1);
		}
}
function Pop(url, width, height) {
   var Win = window.open(url,'Pop','width=' + width + ',height=' + height + ',left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no' );
       
   return(false);
}

function Trim(s){
	// Quita los espacios del principio y del final
	return LTrim(RTrim(s));
}

function window_onload() {
   document.forms[0].action = "<%= strFormAction %>";   
   document.forms[0].elements['txtEncuestaNombre'].value = "<%=Request.Form("txtEncuestaNombre")%>";
   
   var intDireccionId = "<%= intDireccionId %>";
   var intZonaId = "<%= intZonaId %>";
   var strSucursalId = "<%= strSucursalId %>";
   
   var intCompaniaid ="<%=intCompaniaid%>";
   var intSucursalid = "<%=intSucursalid%>";
   
     
   document.forms[0].elements["txtEncuestaInicio"].value = "<%= strEncuestaInicio %>";
   document.forms[0].elements["txtEncuestaFin"].value = "<%= strEncuestaFin %>";
     
   if (intDireccionId == "-1") {
       document.forms[0].elements["cboDireccion"].options[1].selected = true;
       document.forms[0].elements["cboZona"].disabled = true;
       document.forms[0].elements["cboSucursal"].disabled = true;
   }
     
   if (intZonaId == "-1") {
       document.forms[0].elements["cboZona"].options[1].selected = true;
       document.forms[0].elements["cboSucursal"].disabled = true;
   }
     
   if (strSucursalId == "-1") {
       document.forms[0].elements["cboSucursal"].options[1].selected = true;
   }
     
   <%= strLlenarDireccionComboBox() %>
   <%= strLlenarZonaComboBox() %>
   <%= strLlenarSucursalComboBox() %>
   <%= strJavascriptWindowOnLoadCommands %>;  
         
   strPreguntaDescripcion = document.forms[0].elements['hdnPreguntaDescripcion'].value;
   
   if (strPreguntaDescripcion.length > 1) {   
       document.forms[0].elements['txtPreguntaDescripcion'].value  = 'Pregunta Seleccionada: ' + strPreguntaDescripcion;
   }
   
   strRespuestaDescripcion = document.forms[0].elements['hdnRespuestaDescripcion'].value;
   
   if (strRespuestaDescripcion.length > 1) {   
       document.forms[0].elements['txtRespuestaDescripcion'].value  = 'Respuesta Seleccionada: ' + strRespuestaDescripcion;
   }
   document.forms[0].elements["cmdImprimir"].focus(); 
   
   
}

function cboDireccion_onchange() {
   if (document.forms[0].elements["cboDireccion"].selectedIndex > 0) {
       document.forms[0].elements["cboZona"].selectedIndex = 0;
       
       document.forms[0].action = "<%= strFormAction %>";
       document.forms[0].submit();
   }
   return(true);
}

function cboZona_onchange() {
   if (document.forms[0].elements["cboZona"].selectedIndex > 0) {
       document.forms[0].elements["cboSucursal"].selectedIndex = 0;
       
       document.forms[0].action = "<%= strFormAction %>";
       document.forms[0].submit();
   }
   return(true);
}

function cboSucursal_onchange() {
   if (blnValidarSubmit()) {       
       document.forms[0].elements['cmdExportar'].disabled=false;
       document.forms[0].action = "<%= strFormAction %>" + "?strCmd=Consultar";
       document.forms[0].submit(); 
    }
}

function objLupa_onclick() {   
   strEvalJs="opener.fnVerPreguntas();"; 
   strParametros = '';		
      
   strParametros = 'strEncuestaBuscar=' + document.forms[0].elements['txtEncuestaNombre'].value ;
   
   Pop('popEncuestaReporteEncuestas.aspx?'+strParametros+'&strEvalJs='+strEvalJs,500,540); 
}

function txtEncuestaNombre_onKeyDown() { 
   if(event.keyCode==13) {
       txtEncuestaNombre_onblur(); 
   }
}

function txtEncuestaNombre_onblur() {
   
   strEncuestaNombre = Trim(document.forms[0].elements['txtEncuestaNombre'].value);

   if ( (document.forms[0].elements['hdnEncuestaNombre'].value != document.forms[0].elements['txtEncuestaNombre'].value) || strEncuestaNombre.length ==0 ) 
   {   objLupa_onclick(); 
   }
   
}

function fnVerPreguntas() {
   document.forms[0].elements['txtPreguntaId'].value  =0;
   document.forms[0].elements['hdnPreguntaDescripcion'].value  ='';
   
   document.forms[0].elements['txtRespuestaId'].value =0;
   document.forms[0].elements['hdnRespuestaDescripcion'].value ='';
   
   document.forms[0].elements['cmdExportar'].disabled=true;
   
   document.forms[0].action = "<%= strFormAction %>";
   document.forms[0].submit();
}

function fnVerReporte(intPreguntaId, strPreguntaDescripcion) {
   document.forms[0].elements['txtPreguntaId'].value  = intPreguntaId;
   document.forms[0].elements['hdnPreguntaDescripcion'].value  = strPreguntaDescripcion;
       
   if (blnValidarSubmit()) {       
       document.forms[0].elements['cmdExportar'].disabled=false;
       document.forms[0].action = "<%= strFormAction %>" + "?strCmd=Consultar";
       document.forms[0].submit(); 
    }
}

function blnValidarSubmit() {
   var blnValidar = true;
   
   if ( document.forms[0].elements["cboDireccion"].selectedIndex == 0 && document.forms[0].elements["cboZona"].selectedIndex == 0 && document.forms[0].elements["cboSucursal"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar al menos algun criterio de Dirección, Zona o Sucursal");
   }
   
   if ( blnValidar && document.forms[0].elements["cboDireccion"].selectedIndex > 1 &&  document.forms[0].elements["cboZona"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar el criterio de Zona");
   }
   
   if ( blnValidar && document.forms[0].elements["cboZona"].selectedIndex > 1 &&  document.forms[0].elements["cboSucursal"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar el criterio de Sucursal");
   }      
   
   if ( blnValidar && document.forms[0].elements['txtEncuestaId'].value == 0) {
       blnValidar = false;
       alert("Seleccionar una Encuesta");
   }
   
   if ( blnValidar && document.forms[0].elements['txtPreguntaId'].value == 0) {
       blnValidar = false;
       alert("Seleccionar una Pregunta");
   }

   return blnValidar;
   
}

function cmdLimpiar_onclick() {
    window.location.href = "SucursalEncuestaReporteSucursales.aspx";
}
function cmdImprimir_onclick() {
    if (blnValidarSubmit()) {
       document.ifrPageToPrint.document.all.divBody.innerHTML= "<%=strRecordBrowserImpresion%>";
       document.ifrPageToPrint.focus();
	   window.print();   
	       
    }
}

function cmdExportar_onclick() {
   if (blnValidarSubmit()) {          
       document.forms[0].action += "?strCmd=Exportar";
       document.forms[0].submit();  
       document.forms[0].action = "<%=strFormAction%>"; 
   }    
}

function cmdCancelar_onclick() {
   window.location.href = "SucursalEncuestasHome.aspx";
}


//-->
				</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
		<form name="frmPage" action="about:blank" method="post">
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
					<td class="tdtab" width="770">Está en : <A href="SucursalHome.aspx">Sucursal</A> : <A href="SucursalEncuestasHome.aspx">
							Encuestas :</A>Reporte de Encuestas
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Reporte de encuestas de sucursales</h1>
						<p>Aquí podrá consultar las encuestas capturadas en las sucursales.</p>
						<h2>Alcance de la Consulta</h2>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="tdtexttablebold" width="90">* Dirección:</td>
								<td class="tdpadleft5" width="190">
									<select name="cboDireccion" class="field" id="cboDireccion" language="javascript" onChange="return cboDireccion_onchange()">
										<option value="0" selected>--- Elija una dirección ---</option>
										<option value="-1">Todas las direcciones</option>
										<option>--------------------</option>
									</select>
								</td>
								<td width="89">&nbsp;</td>
								<td width="375">&nbsp;</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">* Zona:</td>
								<td class="tdpadleft5"><select name="cboZona" class="field" id="cboZona" onchange="return cboZona_onchange()">
										<option value="0" selected>-- Elija una zona --</option>
										<option value="-1">Todas las zonas</option>
										<option>--------------------</option>
									</select>
								</td>
								<td width="89">&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">* Sucursal:</td>
								<td class="tdpadleft5">
									<select name="cboSucursal" class="field" id="cboSucursal" onchange="return cboSucursal_onchange()">
										<option value="0" selected>-- Elija una sucursal --</option>
										<option value="-1">Todas las sucursales</option>
										<option>--------------------</option>
									</select>
								</td>
								<td width="89">&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">* Fecha Inicio:</td>
								<td class="tdpadleft5"><input class="field" id="txtEncuestaInicio" type="text" maxLength="12" size="12" name="txtEncuestaInicio">
									<A href="javascript:cal1.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></A>
								</td>
								<td class="tdtexttablebold" width="89">* Fecha Inicio:</td>
								<td class="tdpadleft5"><input class="field" id="txtEncuestaFin" type="text" maxLength="12" size="12" name="txtEncuestaFin">
									<A href="javascript:cal2.popup()"><IMG height="15" src="images/imgCalendarIcon.gif" width="16" align="absMiddle" border="0"></A></td>
							</tr>
						</table>
						<br>
						<table class="tdenvolventetablas" width="100%">
							<tr>
								<td class="tdtittablas3" height="16">Encuesta</td>
							</tr>
							<tr>
								<td class="tdpadleft5" height="19"><input class="field" id="txtEncuestaNombre" type="text" maxLength="50" size="50" name="txtEncuestaNombre"
										autocomplete="off" onblur="return txtEncuestaNombre_onblur()" onkeydown="txtEncuestaNombre_onKeyDown()">
									&nbsp; <a id="objLupa" onclick="return objLupa_onclick()"><IMG height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"></a>
								</td>
							</tr>
						</table>
						<br>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<%=strRecorBrowserPreguntas %>
								</td>
							</tr>
							<tr>
								<td><br>
									<%=strRecordBrowserHTML %>
									<br>
								</td>
							</tr>
							<tr>
								<td><input language="javascript" class="button" id="cmdCancelar" onclick="return cmdCancelar_onclick()"
										type="button" value="Regresar" name="cmdCancelar"> <input language="javascript" class="button" id="cmdExportar" onclick="return cmdExportar_onclick()"
										type="button" value="Exportar" name="cmdExportar"> <input language="javascript" class="button" id="cmdImprimir" onclick="return cmdImprimir_onclick()"
										type="button" value="Imprimir" name="cmdImprimir"> <input language="javascript" class="button" id="cmdLimpiar" onclick="return cmdLimpiar_onclick()"
										type="button" value="Limpiar" name="cmdLimpiar">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<input type='hidden' value='<%=Request.Form("txtEncuestaId")%>'  name="txtEncuestaId">
			<input type='hidden' value='<%=Request.Form("txtEncuestaDescripcion")%>' name='txtEncuestaDescripcion'>
			<input type='hidden' value='<%=Request.Form("hdnEncuestaNombre")%>' name='hdnEncuestaNombre'>
			<input type="hidden" value='<%=Request.Form("txtPreguntaId")%>'  name="txtPreguntaId">
			<input type="hidden" value='<%=Request.Form("hdnPreguntaDescripcion")%>'  name="hdnPreguntaDescripcion">
			<input type="hidden" value='<%=Request.Form("txtRespuestaId")%>' name="txtRespuestaId">
			<input type="hidden" value='<%=Request.Form("hdnRespuestaDescripcion")%>' name="hdnRespuestaDescripcion">
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaFooterCentral()</script>
					</td>
				</tr>
			</table>
			<iframe name="ifrPageToPrint" src="ifrImpresionDocumentos.aspx" width="0" height="0" marginheight="0"
				marginwidth="0"></iframe>
			<script language="JavaScript">
    <!--
    new menu (MENU_ITEMS, MENU_POS);
    //-->
			</script>
			<script language="JavaScript">
    <!-- // create calendar object(s) just after form tag closed
    var cal1 = new calendar(null, document.forms['frmPage'].elements['txtEncuestaInicio']);
    var cal2 = new calendar(null, document.forms['frmPage'].elements['txtEncuestaFin']);
    //-->
			</script>
		</form>
	</body>
</HTML>
