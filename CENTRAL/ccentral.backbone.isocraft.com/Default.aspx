<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsLogin" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" CodePage="1252" %>
<!doctype html public "-//w3c//dtd html 4.0 transitional//en">
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
        ' Page          : 
        '                 25 de Febrero 2011 [JAHD]    Actualizacion por CADENA
        '====================================================================
    %>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="static/css/estilo.css">
<script id="clientEventHandlersJS" language="javascript">
<!--
    function strPieFirma() {
        document.write("&copy; " + (new Date()).getFullYear());
    }

    function window_onload() {
        document.forms[0].action = "<%=strFormAction%>";
        document.forms[0].elements[0].value = "<%=strUsuarioNombre%>";
        document.forms[0].elements[1].value = "<%=strUsuarioContrasena%>";
        document.forms[0].elements[0].focus();
        EscribirMensajeError();
        return (true);
}

function EscribirMensajeError() {

    var intMensajeError = "<%=intMensajeError%>";
    var mensajeError = "";
    var mensajeMostrarError = document.getElementById("mensajeMostrarError");

        if (intMensajeError == -100) {
            mensajeError = "La Cuenta de Usuario no existe o la contraseńa no es valida.";
        }
        else if (intMensajeError == -200) {
            mensajeError = "La Cuenta de Usuario no está habilitada.";
        }
        else if (intMensajeError == -300) {
            mensajeError = "La Cuenta de Usuario ha expirado.";
        }
        else if (intMensajeError == -400) {
            mensajeError = "La Cuenta de Usuario esta Bloqueada.";
        }
        else if (intMensajeError == -500) {
            mensajeError = "La contrasena de la Cuenta de Usuario ha cambiado. Favor de establecer una nueva.";
        }
        else if (intMensajeError == -600) {
            mensajeError = "La contrasena de la Cuenta de Usuario ha expirado. Favor de cambiarla.";
        }

        if (intMensajeError < 0) {
            mensajeMostrarError.innerHTML = mensajeError;
            mensajeMostrarError.style.display = "inline";
        }
    }

    function frmAccesoAlSistema_onsubmit(objForm) {
        var mensajeMostrarError = document.getElementById("mensajeMostrarError");

        if (mensajeMostrarError != null) {
            mensajeMostrarError.style.display = "none";
        }

        // Validaciones para el campo txtUsuarioNombre
        if (objForm.txtUsuarioNombre.value == "") {
            alert("Por favor escriba un valor en el campo \"Usuario\".");
            objForm.txtUsuarioNombre.focus();
            return (false);
        }

        if (objForm.txtUsuarioNombre.value.length < 1) {
            alert("Por favor escriba al menos 1 caracter en el campo \"Usuario\".");
            objForm.txtUsuarioNombre.focus();
            return (false);
        }

        if (objForm.txtUsuarioNombre.value.length > 15) {
            alert("Por favor escriba a lo más 15 caracteres en el campo \"Usuario\".");
            objForm.txtUsuarioNombre.focus();
            return (false);
        }

        var checkOK = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzfSOZsozYRÁÂAÄLCÇCÉEËEÍÎDĐNNÓÔOÖRUÚUÜÝTßráâaälcçcéeëeíîddnnóôoöruúuüýt?0123456789-";
        var checkStr = objForm.txtUsuarioNombre.value;
        var allValid = true;
        for (i = 0; i < checkStr.length; i++) {
            ch = checkStr.charAt(i);
            for (j = 0; j < checkOK.length; j++)
                if (ch == checkOK.charAt(j))
                    break;
            if (j == checkOK.length) {
                allValid = false;
                break;
            }
        }

        if (!allValid) {
            alert("Por favor escriba únicamente caracteres y dígitos en el campo \"Usuario\".");
            objForm.txtUsuarioNombre.focus();
            return (false);
        }

        // Validaciones para el campo txtUsuarioContrasena
        if (objForm.txtUsuarioContrasena.value == "") {
            alert("Por favor escriba un valor en el campo \"Contraseńa\".");
            objForm.txtUsuarioContrasena.focus();
            return (false);
        }

        if (objForm.txtUsuarioContrasena.value.length < 1) {
            alert("Por favor escriba al menos 1 caracter en el campo \"Contraseńa\".");
            objForm.txtUsuarioContrasena.focus();
            return (false);
        }

        if (objForm.txtUsuarioContrasena.value.length > 15) {
            alert("Por favor escriba a lo más 15 caracteres en el campo \"Contraseńa\".");
            objForm.txtUsuarioContrasena.focus();
            return (false);
        }

        //var checkOK = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzfSOZsozYRÁÂAÄLCÇCÉEËEÍÎDĐNNÓÔOÖRUÚUÜÝTßráâaälcçcéeëeíîddnnóôoöruúuüýt?0123456789-";
        //var checkStr = objForm.txtUsuarioContrasena.value;
        //var allValid = true;
        //for (i = 0; i < checkStr.length; i++) {
        //    ch = checkStr.charAt(i);
        //    for (j = 0; j < checkOK.length; j++)
        //        if (ch == checkOK.charAt(j))
        //            break;
        //    if (j == checkOK.length) {
        //        allValid = false;
        //        break;
        //    }
        //}
     
        //if (!allValid) {
        //    alert("Por favor escriba únicamente caracteres y dígitos en el campo \"Contrasena\".");
        //    objForm.txtUsuarioContrasena.focus();
        //    return (false);
        //}

        return (true);
    }

    function mostrarVentanaCambioContrasena() {
        window.open("_Manager/PopSistemaCambiarContrasena.aspx", "Pop", "width=565, height=320, left=250, top=120, resizable=no, scrollbars=auto, menubar=no, status=no");
    }

    </script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" language="javascript" onload="return window_onload()" style="background-repeat: no-repeat;">
<form action="about:blank" method="post" name="frmAccesoAlSistema" onsubmit="return frmAccesoAlSistema_onsubmit(this)">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td> <table width="780" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td class="tdbottom">&nbsp;</td>
          </tr>
        </table></td>
    </tr>
    <tr> 
      <td> <table width="780" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="598" height="80" class="tdlogo"> <img src="/static/images/logoFirma.GIF" width="255" height="48"></td>
            <td width="182" align="center">&nbsp;</td>
          </tr>
        </table></td>
    </tr>
    <tr> 
      <td height="34" align="right" class="tdbottom"> <img src="static/images/Pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td> <table width="780" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10"> <img src="static/images/Pixel.gif" width="10" height="8"></td>
            <td width="588" class="tdmigaja"><span class="txdmigaja">Est&aacute; 
              en :Acceso al sistema </span></td>
            <td width="182" class="tdfechahora">&nbsp;</td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="588" height="200" valign="top" class="tdtablaconthome"> 
              <table width="40%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr> 
                  <td height="20" colspan="2">&nbsp;</td>
                </tr>
                <tr> 
                  <td width="40%" class="tdtittablas">Usuario:</td>
                  <td width="60%" valign="middle" class="tdpadleft5" align="left"> 
                    <input name="txtUsuarioNombre" type="text" class="campotabla" id="txtUsuarioNombre" size="15" maxlength="15" autocomplete="off"></td>
                </tr>
                <tr> 
                  <td width="40%" class="tdtittablas">Contrase&ntilde;a:</td>
                  <td width="60%" valign="middle" class="tdpadleft5" align="left"> 
                    <input name="txtUsuarioContrasena" type="password" class="campotabla" id="txtUsuarioContrasena" size="15" maxlength="15"></td>
                </tr>
                <tr> 
                  <td class="tdtittablas" height="10">&nbsp;</td>
                  <td valign="middle" class="tdpadleft5">&nbsp;</td>
                </tr>
                <tr> 
                  <td width="40%" class="tdtittablas">&nbsp;</td>
                  <td width="60%"  valign="middle" class="tdpadleft5" align="left"> 
                    <input name="cmdEnviar" type="submit" class="boton" id="cmdEnviar" value="Enviar"></td>
                  <br>
                </tr>
                <tr> 
                  <td width="40%" class="tdtittablas">&nbsp;</td>
                  <td class="tdtittablas"> <div style="margin-left: 10px;"> <a style="color: #00005c" href="#" onclick="mostrarVentanaCambioContrasena();" >Cambiar 
                      Contrase&ntilde;a</a></div></td>
                </tr>
              </table>
              <div style="position: absolute;"> <span id="mensajeMostrarError" style="display:none;font-family: Arial, Helvetica, sans-serif;font-size: 12px;color: #c00000;font-weight: bold;"></span></div></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;<br></td>
          </tr>
          <tr> 
            <td class="tdbottom" colspan="2"> <script language="javascript">strPieFirma()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
</form>
</body>
</html>
