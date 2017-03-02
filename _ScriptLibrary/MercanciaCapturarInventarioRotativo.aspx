<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaCapturarInventarioRotativo.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaCapturarInventarioRotativo" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaCapturarInventarioRotativo.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página para 
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Griselda Gómez Ponce
    ' Version       : 1.0
    ' Last Modified : Sabado,08 de Noviembre, 2003
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
var strPaginaAyuda
strPaginaAyuda = "<%=strThisPageName%>";


function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}


function strDiaDeHoy(){
    document.write("<%=strDiaDeHoy%>");
    return(true);
}

function strDiaDeAyer(){
    document.write("<%=strDiaDeAyer%>");
    return(true);
}

function frmMercanciaCapturarInventarioRotativo_onsubmit() {
  valida=true;
  if ((document.forms[0].elements('rdoHoy').checked == false) && (document.forms[0].elements('rdoAyer').checked == false)){
      alert("Seleccionar el dia de consulta.");
      valida = false;
  }
  return(valida);
}

function window_onLoad(){
    MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
    document.forms[0].action="<%=strFormAction%>";
    
    //verificamos si hay un record browser generado
    if ("<%=strMensaje%>"!=""){
        alert("<%=strMensaje%>");
    }
        
    //Inicializamos el botton del dia  seleccionado
    if ("<%=rdoFechaCaptura%>"=="1"){
        document.forms[0].elements('rdoHoy').checked=true;
    }
    
    if ("<%=rdoFechaCaptura%>"=="2"){
        document.forms[0].elements('rdoAyer').checked=true;
    }
}


function strRecordBrowserHTML(){
    document.write("<%=strRecordBrowserHTML%>");
    return(true);
}

function strbtnAceptar(){
    document.write("<%=strbtnAceptar%>");
    return(true);
}

function cmdRegresar_onclick() {
   //Redireccionamos al home de inventario rotativos
	strRedireccionaPOSAdmin('MercanciaInventariosRotativos.aspx');
}

function cmdRegistrar_onclick() {
   //Validamos que todos los planogramas estén capturardos
	if("<%=blnPlanogramasCompletos%>"==false){
	    alert("Faltan planogramas por capturar.");
	}
	else{
	   alert("Planogramas registrados.");
	   document.forms[0].submit();
	}
}


//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onLoad="return window_onLoad()">
<form action="about:blank" method="post" name="frmMercanciaCapturarInventarioRotativo" onSubmit="return frmMercanciaCapturarInventarioRotativo_onsubmit()">
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
              : <a href="javascript:strRedireccionaPOSAdmin('MercanciaInventarios.aspx')" class="txdmigaja">Inventarios</a><span class="txdmigaja"> 
              : </span><a href="javascript:strRedireccionaPOSAdmin('MercanciaInventariosRotativos.aspx')" class="txdmigaja">Inventarios 
              rotativos </a></span><span class="txdmigaja">: Capturar inventario 
              rotativo</span></td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script></td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"><span class="txtitulo">Capturar 
                    inventario rotativo</span><span class="txcontenido">Seleccione 
                    el día que desea capturar y oprima "Aceptar". El sistema desplegará 
                    los números de plano del día elegido. Haga clic en el planograma 
                    que desee capturar. Al final del proceso, registre los planogramas 
                    del día.</span><span class="txsubtitulo"><br>
                    <br>
                    <img src="../static/images/bullet_subtitulos.gif" width="17" height="11" align="absMiddle"> 
                    Día a capturar</span> <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td width="91" class="tdtittablas"><input type="radio" name="rdoFechaCaptura" value="1" id="rdoHoy">
                          Hoy</td>
                        <td width="477" valign="middle" class="tdconttablas"><script language=javascript>strDiaDeHoy()</script></td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas"><input type="radio" name="rdoFechaCaptura" value="2" id="rdoAyer">
                          Ayer</td>
                        <td valign="middle" class="tdconttablas"><script language="javascript">strDiaDeAyer()</script></td>
                      </tr>
                    </table>
                    <br> <script language=javascript>strbtnAceptar()</script> 
                    <br> <br> <script language=javascript>strRecordBrowserHTML()</script> 
                    <br> <br> </td>
                </tr>
              </table></td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader"> <script language="javascript">strGeneraTablaAyuda(strPaginaAyuda);</script>	
            </td>
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
