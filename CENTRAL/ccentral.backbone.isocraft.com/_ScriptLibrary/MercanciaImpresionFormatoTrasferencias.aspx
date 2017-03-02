<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaImpresionFormatoTrasferencias.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaImpresionFormatoTrasferencias" codePage="28592"%>
<html>
<head>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaImpresionFormatoTrasferencias.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página Impresion Formato Trasferencias.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Martes, Octubre 31, 2003
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
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
  
  strRegistrosRecordBrowser = "<%=strRegistrosRecordBrowser%>";
  
  if (strRegistrosRecordBrowser.length > 0) {     
      printContent();            
  }
  
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

function strRecordBrowserHTML(){  
     document.write("<%=strRecordBrowserHTML%>");   
}


function frmMercanciaImpresionFormatoTrasferencias_onsubmit() {
    var regreso = true;
    regreso = blnValidarCampo(document.forms[0].elements['txtLineasReporte'],true,'Lineas Reporte',cintTipoCampoEntero,4,0,''); 
        
    if (regreso && document.forms[0].elements['txtLineasReporte'].value > 0 ) {
       document.forms[0].action = "<%=strFormAction%>?strcmd=ImprimeReporte"; 
    }
    else {
       if (regreso) {
         alert("Capturar el número de lineas");
         regreso = false;
       }       
    }

    return(regreso);    
}

function cmdRegresar_onclick() {
     window.location  ="MercanciaSalidasTransferenciasOtraSucursal.aspx";
}

//-->
</script>
</head>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginwidth="0" marginheight="0">
<form name="frmMercanciaImpresionFormatoTrasferencias" action="about:blank" method="post" onSubmit="return frmMercanciaImpresionFormatoTrasferencias_onsubmit()">
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
            <td width="10" bgcolor="#ffffff"> <img height="8" src="../static/images/pixel.gif" width="10"> 
            </td>
            <td class="tdmigaja" width="583"><span class="txdmigaja">Está en :</span><a class="txdmigaja" href="Mercancia.aspx">Mercancía</a> 
              <span class="txdmigaja">: <a class="txdmigaja" href="MercanciaSalidas.aspx">Salidas</a> 
              : </span><span class="txdmigaja"> <a class="txdmigaja" href = "MercanciaSalidasTransferenciasOtraSucursal.aspx">Transferencias 
              a otra sucursal</a> : </span><span class="txdmigaja"></span><span class="txdmigaja"> 
              </span><span class="txdmigaja"></span><span class="txdmigaja"></span> 
              <span class="txdmigaja">Imprimir formato para transferencias</span> 
            </td>
            <td class="tdfechahora" width="187"> <script language="javascript">strGetCustomDateTime()</script> 
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td valign="top" width="583"> <table cellspacing="0" cellpadding="0" width="583" border="0">
                <tr> 
                  <td class="tdtablacont" valign="middle" width="100%" colspan="2"> 
                    <span class="txtitulo">Imprimir formato para transferencias 
                    </span> <span class="txcontenido">Ingrese el número de líneas 
                    que desee en el formato, oprima "Imprimir".</span> <script language="JavaScript">crearDatosSucursal()</script> 
                    <br> <span class="txsubtitulo"> <img height="11" src="../static/images/bullet_subtitulos.gif" width="17"> 
                    Configurar formato</span> <table cellspacing="0" cellpadding="0" width="100%" border="0">
                      <tr> 
                        <td class="tdtittablas" width="29%">Cuantas lineas necesita?:</td>
                        <td width="71%"> <input class="campotabla" type="text" maxlength="4" size="4" name="txtLineasReporte"> 
                        </td>
                      </tr>
                      <tr> 
                        <td  colspan="2"> <input class="boton" type="button" value="Regresar" name="cmdRegresar" onClick="return cmdRegresar_onclick()"> 
                          &nbsp;&nbsp;&nbsp; <input class="boton" type="submit" value="Imprimir formato" name="cmdImprimir" > 
                        </td>
                      </tr>
                      <tr> 
                        <div id="ToPrintTxtMigaja"> </div>
                        <td class="tdtablacont" valign="middle" width="100%" colspan="2"> 
                          <div id="ToPrintHtmContenido" style="DISPLAY:none"> 
                            <script language="javascript">strRecordBrowserHTML()</script>
                          </div></td>
                      </tr>
                    </table></td>
                </tr>
              </table></td>
            <td class="tdcolumnader" valign="top" width="182" rowspan="2"><script language="javascript">strGeneraTablaAyuda('');</script> 
            </td>
          </tr>
          <tr> 
            <td class="tdbottom" colspan="2"><script language="JavaScript">crearTablaFooter()</script> 
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
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"> 
</iframe>
</body>
</html>
