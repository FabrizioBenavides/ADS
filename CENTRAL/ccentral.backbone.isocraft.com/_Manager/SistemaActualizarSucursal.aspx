<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SistemaActualizarSucursal.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SistemaActualizarSucursal"%>
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
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
   document.forms[0].action = "<%= strThisPageName %>";
   
   document.forms[0].elements["txtDireccionId"].value = "<%= intDireccionId %>";
   document.forms[0].elements["txtZonaId"].value = "<%= intZonaId %>";
   document.forms[0].elements["txtSucursales"].value = "<%= strSucursales %>";
   
   var strSucursalesActualizar = document.forms[0].elements["txtSucursales"].value;
   
   if( strSucursalesActualizar.length == 0 ) {
  
       if( document.forms[0].elements["txtDireccionId"].value == 0 && document.forms[0].elements["txtZonaId"].value==0 ) {
           document.forms[0].elements["txtNombreSucursales"].value = "Todas las Sucursales" 
       }
       if( document.forms[0].elements["txtDireccionId"].value > 0 && document.forms[0].elements["txtZonaId"].value==0 ) {
           document.forms[0].elements["txtNombreSucursales"].value = "Toda la Dirección" 
       }
       if( document.forms[0].elements["txtDireccionId"].value > 0 && document.forms[0].elements["txtZonaId"].value>0 ) {
           document.forms[0].elements["txtNombreSucursales"].value = "Toda la Zona" 
       }
   }
   else {
       document.forms[0].elements["txtNombreSucursales"].value =document.forms[0].elements["txtSucursales"].value;
   }
     
   <%= strJavascriptWindowOnLoadCommands %>
   <%= strSeleccionaCombos%>   
}

function strDireccionOperativaNombre() {
  document.write("<%= strDireccionOperativaNombre %>");
}

function strZonaOperativaNombre() {
  document.write("<%= strZonaOperativaNombre() %>");
}


function cmdSeleccionar_onclick() {
   var intSolicitudActualizacionId = 0;
   return Pop("popSistemaElegirSucursalActualizar.aspx","460","480")
}

function cmdRegresar_onclick() {
  window.location.href = "SistemaTransmisiones.aspx";
}

function cmdTransmitir_onclick() {
   var strTablas = "";
   
   for (i = 0; i < document.forms[0].length; i++)
   {
       if (document.forms[0].elements[i].name.indexOf("chk") >= 0) {
           if(document.forms[0].elements[i].checked == true) {               
			   strTablas += document.forms[0].elements[i].value + "\r" ;
		   }
		}		
   }
   
   if (strTablas.length > 0) {   
       valida = confirm("CATALOGOS A TRANSMITIR : \r\r" + strTablas );
       if (valida) {	
           document.forms[0].action = "?strCmd=Transmitir"; 
           document.forms[0].target="ifrOculto";
           document.forms[0].submit();
           
           document.forms[0].target="";
           document.forms[0].action = "";           
       }
   }
   else {
       alert("Seleccione un catalogo a Transmitir");
   }
   
   
}

function fnUpTransmitir(strResultado) {
   if (strResultado >0) {       
       alert("Transmisión Terminada");
   }
   else {
       alert("Error al transmitir catalogos");
   }
   
}
   

// -->
				</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
		<form action="about:blank" name="frmMain" method="post">
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td width="10">&nbsp;</td>
					<td width="770" class="tdtab">Está en : Sistema : Trasmisiones : Actualización 
						Sucursal
					</td>
				</tr>
			</table>
			<table width="780" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Actualizacion de Catálogos a Sucursal</h1>
						<h2>Seleccionar la(s) Sucursal(es) Destino. &nbsp; <input type="button" class="button" id="cmdSeleccionar" name="cmdSeleccionar" value="Seleccionar"
								language="javascript" onclick="return cmdSeleccionar_onclick()">
						</h2>
						<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td width="15%" class="tdtexttablebold">Dirección:</td>
								<td width="75%" class="tdcontentableblue"><script language="javascript">strDireccionOperativaNombre()</script>
								</td>
							</tr>
							<tr>
								<td width="15%" height="29" class="tdtexttablebold">Zona:</td>
								<td width="75%" class="tdcontentableblue"><script language="javascript">strZonaOperativaNombre()</script>
								</td>
							</tr>
							<tr>
								<td width="15%" class="tdtexttablebold">Sucursal:</td>
								<td width="75%" class="tdtexttablebold"><input width="110" type="text" name="txtNombreSucursales" readonly class="campotablaresultado"
										size="110">
								</td>
							</tr>
							<tr>
								<td width="15%" colspan="2">
									<input type="button" class="button" id="cmdRegresar" name="cmdRegresar" value="Regresar"
										language="javascript" onClick="return cmdRegresar_onclick()"> &nbsp; <input type="button" class="button" id="cmdTransmitir" name="cmdTransmitir" value="Transmitir"
										language="javascript" onclick="return cmdTransmitir_onclick()">
								</td>
							</tr>
						</table>
						<table width='100%' border='0' cellpadding='0' cellspacing='0'>
							<tr class='trtitulos'>
								<th width='120' class='rayita' colspan="3" height="35">
									ARTICULOS</th>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>1</td>
								<td class='tdceleste' width="240"><input type='checkbox' name='chkart_1' value='tblArticulo'>
									Articulos</td>
								<td class='tdceleste'>tblArticulo</td>
							</tr>
							<tr>
								<td align='right' class='tdblanco'>2</td>
								<td class='tdblanco' width="240"><input type='checkbox' name='chkart_2' value='tblArticuloSucursal'>
									Articulos Sucursal</td>
								<td class='tdblanco'>tblArticuloSucursal</td>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>3</td>
								<td class='tdceleste'><input type='checkbox' name='chkart_3' value='tblOferta'> Ofertas</td>
								<td class='tdceleste'>tblOferta</td>
							</tr>
							<tr>
								<td align='right' class='tdblanco'>4</td>
								<td class='tdblanco'><input type='checkbox' name='chkart_4' value='tblArticuloOferta'>
									Articulos Ofertas</td>
								<td class='tdblanco'>tblArticuloOferta</td>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>5</td>
								<td class='tdceleste'><input type='checkbox' name='chkart_5' value='tblProveedorArticuloSucursal'>
									Articulos&nbsp;Proveedor</td>
								<td class='tdceleste'>tblProveedorArticuloSucursal</td>
							</tr>
							<tr class='trtitulos'>
								<th width='120' class='rayita' colspan="3" height="35">
									TIPO DE CAMBIO</th>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>1</td>
								<td class='tdceleste'><input type='checkbox' name='chkcam_1' value='tblTipoDeCambioMoneda'>
									Tipo de Cambio&nbsp;</td>
								<td class='tdceleste'>tblTipodeCambioMoneda</td>
							</tr>
							<tr>
								<td align='right' class='tdblanco'>2</td>
								<td class='tdblanco'><input type='checkbox' name='chkcam_2' value='tblMonedaSucursal'>
									Moneda</td>
								<td class='tdblanco'>tblMonedaSucursal</td>
							</tr>
							<tr class='trtitulos'>
								<th width='120' class='rayita' colspan="3" height="35">
									FONDO FIJO</th>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>1</td>
								<td class='tdceleste'><input type='checkbox' name='chkfon_1' value='tblFolioFondoFijo'>
									Fondo Fijo Sucursal</td>
								<td class='tdceleste'>tblFolioFondofijo</td>
							</tr>
							<tr class='trtitulos'>
								<th width='120' height="35" colspan="3" class='rayita'>
									CUPONES</th>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>1</td>
								<td class='tdceleste'><input type='checkbox' name='chkcup_1' value='tblCupon'> Cupon</td>
								<td class='tdceleste'>tblCupon</td>
							</tr>
							<tr>
								<td align='right' class='tdblanco'>2</td>
								<td class='tdblanco'><input type='checkbox' name='chkcup_2' value='tblCuponSucursal'>
									Cupon Sucursal</td>
								<td class='tdblanco'>tblCuponSucursal</td>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>3</td>
								<td class='tdceleste'><input type='checkbox' name='chkcup_3' value='tblCuponFormaPago'>
									Forma de Pago del Cupon</td>
								<td class='tdceleste'>tblCuponFormaPago</td>
							</tr>
							<tr>
								<td align='right' class='tdblanco'>4</td>
								<td class='tdblanco'><input type='checkbox' name='chkcup_4' value='tblCategoriaCupon'>
									Categorias del Cupon&nbsp;</td>
								<td class='tdblanco'>tblCategoriaCupon</td>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>5</td>
								<td class='tdceleste'><input type='checkbox' name='chkcup_5' value='tblSubcategoriaCupon'>
									Subcategorias del Cupon</td>
								<td class='tdceleste'>tblSubcategoriaCupon</td>
							</tr>
							<tr>
								<td height="26" align='right' class='tdblanco'>6</td>
								<td class='tdblanco'><input type='checkbox' name='chkcup_6' value='tblArticuloCupon'>
									Articulos del Cupon
								</td>
								<td class='tdblanco'>tblArticulocupon</td>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>7</td>
								<td class='tdceleste'><input type='checkbox' name='chkcup_7' value='tblProveedorCupon'>
									Proveedores del Cupon&nbsp;</td>
								<td class='tdceleste'>tblProveedorCupon</td>
							</tr>
							<tr>
								<td align='right' class='tdblanco'>8</td>
								<td class='tdblanco'><input type='checkbox' name='chkcup_8' value='tblProveedorCategoriaCupon'>
									Proveedor-Categoria del Cupon</td>
								<td class='tdblanco'>tblProveedorCategoriaCupon</td>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>9</td>
								<td class='tdceleste'><input type='checkbox' name='chkcup_9' value='tblProveedorSubcategoriaCupon'>
									Proveedor-Subcategoria del Cupon</td>
								<td class='tdceleste'>tblProveedorSubcategoriaCupon</td>
							</tr>
							<tr class='trtitulos'>
								<th width='120' class='rayita' colspan="3" height="35">
									CLIENTES</th>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>1</td>
								<td class='tdceleste'><input type='checkbox' name='chkcli_1' value='tblClienteEspecial'>
									Cliente especial</td>
								<td class='tdceleste'>tblClienteEspecial</td>
							</tr>
							<tr>
								<td align='right' class='tdblanco'>2</td>
								<td class='tdblanco'><input type='checkbox' name='chkcli_2' value='tblClienteEspecialSucursal'>
									Cliente Especial Sucursal</td>
								<td class='tdblanco'>tblClienteEspecialSucursal</td>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>3</td>
								<td class='tdceleste'><input type='checkbox' name='chkcli_3' value='tblClienteEspecialDatoGeneralRequerido'>
									Datos adicionales Cliente Especial</td>
								<td class='tdceleste'>tblClienteEspecialDatoGeneralRequerido</td>
							</tr>
							<tr class='trtitulos'>
								<th width='120' class='rayita' colspan="3" height="35">
									EMPLEADOS</th>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>1</td>
								<td class='tdceleste'><input type='checkbox' name='chkemp_1' value='tblEmpleado'> Empleados</td>
								<td class='tdceleste'>tblEmpleado</td>
							</tr>
							<tr>
								<td align='right' class='tdblanco'>2</td>
								<td class='tdblanco'><input type='checkbox' name='chkemp_2' value='tblEmpleadoSucursal'>
									Empleados Sucursal</td>
								<td class='tdblanco'>tblEmpleadoSucursal</td>
							</tr>
							<tr class='trtitulos'>
								<th width='120' class='rayita' colspan="3" height="35">
									DATOS SUCURSAL</th>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>1</td>
								<td class='tdceleste'><input type='checkbox' name='chksuc_1' value='tblPoliticaTicket'>
									Datos Ticket</td>
								<td class='tdceleste'>tblPoliticaTicket</td>
							</tr>
							<tr>
								<td align='right' class='tdblanco'>2</td>
								<td class='tdblanco'><input type='checkbox' name='chksuc_2' value='tblPoliticaPosSucursal'>
									Datos POS</td>
								<td class='tdblanco'>tblPoliticaPosSucursal</td>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>3</td>
								<td class='tdceleste'><input type='checkbox' name='chksuc_3' value='tblServicioPublicoAsignadoSucursal'>
									Servicios Publicos</td>
								<td class='tdceleste'>tblServicioPublicoAsignadoSucursal</td>
							</tr>
							<tr>
								<td align='right' class='tdblanco'>4</td>
								<td class='tdblanco'><input type='checkbox' name='chksuc_4' value='tblTurnoLaboralSucursal'>
									Turno Laboral</td>
								<td class='tdblanco'>tblTurnoLaboralSucursal</td>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>5</td>
								<td class='tdceleste'><input type='checkbox' name='chksuc_5' value='tblImpuestoSucursal'>
									Impuesto Sucursal</td>
								<td class='tdceleste'>tblImpuestoSucursal</td>
							</tr>
							<tr>
								<td align='right' class='tdblanco'>6</td>
								<td class='tdblanco'><input type='checkbox' name='chksuc_6' value='tblCuotaVenta'> Cuota 
									de Venta</td>
								<td class='tdblanco'>tblCuotaVenta</td>
							</tr>
							<tr>
								<td align='right' class='tdceleste'>7</td>
								<td class='tdceleste'><input type='checkbox' name='chksuc_7' value='tblCuenta'> Cuentas</td>
								<td class='tdceleste'>tblcuenta</td>
							</tr>
							<tr>
								<td align='right' class='tdblanco'>8</td>
								<td class='tdblanco'><input type='checkbox' name='chksuc_8' value='tblCuentaSucursal'>
									Cuentas Sucursal</td>
								<td class='tdblanco'>tblCuentaSucursal</td>
							</tr>
						</table>
					</td>
					</TD>
				</tr>
			</table>
			<table width="780" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td><script language="JavaScript">crearTablaFooterCentral()</script>
					</td>
				</tr>
			</table>
			<input type="hidden" name="txtDireccionId"> <input type="hidden" name="txtZonaId"> <input type="hidden" name="txtSucursales">
			<script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
			</script>
		</form>
		<iframe name="ifrOculto" width="0" height="0"></iframe>
	</body>
</HTML>
