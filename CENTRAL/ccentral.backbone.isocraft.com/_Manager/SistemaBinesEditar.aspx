<%@ Page CodeBehind="SistemaBinesEditar.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaBinesEditar" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta content="text/html; charset=iso-8859-1" http-equiv="Content-Type">
		<LINK rel="stylesheet" type="text/css" href="css/menu.css">
		<LINK rel="stylesheet" type="text/css" href="css/estilo.css">
		<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
		<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
		<script id="clientEventHandlersJS" language="javascript">
<!--
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
  document.forms[0].action = "<%= strFormAction %>";
  document.forms[0].elements["intBinTarjetaId"].value = "<%= intBinTarjetaId %>";
  document.forms[0].elements["txtDescripcion"].value = "<%= strtxtDescripcion %>";
  document.forms[0].elements["txtEmisor"].value = "<%= strtxtEmisor %>";
  document.forms[0].elements["txtFechaMod"].value = "<%= strtxtFechaMod %>";
  document.forms[0].elements["intCredito"].value = "<%=intCredito%>";
  document.forms[0].elements["intPermiteCuotas"].value= "<%= intPermiteCuotas %>";
  document.forms[0].elements["intPagoComision"].value= "<%=intPagoComision%>"
  document.forms[0].elements["cboBancoIntegrador"].value= "<%=intBancoIntegradorId%>"
  //AJAL: stkblnValidaPagoConVales 
  document.forms[0].elements["intValidaPagoConVales"].value = "<%= intValidaPagoConVales%>";
  
  if (document.forms[0].elements["intCredito"].value == 0){
    document.frmMain.optTarjeta[1].checked = true;
    document.forms[0].elements["chkPagosCuotas"].disabled = true;
  } else {
    document.frmMain.optTarjeta[0].checked = true;
  }
  if (document.forms[0].elements["intPermiteCuotas"].value == 0){
    document.forms[0].elements["chkPagosCuotas"].checked = false;
  } else {
    document.forms[0].elements["chkPagosCuotas"].checked = true;
  }
  if(document.forms[0].elements["intPagoComision"].value==0){
   document.forms[0].elements["chkPagoComision"].checked=false;
  }else{
   document.forms[0].elements["chkPagoComision"].checked=true
  }
  //AJAL: stkblnValidaPagoConVales se agrega condidicon a chkbox
  if(document.forms[0].elements["intValidaPagoConVales"].value == 0){
   document.forms[0].elements["chkRestringirVentaArt"].checked = false;
   }else{
   document.forms[0].elements["chkRestringirVentaArt"].checked = true;
  }
  <%=strLlenarBancoIntegradorComboBox()%>
}

function cmdBorrar_onclick() {
  document.forms[0].action += "?strCmd=Eliminar";
  document.forms[0].submit();
}

function cmdGuardar_onclick() {
  if (document.frmMain.optTarjeta[0].checked == true){
    document.forms[0].elements["intCredito"].value =1;
  } else {
    document.forms[0].elements["intCredito"].value =0;
  }
  
  if(document.forms[0].elements["chkPagosCuotas"].checked == true){
    document.forms[0].elements["intPermiteCuotas"].value = 1;
  } else {
    document.forms[0].elements["intPermiteCuotas"].value = 0;
  }
  
if(document.forms[0].elements["chkPagoComision"].checked == true){
    document.forms[0].elements["intPagoComision"].value = 1;
  } else {
    document.forms[0].elements["intPagoComision"].value = 0;
  }
  //AJAL: stkblnValidaPagoConVales se agrega condificon a chkbox
  if(document.forms[0].elements["chkRestringirVentaArt"].checked == true){
	document.forms[0].elements["intValidaPagoConVales"].value = 1;
  } else {
    document.forms[0].elements["intValidaPagoConVales"].value = 0;
  }
  
  document.forms[0].action += "?strCmd=Guardar";
  return(true);
}

function cmdRegresar_onclick() {
//onclick="gotopage('SistemaBinesConsultar.htm')"
window.location.href = "<%= "SistemaBinesConsultar.aspx" %>";
return(true);
}

function optTarjeta_onclick(intValue) {
  if (intValue == 1) {
    document.forms[0].elements["chkPagosCuotas"].checked = false;
    document.forms[0].elements["chkPagosCuotas"].disabled = true;
  } else {
    document.forms[0].elements["chkPagosCuotas"].disabled = false;
  }
}

//-->
		</script>
	</HEAD>
	<body onload="return window_onload()" language="javascript">
		<form method="post" name="frmMain" action="about:blank">
			<input type="hidden" value="0" name="intCredito"> <input type="hidden" value="0" name="intPermiteCuotas">
			<input type="hidden" value="0" name="intPagoComision"> <input type="hidden" value="0" name ="intValidaPagoConVales">
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtab" width="770">Está en : <A href="Sistema.htm">Sistema</A> : <A href="../_Manager/SistemaBines.aspx">
							BINes</A> : <A href="../_Manager/.aspx">Consultar BINes</A> : Editar BINes</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Editar BINes
						</h1>
						<table cellSpacing="0" cellPadding="0" width="70%" border="0">
							<tr>
								<td class="tdtexttablebold" width="125">BIN:</td>
								<td class="tdcontentableblue" vAlign="top" width="406"><span class="tdpadleft5"><input id="intBinTarjetaId" class="campotablaresultado" readOnly size="40" border="0" name="intBinTarjetaId">
									</span>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Descripción :
								</td>
								<td class="tdcontentableblue" vAlign="top"><span class="tdpadleft5"><input id="txtDescripcion" class="campotablaresultado" readOnly size="40" border="0" name="txtDescripcion">
									</span>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Emisor:</td>
								<td class="tdcontentableblue" vAlign="top"><span class="tdpadleft5"><input id="txtEmisor" class="campotablaresultado" readOnly size="40" border="0" name="txtEmisor">
									</span>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Tipo de tarjeta :
								</td>
								<td class="tdtexttablebold"><input onclick="return optTarjeta_onclick(this.value)" language="javascript" type="radio"
										value="0" name="optTarjeta"> Crédito &nbsp;&nbsp; <input onclick="return optTarjeta_onclick(this.value)" language="javascript" type="radio"
										value="1" name="optTarjeta"> Débito
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Banco Corresponsalía:</td>
								<td class="tdpadleft5" vAlign="top" width="455"><select id="cboBancoIntegrador" class="field" name="cboBancoIntegrador">
										<option selected value="0">--- Seleccione un Banco Corresponsalía ---</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" colSpan="2"><input id="chkPagosCuotas" type="checkbox" value="checkbox" name="chkPagosCuotas">
									Permite pago en cuotas
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" colSpan="2"><input id="chkPagoComision" type="checkbox" value="checkbox" name="chkPagoComision">
									Paga Comisión Corresponsalía
								</td>
							</tr>
							<!--AJAL: stkblnValidaPagoConVales se agrega checkBox -->
							<tr>
								<td class="tdtexttablebold" colSpan="2"><input id="chkRestringirVentaArt" type="checkbox" value="checkbox" name="chkRestringirVentaArt">
									Restringir venta articulos especiales
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Última modificación:
								</td>
								<td class="tdcontentableblue" vAlign="top"><span class="tdpadleft5"><input id="txtFechaMod" class="campotablaresultado" readOnly size="40" border="0" name="txtFechaMod">
									</span>
								</td>
							</tr>
						</table>
						<br>
						<input onclick="return cmdRegresar_onclick()" id="cmdRegresar" class="button" language="javascript"
							type="button" value="Regresar" name="cmdRegresar"> &nbsp; <input onclick="return cmdGuardar_onclick()" id="cmdGuardar" class="button" language="javascript"
							type="submit" value="Guardar" name="cmdGuardar"> &nbsp; <input onclick="return cmdBorrar_onclick()" id="cmdBorrar" class="button" language="javascript"
							type="button" value="Borrar" name="cmdBorrar">
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
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
