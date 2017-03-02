<%@ Page CodeBehind="SistemaAgregarTipoDeReceta.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaAgregarTipoDeReceta" codePage="1252" EnableSessionState="False" enableViewState="False" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/menu.css" rel="stylesheet" type="text/css" />
<link href="css/estilo.css" rel="stylesheet" type="text/css" />
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
  document.forms[0].action = "<%= strFormAction %>";
  document.forms[0].elements["txtTipoFormaCapturaNombreId"].value = "<%= strTipoFormaCapturaNombreId %>";
  document.forms[0].elements["txtTipoFormaCapturaNombre"].value = "<%= strTipoFormaCapturaNombre %>";
  document.forms[0].elements["txtTipoFormaCapturaDescripcion"].value = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(strTipoFormaCapturaDescripcion) %>";
  document.forms[0].elements["txtTipoFormaCapturaId"].value = "<%= intTipoFormaCapturaId %>";
  document.forms[0].elements["chkTipoFormaCapturaActivo"].checked = <%= blnTipoFormaCapturaActivo.ToString().ToLower() %>;
  document.forms[0].elements["txtTipoFormaCapturaInstruccionVenta"].value = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(strTipoFormaCapturaInstruccionVenta) %>";
<%= strJavascriptWindowOnLoadCommands %>
}

function cmdCancelar_onclick() {
  window.location.href = "SistemaAdministrarTiposDeRecetas.aspx";
}

function cmdGuardar_onclick() {
  var blnReturn = blnFormValidator();
  if ( blnReturn == true) {
    document.forms[0].action += "?strCmd=Salvar";
  }
  return (blnReturn);
}

function blnFormValidator() {

  var blnReturn = false;

  /* Validación del campo "txtTipoFormaCapturaNombreId" */
  if (blnValidarCampo(document.forms[0].elements["txtTipoFormaCapturaNombreId"], true, "Nombre identificador", cintTipoCampoAlfanumerico, 50, 1, "") == true) {

    /* Validación del campo "txtTipoFormaCapturaNombre" */
    blnReturn = blnValidarCampo(document.forms[0].elements["txtTipoFormaCapturaNombre"], true, "Nombre descriptivo", cintTipoCampoAlfanumerico, 255, 1, "")
   
  }

  return (blnReturn);
}

function cmdNavegadorRegistrosAgregar_onclick() {

  var intTipoFormaCapturaId = document.forms[0].elements["txtTipoFormaCapturaId"].value;
 
  if (intTipoFormaCapturaId > 0) {
    Pop("popSistemaAgregarAtributosATipoDeReceta.aspx?intTipoFormaCapturaId=" + intTipoFormaCapturaId,"520","548");
  } else {
    alert("Para agregarle atributos al tipo de receta, primero debe dar de alta un tipo de receta.");
  }

}

//-->
</script>
</head>
<body language=javascript onLoad="return window_onload()">
<form method="POST" action="about:blank" name="frmPage">
  <input type="hidden" name="txtTipoFormaCapturaId" />
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : <a href="Sistema.aspx">Sistema</a> : <a href="SistemaClientesEspeciales.aspx">Clientes especiales </a> : <a href="SistemaAdministrarTiposDeRecetas.aspx">Administrar tipos de recetas</a> : Editar tipo de receta </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Datos del tipo de receta </h1>
        <p>Aqu&iacute; podr&aacute; dar de alta o editar un tipo de receta para asignarla a un cliente especial.</p>
        <h2>Identificador del tipo de receta</h2>
        <table  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="tdtexttablebold"><label for="txtTipoFormaCapturaNombreId">Nombre en POS:</label></td>
            <td class="tdpadleft5"><input name="txtTipoFormaCapturaNombreId" type="text" class="field" id="txtTipoFormaCapturaNombreId" size="50" maxlength="50" />
&nbsp;<span class="txrojobold">*</span></td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="txtTipoFormaCapturaNombre">Nombre en CTX:</label></td>
            <td class="tdpadleft5"><input name="txtTipoFormaCapturaNombre" type="text" class="field" id="txtTipoFormaCapturaNombre" size="118" maxlength="255" />
&nbsp;<span class="txrojobold">*</span></td>
          </tr>
          <tr>
            <td valign="top" class="tdtexttablebold"><label for="txtTipoFormaCapturaDescripcion">Descripci&oacute;n:</label></td>
            <td class="tdpadleft5"><textarea name="txtTipoFormaCapturaDescripcion" cols="120" rows="2" class="fieldcomment" id="txtTipoFormaCapturaDescripcion"></textarea></td>
          </tr>
          <tr>
            <td valign="top" class="tdtexttablebold"><label for="txtTipoFormaCapturaInstruccionVenta">Instrucciones de venta:</label></td>
            <td class="tdpadleft5"><textarea name="txtTipoFormaCapturaInstruccionVenta" cols="120" rows="2" class="fieldcomment" id="txtTipoFormaCapturaInstruccionVenta"></textarea></td>
          </tr>
          <tr>
            <td valign="top" class="tdtexttablebold"><label for="chkTipoFormaCapturaActivo">&iquest;Activo?</label></td>
            <td class="tdpadleft5"><input name="chkTipoFormaCapturaActivo" type="checkbox" class="fieldborderless" id="chkTipoFormaCapturaActivo" value="True"></td>
          </tr>
          <tr>
            <td height="10" colspan="2" align="right" valign="top" class="txaccion">&nbsp;</td>
          </tr>
          <tr>
            <td height="10" colspan="2" align="right" valign="top" class="txaccion"><img src="images/pixel.gif" width="1" height="10" />Los campos marcados con asterisco (<span class="tdpadleft5"><span class="txrojobold">*</span></span>) son obligatorios.</td>
          </tr>
          <tr>
            <td colspan="2" valign="top" class="tdtexttablebold"><input name="cmdCancelar" type="button" class="button" id="cmdCancelar" value="Regresar"  language=javascript onClick="return cmdCancelar_onclick()"/>
              <input name="cmdGuardar" type="submit" class="button" id="cmdGuardar" value="Guardar"  language=javascript onClick="return cmdGuardar_onclick()"/></td>
          </tr>
        </table>
        <%= strGetRecordBrowserHTML() %> </td>
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
