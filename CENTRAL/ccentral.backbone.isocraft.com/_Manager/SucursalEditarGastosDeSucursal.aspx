<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEditarGastosDeSucursal.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEditarGastosDeSucursal" EnableSessionState="False" enableViewState="False"%>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script id="clientEventHandlersJS" language="javascript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {

    var blnFondoFijoPresupuestadoSePuedeEditar = "<%= blnFondoFijoPresupuestadoSePuedeEditar %>";

    document.forms[0].action = "<%= strFormAction %>";
    document.forms[0].elements["intCompaniaId"].value = "<%= intCompaniaId %>";
    document.forms[0].elements["intSucursalId"].value = "<%= intSucursalId %>";
    document.forms[0].elements["intDireccionId"].value = "<%= intDireccionId %>";
    document.forms[0].elements["intZonaId"].value = "<%= intZonaId %>";
    document.forms[0].elements["intMes"].value = "<%= intMes %>";
    document.forms[0].elements["intAnio"].value = "<%= intAnio %>";
    document.forms[0].elements["intFondoFijoPresupuestadoId"].value = "<%= intFondoFijoPresupuestadoId %>";
    document.forms[0].elements["txtMontoExtra"].value = "<%= fltFondoFijoPresupuestadoImporteAdicional %>";

    if (blnFondoFijoPresupuestadoSePuedeEditar == "True") {
    
        document.forms[0].elements["txtMontoExtra"].disabled = false;
        document.forms[0].elements["cmdGuardar"].disabled = false;
        document.forms[0].elements["txtMontoExtra"].focus();

    }
   
}
function cmdCancelar_onclick() {
    window.location.href = "SucursalFondoFijo.aspx?intDireccionId=<%= intDireccionId %>&intZonaId=<%= intZonaId %>&intMes=<%= intMes %>&intAnio=<%= intAnio %>"
}

function cmdGuardar_onclick() {

    if (document.forms[0].elements["txtMontoExtra"].disabled == false) {

        if (document.forms[0].elements["txtMontoExtra"].value.length == 0) {
            alert("Por favor introduzca un valor en el campo \"Monto Extra\".");
            document.forms[0].elements["txtMontoExtra"].focus();
            return(false);
        } 

	    if (blnValidarCampo(document.forms[0].elements["txtMontoExtra"], true, "Monto Extra", cintTipoCampoCadenaDefinida, 9, 1, "0123456789.") == true) {

	        var montoExtraValido = eval(document.forms[0].elements["txtMontoExtra"].value + "> 0");
    	        	    
	        if (montoExtraValido == false) {
                alert("Por favor introduzca un valor mayor que cero en el campo \"Monto Extra\".");
                document.forms[0].elements["txtMontoExtra"].focus();
                return(false);
            } 

            document.forms[0].elements["strCmd"].value = "Salvar";
            return(true);

	    }
	    
	}
	return(false);

}

function strImprimirImporteAsignado() {
    document.write("<%= strFondoFijoPresupuestadoImporteAsignado %>");
}

function strImprimirImporteMaximo() {
    document.write("<%= strFondoFijoPresupuestadoImporteDiarioMaximo %>");
}

function strImprimirNombreSucursal() {
    document.write("<%= strNombreSucursal %>");
}

function strImprimirFechaAsignacion() {
    document.write("<%= strFechaAsignacion %>");
}

function cmdImprimir_onclick() {
    window.print();
}

//-->
</script>
</HEAD>
<body language="javascript" onLoad="return window_onload()">
<form id="frmMain" action="about:blank" method="post">
  <input type="hidden" name="strCmd" value="" />
  <input type="hidden" name="intCompaniaId" value="" />
  <input type="hidden" name="intSucursalId" value="" />
  <input type="hidden" name="intDireccionId" value="" />
  <input type="hidden" name="intZonaId" value="" />
  <input type="hidden" name="intMes" value="" />
  <input type="hidden" name="intAnio" value="" />
  <input type="hidden" name="intFondoFijoPresupuestadoId" value="" />
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : <a href="SucursalHome.aspx">Sucursal</a> : 
        Consulta de fondo fijo : Detalle de gastos de sucursal </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Detalle de gastos de sucursal </h1>
        <p>En esta p&aacute;gina puede consultar el detalle y autorizar a las sucursales los montos extra para gastos. </p>
        <h2>Gastos de sucursal </h2>
        <table width="90%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="14%" class="tdtexttablebold"><table border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td colspan="4" bgcolor="#525698" height="1"><img src="../static/images/pixel.gif" width="1" height="1"></td>
                </tr>
                <tr>
                  <td width="1" bgcolor="#525698" style="HEIGHT: 23px"><img src="../static/images/pixel.gif" width="1" height="1"></td>
                  <td width="166" class="tdceleste"><b>Sucursal:</b></td>
                  <td width="247" class="tdceleste"><script language="JavaScript" type="text/javascript">strImprimirNombreSucursal()</script></td>
                  <td width="1" bgcolor="#525698" style="HEIGHT: 23px"><img src="../static/images/pixel.gif" width="1" height="1"></td>
                </tr>
                <tr>
                  <td width="1" bgcolor="#525698" style="HEIGHT: 23px"><img src="../static/images/pixel.gif" width="1" height="1"></td>
                  <td class="tdceleste"><b>Importe Asignado:</b></td>
                  <td class="tdceleste"><script language="JavaScript" type="text/javascript">strImprimirImporteAsignado()</script></td>
                  <td width="1" bgcolor="#525698" style="HEIGHT: 23px"><img src="../static/images/pixel.gif" width="1" height="1"></td>
                </tr>
                <tr>
                  <td width="1" bgcolor="#525698" style="HEIGHT: 23px"><img src="../static/images/pixel.gif" width="1" height="1"></td>
                  <td class="tdceleste"><b>M&aacute;ximo por transacci&oacute;n:</b></td>
                  <td class="tdceleste"><script language="JavaScript" type="text/javascript">strImprimirImporteMaximo()</script></td>
                  <td width="1" bgcolor="#525698" style="HEIGHT: 23px"><img src="../static/images/pixel.gif" width="1" height="1"></td>
                </tr>
                <tr>
                  <td width="1" bgcolor="#525698" style="HEIGHT: 23px"><img src="../static/images/pixel.gif" width="1" height="1"></td>
                  <td class="tdceleste"><b>Fecha:</b></td>
                  <td class="tdceleste"><script language="JavaScript" type="text/javascript">strImprimirFechaAsignacion()</script></td>
                  <td width="1" bgcolor="#525698" style="HEIGHT: 23px"><img src="../static/images/pixel.gif" width="1" height="1"></td>
                </tr>
              </table></td>
          </tr>
          <tr>
            <td class="tdtexttablebold"><img src="../static/images/pixel.gif" width="1" height="1"></td>
          </tr>
        </table>
        <table width="450" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td width="200"><table width="200" border="0" cellpadding="0" cellspacing="0">
                <tr class="trtitle">
                  <th align="left" valign="top" class="line"> Fecha</th>
                  <th align="left" valign="top" class="line"> Importe</th>
                </tr>
                <%= strHtml %>
              </table>
              <table width="200" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td height="1" colspan="2" bgcolor="#525698"><img src="images/pixel.gif" width="1" height="1" alt=""></td>
                </tr>
                <tr>
                  <td height="8" colspan="2"><img src="images/pixel.gif" width="1" height="8" alt=""></td>
                </tr>
                <tr>
                  <td valign="middle" class="txgreybold" align="right">TOTAL:</td>
                  <td valign="middle" class="txblueregular" align="center">&nbsp;<%= strFondoFijoTotalGastadoImporte %></td>
                </tr>
                <tr>
                  <td height="8" colspan="2"><img src="images/pixel.gif" width="1" height="8" alt=""></td>
                </tr>
              </table></td>
            <td width="250" align="center"><table width="50%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td class="tdframebluefill"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="59%" class="txbluebold12">Monto Extra </td>
                      </tr>
                      <tr>
                        <td height="2" bgcolor="#525698"><img src="../static/images/pixel.gif" width="1" height="1"></td>
                      </tr>
                      <tr>
                        <td class="tdcontentableblue">$
                          <input name="txtMontoExtra" type="text" class="field" id="txtMontoExtra" size="12" maxlength="20" disabled></td>
                      </tr>
                    </table></td>
                </tr>
              </table></td>
          </tr>
        </table>
        <br>
        <input name="cmdCancelar" type="button" class="button" id="cmdCancelar" value="Cancelar" language="javascript" onClick="return cmdCancelar_onclick()">
        &nbsp;
        <input name="cmdGuardar" type="submit" class="button" id="cmdGuardar" value="Guardar" language="javascript" onClick="return cmdGuardar_onclick()" disabled>
        &nbsp;
        <input name="cmdImprimir" type="button" class="button" id="cmdImprimir" value="Imprimir" language=javascript onclick="return cmdImprimir_onclick()">
        <br>
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
</HTML>
