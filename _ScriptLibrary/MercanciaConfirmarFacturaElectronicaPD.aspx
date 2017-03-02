<!--codePage="28592"-->
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConfirmarFacturaElectronicaPD.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaConfirmarFacturaElectronicaProveedoresDirectos" %>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
			'====================================================================
			' Page          : MercanciaConfirmarFacturaElectronicaProveedoresDirectos.aspx
			' Title         : Administracion POS y BackOffice
			' Description   : Página usada para mostrar las facturas pendientes de los proveedores directos.
			' Copyright     : 2012 All rights reserved.
			' Company       : Benavides
			' Consulting C. : Softtek
			' Author        : Victor Ollervides [VHOV]
			' Version       : 1.0
			' Created		: 04 de Junio de 2012
			' Last Modified : 
			'     
			'====================================================================
		%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
<meta name=vs_defaultClientScript content="JavaScript">
<meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
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
				
			function window_onload(){
			MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
			document.forms[0].action="<%=strFormAction%>";
				
			var strMensaje = "<%=strMensaje%>";
			if (strMensaje!=""){
					alert(strMensaje);
			}
			}

			function strGetCustomDateTime() {
				document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
				return(true);
			}

			function strRecordBrowserHTML() {
				document.write("<%=strRecordBrowserHTML%>");
				return(true);
			}

			function frmMercanciaConfirmarFacturaElectronicaProveedoresDirectos_onsubmit() {
			valida=true;
			return(valida);
			}

			function cmdRegresar_onclick() {
			//Ir a la página de Compras Directas
			window.location  = "MercanciaEntradasComprasDirectas.aspx";      
			}

		//-->
		</script>
</HEAD>
<body	MS_POSITIONING="FlowLayout" 
		leftmargin="0" 
		topmargin="0" 
		marginwidth="0" 
		marginheight="0" 
		onLoad="return window_onload()">
<form	action="about:blank" 
		method="post" 
		name="frmMercanciaConfirmarFacturaElectronicaProveedoresDirectos" 
		onSubmit="return frmMercanciaConfirmarFacturaElectronicaProveedoresDirectos_onsubmit()">
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
              : </span> <a	href="Mercancia.aspx" class="txdmigaja"> Mercancía 
              </a> <span class="txdmigaja"> : <a href="MercanciaEntradas.aspx" class="txdmigaja"> 
              Entradas </a> : <a href="MercanciaEntradasComprasDirectas.aspx" class="txdmigaja"> 
              Compras directas </a> : Proveedores por Confirmar </span> </td>
            <td width="182" class="tdfechahora"> <script language="javascript">
								strGetCustomDateTime()
							</script> </td>
          </tr>
          <tr> 
            <td width="10">&nbsp; </td>
            <td width="583" valign="top" class="tdtablacont"> <span class="txtitulo"> 
              Confirmar factura electrónica de proveedores directos </span> <span class="txcontenido"> 
              Para confirmar una factura electrónica, elija primero un proveedor 
              con facturas pendientes. Esto lo llevará a la lista de facturas, 
              donde podrá elegir una para confirmar. <br>
              </span> <script language="JavaScript">
								crearDatosSucursal()
							</script> <br> <script language="javascript">
								strRecordBrowserHTML()
							</script> <br> <input	name="cmdRegresar" 
									type="button" 
									class="boton" 
									value="Regresar" 
									onClick="return cmdRegresar_onclick()"> <br> 
              <br> </td>
            <td width="187" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">
								strGeneraTablaAyuda('');
							</script> </td>
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
