<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEncuestaAdministrarRespuestas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEncuestaAdministrarRespuestas"%>
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
  
  var strCmd = "<%= strCmd %>";
  document.forms[0].action = "<%= strFormAction %>";
  
  document.forms[0].elements["txtRespuestaId"].value       = "<%= intRespuestaId %>";
  document.forms[0].elements["txtRespuestaPreguntaAsociada"].value   = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(strRespuestaPreguntaAsociada) %>";
  document.forms[0].elements["txtRespuestaDescripcion"].value  = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(strRespuestaDescripcion) %>";
  document.forms[0].elements["txtRespuestaOrdenPOS"].value    = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(strRespuestaOrdenPOS) %>";
  
  if (document.forms[0].elements["txtRespuestaId"].value > 0) {
       document.forms[0].elements["chkRespuestaActivo"].checked =  <%= blnRespuestaActivo.ToString().ToLower() %>;
  }
  else {
       document.forms[0].elements["chkRespuestaActivo"].checked = true;
  }
    
  <%= strJavascriptWindowOnLoadCommands %>
  
  document.forms[0].elements["txtRespuestaPreguntaAsociada"].focus();
  
}

function blnFormValidator() {   
   var blnReturn = false;
    
    /* Validación del campo "txtRespuestaPreguntaAsociada" */
    if(blnValidarCampo(document.forms[0].elements["txtRespuestaPreguntaAsociada"], true, "Tipo de Respuesta, para facilitar asociación de la Respuesta a la Pregunta", cintTipoCampoAlfanumerico, 50, 1, "") == true){
	    /* Validación del campo "txtRespuestaDescripcion" */
        if (blnValidarCampo(document.forms[0].elements["txtRespuestaDescripcion"],true,"Respuesta en POS, capturar la respuesta como se vera en el POS", cintTipoCampoAlfanumerico, 65,1,"")== true) {
		    /* Validación del campo "txtRespuestaOrdenPOS" */
			if(blnValidarCampo(document.forms[0].elements["txtRespuestaOrdenPOS"], true, "Respuesta Orden, para darle un orden a la respuesta", cintTipoCampoAlfanumerico, 2, 1, "") == true) {
			    blnReturn = true;
			}
		}
	}
	
	return (blnReturn);
}

function cmdGuardar_onclick() {
   var blnReturn = blnFormValidator();
   if ( blnReturn == true) {
       document.forms[0].action += "?strCmd=Salvar" + "&intNavegadorRegistrosPagina=" + <%= Isocraft.Web.http.GetPageParameter("intNavegadorRegistrosPagina", 1) %>;
   }
   return (blnReturn);
}


function cmdLimpiar_onclick() {
   window.location.href = "<%= strFormAction %>";
}

//-->
				</script>
	</HEAD>
	<body MS_POSITIONING="FlowLayout" onload="return window_onload()">
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
							Encuestas </a>: Administrar Respuestas</td>
				</tr>
			</table>
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent"><h1>Administrar Respuesta</h1>
						<p>Aquí podrá dar de alta o editar las respuestas para las preguntas de las 
							encuestas.</p>
						<%= strGetRecordBrowserHTML() %>
						<br>
						<h2>Información de la respuesta</h2>
						<table class="tdenvolventetablas" width="100%">
							<tr>
								<td width="28%" height="16" class="tdtittablas3"><label for="txtRespuestaPreguntaAsociada">Tipo de Respuesta</label>
								</td>
								<td width="36%" class="tdtittablas3"><label for="txtRespuestaDescripcion">Respuesta
                en POS</label>
								</td>
								<td width="5%" class="tdtittablas3"><label for="txtRespuestaOrdenPOS">Orden</label>
								</td>
								<td width="7%" class="tdtittablas3"><label for="chkRespuestaActivo">Activa</label>
								</td>
								<td width="24%" rowspan="3" align="center">
									<input name="cmdGuardar" type="submit" class="button" id="cmdGuardar" value="Guardar" onclick="return cmdGuardar_onclick()">
									<input name="cmdLimpiar" type="button" class="button" id="cmdLimpiar" value="Limpiar" onclick="return cmdLimpiar_onclick()">
								</td>
							</tr>
							<tr>
								<td class="tdpadleft5"><input name="txtRespuestaPreguntaAsociada" type="text" class="field" id="txtRespuestaPreguntaAsociada"
										size="50" maxlength="50">
								</td>
								<td class="tdpadleft5"><input name="txtRespuestaDescripcion" type="text" class="field" id="txtRespuestaDescripcion"
										size="50" maxlength="30">
								</td>
								<td class="tdpadleft5"><input name="txtRespuestaOrdenPOS" type="text" class="field" id="txtRespuestaOrdenPOS"
										size="3" maxlength="02">
								</td>
								<td class="tdpadleft5"><input name="chkRespuestaActivo" type="checkbox" class="fieldborderless" id="chkRespuestaActivo"
										value="True" checked>
								</td>
							</tr>
						</table>
						<span class="tdpadleft5"></span><br>
					</td>
				</tr>
			</table>
			<input type="hidden" name="txtRespuestaId">
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaFooterCentral()</script>
					</td>
				</tr>
			</table>
			<script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
			</script>
		</form>
	</body>
</HTML>
