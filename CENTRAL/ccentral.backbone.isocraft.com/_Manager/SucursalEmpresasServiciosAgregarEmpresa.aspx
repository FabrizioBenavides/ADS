<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SucursalEmpresasServiciosAgregarEmpresa.aspx.vb" Inherits="com.isocraft.backbone.ccentral.SucursalEmpresasServiciosAgregarEmpresa"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="css/menu.css" type="text/css" rel="stylesheet">
			<LINK href="css/estilo.css" type="text/css" rel="stylesheet">
				<script language="JavaScript" src="js/menu.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/menu_items.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/menu_tpl.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/headerfooter.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="../static/scripts/Tools.js" type="text/JavaScript"></script>
				<script language="JavaScript" src="js/calendario.js"></script>
				<script language="JavaScript" src="js/cal_format00.js"></script>
				<script language="javascript" id="clientEventHandlersJS"></script> 
				<script language="JavaScript" type="text/JavaScript">
<!--

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() 
{   
   document.forms[0].action = "<%= strFormAction %>";
   
   if("<%= strCmd %>" == "Editar")
	{
   
		//document.forms[0].elements["txtEmpresaServicioId"].value = "<%= intEmpresaServicioId %>";
		document.forms[0].elements["txtEmpresaServicioNombre"].value = "<%= strEmpresaServicioNombre %>";
		document.forms[0].elements["chkEmpresaServicioActiva"].checked = <%= blnEmpresaServicioActiva.ToString().ToLower() %>;   
		document.forms[0].elements["chkEmpresaServicioSolicitarRecaptura"].checked = <%= blnEmpresaServicioSolicitarRecaptura.ToString().ToLower() %>;   
   
		document.forms[0].elements["txtEmpresaServicioIdAnterior"].value = "<%= intEmpresaServicioIdAnterior %>";
   }
   else
   {
			document.forms[0].elements["chkEmpresaServicioActiva"].checked = true;
			document.forms[0].elements["chkEmpresaServicioSolicitarRecaptura"].checked = true;
   }
   
   document.forms[0].txtEmpresaServicioNombre.focus();
   
   <%= strJavascriptWindowOnLoadCommands %>
}

function cmdGuardar_onclick() {
   var blnReturn = blnFormValidator();
      
   if ( blnReturn == true) {
       document.forms[0].action += "?strCmd=Salvar";
   }
   
   return (blnReturn);
}


function cmdCancelar_onclick() {
   window.location.href = "SucursalEmpresasServiciosAdministrarEmpresas.aspx";
}


function blnFormValidator() 
{
   var blnReturn = false;
      		
   			/* Validación del campo "txtEmpresaNombre" */
			if(blnValidarCampo(document.forms[0].elements["txtEmpresaServicioNombre"], true, "Nombre de la Empresa", cintTipoCampoAlfanumerico, 80, 1, "") == true)
			{
        		blnReturn = true;
        	}	
			else 
           	{
           		document.forms[0].elements["txtEmpresaServicioNombre"].focus();
           		blnReturn = false;
			}
			
   return (blnReturn);
}

//-->
				</script>
	</HEAD>
	<body onload="window_onload();">
		<form name="SucursalEmpresasServiciosAgregarEmpresa" action="about:blank" method="post">
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
					<td class="tdtab" width="770">Está en : <A href="SucursalHome.aspx">Sucursal</A> : <A href="SucursalEmpresasServiciosHome.aspx">
							Empresas de Servicios :</A> <A href="SucursalEmpresasServiciosAdministrarEmpresas.aspx">
							Administrar Empresas </A>: Datos de la Empresa
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0">
				<tr>
					<td class="tdgeneralcontent">
						<h1>Datos de la empresa</h1>
						<p>Aquí podrá dar de alta y modificar una empresa.</p>
						<h2>Definir empresa</h2>
						<table cellSpacing="0" cellPadding="0" border="0">
							<tr>
								<td class="tdtexttablebold" width="164" height="46"><label for="txtEmpresaNombre">Nombre de la Empresa:</label>
								</td>
								<td class="tdpadleft5"><input class="field" id="txtEmpresaServicioNombre" type="text" maxLength="50" size="80"
										name="txtEmpresaServicioNombre">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="164"><label for="chkEmpresaActiva">¿Activa?</label>
								</td>
								<td class="tdpadleft5"><input class="fieldborderless" id="chkEmpresaServicioActiva" type="checkbox" CHECKED value="True"
										name="chkEmpresaServicioActiva">
								</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" width="164"><label for="chkSolicitarRecaptura">¿Solicitar 
            Recaptura?</label>
								</td>
								<td class="tdpadleft5"><INPUT class="fieldborderless" id="chkEmpresaServicioSolicitarRecaptura" type="checkbox"
										CHECKED value="True" name="chkEmpresaServicioSolicitarRecaptura">
								</td>
							</tr>
							<tr>
								<td class="txaccion" vAlign="top" align="right" colSpan="2" height="10">&nbsp;</td>
							</tr>
							<tr>
								<td class="tdtexttablebold" vAlign="top" colSpan="2">
								<input language="javascript" class="button" id="cmdCancelar" onclick="return cmdCancelar_onclick()"
										type="button" value="Regresar" name="cmdCancelar"> 
								<input language="javascript" class="button" id="cmdGuardar" onclick="return cmdGuardar_onclick()"
										type="submit" value="Guardar" name="cmdGuardar">
								</td>
							</tr>
						</table>
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
			<input type="hidden" name="txtEmpresaServicioIdAnterior"> <input type="hidden" name="txtEmpresaServicioId">
			<script language="JavaScript">
    <!--
    new menu (MENU_ITEMS, MENU_POS);
    //-->
			</script>
		</form>
	</body>
</HTML>
