<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="true" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="InventarioLibreConsulta.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsInventarioLibreConsulta" codePage="28591" %>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : InventarioLibre.aspx
    ' Title         : Inventarios Rotativos Por Listados
    ' Description   : Captura de Inventarios Rotativos Por Listados
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Carolina Caballero
    ' Version       : 1.0
    ' Last Modified : Monday, October 25th, 2004
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
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
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - HH:mm:ss") %>");
	return(true);
}


function validateForm() {
  valida=true;
  
  if (currentAction=="filtrar")
  {
  	if (document.forms[0].dtmFechaInicial.value.length ==0)
	{
		alert ("Favor de ingresar la fecha inicial.")
		
		valida = false		
	}
	else if (document.forms[0].dtmFechaFinal.value.length==0)
	{
		alert ("Favor de ingresar la fecha final.")
		
		valida = false		
	}	
	
  }
  return(valida);
}

function window_onLoad(){
    //MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
    //document.forms[0].action="<%=strFormAction%>";
      
}
function doSubmit()
{
    args = doSubmit.arguments;
    var action = args[0];

	var params = ""
	for (i=1; i < (args.length-1); i +=2)
	{
		params+= "&" + args[i] + "=" + args[i+1]
	}
	if (action == "Seleccionar")
	{	
		window.location.href = "InventarioLibreConsultaDetalle.aspx?cmd=Seleccionar" + params
							 + "&dtmFechaInicial=" + document.forms[0].dtmFechaInicial.value
							 + "&dtmFechaFinal=" + document.forms[0].dtmFechaFinal.value
	}
	else
	{
		document.forms[0].action = "InventarioLibreConsulta.aspx?strCmd=" + action + params
		document.forms[0].submit();  
	}
}
function printDocument()
{
	if (document.forms[0].documentPrinted.value == "0")
	{
		//document.ifrOculto.document.location.href="ImprimirDocumento.aspx"
		window.open("ImprimirDocumento.aspx", "printDocument", "scroll=yes,resizable=yes,width=400,height=400,statusbar=no")
	}
}
//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onLoad()">
<form name="frmConsulta" method="post" runAt="server" ID="Form1" onsubmit="return validateForm()">
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
            <td width="182" class="tdfechahora"><div id="ToPrintTxtFecha"> 
                <script language="JavaScript">strGetCustomDateTime()</script>
              </div></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <span class="txtitulo">Consulta de Inventarios Libres</span> 
                    <span class="txcontenido"> Seleccione el rango de fechas que 
                    desea consultar y oprima "Aceptar"</span> <span class="txsubtitulo"><br>
                    <br>
                    <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> 
                    Seleccione un rango de fechas</span> <table width="60%" border="0" cellspacing="0" cellpadding="0">
                      <tr> 
                        <td width="30%" class="tdtittablas"> Fecha inicial : </td>
                        <td width="80%" class="tdconttablas"> <asp:TextBox id="dtmFechaInicial" name="dtmFechaInicial" runat="server" CssClass="field" readonly size="12"></asp:TextBox> 
                          <a id="imgFechaInicial" href="javascript:openCalendar(document.forms[0].dtmFechaInicial)"> 
                          <img border="0" src="../static/images/calendar/cal.gif"></a> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas" width="30%">Fecha Final:</td>
                        <td class="tdconttablas" width="80%"> <asp:TextBox id="dtmFechaFinal" name="dtmFechaFinal" runat="server" readonly size="12" CssClass="field"></asp:TextBox> 
                          <a id="imgFechaFinal" href="javascript:openCalendar(document.forms[0].dtmFechaFinal)"> 
                          <img border="0" src="../static/images/calendar/cal.gif"></a> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas" width="89"></td>
                        <td class="tdconttablas"> <input name="btnAceptar" runat="server" type="submit" class="boton" value="Aceptar" onclick="setAction('filtrar');" onserverclick="btnAceptar_Click" ID="btnAceptar"> 
                        </td>
                      </tr>
                    </table>
                    <br> <%= strRecordBrowserHTML %> <br> </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda('');</script> 
            </td>
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
				//-->
			</script>
</form>
<iframe name="ifrOculto" src="" width="0" height="0"></iframe>
</body>
</HTML>
