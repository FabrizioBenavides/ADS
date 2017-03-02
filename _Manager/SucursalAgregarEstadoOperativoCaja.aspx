<%@ Page CodeBehind="SucursalAgregarEstadoOperativoCaja.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalAgregarEstadoOperativoCaja" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
document.forms[0].elements["txtEstadoOperativoCajaNombre"].value = "<%=strNombreEstado%>";
document.forms[0].elements["txtEstadoOperativoCajaNombreId"].value = "<%=strNombreIdEstado%>";
document.forms[0].elements["txtEstadoOperativoCajaOrden"].value = "<%=strOrdenEstado%>";
}

function cmdGuardarEstado_onclick() { 
  if (blnFormValidator(frmSucursalAgregarEstadoOperativoCaja)) {
    document.forms[0].action += "?strCmd=Agregar";
    document.forms[0].submit();
    return(true);
  }
}

function cmdGuardarCambios_onclick() {
  if (blnFormValidator(frmSucursalAgregarEstadoOperativoCaja)) {
    document.forms[0].action += "?strCmd=Modificar&intEstadoOperativoCajaId=<%= intEstadoOperativoCajaId %>";
    document.forms[0].submit();
    return(true);
  }
}

function cmdCancelar_onclick() {
  window.location.href = "SucursalAdministrarEstadoOperativoCaja.aspx";
}

function blnFormValidator(theForm) {
  
	var blnReturn = false;
  
	/* Validación del campo "txtEstadoOperativoCajaNombre" */
	if (blnValidarCampo(theForm.elements["txtEstadoOperativoCajaNombre"], true, "Nombre del estado operativo", cintTipoCampoAlfanumerico, 50, 1, "")) {
  
		/* Validación del campo "txtEstadoOperativoCajaNombreId" */
		if (blnValidarCampo(theForm.elements["txtEstadoOperativoCajaNombreId"], true, "Identificador interno", cintTipoCampoAlfanumerico, 50, 1, "")) {
		
			/* Validación del campo "txtEstadoOperativoCajaOrden" */
			if (blnValidarCampo(theForm.elements["txtEstadoOperativoCajaOrden"], true, "Orden de utilización", cintTipoCampoEntero, 50, 1, 0)) {
				blnReturn = true;
			}			
		}
	}

  return (blnReturn);
}

//-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSucursalAgregarEstadoOperativoCaja">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : Sucursal: Puntos de venta : Agregar estado operativo de cajas</td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>
        <% if strCmd = "Crear" then %>
			Agregar estado operativo de cajas
		<% else if strCmd = "Editar" then %>
			Editar estado operativo de cajas
		<% end if %> </h1>
        <table width="320" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td >
              <table width="100%"  border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td class="tdtexttablebold">Nombre del estado operativo:</td>
                  <td align="right" class="tdpadleft5"><input name="txtEstadoOperativoCajaNombre" type="text" class="field" id="txtEstadoOperativoCajaNombre" size="50" maxlength="50"></td>
                </tr>
                <tr>
                  <td width="115" class="tdtexttablebold">Identificador interno: </td>
                  <td align="right" class="tdpadleft5"><input name="txtEstadoOperativoCajaNombreId" type="text" class="field" id="txtEstadoOperativoCajaNombreId" size="50" maxlength="50"></td>
                </tr>
                <tr>
                  <td width="115" class="tdtexttablebold">Orden de utilizaci&oacute;n: </td>
                  <td align="right" class="tdpadleft5"><input name="txtEstadoOperativoCajaOrden" type="text" class="field" id="txtEstadoOperativoCajaOrden" size="20" maxlength="20"></td>
                </tr>
                <tr>
                  <td height="10" colspan="2"><img src="images/pixel.gif" width="1" height="10"></td>
                </tr>
                <tr>
                  <td class="tdtexttablebold">&nbsp;</td>
                  <td align="right" class="tdpadleft5"><input name="cmdCancelar" type="button" class="button" id="cmdCancelar" value="Cancelar" onclick="return cmdCancelar_onclick()">
                  <% if strCmd = "Crear" then %>
					<input name="cmdGuardarEstado" type="button" class="button" id="cmdGuardarEstado" value="Guardar estado" onclick="return cmdGuardarEstado_onclick()"></td>
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
