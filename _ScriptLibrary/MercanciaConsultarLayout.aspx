<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConsultarLayout.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaConsultarLayout" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaConsultarLayout.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página de productos Reclamados.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Miercoles, Noviembre 05, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
	'                 15 de Octubre 2012 [JAHD] Ruta de documentos PDF
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
<script language="JavaScript" src="../static/scripts/FuncionesString.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--



var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

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
function strSucursalNombre() {
	document.write("&nbsp;"+"<%=strSucursalNombre%>");
	return(true);
}
function window_onload() {
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action = "<%=strFormAction%>"; 
  var strCia = "00"  + Trim("<%=intCompaniaId%>");
  var strSuc = "000"  + Trim("<%=intSucursalId%>");
  var strSucursal = strCia.substring(strCia.length -2, strCia.length) + strSuc.substring(strSuc.length -3, strSuc.length);
  
  document.iframeLayout.document.location =  strUrlADSDoc() + "pdf/layouts/" + strSucursal + ".pdf";
  
}

function frmMercanciaConsultarLayout_onsubmit() { 
   var regreso = true;
   return(regreso);
}
  

function cmdRegresar_onclick() {
     window.location="MercanciaInventariosPlanogramas.aspx";
}

function cmdPlanogramas_onclick() {
   window.location="MercanciaConsultarPlanogramas.aspx";
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaConsultarLayout" onSubmit="return frmMercanciaConsultarLayout_onsubmit()" action="about:blank" method="post">
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
              </span><a href="mercancia.aspx" class="txdmigaja">Mercancía</a><span class="txdmigaja"> 
              : <a href="MercanciaInventarios.aspx" class="txdmigaja">Inventarios</a><span class="txdmigaja"> 
              : </span><a href="MercanciaInventariosPlanogramas.aspx" class="txdmigaja">Planogramas</a></span><span class="txdmigaja">: 
              </span><span class="txdmigaja"></span><span class="txdmigaja">Consultar 
              layout</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" > <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Consultar layout</span> 
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" height="460">
                      <tr> 
                        <td><iframe name="iframeLayout" id="iframeLayout" src="" frameborder="0" width="100%" scroll="yes" height="100%" marginwidth="0" marginheight="0"> 
                          </iframe> </td>
                      </tr>
                    </table>
                    <br> <br> <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()"> 
                    &nbsp;&nbsp;&nbsp; <input name="cmdPlanogramas" type="button" class="boton" value="Consultar planogramas" onClick="return cmdPlanogramas_onclick()"> 
                    &nbsp;&nbsp; <br> </p> </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda(strPaginaAyuda);</script> 
            </td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script> 
            </td>
          </tr>
        </table></td>
    </tr>
  </table>
  <p> 
    <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
</script>
  </p>
</form>
</body>
</html>
