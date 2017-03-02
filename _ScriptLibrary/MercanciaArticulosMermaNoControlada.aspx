<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MercanciaArticulosMermaNoControlada.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaArticulosMermaNoControlada"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaArticulosMermaNoControlada.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para accesar al sistema de consulta de 
    '                 Articulos con Merma No Controlada
    ' Copyright     : 2006 All rights reserved.
    ' Company       : Benavides
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Miercoles, Marzo 08, 2006
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
   %>
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
var blnConsultar;
blnConsultar=true;
function window_onload() {  
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action = "<%=strFormAction%>";  
  
  //ADSuser=1&txtUsuario=s14009&txtContrasena=s14&urlConcentrador=http://10.1.7.201
  
   document.ifraOculto.document.location = strURLArtMermaSesion() + 
   "ADSuser=1&" +
   "txtUsuario=" + "<%=strUsuarioAplicacion%>" + 
   "&txtContrasena=" + "<%=strPasswordAplicacion%>" +
   "&urlConcentrador=" + "<%=strURLConcentrador%>" + 
   "/_ScriptLibrary/CCEscribeCookie.aspx"  
}
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
  
function cmdConsultar_onclick() {    
   var intSesion = document.cookie.indexOf("intEntroAComDif=1")
      
   if (intSesion > -1) {
       strParametros = strURLArtMermaConsulta();    
       window.open(strParametros,'xName','left=0, top=0, height=500,width=750,status=yes, toolbar=no, menubar=no, scrollbars=yes, location=no, titlebar=no, resizable=yes');   
   }  
   else {
       alert("Intentar en un momento la consulta");
   }             
}

function cmdRegresar_onclick() {
    strRedireccionaPOSAdmin("Inicio.aspx");
}

//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaArticulosMermaNoControlada" action="about:blank" method="post">
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
                en :</span><span class="txdmigaja"><a href="Mercancia.aspx" class="txdmigaja">Mercancía</a>:</span><span class="txdmigaja"><a href="javascript:strRedireccionaPOSAdmin('MercanciaMermas.aspx')" class="txdmigaja">Merma</a>:Articulos 
                con Merma no Controlada</span></div></td>
            <td width="187" class="tdfechahora"><div id="ToPrintTxtFecha"> 
                <script language="javascript">strGetCustomDateTime()</script>
              </div></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td colspan="3"><br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()"> 
                    <input name="cmdConsultar" type="button" class="boton" value="Consultar" onClick="return cmdConsultar_onclick()"> 
                  </td>
                </tr>
                <tr> 
                  <td colspan="3" class="tdtablacont" width="100%"> <table border="0" cellpadding="0" cellspacing="0" width="100%" height="400">
                      <tr> 
                        <td width="100%"><iframe name="iframeLayout" id="iframeLayout" src="" frameborder="0" width="100%" scroll="yes"
																height="100%" marginwidth="0" marginheight="0"></iframe> 
                        </td>
                      </tr>
                    </table></td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
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
<iframe name="ifraOculto" src="" width="0" height="0"></iframe>
</body>
</HTML>
