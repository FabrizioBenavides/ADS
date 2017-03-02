<%@ Page CodeBehind="popSistemaEmpresasRecolectorasElegirSucursales.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clspopSistemaEmpresasRecolectorasElegirSucursales" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
    document.forms[0].action = "<%= strFormAction %>";
    
    <%= strJavascriptWindowOnLoadCommands %>
    <%= strLlenarSucursalComboBox() %>    
}

function intRecolectora() {
  intRecolectoraId = <%= intRecolectoraId%>;
}

function intDireccion() {
  intDireccionId = <%= intDireccionId%>;
}

function intZona() {
  intZonaId = <%= intZonaId%>;
}

function chkSeleccionar_onclick() {
  for (var intCounter = 0; intCounter < document.forms[0].elements["cboSucursal"].length; intCounter++) {
    document.forms[0].elements["cboSucursal"].options[intCounter].selected = document.forms[0].elements["chkSeleccionar"].checked;
  }
}

function LlenarControlZona(){
 document.write("<%= strZonaOperativaNombre()%>");

}

function LlenarControlDireccion(){
 document.write("<%= strDireccionOperativaNombre()%>");
}

function LlenarControlRecolectora(){
 document.write("<%= strRecolectoraNombre()%>");
}

function cmdCerrar_onclick() {
  var blnSelected = false;
  for (var intCounter = 0; intCounter < document.forms[0].elements["cboSucursal"].length; intCounter++) {
    blnSelected = document.forms[0].elements["cboSucursal"].options[intCounter].selected;
    if (blnSelected == true) {
      break;
    }
  }
  if (blnSelected == true) {
    document.forms[0].action += "?strCmd=Cerrar&intRecolectoraId=" + <%= intRecolectoraId%> + "&intDireccionId=" + <%= intDireccionId%> + "&intZonaId=" + <%= intZonaId%>;
    document.forms[0].submit();
  } else {
    alert("Por favor seleccione al menos una sucursal.");
    document.forms[0].elements["cboSucursal"].focus();
    return(false);
  }
}

function cmdCancelar_onclick() {
  window.close();
}

//-->
		</script>
</HEAD>
<body language="javascript" onload="return window_onload()"> 
<form name="frmMain" action="about:blank" method="post"> 
  <table width="360" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td><script language="JavaScript">crearTablaHeaderPop()</script></td> 
    </tr> 
  </table> 
  <table width="360" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td class="tdgeneralcontentpop"><h2>Elegir sucursal</h2> 
        <table width="100%" border="0" cellspacing="0" cellpadding="0"> 
          <tr> 
            <td width="38%" class="tdtexttablebold">Empresa recolectora:</td> 
            <td width="62%" class="tdcontentableblue"><script language="javascript">LlenarControlRecolectora()</script></td> 
          </tr> 
          <tr> 
            <td class="tdtexttablebold">Dirección: </td> 
            <td class="tdcontentableblue"><script language="javascript">LlenarControlDireccion()</script></td> 
          </tr> 
          <tr> 
            <td class="tdtexttablebold">Zona:</td> 
            <td class="tdcontentableblue"><script language="javascript">LlenarControlZona()</script></td> 
          </tr> 
        </table> 
        <p>Elija la sucursal a la que quiere asignar la empresa recolectora y oprima el botón "Cerrar selección".<br> 
          Para elegir más de una sucursal, haga clic en los nombres correspondientes. </p> 
        <table width="100%" border="0" cellspacing="0" cellpadding="0"> 
          <tr> 
            <td class="tdtexttablebold"><input name="chkSeleccionar" type="checkbox" id="chkSeleccionar" value="checkbox" language=javascript onclick="return chkSeleccionar_onclick()"> 
&nbsp;Seleccionar todas</td> 
          </tr> 
          <tr> 
            <td class="tdblueframe"><select class="fieldcomment" name="cboSucursal" size="10" multiple> </select> </td> 
          </tr> 
        </table></td> 
    </tr> 
  </table> 
  <span class="tdpadleft5"> 
  <input name="cmdCancelar" type="button" class="button" id="cmdCancelar" value="Cancelar" language=javascript onclick="return cmdCancelar_onclick()"> 
&nbsp;&nbsp; 
  <input name="cmdCerrar" type="button" class="button" id="cmdCerrar" value="Cerrar selección" language=javascript onclick="return cmdCerrar_onclick()"> 
  </span> 
  </td> 
  <br> 
  </tr> 
  <tr> 
    <td>&nbsp;</td> 
  </tr> 
  <table width="360" border="0" cellspacing="0" cellpadding="0"> 
    <tr> 
      <td><script language="JavaScript">crearTablaFooterPop()</script></td> 
    </tr> 
  </table> 
</form> 
</body>
</HTML>
