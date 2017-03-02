<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEncuestaAgregarEncuestas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEncuestaAgregarEncuestas"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="css/menu.css" rel="stylesheet" type="text/css">
			<link href="css/estilo.css" rel="stylesheet" type="text/css">
				<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
				<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
				<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
				<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
				<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
				<script language="JavaScript" src="js/calendario.js"></script>
				<script language="JavaScript" src="js/cal_format00.js"></script>
				<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
   document.forms[0].action = "<%= strFormAction %>";
   
   document.forms[0].elements["txtEncuestaId"].value = "<%= intEncuestaId %>";
   document.forms[0].elements["txtEncuestaNombre"].value = "<%= strEncuestaNombre %>";
   document.forms[0].elements["txtEncuestaDescripcion"].value = "<%= strEncuestaDescripcion %>";
   
   document.forms[0].elements["txtEncuestaInicio"].value = "<%= dtmEncuestaInicio.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) %>";
   document.forms[0].elements["txtEncuestaFin"].value = "<%= dtmEncuestaFin.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) %>";
      
   document.forms[0].elements["chkEncuestaObligatoria"].checked = <%= blnEncuestaObligatoria.ToString().ToLower() %>;   
   
   if (document.forms[0].elements["txtEncuestaId"].value > 0) {
       document.forms[0].elements["chkEncuestaActivo"].checked = <%= blnEncuestaActivo.ToString().ToLower() %>;   
   }
   else {
       document.forms[0].elements["chkEncuestaActivo"].checked = true;
   }
   

   <%= strJavascriptWindowOnLoadCommands %>

}

function cmdGuardar_onclick() {
   var blnReturn = blnFormValidator();
   
   if ( blnReturn == true) {
       document.forms[0].action += "?strCmd=Salvar";
   }
   return (blnReturn);
}


function cmdCancelar_onclick() {
   window.location.href = "SucursalEncuestaAdministrarEncuestas.aspx";
}

function blnFormValidator() {
   
   var blnReturn = false;
     
   /* Validación del campo "txtEncuestaNombre" */
   if(blnValidarCampo(document.forms[0].elements["txtEncuestaNombre"], true, "Nombre de la Encuesta, que la identifica centralmente", cintTipoCampoAlfanumerico, 80, 1, "") == true){
          
       /* Validación del campo "txtEncuestaDescripcion" */
       if(blnValidarCampo(document.forms[0].elements["txtEncuestaDescripcion"], true, "Nombre de la Encuesta, en el POS", cintTipoCampoAlfanumericoExtendido, 80, 1, "") == true) {
           
           /* Validación del campo "txtEncuestaInicio" */
           if (blnValidarCampo(document.forms[0].elements["txtEncuestaInicio"], true, "Inicio Encuesta", cintTipoCampoFecha, 10, 0, "") == true) {
           
               /* Validación del campo "txtEncuestaFin" */
               if (blnValidarCampo(document.forms[0].elements["txtEncuestaFin"], true, "Fin Encuesta", cintTipoCampoFecha, 10, 0, "") == true) {           
                   blnReturn = true;
               }
           }
       }
   }
      
             
   return (blnReturn);
}

function cmdNavegadorRegistrosAgregar_onclick() {  
  var intEncuestaId = document.forms[0].elements["txtEncuestaId"].value;
 
  if (intEncuestaId > 0) {
    Pop("popEncuestaAgregarPreguntaAEncuesta.aspx?intEncuestaId=" + intEncuestaId,"600","540");
  } else {
    alert("Para agregarle pregunta, primero debe dar de alta una encuesta.");
  }

}

//-->
				</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
		<form method="post" action="about:blank" name="frmPage">
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td width="770" class="tdtab">Está en : <a href="SucursalHome.aspx">Sucursal</a> : <a href="SucursalEncuestasHome.aspx">
							Encuestas :</a>Administra encuesta
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent"><h1>Datos de la encuesta</h1>
						<p>Aquí podrá dar de alta, modificar y asociar las preguntas correspondientes a la 
							encuesta.</p>
						<h2>Identificador del tipo de encuesta</h2>
						<table border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="120" class="tdtexttablebold"><p>
										<label for="txtEncuestaNombre">Nombre en CTX:</label>
									</p>
								</td>
								<td width="499" class="tdpadleft5"><input name="txtEncuestaNombre" type="text" class="field" id="txtEncuestaNombre" size="80"
										maxlength="60">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold"><label for="txtEncuestaDescripcion">Nombre
                en POS:</label>
								</td>
								<td class="tdpadleft5"><input name="txtEncuestaDescripcion" type="text" class="field" id="txtEncuestaDescripcion"
										size="80" maxlength="60">
								</td>
							</tr>
							<tr>
								<td valign="top" class="tdtexttablebold"><label for="txtEncuestaInicio">FechaInicio:</label>
								</td>
								<td class="tdpadleft5"><input name="txtEncuestaInicio" id="txtEncuestaInicio" class="field" size="12" maxlength="12"
										type="text"> <a href="javascript:cal1.popup()"><img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"></a>
								</td>
							</tr>
							<tr>
								<td valign="top" class="tdtexttablebold"><label for="txtEncuestaFin">Fecha
                Fin:</label>
								</td>
								<td class="tdpadleft5"><input name="txtEncuestaFin" id="txtEncuestaFin" class="field" size="12" maxlength="12"
										type="text"> <a href="javascript:cal2.popup()"><img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"></a></td>
							</tr>
							<tr>
								<td valign="top" class="tdtexttablebold"><label for="chkEncuestaObligatoria">¿Obligatoria
                en POS?</label>
								</td>
								<td class="tdpadleft5"><input name="chkEncuestaObligatoria" type="checkbox" class="fieldborderless" id="chkEncuestaObligatoria"
										value="True">
								</td>
							</tr>
							<tr>
								<td valign="top" class="tdtexttablebold"><label for="chkEncuestaActivo">¿Activo?</label>
								</td>
								<td class="tdpadleft5"><input name="chkEncuestaActivo" type="checkbox" class="fieldborderless" id="chkEncuestaActivo"
										value="True" checked>
								</td>
							</tr>
							<tr>
								<td height="10" colspan="2" align="right" valign="top" class="txaccion">&nbsp;</td>
							</tr>
							<tr>
								<td colspan="2" valign="top" class="tdtexttablebold"><input name="cmdCancelar" type="button" class="button" id="cmdCancelar" value="Regresar"
										language="javascript" onclick="return cmdCancelar_onclick()"> <input name="cmdGuardar" type="submit" class="button" id="cmdGuardar" value="Guardar" language="javascript"
										onclick="return cmdGuardar_onclick()">
								</td>
							</tr>
						</table>
						<%= strGetRecordBrowserHTML() %>
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaFooterCentral()</script>
					</td>
				</tr>
			</table>
			<input type="hidden" name="txtEncuestaId">
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
