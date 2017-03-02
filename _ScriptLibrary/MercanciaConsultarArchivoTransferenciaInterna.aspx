<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConsultarArchivoTransferenciaInterna.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaConsultarArchivoTransferenciaInterna" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaConsultarArchivoTransferenciaInterna.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para Conultar las TIN
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Sabado, Noviembre 01, 2003
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

function window_onload(){
  MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
  document.forms[0].action="<%=strFormAction%>";
  
   var strMensaje = "<%=strMensaje%>";   
   var rdoSeleccionado = "<%=rdoFiltroConsulta%>";
   var strRegistrosRecordBrowser = "<%=strRegistrosRecordBrowser%>";
   
   if (rdoSeleccionado == "1") {
     document.forms[0].elements['rdoFiltroConsulta1'].checked = true;  
   }
   
   if (rdoSeleccionado == "2") {
     document.forms[0].elements['rdoFiltroConsulta2'].checked = true;  
   }
      
   if (strMensaje.length > 0 ) {
       alert(strMensaje);
   } 
   
   if (strRegistrosRecordBrowser.length > 0) {   
       document.forms[0].elements['rdoFiltroConsulta1'].disabled=true;
       document.forms[0].elements['rdoFiltroConsulta2'].disabled=true;
       
       document.forms[0].elements['cmdRegresar'].style.display='none';
       document.forms[0].elements['cmdConsultar'].style.display='none';          
   }
   
   return(true);
   
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


function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}



function frmMercanciaConsultarArchivoTransferenciaInterna_onsubmit() {
    var regreso = true;
    var strFiltroConsulta = 0;
    
    if (document.forms[0].elements['rdoFiltroConsulta1'].checked == true) {
       strFiltroConsulta = 1;
    }
   
   if (document.forms[0].elements['rdoFiltroConsulta2'].checked == true) {
       strFiltroConsulta = 2;
   }
   
   if (strFiltroConsulta == 0) {
       alert("Seleccionar algun criterio para la consulta");
       regreso = false;
   } 
   
   document.forms[0].action = "<%=strFormAction%>?strConsulta=ConsultaTIN" + "&rdoFiltroConsulta=" + strFiltroConsulta ; 
   
   return (regreso);

}

function cmdOtra_onclick() {      
   document.forms[0].action = "<%=strFormAction%>";   
   document.forms[0].submit();      
}

function cmdRegresar_onclick() {
    strRedireccionaPOSAdmin("MercanciaSalidasTransferenciasInternas.aspx");
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaConsultarArchivoTransferenciaInterna" onSubmit="return frmMercanciaConsultarArchivoTransferenciaInterna_onsubmit()">
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
            <td width="583" class="tdmigaja"> <span class="txdmigaja">Está en: 
              </span><a class="txdmigaja" href="Mercancia.aspx">Mercancía</a><span class="txdmigaja"> 
              : <a class="txdmigaja" href="javascript:strRedireccionaPOSAdmin('MercanciaSalidas.aspx');">Salidas</a> 
              : <a class="txdmigaja" href="javascript:strRedireccionaPOSAdmin('MercanciaSalidasTransferenciasInternas.aspx');">Transferencias 
              Internas</a>: Archivo de transferencia interna </span> </td>
            <td width="187" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Archivo 
              de transferencias internas</span><span class="txcontenido">Elija 
              primero el mes que desea ver y luego elija una de las transferencias 
              del mes elegido. Para consultar los detalles de la transferencia, 
              haga clic en el n&uacute;mero de folio.</span><br> <span class="txsubtitulo"><img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absmiddle"> 
              Mes a consultar</span> <table width="98%" height="27" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="133" height="27" class="tdtittablas">Elija una consulta:</td>
                  <td width="424" class="tdconttablas"> <input type="radio" name="rdoFiltroConsulta" value="1" id="rdoFiltroConsulta1" >
                    Mes actual&nbsp;&nbsp;&nbsp; <input type="radio" name="rdoFiltroConsulta" value="2" id="rdoFiltroConsulta2">
                    Mes anterior</td>
                </tr>
              </table>
              <br> <input class="boton" type="button" value="Regresar" name="cmdRegresar"  onClick="return cmdRegresar_onclick()"> 
              <input class="boton" type="submit" value="Consultar" name="cmdConsultar"> 
              <br> <script language="javascript">strRecordBrowserHTML()</script> 
            </td>
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
</body>
</html>
