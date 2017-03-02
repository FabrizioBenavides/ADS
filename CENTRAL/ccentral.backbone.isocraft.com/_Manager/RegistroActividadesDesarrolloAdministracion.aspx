<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RegistroActividadesDesarrolloAdministracion.aspx.vb" Inherits="com.isocraft.backbone.ccentral.RegistroActividadesDesarrolloAdministracion" %>

<html>
<head>
<title>Benavides : Administracion de Actividades</title>
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

        <%= LlenarComboClasificacion()%>

        var _intActivaId = "<%= Request.Form("cboActiva")%>";
        
        if (_intActivaId != '') {
            document.getElementById('cboActiva').value = _intActivaId;
        }
    }

    function cmdElegirSucursales_onclick() {
        var strSucursalNombre = document.forms[0].elements["txtSucursalNombre"].value;
        return Pop("popSistemaBuscarSucursalUsuario.aspx?strSucursalNombre=" + strSucursalNombre, "360", "548")
    }

    function blnFormValidator() {

        var theForm = document.forms[0];
        var blnReturn = false;

        if (document.getElementById('cboClasificacion').selectedIndex == '0') {
        
            alert('Seleccione la clasificacion');
            return blnReturn;
        }

        return (true);
    }

    function cmdRealizarConsulta_onclick() {

        if (blnFormValidator()) {

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultarActividad'
            document.forms[0].target = '_self';
            document.forms[0].submit();

            return true;
            //document.forms[0].submit();
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

    function cmdCambiarEstatus_onclick(intActividadId, intActivaId) {

        var confirmar = confirm('Desea cambiar el estatus de esta actividad?');
        if (confirmar == true) {

            if (intActivaId == 0) {
                strCmd = 'cmdActivar';
            }
            else {
                strCmd = 'cmdDesActivar';

            }

            document.getElementById('hdnActividadId').value = intActividadId;

            document.forms[0].action = '<%= strThisPageName%>?intActividadId=' + intActividadId + '&strCmd=' + strCmd;
            document.forms[0].target = '_self';
            document.forms[0].submit();
        }

        return(false);

    }

    function cmdEditarActividad_onclick(intActividadId, intUsuarioId) {

        window.location.href = 'RegistroActividadesDesarrolloAlta.aspx?strCmd=cmdEditar&intActividadId=' + intActividadId + '&intUsuarioId=' + intUsuarioId;
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

        //document.forms[0].target = "ifrOculto";
        document.forms[0].submit();
    }

    function cboClasificacion_onchange() {

        document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultarActividad'
        document.forms[0].target = '_self';
        document.forms[0].submit();

        return true;
    }

    function cboActividad_onchange() {

        if (document.getElementById('cboActividad').selectedIndex != 0) {

            document.forms[0].action = '<%= strThisPageName%>?strCmd=cmdConsultarActividadAsignada'
            document.forms[0].target = '_self';
            document.forms[0].submit();
            return (true);
        }
        return (false);
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
    <td width="770" class="tdtab">Est&aacute; en : Central : Registro de Actividades : Desarrollo </td>
  </tr>
</table>
<table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td class="tdgeneralcontent"><h1>Administración de Actividades - Sistemas</h1>
      <p>Aqu&iacute; podr&aacute; dar de alta o modificar actividades de desarrollo que seran asignadas a los recursos. </p>
      <table width="80%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="25%" class="tdtexttablebold">Jefatura:</td>
          <td width="24%" class="tdconttablas"><%= strJefatura()%>
          </td>
          <td width="51%" class="tdpadleft5">&nbsp;</td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Clasificacion :</td>
          <td class="tdpadleft5">
              <select id="cboClasificacion" class="campotabla" name="cboClasificacion" class="campotabla" style="width:150px" >
                                            <option selected="selected" value="-1">&raquo; Seleccione &laquo;</option>
							            </select>
           </td>
          <td class="tdpadleft5"></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Activa:</td>
          <td class="tdpadleft5">
              <select id="cboActiva" class="campotabla" name="cboActiva" class="campotabla" style="width:150px" >
                                            <option selected="selected" value="-1">&raquo; Todas &laquo;</option>
                                            <option value="1">Activas </option>
                                            <option value="0"> Inactivas </option>
							            </select>
           </td>
          <td class="tdpadleft5"></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">&nbsp;</td>
          <td class="tdpadleft5" colspan="2" align="right"><br><br><input name="cmdRealizarConsulta" type="button" class="button" value="Realizar Consulta" onclick="cmdRealizarConsulta_onclick();" >
                                         <input name="cmdAgregarActividad" type="button" class="boton" id="cmdAgregarActividad" onclick="window.location = 'RegistroActividadesDesarrolloAlta.aspx?strCmd=Agregar'"  value="Agregar Actividad"/>
          </td>
        </tr>
      </table>
        <input type="hidden" id="hdnActividadId" name="hdnActividadId"  />
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