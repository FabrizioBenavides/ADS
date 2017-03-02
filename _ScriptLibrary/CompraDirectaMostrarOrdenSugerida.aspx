<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CompraDirectaMostrarOrdenSugerida.aspx.vb" Inherits="com.isocraft.backbone.ccentral.CompraDirectaMostrarOrdenSugerida"%>
<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : CompraDirectaMostrarOrdenSugerida.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página donde se Muestra la ORden Sugerida para las compras directas
    ' Copyright     : 2004 All rights reserved.
    ' Company       : BENAVIDES
    ' Author        : J.Antonio Hernandez Dávila
    ' Version       : 1.0
    ' Last Modified : Jueves, 18 de Noviembre 2004
	'                 25 de Enero 2011 [JAHD]    Actualizacion por CADENA
    '====================================================================
%>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2">
<LINK href="../static/css/estilo.css" rel="stylesheet">
<script language="JavaScript" src="../static/scripts/Tools.js"></script>
<script language="JavaScript" src="../static/scripts/HeaderFooter.js"></script>
<script language="JavaScript" id="clientEventHandlersJS">
<!--
function strGetCustomDateTime() {
	document.write("<%=clsCommons.strGetCustomDateTime("dd/MM/yyyy - hh:mm:ss") %>");
	return(true);
}
   function window_onload() {
       MM_preloadImages('../static/images/bsalir_on.gif','../static/images/bayuda_on.gif');
       document.all.divDetalleOrden.innerHTML = "<%=strListaOrdenSugerida%>";         
       document.ifrPageToPrint.document.all.divBody.innerHTML= "<%=strImpresionOrdenSugerida%>";
              	
       return(true);
   }
   
function cmdImprimir_onclick() {
	document.ifrPageToPrint.focus();
	window.print();
    window.close();
    return(true);
}

function cmdCerrar_onclick() {
	window.close();
    return(true);
}

//-->
			</script>
</HEAD>
<body class="bodyv" leftMargin="0" topMargin="0" onload="return window_onload()" marginwidth="0" marginheight="0">
<form name="frmCompraDirectaMostrarOrdenSugerida" action="about:blank" method="post">
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
            <td width="10">&nbsp;</td>
            <td vAlign="top" width="583"> <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                <tr> 
                  <td>&nbsp;</td>
                </tr>
                <tr> 
                  <td class="tdtablacont" vAlign="top" width="100%"> <table cellSpacing="0" cellPadding="0" width="100%" border="0">
                      <tr> 
                        <td class="tdtittablas" width="60">Proveedor:</td>
                        <td class="txcontazul" width="410"> <%=strProveedorNombreId%> 
                          &nbsp; <%=strProveedorRazonSocial%> </td>
                        <td class="txcontazul" width="200"> <script language="javascript">strGetCustomDateTime()</script> 
                        </td>
                      </tr>
                    </table>
                    <br> <span class="txsubtitulo"><IMG height="11" src="../static/images/bullet_subtitulos.gif" width="17" align="absMiddle">Detalle</span> 
                    <div id="divDetalleOrden" name="divDetalleOrden"></div>
                    <input name="cmdImprimir" type="button" class="boton" value="Imprimir Orden Sugerida" language="javascript"
													onclick="return cmdImprimir_onclick()"> 
                    <input name="cmdCerrar" type="button" class="boton" value="Cerrar" language="javascript"
													onclick="return cmdCerrar_onclick()"> 
                  </td>
                </tr>
              </table></td>
            <td class="tdcolumnader" vAlign="top" width="182" rowSpan="2">&nbsp;</td>
          </tr>
          <iframe name="ifrPageToPrint" src="ifrCompraDirectaOrdenSugerida.aspx" width="100%" height="0"
								marginheight="0" marginwidth="0"></iframe>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </tr>
  </table>
</form>
</body>
</HTML>
