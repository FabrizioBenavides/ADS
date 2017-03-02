<%@ Page CodeBehind="SistemaEmpresasRecolectorasEditarEmpresa.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaEmpresasRecolectorasEditarEmpresa" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
<script id="clientEventHandlersJS" language="javascript">
<!--
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
    document.forms[0].action = "<%= strFormAction %>";
    document.forms[0].elements["intEmpresaValoresId"].value = "<%= intEmpresaValoresId %>";
    document.forms[0].elements["dtmEmpresaValoresAlta"].value = "<%= dtmEmpresaValoresAlta %>";
    document.forms[0].elements["txtEmpresa"].value = "<%= strtxtEmpresa %>";
    document.forms[0].elements["txtContacto"].value = "<%= strtxtContacto %>";
    document.forms[0].elements["txtTelefono"].value = "<%= strtxtTelefono %>";
    document.forms[0].elements["chkEmpresaHabilitada"].checked = <%= blnchkEmpresaHabilitada.ToString().ToLower() %>;
}

function FechaActual() {
	document.write("<%= dtmEmpresaValoresAlta.ToString("dd/MM/yyyy") %>");
}

function blnFormValidator() {

  var blnReturn = false;
  
  /* Validación del campo "txtEmpresa" */
  if(blnValidarCampo(document.forms[0].elements["txtEmpresa"], true, "Empresa", cintTipoCampoAlfanumerico, 45, 1, "") == true) {
  
	/* Validación del campo "txtContacto" */
    if(blnValidarCampo(document.forms[0].elements["txtContacto"], true, "Contacto", cintTipoCampoAlfanumericoExtendido, 35, 1, "") == true) {

        /* Validación del campo "txtTelefono" */
        blnReturn = blnValidarCampo(document.forms[0].elements["txtTelefono"], true, "Telefono", cintTipoCampoAlfanumericoExtendido, 20, 1, "");

      }
      
    }
  
  return (blnReturn);
}

function cmdRegresar_onclick() {
 window.location.href = "SistemaEmpresasRecolectorasAdministrarEmpresasRecolectoras.aspx?intNavegadorRegistrosPagina=<%=intPagina%>";
}

function cmdAgregar_onclick() {
 var blnReturn = blnFormValidator();
  if (blnReturn == true) {
	   document.forms[0].action = "SistemaEmpresasRecolectorasEditarEmpresa.aspx?strCmd=Agregar";
  }
 return (blnReturn);
}

//-->
</script>
</head>
<body language="javascript" onLoad="return window_onload()">
<form name="frmMain" action="about:blank" method="post">
  <input type="hidden" name="intEmpresaValoresId">
  <input type="hidden" name="dtmEmpresaValoresAlta">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <a href="Sistema.aspx">Sistema</a> : <a href="SistemaEmpresasRecolectoras.aspx"> Empresas recolectoras</a> : <a href="SistemaEmpresasRecolectorasAdministrarEmpresasRecolectoras.aspx"> Administrar empresas recolectoras</a> : Editar empresa </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Editar empresa </h1>
        <p>En esta parte usted puede dar de alta una nueva empresa o editar la información correspondiente a una empresa recolectora existente. </p>
        <h2>Datos de la empresa </h2>
        <table width="60%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="20%" class="tdtexttablebold">Fecha de alta :</td>
            <td width="80%" class="tdcontentableblue"><script>FechaActual();</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Empresa:</td>
            <td class="tdpadleft5"><input name="txtEmpresa" type="text" class="field" id="txtEmpresa"  size="45" maxlength="45"></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Contacto:</td>
            <td class="tdpadleft5"><input name="txtContacto" type="text" class="field" id="txtContacto"  size="35" maxlength="35"></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Teléfono:</td>
            <td class="tdpadleft5"><input name="txtTelefono" type="text" class="field" id="txtTelefono"  size="20" maxlength="20"></td>
          </tr>
          <tr>
            <td height="10" colspan="2"><img src="images/pixel.gif" width="1" height="10"></td>
          </tr>
          <tr>
            <td colspan="2" class="tdtexttablebold"><input type="checkbox" name="chkEmpresaHabilitada" value="True">
              Empresa habilitada </td>
          </tr>
        </table>
        <br>
        <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar" language=javascript onClick="return cmdRegresar_onclick()">
		&nbsp;&nbsp;
        <input name="cmdAgregar" type="submit" class="button" id="cmdAgregar" value="Salvar los datos" language=javascript onClick="return cmdAgregar_onclick()">
        <br>
        <br>
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
