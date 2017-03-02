<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConsultaDiasInventario.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaConsultaDiasInventario" codePage="28592"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaConsultaDiasInventario.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página de productos Reclamados.
    ' Copyright     : 2012 All rights reserved.
    ' Company       : 
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Viernes, 06 01 2012
    '
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link href="../static/css/menu.css" rel="stylesheet">
<link href="../static/css/menu2.css" rel="stylesheet">
<link href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/tools.js"></script>
<script language="JavaScript" src="../static/scripts/calendar1.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">

<!--
function window_onload() {
   document.forms[0].action = "<%=strFormAction%>"; 
     
   <%= strLlenarDivisionArticulosComboBox() %>
   <%= strJavascriptWindowOnLoadCommands %>       
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}

function cboDivisionArticulos_onchange() {
       document.forms[0].action = "<%= strFormAction %>";
       document.forms[0].submit(); 
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
	
	if (action.length>0) {
	  document.forms[0].action = "MercanciaConsultaDiasInventario.aspx?strCmd=" + action + params;
	}
	else {
	  document.forms[0].action = "MercanciaConsultaDiasInventario.aspx";
	}
	
	document.forms[0].submit(); 	
}


function cmdRegresar_onclick() {
   window.location.href = "MercanciaInventarios.aspx";
}

function cmdConsultar_onclick() {   
   doSubmit("");         
 
}

function cmdLimpiar_onclick() {
    window.location.href = "MercanciaConsultaDiasInventario.aspx";
}
function cmdImprimir_onclick() { 
   
   document.forms[0].action = "<%=strFormAction%>?strCmd=Imprimir";
   document.forms[0].target="ifrOculto";
   document.forms[0].submit();
   document.forms[0].target='';
}

function fnImprimir(strDiasInventario) {
  document.ifrPageToPrint.document.all.divContenido.innerHTML= strDiasInventario;
  document.ifrPageToPrint.focus();
  window.print(); 
     
}

//-->
					</script>
</HEAD>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaConsultaDiasInventario" action="about:blank" method="post">
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
              </span><a href="Mercancia.aspx" class="txdmigaja"> Mercancía</a><span class="txdmigaja"> 
              : <a href="MercanciaInventarios.aspx" class="txdmigaja"> Inventarios</a></span><span class="txdmigaja">: 
              Días Inventario</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Días 
              de Inventario</span><span class="txcontenido"><br>
              Consultar los dias de inventario por División articulo.<br>
              </span><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> 
              Configurar la consulta</span> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="30%" class="tdtittablas">División</td>
                  <td class="tdconttablas" width="70%"> <select name="cboDivisionArticulos" class="campotabla" id="cboDivisionArticulos" onchange="return cboDivisionArticulos_onchange()">
                      <option value="0" selected>-- Todos --</option>
                      <option>--------------------</option>
                    </select> </td>
                </tr>
                <tr> 
                  <td width="30%" colspan="2"> <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="cmdRegresar_onclick()"> 
                    <input name="cmdConsultar" type="button" class="boton" value="Consultar" onClick="cmdConsultar_onclick()"> 
                    <input class="boton" type="button" value="Imprimir" name="cmdImprimir" onclick="return cmdImprimir_onclick()"> 
                  </td>
                  <td width="20%"></td>
                </tr>
                <tr> 
                  <td colspan="2" width="100%"><br> <%=strConsultarDiasInventario%> 
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
	//-->
			</script>
</form>
<iframe name="ifrOculto" width="0" height="0"></iframe>
<iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0" marginheight="0"
			marginwidth="0"></iframe>
</body>
</HTML>
