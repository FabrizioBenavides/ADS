<!-- codePage="28592" -->
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaFacturasPorConfirmarPD.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaFacturasPorConfirmarPD" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
		'====================================================================
		' Page          : MercanciaFacturasPorConfirmarPD.aspx
		' Title         : Administracion POS y BackOffice
		' Description   : Página usada para confirmar las facturas pendientes de un proveedor directo. 
		' Copyright     : 2012 All rights reserved.
		' Company       : Benavides
		' Consulting C. : Softtek
		' Author        : Victor Ollervides [VHOV]
		' Version       : 1.0
		' Created		: 11 de Junio de 2012
		' Last Modified : 
		'====================================================================    
	%>
<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
<meta name=vs_defaultClientScript content="JavaScript">
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
	<!--
	
		function strCompaniaSucursal() {
			document.write(<%=intCompaniaId%> + " - " + <%=intSucursalId%>);
			return(true);
		}
		function strSucursalNombre() {
			document.write("&nbsp;"+"<%=strSucursalNombre%>");
			return(true);
		}
		function strGetCustomDateTime() {
			document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
			return(true);
		}
		function strUsuarioNombre() {
			document.write("<%=strUsuarioNombre%>");
			return(true);
		}

		function strRecordBrowserHTML() {
			document.write("<%=strRecordBrowserHTML%>");
			return(true);
		}

		function frmMercanciaFacturasPorConfirmarPD_onsubmit() {
		valida=true;
			return(valida);
		}

		function window_onload(){
		MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
		document.forms[0].action="<%=strFormAction%>";
		   
		var strMensaje = "<%=strMensaje%>";
		if (strMensaje!=""){
			window.alert(strMensaje);
			}
		}

		function cmdRegresar_onclick() {
		window.location  = "MercanciaConfirmarFacturaElectronicaPD.aspx";
		return(true);
		}

	//-->
	</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaFacturasPorConfirmarPD" onSubmit="return frmMercanciaFacturasPorConfirmarPD_onsubmit()">
  <table width="780" border="0" cellpadding="0" cellspacing="0">
    <tr> 
      <td valign="top" height="98" width="100%"> <script language="JavaScript">
						crearTablaHeader()
					</script> </td>
    </tr>
    <tr> 
      <td valign="top" height="34" width="100%"> <img src="../static/images/pixel.gif" width="1" height="34"> 
      </td>
    </tr>
    <tr> 
      <td width="100%"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr> 
            <td width="10" bgcolor="#ffffff"> <img src="../static/images/pixel.gif" width="10" height="8"> 
            </td>
            <td width="583" class="tdmigaja"> <span class="txdmigaja"> Está en 
              : <a href="Mercancia.aspx" class="txdmigaja"> Mercancía </a> : <a href="MercanciaEntradas.aspx" class="txdmigaja"> 
              Entradas </a> : <a href="MercanciaEntradasComprasDirectas.aspx" class="txdmigaja"> 
              Compras directas </a> : <a href="MercanciaConfirmarFacturaElectronicaPD.aspx" class="txdmigaja"> 
              Proveedores por Confirmar</a> : Facturas pendientes</span></td>
            <td width="182" class="tdfechahora"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp; </td>
            <td width="583" valign="top" class="tdtablacont"> <span class="txtitulo"> 
              Facturas por confirmar </span> <span class="txcontenido"> Para seguir 
              el proceso de confirmación, elija una factura de la lista. </span> 
              <script language="JavaScript">crearDatosSucursal()</script> <br> 
              <script language="javascript">strRecordBrowserHTML()</script> <br> 
              <input	name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()"> 
              <br></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp; </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"> <script language="JavaScript">
									crearTablaFooter()
								</script> </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <script language="JavaScript">
		<!--
			new menu (MENU_ITEMS, MENU_POS);
			new menu (MENU_ITEMS2, MENU_POS2);
		//-->
		</script>
</form>
</body>
</HTML>
