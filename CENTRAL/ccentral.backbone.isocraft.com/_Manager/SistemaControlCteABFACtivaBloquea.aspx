<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SistemaControlCteABFACtivaBloquea.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SistemaControlCteABFACtivaBloquea" codePage="1252" enableViewState="False" EnableSessionState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
<HEAD>
<title>Benavides : Sistema para el Control de ventas a clientes especiales (CTX)</title>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
<LINK rel="stylesheet" type="text/css" href="css/menu.css">
<LINK rel="stylesheet" type="text/css" href="css/estilo.css">
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
	document.forms[0].action = "<%= strFormAction %>";

	document.forms[0].elements["txtbuscaCliente"].value = "<%=strbuscaCliente%>";

	var strCmd = "";
	strCmd = "<%= strCmd %>";
	
	if (strCmd === "Editar")
	{
		document.getElementById('lblClienteSAPId').innerHTML = "<%= strClienteSAPId %>";
		document.getElementById('lblClienteABFId').innerHTML = "<%= strClienteABFId %>";
		document.getElementById('lblClienteInstEdit').innerHTML = "<%= strClienteNombre %>";
		
		document.forms[0].elements["chkActivo"].checked = <%= blnClienteActivo.ToString().ToLower() %>;
		document.forms[0].elements["chkCredDisp"].checked = <%= blnClienteExcedidoEnLimiteCredito.ToString().ToLower() %>;
	}
	else
	{
		document.getElementById('divDescripcionGuardar').style.display='none';
		document.getElementById('divChkActivo').style.display='none';
		document.getElementById('divChkCredDisp').style.display='none';
		document.getElementById('divCamposGuardar').style.display='none';
		document.getElementById('divBotonGuardar').style.display='none';
		document.getElementById('divBotonCancelar').style.display='none';
	}
	
	<%= strJavascriptWindowOnLoadCommands %>
}
function cmdBuscar_onclick() {
   document.forms[0].action = "<%=strFormAction%>";
   document.forms[0].submit();
}
function cmdGuardar_onclick() {
	var lblClienteSAPId
	var strClienteSAPId = ""
	var lblClienteABFId
	var strClienteABFId = ""
	var lblClienteNombre
	var strClienteNombre = ""
	var chkClienteActivo
	var blnClienteActivo = false
	var intClienteActivo = 0
	var chkClienteExcedidoEnLimiteCredito
    var blnClienteExcedidoEnLimiteCredito = false
    var intClienteExcedidoEnLimiteCredito = 0
    
    lblClienteSAPId = document.getElementById('lblClienteSAPId');
    strClienteSAPId = lblClienteSAPId.innerHTML;
    
    lblClienteABFId = document.getElementById('lblClienteABFId');
    strClienteABFId = lblClienteABFId.innerHTML;
    
    lblClienteNombre = document.getElementById('lblClienteInstEdit');
    strClienteNombre = lblClienteNombre.innerHTML;
    
    chkClienteActivo = document.forms[0].elements["chkActivo"];
    blnClienteActivo = chkClienteActivo.checked;
    
    chkClienteExcedidoEnLimiteCredito = document.forms[0].elements["chkCredDisp"];
    blnClienteExcedidoEnLimiteCredito = chkClienteExcedidoEnLimiteCredito.checked;
    
	if (blnClienteActivo==true) 
	{           
		intClienteActivo=1;
	}
	
	if (blnClienteExcedidoEnLimiteCredito==true) 
	{           
		intClienteExcedidoEnLimiteCredito=1;
	}
    
    document.forms[0].action += "?strCmd=Guardar&strbuscaCliente=" + document.forms[0].elements["txtbuscaCliente"].value + "&strClienteSAPId=" + strClienteSAPId + "&strClienteABFId=" + strClienteABFId + "&strClienteNombre=" + strClienteNombre + "&blnClienteActivo=" + intClienteActivo + "&blnClienteExcedidoEnLimiteCredito=" + intClienteExcedidoEnLimiteCredito;
    document.forms(0).submit();
}

function cmdCancelar_onclick() {
   window.location.href = "SistemaControlCteABFACtivaBloquea.aspx";
}

//-->
		</script>
</HEAD>
<body language="javascript" onload="return window_onload()">
<form method="post" name="frmPage" action="about:blank">
  <table border="0" cellSpacing="0" cellPadding="0" width="780">
    <tr> 
      <td> <script language="JavaScript">crearTablaHeader()</script> </td>
    </tr>
  </table>
  <table border="0" cellSpacing="0" cellPadding="0" width="780">
    <tr> 
      <td width="10">&nbsp;</td>
      <td class="tdtab" width="770">Está en : <A href="Sistema.aspx">Sistema</A> 
        : <A href="SistemaControlCteABFACtivaBloquea.aspx"> Clientes especiales</A> 
        : Administrar clientes institucionales</td>
    </tr>
  </table>
  <table border="0" cellSpacing="0" cellPadding="0" width="780">
    <tr> 
      <td class="tdgeneralcontent"> <table border="0" cellSpacing="0" cellPadding="0" width="100%">
          <tr height="20"> 
            <td colspan="2"> <h1>Clientes Institucionales</h1></td>
          </tr>
          <tr> 
            <td class="tdtexttablebold" width="70%" >Cliente: 
              <input class="field" id="txtbuscaCliente" type="text" autocomplete="off"  maxlength="35" size="45" name="txtbuscaCliente"  value='<%=Request("strbuscaCliente")%>'></td>
            <td align="right" width="30%"><input id="cmdBuscar" language="javascript" class="button" onclick="return cmdBuscar_onclick()" value=" Buscar" type="button" name="cmdBuscar"></td>
          </tr>
          <tr height="20"> 
            <td colspan="2"> <div id="divDescripcionGuardar"> 
                <P class="MsoNormal">Editar para activar/desactivar cliente o 
                  marcar excedido limite de credito</P>
              </div></td>
          </tr>
          <tr height="30"> 
            <td class="tdbluebold12" width="70%" align="left" valign="middle"> 
              <div id="divCamposGuardar"> 
                <label style="Z-INDEX: 0" id="lblClienteSAPId"></label>
                &nbsp;&nbsp; 
                <label style="Z-INDEX: 0" id="lblClienteABFId"></label>
                &nbsp;&nbsp; 
                <label style="Z-INDEX: 0" id="lblClienteInstEdit"></label>
              </div></td>
            <td class="tdtexttablebold" width="30%"> <div id="divChkActivo"> 
                <input id="chkActivo" class="fieldborderless" type="checkbox">
                <label>Activo</label>
              </div>
              &nbsp; <div id="divChkCredDisp"> 
                <input id="chkCredDisp" class="fieldborderless" type="checkbox">
                <label>Excedido Limite de Credito</label>
              </div></td>
          </tr>
          <tr height="40" valign="middle"> 
            <td align="right" width="70%"> <div id="divBotonCancelar"> 
                <input id="cmdCancelar" language="javascript" class="button" onclick="return cmdCancelar_onclick()"
											value="Cancelar" type="button" name="cmdCancelar">
              </div></td>
            <td align="right" width="30%"><div id="divBotonGuardar"> 
                <input id="cmdGuardar" language="javascript" class="button" onclick="return cmdGuardar_onclick()"
											value=" Guardar" type="button" name="cmdGuardar">
              </div></td>
          </tr>
          <tr> 
            <td colspan="2"> <%= strGetRecordBrowserHTML() %> </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <table border="0" cellSpacing="0" cellPadding="0" width="780">
    <tr> 
      <td> <script language="JavaScript">crearTablaFooterCentral()</script> </td>
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
