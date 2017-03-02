<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaArchivoMermaControlada.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaArchivoMermaControlada" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaArchivoMermaControlada.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Griselda Gómez Ponce
    ' Version       : 1.0
    ' Last Modified : Jueves, Octubre 30, 2003
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
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
function window_onload(){
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action="<%=strFormAction%>";
  return(true);
}

function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}
function cmdConsultar_onclick() {
   //Generamos el recordbrowse con las mermas del mes selecionado
   document.forms[0].action="<%=strFormAction%>?strCmd=Consultar";
   document.forms[0].submit();
}
function cmdCancelar_onclick() {
    //Nos vamos a al home de mermas
    strRedireccionaPOSAdmin('MercanciaMermas.aspx');
}
//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaArchivoMermaControlada">
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
              </span><a href="Mercancia.aspx" class="txdmigaja">Mercancía</a><span class="txdmigaja"> 
              : </span><span class="txdmigaja"><a href="javascript:strRedireccionaPOSAdmin('MercanciaMermas.aspx')" class="txdmigaja">Merma</a></span><span class="txdmigaja"> 
              : </span><span class="txdmigaja"></span><span class="txdmigaja">Archivo 
              de merma controlada</span></td>
            <td width="187" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Archivo 
              de merma controlada</span><span class="txcontenido">Elija primero 
              el mes que desea ver y luego elija uno de los registros de merma 
              del mes elegido. Para consultar los detalles del reporte de merma, 
              haga clic en el número de folio.<br>
              <br>
              </span><span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle">Mes 
              a consultar</span> <table width="100%" height="27" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="133" height="27" class="tdtittablas">Elija una consulta:</td>
                  <td width="424" class="tdconttablas"><input type="radio" name="rdoMesConsulta" value="1" id="MesActual" checked>
                    Mes actual&nbsp;&nbsp;&nbsp; <input type="radio" name="rdoMesConsulta" value="2" id="MesAnterior">
                    Mes anterior</td>
                </tr>
              </table>
              <br> <script language="javascript">strRecordBrowserHTML()</script> 
              <br> <input name="cmdCancelar" type="button" class="boton" value="Cancelar" onClick="return cmdCancelar_onclick()"> 
              &nbsp;&nbsp; <input name="cmdConsultar" type="button" class="boton" value="Consultar" onClick="return cmdConsultar_onclick()"> 
              <br> <br> </td>
            <td width="187" rowspan="2" valign="top" class="tdcolumnader"><script language="javascript">strGeneraTablaAyuda('');</script></td>
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
</body>
</html>
