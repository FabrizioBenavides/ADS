<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaReciboTransferencias.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaReciboTransferencias" codePage="28592"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaReciboTransferencias.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Griselda Gómez Ponce
    ' Version       : 1.0
    ' Last Modified : Viernes, 24 Octubre, 2003
    '                 20 de Marzo 2007             Actualizacion por SAP
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
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

function frmMercanciaReciboTransferencias_onsubmit() {
  valida=true;
	return(valida);
}

function window_onload(){
   MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
   document.forms[0].action="<%=strFormAction%>";

   var strMensaje = "<%=strMensaje%>";
   if (strMensaje!=""){
      window.alert(strMensaje);
   }
}

function cmdRegresar_onclick() {
   window.location  = "MercanciaEntradasTransferencia.aspx";
   return(true);
}


function cmdCancelar_onclick() {
    window.location  = "MercanciaEntradasTransferencia.aspx";
    return(true);
}
//-->
</script>
</HEAD>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaReciboTransferencias" onSubmit="return frmMercanciaReciboTransferencias_onsubmit()">
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
              : <a href="MercanciaEntradas.aspx" class="txdmigaja">Entradas</a></span><span class="txdmigaja"> 
              : </span><span class="txdmigaja"></span><span class="txdmigaja"><a href="MercanciaEntradasTransferencia.aspx" class="txdmigaja">Transferencias 
              de otra sucursal</a></span><span class="txdmigaja"> : </span><span class="txdmigaja"></span><span class="txdmigaja"></span><span class="txdmigaja">Procesar 
              recibo de transferencias</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Procesar recibo de transferencias</span><span class="txcontenido">La 
                      siguiente tabla muestra los recibos de mercancía que su 
                      sucursal tiene pendientes de confirmar. Aquí podrá confirmar 
                      la mercancía recibida. Para ver los detalles de una transferencia, 
                      haga clic en el número de orden.</span> 
                      <script language="JavaScript">crearDatosSucursal()</script>
                      <br>
                      <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> 
                      Transferencias recibidas pendientes de confirmar</span><span class="txtitulo"></span> 
                      <br>
                      <script language="javascript">strRecordBrowserHTML()</script>
                      <br>
                      <input name="cmdCancelar" type="button" class="boton" value="Cancelar" onClick="return cmdCancelar_onclick()">
                      <br>
                      <br>
                    </p></td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"><script language="javascript">strGeneraTablaAyuda('');</script> 
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
</body>
</HTML>
