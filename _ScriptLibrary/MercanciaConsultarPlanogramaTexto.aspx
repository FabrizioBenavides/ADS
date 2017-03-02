<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaConsultarPlanogramaTexto.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsMercanciaConsultarPlanogramaTexto" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%  '====================================================================
    ' Page          : MercanciaConsultarPlanogramaTexto.aspx
    ' Version       : 1.0
    ' Last Modified :
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<link rel="stylesheet" href="../static/css/menu.css">
<link rel="stylesheet" href="../static/css/menu2.css">
<link rel="stylesheet" href="../static/css/estilo.css">
<script language="JavaScript" src="../static/scripts/menu.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items.js"></script>
<script language="JavaScript" src="../static/scripts/menu_items2.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl.js"></script>
<script language="JavaScript" src="../static/scripts/menu_tpl2.js"></script>
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="javascript" id="clientEventHandlersJS">
<!--

var strPaginaAyuda
strPaginaAyuda = "";

function window_onload() {
		MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
		document.forms[0].action = "<%=strFormAction%>"; 
         return(true);
}


function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss")%>");
	return(true);
}

function intPlanoId() {
	document.write("<%=intPlanoId%>");
	return(true);
}

function strPlanoNombre() {
	document.write("<%=strPlanoNombre%>");
	return(true);
}

function strIFrameHTML() {
	document.write("<%=strIFrameHTML%>");
	return(true);
}

function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

function btnSalir_onclick() {
	window.location = "MercanciaInventarios.aspx"
	return(true);
}

function cmdImprimir_onclick() {	
	document.iframe1.focus();
	window.print();
}



function cmdRegresar_onclick() {
	document.location.href = 'MercanciaConsultarPlanogramas.aspx';
	return(false);
}

function cmdVerPlanogramaGrafico_onclick() {
	var strNombreArchivo = '../static/PDF/Planos/Pa<%=strPlanoGraficoId%>.PDF';
	
	window.open(strNombreArchivo,'Planograma','');
	return(false);
}
//-->
</script>
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0"  onLoad="return window_onload()">
<form action="about:blank" method="post" name="frmMercanciaConsultarPlanogramas">
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
            <td width="10" bgcolor="#FFFFFF"><img src="../static/images/pixel.gif" width="10" height="8"></td>
            <td width="583" class="tdmigaja"> <span class="txdmigaja">Est&aacute; 
              en : </span><a href="Mercancia.aspx" class="txdmigaja">Mercanc&iacute;a</a> 
              <span class="txdmigaja"> : <a href="MercanciaInventarios.aspx" class="txdmigaja">Inventarios</a></span> 
              <span class="txdmigaja"> </span><span class="txdmigaja">:</span> 
              <span class="txdmigaja"><a href="MercanciaInventariosPlanogramas.aspx" class="txdmigaja"> 
              Planogramas</a></span> <span class="txdmigaja"> </span><span class="txdmigaja">:</span> 
              <span class="txdmigaja"><a href="MercanciaConsultarPlanogramas.aspx" class="txdmigaja"> 
              Consultar</a></span> <span class="txdmigaja"> :</span> <span class="txdmigaja"></span> 
              <span class="txdmigaja">Planogramas Texto</span> </td>
            <td width="182" class="tdfechahora"><script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr> 
                  <td width="100%" colspan="3" valign="top" class="tdtablacont"> 
                    <p><span class="txtitulo">Planograma texto</span><span class="txcontenido">Los 
                      siguientes son los productos asociados al planograma indicado.</span> 
                      <script language="JavaScript">crearDatosSucursal()</script>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td width="135" class="tdtittablas">No. planograma:</td>
                        <td width="433" height="40" valign="middle" class="tdconttablas"><script language="javascript">intPlanoId();</script> 
                        </td>
                      </tr>
                      <tr> 
                        <td class="tdtittablas">Descripci&oacute;n:</td>
                        <td height="40" valign="middle" class="tdconttablas"><script language="javascript">strPlanoNombre();</script> 
                        </td>
                      </tr>
                    </table>
                    <script language="javascript">strRecordBrowserHTML();</script> 
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                      <tr> 
                        <td><script language="javascript">strIFrameHTML();</script> 
                        </td>
                      </tr>
                    </table>
                    <br> <br> <input name="btnSalir" type="button" class="boton" value="Regresar" onClick="return cmdRegresar_onclick();"> 
                    &nbsp;&nbsp; <input name="btnVerPlanogramaGrafico" type="button" class="boton" value="Ver planograma gr&aacute;fico" onClick="return cmdVerPlanogramaGrafico_onclick();"> 
                    &nbsp;&nbsp; <input name="btnImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick();"> 
                    &nbsp;&nbsp; <br> </p> </p> <p>&nbsp; </p></td>
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
</form>
</body>
</html>
