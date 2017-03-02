<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PopSistemaCambiarContrasena.aspx.vb" Inherits="com.isocraft.backbone.ccentral.PopSistemaCambiarContrasena" Explicit="True" Trace="False" Strict="True" CodePage="1252" EnableSessionState="False" EnableViewState="False" %>
<html>
<head>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/headerfooterAdmin.js"></script>
<title>Benavides</title>
<script id="clientEventHandlersJS" language="javascript">

        function window_onload() {
            document.getElementById("txtUsuario").focus();
            validarMostrarMensajeActualizacion();
        }

        function validarMostrarMensajeActualizacion() {
            var tipoActualizacionContrasena = "<%= ResultadoActualizacionContrasena%>";
            var mensajeErrorEtiqueta;

            if (tipoActualizacionContrasena == "1") {
                window.alert("Contraseña cambiada correctamente.");
                window.close();
            }
            else if (tipoActualizacionContrasena == "2") {
                mensajeErrorEtiqueta = document.getElementById("mensajeErrorEtiqueta");
                mensajeErrorEtiqueta.innerHTML = "<%= strMensajeContrasenaInvalida%>";
                mensajeErrorEtiqueta.style.display = "inline";
            }
        }

        function btnCancelar_onclick() {
            window.close();
        }

        function btnGuardar_onclick() {
            var mensajeErrorEtiqueta;
            var txtUsuario = document.getElementById('txtUsuario').value;
            var txtUsuarioContrasena = document.getElementById('txtUsuarioContrasena').value;
            var txtUsuarioContrasenaNueva = document.getElementById('txtUsuarioContrasenaNueva').value;
            var txtUsuarioConfirmarContrasenaNueva = document.getElementById('txtUsuarioConfirmarContrasenaNueva').value;

            if (!validarCamposVacios(txtUsuario, txtUsuarioContrasena, txtUsuarioContrasenaNueva, txtUsuarioConfirmarContrasenaNueva)) {

                document.forms[0].action = "PopSistemaCambiarContrasena.aspx?strCmd=Editar" +
                                           "&strUsuarioNombre=" + txtUsuario +
                                           "&strUsuarioContrasena=" + txtUsuarioContrasena +
                                           "&strUsuarioContrasenaNueva=" + txtUsuarioContrasenaNueva +
                                           "&strUsuarioConfirmarContrasenaNueva=" + txtUsuarioConfirmarContrasenaNueva;

                document.forms(0).submit();
            }
            else {
                mensajeErrorEtiqueta = document.getElementById("mensajeErrorEtiqueta");
                mensajeErrorEtiqueta.innerHTML = "Faltan campos por llenar.";
                mensajeErrorEtiqueta.style.display = "inline";
            }
        }

        function validarCamposVacios(txtUsuario, txtUsuarioContrasena, txtUsuarioContrasenaNueva, txtUsuarioConfirmarContrasenaNueva) {
            var hayCamposVacios = false;
            
            if (txtUsuario == "" ||
                txtUsuarioContrasena == "" ||
                txtUsuarioContrasenaNueva == "" ||
                txtUsuarioConfirmarContrasenaNueva == "") {
                hayCamposVacios = true;
            }

            return hayCamposVacios;
        }
function cmdCerrar_onclick() {	
	window.close();	
	return(true);
}
    </script>
</head>
<body bgcolor="#ffffff" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0" onload="return window_onload()">
<form id="frmCambioContrasena" name="frmCambioContrasena" method="POST" >
  <table height="80" cellspacing="0" cellpadding="0" width="560" bgcolor="#ffffff" border="0">
    <tr> 
      <td class="tdlogopop" height="18" width="90%"> <img height="54" src="../static/images/logo_pop.gif"></td>
      <td width="10%"><input name="cmdCerrar" type="submit" class="boton" id="cmdCerrar" value="Cerrar" onclick="return cmdCerrar_onclick()"> 
    </tr>
    <tr> 
      <td width="100%" colspan="2" height="2">&nbsp;</td>
    </tr>
  </table>
  <table width="560" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td width="2%">&nbsp;</td>
      <td  width="98%"class="tdgeneralcontentpop"> <h2>Cambio de Contraseña</h2>
        <p>La nueva contraseña debe contener al menos 5 caracteres, los cuales 
          al menos debe de haber 1 letra, 1 digito y 1 caracter especial (!¡?¿*-+{}[],.-@#$%&/()|_<>)</p>
        <table width="85%" border="0" cellspacing="0" cellpadding="0">
          <tr> 
            <td width="40%" class="tdtexttablebold">Usuario:</td>
            <td width="60%" valign="middle" class="tdpadleft5" align="left"> <input name="txtUsuario" type="text" class="campotabla" id="txtUsuario" size="15" maxlength="15" autocomplete="off"> 
            </td>
          </tr>
          <tr> 
            <td width="40%" class="tdtexttablebold">Contraseña:</td>
            <td width="60%" valign="middle" class="tdpadleft5" align="left"> <input name="txtUsuarioContrasena" type="password" class="campotabla" id="txtUsuarioContrasena" size="15" maxlength="15"> 
            </td>
          </tr>
          <tr> 
            <td width="40%" class="tdtexttablebold">Contraseña nueva:</td>
            <td width="60%" valign="middle" class="tdpadleft5" align="left"> <input name="txtUsuarioContrasenaNueva" id="txtUsuarioContrasenaNueva" type="password" class="campotabla" size="15" maxlength="15"> 
            </td>
          </tr>
          <tr> 
            <td width="40%" class="tdtexttablebold">Confirmar contraseña nueva:</td>
            <td width="60%" valign="middle" class="tdpadleft5" align="left"> <input name="txtUsuarioConfirmarContrasenaNueva" id="txtUsuarioConfirmarContrasenaNueva" type="password" class="campotabla" size="15" maxlength="15"> 
            </td>
          </tr>
        </table>
        <br/> <input id="btnCancelar" name="btnCancelar" type="button" class="button" value="Cancelar" onclick="btnCancelar_onclick()"> 
        <input id="btnGuardar" name="btnGuardar" type="button" class="button" value="Guardar" onclick="btnGuardar_onclick()"> 
        <br/> <div style="position: absolute;"> <span id="mensajeErrorEtiqueta" style="display:none;font-family: Arial, Helvetica, sans-serif;font-size: 12px;color: #c00000;font-weight: bold;"></span> 
        </div></td>
    </tr>
  </table>
</form>
</body>
</html>
