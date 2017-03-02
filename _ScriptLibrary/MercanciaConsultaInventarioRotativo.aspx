<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MercanciaConsultaInventarioRotativo.aspx.vb" EnableSessionState="True" Inherits="com.isocraft.backbone.ccentral.MercanciaConsultaInventarioRotativo"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : ConsultaInventarioRotativo.aspx
    ' Title         : Inventarios Rotativos Por Listados
    ' Description   : Captura de Inventarios Rotativos Por Listados
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Neitek Solutions S.A. de C.V.
    ' Author        : Carolina Caballero
    ' Version       : 1.0
    ' Last Modified : Monday, October 25th, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
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
<script language="JavaScript" src="../static/scripts/Calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/InvRotUtils.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--



var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";

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


function validateForm() {
  valida=true;
  return(valida);
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function window_onload(){
    MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
    document.forms[0].action="<%=strFormAction%>";
      
}


function cmdRegresar_onclick() {
   //Redireccionamos al home de inventario rotativos
	strRedireccionaPOSAdmin('MercanciaInventariosRotativos.aspx');
}

function cmdRegistrar_onclick() {

}
function openCalendar(obj)
{
	calendar1(obj)
	cal_popup1(obj.value)
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
	if (action == "Capturar")
	{	
		window.location.href = "CapturaInventarioRotativo.aspx?cmd=Capturar" + params
	}
	else
	{
		document.forms[0].action = "ConsultaInventarioRotativo.aspx?strCmd=" + action + params
		document.forms[0].submit();  
	}
}

//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form name="frmConsulta" method="post" runAt="server" ID="Form1">
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
            <td width="583" class="tdmigaja"><span class="txdmigaja">Está en : 
              SUCURSAL : INV.&nbsp;ROTATIVO&nbsp;: Consulta </span> </td>
            <td width="187" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"><span class="txtitulo">Inventarios 
                    Rotativos por Listados</span><span class="txcontenido"> Seleccione 
                    el día que desea consultar y oprima "Aceptar"</span><span class="txsubtitulo"><br>
                    <br>
                    <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> 
                    Seleccione el Día a capturar</span> <table width="100%" border="0" cellspacing="0" cellpadding="0">
                      <tr> 
                        <td width="14%" class="tdtittablas"> <asp:RadioButton id="dateSelection1" Text="Hoy" GroupName="radioSelDate" runat="server"></asp:RadioButton> 
                        </td>
                        <td width="86%" class="tdconttablas"> <asp:TextBox id="currentDate" runat="server" MaxLength='0' CssClass="fieldborderless"></asp:TextBox> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas"><asp:RadioButton id="dateSelection2" Text="Fecha" GroupName="radioSelDate" runat="server"></asp:RadioButton></td>
                        <td class="tdconttablas"> <asp:TextBox id="selectedDate" runat="server" MaxLength='0' CssClass="field"></asp:TextBox> 
                          <a href="javascript:openCalendar(document.forms[0].selectedDate)"><img border="0" src="../static/images/calendar/cal.gif"></a> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas"></td>
                        <td class="tdconttablas"> <input name="btnAceptar" runat="server" type="submit" class="boton" value="Aceptar" onclick="setAction('filtrar');" onserverclick="btnAceptar_Click" ID="btnAceptar"> 
                        </td>
                      </tr>
                    </table>
                    <br> <%= strRecordBrowserHTML %> <br> </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp; </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
    <tr> 
      <td> <input type="hidden" name="intListadoId"> <input type="hidden" name="dtmSelectedDate" value='<%= selDate.toString("dd/MM/yyy") %>'> 
        <input type="hidden" name="documentPrinted" value="0"></td>
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
