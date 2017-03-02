<%@ Page CodeBehind="InventarioLibreConsultaDetalle.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsInventarioLibreConsultaDetalle" Explicit="True" Trace="False" Strict="True" codePage="1252"  EnableSessionState="true" enableViewState="False" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : InventarioLibreConsultaDetalle.aspx
    ' Title         : Inventarios Rotativos Por Listados
    ' Description   : Consulta de detalle de Inventarios Libres
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Carolina Caballero
    ' Version       : 1.0
	'
    ' Last Modified : Monday, October 25th, 2004
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA	
    '====================================================================%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<LINK href="../static/css/menu.css" rel="stylesheet">
<LINK href="../static/css/menu2.css" rel="stylesheet">
<LINK href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/Calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/InvRotUtils.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">

<!--
var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";

function strGetCustomDateTime() {
	document.write("<%=Now.toString("dd/MM/yyyy - HH:mm:ss") %>");
	return(true);
}

function validateForm() 
{
    var result = true
    return result;
}

function window_onload(){
  //  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  //  document.forms[0].action="<%=strFormAction%>";
}

function btnRegresar_Click()
{
	window.location.href="InventarioLibreConsulta.aspx"
						   + "?dtmFechaInicial=" + document.forms[0].dtmFechaInicial.value
						   + "&dtmFechaFinal="   + document.forms[0].dtmFechaFinal.value
						 
}
//-->
</script>
</HEAD>
<body leftMargin="0" topMargin="0" onload="return window_onload()" marginwidth="0" marginheight="0">
<form id="Form1" name="frmConsulta" onsubmit="return validateForm()" method="post" runAt="server">
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
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en :</span><span class="txdmigaja"> <a href="Mercancia.aspx" class="txdmigaja">Mercancía</a> 
                : <a href="MercanciaInventarios.aspx" class="txdmigaja">Inventarios</a> 
                : <a href="MercanciaInventariosCapturaLibre.aspx" class="txdmigaja">Inventario 
                Libre</a> : Consulta</span></div></td>
            <td width="182" class="tdfechahora"><script language="JavaScript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td vAlign="top" width="583"> <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtablacont" vAlign="top" width="100%" colSpan="3"><span class="txtitulo">Detalle 
                    de&nbsp;Inventario Libre</span><span class="txcontenido">&nbsp;<br>
                    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                      <tr> 
                        <td class="tdtittablas" width="20%">Sucursal: </td>
                        <td class="tdconttablas" width="50"><asp:textbox id="sucursalNombre" Columns="50" runat="server" MaxLength="0" CssClass="fieldborderless"></asp:textbox></td>
                        <TD class="tdtittablas" width="20%"> <P align="right"> 
                            Fecha Actual:</P></TD>
                        <TD class="tdconttablas" width="10%"><asp:textbox id="fechaActual" runat="server" MaxLength="0" CssClass="fieldborderless"></asp:textbox></TD>
                      </tr>
                      <tr> 
                        <td class="tdtittablas">Folio:</td>
                        <td class="tdconttablas"><asp:textbox id="intFolioId" runat="server" MaxLength="0" CssClass="fieldborderless"></asp:textbox></td>
                        <TD class="tdtittablas"> </TD>
                        <TD class="tdconttablas"></TD>
                      </tr>
                    </table>
                    <br>
                    <%= strRecordBrowserHTML %> <br>
                    <input class="boton" id="btnRegresar" type="button" value="Regresar" name="btnRegresar" onclick="javascript:btnRegresar_Click()">
                    <input class="boton" id="btnImprimir" type="submit" value="Imprimir" name="btnImprimir" runat="server" onserverclick="btnImprimir_Click">
                    <input class="boton" id="btnImprimirDiferencias" type="submit" value="Imprimir Diferencias" name="btnImprimirDiferencias" runat="server" onserverclick="btnImprimirDiferencias_Click">
                    </span> </td>
                </tr>
              </table></td>
            <td class="tdcolumnader" vAlign="top" width="182" rowSpan="2"> <script language="javascript">strGeneraTablaAyuda('');</script> 
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
    <tr> 
      <td>> <input id="intTimestamp" type="hidden" name="intTimestamp" runat="server"> 
        <input id="dtmFechaInicial" type="hidden" name="dtmFechaInicial" runat="server"> 
        <input id="dtmFechaFinal" type="hidden" name="dtmFechaFinal" runat="server"> 
        <input type="hidden" value="0" name="documentPrinted"></td>
    </tr>
  </table>
  <script language="JavaScript">
				<!--
				new menu (MENU_ITEMS, MENU_POS);
				new menu (MENU_ITEMS2, MENU_POS2);
				//-->
			</script>
</form>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
</body>
</HTML>
