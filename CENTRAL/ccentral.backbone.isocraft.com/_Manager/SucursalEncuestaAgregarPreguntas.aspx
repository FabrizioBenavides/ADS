<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEncuestaAgregarPreguntas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEncuestaAgregarPreguntas"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<link href="css/menu.css" rel="stylesheet" type="text/css">
			<link href="css/estilo.css" rel="stylesheet" type="text/css">
				<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
				<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
				<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
				<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
				<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
				<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
   document.forms[0].action = "<%= strFormAction %>";
   
   document.forms[0].elements["txtPreguntaId"].value = "<%= intPreguntaId %>";
   document.forms[0].elements["txtPreguntaEncuestaAsociada"].value = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(strPreguntaEncuestaAsociada) %>";
   document.forms[0].elements["txtPreguntaDescripcion"].value = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(strPreguntaDescripcion) %>";   
   
   if ( document.forms[0].elements["txtPreguntaId"].value > 0) {
       document.forms[0].elements["chkPreguntaActivo"].checked = <%= blnPreguntaActivo.ToString().ToLower() %>;   
   }
   else {
       document.forms[0].elements["chkPreguntaActivo"].checked = true;
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


function cmdRegresar_onclick() {
   window.location.href = "SucursalEncuestaAdministrarPreguntas.aspx";
}

function blnFormValidator() {
   
   var blnReturn = false;
     
   /* Validación del campo "txtPreguntaEncuestaAsociada" */
   if(blnValidarCampo(document.forms[0].elements["txtPreguntaEncuestaAsociada"], true, "Encuesta Relacionada, para facilitar la asignación de la pregunta a la encuesta", cintTipoCampoAlfanumerico, 60, 1, "") == true){
   
      /* Validación del campo "txtPreguntaDescripcion" */
      if(blnValidarCampo(document.forms[0].elements["txtPreguntaDescripcion"], true, "Pregunta en POS", cintTipoCampoAlfanumericoExtendido, 60, 1, "") == true) {      
          blnReturn = true;        
      }
      
   }   
          
   return (blnReturn);
}

function cmdNavegadorRegistrosAgregar_onclick() {  
  var intPreguntaId = document.forms[0].elements["txtPreguntaId"].value;
 
  if (intPreguntaId > 0) {
    Pop("popEncuestaAgregarRespuestaAPregunta.aspx?intPreguntaId=" + intPreguntaId,"600","540");
  } else {
    alert("Para agregarle respuesta, primero debe dar de alta una pregunta.");
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
							Encuestas </a>: Administrar Preguntas</td>
				</tr>
			</table>
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent"><h1>
							Datos de la pregunta</h1>
						<p>Aquí podrá dar de alta, modificar y asociar las respuestas correspondientes a la 
							pregunta.</p>
						<h2>Información de la pregunta</h2>
						<table class="tdenvolventetablas" width="100%">
							<tr>
								<td height="16" class="tdtittablas3"><label for="txtPreguntaEncuestaAsociada">Encuesta
                Relacionada</label>
								</td>
								<td class="tdtittablas3"><label for="txtPreguntaDescripcion">Pregunta
                en POS</label>
								</td>
								<td class="tdtittablas3"><label for="chkPreguntaActivo">Activa</label>
								</td>
								<td rowspan="3" align="center">
									<input name="cmdGuardar" type="submit" class="button" id="cmdGuardar" value="Guardar" onclick="return cmdGuardar_onclick()">
									<input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar"
										onclick="return cmdRegresar_onclick()">
								</td>
							</tr>
							<tr>
								<td height="19" class="tdpadleft5"><input name="txtPreguntaEncuestaAsociada" type="text" class="field" id="txtPreguntaEncuestaAsociada"
										size="50" maxlength="50">
								</td>
								<td class="tdpadleft5"><input name="txtPreguntaDescripcion" type="text" class="field" id="txtPreguntaDescripcion"
										size="60" maxlength="50">
								</td>
								<td class="tdpadleft5"><input name="chkPreguntaActivo" type="checkbox" class="fieldborderless" id="chkPreguntaActivo"
										value="True" checked>
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
			<input type="hidden" name="txtPreguntaId">
			<script language="JavaScript">
    <!--
    new menu (MENU_ITEMS, MENU_POS);
    //-->
			</script>
		</form>
	</body>
</HTML>
