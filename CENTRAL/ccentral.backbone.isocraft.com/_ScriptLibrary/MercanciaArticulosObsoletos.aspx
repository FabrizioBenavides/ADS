<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaArticulosObsoletos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaArticulosObsoletos" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaArticulosObsoletos.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página de productos Reclamados.
    ' Copyright     : 2007 All rights reserved.
    ' Company       : 
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Viernes, Septiembre 07, 2007
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
	'                 20 de Dic 2011 [JAHD]  Filtro de vigencia de articulo
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

  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action = "<%=strFormAction%>"; 
     
   var strSucursalId = "<%= strSucursalId %>";      
   var intCiaConsultaid ="<%=intCiaConsultaid%>";
   var intSucConsultaid ="<%=intSucConsultaid%>";   
     
   if (strSucursalId == "-1") {
       document.forms[0].elements["cboSucursal"].options[1].selected = true;
   }
      
   document.forms[0].elements["txtArticulo"].value = "<%=strArticulo %>";
   
   <%= strLlenarSucursalComboBox() %>
   <%= strLlenarVigenciaArticuloComboBox() %>
   <%= strJavascriptWindowOnLoadCommands %>       
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}

function cboSucursal_onchange() {
   if (blnValidarSubmit()) {
       document.forms[0].action = "<%= strFormAction %>";
       document.forms[0].submit(); 
    }
}
function cboVigencia_onchange() {
   if (blnValidarSubmit()) {
       document.forms[0].action = "<%= strFormAction %>";
       document.forms[0].submit(); 
    }
}

function blnValidarSubmit() {
   var blnValidar = true;   
   
   if (document.forms[0].elements["cboSucursal"].selectedIndex == 0 ) {
       blnValidar = false;
       alert("Seleccionar el criterio de Sucursal");
   }      
   
   return blnValidar;   
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
	  document.forms[0].action = "MercanciaArticulosObsoletos.aspx?strCmd=" + action + params;
	}
	else {
	  document.forms[0].action = "MercanciaArticulosObsoletos.aspx";
	}
	
	document.forms[0].submit(); 
	
}


function cmdRegresar_onclick() {
   window.location.href = "MercanciaInventarios.aspx";
}

function cmdConsultar_onclick() {
   if (blnValidarSubmit()) {          
       doSubmit("");         
   }    
}

function cmdLimpiar_onclick() {
    window.location.href = "MercanciaArticulosObsoletos.aspx";
}
function cmdImprimir_onclick() { 
   
   document.forms[0].action = "<%=strFormAction%>?strCmd=Imprimir&strNombre=" +document.forms[0].elements["cboSucursal"].options[document.forms[0].elements["cboSucursal"].selectedIndex].text;;
   document.forms[0].target="ifrOculto";
   document.forms[0].submit();
   document.forms[0].target='';
}

function fnImprimir(strObsoletos) {
  document.ifrPageToPrint.document.all.divContenido.innerHTML= strObsoletos;
  document.ifrPageToPrint.focus();
  window.print(); 
     
}

//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaArticulosObsoletos" action="about:blank" method="post">
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
              Productos Obsoletos</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Productos 
              Obsoletos</span><span class="txcontenido"><br>
              Para consultar los productos obsoletos, elija su sucursal o la sucursal 
              de la zona para obtener el reporte oprimir consultar.<br>
              </span><span class="txsubtitulo"> <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> 
              Configurar la consulta</span> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="30%" class="tdtittablas">Sucursal:</td>
                  <td class="tdconttablas" width="70%"> <select name="cboSucursal" class="campotabla" id="cboSucursal" onchange="return cboSucursal_onchange()">
                      <option value="0" selected>-- Elija una sucursal --</option>
                      <option>--------------------</option>
                    </select> </td>
                </tr>
                <tr> 
                  <td class="tdtittablas" width="30%">Articulo:</td>
                  <td class="tdconttablas" width="70%"> <input class="campotabla" id="txtArticulo" type="text" autocomplete="off"  maxlength="15" size="24" name="txtArticulo"  value='<%=Request("strArticulo")%>'> 
                  </td>
                </tr>
                <tr> 
                  <td width="30%" class="tdtittablas">Vigencia Articulo:</td>
                  <td class="tdconttablas" width="70%"> <select name="cboVigencia" class="campotabla" id="cboVigencia" onchange="return cboVigencia_onchange()">
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
                  <td colspan="2" width="100%"><br> <%=strConsultarObsoletos%> 
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
<iframe name="ifrPageToPrint" src="ifrPaginaenBlanco.aspx" width="0" height="0" marginheight="0" marginwidth="0"></iframe>
</body>
</HTML>
