<%@ Page Language="vb" AutoEventWireup="false" Codebehind="popEncuestaAgregarRespuestaAPregunta.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popEncuestaAgregarRespuestaAPregunta"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<link href="css/estilo.css" rel="stylesheet" type="text/css">
			<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
			<!-- <script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script> -->
			<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
			<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";


function window_onload() {
   document.forms[0].action = "<%= strFormAction %>";
   document.forms[0].elements["txtintPreguntaId"].value = "<%= intPreguntaId %>";
   
   <%= strComboBoxRespuestas() %>
   <%= strJavascriptWindowOnLoadCommands %>
}

function cmdAgregar_onclick() {
  var blnReturn = false;
  
  if (blnComboBoxHasAnElementSelected(document.forms[0].elements["cboRespuestas"]) == false) {
    alert("Por favor seleccione al menos un \'Respuesta\'.");
    document.forms[0].elements["cboRespuestas"].focus();
  } else {
    document.forms[0].action += "?strCmd=Agregar";
    blnReturn = true;
  }
  return(blnReturn);

}

function cmdCancelar_onclick() {
   window.close();
}

//-->
			</script>
	</HEAD>
	<body onload="return window_onload()">
		<form method="post" action="about:blank" name="frmPage">
			<table width="360" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeaderPop2()</script>
					</td>
				</tr>
			</table>
			<table width="480" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td class="tdgeneralcontentpop" width="490"><h2>Agregar respuestas a pregunta</h2>
						<p>Elija la (las) respuesta(s) que desea agregar a la pregunta<br>
							y oprima el bot�n Agregar. Para elegir m�s de una respuesta, haga clic en los 
							nombres correspondientes.</p>
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td class="tdblueframe"><select name="cboRespuestas" size="20" multiple class="fieldcomment">
									</select>
								</td>
							</tr>
						</table>
						<br>
						<span class="tdpadleft5">
        <input name="cmdCancelar" type="button" class="button" id="cmdCancelar" value="Cancelar"
								language="javascript" onclick="return cmdCancelar_onclick()">
&nbsp;&nbsp;
        <input name="cmdAgregar" type="submit" class="button" id="cmdAgregar" value="Agregar" language="javascript"
								onclick="return cmdAgregar_onclick()">
        </span></td>
				</tr>
			</table>
			<table width="360" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaFooterPop2()</script>
					</td>
				</tr>
			</table>
			<input type="hidden" name="txtintPreguntaId">
		</form>
	</body>
</HTML>
