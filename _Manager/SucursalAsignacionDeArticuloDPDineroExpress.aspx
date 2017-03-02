<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalAsignacionDeArticuloDPDineroExpress.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalAsignacionDeArticuloDPDineroExpress"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
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
		<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
		<script language="JavaScript" src="js/calendario.js"></script>
		<script language="JavaScript" src="js/cal_format00.js"></script>
		<script id="clientEventHandlersJS" language="javascript">

 
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {  
  document.forms[0].action = "<%= strFormAction %>";
 
  document.forms[0].elements["txtTipoOperacionDEXId"].value = "<%= intTipoOperacionDEXId %>";  
  document.forms[0].elements["txtTipoOperacionDEXNombreId"].value = "<%= strTipoOperacionDEXNombreId %>";
  document.forms[0].elements["txtIntArticuloServicioPromocionesArticuloId"].value = "<%= IntArticuloServicioPromocionesArticuloId %>";
 
    
   <%= strJavascriptWindowOnLoadCommands %>
}

//Se Declara el comando Para el CMD, para que se relacione con El Case de .vb 
//11  Junio 2013 JPMB ' cmdGuardar_onclick
function cmdGuardar_onclick ()
{
      document.forms[0].action += "?strCmd=Guardar&intTipoOperacionDEXId=" + <%= intTipoOperacionDEXId()%>;
      document.forms(0).submit();
}

// PPSV JPMB 16/07/2013 Función que verifica si se estan introduciendo datos numéricos
// Entra Como Parte de La Validacion del Bug De las Lista 
function isNumber()
{
	var charCode = event.keyCode;
	if (charCode > 31 && (charCode < 48 || charCode > 57))
	{
		return false;
	}
	return true;
}

function cmdRegresar_onclick() {
    window.location.href = "SucursalAsignacionDeArticuloDineroExpress.aspx";   
}
 //Valida que se ingresen solo numeros con dos decimales maximo
function checkDecimals(fieldName, fieldValue, campo) {

  decallowed = 2;  // Que tantos decimales son permitidos?

  if (isNaN(fieldValue) || fieldValue == "") {
	alert("Por favor introduce un valor numérico en el campo \"" + campo + "\".");
	fieldName.select();
	fieldName.focus();
	return(false)
  }
  else {
    if (fieldValue.indexOf('.') == -1) fieldValue += ".";
    dectext = fieldValue.substring(fieldValue.indexOf('.')+1, fieldValue.length);
	if (dectext.length > decallowed)
	{
	  alert("El valor del campo \"" + campo + "\", debe tener a lo más " + decallowed + " decimales.");
	  fieldName.select();
	  fieldName.focus();
	  return(false);
    }
	else {
	  return(true);
    }
  }
}

function ConsultarArticulo() {
				
	if (blnValidarCampo(document.forms[0].elements["txtIntArticuloServicioPromocionesArticuloId"], true, "Producto específico", cintTipoCampoAlfanumerico, 255, 1, "") == true) {
		
		window.open("../_ScriptLibrary/PopArticulo.aspx?blnSucursal=false&strArticuloIdNombre=" + document.forms[0].elements["txtIntArticuloServicioPromocionesArticuloId"].value + "&strArticulo=txtIntArticuloServicioPromocionesArticuloId&strArticuloNombreId=txtArticuloEncontrado&strEvalJs=opener.AutoSubmit()", "Pop", "width=500,height=540,left=280,top=168,resizable=no,scrollbars=yes,menubar=no,status=no");
		
	}
}

function AutoSubmit() {
	//document.forms[0].elements["txtIntArticuloServicioPromocionesArticuloId"].value = document.forms[0].elements["txtArticuloEncontrado"].value;
	
}

function txtIntArticuloServicioPromocionesArticuloId_onkeydown(objEvent) {
	if (isEnterKey(objEvent)) {
		ConsultarArticulo();
		return(false);
	}
}

function isEnterKey(evt) {

	if (!evt) {
		
		evt = window.event
	} else if (!evt.keyCode) {
		
		evt.keyCode = evt.which
	}
	
	return (evt.keyCode == 13)
}	
		</script>
	</HEAD>
	<body language="javascript" onload="AllClosed();return window_onload()">
		<form method="post" name="frmPage" action="about:blank">
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td>
						<script language="JavaScript">crearTablaHeader()</script>
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td width="10">&nbsp;</td>
					<td class="tdtab" width="770">Está en : <A href="SucursalHome.aspx">Sucursal</A> : 
						Promoción de Servicios :<A href="SucursalAsignacionDeArticuloHome.aspx"> Moviemientos 
							de Dinero </A>: Asignacion de codigo DP&nbsp; Dinero Express
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Promoción Asignación de Artículo&nbsp;Dinero Express</h1>
						<P>Aquí podrá dar de alta o modificar&nbsp;el codigo DP de Dinero Express.</P>
						<P>&nbsp;</P>
						<table border="0" cellSpacing="0" cellPadding="0">
							<tr>
								<td style="WIDTH: 182px" class="tdtexttablebold" height="46" width="182"><label>Tipo de 
										Servicio:</label>
								</td>
								<td class="tdpadleft5"><input class="field" value="Dinero Express" readOnly maxLength="50" size="80">
								</td>
							</tr>
							<tr>
								<td style="WIDTH: 182px">&nbsp;</td>
							</tr>
						</table>
						<h2>Definir&nbsp;Tipo de Movimiento</h2>
						<table border="0" cellSpacing="0" cellPadding="0">
							<tr>
								<td style="WIDTH: 179px" class="tdtexttablebold"><label for="txtServicioNombre">Descripción 
										Moviemiento:</label>
								</td>
								<td class="tdpadleft5"><input id="txtTipoOperacionDEXNombreId" class="field" readOnly maxLength="80" size="80"
										name="txtTipoOperacionDEXNombreId">
								</td>
							</tr>
							<tr>
								<td style="WIDTH: 179px" class="tdtexttablebold"><label for="txtIntArticuloServicioPromocionesArticuloId">Artículo 
										ID :</label>
								</td>
								<td class="tdpadleft5">
								
								<input id="txtIntArticuloServicioPromocionesArticuloId" class="field" maxLength="80" size="80" name="txtIntArticuloServicioPromocionesArticuloId" onkeydown="return txtIntArticuloServicioPromocionesArticuloId_onkeydown(event)">

								<a href="javascript:ConsultarArticulo()"><img height="17" src="../static/images/icono_lupa.gif" width="17" align="absMiddle" border="0"></a>
    					        <input name="txtArticuloEncontrado" type="text" class="campotablaresultado" size="40" border="0" id="txtArticuloEncontrado"  onchange="javascript:AsignarValorCampo()" readonly>
										
										
								</td>
							</tr>
						</table>
						<br>
						<br>
						<table>
							<tr>
								<td class="tdtexttablebold" vAlign="top" align="right" colSpan="2"><input language="javascript" class="button" id="cmdRegresar" onclick="return cmdRegresar_onclick()"
										type="button" value="Regresar" name="cmdRegresar">
								</td>
								<td class="tdtexttablebold" vAlign="top" align="right" colSpan="2"><input class="button" onclick="return cmdGuardar_onclick()" type="button" value="Guardar"
										name="cmdGuardar">
								</td>
							</tr>
						</table>
						<table>
							<TBODY>
								<tr>
									<td class="tdpadleft5" width="499"><input style="DISPLAY: none" id="txtTipoOperacionDEXId" class="campotablaresultado" readOnly
											maxLength="80" size="80" name="txtTipoOperacionDEXId">
									</td>
								</tr>
					</td>
				</tr>
			</table>
			<table border="0" cellSpacing="0" cellPadding="0" width="780">
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
			<script>
				function AllClosed() {
				var table = document.all? document.all.tableRegistro : document.getElementById('tableRegistro');   
			    }			
			</script>
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
