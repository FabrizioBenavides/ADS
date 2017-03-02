<%@ Page CodeBehind="SistemaEditarReceta.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaEditarReceta" codePage="1252" EnableSessionState="False" enableViewState="False"%>
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
  document.forms[0].elements["intTipoFormaCapturaId"].value = "<%= intTipoFormaCapturaId %>";
  document.forms[0].elements["intTicketId"].value = "<%= intTicketId %>";
  document.forms[0].elements["intClienteEspecialId"].value = "<%= intClienteEspecialId %>";
  document.forms[0].elements["intCompaniaId"].value = "<%= intCompaniaId %>";
  document.forms[0].elements["intSucursalId"].value = "<%= intSucursalId %>";
  document.forms[0].elements["intCajaId"].value = "<%= intCajaId %>";
<%= strJavascriptWindowOnLoadCommands %>
}

function cmdRegresar_onclick() {
  window.location.href = "SistemaRevisarRecetas.aspx";
}

function strSucursalNombre() {
  document.write("<%= Trim(strSucursalNombre) %>");
}

function strClienteEspecial() {
  document.write("<%= Trim(strClienteEspecial) %>");
}

function strDetalleFormaCapturaUltimaModificacion() {
  document.write("<%= strDetalleFormaCapturaUltimaModificacion %>");
}

function cmdGuardar_onclick() {
<%= strFormValidatorJavascript %>
  document.forms[0].action += "?strCmd=Salvar";
  return (true);
}

function blnFieldValidator(objSourceControl, strSourceControlName, strSourceControlType, strValidCharacters, intMinLength, intMaxLength, intMinValue, intMaxValue) {

  if (objSourceControl.value == "")
  {
    alert("Por favor introduzca un valor en el campo \"" + strSourceControlName + "\".");
    objSourceControl.focus();
    return (false);
  }

  if (objSourceControl.value.length < 1)
  {
    alert("Por favor introduzca al menos un caracter en el campo \"" + strSourceControlName + "\".");
    objSourceControl.focus();
    return (false);
  }

  if (objSourceControl.value.length > intMaxLength)
  {
    alert("Por favor introduzca a lo más " + intMaxLength + " caracteres en el campo \"" + strSourceControlName + "\".");
    objSourceControl.focus();
    return (false);
  }

  var checkOK = strValidCharacters;
  var checkStr = objSourceControl.value;
  var allValid = true;
  for (i = 0;  i < checkStr.length;  i++)
  {
    ch = checkStr.charAt(i);
    for (j = 0;  j < checkOK.length;  j++)
      if (ch == checkOK.charAt(j))
        break;
    if (j == checkOK.length)
    {
      allValid = false;
      break;
    }
  }
  if (!allValid)
  {
    alert("Por favor introduzca únicamente los siguientes caractéres el campo \"" + strSourceControlName + "\":\n\r\n\r" + strValidCharacters + "\n\r\n\r");
    objSourceControl.focus();
    return (false);
  }

  var chkVal = objSourceControl.value;
  var prsVal = chkVal;
  
  if (strSourceControlType == "NumeroEntero" || strSourceControlType == "NumeroDecimal") {
    if (chkVal != "" && !(prsVal >= intMinValue && prsVal <= intMaxValue))
    {
      alert("Por favor introduzca un valor mayor o igual a \"" + intMinValue + "\" y menor o igual que \"" + intMaxValue + "\" en el campo \"" + strSourceControlName + "\".");
      objSourceControl.focus();
      return (false);
    }
  }
      
  if (strSourceControlType == "Fecha") {
              
    var formato=/^[0-9]{2}[/]{1}[0-9]{2}[/]{1}[0-9]{4}$/;
    if(formato.test(objSourceControl.value) == false) {
      alert("Por favor introduzca un valor con el formato \"dd/mm/aaaa\".");
      objSourceControl.focus();   
      return (false);
    }
          
    if (blnValidarCampo(objSourceControl, true, strSourceControlName, cintTipoCampoFecha, 10, 10, '') == false) {
      objSourceControl.focus();
      return (false);
    }
              
    var intFechaCapturada = objSourceControl.value.substring(6, 10) + objSourceControl.value.substring(3, 5) + objSourceControl.value.substring(0, 2);
       
    if (intMinValue.length > 0 && (intFechaCapturada < intMinValue) ) {
      alert("Por favor introduzca un valor mayor o igual a \"" + intMinValue.substring(6,8) + "/" + intMinValue.substring(4,6) + "/" + intMinValue.substring(0,4) + "\".");
      objSourceControl.focus();
      return (false);                          
    }
    
    if (intMaxValue.length > 0 && (intFechaCapturada > intMaxValue) ) {           
       alert("Por favor introduzca un valor menor o igual a \"" + intMaxValue.substring(6,8) + "/" + intMaxValue.substring(4,6) + "/" + intMaxValue.substring(0,4) + "\".");
       objSourceControl.focus();
       return (false);                          
    }
  }
  
  return (true);
}

//-->
</script>
</head>
<body language=javascript onload="return window_onload()">
<form method="POST" action="about:blank" name="frmPage">
  <input type="hidden" name="intTicketId" />
  <input type="hidden" name="intClienteEspecialId" />
  <input type="hidden" name="intCompaniaId" />
  <input type="hidden" name="intSucursalId" />
  <input type="hidden" name="intCajaId" />
  <input type="hidden" name="intTipoFormaCapturaId" />
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : <a href="sistema.aspx">Sistema</a> : <a href="sistemaclientesespeciales.aspx">Clientes especiales</a> : <a href="SistemaRevisarRecetas.aspx">Revisar recetas</a> : Editar receta </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Editar receta </h1>
        <p>Aqu&iacute; podr&aacute; modificar las recetas que fueron dadas de alta por los puntos de venta. </p>
        <p class="txredregular">*Los atributos marcados con asterisco contienen errores que deben ser corregidos.</p>
        <table width="80%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="tdtexttablebold">Fecha y hora: </td>
            <td class="tdcontentableblue"><script language="javascript">strDetalleFormaCapturaUltimaModificacion()</script></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Sucursal:</td>
            <td class="tdcontentableblue"><script language="javascript">strSucursalNombre()</script></td>
          </tr>
          <tr>
            <td width="20%" class="tdtexttablebold">N&uacute;mero de cliente:</td>
            <td width="80%" class="tdcontentableblue"><script language="javascript">strClienteEspecial()</script></td>
          </tr>
          <%= strHTMLAtributosDetalleFormaCaptura %>
        </table>
        <br />
        <input name="cmdRegresar" type="button" class="button" id="cmdRegresar" value="Regresar"  language=javascript onclick="return cmdRegresar_onclick()"/>
&nbsp;&nbsp;
        <input name="cmdGuardar" type="submit" class="button" id="cmdGuardar" value="Guardar cambios" language=javascript onclick="return cmdGuardar_onclick()"/>
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
