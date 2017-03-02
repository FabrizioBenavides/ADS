<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ControlAsistenciaAdministracionDeUsuarios.aspx.vb" Inherits="com.isocraft.backbone.ccentral.ControlAsistenciaAdministracionDeUsuarios" %>

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
		
	}

    function cmdElegirSucursales_onclick() {
        var strSucursalNombre = document.forms[0].elements["txtSucursalNombre"].value;
        return Pop("popSistemaBuscarSucursalUsuario.aspx?strSucursalNombre=" + strSucursalNombre, "360", "548")
    }

    function blnFormValidator() {
        var theForm = document.forms[0];
        var blnReturn = false;

        //if (!(theForm.elements("cboGrupoUsuario").selectedIndex > 0)) {
        //    /*  			if ((!(isNaN(document.forms[0].elements['txtCompaniaId'].value))) && (document.forms[0].elements['txtCompaniaId'].value.length > 0)) {  			
                            blnReturn = blnValidarCampo(document.forms[0].elements["txtEmpleadoId"], true, "Número de empleado", cintTipoCampoEntero, 15, 1, "")
        //                } else {
        //                    alert("Por favor establezca un valor para el campo Sucursal donde trabaja.");
        //                }
        //    */
        //    alert("Favor de seleccionar un grupo");
        //    theForm.elements("cboGrupoUsuario").focus();
        //} else {
            //blnReturn = true;
        //}

        return (blnReturn);
    }

    function cmdRealizarConsulta_onclick() {
        if (blnFormValidator()) {
            document.forms[0].submit();
        }
    }

    function txtEmpleadoId_onKeyPress(e) {

        //No se permiten caracteres especiales ni letras.
        var key = window.event ? e.keyCode : e.which;
        if (key > 47 && key < 58 || key == 13) {
            return true;
        }
        else {
            return false
        }
    }

    function cmdDeshabilitarUsuario_onclick(intEmpleadoId, intUsuarioId) {

        //var dtmFechaInicio = parent.document.getElementById('dtmFechaIni').value;
        //var dtmFechaFin = parent.document.getElementById('dtmFechaFin').value;

        ////Parametros
        //var strParametros = '?&strEmpleadoId=' + intEmpleadoId + '&strMovimientoId=' + intMovimientoId;
        //strParametros = strParametros + '&dtmFechaInicio=' + dtmFechaInicio + '&dtmFechaFin=' + dtmFechaFin;

        //window.location.href = 'ControlAsistenciaDetalle.aspx' + strParametros;


        window.location.href = 'ControlAsistenciaAdministracionDeUsuarios.aspx?strCmd=Desasignar&intEmpleadoId=' + intEmpleadoId + '&intUsuarioId=' + intUsuarioId; 

    }

    function cmdEditarUsuario_onclick(intEmpleadoId, intUsuarioId) {

        window.location.href = 'ControlAsistenciaAdministracionDeUsuarios.aspx?strCmd=Editar&intEmpleadoId=' + intEmpleadoId + '&intUsuarioId=' + intUsuarioId;
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

</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSistemaAdministrarUsuariosControlAsistencia" onSubmit="return blnFormValidator(this)">
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeader()</script></td>
  </tr>
</table>
<table width="780" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="10">&nbsp;</td>
    <td width="770" class="tdtab">Est&aacute; en : Sucursal : Control de Asistencia : Administrar usuarios </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Administrar usuarios de control de asistencia</h1>
      <p>Aqu&iacute; podr&aacute; dar de alta o modificar los datos de un usuario de Control de Asistencia, ademas de asignarle sucursales. </p>
      <table width="80%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="25%" class="tdtexttablebold">Grupo:</td>
          <td width="24%" class="tdconttablas">Control de Asistencia<%--<select name="cboGrupoUsuario" class="field">
              <option>Elija un grupo</option>
            </select>--%>
          </td>
          <td width="51%" class="tdpadleft5">&nbsp;</td>
        </tr>
        <%--<tr>
          <td class="tdtexttablebold">Sucursal asignada :</td>
          <td class="tdpadleft5"><input name="txtSucursalNombre" type="text" class="field" size="25" maxlength="25">
&nbsp;
          <input type="hidden" name="txtCompaniaId">
          <input type="hidden" name="txtSucursalId">
           </td>
          <td class="tdpadleft5"><input name="cmdElegirSucursales" type="button" class="button" value="Buscar sucursal" onClick="cmdElegirSucursales_onclick();" ></td>
        </tr>--%>
        <%--<tr>
          <td class="tdtexttablebold">&nbsp;</td>
          <td class="tdpadleft5" colspan="2"><span id="strInfoSucursal" class="txgreybold"></span></td>
        </tr>--%>
        <tr>
          <td class="tdtexttablebold">N&uacute;mero de empleado: </td>
          <td class="tdpadleft5"><input name="txtEmpleadoId" type="text" class="field" size="15" maxlength="12" onKeyPress=" return txtEmpleadoId_onKeyPress(event);"></td>
          <td class="tdpadleft5">&nbsp;</td>
        </tr>
        <tr>
          <td class="tdtexttablebold">&nbsp;</td>
          <td class="tdpadleft5" colspan="2"><br><br><input name="cmdRealizarConsulta" type="button" class="button" value="Realizar Consulta" onclick="cmdRealizarConsulta_onclick();" >
                                         <input name="cmdNavegadorRegistrosAgregar" type="button" class="boton" id="cmdNavegadorRegistrosAgregar" onclick="window.location = 'ControlAsistenciaAdministracionDeUsuarios.aspx?strCmd=Agregar'"  value="Agregar Usuario"/>
          </td>
          <%--<td class="tdpadleft5">&nbsp;</td>--%>
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
    new menu(MENU_ITEMS, MENU_POS);
    //-->
</script>
</form>
</body>
</html>
