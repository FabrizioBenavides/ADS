<%@ Page Language="vb" AutoEventWireup="false" Codebehind="popAdministrarClientesNuevos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.popAdministrarClientesNuevos" codePage="28592" EnableSessionState="False" %>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<link href="css/estilo.css" rel="stylesheet" type="text/css">
			<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
			<script language="JavaScript" type="text/JavaScript" src="js/tools.js"></script>
			<script language="javascript" id="clientEventHandlersJS">
<!--

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  <%= strLlenarGrupoClienteEspecialComboBox() %>;    
  document.forms[0].elements['txtClienteEspecialDescripcion'].value = "<%= strClienteEspecialNombreId %>" + ' - ' + "<%= strClienteEspecialNombre %>";
  
  <%= strJavascriptWindowOnLoadCommands %>
      
}


function cmdCancelar_onclick() {
   window.close();
}

function cmdAsignar_onclick() {
 var blnReturn = false;
 
  intGrupoClienteEspecialId = document.forms[0].elements["cboGrupoClienteEspecial"].value;
      
  if (intGrupoClienteEspecialId == 0) {
    alert("Por favor seleccione el grupo en el cual se incluira al cliente");
    document.forms[0].elements["cboGrupoClienteEspecial"].focus();
  } else {
    document.forms[0].action += "?strCmd=Asignar&strClienteEspecialNombreId=" + "<%=strClienteEspecialNombreId%>";
    document.forms[0].submit();
    blnReturn = true;
  }
  return(blnReturn);
}

//-->
			</script>
	</HEAD>
	<body onload="return window_onload()">
		<form method="post" action="about:blank" name="frmpopAdministrarClientesNuevos">
			<table width="500" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td width="152"><img src="images/imgBenavidesLogoPop.gif" width="152" height="51"></td>
					<td align="right"><img src="images/imgSistemaLogoPop.gif" width="162" height="51"></td>
				</tr>
				<tr>
					<td class="tdclosewindow" colspan="2">x<a href="#" onClick="window.close();">cerrar 
							ventana </a>
					</td>
				</tr>
			</table>
			<table width="500" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td class="tdgeneralcontentpop"><h2>Asignar grupo a cliente especial
						</h2>
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td class="tdtexttablebold">Cliente:</td>
								<td><input name="txtClienteEspecialDescripcion" type="text" readonly class="campotablaresultado"
										size="70">
								</td>
							</tr>
							<tr>
								<td width="50" class="tdtexttablebold"><label for="cboGrupoClienteEspecial">Grupo:</label>
								</td>
								<td width="188" class="tdpadleft5"><select name="cboGrupoClienteEspecial" class="field" id="cboGrupoClienteEspecial">
										<option value="0" selected>--- Elija un grupo ---</option>
									</select>
								</td>
							</tr>
							<tr>
								<td height="20" colspan="2"><img src="images/pixel.gif" width="1" height="20"></td>
							</tr>
							<tr>
								<td class="tdpadleft5" align="left" colspan="2"><input name="cmdAsignar" type="button" class="button" value="Asignar Grupo" onclick="return cmdAsignar_onclick()">
								</td>
							</tr>
						</table>
						&nbsp;
						<br>
					</td>
				</tr>
			</table>
			<table width="500" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdbottompop">Administrador del Sistema Concentrador CTX © 2007 Farmacias 
						Benavides</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
