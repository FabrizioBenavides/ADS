<%@ Page CodeBehind="SistemaAdministrarUsuarios.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaAdministrarUsuarios" Explicit="True" Trace="False" Strict="True" codePage="1252" %>

<html>
<head>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" type="text/JavaScript">
	strUsuarioNombre = "<%= strUsuarioNombre %>";
	strFechaHora = "<%= strHTMLFechaHora %>";

	function window_onload() {
		document.forms[0].action = "<%= strThisPageName %>";
		<%= strJavascriptWindowOnLoadCommands %>
		<%= strLlenarGrupoComboBox() %>
	}
	
	function cmdElegirSucursales_onclick() {
		var strSucursalNombre = document.forms[0].elements["txtSucursalNombre"].value;
		return Pop("popSistemaBuscarSucursalUsuario.aspx?strSucursalNombre=" + strSucursalNombre,"360","548")
	}
	
	function blnFormValidator() {
		var theForm = document.forms[0];
  		var blnReturn = false;
  		  		  		
  		if (!(theForm.elements("cboGrupoUsuario").selectedIndex > 0)) {
/*  			if ((!(isNaN(document.forms[0].elements['txtCompaniaId'].value))) && (document.forms[0].elements['txtCompaniaId'].value.length > 0)) {  			
  				blnReturn = blnValidarCampo(document.forms[0].elements["txtEmpleadoId"], true, "Número de empleado", cintTipoCampoEntero, 15, 1, "")
  			} else {
  				alert("Por favor establezca un valor para el campo Sucursal donde trabaja.");
  			}
*/
			alert("Favor de seleccionar un grupo");
			theForm.elements("cboGrupoUsuario").focus();
  		} else {
  			blnReturn = true;
  		}

		return (blnReturn);
	}
	
	function cmdRealizarConsulta_onclick(){
		if (blnFormValidator()) {
			document.forms[0].submit();
		}
	}
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSistemaAdministrarUsuarios" onSubmit="return blnFormValidator(this)">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : Sistema : Administrar usuarios </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Administrar usuarios </h1>
      <p>Aqu&iacute; podr&aacute; dar de alta o modificar los datos de un usuario, incluyendo su rol dentro de Benavides. </p>
      <table width="80%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="25%" class="tdtexttablebold">Grupo al que pertenece :</td>
          <td width="24%" class="tdpadleft5"><select name="cboGrupoUsuario" class="field">
              <option>Elija un grupo</option>
            </select>
          </td>
          <td width="51%" class="tdpadleft5">&nbsp;</td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Sucursal donde trabaja :</td>
          <td class="tdpadleft5"><input name="txtSucursalNombre" type="text" class="field" size="25" maxlength="25">
&nbsp;
          <input type="hidden" name="txtCompaniaId">
          <input type="hidden" name="txtSucursalId">
           </td>
          <td class="tdpadleft5"><input name="cmdElegirSucursales" type="button" class="button" value="Buscar sucursal" onClick="cmdElegirSucursales_onclick();" ></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">&nbsp;</td>
          <td class="tdpadleft5" colspan="2"><span id="strInfoSucursal" class="txgreybold"></span></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">N&uacute;mero de empleado </td>
          <td class="tdpadleft5"><input name="txtEmpleadoId" type="text" class="field" size="15" maxlength="12"></td>
          <td class="tdpadleft5">&nbsp;</td>
        </tr>
        <tr>
          <td class="tdtexttablebold">&nbsp;</td>
          <td class="tdpadleft5"><br><br><input name="cmdRealizarConsulta" type="button" class="button" value="Realizar Consulta" onclick="cmdRealizarConsulta_onclick();"></td>
          <td class="tdpadleft5">&nbsp;</td>
        </tr>
      </table>
      <br>
       <%= strRecordBrowserHTML %>
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
