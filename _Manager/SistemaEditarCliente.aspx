<%@ Page CodeBehind="SistemaEditarCliente.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaEditarCliente" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5" />
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/menu.css" rel="stylesheet" type="text/css" />
<link href="css/estilo.css" rel="stylesheet" type="text/css" />
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="js/calendario.js"></script>
<script language="JavaScript" src="js/cal_format00.js"></script>
<script id=clientEventHandlersJS language=javascript>
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  var intGrupoClienteEspecialId = "<%= intGrupoClienteEspecialId %>";
  document.forms[0].action = "<%= strFormAction %>";
  document.forms[0].elements["txtClienteEspecialNombreId"].value = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(strClienteEspecialNombreId) %>";
  document.forms[0].elements["txtClienteEspecialNombre"].value = "<%= Isocraft.Web.Convert.ConvertToJavascriptString(strClienteEspecialNombre) %>";
  document.forms[0].elements["txtClienteEspecialDescuento"].value = "<%= fltClienteEspecialDescuento %>";
  document.forms[0].elements["txtClienteEspecialVigencia"].value = "<%= dtmClienteEspecialVigencia.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture) %>";
  document.forms[0].elements["txtClienteEspecialMinimoPorcentajeCopago"].value = "<%= fltClienteEspecialMinimoPorcentajeCopago %>";
  document.forms[0].elements["txtClienteEspecialMaximoPorcentajeCopago"].value = "<%= fltClienteEspecialMaximoPorcentajeCopago %>";
  document.forms[0].elements["txtClienteEspecialMinimoImporteCopago"].value = "<%= fltClienteEspecialMinimoImporteCopago %>";
  document.forms[0].elements["txtClienteEspecialMaximoImporteCopago"].value = "<%= fltClienteEspecialMaximoImporteCopago %>";
  document.forms[0].elements["chkClienteEspecialActivo"].checked = <%= blnClienteEspecialActivo.ToString().ToLower() %>;
  document.forms[0].elements["chkClienteEspecialPagoDeContado"].checked = <%= blnClienteEspecialPagoDeContado.ToString().ToLower() %>;
  document.forms[0].elements["chkClienteEspecialRespetarOfertas"].checked = <%= blnClienteEspecialRespetarOfertas.ToString().ToLower() %>;
  document.forms[0].elements["chkClienteEspecialExcedidoEnLimiteCredito"].value = "<%= blnClienteEspecialExcedidoEnLimiteCredito %>";
  document.forms[0].elements["chkClienteEspecialExcedidoEnLimiteCreditoND"].checked = <%= blnClienteEspecialExcedidoEnLimiteCredito.ToString().ToLower() %>;
  document.forms[0].elements["txtClienteEspecialId"].value = "<%= intClienteEspecialId %>";
  document.forms[0].elements["txtGrupoClienteEspecialId"].value = "<%= intGrupoClienteEspecialId %>";
<%= strLlenarGrupoClienteEspecialComboBox %>
<%= strLlenarClientEspecialTipoFormaCapturaComboBox %>
<%= strJavascriptWindowOnLoadCommands %>
  document.forms[0].elements["cboGrupoClienteEspecial"].disabled = true;
  document.forms[0].elements["txtClienteEspecialNombreId"].readOnly = true;
  document.forms[0].elements["txtClienteEspecialNombre"].readOnly = true;
  if (intGrupoClienteEspecialId == "6") {
    document.forms[0].elements["txtClienteEspecialDescuento"].readOnly = true;
    document.forms[0].elements["txtClienteEspecialMinimoPorcentajeCopago"].readOnly = true;
    document.forms[0].elements["txtClienteEspecialMaximoPorcentajeCopago"].readOnly = true;
    document.forms[0].elements["txtClienteEspecialMinimoImporteCopago"].readOnly = true;
    document.forms[0].elements["txtClienteEspecialMaximoImporteCopago"].readOnly = true;
    document.forms[0].elements["chkClienteEspecialPagoDeContado"].disabled = true;
    document.forms[0].elements["chkClienteEspecialRespetarOfertas"].disabled = true;
  }
}

function blnFormValidator() {

  var blnReturn = false;


  /* Validación del campo "txtClienteEspecialDescuento" */
  if (blnValidarCampo(document.forms[0].elements["txtClienteEspecialDescuento"], true, "Descuento", cintTipoCampoReal, 5, 1, "") == true) {
  
    /* Validación del campo "txtClienteEspecialVigencia" */
    if (blnValidarCampo(document.forms[0].elements["txtClienteEspecialVigencia"], true, "Vigencia", cintTipoCampoFecha, 10, 0, "") == true) {

      /* Validación del campo "txtClienteEspecialMinimoPorcentajeCopago" */
      if (blnValidarCampo(document.forms[0].elements["txtClienteEspecialMinimoPorcentajeCopago"], true, "Copago mínimo", cintTipoCampoReal, 5, 1, "") == true) {

        /* Validación del campo "txtClienteEspecialMaximoPorcentajeCopago" */
        if (blnValidarCampo(document.forms[0].elements["txtClienteEspecialMaximoPorcentajeCopago"], true, "Copago máximo", cintTipoCampoReal, 5, 1, "") == true) {

          /* Validación del campo "txtClienteEspecialMinimoImporteCopago" */
          if (blnValidarCampo(document.forms[0].elements["txtClienteEspecialMinimoImporteCopago"], true, "Importe de copago mínimo", cintTipoCampoReal, 10, 0, "") == true) {

            /* Validación del campo "txtClienteEspecialMaximoImporteCopago" */
            blnReturn = blnValidarCampo(document.forms[0].elements["txtClienteEspecialMaximoImporteCopago"], true, "Importe de copago máximo", cintTipoCampoReal, 10, 0, "");

          }

        }

      }
  
    }
    
  }
      
  return (blnReturn);
}

function cmdCancelar_onclick() {
  window.location.href = "SistemaAdministrarClientes.aspx";
}

function cmdGuardar_onclick() {
  var blnReturn = blnFormValidator();
  if (blnReturn == true) {
    document.forms[0].action += "?strCmd=Salvar";
  }
  return (blnReturn);
}

function cmdAsignarSucursales_onclick() {
  Pop('popSucursalAsignarSucursalesAClienteEspecial.aspx?intClienteEspecialId=<%= intClienteEspecialId %>&intGrupoClienteEspecialId=<%= intGrupoClienteEspecialId %>&strClienteEspecialNombreId=<%= strClienteEspecialNombreId %>','360','520');
}

function cmdBorrarTodasSucursales_onclick() {
  var blnReturn = confirm("¿Esta seguro(a) que desea borrar todas las sucursales asignadas a este cliente?");
  if ( blnReturn == true) {
    document.forms[0].action += "?strCmd=EliminarSucursales";
  }
  return(blnReturn);
}

//-->
</script>
</head>
<body language=javascript onLoad="return window_onload()">
<form method="POST" action="about:blank" name="frmPage">
  <input name="txtClienteEspecialId" type="hidden" />
  <input name="chkClienteEspecialExcedidoEnLimiteCredito" type="hidden" />
  <input name="txtGrupoClienteEspecialId" type="hidden" />
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : <a href="Sistema.aspx">Sistema</a> : <a href="SistemaClientesEspeciales.aspx">Clientes especiales</a> : <a href="SistemaAdministrarClientes.aspx">Administrar clientes</a> : Editar cliente</td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Editar cliente </h1>
        <p>Aqu&iacute; podr&aacute; editar la informaci&oacute;n correspondiente a un cliente especial.</p>
        <h2>Datos del cliente especial</h2>
        <table  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="tdtexttablebold"><label for="cboGrupoClienteEspecial">Grupo:</label></td>
            <td colspan="3" class="tdcontentableblue"><select name="cboGrupoClienteEspecial" class="field" id="cboGrupoClienteEspecial">
                <option value="0">--- Elija un grupo ---</option selected>
              </select>
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="txtClienteEspecialNombreId">Nombre identificador:</label></td>
            <td colspan="3" class="tdcontentableblue"><span class="tdpadleft5">
              <input name="txtClienteEspecialNombreId" type="text" class="field" id="txtClienteEspecialNombreId" size="50" maxlength="50" />
              </span></td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="txtClienteEspecialNombre">Nombre del cliente:</label></td>
            <td colspan="3" class="tdcontentableblue"><span class="tdpadleft5">
              <textarea name="txtClienteEspecialNombre" cols="115" rows="2" class="fieldcomment" id="txtClienteEspecialNombre"></textarea>
              </span></td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="txtClienteEspecialDescuento">Descuento:</label></td>
            <td class="tdcontentableblue"><span class="tdpadleft5">
              <input name="txtClienteEspecialDescuento" type="text" class="field" id="txtClienteEspecialDescuento" size="5" maxlength="5" />
              % </span>&nbsp;<span class="txrojobold">*</span></td>
            <td class="tdtexttablebold"><label for="txtClienteEspecialVigencia">Vigencia:</label></td>
            <td class="tdpadleft5"><input name="txtClienteEspecialVigencia" id="txtClienteEspecialVigencia" class="field" size="12" maxlength="12" type="text" />
              <a href="javascript:cal1.popup()"><img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absmiddle" /></a>&nbsp;<span class="txrojobold">*</span></td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="txtClienteEspecialMinimoPorcentajeCopago">Copago m&iacute;nimo:</label></td>
            <td class="tdcontentableblue"><span class="tdpadleft5">
              <input name="txtClienteEspecialMinimoPorcentajeCopago" type="text" class="field" id="txtClienteEspecialMinimoPorcentajeCopago" size="5" maxlength="5" />
              % </span>&nbsp;<span class="txrojobold">*</span></td>
            <td class="tdtexttablebold"><label for="txtClienteEspecialMaximoPorcentajeCopago">Copago m&aacute;ximo:</label></td>
            <td class="tdcontentableblue"><input name="txtClienteEspecialMaximoPorcentajeCopago" type="text" class="field" id="txtClienteEspecialMaximoPorcentajeCopago" size="5" maxlength="5" />
              % &nbsp;<span class="txrojobold">*</span></td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><label for="txtClienteEspecialMinimoImporteCopago">Importe de copago m&iacute;nimo:&nbsp;$</label></td>
            <td class="tdcontentableblue"><span class="tdpadleft5">
              <input name="txtClienteEspecialMinimoImporteCopago" type="text" class="field" id="txtClienteEspecialMinimoImporteCopago" size="20" maxlength="20" />
              </span>&nbsp;<span class="txrojobold">*</span></td>
            <td class="tdtexttablebold"><label for="txtClienteEspecialMaximoImporteCopago">Importe de copago m&aacute;ximo:&nbsp;$</label></td>
            <td class="tdpadleft5"><span class="tdcontentableblue">
              <input name="txtClienteEspecialMaximoImporteCopago" type="text" class="field" id="txtClienteEspecialMaximoImporteCopago" size="20" maxlength="20" />
              </span>&nbsp;<span class="txrojobold">*</span></td>
          </tr>
          <tr align="right">
            <td colspan="4" class="txaccion"><img src="images/pixel.gif" width="1" height="5" /></td>
          </tr>
          <tr>
            <td colspan="4" class="tdtexttablebold"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="102" class="tdtexttablebold"><label for="chkClienteEspecialActivo">&iquest;Activo?</label>
                    <input name="chkClienteEspecialActivo" type="checkbox" id="chkClienteEspecialActivo" value="True" />
                  </td>
                  <td width="188" class="tdtexttablebold"><label for="chkClienteEspecialRespetarOfertas">&iquest;Respetar ofertas?</label>
                    <input name="chkClienteEspecialRespetarOfertas" type="checkbox" id="chkClienteEspecialRespetarOfertas" value="True" /></td>
                  <td width="185" class="tdtexttablebold"><label for="chkClienteEspecialPagoDeContado">&iquest;Pago de contado?</label>
                    <input name="chkClienteEspecialPagoDeContado" type="checkbox" id="chkClienteEspecialPagoDeContado" value="True" /></td>
                  <td width="284" class="tdtexttablebold"><label for="chkClienteEspecialExcedidoEnLimiteCreditoND">&iquest;Excedido en l&iacute;mite de cr&eacute;dito?</label>
                    <input name="chkClienteEspecialExcedidoEnLimiteCreditoND" type="checkbox" id="chkClienteEspecialExcedidoEnLimiteCreditoND" value="True" disabled /></td>
                </tr>
              </table></td>
          </tr>
          <tr align="right">
            <td colspan="4" class="txaccion"><img src="images/pixel.gif" width="1" height="10" /></td>
          </tr>
          <tr align="right">
            <td colspan="4" class="txaccion"><img src="images/pixel.gif" width="1" height="10" />Los campos marcados con asterisco (<span class="tdpadleft5"><span class="txrojobold">*</span></span>) son obligatorios.</td>
          </tr>
        </table>
        <p>&nbsp;</p>
        <h2>Tipo de receta a utilizar </h2>
        <table width="60%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="22%" class="tdtexttablebold"><label for="cboClientEspecialTipoFormaCaptura">Tipo de receta:</label></td>
            <td width="78%" class="tdpadleft5"><select name="cboClientEspecialTipoFormaCaptura" class="field" id="cboClientEspecialTipoFormaCaptura">
                <option value="0">--- Elija un tipo ---</option selected>
              </select></td>
          </tr>
        </table>
        <br />
        <input name="cmdCancelar" type="button" class="button" id="cmdCancelar" value="Regresar"  language=javascript onClick="return cmdCancelar_onclick()"/>
&nbsp;&nbsp;
        <input name="cmdGuardar" type="submit" class="button" id="cmdGuardar" value="Guardar"  language=javascript onClick="return cmdGuardar_onclick()"/>
        <br />
        <br />
        <%= strGetRecordBrowserHTML() %> <br />
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
  <script language="JavaScript">
    <!-- // create calendar object(s) just after form tag closed
    var cal1 = new calendar(null, document.forms['frmPage'].elements['txtClienteEspecialVigencia']);
    //-->
</script>
</form>
</body>
</html>
