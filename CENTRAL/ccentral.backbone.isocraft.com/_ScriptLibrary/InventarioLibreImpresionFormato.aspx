<%@ Page CodeBehind="InventarioLibreImpresionFormato.aspx.vb" Language="vb" AutoEventWireup="false" Inherits="com.isocraft.backbone.ccentral.clsInventarioLibreImpresionFormato" Explicit="True" Trace="False" Strict="True" codePage="1252"  EnableSessionState="true" enableViewState="False" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : InventarioLibreImpresionFormato.aspx
    ' Title         : Inventarios Libre
    ' Description   : Impresion Formato de Inventarios Libre
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Carolina Caballero
    ' Version       : 1.0	
    ' Last Modified : Monday, Nov 1st, 2004
	'
	'
    '====================================================================
%>
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
  var result = false
  var msg = validateInteger(window.document.forms[0].intTotalLineas.value)
  if (msg != "")
  {
	alert ("El valor de Número de Líneas " + msg)
  }
  else
  {
	result = true
  }
 
  return result;
}

function window_onload(){
  //  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  //  document.forms[0].action="<%=strFormAction%>";
  return true
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
                Libre</a> : Imprimir Formato</span></div></td>
            <td width="182" class="tdfechahora"><div id="ToPrintTxtFecha"> 
                <script language="JavaScript">strGetCustomDateTime()</script>
              </div></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td vAlign="top" width="583"> <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                <tr> 
                  <td class="tdtablacont" vAlign="top" width="100%" colSpan="3"> 
                    <span class="txtitulo">Imprimir Formato </span><span class="txtitulo">Listados</span><span class="txcontenido"></span><span class="txcontenido">&nbsp;Ingrese 
                    el número de líneas que necesite para&nbsp;el formato y oprima 
                    "Imprimir Formato"</span><span class="txsubtitulo"><br>
                    <table height="27" cellSpacing="0" cellPadding="0" width="100%" border="0">
                      <tr> 
                        <td class="tdtittablas" width="10%">Sucursal: </td>
                        <td class="tdconttablas" width="50%"><asp:textbox id="sucursalNombre" runat="server" readonly size="70" CssClass="fieldborderless"></asp:textbox></td>
                        <TD class="tdtittablas" align="right" width="30%">Fecha 
                          Actual:</TD>
                        <TD class="tdconttablas" width="10%"><asp:textbox id="fechaActual" runat="server" readonly size="12" CssClass="fieldborderless"></asp:textbox></TD>
                      </tr>
                    </table>
                    <br>
                    <span class="txsubtitulo"> <IMG height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle"> 
                    Configurar formato de Impresión</span> <br>
                    &nbsp; <span class="tdtittablas">¿Cuantas líneas necesita? 
                    </span> &nbsp; 
                    <asp:textbox id="intTotalLineas" runat="server" MaxLength="0" CssClass="campo"></asp:textbox>
                    <br>
                    <br>
                    <input class="boton" id="btnImprimirFormato" type="submit" value="Imprimir Formato" name="btnImprimirFormato" runat="server" onserverclick="btnImprimirFormato_Click">
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
      <td> <input type="hidden" value="0" name="documentPrinted"> <input type="hidden" name="actionName"></td>
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
