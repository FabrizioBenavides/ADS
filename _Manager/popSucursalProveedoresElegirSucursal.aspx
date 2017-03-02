<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" enableViewState="False" Explicit="True" Trace="False" Strict="True" CodeBehind="popSucursalProveedoresElegirSucursal.aspx.vb"      Inherits="com.isocraft.backbone.ccentral.popSucursalProveedoresElegirSucursal" codePage="28592" %>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<script language="JavaScript" type="text/JavaScript" src="js/headerfooter.js"></script>
<script id="clientEventHandlersJS" language="javascript">

var blnRegresaSucursal =false;
strFechaHora = "<%= strHTMLFechaHora %>";

function window_onload() {
   document.forms[0].action = "<%= strFormAction %>";   
   var intCadenaId = "<%= intCadenaId %>";
   
   <%= strLlenarEstadoComboBox() %>
   <%= strLlenarCiudadComboBox() %>
   <%= strLlenarSucursalComboBox() %>
   <%= strJavascriptWindowOnLoadCommands %>
   
   document.forms[0].elements["cboCadena"].options[intCadenaId].selected = true;
  
}

function cboEstado_onchange() {
   if (document.forms[0].elements["cboEstado"].selectedIndex > 0) {
       document.forms[0].elements["cboCiudad"].selectedIndex = 0;
       
       document.forms[0].action = "<%= strFormAction %>"+'?campoSucursalNumero=' + '<%=Request.QueryString("campoSucursalNumero")%>' + '&campoSucursalNombre=' + '<%=Request.QueryString("campoSucursalNombre")%>';
       document.forms[0].submit();
   }
   return(true);
}

function cboCiudad_onchange() {
   if (document.forms[0].elements["cboCiudad"].selectedIndex > 0) {
       document.forms[0].elements["cboSucursal"].selectedIndex = 0;
       
       document.forms[0].action = "<%= strFormAction %>"+'?campoSucursalNumero=' + '<%=Request.QueryString("campoSucursalNumero")%>' + '&campoSucursalNombre=' + '<%=Request.QueryString("campoSucursalNombre")%>';
       document.forms[0].submit();
   }
   return(true);
}

function cboCadena_onchange() {
       document.forms[0].elements["cboSucursal"].selectedIndex = 0;       
       document.forms[0].action = "<%= strFormAction %>"+'?campoSucursalNumero=' + '<%=Request.QueryString("campoSucursalNumero")%>' + '&campoSucursalNombre=' + '<%=Request.QueryString("campoSucursalNombre")%>';
       document.forms[0].submit();

   return(true);
}

function cboSucursal_onchange() {
   if (document.forms[0].elements["cboSucursal"].selectedIndex > 0) {
       blnRegresaSucursal = true;         
	   self.close();
   }

}

function CloseError() {
    self.close();
    return;
}

function cmdCancelar_onclick() {
    self.close();
    return;
}


function window_onunload() {
   window.onerror=CloseError;
   
   if (blnRegresaSucursal) {   
	  
      var strCampoDestino = "";	    
      
      
      strCampoDestino = '<%=Request.QueryString("campoSucursalNumero")%>';        
      if (strCampoDestino.length > 0) {
         opener.document.forms[0].elements[strCampoDestino].value = document.forms[0].elements["cboSucursal"].value;
      }    
      
      strCampoDestino = '<%=Request.QueryString("campoSucursalNombre")%>';  
      if (strCampoDestino.length > 0) {
        opener.document.forms[0].elements[strCampoDestino].value = document.forms[0].elements["cboSucursal"].options[document.forms[0].elements["cboSucursal"].selectedIndex].text;
      }
   }
   
}


</script>
</HEAD>
<body onload="return window_onload()" onunload="return window_onunload()">
<form method="post" action="about:blank">
  <table width="450" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td width="450" class="tdgeneralcontentpop"><h2> Seleccionar Sucursal(es)</h2>
        <table cellSpacing="0" cellPadding="0" width="100%" border="0">
          <tr> 
            <td class="tdtexttablebold" width="30%">* Estado:</td>
            <td class="tdpadleft5" width="70%"> <select name="cboEstado" class="field" id="cboEstado" language="javascript" onChange="return cboEstado_onchange()">
                <option value="0" selected>--- Elija un estado ---</option>
                <option>--------------------</option>
              </select> </td>
          </tr>
          <tr> 
            <td class="tdtexttablebold" width="30%">* Ciudad:</td>
            <td class="tdpadleft5" width="70%"><select name="cboCiudad" class="field" id="cboCiudad" onchange="return cboCiudad_onchange()">
                <option value="0" selected>-- Elija una ciudad --</option>
                <option>--------------------</option>
              </select> </td>
          </tr>
          <tr> 
            <td class="tdtexttablebold" width="30%">* Cadena:</td>
            <td class="tdpadleft5" width="70%"><select name="cboCadena" class="field" id="cboCadena" onchange="return cboCadena_onchange()">
                <option value="0" selected>--- Todas ---</option>
                <option value="1">FARMACIAS BENAVIDES S.A.B. DE C.V.</option>
                <option value="2">FARMACIAS ABC DE MEXICO S.A. DE C.V.</option>
              </select> </td>
          </tr>
          <tr> 
            <td class="tdtexttablebold" width="30%">* Sucursal:</td>
            <td class="tdpadleft5" width="70%"> <select name="cboSucursal" class="field" id="cboSucursal" onchange="return cboSucursal_onchange()">
                <option value="0" selected>-- Elija una sucursal --</option>
                <option>--------------------</option>
              </select> </td>
          </tr>
        </table>
        <br> <input name="cmdCancelar" type="button" class="button" value="Cancelar" onclick="return cmdCancelar_onclick()"> 
      </td>
    </tr>
  </table>
</form>
</body>
</HTML>
