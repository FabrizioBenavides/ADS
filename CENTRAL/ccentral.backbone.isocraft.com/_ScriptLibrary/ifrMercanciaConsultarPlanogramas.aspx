<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="ifrMercanciaConsultarPlanogramas.aspx.vb" Inherits="com.isocraft.backbone.ccentral.clsifrMercanciaConsultarPlanogramas" codePage="28592"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%  '====================================================================
    ' Page          : ifrMercanciaConsultarPlanogramas.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página que muestra en un iframe los planos de ubicación de los productos.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : Carlos E. Pérez Torres
    ' Version       : 1.0
    ' Last Modified : October 27, 2003
    '====================================================================
%>
<html>
<head>
<title>iframe</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<link rel="stylesheet" href="../static/css/estiloifr.css">
<script language="javascript" id="clientEventHandlersJS">
<!--

function strRecordBrowserHTML() {
	document.write("<%=strRecordBrowserHTML%>");
	return(true);
}

//-->
</script>
</head>
<body bgcolor="#FFFFFF" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#FFFFFF">
  <tr> 
    <td width="99%" height="10" valign="top">
	<script language="javascript">strRecordBrowserHTML()</script>
<!--
      <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td width="76" class="tdceleste">25</td>
          <td width="514" class="tdceleste">Art&iacute;culos para resfriado 1 
            tramo 1.22 mts</td>
          <td width="99" class="tdceleste">12/12/2002</td>
          <td width="85" class="tdceleste"><a href="#"><img src="images/icono_texto.gif" width="8" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Texto</a></td>
          <td width="181" class="tdceleste"><a href="#"><img src="images/icono_grafico.gif" width="9" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Gr&aacute;fico</a></td>
        </tr>
        <tr> 
          <td class="tdblanco">85</td>
          <td class="tdblanco">Analg&eacute;sicos, 1 tramo de 1.22 mts</td>
          <td class="tdblanco">12/12/2002</td>
          <td class="tdblanco"><a href="#"><img src="images/icono_texto.gif" width="8" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Texto</a></td>
          <td class="tdblanco"><a href="#"><img src="images/icono_grafico.gif" width="9" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Gr&aacute;fico</a></td>
        </tr>
        <tr> 
          <td class="tdceleste">41</td>
          <td class="tdceleste">Planificaci&oacute;n familiar, 1 tramo de 1.22 
            mts Farmacia 2</td>
          <td class="tdceleste">12/12/2002</td>
          <td class="tdceleste"><a href="#"><img src="images/icono_texto.gif" width="8" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Texto</a></td>
          <td class="tdceleste"><a href="#"><img src="images/icono_grafico.gif" width="9" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Gr&aacute;fico</a></td>
        </tr>
        <tr> 
          <td class="tdblanco">12</td>
          <td class="tdblanco">Gastrointestinales. Mueble 2 vistas Farmacia 2</td>
          <td class="tdblanco">12/12/2002</td>
          <td class="tdblanco"><a href="#"><img src="images/icono_texto.gif" width="8" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Texto</a></td>
          <td class="tdblanco"><a href="#"><img src="images/icono_grafico.gif" width="9" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Gr&aacute;fico</a></td>
        </tr>
        <tr> 
          <td class="tdceleste">36</td>
          <td class="tdceleste">Cuidado de los pies 2 tramos 1.22 m Farmacia</td>
          <td class="tdceleste">12/12/2002</td>
          <td class="tdceleste"><a href="#"><img src="images/icono_texto.gif" width="8" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Texto</a></td>
          <td class="tdceleste"><a href="#"><img src="images/icono_grafico.gif" width="9" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Gr&aacute;fico</a></td>
        </tr>
        <tr> 
          <td class="tdblanco">85</td>
          <td class="tdblanco">Cuidado piel y cabello 1 tramo 1.22 m Farmacia</td>
          <td class="tdblanco">12/12/2002</td>
          <td class="tdblanco"><a href="#"><img src="images/icono_texto.gif" width="8" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Texto</a></td>
          <td class="tdblanco"><a href="#"><img src="images/icono_grafico.gif" width="9" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Gr&aacute;fico</a></td>
        </tr>
        <tr> 
          <td width="76" class="tdceleste">25</td>
          <td width="514" class="tdceleste">Vitam&iacute;nicos 1 tramo 1.22 m 
            Farmacia 20</td>
          <td width="99" class="tdceleste">12/12/2002</td>
          <td width="85" class="tdceleste"><a href="#"><img src="images/icono_texto.gif" width="8" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Texto</a></td>
          <td width="181" class="tdceleste"><a href="#"><img src="images/icono_grafico.gif" width="9" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Gr&aacute;fico</a></td>
        </tr>
        <tr> 
          <td class="tdblanco">12</td>
          <td class="tdblanco">Sueros cabecera Farmacia 2000</td>
          <td class="tdblanco">12/12/2002</td>
          <td class="tdblanco"><a href="#"><img src="images/icono_texto.gif" width="8" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Texto</a></td>
          <td class="tdblanco"><a href="#"><img src="images/icono_grafico.gif" width="9" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Gr&aacute;fico</a></td>
        <tr> 
          <td class="tdceleste">36</td>
          <td class="tdceleste"><a href="#" class="txaccion">Sebryl Plus jarabe 
            150 ml</a></td>
          <td class="tdceleste">12/12/2002</td>
          <td class="tdceleste"><a href="#"><img src="images/icono_texto.gif" width="8" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Texto</a></td>
          <td class="tdceleste"><a href="#"><img src="images/icono_grafico.gif" width="9" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Gr&aacute;fico</a></td>
        </tr>
        <tr> 
          <td class="tdblanco">12</td>
          <td class="tdblanco">Gastrointestinales. Cabecera Farmacia 2</td>
          <td class="tdblanco">12/12/2002</td>
          <td class="tdblanco"><a href="#"><img src="images/icono_texto.gif" width="8" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Texto</a></td>
          <td class="tdblanco"><a href="#"><img src="images/icono_grafico.gif" width="9" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Gr&aacute;fico</a></td>
        </tr>
        <tr> 
          <td class="tdceleste">36</td>
          <td class="tdceleste">Planificaci&oacute;n familiar, 1 tramo de 1.22 
            mts Farmacia 2</td>
          <td class="tdceleste">12/12/2002</td>
          <td class="tdceleste"><a href="#"><img src="images/icono_texto.gif" width="8" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Texto</a></td>
          <td class="tdceleste"><a href="#"><img src="images/icono_grafico.gif" width="9" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Gr&aacute;fico</a></td>
        </tr>
        <tr> 
          <td class="tdblanco">12</td>
          <td class="tdblanco">Analg&eacute;sicos, 1 tramo de 1.22 mts</td>
          <td class="tdblanco">12/12/2002</td>
          <td class="tdblanco"><a href="#"><img src="images/icono_texto.gif" width="8" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Texto</a></td>
          <td class="tdblanco"><a href="#"><img src="images/icono_grafico.gif" width="9" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Gr&aacute;fico</a></td>
        </tr>
        <tr> 
          <td class="tdceleste">36</td>
          <td class="tdceleste">Art&iacute;culos para resfriado 1 tramo 1.22 mts</td>
          <td class="tdceleste">12/12/2002</td>
          <td class="tdceleste"><a href="#"><img src="images/icono_texto.gif" width="8" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Texto</a></td>
          <td class="tdceleste"><a href="#"><img src="images/icono_grafico.gif" width="9" height="12" border="0" align="absmiddle"></a>&nbsp;&nbsp;<a href="#" class="txaccion">Gr&aacute;fico</a></td>
        </tr>
      </table>
-->
    </td>
  </tr>
</table>
</body>
</html>