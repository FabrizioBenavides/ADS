<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalAsignacionCuentasSucursal.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalAsignacionCuentasSucursal"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<link href="css/menu.css" type="text/css" rel="stylesheet">
			<link href="css/estilo.css" type="text/css" rel="stylesheet">
				<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
				<script language="javascript" id="clientEventHandlersJS">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
   document.forms[0].action = "<%= strThisPageName %>";
   document.forms[0].elements["txtSucursales"].value = "<%= strSucursales %>";
   
   <%= strJavascriptWindowOnLoadCommands %>
   <%= strLlenarTipoCuentaComboBox() %>
   <%= strLlenarDireccionComboBox() %>
   <%= strLlenarZonaComboBox() %>

   cboZona_onchange();
   
   var strcomando = "<%=strCmd()%>";
   if ( strcomando == 'Afectar') {
      alert("Datos Afectados");
   }
}

function cmdAsignar_onclick() {
  if ( blnFormValidator(document.forms[0]) == true ) {
    document.forms[0].action += "?strCmd=Afectar";
    document.forms[0].submit();
  }
}

function blnFormValidator(theForm) {
  var blnReturn = true;
  
   for (i = 0; i < theForm.length; i++)
   {
       if (theForm.elements[i].name.indexOf("txtComisionCuenta") >= 0) {
           if (theForm.elements[i].value == "" || isNaN(theForm.elements[i].value)) {
               alert ("Capturar la Comision para la cuenta");  
               theForm.elements[i].focus();
               blnReturn = false;         
               break;
           }
       }
       
       if (theForm.elements[i].name.indexOf("txtValorCuenta") >= 0) {
           if (theForm.elements[i].value == "" ) { 		
		       alert ("Capturar el Valor de la cuenta BANN");   
		       theForm.elements[i].focus();        
		       blnReturn = false;
               break;
		   }		
	   }
	}  

  return (blnReturn);
}

function cboTipoCuenta_onchange() {  
   document.forms[0].submit();
   return(true);
}

function cboDireccion_onchange() {
  document.forms[0].submit();
  return(true);
}

function cboZona_onchange() {
  if (document.forms[0].elements["cboZona"].selectedIndex > 0) {
    document.forms[0].elements["cmdElegirSucursales"].disabled = false;   
  } else {
    document.forms[0].elements["cmdElegirSucursales"].disabled = true;  
  }
  return(true);
}

function cmdElegirSucursales_onclick() {
  var intTipoCuentaId = document.forms[0].elements["cboTipoCuenta"].options[document.forms[0].elements["cboTipoCuenta"].selectedIndex].value;
  var intDireccionId = document.forms[0].elements["cboDireccion"].options[document.forms[0].elements["cboDireccion"].selectedIndex].value;
  var intZonaId = document.forms[0].elements["cboZona"].options[document.forms[0].elements["cboZona"].selectedIndex].value;
  return Pop("popSucursalAsignarCuentasElegirSucursales.aspx?intTipoCuentaId=" + intTipoCuentaId + "&intDireccionId=" + intDireccionId + "&intZonaId=" + intZonaId,"360","548")
}

function ActivateRow(intRowToShow) {
   var table = document.all? document.all.tableRegistro : document.getElementById('tableRegistro');
   table.rows[intRowToShow-1].style.display = 'none';
   table.rows[intRowToShow].style.display = '';
   table.rows[intRowToShow + 1].style.display = '';
}

function DeactivateRow(intRowToHide) {
  
   var table = document.all? document.all.tableRegistro : document.getElementById('tableRegistro');
   
   table.rows[intRowToHide- 1].style.display = '';
   table.rows[intRowToHide].style.display = 'none';
   table.rows[intRowToHide+ 1].style.display = 'none';	
}
				
function AllClosed() {
   var table = document.all? document.all.tableRegistro : document.getElementById('tableRegistro');   
   <%=strCierraDetalleCuentasSucursal%>	
   			
}

function AllOpen() {
   var table = document.all? document.all.tableRegistro : document.getElementById('tableRegistro');
   <%=strAbreDetalleCuentasSucursal%>					
}

function frmSistemaAsignarCuentasaSucursales_onsubmit() {
return (true);
}
//-->
				</script>
	</HEAD>
	<body onload="AllClosed();return window_onload()">
		<form name="SucursalAsignacionCuentasSucursal" action="about:blank" method="post">
			<input type="hidden" name="txtSucursales"> <input type="hidden" name="txtTipoCuentaNombre">
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
					<td class="tdtab" width="770">Está en : Sistema : Asignar Cuentas a Sucursales
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Asignar Cuentas a Sucursales
						</h1>
						<p>Para asignar los valores de las cuentas, seleccione el tipo de cuenta y luego la 
							dirección, zona y sucursales a asignar.
						</p>
						<h2>Tipo de Cuenta y zona de las sucursales
						</h2>
						<table cellSpacing="0" cellPadding="0" width="50%" border="0">
							<tr>
								<td class="tdtexttablebold" width="24%">Tipo de Cuenta:</td>
								<td class="tdpadleft5" width="76%"><select class="field" id="cboTipoCuenta" onchange="return cboTipoCuenta_onchange()" name="cboTipoCuenta">
										<option value="0" selected>Elija Tipo de Cuenta</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Dirección:</td>
								<td class="tdpadleft5"><select class="field" id="cboDireccion" onchange="return cboDireccion_onchange()" name="cboDireccion">
										<option value="0" selected>Elija una dirección</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold">Zona:</td>
								<td class="tdpadleft5"><select class="field" id="cboZona" onchange="return cboZona_onchange()" name="cboZona">
										<option value="0" selected>Elija una zona</option>
									</select>
								</td>
							</tr>
						</table>
						<br>
						<input class="button" id="cmdElegirSucursales" onclick="return cmdElegirSucursales_onclick()"
							type="button" value="Elegir sucursales" name="cmdElegirSucursales">
						<br>
						<br>
						<%= strRecordBrowserHTML() %>
						<br>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td>
						<script language="JavaScript">crearTablaFooterCentral()</script>
					</td>
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
