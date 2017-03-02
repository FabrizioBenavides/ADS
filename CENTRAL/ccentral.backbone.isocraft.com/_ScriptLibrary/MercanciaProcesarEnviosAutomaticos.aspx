<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaProcesarEnviosAutomaticos.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaProcesarEnviosAutomaticos" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaProcesarEnviosAutomaticos.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Raul Corral Gonzalez
    ' Version       : 1.0
    ' Last Modified : Jueves, 30 Octubre, 2003
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
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--

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
function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}
function frmMercanciaProcesarEnviosAutomaticos_onsubmit() {
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
   strHrefMigaja3();
   return(true);
}

//Inicio Migajas, titulo principal y descripcion
function strHrefMigaja1(){
	document.location.href='Mercancia.aspx';
}
function strHrefMigaja2(){
	document.location.href='MercanciaSalidas.aspx';
}
function strHrefMigaja3(){
	document.location.href='MercanciaSalidasTransferenciasOtraSucursal.aspx';
}
function strHrefMigaja4(){
	document.location.href='';
}
function strTituloMigaja1(){
	document.write("Mercancía");
}
function strTituloMigaja2(){
	document.write("Salidas");
}
function strTituloMigaja3(){
	document.write("Transferencias a otra sucursal");
}
function strTituloPrincipalDePagina() {
	document.write("Procesar envíos automáticos");
}
function strDescripcionPrincipalDePagina() {
	document.write("La siguiente tabla muestra las transferencias que su sucursal tiene pendientes de enviar. Aquí podrá confirmar el envío o cancelar la transferencia. Para ver los detalles de una transferencia, haga clic en el número de orden.");
}
//Termina Migajas, titulo principal y descripcion
//-->
					</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaProcesarEnviosAutomaticos" onSubmit="return frmMercanciaProcesarEnviosAutomaticos_onsubmit()">
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
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja"> 
                Está en : </span> <a href="javascript:strHrefMigaja1();" class="txdmigaja"> 
                <script language="javascript">strTituloMigaja1()</script>
                </a> <span class="txdmigaja"> : <a href="javascript:strHrefMigaja2();" class="txdmigaja"> 
                <script language="javascript">strTituloMigaja2()</script>
                </a> : <a href="javascript:strHrefMigaja3();" class="txdmigaja"> 
                <script language="javascript">strTituloMigaja3()</script>
                </a> : 
                <script language="javascript">strTituloPrincipalDePagina()</script>
                </span></div></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo"> 
                      <script language="javascript">strTituloPrincipalDePagina()</script>
                      </span> <span class="txcontenido"> 
                      <script language="javascript">strDescripcionPrincipalDePagina()</script>
                      </span><br>
                      <script language="JavaScript">crearDatosSucursal()</script>
                      <script language="javascript">strRecordBrowserHTML()</script>
                      <br>
                      <input name="cmdRegresar" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick()">
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
</html>
