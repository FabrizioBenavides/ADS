<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="popAsignarCuotaDeVenta.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clspopAsignarCuotaDeVenta" codePage="28592"%>
<html>
<head>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  <%=strCboSucursal%>
  <%=strCboMesConsultar%>
}

function strZonaOperativaNombre(){
	document.write("<%=strZonaOperativaNombre%>");
}

//-->
</script>
</head>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmpopAsignarCuotas">
<table width="360" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaHeaderPop()</script></td>
  </tr>
</table>
<table width="360" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="tdgeneralcontentpop"><h2>Asignar cuota de venta </h2>
      <table width="100%"  border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="32%" class="tdtexttablebold">Zona: </td>
          <td width="68%" class="tdcontentableblue"><script language="javascript">strZonaOperativaNombre()</script></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Sucursal:</td>
          <td class="tdpadleft5">
            <select name="cboSucursal" class="field">
              <option value="0">>>Elija una sucursal<<</option>
            </select>
          </td>
        </tr>
        <tr>
          <td class="tdtexttablebold">Mes: </td>
          <td class="tdpadleft5">
            <select name="cboMes" class="field">
              <option value="0">>>Elija el mes<<</option>
            </select>
          </td>
        </tr>
        <tr>
          <td height="20" colspan="2"><img src="images/pixel.gif" width="1" height="20"></td>
        </tr>
<!--        <tr>
          <td colspan="2" class="tdtexttablebold"><span class="txbluebold">Cuota de venta para [</span><span class="txredbold">MES</span><span class="txbluebold">], Sucursal [</span><span class="txredbold">NOMBRE</span><span class="txbluebold">] </span></td>
        </tr>
-->
        <tr>
          <td class="tdtexttablebold">Cuota de venta: </td>
          <td class="tdpadleft5"><input name="txtCuotaDeVenta" type="text" class="field" size="15" maxlength="15"></td>
        </tr>
        <tr>
          <td height="10" colspan="2"><img src="images/pixel.gif" width="1" height="10"></td>
        </tr>
        <tr>
          <td class="tdtexttablebold">&nbsp;</td>
          <td class="tdpadleft5"><input name="btnAsignar" type="button" class="button" value="Asignar cuota"></td>
        </tr>
      </table>
 	<br>
    </td>
  </tr>
</table>
<table width="360" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><script language="JavaScript">crearTablaFooterPop()</script></td>
  </tr>
</table>
</form>
</body>
</html>
