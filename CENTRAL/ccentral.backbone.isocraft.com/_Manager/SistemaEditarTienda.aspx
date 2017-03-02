<%@ Page CodeBehind="SistemaEditarTienda.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSistemaEditarTienda" Explicit="True" Trace="False" Strict="True" codePage="1252" %>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" type="text/JavaScript">

strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";


function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
  <%= strLlenarEstadoComboBox() %>
  <%= strLlenarCiudadComboBox() %>
}

function cboEstado_onchange() {
  if (document.forms[0].elements["cboEstado"].selectedIndex > 0) {
      document.forms[0].elements["cboCiudad"].selectedIndex = 0;
      document.forms[0].submit();
  }
  return(true);
}

function blnFormValidator() {
  
  var blnReturn = true;
  var arrIp;
  

  if (document.forms[0].elements("cboEstado").selectedIndex > 0){
    if (document.forms[0].elements("cboCiudad").selectedIndex > 0){
      if(document.forms[0].elements("txtNombreTienda").value.length <= 0){
       blnReturn = false
       alert("Debe escribir el nombre de la tienda");
	   document.forms[0].elements("txtNombreTienda").focus();
      }
      else{
		if(document.forms[0].elements("txtIpConcentrador").value.length <= 0){
		  blnReturn = false
		  alert("Debe especificar la IP del Concentrador de la tienda");
		  document.forms[0].elements("txtIpConcentrador").focus();
		}
		else{
		 arrIp = document.forms[0].elements("txtIpConcentrador").value.split(".");
		 if (arrIp.length < 4){
		   blnReturn = false
		   alert("Debe especificar la IP del Concentrador de la tienda");
		   document.forms[0].elements("txtIpConcentrador").focus();
		 }
		 else{
		  if (blnValidarCampo(document.forms[0].elements["txtPuertoConcentrador"], true, "Puerto Concentrador", cintTipoCampoEntero, 4, 1, "") == true) {
			arrIp = document.forms[0].elements("txtIpADS").value.split(".");
			if (arrIp.length < 4){
				blnReturn = false
				alert("Debe especificar la IP del ADS de la tienda");
				document.forms[0].elements("txtIpADS").focus();
			}
			else{
				if (blnValidarCampo(document.forms[0].elements["txtIpConcentrador"], true, "IP del Concentrador", cintTipoCampoCadenaDefinida, 15, 1, "0123456789.") == true) {
					if (blnValidarCampo(document.forms[0].elements["txtIpADS"], true, "IP del ADS", cintTipoCampoCadenaDefinida, 15, 1, "0123456789.") == true) {
						blnReturn = blnValidarCampo(document.forms[0].elements["txtPuertoADS"], true, "Puerto ADS", cintTipoCampoEntero, 4, 1, "");
					}
				}
			}
	      }
	      else{
	       blnReturn=false;
	      }
		 }
		}
	  }
	}
	else{
	  blnReturn = false
	  alert("Debe selecionar una ciudad para ralizar \n\r la administración de tiendas");
	  document.forms[0].elements("cboCiudad").focus();
	}
  }
  else {
	  blnReturn = false
	  alert("Debe selecionar un Estado para ralizar \n\r la administración de tiendas");
	  document.forms[0].elements("cboEstado").focus();
	}
  return (blnReturn);
}

function cmdActualizar_onclick() {
  document.forms[0].elements("strCmd").value="Actualizar";
  if (blnFormValidator()){
     document.forms[0].submit(); 
     return(true);
  }
  else{
     return(false);
  }
}

function cmdAgregar_onclick() {
  document.forms[0].elements("strCmd").value="SalvarAgregar";
  if (blnFormValidator()){
     document.forms[0].submit(); 
     return(true);
  }
  else{
     return(false);
  }
}

function cmdNavegadorRegistrosAgregar_onclick(intTiendaId,intDireccionId,intZonaId) {
  if((document.forms[0].elements["cboEstado"].selectedIndex > 0) && document.forms[0].elements["cboEstado"].selectedIndex > 0){
	var strEstadoNombre = document.forms[0].elements["cboEstado"].options[document.forms[0].elements["cboEstado"].selectedIndex].text;
	var strCiudadNombre = document.forms[0].elements["cboCiudad"].options[document.forms[0].elements["cboCiudad"].selectedIndex].text;
	var strTiendaNombre = document.forms[0].elements["txtNombreTienda"].value;
	return Pop("popSistemaVincularSucursal.aspx?intTiendaId=" + intTiendaId + "&strTiendaNombre=" + strTiendaNombre + "&intDireccionId=" + intDireccionId + "&intZonaId=" + intZonaId + "&strEstadoNombre=" + strEstadoNombre + "&strCiudadNombre=" + strCiudadNombre,"360","620")
	
  }
  else{
	alert("Es necesario selecionar un estado y una ciudad \n\r para vincular sucursales a la Tienda");
  }
}

function cmdRegresar_onclick() {
  window.location.href = "<%= "SistemaAdministrarTiendas.aspx?strCmd=Consultar&intDireccionId=" & intDireccionId & "&intZonaId=" & intZonaId %>";
}

</script>
</HEAD>
<body onload="return window_onload()">
<form method="post" action="about:blank" name="frmSistemaEditarTienda">
  <input type="hidden" name="intTiendaId" value="<%=intTiendaId%>">
  <input type="hidden" name="intDireccionId" value="<%=intDireccionId%>">
  <input type="hidden" name="intZonaId" value="<%=intZonaId%>">
  <input type="hidden" name="strCmd" value="<%=strCmd%>">
  <input type="hidden" name="txtSucursales">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Está en : Sistema : Administrar tiendas : Editar tienda </td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
  <tr>
  <td class="tdgeneralcontent">
  <h1>Editar tienda </h1>
  <p>Capture o edite los datos de la tienda real. Use la tabla de abajo para vincular / desvincular sucursales a la tienda. </p>
  <table width="60%" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="40%" class="tdtexttablebold">Estado:</td>
      <td width="60%" class="tdpadleft5"><select name="cboEstado" class="field" onchange="cboEstado_onchange();">
          <option value="0" selected>Elija una estado</option>
        </select>
      </td>
    </tr>
    <tr>
      <td width="40%" class="tdtexttablebold">Ciudad:</td>
      <td width="60%" class="tdpadleft5"><select name="cboCiudad" class="field">
          <option value="0" selected>Elija una ciudad</option>
        </select>
      </td>
    </tr>
    <%=strHTMLTienda%> <br>
    <br>
    <br>
    <%=strHTMLSucursalesVinculadas%>
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
