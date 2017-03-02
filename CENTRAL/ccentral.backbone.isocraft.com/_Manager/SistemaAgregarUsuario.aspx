<%@ Page CodeBehind="SistemaAgregarUsuario.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaAgregarUsuario" Explicit="True" Trace="False" Strict="True" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=Windows-1252">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" src="js/calendario.js"></script>
<script language="JavaScript" src="js/cal_format00.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" type="text/JavaScript" id="clientEventHandlersJS">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  document.forms[0].elements["txtCmd"].value = "<%= strCmd %>";
  document.forms[0].elements["txtUsuarioId"].value = "<%= intUsuarioId %>";
  document.forms[0].elements["txtEmpleadoNombre"].value = "<%= strEmpleadoNombre %>";
  document.forms[0].elements["txtUsuarioNombre"].value = "<%= intEmpleadoId %>";
  document.forms[0].elements["txtUsuarioContrasena"].value = "<%= strUsuarioContrasena %>";
  document.forms[0].elements["txtUsuarioExpiracion"].value = "<%= dtmUsuarioExpiracion.ToString("dd/MM/yyyy") %>";
  <% if blnUsuarioAlcance = 1 then %>
    document.forms[0].elements["chkUsuarioAlcance"].checked = true;
  <%end if%>
  if (<%= blnUsuarioBloqueado %> == 1) {
    document.forms[0].elements['optCuentaBloqueada'][0].checked = true;
  } else {
    document.forms[0].elements['optCuentaBloqueada'][1].checked = true;
  }
<%= strJavascriptWindowOnLoadCommands() %>
<%= strLlenarGrupoComboBox() %>
}

function cmdBuscarEmpleado_onclick() {
    var strEmpleado = document.forms[0].elements["txtEmpleadoNombre"].value;
    return Pop("popSistemaBuscarEmpleado.aspx?strEmpleado=" + strEmpleado,"400","548")
}

function blnFormValidator(theForm) {

  var blnReturn = false;

  /* Validación del campo "txtUsuarioNombre" */
  if (blnValidarCampo(document.forms[0].elements["txtUsuarioNombre"], true, "Empleado", cintTipoCampoAlfanumerico, 20, 1, "") == true) {

    /* Validación del campo "txtContraseña" */
    if(blnValidarCampo(document.forms[0].elements["txtUsuarioContrasena"], true, "Contraseña", cintTipoCampoAlfanumerico, 35, 1, "") == true){

      blnReturn = blnValidarCampo(document.forms[0].elements["txtUsuarioExpiracion"],true,"Fecha de Expiración",cintTipoCampoFecha,10,10,"");
    }
  } 

  if(blnReturn == true){
    if(document.forms[0].elements["cboGrupoUsuario"].selectedIndex == 0){
      blnReturn = false;
      alert("Es necesario seleccionar un Grupo \n\r para realizar la operación del usuario");
      document.forms[0].elements["cboGrupoUsuario"].focus();
    }
  }

  return (blnReturn);
}

function cmdNavegadorRegistrosAgregar_onclick(intEmpleadoId,strEmpleadoNombre,intGrupoId) {
  if((document.forms[0].elements["cboGrupoUsuario"].selectedIndex > 0) && document.forms[0].elements["cboGrupoUsuario"].selectedIndex > 0){
      var strGrupoUsuarioNombre = document.forms[0].elements["cboGrupoUsuario"].options[document.forms[0].elements["cboGrupoUsuario"].selectedIndex].text;
      return Pop("popSistemaVincularSucursalUsuario.aspx?intEmpleadoId=" + intEmpleadoId + "&strEmpleadoNombre=" + strEmpleadoNombre + "&intGrupoId=" + intGrupoId + "&strGrupoUsuarioNombre=" + strGrupoUsuarioNombre,"400","600")
  }
  else{
    alert("Es necesario selecionar un Grupo de Usuario \n\r para vincular sucursales");
  }    
}

function cmdCancelar_onclick() {
    window.location.href = "SistemaAdministrarUsuarios.aspx";;
}

function txtUsuarioContrasena_onchange() {
  document.forms[0].elements["txtActualizarContrasena"].value = "True";
  return(true);
}

</script>
</head>
<body onLoad="return window_onload();">
<form name="frmAgregarUsuario" method="post" onSubmit="return blnFormValidator(this)">
  <input type="hidden" name="txtSucursales">
  <input type="hidden" name="txtCmd">
  <input type="hidden" name="txtUsuarioId">
  <input type="hidden" name="txtActualizarContrasena" />
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : Sistema : Administrar usuarios : Asignar usuario </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Asignar usuario </h1>
        <p>Llene los campos necesarios para crear/editar el usuario elegido. </p>
        <h2>Datos del usuario</h2>
        <table border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="tdtexttablebold">Empleado:</td>
            <td class="tdcontentableblue"><span class="tdpadleft5">
              <input name="txtEmpleadoNombre" type="text" class="field" id="txtEmpleadoNombre" size="50"
                                            maxlength="50">
              &nbsp;
              <input name="cmdBuscarEmpleado" type="button" class="button" id="cmdBuscarEmpleado" value="Buscar empleado"
                                            onClick="cmdBuscarEmpleado_onclick();">
              </span></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Nombre de usuario:</td>
            <td class="tdcontentableblue"><span class="tdpadleft5">
              <input name="txtUsuarioNombre" type="text" class="fieldborderless" id="txtUsuarioNombre" size="35"
                                            maxlength="35" readonly>
              </span> </td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Contraseña:</td>
            <td class="tdpadleft5"><input name="txtUsuarioContrasena" type="password" class="field" id="txtUsuarioContrasena"
                                        size="35" maxlength="35" language="javascript" onChange="return txtUsuarioContrasena_onchange()"></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Grupo:</td>
            <td class="tdpadleft5"><select name="cboGrupoUsuario" class="field" id="cboGrupoUsuario">
                <option selected>Elija un grupo</option>
              </select></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Estatus: </td>
            <td class="tdtexttablereg"><input name="chkUsuarioHabilitado" type="radio" value="1" checked>
              Habilitado&nbsp;&nbsp;&nbsp;
              <input name="chkUsuarioHabilitado" type="radio" value="0">
              Deshabilitado</td>
          </tr>
          <tr>
            <td class="tdtexttablebold">&iquest;Cuenta bloqueada? </td>
            <td class="tdtexttablereg"><input name="optCuentaBloqueada" type="radio" value="1" />
              S&iacute;&nbsp;
              <input name="optCuentaBloqueada" type="radio" value="0" />
              No</td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Fecha de expiración :&nbsp;&nbsp;&nbsp; </td>
            <td class="tdpadleft5"><input name="txtUsuarioExpiracion" id="txtUsuarioExpiracion" class="field" size="12" maxlength="12"
                                        type="text">
              <a href="javascript:cal1.popup()"><img src="images/imgCalendarIcon.gif" width="16" height="15" border="0" align="absMiddle"></a></td>
          </tr>
          <tr>
            <td colspan="2" class="tdtexttablebold"><span class="tdtexttablereg">
              <input type="checkbox" name="chkUsuarioAlcance" value="1" disabled>
              Operar sólo en el ámbito del Concentrador Central</span></td>
          </tr>
          <tr class="txaccion">
            <td colspan="2">&nbsp;</td>
          </tr>
        </table>
        <input name="cmdSalvar" type="submit" class="button" id="cmdSalvar" value="Salvar usuario" >
        &nbsp;&nbsp;
        <input name="cmdCancelar" type="button" class="button" id="cmdCancelar" onClick="return cmdCancelar_onclick()" value="Cancelar">
        <br>
        <!-- AQUI VA EL RECORDBROWSER -->
        <%=strRecordBrowserHTML%> <br>
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
    var cal1 = new calendar(null, document.forms[0].elements['txtUsuarioExpiracion']);
    //-->
  </script>
</form>
</body>
</html>
