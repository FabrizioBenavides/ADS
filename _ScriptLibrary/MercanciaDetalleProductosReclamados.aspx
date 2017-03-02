<%@ Import Namespace="Benavides.POSAdmin.Commons"%>
<%@ Page Language="vb" AutoEventWireup="false" EnableSessionState="False" EnableViewState="False" Explicit="True" Trace="False" Strict="True" Codebehind="MercanciaDetalleProductosReclamados.aspx.vb" Inherits="com.isocraft.backbone.ccentral.MercanciaDetalleProductosReclamados" codePage="28592"%>
<HTML>
<HEAD>
<title>Sistema Administrador de Sucursal</title>
<%
    '====================================================================
    ' Page          : MercanciaDetalleProductosReclamados.aspx
    ' Title         : Administracion POS y BackOffice
    ' Description   : Página de Detalle de productos Reclamados.
    ' Copyright     : 2003-2006 All rights reserved.
    ' Company       : Isocraft S.A. de C.V.
    ' Author        : J.Antonio Hernández Dávila
    ' Version       : 1.0
    ' Last Modified : Jueves, Octubre 30, 2003
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
function intFolioReclamacion() {
     document.write("<%=intFolioReclamacion%>");   
}
function strFechaReclamacion() {
     document.write("<%=strFechaReclamacion%>");   
}
function strDepartamentoNombre() {
	document.write("<%=strDepartamentoNombre%>");
	return(true);
}
function strProveedorReclamacion() {
     document.write("<%=strProveedorReclamacion%>");   
}
function intReclamacionNumeroDocumento(){
     document.write("<%=intReclamacionNumeroDocumento%>");   
}
function strReclamacionNumeroFactura(){
     document.write("<%=strReclamacionNumeroFactura%>");   
}
function strMotivoReclamacion(){
     document.write("<%=strMotivoReclamacion%>");   
}
function strRecordBrowserHTML(){  
     document.write("<%=strRecordBrowserHTML%>");   
}


function cmdOtro_onclick() {
    window.location = "MercanciaArchivoProductosReclamados.aspx?strConsulta=ConsultaReclamados&rdoFiltroConsulta=" + "<%=rdoFiltroConsulta%>" + "&intProveedor=" +  "<%=strProveedor%>" + "&dtmInicio=" +  "<%=dtmInicio%>" + "&dtmFin=" + "<%=dtmFin%>";
    
}

function cmdImprimir_onclick() {
   if (window.print) {
        document.ifrPageToPrint.document.all.ToPrintTxtMigaja.innerHTML=document.all.ToPrintTxtMigaja.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtFecha.innerHTML=document.all.ToPrintTxtFecha.innerText;
        document.ifrPageToPrint.document.all.ToPrintTxtSucursal.innerHTML=document.all.ToPrintTxtSucursal.innerText;
        document.ifrPageToPrint.document.all.ToPrintHtmContenido.innerHTML=document.all.ToPrintHtmContenido.innerHTML;
        
        //Mostrar Tabla de firmas
        document.ifrPageToPrint.document.all.divFirmas.style.display='';
         
        document.ifrPageToPrint.focus();
        window.print();        
    } else {
        alert("Tu navegador no soporta la función: Print.")
    }
   return(true);
}

//-->
					</script>
</HEAD>
<body leftmargin="0" topmargin="0" onLoad="return window_onload()" marginheight="0" marginwidth="0">
<form name="frmMercanciaDetalleProductosReclamados" onSubmit="return frmMercanciaDetalleProductosReclamados_onsubmit()"action="about:blank" method="post">
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
            <td width="583" class="tdmigaja"><div id="ToPrintTxtMigaja"><span class="txdmigaja">Está 
                en :</span><span class="txdmigaja"> <a href="Mercancia.aspx" class="txdmigaja">Mercancía</a> 
                : <a href="javascript:strRedireccionaPOSAdmin('MercanciaEntradas.aspx')" class="txdmigaja">Entradas</a> 
                : <a href="javascript:strRedireccionaPOSAdmin('MercanciaEntradasReclamaciones.aspx')"
												class="txdmigaja">Reclamaciones</a> 
                : </span><span class="txdmigaja">Detalle de productos reclamados</span></div></td>
            <td width="182" class="tdfechahora"> <script language="javascript">strGetCustomDateTime()</script>	
            </td>
          </tr>
          <tr> 
            <td width="10">&nbsp;</td>
            <td width="583" valign="top" class="tdtablacont"><span class="txtitulo">Detalle 
              de productos reclamados</span><span class="txcontenido">El reporte 
              de reclamación de productos que seleccionó tiene los siguientes 
              datos:</span> <script language="JavaScript">crearDatosSucursal()</script> 
              <br> <div id='ToPrintHtmContenido'> 
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                  <tr> 
                    <td width="137" class="tdtittablas">Folio de reclamación:</td>
                    <td width="446" class="tdconttablas"><script language="javascript">intFolioReclamacion()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Fecha de reclamación:</td>
                    <td class="tdconttablas"><script language="javascript">strFechaReclamacion()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Motivo:</td>
                    <td class="tdconttablas"><script language="javascript">strMotivoReclamacion()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Departamento:</td>
                    <td class="tdconttablas"><script language="javascript">strDepartamentoNombre()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Proveedor:</td>
                    <td class="tdconttablas"><script language="javascript">strProveedorReclamacion()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">Factura:</td>
                    <td class="tdconttablas"><script language="javascript">strReclamacionNumeroFactura()</script> 
                    </td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas">No. de documento:</td>
                    <td class="tdconttablas"><script language="javascript">intReclamacionNumeroDocumento()</script> 
                    </td>
                  </tr>
                </table>
                <script language="javascript">strRecordBrowserHTML()</script>
                <table id="divFirmas" style="DISPLAY:none">
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>_________________</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>_________________</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>_________________</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>_________________</td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" align="center">Nombre y Firma</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="tdtittablas" align="center">Nombre y Firma</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="tdtittablas" align="center">Nombre y Firma</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="tdtittablas" align="center">Nombre y Firma</td>
                  </tr>
                  <tr> 
                    <td class="tdtittablas" align="center">Chofer Repartidor</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="tdtittablas" align="center">Rpte. de Ventas</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="tdtittablas" align="center">Capturó Reclamación</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="tdtittablas" align="center">Gte. Sucursal</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td>&nbsp;</td>
                  </tr>
                  <tr> 
                    <td colspan="5" class="tdtittablas"> * Este documento no será 
                      válido sin el nombre y firma de autorización del representante 
                      del proveedor.* </td>
                  </tr>
                </table>
              </div>
              <br> <input name="cmdOtro" type="button" class="boton" value="Otro Detalle" onClick="return cmdOtro_onclick()"> 
              &nbsp;&nbsp;&nbsp; <input name="cmdImprimir" type="button" class="boton" value="Imprimir" onClick="return cmdImprimir_onclick()"> 
              <br> <br> </td>
            <td width="182" rowspan="2" valign="top" class="tdcolumnader">&nbsp;</td>
          </tr>
          <tr> 
            <td colspan="2" class="tdbottom"><script language="JavaScript">crearTablaFooter()</script></td>
          </tr>
        </table></td>
    </TR></TBODY>
  </TABLE>
  <script language="JavaScript">
	<!--
	new menu (MENU_ITEMS, MENU_POS);
	new menu (MENU_ITEMS2, MENU_POS2);
	//-->
			</script>
</form>
<iframe name="ifrPageToPrint" src="../static/PageToPrint.htm" width="0" height="0"></iframe>
</body>
</HTML>
