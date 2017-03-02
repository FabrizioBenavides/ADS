<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" enableViewState="False" Explicit="True" Trace="False" Strict="True" CodeBehind="VentasFacturacionGlobalDiaria.aspx.vb" Inherits="com.isocraft.backbone.ccentral.VentasFacturacionGlobalDiaria" codePage="28592" %>
<HTML>
<HEAD>
<title>Benavides : Administrador del Sistema Concentrador (CTX)</title>
<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link href="css/menu.css" rel="stylesheet" type="text/css">
<link href="css/estilo.css" rel="stylesheet" type="text/css">
<link href="css/estiloimpresion.css" rel="stylesheet" media="print" type="text/css">
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

   <%= strLlenarComboBoxAnio() %>  
   <%= strLlenarComboBoxMes() %>  
   
   document.forms[0].elements["cboCadena"].options[<%= intCadenaId %>].selected = true;

   <%= strJavascriptWindowOnLoadCommands %>

}

function cboAnio_onchange() {
   if (document.forms[0].elements["cboAnio"].selectedIndex > 0 && document.forms[0].elements["cboMes"].selectedIndex > 0 && document.forms[0].elements["cboCadena"].selectedIndex > 0) {
       document.forms[0].action = '<%= strFormAction %>';
   	   document.forms[0].target='';
       document.forms[0].submit(); 
    }
}
function cboMes_onchange() {
   if (document.forms[0].elements["cboAnio"].selectedIndex > 0 && document.forms[0].elements["cboMes"].selectedIndex > 0 && document.forms[0].elements["cboCadena"].selectedIndex > 0) {
       document.forms[0].action = '<%= strFormAction %>';
   	   document.forms[0].target='';
       document.forms[0].submit(); 
    }
}

function cboCadena_onchange() {
   if (document.forms[0].elements["cboAnio"].selectedIndex > 0 && document.forms[0].elements["cboMes"].selectedIndex > 0 && document.forms[0].elements["cboCadena"].selectedIndex > 0) {
       document.forms[0].action = '<%= strFormAction %>';
   	   document.forms[0].target='';
       document.forms[0].submit(); 
    }
}

function  cmdConsultar_onclick() {
   if (blnValidarSubmit()) {
       document.forms[0].action= '<%= strFormAction %>?strCmd=buscar'; 
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';    
    }
}

function blnValidarSubmit() {
   var blnValidar = true;
   
   if ( document.forms[0].elements["cboAnio"].selectedIndex == 0 && document.forms[0].elements["cboMes"].selectedIndex == 0 && document.forms[0].elements["cboCadena"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar A&ntilde;o, Mes y Cadena");
   }   
   if ( blnValidar && document.forms[0].elements["cboAnio"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar el criterio de A&ntilde;o");
   }
   
   if ( blnValidar && document.forms[0].elements["cboMes"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar el criterio de Mes");
   }  
   if ( blnValidar && document.forms[0].elements["cboCadena"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar el criterio de Cadena");
   }   

   return blnValidar;
   
}

function fnUpConsultar(strRecordBrowserHTML){
    document.all.divDetalle.innerHTML = strRecordBrowserHTML;	
}

function fnUpGenerar(intResultado,strRecordBrowserHTML,strFolioPrefijo,strDiaGenerado){
    var blnmsg = true;
	
    if (intResultado >0) {	
       document.all.divDetalle.innerHTML = strRecordBrowserHTML;
	   alert ("Se genero y envio a sign@ture la Factura del día " + strDiaGenerado + "\n\r\n\r Consultar en el portal con Folio Interno: " + strFolioPrefijo + ' - '  + intResultado);
	   blnmsg = false;
	}
	if (blnmsg && intResultado == "-140") {
       alert("No se puede generar la Factura del día " + strDiaGenerado + "\n\r\n\r [140] No existen datos Fiscales para la Cadena");
	   blnmsg = false;
	}	
	if (intResultado == "-130") {
       alert("No se puede generar la Factura del día " + strDiaGenerado + "\n\r\n\r [130] No existe información de sucursales");
	   blnmsg = false;
	}
	if (blnmsg && intResultado == "-120") {
       alert("No se puede generar la Factura del día " + strDiaGenerado + "\n\r\n\r [120] Ya fue generado anteriormente");
	   blnmsg = false;
	}
	if (blnmsg && intResultado == "-110") {
       alert("No se puede generar la Factura del día " + strDiaGenerado + "\n\r\n\r [110] El día anterior no se a generado");
	   blnmsg = false;
	}
	if (blnmsg && intResultado == "-100") {
       alert("No se puede generar la Factura del día " + strDiaGenerado + "\n\r\n\r [100] No existe Folio Interno de control");
	   blnmsg = false;
	}	
	if (blnmsg) {
	   alert("No se puede generar la Factura del día " + strDiaGenerado + "\n\r\n\r Error en proceso");
	}		
}

function cmdVerSucursales_onclick(intCadenaId,strFechaVenta,intTipoDetalle) {
       url = 'popVentasFacturacionGlobalDiaria.aspx?strCmd=Ver&intCadenaId=' + intCadenaId + "&strFechaVenta=" + strFechaVenta + "&intTipoDetalle=" + intTipoDetalle;       
       var WinVerDetalleSucursal = window.open(url,'PopVerDetalleSucursal','width=720,height=600,left=20,top=10,resizable=no,scrollbars=yes,menubar=no,status=no' );
       
}

function cmdGeneraFactura_onclick(varFecha) {
if (confirm ("Generar Factura del día " + varFecha + "\n\r\n\rSolo continuar \n\r\n\rCuando esten registradas todas las sucursales") )  {
       document.forms[0].action= '<%= strFormAction %>?strCmd=Generar&strFechaVenta=' + varFecha; 
       document.forms[0].target="ifrOculto";
       document.forms[0].submit();
       document.forms[0].target='';
}

}

//-->
		</script>
</HEAD>
<body language="javascript" onLoad="return window_onload()">
<form name="frmVentasFacturacionGlobalDiaria" action="about:blank" method="post">
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td class="tdtab" width="100%">Está en : <a href="VentasHome.aspx">Ventas</a>:Facturación 
        Global Diaria</td>
    </tr>
  </table>
  <table cellspacing="0" cellpadding="0" width="780" border="0">
    <tr> 
      <td width="2%"> 
      <td width="98%" class="tdgeneralcontent"> <table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
          <tr> 
            <td valign="top" height="30"><h1>Facturación Global</h1>
              <p> En esta parte se genera la facura global diaria de las ventas 
                de todas las sucursales.</p></td>
          </tr>
          <tr> 
            <td><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Criterio 
              De Busqueda</span></td>
          </tr>
        </table>
        <table width="100%" class="tdEnvolventeTablaAzul" cellSpacing="0" cellPadding="0" border="0">
          <tr> 
            <td width="15%" class="tdtexttablebold">Año:</td>
            <td width="30%" class="tdpadleft5"> <select name="cboAnio" class="field" id="cboAnio" onchange="return cboAnio_onchange()">
                <option value="0" selected>-- Elija una año --</option>
                <option>--------------------</option>
              </select> </td>
            <td width="15%" class="tdtexttablebold"> Mes:</td>
            <td width="30%" class="tdpadleft5"> <select name="cboMes" class="field" id="cboMes" onchange="return cboMes_onchange()">
                <option value="0" selected>-- Elija una mes --</option>
                <option>--------------------</option>
              </select> </td>
            <td width="10%" class="tdtexttablebold" rowspan="2"><input class="boton" id="cmdConsultar" onclick="return cmdConsultar_onclick()" type="button"
										value="Consultar" name="cmdConsultar"></td>
          </tr>
          <tr > 
            <td width="15%" class="tdtexttablebold" > Cadena: </td>
            <td width="75%" class="tdpadleft5" colspan="3"> <select name="cboCadena" class="field" id="cboCadena" onchange="return cboCadena_onchange()">
                <option value="0" selected>--- Selecionar Cadena ---</option>
                <option value="1">FARMACIAS BENAVIDES S.A.B. DE C.V.</option>
                <option value="2">FARMACIAS ABC DE MEXICO S.A. DE C.V. </option>
              </select> </td>
          </tr>
        </table>
        <br> <div id="divDetalle" name="divDetalle"></div></td>
    </tr>
  </table>
  <table width="780" border="0" cellspacing="0" cellpadding="0">
    <tr> 
      <td><script language="JavaScript">crearTablaFooter()</script></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	//-->
			</script>
</form>
<iframe name="ifrOculto" width="0" height="0"></iframe>
</body>
</HTML>
