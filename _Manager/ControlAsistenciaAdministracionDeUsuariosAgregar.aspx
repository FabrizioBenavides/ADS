<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsistenciaAdministracionDeUsuariosAgregar.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistenciaAdministracionDeUsuariosAgregar" %>

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

    function trim(stringToTrim) {
        return stringToTrim.replace(/^\s+|\s+$/g, "");
    }

    function txtEmpleadoNombre_onKeyPress(e) {

        //No se permiten caracteres especiales ni letras.
        var key = window.event ? e.keyCode : e.which;
        if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || key == 13 || key == 32) {
            return true;
        }
        else {
            return false
        }
    }
    
    function txtUsuarioContrasena_onKeyPress(e) {

        //No se permiten caracteres especiales ni letras.
        var key = window.event ? e.keyCode : e.which;
        if ((key > 47 && key < 58) || (key > 64 && key < 91) || (key > 96 && key < 123) || key == 13) {
            return true;
        }
        else {
            return false
        }
    }

    function cmdBuscarEmpleado_onclick() {
        var strEmpleado = trim(document.forms[0].elements["txtEmpleadoNombre"].value);

        if (strEmpleado == ''){
            return (false);
        }

        return Pop("popSistemaBuscarEmpleado.aspx?strEmpleado=" + strEmpleado,"400","548")
    }

    function blnFormValidator(theForm) {

        var blnReturn = false;
        
        /* Validación del campo "Empleado" */
        if(trim(document.getElementById("txtEmpleadoNombre").value) == ''){
            alert('Seleccione un empleado por favor');
            return (false);
        }

        
        /* Validación del campo "txtUsuarioNombre" */
        if (blnValidarCampo(document.forms[0].elements["txtUsuarioNombre"], true, "Empleado", cintTipoCampoAlfanumerico, 20, 1, "") == true) {

            /* Validación del campo "txtContraseña" */
            if(blnValidarCampo(document.forms[0].elements["txtUsuarioContrasena"], true, "Contraseña", cintTipoCampoAlfanumerico, 35, 1, "") == true){

                blnReturn = blnValidarCampo(document.forms[0].elements["txtUsuarioExpiracion"],true,"Fecha de Expiración",cintTipoCampoFecha,10,10,"");
            }
        } 

        if(blnReturn == true){
            if(document.forms[0].elements["cboGrupoUsuario"].value == 0){
                
                blnReturn = false;
                alert("Es necesario seleccionar un Grupo \n\r para realizar la operación del usuario");
                
                document.forms[0].elements["cboGrupoUsuario"].focus();
            }
        }

        return (blnReturn);
    }

    


    //function cmdNavegadorRegistrosAgregar_onclick(intEmpleadoId,strEmpleadoNombre,intGrupoId) {
    function cmdNavegadorRegistrosAgregar_onclick() {

        var intEmpleadoId = trim(document.getElementById('txtUsuarioNombre').value);
        var strEmpleadoNombre = trim(document.getElementById('txtEmpleadoNombre').value);
        var intGrupoId = trim(document.getElementById('cboGrupoUsuario').value);
        

        //Si el usuario no esta creado no se puede asignar
        if("<%=intUsuarioExistenteId()%>" != 1){
        
            return (false);
        }


        //if((document.forms[0].elements["cboGrupoUsuario"].selectedIndex > 0) && document.forms[0].elements["cboGrupoUsuario"].selectedIndex > 0){
        //if((document.forms[0].elements["cboGrupoUsuario"].value > 0) && document.forms[0].elements["cboGrupoUsuario"].value > 0){
        if((intEmpleadoId > 0) && (strEmpleadoNombre != '') && (intGrupoId > 0)){

            if (blnReturn = fnValidaFechas("txtUsuarioExpiracion") == false){
                return (false);
            }


            var strGrupoUsuarioNombre = document.forms[0].elements["cboGrupoUsuario"].options[document.forms[0].elements["cboGrupoUsuario"].selectedIndex].text;
            //return Pop("popSistemaVincularSucursalUsuario.aspx?intEmpleadoId=" + intEmpleadoId + "&strEmpleadoNombre=" + strEmpleadoNombre + "&intGrupoId=" + intGrupoId + "&strGrupoUsuarioNombre=" + strGrupoUsuarioNombre,"400","600")
            
            return Pop("ControlAsistenciaAsignarSucursales.aspx?intEmpleadoId=" + intEmpleadoId + "&strEmpleadoNombre=" + strEmpleadoNombre + "&intGrupoId=" + intGrupoId + "&strGrupoUsuarioNombre=" + strGrupoUsuarioNombre,"400","600")
        }
        else{
            //alert("Es necesario selecionar un Grupo de Usuario \n\r para vincular sucursales");
            alert("Es necesario crear el usuario \n\r para realizar esta operación.");
        }    
    }

    //Validacion de fechas.
    function fnValidaFechas(dtmFechaFin) {
        valida = true;

        //Validacion de Fecha final
        if (valida) {
            //valida = blnValidarCampo(document.getElementById(dtmFechaFin), true, "Fecha Final", cintTipoCampoFecha, 10, 10, "");
            valida = blnValidarCampo(document.getElementById(dtmFechaFin),true,"Fecha de Expiración",cintTipoCampoFecha,10,10,"");

            //Valida que la fecha inicial NO sea mayor que la fecha final.	
            if (valida) {

                //Fecha final
                var dtmFin = document.getElementById(dtmFechaFin).value;
                var diaFin = dtmFin.substring(0, 2)
                var mesFin = dtmFin.substring(3, 5);
                var anioFin = dtmFin.substring(6, 10);

                //Fecha hoy
                var dtmActual = document.getElementById("dtmFechaActual").value;
                var diaActual = dtmActual.substring(0, 2);
                var mesActual = dtmActual.substring(3, 5);
                var anioActual = dtmActual.substring(6, 10);

                //Validacion
                var date2 = (anioFin + mesFin + diaFin);
                var date3 = (anioActual + mesActual + diaActual);

                if (date3 > date2) {
                    alert('Solo se puede asignar sucursales a usuarios activos');
                    return (false);
                }
            }
        }

        return (valida);
    }

    function cmdCancelar_onclick() {
        //window.location.href = "SistemaAdministrarUsuarios.aspx";;
        window.location.href = "ControlAsistenciaAdministracionDeUsuarios.aspx";
    }

    function txtUsuarioContrasena_onchange() {
        document.forms[0].elements["txtActualizarContrasena"].value = "True";
        return(true);
    }

    function fnRespuestaAsignacionSucursal(intExito, intAsignada){
        if(intAsignada = 1 && intExito == 1){
            alert('Sucursal asignada a otro Coordinador, de cualquier forma se asigno correctamente.');
        }
    }

    function doSubmit(c, t, p) {
        if (p == null) {
            p = document.getElementById('txtCurrentPage').value;
        }
        else {
            document.getElementById('txtCurrentPage').value = p;
        }
        document.forms[0].action =
            '<%= strThisPageName%>?pager=true&p=' + p;
        //'<= strThisPageName%>?strCmd=cmdConsultar&pager=true&p=' + p;

        //document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
    }

    function cmdDesasignarSucursal_onclick(intCompaniaId, intSucursalId, intDireccionOperativaId, intEmpleadoId, intUsuarioId){

        //alert(intCompaniaId);
        //alert(intSucursalId);
        //alert(intEmpleadoId );
        //alert(intUsuarioId);
        if(intCompaniaId == -1 && intSucursalId == -1){
            var confirmar = confirm('Desea eliminar toda la region ' + intDireccionOperativaId)

            if (confirmar != true){

                return(false);
            }
        }

        ////ControlAsistenciaAdministracionDeUsuariosAgregar.aspx?strCmd=Desasignar&intCompaniaId=14&intSucursalId=12&intEmpleadoId=78375&intUsuarioId=100000089"
        window.location.href = 'ControlAsistenciaAdministracionDeUsuariosAgregar.aspx?strCmd=Desasignar&intCompaniaId=' + intCompaniaId + '&intSucursalId=' + intSucursalId + '&intDireccionOperativaId=' + intDireccionOperativaId + '&intEmpleadoId=' + intEmpleadoId + '&intUsuarioId=' + intUsuarioId;
    }

</script>
</head>
<body onLoad="return window_onload();">
<form name="frmAgregarUsuarioControlAsistencia" method="post" onSubmit="return blnFormValidator(this)">
  <input type="hidden" name="txtSucursales">
  <input type="hidden" name="txtCmd">
  <input type="hidden" name="txtUsuarioId">
  <input type="hidden" name="txtActualizarContrasena" />
  <input type="hidden" id="dtmFechaActual" name="dtmFechaActual" value='<%= strFechaActual()%>' /> 
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : Sucursal : Control de Asistencia : Administrar usuarios : Asignar usuario </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Asignar usuario </h1>
        <p>Llene los campos necesarios para crear/editar el usuario elegido de Control de Asistencia. </p>
        <h2>Datos del usuario</h2>
        <table border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="tdtexttablebold">Empleado:</td>
            <td class="tdcontentableblue"><span class="tdpadleft5">
              <input name="txtEmpleadoNombre" type="text" class="field" id="txtEmpleadoNombre" size="50"
                                            maxlength="50" onKeyPress=" return txtEmpleadoNombre_onKeyPress(event);">
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
                                        size="35" maxlength="35" language="javascript" onChange="return txtUsuarioContrasena_onchange()" onKeyPress=" return txtUsuarioContrasena_onKeyPress(event);"></td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Grupo:</td>
            <td class="tdpadleft5"><select name="cboGrupoUsuario" class="field" id="cboGrupoUsuario">
                <%--<option selected>Elija un grupo</option>--%>
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
        <input name="cmdSalvar" type="submit" class="button" id="cmdSalvar" value="Guardar usuario" >
        &nbsp;&nbsp;
        <input name="cmdNavegadorRegistrosAgregar" class="boton" id="cmdNavegadorRegistrosAgregar" onclick="cmdNavegadorRegistrosAgregar_onclick();" type="button" value="Vincular sucursales"/>
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
    var cal1 = new calendar(null, document.forms[0].elements['txtUsuarioExpiracion']);
    //-->
  </script>
  <script language="JavaScript">
      //alert((trim(document.getElementById('txtUsuarioId').value));
      //if(trim(document.getElementById('txtUsuarioId').value) != '0'){
      //    document.getElementById('cmdNavegadorRegistrosAgregar').style.display = 'none'
      //}
      //else{
      //    document.getElementById('cmdNavegadorRegistrosAgregar').style.display = 'block'
      //}
      
      if("<%= intUsuarioId %>" != "0"){

          document.getElementById('cmdBuscarEmpleado').style.display = 'none'
      }      
      //else{

      //    document.getElementById('cmdBuscarEmpleado').style.display = 'block'
      //}
  </script>
</form>
</body>
</html>
