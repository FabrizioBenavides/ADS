<%@ Page CodeBehind="SistemaComisionesDex.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaComisionesDex" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
    document.forms[0].action = "<%= strFormAction %>";
    document.forms[0].elements["txtComisionesDex"].value = "<%= strtxtComisionesDex %>";
    document.forms[0].elements["txtCuotaFijaComisionDEX"].value = "<%= strtxtCuotaComision %>";
    document.forms[0].elements["txtCuotaFijaAdministracionEmpleadosDEX"].value = "<%= strtxtCuotaAdministracion %>";
    <%= strJavascriptWindowOnLoadCommands %>
}

function blnFormValidator() {

  var blnReturn = false;

  /* Validación del campo "txtAtributoNombre" */
  if(blnValidarCampo(document.forms[0].elements["txtComisionesDex"], true, "Comisiones DEX", cintTipoCampoReal, 8, 1, "") == true) {

    /* Validación del campo "txtAtributoDescripcion" */
    if(blnValidarCampo(document.forms[0].elements["txtCuotaFijaComisionDEX"], true, "Cuota fija de comisión", cintTipoCampoReal, 10, 1, "") == true) {

        /* Validación del campo "txtAtributoValorLongitudMaxima" */
        blnReturn = blnValidarCampo(document.forms[0].elements["txtCuotaFijaAdministracionEmpleadosDEX"], true, "Cuota fija de administración para empleados:", cintTipoCampoReal, 10, 1, "");

    }
    
  }
    
  return (blnReturn);
}

function cmdSalvar_onclick() {
var blnReturn = blnFormValidator();
  if ( blnReturn == true) {
    document.forms[0].action += "?strCmd=Salvar";
  }
  return (blnReturn);
}

//-->
</script>
</head>
<body language=javascript onLoad="return window_onload()"> 
<form method="POST" action="about:blank" name="frmPage">
  <table width="780" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td><script language="JavaScript">crearTablaHeader()</script></td> 
    </tr> 
  </table> 
  <table width="780" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td width="10">&nbsp;</td> 
      <td width="770" class="tdtab">Está en : <a href="Sistema.aspx">Sistema</a> : Comisiones DEX </td> 
    </tr> 
  </table> 
  <table width="780" border="0" cellpadding="0" cellspacing="0"> 
    <tr> 
      <td class="tdgeneralcontent"><h1>Comisiones DEX </h1> 
        <p>En esta parte usted puede consultar y actualizar las comisones relacionadas con las operaciones DEX. </p> 
        <h2>Comisiones</h2> 
        <table width="60%" border="0" cellspacing="0" cellpadding="0"> 
          <tr> 
            <td width="22%" class="tdtexttablebold">Comisiones DEX:</td> 
            <td colspan="3" class="tdcontentableblue"><span class="tdpadleft5"> 
              <input name="txtComisionesDex" type="text" class="field" id="txtComisionesDex" value="10.5"
											size="8" maxlength="8"> 
              </span>%</td> 
          </tr> 
          <tr> 
            <td colspan="2" class="tdtexttablebold">Cuota fija de comisión:</td> 
            <td width="26%" class="tdcontentableblue">$
              <input name="txtCuotaFijaComisionDEX" type="text" class="field" id="txtCuotaFijaComisionDEX" value="15.00"
										size="10" maxlength="10"></td> 
            <td class="tdcontentableblue">&nbsp;</td> 
          </tr> 
          <tr> 
            <td colspan="3" class="tdtexttablebold">Cuota fija de administración para empleados:</td> 
            <td width="43%" class="tdcontentableblue">$
              <input name="txtCuotaFijaAdministracionEmpleadosDEX" type="text" class="field" id="txtCuotaFijaAdministracionEmpleadosDEX"
										value="15.00" size="10" maxlength="10"></td> 
          </tr> 
          <tr> 
            <td height="10" colspan="4"><img src="images/pixel.gif" width="1" height="10"></td> 
          </tr> 
        </table> 
        <br> 
        <input name="cmdSalvar" type="submit" class="button" id="cmdSalvar" value="Salvar comisiones" language=javascript onClick="return cmdSalvar_onclick()"> 
        <br> 
        <br> </td> 
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
