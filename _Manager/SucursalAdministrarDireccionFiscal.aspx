<%@ Page CodeBehind="SucursalAdministrarDireccionFiscal.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsSucursalAdministrarDireccionFiscal" codePage="1252" EnableSessionState="False" enableViewState="False"%>
<html>
<head>
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/menu.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_items.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/menu_tpl.js"></script>
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script language="JavaScript" type="text/JavaScript" src="../static/scripts/Tools.js"></script>
<script id=clientEventHandlersJS language="JavaScript" >
strUsuarioNombre = "<%= strUsuarioNombre %>";
strFechaHora = "<%= strHTMLFechaHora %>";

if (parent.parent.document.getElementById('cboDireccion') != null){
	parent.evalInWindow('<%= me.strActions(Request("strCmd"))%>');		
} 

//-->
</script>
<%if Request("strCmd") ="" then %>
<script language="javascript" id="MarcaRolloJS">
<!--

function evalInWindow(str){
	return eval(str);
}

function doSubmit(){
    args = doSubmit.arguments;
    var action = args[0];
	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{params+= "&" + args[i] + "=" + args[i+1]}
    document.forms[0].action = "<%= strThisPageName %>?strCmd=" + action + params
	document.forms[0].target="ifrOculto";
    document.forms[0].submit();  
}

function window_onload() {
  document.forms[0].action = "<%= strThisPageName %>";
	<%= strJavascriptWindowOnLoadCommands %>
	<%= strLlenarDireccionComboBox() %>
	<%= strLlenarEstadosComboBox() %> 		
	return true;
}

function cboDireccion_onchange() {
  document.forms[0].elements["cboZona"].selectedIndex = 0;
  document.forms[0].elements["cboSucursal"].selectedIndex = 0;
	return doSubmit('getComboZona');  
}

function cboZona_onchange() {
  document.forms[0].elements["cboSucursal"].selectedIndex = 0;
	return doSubmit('getComboSucursal');  
}

function cboEstado_onchange() {	
	document.forms[0].elements["cboCiudad"].selectedIndex = 0;
	return doSubmit('getComboCiudad');  
}


function cboSucursal_onchange(comboSucursal) {
	if (comboSucursal.value!="0|0"){ 
		cleanDireccion();
		document.getElementById('divDireccion').style.display="block";		
		doSubmit('getDireccionSucursal');	
	}else{
		cleanDireccion();		
	}
	return(true);
}
function cleanDireccion(){
		document.getElementById('divDireccion').style.display="none";
		document.getElementById('txtSucursalDireccionCalle').value=""
		document.getElementById('txtSucursalDireccionNoExterior').value=""
		document.getElementById('txtSucursalDireccionNoInterior').value=""	
		document.getElementById('txtSucursalDireccionColonia').value=""
		document.getElementById('cboEstado').value="0"	
		DeleteComboBoxElements(document.forms[0].elements["cboCiudad"], 1);	
		document.getElementById('cboCiudad').value="0"		
		document.getElementById('txtSucursalDireccionCodigoPostal').value=""
}

function cmdSalvar_onclick() {
	if (document.getElementById('txtSucursalDireccionCalle').value=='')
	{document.getElementById('txtSucursalDireccionCalle').focus();return alert('Favor de Capturar la Calle');}
	
	if (document.getElementById('txtSucursalDireccionNoExterior').value=='')
	{document.getElementById('txtSucursalDireccionNoExterior').focus();return alert('Favor de Capturar el No. Exterior');}
	
	if (document.getElementById('txtSucursalDireccionNoInterior').value=='')
	{document.getElementById('txtSucursalDireccionNoInterior').focus();return alert('Favor de Capturar el No. Interior');}
	
	if (document.getElementById('txtSucursalDireccionColonia').value=='')
	{document.getElementById('txtSucursalDireccionColonia').focus();return alert('Favor de Capturar la Colonia');}
	
	if (document.getElementById('cboEstado').value=='0')
	{document.getElementById('cboEstado').focus();return alert('Favor de Capturar el Estado');}
	
	if (document.getElementById('cboCiudad').value=='0')
	{document.getElementById('cboCiudad').focus();return alert('Favor de Capturar la Ciudad');}
	
	if (document.getElementById('txtSucursalDireccionCodigoPostal').value=='')
	{document.getElementById('txtSucursalDireccionCodigoPostal').focus();return alert('Favor de Capturar el Codigo Postal');}	
	
	doSubmit('updateDireccionSucursal');	
	
  return(true);
}

function blnFormValidator(theForm) {  
  var blnReturn = true;  
  /* Validación del campo "txtFolioValorActual" 
  if (blnValidarCampo(theForm.elements["txtFolioValorActual"], true, "Valor actual", cintTipoCampoEntero, 10, 1, "") == true) {  
     Validación del campo "txtFolioValorMaximo" 
    blnReturn = blnValidarCampo(theForm.elements["txtFolioValorMaximo"], true, "Valor máximo", cintTipoCampoEntero, 10, 1, "");  
  } 
  */
  return (blnReturn);
}
//-->
</script>
</HEAD>
<body onload="return window_onload()">
<form method="POST" action="about:blank" name="frmSucursalAdministrarDireccionFiscal" onSubmit="return blnFormValidator(this)">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaHeader()</script>
      </td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="10">&nbsp;</td>
      <td width="770" class="tdtab">Est&aacute; en : Sucursal : Consultar Direcci&oacute;n</td>
    </tr>
  </table>
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr>
      <td class="tdgeneralcontent"><h1>Consultar Direcci&oacute;n de Sucursal </h1>
        <p>Para asignar los valores elija Direcci&oacute;n, Zona y Sucursal.</p>
        <table width="60%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="16%" class="tdtexttablebold">* Direcci&oacute;n: </td>
            <td width="84%" class="tdpadleft5"><select name="cboDireccion" class="field" id="cboDireccion" language=javascript onchange="return cboDireccion_onchange()">
                <option value="0">Elija una direcci&oacute;n </option selected>
              </select>
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold">* Zona: </td>
            <td class="tdpadleft5"><select name="cboZona" class="field" id="cboZona" language=javascript onchange="return cboZona_onchange()">
                <option value="0">Elija una zona </option selected>
              </select>
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Sucursal:</td>
            <td class="tdpadleft5"><select name="cboSucursal" class="field" id="cboSucursal" language=javascript onchange="return cboSucursal_onchange(this)">
                <option value="0|0">Elija una sucursal</option selected>
              </select>
            </td>
          </tr>
        </table>
        <br>
        <!--Inicia div de forma de captura de Direccion-->
        <div id="divDireccion" style="display:none">
        <h2>Direcci&oacute;n de la Sucursal Seleccionada</h2>
        <table STYLE="table-layout:fixed" width="100%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td class="tdtexttablebold" width="6%">Calle:</td>
            <td class="tdpadleft5" width="20%">
              <input name="txtSucursalDireccionCalle" type="text" class="field" id="txtSucursalDireccionCalle" size="20" maxlength="50" readonly>
            </td>
            <td class="tdtexttablebold" width="10%">No. Exterior:</td>
            <td class="tdpadleft5" ><input name="txtSucursalDireccionNoExterior" type="text" class="field" id="txtSucursalDireccionNoExterior" size="20" maxlength="15" readonly>
            </td>
            <td class="tdtexttablebold" width="10%">No. Interior:</td>
            <td class="tdpadleft5"><input name="txtSucursalDireccionNoInterior" type="text" class="field" id="txtSucursalDireccionNoInterior" size="20" maxlength="15" readonly>
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold">Colonia: </td>
            <td class="tdpadleft5"><input name="txtSucursalDireccionColonia" type="text" class="field" id="txtSucursalDireccionColonia" size="20" maxlength="50" readonly>
            </td>
            <td class="tdtexttablebold">Estado: </td>
            <td class="tdpadleft5"><select name="cboEstado" class="field" id="cboEstado" onchange="return cboEstado_onchange()" disabled>
                <option value="0">Elija un Estado</option selected>
              </select>
            </td>
            <td class="tdtexttablebold">Ciudad: </td>
            <td class="tdpadleft5"><select name="cboCiudad" class="field" id="cboCiudad"  disabled>
                <option value="0">Elija una Ciudad</option selected>
              </select>
            </td>
          </tr>
          <tr>
            <td class="tdtexttablebold">C.P.: </td>
            <td class="tdpadleft5"><input name="txtSucursalDireccionCodigoPostal" type="text" class="field" id="txtSucursalDireccionCodigoPostal" size="20" maxlength="15" readonly>
            </td>
          </tr>
          <tr>
            <td align=right colspan=6>&nbsp;</td>
          </tr>
        </table>
        <br>
      </td>
    </tr>
  </table>
  </div>
  <!--Termina div de forma de captura de Direccion-->
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td><script language="JavaScript">crearTablaFooterCentral()</script>
      </td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
</script>
</form>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
</body>
<%End If%>
</HEAD>
</HTML>
