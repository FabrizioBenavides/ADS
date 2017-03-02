<%@ Page CodeBehind="SucursalAgregarFormatoDatoPoliticaPos.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalAgregarFormatoDatoPoliticaPos" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script id=clientEventHandlersJS language=javascript>
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
<%= strJavascriptWindowOnLoadCommands %>

//Llenamos los campos con los valores cuando es edición
document.forms[0].elements["txtTipoDatoPoliticaPosNombre"].value = "<%=strNombreFormato%>";
document.forms[0].elements["txtTipoDatoPoliticaPosNombreId"].value = "<%=strNombreIdFormato%>";
document.forms[0].elements["txtTipoDatoPoliticaPosLongitud"].value = "<%=strLongitudFormato%>";
document.forms[0].elements["cboTipoDatoPoliticaPosTipo"].selectedIndex = <%=intTipoDato%>;
}

function cmdGuardarFormato_onclick() { 
  if (blnFormValidator(frmSucursalAgregarFormatoDatoPoliticaPos)) {
    document.forms[0].action += "?strCmd=Agregar";
    document.forms[0].submit();
    return(true);
  }
}

function cmdGuardarCambios_onclick() {
  if (blnFormValidator(frmSucursalAgregarFormatoDatoPoliticaPos)) {
    document.forms[0].action += "?strCmd=Modificar&intTipoDatoPoliticaPosId=<%= intTipoDatoPoliticaPosId %>";
    document.forms[0].submit();
    return(true);
  }
}

function cmdCancelar_onclick() {
  window.location.href = "SucursalAdministrarFormatoDatoPoliticaPos.aspx";
}

function blnFormValidator(theForm) {
  
	var blnReturn = false;
  
	/* Validación del campo "txtTipoDatoPoliticaPosNombre" */
	if (blnValidarCampo(theForm.elements["txtTipoDatoPoliticaPosNombre"], true, "Nombre del formato", cintTipoCampoAlfanumerico, 50, 1, "")) {
  
		/* Validación del campo "txtTipoDatoPoliticaPosNombreId" */
		if (blnValidarCampo(theForm.elements["txtTipoDatoPoliticaPosNombreId"], true, "Identificador interno", cintTipoCampoAlfanumerico, 50, 1, "")) {
		
			/* Validación del campo "txtTipoDatoPoliticaPosLongitud" */
			if (blnValidarCampo(theForm.elements["txtTipoDatoPoliticaPosLongitud"], true, "Longitud del formato", cintTipoCampoEntero, 50, 1, 0)) {
			
				/* Validación del campo "cboTipoDatoPoliticaPosTipo" */
				if (theForm.elements["cboTipoDatoPoliticaPosTipo"].options[0].selected == true) {
					alert("Favor de seleccionar un Tipo de dato.");
					theForm.elements["cboTipoDatoPoliticaPosTipo"].focus();
				} else {
					blnReturn = true;
				}
			}
		}
	}

  return (blnReturn);
}

//-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSucursalAgregarFormatoDatoPoliticaPos">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : Sucursal: Puntos de venta : Agregar formato de datos de políticas POS</td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>
        <% if strCmd = "Crear" then %>
			Agregar formato de datos (pol&iacute;tica POS)
		<% else if strCmd = "Editar" then %>
			Editar formato de datos (pol&iacute;tica POS)
		<% end if %> </h1>
        <table width="320" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td >
              <table width="100%"  border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td class="tdtexttablebold">Nombre del formato:</td>
                  <td align="right" class="tdpadleft5"><input name="txtTipoDatoPoliticaPosNombre" type="text" class="field" id="txtTipoDatoPoliticaPosNombre" size="50" maxlength="50"></td>
                </tr>
                <tr>
                  <td width="115" class="tdtexttablebold">Identificador interno: </td>
                  <td align="right" class="tdpadleft5"><input name="txtTipoDatoPoliticaPosNombreId" type="text" class="field" id="txtTipoDatoPoliticaPosNombreId" size="50" maxlength="50"></td>
                </tr>
                <tr>
                  <td width="115" class="tdtexttablebold">Longitud del formato: </td>
                  <td align="right" class="tdpadleft5"><input name="txtTipoDatoPoliticaPosLongitud" type="text" class="field" id="txtTipoDatoPoliticaPosLongitud" size="50" maxlength="50"></td>
                </tr>
                <tr>
                  <td width="115" class="tdtexttablebold">Tipo de dato: </td>
                  <td align="right" class="tdpadleft5"><select name="cboTipoDatoPoliticaPosTipo" class="field" id="cboTipoDatoPoliticaPosTipo">
					<option value="0">-- Elija un tipo --</option>
					<option value="1">Decimal</option>
					<option value="2">Condicional</option>
					<option value="3">Número entero</option>
					</select>
                  </td>
                </tr>
                <tr>
                  <td height="10" colspan="2"><img src="images/pixel.gif" width="1" height="10"></td>
                </tr>
                <tr>
                  <td class="tdtexttablebold">&nbsp;</td>
                  <td align="right" class="tdpadleft5"><input name="cmdCancelar" type="button" class="button" id="cmdCancelar" value="Cancelar" onclick="return cmdCancelar_onclick()">
                  <% if strCmd = "Crear" then %>
					<input name="cmdGuardarFormato" type="button" class="button" id="cmdGuardarFormato" value="Guardar formato" onclick="return cmdGuardarFormato_onclick()"></td>
				  <% else if strCmd = "Editar" then %>
					<input name="cmdGuardarCambios" type="button" class="button" id="cmdGuardarCambios" value="Guardar cambios" onclick="return cmdGuardarCambios_onclick()"></td>
				  <% end if %>
                </tr>
              </table></td>
          </tr>
        </table>
       </td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaFooterCentral()</script></td>
    </tr>
  </table>
  <script language="JavaScript">
<!--
new menu (MENU_ITEMS, MENU_POS);
//-->
</script>
</form>
</body>
</html>
