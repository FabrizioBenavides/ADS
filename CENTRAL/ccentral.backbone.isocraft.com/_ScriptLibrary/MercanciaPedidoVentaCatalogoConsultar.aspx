<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaPedidoVentaCatalogoConsultar.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaPedidoVentaCatalogoConsultar" codePage="28592" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : MercanciaPedidoVentaCatalogoConsultar.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Consultar los pedidos capturados 
    ' Copyright     : 2012 All rights reserved.
    ' Company       : Farmacias Benavides
    ' Author        : [JAHD] 
    ' Version       : 1.0
    ' Last Modified : 
    '                 31 de Octubre 2012 [JAHD]
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/ToolsValRFC.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

function window_onload() {
		document.forms[0].action = "<%=strFormAction%>";
				
		strFecha = "<%=dtmFechaActual%>";
	    strDiaActual   = strFecha.substring(0,2);	 
     	strMesActual   = strFecha.substring(3,5);	 
     	strAnioActual  = strFecha.substring(6,10);
		
		if (document.forms[0].elements["txtFechaInicio"].value == "") {
		   document.forms[0].elements["txtFechaInicio"].value = "01/" + strMesActual + "/" + strAnioActual;
           document.forms[0].elements["txtFechaFin"].value = strDiaActual + "/" + strMesActual + "/" + strAnioActual;		
		}
		else {	    
		   document.forms[0].elements["txtFechaInicio"].value = "<%=Request.Form("txtFechaInicio")%>"
           document.forms[0].elements["txtFechaFin"].value = "<%=Request.Form("txtFechaFin")%>"
		}
		
        return(true);
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

function cmdValidarForma() {
	if ( (document.forms[0].elements["txtFechaInicio"].value == "") || (document.forms[0].elements["txtFechaFin"].value == "") ) {
	    alert("Por favor seleccione las fechas.");
	    document.forms[0].elements["txtFechaInicio"].focus();
	    return(false);
	}
	else{
		return(true);
	}		
}

function btnSalir_onclick() {
	document.location = 'MercanciaPedidoVentaCatalogo.aspx';
	return(true);
}

function cmdConsultar_onclick(){
	if (cmdValidarForma()==false) {
		return(false);
	}
	else {
		document.forms[0].action = "<%=strFormAction%>?strCmd=Consultar";
		document.forms[0].submit();
		return(true);
	}
}


function strRecordBrowser() {
	document.write("<%=strRecordBrowser%>");
	return(true);
}


//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaPedidoVentaCatalogoConsultar">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"><script language="JavaScript">crearTablaHeader()</script></td>
    </tr>
    <tr> 
      <td valign="top" height="34" width="100%"><img src="../static/images/pixel.gif" width="1" height="34"></td>
    </tr>
    <tr> 
      <td width="100%"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgcolor="#ffffff"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"><span class="txdmigaja">Está en :</span><span class="txdmigaja"> 
              <a href="Mercancia.aspx" class="txdmigaja">Mercancía</a><span class="txdmigaja">: 
              <a class="txdmigaja" href="MercanciaPedido.aspx">Pedidos</a></span> 
              : <a href="MercanciaPedidoVentaCatalogo.aspx" class="txdmigaja">Pedido 
              Venta Catalogo</a> : Consultar pedidos capturados</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Consultar pedido</span> 
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td width="100" valign="middle" class="tdpadleft5"><input name="txtFechaInicio" type="text" class="campotabla" size="10" maxlength="10"> 
                          <a href="javascript:objCalendar1.popup();"><img src="../static/images/icono_calendario.gif" width="20" height="13" border="0"  style="CURSOR:hand"></a></td>
                        <td width="30" align="center" valign="middle" class="tdtittablas">Y:</td>
                        <td width="309" valign="middle" class="tdpadleft5"><input name="txtFechaFin" type="text" class="campotabla" size="10" maxlength="10"> 
                          <a href="javascript:objCalendar2.popup();"><img src="../static/images/icono_calendario.gif" width="20" height="13" border="0" style="CURSOR:hand"></a></td>
                      </tr>
                    </table>
                    <br> <input name="btnSalir" type="button" class="boton" value="Regresar" onClick="return btnSalir_onclick();"> 
                    &nbsp; <input name="btnConsultar" type="button" class="boton" value="Consultar" onClick="return cmdConsultar_onclick();"> 
                    <br> <script language="javascript">strRecordBrowser()</script> 
                  </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	var objCalendar1 = new calendar1(document.forms['frmMercanciaPedidoVentaCatalogoConsultar'].elements['txtFechaInicio']);
	var objCalendar2 = new calendar1(document.forms['frmMercanciaPedidoVentaCatalogoConsultar'].elements['txtFechaFin']);
	//-->
</script>
</form>
</body>
</HTML>
